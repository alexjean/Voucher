using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

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
//            VEDataSet.IngredientDataTable table = MyFunction.SaveCheck<VEDataSet.IngredientDataTable>(this, IngredientBindingSource, vEDataSet.Ingredient);
            if (!this.Validate())
            {
                MessageBox.Show("有資料錯誤, 請改好再存!");
                return;
            }
            IngredientBindingSource.EndEdit();     // 執行此行時,若無問題 RowState.Detached => RowState.Added
            VEDataSet.IngredientDataTable table = (VEDataSet.IngredientDataTable)vEDataSet.Ingredient.GetChanges();
            if (table == null)
            {
                MessageBox.Show("沒有改動任何資料! 不用存");
                return;
            }
            if (table == null) return;
            MyFunction.SetGlobalFlag(GlobalFlag.basicDataModified);

            foreach (VEDataSet.IngredientRow r in table)
            {
                if (r.RowState != DataRowState.Deleted)
                {
                    r.BeginEdit();
                    //if (r.IsTitleCodeNull()) r.TitleCode = "";
                    //if (r.IsVendorIDNull()) r.VendorID = 0;
                    //if (r.IsCanPurchaseNull()) r.CanPurchase = true;
                    //if (r.IsClassNull()) r.Class = 0;
                    //if (r.IsCodeNull()) r.Code = 0;
                    //if (r.IsMinOrderNull()) r.MinOrder = "";
                    //if (r.IsNameNull()) r.Name = "";
                    //if (r.IsPriceNull()) r.Price = 0;
                    //if (r.IsSpecsNull()) r.Specs = "";
                    //if (r.IsUnitNull()) r.Unit = "";
                    //if (r.IsUnitWeightNull()) r.UnitWeight = 0;
                    r.LastUpdated = DateTime.Now;
                    r.EndEdit();
                }
            }
            try
            {
//                this.IngredientTableAdapter.Update(table);
                vEDataSet.Ingredient.Merge(table); 
                this.IngredientTableAdapter.Update(this.vEDataSet.Ingredient);
                vEDataSet.Ingredient.AcceptChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show("錯誤原因:"+ex.Message+"\r\n存檔發生錯誤,請關閉程式,重新登入！");
            }
        }

        private string m_PhotoPath = "Photos\\Ingredients\\";
        private List<CNameIDForComboBox> m_VendorList = new List<CNameIDForComboBox>();
        private void Ingredient_Load(object sender, EventArgs e)
        {
            vendorTableAdapter.Connection           = MapPath.VEConnection;
            accountingTitleTableAdapter.Connection  = MapPath.VEConnection;
            IngredientTableAdapter.Connection       = MapPath.VEConnection;
            try
            {
                vendorTableAdapter.Fill         (this.vEDataSet.Vendor);
                m_VendorList.Add(new CNameIDForComboBox(0, ""));                                // 提到 .Fill(vEdataSet.Ingredient)之前,要不然第一次 BindingSource.CurrentChanged會先發生
                foreach (VEDataSet.VendorRow vendor in vEDataSet.Vendor)
                    m_VendorList.Add(new CNameIDForComboBox(vendor.VendorID, vendor.Name));
                vendorIDComboBox.DataSource = m_VendorList;
                //vendorIDComboBox.ValueMember = "ID";
                //vendorIDComboBox.DisplayMember = "Name";
                accountingTitleTableAdapter.Fill(this.vEDataSet.AccountingTitle);
                IngredientTableAdapter.Fill     (this.vEDataSet.Ingredient);
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤:" + ex.Message);
            }
           
            MyFunction.SetFieldLength(dgvIngredient, vEDataSet.Ingredient);
            MyFunction.SetControlLengthFromDB(this, vEDataSet.Ingredient);
            photoPictureBox.Visible = Directory.Exists(m_PhotoPath);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
//            MyFunction.AddNewItem(dgvIngredient, "columnIngredientID","IngredientID", vEDataSet.Ingredient);
            IngredientBindingSource.AddNew();
            int max = (from ro in vEDataSet.Ingredient select ro.IngredientID).Max();
            int ingredientID = MyFunction.SetCellMaxNo("columnIngredientID", dgvIngredient, max);
            
            // 因為供應商資料沒有ValueMember啟始值,只Binding了SelectedValue
            // 所以後來 BindingSource.EndEdit時,無法成功==> RowState還是Detached,永遠無法改


            // 測試方案1:硬上,自己加.   EditBakeryProduct.cs的處理方式比較文明, 每個Field都在螢幕上填值
            //DataRowView rowView = (DataRowView)IngredientBindingSource.Current;
            //VEDataSet.IngredientRow row = (VEDataSet.IngredientRow)rowView.Row;
            //if (row.RowState == DataRowState.Detached)
            //    vEDataSet.Ingredient.Rows.Add(row);        
        }

        bool m_ShowValidatingWarning = true;
        private void codeTextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel=!MyFunction.UintValidate(((TextBox )sender).Text);
            if (m_ShowValidatingWarning && e.Cancel)
                MessageBox.Show("代号必需是正整數!");
        }

        private void classTextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !MyFunction.UintValidate(((TextBox)sender).Text);
            if (m_ShowValidatingWarning && e.Cancel)
                MessageBox.Show("代号必需是正整數!");
        }

        private void priceTextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !MyFunction.DecimalValidate(((TextBox)sender).Text);
            if (m_ShowValidatingWarning && e.Cancel)
                MessageBox.Show("價格必需是Decimal!");
        }

        private void IngredientDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!MyFunction.ColumnIDGood((DataGridView)sender, "columnIngredientID", e.RowIndex))
                e.Cancel = true;
            if (m_ShowValidatingWarning && e.Cancel)
                MessageBox.Show("DataGridView的<食材內碼>不正確!");
        }

        string CurrentPhotoPath()
        {
            DataRowView rowView = IngredientBindingSource.Current as DataRowView;
            if (rowView == null) return null;
            VEDataSet.IngredientRow row = rowView.Row as VEDataSet.IngredientRow;
            if (row.RowState == DataRowState.Detached)
            {
                try
                {
                    if (row.IngredientID <= 0) return null;
                }
                catch 
                {
                    return null;
                }
            }
            return m_PhotoPath + row.IngredientID.ToString() + ".jpg";
        }

        Size SizeSave = new Size(0, 0);
        Point LocationSave = new Point(0, 0);

        private void IngredientBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (m_VendorList != null && m_VendorList.Count > 0)
            {
                DataRowView rowView = IngredientBindingSource.Current as DataRowView;
                VEDataSet.IngredientRow row = rowView.Row as VEDataSet.IngredientRow;
                CNameIDForComboBox vendor = m_VendorList[0];    // 第一個放的是ID=0 Name ""
                if (!row.IsVendorIDNull())
                {
                    int id = row.VendorID;
                    foreach (CNameIDForComboBox v in m_VendorList)
                    {
                        if (id == v.ID)
                        {
                            vendor = v;
                            break;
                        }
                    }
                }
                vendorIDComboBox.SelectedItem = vendor;
            }
            CalcCostPerGram();
            if (!photoPictureBox.Visible) return;
            if (photoPictureBox.Location.X == 0)
            {
                photoPictureBox.Location = LocationSave;
                photoPictureBox.Size = SizeSave;
            }
            string path = CurrentPhotoPath();
            if (path!=null && File.Exists(path))
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
            if (path == null) return;
