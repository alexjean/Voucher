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
    public partial class FormSupplier : Form
    {
        public FormSupplier()
        {
            InitializeComponent();
        }

        private void supplierBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.supplierBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sQLVEDataSet);

        }

        private void FormsupplierLoad(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“sQLVEDataSet.Supplier_”中。您可以根据需要移动或删除它。
            this.supplierTableAdapter.Fill(this.sQLVEDataSet.Supplier);

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyFunction.AddNewItem(supplierDataGridView, "ColumnSupplierID", "SupplierID", sQLVEDataSet.Supplier);
        }

        private void supplierDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!MyFunction.ColumnIDGood(supplierDataGridView, "ColumnSupplierID", e.RowIndex))
                            e.Cancel = true;
        }       

        
    }
}
