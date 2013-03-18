namespace VoucherExpense
{
    partial class FormOperator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOperator));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.operatorBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.operatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.operatorBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.operatorDataGridView = new System.Windows.Forms.DataGridView();
            this.operatorTableAdapter = new VoucherExpense.VEDataSetTableAdapters.OperatorTableAdapter();
            this.OperatorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StopAccount = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LoginName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EditRecipe = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EditProduct = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn8 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EditInventory = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RevenueOperate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LockVoucher = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LockExpense = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LockAccVoucher = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EditOnDuty = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EditSalary = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LockHR = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EditBank = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn9 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsSuper = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingNavigator)).BeginInit();
            this.operatorBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // operatorBindingNavigator
            // 
            this.operatorBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.operatorBindingNavigator.BackgroundImage = global::VoucherExpense.Properties.Resources.NavBar_Back;
            this.operatorBindingNavigator.BindingSource = this.operatorBindingSource;
            this.operatorBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.operatorBindingNavigator.DeleteItem = null;
            this.operatorBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.operatorBindingNavigatorSaveItem});
            this.operatorBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.operatorBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.operatorBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.operatorBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.operatorBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.operatorBindingNavigator.Name = "operatorBindingNavigator";
            this.operatorBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.operatorBindingNavigator.Size = new System.Drawing.Size(951, 27);
            this.operatorBindingNavigator.TabIndex = 0;
            this.operatorBindingNavigator.Text = "bindingNavigator1";
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
            // operatorBindingNavigatorSaveItem
            // 
            this.operatorBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.operatorBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("operatorBindingNavigatorSaveItem.Image")));
            this.operatorBindingNavigatorSaveItem.Name = "operatorBindingNavigatorSaveItem";
            this.operatorBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 24);
            this.operatorBindingNavigatorSaveItem.Text = "儲存資料";
            this.operatorBindingNavigatorSaveItem.Click += new System.EventHandler(this.operatorBindingNavigatorSaveItem_Click);
            // 
            // operatorDataGridView
            // 
            this.operatorDataGridView.AllowUserToAddRows = false;
            this.operatorDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.operatorDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.operatorDataGridView.AutoGenerateColumns = false;
            this.operatorDataGridView.BackgroundColor = System.Drawing.Color.SeaShell;
            this.operatorDataGridView.ColumnHeadersHeight = 69;
            this.operatorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OperatorID,
            this.StopAccount,
            this.LoginName,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewCheckBoxColumn3,
            this.EditRecipe,
            this.EditProduct,
            this.dataGridViewCheckBoxColumn5,
            this.dataGridViewCheckBoxColumn6,
            this.dataGridViewCheckBoxColumn8,
            this.EditInventory,
            this.RevenueOperate,
            this.LockVoucher,
            this.LockExpense,
            this.LockAccVoucher,
            this.dataGridViewCheckBoxColumn4,
            this.EditOnDuty,
            this.EditSalary,
            this.LockHR,
            this.EditBank,
            this.dataGridViewCheckBoxColumn9,
            this.IsSuper,
            this.dataGridViewTextBoxColumn6});
            this.operatorDataGridView.DataSource = this.operatorBindingSource;
            this.operatorDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operatorDataGridView.Location = new System.Drawing.Point(0, 27);
            this.operatorDataGridView.Name = "operatorDataGridView";
            this.operatorDataGridView.RowHeadersWidth = 20;
            this.operatorDataGridView.RowTemplate.Height = 24;
            this.operatorDataGridView.Size = new System.Drawing.Size(951, 483);
            this.operatorDataGridView.TabIndex = 1;
            this.operatorDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.operatorDataGridView_CellValidating);
            this.operatorDataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.operatorDataGridView_RowValidating);
            // 
            // operatorTableAdapter
            // 
            this.operatorTableAdapter.ClearBeforeFill = true;
            // 
            // OperatorID
            // 
            this.OperatorID.DataPropertyName = "OperatorID";
            this.OperatorID.HeaderText = "內碼";
            this.OperatorID.MinimumWidth = 2;
            this.OperatorID.Name = "OperatorID";
            this.OperatorID.ReadOnly = true;
            this.OperatorID.Width = 2;
            // 
            // StopAccount
            // 
            this.StopAccount.DataPropertyName = "StopAccount";
            this.StopAccount.HeaderText = "停用";
            this.StopAccount.Name = "StopAccount";
            this.StopAccount.Width = 32;
            // 
            // LoginName
            // 
            this.LoginName.DataPropertyName = "LoginName";
            this.LoginName.HeaderText = "登入名";
            this.LoginName.Name = "LoginName";
            this.LoginName.Width = 84;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn5.HeaderText = "名稱";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "EditOperator";
            this.dataGridViewCheckBoxColumn1.HeaderText = "帳號";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 32;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "EditVendor";
            this.dataGridViewCheckBoxColumn2.HeaderText = "供應商";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Width = 32;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.DataPropertyName = "EditIngredient";
            this.dataGridViewCheckBoxColumn3.HeaderText = "食材表";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.Width = 32;
            // 
            // EditRecipe
            // 
            this.EditRecipe.DataPropertyName = "EditRecipe";
            this.EditRecipe.HeaderText = "配方表";
            this.EditRecipe.Name = "EditRecipe";
            this.EditRecipe.Width = 32;
            // 
            // EditProduct
            // 
            this.EditProduct.DataPropertyName = "EditProduct";
            this.EditProduct.HeaderText = "產品表";
            this.EditProduct.Name = "EditProduct";
            this.EditProduct.Width = 32;
            // 
            // dataGridViewCheckBoxColumn5
            // 
            this.dataGridViewCheckBoxColumn5.DataPropertyName = "EditAccountingTitle";
            this.dataGridViewCheckBoxColumn5.HeaderText = "會計科目";
            this.dataGridViewCheckBoxColumn5.Name = "dataGridViewCheckBoxColumn5";
            this.dataGridViewCheckBoxColumn5.Width = 32;
            // 
            // dataGridViewCheckBoxColumn6
            // 
            this.dataGridViewCheckBoxColumn6.DataPropertyName = "EditVoucher";
            this.dataGridViewCheckBoxColumn6.HeaderText = "進貨";
            this.dataGridViewCheckBoxColumn6.Name = "dataGridViewCheckBoxColumn6";
            this.dataGridViewCheckBoxColumn6.Width = 32;
            // 
            // dataGridViewCheckBoxColumn8
            // 
            this.dataGridViewCheckBoxColumn8.DataPropertyName = "EditExpense";
            this.dataGridViewCheckBoxColumn8.HeaderText = "費用";
            this.dataGridViewCheckBoxColumn8.Name = "dataGridViewCheckBoxColumn8";
            this.dataGridViewCheckBoxColumn8.Width = 32;
            // 
            // EditInventory
            // 
            this.EditInventory.DataPropertyName = "EditInventory";
            this.EditInventory.HeaderText = "庫存";
            this.EditInventory.Name = "EditInventory";
            this.EditInventory.Width = 32;
            // 
            // RevenueOperate
            // 
            this.RevenueOperate.DataPropertyName = "RevenueOperate";
            this.RevenueOperate.HeaderText = "營收";
            this.RevenueOperate.Name = "RevenueOperate";
            this.RevenueOperate.Width = 32;
            // 
            // LockVoucher
            // 
            this.LockVoucher.DataPropertyName = "LockVoucher";
            this.LockVoucher.HeaderText = "核進貨";
            this.LockVoucher.Name = "LockVoucher";
            this.LockVoucher.Width = 32;
            // 
            // LockExpense
            // 
            this.LockExpense.DataPropertyName = "LockExpense";
            this.LockExpense.HeaderText = "核費用";
            this.LockExpense.Name = "LockExpense";
            this.LockExpense.Width = 32;
            // 
            // LockAccVoucher
            // 
            this.LockAccVoucher.DataPropertyName = "LockAccVoucher";
            this.LockAccVoucher.HeaderText = "核傳票";
            this.LockAccVoucher.Name = "LockAccVoucher";
            this.LockAccVoucher.Width = 32;
            // 
            // dataGridViewCheckBoxColumn4
            // 
            this.dataGridViewCheckBoxColumn4.DataPropertyName = "EditEmployee";
            this.dataGridViewCheckBoxColumn4.HeaderText = "員工";
            this.dataGridViewCheckBoxColumn4.Name = "dataGridViewCheckBoxColumn4";
            this.dataGridViewCheckBoxColumn4.Width = 32;
            // 
            // EditOnDuty
            // 
            this.EditOnDuty.DataPropertyName = "EditOnDuty";
            this.EditOnDuty.HeaderText = "出勤";
            this.EditOnDuty.Name = "EditOnDuty";
            this.EditOnDuty.Width = 32;
            // 
            // EditSalary
            // 
            this.EditSalary.DataPropertyName = "EditSalary";
            this.EditSalary.HeaderText = "薪資";
            this.EditSalary.Name = "EditSalary";
            this.EditSalary.Width = 32;
            // 
            // LockHR
            // 
            this.LockHR.DataPropertyName = "LockHR";
            this.LockHR.HeaderText = "核人事";
            this.LockHR.Name = "LockHR";
            this.LockHR.Width = 32;
            // 
            // EditBank
            // 
            this.EditBank.DataPropertyName = "EditBank";
            this.EditBank.HeaderText = "銀行";
            this.EditBank.Name = "EditBank";
            this.EditBank.Width = 32;
            // 
            // dataGridViewCheckBoxColumn9
            // 
            this.dataGridViewCheckBoxColumn9.DataPropertyName = "IsManager";
            this.dataGridViewCheckBoxColumn9.HeaderText = "報表";
            this.dataGridViewCheckBoxColumn9.Name = "dataGridViewCheckBoxColumn9";
            this.dataGridViewCheckBoxColumn9.Width = 32;
            // 
            // IsSuper
            // 
            this.IsSuper.DataPropertyName = "IsSuper";
            this.IsSuper.HeaderText = "超級";
            this.IsSuper.Name = "IsSuper";
            this.IsSuper.ReadOnly = true;
            this.IsSuper.Width = 32;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "LastUpdated";
            dataGridViewCellStyle2.Format = "yy-MM-dd";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn6.HeaderText = "更新";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 76;
            // 
            // FormOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 510);
            this.Controls.Add(this.operatorDataGridView);
            this.Controls.Add(this.operatorBindingNavigator);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormOperator";
            this.Text = "帳號權限";
            this.Load += new System.EventHandler(this.FormOperator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingNavigator)).EndInit();
            this.operatorBindingNavigator.ResumeLayout(false);
            this.operatorBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource operatorBindingSource;
        private VoucherExpense.VEDataSetTableAdapters.OperatorTableAdapter operatorTableAdapter;
        private System.Windows.Forms.BindingNavigator operatorBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton operatorBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView operatorDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperatorID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn StopAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EditRecipe;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EditProduct;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EditInventory;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RevenueOperate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn LockVoucher;
        private System.Windows.Forms.DataGridViewCheckBoxColumn LockExpense;
        private System.Windows.Forms.DataGridViewCheckBoxColumn LockAccVoucher;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EditOnDuty;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EditSalary;
        private System.Windows.Forms.DataGridViewCheckBoxColumn LockHR;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EditBank;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSuper;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}