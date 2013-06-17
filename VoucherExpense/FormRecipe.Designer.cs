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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelGross = new System.Windows.Forms.Label();
            this.labelEvaluatedCost = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
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
            this.groupBoxProduct = new System.Windows.Forms.GroupBox();
            this.btnUpdatePrice = new System.Windows.Forms.Button();
            this.textBoxGrossPercent = new System.Windows.Forms.TextBox();
            this.textBoxGross = new System.Windows.Forms.TextBox();
            this.textBoxEvaluatedCost = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.btnGreen = new System.Windows.Forms.Button();
            this.tableAdapterManager = new VoucherExpense.BakeryOrderSetTableAdapters.TableAdapterManager();
            this.btnYellow = new System.Windows.Forms.Button();
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
            this.groupBoxProduct.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(788, 376);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 16);
            label1.TabIndex = 11;
            label1.Text = "原料重";
            // 
            // recipeNameLabel
            // 
            recipeNameLabel.AutoSize = true;
            recipeNameLabel.Location = new System.Drawing.Point(159, 7);
            recipeNameLabel.Name = "recipeNameLabel";
            recipeNameLabel.Size = new System.Drawing.Size(56, 16);
            recipeNameLabel.TabIndex = 13;
            recipeNameLabel.Text = "配方名";
            // 
            // packageNoLabel
            // 
            packageNoLabel.AutoSize = true;
            packageNoLabel.Location = new System.Drawing.Point(788, 442);
            packageNoLabel.Name = "packageNoLabel";
            packageNoLabel.Size = new System.Drawing.Size(72, 16);
            packageNoLabel.TabIndex = 14;
            packageNoLabel.Text = "包裝單位";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(914, 442);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(24, 16);
            label2.TabIndex = 23;
            label2.Text = "個";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(568, 376);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(72, 16);
            label3.TabIndex = 24;
            label3.Text = "成本試算";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(936, 376);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(24, 16);
            label4.TabIndex = 26;
            label4.Text = "克";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(718, 376);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(24, 16);
            label5.TabIndex = 27;
            label5.Text = "元";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(788, 409);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(72, 16);
            label6.TabIndex = 29;
            label6.Text = "烘成數量";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(914, 409);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(24, 16);
            label7.TabIndex = 31;
            label7.Text = "個";
            // 
            // labelGross
            // 
            this.labelGross.AutoSize = true;
            this.labelGross.Location = new System.Drawing.Point(47, 122);
            this.labelGross.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGross.Name = "labelGross";
            this.labelGross.Size = new System.Drawing.Size(40, 16);
            this.labelGross.TabIndex = 32;
            this.labelGross.Text = "毛利";
            // 
            // labelEvaluatedCost
            // 
            this.labelEvaluatedCost.AutoSize = true;
            this.labelEvaluatedCost.Location = new System.Drawing.Point(47, 85);
            this.labelEvaluatedCost.Name = "labelEvaluatedCost";
            this.labelEvaluatedCost.Size = new System.Drawing.Size(72, 16);
            this.labelEvaluatedCost.TabIndex = 30;
            this.labelEvaluatedCost.Text = "估算成本";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(47, 48);
            this.labelPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(44, 16);
            this.labelPrice.TabIndex = 26;
            this.labelPrice.Text = "價格:";
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
            this.finalProductIDComboBox.Location = new System.Drawing.Point(52, 0);
            this.finalProductIDComboBox.Name = "finalProductIDComboBox";
            this.finalProductIDComboBox.Size = new System.Drawing.Size(149, 24);
            this.finalProductIDComboBox.TabIndex = 3;
            this.finalProductIDComboBox.ValueMember = "ID";
            this.finalProductIDComboBox.SelectedIndexChanged += new System.EventHandler(this.finalProductIDComboBox_SelectedIndexChanged);
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
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Azure;
            this.dgvRecipeDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N1";
            dataGridViewCellStyle4.NullValue = null;
            this.ColumnWeight.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnWeight.HeaderText = "重量-克";
            this.ColumnWeight.Name = "ColumnWeight";
            this.ColumnWeight.Width = 92;
            // 
            // recipeRecipeDetailBindingSource
            // 
            this.recipeRecipeDetailBindingSource.DataMember = "RecipeRecipeDetail";
            this.recipeRecipeDetailBindingSource.DataSource = this.recipeBindingSource;
            // 
            // textBoxIngredientWeight
            // 
            this.textBoxIngredientWeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.textBoxIngredientWeight.Location = new System.Drawing.Point(855, 371);
            this.textBoxIngredientWeight.Name = "textBoxIngredientWeight";
            this.textBoxIngredientWeight.Size = new System.Drawing.Size(73, 27);
            this.textBoxIngredientWeight.TabIndex = 12;
            this.textBoxIngredientWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pictureBoxRecipe
            // 
            this.pictureBoxRecipe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxRecipe.Location = new System.Drawing.Point(162, 32);
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
            this.recipeNameTextBox.Location = new System.Drawing.Point(213, 4);
            this.recipeNameTextBox.Name = "recipeNameTextBox";
            this.recipeNameTextBox.Size = new System.Drawing.Size(149, 27);
            this.recipeNameTextBox.TabIndex = 14;
            // 
            // packageNoTextBox
            // 
            this.packageNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipeBindingSource, "PackageNo", true));
            this.packageNoTextBox.Location = new System.Drawing.Point(864, 437);
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
            this.richTextBoxInstruction1.Location = new System.Drawing.Point(161, 472);
            this.richTextBoxInstruction1.MaxLength = 32767;
            this.richTextBoxInstruction1.Name = "richTextBoxInstruction1";
            this.richTextBoxInstruction1.Size = new System.Drawing.Size(388, 203);
            this.richTextBoxInstruction1.TabIndex = 17;
            this.richTextBoxInstruction1.Text = "";
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.Red;
            this.btnRed.Location = new System.Drawing.Point(642, 439);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(28, 23);
            this.btnRed.TabIndex = 19;
            this.btnRed.UseVisualStyleBackColor = false;
            this.btnRed.Click += new System.EventHandler(this.btnRed_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnBlue.Location = new System.Drawing.Point(606, 439);
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
            this.richTextBoxInstruction2.Location = new System.Drawing.Point(555, 472);
            this.richTextBoxInstruction2.MaxLength = 32767;
            this.richTextBoxInstruction2.Name = "richTextBoxInstruction2";
            this.richTextBoxInstruction2.Size = new System.Drawing.Size(405, 203);
            this.richTextBoxInstruction2.TabIndex = 21;
            this.richTextBoxInstruction2.Text = "";
            // 
            // btnBlack
            // 
            this.btnBlack.BackColor = System.Drawing.Color.Black;
            this.btnBlack.Location = new System.Drawing.Point(570, 439);
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
            this.textBoxFloatCost.Location = new System.Drawing.Point(637, 371);
            this.textBoxFloatCost.Name = "textBoxFloatCost";
            this.textBoxFloatCost.ReadOnly = true;
            this.textBoxFloatCost.Size = new System.Drawing.Size(75, 27);
            this.textBoxFloatCost.TabIndex = 25;
            this.textBoxFloatCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnUpdateEvaluatedCost
            // 
            this.btnUpdateEvaluatedCost.Location = new System.Drawing.Point(573, 404);
            this.btnUpdateEvaluatedCost.Name = "btnUpdateEvaluatedCost";
            this.btnUpdateEvaluatedCost.Size = new System.Drawing.Size(139, 27);
            this.btnUpdateEvaluatedCost.TabIndex = 28;
            this.btnUpdateEvaluatedCost.Text = "更新 估算成本";
            this.btnUpdateEvaluatedCost.UseVisualStyleBackColor = true;
            this.btnUpdateEvaluatedCost.Click += new System.EventHandler(this.btnUpdateEvaluatedCost_Click);
            // 
            // bakedNoTextBox
            // 
            this.bakedNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipeBindingSource, "BakedNo", true));
            this.bakedNoTextBox.Location = new System.Drawing.Point(864, 404);
            this.bakedNoTextBox.Name = "bakedNoTextBox";
            this.bakedNoTextBox.Size = new System.Drawing.Size(46, 27);
            this.bakedNoTextBox.TabIndex = 30;
            this.bakedNoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBoxProduct
            // 
            this.groupBoxProduct.Controls.Add(this.btnUpdatePrice);
            this.groupBoxProduct.Controls.Add(this.textBoxGrossPercent);
            this.groupBoxProduct.Controls.Add(this.textBoxGross);
            this.groupBoxProduct.Controls.Add(this.labelGross);
            this.groupBoxProduct.Controls.Add(this.labelEvaluatedCost);
            this.groupBoxProduct.Controls.Add(this.textBoxEvaluatedCost);
            this.groupBoxProduct.Controls.Add(this.labelPrice);
            this.groupBoxProduct.Controls.Add(this.textBoxPrice);
            this.groupBoxProduct.Controls.Add(this.textBoxCode);
            this.groupBoxProduct.Controls.Add(this.finalProductIDComboBox);
            this.groupBoxProduct.Location = new System.Drawing.Point(161, 294);
            this.groupBoxProduct.Name = "groupBoxProduct";
            this.groupBoxProduct.Size = new System.Drawing.Size(385, 168);
            this.groupBoxProduct.TabIndex = 32;
            this.groupBoxProduct.TabStop = false;
            this.groupBoxProduct.Text = "產品";
            // 
            // btnUpdatePrice
            // 
            this.btnUpdatePrice.Location = new System.Drawing.Point(217, 43);
            this.btnUpdatePrice.Name = "btnUpdatePrice";
            this.btnUpdatePrice.Size = new System.Drawing.Size(139, 27);
            this.btnUpdatePrice.TabIndex = 35;
            this.btnUpdatePrice.Text = "編修 價格";
            this.btnUpdatePrice.UseVisualStyleBackColor = true;
            this.btnUpdatePrice.Click += new System.EventHandler(this.btnUpdatePrice_Click);
            // 
            // textBoxGrossPercent
            // 
            this.textBoxGrossPercent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.textBoxGrossPercent.Location = new System.Drawing.Point(217, 117);
            this.textBoxGrossPercent.Name = "textBoxGrossPercent";
            this.textBoxGrossPercent.ReadOnly = true;
            this.textBoxGrossPercent.Size = new System.Drawing.Size(80, 27);
            this.textBoxGrossPercent.TabIndex = 34;
            this.textBoxGrossPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxGross
            // 
            this.textBoxGross.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.textBoxGross.Location = new System.Drawing.Point(121, 117);
            this.textBoxGross.Name = "textBoxGross";
            this.textBoxGross.ReadOnly = true;
            this.textBoxGross.Size = new System.Drawing.Size(80, 27);
            this.textBoxGross.TabIndex = 33;
            this.textBoxGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxEvaluatedCost
            // 
            this.textBoxEvaluatedCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.textBoxEvaluatedCost.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "EvaluatedCost", true));
            this.textBoxEvaluatedCost.Location = new System.Drawing.Point(121, 80);
            this.textBoxEvaluatedCost.Name = "textBoxEvaluatedCost";
            this.textBoxEvaluatedCost.ReadOnly = true;
            this.textBoxEvaluatedCost.Size = new System.Drawing.Size(80, 27);
            this.textBoxEvaluatedCost.TabIndex = 31;
            this.textBoxEvaluatedCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.textBoxPrice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Price", true));
            this.textBoxPrice.Location = new System.Drawing.Point(121, 43);
            this.textBoxPrice.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.ReadOnly = true;
            this.textBoxPrice.Size = new System.Drawing.Size(80, 27);
            this.textBoxPrice.TabIndex = 27;
            this.textBoxPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxCode
            // 
            this.textBoxCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.textBoxCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Code", true));
            this.textBoxCode.Location = new System.Drawing.Point(220, 0);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.ReadOnly = true;
            this.textBoxCode.Size = new System.Drawing.Size(136, 27);
            this.textBoxCode.TabIndex = 4;
            // 
            // btnGreen
            // 
            this.btnGreen.BackColor = System.Drawing.Color.Green;
            this.btnGreen.Location = new System.Drawing.Point(714, 439);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(28, 23);
            this.btnGreen.TabIndex = 33;
            this.btnGreen.UseVisualStyleBackColor = false;
            this.btnGreen.Click += new System.EventHandler(this.btnGreen_Click);
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BakeryConfigTableAdapter = null;
            this.tableAdapterManager.CashierTableAdapter = null;
            this.tableAdapterManager.DrawerRecordTableAdapter = null;
            this.tableAdapterManager.HeaderTableAdapter = null;
            this.tableAdapterManager.OrderItemTableAdapter = null;
            this.tableAdapterManager.OrderTableAdapter = null;
            this.tableAdapterManager.ProductTableAdapter = this.productTableAdapter;
            this.tableAdapterManager.UpdateOrder = VoucherExpense.BakeryOrderSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // btnYellow
            // 
            this.btnYellow.BackColor = System.Drawing.Color.Yellow;
            this.btnYellow.Location = new System.Drawing.Point(680, 439);
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.Size = new System.Drawing.Size(28, 23);
            this.btnYellow.TabIndex = 34;
            this.btnYellow.UseVisualStyleBackColor = false;
            this.btnYellow.Click += new System.EventHandler(this.btnYellow_Click);
            // 
            // FormRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(963, 680);
            this.Controls.Add(this.btnYellow);
            this.Controls.Add(this.btnGreen);
            this.Controls.Add(this.groupBoxProduct);
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
            this.groupBoxProduct.ResumeLayout(false);
            this.groupBoxProduct.PerformLayout();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnName;
        private System.Windows.Forms.TextBox bakedNoTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn recipeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnSourceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWeight;
        private System.Windows.Forms.GroupBox groupBoxProduct;
        private System.Windows.Forms.Button btnGreen;
        private System.Windows.Forms.TextBox textBoxCode;
        private BakeryOrderSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox textBoxGrossPercent;
        private System.Windows.Forms.TextBox textBoxGross;
        private System.Windows.Forms.TextBox textBoxEvaluatedCost;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelGross;
        private System.Windows.Forms.Label labelEvaluatedCost;
        private System.Windows.Forms.Button btnUpdatePrice;
        private System.Windows.Forms.Button btnYellow;
    }
}