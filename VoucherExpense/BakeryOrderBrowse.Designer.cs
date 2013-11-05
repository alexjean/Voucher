namespace VoucherExpense
{
    partial class BakeryOrderBrowse
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lvItems = new System.Windows.Forms.ListView();
            this.columnHeader代碼 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader品名 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader量 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader金額 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOrderList = new System.Windows.Forms.Button();
            this.btnDrawerOpenedList = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelTotalAverage = new System.Windows.Forms.Label();
            this.labelTotalRevenue = new System.Windows.Forms.Label();
            this.labelOrderCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelDgvTitle = new System.Windows.Forms.Label();
            this.dgvStatics = new System.Windows.Forms.DataGridView();
            this.ColumnHour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.revenueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.averageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hourStaticsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.cbBoxDay = new System.Windows.Forms.ComboBox();
            this.cbBoxMonth = new System.Windows.Forms.ComboBox();
            this.labelDeduct = new System.Windows.Forms.Label();
            this.labelDeductLabel = new System.Windows.Forms.Label();
            this.labelReturned = new System.Windows.Forms.Label();
            this.bakeryOrderSet = new VoucherExpense.BakeryOrderSet();
            this.productTableAdapter = new VoucherExpense.BakeryOrderSetTableAdapters.ProductTableAdapter();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hourStaticsBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).BeginInit();
            this.SuspendLayout();
            // 
            // lvItems
            // 
            this.lvItems.BackColor = System.Drawing.Color.SeaShell;
            this.lvItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader代碼,
            this.columnHeader品名,
            this.columnHeader量,
            this.columnHeader金額});
            this.lvItems.FullRowSelect = true;
            this.lvItems.HideSelection = false;
            this.lvItems.Location = new System.Drawing.Point(2, 0);
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(226, 367);
            this.lvItems.TabIndex = 2;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader代碼
            // 
            this.columnHeader代碼.Width = 2;
            // 
            // columnHeader品名
            // 
            this.columnHeader品名.Text = "品名";
            this.columnHeader品名.Width = 124;
            // 
            // columnHeader量
            // 
            this.columnHeader量.Text = "量";
            this.columnHeader量.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader量.Width = 30;
            // 
            // columnHeader金額
            // 
            this.columnHeader金額.Text = "金額";
            this.columnHeader金額.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader金額.Width = 52;
            // 
            // btnOrderList
            // 
            this.btnOrderList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOrderList.Location = new System.Drawing.Point(15, 569);
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.Size = new System.Drawing.Size(88, 56);
            this.btnOrderList.TabIndex = 4;
            this.btnOrderList.Text = "收入明細";
            this.btnOrderList.UseVisualStyleBackColor = true;
            this.btnOrderList.Click += new System.EventHandler(this.btnOrderList_Click);
            // 
            // btnDrawerOpenedList
            // 
            this.btnDrawerOpenedList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDrawerOpenedList.Location = new System.Drawing.Point(130, 569);
            this.btnDrawerOpenedList.Name = "btnDrawerOpenedList";
            this.btnDrawerOpenedList.Size = new System.Drawing.Size(88, 56);
            this.btnDrawerOpenedList.TabIndex = 5;
            this.btnDrawerOpenedList.Text = "錢箱記錄";
            this.btnDrawerOpenedList.UseVisualStyleBackColor = true;
            this.btnDrawerOpenedList.Click += new System.EventHandler(this.btnDrawerOpenedList_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.tabPage1.Controls.Add(this.labelTotalAverage);
            this.tabPage1.Controls.Add(this.labelTotalRevenue);
            this.tabPage1.Controls.Add(this.labelOrderCount);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.labelDgvTitle);
            this.tabPage1.Controls.Add(this.dgvStatics);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(663, 596);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "統計";
            // 
            // labelTotalAverage
            // 
            this.labelTotalAverage.Location = new System.Drawing.Point(244, 473);
            this.labelTotalAverage.Name = "labelTotalAverage";
            this.labelTotalAverage.Size = new System.Drawing.Size(51, 16);
            this.labelTotalAverage.TabIndex = 10;
            this.labelTotalAverage.Text = "0.0";
            this.labelTotalAverage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTotalRevenue
            // 
            this.labelTotalRevenue.Location = new System.Drawing.Point(150, 474);
            this.labelTotalRevenue.Name = "labelTotalRevenue";
            this.labelTotalRevenue.Size = new System.Drawing.Size(79, 16);
            this.labelTotalRevenue.TabIndex = 9;
            this.labelTotalRevenue.Text = "0";
            this.labelTotalRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelOrderCount
            // 
            this.labelOrderCount.Location = new System.Drawing.Point(61, 473);
            this.labelOrderCount.Name = "labelOrderCount";
            this.labelOrderCount.Size = new System.Drawing.Size(71, 16);
            this.labelOrderCount.TabIndex = 8;
            this.labelOrderCount.Text = "0";
            this.labelOrderCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 474);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "總計";
            // 
            // labelDgvTitle
            // 
            this.labelDgvTitle.AutoSize = true;
            this.labelDgvTitle.Location = new System.Drawing.Point(98, 13);
            this.labelDgvTitle.Name = "labelDgvTitle";
            this.labelDgvTitle.Size = new System.Drawing.Size(112, 16);
            this.labelDgvTitle.TabIndex = 1;
            this.labelDgvTitle.Text = "  月   日 統計表";
            // 
            // dgvStatics
            // 
            this.dgvStatics.AllowUserToAddRows = false;
            this.dgvStatics.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Azure;
            this.dgvStatics.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvStatics.AutoGenerateColumns = false;
            this.dgvStatics.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.dgvStatics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnHour,
            this.orderCountDataGridViewTextBoxColumn,
            this.revenueDataGridViewTextBoxColumn,
            this.averageDataGridViewTextBoxColumn});
            this.dgvStatics.DataSource = this.hourStaticsBindingSource;
            this.dgvStatics.Location = new System.Drawing.Point(0, 32);
            this.dgvStatics.Name = "dgvStatics";
            this.dgvStatics.ReadOnly = true;
            this.dgvStatics.RowHeadersVisible = false;
            this.dgvStatics.RowTemplate.Height = 24;
            this.dgvStatics.Size = new System.Drawing.Size(319, 439);
            this.dgvStatics.TabIndex = 0;
            // 
            // ColumnHour
            // 
            this.ColumnHour.DataPropertyName = "Hour";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnHour.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColumnHour.HeaderText = "時間";
            this.ColumnHour.Name = "ColumnHour";
            this.ColumnHour.ReadOnly = true;
            this.ColumnHour.Width = 64;
            // 
            // orderCountDataGridViewTextBoxColumn
            // 
            this.orderCountDataGridViewTextBoxColumn.DataPropertyName = "OrderCount";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.orderCountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.orderCountDataGridViewTextBoxColumn.HeaderText = "單數";
            this.orderCountDataGridViewTextBoxColumn.Name = "orderCountDataGridViewTextBoxColumn";
            this.orderCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderCountDataGridViewTextBoxColumn.Width = 64;
            // 
            // revenueDataGridViewTextBoxColumn
            // 
            this.revenueDataGridViewTextBoxColumn.DataPropertyName = "Revenue";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N1";
            dataGridViewCellStyle9.NullValue = null;
            this.revenueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.revenueDataGridViewTextBoxColumn.HeaderText = "營收";
            this.revenueDataGridViewTextBoxColumn.Name = "revenueDataGridViewTextBoxColumn";
            this.revenueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // averageDataGridViewTextBoxColumn
            // 
            this.averageDataGridViewTextBoxColumn.DataPropertyName = "Average";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N1";
            dataGridViewCellStyle10.NullValue = null;
            this.averageDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.averageDataGridViewTextBoxColumn.HeaderText = "人均";
            this.averageDataGridViewTextBoxColumn.Name = "averageDataGridViewTextBoxColumn";
            this.averageDataGridViewTextBoxColumn.ReadOnly = true;
            this.averageDataGridViewTextBoxColumn.Width = 64;
            // 
            // hourStaticsBindingSource
            // 
            this.hourStaticsBindingSource.DataSource = typeof(VoucherExpense.BakeryOrderBrowse.HourStatics);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.ItemSize = new System.Drawing.Size(48, 32);
            this.tabControl1.Location = new System.Drawing.Point(234, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(671, 636);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 3;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 426);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "總計";
            // 
            // labelTotal
            // 
            this.labelTotal.Location = new System.Drawing.Point(130, 426);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(71, 16);
            this.labelTotal.TabIndex = 7;
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbBoxDay
            // 
            this.cbBoxDay.DropDownHeight = 216;
            this.cbBoxDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxDay.FormattingEnabled = true;
            this.cbBoxDay.IntegralHeight = false;
            this.cbBoxDay.Location = new System.Drawing.Point(130, 459);
            this.cbBoxDay.Name = "cbBoxDay";
            this.cbBoxDay.Size = new System.Drawing.Size(71, 24);
            this.cbBoxDay.TabIndex = 58;
            // 
            // cbBoxMonth
            // 
            this.cbBoxMonth.DropDownHeight = 216;
            this.cbBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxMonth.FormattingEnabled = true;
            this.cbBoxMonth.IntegralHeight = false;
            this.cbBoxMonth.Items.AddRange(new object[] {
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
            this.cbBoxMonth.Location = new System.Drawing.Point(15, 459);
            this.cbBoxMonth.Name = "cbBoxMonth";
            this.cbBoxMonth.Size = new System.Drawing.Size(71, 24);
            this.cbBoxMonth.TabIndex = 57;
            // 
            // labelDeduct
            // 
            this.labelDeduct.Location = new System.Drawing.Point(130, 398);
            this.labelDeduct.Name = "labelDeduct";
            this.labelDeduct.Size = new System.Drawing.Size(71, 16);
            this.labelDeduct.TabIndex = 59;
            this.labelDeduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDeductLabel
            // 
            this.labelDeductLabel.AutoSize = true;
            this.labelDeductLabel.Location = new System.Drawing.Point(46, 398);
            this.labelDeductLabel.Name = "labelDeductLabel";
            this.labelDeductLabel.Size = new System.Drawing.Size(40, 16);
            this.labelDeductLabel.TabIndex = 60;
            this.labelDeductLabel.Text = "优惠";
            // 
            // labelReturned
            // 
            this.labelReturned.AutoSize = true;
            this.labelReturned.Location = new System.Drawing.Point(-1, 370);
            this.labelReturned.Name = "labelReturned";
            this.labelReturned.Size = new System.Drawing.Size(56, 16);
            this.labelReturned.TabIndex = 61;
            this.labelReturned.Text = "退貨號";
            this.labelReturned.Visible = false;
            // 
            // bakeryOrderSet
            // 
            this.bakeryOrderSet.DataSetName = "BakeryOrderSet";
            this.bakeryOrderSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // BakeryOrderBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(908, 637);
            this.Controls.Add(this.labelReturned);
            this.Controls.Add(this.labelDeductLabel);
            this.Controls.Add(this.labelDeduct);
            this.Controls.Add(this.cbBoxDay);
            this.Controls.Add(this.cbBoxMonth);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDrawerOpenedList);
            this.Controls.Add(this.btnOrderList);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lvItems);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BakeryOrderBrowse";
            this.ShowIcon = false;
            this.Text = "烘焙收入明細";
            this.Load += new System.EventHandler(this.BakeryOrderBrowse_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hourStaticsBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvItems;
        private System.Windows.Forms.ColumnHeader columnHeader代碼;
        private System.Windows.Forms.ColumnHeader columnHeader品名;
        private System.Windows.Forms.ColumnHeader columnHeader量;
        private System.Windows.Forms.ColumnHeader columnHeader金額;
        private System.Windows.Forms.Button btnOrderList;
        private System.Windows.Forms.Button btnDrawerOpenedList;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTotal;
        private BakeryOrderSet bakeryOrderSet;
        private BakeryOrderSetTableAdapters.ProductTableAdapter productTableAdapter;
        private System.Windows.Forms.ComboBox cbBoxDay;
        private System.Windows.Forms.ComboBox cbBoxMonth;
        private System.Windows.Forms.Label labelDeduct;
        private System.Windows.Forms.Label labelDeductLabel;
        private System.Windows.Forms.DataGridView dgvStatics;
        private System.Windows.Forms.BindingSource hourStaticsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHour;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn revenueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn averageDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label labelDgvTitle;
        private System.Windows.Forms.Label labelTotalRevenue;
        private System.Windows.Forms.Label labelOrderCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTotalAverage;
        private System.Windows.Forms.Label labelReturned;
    }
}