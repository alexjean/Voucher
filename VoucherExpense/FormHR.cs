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
            this.hRBindingSource.EndEdit();
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
            this.operatorTableAdapter.Fill(this.vEDataSet1.Operator);
            try { this.apartmentTableAdapter.Fill(this.vEDataSet.Apartment); }
            catch (Exception ex)
            { MessageBox.Show("ex:" + ex.Message); }
            try { this.hRDetailTableAdapter.Fill(this.vEDataSet.HRDetail); }        
            catch(Exception ex)
            { MessageBox.Show("ex:" + ex.Message); }
            try { this.hRTableAdapter.Fill(this.vEDataSet.HR); }
            catch (Exception ex)
            { MessageBox.Show("ex:" + ex.Message); }
            MyFunction.SetFieldLength(hRDataGridView, vEDataSet.HR);
            MyFunction.SetFieldLength(hRDetailDataGridView, vEDataSet.HRDetail);
            MyFunction.SetControlLengthFromDB(this,vEDataSet.HR);

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
            Bitmap newbm = new Bitmap(x1,y1);//新建一个放大后大小的图片
            double times=((double)x1)/x;
            if (times >= 1 && times <= 2)
                newbm = img;
            else
            {
                Graphics g = Graphics.FromImage(newbm);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(img, new Rectangle(0, 0, x1, y1), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                g.Dispose();
            }
            photoPictureBox.Image=newbm;
//            photoPictureBox.Image.Save("c:\\result.jpg");
        }

        private void hRDetailDataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridViewRow row = e.Row;
            row.Cells["columnDetailID"].Value = Guid.NewGuid();
        }

        string colApproved = "columnApproved";
        private void hRDetailDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow row = e.Row;

            object obj=row.Cells[colApproved].Value;
            if (obj == null || obj== DBNull.Value) return;
            if ((bool)obj == false) return;
            e.Cancel = true;
            MessageBox.Show("己經核可的記錄無法刪除!");
        }

        private void hRDetailDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int  iRow = e.RowIndex;
            DataGridView view = hRDetailDataGridView;
            object obj = view.Rows[iRow].Cells[colApproved].Value;
            if (obj == null || obj == DBNull.Value) return;
            if ((bool)obj == false) return;
            e.Cancel = true;
            MessageBox.Show("己經核可的記錄無法編修!");
        }
    }
}
