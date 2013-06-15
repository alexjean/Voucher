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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecipe));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.recipeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recipeTableAdapter = new VoucherExpense.VEDataSetTableAdapters.RecipeTableAdapter();
            this.recipeBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.recipeBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.dgvRecipe = new System.Windows.Forms.DataGridView();
            this.dgvColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finalProductIDComboBox = new System.Windows.Forms.ComboBox();
            this.cNameIDForProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bakeryOrderSet = new VoucherExpense.BakeryOrderSet();
            this.dgvRecipeDetail = new System.Windows.Forms.DataGridView();
            this.ColumnDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSourceID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ColumnWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipeRecipeDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxIngredientWeight = new System.Windows.Forms.TextBox();
            this.pictureBoxRecipe = new System.Windows.Forms.PictureBox();
            this.recipeNameTextBox = new System.Windows.Forms.TextBox();
            this.packageNoTextBox = new System.Windows.Forms.TextBox();
            this.productTableAdapter = new VoucherExpense.BakeryOrderSetTableAdapters.ProductTableAdapter();
            this.btnExcel = new System.Windows.Forms.Button();
            this.richTextBoxInstruction1 = new System.Windows.Forms.RichTextBox();
            this.btnRed = new System.Windows.Forms.Button();
            this.btnBlue = new System.Windows.Forms.Button();
            this.richTextBoxInstruction2 = new System.Windows.Forms.RichTextBox();
            this.btnBlack = new System.Windows.Forms.Button();
            this.recipeDetailTableAdapter = new VoucherExpense.VEDataSetTableAdapters.RecipeDetailTableAdapter();
            this.ingredientTableAdapter = new VoucherExpense.VEDataSetTableAdapters.IngredientTableAdapter();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBoxFloatCost = new System.Windows.Forms.TextBox();
            this.btnUpdateEvaluatedCost = new System.Windows.Forms.Button();
            this.bakedNoTextBox = new System.Windows.Forms.TextBox();
            finalProductIDLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            recipeNameLabel = new System.Windows.Forms.Label();
            packageNoLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeBindingNavigator)).BeginInit();
            this.recipeBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNameIDForProductBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipeDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeRecipeDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRecipe)).BeginInit();
            this.SuspendLayout();
            // 
            // finalProductIDLabel
            // 
            finalProductIDLabel.AutoSize = true;
            finalProductIDLabel.Location = new System.Drawing.Point(379, 4);
            finalProductIDLabel.Name = "finalProductIDLabel";
            finalProductIDLabel.Size = new System.Drawing.Size(40, 16);
            finalProductIDLabel.TabIndex = 2;
            finalProductIDLabel.Text = "產品";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(788, 372);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 16);
            label1.TabIndex = 11;
            label1.Text = "原料重";
            // 
            // recipeNameLabel
            // 
            recipeNameLabel.AutoSize = true;
            recipeNameLabel.Location = new System.Drawing.Point(158, 4);
            recipeNameLabel.Name = "recipeNameLabel";
            recipeNameLabel.Size = new System.Drawing.Size(56, 16);
            recipeNameLabel.TabIndex = 13;
            recipeNameLabel.Text = "配方名";
            // 
            // packageNoLabel
            // 
            packageNoLabel.AutoSize = true;
            packageNoLabel.Location = new System.Drawing.Point(356, 372);
            packageNoLabel.Name = "packageNoLabel";
            packageNoLabel.Size = new System.Drawing.Size(72, 16);
            packageNoLabel.TabIndex = 14;
            packageNoLabel.Text = "包裝單位";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(482, 372);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(24, 16);
            label2.TabIndex = 23;
            label2.Text = "個";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(161, 342);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(72, 16);
            label3.TabIndex = 24;
            label3.Text = "浮動成本";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(936, 371);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(24, 16);
            label4.TabIndex = 26;
            label4.Text = "克";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(311, 342);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(24, 16);
            label5.TabIndex = 27;
            label5.Text = "元";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(356, 342);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(72, 16);
            label6.TabIndex = 29;
            label6.Text = "烘成數量";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(482, 342);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(24, 16);
            label7.TabIndex = 31;
            label7.Text = "個";
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
            this.recipeBindingSource.CurrentChanged += new System.EventHandler(this.recipeBindingSource_CurrentChanged);
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
            this.recipeBindingNavigator.DeleteItem = null;
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
            this.recipeBindingNavigator.Size = new System.Drawing.Size(81, 25);
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
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
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
            this.dgvRecipe.AllowUserToResizeRows = false;
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
            this.dgvRecipe.Size = new System.Drawing.Size(156, 647);
            this.dgvRecipe.TabIndex = 1;
            // 
            // dgvColumnID
            // 
            this.dgvColumnID.DataPropertyName = "RecipeID";
            this.dgvColumnID.HeaderText = "RecipeID";
            this.dgvColumnID.Name = "dgvColumnID";
            this.dgvColumnID.ReadOnly = true;
            this.dgvColumnID.Visible = false;
            // 
            // dgvColumnName
            // 
            this.dgvColumnName.DataPropertyName = "RecipeName";
            this.dgvColumnName.HeaderText = "配方名";
            this.dgvColumnName.Name = "dgvColumnName";
            this.dgvColumnName.ReadOnly = true;
            this.dgvColumnName.Width = 130;
            // 
            // finalProductIDComboBox
            // 
            this.finalProductIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.recipeBindingSource, "FinalProductID", true));
            this.finalProductIDComboBox.DataSource = this.cNameIDForProductBindingSource;
            this.finalProductIDComboBox.DisplayMember = "Name";
            this.finalProductIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.finalProductIDComboBox.FormattingEnabled = true;
            this.finalProductIDComboBox.Location = new System.Drawing.Point(425, 0);
            this.finalProductIDComboBox.Name = "finalProductIDComboBox";
            this.finalProductIDComboBox.Size = new System.Drawing.Size(121, 24);
            this.finalProductIDComboBox.TabIndex = 3;
            this.finalProductIDComboBox.ValueMember = "ID";
            // 
            // cNameIDForProductBindingSource
            // 
            this.cNameIDForProductBindingSource.DataSource = typeof(VoucherExpense.CNameIDForComboBox);
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.bakeryOrderSet;
            // 
            // bakeryOrderSet
            // 
            this.bakeryOrderSet.DataSetName = "BakeryOrderSet";
            this.bakeryOrderSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvRecipeDetail
            // 
            this.dgvRecipeDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dgvRecipeDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecipeDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecipeDetail.AutoGenerateColumns = false;
            this.dgvRecipeDetail.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.dgvRecipeDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecipeDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDetailID,
            this.recipeIDDataGridViewTextBoxColumn,
            this.displayCodeDataGridViewTextBoxColumn,
            this.ColumnSourceID,
            this.ColumnWeight});
            this.dgvRecipeDetail.DataSource = this.recipeRecipeDetailBindingSource;
            this.dgvRecipeDetail.Location = new System.Drawing.Point(555, 4);
            this.dgvRecipeDetail.Name = "dgvRecipeDetail";
            this.dgvRecipeDetail.RowHeadersWidth = 25;
            this.dgvRecipeDetail.RowTemplate.Height = 24;
            this.dgvRecipeDetail.Size = new System.Drawing.Size(405, 360);
            this.dgvRecipeDetail.TabIndex = 10;
            this.dgvRecipeDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecipeDetail_CellValueChanged);
            this.dgvRecipeDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvRecipeDetail_DataError);
            this.dgvRecipeDetail.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvRecipeDetail_DefaultValuesNeeded);
            // 
            // ColumnDetailID
            // 
            this.ColumnDetailID.DataPropertyName = "DetailID";
            this.ColumnDetailID.HeaderText = "DetailID";
            this.ColumnDetailID.Name = "ColumnDetailID";
            this.ColumnDetailID.Visible = false;
            // 
            // recipeIDDataGridViewTextBoxColumn
            // 
            this.recipeIDDataGridViewTextBoxColumn.DataPropertyName = "RecipeID";
            this.recipeIDDataGridViewTextBoxColumn.HeaderText = "RecipeID";
            this.recipeIDDataGridViewTextBoxColumn.Name = "recipeIDDataGridViewTextBoxColumn";
            this.recipeIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // displayCodeDataGridViewTextBoxColumn
            // 
            this.displayCodeDataGridViewTextBoxColumn.DataPropertyName = "DisplayCode";
            this.displayCodeDataGridViewTextBoxColumn.HeaderText = "代碼";
            this.displayCodeDataGridViewTextBoxColumn.MaxInputLength = 3;
            this.displayCodeDataGridViewTextBoxColumn.Name = "displayCodeDataGridViewTextBoxColumn";
            this.displayCodeDataGridViewTextBoxColumn.Width = 64;
            // 
            // ColumnSourceID
            // 
            this.ColumnSourceID.DataPropertyName = "SourceID";
            this.ColumnSourceID.DataSource = this.sourceBindingSource;
            this.ColumnSourceID.DisplayMember = "Name";
            this.ColumnSourceID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnSourceID.HeaderText = "食材或配方名";
            this.ColumnSourceID.Name = "ColumnSourceID";
            this.ColumnSourceID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSourceID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnSourceID.ValueMember = "ID";
            this.ColumnSourceID.Width = 192;
            // 
            // sourceBindingSource
            // 
            this.sourceBindingSource.DataSource = typeof(VoucherExpense.CNameIDForComboBox);
            // 
            // ColumnWeight
            // 
            this.ColumnWeight.DataPropertyName = "Weight";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.ColumnWeight.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnWeight.HeaderText = "重量-克";
            this.ColumnWeight.Name = "ColumnWeight";
            // 
            // recipeRecipeDetailBindingSource
            // 
            this.recipeRecipeDetailBindingSource.DataMember = "RecipeRecipeDetail";
            this.recipeRecipeDetailBindingSource.DataSource = this.recipeBindingSource;
            // 
            // textBoxIngredientWeight
            // 
            this.textBoxIngredientWeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.textBoxIngredientWeight.Location = new System.Drawing.Point(855, 367);
            this.textBoxIngredientWeight.Name = "textBoxIngredientWeight";
            this.textBoxIngredientWeight.Size = new System.Drawing.Size(73, 27);
            this.textBoxIngredientWeight.TabIndex = 12;
            this.textBoxIngredientWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pictureBoxRecipe
            // 
            this.pictureBoxRecipe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxRecipe.Location = new System.Drawing.Point(161, 69);
            this.pictureBoxRecipe.Name = "pictureBoxRecipe";
            this.pictureBoxRecipe.Size = new System.Drawing.Size(384, 256);
            this.pictureBoxRecipe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRecipe.TabIndex = 13;
            this.pictureBoxRecipe.TabStop = false;
            this.pictureBoxRecipe.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxRecipe_MouseClick);
            // 
            // recipeNameTextBox
            // 
            this.recipeNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipeBindingSource, "RecipeName", true));
            this.recipeNameTextBox.Location = new System.Drawing.Point(213, -1);
            this.recipeNameTextBox.Name = "recipeNameTextBox";
            this.recipeNameTextBox.Size = new System.Drawing.Size(149, 27);
            this.recipeNameTextBox.TabIndex = 14;
            // 
            // packageNoTextBox
            // 
            this.packageNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipeBindingSource, "PackageNo", true));
            this.packageNoTextBox.Location = new System.Drawing.Point(432, 367);
            this.packageNoTextBox.Name = "packageNoTextBox";
            this.packageNoTextBox.Size = new System.Drawing.Size(46, 27);
            this.packageNoTextBox.TabIndex = 15;
            this.packageNoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.packageNoTextBox.Validated += new System.EventHandler(this.packageNoTextBox_Validated);
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
            this.btnExcel.Visible = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // richTextBoxInstruction1
            // 
            this.richTextBoxInstruction1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxInstruction1.DataBindings.Add(new System.Windows.Forms.Binding("Rtf", this.recipeBindingSource, "Instruction1", true));
            this.richTextBoxInstruction1.Location = new System.Drawing.Point(161, 399);
            this.richTextBoxInstruction1.MaxLength = 32767;
            this.richTextBoxInstruction1.Name = "richTextBoxInstruction1";
            this.richTextBoxInstruction1.Size = new System.Drawing.Size(388, 276);
            this.richTextBoxInstruction1.TabIndex = 17;
            this.richTextBoxInstruction1.Text = "";
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.Red;
            this.btnRed.Location = new System.Drawing.Point(623, 371);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(28, 23);
            this.btnRed.TabIndex = 19;
            this.btnRed.UseVisualStyleBackColor = false;
            this.btnRed.Click += new System.EventHandler(this.btnRed_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnBlue.Location = new System.Drawing.Point(589, 371);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(28, 23);
            this.btnBlue.TabIndex = 20;
            this.btnBlue.UseVisualStyleBackColor = false;
            this.btnBlue.Click += new System.EventHandler(this.btnBlue_Click);
            // 
            // richTextBoxInstruction2
            // 
            this.richTextBoxInstruction2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxInstruction2.DataBindings.Add(new System.Windows.Forms.Binding("Rtf", this.recipeBindingSource, "Instruction2", true));
            this.richTextBoxInstruction2.Location = new System.Drawing.Point(555, 399);
            this.richTextBoxInstruction2.MaxLength = 32767;
            this.richTextBoxInstruction2.Name = "richTextBoxInstruction2";
            this.richTextBoxInstruction2.Size = new System.Drawing.Size(405, 276);
            this.richTextBoxInstruction2.TabIndex = 21;
            this.richTextBoxInstruction2.Text = "";
            // 
            // btnBlack
            // 
            this.btnBlack.BackColor = System.Drawing.Color.Black;
            this.btnBlack.Location = new System.Drawing.Point(555, 371);
            this.btnBlack.Name = "btnBlack";
            this.btnBlack.Size = new System.Drawing.Size(28, 23);
            this.btnBlack.TabIndex = 22;
            this.btnBlack.UseVisualStyleBackColor = false;
            this.btnBlack.Click += new System.EventHandler(this.btnBlack_Click);
            // 
            // recipeDetailTableAdapter
            // 
            this.recipeDetailTableAdapter.ClearBeforeFill = true;
            // 
            // ingredientTableAdapter
            // 
            this.ingredientTableAdapter.ClearBeforeFill = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "jpg";
            // 
            // textBoxFloatCost
            // 
            this.textBoxFloatCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.textBoxFloatCost.Location = new System.Drawing.Point(230, 337);
            this.textBoxFloatCost.Name = "textBoxFloatCost";
            this.textBoxFloatCost.Size = new System.Drawing.Size(75, 27);
            this.textBoxFloatCost.TabIndex = 25;
            this.textBoxFloatCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnUpdateEvaluatedCost
            // 
            this.btnUpdateEvaluatedCost.Location = new System.Drawing.Point(164, 369);
            this.btnUpdateEvaluatedCost.Name = "btnUpdateEvaluatedCost";
            this.btnUpdateEvaluatedCost.Size = new System.Drawing.Size(171, 27);
            this.btnUpdateEvaluatedCost.TabIndex = 28;
            this.btnUpdateEvaluatedCost.Text = "更新 產品 估算成本";
            this.btnUpdateEvaluatedCost.UseVisualStyleBackColor = true;
            this.btnUpdateEvaluatedCost.Click += new System.EventHandler(this.btnUpdateEvaluatedCost_Click);
            // 
            // bakedNoTextBox
            // 
            this.bakedNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipeBindingSource, "BakedNo", true));
            this.bakedNoTextBox.Location = new System.Drawing.Point(432, 337);
            this.bakedNoTextBox.Name = "bakedNoTextBox";
            this.bakedNoTextBox.Size = new System.Drawing.Size(46, 27);
            this.bakedNoTextBox.TabIndex = 30;
            this.bakedNoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FormRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(963, 680);
            this.Controls.Add(label7);
            this.Controls.Add(this.bakedNoTextBox);
            this.Controls.Add(label6);
            this.Controls.Add(this.recipeNameTextBox);
            this.Controls.Add(this.btnUpdateEvaluatedCost);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(this.textBoxFloatCost);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(this.textBoxIngredientWeight);
            this.Controls.Add(this.packageNoTextBox);
            this.Controls.Add(this.btnBlack);
            this.Controls.Add(this.richTextBoxInstruction2);
            this.Controls.Add(this.btnBlue);
            this.Controls.Add(this.btnRed);
            this.Controls.Add(this.richTextBoxInstruction1);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(packageNoLabel);
            this.Controls.Add(recipeNameLabel);
            this.Controls.Add(this.pictureBoxRecipe);
            this.Controls.Add(label1);
            this.Controls.Add(this.dgvRecipeDetail);
            this.Controls.Add(finalProductIDLabel);
            this.Controls.Add(this.finalProductIDComboBox);
            this.Controls.Add(this.dgvRecipe);
            this.Controls.Add(this.recipeBindingNavigator);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormRecipe";
            this.ShowIcon = false;
            this.Text = "烘焙配方表";
            this.Load += new System.EventHandler(this.FormRecipe_Load);
            this.Shown += new System.EventHandler(this.FormRecipe_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeBindingNavigator)).EndInit();
            this.recipeBindingNavigator.ResumeLayout(false);
            this.recipeBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNameIDForProductBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipeDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeRecipeDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRecipe)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvRecipeDetail;
        private System.Windows.Forms.TextBox textBoxIngredientWeight;
        private System.Windows.Forms.PictureBox pictureBoxRecipe;
        private System.Windows.Forms.TextBox recipeNameTextBox;
        private System.Windows.Forms.TextBox packageNoTextBox;
        private BakeryOrderSet bakeryOrderSet;
        private System.Windows.Forms.BindingSource productBindingSource;
        private BakeryOrderSetTableAdapters.ProductTableAdapter productTableAdapter;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.RichTextBox richTextBoxInstruction1;
        private System.Windows.Forms.Button btnRed;
        private System.Windows.Forms.Button btnBlue;
        private System.Windows.Forms.RichTextBox richTextBoxInstruction2;
        private System.Windows.Forms.Button btnBlack;
        private System.Windows.Forms.BindingSource cNameIDForProductBindingSource;
        private System.Windows.Forms.BindingSource recipeRecipeDetailBindingSource;
        private VEDataSetTableAdapters.RecipeDetailTableAdapter recipeDetailTableAdapter;
        private System.Windows.Forms.BindingSource sourceBindingSource;
        private VEDataSetTableAdapters.IngredientTableAdapter ingredientTableAdapter;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBoxFloatCost;
        private System.Windows.Forms.Button btnUpdateEvaluatedCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn recipeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnSourceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnName;
        private System.Windows.Forms.TextBox bakedNoTextBox;
    }
}