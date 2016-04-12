using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using MyDataSet             = VoucherExpense.DamaiDataSet;
using MyRecipeTable         = VoucherExpense.DamaiDataSet.RecipeDataTable;
using MyRecipeDetailTable   = VoucherExpense.DamaiDataSet.RecipeDetailDataTable;
using MyRecipeRow           = VoucherExpense.DamaiDataSet.RecipeRow;
using MyRecipeDetailRow     = VoucherExpense.DamaiDataSet.RecipeDetailRow;
using MyProductAdapter      = VoucherExpense.DamaiDataSetTableAdapters.ProductTableAdapter;
using MyRecipeAdapter       = VoucherExpense.DamaiDataSetTableAdapters.RecipeTableAdapter;
using MyRecipeDetailAdapter = VoucherExpense.DamaiDataSetTableAdapters.RecipeDetailTableAdapter;
using MyIngredientAdapter   = VoucherExpense.DamaiDataSetTableAdapters.IngredientTableAdapter;
using System.Security.Cryptography;


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
        MyDataSet m_DataSet = new MyDataSet();
        MyRecipeAdapter       recipeAdapter      = new MyRecipeAdapter();
        MyRecipeDetailAdapter recipeDetailAdapter= new MyRecipeDetailAdapter();
        MyProductAdapter      productAdapter     = new MyProductAdapter();
        public class MyPhotoAdapter : DamaiDataSetTableAdapters.PhotosTableAdapter
        {
            string SaveStr;
            public int FillBySelectStr(DamaiDataSet.PhotosDataTable dataTable, string SelectStr)
            {
                ClearBeforeFill = false;
                SaveStr = base.CommandCollection[0].CommandText;
                base.CommandCollection[0].CommandText = SelectStr;
                int result = Fill(dataTable);
                base.CommandCollection[0].CommandText = SaveStr;
                return result;
            }
        }
        MyPhotoAdapter PhotoAdapter = new MyPhotoAdapter();



        private void FormRecipe_Load(object sender, EventArgs e)
        {
            var ingredientAdapter = new MyIngredientAdapter();

            productAdapter.Connection.ConnectionString      = DB.SqlConnectString(MyFunction.HardwareCfg);
            ingredientAdapter.Connection.ConnectionString   = DB.SqlConnectString(MyFunction.HardwareCfg);
            recipeAdapter.Connection.ConnectionString       = DB.SqlConnectString(MyFunction.HardwareCfg);
            recipeDetailAdapter.Connection.ConnectionString = DB.SqlConnectString(MyFunction.HardwareCfg);
            PhotoAdapter.Connection.ConnectionString        = DB.SqlConnectString(MyFunction.HardwareCfg);
            try
            {
                
                recipeBindingSource.DataSource = m_DataSet;
                m_PhotoDirectoryExist = Directory.Exists(PhotoPath());
　　　　　　　　 // fKRecipeRecipeDetailBindingSource,damaiDataSet recipeSqlBindingSource創來抄的, 實際上沒用到
                fKRecipeRecipeDetailBindingSource.DataSource = recipeBindingSource;
                dgvRecipeDetail.DataSource = fKRecipeRecipeDetailBindingSource;
                productBindingSource.DataSource = m_DataSet;
                productAdapter.Fill(m_DataSet.Product);

                recipeAdapter.Fill      (m_DataSet.Recipe);
                recipeDetailAdapter.Fill(m_DataSet.RecipeDetail);
                ingredientAdapter.Fill  (m_DataSet.Ingredient);
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入產品食材及配方錯誤!原因:" + ex.Message);
            }
            // 填給使用者選的產品表, 第一個為空白
            m_ProductList = new List<CNameIDForComboBox>();
            m_ProductList.Add(new CNameIDForComboBox(0, " "));
            foreach (var product in m_DataSet.Product)
            {
                if (product.IsCodeNull()) continue;
                if (product.Code <= 0) continue;
                m_ProductList.Add(new CNameIDForComboBox(product.ProductID, product.Name));
            }
            this.cNameIDForProductBindingSource.DataSource = m_ProductList;
            // 填 食材+配方表 (RecipeID +10000)
            m_SourceList = new List<CNameIDForComboBox>();
            foreach (var ing in m_DataSet.Ingredient)
            {
                string name;
                if (ing.IsNameNull()) name = "食材" + ing.IngredientID.ToString();
                else name = ing.Name;
                if (!ing.CanPurchase)
                    name = "**" + name;
                m_SourceList.Add(new CNameIDForComboBox(ing.IngredientID, name));
            }
            foreach (var recipe in m_DataSet.Recipe)
            {
                //if (recipe.IsFinalProductIDNull() || recipe.FinalProductID <= 0)   // 該配方沒有最終產品,才列入
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
                this.fKRecipeRecipeDetailBindingSource.EndEdit();
                UpdateRtf();
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤原因:" + ex.Message);
                return;
            }
            var table  = (MyRecipeTable)      m_DataSet.Recipe.GetChanges();
            var detail = (MyRecipeDetailTable)m_DataSet.RecipeDetail.GetChanges();
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
                    n = recipeAdapter.Update(table);
                    m_DataSet.Recipe.Merge(table);
                    m_DataSet.Recipe.AcceptChanges();
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
                    int n1 = recipeDetailAdapter.Update(detail);
                    m_DataSet.RecipeDetail.Merge(detail);
                    m_DataSet.RecipeDetail.AcceptChanges();
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
            MyFunction.AddNewItem(dgvRecipe, "dgvColumnID", "RecipeID", m_DataSet.Recipe);
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
            var row = rowView.Row as MyRecipeRow;
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
        MyRecipeRow m_OldRow=null;
        private void BindingRtf()
        {
            if (recipeBindingSource.Current == null) return;
            DataRowView rowView = recipeBindingSource.Current as DataRowView;
            var row = rowView.Row as MyRecipeRow;
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

        #region ========================== Photo相關程序 ==================================
        bool m_PhotoDirectoryExist = false;

        string PhotoPath() { return MapPath.DataDir + "Photos\\Recipes\\"; } 

        int CurrentPhotoID()
        {
            DataRowView rowView = recipeBindingSource.Current as DataRowView;
            if (rowView == null) return -1;
            var row = rowView.Row as MyRecipeRow;
            try
            {
                if (row.RecipeID <= 0) return -1;
            }
            catch { return -1; }
            return row.RecipeID;
        }

        string CurrentPhotoPath()
        {
            int id = CurrentPhotoID();
            if (id < 0) return null;
            return PhotoPath() + id.ToString() + ".jpg";
        }

        bool ShowPhotoFile(string path)
        {
            if (!photoPictureBox.Visible) return false;
            if (path != null && File.Exists(path))
            {
                photoPictureBox.ImageLocation = path;
                return true;
            }
            else
            {
                photoPictureBox.Image = null;
                photoPictureBox.ImageLocation = null;
                return false;
            }
        }


        private void SavePicture()
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            string ext = Path.GetExtension(openFileDialog1.FileName).ToLower();
            if (ext != ".jpg")
            {
                MessageBox.Show("對不起!只接受jpg檔");
                return;
            }
            int recipeID = CurrentPhotoID();
            if (recipeID < 0)
            {
                MessageBox.Show("無法取得本筆配方 RecipeID , 無法繼續存檔!");
                return;
            }
            var photos = from r in m_DataSet.Photos where r.PhotoID == recipeID && r.TableID == (short)PhotoTableID.Recipe select r;
            MyDataSet.PhotosRow photo = null;
            if (photos.Count() > 0) photo = photos.First();
            photo=SavePhotoFileToDB(openFileDialog1.FileName, recipeID, (short)PhotoTableID.Recipe, 384, 256, photo);
            ShowPhotoDB(photo);
        }

        private void pictureBoxRecipe_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            SavePicture();
        }

