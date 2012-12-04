using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace VoucherExpense
{
    public partial class Ingredient : Form
    {
        public Ingredient(bool IsSuper)
        {
            InitializeComponent();
        }

        private void IngredientBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            VEDataSet.IngredientDataTable table = MyFunction.SaveCheck<VEDataSet.IngredientDataTable>(
                                                        this, IngredientBindingSource, vEDataSet.Ingredient);
            if (table == null) return;
            MyFunction.SetGlobalFlag(GlobalFlag.basicDataModified);

            foreach (VEDataSet.IngredientRow r in table)
            {
                if (r.RowState != DataRowState.Deleted)
                {
                    r.BeginEdit();
                    r.LastUpdated = DateTime.Now;
                    r.EndEdit();
                }
            }
            try
            {
                vEDataSet.Ingredient.Merge(table);
                this.IngredientTableAdapter.Update(this.vEDataSet.Ingredient);
                vEDataSet.Ingredient.AcceptChanges();
            }
            catch
            {
                MessageBox.Show("存檔發生錯誤,請關閉程式,重新登入！");
            }
        }

        private string m_PhotoPath = "Photos\\Ingredients\\";
        private void Ingredient_Load(object sender, EventArgs e)
        {
            accountingTitleTableAdapter.Connection  = MapPath.VEConnection;
            IngredientTableAdapter.Connection       = MapPath.VEConnection;
            accountingTitleTableAdapter.Fill(this.vEDataSet.AccountingTitle);
            IngredientTableAdapter.Fill(this.vEDataSet.Ingredient);
            MyFunction.SetFieldLength(IngredientDataGridView, vEDataSet.Ingredient);
            MyFunction.SetControlLengthFromDB(this, vEDataSet.Ingredient);
            photoPictureBox.Visible = Directory.Exists(m_PhotoPath);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyFunction.AddNewItem(IngredientDataGridView, "columnIngredientID", 
                                   "IngredientID", vEDataSet.Ingredient);
        }

        private void codeTextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel=!MyFunction.UintValidate(((TextBox )sender).Text);
        }

        private void classTextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !MyFunction.UintValidate(((TextBox)sender).Text);
        }

        private void priceTextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !MyFunction.DecimalValidate(((TextBox)sender).Text);
        }

        private void IngredientDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!MyFunction.ColumnIDGood((DataGridView)sender, "columnIngredientID", e.RowIndex))
                e.Cancel = true;
        }

        string CurrentPhotoPath()
        {
            DataRowView rowView = IngredientBindingSource.Current as DataRowView;
            VEDataSet.IngredientRow row = rowView.Row as VEDataSet.IngredientRow;
            return m_PhotoPath + row.IngredientID.ToString() + ".jpg";
        }

        Size SizeSave = new Size(0, 0);
        Point LocationSave = new Point(0, 0);

        private void IngredientBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (!photoPictureBox.Visible) return;
            if (photoPictureBox.Location.X == 0)
            {
                photoPictureBox.Location = LocationSave;
                photoPictureBox.Size = SizeSave;
            }
            string path = CurrentPhotoPath();
            if (File.Exists(path))
                photoPictureBox.ImageLocation = path;
            else
                photoPictureBox.ImageLocation = null;

        }


        bool m_VoucherDetailLoaded = false;   
        private void DeletetoolStripButton_Click(object sender, EventArgs e)
        {
            if (!this.Validate())
            {
                MessageBox.Show("有資料錯誤, 請改好再作刪除操作!");
                return;
            }
            this.IngredientBindingSource.EndEdit();
            string str = this.IngredientIDTextBox.Text.Trim();
            int ingredientID = 0;
            string name;
            try
            {
                ingredientID = Convert.ToInt32(str);
                name = nameTextBox.Text.Trim();
            }
            catch
            {
                MessageBox.Show("要刪除的食材內碼必需是數字!");
                return;
            }
            string strCodeName = "食材 <" + ingredientID.ToString() + ">"+name;
            if (MessageBox.Show("能刪除的食材必需是本年度從來沒有進過貨的\r\n按'確定', 開始載入並檢查全年度進貨單!", "刪除" + strCodeName, MessageBoxButtons.OKCancel)
                != DialogResult.OK) return;
            if (!m_VoucherDetailLoaded)
            {
                try
                {
                    voucherTableAdapter.Fill(vEDataSet.Voucher);
                    voucherDetailTableAdapter.Fill(vEDataSet.VoucherDetail);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("載入客人進貨細項時,資料庫發生錯誤:" + ex.Message);
                    return;
                }
                m_VoucherDetailLoaded = true;
            }
            foreach (VEDataSet.VoucherDetailRow row in vEDataSet.VoucherDetail)
            {
                if (row.IsIngredientIDNull()) continue;
                if (row.IngredientID == ingredientID)
                {
                    VEDataSet.VoucherRow voucher = row.VoucherRow;
                    MessageBox.Show("進貨單" + voucher.ID.ToString() + "  己經進過" + strCodeName + " 無法刪除");
                    return;
                }
            }

            if (MessageBox.Show(strCodeName + " 本年度沒有進過此貨,可以被刪除\r\n按'確定' 刪除", strCodeName, MessageBoxButtons.OKCancel) ==
                DialogResult.OK)
            {
                try
                {
                    IngredientBindingSource.RemoveCurrent();
                    IngredientTableAdapter.Update(this.vEDataSet.Ingredient);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("刪除" + strCodeName + "及存檔過程錯誤:" + ex.Message);
                    return;
                }
                MessageBox.Show("己刪除" + strCodeName + " 並存檔成功!");
                return;
            }
            MessageBox.Show("沒有刪除 " + strCodeName);

        }

        private void SavePicture()
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            string ext = Path.GetExtension(openFileDialog1.FileName).ToLower();
            if (ext != ".jpg")
            {
                MessageBox.Show("對不起!只接受jpg檔");
                return;
            }
            string path = CurrentPhotoPath();
            File.Copy(openFileDialog1.FileName, path, true);
            photoPictureBox.ImageLocation = path;
        }

        private void photoPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (!photoPictureBox.Visible) return;
            if (e.Button == MouseButtons.Right)
            {
                SavePicture();
                return;
            }
            if (LocationSave.X == 0)
            {
                SizeSave = photoPictureBox.Size;
                LocationSave = photoPictureBox.Location;
            }
            if (photoPictureBox.Location.X == 0)
            {
                photoPictureBox.Location = LocationSave;
                photoPictureBox.Size = SizeSave;
            }
            else
            {
                photoPictureBox.Location = new Point(0, 0);
                photoPictureBox.Size = this.Size;
                photoPictureBox.BringToFront();
            }

        }



     
    }
}