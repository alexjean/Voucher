﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace VoucherExpense
{
    public partial class FormLogin : Form
    {
        HardwareConfig m_Cfg;
//        MapPath m_MapPath;
//        string m_BranchName="麥麥麥達人";
        DamaiDataSet.ApartmentRow m_DefaultApartment = null;

        void SetGlobalConnectionString(HardwareConfig cfg)
        {
            global::VoucherExpense.Properties.Settings.Default.DamaiConnectionString = DB.SqlConnectString(cfg.Local,cfg.Database);
        }
        public FormLogin()
        {
            string EncryptedPasword = "mpwfCblfsz";   // loveBakery
            string password = "";
            foreach (char c in EncryptedPasword) password += (char)(c - 1);
            global::VoucherExpense.Properties.Settings.Default.BakeryOrderConnectionString += password;

            HardwareConfig cfg = new HardwareConfig();
            cfg.Load();
            if (cfg.EnableCloudSync)
            {
                if (cfg.SharedDatabase != cfg.Database)
                {
                    int n = cfg.SharedDatabase.Count() - 6;
                    if (n < 0 || cfg.SharedDatabase.Substring(n, 6).ToLower() != "region")
                    {
                        cfg.EnableCloudSync = false;
                        MessageBox.Show("HardwareCfg.xml 中的<區域資料庫>設定不對! 雲端同步己強制取消.請通知IT帥哥來為你設定, 要跟他說你愛他喔!");
                    }
                }
            }
            if (cfg.SharedDatabase.Length == 0)
            {
                MessageBox.Show("你的HardwareCfg.xml有誤,缺少<區域資料庫>名稱設定 .請向IT帥哥索取一份貴門店專用設定,放置在大麥執行檔同目錄即可!");
                cfg.EnableCloudSync = false;
            }
            SetGlobalConnectionString(m_Cfg = cfg);
            InitializeComponent();
            ShowLogin(false);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            List<string> list=new List<string>();
            foreach(var profile in m_Cfg.ProfileList)
                list.Add(profile.profileName);
            cbxProfile.DataSource = list;

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
            ReadTable();        //  要防一開始就Call cbxProfile_SelectedIndexChanged
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

        COperator GetCOperator(DamaiDataSet.OperatorRow r) 
        {
            COperator op = new COperator();
            if (!r.IsEditAccountingTitleNull())     op.EditAccountingTitle = r.EditAccountingTitle;
            if (!r.IsEditBankNull())                op.EditBank = r.EditBank;
            if (!r.IsEditEmployeeNull())            op.EditEmployee = r.EditEmployee;
            if (!r.IsEditExpenseNull())             op.EditExpense = r.EditExpense;
            if (!r.IsEditIngredientNull())          op.EditIngredient = r.EditIngredient;
            if (!r.IsEditInventoryNull())           op.EditInventory = r.EditInventory;
            if (!r.IsEditOnDutyNull())              op.EditOnDuty = r.EditOnDuty;
            if (!r.IsEditOperatorNull())            op.EditOperator = r.EditOperator;
            if (!r.IsEditProductNull())             op.EditProduct = r.EditProduct;
            if (!r.IsEditRecipeNull())              op.EditRecipe = r.EditRecipe;
            if (!r.IsEditSalaryNull())              op.EditSalary = r.EditSalary;
            if (!r.IsEditShipmentNull())            op.EditShipment = r.EditShipment;
            if (!r.IsEditVendorNull())              op.EditVendor = r.EditVendor;
            if (!r.IsEditVoucherNull())             op.EditVoucher = r.EditVoucher;
            if (!r.IsIsManagerNull())               op.IsManager = r.IsManager;
            if (!r.IsIsSuperNull())                 op.IsSuper = r.IsSuper;
            if (!r.IsLockAccVoucherNull())          op.LockAccVoucher = r.LockAccVoucher;
            if (!r.IsLockExpenseNull())             op.LockExpense = r.LockExpense;
            if (!r.IsLockHRNull())                  op.LockHR = r.LockHR;
            if (!r.IsLockInventoryNull())           op.LockInventory = r.LockInventory;
            if (!r.IsLockShipmentNull())            op.LockShipment = r.LockShipment;
            if (!r.IsLockVoucherNull())             op.LockVoucher = r.LockVoucher;
            if (!r.IsRevenueOperateNull())          op.RevenueOperate = r.RevenueOperate;
            if (!r.IsStopAccountNull())             op.StopAccount = r.StopAccount;
            if (!r.IsEditCustomerNull())            op.EditCustomer = r.EditCustomer;
            op.LoginName = r.LoginName;
            if (r.IsNameNull())
                op.Name = "操作員" + r.OperatorID.ToString();   
            else 
                op.Name = r.Name;
            op.OperatorID = r.OperatorID;
            return op;
        }

        DamaiDataSetTableAdapters.OperatorTableAdapter operatorSQLAdapter;
        DamaiDataSetTableAdapters.VEHeaderTableAdapter headerSQLAdapter;
        DamaiDataSetTableAdapters.ApartmentTableAdapter apartmentSQLAdapter;
        DamaiDataSetTableAdapters.OperatorAuthListTableAdapter authListSQLAdapter;
        DamaiDataSet damaiDataSet;
        private bool ReadTable()
        {
            operatorSQLAdapter  = new DamaiDataSetTableAdapters.OperatorTableAdapter();
            headerSQLAdapter    = new DamaiDataSetTableAdapters.VEHeaderTableAdapter();
            apartmentSQLAdapter = new DamaiDataSetTableAdapters.ApartmentTableAdapter();
            authListSQLAdapter  = new DamaiDataSetTableAdapters.OperatorAuthListTableAdapter();

            operatorSQLAdapter.Connection.ConnectionString = DB.SqlConnectString(m_Cfg);
            apartmentSQLAdapter.Connection.ConnectionString = DB.SqlConnectString(m_Cfg);
            authListSQLAdapter.Connection.ConnectionString = DB.SqlConnectString(m_Cfg);

            damaiDataSet        = new DamaiDataSet();
            try
            {
                operatorSQLAdapter.Fill(damaiDataSet.Operator);
                headerSQLAdapter.Fill(damaiDataSet.VEHeader);
                apartmentSQLAdapter.Fill(damaiDataSet.Apartment);
                authListSQLAdapter.Fill(damaiDataSet.OperatorAuthList);
            }
            catch(Exception ex)
            {
                MessageBox.Show("操作員資料庫讀取錯誤<"+ex.Message+">!  無法登入");
                return false;
            }
            if (damaiDataSet.Operator.Rows.Count == 0)
            {
                MessageBox.Show("資料庫內沒有設定任何操作員,無法登入");
                Close();
                return false;
            }
            if (damaiDataSet.Apartment.Rows.Count != 0)
            {
                string Key = "LordAlex";
                foreach (var a in damaiDataSet.Apartment)
                {
                    byte[] buf = Encoder.RC2Decrypt(Convert.FromBase64String(a.DatabaseName.Trim()), Key);
                    string decoded = Encoding.Unicode.GetString(buf);
                    if (decoded == m_Cfg.Database.Trim())     // 不使用IsCurrent了
                    {
                        m_DefaultApartment = a;
                        break;
                    }
                }
                if (m_DefaultApartment == null)
                {
                    MessageBox.Show("部門資料庫內找不到<" + m_Cfg.Database + ">,設定有誤無法登入,請找IT帥哥!");
#if (DEBUG)                    
                    m_DefaultApartment = damaiDataSet.Apartment[9];
#else
                    Close();
                    return false;
#endif
                }
            }

            DamaiDataSet.VEHeaderRow header = null;
            string sVersion = "";
            if (damaiDataSet.VEHeader.Count > 0)
            {
                header = damaiDataSet.VEHeader[0];
                if (!header.IsVersionNull()) sVersion = header.Version.Trim();
            }
            CheckAppVersion(sVersion);
            return true;
        }

        bool DoUpdate()
        {
            this.Cursor = Cursors.WaitCursor;
            string newExeName = "Manage.exe";

            string fullDest = Path.GetFullPath(Application.ExecutablePath).ToLower();
            string OldDesktop = "Manage_exe.old";
            string filePath = Path.GetDirectoryName(Application.ExecutablePath).ToLower();
            string destPath = filePath + "\\" + newExeName;
            var programAdapter = new VoucherExpense.DamaiDataSetTableAdapters.ProgramTableAdapter();
            var table = new VoucherExpense.DamaiDataSet.ProgramDataTable();
            var row=table.NewProgramRow();
            byte[] data;
            try
            {
                programAdapter.Fill(table);
                if (table.Count<=0)
                {
                    MessageBox.Show("新版程式不存在! 無法更版");
                    return false;
                }
                row=table[table.Count-1];   // 取最後一個
                if (row.IsZippedImageNull())
                {
                    MessageBox.Show("新版程式長度為0 ! 無法更版");
                    return false;
                }
                byte[] md5 = null;
                data=MyFunction.Decompress(row.ZippedImage);
                md5=Encoder.GetMD5(data);
                for(int i=0;i<15;i++)
                    if (md5[i]!=row.MD5[i])
                    {
                        MessageBox.Show("MD5值不符,不進行更版!");
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
                MyFunction.WriteBufferToFile(data, destPath, data.Length);
                this.Cursor = Cursors.Arrow;
                MessageBox.Show("更版完成! 請執行<" + newExeName + ">,舊版備份為<" + OldDesktop + ">");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("新版烤貝或舊版更名過程失敗,原因:" + ex.Message + " 請手動烤貝或更名!新版名<" + newExeName + ">");
                return false;
            }

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
                        if (!r.IsStopAccountNull() && r.StopAccount)
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

        private COperator CheckLogin()
        {
            return CheckLogin(textBoxUserID.Text.Trim(), textBoxPassword.Text.Trim());
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            var row = CheckLogin();
            if (row!=null)
            {
                if (m_DefaultApartment == null)
                {
                    MessageBox.Show("沒有預定要登入的門店!請找碼農!");
                    return;
                }
                var authApartments = from auth in damaiDataSet.OperatorAuthList 
                                     where auth.OperatorID == row.OperatorID
                                     select auth;
                var au = from a in authApartments where a.ApartmentID == m_DefaultApartment.ApartmentID select a;
                if (au.Count() <= 0)
                {
                    MessageBox.Show("你在<" + m_DefaultApartment.ApartmentName.Trim() + ">店號" + m_DefaultApartment.AppartementCode.ToString() + ",沒有登入權限!");
                    return;
                }

                GetHeaderYear();                // 呼叫Home之前要設好
                Visible = false;
                foreach (var ap in damaiDataSet.Apartment)
                {
                    var found = from a in authApartments where a.ApartmentID == ap.ApartmentID select a;
                    if (found.Count() <= 0) ap.Delete();    // 不在授權表的拿掉
                }
                damaiDataSet.Apartment.AcceptChanges();

                m_Cfg.CopyHardwareProfile(m_Cfg.ActiveProfile, m_Cfg.LoginDefaultProfile);    // 為了讓FormHome切換時,ActiveProfile==LoginDefaultProfile 要用Local<->Cloud對應
                Form Home = new FormHome(row, m_Cfg, m_DefaultApartment,damaiDataSet.Apartment);
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
            this.cbxProfile.SelectedIndexChanged += new System.EventHandler(this.cbxProfile_SelectedIndexChanged);     // 防止未顯示就去Call
#if DEBUG
            if (!m_Cfg.IsServer)
                System.Threading.Thread.Sleep(250);   // 給 WinExec一點時間,執行完 Net Use * /Delete /Yes
            ShowLogin(true);
            if (!ReadTable())
            {
                MyFunction.HardwareCfg = m_Cfg;
                Form hardware = new FormHardware();
                hardware.ShowDialog();
                Close();
                return;
            }
            var row = CheckLogin("alexjean", "love2015");
            if (row != null)
            {
                GetHeaderYear();
                m_Cfg.CopyHardwareProfile(m_Cfg.ActiveProfile, m_Cfg.LoginDefaultProfile);         // 切換門店時, 比對LoginDefaultProfile,所以存下

                Form Home = new FormHome(row, m_Cfg, m_DefaultApartment,damaiDataSet.Apartment);   // Debug 把所有部門都放進去
                Visible = false;
                Home.ShowDialog();
                Close();
            }
#endif
        }

        private void cbxProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;
            string profileName=box.SelectedItem.ToString();
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            foreach (HardwareProfile p in m_Cfg.ProfileList)
            {
                if (p.profileName == profileName)
                {
                    m_Cfg.SetDefaultAs(p);
                    SetGlobalConnectionString(m_Cfg);
                    ReadTable();
                    break;
                }
            }
            Cursor = Cursors.Arrow;
            textBoxUserID.Focus();
        }

    }
}