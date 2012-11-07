using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
    }
}
