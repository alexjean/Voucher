using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace VoucherExpense
{
    public partial class FormHR : Form
    {
        public FormHR()
        {
            InitializeComponent();
        }

        private void hRBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!this.Validate())
            {
                MessageBox.Show("有資料錯誤, 請改好再存!");
                return;
            }
            this.hRBindingSource.EndEdit();    // 這行一加,現有RowState一定變成Modified (經查是photo惹的禍)
            this.hRHRDetailBindingSource.EndEdit();
            VEDataSet.HRDataTable table = (VEDataSet.HRDataTable)vEDataSet.HR.GetChanges();
            VEDataSet.HRDetailDataTable detail = (VEDataSet.HRDetailDataTable)vEDataSet.HRDetail.GetChanges();
            if (table == null && detail == null)
            {
                MessageBox.Show("沒有改動任何資料! 不用存");
                return;
            }
            // 設定修改人及修改日期
            if (table != null)
            {
                foreach (VEDataSet.HRRow r in table)
                    if (r.RowState != DataRowState.Deleted)
                    {
                        r.BeginEdit();
                        r.KeyinID = MyFunction.OperatorID;
                        r.LastUpdated = DateTime.Now;
                        r.EndEdit();
                    }
                vEDataSet.HR.Merge(table);
                try
                {
                    this.hRTableAdapter.Update(this.vEDataSet.HR);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ex:" + ex.Message);
                }
                vEDataSet.HR.AcceptChanges();
            }
            if (detail != null)
            {
                vEDataSet.HRDetail.Merge(detail);
                this.hRDetailTableAdapter.Update(vEDataSet.HRDetail);
                vEDataSet.HRDetail.AcceptChanges();
            }
        }

        private void FormHR_Load(object sender, EventArgs e)
        {
            this.operatorTableAdapter.Fill(this.vEDataSet.Operator);
            try { this.apartmentTableAdapter.Fill(this.vEDataSet.Apartment); }
            catch (Exception ex)
            { MessageBox.Show("ex:" + ex.Message); }
            try { this.hRTableAdapter.Fill(this.vEDataSet.HR); }
            catch (Exception ex)
            { MessageBox.Show("ex:" + ex.Message); }
            try { this.hRDetailTableAdapter.Fill(this.vEDataSet.HRDetail); }        
            catch(Exception ex)
            { MessageBox.Show("ex:" + ex.Message); }
            MyFunction.SetFieldLength(hRDataGridView, vEDataSet.HR);
            MyFunction.SetFieldLength(hRDetailDataGridView, vEDataSet.HRDetail);
            MyFunction.SetControlLengthFromDB(this,vEDataSet.HR);

            checkBoxShowAll.Checked = false;

            

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyFunction.AddNewItem(this.hRDataGridView, "columnEmployeeID", "EmployeeID", vEDataSet.HR);
            this.hRBindingSource.ResetBindings(false);
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result=dialog.ShowDialog();
            if (result != DialogResult.OK) return;
            string fileName = dialog.FileName;
            if (!File.Exists(fileName))
            {
                MessageBox.Show("文件不存在!");
                return;
            }
            Bitmap img = new Bitmap(fileName);
            int x = img.Size.Width;
            int y = img.Size.Height;
            int x1 = photoPictureBox.Size.Width;
            int y1 = y = y * x1 / x;
            Bitmap newbmp = new Bitmap(x1,y1);//新建一个放大后大小的图片
            double times=((double)x1)/x;
            if (times >= 1 && times <= 2)
                newbmp = img;
            else
            {
                Graphics g = Graphics.FromImage(newbmp);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(img, new Rectangle(0, 0, x1, y1), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                g.Dispose();
            }
            photoPictureBox.Image=newbmp;
            // PictureBox DataBinding時,那個DataRow的RowState不比對資料永遠是Modified,所以只好手工Binding
            DataRowView rowView = hRBindingSource.Current as DataRowView;
            VEDataSet.HRRow row = rowView.Row as VEDataSet.HRRow;
            MemoryStream stream = new MemoryStream();
            newbmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            row.Photo = stream.ToArray();
//            photoPictureBox.Image.Save("c:\\result.jpg");
        }

        private void hRDetailDataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridViewRow row = e.Row;
            row.Cells["columnDetailID"].Value = Guid.NewGuid();
        }

        string colApproved = "columnApproved";
        int iColApproved = -1;
        private void hRDetailDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow row = e.Row;
            DataGridViewCell cell=row.Cells[colApproved];
            if (cell == null)
            {
                e.Cancel = true;
                MessageBox.Show("hRDetailDataGridView找不到Cell<" + colApproved + ">,程式或資料庫版本錯誤!");
                return;
            }
            object obj=cell.Value;
            if (obj == null || obj== DBNull.Value) return;
            if ((bool)obj == false) return;
            e.Cancel = true;
            MessageBox.Show("己經核可的記錄無法刪除!");
        }

        bool NoticeCellValueChanged = false;   // 每次CellBeginEdit才設為true, CellValueChanged就重設為false
 
        private void hRDetailDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            NoticeCellValueChanged = true;
            int  iRow = e.RowIndex;
            DataGridView view = hRDetailDataGridView;
            if (iColApproved < 0)
            {
                DataGridViewColumn col = view.Columns[colApproved];
                if (col == null)
                {
                    e.Cancel = true;
                    MessageBox.Show("hRDetailDataGridView找不到Column<" + colApproved + ">,程式或資料庫版本錯誤!");
                    return;
                }
                iColApproved = col.Index;
            }
            if (e.ColumnIndex == iColApproved)   // 只有有LockHR權限的才能編
            {
                if (MyFunction.LockHR) return;
                e.Cancel = true;
                MessageBox.Show("沒有人事核定權限!");
                return;
            }
            DataGridViewRow row = view.Rows[iRow];
            DataGridViewCell cell=row.Cells[iColApproved];
            object obj = cell.Value;
            if (obj == null || obj == DBNull.Value) return;
            if ((bool)obj == false) return;
            e.Cancel = true;
            MessageBox.Show("己經核可的記錄無法編修!");
        }

        private void hRBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            // PictureBox DataBinding時,那個DataRow的RowState不比對資料永遠是Modified,所以只好手工Binding
            BindingSource source = sender as BindingSource;
            DataRowView rowView = source.Current as DataRowView;
            VEDataSet.HRRow row = rowView.Row as VEDataSet.HRRow;
            if (row == null || row.IsPhotoNull())
            {
                photoPictureBox.Image = null;
            }
            else
            {
                MemoryStream stream = new MemoryStream(row.Photo);
                Image bmp = Image.FromStream(stream);
                photoPictureBox.Image = bmp;
            }
        }

        string colEffectiveDate = "columnEffectiveDate";
        string colContent = "columnContent";
        int iColEffectiveDate = -1;
        int iColContent = -1;
        private void hRDetailDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!NoticeCellValueChanged) return;
            NoticeCellValueChanged = false;
            DataGridView view = sender as DataGridView;
            if (iColContent<0 || iColEffectiveDate<0 || iColApproved<0)
            {
                DataGridViewColumn col=view.Columns[colContent];
                if (col==null)
                {
                    MessageBox.Show("hRDetailDataGridView找不到Column<" + colContent + ">,程式或資料庫版本錯誤!");
                    return;
                }
                iColContent=col.Index;
                col=view.Columns[colEffectiveDate];
                if (col==null)
                {
                    MessageBox.Show("hRDetailDataGridView找不到Column<" + colEffectiveDate + ">,程式或資料庫版本錯誤!");
                    return;
                }
                iColEffectiveDate=col.Index;
                col = view.Columns[colApproved];
                if (col == null)
                {
                    MessageBox.Show("hRDetailDataGridView找不到Column<" + colApproved + ">,程式或資料庫版本錯誤!");
                    return;
                }
                iColApproved = col.Index;
            }
            int iCol =e.ColumnIndex;
            DataGridViewRow viewRow=view.Rows[e.RowIndex];
            DataGridViewCell cell=null;
            if (iCol == iColContent || iCol == iColEffectiveDate)   // 變更申請者,和日期
            {
                cell = viewRow.Cells["columnLastUpdated"];
                if (cell == null)
                {
                    MessageBox.Show("hRDetailDataGridView找不到Column<columnLastUpdated>,程式或資料庫版本錯誤!");
                    return;
                }
                cell.Value = DateTime.Now.ToString();
                cell = viewRow.Cells["columnApplier"];
                if (cell == null)
                {
                    MessageBox.Show("hRDetailDataGridView找不到Column<columnApplier>,程式或資料庫版本錯誤!");
                    return;
                }
                cell.Value = MyFunction.OperatorID;
            }
            else if (iCol == iColApproved)                          // 變更核可者
            {
                cell = viewRow.Cells["columnApprover"];
                if (cell == null)
                {
                    MessageBox.Show("hRDetailDataGridView找不到Column<columnApprover>,程式或資料庫版本錯誤!");
                    return;
                }
                cell.Value = MyFunction.OperatorID;

            }
        }

        private void hRDetailDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        private void checkBoxShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowAll.Checked)
                hRBindingSource.RemoveFilter();
            else 
                hRBindingSource.Filter = "InPosition";
        }

        private void birthdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker picker = sender as DateTimePicker;
            birthdayTextBox.Text = picker.Text;
        }

 
    }
}
