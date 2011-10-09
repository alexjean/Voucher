namespace VoucherExpense
{
    partial class FormHardware
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbBoxRS232 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPrinter = new System.Windows.Forms.TextBox();
            this.btnFindPrinter = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ckBoxIsServer = new System.Windows.Forms.CheckBox();
            this.textBoxDataDir = new System.Windows.Forms.TextBox();
            this.labelShareName = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.textBoxBackupDir = new System.Windows.Forms.TextBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnFolerBrowse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "",
            "            XP資料庫目錄共享設定 (以 \\Voucher 為例)",
            "",
            " 1 主機一定要是XP Professional , NTFS格式. Home Edition不行",
            "",
            " 2 網路上的芳鄰=>設定家用或小型辦公室網路=> ．．．=>．．． ",
            "    要確認 開啟檔案與印表機共用,  一路繼續到完成",
            "",
            " 3 控制台=>Windows防火牆，檢查 例外 \"檔案與印表機共用\" 己經勾起",
            "",
            " 4 工具=>資料夾選項=>檢視=>使用簡易檔案共用   勾勾拿掉",
            "    (Win7   資料夾選項=>檢視=>使用共用精靈    取消掉)",
            "",
            " 5 我的電腦 按右鍵=>管理=>本機使用者和群組=>使用者 按右鍵=>",
            "    新使用者.    在該機器上建立一個帳號 ( 例 remote  密碼為 password) ,",
            "    只勾 \"使用者不能變更密碼\" 及 \"密碼永久有效\"",
            "    remote的 內容=>成員隸屬=>移除=> users , 避免出現在登入畫面",
            "",
            " 6 在 \\Voucher的目錄  滑鼠右鍵=>共用和安全性=> 安全性=>",
            "    新增 => remote 權限為完全控制",
            "",
            " 7 共用=>共用此資料夾   <名稱> 尾巴加$以便隱形 (例  Voucher1$)",
            "    =>使用權限 移除everyone ,加入 remote 打開所有權限",
            "",
            "8 資料主機的 ShareDocs=>使用權限 移除everyone ,加入 remote 打開所有權限",
            "   請勿分享其他文件夾, 以避免其他機器以 anonymous 登入.  "});
            this.listBox1.Location = new System.Drawing.Point(344, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(536, 436);
            this.listBox1.TabIndex = 0;
            this.listBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "收機机串口";
            // 
            // cbBoxRS232
            // 
            this.cbBoxRS232.FormattingEnabled = true;
            this.cbBoxRS232.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8"});
            this.cbBoxRS232.Location = new System.Drawing.Point(147, 105);
            this.cbBoxRS232.Name = "cbBoxRS232";
            this.cbBoxRS232.Size = new System.Drawing.Size(111, 24);
            this.cbBoxRS232.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "小票机名稱";
            // 
            // textBoxPrinter
            // 
            this.textBoxPrinter.Location = new System.Drawing.Point(36, 171);
            this.textBoxPrinter.Name = "textBoxPrinter";
            this.textBoxPrinter.Size = new System.Drawing.Size(277, 27);
            this.textBoxPrinter.TabIndex = 6;
            // 
            // btnFindPrinter
            // 
            this.btnFindPrinter.Location = new System.Drawing.Point(147, 144);
            this.btnFindPrinter.Name = "btnFindPrinter";
            this.btnFindPrinter.Size = new System.Drawing.Size(111, 26);
            this.btnFindPrinter.TabIndex = 5;
            this.btnFindPrinter.Text = "找印表机";
            this.btnFindPrinter.UseVisualStyleBackColor = true;
            this.btnFindPrinter.Click += new System.EventHandler(this.btnFindPrinter_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "本處所設資料存於 HardwareCfg.xml";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "每台机器需單獨設定";
            // 
            // ckBoxIsServer
            // 
            this.ckBoxIsServer.AutoSize = true;
            this.ckBoxIsServer.Location = new System.Drawing.Point(36, 252);
            this.ckBoxIsServer.Name = "ckBoxIsServer";
            this.ckBoxIsServer.Size = new System.Drawing.Size(221, 20);
            this.ckBoxIsServer.TabIndex = 0;
            this.ckBoxIsServer.Text = "我是主機  (資料庫位於本機)";
            this.ckBoxIsServer.UseVisualStyleBackColor = true;
            this.ckBoxIsServer.CheckedChanged += new System.EventHandler(this.ckBoxIsServer_CheckedChanged);
            // 
            // textBoxDataDir
            // 
            this.textBoxDataDir.Location = new System.Drawing.Point(36, 308);
            this.textBoxDataDir.Name = "textBoxDataDir";
            this.textBoxDataDir.Size = new System.Drawing.Size(277, 27);
            this.textBoxDataDir.TabIndex = 1;
            // 
            // labelShareName
            // 
            this.labelShareName.AutoSize = true;
            this.labelShareName.Location = new System.Drawing.Point(36, 289);
            this.labelShareName.Name = "labelShareName";
            this.labelShareName.Size = new System.Drawing.Size(216, 16);
            this.labelShareName.TabIndex = 7;
            this.labelShareName.Text = "資料庫目錄     \\\\主机名\\共享名";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(36, 359);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(40, 16);
            this.labelUser.TabIndex = 12;
            this.labelUser.Text = "帳號";
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(36, 392);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(40, 16);
            this.labelPass.TabIndex = 13;
            this.labelPass.Text = "密碼";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(82, 354);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(231, 27);
            this.textBoxUserName.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(82, 387);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(231, 27);
            this.textBoxPassword.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(147, 459);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "存檔";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textBoxBackupDir
            // 
            this.textBoxBackupDir.Location = new System.Drawing.Point(446, 459);
            this.textBoxBackupDir.Name = "textBoxBackupDir";
            this.textBoxBackupDir.Size = new System.Drawing.Size(425, 27);
            this.textBoxBackupDir.TabIndex = 14;
            // 
            // btnBackup
            // 
            this.btnBackup.AutoSize = true;
            this.btnBackup.Location = new System.Drawing.Point(566, 501);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(98, 26);
            this.btnBackup.TabIndex = 16;
            this.btnBackup.Text = "備份資料庫";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnFolerBrowse
            // 
            this.btnFolerBrowse.Location = new System.Drawing.Point(344, 459);
            this.btnFolerBrowse.Name = "btnFolerBrowse";
            this.btnFolerBrowse.Size = new System.Drawing.Size(93, 23);
            this.btnFolerBrowse.TabIndex = 17;
            this.btnFolerBrowse.Text = "備份位置";
            this.btnFolerBrowse.UseVisualStyleBackColor = true;
            this.btnFolerBrowse.Click += new System.EventHandler(this.btnFolerBrowse_Click);
            // 
            // FormHardware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(892, 565);
            this.Controls.Add(this.btnFolerBrowse);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.textBoxBackupDir);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.labelShareName);
            this.Controls.Add(this.textBoxDataDir);
            this.Controls.Add(this.ckBoxIsServer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFindPrinter);
            this.Controls.Add(this.textBoxPrinter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbBoxRS232);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormHardware";
            this.Text = "硬體環境設定";
            this.Load += new System.EventHandler(this.FormHardware_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBoxRS232;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPrinter;
        private System.Windows.Forms.Button btnFindPrinter;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ckBoxIsServer;
        private System.Windows.Forms.TextBox textBoxDataDir;
        private System.Windows.Forms.Label labelShareName;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBoxBackupDir;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnFolerBrowse;
    }
}