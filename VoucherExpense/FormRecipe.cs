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
    public partial class FormRecipe : Form
    {
        public FormRecipe()
        {
            InitializeComponent();
        }

        private void recipeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.recipeBindingSource.EndEdit();
            this.recipeTableAdapter.Update(this.vEDataSet.Recipe);

        }

        private void FormRecipe_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'bakeryOrderSet.Product' 資料表。您可以視需要進行移動或移除。
            this.productTableAdapter.Fill(this.bakeryOrderSet.Product);
            this.recipeTableAdapter.Fill(this.vEDataSet.Recipe);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyFunction.AddNewItem(dgvRecipe, "dgvColumnID", "RecipeID", vEDataSet.Recipe);
        }

  
    }
}
