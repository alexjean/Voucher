namespace VoucherExpense
{
    partial class ReportByTitle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnMoney1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentageDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountingTableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnMoney2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountingTableBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.labelExpenseSum = new System.Windows.Forms.Label();
            this.labelCostSum = new System.Windows.Forms.Label();
            this.btnPrintCost = new System.Windows.Forms.Button();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelRevenue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelBalance = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelAsset = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelLiability = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelEquity = new System.Windows.Forms.Label();
            this.comboBoxStart = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelMessage = new System.Windows.Forms.Label();
            this.labelEquity1 = new System.Windows.Forms.Label();
            this.labelLiability1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.veDataSet1 = new VoucherExpense.VEDataSet();
            this.expenseTableAdapter1 = new VoucherExpense.VEDataSetTableAdapters.ExpenseTableAdapter();
            this.accountingTitleTableAdapter1 = new VoucherExpense.VEDataSetTableAdapters.AccountingTitleTableAdapter();
            this.voucherTableAdapter1 = new VoucherExpense.VEDataSetTableAdapters.VoucherTableAdapter();
            this.voucherDetailTableAdapter1 = new VoucherExpense.VEDataSetTableAdapters.VoucherDetailTableAdapter();
            this.basicDataSet1 = new VoucherExpense.BasicDataSet();
            this.headerTableAdapter1 = new VoucherExpense.BasicDataSetTableAdapters.HeaderTableAdapter();
            this.bankAccountTableAdapter1 = new VoucherExpense.VEDataSetTableAdapters.BankAccountTableAdapter();
            this.bankDetailTableAdapter1 = new VoucherExpense.VEDataSetTableAdapters.BankDetailTableAdapter();
            this.label6 = new System.Windows.Forms.Label();
            this.accVoucherTableAdapter1 = new VoucherExpense.VEDataSetTableAdapters.AccVoucherTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTableBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTableBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.veDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basicDataSet1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.DropDownHeight = 216;
            this.comboBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.IntegralHeight = false;
            this.comboBoxMonth.Items.AddRange(new object[] {
            "全期",
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
            this.comboBoxMonth.Location = new System.Drawing.Point(21, 15);
            this.comboBoxMonth.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(91, 24);
            this.comboBoxMonth.TabIndex = 54;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Azure;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn1,
            this.columnMoney1,
            this.percentageDataGridViewTextBoxColumn1});
            this.dataGridView1.DataSource = this.accountingTableBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(21, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(368, 468);
            this.dataGridView1.TabIndex = 55;
            this.dataGridView1.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseDoubleClick);
            // 
            // codeDataGridViewTextBoxColumn1
            // 
            this.codeDataGridViewTextBoxColumn1.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn1.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn1.Name = "codeDataGridViewTextBoxColumn1";
            this.codeDataGridViewTextBoxColumn1.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn1.Width = 60;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "科目";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // columnMoney1
            // 
            this.columnMoney1.DataPropertyName = "Money";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N1";
            dataGridViewCellStyle2.NullValue = null;
            this.columnMoney1.DefaultCellStyle = dataGridViewCellStyle2;
            this.columnMoney1.HeaderText = "金額";
            this.columnMoney1.Name = "columnMoney1";
            this.columnMoney1.ReadOnly = true;
            // 
            // percentageDataGridViewTextBoxColumn1
            // 
            this.percentageDataGridViewTextBoxColumn1.DataPropertyName = "Percentage";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N1";
            dataGridViewCellStyle3.NullValue = null;
            this.percentageDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.percentageDataGridViewTextBoxColumn1.HeaderText = "%";
            this.percentageDataGridViewTextBoxColumn1.Name = "percentageDataGridViewTextBoxColumn1";
            this.percentageDataGridViewTextBoxColumn1.ReadOnly = true;
            this.percentageDataGridViewTextBoxColumn1.Width = 60;
            // 
            // accountingTableBindingSource1
            // 
            this.accountingTableBindingSource1.DataSource = typeof(VoucherExpense.AccTitle);
            this.accountingTableBindingSource1.Sort = "";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Azure;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.Azure;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.columnMoney2,
            this.percentageDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.accountingTableBindingSource2;
            this.dataGridView2.Location = new System.Drawing.Point(452, 56);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 25;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(368, 468);
            this.dataGridView2.TabIndex = 59;
            this.dataGridView2.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_ColumnHeaderMouseDoubleClick);
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.Width = 60;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "科目";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnMoney2
            // 
            this.columnMoney2.DataPropertyName = "Money";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N1";
            dataGridViewCellStyle5.NullValue = null;
            this.columnMoney2.DefaultCellStyle = dataGridViewCellStyle5;
            this.columnMoney2.HeaderText = "金額";
            this.columnMoney2.Name = "columnMoney2";
            this.columnMoney2.ReadOnly = true;
            // 
            // percentageDataGridViewTextBoxColumn
            // 
            this.percentageDataGridViewTextBoxColumn.DataPropertyName = "Percentage";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N1";
            dataGridViewCellStyle6.NullValue = null;
            this.percentageDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.percentageDataGridViewTextBoxColumn.HeaderText = "%";
            this.percentageDataGridViewTextBoxColumn.Name = "percentageDataGridViewTextBoxColumn";
            this.percentageDataGridViewTextBoxColumn.ReadOnly = true;
            this.percentageDataGridViewTextBoxColumn.Width = 60;
            // 
            // accountingTableBindingSource2
            // 
            this.accountingTableBindingSource2.DataSource = typeof(VoucherExpense.AccTitle);
            this.accountingTableBindingSource2.Sort = "";
            // 
            // labelExpenseSum
            // 
            this.labelExpenseSum.Location = new System.Drawing.Point(144, 53);
            this.labelExpenseSum.Name = "labelExpenseSum";
            this.labelExpenseSum.Size = new System.Drawing.Size(80, 16);
            this.labelExpenseSum.TabIndex = 60;
            this.labelExpenseSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCostSum
            // 
            this.labelCostSum.Location = new System.Drawing.Point(249, 53);
            this.labelCostSum.Name = "labelCostSum";
            this.labelCostSum.Size = new System.Drawing.Size(80, 16);
            this.labelCostSum.TabIndex = 61;
            this.labelCostSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrintCost
            // 
            this.btnPrintCost.Location = new System.Drawing.Point(745, 16);
            this.btnPrintCost.Name = "btnPrintCost";
            this.btnPrintCost.Size = new System.Drawing.Size(75, 23);
            this.btnPrintCost.TabIndex = 62;
            this.btnPrintCost.Text = "列印";
            this.btnPrintCost.UseVisualStyleBackColor = true;
            this.btnPrintCost.Click += new System.EventHandler(this.btnPrintCost_Click);
            // 
            // printDocument
            // 
            this.printDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_BeginPrint);
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(154, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(66, 24);
            this.comboBox1.TabIndex = 63;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(581, 15);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(66, 24);
            this.comboBox2.TabIndex = 64;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 65;
            this.label1.Text = "－費用";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 66;
            this.label2.Text = "－成本";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 68;
            this.label3.Text = "收入";
            // 
            // labelRevenue
            // 
            this.labelRevenue.Location = new System.Drawing.Point(34, 53);
            this.labelRevenue.Name = "labelRevenue";
            this.labelRevenue.Size = new System.Drawing.Size(80, 16);
            this.labelRevenue.TabIndex = 67;
            this.labelRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(359, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 70;
            this.label5.Text = "＝損益";
            // 
            // labelBalance
            // 
            this.labelBalance.Location = new System.Drawing.Point(346, 53);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(80, 16);
            this.labelBalance.TabIndex = 69;
            this.labelBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(582, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 72;
            this.label4.Text = "資產";
            // 
            // labelAsset
            // 
            this.labelAsset.Location = new System.Drawing.Point(556, 53);
            this.labelAsset.Name = "labelAsset";
            this.labelAsset.Size = new System.Drawing.Size(80, 16);
            this.labelAsset.TabIndex = 71;
            this.labelAsset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(673, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 74;
            this.label7.Text = "－負債";
            // 
            // labelLiability
            // 
            this.labelLiability.Location = new System.Drawing.Point(665, 53);
            this.labelLiability.Name = "labelLiability";
            this.labelLiability.Size = new System.Drawing.Size(80, 16);
            this.labelLiability.TabIndex = 73;
            this.labelLiability.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(784, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 76;
            this.label9.Text = "＝權益";
            // 
            // labelEquity
            // 
            this.labelEquity.Location = new System.Drawing.Point(773, 53);
            this.labelEquity.Name = "labelEquity";
            this.labelEquity.Size = new System.Drawing.Size(80, 16);
            this.labelEquity.TabIndex = 75;
            this.labelEquity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxStart
            // 
            this.comboBoxStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.comboBoxStart.DropDownHeight = 216;
            this.comboBoxStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBoxStart.FormattingEnabled = true;
            this.comboBoxStart.IntegralHeight = false;
            this.comboBoxStart.Items.AddRange(new object[] {
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
            this.comboBoxStart.Location = new System.Drawing.Point(474, 49);
            this.comboBoxStart.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxStart.Name = "comboBoxStart";
            this.comboBoxStart.Size = new System.Drawing.Size(56, 24);
            this.comboBoxStart.TabIndex = 77;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(474, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.label11.TabIndex = 78;
            this.label11.Text = "起始月";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(921, 13);
            this.progressBar1.TabIndex = 79;
            this.progressBar1.Visible = false;
            // 
            // labelMessage
            // 
            this.labelMessage.Location = new System.Drawing.Point(326, 15);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(203, 24);
            this.labelMessage.TabIndex = 80;
            this.labelMessage.Text = "雙擊 \"金額\" 改變小數位數";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEquity1
            // 
            this.labelEquity1.Location = new System.Drawing.Point(773, 81);
            this.labelEquity1.Name = "labelEquity1";
            this.labelEquity1.Size = new System.Drawing.Size(80, 16);
            this.labelEquity1.TabIndex = 82;
            this.labelEquity1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelLiability1
            // 
            this.labelLiability1.Location = new System.Drawing.Point(665, 81);
            this.labelLiability1.Name = "labelLiability1";
            this.labelLiability1.Size = new System.Drawing.Size(80, 16);
            this.labelLiability1.TabIndex = 81;
            this.labelLiability1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(474, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 16);
            this.label10.TabIndex = 83;
            this.label10.Text = "不計股東往來";
            // 
            // veDataSet1
            // 
            this.veDataSet1.DataSetName = "VEDataSet";
            this.veDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // expenseTableAdapter1
            // 
            this.expenseTableAdapter1.ClearBeforeFill = true;
            // 
            // accountingTitleTableAdapter1
            // 
            this.accountingTitleTableAdapter1.ClearBeforeFill = true;
            // 
            // voucherTableAdapter1
            // 
            this.voucherTableAdapter1.ClearBeforeFill = true;
            // 
            // voucherDetailTableAdapter1
            // 
            this.voucherDetailTableAdapter1.ClearBeforeFill = true;
            // 
            // basicDataSet1
            // 
            this.basicDataSet1.DataSetName = "BasicDataSet";
            this.basicDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // headerTableAdapter1
            // 
            this.headerTableAdapter1.ClearBeforeFill = true;
            // 
            // bankAccountTableAdapter1
            // 
            this.bankAccountTableAdapter1.ClearBeforeFill = true;
            // 
            // bankDetailTableAdapter1
            // 
            this.bankDetailTableAdapter1.ClearBeforeFill = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Azure;
            this.label6.Location = new System.Drawing.Point(73, 463);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 16);
            this.label6.TabIndex = 84;
            // 
            // accVoucherTableAdapter1
            // 
            this.accVoucherTableAdapter1.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.labelExpenseSum);
            this.panel1.Controls.Add(this.labelEquity1);
            this.panel1.Controls.Add(this.labelCostSum);
            this.panel1.Controls.Add(this.labelLiability1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelRevenue);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxStart);
            this.panel1.Controls.Add(this.labelBalance);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.labelEquity);
            this.panel1.Controls.Add(this.labelAsset);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labelLiability);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 519);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(920, 123);
            this.panel1.TabIndex = 85;
            // 
            // ReportByTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(920, 642);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnPrintCost);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReportByTitle";
            this.Text = "月報表 會計科目別";
            this.Load += new System.EventHandler(this.ReportByTitle_Load);
            this.SizeChanged += new System.EventHandler(this.ReportByTitle_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTableBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTableBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.veDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basicDataSet1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMonth;
        private VEDataSet veDataSet1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private VoucherExpense.VEDataSetTableAdapters.ExpenseTableAdapter expenseTableAdapter1;
        private VoucherExpense.VEDataSetTableAdapters.AccountingTitleTableAdapter accountingTitleTableAdapter1;
        private System.Windows.Forms.BindingSource accountingTableBindingSource1;
        private System.Windows.Forms.BindingSource accountingTableBindingSource2;
        private System.Windows.Forms.Label labelExpenseSum;
        private System.Windows.Forms.Label labelCostSum;
        private VoucherExpense.VEDataSetTableAdapters.VoucherTableAdapter voucherTableAdapter1;
        private VoucherExpense.VEDataSetTableAdapters.VoucherDetailTableAdapter voucherDetailTableAdapter1;
        private System.Windows.Forms.Button btnPrintCost;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelRevenue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelAsset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelLiability;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelEquity;
        private System.Windows.Forms.ComboBox comboBoxStart;
        private System.Windows.Forms.Label label11;
        private BasicDataSet basicDataSet1;
        private VoucherExpense.BasicDataSetTableAdapters.HeaderTableAdapter headerTableAdapter1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private VoucherExpense.VEDataSetTableAdapters.BankAccountTableAdapter bankAccountTableAdapter1;
        private System.Windows.Forms.Label labelMessage;
        private VoucherExpense.VEDataSetTableAdapters.BankDetailTableAdapter bankDetailTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnMoney1;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentageDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnMoney2;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentageDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label labelEquity1;
        private System.Windows.Forms.Label labelLiability1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private VoucherExpense.VEDataSetTableAdapters.AccVoucherTableAdapter accVoucherTableAdapter1;
        private System.Windows.Forms.Panel panel1;
    }
}