namespace VoucherExpense
{
    partial class FormMonthlyPay
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.dgViewMonthlyPay = new System.Windows.Forms.DataGridView();
            this.venderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.vendorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.orderCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMonthlyPayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelWarning1 = new System.Windows.Forms.Label();
            this.labelWarning2 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.btnIncludeTotal = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMonthlyPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonthlyPayBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AllowDrop = true;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(22, 17);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 16);
            label1.TabIndex = 60;
            label1.Text = "月  份:";
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
            this.comboBoxMonth.Location = new System.Drawing.Point(91, 13);
            this.comboBoxMonth.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(91, 24);
            this.comboBoxMonth.TabIndex = 59;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // dgViewMonthlyPay
            // 
            this.dgViewMonthlyPay.AllowUserToAddRows = false;
            this.dgViewMonthlyPay.AllowUserToDeleteRows = false;
            this.dgViewMonthlyPay.AllowUserToOrderColumns = true;
            this.dgViewMonthlyPay.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dgViewMonthlyPay.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgViewMonthlyPay.AutoGenerateColumns = false;
            this.dgViewMonthlyPay.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgViewMonthlyPay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewMonthlyPay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.venderIDDataGridViewTextBoxColumn,
            this.orderCountDataGridViewTextBoxColumn,
            this.moneyDataGridViewTextBoxColumn});
            this.dgViewMonthlyPay.DataSource = this.cMonthlyPayBindingSource;
            this.dgViewMonthlyPay.Location = new System.Drawing.Point(12, 52);
            this.dgViewMonthlyPay.Name = "dgViewMonthlyPay";
            this.dgViewMonthlyPay.ReadOnly = true;
            this.dgViewMonthlyPay.RowHeadersVisible = false;
            this.dgViewMonthlyPay.RowTemplate.Height = 24;
            this.dgViewMonthlyPay.Size = new System.Drawing.Size(453, 537);
            this.dgViewMonthlyPay.TabIndex = 61;
            this.dgViewMonthlyPay.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgViewMonthlyPay_DataError);
            // 
            // venderIDDataGridViewTextBoxColumn
            // 
            this.venderIDDataGridViewTextBoxColumn.DataPropertyName = "VenderID";
            this.venderIDDataGridViewTextBoxColumn.DataSource = this.vendorBindingSource;
            this.venderIDDataGridViewTextBoxColumn.DisplayMember = "Name";
            this.venderIDDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.venderIDDataGridViewTextBoxColumn.HeaderText = "廠商";
            this.venderIDDataGridViewTextBoxColumn.Name = "venderIDDataGridViewTextBoxColumn";
            this.venderIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.venderIDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.venderIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.venderIDDataGridViewTextBoxColumn.ValueMember = "VendorID";
            this.venderIDDataGridViewTextBoxColumn.Width = 160;
            // 
            // vendorBindingSource
            // 
            this.vendorBindingSource.DataMember = "Vendor";
            this.vendorBindingSource.DataSource = this.vEDataSet;
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // orderCountDataGridViewTextBoxColumn
            // 
            this.orderCountDataGridViewTextBoxColumn.DataPropertyName = "OrderCount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.orderCountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.orderCountDataGridViewTextBoxColumn.HeaderText = "核可單數";
            this.orderCountDataGridViewTextBoxColumn.Name = "orderCountDataGridViewTextBoxColumn";
            this.orderCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // moneyDataGridViewTextBoxColumn
            // 
            this.moneyDataGridViewTextBoxColumn.DataPropertyName = "Money";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N1";
            dataGridViewCellStyle3.NullValue = null;
            this.moneyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.moneyDataGridViewTextBoxColumn.HeaderText = "金額";
            this.moneyDataGridViewTextBoxColumn.Name = "moneyDataGridViewTextBoxColumn";
            this.moneyDataGridViewTextBoxColumn.ReadOnly = true;
            this.moneyDataGridViewTextBoxColumn.Width = 140;
            // 
            // cMonthlyPayBindingSource
            // 
            this.cMonthlyPayBindingSource.DataSource = typeof(VoucherExpense.FormMonthlyPay.CMonthlyPay);
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxTotal.Location = new System.Drawing.Point(313, 12);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(100, 27);
            this.textBoxTotal.TabIndex = 63;
            this.textBoxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 62;
            this.label2.Text = "小計";
            // 
            // labelWarning1
            // 
            this.labelWarning1.AutoSize = true;
            this.labelWarning1.Location = new System.Drawing.Point(135, 363);
            this.labelWarning1.Name = "labelWarning1";
            this.labelWarning1.Size = new System.Drawing.Size(216, 16);
            this.labelWarning1.TabIndex = 64;
            this.labelWarning1.Text = "己核可的單據才加總在單數上";
            // 
            // labelWarning2
            // 
            this.labelWarning2.AutoSize = true;
            this.labelWarning2.Location = new System.Drawing.Point(135, 400);
            this.labelWarning2.Name = "labelWarning2";
            this.labelWarning2.Size = new System.Drawing.Size(216, 16);
            this.labelWarning2.TabIndex = 65;
            this.labelWarning2.Text = "未核可的單子己計入在金額上";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(543, 17);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 23);
            this.btnPrint.TabIndex = 66;
            this.btnPrint.Text = "印簽收單";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printDocument
            // 
            this.printDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_BeginPrint);
            this.printDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_EndPrint);
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // btnIncludeTotal
            // 
            this.btnIncludeTotal.Location = new System.Drawing.Point(543, 64);
            this.btnIncludeTotal.Name = "btnIncludeTotal";
            this.btnIncludeTotal.Size = new System.Drawing.Size(100, 23);
            this.btnIncludeTotal.TabIndex = 67;
            this.btnIncludeTotal.Text = "列印含小計";
            this.btnIncludeTotal.UseVisualStyleBackColor = true;
            this.btnIncludeTotal.Click += new System.EventHandler(this.btnIncludeTotal_Click);
            // 
            // FormMonthlyPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(761, 601);
            this.Controls.Add(this.btnIncludeTotal);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.labelWarning2);
            this.Controls.Add(this.labelWarning1);
            this.Controls.Add(this.textBoxTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgViewMonthlyPay);
            this.Controls.Add(label1);
            this.Controls.Add(this.comboBoxMonth);
            this.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMonthlyPay";
            this.Text = "付款匯總";
            this.Load += new System.EventHandler(this.FormMonthlyPay_Load);
            this.SizeChanged += new System.EventHandler(this.FormMonthlyPay_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMonthlyPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMonthlyPayBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.DataGridView dgViewMonthlyPay;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource cMonthlyPayBindingSource;
        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource vendorBindingSource;
        private System.Windows.Forms.Label labelWarning1;
        private System.Windows.Forms.Label labelWarning2;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.Button btnIncludeTotal;
        private System.Windows.Forms.DataGridViewComboBoxColumn venderIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneyDataGridViewTextBoxColumn;
    }
}