namespace VoucherExpense
{
    partial class MonthlyReportBakery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgViewMonthly = new System.Windows.Forms.DataGridView();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.revenueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cashDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditCardDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Coupond = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avePerPersonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnedCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnedMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeletedCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeletedMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthlyReportDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bakeryOrderSet = new VoucherExpense.BakeryOrderSet();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.labelOrderCount = new System.Windows.Forms.Label();
            this.labelCash = new System.Windows.Forms.Label();
            this.labelCredit = new System.Windows.Forms.Label();
            this.labelRevenue = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelCreditNet = new System.Windows.Forms.Label();
            this.labelCreditFee = new System.Windows.Forms.Label();
            this.labelFeeRate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMonthly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyReportDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgViewMonthly
            // 
            this.dgViewMonthly.AllowUserToAddRows = false;
            this.dgViewMonthly.AllowUserToDeleteRows = false;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.Azure;
            this.dgViewMonthly.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle18;
            this.dgViewMonthly.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgViewMonthly.AutoGenerateColumns = false;
            this.dgViewMonthly.BackgroundColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle19.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewMonthly.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgViewMonthly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewMonthly.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateDataGridViewTextBoxColumn,
            this.revenueDataGridViewTextBoxColumn,
            this.cashDataGridViewTextBoxColumn,
            this.creditCardDataGridViewTextBoxColumn,
            this.Coupond,
            this.orderCountDataGridViewTextBoxColumn,
            this.avePerPersonDataGridViewTextBoxColumn,
            this.Deduct,
            this.ReturnedCount,
            this.ReturnedMoney,
            this.DeletedCount,
            this.DeletedMoney,
            this.CreditNet,
            this.CreditFee,
            this.Column1});
            this.dgViewMonthly.DataSource = this.monthlyReportDataBindingSource;
            this.dgViewMonthly.Location = new System.Drawing.Point(0, 34);
            this.dgViewMonthly.Margin = new System.Windows.Forms.Padding(4);
            this.dgViewMonthly.Name = "dgViewMonthly";
            this.dgViewMonthly.ReadOnly = true;
            this.dgViewMonthly.RowHeadersWidth = 25;
            this.dgViewMonthly.RowTemplate.Height = 24;
            this.dgViewMonthly.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgViewMonthly.Size = new System.Drawing.Size(1141, 410);
            this.dgViewMonthly.TabIndex = 0;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "DayAndWeekDay";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.NullValue = null;
            this.dateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle20;
            this.dateDataGridViewTextBoxColumn.HeaderText = "日期";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateDataGridViewTextBoxColumn.Width = 64;
            // 
            // revenueDataGridViewTextBoxColumn
            // 
            this.revenueDataGridViewTextBoxColumn.DataPropertyName = "Revenue";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.revenueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle21;
            this.revenueDataGridViewTextBoxColumn.HeaderText = "營收";
            this.revenueDataGridViewTextBoxColumn.Name = "revenueDataGridViewTextBoxColumn";
            this.revenueDataGridViewTextBoxColumn.ReadOnly = true;
            this.revenueDataGridViewTextBoxColumn.Width = 80;
            // 
            // cashDataGridViewTextBoxColumn
            // 
            this.cashDataGridViewTextBoxColumn.DataPropertyName = "Cash";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cashDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle22;
            this.cashDataGridViewTextBoxColumn.HeaderText = "現金";
            this.cashDataGridViewTextBoxColumn.Name = "cashDataGridViewTextBoxColumn";
            this.cashDataGridViewTextBoxColumn.ReadOnly = true;
            this.cashDataGridViewTextBoxColumn.Width = 80;
            // 
            // creditCardDataGridViewTextBoxColumn
            // 
            this.creditCardDataGridViewTextBoxColumn.DataPropertyName = "CreditCard";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.creditCardDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle23;
            this.creditCardDataGridViewTextBoxColumn.HeaderText = "刷卡";
            this.creditCardDataGridViewTextBoxColumn.Name = "creditCardDataGridViewTextBoxColumn";
            this.creditCardDataGridViewTextBoxColumn.ReadOnly = true;
            this.creditCardDataGridViewTextBoxColumn.Width = 80;
            // 
            // Coupond
            // 
            this.Coupond.DataPropertyName = "Coupond";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Coupond.DefaultCellStyle = dataGridViewCellStyle24;
            this.Coupond.HeaderText = "券";
            this.Coupond.Name = "Coupond";
            this.Coupond.ReadOnly = true;
            this.Coupond.Width = 80;
            // 
            // orderCountDataGridViewTextBoxColumn
            // 
            this.orderCountDataGridViewTextBoxColumn.DataPropertyName = "OrderCount";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.orderCountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle25;
            this.orderCountDataGridViewTextBoxColumn.HeaderText = "單數";
            this.orderCountDataGridViewTextBoxColumn.Name = "orderCountDataGridViewTextBoxColumn";
            this.orderCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderCountDataGridViewTextBoxColumn.Width = 64;
            // 
            // avePerPersonDataGridViewTextBoxColumn
            // 
            this.avePerPersonDataGridViewTextBoxColumn.DataPropertyName = "AvePerPerson";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.avePerPersonDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle26;
            this.avePerPersonDataGridViewTextBoxColumn.HeaderText = "人均";
            this.avePerPersonDataGridViewTextBoxColumn.Name = "avePerPersonDataGridViewTextBoxColumn";
            this.avePerPersonDataGridViewTextBoxColumn.ReadOnly = true;
            this.avePerPersonDataGridViewTextBoxColumn.Width = 64;
            // 
            // Deduct
            // 
            this.Deduct.DataPropertyName = "Deduct";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Deduct.DefaultCellStyle = dataGridViewCellStyle27;
            this.Deduct.HeaderText = "优惠";
            this.Deduct.Name = "Deduct";
            this.Deduct.ReadOnly = true;
            this.Deduct.Width = 64;
            // 
            // ReturnedCount
            // 
            this.ReturnedCount.DataPropertyName = "ReturnedCount";
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ReturnedCount.DefaultCellStyle = dataGridViewCellStyle28;
            this.ReturnedCount.HeaderText = "退單";
            this.ReturnedCount.Name = "ReturnedCount";
            this.ReturnedCount.ReadOnly = true;
            this.ReturnedCount.Width = 64;
            // 
            // ReturnedMoney
            // 
            this.ReturnedMoney.DataPropertyName = "ReturnedMoney";
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ReturnedMoney.DefaultCellStyle = dataGridViewCellStyle29;
            this.ReturnedMoney.HeaderText = "退金額";
            this.ReturnedMoney.Name = "ReturnedMoney";
            this.ReturnedMoney.ReadOnly = true;
            this.ReturnedMoney.Width = 80;
            // 
            // DeletedCount
            // 
            this.DeletedCount.DataPropertyName = "DeletedCount";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DeletedCount.DefaultCellStyle = dataGridViewCellStyle30;
            this.DeletedCount.HeaderText = "癈單";
            this.DeletedCount.Name = "DeletedCount";
            this.DeletedCount.ReadOnly = true;
            this.DeletedCount.Width = 64;
            // 
            // DeletedMoney
            // 
            this.DeletedMoney.DataPropertyName = "DeletedMoney";
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DeletedMoney.DefaultCellStyle = dataGridViewCellStyle31;
            this.DeletedMoney.HeaderText = "癈金額";
            this.DeletedMoney.Name = "DeletedMoney";
            this.DeletedMoney.ReadOnly = true;
            this.DeletedMoney.Width = 80;
            // 
            // CreditNet
            // 
            this.CreditNet.DataPropertyName = "CreditNet";
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CreditNet.DefaultCellStyle = dataGridViewCellStyle32;
            this.CreditNet.HeaderText = "刷卡淨收";
            this.CreditNet.Name = "CreditNet";
            this.CreditNet.ReadOnly = true;
            // 
            // CreditFee
            // 
            this.CreditFee.DataPropertyName = "CreditFee";
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CreditFee.DefaultCellStyle = dataGridViewCellStyle33;
            this.CreditFee.HeaderText = "手續費";
            this.CreditFee.Name = "CreditFee";
            this.CreditFee.ReadOnly = true;
            this.CreditFee.Width = 80;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Date";
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle34.Format = "dd";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle34;
            this.Column1.HeaderText = "日期";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 64;
            // 
            // monthlyReportDataBindingSource
            // 
            this.monthlyReportDataBindingSource.DataSource = typeof(VoucherExpense.MonthlyReportData);
            // 
            // bakeryOrderSet
            // 
            this.bakeryOrderSet.DataSetName = "BakeryOrderSet";
            this.bakeryOrderSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.comboBoxMonth.Location = new System.Drawing.Point(13, 2);
            this.comboBoxMonth.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(84, 24);
            this.comboBoxMonth.TabIndex = 2;
            // 
            // labelOrderCount
            // 
            this.labelOrderCount.Location = new System.Drawing.Point(406, 8);
            this.labelOrderCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOrderCount.Name = "labelOrderCount";
            this.labelOrderCount.Size = new System.Drawing.Size(64, 14);
            this.labelOrderCount.TabIndex = 3;
            this.labelOrderCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCash
            // 
            this.labelCash.Location = new System.Drawing.Point(184, 7);
            this.labelCash.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCash.Name = "labelCash";
            this.labelCash.Size = new System.Drawing.Size(67, 16);
            this.labelCash.TabIndex = 4;
            this.labelCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCredit
            // 
            this.labelCredit.Location = new System.Drawing.Point(250, 7);
            this.labelCredit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCredit.Name = "labelCredit";
            this.labelCredit.Size = new System.Drawing.Size(75, 16);
            this.labelCredit.TabIndex = 5;
            this.labelCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRevenue
            // 
            this.labelRevenue.Location = new System.Drawing.Point(96, 7);
            this.labelRevenue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRevenue.Name = "labelRevenue";
            this.labelRevenue.Size = new System.Drawing.Size(71, 16);
            this.labelRevenue.TabIndex = 6;
            this.labelRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(0, 317);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1141, 40);
            this.progressBar1.TabIndex = 7;
            this.progressBar1.Visible = false;
            // 
            // labelCreditNet
            // 
            this.labelCreditNet.Location = new System.Drawing.Point(901, 7);
            this.labelCreditNet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCreditNet.Name = "labelCreditNet";
            this.labelCreditNet.Size = new System.Drawing.Size(79, 16);
            this.labelCreditNet.TabIndex = 8;
            this.labelCreditNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCreditFee
            // 
            this.labelCreditFee.Location = new System.Drawing.Point(978, 7);
            this.labelCreditFee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCreditFee.Name = "labelCreditFee";
            this.labelCreditFee.Size = new System.Drawing.Size(90, 16);
            this.labelCreditFee.TabIndex = 9;
            this.labelCreditFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelFeeRate
            // 
            this.labelFeeRate.Location = new System.Drawing.Point(1076, 7);
            this.labelFeeRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFeeRate.Name = "labelFeeRate";
            this.labelFeeRate.Size = new System.Drawing.Size(65, 16);
            this.labelFeeRate.TabIndex = 10;
            this.labelFeeRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MonthlyReportBakery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(226)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1141, 444);
            this.Controls.Add(this.labelFeeRate);
            this.Controls.Add(this.labelCreditFee);
            this.Controls.Add(this.labelCreditNet);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelRevenue);
            this.Controls.Add(this.labelCredit);
            this.Controls.Add(this.labelCash);
            this.Controls.Add(this.labelOrderCount);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.dgViewMonthly);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MonthlyReportBakery";
            this.Text = "烘焙收入月報";
            this.Load += new System.EventHandler(this.MonthlyReportBakery_Load);
            this.Shown += new System.EventHandler(this.MonthlyReportBakery_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMonthly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyReportDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgViewMonthly;
        private System.Windows.Forms.BindingSource monthlyReportDataBindingSource;
        private BakeryOrderSet bakeryOrderSet;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.Label labelOrderCount;
        private System.Windows.Forms.Label labelCash;
        private System.Windows.Forms.Label labelCredit;
        private System.Windows.Forms.Label labelRevenue;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelCreditNet;
        private System.Windows.Forms.Label labelCreditFee;
        private System.Windows.Forms.Label labelFeeRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn revenueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cashDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditCardDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coupond;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avePerPersonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnedCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnedMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeletedCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeletedMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditNet;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}