namespace VoucherExpense
{
    partial class FormBankDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBankDetail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bankDetailBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bankBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bankDetailBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.dgvBankDetail = new System.Windows.Forms.DataGridView();
            this.columnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnAccount = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bankAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.columnIsCredit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.accountingTitleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.cbSelectBank = new System.Windows.Forms.ComboBox();
            this.cBankAccountForComboBoxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkBoxSort = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bankDetailBindingNavigator)).BeginInit();
            this.bankDetailBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBankDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBankAccountForComboBoxBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bankDetailBindingNavigator
            // 
            this.bankDetailBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bankDetailBindingNavigator.BindingSource = this.bankBindingSource;
            this.bankDetailBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.bankDetailBindingNavigator.DeleteItem = null;
            this.bankDetailBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.bankDetailBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bankDetailBindingNavigatorSaveItem});
            this.bankDetailBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.bankDetailBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bankDetailBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bankDetailBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bankDetailBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bankDetailBindingNavigator.Name = "bankDetailBindingNavigator";
            this.bankDetailBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.bankDetailBindingNavigator.Size = new System.Drawing.Size(249, 27);
            this.bankDetailBindingNavigator.TabIndex = 0;
            this.bankDetailBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorAddNewItem.Text = "加入新的";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bankBindingSource
            // 
            this.bankBindingSource.DataMember = "BankDetail";
            this.bankBindingSource.DataSource = this.vEDataSet;
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorCountItem.Text = "/{0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目總數";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveFirstItem.Text = "移到最前面";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一個";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "目前的位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveNextItem.Text = "移到下一個";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveLastItem.Text = "移到最後面";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // bankDetailBindingNavigatorSaveItem
            // 
            this.bankDetailBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bankDetailBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("bankDetailBindingNavigatorSaveItem.Image")));
            this.bankDetailBindingNavigatorSaveItem.Name = "bankDetailBindingNavigatorSaveItem";
            this.bankDetailBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 24);
            this.bankDetailBindingNavigatorSaveItem.Text = "儲存資料";
            this.bankDetailBindingNavigatorSaveItem.Click += new System.EventHandler(this.bankDetailBindingNavigatorSaveItem_Click);
            // 
            // dgvBankDetail
            // 
            this.dgvBankDetail.AllowUserToAddRows = false;
            this.dgvBankDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBankDetail.AutoGenerateColumns = false;
            this.dgvBankDetail.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgvBankDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBankDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnID,
            this.columnAccount,
            this.columnIsCredit,
            this.columnDay,
            this.columnMoney,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.columnTotal});
            this.dgvBankDetail.DataSource = this.bankBindingSource;
            this.dgvBankDetail.Location = new System.Drawing.Point(0, 30);
            this.dgvBankDetail.Name = "dgvBankDetail";
            this.dgvBankDetail.RowHeadersWidth = 25;
            this.dgvBankDetail.RowTemplate.Height = 24;
            this.dgvBankDetail.Size = new System.Drawing.Size(952, 591);
            this.dgvBankDetail.TabIndex = 1;
            this.dgvBankDetail.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.bankDetailDataGridView_CellMouseDoubleClick);
            this.dgvBankDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.bankDetailDataGridView_DataBindingComplete);
            this.dgvBankDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.bankDetailDataGridView_DataError);
            this.dgvBankDetail.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.bankDetailDataGridView_RowPrePaint);
            // 
            // columnID
            // 
            this.columnID.DataPropertyName = "ID";
            this.columnID.HeaderText = "ID";
            this.columnID.MinimumWidth = 2;
            this.columnID.Name = "columnID";
            this.columnID.ReadOnly = true;
            this.columnID.Width = 2;
            // 
            // columnAccount
            // 
            this.columnAccount.DataPropertyName = "BankID";
            this.columnAccount.DataSource = this.bankAccountBindingSource;
            this.columnAccount.DisplayMember = "ShowName";
            this.columnAccount.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.columnAccount.HeaderText = "帳戶";
            this.columnAccount.Name = "columnAccount";
            this.columnAccount.ReadOnly = true;
            this.columnAccount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnAccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnAccount.ValueMember = "ID";
            this.columnAccount.Width = 92;
            // 
            // bankAccountBindingSource
            // 
            this.bankAccountBindingSource.DataMember = "BankAccount";
            this.bankAccountBindingSource.DataSource = this.vEDataSet;
            // 
            // columnIsCredit
            // 
            this.columnIsCredit.DataPropertyName = "IsCredit";
            this.columnIsCredit.HeaderText = "付";
            this.columnIsCredit.Name = "columnIsCredit";
            this.columnIsCredit.Width = 45;
            // 
            // columnDay
            // 
            this.columnDay.DataPropertyName = "Day";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.columnDay.DefaultCellStyle = dataGridViewCellStyle1;
            this.columnDay.HeaderText = "日期";
            this.columnDay.Name = "columnDay";
            this.columnDay.ReadOnly = true;
            this.columnDay.Width = 92;
            // 
            // columnMoney
            // 
            this.columnMoney.DataPropertyName = "Money";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.columnMoney.DefaultCellStyle = dataGridViewCellStyle2;
            this.columnMoney.HeaderText = "金額";
            this.columnMoney.Name = "columnMoney";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TitleCode";
            this.dataGridViewTextBoxColumn3.DataSource = this.accountingTitleBindingSource;
            this.dataGridViewTextBoxColumn3.DisplayMember = "Name";
            this.dataGridViewTextBoxColumn3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewTextBoxColumn3.HeaderText = "科目";
            this.dataGridViewTextBoxColumn3.MaxDropDownItems = 16;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.ValueMember = "TitleCode";
            this.dataGridViewTextBoxColumn3.Width = 140;
            // 
            // accountingTitleBindingSource
            // 
            this.accountingTitleBindingSource.DataMember = "AccountingTitle";
            this.accountingTitleBindingSource.DataSource = this.vEDataSet;
            this.accountingTitleBindingSource.Filter = "";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Note";
            this.dataGridViewTextBoxColumn5.HeaderText = "Note";
            this.dataGridViewTextBoxColumn5.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 320;
            // 
            // columnTotal
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.columnTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.columnTotal.HeaderText = "餘額";
            this.columnTotal.Name = "columnTotal";
            this.columnTotal.ReadOnly = true;
            this.columnTotal.Width = 116;
            // 
            // calendar
            // 
            this.calendar.Location = new System.Drawing.Point(264, 212);
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 2;
            this.calendar.Visible = false;
            this.calendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calendar_DateSelected);
            // 
            // comboBoxMonth
            // 
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
            this.comboBoxMonth.Location = new System.Drawing.Point(446, 3);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(71, 24);
            this.comboBoxMonth.TabIndex = 54;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // cbSelectBank
            // 
            this.cbSelectBank.DataSource = this.cBankAccountForComboBoxBindingSource;
            this.cbSelectBank.DisplayMember = "Name";
            this.cbSelectBank.FormattingEnabled = true;
            this.cbSelectBank.Location = new System.Drawing.Point(337, 3);
            this.cbSelectBank.Name = "cbSelectBank";
            this.cbSelectBank.Size = new System.Drawing.Size(88, 24);
            this.cbSelectBank.TabIndex = 62;
            this.cbSelectBank.ValueMember = "ID";
            this.cbSelectBank.SelectedIndexChanged += new System.EventHandler(this.cbSelectBank_SelectedIndexChanged);
            // 
            // cBankAccountForComboBoxBindingSource
            // 
            this.cBankAccountForComboBoxBindingSource.DataSource = typeof(VoucherExpense.CBankAccountForComboBox);
            // 
            // checkBoxSort
            // 
            this.checkBoxSort.AutoSize = true;
            this.checkBoxSort.Location = new System.Drawing.Point(549, 5);
            this.checkBoxSort.Name = "checkBoxSort";
            this.checkBoxSort.Size = new System.Drawing.Size(107, 20);
            this.checkBoxSort.TabIndex = 63;
            this.checkBoxSort.Text = "按日期排序";
            this.checkBoxSort.UseVisualStyleBackColor = true;
            this.checkBoxSort.CheckedChanged += new System.EventHandler(this.checkBoxSort_CheckedChanged);
            // 
            // FormBankDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(952, 625);
            this.Controls.Add(this.checkBoxSort);
            this.Controls.Add(this.cbSelectBank);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.calendar);
            this.Controls.Add(this.dgvBankDetail);
            this.Controls.Add(this.bankDetailBindingNavigator);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormBankDetail";
            this.Text = "銀行帳戶明細";
            this.Load += new System.EventHandler(this.FormBankDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bankDetailBindingNavigator)).EndInit();
            this.bankDetailBindingNavigator.ResumeLayout(false);
            this.bankDetailBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBankDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBankAccountForComboBoxBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource bankBindingSource;
        private System.Windows.Forms.BindingNavigator bankDetailBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bankDetailBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView dgvBankDetail;
        private System.Windows.Forms.BindingSource accountingTitleBindingSource;
        private System.Windows.Forms.BindingSource bankAccountBindingSource;
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.ComboBox cbSelectBank;
        private System.Windows.Forms.CheckBox checkBoxSort;
        private System.Windows.Forms.BindingSource cBankAccountForComboBoxBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnID;
        private System.Windows.Forms.DataGridViewComboBoxColumn columnAccount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnIsCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnMoney;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTotal;
    }
}