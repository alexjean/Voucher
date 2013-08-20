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
            productTableAdapter.Connection = MapPath.BakeryConnection;
            recipeTableAdapter.Connection = MapPath.VEConnection;
            recipeDetailTableAdapter.Connection = MapPath.VEConnection;
            ingredientTableAdapter.Connection = MapPath.VEConnection;
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
                string name;
                if (ing.IsNameNull()) name = "食材" + ing.IngredientID.ToString();
                else name = ing.Name;
                if (!ing.CanPurchase)
                    name = "**" + name;
                m_SourceList.Add(new CNameIDForComboBox(ing.IngredientID, name));
            }
            foreach (var recipe in vEDataSet.Recipe)
            {
                if (recipe.IsFinalProductIDNull() || recipe.FinalProductID <= 0)   // 該配方沒有最終產品,才列入
                {
                    string name = "配方:";
                    if (recipe.IsRecipeNameNull()) name += recipe.RecipeID.ToString();
                    else name += recipe.RecipeName;
                    m_SourceList.Add(new CNameIDForComboBox(recipe.RecipeID + 10000, name));
                }
            }
            sourceBindingSource.DataSource = m_SourceList;
            ShowProductColumn(false);
        }

        private void recipeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                Validate();
                recipeBindingSource.EndEdit();
                recipeRecipeDetailBindingSource.EndEdit();
                UpdateRtf();
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤原因:" + ex.Message);
                return;
            }
            var table = (VEDataSet.RecipeDataTable)vEDataSet.Recipe.GetChanges();
            var detail = (VEDataSet.RecipeDetailDataTable)vEDataSet.RecipeDetail.GetChanges();
            if (table == null && detail == null)
            {
                MessageBox.Show("沒有更改,不需存檔!");
                return;
            }
            int n=0;
            if (table != null)
            {
                try
                {
                    n = recipeTableAdapter.Update(table);
                    vEDataSet.Recipe.Merge(table);
                    vEDataSet.Recipe.AcceptChanges();
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
                    int n1 = recipeDetailTableAdapter.Update(detail);
                    vEDataSet.RecipeDetail.Merge(detail);
                    vEDataSet.RecipeDetail.AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("更新[RecipeDetail]錯誤原因:" + ex.Message);
                    return;
                }
            }
            MessageBox.Show(n.ToString() + "筆更改己存檔!");

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyFunction.AddNewItem(dgvRecipe, "dgvColumnID", "RecipeID", vEDataSet.Recipe);
            recipeBindingSource.ResetBindings(false);    // 不加這行Detail顯示不會改
        }

        void SetRichTextColor(Button btn,Color color)
        {
            richTextBoxInstruction1.SelectionColor = color;
            richTextBoxInstruction2.SelectionColor = color;
            btnYellow.FlatStyle=btnGreen.FlatStyle=btnRed.FlatStyle=btnBlue.FlatStyle = btnBlack.FlatStyle = FlatStyle.Standard;
            btn.FlatStyle = FlatStyle.Popup;
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            SetRichTextColor(btnGreen, Color.Green);
        }
        private void btnRed_Click(object sender, EventArgs e)
        {
            SetRichTextColor(btnRed  , Color.Red);
        }
        private void btnBlack_Click(object sender, EventArgs e)
        {
            SetRichTextColor(btnBlack, Color.Black);
        }
        private void btnBlue_Click(object sender, EventArgs e)
        {
            SetRichTextColor(btnBlue , Color.FromArgb(0, 0, 192));
        }
        private void btnYellow_Click(object sender, EventArgs e)
        {
            SetRichTextColor(btnYellow, Color.Yellow);
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


        #region ====== RTF手動Binding , 第一次在Form_Shown , 以後在 BindingSource_CurrentChanged. 存檔呼叫了UpdateRtf ======
        //因為RTF的Binding 總是 Changed ,變成每次都Save,所以自己Binding
        bool m_Instruction1Modified = false;
        bool m_Instruction2Modified = false;
        VEDataSet.RecipeRow m_OldRow=null;
        private void BindingRtf()
        {
            if (recipeBindingSource.Current == null) return;
            DataRowView rowView = recipeBindingSource.Current as DataRowView;
            VEDataSet.RecipeRow row = rowView.Row as VEDataSet.RecipeRow;
            if (row == null) return;
            if (row.IsInstruction1Null()) richTextBoxInstruction1.Rtf = "";
            else richTextBoxInstruction1.Rtf = row.Instruction1;  // 這裏Rtf的TextChanged會被呼叫, 但後面 m_Instruction1Modified=false又會蓋回來
            if (row.IsInstruction2Null()) richTextBoxInstruction2.Rtf = "";
            else richTextBoxInstruction2.Rtf = row.Instruction2;
            m_OldRow=row;
            m_Instruction1Modified = m_Instruction2Modified = false;
        }

        private void UpdateRtf()
        {
            if (m_OldRow == null)
            {
                m_Instruction1Modified = m_Instruction2Modified = false;
                return;
            }
            if (m_Instruction1Modified)
            {
                m_OldRow.Instruction1 = richTextBoxInstruction1.Rtf;
                m_Instruction1Modified = false;
            }
            if (m_Instruction2Modified)
            {
                m_OldRow.Instruction2 = richTextBoxInstruction2.Rtf;
                m_Instruction2Modified = false;
            }
        }

        private void richTextBoxInstruction1_TextChanged(object sender, EventArgs e)
        {
            m_Instruction1Modified = true;
        }
        private void richTextBoxInstruction2_TextChanged(object sender, EventArgs e)
        {
            m_Instruction2Modified = true;
        }
        #endregion

        private void recipeBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (m_ProductList == null || m_ProductList.Count <= 0) return;
            ShowProductName();
            ShowCurrentPicture();
            CalcWeight();
            UpdateRtf();
            BindingRtf();
        }

        // BindingSource.BindingComplete 有幾個Control Bind就會呼叫幾次,不能用,第一次只好放在Form_Show內顯示
        private void FormRecipe_Shown(object sender, EventArgs e)
        {
            if (m_ProductList == null || m_ProductList.Count <= 0) return;
            // 參照Ingredient.cs解法和這裏不同
            ShowProductName();     // 第一次Shown時, finalProductIDComboBox.SelectedValue會被改成0, 先在這Shown就可以搶蓋回來, @@"
            ShowCurrentPicture();
            CalcWeight();
            BindingRtf();
            vEDataSet.Recipe.AcceptChanges();  // 不知為何第一次進來,第一筆就被當做有改過,所以加了這行.可能用rtf的副作用
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
            string name = dgv.Columns[colIndex].Name;
            if (name == "ColumnSourceID")
            {
                DataGridViewCell cell = dgv.Rows[rowIndex].Cells[colIndex];
                if (cell.Value.GetType() == typeof(int))
                {
                    int id = (int)cell.Value;
                    MessageBox.Show("食材或配方<"+id.ToString()+"> 找不到!");
                }
                return;
            }
            MessageBox.Show("row" + rowIndex.ToString() + " column<" + name + "> ex:" + e.Exception.Message);
        }

        bool m_DirChecked = false;
        string CurrentPhotoPath()
        {
            string RecipePhotoPath = MapPath.DataDir+"Photos\\Recipes\\";
            DataRowView rowView = this.recipeBindingSource.Current as DataRowView;
            if (rowView == null) return null;
            var row = rowView.Row as VEDataSet.RecipeRow;
            if (row.RowState == DataRowState.Deleted) return null;
            if (row.RowState == DataRowState.Detached )    //  新增時, RecipeID有時沒有值,會Exception
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
                m_DirChecked = true;
            }
            return RecipePhotoPath + row.RecipeID.ToString() + ".jpg";
        }

        private void ShowCurrentPicture()
        {
            string path = CurrentPhotoPath();
            if (path != null && File.Exists(path))
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
            //            File.Copy(openFileDialog1.FileName, path, true);
            try
            {
                Bitmap img = (Bitmap)(Bitmap.FromFile(openFileDialog1.FileName));
                Bitmap thumbNail = MyFunction.GetThumbnail(img, 256);
                thumbNail.Save(path,System.Drawing.Imaging.ImageFormat.Jpeg);
                pictureBoxRecipe.ImageLocation = path;
            }
            catch (Exception ex)
            {
                MessageBox.Show("存圖形<"+path.ToString()+">時出錯!原因:" + ex.Message);
            }
        }

        private int m_ColumnWeightIndex = -1;
        int ColumnWeightIndex
        {
            get
            {
                if (m_ColumnWeightIndex < 0)
                {
                    foreach (DataGridViewColumn col in dgvRecipeDetail.Columns)
                        if (col.Name == "ColumnWeight")
                        {
                            m_ColumnWeightIndex = col.Index;
                            break;
                        }
                    if (m_ColumnWeightIndex < 0)
                        MessageBox.Show("程式有誤! ColumnWeight定義找不到!");
                }
                return m_ColumnWeightIndex;
            }
        }
        private void dgvRecipeDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;
            if (rowIndex < 0) return;
            if (colIndex < 0) return;
            if (colIndex == ColumnWeightIndex) CalcWeight(useDataTable: false);
        }

        private void CalcWeight(bool useDataTable = true)
        {
            decimal sum = 0m;
            // 去找DataTable,最後新增那行還是DataRowState.Detached, 會少加一行
            if (useDataTable)
            {
                DataRowView rowView = this.recipeBindingSource.Current as DataRowView;
                if (rowView == null) return;
                var row = rowView.Row as VEDataSet.RecipeRow;
                var details = row.GetRecipeDetailRows();
                foreach (var d in details)
                {
                    if (!d.IsWeightNull()) sum += d.Weight;
                }
                decimal packageNo = 1;
                if (!row.IsPackageNoNull() && row.PackageNo > 0) packageNo = row.PackageNo;
                decimal bakedNo = 1;
                if (!row.IsBakedNoNull() && row.BakedNo > 0) bakedNo = row.BakedNo;
                this.textBoxFloatCost.Text = CalcCost(packageNo/bakedNo, details, usedRecipes: new List<int>()).ToString("N2");
            }
            else
            {   // From DataGridViewCell , Event BindingSource.CurrentChanged時,DataGridView內容還沒改
                foreach (DataGridViewRow row in dgvRecipeDetail.Rows)
                {
                    DataGridViewCell cell = row.Cells[ColumnWeightIndex];
                    if (cell.ValueType == typeof(Decimal))
                    {
                        if (cell.Value != null && cell.Value != Convert.DBNull)
                            sum += (decimal)cell.Value;
                    }
                }
            }
            textBoxIngredientWeight.Text = sum.ToString("N1");
        }

        private decimal CalcCost(decimal ratio,VEDataSet.RecipeDetailRow[] details, List<int> usedRecipes)  // usedRecipes填入己使用的配方,避免Recursive
        {
            decimal cost = 0m;
            if (ratio <= 0) ratio = 1;     // 包裝單位不正常時,以1計算
            // 去找DataTable,最後新增那行還是DataRowState.Detached, 會少加一行
            foreach (var d in details)
            {
                if (d.IsWeightNull()) continue;
                if (d.IsSourceIDNull()) continue;
                decimal we;
                if (d.IsWeightNull()) we = 0m;
                else we = d.Weight;
                if (d.SourceID < 10000)  // 是食材
                {
                    var ingredients = from ing in vEDataSet.Ingredient where ing.IngredientID == d.SourceID select ing;
                    if (ingredients.Count() <= 0) continue;
                    var ingredient = ingredients.First();
                    if (ingredient.IsPriceNull())
                    {
                        MessageBox.Show(ingredient.Name + "沒有參考進價,無法計算每克成本!");
                        continue;  
                    }
                    if (ingredient.IsUnitWeightNull() || ingredient.UnitWeight <= 0)
                    {
                        MessageBox.Show(ingredient.Name + "沒有單位重量,無法計算每克成本!");
                        continue;  
                    }
                    cost += (decimal)ingredient.Price * we / ingredient.UnitWeight;
                }
                else                   // 是配方
                {
                    int recipeID = d.SourceID % 10000;
                    var ids = from i in usedRecipes where i == recipeID select i;
                    if (ids.Count() == 0)   // 沒有使用過此配方可用
                    {
                        var recipes = from row in vEDataSet.Recipe where (row.RowState!=DataRowState.Deleted) && (row.RecipeID == recipeID) select row;
                        if (recipes.Count() > 0)
                        {
                            usedRecipes.Add(recipeID);
                            var recipe = recipes.First();
                            var details1 = recipe.GetRecipeDetailRows();
                            decimal we1 = 0;
                            foreach (VEDataSet.RecipeDetailRow r in details1)
                            {
                                if (r.IsWeightNull()) continue;
                                we1 += r.Weight;
                            }
                            if (we1 > 0m)
                            {
                                decimal co = CalcCost(we / we1, details1, usedRecipes);   // 配方下的配方,只計算重量比, 忽視包裝單位
                                cost += co;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("配方:" + ids.First().ToString() + "重複使用,不計入!");
                    }
                }
                // cost += d.Weight; bug
            }
            return ratio*cost;
        }

        private void btnUpdateEvaluatedCost_Click(object sender, EventArgs e)
        {
            // 更新估算成本時,要計算一張表給User看, 列出每一筆食材及價格 重量
            var rowView = recipeBindingSource.Current as DataRowView;
            if (rowView == null)
            {
                MessageBox.Show("沒有現有配方,無法更新!");
                return;
            }
            var row = rowView.Row as VEDataSet.RecipeRow;
            if (row.RowState == DataRowState.Detached || row.RowState == DataRowState.Deleted)
            {
                MessageBox.Show("配方表尚未儲存或己刪除!");
                return;
            }
            decimal packageNo = 1;
            if (!row.IsPackageNoNull() && row.PackageNo > 0) packageNo = row.PackageNo;
            decimal bakedNo = 1;
            if (!row.IsBakedNoNull() && row.BakedNo > 0) bakedNo = row.BakedNo;
            var details = row.GetRecipeDetailRows();
            Form form = new FormRecipePriceUpdate(packageNo,bakedNo,details,vEDataSet);
            if (form.ShowDialog()==DialogResult.OK)
            {
                if (row.IsFinalProductIDNull() || row.FinalProductID <= 0)
                {
                    MessageBox.Show("沒有最終產品,無可更新!");
                    return;
                }
                var products = from pr in bakeryOrderSet.Product where pr.ProductID == row.FinalProductID select pr;
                if (products.Count() == 0)
                {
                    MessageBox.Show("找不到產品号<" + row.FinalProductID.ToString() + ">,無法更新價格!");
                    return;
                }
                var product = products.First();
                if (form.Tag.GetType() == typeof(decimal))
                {
                    decimal co=(decimal)form.Tag;
                    co=Math.Round(co,1);
                    product.EvaluatedCost = co;
                    productTableAdapter.Update(product);
                    product.AcceptChanges();
                    productBindingSource.ResetBindings(false);    // 刷新Product螢幕顯示
                    MessageBox.Show("產品<"+product.Name+">的估算成本己更新為 "+co.ToString());
                    CalcGrossProfit();
                }
                else
                    MessageBox.Show("計算之估算成本不是decimal 產品" + product.Name + " 未更新!");
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            var rowView = recipeBindingSource.Current as DataRowView;
            if (rowView == null) return;
            var row = rowView.Row as VEDataSet.RecipeRow;
            var details = row.GetRecipeDetailRows();
            foreach (var d in details)
                d.Delete();
            this.recipeRecipeDetailBindingSource.ResetBindings(false);
            string name;
            if (row.IsRecipeNameNull())
                name = "配方<" + row.RecipeID.ToString() + ">";
            else name = row.RecipeName;
            row.Delete();
            recipeBindingSource.ResetBindings(false);
            MessageBox.Show(name + " 己刪除,請按存檔更新資料庫");
        }

        private void pictureBoxRecipe_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            SavePicture();
        }

        private void packageNoTextBox_Validated(object sender, EventArgs e)
        {
            CalcWeight(useDataTable: true);
        }

        void ShowProductColumn(bool b)
        {
            btnUpdatePrice.Visible = b; 
            textBoxCode.Visible = b;
            textBoxEvaluatedCost.Visible = b;
            textBoxPrice.Visible = b;
            textBoxGross.Visible = b;
            textBoxGrossPercent.Visible = b;
            labelPrice.Visible = b;
            labelEvaluatedCost.Visible = b;
            labelGross.Visible = b;
        }

        private void CalcGrossProfit()
        {
            double price, cost;
            try
            {
                cost = Convert.ToDouble(textBoxEvaluatedCost.Text);
            }
            catch { cost = 0; }
            try
            {
                price = Convert.ToDouble(textBoxPrice.Text);
            }
            catch { price = 0; }

            double gross = price - cost;
            textBoxGross.Text = gross.ToString("f2");
            if (price != 0)
                textBoxGrossPercent.Text = ((gross / price) * 100).ToString("f1") + "%";
            else
                textBoxGrossPercent.Text = "--.-%";
        }

        TextBox textBoxPriceForEdit = null;
        enum PriceEditMode { Invisible=0,Editing}
        private void ConfigPriceForEdit()
        {
            btnUpdatePrice.Text = "編修 價格";
            if (textBoxPriceForEdit == null)
            {
                textBoxPriceForEdit = new TextBox();
                textBoxPriceForEdit.Location = textBoxPrice.Location;
                textBoxPriceForEdit.Size = textBoxPrice.Size;
                this.groupBoxProduct.Controls.Add(textBoxPriceForEdit);
            }
            textBoxPriceForEdit.Visible = false;
            textBoxPriceForEdit.Tag = PriceEditMode.Invisible;
        }

        private void finalProductIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigPriceForEdit();
            if (finalProductIDComboBox.SelectedIndex <= 0)
                ShowProductColumn(false);
            else
            {
                ShowProductColumn(true);
                try
                {
                    ComboBox box = sender as ComboBox;
                    int index = productBindingSource.Find("ProductID", box.SelectedValue);
                    if (index < 0)
                        ShowProductColumn(false);
                    else productBindingSource.Position = index;
                    CalcGrossProfit();
                }
                catch
                {
                    ShowProductColumn(false);
                }
            }

        }

        private void btnUpdatePrice_Click(object sender, EventArgs e)
        {
            switch((PriceEditMode)textBoxPriceForEdit.Tag)
            {
                case PriceEditMode.Invisible:
                    textBoxPriceForEdit.Text = textBoxPrice.Text;
                    textBoxPriceForEdit.Visible = true;
                    textBoxPriceForEdit.Tag = PriceEditMode.Editing;
                    textBoxPriceForEdit.BringToFront();
                    btnUpdatePrice.Text = "更新 價格";
                    break;
                case PriceEditMode.Editing:
                    try
                    {
                        if (Convert.ToDouble(textBoxPriceForEdit.Text) < 0)
                        {
                            MessageBox.Show("價格不能小於 0!");
                            return;
                        }
                    }
                    catch 
                    {
                        MessageBox.Show("價格必需是數字!");
                        return;
                    }
                    textBoxPrice.Text = textBoxPriceForEdit.Text;
                    productBindingSource.EndEdit();
                    productTableAdapter.Update(bakeryOrderSet.Product);
                    bakeryOrderSet.Product.AcceptChanges();
                    textBoxPriceForEdit.Tag = PriceEditMode.Invisible;
                    textBoxPriceForEdit.Visible = false;
                    btnUpdatePrice.Text = "編修 價格";
                    MessageBox.Show("產品<"+finalProductIDComboBox.Text.Trim()+"> 價格己更新為　"+textBoxPrice.Text.Trim()+"");
                    CalcGrossProfit();
                    break;
                default:
                    textBoxPriceForEdit.Tag = PriceEditMode.Invisible;
                    textBoxPriceForEdit.Visible = false;
                    btnUpdatePrice.Text = "編修 價格";
                    break;
            }

        }




 
    }
}
