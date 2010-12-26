using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VoucherExpense
{
    public partial class Product : Form
    {
        public Product(bool IsSuper)
        {
            InitializeComponent();
            referenceCostTextBox.ReadOnly = !IsSuper;
        }

        private void productBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!this.Validate())
            {
                MessageBox.Show("有資料錯誤, 請改好再存!");
                return;
            }
            this.productBindingSource.EndEdit();
            VEDataSet.ProductDataTable table = (VEDataSet.ProductDataTable)vEDataSet.Product.GetChanges();
            if (table == null)
            {
                MessageBox.Show("沒有改動任何資料! 不用存");
                return;
            }
            MyFunction.SetGlobalFlag(GlobalFlag.basicDataModified);

            foreach (VEDataSet.ProductRow r in table)
            {
                if (r.RowState != DataRowState.Deleted)
                {
                    r.BeginEdit();
                    r.LastUpdated = DateTime.Now;
                    r.EndEdit();
                }
            }

            vEDataSet.Product.Merge(table);
            this.productTableAdapter.Update(this.vEDataSet.Product);
            vEDataSet.Product.AcceptChanges();

        }

        private void Product_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'vEDataSet.Product' 資料表。您可以視需要進行移動或移除。
            this.productTableAdapter.Fill(this.vEDataSet.Product);
            MyFunction.SetFieldLength(productDataGridView, vEDataSet.Product);
            MyFunction.SetControlLengthFromDB(this, vEDataSet.Product);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            string cellName = "columnProductID";
            DataGridView view = productDataGridView;
            DataGridViewRow row = view.CurrentRow;
            if (Convert.IsDBNull(row.Cells[cellName].Value))
            {
                int m = 0, n = 0;
                foreach (DataGridViewRow r in view.Rows)
                {
                    object obj = r.Cells[cellName].Value;
                    if (obj == null) continue;
                    if (Convert.IsDBNull(obj)) continue;
                    n = (int)obj;
                    if (n > m) m = n;
                }
                row.Cells[cellName].Value = m + 1;
            }

        }

        private void codeTextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel=!MyFunction.UintValidate(((TextBox )sender).Text);
        }

        private void classTextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !MyFunction.UintValidate(((TextBox)sender).Text);
        }

        private void priceTextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !MyFunction.UintValidate(((TextBox)sender).Text);
        }

        private void initialStockTextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !MyFunction.DecimalValidate(((TextBox)sender).Text);
        }

        private void initialCostTextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !MyFunction.DecimalValidate(((TextBox)sender).Text);
        }

        private void unitVolumeTextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !MyFunction.DecimalValidate(((TextBox)sender).Text);
        }

   
    }
}