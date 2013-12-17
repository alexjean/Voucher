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
            System.Windows.Forms.Label keyinIDLabel;
            System.Windows.Forms.Label checkedIDLabel;
            System.Windows.Forms.Label iDLabel;
            System.Windows.Forms.Label lastUpdatedLabel;
            System.Windows.Forms.Label checkedLabel;
            System.Windows.Forms.Label removedLabel;
            System.Windows.Forms.Label costLabel;
            System.Windows.Forms.Label shipCodeLabel;
            System.Windows.Forms.Label shipTimeLabel;
            System.Windows.Forms.Label supplierLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShipment));
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.shipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sQLVEDataSet = new VoucherExpense.SQLVEDataSet();
            this.operatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.iDLabel1 = new System.Windows.Forms.Label();
            this.lastUpdatedLabel1 = new System.Windows.Forms.Label();
            this.checkedCheckBox = new System.Windows.Forms.CheckBox();
            this.removedCheckBox = new System.Windows.Forms.CheckBox();
            this.shipmentDetailDataGridView = new System.Windows.Forms.DataGridView();
            this.detailColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipmentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnProductID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bakeryOrderSet = new VoucherExpense.BakeryOrderSet();
            this.dgvColumnVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvCostColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnTitleCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.accountingTitleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shipmentDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.costTextBox = new System.Windows.Forms.TextBox();
            this.shipCodeTextBox = new System.Windows.Forms.TextBox();
            this.shipTimeTextBox = new System.Windows.Forms.TextBox();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shipmentDataGridView = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Removed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.shipCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.shipmentTableAdapter = new VoucherExpense.SQLVEDataSetTableAdapters.ShipmentTableAdapter();
            this.tableAdapterManager = new VoucherExpense.SQLVEDataSetTableAdapters.TableAdapterManager();
            this.customerTableAdapter = new VoucherExpense.SQLVEDataSetTableAdapters.CustomerTableAdapter();
            this.shipmentDetailTableAdapter = new VoucherExpense.SQLVEDataSetTableAdapters.ShipmentDetailTableAdapter();
            this.productTableAdapter = new VoucherExpense.BakeryOrderSetTableAdapters.ProductTableAdapter();
            this.accountingTitleTableAdapter = new VoucherExpense.VEDataSetTableAdapters.AccountingTitleTableAdapter();
            this.operatorTableAdapter = new VoucherExpense.VEDataSetTableAdapters.OperatorTableAdapter();
            this.pD = new System.Drawing.Printing.PrintDocument();
            keyinIDLabel = new System.Windows.Forms.Label();
            checkedIDLabel = new System.Windows.Forms.Label();
            iDLabel = new System.Windows.Forms.Label();
            lastUpdatedLabel = new System.Windows.Forms.Label();
            checkedLabel = new System.Windows.Forms.Label();
            removedLabel = new System.Windows.Forms.Label();
            costLabel = new System.Windows.Forms.Label();
            shipCodeLabel = new System.Windows.Forms.Label();
            shipTimeLabel = new System.Windows.Forms.Label();
            supplierLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLVEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDetailDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentBindingNavigator)).BeginInit();
            this.shipmentBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // keyinIDLabel
            // 
            keyinIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            keyinIDLabel.AutoSize = true;
            keyinIDLabel.Location = new System.Drawing.Point(474, 630);
            keyinIDLabel.Name = "keyinIDLabel";
            keyinIDLabel.Size = new System.Drawing.Size(44, 16);
            keyinIDLabel.TabIndex = 78;
            keyinIDLabel.Text = "输入:";
            // 
            // checkedIDLabel
            // 
            checkedIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            checkedIDLabel.AutoSize = true;
            checkedIDLabel.Location = new System.Drawing.Point(717, 630);
            checkedIDLabel.Name = "checkedIDLabel";
            checkedIDLabel.Size = new System.Drawing.Size(60, 16);
            checkedIDLabel.TabIndex = 76;
            checkedIDLabel.Text = "复核人:";
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
            lastUpdatedLabel.Location = new System.Drawing.Point(474, 663);
            lastUpdatedLabel.Name = "lastUpdatedLabel";
            lastUpdatedLabel.Size = new System.Drawing.Size(44, 16);
            lastUpdatedLabel.TabIndex = 72;
            lastUpdatedLabel.Text = "更新:";
            // 
            // checkedLabel
            // 
            checkedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            checkedLabel.AutoSize = true;
            checkedLabel.Location = new System.Drawing.Point(717, 601);
            checkedLabel.Name = "checkedLabel";
            checkedLabel.Size = new System.Drawing.Size(28, 16);
            checkedLabel.TabIndex = 70;
            checkedLabel.Text = "核:";
            // 
            // removedLabel
            // 
            removedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            removedLabel.AutoSize = true;
            removedLabel.Location = new System.Drawing.Point(474, 601);
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
            this.comboBox2.Location = new System.Drawing.Point(783, 627);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(106, 24);
            this.comboBox2.TabIndex = 82;
            this.comboBox2.ValueMember = "OperatorID";
            // 
            // shipmentBindingSource
            // 
            this.shipmentBindingSource.DataMember = "Shipment";
            this.shipmentBindingSource.DataSource = this.sQLVEDataSet;
            // 
            // sQLVEDataSet
            // 
            this.sQLVEDataSet.DataSetName = "SQLVEDataSet";
            this.sQLVEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.comboBox1.Location = new System.Drawing.Point(524, 627);
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
            this.lastUpdatedLabel1.Location = new System.Drawing.Point(521, 663);
            this.lastUpdatedLabel1.Name = "lastUpdatedLabel1";
            this.lastUpdatedLabel1.Size = new System.Drawing.Size(137, 23);
            this.lastUpdatedLabel1.TabIndex = 74;
            // 
            // checkedCheckBox
            // 
            this.checkedCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.shipmentBindingSource, "Checked", true));
            this.checkedCheckBox.Enabled = false;
            this.checkedCheckBox.Location = new System.Drawing.Point(783, 595);
            this.checkedCheckBox.Name = "checkedCheckBox";
            this.checkedCheckBox.Size = new System.Drawing.Size(20, 24);
            this.checkedCheckBox.TabIndex = 71;
            this.checkedCheckBox.UseVisualStyleBackColor = true;
            this.checkedCheckBox.CheckedChanged += new System.EventHandler(this.checkedCheckBox_CheckedChanged);
            // 
            // removedCheckBox
            // 
            this.removedCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.shipmentBindingSource, "Removed", true));
            this.removedCheckBox.Location = new System.Drawing.Point(556, 595);
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
            this.shipmentIDDataGridViewTextBoxColumn,
            this.dgvColumnProductID,
            this.dgvColumnVolume,
            this.ProductID,
            this.dgvCostColumn,
            this.dgvColumnTitleCode});
            this.shipmentDetailDataGridView.DataSource = this.shipmentDetailBindingSource;
            this.shipmentDetailDataGridView.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.shipmentDetailDataGridView.Location = new System.Drawing.Point(445, 154);
            this.shipmentDetailDataGridView.Name = "shipmentDetailDataGridView";
            this.shipmentDetailDataGridView.RowHeadersWidth = 25;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.shipmentDetailDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.shipmentDetailDataGridView.RowTemplate.Height = 23;
            this.shipmentDetailDataGridView.Size = new System.Drawing.Size(492, 432);
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
            // shipmentIDDataGridViewTextBoxColumn
            // 
            this.shipmentIDDataGridViewTextBoxColumn.DataPropertyName = "ShipmentID";
            this.shipmentIDDataGridViewTextBoxColumn.HeaderText = "ShipmentID";
            this.shipmentIDDataGridViewTextBoxColumn.Name = "shipmentIDDataGridViewTextBoxColumn";
            this.shipmentIDDataGridViewTextBoxColumn.Visible = false;
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
            this.dgvColumnProductID.Width = 140;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.bakeryOrderSet;
            this.productBindingSource.Filter = "Code>0";
            // 
            // bakeryOrderSet
            // 
            this.bakeryOrderSet.DataSetName = "BakeryOrderSet";
            this.bakeryOrderSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvColumnVolume
            // 
            this.dgvColumnVolume.DataPropertyName = "Volume";
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
            this.ProductID.Width = 40;
            // 
            // dgvCostColumn
            // 
            this.dgvCostColumn.DataPropertyName = "Cost";
            this.dgvCostColumn.HeaderText = "金额";
            this.dgvCostColumn.Name = "dgvCostColumn";
            // 
            // dgvColumnTitleCode
            // 
            this.dgvColumnTitleCode.DataPropertyName = "TitleCode";
            this.dgvColumnTitleCode.DataSource = this.accountingTitleBindingSource;
            this.dgvColumnTitleCode.DisplayMember = "Name";
            this.dgvColumnTitleCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dgvColumnTitleCode.HeaderText = "会计科目";
            this.dgvColumnTitleCode.Name = "dgvColumnTitleCode";
            this.dgvColumnTitleCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColumnTitleCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvColumnTitleCode.ValueMember = "TitleCode";
            // 
            // accountingTitleBindingSource
            // 
            this.accountingTitleBindingSource.DataMember = "AccountingTitle";
            this.accountingTitleBindingSource.DataSource = this.vEDataSet;
            // 
            // shipmentDetailBindingSource
            // 
            this.shipmentDetailBindingSource.DataMember = "FK_ShipmentDetail_Shipment";
            this.shipmentDetailBindingSource.DataSource = this.shipmentBindingSource;
            // 
            // costTextBox
            // 
            this.costTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shipmentBindingSource, "Cost", true));
            this.costTextBox.Location = new System.Drawing.Point(566, 111);
            this.costTextBox.Name = "costTextBox";
            this.costTextBox.Size = new System.Drawing.Size(123, 27);
            this.costTextBox.TabIndex = 67;
            // 
            // shipCodeTextBox
            // 
            this.shipCodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shipmentBindingSource, "ShipCode", true));
            this.shipCodeTextBox.Location = new System.Drawing.Point(793, 79);
            this.shipCodeTextBox.Name = "shipCodeTextBox";
            this.shipCodeTextBox.Size = new System.Drawing.Size(111, 27);
            this.shipCodeTextBox.TabIndex = 65;
            // 
            // shipTimeTextBox
            // 
            this.shipTimeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shipmentBindingSource, "ShipTime", true));
            this.shipTimeTextBox.Location = new System.Drawing.Point(566, 79);
            this.shipTimeTextBox.Name = "shipTimeTextBox";
            this.shipTimeTextBox.Size = new System.Drawing.Size(110, 27);
            this.shipTimeTextBox.TabIndex = 63;
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
            this.customerBindingSource.DataSource = this.sQLVEDataSet;
            // 
            // shipmentDataGridView
            // 
            this.shipmentDataGridView.AllowUserToAddRows = false;
            this.shipmentDataGridView.AllowUserToDeleteRows = false;
            this.shipmentDataGridView.AllowUserToOrderColumns = true;
            this.shipmentDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Azure;
            this.shipmentDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.shipmentDataGridView.AutoGenerateColumns = false;
            this.shipmentDataGridView.BackgroundColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("PMingLiU", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.shipmentDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.shipmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.shipmentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
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
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.shipmentDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.shipmentDataGridView.RowTemplate.Height = 23;
            this.shipmentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.shipmentDataGridView.Size = new System.Drawing.Size(444, 694);
            this.shipmentDataGridView.TabIndex = 59;
            this.shipmentDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.shipmentDataGridView_DataError);
            this.shipmentDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.shipmentDataGridView_RowEnter);
            this.shipmentDataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.shipmentDataGridView_RowPrePaint);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "顺序";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Width = 50;
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
            this.shipCodeDataGridViewTextBoxColumn.Width = 70;
            // 
            // customerDataGridViewTextBoxColumn
            // 
            this.customerDataGridViewTextBoxColumn.DataPropertyName = "Customer";
            this.customerDataGridViewTextBoxColumn.HeaderText = "客户";
            this.customerDataGridViewTextBoxColumn.Name = "customerDataGridViewTextBoxColumn";
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            this.costDataGridViewTextBoxColumn.HeaderText = "总计";
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
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
            this.shipmentBindingNavigator.Size = new System.Drawing.Size(367, 25);
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
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(32, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
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
            this.tsbtPrint.Size = new System.Drawing.Size(72, 22);
            this.tsbtPrint.Text = "出货单打印";
            this.tsbtPrint.Click += new System.EventHandler(this.tsbtPrint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // shipmentTableAdapter
            // 
            this.shipmentTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CustomerTableAdapter = this.customerTableAdapter;
            this.tableAdapterManager.InventoryDetailTableAdapter = null;
            this.tableAdapterManager.InventoryProductsTableAdapter = null;
            this.tableAdapterManager.InventoryTableAdapter = null;
            this.tableAdapterManager.ProductScrappedDetailTableAdapter = null;
            this.tableAdapterManager.ProductScrappedTableAdapter = null;
            this.tableAdapterManager.ShipmentDetailTableAdapter = this.shipmentDetailTableAdapter;
            this.tableAdapterManager.ShipmentTableAdapter = this.shipmentTableAdapter;
            this.tableAdapterManager.UpdateOrder = VoucherExpense.SQLVEDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // customerTableAdapter
            // 
            this.customerTableAdapter.ClearBeforeFill = true;
            // 
            // shipmentDetailTableAdapter
            // 
            this.shipmentDetailTableAdapter.ClearBeforeFill = true;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // accountingTitleTableAdapter
            // 
            this.accountingTitleTableAdapter.ClearBeforeFill = true;
            // 
            // operatorTableAdapter
            // 
            this.operatorTableAdapter.ClearBeforeFill = true;
            // 
            // FormShipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(936, 694);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(keyinIDLabel);
            this.Controls.Add(checkedIDLabel);
            this.Controls.Add(iDLabel);
            this.Controls.Add(this.iDLabel1);
            this.Controls.Add(lastUpdatedLabel);
            this.Controls.Add(this.lastUpdatedLabel1);
            this.Controls.Add(checkedLabel);
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
            this.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormShipment";
            this.Text = "出货";
            this.Load += new System.EventHandler(this.FormShipment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.shipmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLVEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDetailDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentBindingNavigator)).EndInit();
            this.shipmentBindingNavigator.ResumeLayout(false);
            this.shipmentBindingNavigator.PerformLayout();
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
        private SQLVEDataSet sQLVEDataSet;
        private System.Windows.Forms.BindingSource shipmentBindingSource;
        private SQLVEDataSetTableAdapters.ShipmentTableAdapter shipmentTableAdapter;
        private SQLVEDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private SQLVEDataSetTableAdapters.ShipmentDetailTableAdapter shipmentDetailTableAdapter;
        private System.Windows.Forms.BindingSource shipmentDetailBindingSource;
        private BakeryOrderSet bakeryOrderSet;
        private System.Windows.Forms.BindingSource productBindingSource;
        private BakeryOrderSetTableAdapters.ProductTableAdapter productTableAdapter;
        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource accountingTitleBindingSource;
        private VEDataSetTableAdapters.AccountingTitleTableAdapter accountingTitleTableAdapter;
        private SQLVEDataSetTableAdapters.CustomerTableAdapter customerTableAdapter;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private System.Windows.Forms.BindingSource operatorBindingSource;
        private VEDataSetTableAdapters.OperatorTableAdapter operatorTableAdapter;
        private System.Drawing.Printing.PrintDocument pD;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Removed;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Checked;
        private System.Windows.Forms.DataGridViewTextBoxColumn detailColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipmentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColumnProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnVolume;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCostColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColumnTitleCode;
    }
}