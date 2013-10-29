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

        private void supplier_BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.supplier_BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sQLVEDataSet);

        }

        private void FormSupplier_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“sQLVEDataSet.Supplier_”中。您可以根据需要移动或删除它。
            this.supplier_TableAdapter.Fill(this.sQLVEDataSet.Supplier_);

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyFunction.AddNewItem(supplier_DataGridView, "ColumnSupplierID", "SupplierID", sQLVEDataSet.Supplier_);
        }

        private void supplier_DataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!MyFunction.ColumnIDGood(supplier_DataGridView, "ColumnSupplierID", e.RowIndex))
                            e.Cancel = true;
        }       

        
    }
}
