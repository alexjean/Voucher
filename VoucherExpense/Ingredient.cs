using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using MyDataSet             = VoucherExpense.DamaiDataSet;
using MyIngredientRow       = VoucherExpense.DamaiDataSet.IngredientRow;
using MyIngredientTable     = VoucherExpense.DamaiDataSet.IngredientDataTable;
using MyIngredientAdapter   = VoucherExpense.DamaiDataSetTableAdapters.IngredientTableAdapter;
using MyVoucherAdapter      = VoucherExpense.DamaiDataSetTableAdapters.VoucherTableAdapter;
using MyVoucherDetailAdapter= VoucherExpense.DamaiDataSetTableAdapters.VoucherDetailTableAdapter;
using System.Security.Cryptography;

namespace VoucherExpense
{
    public partial class Ingredient : Form
    {
        public Ingredient(bool IsSuper)
        {
            InitializeComponent();
        }

        MyDataSet m_DataSet = new MyDataSet();

        private List<CNameIDForComboBox> m_VendorList = new List<CNameIDForComboBox>();

        MyIngredientAdapter IngredientAdapter       = new MyIngredientAdapter();
        MyVoucherAdapter VoucherAdapter = new MyVoucherAdapter();
        MyVoucherDetailAdapter VoucherDetailAdapter = new MyVoucherDetailAdapter();


        private void Ingredient_Load(object sender, EventArgs e)
        {
            IngredientBindingSource.DataSource = m_DataSet;
            vendorBindingSource.DataSource = m_DataSet;
            accountingTitleBindingSource.DataSource = m_DataSet;
            m_PhotoDirectoryExist = Directory.Exists(PhotoPath());
            photoPictureBox.Visible = true;
            var vendorAdapter = new DamaiDataSetTableAdapters.VendorTableAdapter();
            var accountingTitleAdapter = new DamaiDataSetTableAdapters.AccountingTitleTableAdapter();

            IngredientAdapter.Connection.ConnectionString = DB.SqlConnectString(MyFunction.HardwareCfg);
            vendorAdapter.Connection.ConnectionString = DB.SqlConnectString(MyFunction.HardwareCfg);

            try
            {
                vendorAdapter.Fill         (m_DataSet.Vendor);
                m_VendorList.Add(new CNameIDForComboBox(0, ""));                                // 提到 .Fill(vEdataSet.Ingredient)之前,要不然第一次 BindingSource.CurrentChanged會先發生
                foreach (var vendor in m_DataSet.Vendor)
                    m_VendorList.Add(new CNameIDForComboBox(vendor.VendorID, vendor.Name));
                vendorIDComboBox.DataSource = m_VendorList;
                //vendorIDComboBox.ValueMember = "ID";
                //vendorIDComboBox.DisplayMember = "Name";
                accountingTitleAdapter.Fill(m_DataSet.AccountingTitle);
                IngredientAdapter.Fill     (m_DataSet.Ingredient);
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤:" + ex.Message);
            }

            MyFunction.SetFieldLength(dgvIngredient, m_DataSet.Ingredient);
            MyFunction.SetControlLengthFromDB(this, m_DataSet.Ingredient);
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
            var table = (MyIngredientTable)m_DataSet.Ingredient.GetChanges();
            if (table == null)
            {
                MessageBox.Show("沒有改動任何資料! 不用存");
                return;
            }
            if (table == null) return;
            MyFunction.SetGlobalFlag(GlobalFlag.basicDataModified);

            foreach (var r in table)
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
                m_DataSet.Ingredient.Merge(table);
                this.IngredientAdapter.Update(m_DataSet.Ingredient);
                m_DataSet.Ingredient.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤原因:" + ex.Message + "\r\n存檔發生錯誤,請關閉程式,重新登入！");
            }
        }


        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
//            MyFunction.AddNewItem(dgvIngredient, "columnIngredientID","IngredientID", vEDataSet.Ingredient);
            IngredientBindingSource.AddNew();
            int max = (from ro in m_DataSet.Ingredient select ro.IngredientID).Max();
            int ingredientID = MyFunction.SetCellMaxNo("columnIngredientID", dgvIngredient, max);
            
