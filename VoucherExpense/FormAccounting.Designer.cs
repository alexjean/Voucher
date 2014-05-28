namespace VoucherExpense
{
    partial class FormAccounting
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
            System.Windows.Forms.Label applierIDLabel;
            System.Windows.Forms.Label noteLabel;
            System.Windows.Forms.Label authorizeIDLabel;
            System.Windows.Forms.Label lastUpdatedLabel1;
            System.Windows.Forms.Label lockedLabel;
            System.Windows.Forms.Label keyinIDLabel;
            System.Windows.Forms.Label indentureIDLabel;
            System.Windows.Forms.Label removedLabel;
            System.Windows.Forms.Label accVoucherTimeLabel;
            System.Windows.Forms.TextBox accVoucherIDTextBox;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAccounting));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.accVoucherBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.damaiDataSet = new VoucherExpense.DamaiDataSet();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ckBoxAllowEdit = new System.Windows.Forms.CheckBox();
            this.authorizeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.operatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accTitleDGVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.accVoucherIDLabel = new System.Windows.Forms.Label();
            this.accVoucherBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.accVoucherBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.applierIDComboBox = new System.Windows.Forms.ComboBox();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.authorizeIDComboBox = new System.Windows.Forms.ComboBox();
            this.lastUpdatedLabel = new System.Windows.Forms.Label();
            this.lockedCheckBox = new System.Windows.Forms.CheckBox();
            this.removedCheckBox = new System.Windows.Forms.CheckBox();
            this.indentureIDTextBox = new System.Windows.Forms.TextBox();
            this.keyinIDComboBox = new System.Windows.Forms.ComboBox();
            this.iDTextBox = new System.Windows.Forms.TextBox();
            this.accVoucherDataGridView = new System.Windows.Forms.DataGridView();
            this.accVoucherTimeTextBox = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabVoucher = new System.Windows.Forms.TabPage();
            this.tabExpense = new System.Windows.Forms.TabPage();
            this.tabRevenue = new System.Windows.Forms.TabPage();
            this.tabShipment = new System.Windows.Forms.TabPage();
            this.tabBank = new System.Windows.Forms.TabPage();
            this.tabSalary = new System.Windows.Forms.TabPage();
            this.accVoucherTableAdapter = new VoucherExpense.DamaiDataSetTableAdapters.AccVoucherTableAdapter();
            this.accountingTitleTableAdapter = new VoucherExpense.DamaiDataSetTableAdapters.AccountingTitleTableAdapter();
            this.hRTableAdapter = new VoucherExpense.DamaiDataSetTableAdapters.HRTableAdapter();
            this.operatorTableAdapter = new VoucherExpense.DamaiDataSetTableAdapters.OperatorTableAdapter();
            this.accVoucherDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accVoucherDetailTableAdapter = new VoucherExpense.DamaiDataSetTableAdapters.AccVoucherDetailTableAdapter();
            this.tableAdapterManager = new VoucherExpense.DamaiDataSetTableAdapters.TableAdapterManager();
            this.accVoucherDetailDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accVoucherIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accVoucherTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.removedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lockedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            label1 = new System.Windows.Forms.Label();
            applierIDLabel = new System.Windows.Forms.Label();
            noteLabel = new System.Windows.Forms.Label();
            authorizeIDLabel = new System.Windows.Forms.Label();
            lastUpdatedLabel1 = new System.Windows.Forms.Label();
            lockedLabel = new System.Windows.Forms.Label();
            keyinIDLabel = new System.Windows.Forms.Label();
            indentureIDLabel = new System.Windows.Forms.Label();
            removedLabel = new System.Windows.Forms.Label();
            accVoucherTimeLabel = new System.Windows.Forms.Label();
            accVoucherIDTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.accVoucherBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorizeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accTitleDGVBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accVoucherBindingNavigator)).BeginInit();
            this.accVoucherBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accVoucherDataGridView)).BeginInit();
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accVoucherDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accVoucherDetailDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(424, 44);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 16);
            label1.TabIndex = 91;
            label1.Text = "單号:";
            // 
            // applierIDLabel
            // 
            applierIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            applierIDLabel.AutoSize = true;
            applierIDLabel.Location = new System.Drawing.Point(445, 515);
            applierIDLabel.Name = "applierIDLabel";
            applierIDLabel.Size = new System.Drawing.Size(44, 16);
            applierIDLabel.TabIndex = 90;
            applierIDLabel.Text = "製單:";
            // 
            // noteLabel
            // 
            noteLabel.AutoSize = true;
            noteLabel.Location = new System.Drawing.Point(432, 159);
            noteLabel.Name = "noteLabel";
            noteLabel.Size = new System.Drawing.Size(42, 16);
            noteLabel.TabIndex = 89;
            noteLabel.Text = "Note:";
            // 
            // authorizeIDLabel
            // 
            authorizeIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            authorizeIDLabel.AutoSize = true;
            authorizeIDLabel.Location = new System.Drawing.Point(610, 515);
            authorizeIDLabel.Name = "authorizeIDLabel";
            authorizeIDLabel.Size = new System.Drawing.Size(44, 16);
            authorizeIDLabel.TabIndex = 87;
            authorizeIDLabel.Text = "核准:";
            // 
            // lastUpdatedLabel1
            // 
            lastUpdatedLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            lastUpdatedLabel1.AutoSize = true;
            lastUpdatedLabel1.Location = new System.Drawing.Point(439, 591);
            lastUpdatedLabel1.Name = "lastUpdatedLabel1";
            lastUpdatedLabel1.Size = new System.Drawing.Size(60, 16);
            lastUpdatedLabel1.TabIndex = 86;
            lastUpdatedLabel1.Text = "更新日:";
            // 
            // lockedLabel
            // 
            lockedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            lockedLabel.AutoSize = true;
            lockedLabel.Location = new System.Drawing.Point(528, 553);
            lockedLabel.Name = "lockedLabel";
            lockedLabel.Size = new System.Drawing.Size(44, 16);
            lockedLabel.TabIndex = 84;
            lockedLabel.Text = "複核:";
            // 
            // keyinIDLabel
            // 
            keyinIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            keyinIDLabel.AutoSize = true;
            keyinIDLabel.Location = new System.Drawing.Point(613, 553);
            keyinIDLabel.Name = "keyinIDLabel";
            keyinIDLabel.Size = new System.Drawing.Size(44, 16);
            keyinIDLabel.TabIndex = 80;
            keyinIDLabel.Text = "輸入:";
            // 
            // indentureIDLabel
            // 
            indentureIDLabel.AutoSize = true;
            indentureIDLabel.Location = new System.Drawing.Point(596, 79);
            indentureIDLabel.Name = "indentureIDLabel";
            indentureIDLabel.Size = new System.Drawing.Size(60, 16);
            indentureIDLabel.TabIndex = 79;
            indentureIDLabel.Text = "憑証号:";
            // 
            // removedLabel
            // 
            removedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            removedLabel.AutoSize = true;
            removedLabel.Location = new System.Drawing.Point(445, 553);
            removedLabel.Name = "removedLabel";
            removedLabel.Size = new System.Drawing.Size(44, 16);
            removedLabel.TabIndex = 82;
            removedLabel.Text = "作癈:";
            // 
            // accVoucherTimeLabel
            // 
            accVoucherTimeLabel.AutoSize = true;
            accVoucherTimeLabel.Location = new System.Drawing.Point(428, 119);
            accVoucherTimeLabel.Name = "accVoucherTimeLabel";
            accVoucherTimeLabel.Size = new System.Drawing.Size(44, 16);
            accVoucherTimeLabel.TabIndex = 76;
            accVoucherTimeLabel.Text = "日期:";
            // 
            // accVoucherIDTextBox
            // 
            accVoucherIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.accVoucherBindingSource, "AccVoucherID", true));
            accVoucherIDTextBox.Location = new System.Drawing.Point(490, 74);
            accVoucherIDTextBox.Name = "accVoucherIDTextBox";
            accVoucherIDTextBox.Size = new System.Drawing.Size(100, 27);
            accVoucherIDTextBox.TabIndex = 68;
            // 
            // accVoucherBindingSource
            // 
            this.accVoucherBindingSource.DataMember = "AccVoucher";
            this.accVoucherBindingSource.DataSource = this.damaiDataSet;
            // 
            // damaiDataSet
            // 
            this.damaiDataSet.DataSetName = "DamaiDataSet";
            this.damaiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataMember = "HR";
            this.employeeBindingSource.DataSource = this.damaiDataSet;
            this.employeeBindingSource.Filter = "IsApplier";
            // 
            // ckBoxAllowEdit
            // 
            this.ckBoxAllowEdit.AutoSize = true;
            this.ckBoxAllowEdit.Location = new System.Drawing.Point(660, 44);
            this.ckBoxAllowEdit.Name = "ckBoxAllowEdit";
            this.ckBoxAllowEdit.Size = new System.Drawing.Size(59, 20);
            this.ckBoxAllowEdit.TabIndex = 94;
            this.ckBoxAllowEdit.Text = "編修";
            this.ckBoxAllowEdit.UseVisualStyleBackColor = true;
            this.ckBoxAllowEdit.Visible = false;
            // 
            // authorizeBindingSource
            // 
            this.authorizeBindingSource.DataMember = "HR";
            this.authorizeBindingSource.DataSource = this.damaiDataSet;
            this.authorizeBindingSource.Filter = "IsManager=true";
            // 
            // operatorBindingSource
            // 
            this.operatorBindingSource.DataMember = "Operator";
            this.operatorBindingSource.DataSource = this.damaiDataSet;
            // 
            // accTitleDGVBindingSource
            // 
            this.accTitleDGVBindingSource.DataMember = "AccountingTitle";
            this.accTitleDGVBindingSource.DataSource = this.damaiDataSet;
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.DropDownHeight = 216;
            this.comboBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.IntegralHeight = false;
            this.comboBoxMonth.Items.AddRange(new object[] {
            "全年",
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
            this.comboBoxMonth.Location = new System.Drawing.Point(424, 2);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(71, 24);
            this.comboBoxMonth.TabIndex = 93;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(587, 116);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(18, 27);
            this.dateTimePicker1.TabIndex = 92;
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
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "加入新的";
            // 
            // accVoucherIDLabel
            // 
            this.accVoucherIDLabel.AutoSize = true;
            this.accVoucherIDLabel.Location = new System.Drawing.Point(424, 79);
            this.accVoucherIDLabel.Name = "accVoucherIDLabel";
            this.accVoucherIDLabel.Size = new System.Drawing.Size(60, 16);
            this.accVoucherIDLabel.TabIndex = 73;
            this.accVoucherIDLabel.Text = "傳票号:";
            // 
            // accVoucherBindingNavigator
            // 
            this.accVoucherBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.accVoucherBindingNavigator.BindingSource = this.accVoucherBindingSource;
            this.accVoucherBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.accVoucherBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.accVoucherBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.accVoucherBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.accVoucherBindingNavigatorSaveItem});
            this.accVoucherBindingNavigator.Location = new System.Drawing.Point(506, 1);
            this.accVoucherBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.accVoucherBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.accVoucherBindingNavigator.MoveNextItem = null;
            this.accVoucherBindingNavigator.MovePreviousItem = null;
            this.accVoucherBindingNavigator.Name = "accVoucherBindingNavigator";
            this.accVoucherBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.accVoucherBindingNavigator.Size = new System.Drawing.Size(226, 25);
            this.accVoucherBindingNavigator.TabIndex = 67;
            this.accVoucherBindingNavigator.Text = "bindingNavigator1";
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
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Tahoma", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 22);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "目前的位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // accVoucherBindingNavigatorSaveItem
            // 
            this.accVoucherBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.accVoucherBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("accVoucherBindingNavigatorSaveItem.Image")));
            this.accVoucherBindingNavigatorSaveItem.Name = "accVoucherBindingNavigatorSaveItem";
            this.accVoucherBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.accVoucherBindingNavigatorSaveItem.Text = "儲存資料";
            // 
            // applierIDComboBox
            // 
            this.applierIDComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.applierIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.accVoucherBindingSource, "ApplierID", true));
            this.applierIDComboBox.DataSource = this.employeeBindingSource;
            this.applierIDComboBox.DisplayMember = "EmployeeName";
            this.applierIDComboBox.FormattingEnabled = true;
            this.applierIDComboBox.Location = new System.Drawing.Point(490, 512);
            this.applierIDComboBox.Name = "applierIDComboBox";
            this.applierIDComboBox.Size = new System.Drawing.Size(110, 24);
            this.applierIDComboBox.TabIndex = 75;
            this.applierIDComboBox.ValueMember = "EmployeeID";
            // 
            // noteTextBox
            // 
            this.noteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.accVoucherBindingSource, "Note", true));
            this.noteTextBox.Location = new System.Drawing.Point(490, 159);
            this.noteTextBox.Multiline = true;
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(333, 42);
            this.noteTextBox.TabIndex = 72;
            // 
            // authorizeIDComboBox
            // 
            this.authorizeIDComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.authorizeIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.accVoucherBindingSource, "AuthorizeID", true));
            this.authorizeIDComboBox.DataSource = this.authorizeBindingSource;
            this.authorizeIDComboBox.DisplayMember = "EmployeeName";
            this.authorizeIDComboBox.FormattingEnabled = true;
            this.authorizeIDComboBox.Location = new System.Drawing.Point(660, 512);
            this.authorizeIDComboBox.Name = "authorizeIDComboBox";
            this.authorizeIDComboBox.Size = new System.Drawing.Size(110, 24);
            this.authorizeIDComboBox.TabIndex = 77;
            this.authorizeIDComboBox.ValueMember = "EmployeeID";
            // 
            // lastUpdatedLabel
            // 
            this.lastUpdatedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lastUpdatedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.accVoucherBindingSource, "LastUpdated", true));
            this.lastUpdatedLabel.Location = new System.Drawing.Point(505, 588);
            this.lastUpdatedLabel.Name = "lastUpdatedLabel";
            this.lastUpdatedLabel.Size = new System.Drawing.Size(265, 23);
            this.lastUpdatedLabel.TabIndex = 88;
            // 
            // lockedCheckBox
            // 
            this.lockedCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lockedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.accVoucherBindingSource, "Locked", true));
            this.lockedCheckBox.Enabled = false;
            this.lockedCheckBox.Location = new System.Drawing.Point(584, 549);
            this.lockedCheckBox.Name = "lockedCheckBox";
            this.lockedCheckBox.Size = new System.Drawing.Size(29, 24);
            this.lockedCheckBox.TabIndex = 85;
            this.lockedCheckBox.UseVisualStyleBackColor = true;
            // 
            // removedCheckBox
            // 
            this.removedCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.accVoucherBindingSource, "Removed", true));
            this.removedCheckBox.Location = new System.Drawing.Point(493, 549);
            this.removedCheckBox.Name = "removedCheckBox";
            this.removedCheckBox.Size = new System.Drawing.Size(29, 24);
            this.removedCheckBox.TabIndex = 83;
            this.removedCheckBox.UseVisualStyleBackColor = true;
            // 
            // indentureIDTextBox
            // 
            this.indentureIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.accVoucherBindingSource, "IndentureID", true));
            this.indentureIDTextBox.Location = new System.Drawing.Point(660, 74);
            this.indentureIDTextBox.Name = "indentureIDTextBox";
            this.indentureIDTextBox.Size = new System.Drawing.Size(100, 27);
            this.indentureIDTextBox.TabIndex = 69;
            // 
            // keyinIDComboBox
            // 
            this.keyinIDComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.keyinIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.accVoucherBindingSource, "KeyinID", true));
            this.keyinIDComboBox.DataSource = this.operatorBindingSource;
            this.keyinIDComboBox.DisplayMember = "Name";
            this.keyinIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.keyinIDComboBox.Enabled = false;
            this.keyinIDComboBox.FormattingEnabled = true;
            this.keyinIDComboBox.Location = new System.Drawing.Point(663, 550);
            this.keyinIDComboBox.Name = "keyinIDComboBox";
            this.keyinIDComboBox.Size = new System.Drawing.Size(110, 22);
            this.keyinIDComboBox.TabIndex = 81;
            this.keyinIDComboBox.ValueMember = "OperatorID";
            // 
            // iDTextBox
            // 
            this.iDTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.iDTextBox.CausesValidation = false;
            this.iDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.accVoucherBindingSource, "ID", true));
            this.iDTextBox.Location = new System.Drawing.Point(490, 41);
            this.iDTextBox.Name = "iDTextBox";
            this.iDTextBox.Size = new System.Drawing.Size(100, 27);
            this.iDTextBox.TabIndex = 71;
            // 
            // accVoucherDataGridView
            // 
            this.accVoucherDataGridView.AllowUserToAddRows = false;
            this.accVoucherDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.accVoucherDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.accVoucherDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.accVoucherDataGridView.AutoGenerateColumns = false;
            this.accVoucherDataGridView.BackgroundColor = System.Drawing.Color.Azure;
            this.accVoucherDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accVoucherDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.accVoucherIDDataGridViewTextBoxColumn,
            this.accVoucherTimeDataGridViewTextBoxColumn,
            this.columnTotal,
            this.noteDataGridViewTextBoxColumn,
            this.removedDataGridViewCheckBoxColumn,
            this.lockedDataGridViewCheckBoxColumn});
            this.accVoucherDataGridView.DataSource = this.accVoucherBindingSource;
            this.accVoucherDataGridView.Location = new System.Drawing.Point(852, 0);
            this.accVoucherDataGridView.Name = "accVoucherDataGridView";
            this.accVoucherDataGridView.RowHeadersVisible = false;
            this.accVoucherDataGridView.RowTemplate.Height = 24;
            this.accVoucherDataGridView.Size = new System.Drawing.Size(584, 622);
            this.accVoucherDataGridView.TabIndex = 78;
            this.accVoucherDataGridView.TabStop = false;
            this.accVoucherDataGridView.VirtualMode = true;
            // 
            // accVoucherTimeTextBox
            // 
            this.accVoucherTimeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.accVoucherBindingSource, "AccVoucherTime", true));
            this.accVoucherTimeTextBox.Location = new System.Drawing.Point(490, 116);
            this.accVoucherTimeTextBox.Name = "accVoucherTimeTextBox";
            this.accVoucherTimeTextBox.Size = new System.Drawing.Size(100, 27);
            this.accVoucherTimeTextBox.TabIndex = 70;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl.Controls.Add(this.tabVoucher);
            this.tabControl.Controls.Add(this.tabExpense);
            this.tabControl.Controls.Add(this.tabRevenue);
            this.tabControl.Controls.Add(this.tabShipment);
            this.tabControl.Controls.Add(this.tabBank);
            this.tabControl.Controls.Add(this.tabSalary);
            this.tabControl.Location = new System.Drawing.Point(1, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(397, 622);
            this.tabControl.TabIndex = 95;
            // 
            // tabVoucher
            // 
            this.tabVoucher.Location = new System.Drawing.Point(4, 26);
            this.tabVoucher.Name = "tabVoucher";
            this.tabVoucher.Padding = new System.Windows.Forms.Padding(3);
            this.tabVoucher.Size = new System.Drawing.Size(389, 592);
            this.tabVoucher.TabIndex = 0;
            this.tabVoucher.Text = "進貨";
            this.tabVoucher.UseVisualStyleBackColor = true;
            // 
            // tabExpense
            // 
            this.tabExpense.Location = new System.Drawing.Point(4, 26);
            this.tabExpense.Name = "tabExpense";
            this.tabExpense.Padding = new System.Windows.Forms.Padding(3);
            this.tabExpense.Size = new System.Drawing.Size(389, 593);
            this.tabExpense.TabIndex = 1;
            this.tabExpense.Text = "費用";
            this.tabExpense.UseVisualStyleBackColor = true;
            // 
            // tabRevenue
            // 
            this.tabRevenue.Location = new System.Drawing.Point(4, 26);
            this.tabRevenue.Name = "tabRevenue";
            this.tabRevenue.Padding = new System.Windows.Forms.Padding(3);
            this.tabRevenue.Size = new System.Drawing.Size(389, 593);
            this.tabRevenue.TabIndex = 2;
            this.tabRevenue.Text = "POS營收";
            this.tabRevenue.UseVisualStyleBackColor = true;
            // 
            // tabShipment
            // 
            this.tabShipment.Location = new System.Drawing.Point(4, 26);
            this.tabShipment.Name = "tabShipment";
            this.tabShipment.Padding = new System.Windows.Forms.Padding(3);
            this.tabShipment.Size = new System.Drawing.Size(389, 593);
            this.tabShipment.TabIndex = 3;
            this.tabShipment.Text = "出貨單";
            this.tabShipment.UseVisualStyleBackColor = true;
            // 
            // tabBank
            // 
            this.tabBank.Location = new System.Drawing.Point(4, 26);
            this.tabBank.Name = "tabBank";
            this.tabBank.Padding = new System.Windows.Forms.Padding(3);
            this.tabBank.Size = new System.Drawing.Size(389, 593);
            this.tabBank.TabIndex = 4;
            this.tabBank.Text = "銀行";
            this.tabBank.UseVisualStyleBackColor = true;
            // 
            // tabSalary
            // 
            this.tabSalary.Location = new System.Drawing.Point(4, 26);
            this.tabSalary.Name = "tabSalary";
            this.tabSalary.Padding = new System.Windows.Forms.Padding(3);
            this.tabSalary.Size = new System.Drawing.Size(389, 593);
            this.tabSalary.TabIndex = 5;
            this.tabSalary.Text = "薪資";
            this.tabSalary.UseVisualStyleBackColor = true;
            // 
            // accVoucherTableAdapter
            // 
            this.accVoucherTableAdapter.ClearBeforeFill = true;
            // 
            // accountingTitleTableAdapter
            // 
            this.accountingTitleTableAdapter.ClearBeforeFill = true;
            // 
            // hRTableAdapter
            // 
            this.hRTableAdapter.ClearBeforeFill = true;
            // 
            // operatorTableAdapter
            // 
            this.operatorTableAdapter.ClearBeforeFill = true;
            // 
            // accVoucherDetailBindingSource
            // 
            this.accVoucherDetailBindingSource.DataMember = "FK_AccVoucherDetail_AccVoucher";
            this.accVoucherDetailBindingSource.DataSource = this.accVoucherBindingSource;
            // 
            // accVoucherDetailTableAdapter
            // 
            this.accVoucherDetailTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AccountingTitleTableAdapter = this.accountingTitleTableAdapter;
            this.tableAdapterManager.AccVoucherDetailTableAdapter = this.accVoucherDetailTableAdapter;
            this.tableAdapterManager.AccVoucherTableAdapter = this.accVoucherTableAdapter;
            this.tableAdapterManager.ApartmentTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BakeryConfigTableAdapter = null;
            this.tableAdapterManager.BankAccountTableAdapter = null;
            this.tableAdapterManager.BankDetailTableAdapter = null;
            this.tableAdapterManager.CashierTableAdapter = null;
            this.tableAdapterManager.ConfigTableAdapter = null;
            this.tableAdapterManager.CustomerTableAdapter = null;
            this.tableAdapterManager.DrawerRecordTableAdapter = null;
            this.tableAdapterManager.ExpenseTableAdapter = null;
            this.tableAdapterManager.HeaderTableAdapter = null;
            this.tableAdapterManager.HRDetailTableAdapter = null;
            this.tableAdapterManager.HRTableAdapter = this.hRTableAdapter;
            this.tableAdapterManager.IngredientTableAdapter = null;
            this.tableAdapterManager.InventoryDetailTableAdapter = null;
            this.tableAdapterManager.InventoryProductsTableAdapter = null;
            this.tableAdapterManager.InventoryTableAdapter = null;
            this.tableAdapterManager.OnDutyDataTableAdapter = null;
            this.tableAdapterManager.OperatorTableAdapter = this.operatorTableAdapter;
            this.tableAdapterManager.OrderItemTableAdapter = null;
            this.tableAdapterManager.OrderTableAdapter = null;
            this.tableAdapterManager.PhotosTableAdapter = null;
            this.tableAdapterManager.ProductClassTableAdapter = null;
            this.tableAdapterManager.ProductScrappedDetailTableAdapter = null;
            this.tableAdapterManager.ProductScrappedTableAdapter = null;
            this.tableAdapterManager.ProductTableAdapter = null;
            this.tableAdapterManager.ProgramTableAdapter = null;
            this.tableAdapterManager.RecipeDetailTableAdapter = null;
            this.tableAdapterManager.RecipeTableAdapter = null;
            this.tableAdapterManager.RequestsTableAdapter = null;
            this.tableAdapterManager.ShiftDetailTableAdapter = null;
            this.tableAdapterManager.ShiftTableTableAdapter = null;
            this.tableAdapterManager.ShipmentDetailTableAdapter = null;
            this.tableAdapterManager.ShipmentTableAdapter = null;
            this.tableAdapterManager.SyncMD5OldTableAdapter = null;
            this.tableAdapterManager.SyncTableTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = VoucherExpense.DamaiDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VEHeaderTableAdapter = null;
            this.tableAdapterManager.VendorTableAdapter = null;
            this.tableAdapterManager.VoucherDetailTableAdapter = null;
            this.tableAdapterManager.VoucherTableAdapter = null;
            // 
            // accVoucherDetailDataGridView
            // 
            this.accVoucherDetailDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.accVoucherDetailDataGridView.AutoGenerateColumns = false;
            this.accVoucherDetailDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.accVoucherDetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accVoucherDetailDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.accVoucherDetailDataGridView.DataSource = this.accVoucherDetailBindingSource;
            this.accVoucherDetailDataGridView.Location = new System.Drawing.Point(400, 207);
            this.accVoucherDetailDataGridView.Name = "accVoucherDetailDataGridView";
            this.accVoucherDetailDataGridView.RowHeadersVisible = false;
            this.accVoucherDetailDataGridView.RowTemplate.Height = 24;
            this.accVoucherDetailDataGridView.Size = new System.Drawing.Size(446, 288);
            this.accVoucherDetailDataGridView.TabIndex = 95;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MainID";
            this.dataGridViewTextBoxColumn2.HeaderText = "MainID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "IsDebt";
            this.dataGridViewCheckBoxColumn1.HeaderText = "C/D";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TitleCode";
            this.dataGridViewTextBoxColumn3.HeaderText = "科目";
            this.dataGridViewTextBoxColumn3.MaxInputLength = 8;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Money";
            this.dataGridViewTextBoxColumn4.HeaderText = "金額";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Note";
            this.dataGridViewTextBoxColumn5.HeaderText = "Note";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // accVoucherIDDataGridViewTextBoxColumn
            // 
            this.accVoucherIDDataGridViewTextBoxColumn.DataPropertyName = "AccVoucherID";
            this.accVoucherIDDataGridViewTextBoxColumn.HeaderText = "傳票号";
            this.accVoucherIDDataGridViewTextBoxColumn.Name = "accVoucherIDDataGridViewTextBoxColumn";
            this.accVoucherIDDataGridViewTextBoxColumn.Width = 80;
            // 
            // accVoucherTimeDataGridViewTextBoxColumn
            // 
            this.accVoucherTimeDataGridViewTextBoxColumn.DataPropertyName = "AccVoucherTime";
            this.accVoucherTimeDataGridViewTextBoxColumn.HeaderText = "時間";
            this.accVoucherTimeDataGridViewTextBoxColumn.Name = "accVoucherTimeDataGridViewTextBoxColumn";
            // 
            // columnTotal
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "??????";
            this.columnTotal.DefaultCellStyle = dataGridViewCellStyle2;
            this.columnTotal.HeaderText = "金額";
            this.columnTotal.Name = "columnTotal";
            this.columnTotal.ReadOnly = true;
            this.columnTotal.Width = 88;
            // 
            // noteDataGridViewTextBoxColumn
            // 
            this.noteDataGridViewTextBoxColumn.DataPropertyName = "Note";
            this.noteDataGridViewTextBoxColumn.HeaderText = "Note";
            this.noteDataGridViewTextBoxColumn.Name = "noteDataGridViewTextBoxColumn";
            this.noteDataGridViewTextBoxColumn.Width = 240;
            // 
            // removedDataGridViewCheckBoxColumn
            // 
            this.removedDataGridViewCheckBoxColumn.DataPropertyName = "Removed";
            this.removedDataGridViewCheckBoxColumn.HeaderText = "Removed";
            this.removedDataGridViewCheckBoxColumn.Name = "removedDataGridViewCheckBoxColumn";
            this.removedDataGridViewCheckBoxColumn.Visible = false;
            // 
            // lockedDataGridViewCheckBoxColumn
            // 
            this.lockedDataGridViewCheckBoxColumn.DataPropertyName = "Locked";
            this.lockedDataGridViewCheckBoxColumn.HeaderText = "核";
            this.lockedDataGridViewCheckBoxColumn.Name = "lockedDataGridViewCheckBoxColumn";
            this.lockedDataGridViewCheckBoxColumn.Width = 40;
            // 
            // FormAccounting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1424, 623);
            this.Controls.Add(this.accVoucherDetailDataGridView);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.accVoucherDataGridView);
            this.Controls.Add(this.ckBoxAllowEdit);
            this.Controls.Add(label1);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(applierIDLabel);
            this.Controls.Add(noteLabel);
            this.Controls.Add(authorizeIDLabel);
            this.Controls.Add(lastUpdatedLabel1);
            this.Controls.Add(lockedLabel);
            this.Controls.Add(keyinIDLabel);
            this.Controls.Add(indentureIDLabel);
            this.Controls.Add(removedLabel);
            this.Controls.Add(accVoucherTimeLabel);
            this.Controls.Add(this.accVoucherIDLabel);
            this.Controls.Add(this.accVoucherBindingNavigator);
            this.Controls.Add(accVoucherIDTextBox);
            this.Controls.Add(this.applierIDComboBox);
            this.Controls.Add(this.noteTextBox);
            this.Controls.Add(this.authorizeIDComboBox);
            this.Controls.Add(this.lastUpdatedLabel);
            this.Controls.Add(this.lockedCheckBox);
            this.Controls.Add(this.removedCheckBox);
            this.Controls.Add(this.indentureIDTextBox);
            this.Controls.Add(this.keyinIDComboBox);
            this.Controls.Add(this.iDTextBox);
            this.Controls.Add(this.accVoucherTimeTextBox);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormAccounting";
            this.Text = "會計傳票";
            this.Load += new System.EventHandler(this.FormAccounting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accVoucherBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorizeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accTitleDGVBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accVoucherBindingNavigator)).EndInit();
            this.accVoucherBindingNavigator.ResumeLayout(false);
            this.accVoucherBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accVoucherDataGridView)).EndInit();
            this.tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accVoucherDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accVoucherDetailDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource accVoucherBindingSource;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private System.Windows.Forms.CheckBox ckBoxAllowEdit;
        private System.Windows.Forms.BindingSource authorizeBindingSource;
        private System.Windows.Forms.BindingSource operatorBindingSource;
        private System.Windows.Forms.BindingSource accTitleDGVBindingSource;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.Label accVoucherIDLabel;
        private System.Windows.Forms.BindingNavigator accVoucherBindingNavigator;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton accVoucherBindingNavigatorSaveItem;
        private System.Windows.Forms.ComboBox applierIDComboBox;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.ComboBox authorizeIDComboBox;
        private System.Windows.Forms.Label lastUpdatedLabel;
        private System.Windows.Forms.CheckBox lockedCheckBox;
        private System.Windows.Forms.CheckBox removedCheckBox;
        private System.Windows.Forms.TextBox indentureIDTextBox;
        private System.Windows.Forms.ComboBox keyinIDComboBox;
        private System.Windows.Forms.TextBox iDTextBox;
        private System.Windows.Forms.DataGridView accVoucherDataGridView;
        private System.Windows.Forms.TextBox accVoucherTimeTextBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabVoucher;
        private System.Windows.Forms.TabPage tabExpense;
        private System.Windows.Forms.TabPage tabRevenue;
        private System.Windows.Forms.TabPage tabShipment;
        private System.Windows.Forms.TabPage tabBank;
        private System.Windows.Forms.TabPage tabSalary;
        private DamaiDataSet damaiDataSet;
        private DamaiDataSetTableAdapters.AccVoucherTableAdapter accVoucherTableAdapter;
        private DamaiDataSetTableAdapters.AccountingTitleTableAdapter accountingTitleTableAdapter;
        private DamaiDataSetTableAdapters.HRTableAdapter hRTableAdapter;
        private DamaiDataSetTableAdapters.OperatorTableAdapter operatorTableAdapter;
        private System.Windows.Forms.BindingSource accVoucherDetailBindingSource;
        private DamaiDataSetTableAdapters.AccVoucherDetailTableAdapter accVoucherDetailTableAdapter;
        private DamaiDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView accVoucherDetailDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accVoucherIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accVoucherTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn removedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lockedDataGridViewCheckBoxColumn;
    }
}