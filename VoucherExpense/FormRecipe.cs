using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace VoucherExpense
{
    public partial class FormRecipe : Form
    {
        public FormRecipe()
        {
            InitializeComponent();
        }

        List<CNameIDForComboBox> m_ProductList = null;
        List<CNameIDForComboBox> m_SourceList = null;
        private void FormRecipe_Load(object sender, EventArgs e)
        {
            try
            {
                this.productTableAdapter.Fill(this.bakeryOrderSet.Product);
                this.recipeTableAdapter.Fill(this.vEDataSet.Recipe);
                this.recipeDetailTableAdapter.Fill(this.vEDataSet.RecipeDetail);
                this.ingredientTableAdapter.Fill(this.vEDataSet.Ingredient);
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入產品食材及配方錯誤!原因:" + ex.Message);
            }
            // 填給使用者選的產品表, 第一個為空白
            m_ProductList = new List<CNameIDForComboBox>();
            m_ProductList.Add(new CNameIDForComboBox(0, " "));
            foreach (var product in bakeryOrderSet.Product)
            {
                if (product.IsCodeNull()) continue;
                if (product.Code <= 0) continue;
                m_ProductList.Add(new CNameIDForComboBox(product.ProductID, product.Name));
            }
            this.cNameIDForProductBindingSource.DataSource = m_ProductList;
            // 填 食材+配方表 (RecipeID +10000)
            m_SourceList = new List<CNameIDForComboBox>();
            foreach (var ing in vEDataSet.Ingredient)
            {
                if (ing.CanPurchase)
                {
                    string name;
                    if (ing.IsNameNull()) name="食材"+ing.IngredientID.ToString();
                    else                  name= ing.Name;
                    m_SourceList.Add(new CNameIDForComboBox(ing.IngredientID, name));
                }
            }
            foreach (var recipe in vEDataSet.Recipe)
            {
                if (recipe.IsFinalProductIDNull() || recipe.FinalProductID <= 0)   // 該配方沒有最終產品,才列入
                {
                    string name = "配方:";
                    if (recipe.IsRecipeNameNull()) name+=recipe.RecipeID.ToString();
                    else                           name+=recipe.RecipeName;
                    m_SourceList.Add(new CNameIDForComboBox(recipe.RecipeID+10000,name));
                }
            }
            sourceBindingSource.DataSource = m_SourceList;

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
            if (rowView == null) return;
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
            ShowCurrentPicture();
        }

        private void FormRecipe_Shown(object sender, EventArgs e)
        {
            if (m_ProductList == null || m_ProductList.Count <= 0) return;
            // 參照Ingredient.cs解法和這裏不同
            ShowProductName();     // 第一次Shown時, finalProductIDComboBox.SelectedValue會被改成0, 先在這Shown就可以搶蓋回來, @@"
            ShowCurrentPicture();
        }

        private void dgvRecipeDetail_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridViewRow row = e.Row;
            DataGridViewCell cellID = row.Cells["ColumnDetailID"];
            cellID.Value = Guid.NewGuid();
        }

        private void dgvRecipeDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;
            if (rowIndex < 0) return;
            if (colIndex < 0) return;
            string name=dgv.Columns[colIndex].Name;
            if ( name== "ColumnSourceID") return;
            MessageBox.Show("row" + rowIndex.ToString() + " column<" + name + "> ex:" + e.Exception.Message);
        }

        bool m_DirChecked = false;
        string CurrentPhotoPath()
        {   
            string RecipePhotoPath = "Photos\\Recipes\\";
            DataRowView rowView = this.recipeBindingSource.Current as DataRowView;
            if (rowView==null) return null;
            var row = rowView.Row as VEDataSet.RecipeRow;
            if (row.RowState == DataRowState.Detached)    //  新增時, RecipeID有時沒有值,會Exception
            {
                try
                {
                    if (row.RecipeID <= 0) return null;
                }
                catch { return null; }
            }
            if (!m_DirChecked)
            {
                if (!Directory.Exists(RecipePhotoPath))
                    Directory.CreateDirectory(RecipePhotoPath);
                m_DirChecked=true;
            }
            return RecipePhotoPath + row.RecipeID.ToString() + ".jpg";
        }

        private void ShowCurrentPicture()
        {
            string path = CurrentPhotoPath();
            if (path!=null && File.Exists(path))
                pictureBoxRecipe.ImageLocation = path;
            else
                pictureBoxRecipe.ImageLocation = null;
        }

        private void SavePicture()
        {
            string path = CurrentPhotoPath();
            if (path == null)
            {
                MessageBox.Show("沒有當前記錄,請按 '+' 新增資料!");
                return;          // 沒有當前記錄則不存檔
            }
            DialogResult result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            string ext = Path.GetExtension(openFileDialog1.FileName).ToLower();
            if (ext != ".jpg")
            {
                MessageBox.Show("對不起!只接受jpg檔");
                return;
            }
            File.Copy(openFileDialog1.FileName, path, true);
            pictureBoxRecipe.ImageLocation = path;
        }
        private void pictureBoxRecipe_Click(object sender, EventArgs e)
        {
            SavePicture();
        }
    }
}