            // 因為供應商資料沒有ValueMember啟始值,只Binding了SelectedValue
            // 所以後來 BindingSource.EndEdit時,無法成功==> RowState還是Detached,永遠無法改


            // 測試方案1:硬上,自己加.   EditBakeryProduct.cs的處理方式比較文明, 每個Field都在螢幕上填值
            //DataRowView rowView = (DataRowView)IngredientBindingSource.Current;
            //VEDataSet.IngredientRow row = (VEDataSet.IngredientRow)rowView.Row;
            //if (row.RowState == DataRowState.Detached)
            //    vEDataSet.Ingredient.Rows.Add(row);        

            DataRowView rowView = (DataRowView)IngredientBindingSource.Current;
            var row = (MyIngredientRow)rowView.Row;
            row.CanPurchase = true;

        }

        bool m_ShowValidatingWarning = true;
        private void codeTextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel=!MyFunction.UintValidate(((TextBox )sender).Text);
            if (m_ShowValidatingWarning && e.Cancel)
                MessageBox.Show("代号必需是正整數!");
        }

        //private void classTextBox_Validating(object sender, CancelEventArgs e)
        //{
        //    e.Cancel = !MyFunction.UintValidate(((TextBox)sender).Text);
        //    if (m_ShowValidatingWarning && e.Cancel)
        //        MessageBox.Show("代号必需是正整數!");
        //}

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

        #region ============ Photo相關程序 ====================================
        bool m_PhotoDirectoryExist = false;
        public class MyPhotoAdapter : DamaiDataSetTableAdapters.PhotosTableAdapter
        {
            string SaveStr;
            public int FillBySelectStr(DamaiDataSet.PhotosDataTable dataTable, string SelectStr)
            {
                ClearBeforeFill = false;
                SaveStr = base.CommandCollection[0].CommandText;
                base.CommandCollection[0].CommandText = SelectStr;
                int result = Fill(dataTable);
                base.CommandCollection[0].CommandText = SaveStr;
                return result;
            }
        }
        MyPhotoAdapter PhotoAdapter = new MyPhotoAdapter();

        string PhotoPath() { return MapPath.DataDir + "Photos\\Ingredients\\";  }

        int CurrentPhotoID()
        {
            DataRowView rowView = IngredientBindingSource.Current as DataRowView;
            if (rowView == null) return -1;
            var row = rowView.Row as MyIngredientRow;
            try
            {
                if (row.IngredientID <= 0) return -1;
            }
            catch { return -1; }
            return row.IngredientID;
        }
        string CurrentPhotoPath()
        {
            int id = CurrentPhotoID();
            if (id < 0) return null;
            return PhotoPath() + id.ToString() + ".jpg";
        }

        bool ShowPhotoFile(string path)
        {
            if (!photoPictureBox.Visible) return false;
            if (path != null && File.Exists(path))
            {
                photoPictureBox.ImageLocation = path;
                return true;
            }
            else
            {
                photoPictureBox.Image = null;
                photoPictureBox.ImageLocation = null;
                return false;
            }
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
            int ingredientID = CurrentPhotoID();
            if (ingredientID < 0)
            {
                MessageBox.Show("無法取得本筆食材 IngredientID , 無法繼續存檔!");
                return;
            }
            var photos = from r in m_DataSet.Photos where r.PhotoID == ingredientID && r.TableID == (short)PhotoTableID.Ingredient select r;
            MyDataSet.PhotosRow photo = null;
            if (photos.Count() > 0) photo = photos.First();
            photo=SavePhotoFileToDB(openFileDialog1.FileName, ingredientID, (short)PhotoTableID.Ingredient, 240, 240, photo);
            ShowPhotoDB(photo);

        }

        private void photoPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (!photoPictureBox.Visible) return;
            if (e.Button == MouseButtons.Right)
            {
                SavePicture();
                return;
            }

        }

        void ShowPhotoDB(MyDataSet.PhotosRow row)
        {
            if (row == null || row.IsPhotoNull()) return;
            MemoryStream stream = new MemoryStream(row.Photo);
            Image bmp = Image.FromStream(stream);
            photoPictureBox.Image = bmp;
        }

        private MyDataSet.PhotosRow SavePhotoFileToDB(string fileName, int id, short tableID, int width, int height, MyDataSet.PhotosRow photo) // photo==null 就新增
        {
            Cursor = Cursors.WaitCursor;
            MD5 MD5Provider = new MD5CryptoServiceProvider();
            try
            {
                Bitmap img = (Bitmap)(Bitmap.FromFile(fileName));
                Bitmap shrank = MyFunction.ShrinkBitmap(img, width, height);    // 使用SQLServer時,只存縮圖以節省網路傳輸時間, 產品統一尺寸 W240 H160
                MemoryStream stream = new MemoryStream();
                shrank.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                if (photo == null)
                {
                    photo = m_DataSet.Photos.NewPhotosRow();
                    photo.TableID = tableID;
                    photo.PhotoID = id;
                    photo.Photo = stream.ToArray();
                    photo.UpdatedTime = DateTime.Now;
                    photo.MD5 = MD5Provider.ComputeHash(photo.Photo);
                    m_DataSet.Photos.AddPhotosRow(photo);
                }
                else
                {
                    photo.Photo = stream.ToArray();
                    photo.UpdatedTime = DateTime.Now;
                    photo.MD5 = MD5Provider.ComputeHash(photo.Photo);
                }
                PhotoAdapter.Update(m_DataSet.Photos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("存食材照片<" + id.ToString() + ">時出錯!原因:" + ex.Message);
            }
            Cursor = Cursors.Arrow;
            return photo;
        }


        void TryShowPhoto(int id, short tableID, string name, int width, int height)
        {
            if (id < 0) return;
            // 先找m_DataSet裏有沒有
            var photos = from r in m_DataSet.Photos where r.PhotoID == id && r.TableID == tableID select r;
            if (photos.Count() <= 0)
            {
                // 再從資料庫找找看
                string sqlStr = "Select * From Photos Where PhotoID=" + id.ToString() + "And TableID=" + tableID.ToString();
                int n = PhotoAdapter.FillBySelectStr(m_DataSet.Photos, sqlStr);
                photos = from r in m_DataSet.Photos where r.PhotoID == id && r.TableID == tableID select r;
                if (photos.Count() > 0)
                {
                    ShowPhotoDB(photos.First());
                    return;
                }
                if (!m_PhotoDirectoryExist)
                {
                    photoPictureBox.Image = null;
                    return;
                }
                // 照片資料庫中不存在,找找當前目錄中有沒有
                string path = CurrentPhotoPath();
                if (!ShowPhotoFile(path)) return;    // 若有圖,就存到資料庫中
                SavePhotoFileToDB(path, id, tableID, width, height, null);
                return;
            }
            else
            {
                var photo = photos.First();
                ShowPhotoDB(photo);
                if (photo.IsMD5Null())
                {
                    MD5 Md5Provider = new MD5CryptoServiceProvider();
                    try
                    {
                        photo.MD5 = Md5Provider.ComputeHash(photo.Photo);
                        PhotoAdapter.Update(photo);
                    }
                    catch { }
                }
            }
        }
        #endregion

        private void IngredientBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (m_VendorList != null && m_VendorList.Count > 0)
            {
                DataRowView rowView = IngredientBindingSource.Current as DataRowView;
                var row = rowView.Row as MyIngredientRow;
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
            // 手動載入Photo
            if (!photoPictureBox.Visible) return;
            TryShowPhoto(CurrentPhotoID(), (int)PhotoTableID.Ingredient, "食材", 240, 240);
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
                    VoucherAdapter.Fill(m_DataSet.Voucher);
                    VoucherDetailAdapter.Fill(m_DataSet.VoucherDetail);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("載入客人進貨細項時,資料庫發生錯誤:" + ex.Message);
                    return;
                }
                m_VoucherDetailLoaded = true;
            }
            foreach (var row in m_DataSet.VoucherDetail)
            {
                if (row.IsIngredientIDNull()) continue;
                if (row.IngredientID == ingredientID)
                {
                    var voucher = row.VoucherRow;
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
                    IngredientAdapter.Update(m_DataSet.Ingredient);
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



        private void vendorIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box=sender as ComboBox;
            var rowView = IngredientBindingSource.Current as DataRowView;
            var row     = rowView.Row as MyIngredientRow;
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