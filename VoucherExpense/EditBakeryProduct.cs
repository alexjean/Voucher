using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;

using MyDataSet         = VoucherExpense.DamaiDataSet;
using MyProductTable    = VoucherExpense.DamaiDataSet.ProductDataTable;
using MyProductRow      = VoucherExpense.DamaiDataSet.ProductRow;
using MyProductAdapter  = VoucherExpense.DamaiDataSetTableAdapters.ProductTableAdapter;
using MyOrderAdapter    = VoucherExpense.DamaiDataSetTableAdapters.OrderTableAdapter;
using MyOrderItemAdapter= VoucherExpense.DamaiDataSetTableAdapters.OrderItemTableAdapter;
using MyAccountingTitleAdapter = VoucherExpense.DamaiDataSetTableAdapters.AccountingTitleTableAdapter;
using System.Security.Cryptography;




namespace VoucherExpense
{
    public partial class EditBakeryProduct : Form
    {
        public EditBakeryProduct()
        {
            InitializeComponent();
        }

        private MyDataSet m_DataSet=new MyDataSet();
        MyProductAdapter productAdapter     = new MyProductAdapter();
        MyOrderAdapter   orderAdapter       = new MyOrderAdapter();
        MyOrderItemAdapter orderItemAdapter = new MyOrderItemAdapter();
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

        private void EditBakeryProduct_Load(object sender, EventArgs e)
        {
            productAdapter.Connection.ConnectionString           = DB.SqlConnectString(MyFunction.HardwareCfg);
            productClassTableAdapter.Connection.ConnectionString = DB.SqlConnectString(MyFunction.HardwareCfg);
            PhotoAdapter.Connection.ConnectionString             = DB.SqlConnectString(MyFunction.HardwareCfg);

            this.productClassTableAdapter.Fill(this.damaiDataSet.ProductClass);
            var accountingTitleAdapter = new MyAccountingTitleAdapter();
            productBindingSource.DataSource = m_DataSet;
            m_PhotoDirectoryExist = Directory.Exists(PhotoPath());


            photoPictureBox.Visible = true;
            accountingTitleBindingSource.DataSource = m_DataSet;
            accountingTitleAdapter.Fill(m_DataSet.AccountingTitle);

            productAdapter.Fill(m_DataSet.Product);
            SetControlLengthFromDB(this, m_DataSet.Product);
        }

        private void EditBakeryProduct_Shown(object sender, EventArgs e)
        {
            productBindingSource_CurrentChanged(null, null);
        }

        #region ============ Photo 相關程序 ==========================
        bool m_PhotoDirectoryExist = false;

        string PhotoPath()
        {
            return MapPath.DataDir + "Photos\\Products\\";
        }

        int CurrentPhotoID()
        {
            DataRowView rowView = productBindingSource.Current as DataRowView;
            if (rowView == null) return -1;
            var row = rowView.Row as MyProductRow;
            try
            {
                if (row.ProductID <= 0) return -1;
            }
            catch { return -1; }
            return row.ProductID;
        }

        string CurrentPhotoPath()
        {
            int id = CurrentPhotoID();
            if (id < 0) return null;
            return PhotoPath() + id.ToString() + ".jpg";
        }

        private bool ShowPhotoFile(string path)
        {
            if (!photoPictureBox.Visible) return false;
            if (path != null && File.Exists(path))
            {
                photoPictureBox.ImageLocation = path;
                return true;
            }
            else
            {
                photoPictureBox.ImageLocation = null;
                photoPictureBox.Image = null;
                return false;
            }
        }


