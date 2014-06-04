namespace VoucherExpense
{
    partial class FormShipmentReport
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCalc = new System.Windows.Forms.Button();
            this.cbBoxTo = new System.Windows.Forms.ComboBox();
            this.cbBoxFrom = new System.Windows.Forms.ComboBox();
            this.cbBoxMonthTo = new System.Windows.Forms.ComboBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.tBTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBoxMonth = new System.Windows.Forms.ComboBox();
            this.damaiDataSet = new VoucherExpense.DamaiDataSet();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerTableAdapter = new VoucherExpense.DamaiDataSetTableAdapters.CustomerTableAdapter();
            this.nameComboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btPrint = new System.Windows.Forms.Button();
            this.pD = new System.Drawing.Printing.PrintDocument();
            this.tBCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AllowDrop = true;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(251, 16);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(24, 16);
            label3.TabIndex = 81;
            label3.Text = "至";
            // 
            // label1
            // 
            label1.AllowDrop = true;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(10, 19);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(40, 16);
            label1.TabIndex = 73;
            label1.Text = "月份";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(10, 50);
            nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(56, 16);
            nameLabel.TabIndex = 85;
            nameLabel.Text = "客户：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Azure;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("PMingLiU", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(13, 90);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(516, 555);
            this.dataGridView1.TabIndex = 74;
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(667, 7);
            this.btnCalc.Margin = new System.Windows.Forms.Padding(4);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(71, 48);
            this.btnCalc.TabIndex = 84;
            this.btnCalc.Text = "查询";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // cbBoxTo
            // 
            this.cbBoxTo.FormattingEnabled = true;
            this.cbBoxTo.Location = new System.Drawing.Point(379, 13);
            this.cbBoxTo.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbBoxTo.Name = "cbBoxTo";
            this.cbBoxTo.Size = new System.Drawing.Size(94, 24);
            this.cbBoxTo.TabIndex = 83;
            // 
            // cbBoxFrom
            // 
            this.cbBoxFrom.FormattingEnabled = true;
            this.cbBoxFrom.Location = new System.Drawing.Point(138, 13);
            this.cbBoxFrom.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbBoxFrom.Name = "cbBoxFrom";
            this.cbBoxFrom.Size = new System.Drawing.Size(88, 24);
            this.cbBoxFrom.TabIndex = 82;
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
            this.cbBoxMonthTo.Location = new System.Drawing.Point(285, 13);
            this.cbBoxMonthTo.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbBoxMonthTo.Name = "cbBoxMonthTo";
            this.cbBoxMonthTo.Size = new System.Drawing.Size(83, 24);
            this.cbBoxMonthTo.TabIndex = 80;
            this.cbBoxMonthTo.SelectedIndexChanged += new System.EventHandler(this.cbBoxMonthTo_SelectedIndexChanged);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(762, 662);
            this.labelCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(62, 16);
            this.labelCount.TabIndex = 79;
            this.labelCount.Text = "共XX張";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(960, 33);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 31);
            this.btnPrint.TabIndex = 77;
            this.btnPrint.Text = "列印";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // tBTotal
            // 
            this.tBTotal.BackColor = System.Drawing.SystemColors.Window;
            this.tBTotal.Location = new System.Drawing.Point(134, 659);
            this.tBTotal.Margin = new System.Windows.Forms.Padding(4);
            this.tBTotal.Name = "tBTotal";
            this.tBTotal.ReadOnly = true;
            this.tBTotal.Size = new System.Drawing.Size(142, 27);
            this.tBTotal.TabIndex = 76;
            this.tBTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 662);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 75;
            this.label2.Text = "金额小計";
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
            this.cbBoxMonth.Location = new System.Drawing.Point(53, 13);
            this.cbBoxMonth.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbBoxMonth.Name = "cbBoxMonth";
            this.cbBoxMonth.Size = new System.Drawing.Size(73, 24);
            this.cbBoxMonth.TabIndex = 70;
            this.cbBoxMonth.SelectedIndexChanged += new System.EventHandler(this.cbBoxMonth_SelectedIndexChanged);
            // 
            // damaiDataSet
            // 
            this.damaiDataSet.DataSetName = "DamaiDataSet";
            this.damaiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataMember = "Customer";
            this.customerBindingSource.DataSource = this.damaiDataSet;
            // 
            // customerTableAdapter
            // 
            this.customerTableAdapter.ClearBeforeFill = true;
            // 
            // nameComboBox
            // 
            this.nameComboBox.DataSource = this.customerBindingSource;
            this.nameComboBox.DisplayMember = "Name";
            this.nameComboBox.FormattingEnabled = true;
            this.nameComboBox.Location = new System.Drawing.Point(72, 46);
            this.nameComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.nameComboBox.Name = "nameComboBox";
            this.nameComboBox.Size = new System.Drawing.Size(140, 24);
            this.nameComboBox.TabIndex = 86;
            this.nameComboBox.ValueMember = "CustomerID";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Azure;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("PMingLiU", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.Location = new System.Drawing.Point(563, 90);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 25;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(353, 555);
            this.dataGridView2.TabIndex = 78;
            // 
            // btPrint
            // 
            this.btPrint.Location = new System.Drawing.Point(746, 7);
            this.btPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(71, 48);
            this.btPrint.TabIndex = 87;
            this.btPrint.Text = "列印";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // pD
            // 
            this.pD.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pD_PrintPage);
            // 
            // tBCount
            // 
            this.tBCount.BackColor = System.Drawing.SystemColors.Window;
            this.tBCount.Location = new System.Drawing.Point(361, 658);
            this.tBCount.Margin = new System.Windows.Forms.Padding(4);
            this.tBCount.Name = "tBCount";
            this.tBCount.ReadOnly = true;
            this.tBCount.Size = new System.Drawing.Size(142, 27);
            this.tBCount.TabIndex = 89;
            this.tBCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 661);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 88;
            this.label4.Text = "量小計";
            // 
            // FormShipmentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 718);
            this.Controls.Add(this.tBCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameComboBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.cbBoxTo);
            this.Controls.Add(this.cbBoxFrom);
            this.Controls.Add(label3);
            this.Controls.Add(this.cbBoxMonthTo);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.tBTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.cbBoxMonth);
            this.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormShipmentReport";
            this.Text = "出货统计";
            this.Load += new System.EventHandler(this.FormShipmentReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.ComboBox cbBoxTo;
        private System.Windows.Forms.ComboBox cbBoxFrom;
        private System.Windows.Forms.ComboBox cbBoxMonthTo;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox tBTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbBoxMonth;
        private DamaiDataSet damaiDataSet;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private DamaiDataSetTableAdapters.CustomerTableAdapter customerTableAdapter;
        private System.Windows.Forms.ComboBox nameComboBox;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btPrint;
        private System.Drawing.Printing.PrintDocument pD;
        private System.Windows.Forms.TextBox tBCount;
        private System.Windows.Forms.Label label4;
    }
}