//#define UseSQLServer
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
            DamaiDataSet.BankAccountDataTable table = MyFunction.SaveCheck<DamaiDataSet.BankAccountDataTable>(
                                                              this, bankAccountBindingSource, damaiDataSet.BankAccount);
            if (table == null) return;
            damaiDataSet.BankAccount.Merge(table);
            this.bankAccountSQLAdapter.Update(this.damaiDataSet.BankAccount);
            this.damaiDataSet.BankAccount.AcceptChanges();
        }

        private void FormBank_Load(object sender, EventArgs e)
        {
            this.bankAccountBindingSource.DataSource     = damaiDataSet;
            this.accountingTitleBindingSource.DataSource = damaiDataSet;
            this.accountingTitleBindingSource1.DataSource = damaiDataSet;
            this.accountingTitleSQLAdapter.Fill(this.damaiDataSet.AccountingTitle);
            this.bankAccountSQLAdapter.Fill    (this.damaiDataSet.BankAccount);
            MyFunction.SetFieldLength(dgvBankAccount, damaiDataSet.BankAccount);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyFunction.AddNewItem(dgvBankAccount, "columnID", "ID", damaiDataSet.BankAccount);
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