        private void SavePicture()
        {
            DataRowView rowView = productBindingSource.Current as DataRowView;
            var row = rowView.Row as MyProductRow;
            if (row.ProductID <= 0)
            {
                MessageBox.Show("抱歉! 新增時內碼小於 0 無法存照片!\r\n請存檔後關閉產品表,再重新進入設定照片!");
                return;
            }
            DialogResult result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            string ext = Path.GetExtension(openFileDialog1.FileName).ToLower();
            if (ext != ".jpg")
            {
                MessageBox.Show("對不起!只接受jpg檔");
                return;
            }
            int productID = CurrentPhotoID();
            if (productID < 0)
            {
                MessageBox.Show("無法取得本筆產品 ProductID , 無法繼續存檔!");
                return;
            }
            var photos = from r in m_DataSet.Photos where r.PhotoID == productID && r.TableID == (int)PhotoTableID.Product select r;
            MyDataSet.PhotosRow photo=null;
            if (photos.Count() > 0) photo = photos.First();
            photo=SavePhotoFileToDB(openFileDialog1.FileName, productID,(short)PhotoTableID.Product, 240, 160, photo);
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

        private MyDataSet.PhotosRow SavePhotoFileToDB(string fileName,int id,short tableID,int width,int height,MyDataSet.PhotosRow photo) // photo==null 就新增
        {
            Cursor = Cursors.WaitCursor;
            MD5 MD5Provider = new MD5CryptoServiceProvider();
            try
            {
                Bitmap img = (Bitmap)(Bitmap.FromFile(fileName));
                Bitmap shrank = MyFunction.ShrinkBitmap(img, width,height);    // 使用SQLServer時,只存縮圖以節省網路傳輸時間, 產品統一尺寸 W240 H160
                MemoryStream stream = new MemoryStream();
                shrank.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                if (photo== null)
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
                MessageBox.Show("存產品照片<" + id.ToString() + ">時出錯!原因:" + ex.Message);
            }
            Cursor = Cursors.Arrow;
            return photo;
        }


        void TryShowPhoto(int id, short tableID, int width, int height)
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

        private void productBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            CalcGrossProfit(double.NaN, double.NaN);
            if (!photoPictureBox.Visible) return;

            int productID = CurrentPhotoID();
            TryShowPhoto(CurrentPhotoID(), (short)PhotoTableID.Product,240,160);
        }


        static public void SetControlLengthFromDB(Form form, DataTable table)
        {
            foreach (Control ctl in form.Controls)
            {
                if (!ctl.Enabled) continue;
                string str = ctl.Name;
                if (str.Contains("TextBox"))                        // 假如沒手改,預設的會有 xxxxTextBox
                {
                    TextBox textBox = (TextBox)ctl;
                    if (textBox.ReadOnly) continue;                 // 程式填資料,不管
                    if (textBox.DataBindings.Count <= 0) continue;  // 沒有Binding的Control不管
                    try                                             // 出錯就不管
                    {
                        Binding bind = textBox.DataBindings[0];
                        if (bind == null) continue;
                        string member = bind.BindingMemberInfo.BindingMember;
                        if (string.IsNullOrEmpty(member)) continue;
                        foreach (DataColumn dCol in table.Columns)
                        {
                            if (dCol.ColumnName == member)
                            {
                                string type = dCol.DataType.Name;
                                if (type == "String")
                                    textBox.MaxLength = dCol.MaxLength;
                                else if (type == "DateTime")   // 一律當做ShortDate
                                    textBox.MaxLength = 10;
                                else if (type == "Int16")
                                    textBox.MaxLength = Int16.MaxValue.ToString().Length - 1;
                                else if (type == "Int32")
                                    textBox.MaxLength = Int32.MaxValue.ToString().Length - 1;
                                else if (type == "Single")
                                    textBox.MaxLength = Single.MaxValue.ToString().Length - 1;
                                else if (type == "Double")
                                    textBox.MaxLength = Double.MaxValue.ToString().Length - 1;
                                else if (type == "Decimal")
                                    textBox.MaxLength = Decimal.MaxValue.ToString().Length - 1;
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("設定Control欄寬時出錯!" + ex.Message);
                    }
                }
            }

        }

        private int MaxNoInDGView(string cellName, DataGridView view)
        {
            int m = 0, n = 0;
            foreach (DataGridViewRow r in view.Rows)
            {
                object obj = r.Cells[cellName].Value;
                if (obj == null) continue;
                if (Convert.IsDBNull(obj)) continue;
                n = (int)obj;
                if (n > m) m = n;
            }
            return (m + 1);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
//            MyFunction.AddNewItem(dataGridView1, "ColumnProductID","ProductID", bakeryOrderSet.Product);
            int max = (from row in m_DataSet.Product select row.ProductID).Max();
            int productID=MyFunction.SetCellMaxNo("ColumnProductID",dataGridView1 ,max);
            productIDTextBox.Text = productID.ToString();
            string code=MaxNoInDGView("codeColumn", dataGridView1).ToString();
            codeTextBox.Text = code;
            nameTextBox.Text = "产品" + code;
            priceTextBox.Text = "0";
            classComboBox.SelectedValue = 1;
            menuXTextBox.Text = "-2";
            menuYTextBox.Text = "0";
        }

        private void codeTextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox box = sender as TextBox;
            string str = box.Text.Trim();
            int code=0,innerCode=0;
            try
            {
                code=Convert.ToInt32(str);
                innerCode=Convert.ToInt32(productIDTextBox.Text);
            }
            catch
            {
                MessageBox.Show("必需是數字!");
                e.Cancel = true;
                return;
            }
            if (code <= 0)  // 內部用的才能小於0
            {
                MessageBox.Show("產品代碼必需大於0!");
                e.Cancel = true;
                return;
            }
            var table = m_DataSet.Product;
            foreach (var row in table)
            {
                if (row.Code == code)
                {
                    if (row.ProductID == innerCode) continue; // 同一個產品
                    MessageBox.Show("代碼<" + code.ToString() + ">和 內碼" + row.ProductID.ToString() + "的產品重複");
                    e.Cancel = true;
                }
            }
        }

        private void priceTextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox box = (TextBox)sender;
            double price = 0;
            try{
                price = Convert.ToDouble(box.Text);
            }
            catch{
                MessageBox.Show("價格必需是數字!");
                e.Cancel = true;
                return;
            }
            CalcGrossProfit(price, double.NaN);
        }

