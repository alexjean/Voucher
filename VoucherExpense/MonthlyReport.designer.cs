namespace VoucherExpense
{
    partial class MonthlyReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgViewMonthly = new System.Windows.Forms.DataGridView();
            this.basicDataSet1 = new VoucherExpense.BasicDataSet();
            this.checkBoxUse12 = new System.Windows.Forms.CheckBox();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.headerTableAdapter1 = new VoucherExpense.BasicDataSetTableAdapters.HeaderTableAdapter();
            this.labelOrderCount = new System.Windows.Forms.Label();
            this.labelCash = new System.Windows.Forms.Label();
            this.labelCredit = new System.Windows.Forms.Label();
            this.labelRevenue = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelCreditNet = new System.Windows.Forms.Label();
            this.labelCreditFee = new System.Windows.Forms.Label();
            this.CreditNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelFeeRate = new System.Windows.Forms.Label();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.revenueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditCardDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cashDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avePerPersonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthlyReportDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMonthly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basicDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyReportDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgViewMonthly
            // 
            this.dgViewMonthly.AutoGenerateColumns = false;
            this.dgViewMonthly.BackgroundColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewMonthly.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgViewMonthly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewMonthly.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateDataGridViewTextBoxColumn,
            this.revenueDataGridViewTextBoxColumn,
            this.creditCardDataGridViewTextBoxColumn,
            this.cashDataGridViewTextBoxColumn,
            this.orderCountDataGridViewTextBoxColumn,
            this.avePerPersonDataGridViewTextBoxColumn,
            this.CreditNet,
            this.CreditFee,
            this.Column1});
            this.dgViewMonthly.DataSource = this.monthlyReportDataBindingSource;
            this.dgViewMonthly.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgViewMonthly.Location = new System.Drawing.Point(0, 59);
            this.dgViewMonthly.Margin = new System.Windows.Forms.Padding(4);
            this.dgViewMonthly.Name = "dgViewMonthly";
            this.dgViewMonthly.RowTemplate.Height = 24;
            this.dgViewMonthly.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgViewMonthly.Size = new System.Drawing.Size(890, 585);
            this.dgViewMonthly.TabIndex = 0;
            // 
            // basicDataSet1
            // 
            this.basicDataSet1.DataSetName = "BasicDataSet";
            this.basicDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // checkBoxUse12
            // 
            this.checkBoxUse12.AutoSize = true;
            this.checkBoxUse12.Checked = true;
            this.checkBoxUse12.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUse12.Location = new System.Drawing.Point(523, 17);
            this.checkBoxUse12.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxUse12.Name = "checkBoxUse12";
            this.checkBoxUse12.Size = new System.Drawing.Size(75, 20);
            this.checkBoxUse12.TabIndex = 1;
            this.checkBoxUse12.Text = "0_24時";
            this.checkBoxUse12.UseVisualStyleBackColor = true;
            this.checkBoxUse12.CheckedChanged += new System.EventHandler(this.checkBoxUse12_CheckedChanged);
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Items.AddRange(new object[] {
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
            this.comboBoxMonth.Location = new System.Drawing.Point(13, 11);
            this.comboBoxMonth.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(84, 24);
            this.comboBoxMonth.TabIndex = 2;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // headerTableAdapter1
            // 
            this.headerTableAdapter1.ClearBeforeFill = true;
            // 
            // labelOrderCount
            // 
            this.labelOrderCount.Location = new System.Drawing.Point(408, 19);
            this.labelOrderCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOrderCount.Name = "labelOrderCount";
            this.labelOrderCount.Size = new System.Drawing.Size(90, 16);
            this.labelOrderCount.TabIndex = 3;
            this.labelOrderCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCash
            // 
            this.labelCash.Location = new System.Drawing.Point(310, 19);
            this.labelCash.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCash.Name = "labelCash";
            this.labelCash.Size = new System.Drawing.Size(90, 16);
            this.labelCash.TabIndex = 4;
            this.labelCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCredit
            // 
            this.labelCredit.Location = new System.Drawing.Point(212, 19);
            this.labelCredit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCredit.Name = "labelCredit";
            this.labelCredit.Size = new System.Drawing.Size(90, 16);
            this.labelCredit.TabIndex = 5;
            this.labelCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRevenue
            // 
            this.labelRevenue.Location = new System.Drawing.Point(114, 19);
            this.labelRevenue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRevenue.Name = "labelRevenue";
            this.labelRevenue.Size = new System.Drawing.Size(90, 16);
            this.labelRevenue.TabIndex = 6;
            this.labelRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 48);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1004, 13);
            this.progressBar1.TabIndex = 7;
            this.progressBar1.Visible = false;
            // 
            // labelCreditNet
            // 
            this.labelCreditNet.Location = new System.Drawing.Point(616, 21);
            this.labelCreditNet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCreditNet.Name = "labelCreditNet";
            this.labelCreditNet.Size = new System.Drawing.Size(90, 16);
            this.labelCreditNet.TabIndex = 8;
            this.labelCreditNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCreditFee
            // 
            this.labelCreditFee.Location = new System.Drawing.Point(714, 21);
            this.labelCreditFee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCreditFee.Name = "labelCreditFee";
            this.labelCreditFee.Size = new System.Drawing.Size(90, 16);
            this.labelCreditFee.TabIndex = 9;
            this.labelCreditFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CreditNet
            // 
            this.CreditNet.DataPropertyName = "CreditNet";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CreditNet.DefaultCellStyle = dataGridViewCellStyle8;
            this.CreditNet.HeaderText = "刷卡淨收";
            this.CreditNet.Name = "CreditNet";
            // 
            // CreditFee
            // 
            this.CreditFee.DataPropertyName = "CreditFee";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CreditFee.DefaultCellStyle = dataGridViewCellStyle9;
            this.CreditFee.HeaderText = "手續費";
            this.CreditFee.Name = "CreditFee";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Date";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column1.HeaderText = "日期";
            this.Column1.Name = "Column1";
            this.Column1.Width = 64;
            // 
            // labelFeeRate
            // 
            this.labelFeeRate.Location = new System.Drawing.Point(812, 21);
            this.labelFeeRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFeeRate.Name = "labelFeeRate";
            this.labelFeeRate.Size = new System.Drawing.Size(65, 16);
            this.labelFeeRate.TabIndex = 10;
            this.labelFeeRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.dateDataGridViewTextBoxColumn.HeaderText = "日期";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.Width = 64;
            // 
            // revenueDataGridViewTextBoxColumn
            // 
            this.revenueDataGridViewTextBoxColumn.DataPropertyName = "Revenue";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.revenueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.revenueDataGridViewTextBoxColumn.HeaderText = "營收";
            this.revenueDataGridViewTextBoxColumn.Name = "revenueDataGridViewTextBoxColumn";
            // 
            // creditCardDataGridViewTextBoxColumn
            // 
            this.creditCardDataGridViewTextBoxColumn.DataPropertyName = "CreditCard";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.creditCardDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.creditCardDataGridViewTextBoxColumn.HeaderText = "刷卡";
            this.creditCardDataGridViewTextBoxColumn.Name = "creditCardDataGridViewTextBoxColumn";
            // 
            // cashDataGridViewTextBoxColumn
            // 
            this.cashDataGridViewTextBoxColumn.DataPropertyName = "Cash";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cashDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.cashDataGridViewTextBoxColumn.HeaderText = "現金";
            this.cashDataGridViewTextBoxColumn.Name = "cashDataGridViewTextBoxColumn";
            // 
            // orderCountDataGridViewTextBoxColumn
            // 
            this.orderCountDataGridViewTextBoxColumn.DataPropertyName = "OrderCount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.orderCountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.orderCountDataGridViewTextBoxColumn.HeaderText = "檔數";
            this.orderCountDataGridViewTextBoxColumn.Name = "orderCountDataGridViewTextBoxColumn";
            // 
            // avePerPersonDataGridViewTextBoxColumn
            // 
            this.avePerPersonDataGridViewTextBoxColumn.DataPropertyName = "AvePerPerson";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.avePerPersonDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.avePerPersonDataGridViewTextBoxColumn.HeaderText = "人均";
            this.avePerPersonDataGridViewTextBoxColumn.Name = "avePerPersonDataGridViewTextBoxColumn";
            // 
            // monthlyReportDataBindingSource
            // 
            this.monthlyReportDataBindingSource.DataSource = typeof(VoucherExpense.MonthlyReportData);
            // 
            // MonthlyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(226)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(890, 644);
            this.Controls.Add(this.labelFeeRate);
            this.Controls.Add(this.labelCreditFee);
            this.Controls.Add(this.labelCreditNet);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelRevenue);
            this.Controls.Add(this.labelCredit);
            this.Controls.Add(this.labelCash);
            this.Controls.Add(this.labelOrderCount);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.checkBoxUse12);
            this.Controls.Add(this.dgViewMonthly);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MonthlyReport";
            this.Text = "收入月報";
            this.Load += new System.EventHandler(this.MonthlyReport_Load);
            this.SizeChanged += new System.EventHandler(this.MonthlyReport_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMonthly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basicDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyReportDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgViewMonthly;
        private System.Windows.Forms.BindingSource monthlyReportDataBindingSource;
        private BasicDataSet basicDataSet1;
        private System.Windows.Forms.CheckBox checkBoxUse12;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private BasicDataSetTableAdapters.HeaderTableAdapter headerTableAdapter1;
        private System.Windows.Forms.Label labelOrderCount;
        private System.Windows.Forms.Label labelCash;
        private System.Windows.Forms.Label labelCredit;
        private System.Windows.Forms.Label labelRevenue;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelCreditNet;
        private System.Windows.Forms.Label labelCreditFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn revenueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditCardDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cashDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avePerPersonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditNet;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label labelFeeRate;
    }
}