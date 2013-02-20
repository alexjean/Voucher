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

        List<CNameIDForComboBox> m_ProductList = null;
        private void FormRecipe_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'vEDataSet.RecipeDetail' 資料表。您可以視需要進行移動或移除。
            this.recipeDetailTableAdapter.Fill(this.vEDataSet.RecipeDetail);
            try
            {
                this.productTableAdapter.Fill(this.bakeryOrderSet.Product);
                this.recipeTableAdapter.Fill(this.vEDataSet.Recipe);
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入產品及配方錯誤!原因:" + ex.Message);
            }
            m_ProductList = new List<CNameIDForComboBox>();
            m_ProductList.Add(new CNameIDForComboBox(0, " "));
            foreach (var product in bakeryOrderSet.Product)
            {
                if (product.IsCodeNull()) continue;
                if (product.Code <= 0) continue;
                m_ProductList.Add(new CNameIDForComboBox(product.ProductID, product.Name));
            }
            this.cNameIDForProductBindingSource.DataSource = m_ProductList;
        }

        private void recipeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                Validate();
                recipeBindingSource.EndEdit();
                recipeRecipeDetailBindingSource.EndEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤原因:" + ex.Message);
                return;
            }
            var table = (VEDataSet.RecipeDataTable)vEDataSet.Recipe.GetChanges();
            var detail = (VEDataSet.RecipeDetailDataTable)vEDataSet.RecipeDetail.GetChanges();
            if (table==null && detail==null)
            {
                MessageBox.Show("沒有更改,不需存檔!");
                return;
            }
            if (table != null)
            {
                try
                {
                    int n = recipeTableAdapter.Update(table);
                    vEDataSet.Recipe.Merge(table);
                    vEDataSet.Recipe.AcceptChanges();
                    MessageBox.Show(n.ToString() + "筆更改己存檔!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("更新[Recipe]錯誤原因:" + ex.Message);
                    return;
                }
            }
            if (detail != null)
            {
                try
                {
                    int n = recipeDetailTableAdapter.Update(detail);
                    vEDataSet.RecipeDetail.Merge(detail);
                    vEDataSet.RecipeDetail.AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("更新[RecipeDetail]錯誤原因:" + ex.Message);
                    return;
                }
            }

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyFunction.AddNewItem(dgvRecipe, "dgvColumnID", "RecipeID", vEDataSet.Recipe);
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            richTextBoxInstruction1.SelectionColor = Color.Red;
            richTextBoxInstruction2.SelectionColor = Color.Red;
            btnRed.FlatStyle = FlatStyle.Popup;
            btnBlue.FlatStyle = btnBlack.FlatStyle = FlatStyle.Standard;
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            richTextBoxInstruction1.SelectionColor = Color.Black;
            richTextBoxInstruction2.SelectionColor = Color.Black;
            btnBlack.FlatStyle = FlatStyle.Popup;
            btnBlue.FlatStyle = btnRed.FlatStyle = FlatStyle.Standard;
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            richTextBoxInstruction1.SelectionColor = Color.FromArgb(0, 0, 192);
            richTextBoxInstruction2.SelectionColor = Color.FromArgb(0, 0, 192);
            btnBlue.FlatStyle = FlatStyle.Popup;
            btnRed.FlatStyle = btnBlack.FlatStyle = FlatStyle.Standard;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }

        private void ShowProductName()
        {
            var rowView = recipeBindingSource.Current as DataRowView;
            var row = rowView.Row as VEDataSet.RecipeRow;
            CNameIDForComboBox product = m_ProductList[0];    // 第一個放的是ID=0 Name ""
            if (!row.IsFinalProductIDNull())
            {
                int id = row.FinalProductID;
                foreach (CNameIDForComboBox p in m_ProductList)
                {
                    if (id == p.ID)
                    {
                        product = p;
                        break;
                    }
                }
            }
            this.finalProductIDComboBox.SelectedItem = product;
        }

        private void recipeBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (m_ProductList == null || m_ProductList.Count<=0) return;
            ShowProductName();

        }

        private void FormRecipe_Shown(object sender, EventArgs e)
        {
            if (m_ProductList == null || m_ProductList.Count <= 0) return;
            // 參照Ingredient.cs解法和這裏不同
            ShowProductName();     // 第一次Shown時, finalProductIDComboBox.SelectedValue會被改成0, 先在這Shown就可以搶蓋回來, @@"
        }

        private void pictureBoxRecipe_Click(object sender, EventArgs e)
        {

        }

        private void dgvRecipeDetail_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridViewRow row = e.Row;
            DataGridViewCell cellID = row.Cells["ColumnDetailID"];
            cellID.Value = Guid.NewGuid();
        }
    }
}
