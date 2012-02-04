using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VoucherExpense
{
    public partial class FormLogin : Form
    {
        HardwareConfig m_Cfg = new HardwareConfig();
        MapPath m_MapPath;
        public FormLogin()
        {
            InitializeComponent();
            ShowLogin(false);
            m_Cfg.Load();
            if (!m_Cfg.IsServer)
                MapPath.DeleteAllMapDriver();  // 因為一台機器,你只能用一個UserName login,ShareDocs可能用guest己經login
            m_MapPath = new MapPath(timer1, progressBar1,m_Cfg);
        }

        private void ShowLogin(bool Yes)
        {
            pictureBox1.Visible     = !Yes;
            textBoxUserID.Visible   = Yes;
            textBoxPassword.Visible = Yes;
            labelPassword.Visible   = Yes;
            labelUserID.Visible     = Yes;
            btnLogin.Visible        = Yes;
            groupBox1.Visible       = Yes;
        }

        int ErrorCount;
        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int Left=125,Right=150,Top=45,Bottom=60;
            //  int Left = 125, Right = 150, Top = 80, Bottom = 100;
            if (e.X < Left) return;
            if (e.X > Right) return;
            if (e.Y < Top) return;
            if (e.Y > Bottom) return;
            ShowLogin(true);
            ReadTable();
            ErrorCount = 0;
            textBoxUserID.Focus();
        }

        private void ReadTable()
        {
            // 把 Net Use * /Delete /Yes 分開是因為 WinExec有執行時間, 太快回來,會Map先好, 又被Delete
            if (!m_Cfg.IsServer)
            {
                btnLogin.Enabled = false;
                m_MapPath.DoWaitUpdateProgressBar();
                btnLogin.Enabled = true;
            }
            operatorTableAdapter1.Connection =  MapPath.VEConnection;
            headerTableAdapter1.Connection =    MapPath.VEConnection;
            try
            {
                operatorTableAdapter1.Fill(veDataSet1.Operator);
                headerTableAdapter1.Fill(veDataSet1.Header);
            }
            catch(Exception ex)
            {
                MessageBox.Show("操作員資料庫讀取錯誤<"+ex.Message+">!  無法登入");
                Close();
            }
            if (veDataSet1.Operator.Rows.Count == 0)
            {
                MessageBox.Show("資料庫內沒有設定任何操作員,無法登入");
                Close();
            }
        }



        private VEDataSet.OperatorRow CheckLogin()
        {
            return CheckLogin(textBoxUserID.Text.Trim(), textBoxPassword.Text.Trim());
        }

        private VEDataSet.OperatorRow CheckLogin(string UserID,string Password)
        {
            if (UserID.Length == 0)
            {
                MessageBox.Show("請輸入帳號");
                return null;
            }
            if (Password.Length == 0)
            {
                MessageBox.Show("請輸入密碼");
                return null;
            }
            foreach (VEDataSet.OperatorRow r in veDataSet1.Operator.Rows)
            {
                if (r.LoginName.CompareTo(UserID) == 0)
                {
                    if (r.Password.CompareTo(Password) == 0)
                    {
                        if (r.StopAccount)
                        {
                            MessageBox.Show("此帳號己經停用!");
                            return null;
                        }
                        return r;
                    }
                    else
                    {
                        MessageBox.Show("密碼錯誤!");
                        return null;
                    }
                }
            }
            MessageBox.Show("無此帳號!");
            return null;
        }

        void GetHeaderYear()
        {
            if (veDataSet1.Header.Rows.Count > 0)   // Header內容在ReadFile 讀進來了
            {
                VEDataSet.HeaderRow headerRow = (VEDataSet.HeaderRow)veDataSet1.Header.Rows[0];
                if (headerRow != null)
                {
                    string str;
                    str = headerRow.DataYear.Year.ToString().Trim();
                    if (str != "") MyFunction.HeaderYear = str;
                    MyFunction.IntHeaderYear = headerRow.DataYear.Year;
                    MyFunction.LockAll = headerRow.Closed;
                    MyFunction.IntHeaderMonth = headerRow.DataYear.Month;
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            VEDataSet.OperatorRow row = CheckLogin();
            if (row!=null)
            {
                GetHeaderYear();                // 呼叫Home之前要設好
                Visible = false;
                Form Home = new FormHome(row,m_Cfg);
                Home.ShowDialog();
                Close();
            }
            else if (ErrorCount++ > 5)
            {
                MessageBox.Show("錯誤次數過多! Bye!");
                Close();
            }
        }

        private void FormLogin_Shown(object sender, EventArgs e)
        {
#if DEBUG
            if (!m_Cfg.IsServer) 
                System.Threading.Thread.Sleep(250);   // 給 WinExec一點時間,執行完 Net Use * /Delete /Yes
            ShowLogin(true);
            ReadTable();
            VEDataSet.OperatorRow row = CheckLogin("alexjean", "loveyou");
            if (row != null)
            {
                GetHeaderYear();
                Form Home = new FormHome(row, m_Cfg);
                Visible = false;
                Home.ShowDialog();
                Close();
            }
#endif
        }

 
    }
}