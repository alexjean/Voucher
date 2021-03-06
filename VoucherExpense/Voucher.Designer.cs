﻿namespace VoucherExpense
{
    partial class Voucher
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
            System.Windows.Forms.Label iDLabel;
            System.Windows.Forms.Label voucherIDLabel;
            System.Windows.Forms.Label vendorIDLabel;
            System.Windows.Forms.Label stockTimeLabel;
            System.Windows.Forms.Label costLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label entryTimeLabel;
            System.Windows.Forms.Label keyinIDLabel;
            System.Windows.Forms.Label removedLabel;
            System.Windows.Forms.Label lastUpdatedLabel;
            System.Windows.Forms.Label lockedLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Voucher));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.voucherBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.damaiDataSet = new VoucherExpense.DamaiDataSet();
            this.voucherBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.voucherBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.列印PToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.venderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.IngredientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iDTextBox = new System.Windows.Forms.TextBox();
            this.voucherIDTextBox = new System.Windows.Forms.TextBox();
            this.accountingTitleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vendorIDComboBox = new System.Windows.Forms.ComboBox();
            this.venderFilterSource = new System.Windows.Forms.BindingSource(this.components);
            this.operatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stockTimeTextBox = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dgvVoucherDetail = new System.Windows.Forms.DataGridView();
            this.detailColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnVoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgIngredientIDColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgVolumeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUnitComlumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgCostColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTitleCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.voucherVoucherDetailSqlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.costTextBox = new System.Windows.Forms.TextBox();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.dgvVoucher = new System.Windows.Forms.DataGridView();
            this.columnRemoved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VoucherID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.columnCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ckBoxAllowEdit = new System.Windows.Forms.CheckBox();
            this.cbBoxIngredientSelector = new System.Windows.Forms.ComboBox();
            this.titleCodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.keyinIDComboBox = new System.Windows.Forms.ComboBox();
            this.entryTimeTextBox = new System.Windows.Forms.TextBox();
            this.lastUpdatedTextBox = new System.Windows.Forms.TextBox();
            this.removedCheckBox = new System.Windows.Forms.CheckBox();
            this.lockedCheckBox = new System.Windows.Forms.CheckBox();
            iDLabel = new System.Windows.Forms.Label();
            voucherIDLabel = new System.Windows.Forms.Label();
            vendorIDLabel = new System.Windows.Forms.Label();
            stockTimeLabel = new System.Windows.Forms.Label();
            costLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            entryTimeLabel = new System.Windows.Forms.Label();
            keyinIDLabel = new System.Windows.Forms.Label();
            removedLabel = new System.Windows.Forms.Label();
            lastUpdatedLabel = new System.Windows.Forms.Label();
            lockedLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.voucherBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.voucherBindingNavigator)).BeginInit();
            this.voucherBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.venderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.venderFilterSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucherDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.voucherVoucherDetailSqlBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleCodeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // iDLabel
            // 
            iDLabel.AutoSize = true;
            iDLabel.Location = new System.Drawing.Point(681, 51);
            iDLabel.Name = "iDLabel";
            iDLabel.Size = new System.Drawing.Size(40, 16);
            iDLabel.TabIndex = 2;
            iDLabel.Text = "順序";
            // 
            // voucherIDLabel
            // 
            voucherIDLabel.AutoSize = true;
            voucherIDLabel.Location = new System.Drawing.Point(681, 88);
            voucherIDLabel.Name = "voucherIDLabel";
            voucherIDLabel.Size = new System.Drawing.Size(56, 16);
            voucherIDLabel.TabIndex = 4;
            voucherIDLabel.Text = "憑証號";
            // 
            // vendorIDLabel
            // 
            vendorIDLabel.AllowDrop = true;
            vendorIDLabel.AutoSize = true;
            vendorIDLabel.Location = new System.Drawing.Point(430, 53);
            vendorIDLabel.Name = "vendorIDLabel";
            vendorIDLabel.Size = new System.Drawing.Size(60, 16);
            vendorIDLabel.TabIndex = 8;
            vendorIDLabel.Text = "供應商:";
            // 
            // stockTimeLabel
            // 
            stockTimeLabel.AutoSize = true;
            stockTimeLabel.Location = new System.Drawing.Point(430, 88);
            stockTimeLabel.Name = "stockTimeLabel";
            stockTimeLabel.Size = new System.Drawing.Size(76, 16);
            stockTimeLabel.TabIndex = 14;
            stockTimeLabel.Text = "進貨時間:";
            // 
            // costLabel
            // 
            costLabel.AutoSize = true;
            costLabel.Location = new System.Drawing.Point(681, 121);
            costLabel.Name = "costLabel";
            costLabel.Size = new System.Drawing.Size(40, 16);
            costLabel.TabIndex = 50;
            costLabel.Text = "總計";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(430, 120);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 16);
            label1.TabIndex = 54;
            label1.Text = "食材類";
            // 
            // entryTimeLabel
            // 
            entryTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            entryTimeLabel.AutoSize = true;
            entryTimeLabel.Location = new System.Drawing.Point(449, 594);
            entryTimeLabel.Name = "entryTimeLabel";
            entryTimeLabel.Size = new System.Drawing.Size(44, 16);
            entryTimeLabel.TabIndex = 16;
            entryTimeLabel.Text = "建單:";
            // 
            // keyinIDLabel
            // 
            keyinIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            keyinIDLabel.AutoSize = true;
            keyinIDLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            keyinIDLabel.Location = new System.Drawing.Point(450, 624);
            keyinIDLabel.Name = "keyinIDLabel";
            keyinIDLabel.Size = new System.Drawing.Size(44, 16);
            keyinIDLabel.TabIndex = 22;
            keyinIDLabel.Text = "輸入:";
            // 
            // removedLabel
            // 
            removedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            removedLabel.AutoSize = true;
            removedLabel.Location = new System.Drawing.Point(450, 565);
            removedLabel.Name = "removedLabel";
            removedLabel.Size = new System.Drawing.Size(44, 16);
            removedLabel.TabIndex = 24;
            removedLabel.Text = "作癈:";
            // 
            // lastUpdatedLabel
            // 
            lastUpdatedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            lastUpdatedLabel.AutoSize = true;
            lastUpdatedLabel.Location = new System.Drawing.Point(685, 624);
            lastUpdatedLabel.Name = "lastUpdatedLabel";
            lastUpdatedLabel.Size = new System.Drawing.Size(60, 16);
            lastUpdatedLabel.TabIndex = 28;
            lastUpdatedLabel.Text = "更新日:";
            // 
            // lockedLabel
            // 
            lockedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            lockedLabel.AutoSize = true;
            lockedLabel.Location = new System.Drawing.Point(685, 565);
            lockedLabel.Name = "lockedLabel";
            lockedLabel.Size = new System.Drawing.Size(44, 16);
            lockedLabel.TabIndex = 26;
            lockedLabel.Text = "複核:";
            // 
            // voucherBindingSource
            // 
            this.voucherBindingSource.DataMember = "Voucher";
            this.voucherBindingSource.DataSource = this.damaiDataSet;
            // 
            // damaiDataSet
            // 
            this.damaiDataSet.DataSetName = "DamaiDataSet";
            this.damaiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // voucherBindingNavigator
            // 
            this.voucherBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.voucherBindingNavigator.BackgroundImage = global::VoucherExpense.Properties.Resources.NavBar_Back;
            this.voucherBindingNavigator.BindingSource = this.voucherBindingSource;
            this.voucherBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.voucherBindingNavigator.DeleteItem = null;
            this.voucherBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.voucherBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.voucherBindingNavigatorSaveItem,
            this.列印PToolStripButton});
            this.voucherBindingNavigator.Location = new System.Drawing.Point(610, 0);
            this.voucherBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.voucherBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.voucherBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.voucherBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.voucherBindingNavigator.Name = "voucherBindingNavigator";
            this.voucherBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.voucherBindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.voucherBindingNavigator.Size = new System.Drawing.Size(270, 27);
            this.voucherBindingNavigator.TabIndex = 0;
            this.voucherBindingNavigator.Text = "bindingNavigator1";
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
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(27, 24);
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
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
            // voucherBindingNavigatorSaveItem
            // 
            this.voucherBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.voucherBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("voucherBindingNavigatorSaveItem.Image")));
            this.voucherBindingNavigatorSaveItem.Name = "voucherBindingNavigatorSaveItem";
            this.voucherBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 24);
            this.voucherBindingNavigatorSaveItem.Text = "儲存資料";
            this.voucherBindingNavigatorSaveItem.Click += new System.EventHandler(this.voucherBindingNavigatorSaveItem_Click);
            // 
            // 列印PToolStripButton
            // 
            this.列印PToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.列印PToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("列印PToolStripButton.Image")));
            this.列印PToolStripButton.Name = "列印PToolStripButton";
            this.列印PToolStripButton.Size = new System.Drawing.Size(23, 24);
            this.列印PToolStripButton.Text = "列印(&P)";
            this.列印PToolStripButton.Click += new System.EventHandler(this.列印PToolStripButton_Click);
            // 
            // venderBindingSource
            // 
            this.venderBindingSource.DataMember = "Vendor";
            this.venderBindingSource.DataSource = this.damaiDataSet;
            this.venderBindingSource.Filter = "";
            // 
            // IngredientBindingSource
            // 
            this.IngredientBindingSource.DataMember = "Ingredient";
            this.IngredientBindingSource.DataSource = this.damaiDataSet;
            this.IngredientBindingSource.Filter = "CanPurchase=true";
            // 
            // iDTextBox
            // 
            this.iDTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.iDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.iDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.voucherBindingSource, "ID", true));
            this.iDTextBox.Location = new System.Drawing.Point(747, 49);
            this.iDTextBox.Name = "iDTextBox";
            this.iDTextBox.ReadOnly = true;
            this.iDTextBox.Size = new System.Drawing.Size(69, 20);
            this.iDTextBox.TabIndex = 3;
            // 
            // voucherIDTextBox
            // 
            this.voucherIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.voucherBindingSource, "VoucherID", true));
            this.voucherIDTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.voucherIDTextBox.Location = new System.Drawing.Point(747, 83);
            this.voucherIDTextBox.Name = "voucherIDTextBox";
            this.voucherIDTextBox.Size = new System.Drawing.Size(94, 27);
            this.voucherIDTextBox.TabIndex = 38;
            // 
            // accountingTitleBindingSource
            // 
            this.accountingTitleBindingSource.DataMember = "AccountingTitle";
            this.accountingTitleBindingSource.DataSource = this.damaiDataSet;
            this.accountingTitleBindingSource.Filter = "TitleCode like \'5*\'";
            // 
            // vendorIDComboBox
            // 
            this.vendorIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.voucherBindingSource, "VendorID", true));
            this.vendorIDComboBox.DataSource = this.venderFilterSource;
            this.vendorIDComboBox.DisplayMember = "Name";
            this.vendorIDComboBox.DropDownHeight = 360;
            this.vendorIDComboBox.FormattingEnabled = true;
            this.vendorIDComboBox.IntegralHeight = false;
            this.vendorIDComboBox.Location = new System.Drawing.Point(512, 49);
            this.vendorIDComboBox.Name = "vendorIDComboBox";
            this.vendorIDComboBox.Size = new System.Drawing.Size(146, 24);
            this.vendorIDComboBox.TabIndex = 45;
            this.vendorIDComboBox.ValueMember = "VendorID";
            this.vendorIDComboBox.SelectedIndexChanged += new System.EventHandler(this.vendorIDComboBox_SelectedIndexChanged);
            // 
            // venderFilterSource
            // 
            this.venderFilterSource.DataMember = "Vendor";
            this.venderFilterSource.DataSource = this.damaiDataSet;
            this.venderFilterSource.Filter = "Hide = false";
            // 
            // operatorBindingSource
            // 
            this.operatorBindingSource.DataMember = "Operator";
            this.operatorBindingSource.DataSource = this.damaiDataSet;
            // 
            // stockTimeTextBox
            // 
            this.stockTimeTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.stockTimeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.voucherBindingSource, "StockTime", true));
            this.stockTimeTextBox.Location = new System.Drawing.Point(512, 83);
            this.stockTimeTextBox.Name = "stockTimeTextBox";
            this.stockTimeTextBox.ReadOnly = true;
            this.stockTimeTextBox.Size = new System.Drawing.Size(132, 27);
            this.stockTimeTextBox.TabIndex = 49;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(640, 83);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(17, 27);
            this.dateTimePicker1.TabIndex = 50;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dgvVoucherDetail
            // 
            this.dgvVoucherDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dgvVoucherDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVoucherDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVoucherDetail.AutoGenerateColumns = false;
            this.dgvVoucherDetail.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.dgvVoucherDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVoucherDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.detailColumnID,
            this.columnVoID,
            this.dgIngredientIDColumn,
            this.dgVolumeColumn,
            this.dgUnitComlumn,
            this.dgCostColumn,
            this.columnTitleCode});
            this.dgvVoucherDetail.DataSource = this.voucherVoucherDetailSqlBindingSource;
            this.dgvVoucherDetail.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.dgvVoucherDetail.Location = new System.Drawing.Point(409, 149);
            this.dgvVoucherDetail.Name = "dgvVoucherDetail";
            this.dgvVoucherDetail.RowHeadersWidth = 25;
            this.dgvVoucherDetail.RowTemplate.Height = 24;
            this.dgvVoucherDetail.Size = new System.Drawing.Size(548, 394);
            this.dgvVoucherDetail.TabIndex = 50;
            this.dgvVoucherDetail.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.voucherDetailDataGridView_CellValidated);
            this.dgvVoucherDetail.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.voucherDetailDataGridView_CellValidating);
            this.dgvVoucherDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.voucherDetailDataGridView_CellValueChanged);
            this.dgvVoucherDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.voucherDetailDataGridView_DataBindingComplete);
            this.dgvVoucherDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.voucherDetailDataGridView_DataError);
            this.dgvVoucherDetail.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.voucherDetailDataGridView_DefaultValuesNeeded);
            this.dgvVoucherDetail.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.voucherDetailDataGridView_UserDeletedRow);
            // 
            // detailColumnID
            // 
            this.detailColumnID.DataPropertyName = "ID";
            this.detailColumnID.HeaderText = "ID";
            this.detailColumnID.Name = "detailColumnID";
            this.detailColumnID.ReadOnly = true;
            this.detailColumnID.Visible = false;
            // 
            // columnVoID
            // 
            this.columnVoID.DataPropertyName = "VoID";
            this.columnVoID.HeaderText = "順序";
            this.columnVoID.Name = "columnVoID";
            this.columnVoID.ReadOnly = true;
            this.columnVoID.Visible = false;
            // 
            // dgIngredientIDColumn
            // 
            this.dgIngredientIDColumn.DataPropertyName = "IngredientID";
            this.dgIngredientIDColumn.DataSource = this.IngredientBindingSource;
            this.dgIngredientIDColumn.DisplayMember = "Name";
            this.dgIngredientIDColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dgIngredientIDColumn.HeaderText = "食材";
            this.dgIngredientIDColumn.MaxDropDownItems = 22;
            this.dgIngredientIDColumn.Name = "dgIngredientIDColumn";
            this.dgIngredientIDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgIngredientIDColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgIngredientIDColumn.ValueMember = "IngredientID";
            this.dgIngredientIDColumn.Width = 232;
            // 
            // dgVolumeColumn
            // 
            this.dgVolumeColumn.DataPropertyName = "Volume";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N1";
            dataGridViewCellStyle2.NullValue = null;
            this.dgVolumeColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgVolumeColumn.HeaderText = "量";
            this.dgVolumeColumn.Name = "dgVolumeColumn";
            this.dgVolumeColumn.Width = 48;
            // 
            // dgUnitComlumn
            // 
            this.dgUnitComlumn.DataPropertyName = "IngredientID";
            this.dgUnitComlumn.DataSource = this.IngredientBindingSource;
            this.dgUnitComlumn.DisplayMember = "Unit";
            this.dgUnitComlumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dgUnitComlumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgUnitComlumn.HeaderText = "";
            this.dgUnitComlumn.MaxDropDownItems = 16;
            this.dgUnitComlumn.Name = "dgUnitComlumn";
            this.dgUnitComlumn.ReadOnly = true;
            this.dgUnitComlumn.ValueMember = "IngredientID";
            this.dgUnitComlumn.Width = 40;
            // 
            // dgCostColumn
            // 
            this.dgCostColumn.DataPropertyName = "Cost";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.dgCostColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgCostColumn.HeaderText = "小計";
            this.dgCostColumn.Name = "dgCostColumn";
            this.dgCostColumn.Width = 80;
            // 
            // columnTitleCode
            // 
            this.columnTitleCode.DataPropertyName = "TitleCode";
            this.columnTitleCode.DataSource = this.accountingTitleBindingSource;
            this.columnTitleCode.DisplayMember = "Name";
            this.columnTitleCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.columnTitleCode.HeaderText = "會計科目";
            this.columnTitleCode.MaxDropDownItems = 16;
            this.columnTitleCode.Name = "columnTitleCode";
            this.columnTitleCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnTitleCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnTitleCode.ValueMember = "TitleCode";
            // 
            // voucherVoucherDetailSqlBindingSource
            // 
            this.voucherVoucherDetailSqlBindingSource.DataMember = "FK_Voucher_VoucherDetail";
            this.voucherVoucherDetailSqlBindingSource.DataSource = this.voucherBindingSource;
            // 
            // costTextBox
            // 
            this.costTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.costTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.voucherBindingSource, "Cost", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.costTextBox.Location = new System.Drawing.Point(747, 116);
            this.costTextBox.Name = "costTextBox";
            this.costTextBox.ReadOnly = true;
            this.costTextBox.Size = new System.Drawing.Size(94, 27);
            this.costTextBox.TabIndex = 51;
            this.costTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.costTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.costTextBox_Validating);
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.DropDownHeight = 216;
            this.comboBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.IntegralHeight = false;
            this.comboBoxMonth.Items.AddRange(new object[] {
            "",
            "一月",
            "二月",
            "三月",
            "四月",
            "五月",
            "六月",
            "七月",
            "八月",
            "九月",
            "十月",
            "十一月",
            "十二月"});
            this.comboBoxMonth.Location = new System.Drawing.Point(427, 3);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(86, 24);
            this.comboBoxMonth.TabIndex = 52;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // printDocument
            // 
            this.printDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_BeginPrint);
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // dgvVoucher
            // 
            this.dgvVoucher.AllowUserToAddRows = false;
            this.dgvVoucher.AllowUserToDeleteRows = false;
            this.dgvVoucher.AllowUserToOrderColumns = true;
            this.dgvVoucher.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Azure;
            this.dgvVoucher.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvVoucher.AutoGenerateColumns = false;
            this.dgvVoucher.BackgroundColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVoucher.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVoucher.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnRemoved,
            this.columnID,
            this.VoucherID,
            this.StockTime,
            this.dataGridViewTextBoxColumn4,
            this.columnCost,
            this.columnCheck});
            this.dgvVoucher.DataSource = this.voucherBindingSource;
            this.dgvVoucher.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvVoucher.EnableHeadersVisualStyles = false;
            this.dgvVoucher.Location = new System.Drawing.Point(0, 0);
            this.dgvVoucher.Name = "dgvVoucher";
            this.dgvVoucher.RowHeadersVisible = false;
            this.dgvVoucher.RowHeadersWidth = 25;
            this.dgvVoucher.RowTemplate.Height = 24;
            this.dgvVoucher.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVoucher.Size = new System.Drawing.Size(403, 670);
            this.dgvVoucher.TabIndex = 1;
            this.dgvVoucher.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.voucherDataGridView_CellValueChanged);
            this.dgvVoucher.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.voucherDataGridView_DataError);
            this.dgvVoucher.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.voucherDataGridView_RowPrePaint);
            this.dgvVoucher.SelectionChanged += new System.EventHandler(this.voucherDataGridView_SelectionChanged);
            // 
            // columnRemoved
            // 
            this.columnRemoved.DataPropertyName = "Removed";
            this.columnRemoved.HeaderText = "";
            this.columnRemoved.MinimumWidth = 2;
            this.columnRemoved.Name = "columnRemoved";
            this.columnRemoved.ReadOnly = true;
            this.columnRemoved.Width = 2;
            // 
            // columnID
            // 
            this.columnID.DataPropertyName = "ID";
            this.columnID.HeaderText = "順序";
            this.columnID.Name = "columnID";
            this.columnID.ReadOnly = true;
            this.columnID.Width = 48;
            // 
            // VoucherID
            // 
            this.VoucherID.DataPropertyName = "VoucherID";
            this.VoucherID.HeaderText = "憑証号";
            this.VoucherID.Name = "VoucherID";
            this.VoucherID.ReadOnly = true;
            this.VoucherID.Width = 75;
            // 
            // StockTime
            // 
            this.StockTime.DataPropertyName = "StockTime";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "M/dd";
            this.StockTime.DefaultCellStyle = dataGridViewCellStyle6;
            this.StockTime.HeaderText = "時間";
            this.StockTime.Name = "StockTime";
            this.StockTime.ReadOnly = true;
            this.StockTime.Width = 48;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "VendorID";
            this.dataGridViewTextBoxColumn4.DataSource = this.venderBindingSource;
            this.dataGridViewTextBoxColumn4.DisplayMember = "Name";
            this.dataGridViewTextBoxColumn4.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewTextBoxColumn4.HeaderText = "供應商";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn4.ValueMember = "VendorID";
            this.dataGridViewTextBoxColumn4.Width = 110;
            // 
            // columnCost
            // 
            this.columnCost.DataPropertyName = "Cost";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N1";
            dataGridViewCellStyle7.NullValue = null;
            this.columnCost.DefaultCellStyle = dataGridViewCellStyle7;
            this.columnCost.HeaderText = "總計";
            this.columnCost.Name = "columnCost";
            this.columnCost.ReadOnly = true;
            this.columnCost.Width = 70;
            // 
            // columnCheck
            // 
            this.columnCheck.DataPropertyName = "Locked";
            this.columnCheck.HeaderText = "核";
            this.columnCheck.Name = "columnCheck";
            this.columnCheck.ReadOnly = true;
            this.columnCheck.Width = 25;
            // 
            // ckBoxAllowEdit
            // 
            this.ckBoxAllowEdit.AutoSize = true;
            this.ckBoxAllowEdit.Location = new System.Drawing.Point(532, 7);
            this.ckBoxAllowEdit.Name = "ckBoxAllowEdit";
            this.ckBoxAllowEdit.Size = new System.Drawing.Size(59, 20);
            this.ckBoxAllowEdit.TabIndex = 53;
            this.ckBoxAllowEdit.Text = "編修";
            this.ckBoxAllowEdit.UseVisualStyleBackColor = true;
            this.ckBoxAllowEdit.Visible = false;
            this.ckBoxAllowEdit.CheckedChanged += new System.EventHandler(this.ckBoxAllowEdit_CheckedChanged);
            // 
            // cbBoxIngredientSelector
            // 
            this.cbBoxIngredientSelector.BackColor = System.Drawing.SystemColors.Window;
            this.cbBoxIngredientSelector.DataSource = this.titleCodeBindingSource;
            this.cbBoxIngredientSelector.DisplayMember = "Name";
            this.cbBoxIngredientSelector.DropDownHeight = 300;
            this.cbBoxIngredientSelector.FormattingEnabled = true;
            this.cbBoxIngredientSelector.IntegralHeight = false;
            this.cbBoxIngredientSelector.Location = new System.Drawing.Point(512, 116);
            this.cbBoxIngredientSelector.Name = "cbBoxIngredientSelector";
            this.cbBoxIngredientSelector.Size = new System.Drawing.Size(145, 24);
            this.cbBoxIngredientSelector.TabIndex = 55;
            this.cbBoxIngredientSelector.ValueMember = "Code";
            this.cbBoxIngredientSelector.SelectedIndexChanged += new System.EventHandler(this.cbBoxIngredientSelector_SelectedIndexChanged);
            // 
            // titleCodeBindingSource
            // 
            this.titleCodeBindingSource.DataSource = typeof(VoucherExpense.Voucher.TitleCode);
            // 
            // keyinIDComboBox
            // 
            this.keyinIDComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.keyinIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.voucherBindingSource, "KeyinID", true));
            this.keyinIDComboBox.DataSource = this.operatorBindingSource;
            this.keyinIDComboBox.DisplayMember = "Name";
            this.keyinIDComboBox.DropDownHeight = 1;
            this.keyinIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.keyinIDComboBox.Enabled = false;
            this.keyinIDComboBox.FormattingEnabled = true;
            this.keyinIDComboBox.IntegralHeight = false;
            this.keyinIDComboBox.Location = new System.Drawing.Point(512, 620);
            this.keyinIDComboBox.Name = "keyinIDComboBox";
            this.keyinIDComboBox.Size = new System.Drawing.Size(145, 24);
            this.keyinIDComboBox.TabIndex = 47;
            this.keyinIDComboBox.ValueMember = "OperatorID";
            // 
            // entryTimeTextBox
            // 
            this.entryTimeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.entryTimeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.entryTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.entryTimeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.voucherBindingSource, "EntryTime", true));
            this.entryTimeTextBox.Location = new System.Drawing.Point(511, 594);
            this.entryTimeTextBox.Name = "entryTimeTextBox";
            this.entryTimeTextBox.ReadOnly = true;
            this.entryTimeTextBox.Size = new System.Drawing.Size(151, 20);
            this.entryTimeTextBox.TabIndex = 32;
            // 
            // lastUpdatedTextBox
            // 
            this.lastUpdatedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lastUpdatedTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.lastUpdatedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastUpdatedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.voucherBindingSource, "LastUpdated", true));
            this.lastUpdatedTextBox.Location = new System.Drawing.Point(751, 622);
            this.lastUpdatedTextBox.Name = "lastUpdatedTextBox";
            this.lastUpdatedTextBox.ReadOnly = true;
            this.lastUpdatedTextBox.Size = new System.Drawing.Size(152, 20);
            this.lastUpdatedTextBox.TabIndex = 30;
            // 
            // removedCheckBox
            // 
            this.removedCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.voucherBindingSource, "Removed", true));
            this.removedCheckBox.Location = new System.Drawing.Point(512, 560);
            this.removedCheckBox.Name = "removedCheckBox";
            this.removedCheckBox.Size = new System.Drawing.Size(27, 27);
            this.removedCheckBox.TabIndex = 25;
            // 
            // lockedCheckBox
            // 
            this.lockedCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lockedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.voucherBindingSource, "Locked", true));
            this.lockedCheckBox.Enabled = false;
            this.lockedCheckBox.Location = new System.Drawing.Point(747, 560);
            this.lockedCheckBox.Name = "lockedCheckBox";
            this.lockedCheckBox.Size = new System.Drawing.Size(27, 27);
            this.lockedCheckBox.TabIndex = 27;
            this.lockedCheckBox.CheckedChanged += new System.EventHandler(this.lockedCheckBox_CheckedChanged);
            // 
            // Voucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(961, 670);
            this.Controls.Add(lockedLabel);
            this.Controls.Add(lastUpdatedLabel);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lockedCheckBox);
            this.Controls.Add(this.removedCheckBox);
            this.Controls.Add(this.cbBoxIngredientSelector);
            this.Controls.Add(removedLabel);
            this.Controls.Add(label1);
            this.Controls.Add(keyinIDLabel);
            this.Controls.Add(this.ckBoxAllowEdit);
            this.Controls.Add(entryTimeLabel);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.lastUpdatedTextBox);
            this.Controls.Add(costLabel);
            this.Controls.Add(this.entryTimeTextBox);
            this.Controls.Add(this.costTextBox);
            this.Controls.Add(this.keyinIDComboBox);
            this.Controls.Add(this.stockTimeTextBox);
            this.Controls.Add(this.vendorIDComboBox);
            this.Controls.Add(this.voucherIDTextBox);
            this.Controls.Add(iDLabel);
            this.Controls.Add(this.iDTextBox);
            this.Controls.Add(voucherIDLabel);
            this.Controls.Add(vendorIDLabel);
            this.Controls.Add(stockTimeLabel);
            this.Controls.Add(this.dgvVoucher);
            this.Controls.Add(this.voucherBindingNavigator);
            this.Controls.Add(this.dgvVoucherDetail);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Voucher";
            this.Text = "進貨";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Voucher_FormClosing);
            this.Load += new System.EventHandler(this.Voucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.voucherBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.voucherBindingNavigator)).EndInit();
            this.voucherBindingNavigator.ResumeLayout(false);
            this.voucherBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.venderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.venderFilterSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucherDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.voucherVoucherDetailSqlBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleCodeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource voucherBindingSource;
        private System.Windows.Forms.BindingNavigator voucherBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton voucherBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox iDTextBox;
        private System.Windows.Forms.TextBox voucherIDTextBox;
        private System.Windows.Forms.BindingSource venderBindingSource;
        private System.Windows.Forms.BindingSource accountingTitleBindingSource;
        private System.Windows.Forms.BindingSource IngredientBindingSource;
        private System.Windows.Forms.ComboBox vendorIDComboBox;
        private System.Windows.Forms.BindingSource operatorBindingSource;
        private System.Windows.Forms.TextBox stockTimeTextBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dgvVoucherDetail;
        private System.Windows.Forms.TextBox costTextBox;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.ToolStripButton 列印PToolStripButton;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.BindingSource venderFilterSource;
        private System.Windows.Forms.DataGridView dgvVoucher;
        private System.Windows.Forms.CheckBox ckBoxAllowEdit;
        private System.Windows.Forms.ComboBox cbBoxIngredientSelector;
        private System.Windows.Forms.BindingSource titleCodeBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnRemoved;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn VoucherID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockTime;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCost;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnCheck;
        private System.Windows.Forms.ComboBox keyinIDComboBox;
        private System.Windows.Forms.TextBox entryTimeTextBox;
        private System.Windows.Forms.TextBox lastUpdatedTextBox;
        private System.Windows.Forms.CheckBox removedCheckBox;
        private System.Windows.Forms.CheckBox lockedCheckBox;
        private DamaiDataSet damaiDataSet;
        private System.Windows.Forms.BindingSource voucherVoucherDetailSqlBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn detailColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnVoID;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgIngredientIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVolumeColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgUnitComlumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCostColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn columnTitleCode;
    }
}