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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScraps));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.productScrappedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productScrappedTableAdapter = new VoucherExpense.VEDataSetTableAdapters.ProductScrappedTableAdapter();
            this.productScrappedBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.productScrappedBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.dgvProductScrapped = new System.Windows.Forms.DataGridView();
            this.ColumnProductScrappedID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reason = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cNameIDForComboBoxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ColumnLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.operatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productScrappedDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productScrappedDetailTableAdapter = new VoucherExpense.VEDataSetTableAdapters.ProductScrappedDetailTableAdapter();
            this.dgvScrappedDetail = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bakeryOrderSet = new VoucherExpense.BakeryOrderSet();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEvaluate = new System.Windows.Forms.Button();
            this.chBoxHide = new System.Windows.Forms.CheckBox();
            this.productTableAdapter = new VoucherExpense.BakeryOrderSetTableAdapters.ProductTableAdapter();
            this.operatorTableAdapter = new VoucherExpense.VEDataSetTableAdapters.OperatorTableAdapter();
            this.soldValueTextBox = new System.Windows.Forms.TextBox();
            this.ingredientsCostTextBox = new System.Windows.Forms.TextBox();
            this.scrappedDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            soldValueLabel = new System.Windows.Forms.Label();
            ingredientsCostLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedBindingNavigator)).BeginInit();
            this.productScrappedBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductScrapped)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNameIDForComboBoxBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScrappedDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).BeginInit();
            this.SuspendLayout();
            // 
            // soldValueLabel
            // 
            soldValueLabel.AutoSize = true;
            soldValueLabel.Location = new System.Drawing.Point(453, 52);
            soldValueLabel.Name = "soldValueLabel";
            soldValueLabel.Size = new System.Drawing.Size(40, 16);
            soldValueLabel.TabIndex = 74;
            soldValueLabel.Text = "價值";
            // 
            // ingredientsCostLabel
            // 
            ingredientsCostLabel.AutoSize = true;
            ingredientsCostLabel.Location = new System.Drawing.Point(632, 52);
            ingredientsCostLabel.Name = "ingredientsCostLabel";
            ingredientsCostLabel.Size = new System.Drawing.Size(40, 16);
            ingredientsCostLabel.TabIndex = 75;
            ingredientsCostLabel.Text = "成本";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(453, 14);
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
            // productScrappedTableAdapter
            // 
            this.productScrappedTableAdapter.ClearBeforeFill = true;
            // 
            // productScrappedBindingNavigator
            // 
            this.productScrappedBindingNavigator.AddNewItem = null;
            this.productScrappedBindingNavigator.BindingSource = this.productScrappedBindingSource;
            this.productScrappedBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.productScrappedBindingNavigator.DeleteItem = null;
            this.productScrappedBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.productScrappedBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.productScrappedBindingNavigatorSaveItem});
            this.productScrappedBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.productScrappedBindingNavigator.MoveFirstItem = null;
            this.productScrappedBindingNavigator.MoveLastItem = null;
            this.productScrappedBindingNavigator.MoveNextItem = null;
            this.productScrappedBindingNavigator.MovePreviousItem = null;
            this.productScrappedBindingNavigator.Name = "productScrappedBindingNavigator";
            this.productScrappedBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.productScrappedBindingNavigator.Size = new System.Drawing.Size(174, 25);
            this.productScrappedBindingNavigator.TabIndex = 2;
            this.productScrappedBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(29, 22);
            this.bindingNavigatorCountItem.Text = "/{0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目總數";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 25);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "目前的位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // dgvProductScrapped
            // 
            this.dgvProductScrapped.AllowUserToAddRows = false;
            this.dgvProductScrapped.AllowUserToDeleteRows = false;
            this.dgvProductScrapped.AllowUserToResizeRows = false;
            this.dgvProductScrapped.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvProductScrapped.AutoGenerateColumns = false;
            this.dgvProductScrapped.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgvProductScrapped.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductScrapped.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnProductScrappedID,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn8,
            this.Reason,
            this.ColumnLocked,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn3});
            this.dgvProductScrapped.DataSource = this.productScrappedBindingSource;
            this.dgvProductScrapped.Location = new System.Drawing.Point(0, 28);
            this.dgvProductScrapped.Name = "dgvProductScrapped";
            this.dgvProductScrapped.RowHeadersWidth = 24;
            this.dgvProductScrapped.RowTemplate.Height = 24;
            this.dgvProductScrapped.Size = new System.Drawing.Size(450, 691);
            this.dgvProductScrapped.TabIndex = 3;
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
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "SoldValue";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn4.HeaderText = "價值";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 64;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "IngredientsCost";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn5.HeaderText = "成本";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 64;
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
            // productScrappedDetailTableAdapter
            // 
            this.productScrappedDetailTableAdapter.ClearBeforeFill = true;
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
            this.dataGridViewTextBoxColumn11,
            this.ColumnVolume,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14});
            this.dgvScrappedDetail.DataSource = this.productScrappedDetailBindingSource;
            this.dgvScrappedDetail.Location = new System.Drawing.Point(456, 81);
            this.dgvScrappedDetail.Name = "dgvScrappedDetail";
            this.dgvScrappedDetail.RowHeadersWidth = 24;
            this.dgvScrappedDetail.RowTemplate.Height = 24;
            this.dgvScrappedDetail.Size = new System.Drawing.Size(502, 638);
            this.dgvScrappedDetail.TabIndex = 4;
            this.dgvScrappedDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScrappedDetail_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ID";
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
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "ProductID";
            this.dataGridViewTextBoxColumn11.DataSource = this.productBindingSource;
            this.dataGridViewTextBoxColumn11.DisplayMember = "Name";
            this.dataGridViewTextBoxColumn11.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewTextBoxColumn11.HeaderText = "產品";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn11.ValueMember = "ProductID";
            this.dataGridViewTextBoxColumn11.Width = 128;
            // 
            // ColumnVolume
            // 
            this.ColumnVolume.DataPropertyName = "Volume";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnVolume.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnVolume.HeaderText = "量";
            this.ColumnVolume.Name = "ColumnVolume";
            this.ColumnVolume.Width = 80;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Price";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn13.HeaderText = "價格";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 80;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "EvaluatedCost";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn14.HeaderText = "成本";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 80;
            // 
            // btnEvaluate
            // 
            this.btnEvaluate.Location = new System.Drawing.Point(678, 9);
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
            this.chBoxHide.Location = new System.Drawing.Point(830, 10);
            this.chBoxHide.Name = "chBoxHide";
            this.chBoxHide.Size = new System.Drawing.Size(123, 20);
            this.chBoxHide.TabIndex = 74;
            this.chBoxHide.Text = "隱藏無資料行";
            this.chBoxHide.UseVisualStyleBackColor = true;
            this.chBoxHide.CheckedChanged += new System.EventHandler(this.chBoxHide_CheckedChanged);
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // operatorTableAdapter
            // 
            this.operatorTableAdapter.ClearBeforeFill = true;
            // 
            // soldValueTextBox
            // 
            this.soldValueTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.soldValueTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productScrappedBindingSource, "SoldValue", true));
            this.soldValueTextBox.Location = new System.Drawing.Point(515, 47);
            this.soldValueTextBox.Name = "soldValueTextBox";
            this.soldValueTextBox.ReadOnly = true;
            this.soldValueTextBox.Size = new System.Drawing.Size(100, 27);
            this.soldValueTextBox.TabIndex = 75;
            this.soldValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ingredientsCostTextBox
            // 
            this.ingredientsCostTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ingredientsCostTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productScrappedBindingSource, "IngredientsCost", true));
            this.ingredientsCostTextBox.Location = new System.Drawing.Point(678, 47);
            this.ingredientsCostTextBox.Name = "ingredientsCostTextBox";
            this.ingredientsCostTextBox.ReadOnly = true;
            this.ingredientsCostTextBox.Size = new System.Drawing.Size(100, 27);
            this.ingredientsCostTextBox.TabIndex = 76;
            this.ingredientsCostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // scrappedDateDateTimePicker
            // 
            this.scrappedDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.productScrappedBindingSource, "ScrappedDate", true));
            this.scrappedDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.scrappedDateDateTimePicker.Location = new System.Drawing.Point(515, 9);
            this.scrappedDateDateTimePicker.Name = "scrappedDateDateTimePicker";
            this.scrappedDateDateTimePicker.Size = new System.Drawing.Size(97, 27);
            this.scrappedDateDateTimePicker.TabIndex = 77;
            // 
            // FormScraps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(961, 720);
            this.Controls.Add(this.scrappedDateDateTimePicker);
            this.Controls.Add(ingredientsCostLabel);
            this.Controls.Add(this.ingredientsCostTextBox);
            this.Controls.Add(soldValueLabel);
            this.Controls.Add(this.soldValueTextBox);
            this.Controls.Add(this.chBoxHide);
            this.Controls.Add(this.btnEvaluate);
            this.Controls.Add(this.dgvScrappedDetail);
            this.Controls.Add(this.dgvProductScrapped);
            this.Controls.Add(this.productScrappedBindingNavigator);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormScraps";
            this.Text = "報癈 試吃 登記表";
            this.Load += new System.EventHandler(this.FormScraps_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedBindingNavigator)).EndInit();
            this.productScrappedBindingNavigator.ResumeLayout(false);
            this.productScrappedBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductScrapped)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNameIDForComboBoxBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScrappedDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource productScrappedBindingSource;
        private VEDataSetTableAdapters.ProductScrappedTableAdapter productScrappedTableAdapter;
        private System.Windows.Forms.BindingNavigator productScrappedBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton productScrappedBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView dgvProductScrapped;
        private System.Windows.Forms.BindingSource productScrappedDetailBindingSource;
        private VEDataSetTableAdapters.ProductScrappedDetailTableAdapter productScrappedDetailTableAdapter;
        private System.Windows.Forms.DataGridView dgvScrappedDetail;
        private System.Windows.Forms.Button btnEvaluate;
        private System.Windows.Forms.CheckBox chBoxHide;
        private BakeryOrderSet bakeryOrderSet;
        private BakeryOrderSetTableAdapters.ProductTableAdapter productTableAdapter;
        private System.Windows.Forms.BindingSource operatorBindingSource;
        private VEDataSetTableAdapters.OperatorTableAdapter operatorTableAdapter;
        private System.Windows.Forms.BindingSource cNameIDForComboBoxBindingSource;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.TextBox soldValueTextBox;
        private System.Windows.Forms.TextBox ingredientsCostTextBox;
        private System.Windows.Forms.DateTimePicker scrappedDateDateTimePicker;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProductScrappedID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewComboBoxColumn Reason;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
    }
}