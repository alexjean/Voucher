namespace VoucherExpense
{
    partial class FormCashierAuthen
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label labelTime;
            System.Windows.Forms.Label label4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCashierAuthen));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bakeryOrderSet = new VoucherExpense.BakeryOrderSet();
            this.cashierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cashierTableAdapter = new VoucherExpense.BakeryOrderSetTableAdapters.CashierTableAdapter();
            this.cashierBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.cashierBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.cashierDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CashierIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PasswordColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.operatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operatorTableAdapter = new VoucherExpense.VEDataSetTableAdapters.OperatorTableAdapter();
            this.chBoxOnlyInPosition = new System.Windows.Forms.CheckBox();
            this.listBoxReadme = new System.Windows.Forms.ListBox();
            this.textBoxPOS1 = new System.Windows.Forms.TextBox();
            this.textBoxPOS2 = new System.Windows.Forms.TextBox();
            this.textBoxPOS3 = new System.Windows.Forms.TextBox();
            this.btnBrowse1 = new System.Windows.Forms.Button();
            this.btnBrowse2 = new System.Windows.Forms.Button();
            this.btnBrowse3 = new System.Windows.Forms.Button();
            this.btnConfigSave = new System.Windows.Forms.Button();
            this.btnGetDataFromPOS = new System.Windows.Forms.Button();
            this.btnClosedBackup = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.todayPicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBackupDir = new System.Windows.Forms.Button();
            this.textBoxBackupDir = new System.Windows.Forms.TextBox();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.productTableAdapter = new VoucherExpense.BakeryOrderSetTableAdapters.ProductTableAdapter();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            labelTime = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashierBindingNavigator)).BeginInit();
            this.cashierBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cashierDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(133, 21);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(136, 16);
            label1.TabIndex = 7;
            label1.Text = "收銀机 1 網路位置";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(133, 82);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(136, 16);
            label2.TabIndex = 8;
            label2.Text = "收銀机 2 網路位置";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(133, 143);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(136, 16);
            label3.TabIndex = 9;
            label3.Text = "收銀机 3 網路位置";
            // 
            // labelTime
            // 
            labelTime.Location = new System.Drawing.Point(665, 645);
            labelTime.Name = "labelTime";
            labelTime.Size = new System.Drawing.Size(56, 30);
            labelTime.TabIndex = 15;
            labelTime.Text = "今日是";
            labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(133, 204);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(140, 16);
            label4.TabIndex = 15;
            label4.Text = "備份資料 網路位置";
            // 
            // bakeryOrderSet
            // 
            this.bakeryOrderSet.DataSetName = "BakeryOrderSet";
            this.bakeryOrderSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cashierBindingSource
            // 
            this.cashierBindingSource.DataMember = "Cashier";
            this.cashierBindingSource.DataSource = this.bakeryOrderSet;
            // 
            // cashierTableAdapter
            // 
            this.cashierTableAdapter.ClearBeforeFill = true;
            // 
            // cashierBindingNavigator
            // 
            this.cashierBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.cashierBindingNavigator.BackgroundImage = global::VoucherExpense.Properties.Resources.NavBar_Back;
            this.cashierBindingNavigator.BindingSource = this.cashierBindingSource;
            this.cashierBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.cashierBindingNavigator.DeleteItem = null;
            this.cashierBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.cashierBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.cashierBindingNavigatorSaveItem});
            this.cashierBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.cashierBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.cashierBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.cashierBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.cashierBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.cashierBindingNavigator.Name = "cashierBindingNavigator";
            this.cashierBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.cashierBindingNavigator.Size = new System.Drawing.Size(249, 25);
            this.cashierBindingNavigator.TabIndex = 0;
            this.cashierBindingNavigator.Text = "bindingNavigator1";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(29, 22);
            this.bindingNavigatorCountItem.Text = "/{0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目總數";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "移到最前面";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一個";
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
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "移到下一個";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "移到最後面";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // cashierBindingNavigatorSaveItem
            // 
            this.cashierBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cashierBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("cashierBindingNavigatorSaveItem.Image")));
            this.cashierBindingNavigatorSaveItem.Name = "cashierBindingNavigatorSaveItem";
            this.cashierBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.cashierBindingNavigatorSaveItem.Text = "儲存資料";
            this.cashierBindingNavigatorSaveItem.Click += new System.EventHandler(this.cashierBindingNavigatorSaveItem_Click);
            // 
            // cashierDataGridView
            // 
            this.cashierDataGridView.AllowUserToAddRows = false;
            this.cashierDataGridView.AllowUserToDeleteRows = false;
            this.cashierDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cashierDataGridView.AutoGenerateColumns = false;
            this.cashierDataGridView.BackgroundColor = System.Drawing.Color.SeaShell;
            this.cashierDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cashierDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.CashierIDColumn,
            this.dataGridViewTextBoxColumn2,
            this.PasswordColumn,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.cashierDataGridView.DataSource = this.cashierBindingSource;
            this.cashierDataGridView.Location = new System.Drawing.Point(0, 28);
            this.cashierDataGridView.Name = "cashierDataGridView";
            this.cashierDataGridView.RowHeadersVisible = false;
            this.cashierDataGridView.RowTemplate.Height = 24;
            this.cashierDataGridView.Size = new System.Drawing.Size(474, 644);
            this.cashierDataGridView.TabIndex = 1;
            this.cashierDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.cashierDataGridView_CellFormatting);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "InPosition";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.NullValue = false;
            this.dataGridViewCheckBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCheckBoxColumn1.HeaderText = "在職";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 48;
            // 
            // CashierIDColumn
            // 
            this.CashierIDColumn.DataPropertyName = "CashierID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CashierIDColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.CashierIDColumn.HeaderText = "編号";
            this.CashierIDColumn.Name = "CashierIDColumn";
            this.CashierIDColumn.ReadOnly = true;
            this.CashierIDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CashierIDColumn.Width = 64;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CashierName";
            this.dataGridViewTextBoxColumn2.HeaderText = "姓名";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 10;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // PasswordColumn
            // 
            this.PasswordColumn.DataPropertyName = "CashierPassword";
            this.PasswordColumn.HeaderText = "密碼";
            this.PasswordColumn.MaxInputLength = 6;
            this.PasswordColumn.Name = "PasswordColumn";
            this.PasswordColumn.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "AuthenID";
            this.dataGridViewTextBoxColumn4.DataSource = this.operatorBindingSource;
            this.dataGridViewTextBoxColumn4.DisplayMember = "Name";
            this.dataGridViewTextBoxColumn4.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewTextBoxColumn4.HeaderText = "授權者";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn4.ValueMember = "OperatorID";
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // operatorBindingSource
            // 
            this.operatorBindingSource.DataMember = "Operator";
            this.operatorBindingSource.DataSource = this.vEDataSet;
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "LastUpdated";
            dataGridViewCellStyle3.Format = "MM-dd hh:mm";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn5.HeaderText = "更新時間";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // operatorTableAdapter
            // 
            this.operatorTableAdapter.ClearBeforeFill = true;
            // 
            // chBoxOnlyInPosition
            // 
            this.chBoxOnlyInPosition.AutoSize = true;
            this.chBoxOnlyInPosition.Checked = true;
            this.chBoxOnlyInPosition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBoxOnlyInPosition.Location = new System.Drawing.Point(266, 5);
            this.chBoxOnlyInPosition.Name = "chBoxOnlyInPosition";
            this.chBoxOnlyInPosition.Size = new System.Drawing.Size(123, 20);
            this.chBoxOnlyInPosition.TabIndex = 2;
            this.chBoxOnlyInPosition.Text = "只顯示在職者";
            this.chBoxOnlyInPosition.UseVisualStyleBackColor = true;
            this.chBoxOnlyInPosition.CheckedChanged += new System.EventHandler(this.chBoxOnlyInPosition_CheckedChanged);
            // 
            // listBoxReadme
            // 
            this.listBoxReadme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.listBoxReadme.FormattingEnabled = true;
            this.listBoxReadme.ItemHeight = 16;
            this.listBoxReadme.Items.AddRange(new object[] {
            "",
            " \t為保持資料一致性,故不提供刪除",
            "",
            " \t收銀員離職後,應將在職勾選取消",
            "",
            " \t新收銀員應使用新編號",
            "",
            " \t不可重複使用同一編号",
            "",
            " \t收銀台密碼只能輸入數字",
            "",
            " \t年度開帳全部授權消除,需重新授權"});
            this.listBoxReadme.Location = new System.Drawing.Point(494, 28);
            this.listBoxReadme.Name = "listBoxReadme";
            this.listBoxReadme.Size = new System.Drawing.Size(447, 276);
            this.listBoxReadme.TabIndex = 3;
            // 
            // textBoxPOS1
            // 
            this.textBoxPOS1.Location = new System.Drawing.Point(14, 45);
            this.textBoxPOS1.Name = "textBoxPOS1";
            this.textBoxPOS1.Size = new System.Drawing.Size(447, 27);
            this.textBoxPOS1.TabIndex = 4;
            // 
            // textBoxPOS2
            // 
            this.textBoxPOS2.Location = new System.Drawing.Point(14, 104);
            this.textBoxPOS2.Name = "textBoxPOS2";
            this.textBoxPOS2.Size = new System.Drawing.Size(447, 27);
            this.textBoxPOS2.TabIndex = 5;
            // 
            // textBoxPOS3
            // 
            this.textBoxPOS3.Location = new System.Drawing.Point(14, 165);
            this.textBoxPOS3.Name = "textBoxPOS3";
            this.textBoxPOS3.Size = new System.Drawing.Size(447, 27);
            this.textBoxPOS3.TabIndex = 6;
            // 
            // btnBrowse1
            // 
            this.btnBrowse1.AutoSize = true;
            this.btnBrowse1.Location = new System.Drawing.Point(275, 16);
            this.btnBrowse1.Name = "btnBrowse1";
            this.btnBrowse1.Size = new System.Drawing.Size(75, 26);
            this.btnBrowse1.TabIndex = 10;
            this.btnBrowse1.Text = "瀏覽";
            this.btnBrowse1.UseVisualStyleBackColor = true;
            this.btnBrowse1.Click += new System.EventHandler(this.btnBrowse1_Click);
            // 
            // btnBrowse2
            // 
            this.btnBrowse2.AutoSize = true;
            this.btnBrowse2.Location = new System.Drawing.Point(275, 78);
            this.btnBrowse2.Name = "btnBrowse2";
            this.btnBrowse2.Size = new System.Drawing.Size(75, 26);
            this.btnBrowse2.TabIndex = 11;
            this.btnBrowse2.Text = "瀏覽";
            this.btnBrowse2.UseVisualStyleBackColor = true;
            this.btnBrowse2.Click += new System.EventHandler(this.btnBrowse2_Click);
            // 
            // btnBrowse3
            // 
            this.btnBrowse3.AutoSize = true;
            this.btnBrowse3.Location = new System.Drawing.Point(275, 138);
            this.btnBrowse3.Name = "btnBrowse3";
            this.btnBrowse3.Size = new System.Drawing.Size(75, 26);
            this.btnBrowse3.TabIndex = 12;
            this.btnBrowse3.Text = "瀏覽";
            this.btnBrowse3.UseVisualStyleBackColor = true;
            this.btnBrowse3.Click += new System.EventHandler(this.btnBrowse3_Click);
            // 
            // btnConfigSave
            // 
            this.btnConfigSave.AutoSize = true;
            this.btnConfigSave.Location = new System.Drawing.Point(14, 0);
            this.btnConfigSave.Name = "btnConfigSave";
            this.btnConfigSave.Size = new System.Drawing.Size(82, 26);
            this.btnConfigSave.TabIndex = 13;
            this.btnConfigSave.Text = "設定存檔";
            this.btnConfigSave.UseVisualStyleBackColor = true;
            this.btnConfigSave.Click += new System.EventHandler(this.btnConfigSave_Click);
            // 
            // btnGetDataFromPOS
            // 
            this.btnGetDataFromPOS.Location = new System.Drawing.Point(494, 589);
            this.btnGetDataFromPOS.Name = "btnGetDataFromPOS";
            this.btnGetDataFromPOS.Size = new System.Drawing.Size(162, 40);
            this.btnGetDataFromPOS.TabIndex = 14;
            this.btnGetDataFromPOS.Text = "收取收銀机今日資料";
            this.btnGetDataFromPOS.UseVisualStyleBackColor = true;
            this.btnGetDataFromPOS.Click += new System.EventHandler(this.btnGetDataFromPOS_Click);
            // 
            // btnClosedBackup
            // 
            this.btnClosedBackup.Location = new System.Drawing.Point(494, 632);
            this.btnClosedBackup.Name = "btnClosedBackup";
            this.btnClosedBackup.Size = new System.Drawing.Size(162, 40);
            this.btnClosedBackup.TabIndex = 16;
            this.btnClosedBackup.Text = "封印及備份";
            this.btnClosedBackup.UseVisualStyleBackColor = true;
            this.btnClosedBackup.Click += new System.EventHandler(this.btnClosedBackup_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // todayPicker
            // 
            this.todayPicker.Location = new System.Drawing.Point(722, 645);
            this.todayPicker.Name = "todayPicker";
            this.todayPicker.Size = new System.Drawing.Size(146, 27);
            this.todayPicker.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBackupDir);
            this.groupBox1.Controls.Add(label4);
            this.groupBox1.Controls.Add(this.textBoxBackupDir);
            this.groupBox1.Controls.Add(this.btnBrowse1);
            this.groupBox1.Controls.Add(this.textBoxPOS1);
            this.groupBox1.Controls.Add(this.textBoxPOS2);
            this.groupBox1.Controls.Add(this.textBoxPOS3);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(this.btnConfigSave);
            this.groupBox1.Controls.Add(label2);
            this.groupBox1.Controls.Add(this.btnBrowse3);
            this.groupBox1.Controls.Add(label3);
            this.groupBox1.Controls.Add(this.btnBrowse2);
            this.groupBox1.Location = new System.Drawing.Point(480, 319);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 264);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // btnBackupDir
            // 
            this.btnBackupDir.AutoSize = true;
            this.btnBackupDir.Location = new System.Drawing.Point(275, 199);
            this.btnBackupDir.Name = "btnBackupDir";
            this.btnBackupDir.Size = new System.Drawing.Size(75, 26);
            this.btnBackupDir.TabIndex = 16;
            this.btnBackupDir.Text = "瀏覽";
            this.btnBackupDir.UseVisualStyleBackColor = true;
            this.btnBackupDir.Click += new System.EventHandler(this.btnBackupDir_Click);
            // 
            // textBoxBackupDir
            // 
            this.textBoxBackupDir.Location = new System.Drawing.Point(14, 229);
            this.textBoxBackupDir.Name = "textBoxBackupDir";
            this.textBoxBackupDir.Size = new System.Drawing.Size(447, 27);
            this.textBoxBackupDir.TabIndex = 14;
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Location = new System.Drawing.Point(722, 589);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(162, 40);
            this.btnUpdateProduct.TabIndex = 19;
            this.btnUpdateProduct.Text = "更新收銀机產品表";
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // FormCashierAuthen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(953, 672);
            this.Controls.Add(this.btnUpdateProduct);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.todayPicker);
            this.Controls.Add(this.btnClosedBackup);
            this.Controls.Add(labelTime);
            this.Controls.Add(this.btnGetDataFromPOS);
            this.Controls.Add(this.listBoxReadme);
            this.Controls.Add(this.chBoxOnlyInPosition);
            this.Controls.Add(this.cashierDataGridView);
            this.Controls.Add(this.cashierBindingNavigator);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormCashierAuthen";
            this.Text = "收銀授權";
            this.Load += new System.EventHandler(this.FormCashierAuthen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashierBindingNavigator)).EndInit();
            this.cashierBindingNavigator.ResumeLayout(false);
            this.cashierBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cashierDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BakeryOrderSet bakeryOrderSet;
        private System.Windows.Forms.BindingSource cashierBindingSource;
        private BakeryOrderSetTableAdapters.CashierTableAdapter cashierTableAdapter;
        private System.Windows.Forms.BindingNavigator cashierBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton cashierBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView cashierDataGridView;
        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource operatorBindingSource;
        private VEDataSetTableAdapters.OperatorTableAdapter operatorTableAdapter;
        private System.Windows.Forms.CheckBox chBoxOnlyInPosition;
        private System.Windows.Forms.ListBox listBoxReadme;
        private System.Windows.Forms.TextBox textBoxPOS1;
        private System.Windows.Forms.TextBox textBoxPOS2;
        private System.Windows.Forms.TextBox textBoxPOS3;
        private System.Windows.Forms.Button btnBrowse1;
        private System.Windows.Forms.Button btnBrowse2;
        private System.Windows.Forms.Button btnBrowse3;
        private System.Windows.Forms.Button btnConfigSave;
        private System.Windows.Forms.Button btnGetDataFromPOS;
        private System.Windows.Forms.Button btnClosedBackup;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashierIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PasswordColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DateTimePicker todayPicker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBackupDir;
        private System.Windows.Forms.TextBox textBoxBackupDir;
        private System.Windows.Forms.Button btnUpdateProduct;
        private BakeryOrderSetTableAdapters.ProductTableAdapter productTableAdapter;
    }
}