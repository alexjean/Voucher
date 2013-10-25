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
    public partial class FormShrink : Form
    {
        public FormShrink()
        {
            InitializeComponent();
        }

        private void inventoryBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.inventoryBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sQLVEDataSet);

        }

        private void FormShrink_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“sQLVEDataSet.Inventory”中。您可以根据需要移动或删除它。
            this.inventoryTableAdapter.Fill(this.sQLVEDataSet.Inventory);

        }
    }
}
