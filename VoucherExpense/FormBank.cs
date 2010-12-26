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
            // TODO: 這行程式碼會將資料載入 'vEDataSet.AccountingTitle' 資料表。您可以視需要進行移動或移除。
            this.accountingTitleTableAdapter.Fill(this.vEDataSet.AccountingTitle);
            this.bankAccountTableAdapter.Fill(this.vEDataSet.BankAccount);
            MyFunction.SetFieldLength(bankAccountDataGridView, vEDataSet.BankAccount);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyFunction.AddNewItem(bankAccountDataGridView, "columnID", "ID", vEDataSet.BankAccount);
        }

        private void bankAccountDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

     

    }
}
