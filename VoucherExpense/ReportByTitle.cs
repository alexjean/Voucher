using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
#if UseSQLServer
using MyDataSet = VoucherExpense.DamaiDataSet;
using MyOrderSet = VoucherExpense.DamaiDataSet;
using MyHeaderAdapter = VoucherExpense.DamaiDataSetTableAdapters.HeaderTableAdapter;
#else
using MyDataSet = VoucherExpense.VEDataSet;
using MyOrderSet = VoucherExpense.BakeryOrderSet;
using MyHeaderAdapter = VoucherExpense.BakeryOrderSetTableAdapters.HeaderTableAdapter;
#endif

namespace VoucherExpense
{
    public partial class ReportByTitle : Form
    {
        AccTitleList AccList  = new AccTitleList();      // 顯示用  
        AccTitleList AccList1 = new AccTitleList();      // Copy有初值的空表用
        AccTitleList NewList;                            // 計算用

        Dictionary<int, BankDefault> BankDictionary;     // < BankAccountID, TitleCode>
        VoucherExpense.MonthlyReportData[] RevenueCache; // 計算加速用
        CMonthBalance[] MonthBalances;                   // 存月比較表用 
        TitleSetup Setup = new TitleSetup();

        public ReportByTitle()
        {
            InitializeComponent();
        }

