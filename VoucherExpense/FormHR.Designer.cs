namespace VoucherExpense
{
    partial class FormHR
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
            System.Windows.Forms.Label employeeIDLabel;
            System.Windows.Forms.Label employeeCodeLabel;
            System.Windows.Forms.Label employeeNameLabel;
            System.Windows.Forms.Label apartmentIDLabel;
            System.Windows.Forms.Label idNoLabel;
            System.Windows.Forms.Label birthdayLabel;
            System.Windows.Forms.Label marriageLabel;
            System.Windows.Forms.Label bloodTypeLabel;
            System.Windows.Forms.Label telphoneLabel;
            System.Windows.Forms.Label mobileLabel;
            System.Windows.Forms.Label genderLabel;
            System.Windows.Forms.Label addressLabel;
            System.Windows.Forms.Label educationLabel;
            System.Windows.Forms.Label titleLabel;
            System.Windows.Forms.Label contactLabel;
            System.Windows.Forms.Label emergencyTelLabel;
            System.Windows.Forms.Label lastUpdatedLabel;
            System.Windows.Forms.Label keyinIDLabel;
            System.Windows.Forms.Label fingerPintNoLabel;
            System.Windows.Forms.Label bankAccoutLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHR));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.hRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hRTableAdapter = new VoucherExpense.VEDataSetTableAdapters.HRTableAdapter();
            this.hRBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.hRBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.hRDataGridView = new System.Windows.Forms.DataGridView();
            this.columnEmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApartmentID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.apartmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeIDTextBox = new System.Windows.Forms.TextBox();
            this.employeeCodeTextBox = new System.Windows.Forms.TextBox();
            this.employeeNameTextBox = new System.Windows.Forms.TextBox();
            this.isManagerCheckBox = new System.Windows.Forms.CheckBox();
            this.inPositionCheckBox = new System.Windows.Forms.CheckBox();
            this.idNoTextBox = new System.Windows.Forms.TextBox();
            this.birthdayDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.marriageTextBox = new System.Windows.Forms.TextBox();
            this.bloodTypeTextBox = new System.Windows.Forms.TextBox();
            this.telphoneTextBox = new System.Windows.Forms.TextBox();
            this.mobileTextBox = new System.Windows.Forms.TextBox();
            this.genderTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.educationTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.contactTextBox = new System.Windows.Forms.TextBox();
            this.emergencyTelTextBox = new System.Windows.Forms.TextBox();
            this.fingerPintNoTextBox = new System.Windows.Forms.TextBox();
            this.lastUpdatedTextBox = new System.Windows.Forms.TextBox();
            this.hRDetailTableAdapter = new VoucherExpense.VEDataSetTableAdapters.HRDetailTableAdapter();
            this.hRDetailDataGridView = new System.Windows.Forms.DataGridView();
            this.hRHRDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.apartmentTableAdapter = new VoucherExpense.VEDataSetTableAdapters.ApartmentTableAdapter();
            this.photoPictureBox = new System.Windows.Forms.PictureBox();
            this.btnPhoto = new System.Windows.Forms.Button();
            this.apartmentIDComboBox = new System.Windows.Forms.ComboBox();
            this.bankAccoutTextBox = new System.Windows.Forms.TextBox();
            this.keyinIDComboBox = new System.Windows.Forms.ComboBox();
            this.operatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vEDataSet1 = new VoucherExpense.VEDataSet();
            this.operatorTableAdapter = new VoucherExpense.VEDataSetTableAdapters.OperatorTableAdapter();
            this.columnDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnApproved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            employeeIDLabel = new System.Windows.Forms.Label();
            employeeCodeLabel = new System.Windows.Forms.Label();
            employeeNameLabel = new System.Windows.Forms.Label();
            apartmentIDLabel = new System.Windows.Forms.Label();
            idNoLabel = new System.Windows.Forms.Label();
            birthdayLabel = new System.Windows.Forms.Label();
            marriageLabel = new System.Windows.Forms.Label();
            bloodTypeLabel = new System.Windows.Forms.Label();
            telphoneLabel = new System.Windows.Forms.Label();
            mobileLabel = new System.Windows.Forms.Label();
            genderLabel = new System.Windows.Forms.Label();
            addressLabel = new System.Windows.Forms.Label();
            educationLabel = new System.Windows.Forms.Label();
            titleLabel = new System.Windows.Forms.Label();
            contactLabel = new System.Windows.Forms.Label();
            emergencyTelLabel = new System.Windows.Forms.Label();
            lastUpdatedLabel = new System.Windows.Forms.Label();
            keyinIDLabel = new System.Windows.Forms.Label();
            fingerPintNoLabel = new System.Windows.Forms.Label();
            bankAccoutLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hRBindingNavigator)).BeginInit();
            this.hRBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hRDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hRDetailDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hRHRDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // employeeIDLabel
            // 
            employeeIDLabel.AutoSize = true;
            employeeIDLabel.Location = new System.Drawing.Point(611, 59);
            employeeIDLabel.Name = "employeeIDLabel";
            employeeIDLabel.Size = new System.Drawing.Size(56, 16);
            employeeIDLabel.TabIndex = 2;
            employeeIDLabel.Text = "內部號";
            // 
            // employeeCodeLabel
            // 
            employeeCodeLabel.AutoSize = true;
            employeeCodeLabel.Location = new System.Drawing.Point(387, 59);
            employeeCodeLabel.Name = "employeeCodeLabel";
            employeeCodeLabel.Size = new System.Drawing.Size(56, 16);
            employeeCodeLabel.TabIndex = 4;
            employeeCodeLabel.Text = "員工碼";
            // 
            // employeeNameLabel
            // 
            employeeNameLabel.AutoSize = true;
            employeeNameLabel.Location = new System.Drawing.Point(387, 92);
            employeeNameLabel.Name = "employeeNameLabel";
            employeeNameLabel.Size = new System.Drawing.Size(40, 16);
            employeeNameLabel.TabIndex = 6;
            employeeNameLabel.Text = "姓名";
            // 
            // apartmentIDLabel
            // 
            apartmentIDLabel.AutoSize = true;
            apartmentIDLabel.Location = new System.Drawing.Point(611, 92);
            apartmentIDLabel.Name = "apartmentIDLabel";
            apartmentIDLabel.Size = new System.Drawing.Size(40, 16);
            apartmentIDLabel.TabIndex = 8;
            apartmentIDLabel.Text = "部門";
            // 
            // idNoLabel
            // 
            idNoLabel.AutoSize = true;
            idNoLabel.Location = new System.Drawing.Point(387, 125);
            idNoLabel.Name = "idNoLabel";
            idNoLabel.Size = new System.Drawing.Size(56, 16);
            idNoLabel.TabIndex = 14;
            idNoLabel.Text = "身份証";
            // 
            // birthdayLabel
            // 
            birthdayLabel.AutoSize = true;
            birthdayLabel.Location = new System.Drawing.Point(387, 162);
            birthdayLabel.Name = "birthdayLabel";
            birthdayLabel.Size = new System.Drawing.Size(40, 16);
            birthdayLabel.TabIndex = 16;
            birthdayLabel.Text = "生日";
            // 
            // marriageLabel
            // 
            marriageLabel.AutoSize = true;
            marriageLabel.Location = new System.Drawing.Point(611, 164);
            marriageLabel.Name = "marriageLabel";
            marriageLabel.Size = new System.Drawing.Size(40, 16);
            marriageLabel.TabIndex = 20;
            marriageLabel.Text = "婚姻";
            // 
            // bloodTypeLabel
            // 
            bloodTypeLabel.AutoSize = true;
            bloodTypeLabel.Location = new System.Drawing.Point(611, 232);
            bloodTypeLabel.Name = "bloodTypeLabel";
            bloodTypeLabel.Size = new System.Drawing.Size(40, 16);
            bloodTypeLabel.TabIndex = 22;
            bloodTypeLabel.Text = "血型";
            // 
            // telphoneLabel
            // 
            telphoneLabel.AutoSize = true;
            telphoneLabel.Location = new System.Drawing.Point(387, 232);
            telphoneLabel.Name = "telphoneLabel";
            telphoneLabel.Size = new System.Drawing.Size(40, 16);
            telphoneLabel.TabIndex = 24;
            telphoneLabel.Text = "電話";
            // 
            // mobileLabel
            // 
            mobileLabel.AutoSize = true;
            mobileLabel.Location = new System.Drawing.Point(387, 265);
            mobileLabel.Name = "mobileLabel";
            mobileLabel.Size = new System.Drawing.Size(40, 16);
            mobileLabel.TabIndex = 26;
            mobileLabel.Text = "手机";
            // 
            // genderLabel
            // 
            genderLabel.AutoSize = true;
            genderLabel.Location = new System.Drawing.Point(701, 235);
            genderLabel.Name = "genderLabel";
            genderLabel.Size = new System.Drawing.Size(40, 16);
            genderLabel.TabIndex = 28;
            genderLabel.Text = "姓別";
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new System.Drawing.Point(387, 331);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new System.Drawing.Size(40, 16);
            addressLabel.TabIndex = 30;
            addressLabel.Text = "地址";
            // 
            // educationLabel
            // 
            educationLabel.AutoSize = true;
            educationLabel.Location = new System.Drawing.Point(611, 199);
            educationLabel.Name = "educationLabel";
            educationLabel.Size = new System.Drawing.Size(40, 16);
            educationLabel.TabIndex = 32;
            educationLabel.Text = "學歷";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new System.Drawing.Point(611, 125);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(40, 16);
            titleLabel.TabIndex = 34;
            titleLabel.Text = "職稱";
            // 
            // contactLabel
            // 
            contactLabel.AutoSize = true;
            contactLabel.Location = new System.Drawing.Point(611, 364);
            contactLabel.Name = "contactLabel";
            contactLabel.Size = new System.Drawing.Size(56, 16);
            contactLabel.TabIndex = 36;
            contactLabel.Text = "連絡人";
            // 
            // emergencyTelLabel
            // 
            emergencyTelLabel.AutoSize = true;
            emergencyTelLabel.Location = new System.Drawing.Point(371, 364);
            emergencyTelLabel.Name = "emergencyTelLabel";
            emergencyTelLabel.Size = new System.Drawing.Size(72, 16);
            emergencyTelLabel.TabIndex = 38;
            emergencyTelLabel.Text = "緊急連絡";
            // 
            // lastUpdatedLabel
            // 
            lastUpdatedLabel.AutoSize = true;
            lastUpdatedLabel.Location = new System.Drawing.Point(371, 397);
            lastUpdatedLabel.Name = "lastUpdatedLabel";
            lastUpdatedLabel.Size = new System.Drawing.Size(72, 16);
            lastUpdatedLabel.TabIndex = 40;
            lastUpdatedLabel.Text = "最後更新";
            // 
            // keyinIDLabel
            // 
            keyinIDLabel.AutoSize = true;
            keyinIDLabel.Location = new System.Drawing.Point(611, 397);
            keyinIDLabel.Name = "keyinIDLabel";
            keyinIDLabel.Size = new System.Drawing.Size(40, 16);
            keyinIDLabel.TabIndex = 42;
            keyinIDLabel.Text = "輸入";
            // 
            // fingerPintNoLabel
            // 
            fingerPintNoLabel.AutoSize = true;
            fingerPintNoLabel.Location = new System.Drawing.Point(387, 199);
            fingerPintNoLabel.Name = "fingerPintNoLabel";
            fingerPintNoLabel.Size = new System.Drawing.Size(56, 16);
            fingerPintNoLabel.TabIndex = 43;
            fingerPintNoLabel.Text = "指紋號";
            // 
            // bankAccoutLabel
            // 
            bankAccoutLabel.AutoSize = true;
            bankAccoutLabel.Location = new System.Drawing.Point(387, 301);
            bankAccoutLabel.Name = "bankAccoutLabel";
            bankAccoutLabel.Size = new System.Drawing.Size(56, 16);
            bankAccoutLabel.TabIndex = 48;
            bankAccoutLabel.Text = "銀行号";
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hRBindingSource
            // 
            this.hRBindingSource.DataMember = "HR";
            this.hRBindingSource.DataSource = this.vEDataSet;
            // 
            // hRTableAdapter
            // 
            this.hRTableAdapter.ClearBeforeFill = true;
            // 
            // hRBindingNavigator
            // 
            this.hRBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.hRBindingNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hRBindingNavigator.BindingSource = this.hRBindingSource;
            this.hRBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.hRBindingNavigator.DeleteItem = null;
            this.hRBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.hRBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.hRBindingNavigatorSaveItem});
            this.hRBindingNavigator.Location = new System.Drawing.Point(703, 9);
            this.hRBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.hRBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.hRBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.hRBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.hRBindingNavigator.Name = "hRBindingNavigator";
            this.hRBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.hRBindingNavigator.Size = new System.Drawing.Size(249, 25);
            this.hRBindingNavigator.TabIndex = 0;
            this.hRBindingNavigator.Text = "bindingNavigator1";
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
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
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
            // hRBindingNavigatorSaveItem
            // 
            this.hRBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.hRBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("hRBindingNavigatorSaveItem.Image")));
            this.hRBindingNavigatorSaveItem.Name = "hRBindingNavigatorSaveItem";
            this.hRBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.hRBindingNavigatorSaveItem.Text = "儲存資料";
            this.hRBindingNavigatorSaveItem.Click += new System.EventHandler(this.hRBindingNavigatorSaveItem_Click);
            // 
            // hRDataGridView
            // 
            this.hRDataGridView.AllowUserToAddRows = false;
            this.hRDataGridView.AllowUserToResizeRows = false;
            this.hRDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.hRDataGridView.AutoGenerateColumns = false;
            this.hRDataGridView.BackgroundColor = System.Drawing.Color.SeaShell;
            this.hRDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hRDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnEmployeeID,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewTextBoxColumn11,
            this.ApartmentID});
            this.hRDataGridView.DataSource = this.hRBindingSource;
            this.hRDataGridView.Location = new System.Drawing.Point(0, 2);
            this.hRDataGridView.Name = "hRDataGridView";
            this.hRDataGridView.RowHeadersVisible = false;
            this.hRDataGridView.RowTemplate.Height = 24;
            this.hRDataGridView.Size = new System.Drawing.Size(354, 794);
            this.hRDataGridView.TabIndex = 1;
            // 
            // columnEmployeeID
            // 
            this.columnEmployeeID.DataPropertyName = "EmployeeID";
            this.columnEmployeeID.HeaderText = "ID";
            this.columnEmployeeID.MinimumWidth = 2;
            this.columnEmployeeID.Name = "columnEmployeeID";
            this.columnEmployeeID.Width = 2;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "EmployeeName";
            this.dataGridViewTextBoxColumn3.HeaderText = "姓名";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "InPosition";
            this.dataGridViewCheckBoxColumn2.HeaderText = "在職";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Width = 48;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Mobile";
            this.dataGridViewTextBoxColumn11.HeaderText = "手机";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // ApartmentID
            // 
            this.ApartmentID.DataPropertyName = "ApartmentID";
            this.ApartmentID.DataSource = this.apartmentBindingSource;
            this.ApartmentID.DisplayMember = "ApartmentName";
            this.ApartmentID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ApartmentID.HeaderText = "部門";
            this.ApartmentID.Name = "ApartmentID";
            this.ApartmentID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ApartmentID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ApartmentID.ValueMember = "ApartmentID";
            this.ApartmentID.Width = 80;
            // 
            // apartmentBindingSource
            // 
            this.apartmentBindingSource.DataMember = "Apartment";
            this.apartmentBindingSource.DataSource = this.vEDataSet;
            // 
            // employeeIDTextBox
            // 
            this.employeeIDTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.employeeIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hRBindingSource, "EmployeeID", true));
            this.employeeIDTextBox.Location = new System.Drawing.Point(670, 54);
            this.employeeIDTextBox.Name = "employeeIDTextBox";
            this.employeeIDTextBox.ReadOnly = true;
            this.employeeIDTextBox.Size = new System.Drawing.Size(116, 27);
            this.employeeIDTextBox.TabIndex = 3;
            // 
            // employeeCodeTextBox
            // 
            this.employeeCodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hRBindingSource, "EmployeeCode", true));
            this.employeeCodeTextBox.Location = new System.Drawing.Point(449, 54);
            this.employeeCodeTextBox.Name = "employeeCodeTextBox";
            this.employeeCodeTextBox.Size = new System.Drawing.Size(100, 27);
            this.employeeCodeTextBox.TabIndex = 5;
            // 
            // employeeNameTextBox
            // 
            this.employeeNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hRBindingSource, "EmployeeName", true));
            this.employeeNameTextBox.Location = new System.Drawing.Point(449, 87);
            this.employeeNameTextBox.Name = "employeeNameTextBox";
            this.employeeNameTextBox.Size = new System.Drawing.Size(100, 27);
            this.employeeNameTextBox.TabIndex = 7;
            // 
            // isManagerCheckBox
            // 
            this.isManagerCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.hRBindingSource, "IsManager", true));
            this.isManagerCheckBox.Location = new System.Drawing.Point(617, 260);
            this.isManagerCheckBox.Name = "isManagerCheckBox";
            this.isManagerCheckBox.Size = new System.Drawing.Size(78, 24);
            this.isManagerCheckBox.TabIndex = 11;
            this.isManagerCheckBox.Text = "經理級";
            this.isManagerCheckBox.UseVisualStyleBackColor = true;
            // 
            // inPositionCheckBox
            // 
            this.inPositionCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.hRBindingSource, "InPosition", true));
            this.inPositionCheckBox.Location = new System.Drawing.Point(704, 262);
            this.inPositionCheckBox.Name = "inPositionCheckBox";
            this.inPositionCheckBox.Size = new System.Drawing.Size(62, 24);
            this.inPositionCheckBox.TabIndex = 13;
            this.inPositionCheckBox.Text = "在職";
            this.inPositionCheckBox.UseVisualStyleBackColor = true;
            // 
            // idNoTextBox
            // 
            this.idNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hRBindingSource, "IdNo", true));
            this.idNoTextBox.Location = new System.Drawing.Point(449, 120);
            this.idNoTextBox.Name = "idNoTextBox";
            this.idNoTextBox.Size = new System.Drawing.Size(147, 27);
            this.idNoTextBox.TabIndex = 15;
            // 
            // birthdayDateTimePicker
            // 
            this.birthdayDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.hRBindingSource, "Birthday", true));
            this.birthdayDateTimePicker.Location = new System.Drawing.Point(449, 157);
            this.birthdayDateTimePicker.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.birthdayDateTimePicker.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.birthdayDateTimePicker.Name = "birthdayDateTimePicker";
            this.birthdayDateTimePicker.Size = new System.Drawing.Size(147, 27);
            this.birthdayDateTimePicker.TabIndex = 17;
            // 
            // marriageTextBox
            // 
            this.marriageTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hRBindingSource, "Marriage", true));
            this.marriageTextBox.Location = new System.Drawing.Point(670, 159);
            this.marriageTextBox.Name = "marriageTextBox";
            this.marriageTextBox.Size = new System.Drawing.Size(116, 27);
            this.marriageTextBox.TabIndex = 21;
            // 
            // bloodTypeTextBox
            // 
            this.bloodTypeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hRBindingSource, "BloodType", true));
            this.bloodTypeTextBox.Location = new System.Drawing.Point(648, 229);
            this.bloodTypeTextBox.Name = "bloodTypeTextBox";
            this.bloodTypeTextBox.Size = new System.Drawing.Size(47, 27);
            this.bloodTypeTextBox.TabIndex = 23;
            // 
            // telphoneTextBox
            // 
            this.telphoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hRBindingSource, "Telphone", true));
            this.telphoneTextBox.Location = new System.Drawing.Point(449, 227);
            this.telphoneTextBox.Name = "telphoneTextBox";
            this.telphoneTextBox.Size = new System.Drawing.Size(147, 27);
            this.telphoneTextBox.TabIndex = 25;
            // 
            // mobileTextBox
            // 
            this.mobileTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hRBindingSource, "Mobile", true));
            this.mobileTextBox.Location = new System.Drawing.Point(449, 260);
            this.mobileTextBox.Name = "mobileTextBox";
            this.mobileTextBox.Size = new System.Drawing.Size(147, 27);
            this.mobileTextBox.TabIndex = 27;
            // 
            // genderTextBox
            // 
            this.genderTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hRBindingSource, "Gender", true));
            this.genderTextBox.Location = new System.Drawing.Point(739, 229);
            this.genderTextBox.Name = "genderTextBox";
            this.genderTextBox.Size = new System.Drawing.Size(47, 27);
            this.genderTextBox.TabIndex = 29;
            // 
            // addressTextBox
            // 
            this.addressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hRBindingSource, "Address", true));
            this.addressTextBox.Location = new System.Drawing.Point(449, 326);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(337, 27);
            this.addressTextBox.TabIndex = 31;
            // 
            // educationTextBox
            // 
            this.educationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hRBindingSource, "Education", true));
            this.educationTextBox.Location = new System.Drawing.Point(670, 194);
            this.educationTextBox.Name = "educationTextBox";
            this.educationTextBox.Size = new System.Drawing.Size(116, 27);
            this.educationTextBox.TabIndex = 33;
            // 
            // titleTextBox
            // 
            this.titleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hRBindingSource, "Title", true));
            this.titleTextBox.Location = new System.Drawing.Point(670, 120);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(116, 27);
            this.titleTextBox.TabIndex = 35;
            // 
            // contactTextBox
            // 
            this.contactTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hRBindingSource, "Contact", true));
            this.contactTextBox.Location = new System.Drawing.Point(670, 359);
            this.contactTextBox.Name = "contactTextBox";
            this.contactTextBox.Size = new System.Drawing.Size(116, 27);
            this.contactTextBox.TabIndex = 37;
            // 
            // emergencyTelTextBox
            // 
            this.emergencyTelTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hRBindingSource, "EmergencyTel", true));
            this.emergencyTelTextBox.Location = new System.Drawing.Point(449, 359);
            this.emergencyTelTextBox.Name = "emergencyTelTextBox";
            this.emergencyTelTextBox.Size = new System.Drawing.Size(147, 27);
            this.emergencyTelTextBox.TabIndex = 39;
            // 
            // fingerPintNoTextBox
            // 
            this.fingerPintNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hRBindingSource, "FingerPintNo", true));
            this.fingerPintNoTextBox.Location = new System.Drawing.Point(449, 194);
            this.fingerPintNoTextBox.Name = "fingerPintNoTextBox";
            this.fingerPintNoTextBox.Size = new System.Drawing.Size(147, 27);
            this.fingerPintNoTextBox.TabIndex = 44;
            // 
            // lastUpdatedTextBox
            // 
            this.lastUpdatedTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.lastUpdatedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hRBindingSource, "LastUpdated", true));
            this.lastUpdatedTextBox.Location = new System.Drawing.Point(449, 392);
            this.lastUpdatedTextBox.Name = "lastUpdatedTextBox";
            this.lastUpdatedTextBox.ReadOnly = true;
            this.lastUpdatedTextBox.Size = new System.Drawing.Size(147, 27);
            this.lastUpdatedTextBox.TabIndex = 45;
            // 
            // hRDetailTableAdapter
            // 
            this.hRDetailTableAdapter.ClearBeforeFill = true;
            // 
            // hRDetailDataGridView
            // 
            this.hRDetailDataGridView.AllowUserToOrderColumns = true;
            this.hRDetailDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.hRDetailDataGridView.AutoGenerateColumns = false;
            this.hRDetailDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.hRDetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hRDetailDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnDetailID,
            this.dataGridViewTextBoxColumn4,
            this.columnApproved,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.hRDetailDataGridView.DataSource = this.hRHRDetailBindingSource;
            this.hRDetailDataGridView.Location = new System.Drawing.Point(360, 423);
            this.hRDetailDataGridView.Name = "hRDetailDataGridView";
            this.hRDetailDataGridView.RowHeadersWidth = 25;
            this.hRDetailDataGridView.RowTemplate.Height = 24;
            this.hRDetailDataGridView.Size = new System.Drawing.Size(591, 373);
            this.hRDetailDataGridView.TabIndex = 45;
            this.hRDetailDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.hRDetailDataGridView_CellBeginEdit);
            this.hRDetailDataGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.hRDetailDataGridView_DefaultValuesNeeded);
            this.hRDetailDataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.hRDetailDataGridView_UserDeletingRow);
            // 
            // hRHRDetailBindingSource
            // 
            this.hRHRDetailBindingSource.DataMember = "HR_HRDetail";
            this.hRHRDetailBindingSource.DataSource = this.hRBindingSource;
            // 
            // apartmentTableAdapter
            // 
            this.apartmentTableAdapter.ClearBeforeFill = true;
            // 
            // photoPictureBox
            // 
            this.photoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.photoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.photoPictureBox.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.hRBindingSource, "Photo", true));
            this.photoPictureBox.Location = new System.Drawing.Point(796, 54);
            this.photoPictureBox.Name = "photoPictureBox";
            this.photoPictureBox.Size = new System.Drawing.Size(155, 170);
            this.photoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.photoPictureBox.TabIndex = 46;
            this.photoPictureBox.TabStop = false;
            // 
            // btnPhoto
            // 
            this.btnPhoto.Location = new System.Drawing.Point(839, 232);
            this.btnPhoto.Name = "btnPhoto";
            this.btnPhoto.Size = new System.Drawing.Size(75, 23);
            this.btnPhoto.TabIndex = 47;
            this.btnPhoto.Text = "照片";
            this.btnPhoto.UseVisualStyleBackColor = true;
            this.btnPhoto.Click += new System.EventHandler(this.btnPhoto_Click);
            // 
            // apartmentIDComboBox
            // 
            this.apartmentIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.hRBindingSource, "ApartmentID", true));
            this.apartmentIDComboBox.DataSource = this.apartmentBindingSource;
            this.apartmentIDComboBox.DisplayMember = "ApartmentName";
            this.apartmentIDComboBox.FormattingEnabled = true;
            this.apartmentIDComboBox.Location = new System.Drawing.Point(670, 90);
            this.apartmentIDComboBox.Name = "apartmentIDComboBox";
            this.apartmentIDComboBox.Size = new System.Drawing.Size(116, 24);
            this.apartmentIDComboBox.TabIndex = 48;
            this.apartmentIDComboBox.ValueMember = "ApartmentID";
            // 
            // bankAccoutTextBox
            // 
            this.bankAccoutTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hRBindingSource, "BankAccout", true));
            this.bankAccoutTextBox.Location = new System.Drawing.Point(449, 293);
            this.bankAccoutTextBox.Name = "bankAccoutTextBox";
            this.bankAccoutTextBox.Size = new System.Drawing.Size(337, 27);
            this.bankAccoutTextBox.TabIndex = 49;
            // 
            // keyinIDComboBox
            // 
            this.keyinIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.hRBindingSource, "KeyinID", true));
            this.keyinIDComboBox.DataSource = this.operatorBindingSource;
            this.keyinIDComboBox.DisplayMember = "Name";
            this.keyinIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.keyinIDComboBox.Enabled = false;
            this.keyinIDComboBox.FormattingEnabled = true;
            this.keyinIDComboBox.Location = new System.Drawing.Point(670, 393);
            this.keyinIDComboBox.Name = "keyinIDComboBox";
            this.keyinIDComboBox.Size = new System.Drawing.Size(116, 24);
            this.keyinIDComboBox.TabIndex = 50;
            this.keyinIDComboBox.ValueMember = "OperatorID";
            // 
            // operatorBindingSource
            // 
            this.operatorBindingSource.DataMember = "Operator";
            this.operatorBindingSource.DataSource = this.vEDataSet1;
            // 
            // vEDataSet1
            // 
            this.vEDataSet1.DataSetName = "VEDataSet";
            this.vEDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // operatorTableAdapter
            // 
            this.operatorTableAdapter.ClearBeforeFill = true;
            // 
            // columnDetailID
            // 
            this.columnDetailID.DataPropertyName = "ID";
            this.columnDetailID.HeaderText = "ID";
            this.columnDetailID.Name = "columnDetailID";
            this.columnDetailID.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "EmployeeID";
            this.dataGridViewTextBoxColumn4.HeaderText = "員工內碼";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 2;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 2;
            // 
            // columnApproved
            // 
            this.columnApproved.DataPropertyName = "Approved";
            this.columnApproved.HeaderText = "核";
            this.columnApproved.Name = "columnApproved";
            this.columnApproved.Width = 48;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Data";
            this.dataGridViewTextBoxColumn5.HeaderText = "內容";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 400;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "EffectiveDate";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn6.HeaderText = "生效日";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "AppliedID";
            this.dataGridViewTextBoxColumn7.HeaderText = "申請者";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ApprovedID";
            this.dataGridViewTextBoxColumn8.HeaderText = "核可";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "LastUpdated";
            this.dataGridViewTextBoxColumn9.HeaderText = "更新";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // FormHR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(961, 794);
            this.Controls.Add(this.keyinIDComboBox);
            this.Controls.Add(bankAccoutLabel);
            this.Controls.Add(this.bankAccoutTextBox);
            this.Controls.Add(this.apartmentIDComboBox);
            this.Controls.Add(this.btnPhoto);
            this.Controls.Add(this.photoPictureBox);
            this.Controls.Add(this.hRDetailDataGridView);
            this.Controls.Add(this.lastUpdatedTextBox);
            this.Controls.Add(fingerPintNoLabel);
            this.Controls.Add(this.fingerPintNoTextBox);
            this.Controls.Add(employeeIDLabel);
            this.Controls.Add(this.employeeIDTextBox);
            this.Controls.Add(employeeCodeLabel);
            this.Controls.Add(this.employeeCodeTextBox);
            this.Controls.Add(employeeNameLabel);
            this.Controls.Add(this.employeeNameTextBox);
            this.Controls.Add(apartmentIDLabel);
            this.Controls.Add(this.isManagerCheckBox);
            this.Controls.Add(this.inPositionCheckBox);
            this.Controls.Add(idNoLabel);
            this.Controls.Add(this.idNoTextBox);
            this.Controls.Add(birthdayLabel);
            this.Controls.Add(this.birthdayDateTimePicker);
            this.Controls.Add(marriageLabel);
            this.Controls.Add(this.marriageTextBox);
            this.Controls.Add(this.bloodTypeTextBox);
            this.Controls.Add(telphoneLabel);
            this.Controls.Add(this.telphoneTextBox);
            this.Controls.Add(mobileLabel);
            this.Controls.Add(this.mobileTextBox);
            this.Controls.Add(this.genderTextBox);
            this.Controls.Add(addressLabel);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(educationLabel);
            this.Controls.Add(this.educationTextBox);
            this.Controls.Add(titleLabel);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(contactLabel);
            this.Controls.Add(this.contactTextBox);
            this.Controls.Add(emergencyTelLabel);
            this.Controls.Add(this.emergencyTelTextBox);
            this.Controls.Add(lastUpdatedLabel);
            this.Controls.Add(keyinIDLabel);
            this.Controls.Add(this.hRDataGridView);
            this.Controls.Add(this.hRBindingNavigator);
            this.Controls.Add(bloodTypeLabel);
            this.Controls.Add(genderLabel);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormHR";
            this.Text = "人事資料卡";
            this.Load += new System.EventHandler(this.FormHR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hRBindingNavigator)).EndInit();
            this.hRBindingNavigator.ResumeLayout(false);
            this.hRBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hRDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hRDetailDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hRHRDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource hRBindingSource;
        private VEDataSetTableAdapters.HRTableAdapter hRTableAdapter;
        private System.Windows.Forms.BindingNavigator hRBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton hRBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView hRDataGridView;
        private System.Windows.Forms.TextBox employeeIDTextBox;
        private System.Windows.Forms.TextBox employeeCodeTextBox;
        private System.Windows.Forms.TextBox employeeNameTextBox;
        private System.Windows.Forms.CheckBox isManagerCheckBox;
        private System.Windows.Forms.CheckBox inPositionCheckBox;
        private System.Windows.Forms.TextBox idNoTextBox;
        private System.Windows.Forms.DateTimePicker birthdayDateTimePicker;
        private System.Windows.Forms.TextBox marriageTextBox;
        private System.Windows.Forms.TextBox bloodTypeTextBox;
        private System.Windows.Forms.TextBox telphoneTextBox;
        private System.Windows.Forms.TextBox mobileTextBox;
        private System.Windows.Forms.TextBox genderTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.TextBox educationTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox contactTextBox;
        private System.Windows.Forms.TextBox emergencyTelTextBox;
        private System.Windows.Forms.TextBox fingerPintNoTextBox;
        private System.Windows.Forms.TextBox lastUpdatedTextBox;
        private VEDataSetTableAdapters.HRDetailTableAdapter hRDetailTableAdapter;
        private System.Windows.Forms.DataGridView hRDetailDataGridView;
        private System.Windows.Forms.BindingSource hRHRDetailBindingSource;
        private System.Windows.Forms.BindingSource apartmentBindingSource;
        private VEDataSetTableAdapters.ApartmentTableAdapter apartmentTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnEmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewComboBoxColumn ApartmentID;
        private System.Windows.Forms.PictureBox photoPictureBox;
        private System.Windows.Forms.Button btnPhoto;
        private System.Windows.Forms.ComboBox apartmentIDComboBox;
        private System.Windows.Forms.TextBox bankAccoutTextBox;
        private System.Windows.Forms.ComboBox keyinIDComboBox;
        private VEDataSet vEDataSet1;
        private System.Windows.Forms.BindingSource operatorBindingSource;
        private VEDataSetTableAdapters.OperatorTableAdapter operatorTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnApproved;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}