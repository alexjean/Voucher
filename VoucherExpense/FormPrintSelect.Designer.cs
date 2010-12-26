namespace VoucherExpense
{
    partial class FormPrintSelect
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.供貨商ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veDataSet1 = new VoucherExpense.VEDataSet();
            this.vendorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vendorTableAdapter = new VoucherExpense.VEDataSetTableAdapters.VendorTableAdapter();
            this.vendorDataGridView = new System.Windows.Forms.DataGridView();
            this.columnVendorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnVendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgViewUserSelected = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSelectedVoucherBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelCount = new System.Windows.Forms.Label();
            this.labelSum = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.veDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewUserSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSelectedVoucherBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.供貨商ToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(1, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(160, 65);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 供貨商ToolStripMenuItem
            // 
            this.供貨商ToolStripMenuItem.Name = "供貨商ToolStripMenuItem";
            this.供貨商ToolStripMenuItem.Size = new System.Drawing.Size(153, 20);
            this.供貨商ToolStripMenuItem.Text = "供貨商對帳";
            this.供貨商ToolStripMenuItem.Click += new System.EventHandler(this.供貨商ToolStripMenuItem_Click);
            // 
            // veDataSet1
            // 
            this.veDataSet1.DataSetName = "VEDataSet";
            this.veDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vendorBindingSource
            // 
            this.vendorBindingSource.DataMember = "Vendor";
            this.vendorBindingSource.DataSource = this.veDataSet1;
            this.vendorBindingSource.Filter = "Hide= false";
            // 
            // vendorTableAdapter
            // 
            this.vendorTableAdapter.ClearBeforeFill = true;
            // 
            // vendorDataGridView
            // 
            this.vendorDataGridView.AllowUserToAddRows = false;
            this.vendorDataGridView.AllowUserToDeleteRows = false;
            this.vendorDataGridView.AllowUserToOrderColumns = true;
            this.vendorDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.vendorDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.vendorDataGridView.AutoGenerateColumns = false;
            this.vendorDataGridView.BackgroundColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.vendorDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.vendorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnVendorID,
            this.columnVendorName});
            this.vendorDataGridView.DataSource = this.vendorBindingSource;
            this.vendorDataGridView.Dock = System.Windows.Forms.DockStyle.Right;
            this.vendorDataGridView.EnableHeadersVisualStyles = false;
            this.vendorDataGridView.Location = new System.Drawing.Point(162, 0);
            this.vendorDataGridView.Name = "vendorDataGridView";
            this.vendorDataGridView.ReadOnly = true;
            this.vendorDataGridView.RowHeadersVisible = false;
            this.vendorDataGridView.RowTemplate.Height = 24;
            this.vendorDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.vendorDataGridView.Size = new System.Drawing.Size(263, 497);
            this.vendorDataGridView.TabIndex = 2;
            // 
            // columnVendorID
            // 
            this.columnVendorID.DataPropertyName = "VendorID";
            this.columnVendorID.HeaderText = "代碼";
            this.columnVendorID.Name = "columnVendorID";
            this.columnVendorID.ReadOnly = true;
            this.columnVendorID.Width = 60;
            // 
            // columnVendorName
            // 
            this.columnVendorName.DataPropertyName = "Name";
            this.columnVendorName.HeaderText = "姓名";
            this.columnVendorName.Name = "columnVendorName";
            this.columnVendorName.ReadOnly = true;
            this.columnVendorName.Width = 180;
            // 
            // dgViewUserSelected
            // 
            this.dgViewUserSelected.AllowUserToAddRows = false;
            this.dgViewUserSelected.AllowUserToDeleteRows = false;
            this.dgViewUserSelected.AllowUserToOrderColumns = true;
            this.dgViewUserSelected.AllowUserToResizeRows = false;
            this.dgViewUserSelected.AutoGenerateColumns = false;
            this.dgViewUserSelected.BackgroundColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewUserSelected.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgViewUserSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewUserSelected.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.costDataGridViewTextBoxColumn});
            this.dgViewUserSelected.DataSource = this.cSelectedVoucherBindingSource;
            this.dgViewUserSelected.EnableHeadersVisualStyles = false;
            this.dgViewUserSelected.Location = new System.Drawing.Point(1, 49);
            this.dgViewUserSelected.Name = "dgViewUserSelected";
            this.dgViewUserSelected.ReadOnly = true;
            this.dgViewUserSelected.RowHeadersVisible = false;
            this.dgViewUserSelected.RowTemplate.Height = 24;
            this.dgViewUserSelected.Size = new System.Drawing.Size(160, 412);
            this.dgViewUserSelected.TabIndex = 3;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 50;
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.costDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.costDataGridViewTextBoxColumn.HeaderText = "金額";
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            this.costDataGridViewTextBoxColumn.ReadOnly = true;
            this.costDataGridViewTextBoxColumn.Width = 90;
            // 
            // cSelectedVoucherBindingSource
            // 
            this.cSelectedVoucherBindingSource.DataSource = typeof(VoucherExpense.CSelectedVoucher);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(1, 473);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(40, 16);
            this.labelCount.TabIndex = 4;
            this.labelCount.Text = "小計";
            // 
            // labelSum
            // 
            this.labelSum.Location = new System.Drawing.Point(66, 473);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(74, 16);
            this.labelSum.TabIndex = 5;
            this.labelSum.Text = "0";
            this.labelSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormPrintSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(425, 497);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.dgViewUserSelected);
            this.Controls.Add(this.vendorDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormPrintSelect";
            this.ShowIcon = false;
            this.Text = "選擇列印方法";
            this.Load += new System.EventHandler(this.FormPrintSelect_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.veDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewUserSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSelectedVoucherBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 供貨商ToolStripMenuItem;
        private VEDataSet veDataSet1;
        private System.Windows.Forms.BindingSource vendorBindingSource;
        private VoucherExpense.VEDataSetTableAdapters.VendorTableAdapter vendorTableAdapter;
        private System.Windows.Forms.DataGridView vendorDataGridView;
        private System.Windows.Forms.DataGridView dgViewUserSelected;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.BindingSource cSelectedVoucherBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnVendorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnVendorName;
    }
}