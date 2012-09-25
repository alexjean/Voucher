using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace VoucherExpense
{
    public partial class FormHome : Form
    {
   

        VEDataSet.OperatorRow Operator;
        HardwareConfig m_Config;
        // 必需設好 Operator及m_Config才能呼叫SetFormTitle
        void SetFormTitle()
        {
            string str;
            if (m_Config.IsServer)  str = "本地";
            else                    str = "遠端";
            string name;
            if (Operator.IsNameNull()) 
                 name = "操作員" + Operator.OperatorID.ToString();   
            else name = Operator.Name;
            this.Text = str + MyFunction.HeaderYear + "      " + name;
            if (MyFunction.LockAll) this.Text += " 鎖定中";
        }

        public FormHome(VEDataSet.OperatorRow Op,HardwareConfig cfg)
        {
            InitializeComponent();

            Operator=Op;
            MyFunction.OperatorID=Op.OperatorID;
            m_Config = cfg;
            SetFormTitle();

            ToolStripMenuItem basic;
            basic=(ToolStripMenuItem)menu1.Items["基本資料MenuItem"];
            basic.Enabled = (Op.EditEmployee | Op.EditOperator | Op.EditAccountingTitle | 
                             Op.EditIngredient  | Op.EditVendor | Op.EditBank);
            bool manager = Op.IsManager;
            MyFunction.IsManager = manager;
            MyFunction.LockHR = Op.LockHR;
            basic.DropDownItems["操作員MenuItem"].Enabled   = Op.EditOperator;
            basic.DropDownItems["環境設定MenuItem"].Enabled = Op.IsManager;
            basic.DropDownItems["食材表MenuItem"].Enabled   = Op.EditIngredient;
            basic.DropDownItems["供應商MenuItem"].Enabled   = Op.EditVendor;
            basic.DropDownItems["會計科目MenuItem"].Enabled = Op.EditAccountingTitle;
            basic.DropDownItems["銀行帳號MenuItem"].Enabled = Op.EditBank ;
            basic.DropDownItems["銀行帳號MenuItem"].Visible = Op.EditBank ;
            basic.DropDownItems["傳票設定MenuItem"].Visible = manager && Op.EditAccountingTitle;  // 經理+編修科目
            basic.DropDownItems["年初開帳MenuItem"].Visible = Op.IsSuper;
            basic.DropDownItems["編修部門MenuItem"].Visible = Op.IsSuper;
            會計MenuItem.Enabled = manager || Op.EditAccountingTitle;
            轉帳傳票MenuItem.Enabled = Op.EditAccountingTitle;                                    // 傳票和會計科目

            menu1.Items["費用MenuItem"].Enabled = Op.EditExpense;
            menu1.Items["進貨MenuItem"].Enabled = Op.EditVoucher;
            menu1.Items["收入MenuItem"].Enabled = manager;
            menu1.Items["銀行MenuItem"].Enabled = Op.EditBank;
            menu1.Items["報表MenuItem"].Enabled = manager;
            ToolStripMenuItem i = (ToolStripMenuItem)menu1.Items["查核MenuItem"];
            i.Enabled = Op.LockExpense || Op.LockVoucher || Op.LockAccVoucher;
            查核費用MenuItem.Enabled = Op.LockExpense;
            查核進貨MenuItem.Enabled = Op.LockVoucher;
            查核傳票MenuItem.Enabled = Op.LockAccVoucher;
            人事MenuItem.Enabled = Op.EditSalary || Op.EditOnDuty;
            考勤MenuItem.Enabled = Op.EditOnDuty;
            資料卡MenuItem.Enabled = Op.EditSalary;
            合併傳票MenuItem.Enabled = Op.LockAccVoucher;

            if (MyFunction.LockAll)
                i.DropDownItems["鎖定資料庫MenuItem"].Text = "解鎖資料庫";
            else
                i.DropDownItems["鎖定資料庫MenuItem"].Text = "鎖定資料庫";
            foreach (ToolStripMenuItem item in menu1.Items)
            {
                if (!item.Enabled) item.Visible = false;
                else
                    foreach (ToolStripMenuItem it in item.DropDownItems)
                        if (!it.Enabled) it.Visible = false;
            }

            headerTableAdapter.Connection = MapPath.VEConnection;
 
        }
        /*
                [DllImport("user32.dll")]
                static extern bool SetForegroundWindow(IntPtr hWnd);
                [DllImport("user32.dll")]
                public extern static int SendMessage(IntPtr hwnd, uint msg, uint wParam,uint lParam);
                enum WindowMessage
                {
                    MDIMaxmize = 0x225
                }
        */
        private void CloseOpenedMenu(string formName)
        {
            foreach (Form Opened in this.MdiChildren)
            {
                if (Opened.Name == formName)
                {
                    Opened.Close();
                    return;
                }
            }
        }

     
        private void 修改密碼MenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("ModifyPassword",typeof(ModifyPassword));
        }
 
        private void 會計科目MenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("AccountingTitle",typeof(AccountingTitle));
        }

        private void 食材表MenuItem_Click(object sender, EventArgs e)
        {
            // 只有Super可以編參考價
            if (!PopupMenu("Ingredient"))
                Run("Ingredient", new Ingredient(Operator.IsSuper));
        }

        private void 操作員MenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("Operator",typeof(FormOperator));
        }

        private void 供應商MenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("Vendor", typeof(Vendor));
        }

        private void 費用MenuItem_Click(object sender, EventArgs e)
        {
            bool modified = MyFunction.GetThenResetGlobalFlag(GlobalFlag.employeeModified);
            if (modified) CloseOpenedMenu("Expense");
            if (!PopupMenu("Expense"))
                 Run("Expense", new Expense(false,true));
        }

        private void 進貨MenuItem_Click(object sender, EventArgs e)
        {
            bool modified = MyFunction.GetThenResetGlobalFlag(GlobalFlag.basicDataModified);
            if (modified) CloseOpenedMenu("Voucher");
            PopupOrRun("Voucher", typeof(Voucher));
        }

        private void 費用MenuItem1_Click(object sender, EventArgs e)
        {
            if (!PopupMenu("ExpenseCheck"))
                Run("ExpenseCheck", new Expense(true,true));
        }

        private void 進貨MenuItem1_Click(object sender, EventArgs e)
        {
            if (!PopupMenu("VoucherCheck"))
                Run("VoucherCheck", new Voucher(true));
        }

        private void 損益報表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("ReportByTitle", typeof(ReportByTitle));
        }

        private void 轉帳傳票MenuItem_Click(object sender, EventArgs e)
        {
            if (!PopupMenu("AccVoucher"))
                Run("AccVoucher", new FormAccVoucher(false));
        }

        private void 查核傳票MenuItem_Click(object sender, EventArgs e)
        {
            if (!PopupMenu("AccVoucherCheck"))
                Run("AccVoucherCheck", new FormAccVoucher(true));
        }


        private void 統計廠商MenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("ReportByVender", typeof(ReportByVender));
        }

        private void 付款總表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("MonthlyPay", typeof(FormMonthlyPay));
        }

        private void 鎖定資料庫ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.headerTableAdapter.Fill(this.vEDataSet.Header);
            if (vEDataSet.Header.Count==0)
            {
                VEDataSet.HeaderRow row=vEDataSet.Header.NewHeaderRow();
                row.Closed=!MyFunction.LockAll;
                int y=DateTime.Now.Year;
                row.DataYear=new DateTime(y,1,1);
                vEDataSet.Header.AddHeaderRow(row);
            }
            VEDataSet.HeaderRow header=vEDataSet.Header[0];
            header.BeginEdit();
            header.Closed = !MyFunction.LockAll;
            header.EndEdit();
            try
            {
                headerTableAdapter.Update(header);
            }
            catch(Exception ex)
            {
                MessageBox.Show("變更鎖定狀態未成功:"+ex.Message);
                return;
            }
            MyFunction.LockAll = !MyFunction.LockAll;
            SetFormTitle();             
            ToolStripMenuItem i = (ToolStripMenuItem)menu1.Items["查核MenuItem"];
            if (MyFunction.LockAll)
            {
                i.DropDownItems["鎖定資料庫MenuItem"].Text = "解鎖資料庫";
            }
            else
                i.DropDownItems["鎖定資料庫MenuItem"].Text = "鎖定資料庫";

        }

        private void FormHome_Load(object sender, EventArgs e)
        {
        }

        private void FormHome_SizeChanged(object sender, EventArgs e)
        {
            if (Width > BackgroundImage.Width && Height > BackgroundImage.Height)
                BackgroundImageLayout = ImageLayout.Stretch;
            else
                BackgroundImageLayout = ImageLayout.Tile;
        }


        private bool PopupMenu(string formName)
        {
            foreach (Form Opened in this.MdiChildren)
            {
                if (Opened.Name == formName)
                {
                    Opened.Focus();
                    return true;
                }
            }
            return false;
        }

        // RunMenu浪費,但是有Constructor有參數的沒辦法
        private void Run(string formName, Form form)
        {
            form.MdiParent = this;
            form.Name = formName;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void PopupOrRun(string formName, Type formType)
        {
            if (PopupMenu(formName)) return;
            Form form = (Form)Activator.CreateInstance(formType);
            Run(formName, form);
        }

        private void 銀行帳號ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("BankAccount", typeof(FormBank));
        }

        private void 明細ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("OrderBrowse", typeof(FormBrowse));
        }

        private void 月報ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("MonthlyIncome", typeof(MonthlyReport));
        }

        private void 進銷比ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("SaleSpendRatio", typeof(SaleSpendRatio));
        }

        private void 傳票設定MenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("TitleSetup", typeof(FormTitleSetup));
        }

        private void 細目編修ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("BankDetail", typeof(FormBankDetail));
        }

        private void 匯入XLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("ImportBankExcel", typeof(FormImportBankExcel));
        }

        private void FormHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form Opened in this.MdiChildren) 
            {
                 Opened.Close();    // 關閉每個子視窗
            }
        }

        private void 盤點ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("Stock", typeof(FormStock));
        }

        private void 環境設定MenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("Hardware", typeof(FormHardware));
        }

        private void 備份資料庫ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HardwareConfig config = new HardwareConfig();
            config.Load();
            BackupData.DoBackup(config);
        }

        private void 考勤MenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("OnDutyEmployee", typeof(FormOnDutyEmployee));
        }

        private void 合併銀行細目MdbMenuItem_Click(object sender, EventArgs e)
        {
            MergeMdb.合併銀行細目(vEDataSet.BankDetail);
        }

        private void 合併傳票MdbMenuItem_Click(object sender, EventArgs e)
        {
            MergeMdb.合併傳票(vEDataSet.AccVoucher);
        }

        private void 年初開帳ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("年初開帳", typeof(FormInitNewYear));
        }

        private void 排班表MenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("排班表", typeof(FormShift));
        }

        private void 編點菜單ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("點菜單", typeof(FormEditMenu));
        }

        private void 資料卡MenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("人事資料卡", typeof(FormHR));
        }

        private void 編修部門ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("編修部門", typeof(FormApartment));
        }

        private void 銷售統計ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("SoldProducts", typeof(FormSoldProducts));
        }

        //private void 盤點ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    PopupOrRun("Stock", typeof(FormStock));
        //}
   




    }
}