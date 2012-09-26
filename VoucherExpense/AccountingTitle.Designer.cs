namespace VoucherExpense
{
    partial class AccountingTitle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountingTitle));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.accountingTitleBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.accountingTitleBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.accountingTitleBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.accountingTitleDataGridView = new System.Windows.Forms.DataGridView();
            this.TitleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTitleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitialValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.accountingTitleTableAdapter = new VoucherExpense.VEDataSetTableAdapters.AccountingTitleTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingNavigator)).BeginInit();
            this.accountingTitleBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // accountingTitleBindingNavigator
            // 
            this.accountingTitleBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.accountingTitleBindingNavigator.BackgroundImage = global::VoucherExpense.Properties.Resources.NavBar_Back;
            this.accountingTitleBindingNavigator.BindingSource = this.accountingTitleBindingSource;
            this.accountingTitleBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.accountingTitleBindingNavigator.DeleteItem = null;
            this.accountingTitleBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.accountingTitleBindingNavigatorSaveItem});
            this.accountingTitleBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.accountingTitleBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.accountingTitleBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.accountingTitleBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.accountingTitleBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.accountingTitleBindingNavigator.Name = "accountingTitleBindingNavigator";
            this.accountingTitleBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.accountingTitleBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.accountingTitleBindingNavigator.Size = new System.Drawing.Size(437, 27);
            this.accountingTitleBindingNavigator.TabIndex = 0;
            this.accountingTitleBindingNavigator.Text = "bindingNavigator1";
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
            // accountingTitleBindingSource
            // 
            this.accountingTitleBindingSource.DataMember = "AccountingTitle";
            this.accountingTitleBindingSource.DataSource = this.vEDataSet;
            this.accountingTitleBindingSource.Sort = "TitleCode";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(73, 27);
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
            // accountingTitleBindingNavigatorSaveItem
            // 
            this.accountingTitleBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.accountingTitleBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("accountingTitleBindingNavigatorSaveItem.Image")));
            this.accountingTitleBindingNavigatorSaveItem.Name = "accountingTitleBindingNavigatorSaveItem";
            this.accountingTitleBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 24);
            this.accountingTitleBindingNavigatorSaveItem.Text = "儲存資料";
            this.accountingTitleBindingNavigatorSaveItem.Click += new System.EventHandler(this.accountingTitleBindingNavigatorSaveItem_Click);
            // 
            // accountingTitleDataGridView
            // 
            this.accountingTitleDataGridView.AllowUserToAddRows = false;
            this.accountingTitleDataGridView.AllowUserToDeleteRows = false;
            this.accountingTitleDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.Azure;
            this.accountingTitleDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle26;
            this.accountingTitleDataGridView.AutoGenerateColumns = false;
            this.accountingTitleDataGridView.BackgroundColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle27.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.accountingTitleDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.accountingTitleDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TitleCode,
            this.columnTitleName,
            this.InitialValue,
            this.dataGridViewTextBoxColumn4});
            this.accountingTitleDataGridView.DataSource = this.accountingTitleBindingSource;
            this.accountingTitleDataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.accountingTitleDataGridView.EnableHeadersVisualStyles = false;
            this.accountingTitleDataGridView.Location = new System.Drawing.Point(0, 0);
            this.accountingTitleDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.accountingTitleDataGridView.Name = "accountingTitleDataGridView";
            this.accountingTitleDataGridView.RowHeadersWidth = 25;
            this.accountingTitleDataGridView.RowTemplate.Height = 24;
            this.accountingTitleDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.accountingTitleDataGridView.Size = new System.Drawing.Size(448, 514);
            this.accountingTitleDataGridView.TabIndex = 1;
            this.accountingTitleDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.accountingTitleDataGridView_CellValidating);
            this.accountingTitleDataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.accountingTitleDataGridView_RowValidating);
            // 
            // TitleCode
            // 
            this.TitleCode.DataPropertyName = "TitleCode";
            dataGridViewCellStyle28.NullValue = null;
            this.TitleCode.DefaultCellStyle = dataGridViewCellStyle28;
            this.TitleCode.HeaderText = "科目編號";
            this.TitleCode.Name = "TitleCode";
            this.TitleCode.Width = 80;
            // 
            // columnTitleName
            // 
            this.columnTitleName.DataPropertyName = "Name";
            this.columnTitleName.HeaderText = "科目名稱";
            this.columnTitleName.Name = "columnTitleName";
            this.columnTitleName.Width = 120;
            // 
            // InitialValue
            // 
            this.InitialValue.DataPropertyName = "InitialValue";
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle29.Format = "N2";
            dataGridViewCellStyle29.NullValue = null;
            this.InitialValue.DefaultCellStyle = dataGridViewCellStyle29;
            this.InitialValue.HeaderText = "期初值";
            this.InitialValue.Name = "InitialValue";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "LastUpdated";
            dataGridViewCellStyle30.Format = "d";
            dataGridViewCellStyle30.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle30;
            this.dataGridViewTextBoxColumn4.HeaderText = "更新日";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "會計科目類別說明";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.accountingTitleBindingNavigator);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(448, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(437, 514);
            this.panel1.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "科目編號的第一碼代表大類",
            "第二三碼為小類",
            "",
            "",
            "1  資產",
            "2  負債",
            "3  業主權益",
            "4  營業收入",
            "5  營業成本",
            "6  營業費用",
            "",
            "以下對應之科目請至",
            "功能<傳票設定> 去設置",
            "---------------------------------",
            "不明的資產,不明的負債",
            "未標的成本,未標的費用",
            "所有進貨的貸方  ",
            "現金收入 刷卡收入",
            "---------------------------------"});
            this.listBox1.Location = new System.Drawing.Point(34, 142);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(379, 324);
            this.listBox1.TabIndex = 3;
            // 
            // accountingTitleTableAdapter
            // 
            this.accountingTitleTableAdapter.ClearBeforeFill = true;
            // 
            // AccountingTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 514);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.accountingTitleDataGridView);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AccountingTitle";
            this.Text = "會計科目";
            this.Load += new System.EventHandler(this.FormAccountingTitle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingNavigator)).EndInit();
            this.accountingTitleBindingNavigator.ResumeLayout(false);
            this.accountingTitleBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource accountingTitleBindingSource;
        private VoucherExpense.VEDataSetTableAdapters.AccountingTitleTableAdapter accountingTitleTableAdapter;
        private System.Windows.Forms.BindingNavigator accountingTitleBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton accountingTitleBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView accountingTitleDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTitleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitialValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

    }
}