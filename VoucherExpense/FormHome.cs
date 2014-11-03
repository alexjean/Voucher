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
        COperator Operator;
        HardwareConfig m_Config;
        string m_BranchName;
        // 必需設好 Operator及m_Config才能呼叫SetFormTitle
        void SetFormTitle()
        {
            string str;
            //if (m_Config.IsServer)  str = "本地";
            //else                    str = "遠端";
            str = m_BranchName;
            string name = Operator.Name;
            this.Text = str + MyFunction.HeaderYear + "      " + name;
            if (MyFunction.LockAll) this.Text += " 鎖定中";
        }

        public FormHome(COperator Op,HardwareConfig cfg,string branchName)
        {
            InitializeComponent();

            Operator=Op;
            MyFunction.OperatorID=Op.OperatorID;
            MyFunction.HardwareCfg=m_Config = cfg;
            m_BranchName = branchName;
            SetFormTitle();

            ToolStripMenuItem basic;
            basic=(ToolStripMenuItem)menu1.Items["基本資料MenuItem"];
            basic.Enabled = (Op.EditEmployee | Op.EditOperator | Op.EditAccountingTitle | 
                             Op.EditIngredient  | Op.EditVendor | Op.EditBank);
            bool manager = Op.IsManager;
            MyFunction.IsManager = manager;
            MyFunction.LockHR = Op.LockHR;
            MyFunction.LockInventory = Op.LockInventory;
            basic.DropDownItems["操作員MenuItem"].Enabled   = Op.EditOperator;
            basic.DropDownItems["硬體環境MenuItem"].Enabled = Op.IsSuper;
            basic.DropDownItems["食材表MenuItem"].Enabled   = Op.EditIngredient;
            basic.DropDownItems["配方表MenuItem"].Enabled   = Op.EditRecipe;
            basic.DropDownItems["產品表MenuItem"].Enabled   = Op.EditProduct;
            basic.DropDownItems["产品类别ToolStripMenuItem"].Enabled = Op.EditProduct;
            basic.DropDownItems["編修菜單MenuItem"].Enabled = Op.EditProduct;
            basic.DropDownItems["供應商MenuItem"].Enabled   = Op.EditVendor;
            basic.DropDownItems["會計科目MenuItem"].Enabled = Op.EditAccountingTitle;
            basic.DropDownItems["銀行帳號MenuItem"].Enabled = Op.EditBank ;
            basic.DropDownItems["銀行帳號MenuItem"].Visible = Op.EditBank ;
            basic.DropDownItems["傳票設定MenuItem"].Visible = Op.LockAccVoucher && Op.EditAccountingTitle;  // 核傳票+編修科目
            basic.DropDownItems["年初開帳MenuItem"].Visible = Op.IsSuper;
            basic.DropDownItems["編修部門MenuItem"].Visible = Op.IsSuper;
            basic.DropDownItems["客户MenuItem"].Visible = Op.EditCustomer;
            會計MenuItem.Enabled = Op.EditAccountingTitle;
            轉帳傳票MenuItem.Enabled = Op.EditAccountingTitle;                                              // 傳票和會計科目

            menu1.Items["庫存MenuItem"].Enabled=  Op.EditInventory;
            menu1.Items["費用MenuItem"].Enabled = Op.EditExpense;
            menu1.Items["進貨MenuItem"].Enabled = Op.EditVoucher;
            menu1.Items["收入MenuItem"].Enabled = Op.RevenueOperate;
            menu1.Items["銀行MenuItem"].Enabled = Op.EditBank;
            menu1.Items["報表MenuItem"].Enabled = manager;
            ToolStripMenuItem i = (ToolStripMenuItem)menu1.Items["查核MenuItem"];
            i.Enabled = Op.LockExpense || Op.LockVoucher || Op.LockAccVoucher;
            查核費用MenuItem.Enabled = Op.LockExpense;
            查核進貨MenuItem.Enabled = Op.LockVoucher;
            查核傳票MenuItem.Enabled = Op.LockAccVoucher;
            人事MenuItem.Enabled = Op.EditSalary || Op.EditOnDuty || Op.LockHR;
            考勤MenuItem.Enabled = Op.EditOnDuty;
            排班表MenuItem.Enabled = Op.EditOnDuty;
            資料卡MenuItem.Enabled = Op.EditSalary;
            合併傳票MenuItem.Enabled = Op.LockAccVoucher;
            出货MenuItem.Enabled = Op.EditShipment||Op.LockShipment;

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
                 Run("Expense", new Expense(false,false));   
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
#if UseSQLServer
            VoucherExpense.DamaiDataSet DataSet = new DamaiDataSet();
            var headerAdapter = new VoucherExpense.DamaiDataSetTableAdapters.VEHeaderTableAdapter();
            headerAdapter.Fill(DataSet.VEHeader);
            if (DataSet.VEHeader.Count == 0)
            {
                var row = DataSet.VEHeader.NewVEHeaderRow();
                row.Closed = !MyFunction.LockAll;
                int y = DateTime.Now.Year;
                row.DataYear = new DateTime(y, 1, 1);
                DataSet.VEHeader.AddVEHeaderRow(row);
            }
            var header = DataSet.VEHeader[0];
#else
            VoucherExpense.VEDataSet DataSet = new VEDataSet();
            var headerAdapter = new VoucherExpense.VEDataSetTableAdapters.HeaderTableAdapter();
            headerAdapter.Connection = MapPath.VEConnection;
            headerAdapter.Fill(DataSet.Header);
            if (DataSet.Header.Count==0)
            {
                var row=DataSet.Header.NewHeaderRow();
                row.Closed=!MyFunction.LockAll;
                int y=DateTime.Now.Year;
                row.DataYear=new DateTime(y,1,1);
                DataSet.Header.AddHeaderRow(row);
            }
            VEDataSet.HeaderRow header=DataSet.Header[0];
#endif
            header.BeginEdit();
            header.Closed = !MyFunction.LockAll;
            header.EndEdit();
            try
            {
                headerAdapter.Update(header);
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

        private bool PopupOrRun(string formName, Type formType)
        {
            if (PopupMenu(formName)) return true;
            Form form = (Form)Activator.CreateInstance(formType);
            Run(formName, form);
            return false;
        }

        private void 銀行帳號ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("BankAccount", typeof(FormBank));
        }

        private void 明細ToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if Define_Bakery
            PopupOrRun("BakeryOrderBrowse",typeof(BakeryOrderBrowse));
#else
            PopupOrRun("BasicOrderBrowse", typeof(FormBrowse));
#endif
        }

        private void 月報ToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if Define_Bakery
            PopupOrRun("MonthlyIncome", typeof(MonthlyReportBakery));
