namespace VoucherExpense
{
    partial class FormRecipe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label finalProductIDLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label recipeNameLabel;
            System.Windows.Forms.Label packageNoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecipe));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.recipeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recipeTableAdapter = new VoucherExpense.VEDataSetTableAdapters.RecipeTableAdapter();
            this.recipeBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.recipeBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.dgvRecipe = new System.Windows.Forms.DataGridView();
            this.finalProductIDComboBox = new System.Windows.Forms.ComboBox();
            this.instruction1ListBox = new System.Windows.Forms.ListBox();
            this.instruction2ListBox = new System.Windows.Forms.ListBox();
            this.dgvRecipeDetail = new System.Windows.Forms.DataGridView();
            this.dgvColumnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnSourceName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvColumnWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBoxRecipe = new System.Windows.Forms.PictureBox();
            this.recipeNameTextBox = new System.Windows.Forms.TextBox();
            this.packageNoTextBox = new System.Windows.Forms.TextBox();
            this.bakeryOrderSet = new VoucherExpense.BakeryOrderSet();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productTableAdapter = new VoucherExpense.BakeryOrderSetTableAdapters.ProductTableAdapter();
            this.btnExcel = new System.Windows.Forms.Button();
            this.dgvColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            finalProductIDLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            recipeNameLabel = new System.Windows.Forms.Label();
            packageNoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeBindingNavigator)).BeginInit();
            this.recipeBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipeDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRecipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // finalProductIDLabel
            // 
            finalProductIDLabel.AutoSize = true;
            finalProductIDLabel.Location = new System.Drawing.Point(334, 5);
            finalProductIDLabel.Name = "finalProductIDLabel";
            finalProductIDLabel.Size = new System.Drawing.Size(40, 16);
            finalProductIDLabel.TabIndex = 2;
            finalProductIDLabel.Text = "產品";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(360, 382);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 16);
            label1.TabIndex = 11;
            label1.Text = "原料重";
            // 
            // recipeNameLabel
            // 
            recipeNameLabel.AutoSize = true;
            recipeNameLabel.Location = new System.Drawing.Point(158, 5);
            recipeNameLabel.Name = "recipeNameLabel";
            recipeNameLabel.Size = new System.Drawing.Size(56, 16);
            recipeNameLabel.TabIndex = 13;
            recipeNameLabel.Text = "配方名";
            // 
            // packageNoLabel
            // 
            packageNoLabel.AutoSize = true;
            packageNoLabel.Location = new System.Drawing.Point(158, 382);
            packageNoLabel.Name = "packageNoLabel";
            packageNoLabel.Size = new System.Drawing.Size(72, 16);
            packageNoLabel.TabIndex = 14;
            packageNoLabel.Text = "包裝單位";
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // recipeBindingSource
            // 
            this.recipeBindingSource.DataMember = "Recipe";
            this.recipeBindingSource.DataSource = this.vEDataSet;
            // 
            // recipeTableAdapter
            // 
            this.recipeTableAdapter.ClearBeforeFill = true;
            // 
            // recipeBindingNavigator
            // 
            this.recipeBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.recipeBindingNavigator.BindingSource = this.recipeBindingSource;
            this.recipeBindingNavigator.CountItem = null;
            this.recipeBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.recipeBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.recipeBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.recipeBindingNavigatorSaveItem});
            this.recipeBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.recipeBindingNavigator.MoveFirstItem = null;
            this.recipeBindingNavigator.MoveLastItem = null;
            this.recipeBindingNavigator.MoveNextItem = null;
            this.recipeBindingNavigator.MovePreviousItem = null;
            this.recipeBindingNavigator.Name = "recipeBindingNavigator";
            this.recipeBindingNavigator.PositionItem = null;
            this.recipeBindingNavigator.Size = new System.Drawing.Size(112, 25);
            this.recipeBindingNavigator.TabIndex = 0;
            this.recipeBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "加入新的";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "刪除";
            // 
            // recipeBindingNavigatorSaveItem
            // 
            this.recipeBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.recipeBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("recipeBindingNavigatorSaveItem.Image")));
            this.recipeBindingNavigatorSaveItem.Name = "recipeBindingNavigatorSaveItem";
            this.recipeBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.recipeBindingNavigatorSaveItem.Text = "儲存資料";
            this.recipeBindingNavigatorSaveItem.Click += new System.EventHandler(this.recipeBindingNavigatorSaveItem_Click);
            // 
            // dgvRecipe
            // 
            this.dgvRecipe.AllowUserToAddRows = false;
            this.dgvRecipe.AllowUserToDeleteRows = false;
            this.dgvRecipe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvRecipe.AutoGenerateColumns = false;
            this.dgvRecipe.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgvRecipe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecipe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColumnID,
            this.dgvColumnName});
            this.dgvRecipe.DataSource = this.recipeBindingSource;
            this.dgvRecipe.Location = new System.Drawing.Point(0, 28);
            this.dgvRecipe.Name = "dgvRecipe";
            this.dgvRecipe.ReadOnly = true;
            this.dgvRecipe.RowHeadersVisible = false;
            this.dgvRecipe.RowTemplate.Height = 24;
            this.dgvRecipe.Size = new System.Drawing.Size(141, 751);
            this.dgvRecipe.TabIndex = 1;
            // 
            // finalProductIDComboBox
            // 
            this.finalProductIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.recipeBindingSource, "FinalProductID", true));
            this.finalProductIDComboBox.DataSource = this.productBindingSource;
            this.finalProductIDComboBox.DisplayMember = "Name";
            this.finalProductIDComboBox.FormattingEnabled = true;
            this.finalProductIDComboBox.Location = new System.Drawing.Point(399, 1);
            this.finalProductIDComboBox.Name = "finalProductIDComboBox";
            this.finalProductIDComboBox.Size = new System.Drawing.Size(121, 24);
            this.finalProductIDComboBox.TabIndex = 3;
            this.finalProductIDComboBox.ValueMember = "ProductID";
            // 
            // instruction1ListBox
            // 
            this.instruction1ListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.instruction1ListBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.recipeBindingSource, "Instruction1", true));
            this.instruction1ListBox.FormattingEnabled = true;
            this.instruction1ListBox.ItemHeight = 16;
            this.instruction1ListBox.Location = new System.Drawing.Point(147, 417);
            this.instruction1ListBox.Name = "instruction1ListBox";
            this.instruction1ListBox.Size = new System.Drawing.Size(397, 356);
            this.instruction1ListBox.TabIndex = 8;
            // 
            // instruction2ListBox
            // 
            this.instruction2ListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.instruction2ListBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.recipeBindingSource, "Instruction2", true));
            this.instruction2ListBox.FormattingEnabled = true;
            this.instruction2ListBox.ItemHeight = 16;
            this.instruction2ListBox.Location = new System.Drawing.Point(549, 417);
            this.instruction2ListBox.Name = "instruction2ListBox";
            this.instruction2ListBox.Size = new System.Drawing.Size(397, 356);
            this.instruction2ListBox.TabIndex = 9;
            // 
            // dgvRecipeDetail
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Azure;
            this.dgvRecipeDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvRecipeDetail.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.dgvRecipeDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecipeDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColumnCode,
            this.dgvColumnSourceName,
            this.dgvColumnWeight});
            this.dgvRecipeDetail.Location = new System.Drawing.Point(549, 0);
            this.dgvRecipeDetail.Name = "dgvRecipeDetail";
            this.dgvRecipeDetail.RowHeadersVisible = false;
            this.dgvRecipeDetail.RowTemplate.Height = 24;
            this.dgvRecipeDetail.Size = new System.Drawing.Size(397, 411);
            this.dgvRecipeDetail.TabIndex = 10;
            // 
            // dgvColumnCode
            // 
            this.dgvColumnCode.HeaderText = "";
            this.dgvColumnCode.Name = "dgvColumnCode";
            this.dgvColumnCode.Width = 40;
            // 
            // dgvColumnSourceName
            // 
            this.dgvColumnSourceName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dgvColumnSourceName.HeaderText = "原料品名";
            this.dgvColumnSourceName.Name = "dgvColumnSourceName";
            this.dgvColumnSourceName.Width = 120;
            // 
            // dgvColumnWeight
            // 
            this.dgvColumnWeight.HeaderText = "重量";
            this.dgvColumnWeight.Name = "dgvColumnWeight";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipeBindingSource, "TotalWeight", true));
            this.textBox1.Location = new System.Drawing.Point(422, 377);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 27);
            this.textBox1.TabIndex = 12;
            // 
            // pictureBoxRecipe
            // 
            this.pictureBoxRecipe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxRecipe.Location = new System.Drawing.Point(161, 31);
            this.pictureBoxRecipe.Name = "pictureBoxRecipe";
            this.pictureBoxRecipe.Size = new System.Drawing.Size(361, 330);
            this.pictureBoxRecipe.TabIndex = 13;
            this.pictureBoxRecipe.TabStop = false;
            // 
            // recipeNameTextBox
            // 
            this.recipeNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipeBindingSource, "RecipeName", true));
            this.recipeNameTextBox.Location = new System.Drawing.Point(213, 0);
            this.recipeNameTextBox.Name = "recipeNameTextBox";
            this.recipeNameTextBox.Size = new System.Drawing.Size(100, 27);
            this.recipeNameTextBox.TabIndex = 14;
            // 
            // packageNoTextBox
            // 
            this.packageNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipeBindingSource, "PackageNo", true));
            this.packageNoTextBox.Location = new System.Drawing.Point(236, 377);
            this.packageNoTextBox.Name = "packageNoTextBox";
            this.packageNoTextBox.Size = new System.Drawing.Size(100, 27);
            this.packageNoTextBox.TabIndex = 15;
            // 
            // bakeryOrderSet
            // 
            this.bakeryOrderSet.DataSetName = "BakeryOrderSet";
            this.bakeryOrderSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.bakeryOrderSet;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(87, -1);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(54, 27);
            this.btnExcel.TabIndex = 16;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // dgvColumnID
            // 
            this.dgvColumnID.DataPropertyName = "RecipeID";
            this.dgvColumnID.HeaderText = "RecipeID";
            this.dgvColumnID.Name = "dgvColumnID";
            this.dgvColumnID.Visible = false;
            // 
            // dgvColumnName
            // 
            this.dgvColumnName.DataPropertyName = "RecipeName";
            this.dgvColumnName.HeaderText = "配方名";
            this.dgvColumnName.Name = "dgvColumnName";
            this.dgvColumnName.Width = 120;
            // 
            // FormRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(966, 780);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(packageNoLabel);
            this.Controls.Add(this.packageNoTextBox);
            this.Controls.Add(recipeNameLabel);
            this.Controls.Add(this.recipeNameTextBox);
            this.Controls.Add(this.pictureBoxRecipe);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgvRecipeDetail);
            this.Controls.Add(this.instruction2ListBox);
            this.Controls.Add(this.instruction1ListBox);
            this.Controls.Add(finalProductIDLabel);
            this.Controls.Add(this.finalProductIDComboBox);
            this.Controls.Add(this.dgvRecipe);
            this.Controls.Add(this.recipeBindingNavigator);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormRecipe";
            this.Text = "烘焙配方表";
            this.Load += new System.EventHandler(this.FormRecipe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeBindingNavigator)).EndInit();
            this.recipeBindingNavigator.ResumeLayout(false);
            this.recipeBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipeDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRecipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource recipeBindingSource;
        private VEDataSetTableAdapters.RecipeTableAdapter recipeTableAdapter;
        private System.Windows.Forms.BindingNavigator recipeBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton recipeBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView dgvRecipe;
        private System.Windows.Forms.ComboBox finalProductIDComboBox;
        private System.Windows.Forms.ListBox instruction1ListBox;
        private System.Windows.Forms.ListBox instruction2ListBox;
        private System.Windows.Forms.DataGridView dgvRecipeDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColumnSourceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnWeight;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBoxRecipe;
        private System.Windows.Forms.TextBox recipeNameTextBox;
        private System.Windows.Forms.TextBox packageNoTextBox;
        private BakeryOrderSet bakeryOrderSet;
        private System.Windows.Forms.BindingSource productBindingSource;
        private BakeryOrderSetTableAdapters.ProductTableAdapter productTableAdapter;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnName;
    }
}