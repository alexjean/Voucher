namespace VoucherExpense
{
    partial class FormSwitchApartment
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
            this.apartmentDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apartmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.damaiDataSet = new VoucherExpense.DamaiDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // apartmentDataGridView
            // 
            this.apartmentDataGridView.AllowUserToAddRows = false;
            this.apartmentDataGridView.AllowUserToDeleteRows = false;
            this.apartmentDataGridView.AllowUserToResizeRows = false;
            this.apartmentDataGridView.AutoGenerateColumns = false;
            this.apartmentDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.apartmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.apartmentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.apartmentDataGridView.DataSource = this.apartmentBindingSource;
            this.apartmentDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.apartmentDataGridView.Location = new System.Drawing.Point(0, 0);
            this.apartmentDataGridView.Name = "apartmentDataGridView";
            this.apartmentDataGridView.ReadOnly = true;
            this.apartmentDataGridView.RowHeadersVisible = false;
            this.apartmentDataGridView.RowTemplate.Height = 24;
            this.apartmentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.apartmentDataGridView.Size = new System.Drawing.Size(429, 431);
            this.apartmentDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ApartmentID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ApartmentID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 2;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 2;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "AppartementCode";
            this.dataGridViewTextBoxColumn2.HeaderText = "店代号";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ApartmentName";
            this.dataGridViewTextBoxColumn3.HeaderText = "店名";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 300;
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
            // FormSwitchApartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 431);
            this.Controls.Add(this.apartmentDataGridView);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormSwitchApartment";
            this.Text = "切換門店";
            this.Load += new System.EventHandler(this.FormSwitchApartment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.apartmentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DamaiDataSet damaiDataSet;
        private System.Windows.Forms.BindingSource apartmentBindingSource;
        private System.Windows.Forms.DataGridView apartmentDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}