        RevenueCalcBakery Revenue;
        MyDataSet m_DataSet = new MyDataSet();
        MyOrderSet m_OrderSet;
        private void ReportByTitle_Load(object sender, EventArgs e)
        {
            var headerAdapter = new MyHeaderAdapter();
#if (UseSQLServer)
            m_OrderSet = m_DataSet;
            var accTitleAdapter     = new VoucherExpense.DamaiDataSetTableAdapters.AccountingTitleTableAdapter();
            var bankAccountAdapter  = new VoucherExpense.DamaiDataSetTableAdapters.BankAccountTableAdapter();
            var expenseAdapter      = new VoucherExpense.DamaiDataSetTableAdapters.ExpenseTableAdapter();
            var voucherAdapter      = new VoucherExpense.DamaiDataSetTableAdapters.VoucherTableAdapter();
            var voucherDetailAdapter= new VoucherExpense.DamaiDataSetTableAdapters.VoucherDetailTableAdapter();
            var bankDetailAdapter   = new VoucherExpense.DamaiDataSetTableAdapters.BankDetailTableAdapter();
            var accVoucherAdapter   = new VoucherExpense.DamaiDataSetTableAdapters.AccVoucherTableAdapter();
#else
            m_OrderSet = new BakeryOrderSet();
            var accTitleAdapter     = new VoucherExpense.VEDataSetTableAdapters.AccountingTitleTableAdapter();
            var bankAccountAdapter  = new VoucherExpense.VEDataSetTableAdapters.BankAccountTableAdapter();
            var expenseAdapter      = new VoucherExpense.VEDataSetTableAdapters.ExpenseTableAdapter();
            var voucherAdapter      = new VoucherExpense.VEDataSetTableAdapters.VoucherTableAdapter();
            var voucherDetailAdapter= new VoucherExpense.VEDataSetTableAdapters.VoucherDetailTableAdapter();
            var bankDetailAdapter   = new VoucherExpense.VEDataSetTableAdapters.BankDetailTableAdapter();
            var accVoucherAdapter   = new VoucherExpense.VEDataSetTableAdapters.AccVoucherTableAdapter();
            headerAdapter.Connection          = MapPath.BakeryConnection;
            accTitleAdapter.Connection        = MapPath.VEConnection;
            bankAccountAdapter.Connection     = MapPath.VEConnection;
            expenseAdapter.Connection         = MapPath.VEConnection;
            voucherAdapter.Connection         = MapPath.VEConnection;
            voucherDetailAdapter.Connection   = MapPath.VEConnection;
            bankDetailAdapter.Connection      = MapPath.VEConnection;
            accVoucherAdapter.Connection      = MapPath.VEConnection;
#endif
            try
            {
                headerAdapter.Fill(m_OrderSet.Header);
            }
            catch { MessageBox.Show("標頭資料讀取錯誤,你的資料庫版本可能不對"); }
            int count = m_OrderSet.Header.Count;
            if (count == 0)
            {
                MessageBox.Show("無資料!");
                Close();
                return;
            }
            var row = m_OrderSet.Header[count - 1];
            Revenue = new RevenueCalcBakery(row.DataDate, 0);
            AccList.NewAll();
            BankDictionary = new Dictionary<int, BankDefault>();
            RevenueCache = new MonthlyReportData[12];
            MonthBalances = new CMonthBalance[13];
            for (int i = 0; i < 13; i++)
            {
                MonthBalances[i] = new CMonthBalance();
                MonthBalances[i].Month = i + 1;
            }
            MonthBalances[12].Month = 0;   // 第13月統計用
            cMonthBalanceBindingSource.DataSource = MonthBalances;
            string[] Name = new string[6] { "資產", "負債", "收入", "成本", "費用", "股東權益" };
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            foreach (string str in Name)
            {
                comboBox1.Items.Add(str);
                comboBox2.Items.Add(str);
            }
            try
            {
                accTitleAdapter.Fill    (m_DataSet.AccountingTitle);
                bankAccountAdapter.Fill (m_DataSet.BankAccount);
                expenseAdapter.Fill     (m_DataSet.Expense);    // expense檔案小,先全部讀進記憶體
                voucherAdapter.Fill     (m_DataSet.Voucher);
                voucherDetailAdapter.Fill(m_DataSet.VoucherDetail);
                bankDetailAdapter.Fill  (m_DataSet.BankDetail);
                accVoucherAdapter.Fill  (m_DataSet.AccVoucher);
                foreach (var r in m_DataSet.AccountingTitle)
                {
                    AccTitle item = new AccTitle(r.TitleCode, r.Name);
                    if (r.IsInitialValueNull())
                        item.Money = 0;
                    else
                        item.Money = r.InitialValue;
                    if (r.TitleCode.Length == 0) continue;
                    AccList.Add(item);
                }
                AccList1.CopyTableFrom(AccList);

                foreach (var r in m_DataSet.BankAccount)
                    BankDictionary.Add(r.ID, new BankDefault(r.AccountTitleCode, r.DefaultTitleCode));
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


        int CompareAccountingTable(AccTitle t1, AccTitle t2)
        {
            if (t1.Money > t2.Money) return -1;
            else if (t2.Money > t1.Money) return 1;
            return 0;
        }

        void InitList()
        {
            NewList = new AccTitleList();
            NewList.CopyTableFrom(AccList1);
            NewList.SetDefaultTitle(Setup.DefaultAsset, Setup.DefualtLiability, Setup.DefaultIncome, Setup.DefaultCost, Setup.DefaultExpense,Setup.DefaultOwnersEquity);
            foreach (KeyValuePair<int,BankDefault> pair in BankDictionary)
            {
                BankDefault bank=pair.Value;
                bank.DefaultTitle = AccTitleList.Find(bank.DefaultCode, NewList.Assets, NewList.defaultAsset);
            }
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
            foreach (var ro in m_DataSet.Expense)
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
                         debitTitle = NewList.defaultExpense.Code;
                    else
                         debitTitle = ro.TitleCode;
                    NewList.PostToAccount(debitTitle, creditTitle, ro.Money, isCurrent, inDuration);
                }
                else  // 非零用金
                {
                    if (ro.IsTitleCodeNull())       debitTitle  = null;
                    else                            debitTitle  = ro.TitleCode;
                    if (ro.IsTitleCodeCreditNull()) creditTitle = null;
                    else                            creditTitle = ro.TitleCodeCredit;
                    NewList.PostToAccount(debitTitle, creditTitle, ro.Money, isCurrent, inDuration);
                }
            }
            #endregion
            #region ====== 計算轉帳傳票 ======
            Message("計算轉帳傳票");
            foreach (var ro in m_DataSet.AccVoucher)
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
                    NewList.PostTo1Account(ro.TitleCode0, ro.Money0, ro.IsDebt0, isCurrent, inDuration);
                if (!ro.IsTitleCode1Null() && (!ro.IsMoney1Null()))
                    NewList.PostTo1Account(ro.TitleCode1, ro.Money1, ro.IsDebt1, isCurrent, inDuration);
                if (!ro.IsTitleCode2Null() && (!ro.IsMoney2Null()))
                    NewList.PostTo1Account(ro.TitleCode2, ro.Money2, ro.IsDebt2, isCurrent, inDuration);
                if (!ro.IsTitleCode3Null() && (!ro.IsMoney3Null()))
                    NewList.PostTo1Account(ro.TitleCode3, ro.Money3, ro.IsDebt3, isCurrent, inDuration);
            }
            #endregion