        private void CalcGrossProfit(double price, double cost)
        {
            if (double.NaN.Equals(cost))
            {
                try
                {
                    cost = Convert.ToDouble(evaluatedCostTextBox.Text);
                }
                catch { cost = 0; }
            }
            if (double.NaN.Equals(price))
            {
                try
                {
                    price = Convert.ToDouble(priceTextBox.Text);
                }
                catch { price = 0; }
            }

            double gross = price - cost;
            grossTextBox.Text = gross.ToString("f2");
            if (price != 0)
                grossPercentTextBox.Text = ((gross / price) * 100).ToString("f1")+"%";
            else
                grossPercentTextBox.Text = "--.-%";
        }

        private void evaluatedCostTextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox box = (TextBox)sender;
            double cost = 0;
            try
            {
                cost = Convert.ToDouble(box.Text);
            }
            catch
            {
                MessageBox.Show("成本必需是數字!");
                e.Cancel = true;
                return;
            }
            CalcGrossProfit(double.NaN, cost);
        }

        private void 儲存SToolStripButton_Click(object sender, EventArgs e)
        {
            if (!this.Validate())
            {
                MessageBox.Show("有資料錯誤, 請改好再存!");
                return;
            }
            productBindingSource.EndEdit();
            var table = (MyProductTable)m_DataSet.Product.GetChanges();
            if (table == null)
            {
                MessageBox.Show("沒有改動任何資料! 不用存");
                return;
            }
            productAdapter.Update(m_DataSet.Product);
            MessageBox.Show(table.Rows.Count.ToString()+"筆有改動,己存檔!");
        }


        bool m_OrderItemLoaded = false;
        private void DeletetoolStripButton_Click(object sender, EventArgs e)
        {
            if (!this.Validate())
            {
                MessageBox.Show("有資料錯誤, 請改好再作刪除操作!");
                return;
            }
            productBindingSource.EndEdit();
            string str = this.productIDTextBox.Text.Trim();
            int productID = 0;
            string name;
            try
            {
                productID = Convert.ToInt32(str);
                name = nameTextBox.Text.Trim();
            }
            catch
            {
                MessageBox.Show("要刪除的產品內碼必需是數字!");
                return;
            }
            string strCode="產品 <"+productID.ToString()+">";
            if (MessageBox.Show("能刪除的產品必需是本年度從來沒有被客人點過的\r\n按'確定', 開始載入並檢查全年度點菜單!", "刪除"+strCode+name, MessageBoxButtons.OKCancel)
                != DialogResult.OK) return;
            if (!m_OrderItemLoaded)
            {
                try
                {
                    orderAdapter.Fill(m_DataSet.Order);
                    orderItemAdapter.Fill(m_DataSet.OrderItem);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("載入客人點菜細項時,資料庫發生錯誤:" + ex.Message);
                    return;
                }
                m_OrderItemLoaded = true;
            }
            foreach (var row in m_DataSet.OrderItem)
            {
                if (row.IsProductIDNull()) continue;
                if (row.ProductID == productID)
                {
                    var order=row.OrderRow;
                    MessageBox.Show("點菜單"+order.ID.ToString()+"  己經點了"+strCode+" 無法刪除");
                    return;
                }
            }

            if (MessageBox.Show(strCode+" 本年度沒有人點過,可以被刪除\r\n按'確定' 刪除",strCode,MessageBoxButtons.OKCancel)==
                DialogResult.OK)
            {
                try
                {
                    productBindingSource.RemoveCurrent();
                    productAdapter.Update(m_DataSet.Product);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("刪除"+strCode+"及存檔過程錯誤:" + ex.Message);
                    return;
                }
                MessageBox.Show("己刪除" + strCode + name + " 並存檔成功!");
                return;
            }
            MessageBox.Show("沒有刪除 " + strCode + name);
        }



        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.Application excel;
            Excel.Worksheet sheet;
            Excel.Workbook book;
            try
            {
                excel = new Excel.Application();
                book = excel.Application.Workbooks.Add(true);
                sheet = book.Worksheets[1];
                sheet.Name = MyFunction.HeaderYear + "產品表";
            }
            catch (Exception ex)
            {
                MessageBox.Show("開啟Excel出錯,原因:" + ex.Message);
                return;
            }
            excel.Visible = true;
            DataGridView view = this.dataGridView1;
            int i = 1;
            // 插入Logo圖片
            int imgHeight = 48;
            Excel.Range range;
            range = sheet.Rows[1];
            range.RowHeight = imgHeight + 2;
            Bitmap img = MyFunction.GetThumbnail(global::VoucherExpense.Properties.Resources.LogoVI, imgHeight * 4 / 3);   // 一般圖是96DPI,換算就是4pixels=3單位
            range = sheet.Cells[1, 1];
            Clipboard.SetDataObject(img, true);
            sheet.Paste(range, "LogoVI");



