using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace VoucherExpense
{
    public partial class FormHardware : Form
    {
        public FormHardware()
        {
            InitializeComponent();
        }

        private void btnFindPrinter_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog()==DialogResult.OK)
                textBoxPrinter.Text=printDialog1.PrinterSettings.PrinterName;
        }

        void SetIsServer(bool notServer)
        {
            textBoxDataDir.Enabled = notServer;
            textBoxUserName.Enabled = textBoxPassword.Enabled = notServer;
            labelShareName.Enabled = notServer;
            labelUser.Enabled = labelPass.Enabled = notServer;
        }

        private void ckBoxIsServer_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            SetIsServer(!box.Checked);
        }

        HardwareConfig Config = new HardwareConfig();
        
        private void FormHardware_Load(object sender, EventArgs e)
        {
            Config.Load();
            cbBoxRS232.Text       = Config.ComPortName;
            textBoxPrinter.Text   = Config.PrinterName;
            ckBoxIsServer.Checked = Config.IsServer;
            textBoxDataDir.Text = Config.DataDir;
            textBoxUserName.Text  = Config.UserName;
            textBoxPassword.Text  = Config.Password;
            textBoxBackupDir.Text = Config.BackupDir;
            labelProgramVersion.Text = "程式版本 "+Application.ProductVersion.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Config.ComPortName= cbBoxRS232.Text;
            Config.PrinterName= textBoxPrinter.Text;
            Config.IsServer   = ckBoxIsServer.Checked;
            Config.DataDir    = textBoxDataDir.Text.Trim();
            Config.UserName   = textBoxUserName.Text.Trim();
            Config.Password   = textBoxPassword.Text.Trim();
            Config.BackupDir  = textBoxBackupDir.Text.Trim();
            Config.Save();
            MessageBox.Show("存檔完成! 重新啟動程式後, 設定方生效.");
        }


        private void btnFolerBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK) return;
            this.textBoxBackupDir.Text=folderBrowserDialog1.SelectedPath;
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            BackupData.DoBackup(Config);
        }

        private void textBoxPrinter_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
 
    }
}
