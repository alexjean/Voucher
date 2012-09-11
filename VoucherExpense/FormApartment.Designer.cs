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
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.apartmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.apartmentTableAdapter = new VoucherExpense.VEDataSetTableAdapters.ApartmentTableAdapter();
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
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentBindingNavigator)).BeginInit();
            this.apartmentBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.apartmentBindingNavigator.Size = new System.Drawing.Size(760, 25);
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
            this.apartmentDataGridView.AllowUserToDeleteRows = false;
            this.apartmentDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.apartmentDataGridView.AutoGenerateColumns = false;
            this.apartmentDataGridView.BackgroundColor = System.Drawing.Color.Azure;
            this.apartmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.apartmentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnApartmentID,
            this.dataGridViewTextBoxColumn2});
            this.apartmentDataGridView.DataSource = this.apartmentBindingSource;
            this.apartmentDataGridView.Location = new System.Drawing.Point(0, 28);
            this.apartmentDataGridView.Name = "apartmentDataGridView";
            this.apartmentDataGridView.RowTemplate.Height = 24;
            this.apartmentDataGridView.Size = new System.Drawing.Size(465, 654);
            this.apartmentDataGridView.TabIndex = 1;
            // 
            // columnApartmentID
            // 
            this.columnApartmentID.DataPropertyName = "ApartmentID";
            this.columnApartmentID.HeaderText = "部門內碼";
            this.columnApartmentID.Name = "columnApartmentID";
            this.columnApartmentID.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ApartmentName";
            this.dataGridViewTextBoxColumn2.HeaderText = "部門名稱";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // FormApartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(760, 684);
            this.Controls.Add(this.apartmentDataGridView);
            this.Controls.Add(this.apartmentBindingNavigator);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormApartment";
            this.Text = "編修部門";
            this.Load += new System.EventHandler(this.FormApartment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentBindingNavigator)).EndInit();
            this.apartmentBindingNavigator.ResumeLayout(false);
            this.apartmentBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource apartmentBindingSource;
        private VEDataSetTableAdapters.ApartmentTableAdapter apartmentTableAdapter;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn columnApartmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}