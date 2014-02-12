namespace VoucherExpense
{
    partial class FormImportBankExcel
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
            this.cbSheetNames = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dgViewImport = new System.Windows.Forms.DataGridView();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBankDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelWarning2 = new System.Windows.Forms.Label();
            this.labelWarning1 = new System.Windows.Forms.Label();
            this.cbDate = new System.Windows.Forms.ComboBox();
            this.cbDebt = new System.Windows.Forms.ComboBox();
            this.cbCredit = new System.Windows.Forms.ComboBox();
            this.cbNote = new System.Windows.Forms.ComboBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.veDataSet1 = new VoucherExpense.VEDataSet();
            this.bankDetailTableAdapter = new VoucherExpense.VEDataSetTableAdapters.BankDetailTableAdapter();
            this.cbBankAccount = new System.Windows.Forms.ComboBox();
            this.cBankAccountForComboBoxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankAccountTableAdapter = new VoucherExpense.VEDataSetTableAdapters.BankAccountTableAdapter();
            this.labelWarning3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBankDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.veDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBankAccountForComboBoxBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSheetNames
            // 
            this.cbSheetNames.FormattingEnabled = true;
            this.cbSheetNames.Location = new System.Drawing.Point(140, 22);
            this.cbSheetNames.Name = "cbSheetNames";
            this.cbSheetNames.Size = new System.Drawing.Size(131, 24);
            this.cbSheetNames.TabIndex = 0;
            this.cbSheetNames.SelectedIndexChanged += new System.EventHandler(this.cbSheetNames_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "選擇工作表";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Excel檔|*.xls*";
            this.openFileDialog1.Title = "使用此功能,此機器需安裝Excel";
            // 
            // dgViewImport
            // 
            this.dgViewImport.AllowUserToAddRows = false;
            this.dgViewImport.AutoGenerateColumns = false;
            this.dgViewImport.BackgroundColor = System.Drawing.Color.Azure;
            this.dgViewImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewImport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateDataGridViewTextBoxColumn,
            this.debtDataGridViewTextBoxColumn,
            this.creditDataGridViewTextBoxColumn,
            this.noteDataGridViewTextBoxColumn});
            this.dgViewImport.DataSource = this.cBankDetailBindingSource;
            this.dgViewImport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgViewImport.Location = new System.Drawing.Point(0, 101);
            this.dgViewImport.Name = "dgViewImport";
            this.dgViewImport.ReadOnly = true;
            this.dgViewImport.RowTemplate.Height = 24;
            this.dgViewImport.Size = new System.Drawing.Size(739, 435);
            this.dgViewImport.TabIndex = 2;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "日期";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // debtDataGridViewTextBoxColumn
            // 
            this.debtDataGridViewTextBoxColumn.DataPropertyName = "Debt";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.debtDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.debtDataGridViewTextBoxColumn.HeaderText = "支出";
            this.debtDataGridViewTextBoxColumn.Name = "debtDataGridViewTextBoxColumn";
            this.debtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // creditDataGridViewTextBoxColumn
            // 
            this.creditDataGridViewTextBoxColumn.DataPropertyName = "Credit";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.creditDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.creditDataGridViewTextBoxColumn.HeaderText = "存入";
            this.creditDataGridViewTextBoxColumn.Name = "creditDataGridViewTextBoxColumn";
            this.creditDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // noteDataGridViewTextBoxColumn
            // 
            this.noteDataGridViewTextBoxColumn.DataPropertyName = "Note";
            this.noteDataGridViewTextBoxColumn.HeaderText = "摘要";
            this.noteDataGridViewTextBoxColumn.Name = "noteDataGridViewTextBoxColumn";
            this.noteDataGridViewTextBoxColumn.ReadOnly = true;
            this.noteDataGridViewTextBoxColumn.Width = 320;
            // 
            // cBankDetailBindingSource
            // 
            this.cBankDetailBindingSource.DataSource = typeof(VoucherExpense.CBankDetail);
            // 
            // labelWarning2
            // 
            this.labelWarning2.AutoSize = true;
            this.labelWarning2.BackColor = System.Drawing.Color.Azure;
            this.labelWarning2.Location = new System.Drawing.Point(246, 321);
            this.labelWarning2.Name = "labelWarning2";
            this.labelWarning2.Size = new System.Drawing.Size(216, 16);
            this.labelWarning2.TabIndex = 3;
            this.labelWarning2.Text = "任一欄位無法轉換的整行跳過";
            // 
            // labelWarning1
            // 
            this.labelWarning1.AutoSize = true;
            this.labelWarning1.BackColor = System.Drawing.Color.Azure;
            this.labelWarning1.Location = new System.Drawing.Point(246, 289);
            this.labelWarning1.Name = "labelWarning1";
            this.labelWarning1.Size = new System.Drawing.Size(216, 16);
            this.labelWarning1.TabIndex = 4;
            this.labelWarning1.Text = "工作表第一行規定為欄位名稱";
            // 
            // cbDate
            // 
            this.cbDate.FormattingEnabled = true;
            this.cbDate.Location = new System.Drawing.Point(40, 69);
            this.cbDate.Name = "cbDate";
            this.cbDate.Size = new System.Drawing.Size(94, 24);
            this.cbDate.TabIndex = 5;
            this.cbDate.SelectedIndexChanged += new System.EventHandler(this.cbDate_SelectedIndexChanged);
            // 
            // cbDebt
            // 
            this.cbDebt.FormattingEnabled = true;
            this.cbDebt.Location = new System.Drawing.Point(140, 69);
            this.cbDebt.Name = "cbDebt";
            this.cbDebt.Size = new System.Drawing.Size(94, 24);
            this.cbDebt.TabIndex = 6;
            this.cbDebt.SelectedIndexChanged += new System.EventHandler(this.cbDebt_SelectedIndexChanged);
            // 
            // cbCredit
            // 
            this.cbCredit.FormattingEnabled = true;
            this.cbCredit.Location = new System.Drawing.Point(240, 69);
            this.cbCredit.Name = "cbCredit";
            this.cbCredit.Size = new System.Drawing.Size(94, 24);
            this.cbCredit.TabIndex = 7;
            this.cbCredit.SelectedIndexChanged += new System.EventHandler(this.cbCredit_SelectedIndexChanged);
            // 
            // cbNote
            // 
            this.cbNote.FormattingEnabled = true;
            this.cbNote.Location = new System.Drawing.Point(340, 69);
            this.cbNote.Name = "cbNote";
            this.cbNote.Size = new System.Drawing.Size(94, 24);
            this.cbNote.TabIndex = 8;
            this.cbNote.SelectedIndexChanged += new System.EventHandler(this.cbNote_SelectedIndexChanged);
            // 
            // btnConvert
            // 
            this.btnConvert.Enabled = false;
            this.btnConvert.Location = new System.Drawing.Point(436, 23);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(94, 23);
            this.btnConvert.TabIndex = 9;
            this.btnConvert.Text = "確認轉入";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // veDataSet1
            // 
            this.veDataSet1.DataSetName = "VEDataSet";
            this.veDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bankDetailTableAdapter
            // 
            this.bankDetailTableAdapter.ClearBeforeFill = true;
            // 
            // cbBankAccount
            // 
            this.cbBankAccount.DataSource = this.cBankAccountForComboBoxBindingSource;
            this.cbBankAccount.DisplayMember = "Name";
            this.cbBankAccount.FormattingEnabled = true;
            this.cbBankAccount.Location = new System.Drawing.Point(277, 22);
            this.cbBankAccount.Name = "cbBankAccount";
            this.cbBankAccount.Size = new System.Drawing.Size(121, 24);
            this.cbBankAccount.TabIndex = 10;
            this.cbBankAccount.ValueMember = "ID";
            // 
            // cBankAccountForComboBoxBindingSource
            // 
            this.cBankAccountForComboBoxBindingSource.DataSource = typeof(VoucherExpense.CBankAccountForComboBox);
            // 
            // bankAccountTableAdapter
            // 
            this.bankAccountTableAdapter.ClearBeforeFill = true;
            // 
            // labelWarning3
            // 
            this.labelWarning3.AutoSize = true;
            this.labelWarning3.BackColor = System.Drawing.Color.Azure;
            this.labelWarning3.Location = new System.Drawing.Point(246, 352);
            this.labelWarning3.Name = "labelWarning3";
            this.labelWarning3.Size = new System.Drawing.Size(144, 16);
            this.labelWarning3.TabIndex = 11;
            this.labelWarning3.Text = "按Delete可以刪除行";
            // 
            // FormImportBankExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(739, 536);
            this.Controls.Add(this.labelWarning3);
            this.Controls.Add(this.cbBankAccount);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.cbNote);
            this.Controls.Add(this.cbCredit);
            this.Controls.Add(this.cbDebt);
            this.Controls.Add(this.cbDate);
            this.Controls.Add(this.labelWarning1);
            this.Controls.Add(this.labelWarning2);
            this.Controls.Add(this.dgViewImport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSheetNames);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormImportBankExcel";
            this.Text = "匯入銀行Excel工作表";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormImportBankExcel_FormClosed);
            this.Load += new System.EventHandler(this.FormImportBankExcel_Load);
            this.Shown += new System.EventHandler(this.FormImportBankExcel_Shown);
            this.SizeChanged += new System.EventHandler(this.FormImportBankExcel_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBankDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.veDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBankAccountForComboBoxBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSheetNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dgViewImport;
        private System.Windows.Forms.BindingSource cBankDetailBindingSource;
        private System.Windows.Forms.Label labelWarning2;
        private System.Windows.Forms.Label labelWarning1;
        private System.Windows.Forms.ComboBox cbDate;
        private System.Windows.Forms.ComboBox cbDebt;
        private System.Windows.Forms.ComboBox cbCredit;
        private System.Windows.Forms.ComboBox cbNote;
        private System.Windows.Forms.Button btnConvert;
        private VEDataSet veDataSet1;
        private VoucherExpense.VEDataSetTableAdapters.BankDetailTableAdapter bankDetailTableAdapter;
        private System.Windows.Forms.ComboBox cbBankAccount;
        private VoucherExpense.VEDataSetTableAdapters.BankAccountTableAdapter bankAccountTableAdapter;
        private System.Windows.Forms.BindingSource cBankAccountForComboBoxBindingSource;
        private System.Windows.Forms.Label labelWarning3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteDataGridViewTextBoxColumn;
    }
}