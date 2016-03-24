using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace VoucherExpense
{
    public partial class BasicSoldProducts : Form
    {
        List<CSaleItem> m_SaleList = new List<CSaleItem>();
        
        private Config Cfg = new Config();
        private string ConfigName = "BasicSoldProducts";

        public BasicSoldProducts()
        {
            InitializeComponent();
        }

        void SetEditMode(bool flag)
        {
            labelName.Visible = textBoxName.Visible = btnSave.Visible = flag;
            textBoxName.Enabled = flag;
            btnEdit.Visible = !flag;
            btnCancel.Visible = flag;
            btnDelete.Visible = flag;
            btnExport.Visible = flag;
            btnImport.Visible = flag;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetEditMode(true);
//            textBoxName.Text = cbBoxTable.Text.Trim();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetEditMode(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            if (name.Length < 2)
            {
                MessageBox.Show("請輸入正確的名稱!");
                return;
            }
            if (MessageBox.Show("將移除<" + name + ">的設定", "", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            if (Cfg.Remove(ConfigName, name))
            {
                Reload();
                MessageBox.Show("移除<" + name + ">成功!");
                return;
            }
            MessageBox.Show("移除<" + name + ">失敗! 名稱是否正確?");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            string name = textBoxName.Text.Trim();
            Cfg.Export(ConfigName, name, "匯出<" + name + ">的設定至檔案");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (Cfg.Import(ConfigName)) Reload();
        }


        private void dgViewSale_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void FormSoldIngredients_Load(object sender, EventArgs e)
        {
            m_OrderAdapter.Connection = MapPath.BasicConnection;
            m_OrderItemAdapter.Connection   = MapPath.BasicConnection;
            productTableAdapter.Connection  = MapPath.BasicConnection;
            productTableAdapter.Fill(basicDataSet.Product);

            cbBoxMonth.Items.Clear();
            for (int i = 1; i <= 12; i++)
                cbBoxMonth.Items.Add(i.ToString() + "月");
            int month = DateTime.Now.Month;
            cbBoxMonth.SelectedIndex = month - 1;


            cSaleItemBindingSource.DataSource = m_SaleList;
            this.dgViewSale.DataSource = cSaleItemBindingSource;
            Reload();
            if (cbBoxTable.Items.Count > 0)
                cbBoxTable.SelectedIndex = 0;
        }

        private void cbBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            int[] dayCount = new int[12] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int month = box.SelectedIndex + 1;
            if (month < 1 || month > 12) return;
            ckBoxWholeMonth.Checked = false;
            int count = dayCount[month - 1];
            cbBoxFrom.Items.Clear();
            cbBoxTo.Items.Clear();
            for (int i = 1; i <= count; i++)
            {
                cbBoxFrom.Items.Add(i.ToString() + "日");
                cbBoxTo.Items.Add(i.ToString() + "日");
            }
            int day;
            DateTime now = DateTime.Now;
            if (now.Month != month)
            {
                ckBoxWholeMonth.Checked = true;
                return;
            }
            if (now.Hour < 5)
                now = now.Subtract(new TimeSpan(24, 0, 0));
            day = now.Day;
            if (day < 1) day = 1;
            cbBoxFrom.SelectedIndex = day - 1;
            cbBoxTo.SelectedIndex = day - 1;
        }

        private void cbBoxFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            int i = box.SelectedIndex;
            if (cbBoxTo.SelectedIndex < i)
                cbBoxTo.SelectedIndex = i;
        }

        private void cbBoxTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            int i = box.SelectedIndex;
            if (cbBoxFrom.SelectedIndex > i)
                cbBoxFrom.SelectedIndex = i;
        }

        private void ckBoxWholeMonth_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            if (!box.Checked)
            {
                cbBoxTo.Enabled = cbBoxFrom.Enabled = true;
                return;
            }
            cbBoxFrom.SelectedIndex = 0;
            cbBoxTo.SelectedIndex = cbBoxTo.Items.Count - 1;
            cbBoxTo.Enabled = cbBoxFrom.Enabled = false;
        }

        private void cbBoxTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;
            string tableName = box.SelectedItem.ToString();
            XmlNode root = Cfg.Load(ConfigName, tableName);
            if (root == null)
            {
                MessageBox.Show("載入<" + tableName + ">失敗!");
                return;
            }
            textBoxName.Text = tableName;
            int productID;
            XmlNode sale = root.SelectSingleNode("Product");