            #region ======= 計算成本 =======
            // 在付款總表裏是每個月都被4捨5入至小數第一位,所以要分12個月,進位後再加
            Message("計算成本");
            decimal[] shouldPayMonth = new decimal[13];    // index0不用,以加快運算速度
            foreach (var ro in m_DataSet.Voucher)
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
                if (InDuration(m1,mon)) shouldPayMonth[m1] += ro.Cost;
                if (IsCurrent(m1,mon))  // 加總到每個成本科目去 
                {
                    foreach (var r1 in ro.GetVoucherDetailRows())
                    {
                        AccTitle r;
                        if (r1.IsTitleCodeNull()) r = NewList.defaultCost;
                        else
                            r = AccTitleList.Find(r1.TitleCode, NewList.Costs, NewList.defaultCost);
                        if (r != null && (!r1.IsCostNull()))
                            r.Add(r1.Cost);
                    }
                }
            }

            decimal shouldPayTotal = 0;
            for (int i = 1; i <= 12; i++)
                shouldPayTotal += System.Math.Round(shouldPayMonth[i], 1);  // 應付貨款只精確到小數第一位,每個月進位
            AccTitle shouldPay = AccTitleList.Find(Setup.VoucherShouldPay, NewList.Liabilitys, NewList.defaultLiability);
            if (shouldPay != null)
                shouldPay.Add(shouldPayTotal);
            #endregion

 
            #region ====== 計算營業額 ======
            Message("計算營業額");
            AccTitle cash               = AccTitleList.Find(Setup.CashIncome     , NewList.Revenues, NewList.defaultIncome);
            AccTitle credit             = AccTitleList.Find(Setup.CardIncome   , NewList.Revenues, NewList.defaultIncome);
            AccTitle cashReceivable     = AccTitleList.Find(Setup.CashReceivable , NewList.Assets  , NewList.defaultAsset);
            AccTitle creditReceivable   = AccTitleList.Find(Setup.CardReceivable,NewList.Assets  , NewList.defaultAsset);
            MonthlyReportData total;
            for (int m1 = 1; m1 <= 12; m1++)
            {
                inDuration=InDuration(m1, mon);
                isCurrent = IsCurrent(m1, mon);
                if (!inDuration && !isCurrent) continue;
                total = CalcRevenue(m1);
                if (isCurrent)
                {
                    if (cash   != null) cash.Add  (total.Cash);
                    if (credit != null) credit.Add(total.CreditCard);
                }
                if (inDuration)
                {
                    if (cashReceivable   != null) cashReceivable.Add  (total.Cash);
                    if (creditReceivable != null) creditReceivable.Add(total.CreditCard);
                }
            }

            #endregion
//            MessageBox.Show("計算銀行前 1040 刷卡應付 " + creditReceivable.Money.ToString("N1"));
            #region ====== 計算銀行帳戶 ======
            Message("計算銀行帳戶");
            foreach (var ro in m_DataSet.BankDetail)
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

