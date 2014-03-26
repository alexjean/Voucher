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
    public partial class FormCustomer : Form
    {
        public FormCustomer()
        {
            InitializeComponent();
        }

        private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.customerBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.sQLVEDataSet);
                bindingNavigatorAddNewItem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据更新出现错误" + ex.ToString());
            }
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: 这行代码将数据加载到表“sQLVEDataSet.Customer”中。您可以根据需要移动或删除它。
                this.customerTableAdapter.Fill(this.sQLVEDataSet.Customer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据加载出现错误"+ex.ToString());
            }
        }

        private void customerDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!MyFunction.ColumnIDGood(customerDataGridView, "ColumnCustomerID", e.RowIndex))
                e.Cancel = true;
        }

        private void bindingNavigatorAddNewItem_Click_1(object sender, EventArgs e)
        { 
            MyFunction.AddNewItem(customerDataGridView, "ColumnCustomerID", "CustomerID", sQLVEDataSet.Customer);
            bindingNavigatorAddNewItem.Enabled = false;
        }   
    }
}
