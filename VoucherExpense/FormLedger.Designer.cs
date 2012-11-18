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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLedger));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cLedgerTableBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.cLedgerTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cLedgerTableDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.accountingTitleBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.cLedgerTableBindingNavigator)).BeginInit();
            this.cLedgerTableBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cLedgerTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLedgerTableDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cLedgerTableBindingNavigator
            // 
            this.cLedgerTableBindingNavigator.AddNewItem = null;
            this.cLedgerTableBindingNavigator.BindingSource = this.cLedgerTableBindingSource;
            this.cLedgerTableBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.cLedgerTableBindingNavigator.DeleteItem = null;
            this.cLedgerTableBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.cLedgerTableBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.cLedgerTableBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.cLedgerTableBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.cLedgerTableBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.cLedgerTableBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.cLedgerTableBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.cLedgerTableBindingNavigator.Name = "cLedgerTableBindingNavigator";
            this.cLedgerTableBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.cLedgerTableBindingNavigator.Size = new System.Drawing.Size(203, 25);
            this.cLedgerTableBindingNavigator.TabIndex = 0;
            this.cLedgerTableBindingNavigator.Text = "bindingNavigator1";
            // 
            // cLedgerTableBindingSource
            // 
            this.cLedgerTableBindingSource.DataSource = typeof(VoucherExpense.CLedgerRow);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(29, 22);
            this.bindingNavigatorCountItem.Text = "/{0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目總數";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "移到最前面";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一個";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 25);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "目前的位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "移到下一個";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "移到最後面";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // cLedgerTableDataGridView
            // 
            this.cLedgerTableDataGridView.AllowUserToAddRows = false;
            this.cLedgerTableDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.cLedgerTableDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.cLedgerTableDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cLedgerTableDataGridView.AutoGenerateColumns = false;
            this.cLedgerTableDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.cLedgerTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cLedgerTableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.cLedgerTableDataGridView.DataSource = this.cLedgerTableBindingSource;
            this.cLedgerTableDataGridView.Location = new System.Drawing.Point(0, 28);
            this.cLedgerTableDataGridView.Name = "cLedgerTableDataGridView";
            this.cLedgerTableDataGridView.ReadOnly = true;
            this.cLedgerTableDataGridView.RowHeadersWidth = 25;
            this.cLedgerTableDataGridView.RowTemplate.Height = 24;
            this.cLedgerTableDataGridView.Size = new System.Drawing.Size(950, 610);
            this.cLedgerTableDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Date";
            this.dataGridViewTextBoxColumn1.HeaderText = "日期";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Note";
            this.dataGridViewTextBoxColumn2.HeaderText = "摘要";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "debt";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.NullValue = "\"\"";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn3.HeaderText = "借方";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "credit";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn4.HeaderText = "貸方";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "sum";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn5.HeaderText = "餘額";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
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
            this.comboBoxMonth.Location = new System.Drawing.Point(220, 1);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(71, 24);
            this.comboBoxMonth.TabIndex = 55;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // accountingTitleBindingSource
            // 
            this.accountingTitleBindingSource.DataMember = "AccountingTitle";
            this.accountingTitleBindingSource.DataSource = this.vEDataSet;
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
            this.comboBoxAccTitle.Location = new System.Drawing.Point(311, 1);
            this.comboBoxAccTitle.Name = "comboBoxAccTitle";
            this.comboBoxAccTitle.Size = new System.Drawing.Size(121, 24);
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
            this.labelMessage.Location = new System.Drawing.Point(524, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(203, 24);
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
            this.progressBar1.Size = new System.Drawing.Size(950, 23);
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
            // FormLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(950, 640);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.comboBoxAccTitle);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.cLedgerTableDataGridView);
            this.Controls.Add(this.cLedgerTableBindingNavigator);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormLedger";
            this.Text = "分類帳";
            this.Load += new System.EventHandler(this.FormLedger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cLedgerTableBindingNavigator)).EndInit();
            this.cLedgerTableBindingNavigator.ResumeLayout(false);
            this.cLedgerTableBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cLedgerTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLedgerTableDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource cLedgerTableBindingSource;
        private System.Windows.Forms.BindingNavigator cLedgerTableBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridView cLedgerTableDataGridView;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private VEDataSet vEDataSet;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}