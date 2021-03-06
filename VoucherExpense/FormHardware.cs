﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
#if UseSQLServer
using MyVEHeaderAdapter = VoucherExpense.DamaiDataSetTableAdapters.VEHeaderTableAdapter;
using MyVEHeaderTable = VoucherExpense.DamaiDataSet.VEHeaderDataTable;
using System.Data.SqlClient;
#else
using MyVEHeaderAdapter = VoucherExpense.VEDataSetTableAdapters.HeaderTableAdapter;
using MyVEHeaderTable = VoucherExpense.VEDataSet.HeaderDataTable;
#endif
namespace VoucherExpense
{
    public partial class FormHardware : Form
    {
        HardwareConfig Config;
        public FormHardware()
        {
            InitializeComponent();
            Config = MyFunction.HardwareCfg;
        }



        private void btnFindDotPrinter_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
                textBoxDotPrinter.Text = printDialog1.PrinterSettings.PrinterName;
        }


        //void SetIsServer(bool notServer)
        //{
        //    textBoxDataDir.Enabled = notServer;
        //    textBoxUserName.Enabled = textBoxPassword.Enabled = notServer;
        //    labelShareName.Enabled = notServer;
        //    labelUser.Enabled = labelPass.Enabled = notServer;
        //}

        private void ckBoxIsServer_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            //SetIsServer(!box.Checked);
        }

        MyVEHeaderTable m_VEHeader = new MyVEHeaderTable();
        MyVEHeaderAdapter VEHeaderAdapter = new MyVEHeaderAdapter();
        private void FormHardware_Load(object sender, EventArgs e)
        {
            try
            {
#if UseSQLServer
                VEHeaderAdapter.Fill(m_VEHeader);
                labelDataBase.Text = "資料庫為MsSQL";
#else
                VEHeaderAdapter.Connection =    MapPath.VEConnection;
                VEHeaderAdapter.Fill(m_VEHeader);
                labelDataBase.Text = "資料庫為Access";
#endif
            }
            catch (Exception ex)
            {
                MessageBox.Show("程式錯誤!:" + ex.Message);
            }
//            Config.Load();
            textBoxProfileName.Text = Config.ProfileName;
            //textBoxPrinter.Text     = Config.PrinterName;
            textBoxDotPrinter.Text  = Config.DotPrinterName;
            ckBoxIsServer.Checked   = Config.IsServer;
            //cbBoxRS232.Text = Config.ComPortName;
            //textBoxDataDir.Text = Config.DataDir;
            //textBoxUserName.Text    = Config.UserName;
            //textBoxPassword.Text    = Config.Password;
            //textBoxBackupDir.Text   = Config.BackupDir;

            textBoxSqlServerIP.Text = Config.Local.ServerIP;
            textBoxSqlUserID.Text   = Config.Local.UserID;
            textBoxSqlPassword.Text = Config.Local.Password;

            chBoxCloudSync.Checked      = Config.EnableCloudSync;
            textBoxSqlDatabase.Text     = Config.Database;
            textBoxSharedDatabase.Text  = Config.SharedDatabase;

            textBoxSqlServerIPCloud.Text = Config.Cloud.ServerIP;
            textBoxSqlUserIDCloud.Text   = Config.Cloud.UserID;
            textBoxSqlPasswordCloud.Text = Config.Cloud.Password;
            

            labelProgramVersion.Text = "程式版本 "+Application.ProductVersion.ToString();
            labelRequiredVersion.Text = "要求版本 " + GetVersion();

        }

        string GetVersion()
        {
            if (m_VEHeader.Count > 0)
            {
                var header = m_VEHeader[0];
                if (!header.IsVersionNull())
                    return header.Version.Trim();
            }
            return "未註明";
        }

 
        private void btnSaveSql_Click(object sender, EventArgs e)
        {
            Config.ProfileName    = textBoxProfileName.Text.Trim();

            Config.DotPrinterName = textBoxDotPrinter.Text.Trim();
            Config.IsServer = ckBoxIsServer.Checked;
            Config.Database       = textBoxSqlDatabase.Text.Trim();
            Config.SharedDatabase = textBoxSharedDatabase.Text.Trim();

            Config.Local.ServerIP = textBoxSqlServerIP.Text.Trim();
            Config.Local.UserID   = textBoxSqlUserID.Text.Trim();
            Config.Local.Password = textBoxSqlPassword.Text.Trim();

            Config.EnableCloudSync  = chBoxCloudSync.Checked;
            Config.Cloud.ServerIP   = textBoxSqlServerIPCloud.Text.Trim();
            Config.Cloud.UserID     = textBoxSqlUserIDCloud.Text.Trim();
            Config.Cloud.Password   = textBoxSqlPasswordCloud.Text.Trim();
            Config.Save();
            MessageBox.Show("SQL設定存檔完成! 重新啟動程式後, 設定方生效.");
        }



 


        private void btnUpdateRequiedVersion_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_VEHeader.Count<=0) return;
                var header = m_VEHeader[0];
                if (!header.IsVersionNull() && header.Version.Trim() == Application.ProductVersion.Trim())
                {
                    MessageBox.Show("版本号相同不需更換!");
                    return;
                }
                string ver = Application.ProductVersion.Trim();
