using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SyncCloud
{
    static class DB
    {
        public static string SqlConnectString(string address, string database, string userID, string password)
        {
            return "Data Source=" + address + ";Initial Catalog=" + database
                   + ";Persist Security Info=True;User ID=" + userID + ";Password=" + password;
        }

        public static bool GetDeletedVersion(SqlConnection conn,out int maxID)
        {
            SqlCommand cmd = new SqlCommand("SELECT MAX(DeletedID) from dbo.SyncDeletedVersion where 1=1", conn);
            maxID = -1;
            try
            {
                object obj = cmd.ExecuteScalar();
                if (obj == DBNull.Value)
                {
                    cmd.CommandText = "INSERT INTO dbo.SyncDeletedVersion (DeletedID,Locked) VALUES(0,1)";
                    cmd.ExecuteNonQuery();
                    maxID = 0;
                    return true;                          // 是空的
                }
                if (obj == null || obj.GetType() != typeof(int)) return false; // 發生錯誤了
                int n = (int)obj;
                maxID = n;
                //cmd.CommandText = "SELECT Locked from dbo.SyncDeletedVersion Where DeletedID=" + n.ToString();
                //obj=cmd.ExecuteScalar();
                //if (obj == null || obj == DBNull.Value || obj.GetType() != typeof(bool))
                //    return false;    // 無法取得
                //if ((bool)obj == true) return false;   // 資料庫己鎖定
                //else
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("取得<刪除版本号>出錯,原因:" + ex.Message);
                return false;
            }
        }

        public static List<string> GetTablesName(SqlConnection conn)
        {
            string cmdText = "Select SO.name from sysobjects SO where SO.xtype ='U' and SO.status>= 0";
            SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn);
            DataTable tables = new DataTable();
            try
            {
                adapter.Fill(tables);
            }
            catch (Exception ex)
            {
                MessageBox.Show("尋找表名出錯,原因:" + ex.Message);
                return null;
            }
            List<string> list = new List<string>();
            foreach (DataRow row in tables.Rows)
            {
                list.Add((string)row["name"]);
            }
            return list;
        }

        static public void CheckSyncTable(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("dbo.uspCheckSyncTable", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                object obj = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("呼叫uspCheckSynctable時出錯,原因:" + ex.Message);
            }
        }

        static public bool SameStruct(string TableName, SqlConnection DB1, SqlConnection DB2)
        {
            SqlDataAdapter sda1 = null;
            SqlDataAdapter sda2 = null;
            string sqltxt = "SELECT SO.name SOName, SC.name SCName, SC.isnullable 'IsNullable',SC.length 'SC len',ST.name STName FROM sysobjects SO , syscolumns SC , systypes ST WHERE so.name='"
                          + TableName + "' and SO.id = SC.id AND SO.xtype = 'U' AND   SO.status >= 0 AND  SC.xtype = ST.xusertype  ORDER BY  SO.name , SC.colorder";
            try
            {
                sda1 = new SqlDataAdapter(sqltxt, DB1);
                sda2 = new SqlDataAdapter(sqltxt, DB2);
                DataSet ds1 = new DataSet();
                DataSet ds2 = new DataSet();
                sda1.Fill(ds1);
                sda2.Fill(ds2);
                if (ds1 == null || ds2 == null)
                {
                    return false;
                }
                return TableIsSame(ds1.Tables[0], ds2.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sda1.Dispose();
                sda2.Dispose();
            }
        }

        static bool TableIsSame(DataTable dt1, DataTable dt2)
        {
            if (dt1 == null || dt2 == null)
            {
                return false;
            }
            if (dt1.Rows.Count != dt2.Rows.Count || dt1.Columns.Count != dt2.Columns.Count)
            {
                return false;
            }
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                for (int j = 0; j < dt1.Columns.Count; j++)
                {
                    if (dt1.Rows[i][j].ToString() != dt2.Rows[i][j].ToString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }



    }
}