            //欄位表頭
            i++;

            sheet.Cells[i, 1] = "代碼";
            range = sheet.Columns[1];
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            range.ColumnWidth = 10;

            sheet.Cells[i, 2] = "品名";
            range = sheet.Columns[2];
            range.ColumnWidth = 25;

            sheet.Cells[i, 3] = "價格";
            range = sheet.Columns[3];
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
            range.ColumnWidth = 15;
            range.NumberFormat = "#,##0.0";

            sheet.Cells[i, 4] = "成本";
            range = sheet.Columns[4];
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
            range.ColumnWidth = 10;
            range.NumberFormat = "#,##0.00";    // "0.00";

            sheet.Cells[i, 5] = "毛利";
            range = sheet.Columns[5];
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
            range.ColumnWidth = 10;
            range.NumberFormat = "#,##0.00";

            sheet.Cells[i, 6] = "毛利率";
            range = sheet.Columns[6];
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
            range.ColumnWidth = 10;
            range.NumberFormat = "#00.0%";


            range = sheet.Cells[1, 6];                                 // 放在 sheet.Columns[6] 後面再設
            sheet.Cells[1, 6] = DateTime.Now.ToShortDateString();
            range.NumberFormat = "yyyy/mm/dd";

            range = sheet.Cells[1, 3];                                 // 放在sheet.Columns[3] 後面再設,要不然會被蓋 
            sheet.Cells[1, 3] = sheet.Name;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.Select();



            i++;
            string strRange = "F" + i.ToString() + ":F";
            foreach (DataGridViewRow vr in view.Rows)
            {
                DataRowView rowView = vr.DataBoundItem as DataRowView;
                var row =  rowView.Row as MyProductRow;
                if (row.Code <= 0) continue;   // 系統內用的不轉Excel
                string strI = i.ToString();
                sheet.Cells[i, 1] = vr.Cells[1].FormattedValue;         // 代碼
                sheet.Cells[i, 2] = "'" + vr.Cells[3].FormattedValue;   // 品名
                sheet.Cells[i, 3] = vr.Cells[4].FormattedValue;         // 價格
                sheet.Cells[i, 4] = vr.Cells[6].FormattedValue;         // 成本
                sheet.Cells[i, 5] = "=C"+strI+"-D"+strI;                // 毛利
                sheet.Cells[i, 6] = "=E"+strI+"/C"+strI;                // 毛利率

                //DataRowView rowView = vr.DataBoundItem as DataRowView;
                //VEDataSet.ExpenseRow row =  rowView.Row as VEDataSet.ExpenseRow;
                //if (!row.IsInnerIDNull())   sheet.Cells[i, 1] = row.InnerID;
                //                            sheet.Cells[i, 2] = row.ApplyTime;
                //if (!row.IsNoteNull())      sheet.Cells[i, 3] = row.Note;
                //if (!row.IsTitleCodeNull()) sheet.Cells[i, 4] = "'"+row.TitleCode.ToString();
                //if (!row.IsMoneyNull())     sheet.Cells[i, 5] = row.Money;
                //if (!row.IsApplierIDNull())
                //{
                //    sheet.Cells[i, 6] = row.ApplierID;
                //}
                i++;
            }
            sheet.Cells[i, 5] = "品項計";
            sheet.Cells[i, 6] = "平均毛利";
            sheet.Cells[i++, 2] = "'===================================================";
            
            strRange+=(i-2).ToString();
            Excel.Range rangeCount = sheet.Cells[i, 5];
            rangeCount.NumberFormat = "###0";
            sheet.Cells[i  , 5] = "=Count("+strRange+")";
            sheet.Cells[i  , 6] = "=Sum(" + strRange + ")/E"+i.ToString();
            excel.Quit();

        }

  
    }
}