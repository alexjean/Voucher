using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace VoucherExpense
{
    public partial class FormCashierAuthen : Form
    {
        public FormCashierAuthen()
        {
            InitializeComponent();
        }

        private void cashierBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            BakeryOrderSet.CashierDataTable table = MyFunction.SaveCheck<BakeryOrderSet.CashierDataTable>(
                                            this, cashierBindingSource, bakeryOrderSet.Cashier);
            if (table == null) return;
            foreach (BakeryOrderSet.CashierRow r in table.Rows)
            {
                if (r.RowState == DataRowState.Deleted) continue;
                r.BeginEdit();
                r.LastUpdated = DateTime.Now;
                r.AuthenID = MyFunction.OperatorID;
                r.EndEdit();
            }
            bakeryOrderSet.Cashier.Merge(table);
            this.cashierTableAdapter.Update(bakeryOrderSet.Cashier);
            bakeryOrderSet.Cashier.AcceptChanges();
            this.cashierBindingSource.ResetBindings(false);
        }

        private void FormCashierAuthen_Load(object sender, EventArgs e)
        {
            this.operatorTableAdapter.Fill(this.vEDataSet.Operator);
            this.cashierTableAdapter.Fill(this.bakeryOrderSet.Cashier);
            chBoxOnlyInPosition_CheckedChanged(null, null);
            DateTime now = DateTime.Now;
            labelTime.Text = "今天是 " + now.ToShortDateString() +" "+ DateTime.Now.DayOfWeek.ToString();
            LoadCfg();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyFunction.AddNewItem(cashierDataGridView, "CashierIDColumn", "CashierID", bakeryOrderSet.Cashier);
            DataGridViewRow row = cashierDataGridView.CurrentRow;
        }

        private void cashierDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != -1 && this.cashierDataGridView.Columns[e.ColumnIndex].Name ==  "PasswordColumn")
            {
                if (e.Value != null)
                {
                    String st = new String('*', e.Value.ToString().Length);
                    e.Value = st;
                }
            }
        }

        private void chBoxOnlyInPosition_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxOnlyInPosition.Checked)
                this.cashierBindingSource.Filter = "InPosition";
            else
                this.cashierBindingSource.RemoveFilter();
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            textBoxPOS1.Text = folderBrowserDialog.SelectedPath;
        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            textBoxPOS2.Text = folderBrowserDialog.SelectedPath;
        }

        private void btnBrowse3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            textBoxPOS3.Text = folderBrowserDialog.SelectedPath;
        }


        Config Cfg = new Config();
        string ConfigName = "CashierAuthen";
        string TableName = "DirectoryPath";
        private void btnConfigSave_Click(object sender, EventArgs e)
        {
            string[] paths=new string[3];
            paths[0] = textBoxPOS1.Text.Trim();
            paths[1] = textBoxPOS2.Text.Trim();
            paths[2] = textBoxPOS3.Text.Trim();
            StringBuilder xml = new StringBuilder("<" + ConfigName + " Name=\"" + TableName + "\">", 512);
            for(int i=0;i<3;i++)
                xml.Append("<POS"+(i+1).ToString()+" Dir=\""+paths[i]+"\" />");

            xml.Append("</" + ConfigName + ">");
            Cfg.Save(ConfigName, TableName, xml.ToString());
        }

        void LoadCfg()
        {
            XmlNode list = Cfg.Load(ConfigName, TableName);
            if (list == null) return;
            foreach (XmlNode node in list)
            {
                XmlAttribute dir = node.Attributes["Dir"];
                if (dir == null) continue;
                if      (node.Name == "POS1") textBoxPOS1.Text = dir.Value;
                else if (node.Name == "POS2") textBoxPOS2.Text = dir.Value;
                else if (node.Name == "POS3") textBoxPOS3.Text = dir.Value;
            }
        }
    }
}
