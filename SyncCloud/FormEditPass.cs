using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SyncCloud
{
    public partial class FormEditPass : Form
    {
        public FormEditPass()
        {
            InitializeComponent();
        }

        XmlConfig m_Cfg = new XmlConfig();
        private void FormEditPass_Load(object sender, EventArgs e)
        {
            m_Cfg.Load();
            tbxPassword.Text      = m_Cfg.Password;
            tbxLocalServer.Text   = m_Cfg.LocalServer;
            tbxLocalDb.Text       = m_Cfg.LocalDatabase;
            tbxLocalUserId.Text   = m_Cfg.LocalUserId;
            tbxLocalPassword.Text = m_Cfg.LocalPassword;
            tbxCloudServer.Text   = m_Cfg.CloudServer;
            tbxCloudDb.Text       = m_Cfg.CloudDatabase;
            tbxCloudUserId.Text   = m_Cfg.CloudUserId;
            tbxCloudPassword.Text = m_Cfg.CloudPassword;
           
        }

        private void btnGetLocalName_Click(object sender, EventArgs e)
        {
            this.tbxLocalServer.Text = System.Net.Dns.GetHostName();
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            m_Cfg.Password      = tbxPassword.Text.Trim(); 
            m_Cfg.LocalServer   = tbxLocalServer.Text.Trim();
            m_Cfg.LocalDatabase = tbxLocalDb.Text.Trim();
            m_Cfg.LocalUserId   = tbxLocalUserId.Text.Trim();
            m_Cfg.LocalPassword = tbxLocalPassword.Text.Trim();
            m_Cfg.CloudServer   = tbxCloudServer.Text.Trim();
            m_Cfg.CloudDatabase = tbxCloudDb.Text.Trim();
            m_Cfg.CloudUserId   = tbxCloudUserId.Text.Trim();
            m_Cfg.CloudPassword = tbxCloudPassword.Text.Trim();
            m_Cfg.Save();
        }

        string SqlConnectString(string address, string database, string userID, string password)
        {
            return "Data Source=" + address + ";Initial Catalog=" + database
                   + ";Persist Security Info=True;User ID=" + userID + ";Password=" + password;
        }

        private void btnTestLocal_Click(object sender, EventArgs e)
        {
            string connStr = SqlConnectString(tbxLocalServer.Text.Trim(), tbxLocalDb.Text.Trim()
                                            , tbxLocalUserId.Text.Trim(), tbxLocalPassword.Text.Trim());
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
            string connStr = SqlConnectString(tbxCloudServer.Text.Trim(), tbxCloudDb.Text.Trim()
                                , tbxCloudUserId.Text.Trim(), tbxCloudPassword.Text.Trim());
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
