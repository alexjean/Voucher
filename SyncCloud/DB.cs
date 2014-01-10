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
            SqlCommand cmd = new SqlCommand("SELECT MAX(DeletedID) from dbo.SyncUpdatedVersion where 1=1", conn);
            maxID = -1;
            try
            {
                object obj = cmd.ExecuteScalar();
                if (obj == DBNull.Value)
                {
                    cmd.CommandText = "INSERT INTO dbo.SyncUpdatedVersion (DeletedID,Locked) VALUES(0,1)";
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
                MessageBox.Show("取得<更新版本号>出錯,原因:" + ex.Message);
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

        static public bool CheckSyncTable(SqlConnection conn,string briefName)
        {
Retry:
            SqlCommand cmd = new SqlCommand("dbo.uspCheckSyncTable", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                object obj = cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 0xafc)
                {
                    if (MessageBox.Show(briefName+"沒有找到預存程序"+"[uspCheckSyncTable],是否建立?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (CreateStoredProcedure(StoredProcedureName.uspCheckSynTable, conn))
                            goto Retry;
                    }
                }
                else
                    MessageBox.Show("呼叫uspCheckSynctable時出錯,原因:" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("呼叫uspCheckSynctable時出錯,原因:" + ex.Message);
            }
            return false;
        }

        public enum StoredProcedureName { uspCheckSynTable };
        static public bool CreateStoredProcedure(StoredProcedureName name,SqlConnection conn)
        {
            StringBuilder sb=new StringBuilder();
            string cmdTxt;
            switch (name)
            {
                case StoredProcedureName.uspCheckSynTable:
                     sb=new StringBuilder("CREATE PROCEDURE [dbo].[uspCheckSyncTable] AS\r\n");
                     sb.AppendLine("BEGIN");
                     sb.AppendLine("Declare @tableName nvarchar(50)");
                     sb.AppendLine("DECLARE @program nvarchar(512)");
	                 sb.AppendLine("DECLARE @maxID int");
	                 sb.AppendLine("DECLARE @result int");
	                 sb.AppendLine("SET NOCOUNT ON");
	                 sb.AppendLine("DECLARE My_Cursor Cursor");
	                 sb.AppendLine("FOR (Select SO.name from sysobjects SO where SO.xtype ='U' and SO.status>= 0) ORDER BY SO.name");
	                 sb.AppendLine("OPEN My_Cursor");
	                 sb.AppendLine("FETCH NEXT FROM My_Cursor INTO @tableName");
	                 sb.AppendLine("WHILE @@FETCH_STATUS =0");
	                 sb.AppendLine("BEGIN");
		             sb.AppendLine("    IF (@tableName not like 'Order%') and (@tableName not like 'Sync%') and (@tableName<>'DrawerRecord') and (@tableName not like '%Detail')");
                     sb.AppendLine("    BEGIN");
			         sb.AppendLine("    SET @result=(SELECT Count(Name) from SyncTable where Name=@tableName)");
			         sb.AppendLine("    IF (@result<=0)");
			         sb.AppendLine("        BEGIN");
			         sb.AppendLine("        Set @maxID=ISNULL((SELECT MAX(TableID) from SyncTable),0)+1");
				     sb.AppendLine("        INSERT INTO [dbo].[SyncTable] ([TableID],[Name]) Values(@maxID,@tableName)");
			         sb.AppendLine("        END");
		             sb.AppendLine("    END");
		             sb.AppendLine("    FETCH NEXT FROM My_Cursor INTO @tableName");
	                 sb.AppendLine("END");
	                 sb.AppendLine("CLOSE My_Cursor");
	                 sb.AppendLine("DEALLOCATE My_Cursor");
                     sb.AppendLine("END");
                     cmdTxt=sb.ToString();
                     break;
                default: MessageBox.Show("不知名字的Stored Procedure 程式錯誤!");
                         return false;
            }
            try
            {
                SqlCommand sc=new SqlCommand(cmdTxt,conn);
                sc.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("創建Stored Procedure<"+name.ToString()+">失敗,原因:"+ex.Message);
                return false;
            }
            return true;

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

        static string PrimaryKeyStandardOption=" WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY]";
        public enum SyncDataTable { SyncUpdatedVersion ,SyncTable,SyncMD5Old};
        static public bool CreateDataTable(SyncDataTable tableName,SqlConnection conn)
        {
            string cmdStr;
            string name = tableName.ToString();
            switch (tableName)
            {
                case SyncDataTable.SyncUpdatedVersion:
                    cmdStr = "CREATE TABLE [dbo].[SyncUpdatedVersion] (";
                    cmdStr += "  [DeletedID] [int] NOT NULL,[Locked] [bit],";
                    cmdStr += "  CONSTRAINT [PK_Sync_UpdatedVersion] PRIMARY KEY CLUSTERED ( [DeletedID] ASC )" + PrimaryKeyStandardOption;
                    break;
                case SyncDataTable.SyncTable:
                    cmdStr = "CREATE TABLE [dbo].[SyncTable] (";
                    cmdStr+= "  [TableID] [int] NOT NULL,";
	                cmdStr+= "  [Name] [nvarchar](50) NOT NULL,";
	                cmdStr+= "  [MD5] [uniqueidentifier] NULL,";
	                cmdStr+= "  [RecordCount] [int] NULL,";
	                cmdStr+= "  [PKIsInt] [bit] NULL,";
                    cmdStr+= "  [PKCast] [sysname] NULL,";
	                cmdStr+= "  [CastMethod] [varchar](max) NULL,";
                    cmdStr+= "  [RelationForeignKeyName] [nvarchar](50) NULL,";
                    cmdStr += "  CONSTRAINT [PK_SyncTable] PRIMARY KEY CLUSTERED ( [TableID] ASC )" + PrimaryKeyStandardOption;
                    break;
                case SyncDataTable.SyncMD5Old:
                    cmdStr = "CREATE TABLE [dbo].[SyncMD5Old](";
	                cmdStr+= "  [ID] [uniqueidentifier] NOT NULL,";
	                cmdStr+= "  [TableID] [int] NULL,";
	                cmdStr+= "  [PKInt] [int] NULL,";
	                cmdStr+= "  [PKUUID] [uniqueidentifier] NULL,";
	                cmdStr+= "  [MD5] [binary](16) NULL,";
                    cmdStr+= "  CONSTRAINT [PK_SyncMD5Old] PRIMARY KEY CLUSTERED ( [ID] ASC )"+ PrimaryKeyStandardOption;
                    break;
                default:
                    MessageBox.Show("不知TableName[" + name + "] 程式錯誤!");
                    return false;
            }
            SqlCommand cmd = new SqlCommand(cmdStr, conn);
            try
            {
                object obj = cmd.ExecuteScalar();
                if (obj!=null)   
                {
                    MessageBox.Show("創建Sync用資料表["+name+"]出錯!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("創建Sync用資料表["+name+"]出錯,原因:" + ex.Message);
                return false;
            }
            return true;
        }

        static public bool AskCreateDataTable(string prefix, SyncDataTable tableName, SqlConnection conn)
        {
            if (MessageBox.Show(prefix+"必需有["+tableName.ToString()+"]資料表! 要創建嗎?", "", MessageBoxButtons.YesNo) != DialogResult.Yes) return false;
            if (!CreateDataTable(tableName, conn)) return false;
            return true;
        }

    }
}
