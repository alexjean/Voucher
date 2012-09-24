using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

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
            photoPictureBox.Visible = Directory.Exists("Photos");

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

        string CurrentPhotoPath()
        {
            DataRowView rowView = IngredientBindingSource.Current as DataRowView;
            VEDataSet.IngredientRow row = rowView.Row as VEDataSet.IngredientRow;
            return "Photos\\" + row.IngredientID.ToString() + ".jpg";
        }

        Size SizeSave = new Size(0, 0);
        Point LocationSave = new Point(0, 0);
        private void photoPictureBox_Click(object sender, EventArgs e)
        {
            if (!photoPictureBox.Visible) return;
            if (photoPictureBox.ImageLocation == null)
            {
                photoPictureBox_DoubleClick(null,null);
                return;
            }
            if (LocationSave.X == 0)
            {
                SizeSave = photoPictureBox.Size;
                LocationSave = photoPictureBox.Location;
            }
            if (photoPictureBox.Location.X == 0)
            {
                photoPictureBox.Location = LocationSave;
                photoPictureBox.Size = SizeSave;
            }
            else
            {
                photoPictureBox.Location = new Point(0, 0);
                photoPictureBox.Size = this.Size;
                photoPictureBox.BringToFront();
            }
        }

        private void IngredientBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (!photoPictureBox.Visible) return;
            if (photoPictureBox.Location.X == 0)
            {
                photoPictureBox.Location = LocationSave;
                photoPictureBox.Size = SizeSave;
            }
            string path = CurrentPhotoPath();
            if (File.Exists(path))
                photoPictureBox.ImageLocation = path;
            else
                photoPictureBox.ImageLocation = null;

        }

        private void photoPictureBox_DoubleClick(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            string ext = Path.GetExtension(openFileDialog1.FileName).ToLower();
            if (ext != ".jpg")
            {
                MessageBox.Show("對不起!只接受jpg檔");
                return;
            }
            string path = CurrentPhotoPath();
            File.Copy(openFileDialog1.FileName, path, true);
            photoPictureBox.ImageLocation = path;
        }

     
    }
}