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
                // TODO: 这行代码将数据加载到表“damaiDataSet.ProductClass”中。您可以根据需要移动或删除它。
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
            int maxid = 0;
            foreach (var item in this.damaiDataSet.ProductClass)
            {
                if (item.ID > maxid)
                {
                    maxid = item.ID;
                }
            }
            DamaiDataSet.ProductClassRow row = this.damaiDataSet.ProductClass.NewProductClassRow();
            row.ID = maxid+1;
            this.damaiDataSet.ProductClass.AddProductClassRow(row);
            this.productClassTableAdapter.Update(damaiDataSet);
            this.productClassTableAdapter.Fill(this.damaiDataSet.ProductClass);
        }


    }
}
