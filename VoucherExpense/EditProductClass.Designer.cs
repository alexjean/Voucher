﻿namespace VoucherExpense
{
    partial class EditProductClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditProductClass));
            this.productClassDataGridView = new System.Windows.Forms.DataGridView();
            this.dgvColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.damaiDataSet = new VoucherExpense.DamaiDataSet();
            this.productClassTableAdapter = new VoucherExpense.DamaiDataSetTableAdapters.ProductClassTableAdapter();
            this.tableAdapterManager = new VoucherExpense.DamaiDataSetTableAdapters.TableAdapterManager();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.productClassBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.productClassBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.productClassDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productClassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productClassBindingNavigator)).BeginInit();
            this.productClassBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // productClassDataGridView
            // 
            this.productClassDataGridView.AllowUserToAddRows = false;
            this.productClassDataGridView.AllowUserToDeleteRows = false;
            this.productClassDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.productClassDataGridView.AutoGenerateColumns = false;
            this.productClassDataGridView.BackgroundColor = System.Drawing.Color.SeaShell;
            this.productClassDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productClassDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColumnID,
            this.ColumnClassName});
            this.productClassDataGridView.DataSource = this.productClassBindingSource;
            this.productClassDataGridView.Location = new System.Drawing.Point(0, 29);
            this.productClassDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.productClassDataGridView.Name = "productClassDataGridView";
            this.productClassDataGridView.RowTemplate.Height = 23;
            this.productClassDataGridView.Size = new System.Drawing.Size(462, 647);
            this.productClassDataGridView.TabIndex = 1;
            this.productClassDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.productClassDataGridView_CellBeginEdit);
            // 
            // dgvColumnID
            // 
            this.dgvColumnID.DataPropertyName = "ID";
            this.dgvColumnID.HeaderText = "编号";
            this.dgvColumnID.MaxInputLength = 50;
            this.dgvColumnID.Name = "dgvColumnID";
            this.dgvColumnID.ReadOnly = true;
            // 
            // ColumnClassName
            // 
            this.ColumnClassName.DataPropertyName = "ProductClass";
            this.ColumnClassName.HeaderText = "产品类别";
            this.ColumnClassName.MaxInputLength = 20;
            this.ColumnClassName.Name = "ColumnClassName";
            this.ColumnClassName.Width = 300;
            // 
            // productClassBindingSource
            // 
            this.productClassBindingSource.DataMember = "ProductClass";
            this.productClassBindingSource.DataSource = this.damaiDataSet;
            this.productClassBindingSource.Filter = "ID>0";
            // 
            // damaiDataSet
            // 
            this.damaiDataSet.DataSetName = "DamaiDataSet";
            this.damaiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productClassTableAdapter
            // 
            this.productClassTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AccountingTitleTableAdapter = null;
            this.tableAdapterManager.AccVoucherTableAdapter = null;
            this.tableAdapterManager.ApartmentTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BakeryConfigTableAdapter = null;
            this.tableAdapterManager.BankAccountTableAdapter = null;
            this.tableAdapterManager.BankDetailTableAdapter = null;
            this.tableAdapterManager.CashierTableAdapter = null;
            this.tableAdapterManager.ConfigTableAdapter = null;
            this.tableAdapterManager.CustomerTableAdapter = null;
            this.tableAdapterManager.DrawerRecordTableAdapter = null;
            this.tableAdapterManager.ExpenseTableAdapter = null;
            this.tableAdapterManager.HeaderTableAdapter = null;
            this.tableAdapterManager.HRDetailTableAdapter = null;
            this.tableAdapterManager.HRTableAdapter = null;
            this.tableAdapterManager.IngredientTableAdapter = null;
            this.tableAdapterManager.InventoryDetailTableAdapter = null;
            this.tableAdapterManager.InventoryProductsTableAdapter = null;
            this.tableAdapterManager.InventoryTableAdapter = null;
            this.tableAdapterManager.OnDutyDataTableAdapter = null;
            this.tableAdapterManager.OperatorTableAdapter = null;
            this.tableAdapterManager.OrderItemTableAdapter = null;
            this.tableAdapterManager.OrderTableAdapter = null;
            this.tableAdapterManager.PhotosTableAdapter = null;
            this.tableAdapterManager.ProductClassTableAdapter = this.productClassTableAdapter;
            this.tableAdapterManager.ProductScrappedDetailTableAdapter = null;
            this.tableAdapterManager.ProductScrappedTableAdapter = null;
            this.tableAdapterManager.ProductTableAdapter = null;
            this.tableAdapterManager.ProgramTableAdapter = null;
            this.tableAdapterManager.RecipeDetailTableAdapter = null;
            this.tableAdapterManager.RecipeTableAdapter = null;
            this.tableAdapterManager.RequestsTableAdapter = null;
            this.tableAdapterManager.ShiftDetailTableAdapter = null;
            this.tableAdapterManager.ShiftTableTableAdapter = null;
            this.tableAdapterManager.ShipmentDetailTableAdapter = null;
            this.tableAdapterManager.ShipmentTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = VoucherExpense.DamaiDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VEHeaderTableAdapter = null;
            this.tableAdapterManager.VendorTableAdapter = null;
            this.tableAdapterManager.VoucherDetailTableAdapter = null;
            this.tableAdapterManager.VoucherTableAdapter = null;
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "移到第一条记录";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一条记录";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "当前位置";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(32, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "总项数";
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
            this.bindingNavigatorMoveNextItem.Text = "移到下一条记录";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "移到最后一条记录";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "新添";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.AddNewItem_Click);
            // 
            // productClassBindingNavigatorSaveItem
            // 
            this.productClassBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.productClassBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("productClassBindingNavigatorSaveItem.Image")));
            this.productClassBindingNavigatorSaveItem.Name = "productClassBindingNavigatorSaveItem";
            this.productClassBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.productClassBindingNavigatorSaveItem.Text = "保存数据";
            this.productClassBindingNavigatorSaveItem.Click += new System.EventHandler(this.productClassBindingNavigatorSaveItem_Click);
            // 
            // productClassBindingNavigator
            // 
            this.productClassBindingNavigator.AddNewItem = null;
            this.productClassBindingNavigator.BindingSource = this.productClassBindingSource;
            this.productClassBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.productClassBindingNavigator.DeleteItem = null;
            this.productClassBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.productClassBindingNavigatorSaveItem});
            this.productClassBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.productClassBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.productClassBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.productClassBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.productClassBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.productClassBindingNavigator.Name = "productClassBindingNavigator";
            this.productClassBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.productClassBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.productClassBindingNavigator.Size = new System.Drawing.Size(1017, 25);
            this.productClassBindingNavigator.TabIndex = 0;
            this.productClassBindingNavigator.Text = "bindingNavigator1";
            // 
            // EditProductClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1017, 676);
            this.Controls.Add(this.productClassDataGridView);
            this.Controls.Add(this.productClassBindingNavigator);
            this.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EditProductClass";
            this.Text = "产品类别";
            this.Load += new System.EventHandler(this.EditProductClass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productClassDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productClassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productClassBindingNavigator)).EndInit();
            this.productClassBindingNavigator.ResumeLayout(false);
            this.productClassBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DamaiDataSet damaiDataSet;
        private System.Windows.Forms.BindingSource productClassBindingSource;
        private DamaiDataSetTableAdapters.ProductClassTableAdapter productClassTableAdapter;
        private DamaiDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView productClassDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnClassName;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton productClassBindingNavigatorSaveItem;
        private System.Windows.Forms.BindingNavigator productClassBindingNavigator;
    }
}