#else
            PopupOrRun("MonthlyIncome", typeof(MonthlyReport));
#endif 
        }

        private void 銷貨進貨ToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if Define_Bakery
            PopupOrRun("BakerySoldSpent", typeof(BakerySoldSpent));
#else
            PopupOrRun("BasicSoldSpent", typeof(BasicSoldSpent));
#endif

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


        private void 環境設定MenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("Hardware", typeof(FormHardware));
        }

        private void 同步資料庫ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Alex 2013.12.18 改SQL同步,暫時Markout備份部分
            //HardwareConfig config = new HardwareConfig();
            //config.Load();
            //BackupData.DoBackup(config);
        }

        private void 考勤MenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("OnDutyEmployee", typeof(FormOnDutyEmployee));
        }

        private void 合併銀行細目MdbMenuItem_Click(object sender, EventArgs e)
        {
            MergeMdb.合併銀行細目();
        }

        private void 合併傳票MdbMenuItem_Click(object sender, EventArgs e)
        {
            MergeMdb.合併傳票();
        }

        private void 年初開帳ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("年初開帳", typeof(FormInitNewYear));
        }

        private void 排班表MenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("排班表", typeof(FormShift));
        }


        private void 資料卡MenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("人事資料卡", typeof(FormHR));
        }

        private void 編修部門ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("編修部門", typeof(FormApartment));
        }

        private void 銷貨統計ToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if Define_Bakery            
            PopupOrRun("SoldProducts", typeof(BakerySoldProducts));
#else
            PopupOrRun("SoldProducts", typeof(BasicSoldProducts));
#endif

        }

        private void 產品表MenuItem_Click(object sender, EventArgs e)
        {
#if Define_Bakery
            PopupOrRun("烘培產品", typeof(EditBakeryProduct));
#else
            PopupOrRun("餐飲產品", typeof(EditBasicProduct));
#endif
        }
        private void 編修菜單MenuItem_Click(object sender, EventArgs e)
        {
#if Define_Bakery
            PopupOrRun("EditBakeryMenu", typeof(EditBakeryMenu));
#else
            PopupOrRun("餐飲菜單", typeof(EditBasicMenu));
#endif
        }

        private void 收銀授權ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("收銀授權", typeof(FormCashierAuthen));
        }

        private void 分類MenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("分類帳", typeof(FormLedgerNew));
//            PopupOrRun("分類帳", typeof(FormLedger));
        }

        private void 配方表MenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("FormRecipe", typeof(FormRecipe));
        }

        private void 盤點單ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("FormIngredientInventories", typeof(FormInventories));
        }

        private void 產品報廢ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("FormScraps",typeof(FormScraps));
        }

        private void 未知損耗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("FormShrink", typeof(FormShrink));
        }


        private void 请款单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("FormBillList", typeof(FormBillList));
        }

        private void 客户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("FormCustomer", typeof(FormCustomer));
        }


        private void 单据ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 产品类别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("EditProductClass", typeof(EditProductClass));
        }

        private void 出货统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("FormShipmentReport", typeof(FormShipmentReport));
        }

        private void 出货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("FormShipment", typeof(FormShipment));
        }

        private void 出货收款统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("FormMonthlyIncome", typeof(FormMonthlyIncome));
        }

        private void 組合傳票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PopupOrRun("FormAccounting", typeof(FormAccounting)))
            {
                int w=Screen.PrimaryScreen.WorkingArea.Width;
                if ( w> 1600 && this.Width<1600)
                {
                    this.Width = 1600;
                    if ((this.Left + this.Width) > w)
                        this.Left = w - this.Width;
                }
            }
        }

        private void 销售预估ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopupOrRun("FormSalesForecast", typeof(FormSalesForecast));
        }
    }
}