#if (UseSQLServer)
        void ShowPhotoDB(MyDataSet.PhotosRow row)
        {
            if (row == null || row.IsPhotoNull()) return;
            MemoryStream stream = new MemoryStream(row.Photo);
            Image bmp = Image.FromStream(stream);
            photoPictureBox.Image = bmp;
        }

        private MyDataSet.PhotosRow SavePhotoFileToDB(string fileName, int id, short tableID, int width, int height, MyDataSet.PhotosRow photo) // photo==null 就新增
        {
            Cursor = Cursors.WaitCursor;
            MD5 MD5Provider = new MD5CryptoServiceProvider();
            try
            {
                Bitmap img = (Bitmap)(Bitmap.FromFile(fileName));
                Bitmap shrank = MyFunction.ShrinkBitmap(img, width, height);    // 使用SQLServer時,只存縮圖以節省網路傳輸時間, 產品統一尺寸 W240 H160
                MemoryStream stream = new MemoryStream();
                shrank.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                if (photo == null)
                {
                    photo = m_DataSet.Photos.NewPhotosRow();
                    photo.TableID = tableID;
                    photo.PhotoID = id;
                    photo.Photo = stream.ToArray();
                    photo.UpdatedTime = DateTime.Now;
                    photo.MD5 = MD5Provider.ComputeHash(photo.Photo);
                    m_DataSet.Photos.AddPhotosRow(photo);
                }
                else
                {
                    photo.Photo = stream.ToArray();
                    photo.UpdatedTime = DateTime.Now;
                    photo.MD5 = MD5Provider.ComputeHash(photo.Photo);
                }
                PhotoAdapter.Update(m_DataSet.Photos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("存配方照片<" + id.ToString() + ">時出錯!原因:" + ex.Message);
            }
            Cursor = Cursors.Arrow;
            return photo;
        }


        void TryShowPhoto(int id, short tableID, string name, int width, int height)
        {
            if (id < 0) return;
            // 先找m_DataSet裏有沒有
            var photos = from r in m_DataSet.Photos where r.PhotoID == id && r.TableID == tableID select r;
            if (photos.Count() <= 0)
            {
                // 再從資料庫找找看
                string sqlStr = "Select * From Photos Where PhotoID=" + id.ToString() + "And TableID=" + tableID.ToString();
                int n = PhotoAdapter.FillBySelectStr(m_DataSet.Photos, sqlStr);
                photos = from r in m_DataSet.Photos where r.PhotoID == id && r.TableID == tableID select r;
                if (photos.Count() > 0)
                {
                    ShowPhotoDB(photos.First());
                    return;
                }
                if (!m_PhotoDirectoryExist)
                {
                    photoPictureBox.Image = null;
                    return;
                }
                // 照片資料庫中不存在,找找當前目錄中有沒有
                string path = CurrentPhotoPath();
                if (!ShowPhotoFile(path)) return;    // 若有圖,就存到資料庫中
                SavePhotoFileToDB(path, id, tableID, width, height, null);
                return;
            }
            else
            {
                var photo = photos.First();
                ShowPhotoDB(photo);
                if (photo.IsMD5Null())
                {
                    MD5 Md5Provider = new MD5CryptoServiceProvider();
                    try
                    {
                        photo.MD5 = Md5Provider.ComputeHash(photo.Photo);
                        PhotoAdapter.Update(photo);
                    }
                    catch { }
                }
            }
        }
#endif
        #endregion

        private void recipeBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (m_ProductList == null || m_ProductList.Count <= 0) return;
            ShowProductName();
            TryShowPhoto(CurrentPhotoID(), (short)PhotoTableID.Recipe, "配方", 384, 256);

            CalcWeight();
            UpdateRtf();
            BindingRtf();
        }

        // BindingSource.BindingComplete 有幾個Control Bind就會呼叫幾次,不能用,第一次只好放在Form_Show內顯示
        private void FormRecipe_Shown(object sender, EventArgs e)
        {   // 參照Ingredient.cs解法和這裏不同
            // 第一次Shown時, finalProductIDComboBox.SelectedValue會被改成0, 先在這Shown就可以搶蓋回來, @@"  
            recipeBindingSource_CurrentChanged(null, null);
            m_DataSet.Recipe.AcceptChanges();  // 不知為何第一次進來,第一筆就被當做有改過,所以加了這行.可能用rtf的副作用
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
                var row = rowView.Row as MyRecipeRow;
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

        private decimal CalcCost(decimal ratio,MyRecipeDetailRow[] details, List<int> usedRecipes)  // usedRecipes填入己使用的配方,避免Recursive
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
                    var ingredients = from ing in m_DataSet.Ingredient where ing.IngredientID == d.SourceID select ing;
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
                        var recipes = from row in m_DataSet.Recipe where (row.RowState!=DataRowState.Deleted) && (row.RecipeID == recipeID) select row;
                        if (recipes.Count() > 0)
                        {
                            usedRecipes.Add(recipeID);
                            var recipe = recipes.First();
                            var details1 = recipe.GetRecipeDetailRows();
                            decimal we1 = 0;
                            foreach (var r in details1)
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
            var row = rowView.Row as MyRecipeRow;
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
            Form form = new FormRecipePriceUpdate(packageNo,bakedNo,details,m_DataSet);
            if (form.ShowDialog()==DialogResult.OK)
            {
                if (row.IsFinalProductIDNull() || row.FinalProductID <= 0)
                {
                    MessageBox.Show("沒有最終產品,無可更新!");
                    return;
                }
                var products = from pr in m_DataSet.Product where pr.ProductID == row.FinalProductID select pr;
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
                    productAdapter.Update(product);
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
            var row = rowView.Row as MyRecipeRow;
            var details = row.GetRecipeDetailRows();
            foreach (var d in details)
                d.Delete();
            this.fKRecipeRecipeDetailBindingSource.ResetBindings(false);
            string name;
            if (row.IsRecipeNameNull())
                name = "配方<" + row.RecipeID.ToString() + ">";
            else name = row.RecipeName;
            row.Delete();
            recipeBindingSource.ResetBindings(false);
            MessageBox.Show(name + " 己刪除,請按存檔更新資料庫");
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
                    productAdapter.Update(m_DataSet.Product);
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
