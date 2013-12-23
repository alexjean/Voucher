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
using System.Data.SqlClient;
#if UseSQLServer
using MyDataSet = VoucherExpense.DamaiDataSet;
using MyOrderSet= VoucherExpense.DamaiDataSet;
#else
using MyDataSet = VoucherExpense.VEDataSet;
using MyOrderSet = VoucherExpense.BakeryOrderSet;
#endif

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
        MyDataSet m_DataSet = new MyDataSet();
        MyOrderSet m_OrderSet;
        string NewSqlDB = "Daimai";
        HardwareConfig m_HCfg = new HardwareConfig();
        private void FormInitNewYear_Load(object sender, EventArgs e)
        {
            try
            {
#if UseSQLServer
                m_OrderSet=m_DataSet;
                var veHeaderAdapter=new DamaiDataSetTableAdapters.VEHeaderTableAdapter();
                veHeaderAdapter.Fill(m_DataSet.VEHeader);
#else
                m_OrderSet =new MyOrderSet();
                var veHeaderAdapter = new VoucherExpense.VEDataSetTableAdapters.HeaderTableAdapter();
                veHeaderAdapter.Connection = MapPath.VEConnection;
                veHeaderAdapter.Fill(m_DataSet.Header);
#endif
                m_HCfg.Load();
            }
            catch
            {
                MessageBox.Show("標頭資料讀取錯誤,你的資料庫版本可能不對");
                Close();
                return;
            }
            string path = Application.ExecutablePath;
            int len = path.Length;
            if (path[len - 1] == '\\')     path = path.Substring(0, len - 1);      // 去掉最後面的 \
            len = path.LastIndexOf('\\');
            if (len > 0)                   path = path.Substring(0, len);          // 取路
            DateTime dt = DateTime.Now;

#if UseSQLServer
            int count = m_DataSet.VEHeader.Rows.Count;
            if (count != 0)
            {
                var row = (DamaiDataSet.VEHeaderRow)m_DataSet.VEHeader.Rows[count - 1]; // 沒指定用最後一個
                dt = row.DataYear;
            }
            m_Year=dt.Year+1;
            NewSqlDB = m_HCfg.SqlDatabase;
            int n = NewSqlDB.Length - 1;
            for(;n>0;n--)
            {
                if (!char.IsDigit(NewSqlDB[n])) break;
            }
            NewSqlDB = NewSqlDB.Substring(0, n+1)+m_Year.ToString();
            labelYear.Text = "原資料年是 " + dt.Year.ToString() + " 將啟始"+m_Year.ToString()+"年資料";
            labelNote.Text = "新年度資料將被放在資料庫[" +NewSqlDB+"] 設定檔HardwareCfg.xml放置於"+ System.Net.Dns.GetHostName() + "的";
            m_Dir = path + "\\Manage" + m_Year.ToString();
            labelPath.Text = m_Dir;
            // SQL Server只要一個Table
            chListBoxBasic.Visible = false;
            List<string> list2 = GetTableName(m_DataSet);
            foreach (string s in list2)
            {
                if (s == "Header") continue;      // Header要特殊處理
                if (s == "VEHeader") continue;    // VEHeader要特殊處理
                if (ReservedTable.Contains(s))
                    chListBoxVE.Items.Add(s, true);
                else
                    chListBoxVE.Items.Add(s, false);
            }

#else
            int count = m_DataSet.Header.Rows.Count;
            if (count != 0)
            {
                var row = (VEDataSet.HeaderRow)m_DataSet.Header.Rows[count - 1]; // 沒指定用最後一個
                dt = row.DataYear;
            }
            m_Year=dt.Year+1;
            labelYear.Text = "原資料年是 " + dt.Year.ToString() + " 將啟始"+m_Year.ToString()+"年資料";
            labelNote.Text = "起始資料將被放在 " + System.Net.Dns.GetHostName() + "的";
            m_Dir = path + "\\Manage" + m_Year.ToString();
            labelPath.Text = m_Dir;
            List<string> list1 = GetTableName(m_OrderSet);
            List<string> list2 = GetTableName(m_DataSet);
            foreach (string s in list1)
            {
                if (s == "Header") continue;      // Header要特殊處理
                if (ReservedTable.Contains(s))
                    chListBoxBasic.Items.Add(s,true);
                else
                    chListBoxBasic.Items.Add(s, false);
            }
            foreach (string s in list2)
            {
                if (s == "Header") continue;      // Header要特殊處理
                if (ReservedTable.Contains(s))
                    chListBoxVE.Items.Add(s,true);
                else
                    chListBoxVE.Items.Add(s,false);
            }
#endif
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
                        "HRDetail"      ,
                        "Recipe"        ,
                        "RecipeDetail"
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
                Message("建立新年度的" + HardwareConfig.CfgFileName);
                string backupStr = m_HCfg.SqlDatabase;
                m_HCfg.SqlDatabase = NewSqlDB;
                m_HCfg.SaveTo(m_Dir);
                m_HCfg.SqlDatabase = backupStr;
#if UseSQLServer
                Message("創建 [" + NewSqlDB + "]");
                // 檢查 NewSqlDB是否己經存在
                var sqlCommand = new SqlCommand("select count(*) from sysdatabases where name='" + NewSqlDB+"'");
                string connStr = MapPath.SqlConnectString(m_HCfg.SqlServerIP, "master", m_HCfg.SqlUserID, m_HCfg.SqlPassword);
                SqlConnection sqlMasterConn=new SqlConnection(connStr);
                sqlMasterConn.Open();
                sqlCommand.Connection = sqlMasterConn;
                int num = (int)sqlCommand.ExecuteScalar();
                if (num > 0)
                {
                    MessageBox.Show("己經存在[" + NewSqlDB + "], 無法新建!");
                    return;
                }
                // 建立 DataBase
                sqlCommand = sqlMasterConn.CreateCommand();
                sqlCommand.CommandText = "CREATE DATABASE [" + NewSqlDB + "]";
                num = sqlCommand.ExecuteNonQuery();
                // 建立所有的空Table
                List<string> list = GetTableName(m_DataSet);    // 懶得寫SqlCommand,直接重DataSet定義抓
                string destDB="["+NewSqlDB+"].[dbo].[";
                string sourDB="["+m_HCfg.SqlDatabase+"].[dbo].[";
                foreach(string name in list)
                {
                    string cmd="select * into " + destDB + name + "] from " + sourDB + name + "]";
                    var results = from string s in chListBoxVE.CheckedItems where s == name select s;
                    if (results.Count() <= 0)
                    {
                        sqlCommand.CommandText = cmd + " where 1=0";    // 只建立結構,不帶主Key及FK
                        sqlCommand.ExecuteNonQuery();
                        Message("建立空 [" + name + "]");
                    }
                    else
                    {
                        sqlCommand.CommandText = cmd + " where 1=1";    // 建立結構,也Copy資料
                        num=sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("複制 [" + name + "] 共"+num.ToString()+"筆!");
                    }
                }
                sqlMasterConn.Dispose();
                // 建立PrimaryKey 
                Message("建立各表PrimaryKey!");
                SqlConnection newConn=new SqlConnection(MapPath.SqlConnectString(m_HCfg.SqlServerIP, NewSqlDB, m_HCfg.SqlUserID, m_HCfg.SqlPassword));
                newConn.Open();
                sqlCommand.Connection=newConn;
                string cmdPrifix,cmdMiddle;
                string cmdPosfix=" ) WITH (PAD_INDEX = OFF,STATISTICS_NORECOMPUTE = OFF,IGNORE_DUP_KEY = OFF,ALLOW_ROW_LOCKS = ON,ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]";
                foreach (DataTable tab in m_DataSet.Tables)
                {
                    cmdPrifix = "ALTER TABLE [dbo].[" + tab.TableName + "] ADD  CONSTRAINT [PK_" + tab.TableName + "] PRIMARY KEY CLUSTERED ( ";
                    cmdMiddle = "";
                    foreach (DataColumn col in tab.PrimaryKey)
                        cmdMiddle +=("["+ col.ColumnName + "] ASC,");
                    sqlCommand.CommandText = cmdPrifix + cmdMiddle.Substring(0,cmdMiddle.Length-1) + cmdPosfix;
                    sqlCommand.ExecuteNonQuery();
                }
                // 建立Relation,,AutoIncrement
                foreach (DataRelation fk in m_DataSet.Relations)
                {
                    cmdPrifix="ALTER TABLE [dbo].["+fk.ChildTable.TableName+"]  WITH NOCHECK ADD  CONSTRAINT ["+fk.RelationName+"] ";
                    cmdMiddle = "FOREIGN KEY( [" + fk.ChildColumns[0].ColumnName + "] ) ";
                    cmdPosfix = "REFERENCES [dbo].["+fk.ParentTable.TableName+"] (["+fk.ParentColumns[0].ColumnName+"])";
                    if (fk.ChildColumns.Count() != 1 || fk.ParentColumns.Count()!=1)
                        MessageBox.Show("ForiegnKey:"+fk.RelationName+"超二個欄位,目前系統未支持,請手動修正!");
                    sqlCommand.CommandText = cmdPrifix + cmdMiddle + cmdPosfix;
                    sqlCommand.ExecuteNonQuery();
                    // Constrain Check
                    sqlCommand.CommandText = "ALTER TABLE [dbo].[" + fk.ChildTable.TableName + "]  CHECK CONSTRAINT [" + fk.RelationName + "] ";
                    sqlCommand.ExecuteNonQuery();
                }
                // 建立Header VEHeader
                var sqlConn       = new SqlConnection(MapPath.SqlConnectString(m_HCfg.SqlServerIP, NewSqlDB           , m_HCfg.SqlUserID, m_HCfg.SqlPassword));
                var sourceConn    = new SqlConnection(MapPath.SqlConnectString(m_HCfg.SqlServerIP, m_HCfg.SqlDatabase , m_HCfg.SqlUserID, m_HCfg.SqlPassword));

                m_OrderSet.Header.Clear();
                var row1 = m_OrderSet.Header.AddHeaderRow(new DateTime(m_Year , 1, 1), false);
                var adapterBa = new VoucherExpense.DamaiDataSetTableAdapters.HeaderTableAdapter();
                adapterBa.Connection = sqlConn;
                adapterBa.Update(row1);

                DateTime dt=new DateTime(m_Year,1,1);
                m_DataSet.Header.Clear();
                var row2 = m_DataSet.VEHeader.AddVEHeaderRow(dt, false,dt,dt,Application.ProductVersion.Trim());
                var adapterVE = new VoucherExpense.DamaiDataSetTableAdapters.VEHeaderTableAdapter();
                adapterVE.Connection = sqlConn;
                adapterVE.Update(row2);
                MessageBox.Show("己建立新年度資料庫!");
#else
                string IncomeMdb = "BakeryOrder.mdb";
                Message("創建" + IncomeMdb + "!");
                string incomePath = m_Dir + "\\" + IncomeMdb;
                OleDbConnection incomeConn       = new OleDbConnection(MapPath.ConnectString(incomePath, MapPath.BakeryPass + "Bakery"));
                OleDbConnection sourceIncomeConn = MapPath.BakeryConnection;
                if (!MyFunction.Decompress(Properties.Resources.BakeryOrder, incomePath))
                {
                    MessageBox.Show("空白" + IncomeMdb + "建立失敗,無法繼續!");   return;
                }
                m_OrderSet.Header.Clear();
                var row1 = m_OrderSet.Header.AddHeaderRow(new DateTime(m_Year , 1, 1), false);
                var adapterBa = new VoucherExpense.BakeryOrderSetTableAdapters.HeaderTableAdapter();
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
                m_DataSet.Header.Clear();
                var row2 = m_DataSet.Header.AddHeaderRow(dt, false,dt,dt,Application.ProductVersion.Trim());
                VEDataSetTableAdapters.HeaderTableAdapter adapterVE = new VEDataSetTableAdapters.HeaderTableAdapter();
                adapterVE.Connection = voucherConn;
                adapterVE.Update(row2);
                MessageBox.Show("己建立空白資料庫!");

                foreach (string s in chListBoxBasic.CheckedItems) CopyOldDbTable(s, sourceIncomeConn, incomeConn);
                foreach (string s in chListBoxVE.CheckedItems)    CopyOldDbTable(s, MapPath.VEConnection, voucherConn);
                Message("資料拷貝完成!");
#endif
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤:" + ex.Message);
                return;
            }
            MessageBox.Show("新年度資料設定完成!");
        }

        //void CopySqlTable(string name,SqlConnection sourceConn,SqlConnection destConn)
        //{
        //    Message("拷貝" + name);
        //    DataTable table = new DataTable(name);
        //    string SelectStr = "Select * From " + name;
        //    var sourceAdapter = new SqlDataAdapter(SelectStr, sourceConn);
        //    try
        //    {
        //        int sourceNo = sourceAdapter.Fill(table);
        //        foreach (DataRow row in table.Rows) row.SetAdded();
        //        var destAdapter = new SqlDataAdapter(SelectStr, destConn);
        //        var builder = new SqlCommandBuilder(destAdapter);
        //        builder.QuotePrefix = "[";    // 因為有些ColumnName是保留字,如Password
        //        builder.QuoteSuffix = "]";
        //        destAdapter.UpdateCommand = builder.GetUpdateCommand();
        //        destAdapter.InsertCommand = builder.GetInsertCommand();
        //        destAdapter.DeleteCommand = builder.GetDeleteCommand();
        //        int no = destAdapter.Update(table);
        //        MessageBox.Show(name + "來源共" + sourceNo.ToString() + "筆,寫出成功" + no.ToString() + "筆");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("寫出[" + name + "]時出錯:" + ex.Message);
        //    }
        //}

        void CopyOldDbTable(string name, OleDbConnection sourceConn, OleDbConnection destConn)
        {
            Message("拷貝" + name);
            DataTable table = new DataTable(name);
            string SelectStr = "Select * From " + name;
            var sourceAdapter  = new OleDbDataAdapter(SelectStr,sourceConn);
            try
            {
                int sourceNo = sourceAdapter.Fill(table);
                foreach (DataRow row in table.Rows) row.SetAdded();
                var destAdapter = new OleDbDataAdapter(SelectStr, destConn);
                var builder = new OleDbCommandBuilder(destAdapter);
                builder.QuotePrefix = "[";    // 因為有些ColumnName是保留字,如Password
                builder.QuoteSuffix = "]";
                destAdapter.UpdateCommand = builder.GetUpdateCommand();
                destAdapter.InsertCommand = builder.GetInsertCommand();
                destAdapter.DeleteCommand = builder.GetDeleteCommand();
                int no = destAdapter.Update(table);
                MessageBox.Show(name + "來源共" + sourceNo.ToString() + "筆,寫出成功" + no.ToString() + "筆");
            }
            catch (Exception ex)
            {
                MessageBox.Show("寫出[" + name + "]時出錯:" + ex.Message);
            }
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