#if UseSQLServer
                string fullDest = Path.GetFullPath(Application.ExecutablePath).ToLower();
                byte[] zipped=null;
                byte[] md5 = null;
                
                if (MyFunction.CompressFileToBuf(fullDest, out zipped,out md5))
                {
                    var programAdapter = new VoucherExpense.DamaiDataSetTableAdapters.ProgramTableAdapter();
                    var cmd = new System.Data.SqlClient.SqlCommand("DELETE FROM [dbo].[Program] WHERE 1=1");
                    cmd.Connection = programAdapter.Connection;
                    programAdapter.Connection.Open();
                    cmd.ExecuteNonQuery();
                    var table = new VoucherExpense.DamaiDataSet.ProgramDataTable();
                    var programRow = table.NewProgramRow();
                    programRow.ID = Guid.NewGuid();
                    programRow.ProgramVersion = ver;
                    programRow.UpdatedTime = DateTime.Now;
                    programRow.ZippedImage = zipped;
                    programRow.MD5 = md5;
                    table.AddProgramRow(programRow);
                    labelRequiredVersion.Text = ver+" 正在上傳";
                    Application.DoEvents();
                    programAdapter.Update(table);    
                    programAdapter.Connection.Dispose();
                }
#endif 
                header.Version = ver;
                VEHeaderAdapter.Update(m_VEHeader);
                labelRequiredVersion.Text = "要求版本 " + header.Version;
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤:" + ex.Message);
            }
        }

        private void btnTestLocal_Click(object sender, EventArgs e)
        {
            string connStr = DB.SqlConnectString(textBoxSqlServerIP.Text.Trim(), textBoxSqlDatabase.Text.Trim()
                                , textBoxSqlUserID.Text.Trim(), textBoxSqlPassword.Text.Trim());
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("本地資料庫連線 失敗,原因:" + ex.Message);
                return;
            }
            conn.Close();
            MessageBox.Show("本地資料庫 連線成功!");
        }

        private void btnTestCloud_Click(object sender, EventArgs e)
        {
                        string connStr = DB.SqlConnectString(textBoxSqlServerIPCloud.Text.Trim(), textBoxSqlDatabase.Text.Trim()
                                , textBoxSqlUserIDCloud.Text.Trim(), textBoxSqlPasswordCloud.Text.Trim());
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("雲端資料庫連線 失敗,原因:" + ex.Message);
                return;
            }
            conn.Close();
            MessageBox.Show("雲端資料庫 連線成功!");
        }
    }
}
