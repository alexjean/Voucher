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
    public partial class EditProductClass : Form
    {
        public EditProductClass()
        {
            InitializeComponent();
        }

        private void productClassBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productClassBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.damaiDataSet);

        }

        private void EditProductClass_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“damaiDataSet.ProductClass”中。您可以根据需要移动或删除它。
            this.productClassTableAdapter.Fill(this.damaiDataSet.ProductClass);

        }

        private void productClassDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView s = sender as DataGridView;
            if (s.CurrentRow.Cells["dGVColumnID"].Value.ToString() == "0")
            {
                s.CurrentRow.ReadOnly = true;
            }
        }

        private void productClassDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "DataError!");
        }
    }
}
