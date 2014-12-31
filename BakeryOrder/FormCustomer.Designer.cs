namespace BakeryOrder
{
    partial class FormCustomer
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
            this.lvCustomer = new System.Windows.Forms.ListView();
            this.columnHeader品名 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader量 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader金額 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.pictureBoxOrdered = new System.Windows.Forms.PictureBox();
            this.myImgControl1 = new MyControlLibrary.MyImgControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrdered)).BeginInit();
            this.SuspendLayout();
            // 
            // lvCustomer
            // 
            this.lvCustomer.BackColor = System.Drawing.Color.SeaShell;
            this.lvCustomer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader品名,
            this.columnHeader量,
            this.columnHeader金額});
            this.lvCustomer.Font = new System.Drawing.Font("DFKai-SB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lvCustomer.FullRowSelect = true;
            this.lvCustomer.HideSelection = false;
            this.lvCustomer.Location = new System.Drawing.Point(3, 3);
            this.lvCustomer.Name = "lvCustomer";
            this.lvCustomer.Size = new System.Drawing.Size(266, 469);
            this.lvCustomer.TabIndex = 1;
            this.lvCustomer.UseCompatibleStateImageBehavior = false;
            this.lvCustomer.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader品名
            // 
            this.columnHeader品名.Text = "品名";
            this.columnHeader品名.Width = 164;
            // 
            // columnHeader量
            // 
            this.columnHeader量.Text = "量";
            this.columnHeader量.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader量.Width = 36;
            // 
            // columnHeader金額
            // 
            this.columnHeader金額.Text = "金额";
            this.columnHeader金額.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("DFKai-SB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(118, 659);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "金额总计";
            // 
            // labelTotal
            // 
            this.labelTotal.Font = new System.Drawing.Font("DFKai-SB", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelTotal.ForeColor = System.Drawing.Color.Red;
            this.labelTotal.Location = new System.Drawing.Point(69, 695);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(155, 48);
            this.labelTotal.TabIndex = 4;
            this.labelTotal.Text = "0";
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBoxOrdered
            // 
            this.pictureBoxOrdered.Location = new System.Drawing.Point(16, 478);
            this.pictureBoxOrdered.Name = "pictureBoxOrdered";
            this.pictureBoxOrdered.Size = new System.Drawing.Size(240, 160);
            this.pictureBoxOrdered.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxOrdered.TabIndex = 8;
            this.pictureBoxOrdered.TabStop = false;
            // 
            // myImgControl1
            // 
            this.myImgControl1.BackColor = System.Drawing.Color.Black;
            this.myImgControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.myImgControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.myImgControl1.Location = new System.Drawing.Point(275, 0);
            this.myImgControl1.Margin = new System.Windows.Forms.Padding(4);
            this.myImgControl1.MyStr = null;
            this.myImgControl1.Name = "myImgControl1";
            this.myImgControl1.Size = new System.Drawing.Size(749, 768);
            this.myImgControl1.TabIndex = 9;
            // 
            // FormCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.myImgControl1);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvCustomer);
            this.Controls.Add(this.pictureBoxOrdered);
            this.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormCustomer";
            this.Text = "客顯";
            this.Load += new System.EventHandler(this.FormCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrdered)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvCustomer;
        private System.Windows.Forms.ColumnHeader columnHeader品名;
        private System.Windows.Forms.ColumnHeader columnHeader量;
        private System.Windows.Forms.ColumnHeader columnHeader金額;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.PictureBox pictureBoxOrdered;
        private MyControlLibrary.MyImgControl myImgControl1;
    }
}