//            XmlNode stock = root.SelectSingleNode("Ingredient");
            m_SaleList = new List<CSaleItem>();
//            m_StockList = new List<StockItem>();
            foreach (XmlNode node in sale.ChildNodes)
            {
                if (node.Name != "ProductID") continue;
                productID = 0;
                try
                {
                    productID = Convert.ToInt32(node.InnerText);
                }
                catch { continue; }
                if (productID <= 0) continue;
                CSaleItem m = new CSaleItem(productID);
                foreach (BasicDataSet.ProductRow row in this.basicDataSet.Product)
                {
                    if (row.ProductID == productID)
                    {
                        if (!row.IsPriceNull())
                            m.Price = (decimal)row.Price;
                        if (!row.IsUnitNull())
                            m.Unit = row.Unit;
                        else
                            m.Unit = "份";
                        break;
                    }
                }
                m_SaleList.Add(m);
            }
            cSaleItemBindingSource.DataSource = m_SaleList;
        }

        private string Config2Xml(string name)
        {
            StringBuilder xml = new StringBuilder("<" + ConfigName + " Name=\"" + name + "\">", 512);
            xml.Append("<Product>");
            foreach (CSaleItem item in m_SaleList)
            {
                if (item.ProductID < 1) continue;
                xml.Append("<ProductID>" + item.ProductID.ToString() + "</ProductID>");
            }
            xml.Append("</Product>");
            xml.Append("</" + ConfigName + ">");
            return xml.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            if (name.Length < 2)
            {
                MessageBox.Show("存檔名請至少輸入二個字!");
                return;
            }
            SetEditMode(false);
            if (Cfg.Save(ConfigName, name, Config2Xml(name)))
            {
                Reload();
                MessageBox.Show("存檔<" + name + ">成功!");
            }
            else
            {
                MessageBox.Show("存檔<" + name + ">失敗!");
            }
        }

        void Reload()
        {
            List<XmlNode> list = Cfg.LoadAll(ConfigName);
            cbBoxTable.Items.Clear();
            foreach (XmlNode node in list)
            {
                XmlAttribute attr = node.Attributes["Name"];
                if (attr == null) continue;
                cbBoxTable.Items.Add(attr.Value);
            }
        }

        #region Adapter Modified Utility
        OrderAdapter m_OrderAdapter = new OrderAdapter();
        OrderItemAdapter m_OrderItemAdapter = new OrderItemAdapter();

        class OrderAdapter : BasicDataSetTableAdapters.OrderTableAdapter
        {
            string SaveStr;
            public int FillBySelectStr(BasicDataSet.OrderDataTable dataTable, string SelectStr)
            {
                SaveStr = base.CommandCollection[0].CommandText;
                base.CommandCollection[0].CommandText = SelectStr;
                int result = Fill(dataTable);
                base.CommandCollection[0].CommandText = SaveStr;
                return result;
            }
        }
        class OrderItemAdapter : BasicDataSetTableAdapters.OrderItemTableAdapter
        {
            string SaveStr;
            public int FillBySelectStr(BasicDataSet.OrderItemDataTable dataTable, string SelectStr)
            {
                SaveStr = base.CommandCollection[0].CommandText;
                base.CommandCollection[0].CommandText = SelectStr;
                int result = Fill(dataTable);
                base.CommandCollection[0].CommandText = SaveStr;
                return result;
            }
        }
        string DateStr(DateTime da)
        {
            return DateStr(da.Year, da.Month, da.Day);
        }
        string DateStr(int y, int m, int d)
        {
            return (y % 100).ToString() + m.ToString("d2") + d.ToString("d2");
        }
        int IDTagHead(int y, int m, int d)
        {
            int tag = y % 100;
            tag = tag * 10000 + m * 100 + d;
            return tag;
        }

        void InitProgressBar(int count)
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = count;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
        }

        void LoadData(int year, int month, int from, int to, bool Use12)
        {
            string sql;
            try
            {
                if (Use12)
                {
                    TimeSpan oneDay = new TimeSpan(24, 0, 0);
                    DateTime prev = new DateTime(year, month, from).Subtract(oneDay);
                    DateTime next = new DateTime(year, month, to);
                    sql = "Where (INT(ID/10000)>=" + DateStr(prev)
                        + " And INT(ID/10000)<=" + DateStr(next) + ")";
                    BasicDataSet.OrderDataTable temp = new BasicDataSet.OrderDataTable();
                    m_OrderAdapter.FillBySelectStr(temp, "Select * From [Order] " + sql + " Order by ID");
                    int nextID = IDTagHead(next.Year, next.Month, next.Day);
                    int prevID = IDTagHead(prev.Year, prev.Month, prev.Day);
                    basicDataSet.Order.Clear();

                    foreach (BasicDataSet.OrderRow r in temp)
                    {
                        int idHead = r.ID / 10000;
                        if (idHead == nextID)
                        {
                            if (r.PrintTime.Hour < 7) continue;
                        }
                        else if (idHead == prevID)
                        {
                            if (r.PrintTime.Hour >= 7) continue;
                        }
                        BasicDataSet.OrderRow oRow = basicDataSet.Order.NewOrderRow();
                        oRow.ItemArray = r.ItemArray;
                        basicDataSet.Order.AddOrderRow(oRow);
                    }
                }
                else
                {
                    sql = "Where (INT(ID/10000)>=" + DateStr(year, month, from)
                        + " And INT(ID/10000)<=" + DateStr(year, month, to) + ")";
                    m_OrderAdapter.FillBySelectStr(basicDataSet.Order, "Select * From [Order] " + sql + " Order by ID");
                }
                m_OrderItemAdapter.FillBySelectStr(basicDataSet.OrderItem, "Select * From [OrderItem] " + sql);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                MessageBox.Show("訂菜單資料庫讀取錯誤!");
            }
        }
        #endregion


        private decimal CalcSaleList(int month,int from,int to,bool taxBased)
        {
            int count = m_SaleList.Count;
            if (count <= 1)
            {
                MessageBox.Show("請選擇產品列表");
                return decimal.MinValue;    // 不可能是負 
            }
            int year = MyFunction.IntHeaderYear;

            labelMessage.Text = "載入資料中.";
            labelMessage.Visible = true;
            Application.DoEvents();
            LoadData(year, month, from , to, taxBased);   // 一律稅控制
            foreach (CSaleItem m in m_SaleList)
            {
                m.Total = 0;
                m.Volume = 0;
            }
            labelMessage.Text = "計算中...";

            InitProgressBar(basicDataSet.Order.Count);
            Application.DoEvents();

            bool[] debug = new bool[count];   // items code會重複, 不知為何 ,只好用此辦法
            foreach (BasicDataSet.OrderRow row in basicDataSet.Order)
            {
                BasicDataSet.OrderItemRow[] items = row.GetOrderItemRows();
                for (int i = 0; i < count; i++) debug[i] = false;
                foreach (BasicDataSet.OrderItemRow it in items)
                {
                    if (it.IsProductIDNull()) continue;
                    for (int i = 0; i < m_SaleList.Count; i++)
                    {
                        CSaleItem m = m_SaleList[i];
                        if (m.ProductID == it.ProductID)
                        {
                            if (debug[i]) break;        // 重複算了二次, items存入有bug,只好先跳掉
                            debug[i] = true;
                            m.Volume += it.No;
                            if (it.Discount)
                                m.Total += it.Price * it.No * 0.88m;
                            else
                                m.Total += it.Price * it.No;
                            break;
                        }
                    }
                }
                progressBar1.Increment(1);
                Application.DoEvents();
            }
            decimal sum = 0;
            foreach (CSaleItem item in m_SaleList) sum += item.Total;
            progressBar1.Visible = false;
            labelMessage.Visible = false;
            return sum;

            //            materialBindingSource.ResetBindings(false);
            //            Text = "物料統計 " + month.ToString() + "月 " + from.ToString() + "日 至 " + to.ToString() + "日";
            //            if (ckBoxUse12.Checked) Text += "  稅控制";
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            Print();
        }
        private bool Print()
        {
            int month = cbBoxMonth.SelectedIndex + 1;
            int from = cbBoxFrom.SelectedIndex + 1;
            int to = cbBoxTo.SelectedIndex + 1;
            if (month < 1 || month > 12)
            {
                MessageBox.Show("所選月份<" + month.ToString() + ">不對!");
                return false;
            }
            if (from < 1 || from > 31)
            {
                MessageBox.Show("所選啟始日期<" + from.ToString() + ">不對!");
                return false;
            }
            if (to < 1 || to > 31)
            {
                MessageBox.Show("所選結束日期<" + to.ToString() + ">不對!");
                return false;
            }
            if (CalcSaleList(month, from, to, ckBoxUse12.Checked) ==decimal.MinValue) return false;
            cSaleItemBindingSource.DataSource = m_SaleList;
            cSaleItemBindingSource.ResetBindings(false);
            return true;
        }

        string d2str(decimal d,int width)
        {
            return d2str((double)d,width);
        }
        string d2str(double d, int width)
        {
            string s;
            if ((d-Math.Floor(d))< 0.01)   // 小於一分 ,不印 x.0
                s=d.ToString("f0")+"  ";
            else
                s=d.ToString("f1");
            if (s.Length>=width) return s;
            return s.PadLeft(width);
        }

        void Item2Buffer(ByteBuilder Buf, CSaleItem item)
        {
            int index = productBindingSource.Find("ProductID", item.ProductID);
            string s="產品"+item.ProductID.ToString();
            if (index >= 0)
            {
                object o = productBindingSource.DataSource;
                BasicDataSet ds=(BasicDataSet)o;
                BasicDataSet.ProductDataTable t = ds.Product;
                BasicDataSet.ProductRow row = t[index];
                s = row.Name;
            }

            int m;
            do
            {
                m = GB2312.GetByteCount(s);
                if (m <= 16) break;
                s = s.Substring(0, s.Length - 1);
            } while (true);
            int    n = 16-m+s.Length;
            Buf.AppendPadRight(s,n,GB2312);
            Buf.Append(d2str(item.Volume , 6), GB2312);
//            Buf.Append(d2str(item.Price  , 5), GB2312);
            Buf.Append(d2str(item.Total  , 10), GB2312);
            Buf.Append("\r\n", GB2312);
        }

        string LoadConfigPrinterName()
        {
            //HardwareConfig cfg = MyFunction.HardwareCfg;
            //return cfg.PrinterName ?? "Zonerich AB-58MK USB";
            return "Zonerich AB-58MK USB";
        }

        Encoding GB2312 = Encoding.GetEncoding("GB2312");
        private void btnPrintSmall_Click(object sender, EventArgs e)
        {
            if (!Print()) return;
            if (MessageBox.Show("此功能將從熱敏印表機印出! 要繼續嗎?", "", MessageBoxButtons.OKCancel) !=
                DialogResult.OK) return;
            byte[] BorderMode = new byte[] { 0x1c, 0x21, 0x28 };
            byte[] NormalMode = new byte[] { 0x1c, 0x21, 0 };

            ByteBuilder Buf = new ByteBuilder(2048);
            Buf.SetEncoding(GB2312);

            Buf.Append(BorderMode);                                      // 設定列印模式28
//            Buf.Append("     吴记老锅底大华店\r\n", GB2312);
            Buf.Append("     销售物料统计表\r\n"  , GB2312);
            Buf.Append(NormalMode);                                      // 設定列印模式正常 

            Buf.Append("\r\n");
            Buf.AppendPadRight("印表时间:" + DateTime.Now.ToString("yy/MM/dd hh:mm"), 19, GB2312);
            Buf.Append("\r\n表单: " + cbBoxTable.Text + "\r\n", GB2312);
            string str = cbBoxMonth.Text.Trim() + cbBoxFrom.Text.Trim() + "至" + cbBoxTo.Text.Trim()+" ";
            if (ckBoxUse12.Checked)
                str += "营业日";
            else str += "0_24时";
            Buf.Append("时段: "+str +"\r\n\r\n");

            Buf.Append("  品名          数量      金额\r\n", GB2312);
            Buf.Append("- - - - - - - - - - - - - - - -\r\n", GB2312);
            decimal no = 0, total = 0;

            foreach (CSaleItem item in m_SaleList)   // 印不可折扣項
            {
                Item2Buffer(Buf, item);
                no += item.Volume;
                total += item.Total;
            }
            Buf.Append("- - - - - - - - - - - - - - - -\r\n", GB2312);
            Buf.Append("合计:        " + d2str(no, 9) + d2str(total, 10) + "\r\n", GB2312);
            Buf.Append(NormalMode);
            Buf.Append("* * * * * * * * * * * * * * * *\r\n\r\n\r\n\r\n\r\n\r\n", GB2312);
            Buf.Append("\f", GB2312);
//            File.WriteAllText("TestPrn.txt",GB2312.GetString(Buf.ToBytes()),Encoding.Unicode);
            RawPrint.SendManagedBytes(LoadConfigPrinterName(), Buf.ToBytes());
        }


    }
}
