namespace VoucherExpense
{
    partial class FormIngredientInventories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIngredientInventories));
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.inventoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventoryTableAdapter = new VoucherExpense.VEDataSetTableAdapters.InventoryTableAdapter();
            this.inventoryBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.inventoryBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.dgvInventories = new System.Windows.Forms.DataGridView();
            this.ColumnInventoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EvaluatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKeyID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.operatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.inventoryDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventoryDetailTableAdapter = new VoucherExpense.VEDataSetTableAdapters.InventoryDetailTableAdapter();
            this.dgvInventoryDetail = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ingredientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientUnit = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnStockChecked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LostMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEvaluate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ingredientTableAdapter = new VoucherExpense.VEDataSetTableAdapters.IngredientTableAdapter();
            this.chBoxHide = new System.Windows.Forms.CheckBox();
            this.checkDayDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.labelIngredientsCount = new System.Windows.Forms.Label();
            this.operatorTableAdapter = new VoucherExpense.VEDataSetTableAdapters.OperatorTableAdapter();
            this.totalStockMoneyTextBox = new System.Windows.Forms.TextBox();
            this.totalLostMoneyTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingNavigator)).BeginInit();
            this.inventoryBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(415, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 67;
            this.label3.Text = "盤點日期";
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inventoryBindingSource
            // 
            this.inventoryBindingSource.DataMember = "Inventory";
            this.inventoryBindingSource.DataSource = this.vEDataSet;
            // 
            // inventoryTableAdapter
            // 
            this.inventoryTableAdapter.ClearBeforeFill = true;
            // 
            // inventoryBindingNavigator
            // 
            this.inventoryBindingNavigator.AddNewItem = null;
            this.inventoryBindingNavigator.BindingSource = this.inventoryBindingSource;
            this.inventoryBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.inventoryBindingNavigator.DeleteItem = null;
            this.inventoryBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.inventoryBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.inventoryBindingNavigatorSaveItem});
            this.inventoryBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.inventoryBindingNavigator.MoveFirstItem = null;
            this.inventoryBindingNavigator.MoveLastItem = null;
            this.inventoryBindingNavigator.MoveNextItem = null;
            this.inventoryBindingNavigator.MovePreviousItem = null;
            this.inventoryBindingNavigator.Name = "inventoryBindingNavigator";
            this.inventoryBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.inventoryBindingNavigator.Size = new System.Drawing.Size(174, 25);
            this.inventoryBindingNavigator.TabIndex = 68;
            this.inventoryBindingNavigator.Text = "bindingNavigator1";
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
            // inventoryBindingNavigatorSaveItem
            // 
            this.inventoryBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.inventoryBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("inventoryBindingNavigatorSaveItem.Image")));
            this.inventoryBindingNavigatorSaveItem.Name = "inventoryBindingNavigatorSaveItem";
            this.inventoryBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.inventoryBindingNavigatorSaveItem.Text = "儲存資料";
            this.inventoryBindingNavigatorSaveItem.Click += new System.EventHandler(this.inventoryBindingNavigatorSaveItem_Click);
            // 
            // dgvInventories
            // 
            this.dgvInventories.AllowUserToAddRows = false;
            this.dgvInventories.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dgvInventories.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInventories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvInventories.AutoGenerateColumns = false;
            this.dgvInventories.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgvInventories.ColumnHeadersHeight = 32;
            this.dgvInventories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInventories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnInventoryID,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.EvaluatedDate,
            this.ColumnLocked,
            this.dataGridViewTextBoxColumn6,
            this.ColumnKeyID});
            this.dgvInventories.DataSource = this.inventoryBindingSource;
            this.dgvInventories.Location = new System.Drawing.Point(0, 28);
            this.dgvInventories.MultiSelect = false;
            this.dgvInventories.Name = "dgvInventories";
            this.dgvInventories.RowHeadersWidth = 24;
            this.dgvInventories.RowTemplate.Height = 24;
            this.dgvInventories.Size = new System.Drawing.Size(357, 779);
            this.dgvInventories.TabIndex = 68;
            this.dgvInventories.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventories_CellValueChanged);
            this.dgvInventories.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventories_RowEnter);
            // 
            // ColumnInventoryID
            // 
            this.ColumnInventoryID.DataPropertyName = "InventoryID";
            this.ColumnInventoryID.HeaderText = "InventoryID";
            this.ColumnInventoryID.Name = "ColumnInventoryID";
            this.ColumnInventoryID.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CheckDay";
            dataGridViewCellStyle2.Format = "yy-MM-dd";
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.HeaderText = "盤點日";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TotalStockMoney";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn4.HeaderText = "庫存";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TotalLostMoney";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn5.HeaderText = "損失";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // EvaluatedDate
            // 
            this.EvaluatedDate.DataPropertyName = "EvaluatedDate";
            dataGridViewCellStyle5.Format = "MM-dd";
            this.EvaluatedDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.EvaluatedDate.HeaderText = "估值日";
            this.EvaluatedDate.Name = "EvaluatedDate";
            this.EvaluatedDate.ReadOnly = true;
            this.EvaluatedDate.Width = 64;
            // 
            // ColumnLocked
            // 
            this.ColumnLocked.DataPropertyName = "Locked";
            this.ColumnLocked.HeaderText = "核";
            this.ColumnLocked.Name = "ColumnLocked";
            this.ColumnLocked.Width = 32;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "LastUpdated";
            dataGridViewCellStyle6.Format = "MM-dd";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn6.HeaderText = "更新日";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 64;
            // 
            // ColumnKeyID
            // 
            this.ColumnKeyID.DataPropertyName = "KeyinID";
            this.ColumnKeyID.DataSource = this.operatorBindingSource;
            this.ColumnKeyID.DisplayMember = "Name";
            this.ColumnKeyID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnKeyID.HeaderText = "輸入者";
            this.ColumnKeyID.Name = "ColumnKeyID";
            this.ColumnKeyID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnKeyID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnKeyID.ValueMember = "OperatorID";
            this.ColumnKeyID.Width = 80;
            // 
            // operatorBindingSource
            // 
            this.operatorBindingSource.DataMember = "Operator";
            this.operatorBindingSource.DataSource = this.vEDataSet;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(415, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 69;
            this.label1.Text = "食材數";
            // 
            // inventoryDetailBindingSource
            // 
            this.inventoryDetailBindingSource.DataMember = "InventoryInventoryDetail";
            this.inventoryDetailBindingSource.DataSource = this.inventoryBindingSource;
            // 
            // inventoryDetailTableAdapter
            // 
            this.inventoryDetailTableAdapter.ClearBeforeFill = true;
            // 
            // dgvInventoryDetail
            // 
            this.dgvInventoryDetail.AllowUserToAddRows = false;
            this.dgvInventoryDetail.AllowUserToDeleteRows = false;
            this.dgvInventoryDetail.AllowUserToResizeRows = false;
            this.dgvInventoryDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInventoryDetail.AutoGenerateColumns = false;
            this.dgvInventoryDetail.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.dgvInventoryDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventoryDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn8,
            this.ColumnPosition,
            this.IngredientID,
            this.dataGridViewComboBoxColumn1,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn11,
            this.IngredientUnit,
            this.ColumnStockChecked,
            this.dataGridViewTextBoxColumn13,
            this.LostMoney});
            this.dgvInventoryDetail.DataSource = this.inventoryDetailBindingSource;
            this.dgvInventoryDetail.Location = new System.Drawing.Point(363, 71);
            this.dgvInventoryDetail.Name = "dgvInventoryDetail";
            this.dgvInventoryDetail.RowHeadersWidth = 25;
            this.dgvInventoryDetail.RowTemplate.Height = 24;
            this.dgvInventoryDetail.Size = new System.Drawing.Size(620, 736);
            this.dgvInventoryDetail.TabIndex = 69;
            this.dgvInventoryDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventoryDetail_CellValueChanged);
            this.dgvInventoryDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvInventoryDetail_DataBindingComplete);
            this.dgvInventoryDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvInventoryDetail_DataError);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ID";
            dataGridViewCellStyle7.Format = "N1";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn3.HeaderText = "ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "InventoryID";
            this.dataGridViewTextBoxColumn8.HeaderText = "InventoryID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // ColumnPosition
            // 
            this.ColumnPosition.DataPropertyName = "AreaCode";
            this.ColumnPosition.HeaderText = "位";
            this.ColumnPosition.MaxInputLength = 3;
            this.ColumnPosition.Name = "ColumnPosition";
            this.ColumnPosition.Width = 36;
            // 
            // IngredientID
            // 
            this.IngredientID.DataPropertyName = "IngredientID";
            this.IngredientID.DataSource = this.ingredientBindingSource;
            this.IngredientID.DisplayMember = "Code";
            this.IngredientID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.IngredientID.HeaderText = "代号";
            this.IngredientID.Name = "IngredientID";
            this.IngredientID.ReadOnly = true;
            this.IngredientID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IngredientID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IngredientID.ValueMember = "IngredientID";
            this.IngredientID.Width = 64;
            // 
            // ingredientBindingSource
            // 
            this.ingredientBindingSource.DataMember = "Ingredient";
            this.ingredientBindingSource.DataSource = this.vEDataSet;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataPropertyName = "IngredientID";
            this.dataGridViewComboBoxColumn1.DataSource = this.ingredientBindingSource;
            this.dataGridViewComboBoxColumn1.DisplayMember = "Name";
            this.dataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewComboBoxColumn1.HeaderText = "品名";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.ReadOnly = true;
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn1.ValueMember = "IngredientID";
            this.dataGridViewComboBoxColumn1.Width = 136;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "PrevStockVolume";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn15.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn15.HeaderText = "前期";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 64;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "CurrentIn";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn11.HeaderText = "進貨";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 64;
            // 
            // IngredientUnit
            // 
            this.IngredientUnit.DataPropertyName = "IngredientID";
            this.IngredientUnit.DataSource = this.ingredientBindingSource;
            this.IngredientUnit.DisplayMember = "Unit";
            this.IngredientUnit.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.IngredientUnit.HeaderText = "";
            this.IngredientUnit.Name = "IngredientUnit";
            this.IngredientUnit.ReadOnly = true;
            this.IngredientUnit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IngredientUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IngredientUnit.ValueMember = "IngredientID";
            this.IngredientUnit.Width = 32;
            // 
            // ColumnStockChecked
            // 
            this.ColumnStockChecked.DataPropertyName = "StockVolume";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockChecked.DefaultCellStyle = dataGridViewCellStyle10;
            this.ColumnStockChecked.FillWeight = 64F;
            this.ColumnStockChecked.HeaderText = "盤點";
            this.ColumnStockChecked.Name = "ColumnStockChecked";
            this.ColumnStockChecked.Width = 64;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "StockMoney";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N1";
            dataGridViewCellStyle11.NullValue = null;
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn13.HeaderText = "金額";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 80;
            // 
            // LostMoney
            // 
            this.LostMoney.DataPropertyName = "LostMoney";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N1";
            dataGridViewCellStyle12.NullValue = null;
            this.LostMoney.DefaultCellStyle = dataGridViewCellStyle12;
            this.LostMoney.HeaderText = "盤損金";
            this.LostMoney.Name = "LostMoney";
            this.LostMoney.Width = 80;
            // 
            // btnEvaluate
            // 
            this.btnEvaluate.Location = new System.Drawing.Point(649, 3);
            this.btnEvaluate.Name = "btnEvaluate";
            this.btnEvaluate.Size = new System.Drawing.Size(92, 29);
            this.btnEvaluate.TabIndex = 70;
            this.btnEvaluate.Text = "重估此單";
            this.btnEvaluate.UseVisualStyleBackColor = true;
            this.btnEvaluate.Click += new System.EventHandler(this.btnEvaluate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(762, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 71;
            this.label2.Text = "庫存金額";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(558, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 72;
            this.label4.Text = "損失金額";
            // 
            // ingredientTableAdapter
            // 
            this.ingredientTableAdapter.ClearBeforeFill = true;
            // 
            // chBoxHide
            // 
            this.chBoxHide.AutoSize = true;
            this.chBoxHide.Checked = true;
            this.chBoxHide.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBoxHide.Location = new System.Drawing.Point(761, 7);
            this.chBoxHide.Name = "chBoxHide";
            this.chBoxHide.Size = new System.Drawing.Size(139, 20);
            this.chBoxHide.TabIndex = 73;
            this.chBoxHide.Text = "隱藏無資料食材";
            this.chBoxHide.UseVisualStyleBackColor = true;
            this.chBoxHide.CheckedChanged += new System.EventHandler(this.chBoxHide_CheckedChanged);
            // 
            // checkDayDateTimePicker
            // 
            this.checkDayDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.inventoryBindingSource, "CheckDay", true));
            this.checkDayDateTimePicker.Location = new System.Drawing.Point(493, 4);
            this.checkDayDateTimePicker.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.checkDayDateTimePicker.MinDate = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.checkDayDateTimePicker.Name = "checkDayDateTimePicker";
            this.checkDayDateTimePicker.Size = new System.Drawing.Size(134, 27);
            this.checkDayDateTimePicker.TabIndex = 74;
            this.checkDayDateTimePicker.Validating += new System.ComponentModel.CancelEventHandler(this.checkDayDateTimePicker_Validating);
            // 
            // labelIngredientsCount
            // 
            this.labelIngredientsCount.Location = new System.Drawing.Point(493, 42);
            this.labelIngredientsCount.Name = "labelIngredientsCount";
            this.labelIngredientsCount.Size = new System.Drawing.Size(47, 16);
            this.labelIngredientsCount.TabIndex = 75;
            // 
            // operatorTableAdapter
            // 
            this.operatorTableAdapter.ClearBeforeFill = true;
            // 
            // totalStockMoneyTextBox
            // 
            this.totalStockMoneyTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.totalStockMoneyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.inventoryBindingSource, "TotalStockMoney", true));
            this.totalStockMoneyTextBox.Location = new System.Drawing.Point(840, 37);
            this.totalStockMoneyTextBox.Name = "totalStockMoneyTextBox";
            this.totalStockMoneyTextBox.Size = new System.Drawing.Size(90, 27);
            this.totalStockMoneyTextBox.TabIndex = 76;
            this.totalStockMoneyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totalLostMoneyTextBox
            // 
            this.totalLostMoneyTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.totalLostMoneyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.inventoryBindingSource, "TotalLostMoney", true));
            this.totalLostMoneyTextBox.Location = new System.Drawing.Point(649, 37);
            this.totalLostMoneyTextBox.Name = "totalLostMoneyTextBox";
            this.totalLostMoneyTextBox.Size = new System.Drawing.Size(90, 27);
            this.totalLostMoneyTextBox.TabIndex = 77;
            this.totalLostMoneyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FormIngredientInventories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(986, 808);
            this.Controls.Add(this.totalLostMoneyTextBox);
            this.Controls.Add(this.totalStockMoneyTextBox);
            this.Controls.Add(this.labelIngredientsCount);
            this.Controls.Add(this.checkDayDateTimePicker);
            this.Controls.Add(this.chBoxHide);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvInventoryDetail);
            this.Controls.Add(this.btnEvaluate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvInventories);
            this.Controls.Add(this.inventoryBindingNavigator);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormIngredientInventories";
            this.Text = "食材盤點表輸入";
            this.Load += new System.EventHandler(this.FormIngredientInventories_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingNavigator)).EndInit();
            this.inventoryBindingNavigator.ResumeLayout(false);
            this.inventoryBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource inventoryBindingSource;
        private VEDataSetTableAdapters.InventoryTableAdapter inventoryTableAdapter;
        private System.Windows.Forms.BindingNavigator inventoryBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton inventoryBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView dgvInventories;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource inventoryDetailBindingSource;
        private VEDataSetTableAdapters.InventoryDetailTableAdapter inventoryDetailTableAdapter;
        private System.Windows.Forms.DataGridView dgvInventoryDetail;
        private System.Windows.Forms.Button btnEvaluate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource ingredientBindingSource;
        private VEDataSetTableAdapters.IngredientTableAdapter ingredientTableAdapter;
        private System.Windows.Forms.CheckBox chBoxHide;
        private System.Windows.Forms.DateTimePicker checkDayDateTimePicker;
        private System.Windows.Forms.Label labelIngredientsCount;
        private System.Windows.Forms.BindingSource operatorBindingSource;
        private VEDataSetTableAdapters.OperatorTableAdapter operatorTableAdapter;
        private System.Windows.Forms.TextBox totalStockMoneyTextBox;
        private System.Windows.Forms.TextBox totalLostMoneyTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPosition;
        private System.Windows.Forms.DataGridViewComboBoxColumn IngredientID;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewComboBoxColumn IngredientUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn LostMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInventoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn EvaluatedDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnKeyID;
    }
}