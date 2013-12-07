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
#if (UseSQLServer)
            DamaiDataSet.BankAccountDataTable table = MyFunction.SaveCheck<DamaiDataSet.BankAccountDataTable>(
                                                              this, bankAccountBindingSource, damaiDataSet.BankAccount);
            if (table == null) return;
            damaiDataSet.BankAccount.Merge(table);
            this.bankAccountSQLAdapter.Update(this.damaiDataSet.BankAccount);
            this.damaiDataSet.BankAccount.AcceptChanges();
#else
            
            VEDataSet.BankAccountDataTable table = MyFunction.SaveCheck<VEDataSet.BankAccountDataTable>(
                                                              this, bankAccountBindingSource, vEDataSet.BankAccount);
            if (table==null) return;
            vEDataSet.BankAccount.Merge(table);
            this.bankAccountTableAdapter.Update(this.vEDataSet.BankAccount);
            this.vEDataSet.BankAccount.AcceptChanges();
#endif
        }

        private void FormBank_Load(object sender, EventArgs e)
        {
#if (UseSQLServer)
            this.bankAccountBindingSource.DataSource     = damaiDataSet;
            this.accountingTitleBindingSource.DataSource = damaiDataSet;
            this.accountingTitleBindingSource1.DataSource = damaiDataSet;
            this.accountingTitleSQLAdapter.Fill(this.damaiDataSet.AccountingTitle);
            this.bankAccountSQLAdapter.Fill    (this.damaiDataSet.BankAccount);
            MyFunction.SetFieldLength(dgvBankAccount, damaiDataSet.BankAccount);
#else
            this.bankAccountBindingSource.DataSource     = vEDataSet;
            this.accountingTitleBindingSource.DataSource = vEDataSet;
            this.accountingTitleBindingSource1.DataSource = vEDataSet;
            accountingTitleTableAdapter.Connection  = MapPath.VEConnection;
            bankAccountTableAdapter.Connection      = MapPath.VEConnection; 
            this.accountingTitleTableAdapter.Fill(this.vEDataSet.AccountingTitle);
            this.bankAccountTableAdapter.Fill    (this.vEDataSet.BankAccount);
            MyFunction.SetFieldLength(dgvBankAccount, vEDataSet.BankAccount);
#endif
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
#if (UseSQLServer)
            MyFunction.AddNewItem(dgvBankAccount, "columnID", "ID", damaiDataSet.BankAccount);
#else
            MyFunction.AddNewItem(dgvBankAccount, "columnID", "ID", vEDataSet.BankAccount);
#endif
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
