namespace VoucherExpense
{
    partial class FormShift
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShift));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.dgvShift = new System.Windows.Forms.DataGridView();
            this.columnShiftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apartmentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.apartmentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.tableNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.operatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lastUpdatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shiftTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shiftTableTableAdapter = new VoucherExpense.VEDataSetTableAdapters.ShiftTableTableAdapter();
            this.comboBoxApartment = new System.Windows.Forms.ComboBox();
            this.cNameIDForComboBoxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.apartmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.apartmentTableAdapter = new VoucherExpense.VEDataSetTableAdapters.ApartmentTableAdapter();
            this.shiftTableBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.儲存SToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.hRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hRTableAdapter = new VoucherExpense.VEDataSetTableAdapters.HRTableAdapter();
            this.shiftDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shiftDetailTableAdapter = new VoucherExpense.VEDataSetTableAdapters.ShiftDetailTableAdapter();
            this.dgvShiftDetail = new System.Windows.Forms.DataGridView();
            this.columnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.operatorTableAdapter = new VoucherExpense.VEDataSetTableAdapters.OperatorTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNameIDForComboBoxBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftTableBindingNavigator)).BeginInit();
            this.shiftTableBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShiftDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.DropDownHeight = 216;
            this.comboBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.IntegralHeight = false;
            this.comboBoxMonth.Items.AddRange(new object[] {
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
            this.comboBoxMonth.Location = new System.Drawing.Point(258, 4);
            this.comboBoxMonth.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(74, 24);
            this.comboBoxMonth.TabIndex = 55;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // dgvShift
            // 
            this.dgvShift.AllowUserToAddRows = false;
            this.dgvShift.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dgvShift.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvShift.AutoGenerateColumns = false;
            this.dgvShift.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgvShift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShift.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnShiftID,
            this.apartmentIDDataGridViewTextBoxColumn,
            this.tableNameDataGridViewTextBoxColumn,
            this.keyIDDataGridViewTextBoxColumn,
            this.lastUpdatedDataGridViewTextBoxColumn});
            this.dgvShift.DataSource = this.shiftTableBindingSource;
            this.dgvShift.Location = new System.Drawing.Point(0, 33);
            this.dgvShift.Name = "dgvShift";
            this.dgvShift.RowHeadersVisible = false;
            this.dgvShift.RowTemplate.Height = 24;
            this.dgvShift.Size = new System.Drawing.Size(372, 642);
            this.dgvShift.TabIndex = 56;
            this.dgvShift.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvShift_DataError);
            // 
            // columnShiftID
            // 
            this.columnShiftID.DataPropertyName = "ShiftID";
            this.columnShiftID.HeaderText = "ShiftID";
            this.columnShiftID.Name = "columnShiftID";
            this.columnShiftID.Visible = false;
            // 
            // apartmentIDDataGridViewTextBoxColumn
            // 
            this.apartmentIDDataGridViewTextBoxColumn.DataPropertyName = "ApartmentID";
            this.apartmentIDDataGridViewTextBoxColumn.DataSource = this.apartmentBindingSource1;
            this.apartmentIDDataGridViewTextBoxColumn.DisplayMember = "ApartmentName";
            this.apartmentIDDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.apartmentIDDataGridViewTextBoxColumn.HeaderText = "部門";
            this.apartmentIDDataGridViewTextBoxColumn.Name = "apartmentIDDataGridViewTextBoxColumn";
            this.apartmentIDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.apartmentIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.apartmentIDDataGridViewTextBoxColumn.ValueMember = "ApartmentID";
            this.apartmentIDDataGridViewTextBoxColumn.Width = 108;
            // 
            // apartmentBindingSource1
            // 
            this.apartmentBindingSource1.DataMember = "Apartment";
            this.apartmentBindingSource1.DataSource = this.vEDataSet;
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableNameDataGridViewTextBoxColumn
            // 
            this.tableNameDataGridViewTextBoxColumn.DataPropertyName = "TableName";
            this.tableNameDataGridViewTextBoxColumn.HeaderText = "名稱";
            this.tableNameDataGridViewTextBoxColumn.Name = "tableNameDataGridViewTextBoxColumn";
            // 
            // keyIDDataGridViewTextBoxColumn
            // 
            this.keyIDDataGridViewTextBoxColumn.DataPropertyName = "KeyID";
            this.keyIDDataGridViewTextBoxColumn.DataSource = this.operatorBindingSource;
            this.keyIDDataGridViewTextBoxColumn.DisplayMember = "Name";
            this.keyIDDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.keyIDDataGridViewTextBoxColumn.HeaderText = "製表";
            this.keyIDDataGridViewTextBoxColumn.Name = "keyIDDataGridViewTextBoxColumn";
            this.keyIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.keyIDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.keyIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.keyIDDataGridViewTextBoxColumn.ValueMember = "OperatorID";
            this.keyIDDataGridViewTextBoxColumn.Width = 72;
            // 
            // operatorBindingSource
            // 
            this.operatorBindingSource.DataMember = "Operator";
            this.operatorBindingSource.DataSource = this.vEDataSet;
            // 
            // lastUpdatedDataGridViewTextBoxColumn
            // 
            this.lastUpdatedDataGridViewTextBoxColumn.DataPropertyName = "LastUpdated";
            this.lastUpdatedDataGridViewTextBoxColumn.HeaderText = "更新";
            this.lastUpdatedDataGridViewTextBoxColumn.Name = "lastUpdatedDataGridViewTextBoxColumn";
            this.lastUpdatedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // shiftTableBindingSource
            // 
            this.shiftTableBindingSource.DataMember = "ShiftTable";
            this.shiftTableBindingSource.DataSource = this.vEDataSet;
            // 
            // shiftTableTableAdapter
            // 
            this.shiftTableTableAdapter.ClearBeforeFill = true;
            // 
            // comboBoxApartment
            // 
            this.comboBoxApartment.DataSource = this.cNameIDForComboBoxBindingSource;
            this.comboBoxApartment.DisplayMember = "Name";
            this.comboBoxApartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxApartment.FormattingEnabled = true;
            this.comboBoxApartment.Location = new System.Drawing.Point(0, 4);
            this.comboBoxApartment.Name = "comboBoxApartment";
            this.comboBoxApartment.Size = new System.Drawing.Size(116, 24);
            this.comboBoxApartment.TabIndex = 57;
            this.comboBoxApartment.ValueMember = "ID";
            // 
            // cNameIDForComboBoxBindingSource
            // 
            this.cNameIDForComboBoxBindingSource.DataSource = typeof(VoucherExpense.CNameIDForComboBox);
            // 
            // apartmentBindingSource
            // 
            this.apartmentBindingSource.DataMember = "Apartment";
            this.apartmentBindingSource.DataSource = this.vEDataSet;
            // 
            // apartmentTableAdapter
            // 
            this.apartmentTableAdapter.ClearBeforeFill = true;
            // 
            // shiftTableBindingNavigator
            // 
            this.shiftTableBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.shiftTableBindingNavigator.BindingSource = this.shiftTableBindingSource;
            this.shiftTableBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.shiftTableBindingNavigator.CountItemFormat = "{0}";
            this.shiftTableBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.shiftTableBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.shiftTableBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.儲存SToolStripButton,
            this.toolStripSeparator1,
            this.bindingNavigatorCountItem});
            this.shiftTableBindingNavigator.Location = new System.Drawing.Point(128, 4);
            this.shiftTableBindingNavigator.MoveFirstItem = null;
            this.shiftTableBindingNavigator.MoveLastItem = null;
            this.shiftTableBindingNavigator.MoveNextItem = null;
            this.shiftTableBindingNavigator.MovePreviousItem = null;
            this.shiftTableBindingNavigator.Name = "shiftTableBindingNavigator";
            this.shiftTableBindingNavigator.PositionItem = null;
            this.shiftTableBindingNavigator.Size = new System.Drawing.Size(111, 25);
            this.shiftTableBindingNavigator.TabIndex = 58;
            this.shiftTableBindingNavigator.Text = "bindingNavigator1";
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
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(24, 22);
            this.bindingNavigatorCountItem.Text = "{0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目總數";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "刪除";
            // 
            // 儲存SToolStripButton
            // 
            this.儲存SToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.儲存SToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("儲存SToolStripButton.Image")));
            this.儲存SToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.儲存SToolStripButton.Name = "儲存SToolStripButton";
            this.儲存SToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.儲存SToolStripButton.Text = "儲存(&S)";
            this.儲存SToolStripButton.Click += new System.EventHandler(this.儲存SToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // hRBindingSource
            // 
            this.hRBindingSource.DataMember = "HR";
            this.hRBindingSource.DataSource = this.vEDataSet;
            // 
            // hRTableAdapter
            // 
            this.hRTableAdapter.ClearBeforeFill = true;
            // 
            // shiftDetailBindingSource
            // 
            this.shiftDetailBindingSource.DataMember = "ShiftTableShiftDetail";
            this.shiftDetailBindingSource.DataSource = this.shiftTableBindingSource;
            // 
            // shiftDetailTableAdapter
            // 
            this.shiftDetailTableAdapter.ClearBeforeFill = true;
            // 
            // dgvShiftDetail
            // 
            this.dgvShiftDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.dgvShiftDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvShiftDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShiftDetail.AutoGenerateColumns = false;
            this.dgvShiftDetail.BackgroundColor = System.Drawing.Color.Azure;
            this.dgvShiftDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShiftDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnID,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewCheckBoxColumn1});
            this.dgvShiftDetail.DataSource = this.shiftDetailBindingSource;
            this.dgvShiftDetail.Location = new System.Drawing.Point(378, 33);
            this.dgvShiftDetail.Name = "dgvShiftDetail";
            this.dgvShiftDetail.RowHeadersWidth = 25;
            this.dgvShiftDetail.RowTemplate.Height = 24;
            this.dgvShiftDetail.Size = new System.Drawing.Size(519, 642);
            this.dgvShiftDetail.TabIndex = 58;
            this.dgvShiftDetail.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvShiftDetail_DefaultValuesNeeded);
            // 
            // columnID
            // 
            this.columnID.DataPropertyName = "ID";
            this.columnID.HeaderText = "ID";
            this.columnID.Name = "columnID";
            this.columnID.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ShiftID";
            this.dataGridViewTextBoxColumn2.HeaderText = "ShiftID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "EmpolyeeID";
            this.dataGridViewTextBoxColumn3.DataSource = this.hRBindingSource;
            this.dataGridViewTextBoxColumn3.DisplayMember = "EmployeeName";
            this.dataGridViewTextBoxColumn3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewTextBoxColumn3.HeaderText = "姓名";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.ValueMember = "EmployeeID";
            this.dataGridViewTextBoxColumn3.Width = 72;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ShiftData";
            this.dataGridViewTextBoxColumn4.HeaderText = "ShiftData";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 250;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Wage";
            this.dataGridViewTextBoxColumn5.HeaderText = "Wage";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 64;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "IsHourlyWage";
            this.dataGridViewCheckBoxColumn1.HeaderText = "時薪";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 48;
            // 
            // operatorTableAdapter
            // 
            this.operatorTableAdapter.ClearBeforeFill = true;
            // 
            // FormShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(896, 675);
            this.Controls.Add(this.dgvShiftDetail);
            this.Controls.Add(this.shiftTableBindingNavigator);
            this.Controls.Add(this.comboBoxApartment);
            this.Controls.Add(this.dgvShift);
            this.Controls.Add(this.comboBoxMonth);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormShift";
            this.Text = "輪班表";
            this.Load += new System.EventHandler(this.FormShift_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNameIDForComboBoxBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftTableBindingNavigator)).EndInit();
            this.shiftTableBindingNavigator.ResumeLayout(false);
            this.shiftTableBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShiftDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.DataGridView dgvShift;
        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource shiftTableBindingSource;
        private VEDataSetTableAdapters.ShiftTableTableAdapter shiftTableTableAdapter;
        private System.Windows.Forms.ComboBox comboBoxApartment;
        private System.Windows.Forms.BindingSource apartmentBindingSource;
        private VEDataSetTableAdapters.ApartmentTableAdapter apartmentTableAdapter;
        private System.Windows.Forms.BindingSource cNameIDForComboBoxBindingSource;
        private System.Windows.Forms.BindingNavigator shiftTableBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.BindingSource apartmentBindingSource1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton 儲存SToolStripButton;
        private System.Windows.Forms.BindingSource hRBindingSource;
        private VEDataSetTableAdapters.HRTableAdapter hRTableAdapter;
        private System.Windows.Forms.BindingSource shiftDetailBindingSource;
        private VEDataSetTableAdapters.ShiftDetailTableAdapter shiftDetailTableAdapter;
        private System.Windows.Forms.DataGridView dgvShiftDetail;
        private System.Windows.Forms.BindingSource operatorBindingSource;
        private VEDataSetTableAdapters.OperatorTableAdapter operatorTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnShiftID;
        private System.Windows.Forms.DataGridViewComboBoxColumn apartmentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn keyIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
    }
}