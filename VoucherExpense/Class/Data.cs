using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.ComponentModel;

namespace VoucherExpense
{
   
    public class AccTitle
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Money { get; set; }
        public double Percentage { get; set; }

        public AccTitle(string code, string name) { Code = code; Name = name; Clear(); }
        public void Clear() { Money = 0;  Percentage = 0; }
        public void Add(decimal n) 
        {
/*            
            if (Code=="1030")
            {
                int i = 0;
                i++;
            }
*/
            Money += n;
        }
    }

    public class CVendor
    {
        public int ID { get; set; }
    }


    // ReportByVender.cs使用來顯示, 其實沒有編修沒必要加 INotifyPropertyChanged
    public class CIngredient : INotifyPropertyChanged
    {
        int id;
        decimal vol;
        int orc;
        decimal toc;
        decimal unc;
        public int ID
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("ID"));
                }
            }
        }
        public decimal Volume   
        {
            get { return vol; }
            set 
            {
                if (vol != value)
                {
                    vol = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Volume"));
                }
            } 
        }
        public decimal TotalCost 
        {
            get { return toc; }
            set
            {
                if (toc != value)
                {
                    toc = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("TotalCost"));
                }
            } 

        }
        public decimal UnitCost  
        {
            get { return unc; }
            set
            {
                if (unc != value)
                {
                    unc = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("UnitCost"));
                }
            } 

        }
        public int OrderCount    
        {
            get { return orc; }
            set
            {
                if (orc != value)
                {
                    orc = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("OrderCount"));
                }
            } 

        }
        public CIngredient(int ID) { id = ID; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
 
    }


    public class CMonthlyPay1
    {
        int vid;
        int orc;
        decimal mon;
        public int VenderID { get { return vid; } set { vid = value; } }
        public int OrderCount { get { return orc; } set { orc = value; } }
        public decimal Money { get { return mon; } set { mon = value; } }
    }

    public class TitleSetup
    {
        public string DefaultAsset      { get; set; }
        public string DefualtLiability  { get; set; }
        public string DefaultOwnersEquity { get; set; }
        public string DefaultIncome     { get; set; }
        public string DefaultCost       { get; set; }
        public string DefaultExpense    { get; set; }
        public string VoucherShouldPay  { get; set; }
        public string CashIncome        { get; set; }
        public string CreditIncome      { get; set; }
        public string CashReceivable    { get; set; }
        public string CreditReceivable  { get; set; }
//        public string OwnersEquity      { get; set; }
        private decimal feeRate;
        public decimal FeeRate() { return feeRate; }
        public string CreditFeeRate     
        {
            get { return feeRate.ToString(); }
            set 
            {
                decimal rate;
                if (decimal.TryParse(value, out rate) == true)
                     feeRate = rate;
                else feeRate = 0;
            }
        } 
        public const string ConfigName = "DefaultTitle";
        public const string TableName = "ForBalanceSheet";
        Config Cfg = new Config();

        public TitleSetup()
        {
            DefaultAsset    ="100";
            DefualtLiability="200";
            DefaultOwnersEquity = "300";
            DefaultIncome   ="400";
            DefaultCost     ="500";
            DefaultExpense  ="600";
            VoucherShouldPay="203";
            CashIncome      ="403";
            CreditIncome    ="404";
            CashReceivable  ="1030";
            CreditReceivable="1040";
//            OwnersEquity    ="210";
            CreditFeeRate   = "1.8";
        }

        bool DoSetup(XmlNode root, string nodeName, ref string outValue)
        {
            XmlNode node;
            node = root.SelectSingleNode(nodeName);
            if (node != null)
            {
                outValue = node.InnerText;
                return true;
            }
            return false;
        }

        public void Load()
        {
            XmlNode root = Cfg.Load(ConfigName, TableName);
            if (root == null) return;
            string str = "";
            if (DoSetup(root, "DefaultAsset"    , ref str)) DefaultAsset = str;
            if (DoSetup(root, "DefaultLiability", ref str)) DefualtLiability = str;
            if (DoSetup(root, "DefaultOwnersEquity", ref str)) DefaultOwnersEquity = str;
            if (DoSetup(root, "DefaultIncome"   , ref str)) DefaultIncome = str;
            if (DoSetup(root, "DefaultCost"     , ref str)) DefaultCost = str;
            if (DoSetup(root, "DefaultExpense"  , ref str)) DefaultExpense = str;
            if (DoSetup(root, "CashReceivable"  , ref str)) CashReceivable = str;
            if (DoSetup(root, "CashIncome"      , ref str)) CashIncome = str;
            if (DoSetup(root, "CreditIncome"    , ref str)) CreditIncome = str;
            if (DoSetup(root, "CreditReceivable", ref str)) CreditReceivable = str;
            if (DoSetup(root, "VoucherShouldPay", ref str)) VoucherShouldPay = str;
//            if (DoSetup(root, "OwnersEquity"    , ref str)) OwnersEquity = str;
            if (DoSetup(root, "CreditFeeRate"   , ref str)) CreditFeeRate = str;
            
        }

        string AddSetup(string name, string value)
        {
            return "<" + name + ">" + value + "</" + name + ">";
        }

        public bool Save()
        {
            string content="<"+ConfigName+" Name=\""+TableName+"\">";
            content += AddSetup("DefaultAsset"      , DefaultAsset        );
            content += AddSetup("DefaultLiability"  , DefualtLiability    );
            content += AddSetup("DefaultOwnersEquity", DefaultOwnersEquity);
            content += AddSetup("DefaultIncome"     , DefaultIncome       );
            content += AddSetup("DefaultCost"       , DefaultCost         );
            content += AddSetup("DefaultExpense"    , DefaultExpense      );
            content += AddSetup("CashReceivable"    , CashReceivable      );
            content += AddSetup("CashIncome"        , CashIncome          );
            content += AddSetup("CreditIncome"      , CreditIncome        );
            content += AddSetup("CreditReceivable"  , CreditReceivable    );
            content += AddSetup("VoucherShouldPay"  , VoucherShouldPay    );
//            content += AddSetup("OwnersEquity"      , OwnersEquity        );
            content += AddSetup("CreditFeeRate"     , CreditFeeRate       );
            content += "</" + ConfigName + ">";
            if (Cfg.Save(ConfigName, TableName, content)) return true;
            else return false;
        }

    }

    //使用於FormImportBankExcel.cs
    public class CBankDetail:INotifyPropertyChanged
    {
        private DateTime dat;
        private decimal cre;
        private decimal deb;
        private string  not;
        public DateTime Date 
        {
            get { return dat; }
            set
            {
                if (dat != value)
                {
                    dat = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Date"));
                }
            }
        }
        public decimal Credit
        {
            get { return cre; }
            set
            {
                if (cre != value)
                {
                    cre = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Credit"));
                }
            }
        }
        public decimal Debt
        {
            get { return deb; }
            set
            {
                if (deb != value)
                {
                    deb = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Debt"));
                }
            }
        }
        public string Note
        {
            get { return not; }
            set
            {
                if (not != value)
                {
                    not = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Note"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
 
    }

    public class CBankAccountForComboBox
    {
        public string Name { set; get; }
        public int ID      { set; get; }
        public CBankAccountForComboBox()
        {
            Name = ""; ID = 0;
        }
    }

    // FormOnDutyEmployee有用到 Ingredient有用到
    public class CNameIDForComboBox
    {
        public string Name { set; get; }
        public int ID { set; get; }
        public CNameIDForComboBox()
        {
            Name = ""; ID = 0;
        }
        public CNameIDForComboBox(int id, string name)
        {
            ID = id; Name = name;
        }
        override public string ToString()
        {
            return Name;
        }
    }


    // 在 SaleSpend和 SoldProduct中使用
    public class CSaleItem  
    {
        public CSaleItem() { ProductID = 0; Volume = 0; }  // 必需有這行BindingSource才能AllowNew
        public CSaleItem(int productID) { ProductID = productID; Volume = 0; }
//        public int Code { get; set; }
        public int ProductID  { get; set; }
        public decimal Volume { get; set; }
        public decimal Price  { get; set; }
        public decimal EvaluatedCost { get; set; }
        public decimal TotalEvaluatedCost { get; set; }
        public decimal Total  { get; set; }
        public decimal GrossProfitRate { get; set; }

        public string Unit    { get; set; }
    }

    // BasicSoldSpend BakerySoldSpend使用
    public class CStockItem
    {
        public CStockItem() { IngredientID = 0; Volume = 0; }
        public CStockItem(int ingredient) { IngredientID = ingredient; Volume = 0; }
        public int IngredientID { get; set; }
        public decimal Volume { get; set; }
        public decimal TotalCost { get; set; }
        public decimal UnitCost { get; set; }
        public int OrderCount { get; set; }
    }

    // ReportByTitle.cs用
    public class CMonthBalance
    {
        public int Month { get; set; }
        public decimal Assest   { get; set; }
        public decimal Liability{ get; set; }
        public decimal Revenue  { get; set; }
        public decimal Cost     { get; set; }
        public decimal Expense  { get; set; }
        public decimal Balance  { get; set; }
        public void CalcBalance()
        {
            Balance=Revenue-Cost-Expense;
        }
        public void ClearData()
        {
            Assest = Liability = Revenue = Cost = Expense = Balance= 0m;
        }
        public void Add(CMonthBalance b)
        {
//            Assest += b.Assest;
//            Liability += b.Liability;
            Revenue += b.Revenue;
            Cost += b.Cost;
            Expense += b.Expense;
            Balance += b.Balance;
        }
    }  // End of class CMonthBalance

    // MonthlyReport及MonthlyReportBakery用
    public class MonthlyReportData
    {
        public uint    Date         { get; set; }
        public decimal Revenue      { get; set; }
        public decimal Cash         { get; set; }
        public decimal CreditCard   { get; set; }
        public decimal Coupond      { get; set; }
        public decimal Deduct       { get; set; }
        public decimal CreditFee    { get; set; }
        public decimal CreditNet    { get; set; }
        public int     OrderCount   { get; set; }
        public decimal AvePerPerson { get; set; }

        public int     DeletedCount { get; set; }
        public decimal DeletedMoney { get; set; }

        public int ReturnedCount     { get; set; }
        public decimal ReturnedMoney { get; set; }
    }

    public class CLedgerRow
    {
        public DateTime Date    { get; set; }
        public string   Note    { get; set; }
        public decimal  Debt    { get; set; }
        public decimal  Credit  { get; set; }
        public decimal  Sum     { get; set; }
        public string OthersideAccTitle  { get; set; }    // otherside account title, 存的是名字,不是TitleCode
    }


    public class BankDefault
    {
        public string BankCode;
        public string DefaultCode;
        public AccTitle DefaultTitle;
        public BankDefault(string bankCode, string defaultCode) { BankCode = bankCode; DefaultCode = defaultCode; }
    }

    public class CShiftCode
    {
        public char Code { get; set; }
        public string Note { get; set; }
        public int Hour { get; set; }
        public CShiftCode()
        {
            Code = ' '; Note = ""; Hour = 0;
        }
    }


}
