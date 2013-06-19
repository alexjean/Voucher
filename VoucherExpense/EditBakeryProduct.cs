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

namespace VoucherExpense
{
    public partial class EditBakeryProduct : Form
    {
        public EditBakeryProduct()
        {
            InitializeComponent();
        }

        private string m_PhotoPath = "Photos\\Products\\";
        private void AddProduct_Load(object sender, EventArgs e)
        {
            productTableAdapter.Connection  = MapPath.BakeryConnection;
            orderItemTableAdapter.Connection= MapPath.BakeryConnection;
            orderTableAdapter.Connection    = MapPath.BakeryConnection;
            this.productTableAdapter.Fill(this.bakeryOrderSet.Product);
            SetControlLengthFromDB(this, bakeryOrderSet.Product);
            photoPictureBox.Visible = Directory.Exists(m_PhotoPath);
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
            int max = (from row in bakeryOrderSet.Product select row.ProductID).Max();
            int productID=MyFunction.SetCellMaxNo("ColumnProductID",dataGridView1 ,max);
            productIDTextBox.Text = productID.ToString();
            string code=MaxNoInDGView("codeColumn", dataGridView1).ToString();
            codeTextBox.Text = code;
            nameTextBox.Text = "产品" + code;
            priceTextBox.Text = "0";
            classTextBox.Text = "1";
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
            BakeryOrderSet.ProductDataTable table = bakeryOrderSet.Product;
            foreach (BakeryOrderSet.ProductRow row in table.Rows)
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
            BakeryOrderSet.ProductDataTable table = (BakeryOrderSet.ProductDataTable)bakeryOrderSet.Product.GetChanges();
            if (table == null)
            {
                MessageBox.Show("沒有改動任何資料! 不用存");
                return;
            }
            productTableAdapter.Update(bakeryOrderSet.Product);
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
                    orderTableAdapter.Fill(bakeryOrderSet.Order);
                    orderItemTableAdapter.Fill(bakeryOrderSet.OrderItem);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("載入客人點菜細項時,資料庫發生錯誤:" + ex.Message);
                    return;
                }
                m_OrderItemLoaded = true;
            }
            foreach (BakeryOrderSet.OrderItemRow row in bakeryOrderSet.OrderItem)
            {
                if (row.IsProductIDNull()) continue;
                if (row.ProductID == productID)
                {
                    BakeryOrderSet.OrderRow order=row.OrderRow;
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
                    productTableAdapter.Update(bakeryOrderSet.Product);
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


        string CurrentPhotoPath()
        {
            DataRowView rowView = productBindingSource.Current as DataRowView;
            BakeryOrderSet.ProductRow row = rowView.Row as BakeryOrderSet.ProductRow;
            if (row.RowState == DataRowState.Detached) return "";   // 因為此時row.ProductID 會出錯
            return m_PhotoPath + row.ProductID.ToString() + ".jpg";
        }

        Size SizeSave = new Size(0, 0);
        Point LocationSave = new Point(0, 0);
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

        private void productBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            CalcGrossProfit(double.NaN, double.NaN);

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

        private void SavePicture()
        {
            DataRowView rowView = productBindingSource.Current as DataRowView;
            BakeryOrderSet.ProductRow row = rowView.Row as BakeryOrderSet.ProductRow;
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
            string path = CurrentPhotoPath();
//            File.Copy(openFileDialog1.FileName, path, true);
            try
            {
                Bitmap img = (Bitmap)(Bitmap.FromFile(openFileDialog1.FileName));
                Bitmap shrank = MyFunction.ShrinkBitmap(img, 1280,1024);    // 考量POS机螢幕,所以縮至1280*1024
                shrank.Save(path,System.Drawing.Imaging.ImageFormat.Jpeg);
                photoPictureBox.ImageLocation = path;
            }
            catch (Exception ex)
            {
                MessageBox.Show("存圖形<" + path.ToString() + ">時出錯!原因:" + ex.Message);
            }
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
                BakeryOrderSet.ProductRow row =  rowView.Row as BakeryOrderSet.ProductRow;
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