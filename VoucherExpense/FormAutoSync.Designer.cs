namespace VoucherExpense
{
    partial class FormAutoSync
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
            System.Windows.Forms.Label labelTime;
            this.btnExit = new System.Windows.Forms.Button();
            this.listBoxMessage = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnStartSync = new System.Windows.Forms.Button();
            this.btnClearLocalMemory = new System.Windows.Forms.Button();
            this.btnClearCloundMemory = new System.Windows.Forms.Button();
            this.todayPicker = new System.Windows.Forms.DateTimePicker();
            this.btnClearMessage = new System.Windows.Forms.Button();
            labelTime = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTime
            // 
            labelTime.Location = new System.Drawing.Point(642, 217);
            labelTime.Name = "labelTime";
            labelTime.Size = new System.Drawing.Size(56, 30);
            labelTime.TabIndex = 29;
            labelTime.Text = "今日是";
            labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(694, 471);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 36);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "離開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnExit_KeyPress);
            // 
            // listBoxMessage
            // 
            this.listBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxMessage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxMessage.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxMessage.FormattingEnabled = true;
            this.listBoxMessage.ItemHeight = 18;
            this.listBoxMessage.Location = new System.Drawing.Point(0, 1);
            this.listBoxMessage.Name = "listBoxMessage";
            this.listBoxMessage.Size = new System.Drawing.Size(616, 544);
            this.listBoxMessage.TabIndex = 0;
            this.listBoxMessage.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxMessage_DrawItem);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 550);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(897, 25);
            this.statusStrip1.TabIndex = 24;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelStatus
            // 
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(41, 20);
            this.labelStatus.Text = "狀態";
            // 
            // btnStartSync
            // 
            this.btnStartSync.Location = new System.Drawing.Point(694, 399);
            this.btnStartSync.Name = "btnStartSync";
            this.btnStartSync.Size = new System.Drawing.Size(80, 36);
            this.btnStartSync.TabIndex = 25;
            this.btnStartSync.Text = "開始";
            this.btnStartSync.UseVisualStyleBackColor = true;
            this.btnStartSync.Click += new System.EventHandler(this.btnStartSync_Click);
            // 
            // btnClearLocalMemory
            // 
            this.btnClearLocalMemory.Location = new System.Drawing.Point(667, 275);
            this.btnClearLocalMemory.Name = "btnClearLocalMemory";
            this.btnClearLocalMemory.Size = new System.Drawing.Size(129, 36);
            this.btnClearLocalMemory.TabIndex = 26;
            this.btnClearLocalMemory.Text = "清除本地記憶";
            this.btnClearLocalMemory.UseVisualStyleBackColor = true;
            this.btnClearLocalMemory.Visible = false;
            this.btnClearLocalMemory.Click += new System.EventHandler(this.btnClearLocalMemory_Click);
            // 
            // btnClearCloundMemory
            // 
            this.btnClearCloundMemory.Location = new System.Drawing.Point(667, 334);
            this.btnClearCloundMemory.Name = "btnClearCloundMemory";
            this.btnClearCloundMemory.Size = new System.Drawing.Size(129, 36);
            this.btnClearCloundMemory.TabIndex = 27;
            this.btnClearCloundMemory.Text = "清除雲端記憶";
            this.btnClearCloundMemory.UseVisualStyleBackColor = true;
            this.btnClearCloundMemory.Visible = false;
            this.btnClearCloundMemory.Click += new System.EventHandler(this.btnClearCloundMemory_Click);
            // 
            // todayPicker
            // 
            this.todayPicker.Enabled = false;
            this.todayPicker.Location = new System.Drawing.Point(704, 219);
            this.todayPicker.Name = "todayPicker";
            this.todayPicker.Size = new System.Drawing.Size(146, 27);
            this.todayPicker.TabIndex = 30;
            // 
            // btnClearMessage
            // 
            this.btnClearMessage.Location = new System.Drawing.Point(805, 399);
            this.btnClearMessage.Name = "btnClearMessage";
            this.btnClearMessage.Size = new System.Drawing.Size(80, 36);
            this.btnClearMessage.TabIndex = 31;
            this.btnClearMessage.Text = "清除畫面";
            this.btnClearMessage.UseVisualStyleBackColor = true;
            this.btnClearMessage.Click += new System.EventHandler(this.btnClearMessage_Click);
            // 
            // FormAutoSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 575);
            this.Controls.Add(this.btnClearMessage);
            this.Controls.Add(this.todayPicker);
            this.Controls.Add(labelTime);
            this.Controls.Add(this.btnClearCloundMemory);
            this.Controls.Add(this.btnClearLocalMemory);
            this.Controls.Add(this.listBoxMessage);
            this.Controls.Add(this.btnStartSync);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAutoSync";
            this.Text = "自動同步";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAutoSync_FormClosing);
            this.Load += new System.EventHandler(this.FormAutoSync_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox listBoxMessage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
        private System.Windows.Forms.Button btnStartSync;
        private System.Windows.Forms.Button btnClearLocalMemory;
        private System.Windows.Forms.Button btnClearCloundMemory;
        private System.Windows.Forms.DateTimePicker todayPicker;
        private System.Windows.Forms.Button btnClearMessage;
    }
}