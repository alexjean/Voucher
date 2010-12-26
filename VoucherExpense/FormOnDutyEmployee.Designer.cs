namespace VoucherExpense
{
    partial class FormOnDutyEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOnDutyEmployee));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.onDutyEmployeeBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.onDutyEmployeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.onDutyEmployeeBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.onDutyEmployeeTableAdapter = new VoucherExpense.VEDataSetTableAdapters.OnDutyEmployeeTableAdapter();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.onDutyDataTableAdapter = new VoucherExpense.VEDataSetTableAdapters.OnDutyDataTableAdapter();
            this.labelName = new System.Windows.Forms.Label();
            this.ckBoxShowAll = new System.Windows.Forms.CheckBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnConfirmTrans = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dgvOnDutyEmployee = new System.Windows.Forms.DataGridView();
            this.columnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.onDutyEmployeeBindingNavigator)).BeginInit();
            this.onDutyEmployeeBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.onDutyEmployeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOnDutyEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // onDutyEmployeeBindingNavigator
            // 
            this.onDutyEmployeeBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.onDutyEmployeeBindingNavigator.BindingSource = this.onDutyEmployeeBindingSource;
            this.onDutyEmployeeBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.onDutyEmployeeBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.onDutyEmployeeBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.onDutyEmployeeBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.onDutyEmployeeBindingNavigatorSaveItem});
            this.onDutyEmployeeBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.onDutyEmployeeBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.onDutyEmployeeBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.onDutyEmployeeBindingNavigator.MoveNextItem = null;
            this.onDutyEmployeeBindingNavigator.MovePreviousItem = null;
            this.onDutyEmployeeBindingNavigator.Name = "onDutyEmployeeBindingNavigator";
            this.onDutyEmployeeBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.onDutyEmployeeBindingNavigator.Size = new System.Drawing.Size(217, 25);
            this.onDutyEmployeeBindingNavigator.TabIndex = 0;
            this.onDutyEmployeeBindingNavigator.Text = "bindingNavigator1";
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
            // onDutyEmployeeBindingSource
            // 
            this.onDutyEmployeeBindingSource.DataMember = "OnDutyEmployee";
            this.onDutyEmployeeBindingSource.DataSource = this.vEDataSet;
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(32, 22);
            this.bindingNavigatorCountItem.Text = "/{0}";
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
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "移到最前面";
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 25);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "目前的位置";
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
            // onDutyEmployeeBindingNavigatorSaveItem
            // 
            this.onDutyEmployeeBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.onDutyEmployeeBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("onDutyEmployeeBindingNavigatorSaveItem.Image")));
            this.onDutyEmployeeBindingNavigatorSaveItem.Name = "onDutyEmployeeBindingNavigatorSaveItem";
            this.onDutyEmployeeBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.onDutyEmployeeBindingNavigatorSaveItem.Text = "儲存資料";
            this.onDutyEmployeeBindingNavigatorSaveItem.Click += new System.EventHandler(this.onDutyEmployeeBindingNavigatorSaveItem_Click);
            // 
            // onDutyEmployeeTableAdapter
            // 
            this.onDutyEmployeeTableAdapter.ClearBeforeFill = true;
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
            this.comboBoxMonth.Location = new System.Drawing.Point(243, 3);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(71, 24);
            this.comboBoxMonth.TabIndex = 54;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // onDutyDataTableAdapter
            // 
            this.onDutyDataTableAdapter.ClearBeforeFill = true;
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(570, 1);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(243, 26);
            this.labelName.TabIndex = 56;
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ckBoxShowAll
            // 
            this.ckBoxShowAll.AutoSize = true;
            this.ckBoxShowAll.Location = new System.Drawing.Point(353, 5);
            this.ckBoxShowAll.Name = "ckBoxShowAll";
            this.ckBoxShowAll.Size = new System.Drawing.Size(91, 20);
            this.ckBoxShowAll.TabIndex = 57;
            this.ckBoxShowAll.Text = "顯示全部";
            this.ckBoxShowAll.UseVisualStyleBackColor = true;
            this.ckBoxShowAll.CheckedChanged += new System.EventHandler(this.ckBoxShowAll_CheckedChanged);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(457, 4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(90, 23);
            this.btnImport.TabIndex = 58;
            this.btnImport.Text = "匯入資料";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.Filter = "Txt|*.txt|所有檔|*.*";
            // 
            // btnConfirmTrans
            // 
            this.btnConfirmTrans.Location = new System.Drawing.Point(812, 4);
            this.btnConfirmTrans.Name = "btnConfirmTrans";
            this.btnConfirmTrans.Size = new System.Drawing.Size(90, 23);
            this.btnConfirmTrans.TabIndex = 59;
            this.btnConfirmTrans.Text = "確定轉入";
            this.btnConfirmTrans.UseVisualStyleBackColor = true;
            this.btnConfirmTrans.Visible = false;
            this.btnConfirmTrans.Click += new System.EventHandler(this.btnConfirmTrans_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 497);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(902, 20);
            this.progressBar1.TabIndex = 60;
            this.progressBar1.Visible = false;
            // 
            // dgvOnDutyEmployee
            // 
            this.dgvOnDutyEmployee.AllowUserToAddRows = false;
            this.dgvOnDutyEmployee.AllowUserToResizeRows = false;
            this.dgvOnDutyEmployee.AutoGenerateColumns = false;
            this.dgvOnDutyEmployee.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgvOnDutyEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOnDutyEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnID,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewCheckBoxColumn1,
            this.ColumnName,
            this.dataGridViewTextBoxColumn5});
            this.dgvOnDutyEmployee.DataSource = this.onDutyEmployeeBindingSource;
            this.dgvOnDutyEmployee.Location = new System.Drawing.Point(0, 30);
            this.dgvOnDutyEmployee.Name = "dgvOnDutyEmployee";
            this.dgvOnDutyEmployee.RowHeadersVisible = false;
            this.dgvOnDutyEmployee.RowTemplate.Height = 24;
            this.dgvOnDutyEmployee.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvOnDutyEmployee.Size = new System.Drawing.Size(444, 576);
            this.dgvOnDutyEmployee.TabIndex = 1;
            this.dgvOnDutyEmployee.SelectionChanged += new System.EventHandler(this.dgvOnDutyEmployee_SelectionChanged);
            // 
            // columnID
            // 
            this.columnID.DataPropertyName = "ID";
            this.columnID.HeaderText = "ID";
            this.columnID.MinimumWidth = 2;
            this.columnID.Name = "columnID";
            this.columnID.Width = 2;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "OnDutyCode";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn2.HeaderText = "指紋号";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 96;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Title";
            this.dataGridViewTextBoxColumn3.HeaderText = "";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 5;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "IsOnTheJob";
            this.dataGridViewCheckBoxColumn1.HeaderText = "在職";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 64;
            // 
            // ColumnName
            // 
            this.ColumnName.DataPropertyName = "Name";
            this.ColumnName.HeaderText = "姓名";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Width = 64;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "LastUpdated";
            this.dataGridViewTextBoxColumn5.HeaderText = "";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 2;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 2;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.Azure;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(457, 30);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(445, 576);
            this.checkedListBox1.TabIndex = 55;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 607);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 0);
            this.panel1.TabIndex = 61;
            // 
            // FormOnDutyEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 607);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dgvOnDutyEmployee);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnConfirmTrans);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.ckBoxShowAll);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.onDutyEmployeeBindingNavigator);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormOnDutyEmployee";
            this.Text = "人事資料";
            this.Load += new System.EventHandler(this.FormOnDutyEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.onDutyEmployeeBindingNavigator)).EndInit();
            this.onDutyEmployeeBindingNavigator.ResumeLayout(false);
            this.onDutyEmployeeBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.onDutyEmployeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOnDutyEmployee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource onDutyEmployeeBindingSource;
        private VoucherExpense.VEDataSetTableAdapters.OnDutyEmployeeTableAdapter onDutyEmployeeTableAdapter;
        private System.Windows.Forms.BindingNavigator onDutyEmployeeBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton onDutyEmployeeBindingNavigatorSaveItem;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private VoucherExpense.VEDataSetTableAdapters.OnDutyDataTableAdapter onDutyDataTableAdapter;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.CheckBox ckBoxShowAll;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnConfirmTrans;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView dgvOnDutyEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Panel panel1;
    }
}