namespace VoucherExpense
{
    partial class FormLedger
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cLedgerTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cLedgerTableDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OthersideAccTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.accountingTitleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountingTitleTableAdapter = new VoucherExpense.VEDataSetTableAdapters.AccountingTitleTableAdapter();
            this.comboBoxAccTitle = new System.Windows.Forms.ComboBox();
            this.bankAccountTableAdapter = new VoucherExpense.VEDataSetTableAdapters.BankAccountTableAdapter();
            this.labelMessage = new System.Windows.Forms.Label();
            this.expenseTableAdapter = new VoucherExpense.VEDataSetTableAdapters.ExpenseTableAdapter();
            this.voucherTableAdapter = new VoucherExpense.VEDataSetTableAdapters.VoucherTableAdapter();
            this.voucherDetailTableAdapter = new VoucherExpense.VEDataSetTableAdapters.VoucherDetailTableAdapter();
            this.bankDetailTableAdapter = new VoucherExpense.VEDataSetTableAdapters.BankDetailTableAdapter();
            this.accVoucherTableAdapter = new VoucherExpense.VEDataSetTableAdapters.AccVoucherTableAdapter();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.vendorTableAdapter = new VoucherExpense.VEDataSetTableAdapters.VendorTableAdapter();
            this.ingredientTableAdapter = new VoucherExpense.VEDataSetTableAdapters.IngredientTableAdapter();
            this.btnExport2Excel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cLedgerTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLedgerTableDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cLedgerTableBindingSource
            // 
            this.cLedgerTableBindingSource.DataSource = typeof(VoucherExpense.CLedgerRow);
            // 
            // cLedgerTableDataGridView
            // 
            this.cLedgerTableDataGridView.AllowUserToAddRows = false;
            this.cLedgerTableDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.cLedgerTableDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.cLedgerTableDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cLedgerTableDataGridView.AutoGenerateColumns = false;
            this.cLedgerTableDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.cLedgerTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cLedgerTableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Debt,
            this.Credit,
            this.Sum,
            this.OthersideAccTitle});
            this.cLedgerTableDataGridView.DataSource = this.cLedgerTableBindingSource;
            this.cLedgerTableDataGridView.Location = new System.Drawing.Point(0, 28);
            this.cLedgerTableDataGridView.Name = "cLedgerTableDataGridView";
            this.cLedgerTableDataGridView.ReadOnly = true;
            this.cLedgerTableDataGridView.RowHeadersWidth = 25;
            this.cLedgerTableDataGridView.RowTemplate.Height = 24;
            this.cLedgerTableDataGridView.Size = new System.Drawing.Size(950, 610);
            this.cLedgerTableDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Date";
            this.dataGridViewTextBoxColumn1.HeaderText = "日期";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 92;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Note";
            this.dataGridViewTextBoxColumn2.HeaderText = "摘要";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 308;
            // 
            // Debt
            // 
            this.Debt.DataPropertyName = "Debt";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Debt.DefaultCellStyle = dataGridViewCellStyle2;
            this.Debt.HeaderText = "借方";
            this.Debt.Name = "Debt";
            this.Debt.ReadOnly = true;
            // 
            // Credit
            // 
            this.Credit.DataPropertyName = "Credit";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Credit.DefaultCellStyle = dataGridViewCellStyle3;
            this.Credit.HeaderText = "貸方";
            this.Credit.Name = "Credit";
            this.Credit.ReadOnly = true;
            // 
            // Sum
            // 
            this.Sum.DataPropertyName = "Sum";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Sum.DefaultCellStyle = dataGridViewCellStyle4;
            this.Sum.HeaderText = "餘額";
            this.Sum.Name = "Sum";
            this.Sum.ReadOnly = true;
            // 
            // OthersideAccTitle
            // 
            this.OthersideAccTitle.DataPropertyName = "OthersideAccTitle";
            this.OthersideAccTitle.HeaderText = "對沖科目";
            this.OthersideAccTitle.Name = "OthersideAccTitle";
            this.OthersideAccTitle.ReadOnly = true;
            this.OthersideAccTitle.Width = 200;
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
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
            this.comboBoxMonth.Location = new System.Drawing.Point(26, 1);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(71, 24);
            this.comboBoxMonth.TabIndex = 55;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // accountingTitleBindingSource
            // 
            this.accountingTitleBindingSource.DataMember = "AccountingTitle";
            this.accountingTitleBindingSource.DataSource = this.vEDataSet;
            // 
            // accountingTitleTableAdapter
            // 
            this.accountingTitleTableAdapter.ClearBeforeFill = true;
            // 
            // comboBoxAccTitle
            // 
            this.comboBoxAccTitle.DataSource = this.accountingTitleBindingSource;
            this.comboBoxAccTitle.DisplayMember = "Name";
            this.comboBoxAccTitle.FormattingEnabled = true;
            this.comboBoxAccTitle.Location = new System.Drawing.Point(115, 1);
            this.comboBoxAccTitle.Name = "comboBoxAccTitle";
            this.comboBoxAccTitle.Size = new System.Drawing.Size(109, 24);
            this.comboBoxAccTitle.TabIndex = 56;
            this.comboBoxAccTitle.ValueMember = "TitleCode";
            this.comboBoxAccTitle.SelectedIndexChanged += new System.EventHandler(this.comboBoxAccTitle_SelectedIndexChanged);
            // 
            // bankAccountTableAdapter
            // 
            this.bankAccountTableAdapter.ClearBeforeFill = true;
            // 
            // labelMessage
            // 
            this.labelMessage.Location = new System.Drawing.Point(230, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(195, 24);
            this.labelMessage.TabIndex = 81;
            this.labelMessage.Text = "請選擇 月份 科目";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // expenseTableAdapter
            // 
            this.expenseTableAdapter.ClearBeforeFill = true;
            // 
            // voucherTableAdapter
            // 
            this.voucherTableAdapter.ClearBeforeFill = true;
            // 
            // voucherDetailTableAdapter
            // 
            this.voucherDetailTableAdapter.ClearBeforeFill = true;
            // 
            // bankDetailTableAdapter
            // 
            this.bankDetailTableAdapter.ClearBeforeFill = true;
            // 
            // accVoucherTableAdapter
            // 
            this.accVoucherTableAdapter.ClearBeforeFill = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(0, 605);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(950, 23);
            this.progressBar1.TabIndex = 82;
            this.progressBar1.Visible = false;
            // 
            // vendorTableAdapter
            // 
            this.vendorTableAdapter.ClearBeforeFill = true;
            // 
            // ingredientTableAdapter
            // 
            this.ingredientTableAdapter.ClearBeforeFill = true;
            // 
            // btnExport2Excel
            // 
            this.btnExport2Excel.BackgroundImage = global::VoucherExpense.Properties.Resources.NavBar_Back;
            this.btnExport2Excel.Location = new System.Drawing.Point(850, 1);
            this.btnExport2Excel.Name = "btnExport2Excel";
            this.btnExport2Excel.Size = new System.Drawing.Size(75, 24);
            this.btnExport2Excel.TabIndex = 83;
            this.btnExport2Excel.Text = "轉Excel";
            this.btnExport2Excel.UseVisualStyleBackColor = true;
            this.btnExport2Excel.Click += new System.EventHandler(this.btnExport2Excel_Click);
            // 
            // FormLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(950, 640);
            this.Controls.Add(this.btnExport2Excel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.comboBoxAccTitle);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.cLedgerTableDataGridView);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormLedger";
            this.ShowIcon = false;
            this.Text = "分類帳";
            this.Load += new System.EventHandler(this.FormLedger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cLedgerTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLedgerTableDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource cLedgerTableBindingSource;
        private System.Windows.Forms.DataGridView cLedgerTableDataGridView;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource accountingTitleBindingSource;
        private VEDataSetTableAdapters.AccountingTitleTableAdapter accountingTitleTableAdapter;
        private System.Windows.Forms.ComboBox comboBoxAccTitle;
        private VEDataSetTableAdapters.BankAccountTableAdapter bankAccountTableAdapter;
        private System.Windows.Forms.Label labelMessage;
        private VEDataSetTableAdapters.ExpenseTableAdapter expenseTableAdapter;
        private VEDataSetTableAdapters.VoucherTableAdapter voucherTableAdapter;
        private VEDataSetTableAdapters.VoucherDetailTableAdapter voucherDetailTableAdapter;
        private VEDataSetTableAdapters.BankDetailTableAdapter bankDetailTableAdapter;
        private VEDataSetTableAdapters.AccVoucherTableAdapter accVoucherTableAdapter;
        private System.Windows.Forms.ProgressBar progressBar1;
        private VEDataSetTableAdapters.VendorTableAdapter vendorTableAdapter;
        private VEDataSetTableAdapters.IngredientTableAdapter ingredientTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn OthersideAccTitle;
        private System.Windows.Forms.Button btnExport2Excel;
    }
}