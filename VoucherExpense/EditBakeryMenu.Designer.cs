namespace VoucherExpense
{
    partial class EditBakeryMenu
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
            this.listBoxProduct = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.contextMenuStripForTabControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.插入toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刪除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.改名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.bakeryOrderSet = new VoucherExpense.BakeryOrderSet();
            this.productTableAdapter1 = new VoucherExpense.BakeryOrderSetTableAdapters.ProductTableAdapter();
            this.comboBoxWidth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxHeight = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.textBoxRename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.contextMenuStripForTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxProduct
            // 
            this.listBoxProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxProduct.BackColor = System.Drawing.Color.SeaShell;
            this.listBoxProduct.FormattingEnabled = true;
            this.listBoxProduct.ItemHeight = 16;
            this.listBoxProduct.Location = new System.Drawing.Point(1, 3);
            this.listBoxProduct.Name = "listBoxProduct";
            this.listBoxProduct.Size = new System.Drawing.Size(164, 516);
            this.listBoxProduct.TabIndex = 3;
            this.listBoxProduct.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxProduct_MouseDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl1.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.ItemSize = new System.Drawing.Size(92, 32);
            this.tabControl1.Location = new System.Drawing.Point(167, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(748, 671);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDown);
            this.tabControl1.MouseLeave += new System.EventHandler(this.tabControl1_MouseLeave);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Azure;
            this.tabPage2.ContextMenuStrip = this.contextMenuStripForTabControl;
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(740, 631);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "饮料西点";
            // 
            // contextMenuStripForTabControl
            // 
            this.contextMenuStripForTabControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.插入toolStripMenuItem,
            this.刪除ToolStripMenuItem,
            this.改名ToolStripMenuItem});
            this.contextMenuStripForTabControl.Name = "contextMenuStripForTabControl";
            this.contextMenuStripForTabControl.Size = new System.Drawing.Size(103, 70);
            // 
            // 插入toolStripMenuItem
            // 
            this.插入toolStripMenuItem.Name = "插入toolStripMenuItem";
            this.插入toolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.插入toolStripMenuItem.Text = "插入";
            this.插入toolStripMenuItem.Click += new System.EventHandler(this.插入toolStripMenuItem_Click);
            // 
            // 刪除ToolStripMenuItem
            // 
            this.刪除ToolStripMenuItem.Name = "刪除ToolStripMenuItem";
            this.刪除ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.刪除ToolStripMenuItem.Text = "刪除";
            this.刪除ToolStripMenuItem.Click += new System.EventHandler(this.刪除ToolStripMenuItem_Click);
            // 
            // 改名ToolStripMenuItem
            // 
            this.改名ToolStripMenuItem.Name = "改名ToolStripMenuItem";
            this.改名ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.改名ToolStripMenuItem.Text = "改名";
            this.改名ToolStripMenuItem.Click += new System.EventHandler(this.改名ToolStripMenuItem_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Azure;
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(740, 631);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "面包";
            // 
            // bakeryOrderSet
            // 
            this.bakeryOrderSet.DataSetName = "BakeryOrderSet";
            this.bakeryOrderSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productTableAdapter1
            // 
            this.productTableAdapter1.ClearBeforeFill = true;
            // 
            // comboBoxWidth
            // 
            this.comboBoxWidth.FormattingEnabled = true;
            this.comboBoxWidth.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxWidth.Location = new System.Drawing.Point(19, 536);
            this.comboBoxWidth.Name = "comboBoxWidth";
            this.comboBoxWidth.Size = new System.Drawing.Size(47, 24);
            this.comboBoxWidth.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 540);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "寬";
            // 
            // comboBoxHeight
            // 
            this.comboBoxHeight.FormattingEnabled = true;
            this.comboBoxHeight.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14"});
            this.comboBoxHeight.Location = new System.Drawing.Point(108, 536);
            this.comboBoxHeight.Name = "comboBoxHeight";
            this.comboBoxHeight.Size = new System.Drawing.Size(47, 24);
            this.comboBoxHeight.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 540);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "高";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(19, 566);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(136, 37);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "本頁菜單存檔";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textBoxRename
            // 
            this.textBoxRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxRename.Location = new System.Drawing.Point(74, 635);
            this.textBoxRename.MaxLength = 6;
            this.textBoxRename.Name = "textBoxRename";
            this.textBoxRename.Size = new System.Drawing.Size(86, 27);
            this.textBoxRename.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 638);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "改名為";
            // 
            // EditBakeryMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(915, 671);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.comboBoxHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxProduct);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.textBoxRename);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EditBakeryMenu";
            this.Text = "烘焙菜單";
            this.Load += new System.EventHandler(this.EditBakeryMenu_Load);
            this.tabControl1.ResumeLayout(false);
            this.contextMenuStripForTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxProduct;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private BakeryOrderSet bakeryOrderSet;
        private BakeryOrderSetTableAdapters.ProductTableAdapter productTableAdapter1;
        private System.Windows.Forms.ComboBox comboBoxWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBoxRename;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripForTabControl;
        private System.Windows.Forms.ToolStripMenuItem 刪除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 改名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 插入toolStripMenuItem;
        private System.Windows.Forms.Label label3;
    }
}