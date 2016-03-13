namespace VoucherExpense
{
    partial class FormOperatorAuthList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOperatorAuthList));
            this.label1 = new System.Windows.Forms.Label();
            this.damaiDataSet = new VoucherExpense.DamaiDataSet();
            this.operatorAuthListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.operatorAuthListTableAdapter = new VoucherExpense.DamaiDataSetTableAdapters.OperatorAuthListTableAdapter();
            this.operatorAuthListBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.operatorAuthListBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.operatorAuthListDataGridView = new System.Windows.Forms.DataGridView();
            this.columnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnOperatorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvComboName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.apartmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorAuthListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorAuthListBindingNavigator)).BeginInit();
            this.operatorAuthListBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.operatorAuthListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "可登入門店";
            // 
            // damaiDataSet
            // 
            this.damaiDataSet.DataSetName = "DamaiDataSet";
            this.damaiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // operatorAuthListBindingSource
            // 
            this.operatorAuthListBindingSource.DataMember = "OperatorAuthList";
            this.operatorAuthListBindingSource.DataSource = this.damaiDataSet;
            // 
            // operatorAuthListTableAdapter
            // 
            this.operatorAuthListTableAdapter.ClearBeforeFill = true;
            // 
            // operatorAuthListBindingNavigator
            // 
            this.operatorAuthListBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.operatorAuthListBindingNavigator.BindingSource = this.operatorAuthListBindingSource;
            this.operatorAuthListBindingNavigator.CountItem = null;
            this.operatorAuthListBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.operatorAuthListBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.operatorAuthListBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.operatorAuthListBindingNavigatorSaveItem});
            this.operatorAuthListBindingNavigator.Location = new System.Drawing.Point(119, 0);
            this.operatorAuthListBindingNavigator.MoveFirstItem = null;
            this.operatorAuthListBindingNavigator.MoveLastItem = null;
            this.operatorAuthListBindingNavigator.MoveNextItem = null;
            this.operatorAuthListBindingNavigator.MovePreviousItem = null;
            this.operatorAuthListBindingNavigator.Name = "operatorAuthListBindingNavigator";
            this.operatorAuthListBindingNavigator.PositionItem = null;
            this.operatorAuthListBindingNavigator.Size = new System.Drawing.Size(81, 25);
            this.operatorAuthListBindingNavigator.TabIndex = 2;
            this.operatorAuthListBindingNavigator.Text = "bindingNavigator1";
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
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "刪除";
            // 
            // operatorAuthListBindingNavigatorSaveItem
            // 
            this.operatorAuthListBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.operatorAuthListBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("operatorAuthListBindingNavigatorSaveItem.Image")));
            this.operatorAuthListBindingNavigatorSaveItem.Name = "operatorAuthListBindingNavigatorSaveItem";
            this.operatorAuthListBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.operatorAuthListBindingNavigatorSaveItem.Text = "儲存資料";
            this.operatorAuthListBindingNavigatorSaveItem.Click += new System.EventHandler(this.operatorAuthListBindingNavigatorSaveItem_Click);
            // 
            // operatorAuthListDataGridView
            // 
            this.operatorAuthListDataGridView.AllowUserToAddRows = false;
            this.operatorAuthListDataGridView.AllowUserToResizeRows = false;
            this.operatorAuthListDataGridView.AutoGenerateColumns = false;
            this.operatorAuthListDataGridView.BackgroundColor = System.Drawing.Color.SeaShell;
            this.operatorAuthListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.operatorAuthListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnID,
            this.columnOperatorID,
            this.dgvComboName});
            this.operatorAuthListDataGridView.DataSource = this.operatorAuthListBindingSource;
            this.operatorAuthListDataGridView.Location = new System.Drawing.Point(0, 28);
            this.operatorAuthListDataGridView.Name = "operatorAuthListDataGridView";
            this.operatorAuthListDataGridView.RowTemplate.Height = 24;
            this.operatorAuthListDataGridView.Size = new System.Drawing.Size(429, 671);
            this.operatorAuthListDataGridView.TabIndex = 2;
            // 
            // columnID
            // 
            this.columnID.DataPropertyName = "ID";
            this.columnID.HeaderText = "ID";
            this.columnID.MinimumWidth = 2;
            this.columnID.Name = "columnID";
            this.columnID.ReadOnly = true;
            this.columnID.Width = 2;
            // 
            // columnOperatorID
            // 
            this.columnOperatorID.DataPropertyName = "OperatorID";
            this.columnOperatorID.HeaderText = "OperatorID";
            this.columnOperatorID.MinimumWidth = 2;
            this.columnOperatorID.Name = "columnOperatorID";
            this.columnOperatorID.ReadOnly = true;
            this.columnOperatorID.Width = 2;
            // 
            // dgvComboName
            // 
            this.dgvComboName.DataPropertyName = "ApartmentID";
            this.dgvComboName.DataSource = this.apartmentBindingSource;
            this.dgvComboName.DisplayMember = "ApartmentName";
            this.dgvComboName.HeaderText = "門店名稱";
            this.dgvComboName.Name = "dgvComboName";
            this.dgvComboName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComboName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvComboName.ValueMember = "ApartmentID";
            this.dgvComboName.Width = 360;
            // 
            // apartmentBindingSource
            // 
            this.apartmentBindingSource.DataMember = "Apartment";
            this.apartmentBindingSource.DataSource = this.damaiDataSet;
            // 
            // FormOperatorAuthList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(430, 699);
            this.Controls.Add(this.operatorAuthListDataGridView);
            this.Controls.Add(this.operatorAuthListBindingNavigator);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "FormOperatorAuthList";
            this.Text = "FormOperatorAuthList";
            this.Load += new System.EventHandler(this.FormOperatorAuthList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorAuthListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorAuthListBindingNavigator)).EndInit();
            this.operatorAuthListBindingNavigator.ResumeLayout(false);
            this.operatorAuthListBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.operatorAuthListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DamaiDataSet damaiDataSet;
        private System.Windows.Forms.BindingSource operatorAuthListBindingSource;
        private DamaiDataSetTableAdapters.OperatorAuthListTableAdapter operatorAuthListTableAdapter;
        private System.Windows.Forms.BindingNavigator operatorAuthListBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton operatorAuthListBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView operatorAuthListDataGridView;
        private System.Windows.Forms.BindingSource apartmentBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnOperatorID;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvComboName;
    }
}