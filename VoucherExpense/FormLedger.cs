using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VoucherExpense
{
    public partial class FormLedger : Form
    {
        public FormLedger()
        {
            InitializeComponent();
        }

#if Define_Bakery
        RevenueCalcBakery m_Revenue;
        BakeryOrderSetTableAdapters.HeaderTableAdapter headerTableAdapter = new BakeryOrderSetTableAdapters.HeaderTableAdapter();
        BakeryOrderSet bakeryOrderSet = new BakeryOrderSet();
#else
        RevenueCalc m_Revenue;
        BasicDataSetTableAdapters.HeaderTableAdapter headerTableAdapter = new BasicDataSetTableAdapters.HeaderTableAdapter();
        BasicDataSet basicDataSet=new BasicDataSet();
#endif
        string m_SelectedTitleCode = "";
        int m_SelectedMonth = -1;
        AccTitleList AccList=new AccTitleList();
        AccTitleList AccList1 = new AccTitleList();      // Copy有初值的空表用
        AccTitleList NewList;                            // 計算用

        Dictionary<int, BankDefault> BankDictionary;     // < BankAccountID, TitleCode>
        VoucherExpense.MonthlyReportData[] RevenueCache; // 計算加速用
//        CMonthBalance[] MonthBalances;                   // 存月比較表用 
        TitleSetup Setup = new TitleSetup();

        private void FormLedger_Load(object sender, EventArgs e)
        {

#if Define_Bakery
            try
            {
                headerTableAdapter.Connection = MapPath.BakeryConnection;
                headerTableAdapter.Fill(bakeryOrderSet.Header);
            }
            catch { MessageBox.Show("標頭資料讀取錯誤,你的資料庫版本可能不對"); }
            int count = bakeryOrderSet.Header.Count;
            if (count == 0)
            {
                MessageBox.Show("無資料!");
                Close();
                return;
            }
            BakeryOrderSet.HeaderRow row = bakeryOrderSet.Header[count - 1];
            m_Revenue = new RevenueCalcBakery(row.DataDate, 0);
#else
            try
            {
                headerTableAdapter.Connection = MapPath.BasicConnection;
                headerTableAdapter.Fill(basicDataSet.Header);
            }
            catch { MessageBox.Show("標頭資料讀取錯誤,你的資料庫版本可能不對"); }
            int count = basicDataSet.Header.Count;
            if (count == 0)
            {
                MessageBox.Show("無資料!");
                Close();
                return;
            }
            BasicDataSet.HeaderRow row = basicDataSet.Header[count - 1];
            m_Revenue = new RevenueCalc(row.DataDate,0);
#endif
            AccList.NewAll();
            BankDictionary = new Dictionary<int, BankDefault>();
            RevenueCache = new MonthlyReportData[12];
            //MonthBalances = new CMonthBalance[13];
            //for (int i = 0; i < 13; i++)
            //{
            //    MonthBalances[i] = new CMonthBalance();
            //    MonthBalances[i].Month = i + 1;
            //}
            //MonthBalances[12].Month = 0;   // 第13月統計用

            accountingTitleTableAdapter.Connection = MapPath.VEConnection;
            bankAccountTableAdapter.Connection     = MapPath.VEConnection;
            expenseTableAdapter.Connection         = MapPath.VEConnection;
            voucherTableAdapter.Connection         = MapPath.VEConnection;
            voucherDetailTableAdapter.Connection   = MapPath.VEConnection;
            bankDetailTableAdapter.Connection      = MapPath.VEConnection;
            accVoucherTableAdapter.Connection      = MapPath.VEConnection;
            vendorTableAdapter.Connection          = MapPath.VEConnection;
            ingredientTableAdapter.Connection      = MapPath.VEConnection;

            try
            {
                accountingTitleTableAdapter.Fill(vEDataSet.AccountingTitle);
                bankAccountTableAdapter.Fill(vEDataSet.BankAccount);
                expenseTableAdapter.Fill(vEDataSet.Expense);    // expense檔案小,先全部讀進記憶體
                voucherTableAdapter.Fill(vEDataSet.Voucher);
                voucherDetailTableAdapter.Fill(vEDataSet.VoucherDetail);
                bankDetailTableAdapter.Fill(vEDataSet.BankDetail);
                accVoucherTableAdapter.Fill(vEDataSet.AccVoucher);
                vendorTableAdapter.Fill(vEDataSet.Vendor);
                ingredientTableAdapter.Fill(vEDataSet.Ingredient);
                foreach (VEDataSet.AccountingTitleRow r in vEDataSet.AccountingTitle.Rows)
                {
                    AccTitle item=new AccTitle(r.TitleCode,r.Name);
                    if (r.IsInitialValueNull())
                        item.Money = 0;
                    else 
                        item.Money = r.InitialValue;
                    if (r.TitleCode.Length == 0) continue;
                    AccList.Add(item);
                }
                AccList1.CopyTableFrom(AccList);

                foreach (VEDataSet.BankAccountRow r in vEDataSet.BankAccount.Rows)
                    BankDictionary.Add(r.ID,new BankDefault(r.AccountTitleCode,r.DefaultTitleCode));
                Setup.Load();
                cLedgerTableDataGridView.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show("資料庫讀取錯誤! 原因:"+ex.Message);
            }
        
            // 設置comboBoxAccTitle的初值為 <零用金>
            if (vEDataSet.BankAccount.Rows.Count>1)
            {
                VEDataSet.BankAccountRow bank=vEDataSet.BankAccount[0];
                if (bank.IsAccountTitleCodeNull())
                    comboBoxAccTitle.SelectedIndex=0;
                else
                    comboBoxAccTitle.SelectedValue=bank.AccountTitleCode;
            }
            DontRefresh = false;     // Form剛Load不Refresh DataGridView
        }

        bool DontRefresh = true;
        private void comboBoxAccTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;
            if (box.SelectedValue == null) return;
            m_SelectedTitleCode = box.SelectedValue.ToString();
            if (DontRefresh) return;
            if (m_SelectedMonth < 0 || m_SelectedMonth > 12)
            {
                Message("請選擇月份!!!");
                return;
            }
            CreateTable(m_SelectedMonth);
            cLedgerTableDataGridView.Focus();
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox box = sender as ComboBox;
            int i=box.SelectedIndex;
            if (i < 0 || i > 12) return;
            if (DontRefresh) return;
            CreateTable(m_SelectedMonth = i);
            cLedgerTableDataGridView.Focus();
        }


        void InitList()
        {
            NewList = new AccTitleList();
            NewList.CopyTableFrom(AccList1);
            NewList.defaultCost = AccTitleList.Find(Setup.DefaultCost, NewList.Costs, null);
            NewList.defaultExpense = AccTitleList.Find(Setup.DefaultExpense, NewList.Expenses, null);
            NewList.defaultIncome = AccTitleList.Find(Setup.DefaultIncome, NewList.Revenues, null);
            NewList.defaultAsset = AccTitleList.Find(Setup.DefaultAsset, NewList.Assets, null);
            NewList.defaultLiability = AccTitleList.Find(Setup.DefualtLiability, NewList.Liabilitys, null);
            foreach (KeyValuePair<int, BankDefault> pair in BankDictionary)
            {
                BankDefault bank = pair.Value;
                bank.DefaultTitle = AccTitleList.Find(bank.DefaultCode, NewList.Assets, NewList.defaultAsset);
            }
        }

        void Message(string msg)
        {
            labelMessage.Text = msg;
            Application.DoEvents();
        }

        bool InDuration(int curr, int to)
        {
            if (curr < MyFunction.IntHeaderMonth) return false;
            if (to == 0) // 全期
            {
                if (curr > 12) return false;
                return true;
            }
            if (curr <= to) return true;
            return false;
        }

        bool IsCurrent(int curr, int to)
        {
            if (to == 0)   // 全期和InDuration定相同
            {
                if (curr < MyFunction.IntHeaderMonth) return false;
                if (curr > 12) return false;
                return true;
            }
            if (curr == to) return true;
            return false;
        }

        MonthlyReportData CalcRevenue(int month,out List<MonthlyReportData> reportList)
        {
            int year = m_Revenue.Year;
            reportList = null;
            if (month < 1 || month > 12)
            {
                MessageBox.Show("所選月份不對!");
                return null;
            }
            Message("計算 " + month.ToString() + "月營業額");
            //if (RevenueCache[month - 1] != null)    // 不能用Cache了
            //    return RevenueCache[month - 1];
            int count = MyFunction.DayCountOfMonth(month);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = count;
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            List<MonthlyReportData> list = new List<MonthlyReportData>();
            for (int i = 1; i <= count; i++)
            {
#if Define_Bakery
                if (m_Revenue.LoadData(bakeryOrderSet, month, i))
                    list.Add(m_Revenue.Statics(bakeryOrderSet));
#else
                if (m_Revenue.LoadData(basicDataSet, year, month, i, true))
                    list.Add(m_Revenue.Statics(basicDataSet));
#endif
                progressBar1.Value = i;
                Application.DoEvents();
            }
            progressBar1.Visible = false;
            MonthlyReportData total = new MonthlyReportData();
            foreach (MonthlyReportData d in list)
            {
                total.Revenue += d.Revenue;
                total.OrderCount += d.OrderCount;
                total.Cash += d.Cash;
                total.CreditCard += d.CreditCard;
            }
            RevenueCache[month - 1] = total;       // 存到Cache裏
            reportList = list;
            return total;
        }

        // 和m_TitleCode比較相同就加
        decimal m_TitleSum = 0;  // 實科目算期初值用的
        int     m_Direction = 1; // 借方科目Direction -1 ,貸方科目Direction 1
        List<CLedgerRow> m_LedgerTable;

        // othersideTitle第一個數字,就當TitleCode找出科目名字,要不然就直接填
        bool AddIfWant(DateTime date,string titleCode,string note, decimal money, bool isDebt,bool isCurrent,bool inDuration,string othersideTitle)
        {
            if (titleCode != m_SelectedTitleCode) return false;
            if (!AccTitleList.IsVirtualTitle(titleCode))
                if (!isCurrent && inDuration)    
                {
                    if (isDebt) m_TitleSum -= (money*m_Direction);   
                    else        m_TitleSum += (money*m_Direction);
                }
            if (!isCurrent) return true; // 不是本期的
            CLedgerRow row = new CLedgerRow();
            row.Date = date;
            if (isDebt) { row.Debt = money; row.Credit = 0; }
            else        { row.Debt = 0;     row.Credit = money; }
            row.Note = note;            // row.sum最後再一起算
            string titleName = "";
            if (othersideTitle != null)
            {
                if (char.IsDigit(othersideTitle[0]))
                {
                    int tmp;
                    AccTitle t=NewList.FindTitleByCode(othersideTitle, out tmp);
                    if (t != null) titleName = t.Name;
                }
                else
                    titleName = othersideTitle;
            }
            row.OthersideAccTitle=titleName;
            m_LedgerTable.Add(row);
            return true;
        }


        class AccTemp
        {
            public string Code;
            public decimal Money;
            public bool IsDebt;
            public AccTemp(string code, decimal money, bool isDebt) { Code = code; Money = money; IsDebt = isDebt; }
        }
        void CreateTable(int mon)
        {
            m_LedgerTable = new List<CLedgerRow>();
            InitList();
            AccTitle selected=NewList.FindTitleByCode(m_SelectedTitleCode,out m_Direction);  // 1,5,6 借方科目,direction= -1
            if (selected == null)
            {
                MessageBox.Show("所選的科目<" + m_SelectedTitleCode + "> 在會計科目表找不到!");
                return;
            }
            m_TitleSum = selected.Money;  // 年度初值

            bool inDuration;
            bool isCurrent;
            #region ====== 股東權益======
            AccTitle ownersEquity = AccTitleList.Find(Setup.OwnersEquity, NewList.Liabilitys, null);
            if (ownersEquity != null)
            {
                if (ownersEquity.Code == m_SelectedTitleCode)
                {
                    MessageBox.Show("什麼都和股東權益有關,沒有分類帳! 請看損益表");
                    return;
                }
            }
            #endregion

            #region  ======= 計算費用 =======
            Message("計算費用");
            foreach (VEDataSet.ExpenseRow ro in vEDataSet.Expense)
            {
                if (ro.IsApplyTimeNull()) continue;
                if (ro.ApplyTime.Year != MyFunction.IntHeaderYear) continue;
                if (!ro.IsRemovedNull())
                    if (ro.Removed) continue;  //作癈的不計
                if (ro.IsMoneyNull()) continue;
                if (ro.RowState == DataRowState.Deleted)
                    continue;
                int m1 = ro.ApplyTime.Month;
                inDuration = InDuration(m1, mon);
                if (!inDuration) continue;   // inDuratio 一定 isCurrent
                isCurrent = IsCurrent(m1, mon);
                int bankID = 1;
                if (!ro.IsBankAccountIDNull())
                    bankID = ro.BankAccountID;
                string debitTitle, creditTitle;
                if (bankID == 1)  // 零用金戶 ,貸方一定是零用金, 資產項要累計
                {   // +++ 計算貸方科目 +++
                    creditTitle = null;
                    BankDefault bank;
                    if (BankDictionary.TryGetValue(bankID, out bank))    // 如果沒有設定好銀行的TitleCode, 零用金會不平
                        creditTitle = bank.BankCode;
                    else
                    {
                        MessageBox.Show("銀行帳号第一個<零用金>的設定有問題! 計算中止");
                        return;
                    }
                    // +++ 計算借方科目 +++
                    if (ro.IsTitleCodeNull())
                        debitTitle = NewList.defaultExpense.Code;
                    else
                        debitTitle = ro.TitleCode;
                    //NewList.PostToAccount(debitTitle, creditTitle, ro.Money, isCurrent, inDuration);
                    AddIfWant(ro.ApplyTime,debitTitle , ro.Note, ro.Money, true , isCurrent, inDuration,creditTitle);
                    AddIfWant(ro.ApplyTime,creditTitle, ro.Note, ro.Money, false, isCurrent, inDuration,debitTitle);
                }
                else  // 非零用金
                {
                    if (ro.IsTitleCodeNull()) debitTitle = null;
                    else debitTitle = ro.TitleCode;
                    if (ro.IsTitleCodeCreditNull()) creditTitle = null;
                    else creditTitle = ro.TitleCodeCredit;
                    //NewList.PostToAccount(debitTitle, creditTitle, ro.Money, isCurrent, inDuration);
                    string note = "";
                    if (!ro.IsNoteNull()) note = ro.Note;
                    AddIfWant(ro.ApplyTime,debitTitle , note, ro.Money, true , isCurrent, inDuration,creditTitle);
                    AddIfWant(ro.ApplyTime,creditTitle, note, ro.Money, false, isCurrent, inDuration,debitTitle);
                }
            }
            #endregion
            #region ====== 計算轉帳傳票 ======
            Message("計算轉帳傳票");
            foreach (VEDataSet.AccVoucherRow ro in vEDataSet.AccVoucher)
            {
                if (ro.IsAccVoucherTimeNull()) continue;
                if (ro.AccVoucherTime.Year != MyFunction.IntHeaderYear) continue;
                if (!ro.IsRemovedNull())
                    if (ro.Removed) continue;  //作癈的不計
                if (ro.RowState == DataRowState.Deleted) continue;
                int m1 = ro.AccVoucherTime.Month;
                inDuration = InDuration(m1, mon);
                isCurrent = IsCurrent(m1, mon);
                if (!inDuration) continue;
                
                string othersideAccTitle="<傳票"+ro.ID.ToString()+">";   // 第一個不是數字,就直接顯示
                string note = "";
                if (!ro.IsNoteNull()) note = ro.Note;
                List<AccTemp> temp = new List<AccTemp>();
                if (!ro.IsTitleCode0Null() && (!ro.IsMoney0Null()) && ro.Money0 != 0m) temp.Add(new AccTemp(ro.TitleCode0, ro.Money0, ro.IsDebt0));
                if (!ro.IsTitleCode1Null() && (!ro.IsMoney1Null()) && ro.Money1 != 0m) temp.Add(new AccTemp(ro.TitleCode1, ro.Money1, ro.IsDebt1));
                if (!ro.IsTitleCode2Null() && (!ro.IsMoney2Null()) && ro.Money2 != 0m) temp.Add(new AccTemp(ro.TitleCode2, ro.Money2, ro.IsDebt2));
                if (!ro.IsTitleCode3Null() && (!ro.IsMoney3Null()) && ro.Money3 != 0m) temp.Add(new AccTemp(ro.TitleCode3, ro.Money3, ro.IsDebt3));
                if (temp.Count == 2)    // 只有二個,可以把對沖科目列出
                {
                    AddIfWant(ro.AccVoucherTime, temp[0].Code, note, temp[0].Money, temp[0].IsDebt, isCurrent, inDuration, temp[1].Code);
                    AddIfWant(ro.AccVoucherTime, temp[1].Code, note, temp[1].Money, temp[1].IsDebt, isCurrent, inDuration, temp[0].Code);
                }
                else
                {
                    foreach(AccTemp ac in temp)
                        AddIfWant(ro.AccVoucherTime, ac.Code, note, ac.Money, ac.IsDebt, isCurrent, inDuration, othersideAccTitle);
                }
            }
            #endregion

            #region ======= 計算成本 =======
            // 在付款總表裏是每個月都被4捨5入至小數第一位,所以要分12個月,進位後再加
            Message("計算成本");
            decimal[] shouldPayMonth = new decimal[13];    // index0不用,以加快運算速度
            AccTitle shouldPay = AccTitleList.Find(Setup.VoucherShouldPay, NewList.Liabilitys, NewList.defaultLiability);
            if (shouldPay==null)
                MessageBox.Show("<應付帳款>科目未設定, 計算可能發生錯誤!");
            foreach (VEDataSet.VoucherRow ro in vEDataSet.Voucher)
            {
                if (ro.IsStockTimeNull()) continue;
                if (ro.StockTime.Year != MyFunction.IntHeaderYear) continue;
                if (!ro.IsRemovedNull())
                    if (ro.Removed) continue;
                if (ro.RowState == DataRowState.Deleted)
                    continue;
                int m1 = ro.StockTime.Month;
                //                if (m1 < MyFunction.IntHeaderMonth || m1 > mon) continue;
                if (ro.IsCostNull()) continue;
                inDuration = InDuration(m1, mon);
                isCurrent = IsCurrent(m1, mon);
                string vendorName="";
                string sID=ro.ID.ToString();
                if (ro.VendorRow!=null)
                    vendorName=ro.VendorRow.Name;
                if (inDuration) 
                {
                    shouldPayMonth[m1] += ro.Cost;
                    if (shouldPay.Code==m_SelectedTitleCode)            // 先檢查下不浪費找SubRow時間
                    {
                        string note=vendorName;     // 應付帳款,note放廠商名 ,對立科目放貨單号
                        AddIfWant(ro.StockTime,shouldPay.Code,note,ro.Cost,false,isCurrent ,inDuration,"<貨單"+sID+">");
                    }
                }
                if (IsCurrent(m1, mon))  // 加總到每個成本科目去 
                {
                    foreach (VEDataSet.VoucherDetailRow r1 in ro.GetVoucherDetailRows())
                    {
                        AccTitle r;
                        if (r1.IsTitleCodeNull()) r = NewList.defaultCost;
                        else
                            r = AccTitleList.Find(r1.TitleCode, NewList.Costs, NewList.defaultCost);
                        if (r != null && (!r1.IsCostNull()))
                        {
                            if (r.Code==m_SelectedTitleCode)          // 要找SubRow費時,先檢查一下  
                            {
                                string note="<"+ro.ID.ToString("d4")+"> ";
                                VEDataSet.IngredientRow ingredient = r1.IngredientRow;
                                if (ingredient!=null && (!ingredient.IsNameNull()))
                                    note+=r1.IngredientRow.Name;
                                if (!r1.IsVolumeNull())
                                    note+="  "+r1.Volume.ToString();
                                if (ingredient != null && (!ingredient.IsUnitNull()))
                                    note += ingredient.Unit;
                                
                                AddIfWant(ro.StockTime,r.Code,note, r1.Cost, true, isCurrent,inDuration,shouldPay.Name+"--"+vendorName);
                            }
                        }
                        //r.Add(r1.Cost);
                    }
                }
            }

            decimal shouldPayTotal = 0;
            for (int i = 1; i <= 12; i++)
                shouldPayTotal += System.Math.Round(shouldPayMonth[i], 1);  // 應付貨款只精確到小數第一位,每個月進位
            if (shouldPay != null)
                shouldPay.Add(shouldPayTotal);
            #endregion


            #region ====== 計算營業額 ======
            Message("計算營業額");
            AccTitle cash               = AccTitleList.Find(Setup.CashIncome        , NewList.Revenues  , NewList.defaultIncome);
            AccTitle credit             = AccTitleList.Find(Setup.CreditIncome      , NewList.Revenues  , NewList.defaultIncome);
            AccTitle cashReceivable     = AccTitleList.Find(Setup.CashReceivable    , NewList.Assets    , NewList.defaultAsset );
            AccTitle creditReceivable   = AccTitleList.Find(Setup.CreditReceivable  , NewList.Assets    , NewList.defaultAsset );
            MonthlyReportData total;
            // 算營業額很耗時, 先檢查是不是要的.分類帳要有每一天營收,要抓CalcRevenue內資料 ,暫時還沒加上
            if ((m_SelectedTitleCode==cash.Code) || (m_SelectedTitleCode==credit.Code) || (m_SelectedTitleCode==cashReceivable.Code) || (m_SelectedTitleCode==creditReceivable.Code)) 
            for (int m1 = 1; m1 <= 12; m1++)
            {
                inDuration = InDuration(m1, mon);
                if (!inDuration) continue;
                isCurrent = IsCurrent(m1, mon);
                List<MonthlyReportData> list;
                total = CalcRevenue(m1,out list);   // RevenueCalc需要Header.Date 己經在FormLoad時給值
                if (isCurrent)
                {
                    if (cash   != null) cash.Add(total.Cash);
                    if (credit != null) credit.Add(total.CreditCard);
                    foreach (MonthlyReportData report in list)
                    {
                        
                        DateTime da = new DateTime(MyFunction.IntHeaderYear, m1,(int)report.Date);
                        string note=m1.ToString()+"月"+report.Date.ToString()+"日 ";
                        if (report.Cash != 0m)
                        {
                            AddIfWant(da, cash.Code, cash.Name + note, report.Cash, false, isCurrent, inDuration, cashReceivable.Code);
                            AddIfWant(da, cashReceivable.Code, cashReceivable.Name + note, report.Cash, true, isCurrent, inDuration, cash.Code);
                        }
                        if (report.CreditCard != 0m)
                        {
                            AddIfWant(da, credit.Code, credit.Name + note, report.CreditCard, false, isCurrent, inDuration, creditReceivable.Code);
                            AddIfWant(da, creditReceivable.Code, creditReceivable.Name + note, report.CreditCard, true, isCurrent, inDuration, credit.Code);
                        }
                    }
                }
                if (cashReceivable   != null) cashReceivable.Add(total.Cash);
                if (creditReceivable != null) creditReceivable.Add(total.CreditCard);
            }
            #endregion
            //            MessageBox.Show("計算銀行前 1040 刷卡應付 " + creditReceivable.Money.ToString("N1"));
            #region ====== 計算銀行帳戶 ======
            Message("計算銀行帳戶");
            foreach (VEDataSet.BankDetailRow ro in vEDataSet.BankDetail.Rows)
            {
                if (ro.IsDayNull()) continue;
                if (ro.Day.Year != MyFunction.IntHeaderYear) continue;
                if (ro.IsMoneyNull()) continue;
                if (ro.RowState == DataRowState.Deleted)
                    continue;
                int m = ro.Day.Month;
                inDuration = InDuration(m, mon);
                isCurrent = IsCurrent(m, mon);
                if (!inDuration && !isCurrent) continue;
                if (ro.IsBankIDNull()) continue;
                if (ro.BankID <= 1) continue;  // 零用金不應存在此資料庫 
                string code;
                BankDefault bank;
                if (!BankDictionary.TryGetValue(ro.BankID, out bank)) continue;   // 找不到科目的銀行帳號
                if (ro.IsMoneyNull() || ro.Money==0m) continue;
                bool isPay = false;
                if (ro.IsIsCreditNull()) isPay = true;
                else isPay = ro.IsCredit;

                if (ro.IsTitleCodeNull() || ro.TitleCode.Length == 0)             // 找到此帳戶預設的科目
                    code = bank.DefaultCode;
                else
                    code = ro.TitleCode;
                //if (isPay)
                //    NewList.PostToAccount(code, bank.BankCode, ro.Money, isCurrent, inDuration, bank.DefaultTitle);
                //else
                //    NewList.PostToAccount(bank.BankCode, code, ro.Money, isCurrent, inDuration, bank.DefaultTitle);
                string note = "";
                if (!ro.IsNoteNull()) note = ro.Note;
                AddIfWant(ro.Day, code          , note, ro.Money,isPay  , isCurrent, inDuration,bank.BankCode);
                AddIfWant(ro.Day, bank.BankCode , note, ro.Money,!isPay , isCurrent, inDuration,code);
            }
            #endregion
            Comparison<CLedgerRow> compare = new Comparison<CLedgerRow>(CompareDate);
            m_LedgerTable.Sort(compare);
            bool isDebtTitle=AccTitleList.IsDebtTitle(m_SelectedTitleCode);
            if (!AccTitleList.IsVirtualTitle(m_SelectedTitleCode))    // 實科目有期初值,插入一行
            {
                CLedgerRow row=new CLedgerRow();
                int month = mon;
                if (month < 1 || month > 12) month = 1;
                row.Date=new DateTime(MyFunction.IntHeaderYear,month,1);
                row.Note="期初值";
                if (m_TitleSum>=0)
                {
                    if (isDebtTitle) { row.Debt=m_TitleSum; row.Credit=0;           }
                    else             { row.Debt=0;          row.Credit=m_TitleSum;  }
                }
                else
                {
                    if (isDebtTitle) { row.Debt=0;           row.Credit=-m_TitleSum; }
                    else             { row.Debt=-m_TitleSum; row.Credit=0;           }
                }
                m_LedgerTable.Insert(0,row);
            }
            decimal sum=0;
            foreach (CLedgerRow r in m_LedgerTable)
            {
                if (isDebtTitle) sum=sum-r.Credit+r.Debt;
                else             sum=sum+r.Credit-r.Debt;
                r.Sum = sum;
            }
            cLedgerTableDataGridView.DataSource = m_LedgerTable;
            Message("");
        }

        int CompareDate(CLedgerRow r1, CLedgerRow r2)
        {
            DateTime t1 = r1.Date.Date;
            DateTime t2 = r2.Date.Date;
            if (t1 > t2) return 1;
            if (t1 < t2) return -1;
            return 0;
        }

        private void btnExport2Excel_Click(object sender, EventArgs e)
        {
            if (m_SelectedMonth<0) 
            {
                Message("請先選擇月份!!");
                return;
            }
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Worksheet sheet;
            Microsoft.Office.Interop.Excel.Workbook book;
            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                book = excel.Application.Workbooks.Add(true);
                sheet = book.Worksheets[1];
                sheet.Name = comboBoxMonth.SelectedItem.ToString() + "費用";
            }
            catch (Exception ex)
            {
                MessageBox.Show("開啟Excel出錯,原因:" + ex.Message);
                return;
            }
            excel.Visible = true;
            DataGridView view = cLedgerTableDataGridView;
            Microsoft.Office.Interop.Excel.Range range;
            int i = 1;
            // 插入Logo圖片
            int imgHeight = 48;
            range = sheet.Rows[1];
            range.RowHeight = imgHeight + 2;
            Bitmap img = MyFunction.GetThumbnail(global::VoucherExpense.Properties.Resources.LogoVI, imgHeight * 4 / 3);   // 一般圖是96DPI,換算就是4pixels=3單位
            range = sheet.Cells[1, 1];
            Clipboard.SetDataObject(img, true);
            sheet.Paste(range, "LogoVI");

            //欄位表頭
            i++;

            sheet.Cells[i, 1] = "日期";
            range = sheet.Columns[1];
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            range.ColumnWidth = 10;

            sheet.Cells[i, 2] = "摘要";
            range = sheet.Columns[2];
            range.ColumnWidth = 30;

            sheet.Cells[i, 3] = "借方";
            range = sheet.Columns[3];
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            sheet.Cells[i, 4] = "貸方";
            range = sheet.Columns[4];
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

            sheet.Cells[i, 5] = "餘額";
            range = sheet.Columns[5];
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

            sheet.Cells[i, 6] = "科目";


            i++;
            foreach (DataGridViewRow vr in view.Rows)
            {
                sheet.Cells[i, 1] = vr.Cells[0].FormattedValue;         // 日期
                sheet.Cells[i, 2] = "'" + vr.Cells[1].FormattedValue;   // 摘要
                sheet.Cells[i, 3] = vr.Cells[2].FormattedValue;         // 借方
                sheet.Cells[i, 4] = vr.Cells[3].FormattedValue;         // 貸方
                sheet.Cells[i, 5] = vr.Cells[4].FormattedValue;         // 餘額
                sheet.Cells[i, 6] = vr.Cells[5].FormattedValue;         // 對沖科目

                //DataRowView rowView = vr.DataBoundItem as DataRowView;
                //VEDataSet.ExpenseRow row =  rowView.Row as VEDataSet.ExpenseRow;
                //if (!row.IsInnerIDNull())   sheet.Cells[i, 1] = row.InnerID;
                //                            sheet.Cells[i, 2] = row.ApplyTime;
                //if (!row.IsNoteNull())      sheet.Cells[i, 3] = row.Note;
                //if (!row.IsTitleCodeNull()) sheet.Cells[i, 4] = "'"+row.TitleCode.ToString();
                //if (!row.IsMoneyNull())     sheet.Cells[i, 5] = row.Money;
                //if (!row.IsApplierIDNull())
                //{
                //    sheet.Cells[i, 6] = row.ApplierID;
                //}
                i++;
            }
            sheet.Cells[i++, 2] = "'================================================";
            excel.Quit();

        }

    }
}
