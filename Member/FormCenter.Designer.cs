namespace Member
{
    partial class FormCenter
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.会员卡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.会员卡类别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.会员卡ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.门店设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.会员卡ToolStripMenuItem,
            this.门店设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(802, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 会员卡ToolStripMenuItem
            // 
            this.会员卡ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.会员卡类别ToolStripMenuItem,
            this.会员卡ToolStripMenuItem1});
            this.会员卡ToolStripMenuItem.Name = "会员卡ToolStripMenuItem";
            this.会员卡ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.会员卡ToolStripMenuItem.Text = "会员卡";
            // 
            // 会员卡类别ToolStripMenuItem
            // 
            this.会员卡类别ToolStripMenuItem.Name = "会员卡类别ToolStripMenuItem";
            this.会员卡类别ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.会员卡类别ToolStripMenuItem.Text = "会员卡类别";
            this.会员卡类别ToolStripMenuItem.Click += new System.EventHandler(this.会员卡类别ToolStripMenuItem_Click);
            // 
            // 会员卡ToolStripMenuItem1
            // 
            this.会员卡ToolStripMenuItem1.Name = "会员卡ToolStripMenuItem1";
            this.会员卡ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.会员卡ToolStripMenuItem1.Text = " 会员卡";
            this.会员卡ToolStripMenuItem1.Click += new System.EventHandler(this.会员卡ToolStripMenuItem1_Click);
            // 
            // 门店设置ToolStripMenuItem
            // 
            this.门店设置ToolStripMenuItem.Name = "门店设置ToolStripMenuItem";
            this.门店设置ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.门店设置ToolStripMenuItem.Text = "门店设置";
            this.门店设置ToolStripMenuItem.Click += new System.EventHandler(this.门店设置ToolStripMenuItem_Click);
            // 
            // FormCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 474);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormCenter";
            this.Text = "FormCenter";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 会员卡ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 会员卡类别ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 会员卡ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 门店设置ToolStripMenuItem;
    }
}