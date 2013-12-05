namespace VoucherExpense
{
    partial class FormShipment
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
            System.Windows.Forms.Label shipTimeLabel;
            System.Windows.Forms.Label shipCodeLabel;
            System.Windows.Forms.Label costLabel;
            System.Windows.Forms.Label removedLabel;
            System.Windows.Forms.Label checkedLabel;
            System.Windows.Forms.Label lastUpdatedLabel;
            System.Windows.Forms.Label supplierLabel;
            System.Windows.Forms.Label iDLabel;
            System.Windows.Forms.Label checkedIDLabel;
            System.Windows.Forms.Label keyinIDLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShipment));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.shipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sQLVEDataSet = new VoucherExpense.SQLVEDataSet();
            this.shipmentTableAdapter = new VoucherExpense.SQLVEDataSetTableAdapters.ShipmentTableAdapter();
            this.tableAdapterManager = new VoucherExpense.SQLVEDataSetTableAdapters.TableAdapterManager();
            this.shipmentDetailTableAdapter = new VoucherExpense.SQLVEDataSetTableAdapters.ShipmentDetailTableAdapter();
            this.shipmentBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.shipmentBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtAllPrint = new System.Windows.Forms.ToolStripButton();
            this.shipmentDataGridView = new System.Windows.Forms.DataGridView();
            this.supplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.supplierComboBox = new System.Windows.Forms.ComboBox();
            this.shipTimeTextBox = new System.Windows.Forms.TextBox();
            this.shipCodeTextBox = new System.Windows.Forms.TextBox();
            this.costTextBox = new System.Windows.Forms.TextBox();
            this.shipmentDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bakeryOrderSet = new VoucherExpense.BakeryOrderSet();
            this.removedCheckBox = new System.Windows.Forms.CheckBox();
            this.checkedCheckBox = new System.Windows.Forms.CheckBox();
            this.lastUpdatedLabel1 = new System.Windows.Forms.Label();
            this.iDLabel1 = new System.Windows.Forms.Label();
            this.productTableAdapter = new VoucherExpense.BakeryOrderSetTableAdapters.ProductTableAdapter();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.supplierTableAdapter = new VoucherExpense.SQLVEDataSetTableAdapters.SupplierTableAdapter();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.shipmentDetailDataGridView = new System.Windows.Forms.DataGridView();
            this.accountingTitleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.operatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.operatorTableAdapter = new VoucherExpense.VEDataSetTableAdapters.OperatorTableAdapter();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.pD = new System.Drawing.Printing.PrintDocument();
            this.accountingTitleTableAdapter = new VoucherExpense.VEDataSetTableAdapters.AccountingTitleTableAdapter();
            this.detailColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnProductID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvColumnVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvCostColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnTitleCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Removed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            shipTimeLabel = new System.Windows.Forms.Label();
            shipCodeLabel = new System.Windows.Forms.Label();
            costLabel = new System.Windows.Forms.Label();
            removedLabel = new System.Windows.Forms.Label();
            checkedLabel = new System.Windows.Forms.Label();
            lastUpdatedLabel = new System.Windows.Forms.Label();
            supplierLabel = new System.Windows.Forms.Label();
            iDLabel = new System.Windows.Forms.Label();
            checkedIDLabel = new System.Windows.Forms.Label();
            keyinIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLVEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentBindingNavigator)).BeginInit();
            this.shipmentBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDetailDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // shipTimeLabel
            // 
            shipTimeLabel.AutoSize = true;
            shipTimeLabel.Location = new System.Drawing.Point(476, 87);
            shipTimeLabel.Name = "shipTimeLabel";
            shipTimeLabel.Size = new System.Drawing.Size(76, 16);
            shipTimeLabel.TabIndex = 6;
            shipTimeLabel.Text = "出货时间:";
            // 
            // shipCodeLabel
            // 
            shipCodeLabel.AutoSize = true;
            shipCodeLabel.Location = new System.Drawing.Point(719, 87);
            shipCodeLabel.Name = "shipCodeLabel";
            shipCodeLabel.Size = new System.Drawing.Size(60, 16);
            shipCodeLabel.TabIndex = 8;
            shipCodeLabel.Text = "凭证号:";
            // 
            // costLabel
            // 
            costLabel.AutoSize = true;
            costLabel.Location = new System.Drawing.Point(476, 118);
            costLabel.Name = "costLabel";
            costLabel.Size = new System.Drawing.Size(60, 16);
            costLabel.TabIndex = 10;
            costLabel.Text = "总金额:";
            // 
            // removedLabel
            // 
            removedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            removedLabel.AutoSize = true;
            removedLabel.Location = new System.Drawing.Point(476, 602);
            removedLabel.Name = "removedLabel";
            removedLabel.Size = new System.Drawing.Size(44, 16);
            removedLabel.TabIndex = 13;
            removedLabel.Text = "废除:";
            // 
            // checkedLabel
            // 
            checkedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            checkedLabel.AutoSize = true;
            checkedLabel.Location = new System.Drawing.Point(719, 602);
            checkedLabel.Name = "checkedLabel";
            checkedLabel.Size = new System.Drawing.Size(28, 16);
            checkedLabel.TabIndex = 15;
            checkedLabel.Text = "核:";
            // 
            // lastUpdatedLabel
            // 
            lastUpdatedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            lastUpdatedLabel.AutoSize = true;
            lastUpdatedLabel.Location = new System.Drawing.Point(476, 664);
            lastUpdatedLabel.Name = "lastUpdatedLabel";
            lastUpdatedLabel.Size = new System.Drawing.Size(44, 16);
            lastUpdatedLabel.TabIndex = 29;
            lastUpdatedLabel.Text = "更新:";
            // 
            // supplierLabel
            // 
            supplierLabel.AutoSize = true;
            supplierLabel.Location = new System.Drawing.Point(476, 59);
            supplierLabel.Name = "supplierLabel";
            supplierLabel.Size = new System.Drawing.Size(44, 16);
            supplierLabel.TabIndex = 2;
            supplierLabel.Text = "客户:";
            // 
            // iDLabel
            // 
            iDLabel.AutoSize = true;
            iDLabel.Location = new System.Drawing.Point(718, 59);
            iDLabel.Name = "iDLabel";
            iDLabel.Size = new System.Drawing.Size(44, 16);
            iDLabel.TabIndex = 30;
            iDLabel.Text = "顺序:";
            // 
            // checkedIDLabel
            // 
            checkedIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            checkedIDLabel.AutoSize = true;
            checkedIDLabel.Location = new System.Drawing.Point(719, 631);
            checkedIDLabel.Name = "checkedIDLabel";
            checkedIDLabel.Size = new System.Drawing.Size(60, 16);
            checkedIDLabel.TabIndex = 50;
            checkedIDLabel.Text = "复核人:";
            // 
            // keyinIDLabel
            // 
            keyinIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            keyinIDLabel.AutoSize = true;
            keyinIDLabel.Location = new System.Drawing.Point(476, 631);
            keyinIDLabel.Name = "keyinIDLabel";
            keyinIDLabel.Size = new System.Drawing.Size(44, 16);
            keyinIDLabel.TabIndex = 51;
            keyinIDLabel.Text = "输入:";
            // 
            // shipmentBindingSource
            // 
            this.shipmentBindingSource.DataMember = "Shipment";
            this.shipmentBindingSource.DataSource = this.sQLVEDataSet;
            // 
            // sQLVEDataSet
            // 
            this.sQLVEDataSet.DataSetName = "SQLVEDataSet";
            this.sQLVEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // shipmentTableAdapter
            // 
            this.shipmentTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.InventoryDetailTableAdapter = null;
            this.tableAdapterManager.InventoryProductsTableAdapter = null;
            this.tableAdapterManager.InventoryTableAdapter = null;
            this.tableAdapterManager.ProductScrappedDetailTableAdapter = null;
            this.tableAdapterManager.ProductScrappedTableAdapter = null;
            this.tableAdapterManager.ShipmentDetailTableAdapter = this.shipmentDetailTableAdapter;
            this.tableAdapterManager.ShipmentTableAdapter = this.shipmentTableAdapter;
            this.tableAdapterManager.SupplierTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = VoucherExpense.SQLVEDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // shipmentDetailTableAdapter
            // 
            this.shipmentDetailTableAdapter.ClearBeforeFill = true;
            // 
            // shipmentBindingNavigator
            // 
            this.shipmentBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.shipmentBindingNavigator.BackgroundImage = global::VoucherExpense.Properties.Resources.NavBar_Back;
            this.shipmentBindingNavigator.BindingSource = this.shipmentBindingSource;
            this.shipmentBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.shipmentBindingNavigator.DeleteItem = null;
            this.shipmentBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.shipmentBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.shipmentBindingNavigatorSaveItem,
            this.toolStripSeparator1,
            this.tsbtPrint,
            this.toolStripSeparator2,
            this.tsbtAllPrint});
            this.shipmentBindingNavigator.Location = new System.Drawing.Point(539, 4);
            this.shipmentBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.shipmentBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.shipmentBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.shipmentBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.shipmentBindingNavigator.Name = "shipmentBindingNavigator";
            this.shipmentBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.shipmentBindingNavigator.Size = new System.Drawing.Size(396, 25);
            this.shipmentBindingNavigator.TabIndex = 0;
            this.shipmentBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "新添";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(32, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "总项数";
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
            // shipmentBindingNavigatorSaveItem
            // 
            this.shipmentBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.shipmentBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("shipmentBindingNavigatorSaveItem.Image")));
            this.shipmentBindingNavigatorSaveItem.Name = "shipmentBindingNavigatorSaveItem";
            this.shipmentBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.shipmentBindingNavigatorSaveItem.Text = "保存数据";
            this.shipmentBindingNavigatorSaveItem.Click += new System.EventHandler(this.shipmentBindingNavigatorSaveItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtPrint
            // 
            this.tsbtPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbtPrint.Image")));
            this.tsbtPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtPrint.Name = "tsbtPrint";
            this.tsbtPrint.Size = new System.Drawing.Size(72, 22);
            this.tsbtPrint.Text = "出货单打印";
            this.tsbtPrint.Click += new System.EventHandler(this.tsbtPrint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtAllPrint
            // 
            this.tsbtAllPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtAllPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbtAllPrint.Image")));
            this.tsbtAllPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtAllPrint.Name = "tsbtAllPrint";
            this.tsbtAllPrint.Size = new System.Drawing.Size(60, 22);
            this.tsbtAllPrint.Text = "统计打印";
            // 
            // shipmentDataGridView
            // 
            this.shipmentDataGridView.AllowUserToAddRows = false;
            this.shipmentDataGridView.AllowUserToDeleteRows = false;
            this.shipmentDataGridView.AllowUserToOrderColumns = true;
            this.shipmentDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.shipmentDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.shipmentDataGridView.AutoGenerateColumns = false;
            this.shipmentDataGridView.BackgroundColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("PMingLiU", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.shipmentDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.shipmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.shipmentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ShipCode,
            this.ShipTime,
            this.Supplier,
            this.Cost,
            this.Checked,
            this.Removed});
            this.shipmentDataGridView.DataSource = this.shipmentBindingSource;
            this.shipmentDataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.shipmentDataGridView.EnableHeadersVisualStyles = false;
            this.shipmentDataGridView.Location = new System.Drawing.Point(0, 0);
            this.shipmentDataGridView.Name = "shipmentDataGridView";
            this.shipmentDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.shipmentDataGridView.RowHeadersVisible = false;
            this.shipmentDataGridView.RowHeadersWidth = 25;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.shipmentDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.shipmentDataGridView.RowTemplate.Height = 23;
            this.shipmentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.shipmentDataGridView.Size = new System.Drawing.Size(444, 694);
            this.shipmentDataGridView.TabIndex = 1;
            this.shipmentDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.shipmentDataGridView_DataError);
            this.shipmentDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.shipmentDataGridView_RowEnter);
            this.shipmentDataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.shipmentDataGridView_RowPrePaint);
            // 
            // supplierBindingSource
            // 
            this.supplierBindingSource.DataMember = "Supplier";
            this.supplierBindingSource.DataSource = this.sQLVEDataSet;
            // 
            // supplierComboBox
            // 
            this.supplierComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.shipmentBindingSource, "Supplier", true));
            this.supplierComboBox.DataSource = this.supplierBindingSource;
            this.supplierComboBox.DisplayMember = "Name";
            this.supplierComboBox.FormattingEnabled = true;
            this.supplierComboBox.Location = new System.Drawing.Point(557, 53);
            this.supplierComboBox.Name = "supplierComboBox";
            this.supplierComboBox.Size = new System.Drawing.Size(124, 24);
            this.supplierComboBox.TabIndex = 3;
            this.supplierComboBox.ValueMember = "SupplierID";
            // 
            // shipTimeTextBox
            // 
            this.shipTimeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shipmentBindingSource, "ShipTime", true));
            this.shipTimeTextBox.Location = new System.Drawing.Point(558, 82);
            this.shipTimeTextBox.Name = "shipTimeTextBox";
            this.shipTimeTextBox.Size = new System.Drawing.Size(110, 27);
            this.shipTimeTextBox.TabIndex = 7;
            // 
            // shipCodeTextBox
            // 
            this.shipCodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shipmentBindingSource, "ShipCode", true));
            this.shipCodeTextBox.Location = new System.Drawing.Point(785, 82);
            this.shipCodeTextBox.Name = "shipCodeTextBox";
            this.shipCodeTextBox.Size = new System.Drawing.Size(111, 27);
            this.shipCodeTextBox.TabIndex = 9;
            // 
            // costTextBox
            // 
            this.costTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shipmentBindingSource, "Cost", true));
            this.costTextBox.Location = new System.Drawing.Point(558, 114);
            this.costTextBox.Name = "costTextBox";
            this.costTextBox.Size = new System.Drawing.Size(123, 27);
            this.costTextBox.TabIndex = 11;
            this.costTextBox.TextChanged += new System.EventHandler(this.costTextBox_TextChanged);
            this.costTextBox.Validated += new System.EventHandler(this.costTextBox_Validated);
            // 
            // shipmentDetailBindingSource
            // 
            this.shipmentDetailBindingSource.DataMember = "FK_ShipmentDetail_Shipment";
            this.shipmentDetailBindingSource.DataSource = this.shipmentBindingSource;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.bakeryOrderSet;
            this.productBindingSource.Filter = "Code>0";
            // 
            // bakeryOrderSet
            // 
            this.bakeryOrderSet.DataSetName = "BakeryOrderSet";
            this.bakeryOrderSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // removedCheckBox
            // 
            this.removedCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.shipmentBindingSource, "Removed", true));
            this.removedCheckBox.Location = new System.Drawing.Point(558, 596);
            this.removedCheckBox.Name = "removedCheckBox";
            this.removedCheckBox.Size = new System.Drawing.Size(16, 24);
            this.removedCheckBox.TabIndex = 14;
            this.removedCheckBox.UseVisualStyleBackColor = true;
            this.removedCheckBox.CheckedChanged += new System.EventHandler(this.removedCheckBox_CheckedChanged);
            // 
            // checkedCheckBox
            // 
            this.checkedCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.shipmentBindingSource, "Checked", true));
            this.checkedCheckBox.Enabled = false;
            this.checkedCheckBox.Location = new System.Drawing.Point(785, 596);
            this.checkedCheckBox.Name = "checkedCheckBox";
            this.checkedCheckBox.Size = new System.Drawing.Size(20, 24);
            this.checkedCheckBox.TabIndex = 16;
            this.checkedCheckBox.UseVisualStyleBackColor = true;
            this.checkedCheckBox.CheckedChanged += new System.EventHandler(this.checkedCheckBox_CheckedChanged);
            // 
            // lastUpdatedLabel1
            // 
            this.lastUpdatedLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lastUpdatedLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shipmentBindingSource, "LastUpdated", true));
            this.lastUpdatedLabel1.Location = new System.Drawing.Point(523, 664);
            this.lastUpdatedLabel1.Name = "lastUpdatedLabel1";
            this.lastUpdatedLabel1.Size = new System.Drawing.Size(137, 23);
            this.lastUpdatedLabel1.TabIndex = 30;
            // 
            // iDLabel1
            // 
            this.iDLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shipmentBindingSource, "ID", true));
            this.iDLabel1.Location = new System.Drawing.Point(782, 56);
            this.iDLabel1.Name = "iDLabel1";
            this.iDLabel1.Size = new System.Drawing.Size(103, 23);
            this.iDLabel1.TabIndex = 31;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.DropDownHeight = 216;
            this.comboBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.IntegralHeight = false;
            this.comboBoxMonth.Items.AddRange(new object[] {
            "",
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
            this.comboBoxMonth.Location = new System.Drawing.Point(450, 4);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(86, 24);
            this.comboBoxMonth.TabIndex = 53;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // supplierTableAdapter
            // 
            this.supplierTableAdapter.ClearBeforeFill = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(665, 82);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(17, 27);
            this.dateTimePicker1.TabIndex = 54;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // shipmentDetailDataGridView
            // 
            this.shipmentDetailDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Azure;
            this.shipmentDetailDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.shipmentDetailDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shipmentDetailDataGridView.AutoGenerateColumns = false;
            this.shipmentDetailDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.shipmentDetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.shipmentDetailDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.detailColumnID,
            this.dataGridViewTextBoxColumn7,
            this.dgvColumnProductID,
            this.dgvColumnVolume,
            this.ProductID,
            this.dgvCostColumn,
            this.dgvColumnTitleCode});
            this.shipmentDetailDataGridView.DataSource = this.shipmentDetailBindingSource;
            this.shipmentDetailDataGridView.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.shipmentDetailDataGridView.Location = new System.Drawing.Point(445, 147);
            this.shipmentDetailDataGridView.Name = "shipmentDetailDataGridView";
            this.shipmentDetailDataGridView.RowHeadersWidth = 25;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.shipmentDetailDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.shipmentDetailDataGridView.RowTemplate.Height = 23;
            this.shipmentDetailDataGridView.Size = new System.Drawing.Size(490, 432);
            this.shipmentDetailDataGridView.TabIndex = 50;
            this.shipmentDetailDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.shipmentDetailDataGridView_CellValueChanged);
            this.shipmentDetailDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.shipmentDetailDataGridView_DataError);
            this.shipmentDetailDataGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.shipmentDetailDataGridView_DefaultValuesNeeded);
            // 
            // accountingTitleBindingSource
            // 
            this.accountingTitleBindingSource.DataMember = "AccountingTitle";
            this.accountingTitleBindingSource.DataSource = this.vEDataSet;
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // operatorBindingSource
            // 
            this.operatorBindingSource.DataMember = "Operator";
            this.operatorBindingSource.DataSource = this.vEDataSet;
            // 
            // operatorTableAdapter
            // 
            this.operatorTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.shipmentBindingSource, "KeyinID", true));
            this.comboBox1.DataSource = this.operatorBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.DropDownHeight = 1;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Location = new System.Drawing.Point(526, 628);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(106, 24);
            this.comboBox1.TabIndex = 56;
            this.comboBox1.ValueMember = "OperatorID";
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.shipmentBindingSource, "CheckedID", true));
            this.comboBox2.DataSource = this.operatorBindingSource;
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.DropDownHeight = 1;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.IntegralHeight = false;
            this.comboBox2.Location = new System.Drawing.Point(785, 628);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(106, 24);
            this.comboBox2.TabIndex = 57;
            this.comboBox2.ValueMember = "OperatorID";
            // 
            // pD
            // 
            this.pD.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pD_PrintPage);
            // 
            // accountingTitleTableAdapter
            // 
            this.accountingTitleTableAdapter.ClearBeforeFill = true;
            // 
            // detailColumnID
            // 
            this.detailColumnID.DataPropertyName = "ID";
            this.detailColumnID.HeaderText = "ID";
            this.detailColumnID.Name = "detailColumnID";
            this.detailColumnID.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ShipmentID";
            this.dataGridViewTextBoxColumn7.HeaderText = "ShipmentID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dgvColumnProductID
            // 
            this.dgvColumnProductID.DataPropertyName = "ProductID";
            this.dgvColumnProductID.DataSource = this.productBindingSource;
            this.dgvColumnProductID.DisplayMember = "Name";
            this.dgvColumnProductID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dgvColumnProductID.HeaderText = "产品";
            this.dgvColumnProductID.Name = "dgvColumnProductID";
            this.dgvColumnProductID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColumnProductID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvColumnProductID.ValueMember = "ProductID";
            this.dgvColumnProductID.Width = 140;
            // 
            // dgvColumnVolume
            // 
            this.dgvColumnVolume.DataPropertyName = "Volume";
            this.dgvColumnVolume.HeaderText = "数量";
            this.dgvColumnVolume.Name = "dgvColumnVolume";
            this.dgvColumnVolume.Width = 80;
            // 
            // ProductID
            // 
            this.ProductID.DataPropertyName = "ProductID";
            this.ProductID.DataSource = this.productBindingSource;
            this.ProductID.DisplayMember = "Unit";
            this.ProductID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ProductID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProductID.HeaderText = "";
            this.ProductID.Name = "ProductID";
            this.ProductID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ProductID.ValueMember = "ProductID";
            this.ProductID.Width = 40;
            // 
            // dgvCostColumn
            // 
            this.dgvCostColumn.DataPropertyName = "Cost";
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.dgvCostColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCostColumn.HeaderText = "金额";
            this.dgvCostColumn.Name = "dgvCostColumn";
            // 
            // dgvColumnTitleCode
            // 
            this.dgvColumnTitleCode.DataPropertyName = "TitleCode";
            this.dgvColumnTitleCode.DataSource = this.accountingTitleBindingSource;
            this.dgvColumnTitleCode.DisplayMember = "Name";
            this.dgvColumnTitleCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dgvColumnTitleCode.HeaderText = "会计科目";
            this.dgvColumnTitleCode.Name = "dgvColumnTitleCode";
            this.dgvColumnTitleCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColumnTitleCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvColumnTitleCode.ValueMember = "TitleCode";
            // 
            // ColumnID
            // 
            this.ColumnID.DataPropertyName = "ID";
            this.ColumnID.HeaderText = "顺序";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Width = 50;
            // 
            // ShipCode
            // 
            this.ShipCode.DataPropertyName = "ShipCode";
            this.ShipCode.HeaderText = "凭证号";
            this.ShipCode.Name = "ShipCode";
            this.ShipCode.ReadOnly = true;
            this.ShipCode.Width = 70;
            // 
            // ShipTime
            // 
            this.ShipTime.DataPropertyName = "ShipTime";
            this.ShipTime.HeaderText = "出货时间";
            this.ShipTime.Name = "ShipTime";
            this.ShipTime.ReadOnly = true;
            this.ShipTime.Width = 90;
            // 
            // Supplier
            // 
            this.Supplier.DataPropertyName = "Supplier";
            this.Supplier.DataSource = this.supplierBindingSource;
            this.Supplier.DisplayMember = "Name";
            this.Supplier.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Supplier.HeaderText = "客户";
            this.Supplier.Name = "Supplier";
            this.Supplier.ReadOnly = true;
            this.Supplier.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Supplier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Supplier.ValueMember = "SupplierID";
            // 
            // Cost
            // 
            this.Cost.DataPropertyName = "Cost";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Cost.DefaultCellStyle = dataGridViewCellStyle3;
            this.Cost.HeaderText = "总计";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            // 
            // Checked
            // 
            this.Checked.DataPropertyName = "Checked";
            this.Checked.HeaderText = "核";
            this.Checked.Name = "Checked";
            this.Checked.ReadOnly = true;
            this.Checked.Width = 30;
            // 
            // Removed
            // 
            this.Removed.DataPropertyName = "Removed";
            this.Removed.HeaderText = "Removed";
            this.Removed.Name = "Removed";
            this.Removed.Visible = false;
            // 
            // FormShipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(936, 694);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(keyinIDLabel);
            this.Controls.Add(checkedIDLabel);
            this.Controls.Add(iDLabel);
            this.Controls.Add(this.iDLabel1);
            this.Controls.Add(lastUpdatedLabel);
            this.Controls.Add(this.lastUpdatedLabel1);
            this.Controls.Add(checkedLabel);
            this.Controls.Add(this.checkedCheckBox);
            this.Controls.Add(removedLabel);
            this.Controls.Add(this.removedCheckBox);
            this.Controls.Add(this.shipmentDetailDataGridView);
            this.Controls.Add(costLabel);
            this.Controls.Add(this.costTextBox);
            this.Controls.Add(shipCodeLabel);
            this.Controls.Add(this.shipCodeTextBox);
            this.Controls.Add(shipTimeLabel);
            this.Controls.Add(this.shipTimeTextBox);
            this.Controls.Add(supplierLabel);
            this.Controls.Add(this.supplierComboBox);
            this.Controls.Add(this.shipmentDataGridView);
            this.Controls.Add(this.shipmentBindingNavigator);
            this.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormShipment";
            this.Text = "出货";
            this.Load += new System.EventHandler(this.FormShipment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.shipmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLVEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentBindingNavigator)).EndInit();
            this.shipmentBindingNavigator.ResumeLayout(false);
            this.shipmentBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDetailDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SQLVEDataSet sQLVEDataSet;
        private System.Windows.Forms.BindingSource shipmentBindingSource;
        private SQLVEDataSetTableAdapters.ShipmentTableAdapter shipmentTableAdapter;
        private SQLVEDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator shipmentBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton shipmentBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView shipmentDataGridView;
        private System.Windows.Forms.ComboBox supplierComboBox;
        private System.Windows.Forms.TextBox shipTimeTextBox;
        private System.Windows.Forms.TextBox shipCodeTextBox;
        private System.Windows.Forms.TextBox costTextBox;
        private SQLVEDataSetTableAdapters.ShipmentDetailTableAdapter shipmentDetailTableAdapter;
        private System.Windows.Forms.BindingSource shipmentDetailBindingSource;
        private System.Windows.Forms.CheckBox removedCheckBox;
        private System.Windows.Forms.CheckBox checkedCheckBox;
        private System.Windows.Forms.Label lastUpdatedLabel1;
        private System.Windows.Forms.Label iDLabel1;
        private BakeryOrderSet bakeryOrderSet;
        private System.Windows.Forms.BindingSource productBindingSource;
        private BakeryOrderSetTableAdapters.ProductTableAdapter productTableAdapter;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.BindingSource supplierBindingSource;
        private SQLVEDataSetTableAdapters.SupplierTableAdapter supplierTableAdapter;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView shipmentDetailDataGridView;
        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource operatorBindingSource;
        private VEDataSetTableAdapters.OperatorTableAdapter operatorTableAdapter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Drawing.Printing.PrintDocument pD;
        private System.Windows.Forms.BindingSource accountingTitleBindingSource;
        private VEDataSetTableAdapters.AccountingTitleTableAdapter accountingTitleTableAdapter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtAllPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn detailColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColumnProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnVolume;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCostColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColumnTitleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipTime;
        private System.Windows.Forms.DataGridViewComboBoxColumn Supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Checked;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Removed;
    }
}