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
            try
            {
                
                this.Validate();
                this.productClassBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.damaiDataSet);
            }
            catch(Exception ex)
            {
                MessageBox.Show("保存数据时出现错误"+ex.ToString());
            }
        }

        private void EditProductClass_Load(object sender, EventArgs e)
        {
            try
            {
                productClassTableAdapter.Connection.ConnectionString = DB.SqlConnectString(MyFunction.HardwareCfg);
                this.productClassTableAdapter.Fill(this.damaiDataSet.ProductClass);
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据时出现错误" + ex.ToString());
            }
        }

        private void productClassDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "DataError!");
        }



        private void productClassDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if (!MyFunction.ColumnIDGood(productClassDataGridView, "dGVColumnID", e.RowIndex))
            //    e.Cancel = true;
        }

        private void AddNewItem_Click(object sender, EventArgs e)
        {
            productClassBindingSource.AddNew();
            MyFunction.AddNewItem(productClassDataGridView, "dgvColumnID", "ID", damaiDataSet.ProductClass);
        }


    }
}
