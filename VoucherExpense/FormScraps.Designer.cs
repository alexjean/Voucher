namespace VoucherExpense
{
    partial class FormScraps
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
            System.Windows.Forms.Label soldValueLabel;
            System.Windows.Forms.Label ingredientsCostLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScraps));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.productScrappedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productScrappedBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.productScrappedBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.damaiDataSet = new VoucherExpense.DamaiDataSet();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.productScrappedBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dgvProductScrapped = new System.Windows.Forms.DataGridView();
            this.ColumnProductScrappedID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reason = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cNameIDForComboBoxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ColumnLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.operatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productScrappedDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvScrappedDetail = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bakeryOrderSet = new VoucherExpense.BakeryOrderSet();
            this.ProductName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productScrappedDetailBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnEvaluate = new System.Windows.Forms.Button();
            this.chBoxHide = new System.Windows.Forms.CheckBox();
            this.soldValueTextBox = new System.Windows.Forms.TextBox();
            this.ingredientsCostTextBox = new System.Windows.Forms.TextBox();
            this.scrappedDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.volumeTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txBoxVolume = new System.Windows.Forms.TextBox();
            this.txBoxCost = new System.Windows.Forms.TextBox();
            this.txBoxSoldValue = new System.Windows.Forms.TextBox();
            this.dgvCalc = new System.Windows.Forms.DataGridView();
            this.productIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soldValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcScrapeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCalc = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.fromPicker = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.toPicker = new System.Windows.Forms.DateTimePicker();
            soldValueLabel = new System.Windows.Forms.Label();
            ingredientsCostLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedBindingNavigator)).BeginInit();
            this.productScrappedBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductScrapped)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNameIDForComboBoxBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScrappedDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedDetailBindingSource1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcScrapeBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // soldValueLabel
            // 
            soldValueLabel.AutoSize = true;
            soldValueLabel.Location = new System.Drawing.Point(85, 13);
            soldValueLabel.Name = "soldValueLabel";
            soldValueLabel.Size = new System.Drawing.Size(40, 16);
            soldValueLabel.TabIndex = 74;
            soldValueLabel.Text = "加總";
            // 
            // ingredientsCostLabel
            // 
            ingredientsCostLabel.AutoSize = true;
            ingredientsCostLabel.Location = new System.Drawing.Point(26, 83);
            ingredientsCostLabel.Name = "ingredientsCostLabel";
            ingredientsCostLabel.Size = new System.Drawing.Size(24, 16);
            ingredientsCostLabel.TabIndex = 75;
            ingredientsCostLabel.Text = "至";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(25, 48);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(24, 16);
            label2.TabIndex = 78;
            label2.Text = "從";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(165, 48);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(24, 16);
            label5.TabIndex = 88;
            label5.Text = "含";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "報癈日";
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productScrappedBindingSource
            // 
            this.productScrappedBindingSource.DataMember = "ProductScrapped";
            this.productScrappedBindingSource.DataSource = this.vEDataSet;
            // 
            // productScrappedBindingNavigator
            // 
            this.productScrappedBindingNavigator.AddNewItem = null;
            this.productScrappedBindingNavigator.BindingSource = this.productScrappedBindingSource1;
            this.productScrappedBindingNavigator.CountItem = null;
            this.productScrappedBindingNavigator.DeleteItem = null;
            this.productScrappedBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.productScrappedBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorSeparator,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.productScrappedBindingNavigatorSaveItem,
            this.toolStripSeparator1});
            this.productScrappedBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.productScrappedBindingNavigator.MoveFirstItem = null;
            this.productScrappedBindingNavigator.MoveLastItem = null;
            this.productScrappedBindingNavigator.MoveNextItem = null;
            this.productScrappedBindingNavigator.MovePreviousItem = null;
            this.productScrappedBindingNavigator.Name = "productScrappedBindingNavigator";
            this.productScrappedBindingNavigator.PositionItem = null;
            this.productScrappedBindingNavigator.Size = new System.Drawing.Size(93, 25);
            this.productScrappedBindingNavigator.TabIndex = 2;
            this.productScrappedBindingNavigator.Text = "bindingNavigator1";
            // 
            // productScrappedBindingSource1
            // 
            this.productScrappedBindingSource1.DataMember = "ProductScrapped";
            this.productScrappedBindingSource1.DataSource = this.damaiDataSet;
            // 
            // damaiDataSet
            // 
            this.damaiDataSet.DataSetName = "DamaiDataSet";
            this.damaiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
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
            // productScrappedBindingNavigatorSaveItem
            // 
            this.productScrappedBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.productScrappedBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("productScrappedBindingNavigatorSaveItem.Image")));
            this.productScrappedBindingNavigatorSaveItem.Name = "productScrappedBindingNavigatorSaveItem";
            this.productScrappedBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.productScrappedBindingNavigatorSaveItem.Text = "儲存資料";
            this.productScrappedBindingNavigatorSaveItem.Click += new System.EventHandler(this.productScrappedBindingNavigatorSaveItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // dgvProductScrapped
            // 
            this.dgvProductScrapped.AllowUserToAddRows = false;
            this.dgvProductScrapped.AllowUserToDeleteRows = false;
            this.dgvProductScrapped.AllowUserToResizeRows = false;
            this.dgvProductScrapped.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductScrapped.AutoGenerateColumns = false;
            this.dgvProductScrapped.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgvProductScrapped.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductScrapped.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnProductScrappedID,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.Reason,
            this.ColumnLocked,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn3});
            this.dgvProductScrapped.DataSource = this.productScrappedBindingSource;
            this.dgvProductScrapped.Location = new System.Drawing.Point(0, 26);
            this.dgvProductScrapped.Name = "dgvProductScrapped";
            this.dgvProductScrapped.RowHeadersWidth = 24;
            this.dgvProductScrapped.RowTemplate.Height = 24;
            this.dgvProductScrapped.Size = new System.Drawing.Size(454, 730);
            this.dgvProductScrapped.TabIndex = 3;
            this.dgvProductScrapped.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductScrapped_CellValueChanged);
            this.dgvProductScrapped.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvProductScrapped_DataError);
            this.dgvProductScrapped.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductScrapped_RowEnter);
            // 
            // ColumnProductScrappedID
            // 
            this.ColumnProductScrappedID.DataPropertyName = "ProductScrappedID";
            this.ColumnProductScrappedID.HeaderText = "ProductScrappedID";
            this.ColumnProductScrappedID.Name = "ColumnProductScrappedID";
            this.ColumnProductScrappedID.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ScrappedDate";
            this.dataGridViewTextBoxColumn2.HeaderText = "報癈日";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "SoldValue";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N1";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn4.HeaderText = "價值";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "IngredientsCost";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn5.HeaderText = "成本";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // Reason
            // 
            this.Reason.DataPropertyName = "Reason";
            this.Reason.DataSource = this.cNameIDForComboBoxBindingSource;
            this.Reason.DisplayMember = "Name";
            this.Reason.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Reason.HeaderText = "原因";
            this.Reason.Name = "Reason";
            this.Reason.ValueMember = "ID";
            this.Reason.Width = 80;
            // 
            // cNameIDForComboBoxBindingSource
            // 
            this.cNameIDForComboBoxBindingSource.DataSource = typeof(VoucherExpense.CNameIDForComboBox);
            // 
            // ColumnLocked
            // 
            this.ColumnLocked.DataPropertyName = "Locked";
            this.ColumnLocked.HeaderText = "核";
            this.ColumnLocked.Name = "ColumnLocked";
            this.ColumnLocked.Width = 32;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "EvaluatedDate";
            dataGridViewCellStyle3.Format = "MM-dd";
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn8.HeaderText = "估值日";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "LastUpdated";
            dataGridViewCellStyle4.Format = "MM-dd";
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn7.HeaderText = "更新";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 64;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "KeyinID";
            this.dataGridViewTextBoxColumn3.DataSource = this.operatorBindingSource;
            this.dataGridViewTextBoxColumn3.DisplayMember = "Name";
            this.dataGridViewTextBoxColumn3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewTextBoxColumn3.HeaderText = "輸入";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.ValueMember = "OperatorID";
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // operatorBindingSource
            // 
            this.operatorBindingSource.DataMember = "Operator";
            this.operatorBindingSource.DataSource = this.vEDataSet;
            // 
            // productScrappedDetailBindingSource
            // 
            this.productScrappedDetailBindingSource.DataMember = "ProductScrappedProductScrappedDetail";
            this.productScrappedDetailBindingSource.DataSource = this.productScrappedBindingSource;
            this.productScrappedDetailBindingSource.Filter = "";
            // 
            // dgvScrappedDetail
            // 
            this.dgvScrappedDetail.AllowUserToAddRows = false;
            this.dgvScrappedDetail.AllowUserToDeleteRows = false;
            this.dgvScrappedDetail.AllowUserToResizeRows = false;
            this.dgvScrappedDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvScrappedDetail.AutoGenerateColumns = false;
            this.dgvScrappedDetail.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.dgvScrappedDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScrappedDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.ProductID,
            this.ProductName,
            this.ColumnVolume,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14});
            this.dgvScrappedDetail.DataSource = this.productScrappedDetailBindingSource;
            this.dgvScrappedDetail.Location = new System.Drawing.Point(0, 70);
            this.dgvScrappedDetail.Name = "dgvScrappedDetail";
            this.dgvScrappedDetail.RowHeadersWidth = 24;
            this.dgvScrappedDetail.RowTemplate.Height = 24;
            this.dgvScrappedDetail.Size = new System.Drawing.Size(493, 657);
            this.dgvScrappedDetail.TabIndex = 4;
            this.dgvScrappedDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScrappedDetail_CellValueChanged);
            this.dgvScrappedDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvScrappedDetail_DataError);
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ID";
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn9.HeaderText = "ID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "ProdcutScrappedID";
            this.dataGridViewTextBoxColumn10.HeaderText = "ProdcutScrappedID";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // ProductID
            // 
            this.ProductID.DataPropertyName = "ProductID";
            this.ProductID.DataSource = this.productBindingSource;
            this.ProductID.DisplayMember = "Code";
            this.ProductID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ProductID.HeaderText = "代碼";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ProductID.ValueMember = "ProductID";
            this.ProductID.Width = 80;
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
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductID";
            this.ProductName.DataSource = this.productBindingSource;
            this.ProductName.DisplayMember = "Name";
            this.ProductName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ProductName.HeaderText = "產品";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ProductName.ValueMember = "ProductID";
            this.ProductName.Width = 128;
            // 
            // ColumnVolume
            // 
            this.ColumnVolume.DataPropertyName = "Volume";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N1";
            dataGridViewCellStyle6.NullValue = null;
            this.ColumnVolume.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnVolume.HeaderText = "量";
            this.ColumnVolume.Name = "ColumnVolume";
            this.ColumnVolume.Width = 64;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Price";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N1";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn13.HeaderText = "價格";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 88;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "EvaluatedCost";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn14.HeaderText = "成本";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 88;
            // 
            // productScrappedDetailBindingSource1
            // 
            this.productScrappedDetailBindingSource1.DataMember = "FK_ProductScrappedDetail_ProductScrappedDetail";
            this.productScrappedDetailBindingSource1.DataSource = this.productScrappedBindingSource1;
            // 
            // btnEvaluate
            // 
            this.btnEvaluate.Location = new System.Drawing.Point(59, 36);
            this.btnEvaluate.Name = "btnEvaluate";
            this.btnEvaluate.Size = new System.Drawing.Size(100, 29);
            this.btnEvaluate.TabIndex = 71;
            this.btnEvaluate.Text = "重估此單";
            this.btnEvaluate.UseVisualStyleBackColor = true;
            this.btnEvaluate.Click += new System.EventHandler(this.btnEvaluate_Click);
            // 
            // chBoxHide
            // 
            this.chBoxHide.AutoSize = true;
            this.chBoxHide.Checked = true;
            this.chBoxHide.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBoxHide.Location = new System.Drawing.Point(231, 9);
            this.chBoxHide.Name = "chBoxHide";
            this.chBoxHide.Size = new System.Drawing.Size(123, 20);
            this.chBoxHide.TabIndex = 74;
            this.chBoxHide.Text = "隱藏無資料行";
            this.chBoxHide.UseVisualStyleBackColor = true;
            this.chBoxHide.CheckedChanged += new System.EventHandler(this.chBoxHide_CheckedChanged);
            // 
            // soldValueTextBox
            // 
            this.soldValueTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.soldValueTextBox.Location = new System.Drawing.Point(304, 37);
            this.soldValueTextBox.Name = "soldValueTextBox";
            this.soldValueTextBox.ReadOnly = true;
            this.soldValueTextBox.Size = new System.Drawing.Size(78, 27);
            this.soldValueTextBox.TabIndex = 75;
            this.soldValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ingredientsCostTextBox
            // 
            this.ingredientsCostTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ingredientsCostTextBox.Location = new System.Drawing.Point(390, 37);
            this.ingredientsCostTextBox.Name = "ingredientsCostTextBox";
            this.ingredientsCostTextBox.ReadOnly = true;
            this.ingredientsCostTextBox.Size = new System.Drawing.Size(79, 27);
            this.ingredientsCostTextBox.TabIndex = 76;
            this.ingredientsCostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // scrappedDateDateTimePicker
            // 
            this.scrappedDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.productScrappedBindingSource, "ScrappedDate", true));
            this.scrappedDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.scrappedDateDateTimePicker.Location = new System.Drawing.Point(59, 5);
            this.scrappedDateDateTimePicker.Name = "scrappedDateDateTimePicker";
            this.scrappedDateDateTimePicker.Size = new System.Drawing.Size(100, 27);
            this.scrappedDateDateTimePicker.TabIndex = 77;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(456, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(497, 757);
            this.tabControl1.TabIndex = 78;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.tabPage1.Controls.Add(this.volumeTextBox);
            this.tabPage1.Controls.Add(this.dgvScrappedDetail);
            this.tabPage1.Controls.Add(this.scrappedDateDateTimePicker);
            this.tabPage1.Controls.Add(this.btnEvaluate);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.ingredientsCostTextBox);
            this.tabPage1.Controls.Add(this.chBoxHide);
            this.tabPage1.Controls.Add(this.soldValueTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(489, 727);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "日明細";
            // 
            // volumeTextBox
            // 
            this.volumeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.volumeTextBox.Location = new System.Drawing.Point(232, 37);
            this.volumeTextBox.Name = "volumeTextBox";
            this.volumeTextBox.ReadOnly = true;
            this.volumeTextBox.Size = new System.Drawing.Size(62, 27);
            this.volumeTextBox.TabIndex = 79;
            this.volumeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Azure;
            this.tabPage2.Controls.Add(this.txBoxVolume);
            this.tabPage2.Controls.Add(this.txBoxCost);
            this.tabPage2.Controls.Add(this.txBoxSoldValue);
            this.tabPage2.Controls.Add(this.dgvCalc);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(489, 727);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "區間統計";
            // 
            // txBoxVolume
            // 
            this.txBoxVolume.BackColor = System.Drawing.Color.Azure;
            this.txBoxVolume.Location = new System.Drawing.Point(215, 141);
            this.txBoxVolume.Name = "txBoxVolume";
            this.txBoxVolume.ReadOnly = true;
            this.txBoxVolume.Size = new System.Drawing.Size(62, 27);
            this.txBoxVolume.TabIndex = 92;
            this.txBoxVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txBoxCost
            // 
            this.txBoxCost.BackColor = System.Drawing.Color.Azure;
            this.txBoxCost.Location = new System.Drawing.Point(373, 141);
            this.txBoxCost.Name = "txBoxCost";
            this.txBoxCost.ReadOnly = true;
            this.txBoxCost.Size = new System.Drawing.Size(79, 27);
            this.txBoxCost.TabIndex = 91;
            this.txBoxCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txBoxSoldValue
            // 
            this.txBoxSoldValue.BackColor = System.Drawing.Color.Azure;
            this.txBoxSoldValue.Location = new System.Drawing.Point(287, 141);
            this.txBoxSoldValue.Name = "txBoxSoldValue";
            this.txBoxSoldValue.ReadOnly = true;
            this.txBoxSoldValue.Size = new System.Drawing.Size(78, 27);
            this.txBoxSoldValue.TabIndex = 90;
            this.txBoxSoldValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvCalc
            // 
            this.dgvCalc.AllowUserToAddRows = false;
            this.dgvCalc.AllowUserToDeleteRows = false;
            this.dgvCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCalc.AutoGenerateColumns = false;
            this.dgvCalc.BackgroundColor = System.Drawing.Color.Azure;
            this.dgvCalc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productIDDataGridViewTextBoxColumn,
            this.Column1,
            this.volumeDataGridViewTextBoxColumn,
            this.costDataGridViewTextBoxColumn,
            this.soldValueDataGridViewTextBoxColumn});
            this.dgvCalc.DataSource = this.calcScrapeBindingSource;
            this.dgvCalc.Location = new System.Drawing.Point(3, 171);
            this.dgvCalc.Name = "dgvCalc";
            this.dgvCalc.ReadOnly = true;
            this.dgvCalc.RowHeadersVisible = false;
            this.dgvCalc.RowTemplate.Height = 24;
            this.dgvCalc.Size = new System.Drawing.Size(480, 553);
            this.dgvCalc.TabIndex = 80;
            // 
            // productIDDataGridViewTextBoxColumn
            // 
            this.productIDDataGridViewTextBoxColumn.DataPropertyName = "ProductID";
            this.productIDDataGridViewTextBoxColumn.DataSource = this.productBindingSource;
            this.productIDDataGridViewTextBoxColumn.DisplayMember = "Code";
            this.productIDDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.productIDDataGridViewTextBoxColumn.HeaderText = "代碼";
            this.productIDDataGridViewTextBoxColumn.Name = "productIDDataGridViewTextBoxColumn";
            this.productIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.productIDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.productIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.productIDDataGridViewTextBoxColumn.ValueMember = "ProductID";
            this.productIDDataGridViewTextBoxColumn.Width = 80;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ProductID";
            this.Column1.DataSource = this.productBindingSource;
            this.Column1.DisplayMember = "Name";
            this.Column1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Column1.HeaderText = "產品名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.ValueMember = "ProductID";
            this.Column1.Width = 128;
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = "Volume";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N1";
            this.volumeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.volumeDataGridViewTextBoxColumn.HeaderText = "數量";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            this.volumeDataGridViewTextBoxColumn.ReadOnly = true;
            this.volumeDataGridViewTextBoxColumn.Width = 64;
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.DataPropertyName = "SoldValue";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N1";
            this.costDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.costDataGridViewTextBoxColumn.HeaderText = "價值";
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            this.costDataGridViewTextBoxColumn.ReadOnly = true;
            this.costDataGridViewTextBoxColumn.Width = 88;
            // 
            // soldValueDataGridViewTextBoxColumn
            // 
            this.soldValueDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            this.soldValueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.soldValueDataGridViewTextBoxColumn.HeaderText = "成本";
            this.soldValueDataGridViewTextBoxColumn.Name = "soldValueDataGridViewTextBoxColumn";
            this.soldValueDataGridViewTextBoxColumn.ReadOnly = true;
            this.soldValueDataGridViewTextBoxColumn.Width = 88;
            // 
            // calcScrapeBindingSource
            // 
            this.calcScrapeBindingSource.DataSource = typeof(VoucherExpense.FormScraps.CalcScrape);
            this.calcScrapeBindingSource.Filter = "";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnCalc);
            this.panel1.Controls.Add(label5);
            this.panel1.Controls.Add(soldValueLabel);
            this.panel1.Controls.Add(ingredientsCostLabel);
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Controls.Add(label2);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.fromPicker);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.toPicker);
            this.panel1.Location = new System.Drawing.Point(3, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 129);
            this.panel1.TabIndex = 89;
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(376, 30);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(84, 53);
            this.btnCalc.TabIndex = 87;
            this.btnCalc.Text = "計算";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(195, 84);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(59, 20);
            this.checkBox3.TabIndex = 86;
            this.checkBox3.Text = "其他";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(195, 49);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(59, 20);
            this.checkBox2.TabIndex = 85;
            this.checkBox2.Text = "試吃";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // fromPicker
            // 
            this.fromPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromPicker.Location = new System.Drawing.Point(55, 43);
            this.fromPicker.Name = "fromPicker";
            this.fromPicker.Size = new System.Drawing.Size(100, 27);
            this.fromPicker.TabIndex = 79;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(195, 14);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(59, 20);
            this.checkBox1.TabIndex = 84;
            this.checkBox1.Text = "報廢";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // toPicker
            // 
            this.toPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toPicker.Location = new System.Drawing.Point(55, 78);
            this.toPicker.Name = "toPicker";
            this.toPicker.Size = new System.Drawing.Size(100, 27);
            this.toPicker.TabIndex = 80;
            // 
            // FormScraps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(956, 757);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dgvProductScrapped);
            this.Controls.Add(this.productScrappedBindingNavigator);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormScraps";
            this.Text = "報癈 試吃 登記表";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormScraps_FormClosing);
            this.Load += new System.EventHandler(this.FormScraps_Load);
            this.Shown += new System.EventHandler(this.FormScraps_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedBindingNavigator)).EndInit();
            this.productScrappedBindingNavigator.ResumeLayout(false);
            this.productScrappedBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductScrapped)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNameIDForComboBoxBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScrappedDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedDetailBindingSource1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcScrapeBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource productScrappedBindingSource;
        private System.Windows.Forms.BindingNavigator productScrappedBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripButton productScrappedBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView dgvProductScrapped;
        private System.Windows.Forms.BindingSource productScrappedDetailBindingSource;
        private System.Windows.Forms.DataGridView dgvScrappedDetail;
        private System.Windows.Forms.Button btnEvaluate;
        private System.Windows.Forms.CheckBox chBoxHide;
        private BakeryOrderSet bakeryOrderSet;
        private System.Windows.Forms.BindingSource operatorBindingSource;
        private System.Windows.Forms.BindingSource cNameIDForComboBoxBindingSource;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.TextBox soldValueTextBox;
        private System.Windows.Forms.TextBox ingredientsCostTextBox;
        private System.Windows.Forms.DateTimePicker scrappedDateDateTimePicker;
        private System.Windows.Forms.BindingSource productScrappedBindingSource1;
        private System.Windows.Forms.BindingSource productScrappedDetailBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProductScrappedID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewComboBoxColumn Reason;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn3;
        private DamaiDataSet damaiDataSet;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox volumeTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DateTimePicker toPicker;
        private System.Windows.Forms.DateTimePicker fromPicker;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvCalc;
        private System.Windows.Forms.BindingSource calcScrapeBindingSource;
        private System.Windows.Forms.TextBox txBoxVolume;
        private System.Windows.Forms.TextBox txBoxCost;
        private System.Windows.Forms.TextBox txBoxSoldValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn productIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soldValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}