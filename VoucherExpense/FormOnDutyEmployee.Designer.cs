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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.onDutyDataTableAdapter = new VoucherExpense.VEDataSetTableAdapters.OnDutyDataTableAdapter();
            this.labelName = new System.Windows.Forms.Label();
            this.ckBoxShowAll = new System.Windows.Forms.CheckBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnConfirmTrans = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dgvOnDutyEmployee = new System.Windows.Forms.DataGridView();
            this.employeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FingerPintNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InPosition = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnApartmentID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.apartmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hRTableAdapter = new VoucherExpense.VEDataSetTableAdapters.HRTableAdapter();
            this.apartmentTableAdapter = new VoucherExpense.VEDataSetTableAdapters.ApartmentTableAdapter();
            this.comboBoxApartment = new System.Windows.Forms.ComboBox();
            this.cNameIDForComboBoxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOnDutyEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNameIDForComboBoxBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.comboBoxMonth.Location = new System.Drawing.Point(373, 3);
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
            this.ckBoxShowAll.Location = new System.Drawing.Point(152, 5);
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
            this.progressBar1.Location = new System.Drawing.Point(0, 630);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(902, 20);
            this.progressBar1.TabIndex = 60;
            this.progressBar1.Visible = false;
            // 
            // dgvOnDutyEmployee
            // 
            this.dgvOnDutyEmployee.AllowUserToAddRows = false;
            this.dgvOnDutyEmployee.AllowUserToDeleteRows = false;
            this.dgvOnDutyEmployee.AllowUserToOrderColumns = true;
            this.dgvOnDutyEmployee.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dgvOnDutyEmployee.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOnDutyEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvOnDutyEmployee.AutoGenerateColumns = false;
            this.dgvOnDutyEmployee.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgvOnDutyEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOnDutyEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.employeeIDDataGridViewTextBoxColumn,
            this.EmployeeName,
            this.FingerPintNo,
            this.InPosition,
            this.ColumnApartmentID,
            this.Title});
            this.dgvOnDutyEmployee.DataSource = this.hRBindingSource;
            this.dgvOnDutyEmployee.Location = new System.Drawing.Point(0, 30);
            this.dgvOnDutyEmployee.Name = "dgvOnDutyEmployee";
            this.dgvOnDutyEmployee.RowHeadersVisible = false;
            this.dgvOnDutyEmployee.RowTemplate.Height = 24;
            this.dgvOnDutyEmployee.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvOnDutyEmployee.Size = new System.Drawing.Size(444, 620);
            this.dgvOnDutyEmployee.TabIndex = 1;
            this.dgvOnDutyEmployee.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvOnDutyEmployee_DataError);
            this.dgvOnDutyEmployee.SelectionChanged += new System.EventHandler(this.dgvOnDutyEmployee_SelectionChanged);
            // 
            // employeeIDDataGridViewTextBoxColumn
            // 
            this.employeeIDDataGridViewTextBoxColumn.DataPropertyName = "EmployeeID";
            this.employeeIDDataGridViewTextBoxColumn.HeaderText = "EmployeeID";
            this.employeeIDDataGridViewTextBoxColumn.MinimumWidth = 2;
            this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
            this.employeeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeIDDataGridViewTextBoxColumn.Width = 2;
            // 
            // EmployeeName
            // 
            this.EmployeeName.DataPropertyName = "EmployeeName";
            this.EmployeeName.HeaderText = "姓名";
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.ReadOnly = true;
            this.EmployeeName.Width = 64;
            // 
            // FingerPintNo
            // 
            this.FingerPintNo.DataPropertyName = "FingerPintNo";
            this.FingerPintNo.HeaderText = "指紋";
            this.FingerPintNo.Name = "FingerPintNo";
            this.FingerPintNo.ReadOnly = true;
            this.FingerPintNo.Width = 64;
            // 
            // InPosition
            // 
            this.InPosition.DataPropertyName = "InPosition";
            this.InPosition.HeaderText = "顯示";
            this.InPosition.Name = "InPosition";
            this.InPosition.Width = 48;
            // 
            // ColumnApartmentID
            // 
            this.ColumnApartmentID.DataPropertyName = "ApartmentID";
            this.ColumnApartmentID.DataSource = this.apartmentBindingSource;
            this.ColumnApartmentID.DisplayMember = "ApartmentName";
            this.ColumnApartmentID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnApartmentID.HeaderText = "部門";
            this.ColumnApartmentID.Name = "ColumnApartmentID";
            this.ColumnApartmentID.ReadOnly = true;
            this.ColumnApartmentID.ValueMember = "ApartmentID";
            // 
            // apartmentBindingSource
            // 
            this.apartmentBindingSource.DataMember = "Apartment";
            this.apartmentBindingSource.DataSource = this.vEDataSet;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "職稱";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // hRBindingSource
            // 
            this.hRBindingSource.DataMember = "HR";
            this.hRBindingSource.DataSource = this.vEDataSet;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox1.BackColor = System.Drawing.Color.Azure;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(457, 30);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(445, 620);
            this.checkedListBox1.TabIndex = 55;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 652);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 0);
            this.panel1.TabIndex = 61;
            // 
            // hRTableAdapter
            // 
            this.hRTableAdapter.ClearBeforeFill = true;
            // 
            // apartmentTableAdapter
            // 
            this.apartmentTableAdapter.ClearBeforeFill = true;
            // 
            // comboBoxApartment
            // 
            this.comboBoxApartment.DataSource = this.cNameIDForComboBoxBindingSource;
            this.comboBoxApartment.DisplayMember = "Name";
            this.comboBoxApartment.DropDownHeight = 216;
            this.comboBoxApartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxApartment.FormattingEnabled = true;
            this.comboBoxApartment.IntegralHeight = false;
            this.comboBoxApartment.Location = new System.Drawing.Point(0, 3);
            this.comboBoxApartment.Name = "comboBoxApartment";
            this.comboBoxApartment.Size = new System.Drawing.Size(108, 24);
            this.comboBoxApartment.TabIndex = 62;
            this.comboBoxApartment.ValueMember = "ID";
            // 
            // cNameIDForComboBoxBindingSource
            // 
            this.cNameIDForComboBoxBindingSource.DataSource = typeof(VoucherExpense.CNameIDForComboBox);
            // 
            // FormOnDutyEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 652);
            this.Controls.Add(this.comboBoxApartment);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dgvOnDutyEmployee);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnConfirmTrans);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.ckBoxShowAll);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.comboBoxMonth);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormOnDutyEmployee";
            this.Text = "上傳考勤至電腦";
            this.Load += new System.EventHandler(this.FormOnDutyEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOnDutyEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNameIDForComboBoxBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VEDataSet vEDataSet;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private VoucherExpense.VEDataSetTableAdapters.OnDutyDataTableAdapter onDutyDataTableAdapter;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.CheckBox ckBoxShowAll;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnConfirmTrans;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView dgvOnDutyEmployee;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource hRBindingSource;
        private VEDataSetTableAdapters.HRTableAdapter hRTableAdapter;
        private System.Windows.Forms.BindingSource apartmentBindingSource;
        private VEDataSetTableAdapters.ApartmentTableAdapter apartmentTableAdapter;
        private System.Windows.Forms.ComboBox comboBoxApartment;
        private System.Windows.Forms.BindingSource cNameIDForComboBoxBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FingerPintNo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn InPosition;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnApartmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
    }
}