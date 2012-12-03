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
    public partial class BakerySoldSpent : Form
    {
        List<CSaleItem> m_SaleList = new List<CSaleItem>();
        List<CStockItem> m_StockList = new List<CStockItem>();

        private Config Cfg = new Config();
        private string ConfigName = "BakerySoldSpent";
        public BakerySoldSpent()
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
            textBoxName.Text = cbBoxTable.Text.Trim();
        }

        // Config內以前存的是 產品Code及食材Code
        // 現在全部改成ProductID, IngredientID
        private string Config2Xml(string name)
        {
            StringBuilder xml = new StringBuilder("<" + ConfigName + " Name=\""+name+"\">",512);
            xml.Append("<Product>");
            foreach (CSaleItem item in m_SaleList)
            {
                if (item.ProductID < 1) continue;
                xml.Append("<ProductID>" + item.ProductID.ToString() + "</ProductID>");
            }
            xml.Append("</Product>");
            xml.Append("<Ingredient>");
            foreach (CStockItem item in m_StockList)
            {
                if (item.IngredientID < 1) continue;
                xml.Append("<IngredientID>" + item.IngredientID.ToString() + "</IngredientID>");
            }
            xml.Append("</Ingredient>");
            xml.Append("</" + ConfigName + ">");
            return xml.ToString();
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



        OrderAdapter m_OrderAdapter = new OrderAdapter();
        OrderItemAdapter m_OrderItemAdapter = new OrderItemAdapter();

        class OrderAdapter : BakeryOrderSetTableAdapters.OrderTableAdapter
        {
            string SaveStr;
            public int FillBySelectStr(BakeryOrderSet.OrderDataTable dataTable, string SelectStr)
            {
                SaveStr = base.CommandCollection[0].CommandText;
                base.CommandCollection[0].CommandText = SelectStr;
                int result = Fill(dataTable);
                base.CommandCollection[0].CommandText = SaveStr;
                return result;
            }
        }
        class OrderItemAdapter : BakeryOrderSetTableAdapters.OrderItemTableAdapter
        {
            string SaveStr;
            public int FillBySelectStr(BakeryOrderSet.OrderItemDataTable dataTable, string SelectStr)
            {
                SaveStr = base.CommandCollection[0].CommandText;
                base.CommandCollection[0].CommandText = SelectStr;
                int result = Fill(dataTable);
                base.CommandCollection[0].CommandText = SaveStr;
                return result;
            }
        }
        //string DateStr(DateTime da)
        //{
        //    return DateStr(da.Month, da.Day);
        //}
        string DateStr(int m, int d)
        {
            return m.ToString("d2") + d.ToString("d2");
        }
        //int IDTagHead(int y, int m, int d)
        //{
        //    int tag = y % 100;
        //    tag = tag * 10000 + m * 100 + d;
        //    return tag;
        //}

        // BakeryOrder的ID格式是 MMDDNN9999
        void LoadData(int month, int from, int to)
        {
            string sql;
            try
            {
               sql = "Where (INT(ID/1000000)>=" + DateStr(month, from)
                   + " And INT(ID/1000000)<=" + DateStr(month, to) + ")";
                m_OrderAdapter.FillBySelectStr(bakeryOrderSet.Order, "Select * From [Order] " + sql + " Order by ID");
                m_OrderItemAdapter.FillBySelectStr(bakeryOrderSet.OrderItem, "Select * From [OrderItem] " + sql);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                MessageBox.Show("訂菜單資料庫讀取錯誤!");
            }
        }

        private decimal CalcSaleList(int month)
        {
            if (month < 1 || month > 12)
            {
                MessageBox.Show("所選月份<" + month.ToString() + ">不對!");
                return 0;
            }
            int count = m_SaleList.Count;
            if (count <= 1) return 0;
            int year = MyFunction.IntHeaderYear;
            int to = MyFunction.DayCountOfMonth(month);
            if (month == 2 && DateTime.IsLeapYear(year)) to = 29;
            LoadData( month, 1, to);   // 一律稅控制
            foreach (CSaleItem m in m_SaleList)
            {
                m.Total = 0;
                m.Volume = 0;
            }
            bool[] debug = new bool[count];   // items code會重複, 不知為何 ,只好用此辦法
            foreach (BakeryOrderSet.OrderRow row in bakeryOrderSet.Order)
            {
                BakeryOrderSet.OrderItemRow[] items = row.GetOrderItemRows();
                for (int i = 0; i < count; i++) debug[i] = false;
                foreach (BakeryOrderSet.OrderItemRow it in items)
                {
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
            }
            decimal sum = 0;
            foreach (CSaleItem item in m_SaleList) sum += item.Total;
            return sum;

            //            materialBindingSource.ResetBindings(false);
            //            Text = "物料統計 " + month.ToString() + "月 " + from.ToString() + "日 至 " + to.ToString() + "日";
            //            if (ckBoxUse12.Checked) Text += "  稅控制";
        }

        decimal CalcStockList(int month)
        {
            List<CStockItem> list = new List<CStockItem>();
            foreach (CStockItem item in m_StockList)
                list.Add(new CStockItem(item.IngredientID));
            VEDataSet.VoucherDataTable voucher = new VEDataSet.VoucherDataTable();
            int count = 0, checkedCount = 0;
            foreach (VEDataSet.VoucherRow vr in vEDataSet.Voucher)
            {
                if (vr.IsStockTimeNull()) continue;
                if (month != 0)
                {
                    if (vr.StockTime.Month != month) continue;
                }
                if (vr.StockTime.Year != MyFunction.IntHeaderYear) continue;
                if (!vr.IsRemovedNull())
                    if (vr.Removed) continue;
                VEDataSet.VoucherRow row = voucher.NewVoucherRow();
                row.ItemArray = vr.ItemArray;
                voucher.AddVoucherRow(row);
                count++;
                if (vr.Locked) checkedCount++;
                decimal checkSum = 0;
                foreach (VEDataSet.VoucherDetailRow dr in vr.GetVoucherDetailRows())
                {
                    if (dr.IsIngredientIDNull()) continue;

                    decimal co = 0, vo = 0;
                    if (!dr.IsCostNull()) co = dr.Cost;

                    checkSum += co;
                    int ingredientID = dr.IngredientID;
                    foreach (CStockItem p in list)
                    {
                        if (p.IngredientID == ingredientID)
                        {
                            p.TotalCost += co;
                            p.OrderCount++;
                            if (!dr.IsVolumeNull()) vo = dr.Volume;
                            p.Volume += vo;
                            if (p.Volume != 0)
                                p.UnitCost = p.TotalCost / p.Volume;
                            break;
                        }
                    }
                }
                decimal vrCost = 0;
                if (!vr.IsCostNull()) vrCost = vr.Cost;
                if (checkSum != vrCost)
                    MessageBox.Show("警告!<" + vr.VoucherID.ToString() +
                        ">號細項和" + checkSum.ToString("f1") +
                        "和總和" + vr.Cost.ToString("f1") + "不符!");
            }
            m_StockList = list;
            decimal sum = 0;
            foreach (CStockItem p in list)
                sum += p.TotalCost;
            return sum;
        }

        private void SaleSpendRatio_Load(object sender, EventArgs e)
        {
            // 位於 CalcSaleList.cs
            m_OrderAdapter.Connection = MapPath.BakeryConnection;
            m_OrderItemAdapter.Connection = MapPath.BakeryConnection;
            productTableAdapter.Connection = MapPath.BakeryConnection;

            ingredientTableAdapter.Connection = MapPath.VEConnection;
            voucherTableAdapter.Connection = MapPath.VEConnection;
            voucherDetailTableAdapter.Connection = MapPath.VEConnection;

            try
            {
                ingredientTableAdapter.Fill(vEDataSet.Ingredient);
                productTableAdapter.Fill   (bakeryOrderSet.Product);
                this.voucherTableAdapter.Fill(vEDataSet.Voucher);
                this.voucherDetailTableAdapter.Fill(vEDataSet.VoucherDetail);
            }
            catch(Exception ex)
            {
                MessageBox.Show("資料庫讀取錯誤<"+ex.Message+">, 後續操作無法進行!");
                Close();
                return;
            }
            cSaleItemBindingSource.DataSource = m_SaleList;
            this.dgViewSale.DataSource = cSaleItemBindingSource;
            stockItemBindingSource.DataSource = m_StockList;
            this.dgViewStock.DataSource = stockItemBindingSource;
            Reload();
        }

        private void dgViewSale_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgViewStock_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }


        private void ShowTotal(decimal sumSale, decimal sumStock)
        {
            if (sumSale == 0)
                labelSaleTotal.Text = "";
            else 
                labelSaleTotal.Text = sumSale.ToString("N1");
            if (sumStock == 0)
                labelStockTotal.Text = "";
            else
                labelStockTotal.Text = sumStock.ToString("N1");
            if (sumSale != 0)
                labelPercent.Text = (sumStock / sumSale * 100).ToString("N1") + "%";
            else
                labelPercent.Text = "";

        }

        private void cbBoxTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;
            string tableName=box.SelectedItem.ToString();
            XmlNode root = Cfg.Load(ConfigName, tableName);
            if (root == null)
            {
                MessageBox.Show("載入<" + tableName + ">失敗!");
                return;
            }
            textBoxName.Text = tableName;
            int code;
            XmlNode sale = root.SelectSingleNode("Product");
            XmlNode stock = root.SelectSingleNode("Ingredient");
            m_SaleList = new List<CSaleItem>();
            m_StockList = new List<CStockItem>();
            foreach (XmlNode node in sale.ChildNodes)
            {
                if (node.Name!="ProductID") continue;
                code=0;
                try
                {
                    code=Convert.ToInt32(node.InnerText);
                }
                catch{ continue; }
                if (code<=0) continue;
                CSaleItem m = new CSaleItem(code);
                foreach (BakeryOrderSet.ProductRow row in this.bakeryOrderSet.Product)
                {
                    if (row.Code == code)
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
            foreach (XmlNode node in stock.ChildNodes)
            {
                if (node.Name != "IngredientID") continue;
                code = 0;
                try
                {
                    code = Convert.ToInt32(node.InnerText);
                }
                catch { continue; }
                if (code <= 0) continue;
                m_StockList.Add(new CStockItem(code));
            }
            int mon = comboBoxMonth.SelectedIndex;
            if (mon > 0 && mon <= 12)
                ShowTotal(CalcSaleList(mon),CalcStockList(mon));
            cSaleItemBindingSource.DataSource = m_SaleList;
            stockItemBindingSource.DataSource = m_StockList;
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box=sender as ComboBox;
            int mon=box.SelectedIndex;
            if (mon < 1) return;
            ShowTotal(CalcSaleList(mon),CalcStockList(mon));
            cSaleItemBindingSource.DataSource = m_SaleList;
            cSaleItemBindingSource.ResetBindings(false);
            stockItemBindingSource.DataSource = m_StockList;
            stockItemBindingSource.ResetBindings(false);
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
            Cfg.Export(ConfigName, name,"匯出<" + name + ">的設定至檔案");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (Cfg.Import(ConfigName)) Reload();
        }
    }


}
