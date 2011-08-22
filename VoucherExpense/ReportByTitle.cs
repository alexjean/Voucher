using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace VoucherExpense
{
    public partial class ReportByTitle : Form
    {
        class BankDefault
        {
            public string BankCode;
            public string DefaultCode;
            public AccTitle DefaultTitle;
            public BankDefault(string bankCode, string defaultCode) { BankCode = bankCode; DefaultCode = defaultCode; }
        }
        List<AccTitle> AssetList;     // 會計科目1字頭 資產
        List<AccTitle> LiabilityList;  // 會計科目2字頭 負債
        List<AccTitle> RevenueList; // 會計科目4字頭 營收
        List<AccTitle> CostList;      // 會計科目5字頭 成本
        List<AccTitle> ExpenseList; // 會計科目6字頭

        List<AccTitle> AssetList1;  
        List<AccTitle> LiabilityList1;
        List<AccTitle> RevenueList1;  
        List<AccTitle> CostList1;     
        List<AccTitle> ExpenseList1;  
        Dictionary<int, BankDefault> BankDictionary; // < BankAccountID, TitleCode>
        MonthlyReportData[] RevenueCache; // 計算加速用
        TitleSetup Setup = new TitleSetup();

        public ReportByTitle()
        {
            InitializeComponent();
        }

        int CompareAccountingTable(AccTitle t1, AccTitle t2)
        {
            if (t1.Money > t2.Money) return -1;
            else if (t2.Money > t1.Money) return 1;
            return 0;
        }

        List<AccTitle> CopyTable(List<AccTitle> list)
        {
            List<AccTitle> NewList = new List<AccTitle>();
            foreach (AccTitle r in list)  // 從空的表Copy過來
            {
                AccTitle item = new AccTitle(r.Code, r.Name);
                item.Money = r.Money;     // 設定初值 
                NewList.Add(item);
            }
            return NewList;
        }

        AccTitle Find(string code,List<AccTitle> table,AccTitle defaultTitle)
        {
            foreach (AccTitle r in table)
            {
                if (code == r.Code) return r;
            }
            return defaultTitle;
        }

        bool IsVirtualTitle(string code)
        {
            if (code.Length == 0) return true; 
            char c = code[0];
            if (c == '6') return true;
            if (c == '5') return true;
            if (c == '4') return true;
            return false;
        }

        
        List<AccTitle> NewExpenseList;
        List<AccTitle> NewRevenueList;
        List<AccTitle> NewAssetList;
        List<AccTitle> NewLiabilityList;
        List<AccTitle> NewCostList;
        AccTitle defaultCost;
        AccTitle defaultExpense;
        AccTitle defaultIncome;
        AccTitle defaultAsset;
        AccTitle defaultLiability;

        void InitList()
        {
            NewExpenseList  = CopyTable(ExpenseList1);
            NewCostList     = CopyTable(CostList1);
            NewRevenueList  = CopyTable(RevenueList1);
            NewAssetList    = CopyTable(AssetList1);
            NewLiabilityList =CopyTable(LiabilityList1);
            defaultCost     = Find(Setup.DefaultCost     , NewCostList      , null);
            defaultExpense  = Find(Setup.DefaultExpense  , NewExpenseList   , null);
            defaultIncome   = Find(Setup.DefaultIncome   , NewRevenueList   , null);
            defaultAsset    = Find(Setup.DefaultAsset    , NewAssetList     , null);
            defaultLiability =Find(Setup.DefualtLiability, NewLiabilityList , null);
            foreach (KeyValuePair<int,BankDefault> pair in BankDictionary)
            {
                BankDefault bank=pair.Value;
                bank.DefaultTitle = Find(bank.DefaultCode, NewAssetList, defaultAsset);
            }
        }

        AccTitle FindTitleByCode(string code,out int credit)
        {
            AccTitle r;
            switch (code[0])
            {
                case '1': r = Find(code, NewAssetList, defaultAsset);         credit = -1; break;
                case '2': r = Find(code, NewLiabilityList, defaultLiability); credit = 1;  break;
                case '4': r = Find(code, NewRevenueList, defaultIncome);      credit = 1;  break;
                case '5': r = Find(code, NewCostList, defaultCost);           credit = -1; break;
                case '6': r = Find(code, NewExpenseList, defaultExpense);     credit = -1; break;
                default: credit = 0; return null;
            }
            return r;
        }

        AccTitle FindTitleByCodeWithDefault(string code,AccTitle defaultTitle ,out int credit)
        {
            AccTitle r;
            switch (code[0])
            {
                case '1': r = Find(code, NewAssetList, defaultTitle);     break;
                case '2': r = Find(code, NewLiabilityList, defaultTitle); break;
                case '4': r = Find(code, NewRevenueList, defaultTitle);   break;
                case '5': r = Find(code, NewCostList, defaultTitle);      break;
                case '6': r = Find(code, NewExpenseList, defaultTitle);   break;
                default: credit = 0; return null;
            }
            switch (r.Code[0])
            {
                case '1': credit = -1;  break;
                case '2': credit = 1;   break;
                case '4': credit = 1;   break;
                case '5': credit = -1;  break;
                case '6': credit = -1;  break;
                default: credit = 0;    break;
            }
            return r;
        }


        decimal SumMarkPercentAndSort(List<AccTitle> list)
        {
            Comparison<AccTitle> comp = new Comparison<AccTitle>(CompareAccountingTable);
            list.Sort(comp);  // 排序
            decimal sum = 0;
            foreach (AccTitle r in list)
                sum += r.Money;
            if (sum != 0)
            {
                foreach (AccTitle r in list)
                    r.Percentage = (double)(r.Money * 100 / sum);
            }
            return sum;
        }

        void Message(string msg)
        {
            labelMessage.Text = msg;
            Application.DoEvents();
        }

        void PostToAccount(string debit, string credit, decimal money, bool isCurrent, bool inDuration,AccTitle defaultTitle)
        {
            AccTitle r;
            // +++ 計算借方科目 +++
            int dir = 1;
            r = FindTitleByCodeWithDefault(debit,defaultTitle,out dir);
            if (r != null)
            {
                if (IsVirtualTitle(r.Code))         // 虛科目當月才加
                {
                    if (isCurrent) r.Add(-money * dir);
                }
                else                                // 實科目在期限內都加  
                {
                    if (inDuration)
                        r.Add(-money * dir);
                }
            }
            // +++ 計算貸方科目 +++
            r = FindTitleByCodeWithDefault(credit,defaultTitle, out dir);
            if (r != null)
            {
                if (IsVirtualTitle(r.Code))         // 虛科目當月才加
                {
                    if (isCurrent) r.Add(money * dir);
                }
                else                                // 實科目在期限內都加  
                {
                    if (inDuration)
                        r.Add(money * dir);
                }
            }
        }


        void PostToAccount(string debit, string credit,decimal money,bool isCurrent,bool inDuration)
        {
            AccTitle r;
            // +++ 計算借方科目 +++
            int dir = 1;
            if (debit==null || debit.Length==0)
                r = null;
            else
                r = FindTitleByCode(debit, out dir);
            if (r != null)
            {
                if (IsVirtualTitle(r.Code))         // 虛科目當月才加
                {
                    if (isCurrent) r.Add(-money * dir);
                }
                else                                // 實科目在期限內都加  
                {
                    if (inDuration)
                        r.Add(-money * dir);
                }
            }
            // +++ 計算貸方科目 +++
            if (credit==null || credit.Length == 0)
                r = null;
            else
                r = FindTitleByCode(credit, out dir);
            if (r != null)
            {
                if (IsVirtualTitle(r.Code))         // 虛科目當月才加
                {
                    if (isCurrent) r.Add(money * dir);
                }
                else                                // 實科目在期限內都加  
                {
                    if (inDuration)
                        r.Add(money * dir);
                }
            }
        }


        void PostTo1Account(string title, decimal money, bool isDebt, bool isCurrent, bool inDuration)
        {
            
            
           
            if (title == null || title.Length == 0 ) return;
            int dir = 1;
            AccTitle r = FindTitleByCode(title, out dir);
            if (isDebt) dir *= -1;                  // 借方多乘負號
            if (r != null)
            {
                if (IsVirtualTitle(r.Code))         // 虛科目當月才加
                {
                    if (isCurrent) r.Add(money * dir);
                }
                else                                // 實科目在期限內都加  
                {
                    if (inDuration)
                        r.Add(money * dir);
                }
            }
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

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            if (box.SelectedIndex < 0 || box.SelectedIndex > 12) return;  // 0 全期
            int mon = box.SelectedIndex;
            box.Enabled = false;
            // 設定初值
            InitList();
            labelRevenue.Text = labelBalance.Text = labelCostSum.Text = labelExpenseSum.Text = "";
            Application.DoEvents();

            bool inDuration;
            bool isCurrent;
            #region  ======= 計算費用 =======
            Message("計算費用");
            foreach (VEDataSet.ExpenseRow ro in veDataSet1.Expense)
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
                isCurrent = IsCurrent(m1, mon);
                if (!inDuration && !isCurrent) continue;

                int bankID = 1;
                if (!ro.IsBankAccountIDNull())
                    bankID = ro.BankAccountID;
                string debitTitle, creditTitle;
                if (bankID == 1)  // 零用金戶 ,貸方一定是零用金, 資產項要累計
                {   // +++ 計算貸方科目 +++
                    creditTitle = null;
                    if (inDuration)                      // 期前的, 不用算實科目
                    {
                        BankDefault bank;
                        if (BankDictionary.TryGetValue(bankID, out bank))    // 如果沒有設定好銀行的TitleCode, 零用金會不平
                            creditTitle = bank.BankCode;
                    }
                    // +++ 計算借方科目 +++
                    if (ro.IsTitleCodeNull())
                         debitTitle = defaultExpense.Code;
                    else
                         debitTitle = ro.TitleCode;
                    PostToAccount(debitTitle, creditTitle, ro.Money, isCurrent, inDuration);
                }
                else  // 非零用金
                {
                    if (ro.IsTitleCodeNull())       debitTitle  = null;
                    else                            debitTitle  = ro.TitleCode;
                    if (ro.IsTitleCodeCreditNull()) creditTitle = null;
                    else                            creditTitle = ro.TitleCodeCredit;
                    PostToAccount(debitTitle, creditTitle, ro.Money, isCurrent, inDuration);
                }
            }


            #endregion
            #region ====== 計算轉帳傳票 ======
            Message("計算轉帳傳票");
            foreach (VEDataSet.AccVoucherRow ro in veDataSet1.AccVoucher)
            {
                if (ro.IsAccVoucherTimeNull()) continue;  
                if (ro.AccVoucherTime.Year != MyFunction.IntHeaderYear) continue;
                if (!ro.IsRemovedNull())
                    if (ro.Removed) continue;  //作癈的不計
                if (ro.RowState == DataRowState.Deleted)  continue;
                int m1 = ro.AccVoucherTime.Month;
                inDuration = InDuration(m1, mon);
                isCurrent = IsCurrent(m1, mon);
                if (!inDuration && !isCurrent) continue;
                if (!ro.IsTitleCode0Null() && (!ro.IsMoney0Null()))
                    PostTo1Account(ro.TitleCode0, ro.Money0, ro.IsDebt0, isCurrent, inDuration);
                if (!ro.IsTitleCode1Null() && (!ro.IsMoney1Null()))
                    PostTo1Account(ro.TitleCode1, ro.Money1, ro.IsDebt1, isCurrent, inDuration);
                if (!ro.IsTitleCode2Null() && (!ro.IsMoney2Null()))
                    PostTo1Account(ro.TitleCode2, ro.Money2, ro.IsDebt2, isCurrent, inDuration);
                if (!ro.IsTitleCode3Null() && (!ro.IsMoney3Null()))
                    PostTo1Account(ro.TitleCode3, ro.Money3, ro.IsDebt3, isCurrent, inDuration);
            }

            

            #endregion


            #region ======= 計算成本 =======
            Message("計算成本");
            decimal shouldPayTotal = 0;
            foreach (VEDataSet.VoucherRow ro in veDataSet1.Voucher)
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
                if (InDuration(m1,mon)) shouldPayTotal += ro.Cost;
                if (IsCurrent(m1,mon))
                {
                    foreach (VEDataSet.VoucherDetailRow r1 in ro.GetVoucherDetailRows())
                    {
                        AccTitle r;
                        if (r1.IsTitleCodeNull()) r = defaultCost;
                        else
                            r = Find(r1.TitleCode, NewCostList, defaultCost);
                        if (r != null && (!r1.IsCostNull()))
                            r.Add(r1.Cost);
                    }
                }
            }

            AccTitle shouldPay = Find(Setup.VoucherShouldPay , NewLiabilityList, defaultLiability);
            if (shouldPay != null)
                shouldPay.Add(shouldPayTotal);
            #endregion

 
            #region ====== 計算營業額 ======
            Message("計算營業額");
            AccTitle cash           = Find(Setup.CashIncome     , NewRevenueList, defaultIncome);
            AccTitle credit         = Find(Setup.CreditIncome   , NewRevenueList, defaultIncome);
            AccTitle cashReceivable = Find(Setup.CashReceivable , NewAssetList  , defaultAsset);
            AccTitle creditReceivable=Find(Setup.CreditReceivable,NewAssetList  , defaultAsset);
            MonthlyReportData total;
            for (int m1 = 1; m1 <= 12; m1++)
            {
                inDuration=InDuration(m1, mon);
                isCurrent = IsCurrent(m1, mon);
                if (!inDuration && !isCurrent) continue;
                total = CalcRevenue(m1);
                if (isCurrent)
                {
                    if (cash != null) cash.Add(total.Cash);
                    if (credit != null) credit.Add(total.CreditCard);
                }
                if (inDuration)
                {
                    if (cashReceivable != null) cashReceivable.Add(total.Cash);
                    if (creditReceivable != null) creditReceivable.Add(total.CreditCard);
                }
            }
            /*
            total = CalcRevenue(mon);         // 先算當月份
            if (cash != null) cash.Add(total.Cash);
            if (credit != null) credit.Add(total.CreditCard);
            if (mon >= MyFunction.IntHeaderMonth)
            {
                if (cashReceivable != null) cashReceivable.Add(total.Cash);
                if (creditReceivable != null) creditReceivable.Add(total.CreditCard);
                for (int m = mon - 1; m >= MyFunction.IntHeaderMonth; m--)
                {
                    total = CalcRevenue(m);
                    if (cashReceivable != null) cashReceivable.Add(total.Cash);
                    if (creditReceivable != null) creditReceivable.Add(total.CreditCard);
                }
            }
            */
            #endregion
//            MessageBox.Show("計算銀行前 1040 刷卡應付 " + creditReceivable.Money.ToString("N1"));
            #region ====== 計算銀行帳戶 ======
            Message("計算銀行帳戶");
            foreach (VEDataSet.BankDetailRow ro in veDataSet1.BankDetail.Rows)
            {
                if (ro.IsDayNull()) continue;
                if (ro.Day.Year != MyFunction.IntHeaderYear) continue;
                if (ro.IsMoneyNull()) continue;
                if (ro.RowState == DataRowState.Deleted)
                    continue;
                int m = ro.Day.Month;
                inDuration = InDuration(m ,mon);
                isCurrent = IsCurrent(m, mon);
                if (!inDuration && !isCurrent) continue;
                if (ro.IsBankIDNull()) continue;
                if (ro.BankID<=1) continue;  // 零用金不應存在此資料庫 
                string code;
                BankDefault bank;
                if (!BankDictionary.TryGetValue(ro.BankID, out bank)) continue;   // 找不到科目的銀行帳號
                bool isPay=false;
                if (ro.IsIsCreditNull()) isPay = true;
                else isPay = ro.IsCredit;
/*
                if (ro.Day.Month == 9 && ro.BankID == 3)
                {
                    int i = 0;
                    i++;
                }
*/
                if (ro.IsTitleCodeNull() || ro.TitleCode.Length == 0)             // 找到此帳戶預設的科目
                    code = bank.DefaultCode;
                else
                    code = ro.TitleCode;
                if (isPay)
                    PostToAccount(code, bank.BankCode, ro.Money, isCurrent, inDuration,bank.DefaultTitle);
                else
                    PostToAccount(bank.BankCode, code, ro.Money, isCurrent, inDuration,bank.DefaultTitle);
            }
            #endregion

            decimal sumExpense  = SumMarkPercentAndSort(NewExpenseList);
            decimal sumCost     = SumMarkPercentAndSort(NewCostList);
            decimal sumRevenue  = SumMarkPercentAndSort(NewRevenueList);
            decimal sumAsset    = SumMarkPercentAndSort(NewAssetList);
            decimal sumLiability= SumMarkPercentAndSort(NewLiabilityList);

            labelExpenseSum.Text = sumExpense.ToString("N1");
            labelCostSum.Text    = sumCost.ToString("N1");
            labelRevenue.Text    = sumRevenue.ToString("N1");
            labelBalance.Text    = (sumRevenue - sumExpense - sumCost).ToString("N1");
            labelAsset.Text      = sumAsset.ToString("N1");
            labelLiability.Text  = sumLiability.ToString("N1");
            labelEquity.Text     = (sumAsset - sumLiability).ToString("N1");

            AccTitle ownersEquity = Find(Setup.OwnersEquity, NewLiabilityList, null);
            if (ownersEquity != null)
            {
                labelLiability1.Text = (sumLiability - ownersEquity.Money).ToString("N1");
                labelEquity1.Text = (sumAsset - sumLiability + ownersEquity.Money).ToString("N1");
            }

            // ====== 設定DataGridView ======
            AssetList       = CleanList(NewAssetList);
            LiabilityList   = CleanList(NewLiabilityList);
            CostList        = CleanList(NewCostList);
            ExpenseList     = CleanList(NewExpenseList);
            RevenueList     = CleanList(NewRevenueList);
            SetDataFromIndex(accountingTableBindingSource1, comboBox1.SelectedIndex);
            SetDataFromIndex(accountingTableBindingSource2, comboBox2.SelectedIndex);
            Message("");

            box.Enabled = true;
        }

        List<AccTitle> CleanList(List<AccTitle> list)
        {
            for(int i=0;i<list.Count;)
            {
                AccTitle acc=list[i];
                if (acc.Money == 0)
                     list.RemoveAt(i);
                else i++;
            }
            return list;
        }


        RevenueCalc Revenue;

        private void ReportByTitle_Load(object sender, EventArgs e)
        {
            try
            {
                headerTableAdapter1.Connection = MapPath.BasicConnection;
                headerTableAdapter1.Fill(basicDataSet1.Header);
            }
            catch
            {
                MessageBox.Show("標頭資料讀取錯誤,你的資料庫版本可能不對");
            }
            int count = basicDataSet1.Header.Count;
            if (count == 0)
            {
                MessageBox.Show("無資料!");
                Close();
                return;
            }
            BasicDataSet.HeaderRow row = basicDataSet1.Header[count - 1];
            Revenue = new RevenueCalc(row.DataDate,0);
            AssetList     = new List<AccTitle>();
            LiabilityList = new List<AccTitle>();
            RevenueList   = new List<AccTitle>();
            ExpenseList   = new List<AccTitle>();
            CostList      = new List<AccTitle>();
            BankDictionary = new Dictionary<int, BankDefault>();
            RevenueCache = new MonthlyReportData[12];
            string[] Name = new string[5] { "資產", "負債", "收入", "成本", "費用" };
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            foreach (string str in Name)
            {
                comboBox1.Items.Add(str);
                comboBox2.Items.Add(str);
            }

            accountingTitleTableAdapter1.Connection = MapPath.VEConnection;
            bankAccountTableAdapter1.Connection     = MapPath.VEConnection;
            expenseTableAdapter1.Connection         = MapPath.VEConnection;
            voucherTableAdapter1.Connection         = MapPath.VEConnection;
            voucherDetailTableAdapter1.Connection   = MapPath.VEConnection;
            bankDetailTableAdapter1.Connection      = MapPath.VEConnection;
            accVoucherTableAdapter1.Connection      = MapPath.VEConnection;

            try
            {
                accountingTitleTableAdapter1.Fill(veDataSet1.AccountingTitle);
                bankAccountTableAdapter1.Fill(veDataSet1.BankAccount);
                expenseTableAdapter1.Fill(veDataSet1.Expense);    // expense檔案小,先全部讀進記憶體
                voucherTableAdapter1.Fill(veDataSet1.Voucher);
                voucherDetailTableAdapter1.Fill(veDataSet1.VoucherDetail);
                bankDetailTableAdapter1.Fill(veDataSet1.BankDetail);
                accVoucherTableAdapter1.Fill(veDataSet1.AccVoucher);
                foreach (VEDataSet.AccountingTitleRow r in veDataSet1.AccountingTitle.Rows)
                {
                    AccTitle item=new AccTitle(r.TitleCode,r.Name);
                    if (r.IsInitialValueNull())
                        item.Money = 0;
                    else 
                        item.Money = r.InitialValue;
                    if (r.TitleCode.Length == 0) continue;
                    char c=r.TitleCode[0];
                    switch(c)
                    {
                        case '1': AssetList.Add(item);      break;
                        case '2': LiabilityList.Add(item);  break;
                        case '4': RevenueList.Add(item);    break;
                        case '5': CostList.Add(item);       break;
                        case '6': ExpenseList.Add(item);    break;
                    }
                }
                AssetList1      = CopyTable(AssetList);
                LiabilityList1  = CopyTable(LiabilityList);
                RevenueList1    = CopyTable(RevenueList);
                CostList1       = CopyTable(CostList);
                ExpenseList1    = CopyTable(ExpenseList);

                foreach (VEDataSet.BankAccountRow r in veDataSet1.BankAccount.Rows)
                    BankDictionary.Add(r.ID,new BankDefault(r.AccountTitleCode,r.DefaultTitleCode));
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 1;
                comboBoxStart.SelectedIndex = MyFunction.IntHeaderMonth;
                Setup.Load();
                dataGridView1.Focus();
            }
            catch
            {
                MessageBox.Show("資料庫讀取錯誤!");
            }
        }

        MonthlyReportData CalcRevenue(int month)
        {
            int year = Revenue.Year;
            if (month < 1 || month > 12)
            {
                MessageBox.Show("所選月份不對!");
                return null;
            }
            Message("計算 " + month.ToString() + "月營業額");
            if (RevenueCache[month - 1] != null)
                return RevenueCache[month - 1];
            int count = MyFunction.DayCountOfMonth(month);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = count;
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            List<MonthlyReportData> list = new List<MonthlyReportData>();
            for (int i = 1; i <= count; i++)
            {
                if (Revenue.LoadData(basicDataSet1, year, month, i, true))
                    list.Add(Revenue.Statics(basicDataSet1));
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
            return total;
        }

        #region ====== PrintFunction ======
        int PageIndex = -1;
        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            PageIndex = 1;
        }

        Graphics m_Graphics = null;
        Font m_Font = null;
        Brush m_Brush = null;
        void PrintColumn(string str, int x, int y, DataGridViewColumn col)
        {
            DataGridViewContentAlignment alignment = col.DefaultCellStyle.Alignment;

            int width = col.Width;
            if (alignment == DataGridViewContentAlignment.BottomRight ||
                alignment == DataGridViewContentAlignment.MiddleRight ||
                alignment == DataGridViewContentAlignment.TopRight)
            {
                SizeF size = m_Graphics.MeasureString(str, m_Font);
                x += (int)(col.Width - size.Width);

            }
            m_Graphics.DrawString(str, m_Font, m_Brush, new PointF(x, y));
        }


        private void PrintOneTable(string title,DataGridView view,int height,int x1,int y,int ListNo)
        {
            string str;
            DataGridViewColumnCollection columns = view.Columns;
            y += height;
            int x = x1;
            m_Graphics.DrawString(title, m_Font, m_Brush, new PointF(x, y));
            y +=  height;
            for (int j = 1; j < columns.Count; j++)
            {
                DataGridViewColumn col = columns[j];
                str = col.HeaderText;
                PrintColumn(str, x, y, col);
                x += view.Columns[j].Width;
            }
            int max = ListNo;
            if (max > view.Rows.Count) max = view.Rows.Count;
            for (int i = 0; i < max; i++)
            {
                DataGridViewRow row = view.Rows[i];
                y += height;
                x = x1;
                for (int j = 1; j < columns.Count; j++)
                {
                    DataGridViewCell cell = row.Cells[j];
                    str = cell.FormattedValue.ToString();
                    PrintColumn(str, x, y, columns[j]);
                    x += columns[j].Width;
                }
            }
            if (view.Rows.Count > ListNo)   // 太長了,把後面加一加
            {
                y += height;
                x = x1;
                PrintColumn("其他", x, y, columns[1]);
                x += columns[1].Width;
                for (int j = 2; j < columns.Count; j++)    // 0 code 1 科目名,都跳過
                {
                    Type type = columns[j].ValueType;
                    if (type == typeof(decimal))
                    {
                        decimal dec = 0;
                        for (int i = ListNo; i < view.Rows.Count; i++)
                        {
                            DataGridViewCell cell = view.Rows[i].Cells[j];
                            dec += (decimal)cell.Value;
                        }
                        str = dec.ToString("f1");
                    }
                    else if (type == typeof(double))
                    {
                        double dou = 0;
                        for (int i = ListNo; i < view.Rows.Count; i++)
                        {
                            DataGridViewCell cell = view.Rows[i].Cells[j];
                            dou += (double)cell.Value;
                        }
                        str = dou.ToString("f1");
                    }
                    else str = "未知格式";
                    PrintColumn(str, x, y, columns[j]);
                    x += columns[j].Width;
                }
            }
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            const int LinePerPage = 40;
            m_Graphics = e.Graphics;
            PageSettings settings = e.PageSettings;
            Rectangle inner = e.MarginBounds;
            Rectangle outter = e.PageBounds;
            List<AccTitle> list = this.accountingTableBindingSource2.DataSource as List<AccTitle>;
            if (list == null || PageIndex <= 0)
            {
                e.HasMorePages = false;
                return;
            }
            DataGridView view = this.dataGridView2;
            e.HasMorePages = false;

            m_Font = new Font("細明體", 10.0f);
            m_Brush = SystemBrushes.WindowText;
            int height = inner.Height / LinePerPage;
            object save = dataGridView2.DataSource;

            int x = inner.Left;
            int y = inner.Top;
            dataGridView2.DataSource = RevenueList;
            PrintOneTable("   "+comboBoxMonth.Text+"收入總計    " + labelRevenue.Text, this.dataGridView2, height, x, y, 3);

            x = inner.Left;
            y = inner.Top+height*6;
            dataGridView2.DataSource = CostList;
            PrintOneTable("        成本總計    " + labelCostSum.Text   , this.dataGridView2, height,x,y,12);

            x = inner.Left+inner.Width/2;
            y = inner.Top+height*6;
            dataGridView2.DataSource = ExpenseList;
            PrintOneTable("        費用總計    " + labelExpenseSum.Text, this.dataGridView2, height, x, y,12);

            x = inner.Left;
            y = inner.Top + height * 22;
            m_Graphics.DrawLine(Pens.Black, x, y, inner.Right, y);

            y = inner.Top + height * 23;
            dataGridView2.DataSource = AssetList;
            PrintOneTable("        資產總計    " + labelAsset.Text, this.dataGridView2, height, x, y, 10);

            x = inner.Left + inner.Width / 2;
            y = inner.Top + height * 23;
            dataGridView2.DataSource = LiabilityList;
            PrintOneTable("        負債總計    " + labelLiability.Text, this.dataGridView2, height, x, y, 10);

            y = inner.Top+height*38;
            m_Graphics.DrawString("不計股東往來負債總計    " + labelLiability1.Text, m_Font, m_Brush, new PointF(x, y));
            m_Graphics.DrawString("      股東權益          " + labelEquity1.Text, m_Font, m_Brush, new PointF(inner.Left, y));
            m_Graphics.DrawString("      當期損益          " + labelBalance.Text, m_Font, m_Brush, new PointF(x, inner.Top+height*2));

            dataGridView2.DataSource = save;
        }

        private void printDocument_EndPrint(object sender, PrintEventArgs e)
        {
            PageIndex = -1;
        }

        private void btnPrintCost_Click(object sender, EventArgs e)
        {
            printDocument.PrinterSettings.PrintToFile = false;
            printDocument.Print();
        }
        #endregion 

        void SetDataFromIndex(BindingSource source, int index)
        {
            List<AccTitle> list = null;
            switch (index)
            {
                case 0: list = AssetList; break;
                case 1: list = LiabilityList; break;
                case 2: list = RevenueList; break;
                case 3: list = CostList; break;
                case 4: list = ExpenseList; break;
            }
            source.DataSource = list;
        }

        List<AccTitle> GetListFromIndex(int index)
        {
            switch (index)
            {
                case 0: return AssetList;
                case 1: return LiabilityList;
                case 2: return RevenueList;
                case 3: return CostList;
                case 4: return ExpenseList;
                default: return null;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box=sender as ComboBox;
            this.accountingTableBindingSource1.DataSource = GetListFromIndex(box.SelectedIndex);
            dataGridView1.Focus();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;
            this.accountingTableBindingSource2.DataSource = GetListFromIndex(box.SelectedIndex);
            dataGridView2.Focus();
        }

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView view = sender as DataGridView;
            DataGridViewColumn column=view.Columns[e.ColumnIndex];
            if (column.Name == "columnMoney1")
            {
                string str;
                switch (column.DefaultCellStyle.Format)
                {
                    case "N0": str = "N1";    break;
                    case "N1": str = "N2";  break;
                    default  : str = "N0";  break;
                }
                column.DefaultCellStyle.Format = str;
            }
        }

        private void dataGridView2_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView view = sender as DataGridView;
            DataGridViewColumn column = view.Columns[e.ColumnIndex];
            if (column.Name == "columnMoney2")
            {
                string str;
                switch (column.DefaultCellStyle.Format)
                {
                    case "N0": str = "N1"; break;
                    case "N1": str = "N2"; break;
                    default: str = "N0"; break;
                }
                column.DefaultCellStyle.Format = str;
            }

        }

        private void ReportByTitle_SizeChanged(object sender, EventArgs e)
        {
            int h = panel1.Top-dataGridView1.Top;
            dataGridView1.Height = dataGridView2.Height = h;
        }
    }
}