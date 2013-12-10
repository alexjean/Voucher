//#define UseSQLServer
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
    public partial class FormLogin : Form
    {
        HardwareConfig m_Cfg;
        MapPath m_MapPath;
        string m_BranchName="麥麥麥達人";
        public FormLogin()
        {
            string EncryptedPasword = "mpwfCblfsz";   // loveBakery
            string password = "";
            foreach (char c in EncryptedPasword) password += (char)(c - 1);
            global::VoucherExpense.Properties.Settings.Default.BakeryOrderConnectionString += password;

            HardwareConfig cfg = new HardwareConfig();
            cfg.Load();
            global::VoucherExpense.Properties.Settings.Default.SqlVeConnectionString =
                   "Data Source=" + cfg.SqlServerIP
                  + ";Initial Catalog=" + cfg.SqlDatabase
                  + ";Persist Security Info=True;User ID=" + cfg.SqlUserID
                  + ";Password=" + cfg.SqlPassword;

            global::VoucherExpense.Properties.Settings.Default.DamaiConnectionString =
                   "Data Source=" + cfg.SqlServerIP
                  + ";Initial Catalog=" + cfg.SqlDatabase
                  + ";Persist Security Info=True;User ID=" + cfg.SqlUserID
                  + ";Password=" + cfg.SqlPassword;

            m_Cfg = cfg;
            InitializeComponent();
            ShowLogin(false);
#if (!UseSQLServer)
            if (!cfg.IsServer)
                MapPath.DeleteAllMapDriver();  // 因為一台機器,你只能用一個UserName login,ShareDocs可能用guest己經login
            m_MapPath = new MapPath(timer1, progressBar1,cfg);
#endif
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

        void  CheckAppVersion(string sVersion)
        {
            if (sVersion != "")
            {
                bool requiredUpdate = false;
                Version now = new Version(Application.ProductVersion);
                try
                {
                    Version required = new Version(sVersion);
                    if (now < required) requiredUpdate = true;
                }
                catch { return; }     // 要求格式有誤, 不管了
                if (requiredUpdate)
                {
                    if (MessageBox.Show("程式版本低於要求! 現有版本<" + now.ToString() + ">,必需更版至<" + sVersion + ">!", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (DoUpdate()) Close();
                    }
                    else
                        MessageBox.Show("不更版可能產生錯誤, 請儘可能更版!");
                }
            }

        }

#if (UseSQLServer)
        COperator GetCOperator(DamaiDataSet.OperatorRow r) 
#else
        COperator GetCOperator(VEDataSet.OperatorRow r) 
#endif
        {
            COperator op = new COperator();
            op.EditAccountingTitle = r.EditAccountingTitle;
            op.EditBank = r.EditBank;
            op.EditEmployee = r.EditEmployee;
            op.EditExpense = r.EditExpense;
            op.EditIngredient = r.EditIngredient;
            op.EditInventory = r.EditInventory;
            op.EditOnDuty = r.EditOnDuty;
            op.EditOperator = r.EditOperator;
            op.EditProduct = r.EditProduct;
            op.EditRecipe = r.EditRecipe;
            op.EditSalary = r.EditSalary;
            op.EditShipment = r.EditShipment;
            op.EditVendor = r.EditVendor;
            op.EditVoucher = r.EditVoucher;
            op.IsManager = r.IsManager;
            op.IsSuper = r.IsSuper;
            op.LockAccVoucher = r.LockAccVoucher;
            op.LockExpense = r.LockExpense;
            op.LockHR = r.LockHR;
            op.LockInventory = r.LockInventory;
            op.LockShipment = r.LockShipment;
            op.LockVoucher = r.LockVoucher;
            op.LoginName = r.LoginName;
            if (r.IsNameNull())
                op.Name = "操作員" + r.OperatorID.ToString();   
            else 
                op.Name = r.Name;
            op.OperatorID = r.OperatorID;
            op.RevenueOperate = r.RevenueOperate;
            op.StopAccount = r.StopAccount;
            return op;
        }

#if (UseSQLServer)
        DamaiDataSetTableAdapters.OperatorTableAdapter operatorSQLAdapter;
        DamaiDataSetTableAdapters.VEHeaderTableAdapter headerSQLAdapter;
        DamaiDataSetTableAdapters.ApartmentTableAdapter apartmentSQLAdapter;
        DamaiDataSet damaiDataSet;
        private void ReadTable()
        {
            operatorSQLAdapter  = new DamaiDataSetTableAdapters.OperatorTableAdapter();
            headerSQLAdapter    = new DamaiDataSetTableAdapters.VEHeaderTableAdapter();
            apartmentSQLAdapter = new DamaiDataSetTableAdapters.ApartmentTableAdapter();
            damaiDataSet        = new DamaiDataSet();
            try
            {
                operatorSQLAdapter.Fill(damaiDataSet.Operator);
                headerSQLAdapter.Fill(damaiDataSet.VEHeader);
                apartmentSQLAdapter.Fill(damaiDataSet.Apartment);
            }
            catch(Exception ex)
            {
                MessageBox.Show("操作員資料庫讀取錯誤<"+ex.Message+">!  無法登入");
                Close();
            }
            if (damaiDataSet.Operator.Rows.Count == 0)
            {
                MessageBox.Show("資料庫內沒有設定任何操作員,無法登入");
                Close();
            }
            if (damaiDataSet.Apartment.Rows.Count != 0)
            {
                var a0 = damaiDataSet.Apartment[0];
                foreach (var a in damaiDataSet.Apartment)
                {
                    if (a.IsCurrent)  // SQL資料庫己規定Not NULL, 沒有IsCurrentNull()
                    {
                        a0 = a;
                        break;
                    }
                }
                if (a0.IsApartmentNameNull())
                    m_BranchName = "分店" + a0.ApartmentID.ToString();
                else
                    m_BranchName = a0.ApartmentName;
            }

            DamaiDataSet.VEHeaderRow header = null;
            string sVersion = "";
            if (damaiDataSet.VEHeader.Count > 0)
            {
                header = damaiDataSet.VEHeader[0];
                if (!header.IsVersionNull()) sVersion = header.Version.Trim();
            }
            CheckAppVersion(sVersion);
        }

        bool DoUpdate()
        {
            MessageBox.Show("SQL版自動更版施工中...");
            return false;
        }

        private COperator CheckLogin(string UserID, string Password) 
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
            foreach (var r in damaiDataSet.Operator)
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
                        return GetCOperator(r);
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
            if (damaiDataSet.VEHeader.Rows.Count > 0)   // Header內容在ReadFile 讀進來了
            {
                DamaiDataSet.VEHeaderRow headerRow = damaiDataSet.VEHeader[0];
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
#else
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
            apartmentTableAdapter1.Connection = MapPath.VEConnection;
            try
            {
                operatorTableAdapter1.Fill(veDataSet1.Operator);
                headerTableAdapter1.Fill(veDataSet1.Header);
                apartmentTableAdapter1.Fill(veDataSet1.Apartment);
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
            if (veDataSet1.Apartment.Rows.Count != 0)
            {
                var a0 = veDataSet1.Apartment[0];
                foreach (var a in veDataSet1.Apartment)
                {
                    if (!a.IsIsCurrentNull() && a.IsCurrent)
                    {
                        a0 = a;
                        break;
                    }
                }
                if (a0.IsApartmentNameNull())
                    m_BranchName = "分店" + a0.ApartmentID.ToString();
                else
                    m_BranchName = a0.ApartmentName;
            }

            VEDataSet.HeaderRow header = null;
            string sVersion = "";
            if (veDataSet1.Header.Count > 0)
            {
                header = veDataSet1.Header[0];
                if (!header.IsVersionNull()) sVersion = header.Version.Trim();
            }
            CheckAppVersion(sVersion);
        }


        bool DoUpdate()
        {
            if (m_Cfg.IsServer)
            {
                MessageBox.Show("只有遠端登入能自動更版!");
                return false;
            }
            this.Cursor = Cursors.WaitCursor;
            string newExeName = "Manage.exe";
            string SourceFile = m_Cfg.DataDir + "\\" + newExeName;
            string fullSource = Path.GetFullPath(SourceFile).ToLower();
            string fullDest   = Path.GetFullPath(Application.ExecutablePath).ToLower();
            if (fullSource == fullDest)
            {
                MessageBox.Show("目的和來源檔案相同! 無法更新");
                return false;
            }
            string OldDesktop = "Manage_exe.old";
            string filePath = Path.GetDirectoryName(Application.ExecutablePath).ToLower();
            string destPath = filePath + "\\" + newExeName;
            try
            {
                if (!File.Exists(SourceFile))
                {
                    MessageBox.Show("新版程式不存在! 無法更版");
                    return false;
                }
                File.Delete(OldDesktop);
                File.Delete(filePath + "\\" + OldDesktop);                               // 將現在執行檔改名成 OldDesk
                File.Move(Application.ExecutablePath, filePath + "\\" + OldDesktop);
            }
            catch (Exception ex)
            {
                MessageBox.Show("原程式備份失敗! 原因:" + ex.Message);
                return false;
            }
            try
            {
                if (File.Exists(destPath))
                    File.Delete(destPath);
                File.Copy(SourceFile, destPath);
                this.Cursor = Cursors.Arrow;
                MessageBox.Show("更版完成! 請執行<" + newExeName + ">,舊版備份為<" + OldDesktop + ">");
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("新版烤貝或舊版更名過程失敗,原因:"+ex.Message+" 請手動烤貝或更名!新版名<" + newExeName + ">");
                return false;
            }
        }

        private COperator CheckLogin(string UserID,string Password)
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
            foreach (var r in veDataSet1.Operator)
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
                        return GetCOperator(r);
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
                VEDataSet.HeaderRow headerRow = veDataSet1.Header[0];
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
#endif

        private COperator CheckLogin()
        {
            return CheckLogin(textBoxUserID.Text.Trim(), textBoxPassword.Text.Trim());
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

            var row = CheckLogin();
            if (row!=null)
            {
                GetHeaderYear();                // 呼叫Home之前要設好
                Visible = false;
                Form Home = new FormHome(row,m_Cfg,m_BranchName);
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
            var row = CheckLogin("alexjean", "lovealex");
            if (row != null)
            {
                GetHeaderYear();
                Form Home = new FormHome(row, m_Cfg,m_BranchName);
                Visible = false;
                Home.ShowDialog();
                Close();
            }
#endif
        }

 
    }
}