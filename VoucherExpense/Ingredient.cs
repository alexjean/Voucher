using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace VoucherExpense
{
    public partial class Ingredient : Form
    {
        public Ingredient(bool IsSuper)
        {
            InitializeComponent();
        }

        private void IngredientBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            VEDataSet.IngredientDataTable table = MyFunction.SaveCheck<VEDataSet.IngredientDataTable>(
                                                        this, IngredientBindingSource, vEDataSet.Ingredient);
            if (table == null) return;
            MyFunction.SetGlobalFlag(GlobalFlag.basicDataModified);

            foreach (VEDataSet.IngredientRow r in table)
            {
                if (r.RowState != DataRowState.Deleted)
                {
                    r.BeginEdit();
                    r.LastUpdated = DateTime.Now;
                    r.EndEdit();
                }
            }

            vEDataSet.Ingredient.Merge(table);
            this.IngredientTableAdapter.Update(this.vEDataSet.Ingredient);
            vEDataSet.Ingredient.AcceptChanges();

        }

        private void Ingredient_Load(object sender, EventArgs e)
        {
            accountingTitleTableAdapter.Connection  = MapPath.VEConnection;
            IngredientTableAdapter.Connection       = MapPath.VEConnection;
            accountingTitleTableAdapter.Fill(this.vEDataSet.AccountingTitle);
            IngredientTableAdapter.Fill(this.vEDataSet.Ingredient);
            MyFunction.SetFieldLength(IngredientDataGridView, vEDataSet.Ingredient);
            MyFunction.SetControlLengthFromDB(this, vEDataSet.Ingredient);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyFunction.AddNewItem(IngredientDataGridView, "columnIngredientID", 
                                   "IngredientID", vEDataSet.Ingredient);
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
            e.Cancel = !MyFunction.DecimalValidate(((TextBox)sender).Text);
        }

        private void IngredientDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!MyFunction.ColumnIDGood((DataGridView)sender, "columnIngredientID", e.RowIndex))
                e.Cancel = true;
        }

     
    }
}