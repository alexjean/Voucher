using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data.SqlClient;

namespace VoucherExpense
{
    class MapPath
    {
        #region OleDB Connection
        static public OleDbConnection VEConnection = new OleDbConnection(global::VoucherExpense.Properties.Settings.Default.VoucherExpenseConnectionString);
        static public OleDbConnection BasicConnection = new OleDbConnection(global::VoucherExpense.Properties.Settings.Default.BasicDataConnectionString);
        static public OleDbConnection BakeryConnection = new OleDbConnection(global::VoucherExpense.Properties.Settings.Default.BakeryOrderConnectionString);    // 己在Program.cs設定
        const string HeadStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
        const string TailStr = ";Persist Security Info=True;Jet OLEDB:Database Password=";

        static public SqlConnection DamaiSQLConnection = new SqlConnection(global::VoucherExpense.Properties.Settings.Default.DamaiConnectionString);

        static public string VoucherPass = "CalcVoucher";
        static public string BasicPass  = "love";
        static public string BakeryPass = "love";
        static private string _dataDir = "";     // 有資料時尾巴帶 \
        static public string DataDir { get { return _dataDir; } }
        static public string ConnectString(string path, string password)
        {
            return HeadStr + path + TailStr + password; 
        }
        static public void SetVEConnectionString(string path, string password)
        {
            VEConnection.ConnectionString = HeadStr + path + TailStr + password;
        }

        static public void SetBasicConnectionString(string path, string password)
        {
            BasicConnection.ConnectionString = HeadStr + path + TailStr + password;
        }

        static public void SetBakeryConnectionString(string path, string password)
        {
            BakeryConnection.ConnectionString = HeadStr + path + TailStr + password;
        }

        static public void SetDamaiConnectionString(string address, string database, string userID,string password)
        {
            DamaiSQLConnection.ConnectionString="Data Source=" + address + ";Initial Catalog=" + database 
                              + ";Persist Security Info=True;User ID=" + userID + ";Password=" + password;
        }
        #endregion


        [DllImport("kernel32.dll")]
        public static extern int WinExec(string exeName, int operType);
        static public void DeleteAllMapDriver()
        {
            int SW_HIDE = 0;
            WinExec("NET USE * /DELETE /Y", SW_HIDE); 
        }

        // 因為Timer及ProgressBar都在User thread
        Timer timer1;
        ProgressBar progressBar1;
        HardwareConfig m_Cfg;
        BackgroundWorker backgroundWorker1;
        public bool Completed;
        public MapPath(Timer timer, ProgressBar progressBar,HardwareConfig cfg)
        {
            timer1=timer;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            progressBar1=progressBar;
            m_Cfg = cfg;
            Completed=false;
            backgroundWorker1=new BackgroundWorker();
            this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
        }

 //       BackgroundWorker backGroundWorker1;
        public void DoWaitUpdateProgressBar()
        {
                Completed=false;
                progressBar1.Visible = true;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 60;
                progressBar1.Step = 1;
                timer1.Interval = 1000;
                timer1.Start();
                Application.DoEvents();
                backgroundWorker1.RunWorkerAsync();
                while (!Completed)
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(20);
                }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
                progressBar1.Increment(1);
            else timer1.Stop();
        }


        #region BackgroundWorker
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            NetworkDrive net = new NetworkDrive();
            net.ShareName = m_Cfg.DataDir;
            e.Result = new int();
            e.Result = net.MapDrive(m_Cfg.UserName, m_Cfg.Password);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int result = (int)e.Result;
            if (result > 0)  // 要改成在Thread裏要不然沒法refresh ProgressBar
            {
                timer1.Stop();
                progressBar1.Visible = false;
                if (MessageBox.Show("無法連線 "+m_Cfg.MaskDataDir()+" 上的資料庫\r\n原因<" + SystemErrorMessage.Get((uint)result) + ">\r\n 無視錯誤使用本地資料繼續執行, 按Yes!", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    Application.Exit();
                m_Cfg.IsServer = true;
                _dataDir = "";
            }
            else
            {
                timer1.Stop();
                progressBar1.Visible = false;

                _dataDir = m_Cfg.DataDir + "\\";
                MapPath.SetVEConnectionString    (m_Cfg.DataDir + "\\" + "VoucherExpense.mdb", VoucherPass + "888");
                MapPath.SetBasicConnectionString (m_Cfg.DataDir + "\\" + "BasicData.mdb"     , BasicPass   + "you");
                MapPath.SetBakeryConnectionString(m_Cfg.DataDir + "\\" + "BakeryOrder.mdb"   , BasicPass   + "Bakery");
            }
            Completed = true;
        }
        #endregion



    }
}
