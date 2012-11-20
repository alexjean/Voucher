using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace VoucherExpense

{
    public partial class EditBasicProduct : Form
    {
        public EditBasicProduct()
        {
            InitializeComponent();
        }

        private string m_PhotoPath = "Photos\\Products\\";
        private void EditBasicProduct_Load(object sender, EventArgs e)
        {
            productTableAdapter.Connection  = MapPath.BasicConnection;
            orderItemTableAdapter.Connection= MapPath.BasicConnection;
            orderTableAdapter.Connection    = MapPath.BasicConnection;
            try
            {
                this.productTableAdapter.Fill(this.basicDataSet.Product);
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入餐飲產品表時出錯:" + ex.Message);
                return;
            }
            SetControlLengthFromDB(this, basicDataSet.Product);
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
            BasicDataSet.ProductDataTable table = basicDataSet.Product;
            foreach (BasicDataSet.ProductRow row in table.Rows)
            {
                if (row.Code == code)
                {
                    if (row.ProductID == innerCode) continue; // 同一個產品
                    MessageBox.Show("代碼<" + code.ToString() + ">和 " + row.ProductID.ToString() + "行的重複");
                    e.Cancel = true;
                }
            }
        }

        private void priceTextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox box = (TextBox)sender;
            double price = 0;
            try
            {
                price = Convert.ToDouble(box.Text);
            }
            catch
            {
                MessageBox.Show("價格必需是數字!");
                e.Cancel = true;
            }
        }

        private void 儲存SToolStripButton_Click(object sender, EventArgs e)
        {
            if (!this.Validate())
            {
                MessageBox.Show("有資料錯誤, 請改好再存!");
                return;
            }
            productBindingSource.EndEdit();
            BasicDataSet.ProductDataTable table = (BasicDataSet.ProductDataTable)basicDataSet.Product.GetChanges();
            if (table == null)
            {
                MessageBox.Show("沒有改動任何資料! 不用存");
                return;
            }
            productTableAdapter.Update(basicDataSet.Product);
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
                MessageBox.Show("要刪除的產品代碼必需是數字!");
                return;
            }
            string strProductID="產品 <"+productID.ToString()+">";
            if (MessageBox.Show("能刪除的產品必需是本年度從來沒有被客人點過的\r\n按'確定', 開始載入並檢查全年度點菜單!", "刪除"+strProductID+name, MessageBoxButtons.OKCancel)
                != DialogResult.OK) return;
            if (!m_OrderItemLoaded)
            {
                try
                {
                    orderTableAdapter.Fill(basicDataSet.Order);
                    orderItemTableAdapter.Fill(basicDataSet.OrderItem);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("載入客人點菜細項時,資料庫發生錯誤:" + ex.Message);
                    return;
                }
                m_OrderItemLoaded = true;
            }
            foreach (BasicDataSet.OrderItemRow row in basicDataSet.OrderItem)
            {
                if (row.ProductID == productID)
                {
                    BasicDataSet.OrderRow order=row.OrderRow;
                    MessageBox.Show("點菜單"+order.ID.ToString()+"  己經點了"+strProductID+" 無法刪除");
                    return;
                }
            }

            if (MessageBox.Show(strProductID+" 本年度沒有人點過,可以被刪除\r\n按'確定' 刪除",strProductID,MessageBoxButtons.OKCancel)==
                DialogResult.OK)
            {
                try
                {
                    productBindingSource.RemoveCurrent();
                    productTableAdapter.Update(basicDataSet.Product);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("刪除"+strProductID+"及存檔過程錯誤:" + ex.Message);
                    return;
                }
                MessageBox.Show("己刪除" + strProductID + name + " 並存檔成功!");
                return;
            }
            MessageBox.Show("沒有刪除 " + strProductID + name);
        }


        string CurrentPhotoPath()
        {
            DataRowView rowView = productBindingSource.Current as DataRowView;
            BasicDataSet.ProductRow row = rowView.Row as BasicDataSet.ProductRow;
            return m_PhotoPath + row.ProductID.ToString() + ".jpg";
        }

        Size SizeSave = new Size(0, 0);
        Point LocationSave = new Point(0, 0);
        private void photoPictureBox_Click(object sender, EventArgs e)
        {
            if (!photoPictureBox.Visible) return;
            if (photoPictureBox.ImageLocation == null)
            {
                photoPictureBox_DoubleClick(null, null);
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

        private void photoPictureBox_DoubleClick(object sender, EventArgs e)
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

   

    }
}