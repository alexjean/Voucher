using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VoucherExpense
{
    class AccTitleList
    {
        public List<AccTitle> Assets;       // 會計科目1字頭 資產
        public List<AccTitle> Liabilitys;   // 會計科目2字頭 負債
        public List<AccTitle> Revenues;     // 會計科目4字頭 營收
        public List<AccTitle> Costs;        // 會計科目5字頭 成本
        public List<AccTitle> Expenses;     // 會計科目6字頭 費用
        public AccTitle defaultCost;
        public AccTitle defaultExpense;
        public AccTitle defaultIncome;
        public AccTitle defaultAsset;
        public AccTitle defaultLiability;

        const int ListCount = 5;
        public List<AccTitle> this[int i]
        { 
            get 
            {  
                switch (i)
                {
                    case 0: return Assets;
                    case 1: return Liabilitys;
                    case 2: return Revenues;
                    case 3: return Costs;
                    case 4: return Expenses;
                    default: return null;
                }
            }
            set
            {
                switch (i)
                {
                    case 0: Assets      = value; break;
                    case 1: Liabilitys  = value; break;
                    case 2: Revenues    = value; break;
                    case 3: Costs       = value; break;
                    case 4: Expenses    = value; break;
                }
            }
        }
        string[] tableName = new string[5] { "資產", "負債", "收入", "成本", "費用" };
        public string TableName(int i)
        {
            if (i < 0 || i >= ListCount) return "";
            return tableName[i];
        }
        public void NewAll()
        {
            for (int i = 0; i < ListCount; i++)
                this[i] = new List<AccTitle>();
        }

        List<AccTitle> CopyTable(List<AccTitle> list)
        {
            List<AccTitle> newList = new List<AccTitle>();
            foreach (AccTitle r in list)  // 從空的表Copy過來
            {
                AccTitle item = new AccTitle(r.Code, r.Name);
                item.Money = r.Money;     // 設定初值 
                newList.Add(item);
            }
            return newList;
        }
        public void CopyTableFrom(AccTitleList source)
        {
            for (int i = 0; i < ListCount; i++)
                this[i] = CopyTable(source[i]);
        }

        List<AccTitle> CleanList(List<AccTitle> list)
        {
            for (int i = 0; i < list.Count; )
            {
                AccTitle acc = list[i];
                if (acc.Money == 0)
                    list.RemoveAt(i);
                else i++;
            }
            return list;
        }
        public void CleanListFrom(AccTitleList source)
        {
            for (int i = 0; i < ListCount; i++)
                this[i] = CleanList(source[i]);
        }

        public void SetDefaultTitle(string asset,string liability,string income,string cost,string expense)
        {
            defaultAsset      = Find(asset      , Assets    , null);
            defaultLiability  = Find(liability  , Liabilitys, null);
            defaultIncome     = Find(income     , Revenues  , null);
            defaultCost       = Find(cost       , Costs     , null);
            defaultExpense    = Find(expense    , Expenses  , null);
        }

        public void Add(AccTitle item)
        {
            if (item == null) return;
            if (item.Code == null) return;
            if (item.Code.Length == 0) return;
            char c = item.Code[0];
            switch (c)
            {
                case '1': Assets.Add(item); break;
                case '2': Liabilitys.Add(item); break;
                case '4': Revenues.Add(item); break;
                case '5': Costs.Add(item); break;
                case '6': Expenses.Add(item); break;
            }
        }

        static public AccTitle Find(string code, List<AccTitle> table, AccTitle defaultTitle)
        {
            foreach (AccTitle r in table)
            {
                if (code == r.Code) return r;
            }
            return defaultTitle;
        }


        public AccTitle FindTitleByCode(string code, out int credit)
        {
            AccTitle r;
            switch (code[0])
            {
                case '1': r = Find(code, Assets     , defaultAsset);    credit = -1; break;
                case '2': r = Find(code, Liabilitys , defaultLiability); credit = 1; break;
                case '4': r = Find(code, Revenues   , defaultIncome);   credit = 1; break;
                case '5': r = Find(code, Costs      , defaultCost);     credit = -1; break;
                case '6': r = Find(code, Expenses   , defaultExpense);  credit = -1; break;
                default: credit = 1; return null;
            }
            return r;
        }

        AccTitle FindTitleByCodeWithDefault(string code, AccTitle defaultTitle, out int credit)
        {
            AccTitle r;
            switch (code[0])
            {
                case '1': r = Find(code, Assets     , defaultTitle); break;
                case '2': r = Find(code, Liabilitys , defaultTitle); break;
                case '4': r = Find(code, Revenues   , defaultTitle); break;
                case '5': r = Find(code, Costs      , defaultTitle); break;
                case '6': r = Find(code, Expenses   , defaultTitle); break;
                default: credit = 0; return null;
            }
            switch (r.Code[0])
            {
                case '1': credit = -1; break;
                case '2': credit = 1; break;
                case '4': credit = 1; break;
                case '5': credit = -1; break;
                case '6': credit = -1; break;
                default: credit = 0; break;
            }
            return r;
        }

        public static bool IsVirtualTitle(string code)
        {
            if (code == null) return true;
            if (code.Length == 0) return true;
            char c = code[0];
            if (c == '6') return true;
            if (c == '5') return true;
            if (c == '4') return true;
            return false;
        }

        public static bool IsDebtTitle(string code)
        {
            if (code == null) return false;
            if (code.Length == 0) return false;
            char c = code[0];
            if (c == '1') return true;
            if (c == '5') return true;
            if (c == '6') return true;
            return false;
        }

        public void PostToAccount(string debit, string credit, decimal money, bool isCurrent, bool inDuration, AccTitle defaultTitle)
        {
            AccTitle r;
            // +++ 計算借方科目 +++
            int dir = 1;
            r = FindTitleByCodeWithDefault(debit, defaultTitle, out dir);
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
            r = FindTitleByCodeWithDefault(credit, defaultTitle, out dir);
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


        public void PostToAccount(string debit, string credit, decimal money, bool isCurrent, bool inDuration)
        {
            AccTitle r;
            // +++ 計算借方科目 +++
            int dir = 1;
            if (debit == null || debit.Length == 0)
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
            if (credit == null || credit.Length == 0)
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

        public void PostTo1Account(string title, decimal money, bool isDebt, bool isCurrent, bool inDuration)
        {
            if (title == null || title.Length == 0) return;
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
    }
}
