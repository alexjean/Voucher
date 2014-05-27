namespace VoucherExpense
{
    partial class FormMonthlyIncome
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnIncludeTotal = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.labelWarning2 = new System.Windows.Forms.Label();
            this.labelWarning1 = new System.Windows.Forms.Label();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgViewMonthlyIncome = new System.Windows.Forms.DataGridView();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.damaiDataSet = new VoucherExpense.DamaiDataSet();
            this.cMonthlyIncomeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.customerTableAdapter = new VoucherExpense.DamaiDataSetTableAdapters.CustomerTableAdapter();
            this.shipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shipmentTableAdapter = new VoucherExpense.DamaiDataSetTableAdapters.ShipmentTableAdapter();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.customerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.shipmentCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMonthlyIncome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonthlyIncomeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AllowDrop = true;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(18, 33);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 16);
            label1.TabIndex = 69;
            label1.Text = "月  份:";
            // 
            // btnIncludeTotal
            // 
            this.btnIncludeTotal.Location = new System.Drawing.Point(581, 96);
            this.btnIncludeTotal.Margin = new System.Windows.Forms.Padding(4);
            this.btnIncludeTotal.Name = "btnIncludeTotal";
            this.btnIncludeTotal.Size = new System.Drawing.Size(119, 31);
            this.btnIncludeTotal.TabIndex = 76;
            this.btnIncludeTotal.Text = "列印含小計";
            this.btnIncludeTotal.UseVisualStyleBackColor = true;
            this.btnIncludeTotal.Click += new System.EventHandler(this.btnIncludeTotal_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(581, 33);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(119, 31);
            this.btnPrint.TabIndex = 75;
            this.btnPrint.Text = "印簽收單";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // labelWarning2
            // 
            this.labelWarning2.AutoSize = true;
            this.labelWarning2.Location = new System.Drawing.Point(155, 457);
            this.labelWarning2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWarning2.Name = "labelWarning2";
            this.labelWarning2.Size = new System.Drawing.Size(216, 16);
            this.labelWarning2.TabIndex = 74;
            this.labelWarning2.Text = "未核可的單子己計入在金額上";
            // 
            // labelWarning1
            // 
            this.labelWarning1.AutoSize = true;
            this.labelWarning1.Location = new System.Drawing.Point(155, 392);
            this.labelWarning1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWarning1.Name = "labelWarning1";
            this.labelWarning1.Size = new System.Drawing.Size(216, 16);
            this.labelWarning1.TabIndex = 73;
            this.labelWarning1.Text = "己核可的單據才加總在單數上";
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxTotal.Location = new System.Drawing.Point(369, 27);
            this.textBoxTotal.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(148, 27);
            this.textBoxTotal.TabIndex = 72;
            this.textBoxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 71;
            this.label2.Text = "小計";
            // 
            // dgViewMonthlyIncome
            // 
            this.dgViewMonthlyIncome.AllowUserToAddRows = false;
            this.dgViewMonthlyIncome.AllowUserToDeleteRows = false;
            this.dgViewMonthlyIncome.AllowUserToOrderColumns = true;
            this.dgViewMonthlyIncome.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dgViewMonthlyIncome.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgViewMonthlyIncome.AutoGenerateColumns = false;
            this.dgViewMonthlyIncome.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgViewMonthlyIncome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewMonthlyIncome.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customerIDDataGridViewTextBoxColumn,
            this.shipmentCountDataGridViewTextBoxColumn,
            this.moneyDataGridViewTextBoxColumn});
            this.dgViewMonthlyIncome.DataSource = this.cMonthlyIncomeBindingSource;
            this.dgViewMonthlyIncome.Location = new System.Drawing.Point(13, 83);
            this.dgViewMonthlyIncome.Margin = new System.Windows.Forms.Padding(4);
            this.dgViewMonthlyIncome.Name = "dgViewMonthlyIncome";
            this.dgViewMonthlyIncome.ReadOnly = true;
            this.dgViewMonthlyIncome.RowHeadersVisible = false;
            this.dgViewMonthlyIncome.RowTemplate.Height = 24;
            this.dgViewMonthlyIncome.Size = new System.Drawing.Size(504, 581);
            this.dgViewMonthlyIncome.TabIndex = 70;
            this.dgViewMonthlyIncome.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgViewMonthlyIncome_DataError);
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataMember = "Customer";
            this.customerBindingSource.DataSource = this.damaiDataSet;
            // 
            // damaiDataSet
            // 
            this.damaiDataSet.DataSetName = "DamaiDataSet";
            this.damaiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cMonthlyIncomeBindingSource
            // 
            this.cMonthlyIncomeBindingSource.DataSource = typeof(VoucherExpense.FormMonthlyIncome.CMonthlyIncome);
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
            this.comboBoxMonth.Location = new System.Drawing.Point(96, 30);
            this.comboBoxMonth.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(134, 24);
            this.comboBoxMonth.TabIndex = 68;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // customerTableAdapter
            // 
            this.customerTableAdapter.ClearBeforeFill = true;
            // 
            // shipmentBindingSource
            // 
            this.shipmentBindingSource.DataMember = "Shipment";
            this.shipmentBindingSource.DataSource = this.damaiDataSet;
            // 
            // shipmentTableAdapter
            // 
            this.shipmentTableAdapter.ClearBeforeFill = true;
            // 
            // printDocument
            // 
            this.printDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_BeginPrint);
            this.printDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_EndPrint);
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            this.printDocument.QueryPageSettings += new System.Drawing.Printing.QueryPageSettingsEventHandler(this.printDocument_QueryPageSettings);
            // 
            // customerIDDataGridViewTextBoxColumn
            // 
            this.customerIDDataGridViewTextBoxColumn.DataPropertyName = "CustomerID";
            this.customerIDDataGridViewTextBoxColumn.DataSource = this.customerBindingSource;
            this.customerIDDataGridViewTextBoxColumn.DisplayMember = "Name";
            this.customerIDDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.customerIDDataGridViewTextBoxColumn.HeaderText = "客户";
            this.customerIDDataGridViewTextBoxColumn.Name = "customerIDDataGridViewTextBoxColumn";
            this.customerIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.customerIDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.customerIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.customerIDDataGridViewTextBoxColumn.ValueMember = "CustomerID";
            this.customerIDDataGridViewTextBoxColumn.Width = 160;
            // 
            // shipmentCountDataGridViewTextBoxColumn
            // 
            this.shipmentCountDataGridViewTextBoxColumn.DataPropertyName = "ShipmentCount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.shipmentCountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.shipmentCountDataGridViewTextBoxColumn.HeaderText = "核可单数";
            this.shipmentCountDataGridViewTextBoxColumn.Name = "shipmentCountDataGridViewTextBoxColumn";
            this.shipmentCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // moneyDataGridViewTextBoxColumn
            // 
            this.moneyDataGridViewTextBoxColumn.DataPropertyName = "Money";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N1";
            this.moneyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.moneyDataGridViewTextBoxColumn.HeaderText = "金额";
            this.moneyDataGridViewTextBoxColumn.Name = "moneyDataGridViewTextBoxColumn";
            this.moneyDataGridViewTextBoxColumn.ReadOnly = true;
            this.moneyDataGridViewTextBoxColumn.Width = 140;
            // 
            // FormMonthlyIncome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(761, 705);
            this.Controls.Add(this.btnIncludeTotal);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.labelWarning2);
            this.Controls.Add(this.labelWarning1);
            this.Controls.Add(this.textBoxTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgViewMonthlyIncome);
            this.Controls.Add(label1);
            this.Controls.Add(this.comboBoxMonth);
            this.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMonthlyIncome";
            this.Text = "收款统计";
            this.Load += new System.EventHandler(this.FormMonthlyIncome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMonthlyIncome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonthlyIncomeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIncludeTotal;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label labelWarning2;
        private System.Windows.Forms.Label labelWarning1;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgViewMonthlyIncome;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private DamaiDataSet damaiDataSet;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private DamaiDataSetTableAdapters.CustomerTableAdapter customerTableAdapter;
        private System.Windows.Forms.BindingSource shipmentBindingSource;
        private DamaiDataSetTableAdapters.ShipmentTableAdapter shipmentTableAdapter;
        private System.Windows.Forms.BindingSource cMonthlyIncomeBindingSource;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.DataGridViewComboBoxColumn customerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipmentCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneyDataGridViewTextBoxColumn;
    }
}