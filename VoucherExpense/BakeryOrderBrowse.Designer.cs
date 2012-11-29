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
            this.lvItems = new System.Windows.Forms.ListView();
            this.columnHeader代碼 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader品名 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader量 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader金額 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOrderList = new System.Windows.Forms.Button();
            this.btnDrawerOpenedList = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.bakeryOrderSet = new VoucherExpense.BakeryOrderSet();
            this.productTableAdapter = new VoucherExpense.BakeryOrderSetTableAdapters.ProductTableAdapter();
            this.cbBoxDay = new System.Windows.Forms.ComboBox();
            this.cbBoxMonth = new System.Windows.Forms.ComboBox();
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
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(663, 596);
            this.tabPage1.TabIndex = 0;
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
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 3;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 387);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "總計";
            // 
            // labelTotal
            // 
            this.labelTotal.Location = new System.Drawing.Point(59, 387);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(147, 16);
            this.labelTotal.TabIndex = 7;
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // cbBoxDay
            // 
            this.cbBoxDay.DropDownHeight = 216;
            this.cbBoxDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxDay.FormattingEnabled = true;
            this.cbBoxDay.IntegralHeight = false;
            this.cbBoxDay.Location = new System.Drawing.Point(140, 423);
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
            this.cbBoxMonth.Location = new System.Drawing.Point(25, 423);
            this.cbBoxMonth.Name = "cbBoxMonth";
            this.cbBoxMonth.Size = new System.Drawing.Size(71, 24);
            this.cbBoxMonth.TabIndex = 57;
            // 
            // BakeryOrderBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(908, 637);
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
    }
}