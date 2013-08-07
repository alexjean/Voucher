using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace VoucherExpense
{
    public partial class FormBank : Form
    {
        public FormBank()
        {
            InitializeComponent();
        }

        private void bankAccountBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            VEDataSet.BankAccountDataTable table = MyFunction.SaveCheck<VEDataSet.BankAccountDataTable>(
                                                              this, bankAccountBindingSource, vEDataSet.BankAccount);
            if (table==null) return;
            vEDataSet.BankAccount.Merge(table);
            this.bankAccountTableAdapter.Update(this.vEDataSet.BankAccount);
            this.vEDataSet.BankAccount.AcceptChanges();
        }

        private void FormBank_Load(object sender, EventArgs e)
        {
            accountingTitleTableAdapter.Connection  = MapPath.VEConnection;
            bankAccountTableAdapter.Connection      = MapPath.VEConnection; 
            this.accountingTitleTableAdapter.Fill(this.vEDataSet.AccountingTitle);
            this.bankAccountTableAdapter.Fill(this.vEDataSet.BankAccount);
            MyFunction.SetFieldLength(dgvBankAccount, vEDataSet.BankAccount);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyFunction.AddNewItem(dgvBankAccount, "columnID", "ID", vEDataSet.BankAccount);
        }

        private void bankAccountDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void FormBank_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvBankAccount.Visible = false;
        }

     

    }
}
