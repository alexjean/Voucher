namespace SyncCloud
{
    partial class FormSync
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxMessage = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItemBeginSync = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemModifyPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemClearScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuItemClearLocalMemory = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemClearCloudMemory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxMessage
            // 
            this.listBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxMessage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxMessage.FormattingEnabled = true;
            this.listBoxMessage.HorizontalScrollbar = true;
            this.listBoxMessage.ItemHeight = 18;
            this.listBoxMessage.Location = new System.Drawing.Point(0, 28);
            this.listBoxMessage.Name = "listBoxMessage";
            this.listBoxMessage.Size = new System.Drawing.Size(826, 652);
            this.listBoxMessage.TabIndex = 2;
            this.listBoxMessage.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxMessage_DrawItem);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemBeginSync,
            this.menuItemModifyPassword,
            this.MenuItemClearScreen,
            this.MenuItemClearLocalMemory,
            this.MenuItemClearCloudMemory});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(828, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuItemBeginSync
            // 
            this.menuItemBeginSync.Name = "menuItemBeginSync";
            this.menuItemBeginSync.Size = new System.Drawing.Size(85, 24);
            this.menuItemBeginSync.Text = "開始同步";
            this.menuItemBeginSync.Click += new System.EventHandler(this.menuItemBeginSync_Click);
            // 
            // menuItemModifyPassword
            // 
            this.menuItemModifyPassword.Name = "menuItemModifyPassword";
            this.menuItemModifyPassword.Size = new System.Drawing.Size(85, 24);
            this.menuItemModifyPassword.Text = "修改帳密";
            this.menuItemModifyPassword.Click += new System.EventHandler(this.menuItemModifyPassword_Click);
            // 
            // MenuItemClearScreen
            // 
            this.MenuItemClearScreen.Name = "MenuItemClearScreen";
            this.MenuItemClearScreen.Size = new System.Drawing.Size(85, 24);
            this.MenuItemClearScreen.Text = "清除畫面";
            this.MenuItemClearScreen.Click += new System.EventHandler(this.MenuItemClearScreen_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 683);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(828, 25);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelStatus
            // 
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(41, 20);
            this.labelStatus.Text = "狀態";
            // 
            // MenuItemClearLocalMemory
            // 
            this.MenuItemClearLocalMemory.Name = "MenuItemClearLocalMemory";
            this.MenuItemClearLocalMemory.Size = new System.Drawing.Size(117, 24);
            this.MenuItemClearLocalMemory.Text = "清除本地記憶";
            this.MenuItemClearLocalMemory.Click += new System.EventHandler(this.MenuItemClearLocalMemory_Click);
            // 
            // MenuItemClearCloudMemory
            // 
            this.MenuItemClearCloudMemory.Name = "MenuItemClearCloudMemory";
            this.MenuItemClearCloudMemory.Size = new System.Drawing.Size(117, 24);
            this.MenuItemClearCloudMemory.Text = "清除雲端記憶";
            this.MenuItemClearCloudMemory.Click += new System.EventHandler(this.MenuItemClearCloudMemory_Click);
            // 
            // FormSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 708);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listBoxMessage);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormSync";
            this.Text = "雲端資料庫同步器";
            this.Load += new System.EventHandler(this.FormSync_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxMessage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemBeginSync;
        private System.Windows.Forms.ToolStripMenuItem menuItemModifyPassword;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
        private System.Windows.Forms.ToolStripMenuItem MenuItemClearScreen;
        private System.Windows.Forms.ToolStripMenuItem MenuItemClearLocalMemory;
        private System.Windows.Forms.ToolStripMenuItem MenuItemClearCloudMemory;
    }
}

