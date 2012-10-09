namespace VoucherExpense
{
    partial class FormEditMenu
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
            this.cbSelectMenu = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxProduct = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.basicDataSet1 = new VoucherExpense.BasicDataSet();
            this.productTableAdapter1 = new VoucherExpense.BasicDataSetTableAdapters.ProductTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.basicDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSelectMenu
            // 
            this.cbSelectMenu.FormattingEnabled = true;
            this.cbSelectMenu.Items.AddRange(new object[] {
            "主菜單",
            "酒水單"});
            this.cbSelectMenu.Location = new System.Drawing.Point(13, 13);
            this.cbSelectMenu.Margin = new System.Windows.Forms.Padding(4);
            this.cbSelectMenu.Name = "cbSelectMenu";
            this.cbSelectMenu.Size = new System.Drawing.Size(120, 24);
            this.cbSelectMenu.TabIndex = 0;
            this.cbSelectMenu.SelectedIndexChanged += new System.EventHandler(this.cbSelectMenu_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Azure;
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(160, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(750, 673);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // listBoxProduct
            // 
            this.listBoxProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.listBoxProduct.FormattingEnabled = true;
            this.listBoxProduct.ItemHeight = 16;
            this.listBoxProduct.Location = new System.Drawing.Point(4, 52);
            this.listBoxProduct.Name = "listBoxProduct";
            this.listBoxProduct.Size = new System.Drawing.Size(150, 580);
            this.listBoxProduct.TabIndex = 2;
            this.listBoxProduct.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxProduct_MouseDown);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(20, 638);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "菜單存檔";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // basicDataSet1
            // 
            this.basicDataSet1.DataSetName = "BasicDataSet";
            this.basicDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productTableAdapter1
            // 
            this.productTableAdapter1.ClearBeforeFill = true;
            // 
            // FormEditMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(910, 673);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.listBoxProduct);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbSelectMenu);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormEditMenu";
            this.Text = "編修菜單";
            this.Load += new System.EventHandler(this.FormEditMenu_Load);
            this.Shown += new System.EventHandler(this.FormEditMenu_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.basicDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSelectMenu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBoxProduct;
        private System.Windows.Forms.Button btnSave;
        private BasicDataSet basicDataSet1;
        private BasicDataSetTableAdapters.ProductTableAdapter productTableAdapter1;
    }
}