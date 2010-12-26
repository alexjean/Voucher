namespace VoucherExpense
{
    partial class Product
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
            System.Windows.Forms.Label productIDLabel;
            System.Windows.Forms.Label codeLabel;
            System.Windows.Forms.Label classLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label priceLabel;
            System.Windows.Forms.Label menuXLabel;
            System.Windows.Forms.Label menuYLabel;
            System.Windows.Forms.Label unitLabel;
            System.Windows.Forms.Label initialStockLabel;
            System.Windows.Forms.Label initialCostLabel;
            System.Windows.Forms.Label lastUpdatedLabel;
            System.Windows.Forms.Label unitVolumeLabel;
            System.Windows.Forms.Label canPurchaseLabel;
            System.Windows.Forms.Label referenceCostLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Product));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.productBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.productBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.productDataGridView = new System.Windows.Forms.DataGridView();
            this.CanPurchase = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.productIDTextBox = new System.Windows.Forms.TextBox();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.classTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.menuXTextBox = new System.Windows.Forms.TextBox();
            this.menuYTextBox = new System.Windows.Forms.TextBox();
            this.unitTextBox = new System.Windows.Forms.TextBox();
            this.initialStockTextBox = new System.Windows.Forms.TextBox();
            this.initialCostTextBox = new System.Windows.Forms.TextBox();
            this.unitVolumeTextBox = new System.Windows.Forms.TextBox();
            this.lastUpdatedTextBox = new System.Windows.Forms.TextBox();
            this.canPurchaseCheckBox = new System.Windows.Forms.CheckBox();
            this.referenceCostTextBox = new System.Windows.Forms.TextBox();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.columnProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productTableAdapter = new VoucherExpense.VEDataSetTableAdapters.ProductTableAdapter();
            productIDLabel = new System.Windows.Forms.Label();
            codeLabel = new System.Windows.Forms.Label();
            classLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            priceLabel = new System.Windows.Forms.Label();
            menuXLabel = new System.Windows.Forms.Label();
            menuYLabel = new System.Windows.Forms.Label();
            unitLabel = new System.Windows.Forms.Label();
            initialStockLabel = new System.Windows.Forms.Label();
            initialCostLabel = new System.Windows.Forms.Label();
            lastUpdatedLabel = new System.Windows.Forms.Label();
            unitVolumeLabel = new System.Windows.Forms.Label();
            canPurchaseLabel = new System.Windows.Forms.Label();
            referenceCostLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingNavigator)).BeginInit();
            this.productBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // productIDLabel
            // 
            productIDLabel.AutoSize = true;
            productIDLabel.Location = new System.Drawing.Point(513, 82);
            productIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            productIDLabel.Name = "productIDLabel";
            productIDLabel.Size = new System.Drawing.Size(44, 16);
            productIDLabel.TabIndex = 2;
            productIDLabel.Text = "內碼:";
            // 
            // codeLabel
            // 
            codeLabel.AutoSize = true;
            codeLabel.Location = new System.Drawing.Point(513, 120);
            codeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            codeLabel.Name = "codeLabel";
            codeLabel.Size = new System.Drawing.Size(44, 16);
            codeLabel.TabIndex = 4;
            codeLabel.Text = "代号:";
            // 
            // classLabel
            // 
            classLabel.AutoSize = true;
            classLabel.Location = new System.Drawing.Point(513, 157);
            classLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            classLabel.Name = "classLabel";
            classLabel.Size = new System.Drawing.Size(44, 16);
            classLabel.TabIndex = 6;
            classLabel.Text = "類別:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(513, 194);
            nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(44, 16);
            nameLabel.TabIndex = 8;
            nameLabel.Text = "品名:";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new System.Drawing.Point(513, 232);
            priceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new System.Drawing.Size(44, 16);
            priceLabel.TabIndex = 10;
            priceLabel.Text = "售價:";
            // 
            // menuXLabel
            // 
            menuXLabel.AutoSize = true;
            menuXLabel.Location = new System.Drawing.Point(513, 533);
            menuXLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            menuXLabel.Name = "menuXLabel";
            menuXLabel.Size = new System.Drawing.Size(63, 16);
            menuXLabel.TabIndex = 12;
            menuXLabel.Text = "Menu X:";
            // 
            // menuYLabel
            // 
            menuYLabel.AutoSize = true;
            menuYLabel.Location = new System.Drawing.Point(513, 570);
            menuYLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            menuYLabel.Name = "menuYLabel";
            menuYLabel.Size = new System.Drawing.Size(63, 16);
            menuYLabel.TabIndex = 14;
            menuYLabel.Text = "Menu Y:";
            // 
            // unitLabel
            // 
            unitLabel.AutoSize = true;
            unitLabel.Location = new System.Drawing.Point(513, 340);
            unitLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            unitLabel.Name = "unitLabel";
            unitLabel.Size = new System.Drawing.Size(44, 16);
            unitLabel.TabIndex = 16;
            unitLabel.Text = "單位:";
            // 
            // initialStockLabel
            // 
            initialStockLabel.AutoSize = true;
            initialStockLabel.Location = new System.Drawing.Point(513, 377);
            initialStockLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            initialStockLabel.Name = "initialStockLabel";
            initialStockLabel.Size = new System.Drawing.Size(76, 16);
            initialStockLabel.TabIndex = 18;
            initialStockLabel.Text = "年初庫存:";
            // 
            // initialCostLabel
            // 
            initialCostLabel.AutoSize = true;
            initialCostLabel.Location = new System.Drawing.Point(513, 414);
            initialCostLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            initialCostLabel.Name = "initialCostLabel";
            initialCostLabel.Size = new System.Drawing.Size(76, 16);
            initialCostLabel.TabIndex = 20;
            initialCostLabel.Text = "年初成本:";
            // 
            // lastUpdatedLabel
            // 
            lastUpdatedLabel.AutoSize = true;
            lastUpdatedLabel.Location = new System.Drawing.Point(513, 489);
            lastUpdatedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lastUpdatedLabel.Name = "lastUpdatedLabel";
            lastUpdatedLabel.Size = new System.Drawing.Size(60, 16);
            lastUpdatedLabel.TabIndex = 22;
            lastUpdatedLabel.Text = "更新日:";
            // 
            // unitVolumeLabel
            // 
            unitVolumeLabel.AutoSize = true;
            unitVolumeLabel.Location = new System.Drawing.Point(513, 453);
            unitVolumeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            unitVolumeLabel.Name = "unitVolumeLabel";
            unitVolumeLabel.Size = new System.Drawing.Size(60, 16);
            unitVolumeLabel.TabIndex = 24;
            unitVolumeLabel.Text = "每份量:";
            // 
            // canPurchaseLabel
            // 
            canPurchaseLabel.AutoSize = true;
            canPurchaseLabel.Location = new System.Drawing.Point(513, 267);
            canPurchaseLabel.Name = "canPurchaseLabel";
            canPurchaseLabel.Size = new System.Drawing.Size(60, 16);
            canPurchaseLabel.TabIndex = 26;
            canPurchaseLabel.Text = "能進貨:";
            // 
            // referenceCostLabel
            // 
            referenceCostLabel.AutoSize = true;
            referenceCostLabel.Location = new System.Drawing.Point(512, 302);
            referenceCostLabel.Name = "referenceCostLabel";
            referenceCostLabel.Size = new System.Drawing.Size(76, 16);
            referenceCostLabel.TabIndex = 28;
            referenceCostLabel.Text = "參考成本:";
            // 
            // productBindingNavigator
            // 
            this.productBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.productBindingNavigator.BindingSource = this.productBindingSource;
            this.productBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.productBindingNavigator.DeleteItem = null;
            this.productBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.productBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.productBindingNavigatorSaveItem});
            this.productBindingNavigator.Location = new System.Drawing.Point(475, 0);
            this.productBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.productBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.productBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.productBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.productBindingNavigator.Name = "productBindingNavigator";
            this.productBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.productBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.productBindingNavigator.Size = new System.Drawing.Size(278, 27);
            this.productBindingNavigator.TabIndex = 0;
            this.productBindingNavigator.Text = "bindingNavigator1";
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
            // productBindingNavigatorSaveItem
            // 
            this.productBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.productBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("productBindingNavigatorSaveItem.Image")));
            this.productBindingNavigatorSaveItem.Name = "productBindingNavigatorSaveItem";
            this.productBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 24);
            this.productBindingNavigatorSaveItem.Text = "儲存資料";
            this.productBindingNavigatorSaveItem.Click += new System.EventHandler(this.productBindingNavigatorSaveItem_Click);
            // 
            // productDataGridView
            // 
            this.productDataGridView.AllowUserToDeleteRows = false;
            this.productDataGridView.AllowUserToOrderColumns = true;
            this.productDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.productDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.productDataGridView.AutoGenerateColumns = false;
            this.productDataGridView.BackgroundColor = System.Drawing.Color.SeaShell;
            this.productDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnProductID,
            this.CanPurchase,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.productDataGridView.DataSource = this.productBindingSource;
            this.productDataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.productDataGridView.Location = new System.Drawing.Point(0, 0);
            this.productDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.productDataGridView.Name = "productDataGridView";
            this.productDataGridView.RowHeadersWidth = 25;
            this.productDataGridView.RowTemplate.Height = 24;
            this.productDataGridView.Size = new System.Drawing.Size(471, 641);
            this.productDataGridView.TabIndex = 1;
            // 
            // CanPurchase
            // 
            this.CanPurchase.DataPropertyName = "CanPurchase";
            this.CanPurchase.HeaderText = "可進";
            this.CanPurchase.Name = "CanPurchase";
            this.CanPurchase.ReadOnly = true;
            this.CanPurchase.Width = 50;
            // 
            // productIDTextBox
            // 
            this.productIDTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.productIDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.productIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "ProductID", true));
            this.productIDTextBox.Location = new System.Drawing.Point(626, 82);
            this.productIDTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.productIDTextBox.Name = "productIDTextBox";
            this.productIDTextBox.ReadOnly = true;
            this.productIDTextBox.Size = new System.Drawing.Size(183, 20);
            this.productIDTextBox.TabIndex = 3;
            // 
            // codeTextBox
            // 
            this.codeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Code", true));
            this.codeTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.codeTextBox.Location = new System.Drawing.Point(626, 116);
            this.codeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(183, 27);
            this.codeTextBox.TabIndex = 5;
            this.codeTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.codeTextBox_Validating);
            // 
            // classTextBox
            // 
            this.classTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Class", true));
            this.classTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.classTextBox.Location = new System.Drawing.Point(626, 153);
            this.classTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.classTextBox.Name = "classTextBox";
            this.classTextBox.Size = new System.Drawing.Size(183, 27);
            this.classTextBox.TabIndex = 7;
            this.classTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.classTextBox_Validating);
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Name", true));
            this.nameTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.nameTextBox.Location = new System.Drawing.Point(626, 190);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(183, 27);
            this.nameTextBox.TabIndex = 9;
            // 
            // priceTextBox
            // 
            this.priceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Price", true));
            this.priceTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.priceTextBox.Location = new System.Drawing.Point(626, 228);
            this.priceTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(183, 27);
            this.priceTextBox.TabIndex = 11;
            this.priceTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.priceTextBox_Validating);
            // 
            // menuXTextBox
            // 
            this.menuXTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.menuXTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.menuXTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "MenuX", true));
            this.menuXTextBox.Location = new System.Drawing.Point(626, 533);
            this.menuXTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.menuXTextBox.Name = "menuXTextBox";
            this.menuXTextBox.ReadOnly = true;
            this.menuXTextBox.Size = new System.Drawing.Size(183, 20);
            this.menuXTextBox.TabIndex = 13;
            // 
            // menuYTextBox
            // 
            this.menuYTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.menuYTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.menuYTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "MenuY", true));
            this.menuYTextBox.Location = new System.Drawing.Point(626, 570);
            this.menuYTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.menuYTextBox.Name = "menuYTextBox";
            this.menuYTextBox.ReadOnly = true;
            this.menuYTextBox.Size = new System.Drawing.Size(183, 20);
            this.menuYTextBox.TabIndex = 15;
            // 
            // unitTextBox
            // 
            this.unitTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Unit", true));
            this.unitTextBox.Location = new System.Drawing.Point(626, 336);
            this.unitTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.unitTextBox.Name = "unitTextBox";
            this.unitTextBox.Size = new System.Drawing.Size(183, 27);
            this.unitTextBox.TabIndex = 17;
            // 
            // initialStockTextBox
            // 
            this.initialStockTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "InitialStock", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.initialStockTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.initialStockTextBox.Location = new System.Drawing.Point(626, 373);
            this.initialStockTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.initialStockTextBox.Name = "initialStockTextBox";
            this.initialStockTextBox.Size = new System.Drawing.Size(183, 27);
            this.initialStockTextBox.TabIndex = 19;
            this.initialStockTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.initialStockTextBox_Validating);
            // 
            // initialCostTextBox
            // 
            this.initialCostTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "InitialCost", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.initialCostTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.initialCostTextBox.Location = new System.Drawing.Point(626, 410);
            this.initialCostTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.initialCostTextBox.Name = "initialCostTextBox";
            this.initialCostTextBox.Size = new System.Drawing.Size(183, 27);
            this.initialCostTextBox.TabIndex = 21;
            this.initialCostTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.initialCostTextBox_Validating);
            // 
            // unitVolumeTextBox
            // 
            this.unitVolumeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "UnitVolume", true));
            this.unitVolumeTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.unitVolumeTextBox.Location = new System.Drawing.Point(626, 448);
            this.unitVolumeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.unitVolumeTextBox.Name = "unitVolumeTextBox";
            this.unitVolumeTextBox.Size = new System.Drawing.Size(183, 27);
            this.unitVolumeTextBox.TabIndex = 25;
            this.unitVolumeTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.unitVolumeTextBox_Validating);
            // 
            // lastUpdatedTextBox
            // 
            this.lastUpdatedTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.lastUpdatedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastUpdatedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "LastUpdated", true));
            this.lastUpdatedTextBox.Location = new System.Drawing.Point(626, 489);
            this.lastUpdatedTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.lastUpdatedTextBox.Name = "lastUpdatedTextBox";
            this.lastUpdatedTextBox.ReadOnly = true;
            this.lastUpdatedTextBox.Size = new System.Drawing.Size(183, 20);
            this.lastUpdatedTextBox.TabIndex = 26;
            // 
            // canPurchaseCheckBox
            // 
            this.canPurchaseCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.productBindingSource, "CanPurchase", true));
            this.canPurchaseCheckBox.Location = new System.Drawing.Point(625, 267);
            this.canPurchaseCheckBox.Name = "canPurchaseCheckBox";
            this.canPurchaseCheckBox.Size = new System.Drawing.Size(104, 24);
            this.canPurchaseCheckBox.TabIndex = 27;
            // 
            // referenceCostTextBox
            // 
            this.referenceCostTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.referenceCostTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "ReferenceCost", true));
            this.referenceCostTextBox.Location = new System.Drawing.Point(625, 297);
            this.referenceCostTextBox.Name = "referenceCostTextBox";
            this.referenceCostTextBox.ReadOnly = true;
            this.referenceCostTextBox.Size = new System.Drawing.Size(183, 27);
            this.referenceCostTextBox.TabIndex = 29;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.vEDataSet;
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // columnProductID
            // 
            this.columnProductID.DataPropertyName = "ProductID";
            this.columnProductID.HeaderText = "內碼";
            this.columnProductID.Name = "columnProductID";
            this.columnProductID.ReadOnly = true;
            this.columnProductID.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Code";
            this.dataGridViewTextBoxColumn2.HeaderText = "代号";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Class";
            this.dataGridViewTextBoxColumn3.HeaderText = "類";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 25;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn4.HeaderText = "品名";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 180;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Price";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn5.HeaderText = "售價";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 55;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(870, 641);
            this.Controls.Add(referenceCostLabel);
            this.Controls.Add(this.referenceCostTextBox);
            this.Controls.Add(canPurchaseLabel);
            this.Controls.Add(this.canPurchaseCheckBox);
            this.Controls.Add(this.lastUpdatedTextBox);
            this.Controls.Add(productIDLabel);
            this.Controls.Add(this.productIDTextBox);
            this.Controls.Add(codeLabel);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(classLabel);
            this.Controls.Add(this.classTextBox);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(priceLabel);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(menuXLabel);
            this.Controls.Add(this.menuXTextBox);
            this.Controls.Add(menuYLabel);
            this.Controls.Add(this.menuYTextBox);
            this.Controls.Add(unitLabel);
            this.Controls.Add(this.unitTextBox);
            this.Controls.Add(initialStockLabel);
            this.Controls.Add(this.initialStockTextBox);
            this.Controls.Add(initialCostLabel);
            this.Controls.Add(this.initialCostTextBox);
            this.Controls.Add(lastUpdatedLabel);
            this.Controls.Add(unitVolumeLabel);
            this.Controls.Add(this.unitVolumeTextBox);
            this.Controls.Add(this.productDataGridView);
            this.Controls.Add(this.productBindingNavigator);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Product";
            this.Text = "產品表";
            this.Load += new System.EventHandler(this.Product_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productBindingNavigator)).EndInit();
            this.productBindingNavigator.ResumeLayout(false);
            this.productBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource productBindingSource;
        private VoucherExpense.VEDataSetTableAdapters.ProductTableAdapter productTableAdapter;
        private System.Windows.Forms.BindingNavigator productBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton productBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView productDataGridView;
        private System.Windows.Forms.TextBox productIDTextBox;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.TextBox classTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox menuXTextBox;
        private System.Windows.Forms.TextBox menuYTextBox;
        private System.Windows.Forms.TextBox unitTextBox;
        private System.Windows.Forms.TextBox initialStockTextBox;
        private System.Windows.Forms.TextBox initialCostTextBox;
        private System.Windows.Forms.TextBox unitVolumeTextBox;
        private System.Windows.Forms.TextBox lastUpdatedTextBox;
        private System.Windows.Forms.CheckBox canPurchaseCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnProductID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CanPurchase;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.TextBox referenceCostTextBox;

    }
}