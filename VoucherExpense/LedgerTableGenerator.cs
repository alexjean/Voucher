using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace VoucherExpense
{
    delegate MonthlyReportData CalcRevenueDelegate(int month, out List<MonthlyReportData> reportList);
    // vEDataSet1 必需載入
    // AccountingTitle, BankAccount,Ingredient
    // Expense,Voucher, VoucherDetail
    // BankDetail,AccVoucher,Vendor
    class LedgerTableGenerator
    {
        Label LabelMessage;
        AccTitleList NewList;
        Dictionary<int, BankDefault> BankDictionary;
        string SelectedTitleCode;
        TitleSetup Setup;
        VEDataSet vEDataSet;
        CalcRevenueDelegate CalcRevenue;

        // 和TitleCode比較相同就加
        decimal TitleSum = 0;  // 實科目算期初值用的
        int Direction = 1; // 借方科目Direction -1 ,貸方科目Direction 1
        List<CLedgerRow> LedgerTable;
        

        public LedgerTableGenerator(Label labelMsg, TitleSetup setup, VEDataSet vEDataSet1, CalcRevenueDelegate calcRevenue)
        {
            LabelMessage = labelMsg;
            Setup = setup;
            vEDataSet = vEDataSet1;
            CalcRevenue = calcRevenue;
        }

        void Message(string msg)
        {
            LabelMessage.Text = msg;
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


        // othersideTitle第一個數字,就當TitleCode找出科目名字,要不然就直接填
        bool AddIfWant(DateTime date, string titleCode, string note, decimal money, bool isDebt, bool isCurrent, bool inDuration, string othersideTitle)
        {
            if (titleCode != SelectedTitleCode) return false;
            if (!AccTitleList.IsVirtualTitle(titleCode))
                if (!isCurrent && inDuration)                    // 要得期初值,所以isCurrent不要
                {
                    if (isDebt) TitleSum -= (money * Direction);   
                    else        TitleSum += (money * Direction);
                }
            if (!isCurrent) return true; // 不是本期的
            CLedgerRow row = new CLedgerRow();
            row.Date = date;
            if (isDebt) { row.Debt = money; row.Credit = 0; }
            else { row.Debt = 0; row.Credit = money; }
            row.Note = note.TrimEnd();            // row.sum最後再一起算
            string titleName = "";
            if (othersideTitle != null)
            {
                if (char.IsDigit(othersideTitle[0]))
                {
                    int tmp;
                    AccTitle t = NewList.FindTitleByCode(othersideTitle, out tmp);
                    if (t != null) titleName = t.Name;
                }
                else
                    titleName = othersideTitle;
            }
            row.OthersideAccTitle = titleName;
            LedgerTable.Add(row);
            return true;
        }

        AccTitleList InitList(AccTitleList sourceList)
        {
            AccTitleList List4Calc = new AccTitleList();
            List4Calc.CopyTableFrom(sourceList);
            List4Calc.defaultCost = AccTitleList.Find(Setup.DefaultCost, List4Calc.Costs, null);
            List4Calc.defaultExpense = AccTitleList.Find(Setup.DefaultExpense, List4Calc.Expenses, null);
            List4Calc.defaultIncome = AccTitleList.Find(Setup.DefaultIncome, List4Calc.Revenues, null);
            List4Calc.defaultAsset = AccTitleList.Find(Setup.DefaultAsset, List4Calc.Assets, null);
            List4Calc.defaultLiability = AccTitleList.Find(Setup.DefualtLiability, List4Calc.Liabilitys, null);
            BankDictionary = new Dictionary<int, BankDefault>();
            foreach (VEDataSet.BankAccountRow r in vEDataSet.BankAccount.Rows)
                BankDictionary.Add(r.ID, new BankDefault(r.AccountTitleCode, r.DefaultTitleCode));
            foreach (KeyValuePair<int, BankDefault> pair in BankDictionary)
            {
                BankDefault bank = pair.Value;
                bank.DefaultTitle = AccTitleList.Find(bank.DefaultCode, List4Calc.Assets, List4Calc.defaultAsset);
            }
            return List4Calc;
        }


        class AccTemp
        {
            public string Code;
            public decimal Money;
            public bool IsDebt;
            public AccTemp(string code, decimal money, bool isDebt) { Code = code; Money = money; IsDebt = isDebt; }
        }


        public List<CLedgerRow> CreateTable(int mon, string selectedTitleCode, AccTitleList sourceList)
        {
            SelectedTitleCode = selectedTitleCode;
            LedgerTable = new List<CLedgerRow>();
            NewList = InitList(sourceList);
            AccTitle selected = NewList.FindTitleByCode(selectedTitleCode, out Direction);
            if (selected == null)
            {
                MessageBox.Show("所選的科目<" + selectedTitleCode + "> 在會計科目表找不到!");
                return null;
            }
            TitleSum = selected.Money;  // 年度初值
            bool inDuration;
            bool isCurrent;
            //#region ====== 股東權益======
            //AccTitle ownersEquity = AccTitleList.Find(Setup.DefaultOwnersEquity, NewList.Liabilitys, null);
            //if (ownersEquity != null)
            //{
            //    if (ownersEquity.Code == selectedTitleCode)
            //    {
            //        MessageBox.Show("什麼都和股東權益有關,沒有分類帳! 請看損益表");
            //        return null;
            //    }
            //}
            //#endregion

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
                        return null;
                    }
                    // +++ 計算借方科目 +++
                    if (ro.IsTitleCodeNull())
                        debitTitle = NewList.defaultExpense.Code;
                    else
                        debitTitle = ro.TitleCode;
                    //NewList.PostToAccount(debitTitle, creditTitle, ro.Money, isCurrent, inDuration);
                    AddIfWant(ro.ApplyTime, debitTitle, ro.Note, ro.Money, true, isCurrent, inDuration, creditTitle);
                    AddIfWant(ro.ApplyTime, creditTitle, ro.Note, ro.Money, false, isCurrent, inDuration, debitTitle);
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
                    AddIfWant(ro.ApplyTime, debitTitle, note, ro.Money, true, isCurrent, inDuration, creditTitle);
                    AddIfWant(ro.ApplyTime, creditTitle, note, ro.Money, false, isCurrent, inDuration, debitTitle);
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

                string othersideAccTitle = "<傳票" + ro.ID.ToString() + ">";   // 第一個不是數字,就直接顯示
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
                    foreach (AccTemp ac in temp)
                        AddIfWant(ro.AccVoucherTime, ac.Code, note, ac.Money, ac.IsDebt, isCurrent, inDuration, othersideAccTitle);
                }
            }
            #endregion

            #region ======= 計算成本 =======
            // 在付款總表裏是每個月都被4捨5入至小數第一位,所以要分12個月,進位後再加
            Message("計算成本");
            decimal[] shouldPayMonth = new decimal[13];    // index0不用,以加快運算速度
            AccTitle shouldPay = AccTitleList.Find(Setup.VoucherShouldPay, NewList.Liabilitys, NewList.defaultLiability);
            if (shouldPay == null)
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
                string vendorName = "";
                string sID = ro.ID.ToString();
                if (ro.VendorRow != null)
                    vendorName = ro.VendorRow.Name;
                if (inDuration)
                {
                    shouldPayMonth[m1] += ro.Cost;
                    if (shouldPay.Code == selectedTitleCode)            // 先檢查下不浪費找SubRow時間
                    {
                        string note = vendorName;     // 應付帳款,note放廠商名 ,對立科目放貨單号
                        AddIfWant(ro.StockTime, shouldPay.Code, note, ro.Cost, false, isCurrent, inDuration, "<貨單" + sID + ">");
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
                            if (r.Code == selectedTitleCode)          // 要找SubRow費時,先檢查一下  
                            {
                                string note = "<" + ro.ID.ToString("d4") + "> ";
                                VEDataSet.IngredientRow ingredient = r1.IngredientRow;
                                if (ingredient != null && (!ingredient.IsNameNull()))
                                    note += r1.IngredientRow.Name;
                                if (!r1.IsVolumeNull())
                                    note += "  " + r1.Volume.ToString();
                                if (ingredient != null && (!ingredient.IsUnitNull()))
                                    note += ingredient.Unit;

                                AddIfWant(ro.StockTime, r.Code, note, r1.Cost, true, isCurrent, inDuration, shouldPay.Name + "--" + vendorName);
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
            AccTitle cashIncome = AccTitleList.Find(Setup.CashIncome, NewList.Revenues, NewList.defaultIncome);     // 營收 現金
            AccTitle creditIncome = AccTitleList.Find(Setup.CreditIncome, NewList.Revenues, NewList.defaultIncome); // 營收 刷卡
            AccTitle cashReceivable = AccTitleList.Find(Setup.CashReceivable, NewList.Assets, NewList.defaultAsset);
            AccTitle creditReceivable = AccTitleList.Find(Setup.CreditReceivable, NewList.Assets, NewList.defaultAsset);
            MonthlyReportData total;
            // 算營業額很耗時, 先檢查是不是要的.分類帳要有每一天營收,要抓CalcRevenue內資料 
            if ((selectedTitleCode == cashIncome.Code) || (selectedTitleCode == creditIncome.Code) || (selectedTitleCode == cashReceivable.Code) || (selectedTitleCode == creditReceivable.Code))
                for (int m1 = 1; m1 <= 12; m1++)
                {
                    inDuration = InDuration(m1, mon);
                    if (!inDuration) continue;
                    isCurrent = IsCurrent(m1, mon);
                    List<MonthlyReportData> list;
                    total = CalcRevenue(m1, out list);
                    foreach (MonthlyReportData report in list)
                    {
                        DateTime da = report.Date;
                        string note = da.Month.ToString() + "月" + da.Day.ToString() + "日 ";
                        if (report.Cash != 0m)
                        {
                            AddIfWant(da, cashIncome.Code    , cashIncome.Name + note    , report.Cash, false, isCurrent, inDuration, cashReceivable.Code);
                            AddIfWant(da, cashReceivable.Code, cashReceivable.Name + note, report.Cash, true , isCurrent, inDuration, cashIncome.Code);
                        }
                        if (report.CreditCard != 0m)
                        {
                            AddIfWant(da, creditIncome.Code     , creditIncome.Name + note    , report.CreditCard, false, isCurrent, inDuration, creditReceivable.Code);
                            AddIfWant(da, creditReceivable.Code , creditReceivable.Name + note, report.CreditCard, true , isCurrent, inDuration, creditIncome.Code);
                        }
                    }
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
                if (ro.IsMoneyNull() || ro.Money == 0m) continue;
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
                AddIfWant(ro.Day, code, note, ro.Money, isPay, isCurrent, inDuration, bank.BankCode);
                AddIfWant(ro.Day, bank.BankCode, note, ro.Money, !isPay, isCurrent, inDuration, code);
            }
            #endregion
            Comparison<CLedgerRow> compare = new Comparison<CLedgerRow>(CompareDate);
            LedgerTable.Sort(compare);
            bool isDebtTitle = AccTitleList.IsDebtTitle(selectedTitleCode);
            if (!AccTitleList.IsVirtualTitle(selectedTitleCode))    // 實科目有期初值,插入一行
            {
                CLedgerRow row = new CLedgerRow();
                int month = mon;
                if (month < 1 || month > 12) month = 1;
                row.Date = new DateTime(MyFunction.IntHeaderYear, month, 1);
                row.Note = "期初值";
                if (TitleSum >= 0)
                {
                    if (isDebtTitle) { row.Debt = TitleSum; row.Credit = 0; }
                    else { row.Debt = 0; row.Credit = TitleSum; }
                }
                else
                {
                    if (isDebtTitle) { row.Debt = 0; row.Credit = -TitleSum; }
                    else { row.Debt = -TitleSum; row.Credit = 0; }
                }
                LedgerTable.Insert(0, row);
            }
            decimal sum = 0;
            foreach (CLedgerRow r in LedgerTable)
            {
                if (isDebtTitle) sum = sum - r.Credit + r.Debt;
                else sum = sum + r.Credit - r.Debt;
                r.Sum = sum;
            }
            Message("");
            return LedgerTable;
        }

        int CompareDate(CLedgerRow r1, CLedgerRow r2)
        {
            DateTime t1 = r1.Date.Date;
            DateTime t2 = r2.Date.Date;
            if (t1 > t2) return 1;
            if (t1 < t2) return -1;
            return 0;
        }
    }
}
