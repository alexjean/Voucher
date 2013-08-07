namespace VoucherExpense
{
    partial class FormBank
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBank));
            this.bankAccountBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bankAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.bankAccountBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.dgvBankAccount = new System.Windows.Forms.DataGridView();
            this.columnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountTitleCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.accountingTitleBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.DefaultTitleCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.accountingTitleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.bankAccountTableAdapter = new VoucherExpense.VEDataSetTableAdapters.BankAccountTableAdapter();
            this.accountingTitleTableAdapter = new VoucherExpense.VEDataSetTableAdapters.AccountingTitleTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingNavigator)).BeginInit();
            this.bankAccountBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBankAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bankAccountBindingNavigator
            // 
            this.bankAccountBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bankAccountBindingNavigator.BindingSource = this.bankAccountBindingSource;
            this.bankAccountBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.bankAccountBindingNavigator.DeleteItem = null;
            this.bankAccountBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bankAccountBindingNavigatorSaveItem});
            this.bankAccountBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.bankAccountBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bankAccountBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bankAccountBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bankAccountBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bankAccountBindingNavigator.Name = "bankAccountBindingNavigator";
            this.bankAccountBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.bankAccountBindingNavigator.Size = new System.Drawing.Size(1012, 25);
            this.bankAccountBindingNavigator.TabIndex = 0;
            this.bankAccountBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "加入新的";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bankAccountBindingSource
            // 
            this.bankAccountBindingSource.DataMember = "BankAccount";
            this.bankAccountBindingSource.DataSource = this.vEDataSet;
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
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
            // bankAccountBindingNavigatorSaveItem
            // 
            this.bankAccountBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bankAccountBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("bankAccountBindingNavigatorSaveItem.Image")));
            this.bankAccountBindingNavigatorSaveItem.Name = "bankAccountBindingNavigatorSaveItem";
            this.bankAccountBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.bankAccountBindingNavigatorSaveItem.Text = "儲存資料";
            this.bankAccountBindingNavigatorSaveItem.Click += new System.EventHandler(this.bankAccountBindingNavigatorSaveItem_Click);
            // 
            // dgvBankAccount
            // 
            this.dgvBankAccount.AllowUserToAddRows = false;
            this.dgvBankAccount.AutoGenerateColumns = false;
            this.dgvBankAccount.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgvBankAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBankAccount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnID,
            this.dataGridViewTextBoxColumn2,
            this.AccountTitleCode,
            this.DefaultTitleCode,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn4});
            this.dgvBankAccount.DataSource = this.bankAccountBindingSource;
            this.dgvBankAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBankAccount.Location = new System.Drawing.Point(0, 25);
            this.dgvBankAccount.Name = "dgvBankAccount";
            this.dgvBankAccount.RowHeadersWidth = 25;
            this.dgvBankAccount.RowTemplate.Height = 23;
            this.dgvBankAccount.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBankAccount.Size = new System.Drawing.Size(1012, 400);
            this.dgvBankAccount.TabIndex = 1;
            this.dgvBankAccount.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.bankAccountDataGridView_DataError);
            // 
            // columnID
            // 
            this.columnID.DataPropertyName = "ID";
            this.columnID.HeaderText = "編號";
            this.columnID.Name = "columnID";
            this.columnID.ReadOnly = true;
            this.columnID.Width = 64;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ShowName";
            this.dataGridViewTextBoxColumn2.HeaderText = "簡稱";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // AccountTitleCode
            // 
            this.AccountTitleCode.DataPropertyName = "AccountTitleCode";
            this.AccountTitleCode.DataSource = this.accountingTitleBindingSource1;
            this.AccountTitleCode.DisplayMember = "Name";
            this.AccountTitleCode.HeaderText = "帳號科目";
            this.AccountTitleCode.Name = "AccountTitleCode";
            this.AccountTitleCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AccountTitleCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AccountTitleCode.ValueMember = "TitleCode";
            // 
            // accountingTitleBindingSource1
            // 
            this.accountingTitleBindingSource1.DataMember = "AccountingTitle";
            this.accountingTitleBindingSource1.DataSource = this.vEDataSet;
            this.accountingTitleBindingSource1.Filter = "TitleCode like \'1*\'";
            // 
            // DefaultTitleCode
            // 
            this.DefaultTitleCode.DataPropertyName = "DefaultTitleCode";
            this.DefaultTitleCode.DataSource = this.accountingTitleBindingSource;
            this.DefaultTitleCode.DisplayMember = "Name";
            this.DefaultTitleCode.HeaderText = "預設科目";
            this.DefaultTitleCode.Name = "DefaultTitleCode";
            this.DefaultTitleCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DefaultTitleCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DefaultTitleCode.ValueMember = "TitleCode";
            this.DefaultTitleCode.Width = 116;
            // 
            // accountingTitleBindingSource
            // 
            this.accountingTitleBindingSource.DataMember = "AccountingTitle";
            this.accountingTitleBindingSource.DataSource = this.vEDataSet;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "BankName";
            this.dataGridViewTextBoxColumn3.HeaderText = "銀行";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 144;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "AccountName";
            this.dataGridViewTextBoxColumn5.HeaderText = "帳戶名稱";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 160;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "AccountNo";
            this.dataGridViewTextBoxColumn4.HeaderText = "帳號";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 168;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SeaShell;
            this.label1.Location = new System.Drawing.Point(315, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "未指定銀行帳號的費用, 一律歸入零用金";
            // 
            // bankAccountTableAdapter
            // 
            this.bankAccountTableAdapter.ClearBeforeFill = true;
            // 
            // accountingTitleTableAdapter
            // 
            this.accountingTitleTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SeaShell;
            this.label2.Location = new System.Drawing.Point(315, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "帳號1是給零用金的特殊帳戶";
            // 
            // FormBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1012, 425);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvBankAccount);
            this.Controls.Add(this.bankAccountBindingNavigator);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormBank";
            this.Text = "銀行帳號";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBank_FormClosing);
            this.Load += new System.EventHandler(this.FormBank_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingNavigator)).EndInit();
            this.bankAccountBindingNavigator.ResumeLayout(false);
            this.bankAccountBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBankAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource bankAccountBindingSource;
        private VoucherExpense.VEDataSetTableAdapters.BankAccountTableAdapter bankAccountTableAdapter;
        private System.Windows.Forms.BindingNavigator bankAccountBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton bankAccountBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView dgvBankAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource accountingTitleBindingSource;
        private VoucherExpense.VEDataSetTableAdapters.AccountingTitleTableAdapter accountingTitleTableAdapter;
        private System.Windows.Forms.BindingSource accountingTitleBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn AccountTitleCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn DefaultTitleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label2;
    }
}