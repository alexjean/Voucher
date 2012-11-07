namespace VoucherExpense
{
    partial class FormCashierAuthen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCashierAuthen));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bakeryOrderSet = new VoucherExpense.BakeryOrderSet();
            this.cashierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cashierTableAdapter = new VoucherExpense.BakeryOrderSetTableAdapters.CashierTableAdapter();
            this.cashierBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cashierBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.cashierDataGridView = new System.Windows.Forms.DataGridView();
            this.operatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.operatorTableAdapter = new VoucherExpense.VEDataSetTableAdapters.OperatorTableAdapter();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CashierIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PasswordColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chBoxOnlyInPosition = new System.Windows.Forms.CheckBox();
            this.listBoxReadme = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashierBindingNavigator)).BeginInit();
            this.cashierBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cashierDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // bakeryOrderSet
            // 
            this.bakeryOrderSet.DataSetName = "BakeryOrderSet";
            this.bakeryOrderSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cashierBindingSource
            // 
            this.cashierBindingSource.DataMember = "Cashier";
            this.cashierBindingSource.DataSource = this.bakeryOrderSet;
            // 
            // cashierTableAdapter
            // 
            this.cashierTableAdapter.ClearBeforeFill = true;
            // 
            // cashierBindingNavigator
            // 
            this.cashierBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.cashierBindingNavigator.BackgroundImage = global::VoucherExpense.Properties.Resources.NavBar_Back;
            this.cashierBindingNavigator.BindingSource = this.cashierBindingSource;
            this.cashierBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.cashierBindingNavigator.DeleteItem = null;
            this.cashierBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.cashierBindingNavigatorSaveItem});
            this.cashierBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.cashierBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.cashierBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.cashierBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.cashierBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.cashierBindingNavigator.Name = "cashierBindingNavigator";
            this.cashierBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.cashierBindingNavigator.Size = new System.Drawing.Size(910, 25);
            this.cashierBindingNavigator.TabIndex = 0;
            this.cashierBindingNavigator.Text = "bindingNavigator1";
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
            // cashierBindingNavigatorSaveItem
            // 
            this.cashierBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cashierBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("cashierBindingNavigatorSaveItem.Image")));
            this.cashierBindingNavigatorSaveItem.Name = "cashierBindingNavigatorSaveItem";
            this.cashierBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.cashierBindingNavigatorSaveItem.Text = "儲存資料";
            this.cashierBindingNavigatorSaveItem.Click += new System.EventHandler(this.cashierBindingNavigatorSaveItem_Click);
            // 
            // cashierDataGridView
            // 
            this.cashierDataGridView.AllowUserToAddRows = false;
            this.cashierDataGridView.AllowUserToDeleteRows = false;
            this.cashierDataGridView.AutoGenerateColumns = false;
            this.cashierDataGridView.BackgroundColor = System.Drawing.Color.SeaShell;
            this.cashierDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cashierDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.CashierIDColumn,
            this.dataGridViewTextBoxColumn2,
            this.PasswordColumn,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.cashierDataGridView.DataSource = this.cashierBindingSource;
            this.cashierDataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.cashierDataGridView.Location = new System.Drawing.Point(0, 25);
            this.cashierDataGridView.Name = "cashierDataGridView";
            this.cashierDataGridView.RowTemplate.Height = 24;
            this.cashierDataGridView.Size = new System.Drawing.Size(607, 628);
            this.cashierDataGridView.TabIndex = 1;
            this.cashierDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.cashierDataGridView_CellFormatting);
            // 
            // operatorBindingSource
            // 
            this.operatorBindingSource.DataMember = "Operator";
            this.operatorBindingSource.DataSource = this.vEDataSet;
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // operatorTableAdapter
            // 
            this.operatorTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "InPosition";
            this.dataGridViewCheckBoxColumn1.HeaderText = "在職";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 48;
            // 
            // CashierIDColumn
            // 
            this.CashierIDColumn.DataPropertyName = "CashierID";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CashierIDColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.CashierIDColumn.HeaderText = "內部編号";
            this.CashierIDColumn.Name = "CashierIDColumn";
            this.CashierIDColumn.ReadOnly = true;
            this.CashierIDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CashierIDColumn.Width = 96;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CashierName";
            this.dataGridViewTextBoxColumn2.HeaderText = "姓名";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 10;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // PasswordColumn
            // 
            this.PasswordColumn.DataPropertyName = "CashierPassword";
            this.PasswordColumn.HeaderText = "密碼";
            this.PasswordColumn.MaxInputLength = 6;
            this.PasswordColumn.Name = "PasswordColumn";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "AuthenID";
            this.dataGridViewTextBoxColumn4.DataSource = this.operatorBindingSource;
            this.dataGridViewTextBoxColumn4.DisplayMember = "Name";
            this.dataGridViewTextBoxColumn4.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewTextBoxColumn4.HeaderText = "授權者";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn4.ValueMember = "OperatorID";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "LastUpdated";
            dataGridViewCellStyle8.Format = "MM-dd hh:mm";
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn5.HeaderText = "更新時間";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // chBoxOnlyInPosition
            // 
            this.chBoxOnlyInPosition.AutoSize = true;
            this.chBoxOnlyInPosition.Checked = true;
            this.chBoxOnlyInPosition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBoxOnlyInPosition.Location = new System.Drawing.Point(655, 67);
            this.chBoxOnlyInPosition.Name = "chBoxOnlyInPosition";
            this.chBoxOnlyInPosition.Size = new System.Drawing.Size(123, 20);
            this.chBoxOnlyInPosition.TabIndex = 2;
            this.chBoxOnlyInPosition.Text = "只顯示在職者";
            this.chBoxOnlyInPosition.UseVisualStyleBackColor = true;
            this.chBoxOnlyInPosition.CheckedChanged += new System.EventHandler(this.chBoxOnlyInPosition_CheckedChanged);
            // 
            // listBoxReadme
            // 
            this.listBoxReadme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.listBoxReadme.FormattingEnabled = true;
            this.listBoxReadme.ItemHeight = 16;
            this.listBoxReadme.Items.AddRange(new object[] {
            "",
            " 為保持資料一致性,故不提供刪除",
            "",
            " 收銀員離職後",
            "",
            " 應將離職者的在職勾選取消",
            "",
            " 新收銀員應使用新編號",
            "",
            " 不可重複使用同一編号",
            "",
            " 收銀台密碼只能輸入數字"});
            this.listBoxReadme.Location = new System.Drawing.Point(626, 112);
            this.listBoxReadme.Name = "listBoxReadme";
            this.listBoxReadme.Size = new System.Drawing.Size(271, 260);
            this.listBoxReadme.TabIndex = 3;
            // 
            // FormCashierAuthen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(910, 653);
            this.Controls.Add(this.listBoxReadme);
            this.Controls.Add(this.chBoxOnlyInPosition);
            this.Controls.Add(this.cashierDataGridView);
            this.Controls.Add(this.cashierBindingNavigator);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormCashierAuthen";
            this.Text = "收銀授權";
            this.Load += new System.EventHandler(this.FormCashierAuthen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashierBindingNavigator)).EndInit();
            this.cashierBindingNavigator.ResumeLayout(false);
            this.cashierBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cashierDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BakeryOrderSet bakeryOrderSet;
        private System.Windows.Forms.BindingSource cashierBindingSource;
        private BakeryOrderSetTableAdapters.CashierTableAdapter cashierTableAdapter;
        private System.Windows.Forms.BindingNavigator cashierBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton cashierBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView cashierDataGridView;
        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource operatorBindingSource;
        private VEDataSetTableAdapters.OperatorTableAdapter operatorTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashierIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PasswordColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.CheckBox chBoxOnlyInPosition;
        private System.Windows.Forms.ListBox listBoxReadme;
    }
}