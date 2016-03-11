namespace VoucherExpense
{
    partial class FormApartment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormApartment));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.apartmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.damaiDataSet = new VoucherExpense.DamaiDataSet();
            this.apartmentBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.apartmentBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.apartmentDataGridView = new System.Windows.Forms.DataGridView();
            this.columnApartmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppartementCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApartmentAllName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCurrent = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LocalServerIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatabaseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocalUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocalPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CloudServerIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CloudSharedDatabase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CloudUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CloudPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apartmentSQLAdapter = new VoucherExpense.DamaiDataSetTableAdapters.ApartmentTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentBindingNavigator)).BeginInit();
            this.apartmentBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // apartmentBindingSource
            // 
            this.apartmentBindingSource.DataMember = "Apartment";
            this.apartmentBindingSource.DataSource = this.damaiDataSet;
            // 
            // damaiDataSet
            // 
            this.damaiDataSet.DataSetName = "DamaiDataSet";
            this.damaiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // apartmentBindingNavigator
            // 
            this.apartmentBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.apartmentBindingNavigator.BindingSource = this.apartmentBindingSource;
            this.apartmentBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.apartmentBindingNavigator.DeleteItem = null;
            this.apartmentBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.apartmentBindingNavigatorSaveItem});
            this.apartmentBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.apartmentBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.apartmentBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.apartmentBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.apartmentBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.apartmentBindingNavigator.Name = "apartmentBindingNavigator";
            this.apartmentBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.apartmentBindingNavigator.Size = new System.Drawing.Size(1548, 25);
            this.apartmentBindingNavigator.TabIndex = 0;
            this.apartmentBindingNavigator.Text = "bindingNavigator1";
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
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(27, 22);
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
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
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
            // apartmentBindingNavigatorSaveItem
            // 
            this.apartmentBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.apartmentBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("apartmentBindingNavigatorSaveItem.Image")));
            this.apartmentBindingNavigatorSaveItem.Name = "apartmentBindingNavigatorSaveItem";
            this.apartmentBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.apartmentBindingNavigatorSaveItem.Text = "儲存資料";
            this.apartmentBindingNavigatorSaveItem.Click += new System.EventHandler(this.apartmentBindingNavigatorSaveItem_Click);
            // 
            // apartmentDataGridView
            // 
            this.apartmentDataGridView.AllowUserToAddRows = false;
            this.apartmentDataGridView.AllowUserToDeleteRows = false;
            this.apartmentDataGridView.AllowUserToResizeRows = false;
            this.apartmentDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.apartmentDataGridView.AutoGenerateColumns = false;
            this.apartmentDataGridView.BackgroundColor = System.Drawing.Color.Azure;
            this.apartmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.apartmentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnApartmentID,
            this.AppartementCode,
            this.dataGridViewTextBoxColumn2,
            this.ApartmentAllName,
            this.IsCurrent,
            this.LocalServerIP,
            this.DatabaseName,
            this.LocalUserID,
            this.LocalPassword,
            this.CloudServerIP,
            this.CloudSharedDatabase,
            this.CloudUserID,
            this.CloudPassword});
            this.apartmentDataGridView.DataSource = this.apartmentBindingSource;
            this.apartmentDataGridView.Location = new System.Drawing.Point(0, 28);
            this.apartmentDataGridView.Name = "apartmentDataGridView";
            this.apartmentDataGridView.RowTemplate.Height = 24;
            this.apartmentDataGridView.Size = new System.Drawing.Size(1548, 654);
            this.apartmentDataGridView.TabIndex = 1;
            // 
            // columnApartmentID
            // 
            this.columnApartmentID.DataPropertyName = "ApartmentID";
            this.columnApartmentID.HeaderText = "內碼";
            this.columnApartmentID.Name = "columnApartmentID";
            this.columnApartmentID.ReadOnly = true;
            this.columnApartmentID.Width = 64;
            // 
            // AppartementCode
            // 
            this.AppartementCode.DataPropertyName = "AppartementCode";
            this.AppartementCode.HeaderText = "部门代碼";
            this.AppartementCode.Name = "AppartementCode";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ApartmentName";
            this.dataGridViewTextBoxColumn2.HeaderText = "部門简称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // ApartmentAllName
            // 
            this.ApartmentAllName.DataPropertyName = "ApartmentAllName";
            this.ApartmentAllName.HeaderText = "部门全称";
            this.ApartmentAllName.Name = "ApartmentAllName";
            this.ApartmentAllName.Width = 240;
            // 
            // IsCurrent
            // 
            this.IsCurrent.DataPropertyName = "IsCurrent";
            this.IsCurrent.HeaderText = "";
            this.IsCurrent.Name = "IsCurrent";
            // 
            // LocalServerIP
            // 
            this.LocalServerIP.DataPropertyName = "LocalServerIP";
            dataGridViewCellStyle1.NullValue = "\"\"";
            this.LocalServerIP.DefaultCellStyle = dataGridViewCellStyle1;
            this.LocalServerIP.HeaderText = "LocalServerIP";
            this.LocalServerIP.Name = "LocalServerIP";
            this.LocalServerIP.Width = 110;
            // 
            // DatabaseName
            // 
            this.DatabaseName.DataPropertyName = "DatabaseName";
            dataGridViewCellStyle2.NullValue = "\"\"";
            this.DatabaseName.DefaultCellStyle = dataGridViewCellStyle2;
            this.DatabaseName.HeaderText = "DatabaseName";
            this.DatabaseName.Name = "DatabaseName";
            this.DatabaseName.Width = 110;
            // 
            // LocalUserID
            // 
            this.LocalUserID.DataPropertyName = "LocalUserID";
            dataGridViewCellStyle3.NullValue = "\"\"";
            this.LocalUserID.DefaultCellStyle = dataGridViewCellStyle3;
            this.LocalUserID.HeaderText = "LocalUserID";
            this.LocalUserID.Name = "LocalUserID";
            this.LocalUserID.Width = 110;
            // 
            // LocalPassword
            // 
            this.LocalPassword.DataPropertyName = "LocalPassword";
            dataGridViewCellStyle4.NullValue = "\"\"";
            this.LocalPassword.DefaultCellStyle = dataGridViewCellStyle4;
            this.LocalPassword.HeaderText = "LocalPassword";
            this.LocalPassword.Name = "LocalPassword";
            this.LocalPassword.Width = 110;
            // 
            // CloudServerIP
            // 
            this.CloudServerIP.DataPropertyName = "CloudServerIP";
            dataGridViewCellStyle5.NullValue = "\"\"";
            this.CloudServerIP.DefaultCellStyle = dataGridViewCellStyle5;
            this.CloudServerIP.HeaderText = "CloudServerIP";
            this.CloudServerIP.Name = "CloudServerIP";
            this.CloudServerIP.Width = 110;
            // 
            // CloudSharedDatabase
            // 
            this.CloudSharedDatabase.DataPropertyName = "CloudSharedDatabase";
            dataGridViewCellStyle6.NullValue = "\"\"";
            this.CloudSharedDatabase.DefaultCellStyle = dataGridViewCellStyle6;
            this.CloudSharedDatabase.HeaderText = "CloudSharedDatabase";
            this.CloudSharedDatabase.Name = "CloudSharedDatabase";
            this.CloudSharedDatabase.Width = 110;
            // 
            // CloudUserID
            // 
            this.CloudUserID.DataPropertyName = "CloudUserID";
            dataGridViewCellStyle7.NullValue = "\"\"";
            this.CloudUserID.DefaultCellStyle = dataGridViewCellStyle7;
            this.CloudUserID.HeaderText = "CloudUserID";
            this.CloudUserID.Name = "CloudUserID";
            this.CloudUserID.Width = 110;
            // 
            // CloudPassword
            // 
            this.CloudPassword.DataPropertyName = "CloudPassword";
            dataGridViewCellStyle8.NullValue = "\"\"";
            this.CloudPassword.DefaultCellStyle = dataGridViewCellStyle8;
            this.CloudPassword.HeaderText = "CloudPassword";
            this.CloudPassword.Name = "CloudPassword";
            this.CloudPassword.Width = 110;
            // 
            // apartmentSQLAdapter
            // 
            this.apartmentSQLAdapter.ClearBeforeFill = true;
            // 
            // FormApartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1548, 684);
            this.Controls.Add(this.apartmentDataGridView);
            this.Controls.Add(this.apartmentBindingNavigator);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormApartment";
            this.Text = "編修部門";
            this.Load += new System.EventHandler(this.FormApartment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.apartmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentBindingNavigator)).EndInit();
            this.apartmentBindingNavigator.ResumeLayout(false);
            this.apartmentBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource apartmentBindingSource;
        private System.Windows.Forms.BindingNavigator apartmentBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton apartmentBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView apartmentDataGridView;
        private DamaiDataSetTableAdapters.ApartmentTableAdapter apartmentSQLAdapter;
        private DamaiDataSet damaiDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnApartmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppartementCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApartmentAllName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsCurrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalServerIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatabaseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn CloudServerIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn CloudSharedDatabase;
        private System.Windows.Forms.DataGridViewTextBoxColumn CloudUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CloudPassword;
    }
}