namespace VoucherExpense
{
    partial class Ingredient
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label IngredientIDLabel;
            System.Windows.Forms.Label codeLabel;
            System.Windows.Forms.Label classLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label priceLabel;
            System.Windows.Forms.Label unitLabel;
            System.Windows.Forms.Label lastUpdatedLabel;
            System.Windows.Forms.Label canPurchaseLabel;
            System.Windows.Forms.Label titleCodeLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ingredient));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.IngredientBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.IngredientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.IngredientBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.IngredientDataGridView = new System.Windows.Forms.DataGridView();
            this.columnIngredientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanPurchase = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTitleCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.accountingTitleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.columnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientIDTextBox = new System.Windows.Forms.TextBox();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.classTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.unitTextBox = new System.Windows.Forms.TextBox();
            this.lastUpdatedTextBox = new System.Windows.Forms.TextBox();
            this.canPurchaseCheckBox = new System.Windows.Forms.CheckBox();
            this.IngredientTableAdapter = new VoucherExpense.VEDataSetTableAdapters.IngredientTableAdapter();
            this.accountingTitleTableAdapter = new VoucherExpense.VEDataSetTableAdapters.AccountingTitleTableAdapter();
            this.titleCodeComboBox = new System.Windows.Forms.ComboBox();
            IngredientIDLabel = new System.Windows.Forms.Label();
            codeLabel = new System.Windows.Forms.Label();
            classLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            priceLabel = new System.Windows.Forms.Label();
            unitLabel = new System.Windows.Forms.Label();
            lastUpdatedLabel = new System.Windows.Forms.Label();
            canPurchaseLabel = new System.Windows.Forms.Label();
            titleCodeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientBindingNavigator)).BeginInit();
            this.IngredientBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // IngredientIDLabel
            // 
            IngredientIDLabel.AutoSize = true;
            IngredientIDLabel.Location = new System.Drawing.Point(627, 87);
            IngredientIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            IngredientIDLabel.Name = "IngredientIDLabel";
            IngredientIDLabel.Size = new System.Drawing.Size(44, 16);
            IngredientIDLabel.TabIndex = 2;
            IngredientIDLabel.Text = "內碼:";
            // 
            // codeLabel
            // 
            codeLabel.AutoSize = true;
            codeLabel.Location = new System.Drawing.Point(627, 124);
            codeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            codeLabel.Name = "codeLabel";
            codeLabel.Size = new System.Drawing.Size(44, 16);
            codeLabel.TabIndex = 4;
            codeLabel.Text = "代号:";
            // 
            // classLabel
            // 
            classLabel.AutoSize = true;
            classLabel.Location = new System.Drawing.Point(627, 161);
            classLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            classLabel.Name = "classLabel";
            classLabel.Size = new System.Drawing.Size(44, 16);
            classLabel.TabIndex = 6;
            classLabel.Text = "類別:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(627, 198);
            nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(44, 16);
            nameLabel.TabIndex = 8;
            nameLabel.Text = "品名:";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new System.Drawing.Point(627, 272);
            priceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new System.Drawing.Size(60, 16);
            priceLabel.TabIndex = 10;
            priceLabel.Text = "參考價:";
            // 
            // unitLabel
            // 
            unitLabel.AutoSize = true;
            unitLabel.Location = new System.Drawing.Point(626, 346);
            unitLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            unitLabel.Name = "unitLabel";
            unitLabel.Size = new System.Drawing.Size(44, 16);
            unitLabel.TabIndex = 16;
            unitLabel.Text = "單位:";
            // 
            // lastUpdatedLabel
            // 
            lastUpdatedLabel.AutoSize = true;
            lastUpdatedLabel.Location = new System.Drawing.Point(627, 383);
            lastUpdatedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lastUpdatedLabel.Name = "lastUpdatedLabel";
            lastUpdatedLabel.Size = new System.Drawing.Size(60, 16);
            lastUpdatedLabel.TabIndex = 22;
            lastUpdatedLabel.Text = "更新日:";
            // 
            // canPurchaseLabel
            // 
            canPurchaseLabel.AutoSize = true;
            canPurchaseLabel.Location = new System.Drawing.Point(627, 309);
            canPurchaseLabel.Name = "canPurchaseLabel";
            canPurchaseLabel.Size = new System.Drawing.Size(60, 16);
            canPurchaseLabel.TabIndex = 26;
            canPurchaseLabel.Text = "能進貨:";
            // 
            // titleCodeLabel
            // 
            titleCodeLabel.AutoSize = true;
            titleCodeLabel.Location = new System.Drawing.Point(626, 235);
            titleCodeLabel.Name = "titleCodeLabel";
            titleCodeLabel.Size = new System.Drawing.Size(44, 16);
            titleCodeLabel.TabIndex = 27;
            titleCodeLabel.Text = "科目:";
            // 
            // IngredientBindingNavigator
            // 
            this.IngredientBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.IngredientBindingNavigator.BindingSource = this.IngredientBindingSource;
            this.IngredientBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.IngredientBindingNavigator.DeleteItem = null;
            this.IngredientBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.IngredientBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.IngredientBindingNavigatorSaveItem});
            this.IngredientBindingNavigator.Location = new System.Drawing.Point(621, 0);
            this.IngredientBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.IngredientBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.IngredientBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.IngredientBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.IngredientBindingNavigator.Name = "IngredientBindingNavigator";
            this.IngredientBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.IngredientBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.IngredientBindingNavigator.Size = new System.Drawing.Size(278, 27);
            this.IngredientBindingNavigator.TabIndex = 0;
            this.IngredientBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorAddNewItem.Text = "加入新的";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // IngredientBindingSource
            // 
            this.IngredientBindingSource.DataMember = "Ingredient";
            this.IngredientBindingSource.DataSource = this.vEDataSet;
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(34, 24);
            this.bindingNavigatorCountItem.Text = "/{0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目總數";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveFirstItem.Text = "移到最前面";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一個";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(73, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "目前的位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveNextItem.Text = "移到下一個";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveLastItem.Text = "移到最後面";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // IngredientBindingNavigatorSaveItem
            // 
            this.IngredientBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IngredientBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("IngredientBindingNavigatorSaveItem.Image")));
            this.IngredientBindingNavigatorSaveItem.Name = "IngredientBindingNavigatorSaveItem";
            this.IngredientBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 24);
            this.IngredientBindingNavigatorSaveItem.Text = "儲存資料";
            this.IngredientBindingNavigatorSaveItem.Click += new System.EventHandler(this.IngredientBindingNavigatorSaveItem_Click);
            // 
            // IngredientDataGridView
            // 
            this.IngredientDataGridView.AllowUserToAddRows = false;
            this.IngredientDataGridView.AllowUserToDeleteRows = false;
            this.IngredientDataGridView.AllowUserToOrderColumns = true;
            this.IngredientDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.IngredientDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.IngredientDataGridView.AutoGenerateColumns = false;
            this.IngredientDataGridView.BackgroundColor = System.Drawing.Color.SeaShell;
            this.IngredientDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnIngredientID,
            this.CanPurchase,
            this.columnCode,
            this.columnClass,
            this.columnName,
            this.Unit,
            this.columnTitleCode,
            this.columnPrice});
            this.IngredientDataGridView.DataSource = this.IngredientBindingSource;
            this.IngredientDataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.IngredientDataGridView.Location = new System.Drawing.Point(0, 0);
            this.IngredientDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.IngredientDataGridView.Name = "IngredientDataGridView";
            this.IngredientDataGridView.RowHeadersWidth = 25;
            this.IngredientDataGridView.RowTemplate.Height = 24;
            this.IngredientDataGridView.Size = new System.Drawing.Size(617, 641);
            this.IngredientDataGridView.TabIndex = 1;
            this.IngredientDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.IngredientDataGridView_CellBeginEdit);
            // 
            // columnIngredientID
            // 
            this.columnIngredientID.DataPropertyName = "IngredientID";
            this.columnIngredientID.HeaderText = "內碼";
            this.columnIngredientID.Name = "columnIngredientID";
            this.columnIngredientID.ReadOnly = true;
            this.columnIngredientID.Width = 50;
            // 
            // CanPurchase
            // 
            this.CanPurchase.DataPropertyName = "CanPurchase";
            this.CanPurchase.HeaderText = "可進";
            this.CanPurchase.Name = "CanPurchase";
            this.CanPurchase.Width = 50;
            // 
            // columnCode
            // 
            this.columnCode.DataPropertyName = "Code";
            this.columnCode.HeaderText = "代号";
            this.columnCode.Name = "columnCode";
            this.columnCode.Width = 50;
            // 
            // columnClass
            // 
            this.columnClass.DataPropertyName = "Class";
            this.columnClass.HeaderText = "類";
            this.columnClass.Name = "columnClass";
            this.columnClass.Width = 25;
            // 
            // columnName
            // 
            this.columnName.DataPropertyName = "Name";
            this.columnName.HeaderText = "品名";
            this.columnName.Name = "columnName";
            this.columnName.Width = 180;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "單位";
            this.Unit.Name = "Unit";
            this.Unit.Width = 55;
            // 
            // columnTitleCode
            // 
            this.columnTitleCode.DataPropertyName = "TitleCode";
            this.columnTitleCode.DataSource = this.accountingTitleBindingSource;
            this.columnTitleCode.DisplayMember = "Name";
            this.columnTitleCode.HeaderText = "科目";
            this.columnTitleCode.MaxDropDownItems = 16;
            this.columnTitleCode.Name = "columnTitleCode";
            this.columnTitleCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnTitleCode.ValueMember = "TitleCode";
            // 
            // accountingTitleBindingSource
            // 
            this.accountingTitleBindingSource.DataMember = "AccountingTitle";
            this.accountingTitleBindingSource.DataSource = this.vEDataSet;
            this.accountingTitleBindingSource.Filter = "TitleCode like \'5*\'";
            // 
            // columnPrice
            // 
            this.columnPrice.DataPropertyName = "Price";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.columnPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.columnPrice.HeaderText = "參考價";
            this.columnPrice.Name = "columnPrice";
            this.columnPrice.Width = 55;
            // 
            // IngredientIDTextBox
            // 
            this.IngredientIDTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.IngredientIDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IngredientIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.IngredientBindingSource, "IngredientID", true));
            this.IngredientIDTextBox.Location = new System.Drawing.Point(717, 85);
            this.IngredientIDTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.IngredientIDTextBox.Name = "IngredientIDTextBox";
            this.IngredientIDTextBox.ReadOnly = true;
            this.IngredientIDTextBox.Size = new System.Drawing.Size(121, 20);
            this.IngredientIDTextBox.TabIndex = 3;
            // 
            // codeTextBox
            // 
            this.codeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.IngredientBindingSource, "Code", true));
            this.codeTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.codeTextBox.Location = new System.Drawing.Point(717, 119);
            this.codeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(121, 27);
            this.codeTextBox.TabIndex = 5;
            this.codeTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.codeTextBox_Validating);
            // 
            // classTextBox
            // 
            this.classTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.IngredientBindingSource, "Class", true));
            this.classTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.classTextBox.Location = new System.Drawing.Point(717, 156);
            this.classTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.classTextBox.Name = "classTextBox";
            this.classTextBox.Size = new System.Drawing.Size(121, 27);
            this.classTextBox.TabIndex = 7;
            this.classTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.classTextBox_Validating);
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.IngredientBindingSource, "Name", true));
            this.nameTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.nameTextBox.Location = new System.Drawing.Point(717, 193);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(183, 27);
            this.nameTextBox.TabIndex = 9;
            // 
            // priceTextBox
            // 
            this.priceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.IngredientBindingSource, "Price", true));
            this.priceTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.priceTextBox.Location = new System.Drawing.Point(717, 267);
            this.priceTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(121, 27);
            this.priceTextBox.TabIndex = 11;
            this.priceTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.priceTextBox_Validating);
            // 
            // unitTextBox
            // 
            this.unitTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.IngredientBindingSource, "Unit", true));
            this.unitTextBox.Location = new System.Drawing.Point(716, 341);
            this.unitTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.unitTextBox.Name = "unitTextBox";
            this.unitTextBox.Size = new System.Drawing.Size(121, 27);
            this.unitTextBox.TabIndex = 17;
            // 
            // lastUpdatedTextBox
            // 
            this.lastUpdatedTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.lastUpdatedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastUpdatedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.IngredientBindingSource, "LastUpdated", true));
            this.lastUpdatedTextBox.Location = new System.Drawing.Point(716, 381);
            this.lastUpdatedTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.lastUpdatedTextBox.Name = "lastUpdatedTextBox";
            this.lastUpdatedTextBox.ReadOnly = true;
            this.lastUpdatedTextBox.Size = new System.Drawing.Size(184, 20);
            this.lastUpdatedTextBox.TabIndex = 26;
            // 
            // canPurchaseCheckBox
            // 
            this.canPurchaseCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.IngredientBindingSource, "CanPurchase", true));
            this.canPurchaseCheckBox.Location = new System.Drawing.Point(716, 305);
            this.canPurchaseCheckBox.Name = "canPurchaseCheckBox";
            this.canPurchaseCheckBox.Size = new System.Drawing.Size(104, 24);
            this.canPurchaseCheckBox.TabIndex = 27;
            // 
            // IngredientTableAdapter
            // 
            this.IngredientTableAdapter.ClearBeforeFill = true;
            // 
            // accountingTitleTableAdapter
            // 
            this.accountingTitleTableAdapter.ClearBeforeFill = true;
            // 
            // titleCodeComboBox
            // 
            this.titleCodeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.IngredientBindingSource, "TitleCode", true));
            this.titleCodeComboBox.DataSource = this.accountingTitleBindingSource;
            this.titleCodeComboBox.DisplayMember = "Name";
            this.titleCodeComboBox.FormattingEnabled = true;
            this.titleCodeComboBox.Location = new System.Drawing.Point(716, 231);
            this.titleCodeComboBox.MaxDropDownItems = 16;
            this.titleCodeComboBox.Name = "titleCodeComboBox";
            this.titleCodeComboBox.Size = new System.Drawing.Size(121, 24);
            this.titleCodeComboBox.TabIndex = 28;
            this.titleCodeComboBox.ValueMember = "TitleCode";
            // 
            // Ingredient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(908, 641);
            this.Controls.Add(this.titleCodeComboBox);
            this.Controls.Add(titleCodeLabel);
            this.Controls.Add(canPurchaseLabel);
            this.Controls.Add(this.canPurchaseCheckBox);
            this.Controls.Add(this.lastUpdatedTextBox);
            this.Controls.Add(IngredientIDLabel);
            this.Controls.Add(this.IngredientIDTextBox);
            this.Controls.Add(codeLabel);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(classLabel);
            this.Controls.Add(this.classTextBox);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(priceLabel);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(unitLabel);
            this.Controls.Add(this.unitTextBox);
            this.Controls.Add(lastUpdatedLabel);
            this.Controls.Add(this.IngredientDataGridView);
            this.Controls.Add(this.IngredientBindingNavigator);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Ingredient";
            this.Text = "食材表";
            this.Load += new System.EventHandler(this.Ingredient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IngredientBindingNavigator)).EndInit();
            this.IngredientBindingNavigator.ResumeLayout(false);
            this.IngredientBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource IngredientBindingSource;
        private VoucherExpense.VEDataSetTableAdapters.IngredientTableAdapter IngredientTableAdapter;
        private System.Windows.Forms.BindingNavigator IngredientBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton IngredientBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView IngredientDataGridView;
        private System.Windows.Forms.TextBox IngredientIDTextBox;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.TextBox classTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox unitTextBox;
        private System.Windows.Forms.TextBox lastUpdatedTextBox;
        private System.Windows.Forms.CheckBox canPurchaseCheckBox;
        private System.Windows.Forms.BindingSource accountingTitleBindingSource;
        private VoucherExpense.VEDataSetTableAdapters.AccountingTitleTableAdapter accountingTitleTableAdapter;
        private System.Windows.Forms.ComboBox titleCodeComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnIngredientID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CanPurchase;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewComboBoxColumn columnTitleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPrice;

    }
}