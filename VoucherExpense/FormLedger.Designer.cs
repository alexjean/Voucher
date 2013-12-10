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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cLedgerTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cLedgerTableDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDebt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OthersideAccTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.accountingTitleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vEDataSet = new VoucherExpense.VEDataSet();
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
            this.damaiDataSet = new VoucherExpense.DamaiDataSet();
            this.accountingTitleTableAdapter1 = new VoucherExpense.DamaiDataSetTableAdapters.AccountingTitleTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cLedgerTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLedgerTableDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).BeginInit();
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
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.Azure;
            this.cLedgerTableDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.cLedgerTableDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cLedgerTableDataGridView.AutoGenerateColumns = false;
            this.cLedgerTableDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.cLedgerTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cLedgerTableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.ColumnDebt,
            this.ColumnCredit,
            this.Sum,
            this.OthersideAccTitle});
            this.cLedgerTableDataGridView.DataSource = this.cLedgerTableBindingSource;
            this.cLedgerTableDataGridView.Location = new System.Drawing.Point(0, 28);
            this.cLedgerTableDataGridView.Name = "cLedgerTableDataGridView";
            this.cLedgerTableDataGridView.ReadOnly = true;
            this.cLedgerTableDataGridView.RowHeadersWidth = 25;
            this.cLedgerTableDataGridView.RowTemplate.Height = 24;
            this.cLedgerTableDataGridView.Size = new System.Drawing.Size(964, 610);
            this.cLedgerTableDataGridView.TabIndex = 1;
            this.cLedgerTableDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.cLedgerTableDataGridView_CellFormatting);
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
            this.dataGridViewTextBoxColumn2.Width = 320;
            // 
            // ColumnDebt
            // 
            this.ColumnDebt.DataPropertyName = "Debt";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            this.ColumnDebt.DefaultCellStyle = dataGridViewCellStyle14;
            this.ColumnDebt.HeaderText = "借方";
            this.ColumnDebt.Name = "ColumnDebt";
            this.ColumnDebt.ReadOnly = true;
            // 
            // ColumnCredit
            // 
            this.ColumnCredit.DataPropertyName = "Credit";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N2";
            this.ColumnCredit.DefaultCellStyle = dataGridViewCellStyle15;
            this.ColumnCredit.HeaderText = "貸方";
            this.ColumnCredit.Name = "ColumnCredit";
            this.ColumnCredit.ReadOnly = true;
            // 
            // Sum
            // 
            this.Sum.DataPropertyName = "Sum";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N2";
            dataGridViewCellStyle16.NullValue = null;
            this.Sum.DefaultCellStyle = dataGridViewCellStyle16;
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
            // accountingTitleBindingSource
            // 
            this.accountingTitleBindingSource.DataMember = "AccountingTitle";
            this.accountingTitleBindingSource.DataSource = this.damaiDataSet;
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.comboBoxAccTitle.Size = new System.Drawing.Size(138, 24);
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
            this.labelMessage.Location = new System.Drawing.Point(259, 1);
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
            this.progressBar1.Size = new System.Drawing.Size(964, 23);
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
            // damaiDataSet
            // 
            this.damaiDataSet.DataSetName = "DamaiDataSet";
            this.damaiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // accountingTitleTableAdapter1
            // 
            this.accountingTitleTableAdapter1.ClearBeforeFill = true;
            // 
            // FormLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(964, 640);
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
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource cLedgerTableBindingSource;
        private System.Windows.Forms.DataGridView cLedgerTableDataGridView;
        private System.Windows.Forms.ComboBox comboBoxMonth;
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
        private System.Windows.Forms.Button btnExport2Excel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDebt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn OthersideAccTitle;
        private VEDataSet vEDataSet;
        private DamaiDataSet damaiDataSet;
        private DamaiDataSetTableAdapters.AccountingTitleTableAdapter accountingTitleTableAdapter1;
    }
}