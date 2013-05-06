using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace VoucherExpense
{
    public partial class FormInitNewYear : Form
    {
        public FormInitNewYear()
        {
            InitializeComponent();
        }

        List<string> GetTableName(DataSet ds)
        {
            List<string> list = new List<string>();
            foreach (DataTable table in ds.Tables)
                list.Add(table.TableName);
            return list;
        }

        string m_Dir ;
        int m_Year;
        private void FormInitNewYear_Load(object sender, EventArgs e)
        {
            try
            {
                voucherHeaderAdapter.Connection = MapPath.VEConnection;
                voucherHeaderAdapter.Fill(veDataSet1.Header);
            }
            catch
            {
                MessageBox.Show("標頭資料讀取錯誤,你的資料庫版本可能不對");
                Close();
                return;
            }
            int count = veDataSet1.Header.Rows.Count;
            string path = Application.ExecutablePath;
            int len = path.Length;
            if (path[len - 1] == '\\')     path = path.Substring(0, len - 1);      // 去掉最後面的 \
            len = path.LastIndexOf('\\');
            if (len > 0)                   path = path.Substring(0, len);          // 取路
            DateTime dt = DateTime.Now;
            if (count != 0)
            {
                VEDataSet.HeaderRow row = (VEDataSet.HeaderRow)veDataSet1.Header.Rows[count - 1]; // 沒指定用最後一個
                dt = row.DataYear;
            }
            m_Year=dt.Year+1;
            labelYear.Text = "原資料年是 " + dt.Year.ToString() + " 將啟始"+m_Year.ToString()+"年資料";
            labelNote.Text = "起始資料將被放在 " + System.Net.Dns.GetHostName() + "的";
            m_Dir = path + "\\Manage" + m_Year.ToString();
            labelPath.Text = m_Dir;
#if (Define_Bakery)            
            List<string> list1=GetTableName(bakeryOrderSet1);
#else
            List<string> list1=GetTableName(basicDataSet1);
#endif
            foreach (string s in list1)
            {
                if (s == "Header") continue;      // Header要特殊處理
                if (ReservedTable.Contains(s))
                    chListBoxBasic.Items.Add(s,true);
                else
                    chListBoxBasic.Items.Add(s, false);
            }
            List<string> list2 = GetTableName(veDataSet1);
            foreach (string s in list2)
            {
                if (s == "Header") continue;      // Header要特殊處理
                if (ReservedTable.Contains(s))
                    chListBoxVE.Items.Add(s,true);
                else
                    chListBoxVE.Items.Add(s,false);
            }
        }
        // 二個資料庫除了Header沒有同名的,所以放在一起了
        // BasicData.mdb 的Header要放 今年的12月31日, 過午夜的部分要手打.打完再啟始新日就是1月1日了
        // BakeryOrder.mdb 放1月1日
        // VoucherExpense.mdb的Header 要放1月1日
        List<string> ReservedTable = new List<string>()
                    {   "BakeryConfig"  ,
                        "Product"       ,
                        "AccountingTitle",
                        "Operator"      ,
                        "Vendor"        ,
                        "Ingredient"    ,
                        "BankAccount"   ,
                        "Config"        ,
                        "Apartment"     ,
                        "HR"            ,
                        "HRDetail"
                    };

        private void Message(string s) 
        {
            labelMessage.Text = s;
            Application.DoEvents();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(m_Dir))
            {
                MessageBox.Show("目錄" + m_Dir + " 己經存在!");
                return;
            }
            try
            {
                Message("建立目錄");
                Directory.CreateDirectory(m_Dir);
                Message("複製" + HardwareConfig.CfgFileName);
                File.Copy(HardwareConfig.CfgFileName, m_Dir + "\\" + HardwareConfig.CfgFileName);

#if (Define_Bakery)
                string IncomeMdb = "BakeryOrder.mdb";
                Message("創建" + IncomeMdb + "!");
                string incomePath = m_Dir + "\\" + IncomeMdb;
                OleDbConnection incomeConn       = new OleDbConnection(MapPath.ConnectString(incomePath, MapPath.BakeryPass + "Bakery"));
                OleDbConnection sourceIncomeConn = MapPath.BakeryConnection;
                if (!MyFunction.Decompress(Properties.Resources.BakeryOrder, incomePath))
                {
                    MessageBox.Show("空白" + IncomeMdb + "建立失敗,無法繼續!");   return;
                }
                bakeryOrderSet1.Header.Clear();
                BakeryOrderSet.HeaderRow row1 = bakeryOrderSet1.Header.AddHeaderRow(new DateTime(m_Year , 1, 1), false);
                BakeryOrderSetTableAdapters.HeaderTableAdapter adapterBa = new BakeryOrderSetTableAdapters.HeaderTableAdapter();
#else
                string IncomeMdb = "BasicData.mdb";
                Message("創建" + IncomeMdb + "!");
                string incomePath = m_Dir + "\\" + IncomeMdb;
                OleDbConnection incomeConn       = new OleDbConnection(MapPath.ConnectString(incomePath, MapPath.BasicPass + "you"));
                OleDbConnection sourceIncomeConn = MapPath.BasicConnection;
                if (!MyFunction.Decompress(Properties.Resources.EmptyBasic,incomePath))
                {
                    MessageBox.Show("空白"+IncomeMdb+"建立失敗,無法繼續!");       return;
                }
                basicDataSet1.Header.Clear();
                BasicDataSet.HeaderRow row1=basicDataSet1.Header.AddHeaderRow(new DateTime(m_Year-1,12,31),false);
                BasicDataSetTableAdapters.HeaderTableAdapter adapterBa = new BasicDataSetTableAdapters.HeaderTableAdapter();
#endif
                adapterBa.Connection = incomeConn;
                adapterBa.Update(row1);

                Message("創建VoucherExpense.mdb!");
                string voucherPath = m_Dir + "\\VoucherExpense.mdb";
                OleDbConnection voucherConn = new OleDbConnection(MapPath.ConnectString(voucherPath, MapPath.VoucherPass + "888"));
                if (!MyFunction.Decompress(Properties.Resources.VoucherExpense, voucherPath))
                {
                    MessageBox.Show("空白VoucherExpense.mdb建立失敗,無法繼續!");
                    return;
                }
                DateTime dt=new DateTime(m_Year,1,1);
                veDataSet1.Header.Clear();
                VEDataSet.HeaderRow row2 = veDataSet1.Header.AddHeaderRow(dt, false,dt,dt,Application.ProductVersion.Trim());
                VEDataSetTableAdapters.HeaderTableAdapter adapterVE = new VEDataSetTableAdapters.HeaderTableAdapter();
                adapterVE.Connection = voucherConn;
                adapterVE.Update(row2);
                MessageBox.Show("己建立空白資料庫!");

                foreach (string s in chListBoxBasic.CheckedItems)      CopyTable(s,  sourceIncomeConn    , incomeConn);
                foreach (string s in chListBoxVE.CheckedItems   )      CopyTable(s,  MapPath.VEConnection, voucherConn);
                Message("資料拷貝完成!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤:" + ex.Message);
                return;
            }
            MessageBox.Show("新年度資料設定完成!");
        }

        void CopyTable(string name, OleDbConnection sourceConn, OleDbConnection destConn)
        {
            Message("拷貝" + name);
            DataTable table = new DataTable(name);
            string SelectStr = "Select * From " + name;
            OleDbDataAdapter sourceAdapter  = new OleDbDataAdapter(SelectStr,sourceConn);
            int sourceNo = sourceAdapter.Fill(table);
            foreach (DataRow row in table.Rows) row.SetAdded();
            OleDbDataAdapter destAdapter = new OleDbDataAdapter(SelectStr,destConn);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(destAdapter);
            builder.QuotePrefix = "[";    // 因為有些ColumnName是保留字,如Password
            builder.QuoteSuffix = "]";
            destAdapter.UpdateCommand = builder.GetUpdateCommand();
            destAdapter.InsertCommand = builder.GetInsertCommand();
            destAdapter.DeleteCommand = builder.GetDeleteCommand();
            int no=destAdapter.Update(table);
            MessageBox.Show(name+"來源共" + sourceNo.ToString() + "筆,寫出成功" + no.ToString() + "筆");

        }

        private void chListBoxVE_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox box = sender as CheckedListBox;
            string str=box.Items[e.Index] as string;
            if (e.NewValue == CheckState.Checked)
            {
                if (!ReservedTable.Contains(str))
                {
                    MessageBox.Show("抱歉! 新年度<" + str + ">不可保留!");
                    e.NewValue = CheckState.Unchecked;
                }
            }
        }

        

    }
}