                if (ro.IsTitleCodeNull() || ro.TitleCode.Length == 0)             // 找到此帳戶預設的科目
                    code = bank.DefaultCode;
                else
                    code = ro.TitleCode;
                if (isPay)
                    NewList.PostToAccount(code, bank.BankCode, ro.Money, isCurrent, inDuration,bank.DefaultTitle);
                else
                    NewList.PostToAccount(bank.BankCode, code, ro.Money, isCurrent, inDuration,bank.DefaultTitle);
            }
            #endregion

            // 設定顯示Label
            decimal sumExpense   = SumMarkPercentAndSort(NewList.Expenses);
            decimal sumCost      = SumMarkPercentAndSort(NewList.Costs);
            decimal sumRevenue   = SumMarkPercentAndSort(NewList.Revenues);
            decimal sumAsset     = SumMarkPercentAndSort(NewList.Assets);
            decimal sumLiability = SumMarkPercentAndSort(NewList.Liabilitys);
            decimal sumOwnersEquity = SumMarkPercentAndSort(NewList.OwnersEquity);

            labelExpenseSum.Text = sumExpense.ToString("N1");
            labelCostSum.Text    = sumCost.ToString("N1");
            labelRevenue.Text    = sumRevenue.ToString("N1");
            labelBalance.Text    = (sumRevenue - sumExpense - sumCost).ToString("N1");
            labelAsset.Text      = sumAsset.ToString("N1");
            labelLiability.Text  = sumLiability.ToString("N1");
            labelEquity.Text     = (sumAsset - sumLiability).ToString("N1");
            labelOwnersEquity.Text = sumOwnersEquity.ToString("N1");

            //AccTitle ownersEquity = AccTitleList.Find(Setup.OwnersEquity, NewList.Liabilitys, null);
            //if (ownersEquity != null)
            //{
            //    labelLiability1.Text = (sumLiability - ownersEquity.Money).ToString("N1");
            //    labelOwnersEquity.Text = (sumAsset - sumLiability + ownersEquity.Money).ToString("N1");
//            }

            // 設定月對照表
            if (mon!=0)
            {
                CMonthBalance b = MonthBalances[mon - 1];
                b.Assest    = sumAsset;
                b.Liability = sumLiability;
                b.Cost      = sumCost;
                b.Revenue   = sumRevenue;
                b.Expense   = sumExpense;
                b.CalcBalance();
                CMonthBalance sum=MonthBalances[12];
                sum.ClearData();
                for (int i = 0; i < 12; i++)
                    sum.Add(MonthBalances[i]);

                cMonthBalanceBindingSource.ResetBindings(false);
            }
            // ====== 設定DataGridView ======
            AccList.CleanListFrom(NewList);
            accountingTableBindingSource1.DataSource = AccList[comboBox1.SelectedIndex];
            accountingTableBindingSource2.DataSource = AccList[comboBox2.SelectedIndex];
            Message("");

            box.Enabled = true;
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
                if (Revenue.LoadData(m_OrderSet, month, i)) list.Add(Revenue.Statics(m_OrderSet));
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
            dataGridView2.DataSource = AccList.Revenues;
            PrintOneTable("   "+comboBoxMonth.Text+"收入總計    " + labelRevenue.Text, this.dataGridView2, height, x, y, 3);

            x = inner.Left;
            y = inner.Top+height*6;
            dataGridView2.DataSource = AccList.Costs;
            PrintOneTable("        成本總計    " + labelCostSum.Text   , this.dataGridView2, height,x,y,12);

            x = inner.Left+inner.Width/2;
            y = inner.Top+height*6;
            dataGridView2.DataSource = AccList.Expenses;
            PrintOneTable("        費用總計    " + labelExpenseSum.Text, this.dataGridView2, height, x, y,12);

            x = inner.Left;
            y = inner.Top + height * 22;
            m_Graphics.DrawLine(Pens.Black, x, y, inner.Right, y);

            y = inner.Top + height * 23;
            dataGridView2.DataSource = AccList.Assets;
            PrintOneTable("        資產總計    " + labelAsset.Text, this.dataGridView2, height, x, y, 10);

            x = inner.Left + inner.Width / 2;
            y = inner.Top + height * 23;
            dataGridView2.DataSource = AccList.Liabilitys;
            PrintOneTable("        負債總計    " + labelLiability.Text, this.dataGridView2, height, x, y, 10);

            y = inner.Top+height*38;
//            m_Graphics.DrawString("不計股東往來負債總計    " + labelLiability1.Text, m_Font, m_Brush, new PointF(x, y));
            m_Graphics.DrawString("      股東權益          " + labelOwnersEquity.Text, m_Font, m_Brush, new PointF(inner.Left, y));
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box=sender as ComboBox;
            this.accountingTableBindingSource1.DataSource = AccList[box.SelectedIndex];
            dataGridView1.Focus();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;
            this.accountingTableBindingSource2.DataSource = AccList[box.SelectedIndex];
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = sender as CheckBox;
            if (box.Checked)
            {
                comboBox2.Visible= dataGridView2.Visible = false;
                dataGridView3.Visible = true;
            }
            else
            {
                comboBox2.Visible = dataGridView2.Visible = true;
                dataGridView3.Visible = false;
            }
        }

  
    }
}