//            File.Copy(openFileDialog1.FileName, path, true);
            try
            {
                Bitmap img = (Bitmap)(Bitmap.FromFile(openFileDialog1.FileName));
                Bitmap shrank = MyFunction.ShrinkBitmap(img, 1280, 1024);    // 考量POS机螢幕,所以縮至1280*1024
                shrank.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                photoPictureBox.ImageLocation = path;
            }
            catch (Exception ex)
            {
                MessageBox.Show("存圖形<" + path.ToString() + ">時出錯!原因:" + ex.Message);
            }
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

        private void vendorIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box=sender as ComboBox;
            var rowView = IngredientBindingSource.Current as DataRowView;
            var row     = rowView.Row as VEDataSet.IngredientRow;
            object obj = box.SelectedItem;
            if (obj != null && obj != DBNull.Value)
            {
                CNameIDForComboBox nameId = obj as CNameIDForComboBox;
                row.VendorID = nameId.ID;
            }
        }

        private void Ingredient_Shown(object sender, EventArgs e)
        {
            CalcCostPerGram();
            vendorIDComboBox.SelectedIndexChanged += this.vendorIDComboBox_SelectedIndexChanged;    // 這裏才加,避免第一個Record VendorID被清0
        }

        void CalcCostPerGram()
        {
            decimal unitWeight;
            if (decimal.TryParse(unitWeightTextBox.Text.Trim(), out unitWeight) && unitWeight > 0)
            {
                decimal cost = 0;
                decimal.TryParse(this.priceTextBox.Text.Trim(), out cost);
                decimal costPerGram = cost / unitWeight;
                textBoxCostPerGram.Text = costPerGram.ToString("f3")+"元/克";
            }
            else
                textBoxCostPerGram.Text = "";
        }

        private void unitWeightTextBox_Validated(object sender, EventArgs e)
        {
            CalcCostPerGram();
        }

        private void priceTextBox_Validated(object sender, EventArgs e)
        {
            CalcCostPerGram();
        }

        private void Ingredient_FormClosing(object sender, FormClosingEventArgs e)
        {
//          搶先在BindingSource被Dispose前,把DataGridView Dispose,否則Win8下先Dispose BindingSource會DataError 
            dgvIngredient.Visible=false;
        }

        private void IngredientDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            MessageBox.Show("IngredientDataGridView 第" + e.RowIndex.ToString() + "行" +
                  e.ColumnIndex.ToString() + "列,錯誤:" + e.Exception.Message);
        }

    }
}