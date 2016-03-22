namespace VoucherExpense
{
    partial class FormShipment
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
            System.Windows.Forms.Label iDLabel;
            System.Windows.Forms.Label lastUpdatedLabel;
            System.Windows.Forms.Label removedLabel;
            System.Windows.Forms.Label costLabel;
            System.Windows.Forms.Label shipCodeLabel;
            System.Windows.Forms.Label shipTimeLabel;
            System.Windows.Forms.Label supplierLabel;
            System.Windows.Forms.Label productClassLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShipment));
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.shipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.damaiDataSet = new VoucherExpense.DamaiDataSet();
            this.operatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.iDLabel1 = new System.Windows.Forms.Label();
            this.lastUpdatedLabel1 = new System.Windows.Forms.Label();
            this.checkedCheckBox = new System.Windows.Forms.CheckBox();
            this.removedCheckBox = new System.Windows.Forms.CheckBox();
            this.shipmentDetailDataGridView = new System.Windows.Forms.DataGridView();
            this.detailColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnProductID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvColumnVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvCostColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipmentDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountingTitleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.costTextBox = new System.Windows.Forms.TextBox();
            this.shipCodeTextBox = new System.Windows.Forms.TextBox();
            this.shipTimeTextBox = new System.Windows.Forms.TextBox();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shipmentDataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Removed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.shipCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.shipmentBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.shipmentBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pD = new System.Drawing.Printing.PrintDocument();
            this.apartmentTableAdapter = new VoucherExpense.DamaiDataSetTableAdapters.ApartmentTableAdapter();
            this.shipmentTableAdapter1 = new VoucherExpense.DamaiDataSetTableAdapters.ShipmentTableAdapter();
            this.operatorTableAdapter1 = new VoucherExpense.DamaiDataSetTableAdapters.OperatorTableAdapter();
            this.accountingTitleTableAdapter1 = new VoucherExpense.DamaiDataSetTableAdapters.AccountingTitleTableAdapter();
            this.customerTableAdapter1 = new VoucherExpense.DamaiDataSetTableAdapters.CustomerTableAdapter();
            this.productTableAdapter1 = new VoucherExpense.DamaiDataSetTableAdapters.ProductTableAdapter();
            this.shipmentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipmentDetailTableAdapter1 = new VoucherExpense.DamaiDataSetTableAdapters.ShipmentDetailTableAdapter();
            this.productBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.productClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productClassTableAdapter = new VoucherExpense.DamaiDataSetTableAdapters.ProductClassTableAdapter();
            this.productClassComboBox = new System.Windows.Forms.ComboBox();
            this.checkedLabel = new System.Windows.Forms.Label();
            this.checkedIDLabel = new System.Windows.Forms.Label();
            this.keyinIDLabel = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            iDLabel = new System.Windows.Forms.Label();
            lastUpdatedLabel = new System.Windows.Forms.Label();
            removedLabel = new System.Windows.Forms.Label();
            costLabel = new System.Windows.Forms.Label();
            shipCodeLabel = new System.Windows.Forms.Label();
            shipTimeLabel = new System.Windows.Forms.Label();
            supplierLabel = new System.Windows.Forms.Label();
            productClassLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDetailDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentBindingNavigator)).BeginInit();
            this.shipmentBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productClassBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iDLabel
            // 
            iDLabel.AutoSize = true;
            iDLabel.Location = new System.Drawing.Point(726, 56);
            iDLabel.Name = "iDLabel";
            iDLabel.Size = new System.Drawing.Size(44, 16);
            iDLabel.TabIndex = 73;
            iDLabel.Text = "顺序:";
            // 
            // lastUpdatedLabel
            // 
            lastUpdatedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            lastUpdatedLabel.AutoSize = true;
            lastUpdatedLabel.Location = new System.Drawing.Point(474, 687);
            lastUpdatedLabel.Name = "lastUpdatedLabel";
            lastUpdatedLabel.Size = new System.Drawing.Size(44, 16);
            lastUpdatedLabel.TabIndex = 72;
            lastUpdatedLabel.Text = "更新:";
            // 
            // removedLabel
            // 
            removedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            removedLabel.AutoSize = true;
            removedLabel.Location = new System.Drawing.Point(474, 625);
            removedLabel.Name = "removedLabel";
            removedLabel.Size = new System.Drawing.Size(44, 16);
            removedLabel.TabIndex = 68;
            removedLabel.Text = "废除:";
            // 
            // costLabel
            // 
            costLabel.AutoSize = true;
            costLabel.Location = new System.Drawing.Point(484, 115);
            costLabel.Name = "costLabel";
            costLabel.Size = new System.Drawing.Size(60, 16);
            costLabel.TabIndex = 66;
            costLabel.Text = "总金额:";
            // 
            // shipCodeLabel
            // 
            shipCodeLabel.AutoSize = true;
            shipCodeLabel.Location = new System.Drawing.Point(727, 84);
            shipCodeLabel.Name = "shipCodeLabel";
            shipCodeLabel.Size = new System.Drawing.Size(60, 16);
            shipCodeLabel.TabIndex = 64;
            shipCodeLabel.Text = "凭证号:";
            // 
            // shipTimeLabel
            // 
            shipTimeLabel.AutoSize = true;
            shipTimeLabel.Location = new System.Drawing.Point(484, 84);
            shipTimeLabel.Name = "shipTimeLabel";
            shipTimeLabel.Size = new System.Drawing.Size(76, 16);
            shipTimeLabel.TabIndex = 62;
            shipTimeLabel.Text = "出货时间:";
            // 
            // supplierLabel
            // 
            supplierLabel.AutoSize = true;
            supplierLabel.Location = new System.Drawing.Point(484, 56);
            supplierLabel.Name = "supplierLabel";
            supplierLabel.Size = new System.Drawing.Size(44, 16);
            supplierLabel.TabIndex = 60;
            supplierLabel.Text = "客户:";
            // 
            // productClassLabel
            // 
            productClassLabel.AutoSize = true;
            productClassLabel.Location = new System.Drawing.Point(16, 52);
            productClassLabel.Name = "productClassLabel";
            productClassLabel.Size = new System.Drawing.Size(60, 16);
            productClassLabel.TabIndex = 82;
            productClassLabel.Text = "出货类:";
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.shipmentBindingSource, "CheckedID", true));
            this.comboBox2.DataSource = this.operatorBindingSource;
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.DropDownHeight = 1;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.IntegralHeight = false;
            this.comboBox2.Location = new System.Drawing.Point(783, 651);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(106, 24);
            this.comboBox2.TabIndex = 82;
            this.comboBox2.ValueMember = "OperatorID";
            // 
            // shipmentBindingSource
            // 
            this.shipmentBindingSource.DataMember = "Shipment";
            this.shipmentBindingSource.DataSource = this.damaiDataSet;
            // 
            // damaiDataSet
            // 
            this.damaiDataSet.DataSetName = "932";
            this.damaiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // operatorBindingSource
            // 
            this.operatorBindingSource.DataMember = "Operator";
            this.operatorBindingSource.DataSource = this.damaiDataSet;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.shipmentBindingSource, "KeyinID", true));
            this.comboBox1.DataSource = this.operatorBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.DropDownHeight = 1;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Location = new System.Drawing.Point(533, 651);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(106, 24);
            this.comboBox1.TabIndex = 81;
            this.comboBox1.ValueMember = "OperatorID";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(673, 79);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(17, 27);
            this.dateTimePicker1.TabIndex = 80;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
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
            this.comboBoxMonth.Location = new System.Drawing.Point(444, 0);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(86, 24);
            this.comboBoxMonth.TabIndex = 79;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // iDLabel1
            // 
            this.iDLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shipmentBindingSource, "ID", true));
            this.iDLabel1.Location = new System.Drawing.Point(790, 53);
            this.iDLabel1.Name = "iDLabel1";
            this.iDLabel1.Size = new System.Drawing.Size(103, 23);
            this.iDLabel1.TabIndex = 75;
            // 
            // lastUpdatedLabel1
            // 
            this.lastUpdatedLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lastUpdatedLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shipmentBindingSource, "LastUpdated", true));
            this.lastUpdatedLabel1.Location = new System.Drawing.Point(521, 687);
            this.lastUpdatedLabel1.Name = "lastUpdatedLabel1";
            this.lastUpdatedLabel1.Size = new System.Drawing.Size(137, 23);
            this.lastUpdatedLabel1.TabIndex = 74;
            // 
            // checkedCheckBox
            // 
            this.checkedCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.shipmentBindingSource, "Checked", true));
            this.checkedCheckBox.Enabled = false;
            this.checkedCheckBox.Location = new System.Drawing.Point(783, 619);
            this.checkedCheckBox.Name = "checkedCheckBox";
            this.checkedCheckBox.Size = new System.Drawing.Size(20, 24);
            this.checkedCheckBox.TabIndex = 71;
            this.checkedCheckBox.UseVisualStyleBackColor = true;
            this.checkedCheckBox.CheckedChanged += new System.EventHandler(this.checkedCheckBox_CheckedChanged);
            this.checkedCheckBox.Click += new System.EventHandler(this.checkedCheckBox_Click);
            // 
            // removedCheckBox
            // 
            this.removedCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.shipmentBindingSource, "Removed", true));
            this.removedCheckBox.Location = new System.Drawing.Point(556, 619);
            this.removedCheckBox.Name = "removedCheckBox";
            this.removedCheckBox.Size = new System.Drawing.Size(16, 24);
            this.removedCheckBox.TabIndex = 69;
            this.removedCheckBox.UseVisualStyleBackColor = true;
            this.removedCheckBox.CheckedChanged += new System.EventHandler(this.removedCheckBox_CheckedChanged);
            // 
            // shipmentDetailDataGridView
            // 
            this.shipmentDetailDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.shipmentDetailDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.shipmentDetailDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shipmentDetailDataGridView.AutoGenerateColumns = false;
            this.shipmentDetailDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.shipmentDetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.shipmentDetailDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.detailColumnID,
            this.dgvColumnProductID,
            this.dgvColumnVolume,
            this.ProductID,
            this.dgvCostColumn});
            this.shipmentDetailDataGridView.DataSource = this.shipmentDetailBindingSource;
            this.shipmentDetailDataGridView.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.shipmentDetailDataGridView.Location = new System.Drawing.Point(445, 154);
            this.shipmentDetailDataGridView.Name = "shipmentDetailDataGridView";
            this.shipmentDetailDataGridView.RowHeadersWidth = 25;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.shipmentDetailDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.shipmentDetailDataGridView.RowTemplate.Height = 23;
            this.shipmentDetailDataGridView.Size = new System.Drawing.Size(494, 456);
            this.shipmentDetailDataGridView.TabIndex = 77;
            this.shipmentDetailDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.shipmentDetailDataGridView_CellValueChanged);
            this.shipmentDetailDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.shipmentDetailDataGridView_DataError_1);
            this.shipmentDetailDataGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.shipmentDetailDataGridView_DefaultValuesNeeded);
            // 
            // detailColumnID
            // 
            this.detailColumnID.DataPropertyName = "ID";
            this.detailColumnID.HeaderText = "ID";
            this.detailColumnID.Name = "detailColumnID";
            this.detailColumnID.Visible = false;
            // 
            // dgvColumnProductID
            // 
            this.dgvColumnProductID.DataPropertyName = "ProductID";
            this.dgvColumnProductID.DataSource = this.productBindingSource;
            this.dgvColumnProductID.DisplayMember = "Name";
            this.dgvColumnProductID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dgvColumnProductID.HeaderText = "产品";
            this.dgvColumnProductID.Name = "dgvColumnProductID";
            this.dgvColumnProductID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColumnProductID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvColumnProductID.ValueMember = "ProductID";
            this.dgvColumnProductID.Width = 160;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.damaiDataSet;
            this.productBindingSource.Filter = "Code>0";
            this.productBindingSource.Sort = "Code asc";
            // 
            // dgvColumnVolume
            // 
            this.dgvColumnVolume.DataPropertyName = "Volume";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvColumnVolume.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvColumnVolume.HeaderText = "数量";
            this.dgvColumnVolume.Name = "dgvColumnVolume";
            this.dgvColumnVolume.Width = 80;
            // 
            // ProductID
            // 
            this.ProductID.DataPropertyName = "ProductID";
            this.ProductID.DataSource = this.productBindingSource;
            this.ProductID.DisplayMember = "Unit";
            this.ProductID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ProductID.HeaderText = "";
            this.ProductID.Name = "ProductID";
            this.ProductID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ProductID.ValueMember = "ProductID";
            this.ProductID.Width = 50;
            // 
            // dgvCostColumn
            // 
            this.dgvCostColumn.DataPropertyName = "Cost";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.dgvCostColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCostColumn.HeaderText = "金额";
            this.dgvCostColumn.Name = "dgvCostColumn";
            this.dgvCostColumn.Width = 150;
            // 
            // shipmentDetailBindingSource
            // 
            this.shipmentDetailBindingSource.DataMember = "FK_ShipmentDetail_Shipment";
            this.shipmentDetailBindingSource.DataSource = this.shipmentBindingSource;
            // 
            // accountingTitleBindingSource
            // 
            this.accountingTitleBindingSource.DataMember = "AccountingTitle";
            this.accountingTitleBindingSource.DataSource = this.damaiDataSet;
            // 
            // costTextBox
            // 
            this.costTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shipmentBindingSource, "Cost", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.costTextBox.Location = new System.Drawing.Point(566, 111);
            this.costTextBox.Name = "costTextBox";
            this.costTextBox.ReadOnly = true;
            this.costTextBox.Size = new System.Drawing.Size(123, 27);
            this.costTextBox.TabIndex = 67;
            this.costTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // shipCodeTextBox
            // 
            this.shipCodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shipmentBindingSource, "ShipCode", true));
            this.shipCodeTextBox.Location = new System.Drawing.Point(793, 79);
            this.shipCodeTextBox.Name = "shipCodeTextBox";
            this.shipCodeTextBox.ReadOnly = true;
            this.shipCodeTextBox.Size = new System.Drawing.Size(111, 27);
            this.shipCodeTextBox.TabIndex = 65;
            this.shipCodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // shipTimeTextBox
            // 
            this.shipTimeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shipmentBindingSource, "ShipTime", true));
            this.shipTimeTextBox.Location = new System.Drawing.Point(566, 79);
            this.shipTimeTextBox.Name = "shipTimeTextBox";
            this.shipTimeTextBox.Size = new System.Drawing.Size(110, 27);
            this.shipTimeTextBox.TabIndex = 63;
            this.shipTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // customerComboBox
            // 
            this.customerComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.shipmentBindingSource, "Customer", true));
            this.customerComboBox.DataSource = this.customerBindingSource;
            this.customerComboBox.DisplayMember = "Name";
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(565, 50);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(124, 24);
            this.customerComboBox.TabIndex = 61;
            this.customerComboBox.ValueMember = "CustomerID";
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataMember = "Customer";
            this.customerBindingSource.DataSource = this.damaiDataSet;
            // 
            // shipmentDataGridView
            // 
            this.shipmentDataGridView.AllowUserToAddRows = false;
            this.shipmentDataGridView.AllowUserToDeleteRows = false;
            this.shipmentDataGridView.AllowUserToOrderColumns = true;
            this.shipmentDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Azure;
            this.shipmentDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.shipmentDataGridView.AutoGenerateColumns = false;
            this.shipmentDataGridView.BackgroundColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("新細明體", 12F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.shipmentDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.shipmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.shipmentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.Removed,
            this.shipCodeDataGridViewTextBoxColumn,
            this.customerDataGridViewTextBoxColumn,
            this.costDataGridViewTextBoxColumn,
            this.shipTimeDataGridViewTextBoxColumn,
            this.Checked});
            this.shipmentDataGridView.DataSource = this.shipmentBindingSource;
            this.shipmentDataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.shipmentDataGridView.EnableHeadersVisualStyles = false;
            this.shipmentDataGridView.Location = new System.Drawing.Point(0, 0);
            this.shipmentDataGridView.Name = "shipmentDataGridView";
            this.shipmentDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.shipmentDataGridView.RowHeadersVisible = false;
            this.shipmentDataGridView.RowHeadersWidth = 25;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.shipmentDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.shipmentDataGridView.RowTemplate.Height = 23;
            this.shipmentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.shipmentDataGridView.Size = new System.Drawing.Size(444, 718);
            this.shipmentDataGridView.TabIndex = 59;
            this.shipmentDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.shipmentDataGridView_DataError);
            this.shipmentDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.shipmentDataGridView_RowEnter);
            this.shipmentDataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.shipmentDataGridView_RowPrePaint);
            // 
            // ColumnID
            // 
            this.ColumnID.DataPropertyName = "ID";
            this.ColumnID.HeaderText = "顺序";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Width = 50;
            // 
            // Removed
            // 
            this.Removed.DataPropertyName = "Removed";
            this.Removed.HeaderText = "废除";
            this.Removed.Name = "Removed";
            this.Removed.Visible = false;
            // 
            // shipCodeDataGridViewTextBoxColumn
            // 
            this.shipCodeDataGridViewTextBoxColumn.DataPropertyName = "ShipCode";
            this.shipCodeDataGridViewTextBoxColumn.HeaderText = "凭证号";
            this.shipCodeDataGridViewTextBoxColumn.Name = "shipCodeDataGridViewTextBoxColumn";
            this.shipCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.shipCodeDataGridViewTextBoxColumn.Width = 70;
            // 
            // customerDataGridViewTextBoxColumn
            // 
            this.customerDataGridViewTextBoxColumn.DataPropertyName = "Customer";
            this.customerDataGridViewTextBoxColumn.DataSource = this.customerBindingSource;
            this.customerDataGridViewTextBoxColumn.DisplayMember = "Name";
            this.customerDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.customerDataGridViewTextBoxColumn.HeaderText = "客户";
            this.customerDataGridViewTextBoxColumn.Name = "customerDataGridViewTextBoxColumn";
            this.customerDataGridViewTextBoxColumn.ReadOnly = true;
            this.customerDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.customerDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.customerDataGridViewTextBoxColumn.ValueMember = "CustomerID";
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.costDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.costDataGridViewTextBoxColumn.HeaderText = "总计";
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            this.costDataGridViewTextBoxColumn.ReadOnly = true;
            this.costDataGridViewTextBoxColumn.Width = 90;
            // 
            // shipTimeDataGridViewTextBoxColumn
            // 
            this.shipTimeDataGridViewTextBoxColumn.DataPropertyName = "ShipTime";
            this.shipTimeDataGridViewTextBoxColumn.HeaderText = "出货时间";
            this.shipTimeDataGridViewTextBoxColumn.Name = "shipTimeDataGridViewTextBoxColumn";
            this.shipTimeDataGridViewTextBoxColumn.Width = 90;
            // 
            // Checked
            // 
            this.Checked.DataPropertyName = "Checked";
            this.Checked.HeaderText = "核";
            this.Checked.Name = "Checked";
            this.Checked.Width = 30;
            // 
            // shipmentBindingNavigator
            // 
            this.shipmentBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.shipmentBindingNavigator.BackgroundImage = global::VoucherExpense.Properties.Resources.NavBar_Back;
            this.shipmentBindingNavigator.BindingSource = this.shipmentBindingSource;
            this.shipmentBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.shipmentBindingNavigator.DeleteItem = null;
            this.shipmentBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.shipmentBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.shipmentBindingNavigatorSaveItem,
            this.toolStripSeparator1,
            this.tsbtPrint,
            this.toolStripSeparator2});
            this.shipmentBindingNavigator.Location = new System.Drawing.Point(533, 0);
            this.shipmentBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.shipmentBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.shipmentBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.shipmentBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.shipmentBindingNavigator.Name = "shipmentBindingNavigator";
            this.shipmentBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.shipmentBindingNavigator.Size = new System.Drawing.Size(330, 25);
            this.shipmentBindingNavigator.TabIndex = 58;
            this.shipmentBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "新添";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(27, 22);
            this.bindingNavigatorCountItem.Text = "/{0}";
            this.bindingNavigatorCountItem.ToolTipText = "总项数";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "移到第一条记录";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一条记录";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "当前位置";
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
            this.bindingNavigatorMoveNextItem.Text = "移到下一条记录";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "移到最后一条记录";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // shipmentBindingNavigatorSaveItem
            // 
            this.shipmentBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.shipmentBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("shipmentBindingNavigatorSaveItem.Image")));
            this.shipmentBindingNavigatorSaveItem.Name = "shipmentBindingNavigatorSaveItem";
            this.shipmentBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.shipmentBindingNavigatorSaveItem.Text = "保存数据";
            this.shipmentBindingNavigatorSaveItem.Click += new System.EventHandler(this.shipmentBindingNavigatorSaveItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtPrint
            // 
            this.tsbtPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbtPrint.Image")));
            this.tsbtPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtPrint.Name = "tsbtPrint";
            this.tsbtPrint.Size = new System.Drawing.Size(71, 22);
            this.tsbtPrint.Text = "出货单打印";
            this.tsbtPrint.Click += new System.EventHandler(this.tsbtPrint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // apartmentTableAdapter
            // 
            this.apartmentTableAdapter.ClearBeforeFill = true;
            // 
            // shipmentTableAdapter1
            // 
            this.shipmentTableAdapter1.ClearBeforeFill = true;
            // 
            // operatorTableAdapter1
            // 
            this.operatorTableAdapter1.ClearBeforeFill = true;
            // 
            // accountingTitleTableAdapter1
            // 
            this.accountingTitleTableAdapter1.ClearBeforeFill = true;
            // 
            // customerTableAdapter1
            // 
            this.customerTableAdapter1.ClearBeforeFill = true;
            // 
            // productTableAdapter1
            // 
            this.productTableAdapter1.ClearBeforeFill = true;
            // 
            // shipmentIDDataGridViewTextBoxColumn
            // 
            this.shipmentIDDataGridViewTextBoxColumn.DataPropertyName = "ShipmentID";
            this.shipmentIDDataGridViewTextBoxColumn.HeaderText = "ShipmentID";
            this.shipmentIDDataGridViewTextBoxColumn.Name = "shipmentIDDataGridViewTextBoxColumn";
            this.shipmentIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // shipmentDetailTableAdapter1
            // 
            this.shipmentDetailTableAdapter1.ClearBeforeFill = true;
            // 
            // productClassBindingSource
            // 
            this.productClassBindingSource.DataMember = "ProductClass";
            this.productClassBindingSource.DataSource = this.damaiDataSet;
            this.productClassBindingSource.Filter = "ID>0";
            this.productClassBindingSource.Sort = "ID  asc";
            // 
            // productClassTableAdapter
            // 
            this.productClassTableAdapter.ClearBeforeFill = true;
            // 
            // productClassComboBox
            // 
            this.productClassComboBox.DataSource = this.productClassBindingSource;
            this.productClassComboBox.DisplayMember = "ProductClass";
            this.productClassComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.productClassComboBox.FormattingEnabled = true;
            this.productClassComboBox.Location = new System.Drawing.Point(82, 49);
            this.productClassComboBox.Name = "productClassComboBox";
            this.productClassComboBox.Size = new System.Drawing.Size(111, 24);
            this.productClassComboBox.TabIndex = 83;
            this.productClassComboBox.ValueMember = "ID";
            this.productClassComboBox.SelectedValueChanged += new System.EventHandler(this.productClassComboBox_SelectedValueChanged);
            // 
            // checkedLabel
            // 
            this.checkedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedLabel.AutoSize = true;
            this.checkedLabel.Location = new System.Drawing.Point(737, 625);
            this.checkedLabel.Name = "checkedLabel";
            this.checkedLabel.Size = new System.Drawing.Size(40, 16);
            this.checkedLabel.TabIndex = 84;
            this.checkedLabel.Text = "核：";
            // 
            // checkedIDLabel
            // 
            this.checkedIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedIDLabel.AutoSize = true;
            this.checkedIDLabel.Location = new System.Drawing.Point(705, 654);
            this.checkedIDLabel.Name = "checkedIDLabel";
            this.checkedIDLabel.Size = new System.Drawing.Size(72, 16);
            this.checkedIDLabel.TabIndex = 85;
            this.checkedIDLabel.Text = "审核人：";
            // 
            // keyinIDLabel
            // 
            this.keyinIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.keyinIDLabel.AutoSize = true;
            this.keyinIDLabel.Location = new System.Drawing.Point(456, 654);
            this.keyinIDLabel.Name = "keyinIDLabel";
            this.keyinIDLabel.Size = new System.Drawing.Size(72, 16);
            this.keyinIDLabel.TabIndex = 86;
            this.keyinIDLabel.Text = "输入人：";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.printDocument1.QueryPageSettings += new System.Drawing.Printing.QueryPageSettingsEventHandler(this.printDocument1_QueryPageSettings);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btOK);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(productClassLabel);
            this.panel1.Controls.Add(this.productClassComboBox);
            this.panel1.Location = new System.Drawing.Point(322, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 145);
            this.panel1.TabIndex = 87;
            this.panel1.Visible = false;
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(82, 95);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 28);
            this.btOK.TabIndex = 85;
            this.btOK.Text = "确定";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 84;
            this.label1.Text = "请选择出货分类";
            // 
            // FormShipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(938, 718);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.keyinIDLabel);
            this.Controls.Add(this.checkedIDLabel);
            this.Controls.Add(this.checkedLabel);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(iDLabel);
            this.Controls.Add(this.iDLabel1);
            this.Controls.Add(lastUpdatedLabel);
            this.Controls.Add(this.lastUpdatedLabel1);
            this.Controls.Add(this.checkedCheckBox);
            this.Controls.Add(removedLabel);
            this.Controls.Add(this.removedCheckBox);
            this.Controls.Add(this.shipmentDetailDataGridView);
            this.Controls.Add(costLabel);
            this.Controls.Add(this.costTextBox);
            this.Controls.Add(shipCodeLabel);
            this.Controls.Add(this.shipCodeTextBox);
            this.Controls.Add(shipTimeLabel);
            this.Controls.Add(this.shipTimeTextBox);
            this.Controls.Add(supplierLabel);
            this.Controls.Add(this.customerComboBox);
            this.Controls.Add(this.shipmentDataGridView);
            this.Controls.Add(this.shipmentBindingNavigator);
            this.Font = new System.Drawing.Font("新細明體", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormShipment";
            this.Text = "出货";
            this.Load += new System.EventHandler(this.FormShipment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.shipmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDetailDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentBindingNavigator)).EndInit();
            this.shipmentBindingNavigator.ResumeLayout(false);
            this.shipmentBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productClassBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.Label iDLabel1;
        private System.Windows.Forms.Label lastUpdatedLabel1;
        private System.Windows.Forms.CheckBox checkedCheckBox;
        private System.Windows.Forms.CheckBox removedCheckBox;
        private System.Windows.Forms.DataGridView shipmentDetailDataGridView;
        private System.Windows.Forms.TextBox costTextBox;
        private System.Windows.Forms.TextBox shipCodeTextBox;
        private System.Windows.Forms.TextBox shipTimeTextBox;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.DataGridView shipmentDataGridView;
        private System.Windows.Forms.BindingNavigator shipmentBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton shipmentBindingNavigatorSaveItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.BindingSource shipmentBindingSource;
        private System.Windows.Forms.BindingSource shipmentDetailBindingSource;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.BindingSource accountingTitleBindingSource;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private System.Windows.Forms.BindingSource operatorBindingSource;
        private System.Drawing.Printing.PrintDocument pD;
        private DamaiDataSetTableAdapters.ApartmentTableAdapter apartmentTableAdapter;
        private DamaiDataSet damaiDataSet;
        private DamaiDataSetTableAdapters.ShipmentTableAdapter shipmentTableAdapter1;
        private DamaiDataSetTableAdapters.OperatorTableAdapter operatorTableAdapter1;
        private DamaiDataSetTableAdapters.AccountingTitleTableAdapter accountingTitleTableAdapter1;
        private DamaiDataSetTableAdapters.CustomerTableAdapter customerTableAdapter1;
        private DamaiDataSetTableAdapters.ProductTableAdapter productTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipmentIDDataGridViewTextBoxColumn;
        private DamaiDataSetTableAdapters.ShipmentDetailTableAdapter shipmentDetailTableAdapter1;
        private System.Windows.Forms.BindingSource productBindingSource1;
        private System.Windows.Forms.BindingSource productClassBindingSource;
        private DamaiDataSetTableAdapters.ProductClassTableAdapter productClassTableAdapter;
        private System.Windows.Forms.ComboBox productClassComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn detailColumnID;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColumnProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnVolume;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCostColumn;
        private System.Windows.Forms.Label checkedLabel;
        private System.Windows.Forms.Label checkedIDLabel;
        private System.Windows.Forms.Label keyinIDLabel;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Removed;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn customerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Checked;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Label label1;
    }
}