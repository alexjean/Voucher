namespace VoucherExpense
{
    partial class ReportByVender
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
            System.Windows.Forms.Label vendorIDLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbBoxMonth = new System.Windows.Forms.ComboBox();
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.vendorTableAdapter = new VoucherExpense.VEDataSetTableAdapters.VendorTableAdapter();
            this.vendorIDComboBox = new System.Windows.Forms.ComboBox();
            this.cVendorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IngredientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDUint = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.totalCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIngredientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.voucherBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.voucherDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.voucherDetailTableAdapter = new VoucherExpense.VEDataSetTableAdapters.VoucherDetailTableAdapter();
            this.voucherTableAdapter = new VoucherExpense.VEDataSetTableAdapters.VoucherTableAdapter();
            this.IngredientTableAdapter = new VoucherExpense.VEDataSetTableAdapters.IngredientTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.btnPrint = new System.Windows.Forms.Button();
            this.voucherDGView = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VoucherID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lockedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.labelCount = new System.Windows.Forms.Label();
            this.cbBoxMonthTo = new System.Windows.Forms.ComboBox();
            this.cbBoxTo = new System.Windows.Forms.ComboBox();
            this.cbBoxFrom = new System.Windows.Forms.ComboBox();
            this.btnCalc = new System.Windows.Forms.Button();
            vendorIDLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cVendorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cIngredientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.voucherBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.voucherDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.voucherDGView)).BeginInit();
            this.SuspendLayout();
            // 
            // vendorIDLabel
            // 
            vendorIDLabel.AllowDrop = true;
            vendorIDLabel.AutoSize = true;
            vendorIDLabel.Location = new System.Drawing.Point(249, 25);
            vendorIDLabel.Name = "vendorIDLabel";
            vendorIDLabel.Size = new System.Drawing.Size(56, 16);
            vendorIDLabel.TabIndex = 56;
            vendorIDLabel.Text = "供應商";
            // 
            // label1
            // 
            label1.AllowDrop = true;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(23, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(40, 16);
            label1.TabIndex = 58;
            label1.Text = "月份";
            // 
            // label3
            // 
            label3.AllowDrop = true;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(24, 41);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(24, 16);
            label3.TabIndex = 66;
            label3.Text = "至";
            // 
            // cbBoxMonth
            // 
            this.cbBoxMonth.DropDownHeight = 216;
            this.cbBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxMonth.FormattingEnabled = true;
            this.cbBoxMonth.IntegralHeight = false;
            this.cbBoxMonth.Items.AddRange(new object[] {
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
            this.cbBoxMonth.Location = new System.Drawing.Point(70, 5);
            this.cbBoxMonth.Margin = new System.Windows.Forms.Padding(4);
            this.cbBoxMonth.Name = "cbBoxMonth";
            this.cbBoxMonth.Size = new System.Drawing.Size(70, 24);
            this.cbBoxMonth.TabIndex = 55;
            this.cbBoxMonth.SelectedIndexChanged += new System.EventHandler(this.cbBoxMonth_SelectedIndexChanged);
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vendorTableAdapter
            // 
            this.vendorTableAdapter.ClearBeforeFill = true;
            // 
            // vendorIDComboBox
            // 
            this.vendorIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cVendorsBindingSource, "ID", true));
            this.vendorIDComboBox.DataSource = this.cVendorsBindingSource;
            this.vendorIDComboBox.DisplayMember = "Name";
            this.vendorIDComboBox.DropDownHeight = 360;
            this.vendorIDComboBox.FormattingEnabled = true;
            this.vendorIDComboBox.IntegralHeight = false;
            this.vendorIDComboBox.Location = new System.Drawing.Point(311, 21);
            this.vendorIDComboBox.Name = "vendorIDComboBox";
            this.vendorIDComboBox.Size = new System.Drawing.Size(106, 24);
            this.vendorIDComboBox.TabIndex = 57;
            this.vendorIDComboBox.ValueMember = "ID";
            // 
            // cVendorsBindingSource
            // 
            this.cVendorsBindingSource.DataSource = typeof(VoucherExpense.CNameIDForComboBox);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Azure;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.volumeDataGridViewTextBoxColumn,
            this.IDUint,
            this.totalCostDataGridViewTextBoxColumn,
            this.unitCostDataGridViewTextBoxColumn,
            this.OrderCount});
            this.dataGridView1.DataSource = this.cIngredientBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(27, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(581, 529);
            this.dataGridView1.TabIndex = 59;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.DataSource = this.IngredientBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.NullValue = null;
            this.ID.DefaultCellStyle = dataGridViewCellStyle2;
            this.ID.DisplayMember = "Name";
            this.ID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ID.HeaderText = "品名";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ID.ValueMember = "IngredientID";
            this.ID.Width = 180;
            // 
            // IngredientBindingSource
            // 
            this.IngredientBindingSource.DataMember = "Ingredient";
            this.IngredientBindingSource.DataSource = this.vEDataSet;
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = "Volume";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N1";
            dataGridViewCellStyle3.NullValue = null;
            this.volumeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.volumeDataGridViewTextBoxColumn.HeaderText = "數量";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            this.volumeDataGridViewTextBoxColumn.ReadOnly = true;
            this.volumeDataGridViewTextBoxColumn.Width = 80;
            // 
            // IDUint
            // 
            this.IDUint.DataPropertyName = "ID";
            this.IDUint.DataSource = this.IngredientBindingSource;
            this.IDUint.DisplayMember = "Unit";
            this.IDUint.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.IDUint.HeaderText = "";
            this.IDUint.Name = "IDUint";
            this.IDUint.ReadOnly = true;
            this.IDUint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IDUint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IDUint.ValueMember = "IngredientID";
            this.IDUint.Width = 32;
            // 
            // totalCostDataGridViewTextBoxColumn
            // 
            this.totalCostDataGridViewTextBoxColumn.DataPropertyName = "TotalCost";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N1";
            dataGridViewCellStyle4.NullValue = null;
            this.totalCostDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.totalCostDataGridViewTextBoxColumn.HeaderText = "總價";
            this.totalCostDataGridViewTextBoxColumn.Name = "totalCostDataGridViewTextBoxColumn";
            this.totalCostDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unitCostDataGridViewTextBoxColumn
            // 
            this.unitCostDataGridViewTextBoxColumn.DataPropertyName = "UnitCost";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N1";
            this.unitCostDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.unitCostDataGridViewTextBoxColumn.HeaderText = "單價";
            this.unitCostDataGridViewTextBoxColumn.Name = "unitCostDataGridViewTextBoxColumn";
            this.unitCostDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitCostDataGridViewTextBoxColumn.Width = 80;
            // 
            // OrderCount
            // 
            this.OrderCount.DataPropertyName = "OrderCount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.OrderCount.DefaultCellStyle = dataGridViewCellStyle6;
            this.OrderCount.HeaderText = "次數";
            this.OrderCount.Name = "OrderCount";
            this.OrderCount.ReadOnly = true;
            this.OrderCount.Width = 65;
            // 
            // cIngredientBindingSource
            // 
            this.cIngredientBindingSource.DataSource = typeof(VoucherExpense.CIngredient);
            // 
            // voucherBindingSource
            // 
            this.voucherBindingSource.DataMember = "Voucher";
            this.voucherBindingSource.DataSource = this.vEDataSet;
            // 
            // voucherDetailBindingSource
            // 
            this.voucherDetailBindingSource.DataMember = "VoucherDetail";
            this.voucherDetailBindingSource.DataSource = this.vEDataSet;
            // 
            // voucherDetailTableAdapter
            // 
            this.voucherDetailTableAdapter.ClearBeforeFill = true;
            // 
            // voucherTableAdapter
            // 
            this.voucherTableAdapter.ClearBeforeFill = true;
            // 
            // IngredientTableAdapter
            // 
            this.IngredientTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(620, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 60;
            this.label2.Text = "小計";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(666, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(106, 27);
            this.textBox1.TabIndex = 61;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // printDocument
            // 
            this.printDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_BeginPrint);
            this.printDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_EndPrint);
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(808, 22);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 62;
            this.btnPrint.Text = "列印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // voucherDGView
            // 
            this.voucherDGView.AllowUserToAddRows = false;
            this.voucherDGView.AllowUserToDeleteRows = false;
            this.voucherDGView.AllowUserToOrderColumns = true;
            this.voucherDGView.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Azure;
            this.voucherDGView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.voucherDGView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.voucherDGView.AutoGenerateColumns = false;
            this.voucherDGView.BackgroundColor = System.Drawing.Color.SeaShell;
            this.voucherDGView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.VoucherID,
            this.StockTime,
            this.costDataGridViewTextBoxColumn,
            this.lockedDataGridViewCheckBoxColumn});
            this.voucherDGView.DataSource = this.voucherBindingSource;
            this.voucherDGView.Location = new System.Drawing.Point(614, 71);
            this.voucherDGView.Name = "voucherDGView";
            this.voucherDGView.ReadOnly = true;
            this.voucherDGView.RowHeadersVisible = false;
            this.voucherDGView.RowHeadersWidth = 25;
            this.voucherDGView.RowTemplate.Height = 24;
            this.voucherDGView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.voucherDGView.Size = new System.Drawing.Size(280, 529);
            this.voucherDGView.TabIndex = 63;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 2;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 2;
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
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            this.StockTime.DefaultCellStyle = dataGridViewCellStyle8;
            this.StockTime.HeaderText = "進貨時間";
            this.StockTime.Name = "StockTime";
            this.StockTime.ReadOnly = true;
            this.StockTime.Width = 84;
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N1";
            this.costDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.costDataGridViewTextBoxColumn.HeaderText = "金額";
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            this.costDataGridViewTextBoxColumn.ReadOnly = true;
            this.costDataGridViewTextBoxColumn.Width = 70;
            // 
            // lockedDataGridViewCheckBoxColumn
            // 
            this.lockedDataGridViewCheckBoxColumn.DataPropertyName = "Locked";
            this.lockedDataGridViewCheckBoxColumn.HeaderText = "核";
            this.lockedDataGridViewCheckBoxColumn.Name = "lockedDataGridViewCheckBoxColumn";
            this.lockedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.lockedDataGridViewCheckBoxColumn.Width = 25;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(620, 9);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(62, 16);
            this.labelCount.TabIndex = 64;
            this.labelCount.Text = "共XX張";
            // 
            // cbBoxMonthTo
            // 
            this.cbBoxMonthTo.DropDownHeight = 216;
            this.cbBoxMonthTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxMonthTo.FormattingEnabled = true;
            this.cbBoxMonthTo.IntegralHeight = false;
            this.cbBoxMonthTo.Items.AddRange(new object[] {
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
            this.cbBoxMonthTo.Location = new System.Drawing.Point(70, 37);
            this.cbBoxMonthTo.Margin = new System.Windows.Forms.Padding(4);
            this.cbBoxMonthTo.Name = "cbBoxMonthTo";
            this.cbBoxMonthTo.Size = new System.Drawing.Size(70, 24);
            this.cbBoxMonthTo.TabIndex = 65;
            this.cbBoxMonthTo.SelectedIndexChanged += new System.EventHandler(this.cbBoxMonthTo_SelectedIndexChanged);
            // 
            // cbBoxTo
            // 
            this.cbBoxTo.FormattingEnabled = true;
            this.cbBoxTo.Location = new System.Drawing.Point(148, 37);
            this.cbBoxTo.Margin = new System.Windows.Forms.Padding(4);
            this.cbBoxTo.Name = "cbBoxTo";
            this.cbBoxTo.Size = new System.Drawing.Size(75, 24);
            this.cbBoxTo.TabIndex = 68;
            // 
            // cbBoxFrom
            // 
            this.cbBoxFrom.FormattingEnabled = true;
            this.cbBoxFrom.Location = new System.Drawing.Point(148, 5);
            this.cbBoxFrom.Margin = new System.Windows.Forms.Padding(4);
            this.cbBoxFrom.Name = "cbBoxFrom";
            this.cbBoxFrom.Size = new System.Drawing.Size(75, 24);
            this.cbBoxFrom.TabIndex = 67;
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(458, 12);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 44);
            this.btnCalc.TabIndex = 69;
            this.btnCalc.Text = "計算";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // ReportByVender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(908, 612);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.cbBoxTo);
            this.Controls.Add(this.cbBoxFrom);
            this.Controls.Add(label3);
            this.Controls.Add(this.cbBoxMonthTo);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.voucherDGView);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(label1);
            this.Controls.Add(this.vendorIDComboBox);
            this.Controls.Add(vendorIDLabel);
            this.Controls.Add(this.cbBoxMonth);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReportByVender";
            this.Text = "月報表 廠商別";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReportByVender_FormClosed);
            this.Load += new System.EventHandler(this.ReportByVender_Load);
            this.SizeChanged += new System.EventHandler(this.ReportByVender_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cVendorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cIngredientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.voucherBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.voucherDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.voucherDGView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBoxMonth;
        private VEDataSet vEDataSet;
        private VoucherExpense.VEDataSetTableAdapters.VendorTableAdapter vendorTableAdapter;
        private System.Windows.Forms.ComboBox vendorIDComboBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource cIngredientBindingSource;
        private System.Windows.Forms.BindingSource voucherBindingSource;
        private System.Windows.Forms.BindingSource voucherDetailBindingSource;
        private VoucherExpense.VEDataSetTableAdapters.VoucherDetailTableAdapter voucherDetailTableAdapter;
        private VoucherExpense.VEDataSetTableAdapters.VoucherTableAdapter voucherTableAdapter;
        private System.Windows.Forms.BindingSource IngredientBindingSource;
        private VoucherExpense.VEDataSetTableAdapters.IngredientTableAdapter IngredientTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView voucherDGView;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn VoucherID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lockedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn IDUint;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderCount;
        private System.Windows.Forms.BindingSource cVendorsBindingSource;
        private System.Windows.Forms.ComboBox cbBoxMonthTo;
        private System.Windows.Forms.ComboBox cbBoxTo;
        private System.Windows.Forms.ComboBox cbBoxFrom;
        private System.Windows.Forms.Button btnCalc;
    }
}