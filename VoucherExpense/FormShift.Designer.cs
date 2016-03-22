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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShift));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cMonthForComboBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.operatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.shiftTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shiftTableBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.儲存SToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnModify = new System.Windows.Forms.Button();
            this.hRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSaveCodeConfig = new System.Windows.Forms.Button();
            this.dgvConfigShiftCode = new System.Windows.Forms.DataGridView();
            this.columnCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cCodeForComboBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.columnNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnHour = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cHourForComboBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cShiftCodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvShift = new System.Windows.Forms.DataGridView();
            this.columnShiftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTableMonth = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.columnLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.KeyinID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lastUpdatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.damaiDataSet = new VoucherExpense.DamaiDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.cMonthForComboBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftTableBindingNavigator)).BeginInit();
            this.shiftTableBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigShiftCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cCodeForComboBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cHourForComboBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cShiftCodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // cMonthForComboBindingSource
            // 
            this.cMonthForComboBindingSource.DataSource = typeof(VoucherExpense.FormShift.CMonthForCombo);
            // 
            // operatorBindingSource
            // 
            this.operatorBindingSource.DataMember = "Operator";
            this.operatorBindingSource.DataSource = this.damaiDataSet;
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // shiftTableBindingSource
            // 
            this.shiftTableBindingSource.DataMember = "ShiftTable";
            this.shiftTableBindingSource.DataSource = this.damaiDataSet;
            // 
            // shiftTableBindingNavigator
            // 
            this.shiftTableBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.shiftTableBindingNavigator.BindingSource = this.shiftTableBindingSource;
            this.shiftTableBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.shiftTableBindingNavigator.CountItemFormat = "{0}";
            this.shiftTableBindingNavigator.DeleteItem = null;
            this.shiftTableBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.shiftTableBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.儲存SToolStripButton,
            this.toolStripSeparator1,
            this.bindingNavigatorCountItem});
            this.shiftTableBindingNavigator.Location = new System.Drawing.Point(0, 4);
            this.shiftTableBindingNavigator.MoveFirstItem = null;
            this.shiftTableBindingNavigator.MoveLastItem = null;
            this.shiftTableBindingNavigator.MoveNextItem = null;
            this.shiftTableBindingNavigator.MovePreviousItem = null;
            this.shiftTableBindingNavigator.Name = "shiftTableBindingNavigator";
            this.shiftTableBindingNavigator.PositionItem = null;
            this.shiftTableBindingNavigator.Size = new System.Drawing.Size(109, 25);
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
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(22, 22);
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
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
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
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(225, 1);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(83, 31);
            this.btnModify.TabIndex = 60;
            this.btnModify.Text = "編排班表";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // hRBindingSource
            // 
            this.hRBindingSource.DataMember = "HR";
            this.hRBindingSource.DataSource = this.damaiDataSet;
            // 
            // btnSaveCodeConfig
            // 
            this.btnSaveCodeConfig.Location = new System.Drawing.Point(639, 1);
            this.btnSaveCodeConfig.Name = "btnSaveCodeConfig";
            this.btnSaveCodeConfig.Size = new System.Drawing.Size(83, 31);
            this.btnSaveCodeConfig.TabIndex = 64;
            this.btnSaveCodeConfig.Text = "代号存檔";
            this.btnSaveCodeConfig.UseVisualStyleBackColor = true;
            this.btnSaveCodeConfig.Click += new System.EventHandler(this.btnSaveCodeConfig_Click);
            // 
            // dgvConfigShiftCode
            // 
            this.dgvConfigShiftCode.AutoGenerateColumns = false;
            this.dgvConfigShiftCode.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.dgvConfigShiftCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConfigShiftCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnCode,
            this.columnNote,
            this.columnHour});
            this.dgvConfigShiftCode.DataSource = this.cShiftCodeBindingSource;
            this.dgvConfigShiftCode.Location = new System.Drawing.Point(464, 32);
            this.dgvConfigShiftCode.Name = "dgvConfigShiftCode";
            this.dgvConfigShiftCode.RowHeadersWidth = 25;
            this.dgvConfigShiftCode.RowTemplate.Height = 24;
            this.dgvConfigShiftCode.Size = new System.Drawing.Size(431, 642);
            this.dgvConfigShiftCode.TabIndex = 104;
            this.dgvConfigShiftCode.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvConfigShiftCode_DefaultValuesNeeded);
            // 
            // columnCode
            // 
            this.columnCode.DataPropertyName = "Code";
            this.columnCode.DataSource = this.cCodeForComboBindingSource;
            this.columnCode.DisplayMember = "Code";
            this.columnCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.columnCode.HeaderText = "代号";
            this.columnCode.Name = "columnCode";
            this.columnCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnCode.ValueMember = "Code";
            this.columnCode.Width = 64;
            // 
            // cCodeForComboBindingSource
            // 
            this.cCodeForComboBindingSource.DataSource = typeof(VoucherExpense.FormShift.CCodeForCombo);
            // 
            // columnNote
            // 
            this.columnNote.DataPropertyName = "Note";
            this.columnNote.HeaderText = "意義";
            this.columnNote.Name = "columnNote";
            this.columnNote.Width = 160;
            // 
            // columnHour
            // 
            this.columnHour.DataPropertyName = "Hour";
            this.columnHour.DataSource = this.cHourForComboBindingSource;
            this.columnHour.DisplayMember = "Hour";
            this.columnHour.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.columnHour.HeaderText = "換算工時";
            this.columnHour.Name = "columnHour";
            this.columnHour.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnHour.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnHour.ValueMember = "Hour";
            // 
            // cHourForComboBindingSource
            // 
            this.cHourForComboBindingSource.DataSource = typeof(VoucherExpense.FormShift.CHourForCombo);
            // 
            // cShiftCodeBindingSource
            // 
            this.cShiftCodeBindingSource.DataSource = typeof(VoucherExpense.CShiftCode);
            // 
            // dgvShift
            // 
            this.dgvShift.AllowUserToAddRows = false;
            this.dgvShift.AllowUserToDeleteRows = false;
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
            this.tableNameDataGridViewTextBoxColumn,
            this.ColumnTableMonth,
            this.columnLocked,
            this.KeyinID,
            this.lastUpdatedDataGridViewTextBoxColumn});
            this.dgvShift.DataSource = this.shiftTableBindingSource;
            this.dgvShift.Location = new System.Drawing.Point(0, 32);
            this.dgvShift.MultiSelect = false;
            this.dgvShift.Name = "dgvShift";
            this.dgvShift.RowHeadersVisible = false;
            this.dgvShift.RowTemplate.Height = 24;
            this.dgvShift.Size = new System.Drawing.Size(458, 642);
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
            // tableNameDataGridViewTextBoxColumn
            // 
            this.tableNameDataGridViewTextBoxColumn.DataPropertyName = "TableName";
            this.tableNameDataGridViewTextBoxColumn.HeaderText = "名稱";
            this.tableNameDataGridViewTextBoxColumn.Name = "tableNameDataGridViewTextBoxColumn";
            this.tableNameDataGridViewTextBoxColumn.Width = 160;
            // 
            // ColumnTableMonth
            // 
            this.ColumnTableMonth.DataPropertyName = "TableMonth";
            this.ColumnTableMonth.DataSource = this.cMonthForComboBindingSource;
            this.ColumnTableMonth.DisplayMember = "Name";
            this.ColumnTableMonth.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnTableMonth.HeaderText = "月份";
            this.ColumnTableMonth.Name = "ColumnTableMonth";
            this.ColumnTableMonth.ValueMember = "Index";
            this.ColumnTableMonth.Width = 64;
            // 
            // columnLocked
            // 
            this.columnLocked.DataPropertyName = "Locked";
            this.columnLocked.HeaderText = "核";
            this.columnLocked.Name = "columnLocked";
            this.columnLocked.ReadOnly = true;
            this.columnLocked.Width = 32;
            // 
            // KeyinID
            // 
            this.KeyinID.DataPropertyName = "KeyinID";
            this.KeyinID.DataSource = this.operatorBindingSource;
            this.KeyinID.DisplayMember = "Name";
            this.KeyinID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.KeyinID.HeaderText = "制表";
            this.KeyinID.Name = "KeyinID";
            this.KeyinID.ReadOnly = true;
            this.KeyinID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.KeyinID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.KeyinID.ValueMember = "OperatorID";
            this.KeyinID.Width = 80;
            // 
            // lastUpdatedDataGridViewTextBoxColumn
            // 
            this.lastUpdatedDataGridViewTextBoxColumn.DataPropertyName = "LastUpdated";
            dataGridViewCellStyle2.Format = "MM-dd HH:mm";
            this.lastUpdatedDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.lastUpdatedDataGridViewTextBoxColumn.HeaderText = "更新";
            this.lastUpdatedDataGridViewTextBoxColumn.Name = "lastUpdatedDataGridViewTextBoxColumn";
            this.lastUpdatedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // damaiDataSet
            // 
            this.damaiDataSet.DataSetName = "DamaiDataSet";
            this.damaiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FormShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(896, 675);
            this.Controls.Add(this.dgvConfigShiftCode);
            this.Controls.Add(this.btnSaveCodeConfig);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.shiftTableBindingNavigator);
            this.Controls.Add(this.dgvShift);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormShift";
            this.ShowIcon = false;
            this.Text = "排班表";
            this.Load += new System.EventHandler(this.FormShift_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cMonthForComboBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftTableBindingNavigator)).EndInit();
            this.shiftTableBindingNavigator.ResumeLayout(false);
            this.shiftTableBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigShiftCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cCodeForComboBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cHourForComboBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cShiftCodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingNavigator shiftTableBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton 儲存SToolStripButton;
        private System.Windows.Forms.BindingSource operatorBindingSource;
        private System.Windows.Forms.BindingSource cMonthForComboBindingSource;
        private System.Windows.Forms.BindingSource shiftTableBindingSource;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.BindingSource hRBindingSource;
        private System.Windows.Forms.Button btnSaveCodeConfig;
        private System.Windows.Forms.DataGridView dgvConfigShiftCode;
        private System.Windows.Forms.BindingSource cCodeForComboBindingSource;
        private System.Windows.Forms.BindingSource cHourForComboBindingSource;
        private System.Windows.Forms.BindingSource cShiftCodeBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn columnCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnNote;
        private System.Windows.Forms.DataGridViewComboBoxColumn columnHour;
        private System.Windows.Forms.DataGridView dgvShift;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnShiftID;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnTableMonth;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnLocked;
        private System.Windows.Forms.DataGridViewComboBoxColumn KeyinID;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedDataGridViewTextBoxColumn;
        private DamaiDataSet damaiDataSet;
    }
}