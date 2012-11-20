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
    public partial class SaleSpendRatio : Form
    {
        List<CSaleItem> m_SaleList = new List<CSaleItem>();
        List<StockItem> m_StockList = new List<StockItem>();

        private Config Cfg = new Config();
        private string ConfigName = "SaleSpend";
        public SaleSpendRatio()
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
            //DataGridViewComboBoxDisplayStyle style;
            //if (flag) style = DataGridViewComboBoxDisplayStyle.DropDownButton;
            //else      style = DataGridViewComboBoxDisplayStyle.Nothing;
            //codeColumnSale.DisplayStyle = style;
            //codeColumnStock.DisplayStyle = style;

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
                xml.Append("<Code>" + item.ProductID.ToString() + "</Code>");
            }
            xml.Append("</Product>");
            xml.Append("<Ingredient>");
            foreach (StockItem item in m_StockList)
            {
                if (item.IngredientID < 1) continue;
                xml.Append("<Code>" + item.IngredientID.ToString() + "</Code>");
            }
            xml.Append("</Ingredient>");
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

        private void SaleSpendRatio_Load(object sender, EventArgs e)
        {
            // 位於 CalcSaleList.cs
            m_OrderAdapter.Connection = MapPath.BasicConnection;
            m_OrderItemAdapter.Connection = MapPath.BasicConnection;
            productTableAdapter.Connection = MapPath.BasicConnection;

            ingredientTableAdapter.Connection = MapPath.VEConnection;
            voucherTableAdapter.Connection = MapPath.VEConnection;
            voucherDetailTableAdapter.Connection = MapPath.VEConnection;

            try
            {
                ingredientTableAdapter.Fill(vEDataSet.Ingredient);
                productTableAdapter.Fill   (basicDataSet.Product);
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
            m_StockList = new List<StockItem>();
            foreach (XmlNode node in sale.ChildNodes)
            {
                if (node.Name!="Code") continue;
                code=0;
                try
                {
                    code=Convert.ToInt32(node.InnerText);
                }
                catch{ continue; }
                if (code<=0) continue;
                CSaleItem m = new CSaleItem(code);
                foreach (BasicDataSet.ProductRow row in this.basicDataSet.Product)
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
                if (node.Name != "Code") continue;
                code = 0;
                try
                {
                    code = Convert.ToInt32(node.InnerText);
                }
                catch { continue; }
                if (code <= 0) continue;
                m_StockList.Add(new StockItem(code));
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

    public class StockItem
    {
        public StockItem() { IngredientID = 0; Volume = 0; } 
        public StockItem(int ingredient) { IngredientID = ingredient; Volume = 0; }  
//        public int Code          { get; set; }
        public int IngredientID  { get; set; }
        public decimal Volume    { get; set; }
        public decimal TotalCost { get; set; }
        public decimal UnitCost  { get; set; }
        public int OrderCount    { get; set; }
    }

}
