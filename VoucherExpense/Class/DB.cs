using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace VoucherExpense
{
    public static class DB
    {
        public class SqlCredential
        {
            public string ServerIP;
            public string UserID;
            public string Password;
            public SqlCredential() { }
            public SqlCredential(SqlCredential from)
            {
                ServerIP = from.ServerIP;
                UserID   = from.UserID;
                Password = from.Password;
            }
        }

        // 只有在Region的資料庫才用這個
        public static string SqlConnectString(HardwareConfig cfg)
        {
            if (cfg.IsServer)   return SqlConnectString(cfg.Local, cfg.Database);
            else                return SqlConnectString(cfg.Local, cfg.SharedDatabase);
        }

        public static string SqlConnectString(SqlCredential lo, string database)
        {
            if (lo == null)
            {
                MessageBox.Show("SqlCredential 為Null on DB.SqlConnectString(...)");
                return "";
            }
            return SqlConnectString(lo.ServerIP, database, lo.UserID, lo.Password);
        }

        public static string SqlConnectString(string address, string database, string userID, string password)
        {
            return "Data Source=" + address + ";Initial Catalog=" + database
                   + ";Persist Security Info=True;User ID=" + userID + ";Password=" + password;
        }

        public static bool GetDeletedVersion(SqlConnection conn, out int maxID)
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

        public static Dictionary<string, List<SqlColumnStruct>> GetTablesName(SqlConnection conn)
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
            var list = new Dictionary<string, List<SqlColumnStruct>>();
            foreach (DataRow row in tables.Rows)
            {
                list.Add((string)row["name"], null);
            }
            return list;
        }

        public static Dictionary<string, DB.TableInfo> GetTableID(SqlConnection conn)
        {
            var adapter = new DamaiDataSetTableAdapters.SyncTableTableAdapter();
            adapter.Connection = conn;
            var table = new DamaiDataSet.SyncTableDataTable();
            var dic = new Dictionary<string, DB.TableInfo>();
            try
            {
                adapter.Fill(table);
                foreach (var row in table)
                {
                    var tableInfo = new TableInfo();
                    tableInfo.Name = row.Name;
                    tableInfo.Childs = null;

                    if (!row.IsMD5Null()) tableInfo.MD5 = row.MD5;
                    if (!row.IsRecordCountNull()) tableInfo.RecordCount = row.RecordCount;
                    tableInfo.TableID = row.TableID;
                    dic.Add(row.Name, tableInfo);
                }
                return dic;
            }
            catch { }
            return null;
        }



        public static void UpdateSyncTable(Dictionary<string, DB.TableInfo> dic, SqlConnection conn)
        {
            var adapter = new DamaiDataSetTableAdapters.SyncTableTableAdapter();
            adapter.Connection = conn;
            var table = new DamaiDataSet.SyncTableDataTable();
            try
            {
                adapter.Fill(table);
                foreach (var row in table)
                {
                    DB.TableInfo ti = null;
                    if (dic.TryGetValue(row.Name, out ti))
                    {
                        row.RecordCount = ti.RecordCount;
                        row.MD5 = ti.MD5;
                    }
                }
                adapter.Update(table);
            }
            catch { }
        }

        static public bool CheckSyncTable(SqlConnection conn, string briefName)
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
                    if (MessageBox.Show(briefName + "沒有找到預存程序" + "[uspCheckSyncTable],是否建立?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
        static public bool CreateStoredProcedure(StoredProcedureName name, SqlConnection conn)
        {
            StringBuilder sb = new StringBuilder();
            string cmdTxt;
            switch (name)
            {
                case StoredProcedureName.uspCheckSynTable:
                    sb = new StringBuilder("CREATE PROCEDURE [dbo].[uspCheckSyncTable] AS\r\n");
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
                    sb.AppendLine("    IF (@tableName='BankDetail') or ((@tableName<>'InventoryProducts') and (@tableName not like '%Item') and (@tableName not like 'Sync%') and (@tableName not like '%Detail'))");
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
                    cmdTxt = sb.ToString();
                    break;
                default: MessageBox.Show("不知名字的Stored Procedure 程式錯誤!");
                    return false;
            }
            try
            {
                SqlCommand sc = new SqlCommand(cmdTxt, conn);
                sc.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("創建Stored Procedure<" + name.ToString() + ">失敗,原因:" + ex.Message);
                return false;
            }
            return true;

        }

        public class SqlColumnStruct
        {
            public string TableName;
            public string Name;
            public bool IsNullable;
            public Int16 Length;
            public SqlDbType DbType;
            public bool IsPrimaryKey = false;
            static public SqlDbType ConvertToDbType(string typeName)
            {
                int n = (int)(SqlDbType.DateTimeOffset);     // DateTimeOffset是最後一個,當作Count來用
                for (int i = 0; i <= n; i++)
                {
                    SqlDbType t = (SqlDbType)i;
                    if (typeName.Equals(t.ToString(), StringComparison.InvariantCultureIgnoreCase))
                        return t;
                }
                return SqlDbType.Structured;   // 未知型態,指定 Structured
            }
        }


        static public List<SqlColumnStruct> GetStruct(string TableName, SqlConnection Db)
        {
            SqlDataAdapter adapter = null, primaryAdapter = null;
            string sqltxt = "SELECT SO.name 'TableName', SC.name 'Name', SC.isnullable 'IsNullable',SC.length 'Length',ST.name 'DbType'" +
                            " FROM sysobjects SO , syscolumns SC , systypes ST" +
                            " WHERE SO.name='" + TableName + "'" +
                            " And SO.id = SC.id AND SO.xtype = 'U' AND SO.status >= 0 AND  SC.xtype = ST.xusertype  ORDER BY  SO.name , SC.colorder";
            string sqlFindPrimary = "SELECT PrimaryColName=SC.name FROM sys.indexes IDX"
                          + " INNER JOIN sys.objects SO ON SO.[object_id]=IDX.[object_id] And SO.name='" + TableName + "'"
                          + " INNER JOIN sys.index_columns IDXC ON IDX.[object_id]=IDXC.[object_id] AND IDX.index_id=IDXC.index_id"
                          + " INNER JOIN sys.columns SC ON SO.[object_id]=SC.[object_id] AND SO.type='U' AND SO.is_ms_shipped=0 AND IDXC.column_id=SC.column_id"
                          + " WHERE IDX.is_primary_key=1";
            List<SqlColumnStruct> list = new List<SqlColumnStruct>();
            try
            {
                primaryAdapter = new SqlDataAdapter(sqlFindPrimary, Db);
                DataTable priTable = new DataTable();
                primaryAdapter.Fill(priTable);
                var listPrimary = new List<string>();
                foreach (DataRow row in priTable.Rows)
                    listPrimary.Add((string)row["PrimaryColName"]);
                adapter = new SqlDataAdapter(sqltxt, Db);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table == null) return null;
                foreach (DataRow row in table.Rows)
                {
                    SqlColumnStruct col = new SqlColumnStruct();
                    col.TableName = (string)row["TableName"];
                    col.Name = (string)row["Name"];
                    col.IsNullable = ((int)row["IsNullable"] == 0) ? false : true;
                    col.Length = (Int16)row["Length"];
                    col.DbType = SqlColumnStruct.ConvertToDbType((string)row["DbType"]);
                    // 查出PrimaryKey
                    if (listPrimary.Contains(col.Name)) col.IsPrimaryKey = true;
                    list.Add(col);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { adapter.Dispose(); primaryAdapter.Dispose(); }

            return list;
        }

        public class ForeignKey
        {
            public string KeyName;
            public string FatherTable;
            public string ChildTable;
            public string FatherKey;
            public string ChildKey;
            public string DeleteAction;
            public string UpdateAction;
        }

        public static List<ForeignKey> GetForeignKey(SqlConnection conn)
        {
            SqlDataAdapter adapter = null;
            string sql = "select fk.name KeyName,obj.name as FatherTable,fkc.referenced_column_id as FatherColumn,sc.name as FatherColName," +
                         " par_obj.name as ChildTable,fkc.parent_column_id as ChildColumn,sc1.name as ChildColName," +
                         " fk.delete_referential_action_desc as DeleteAction,fk.update_referential_action_desc as UpdateAction" +
                         " from sys.foreign_keys fk" +
                         " left join sys.foreign_key_columns fkc on fk.object_id=fkc.constraint_object_id" +
                         " left join sys.objects obj     on fkc.referenced_object_id = obj.object_id " +
                         " left join sys.objects par_obj on fkc.parent_object_id     = par_obj.object_id" +
                         " left join sys.columns sc      on sc.object_id=fkc.referenced_object_id And fkc.referenced_column_id = sc.column_id" +
                         " left join sys.columns sc1     on sc1.object_id=fkc.parent_object_id And fkc.parent_column_id = sc1.column_id";
            try
            {
                adapter = new SqlDataAdapter(sql, conn);
                List<ForeignKey> list = new List<ForeignKey>();
                DataTable table = new DataTable();
                adapter.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    ForeignKey fk = new ForeignKey();
                    fk.KeyName = (string)row["KeyName"];
                    fk.FatherTable = (string)row["FatherTable"];
                    fk.FatherKey = (string)row["FatherColName"];
                    fk.ChildTable = (string)row["ChildTable"];
                    fk.ChildKey = (string)row["ChildColName"];
                    fk.DeleteAction = (string)row["DeleteAction"];
                    fk.UpdateAction = (string)row["UpdateAction"];
                    list.Add(fk);
                }
                return list;
            }
            catch (Exception ex) { throw ex; }
        }

        static public bool IsForeignKeyDeleteActionCascade(TableInfo info)
        {
            if (info == null) return false;
            if (info.Childs == null) return false;
            if (info.Childs.Count() == 0) return false;
            foreach (var child in info.Childs)
                if (child.DeleteAction.ToUpper() != "CASCADE")
                    return false;
            return true;
        }

        static public bool SameForeignKey(TableInfo local, TableInfo cloud)
        {
            if (local == null)
                return false;
            if (cloud == null)
                return false;
            if (local.Childs == null) return false;
            if (cloud.Childs == null) return false;
            if (local.Childs.Count() == 0 && cloud.Childs.Count() != 0) return false;
            foreach (var info in local.Childs)
            {
                var infoCs = from infoC in cloud.Childs where infoC.Name == info.Name select infoC;
                if (infoCs.Count() == 0) return false;
                var info1 = infoCs.First();
                if (info.FatherKey != info1.FatherKey) return false;
                if (info.ChildKey != info1.ChildKey) return false;
                if (info.UpdateAction != info1.UpdateAction) return false;
                if (info.DeleteAction != info1.DeleteAction) return false;
            }
            return true;
        }

        static public bool SameStructWithPK(List<SqlColumnStruct> local, List<SqlColumnStruct> cloud,out string msg)
        {
            if (local.Count != cloud.Count)
            {
                msg = "欄位數不同!";
                return false;
            }
            int count = local.Count;
            for (int i = 0; i < count; i++)
            {
                var l = local[i];
                var c = cloud[i];
                if (l.DbType != c.DbType)               goto Different;
                if (l.IsNullable != c.IsNullable)       goto Different;
                if (l.IsPrimaryKey != c.IsPrimaryKey)   goto Different;
                if (l.Length != c.Length)               goto Different;
                if (l.Name != c.Name)                   goto Different;
                continue;
                // TableName不比對
            Different:
                msg = "欄位<" + l.Name + ">不同!";
                return false;
            }
            msg = "";
            return true;
        
           

        }

        static public bool SameStruct(string TableName, SqlConnection DB1, SqlConnection DB2)
        {
            SqlDataAdapter sda1 = null;
            SqlDataAdapter sda2 = null;
            string sqltxt = "SELECT SO.name 'TableName', SC.name 'Name', SC.isnullable 'IsNullable',SC.length 'Length',ST.name 'DbType' FROM sysobjects SO , syscolumns SC , systypes ST WHERE SO.name='"
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

        static string PrimaryKeyStandardOption = " WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY]";
        public enum SyncDataTable { SyncUpdatedVersion, SyncTable, SyncMD5Old, SyncMD5Now };
        static public bool CreateDataTable(SyncDataTable tableName, SqlConnection conn)
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
                    cmdStr += "  [TableID] [int] NOT NULL,";
                    cmdStr += "  [Name] [nvarchar](50) NOT NULL,";
                    cmdStr += "  [MD5] [uniqueidentifier] NULL,";
                    cmdStr += "  [RecordCount] [int] NULL,";
                    cmdStr += "  CONSTRAINT [PK_SyncTable] PRIMARY KEY CLUSTERED ( [TableID] ASC )" + PrimaryKeyStandardOption;
                    break;
                case SyncDataTable.SyncMD5Old:
                    cmdStr = "CREATE TABLE [dbo].[SyncMD5Old](";
                    cmdStr += "  [ID] [uniqueidentifier] NOT NULL,";
                    cmdStr += "  [TableID] [int] NULL,";
                    cmdStr += "  [PrimaryKey] [uniqueidentifier] NULL,";
                    cmdStr += "  [MD5] [binary](16) NULL,";
                    cmdStr += "  CONSTRAINT [PK_SyncMD5Old] PRIMARY KEY CLUSTERED ( [ID] ASC )" + PrimaryKeyStandardOption;
                    break;
                case SyncDataTable.SyncMD5Now:
                    cmdStr = "CREATE TABLE [dbo].[SyncMD5Now](";
                    cmdStr += "  [ID] [uniqueidentifier] NOT NULL,";
                    cmdStr += "  [TableID] [int] NULL,";
                    cmdStr += "  [PrimaryKey] [uniqueidentifier] NULL,";
                    cmdStr += "  [MD5] [binary](16) NULL,";
                    cmdStr += "  CONSTRAINT [PK_SyncMD5Now] PRIMARY KEY CLUSTERED ( [ID] ASC )" + PrimaryKeyStandardOption;
                    break;
                default:
                    MessageBox.Show("不知TableName[" + name + "] 程式錯誤!");
                    return false;
            }
            SqlCommand cmd = new SqlCommand(cmdStr, conn);
            try
            {
                object obj = cmd.ExecuteScalar();
                if (obj != null)
                {
                    MessageBox.Show("創建Sync用資料表[" + name + "]出錯!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("創建Sync用資料表[" + name + "]出錯,原因:" + ex.Message);
                return false;
            }
            return true;
        }

        static public bool DropTable(string name, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("DROP TABLE [dbo].[" + name + "]", conn);
            try
            {
                object obj = cmd.ExecuteScalar();
                if (obj != null)
                {
                    MessageBox.Show("刪除資料表[" + name + "]出錯!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("刪除資料表[" + name + "]出錯,原因:" + ex.Message);
                return false;
            }
            return true;
        }


        static public bool AskCreateDataTable(string prefix, SyncDataTable tableName, SqlConnection conn)
        {
            if (MessageBox.Show(prefix + "必需有[" + tableName.ToString() + "]資料表! 要創建嗎?", "", MessageBoxButtons.YesNo) != DialogResult.Yes) return false;
            if (!CreateDataTable(tableName, conn)) return false;
            return true;
        }

        public enum RowStatus { Deleted, New, Changed, Unchanged };
        public class Md5Result
        {
            public Guid PrimaryKey;  // 一律為 byte[16]
            public byte[] Md5Old;
            public byte[] Md5Now;
            public RowStatus Status;
            public bool SameMd5()
            {
                if (Md5Old == null) return false;
                if (Md5Now == null) return false;
                if (Md5Old.Length != Md5Now.Length) return false;
                int len = Md5Old.Length;
                for (int i = 0; i < len; i++)
                    if (Md5Old[i] != Md5Now[i]) return false;
                return true;
            }
        }

        public class TableInfo
        {
            public string Name;
            public int TableID;
            public int RecordCount;
            public Guid MD5;
            public List<SqlColumnStruct> Struct;
            public List<SqlColumnStruct> PrimaryKeys = null;
            public List<ChildInfo> Childs;
        }

        public class ChildInfo
        {
            public string Name;
            public List<SqlColumnStruct> Struct;
            public string ForeignKeyName;
            public string FatherKey = null;
            public string ChildKey = null;
            public string DeleteAction = null;
            public string UpdateAction = null;
            public List<SqlColumnStruct> PrimaryKeys = null;
            public ChildInfo(string name) { Name = name; }
        }

        public static string Bytes2Hex(byte[] bytes)
        {
            string str = "";
            foreach (byte b in bytes)
                str += b.ToString("X2");
            return str;
        }

        static void IntToBinary16(int id, ref byte[] pk, int offset)
        {
            byte[] bts = BitConverter.GetBytes(id);
            for (int i = 0; i < 4; i++) pk[i + offset] = bts[i];
        }
        static void Int64ToBinary16(Int64 id, ref byte[] pk, int offset)
        {
            byte[] bts = BitConverter.GetBytes(id);
            for (int i = 0; i < 8; i++) pk[i + offset] = bts[i];
        }
        static void Int16ToBinary16(Int16 id, ref byte[] pk, int offset)
        {
            byte[] bts = BitConverter.GetBytes(id);
            for (int i = 0; i < 2; i++) pk[i + offset] = bts[i];
        }


        public enum PrimaryKeyType { IntCombined, UniqueIdentifier, DateTime, String, Unknown };
        public static PrimaryKeyType GetKeyType(SqlDbType DbType)
        {
            switch (DbType)
            {
                case SqlDbType.UniqueIdentifier:
                    return PrimaryKeyType.UniqueIdentifier;
                case SqlDbType.SmallInt:
                case SqlDbType.TinyInt:
                case SqlDbType.BigInt:
                case SqlDbType.Int: return PrimaryKeyType.IntCombined;
                case SqlDbType.DateTime: return PrimaryKeyType.DateTime;
                case SqlDbType.NChar:
                case SqlDbType.Char:
                case SqlDbType.VarChar:
                case SqlDbType.NVarChar: return PrimaryKeyType.String;
                default: return PrimaryKeyType.Unknown;
            }
        }

        static public int FindTableID(string tableName, Dictionary<string, DB.TableInfo> IDLookupTable)
        {
            // 找出TableID
            if (!IDLookupTable.ContainsKey(tableName)) return int.MinValue;
            return IDLookupTable[tableName].TableID;
        }

        static public PrimaryKeyType GetFirstKeyType(List<SqlColumnStruct> listStruct)
        {
            foreach (var col in listStruct)
            {
                if (col.IsPrimaryKey)
                    return GetKeyType(col.DbType);  // 找到一個就夠了
            }
            return PrimaryKeyType.Unknown;
        }

        public class RunningSet
        {
            public SqlDataAdapter adapter = null;
            public DataTable table = null;
            public DataRelation relation = null;
            public PrimaryKeyType childType = PrimaryKeyType.Unknown;
            public DB.ChildInfo childInfo = null;
            public RunningSet(DB.ChildInfo info) { childInfo = info; }
        };

        static public Dictionary<Guid, Md5Result> CalcCompMd5(DB.TableInfo tableInfo, SqlConnection conn,
                                                    ref DataSet dataSet, ref DamaiDataSet.SyncMD5OldDataTable tableMd5Old)
        {

            int tableID = tableInfo.TableID;
            if (tableID == int.MinValue) return null;
            string tableName = tableInfo.Name;
            // 判斷主Key型態
            List<SqlColumnStruct> listStruct = tableInfo.Struct;
            PrimaryKeyType PKType = GetFirstKeyType(listStruct);
            if (PKType == PrimaryKeyType.Unknown) return null;
            // 載入Old
            var adapterOld = new DamaiDataSetTableAdapters.SyncMD5OldTableAdapter();
            adapterOld.Connection = conn;
            var dicResult = new Dictionary<Guid, Md5Result>();
            //byte[] FileMd5Old=null;
            try
            {
                // Fill的預設動作,因為他會自設SelectCommand,所以只好自己寫一次
                var SqlCmd = new SqlCommand("Select * from SyncMd5Old Where TableID=" + tableID.ToString(), conn);
                SqlCmd.CommandType = CommandType.Text;
                adapterOld.Adapter.SelectCommand = SqlCmd;
                tableMd5Old.Clear();
                adapterOld.Adapter.Fill(tableMd5Old);
                //////////////////////////////////////
                foreach (var row in tableMd5Old)
                {
                    if (row.IsMD5Null())                       { row.Delete(); continue; }  // 資料庫內md5是dbnull,不應該   
                    if (row.IsPrimaryKeyNull())                { row.Delete(); continue; }
                    if (dicResult.ContainsKey(row.PrimaryKey)) { row.Delete(); continue; }  // 重複了,Bug
                    Md5Result result = new Md5Result();
                    result.PrimaryKey = row.PrimaryKey;
                    result.Md5Old = row.MD5;
                    result.Status = RowStatus.Deleted;
                    switch (PKType)
                    {
                        case PrimaryKeyType.DateTime:
                        case PrimaryKeyType.IntCombined:
                        case PrimaryKeyType.String:
                        case PrimaryKeyType.UniqueIdentifier:   dicResult.Add(result.PrimaryKey, result); break;
                        default: return null;
                    }
                }

            }
            catch(Exception ex)
            {
                return null;
            }
            // 計算New
            if (tableName == "Order")    // [Order]的MD5量大,是由AP計算的
            {
                DataTable tableNow = new DataTable(tableName);
                try
                {
                    SqlDataAdapter adapterNow = new SqlDataAdapter("Select * From [Order]", conn);   // Order只准從本地至雲端,本地全讀不是負擔
                    adapterNow.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    dataSet.Tables.Add(tableNow);                     //
                    adapterNow.Fill(dataSet, tableName);              // 這三行一定要這樣寫才會自動填 Columns,一定要指定tableName,而且要存在,要不然會新建一個叫'Table'

                    foreach (DataRow row in tableNow.Rows)
                    {
                        byte[] bts = new byte[16];
                        IntToBinary16((int)row["ID"], ref bts, 0);
                        Guid pk = new Guid(bts);
                        Md5Result val;
                        object objMD5 = row["MD5"];
                        if (objMD5 == Convert.DBNull)  dicResult.Remove(pk);   // MD5 DBNull 刪掉這個記錄
                        else if (dicResult.TryGetValue(pk, out val))
                        {
                            val.Md5Now = (byte[])objMD5;
                            if (!val.SameMd5()) val.Status = RowStatus.Changed;
                            else val.Status = RowStatus.Unchanged;
                        }
                        else
                        {
                            val = new Md5Result();
                            val.PrimaryKey = pk;
                            val.Md5Old = null;
                            val.Md5Now = (byte[])objMD5;
                            val.Status = RowStatus.New;
                            dicResult.Add(pk, val);
                        }
                    }
                }
                catch (Exception ex) { return null; }
            }
            else if (tableName == "Photos")
            {
                DataTable table = new DataTable();
                try
                {
                    SqlDataAdapter adapterNow = new SqlDataAdapter("Select TableID,PhotoID,MD5 From [Photos]", conn);
                    adapterNow.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    adapterNow.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        byte[] bts = new byte[16];
                        IntToBinary16((short)row["TableID"], ref bts, 0);
                        IntToBinary16((int)row["PhotoID"], ref bts, 8);
                        Guid pk = new Guid(bts);
                        Md5Result val;
                        object objMD5=row["MD5"];
                        if (objMD5 == Convert.DBNull) dicResult.Remove(pk);
                        else if (dicResult.TryGetValue(pk, out val))
                        {
                            val.Md5Now = (byte[])objMD5;
                            if (!val.SameMd5()) val.Status = RowStatus.Changed;
                            else val.Status = RowStatus.Unchanged;
                        }
                        else
                        {
                            val = new Md5Result();
                            val.PrimaryKey = pk;
                            val.Md5Old = null;
                            val.Md5Now = (byte[])objMD5;
                            val.Status = RowStatus.New;
                            dicResult.Add(pk, val);
                        }
                    }
                }
                catch (Exception ex) 
                {
                    return null;
                }
            }
            else if (tableName == "Program")
            {
                DataTable table = new DataTable();
                try
                {
                    SqlDataAdapter adapterNow = new SqlDataAdapter("Select [ID],[Md5] From [Program]", conn);   // Order只准從本地至雲端,本地全讀不是負擔
                    adapterNow.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    adapterNow.Fill(table);              // 這三行一定要這樣寫才會自動填 Columns,一定要指定tableName,而且要存在,要不然會新建一個叫'Table'

                    foreach (DataRow row in table.Rows)
                    {
                        Guid pk = (Guid)row["ID"];
                        Md5Result val;
                        object objMD5 = row["Md5"];
                        if (objMD5 == Convert.DBNull) dicResult.Remove(pk);   // MD5 DBNull 刪掉這個記錄
                        else if (dicResult.TryGetValue(pk, out val))
                        {
                            val.Md5Now = (byte[])objMD5;
                            if (!val.SameMd5()) val.Status = RowStatus.Changed;
                            else val.Status = RowStatus.Unchanged;
                        }
                        else
                        {
                            val = new Md5Result();
                            val.PrimaryKey = pk;
                            val.Md5Old = null;
                            val.Md5Now = (byte[])objMD5;
                            val.Status = RowStatus.New;
                            dicResult.Add(pk, val);
                        }
                    }
                }
                catch (Exception ex) { return null; }
            }
            else
            {
                MD5 MD5Provider = new MD5CryptoServiceProvider();
                SqlDataAdapter adapterNow = new SqlDataAdapter("Select * From [" + tableName + "]", conn);
                adapterNow.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                DataTable tableNow = new DataTable(tableName);         //
                try
                {
                    dataSet.Tables.Add(tableNow);                     //
                    adapterNow.Fill(dataSet, tableName);              // 這三行一定要這樣寫才會自動填 Columns,一定要指定tableName,而且要存在,要不然會新建一個叫'Table'

                    List<RunningSet> Runnings = new List<RunningSet>();
                    if (tableInfo.Childs != null)
                        foreach (var child in tableInfo.Childs)
                            Runnings.Add(new RunningSet(child));

                    foreach (var run in Runnings)
                    {
                        ChildInfo info = run.childInfo;
                        run.adapter = new SqlDataAdapter("Select * From [" + info.Name + "]", conn);
                        run.table = new DataTable(info.Name);
                        dataSet.Tables.Add(run.table);
                        run.childType = GetFirstKeyType(info.Struct);
                        run.adapter.Fill(dataSet, info.Name);
                        run.relation = new DataRelation(info.ForeignKeyName, tableNow.Columns[info.FatherKey], run.table.Columns[info.ChildKey]);
                        dataSet.Relations.Add(run.relation);
                    }

                    foreach (DataRow row in tableNow.Rows)
                    {
                        byte[] pk;
                        StringBuilder strBuilder = Row2Str(row, listStruct, PKType, MD5Provider, out pk);
                        if (strBuilder == null) return null;
                        foreach (var run in Runnings)
                        {
                            if (run.relation == null) continue;
                            DataRow[] childRows = row.GetChildRows(run.relation);
                            byte[] childPK;
                            foreach (DataRow childRow in childRows)
                                strBuilder.Append(Row2Str(childRow, run.childInfo.Struct, run.childType, MD5Provider, out childPK));
                        }

                        byte[] md5 = MD5Provider.ComputeHash(Encoding.Unicode.GetBytes(strBuilder.ToString()));   // 還沒考慮Detail
                        Guid pkGuid = new Guid(pk);
                        Md5Result val;
                        if (dicResult.TryGetValue(pkGuid, out val))
                        {
                            val.Md5Now = md5;
                            if (!val.SameMd5()) val.Status = RowStatus.Changed;
                            else val.Status = RowStatus.Unchanged;
                        }
                        else
                        {
                            val = new Md5Result();
                            val.PrimaryKey = pkGuid;
                            val.Md5Old = null;
                            val.Md5Now = md5;
                            val.Status = RowStatus.New;
                            dicResult.Add(pkGuid, val);
                        }
                    }
                    // 更新SyncTable內容
                    tableInfo.RecordCount = tableNow.Rows.Count;
                    // syncTableRow.MD5 =  ??? File MD5待寫
                }
                catch (Exception ex) { return null; }
            }
            return dicResult;
        }

        private static StringBuilder Row2Str(DataRow row, List<SqlColumnStruct> listStruct, PrimaryKeyType PKType, MD5 MD5Provider, out byte[] pk)
        {
            StringBuilder str = new StringBuilder("");
            int ofs = 0;
            pk = new byte[16];
            foreach (SqlColumnStruct st in listStruct)
            {
                str.Append("|");
                object obj = row[st.Name];
                if (obj == null || DBNull.Value == obj) continue; // Null不加入計算MD5
                if (st.IsPrimaryKey)
                {
                    switch (PKType)
                    {
                        case PrimaryKeyType.IntCombined:
                            if (ofs > 8)
                            {
                                MessageBox.Show("整數型複合Key,只接受二個!");
                                return null;
                            }
                            switch (st.DbType)
                            {
                                case SqlDbType.Int: IntToBinary16((int)obj, ref pk, ofs); break;
                                case SqlDbType.BigInt: Int64ToBinary16((Int64)obj, ref pk, ofs); break;
                                case SqlDbType.TinyInt: pk[ofs] = (byte)obj; break;
                                case SqlDbType.SmallInt: Int16ToBinary16((Int16)obj, ref pk, ofs); break;
                                default:
                                    MessageBox.Show("無法辦認的PrimaryKey型態<" + st.DbType.ToString() + "> 欄位[" + st.Name + "]!"); return null;
                            }
                            ofs += 8;
                            break;
                        case PrimaryKeyType.UniqueIdentifier:
                            pk = ((Guid)obj).ToByteArray();
                            break;
                        case PrimaryKeyType.DateTime:
                            DateTime dt = (DateTime)obj;
                            Int64ToBinary16(dt.ToBinary(), ref pk, 0);
                            break;
                        case PrimaryKeyType.String:
                            byte[] strBytes=Encoding.Unicode.GetBytes((string)obj);
                            if (strBytes.Length > 16)
                            {
                                MessageBox.Show("String類主Key最大支援8個Unicode字元!");
                                return null;
                            }
                            pk = new byte[16];
                            int iMax = 16;
                            if (iMax > strBytes.Length) iMax = strBytes.Length;
                            for (int i = 0; i < iMax; i++) pk[i] = strBytes[i];
                            break;
                        default: return null;
                    }
                }
                else
                    switch (st.DbType)
                    {
                        case SqlDbType.UniqueIdentifier:
                        case SqlDbType.SmallInt:
                        case SqlDbType.TinyInt:
                        case SqlDbType.BigInt:
                        case SqlDbType.Int: str.Append(obj.ToString()); break;
                        case SqlDbType.Char:
                        case SqlDbType.NChar:
                        case SqlDbType.NVarChar:
                        case SqlDbType.VarChar: str.Append(obj.ToString()); break;
                        case SqlDbType.Bit: str.Append((bool)obj ? '1' : '0'); break;   // bit被轉成bool
                        case SqlDbType.Money:
                        case SqlDbType.SmallMoney:
                        case SqlDbType.Decimal: str.Append(((decimal)obj).ToString("N2")); break;
                        case SqlDbType.Float: str.Append(((Double)obj).ToString("F4")); break;                      // float目前暫時用N4
                        case SqlDbType.Real: str.Append(((Single)obj).ToString("F4")); break;
                        case SqlDbType.SmallDateTime:
                        case SqlDbType.DateTime: str.Append(((DateTime)obj).ToString("yyyy-MM-dd hh:mm:ss")); break;
                        case SqlDbType.Binary:
                        case SqlDbType.VarBinary:
                        case SqlDbType.Image:
                            byte[] bytes = (byte[])obj;
                            if (bytes.Length <= 32)
                                str.Append(Bytes2Hex(bytes));
                            else
                                str.Append(Bytes2Hex(MD5Provider.ComputeHash((byte[])obj))); break;    // Image算出MD5後轉成string
                        default:
                            throw new Exception("不支援計算MD5的型別<" + st.DbType.ToString() + "> 欄位[" + st.Name + "]!");
                    }
            }
            return str;
        }

        public static Type SqlType2CsharpType(SqlDbType sqlType)
        {
            switch (sqlType)
            {
                case SqlDbType.BigInt: return typeof(Int64);
                case SqlDbType.Binary: return typeof(Object);
                case SqlDbType.Bit: return typeof(Boolean);
                case SqlDbType.Char: return typeof(String);
                case SqlDbType.DateTime: return typeof(DateTime);
                case SqlDbType.Decimal: return typeof(Decimal);
                case SqlDbType.Float: return typeof(Double);
                case SqlDbType.Image: return typeof(Object);
                case SqlDbType.Int: return typeof(Int32);
                case SqlDbType.Money: return typeof(Decimal);
                case SqlDbType.NChar: return typeof(String);
                case SqlDbType.NText: return typeof(String);
                case SqlDbType.NVarChar: return typeof(String);
                case SqlDbType.Real: return typeof(Single);
                case SqlDbType.SmallDateTime: return typeof(DateTime);
                case SqlDbType.SmallInt: return typeof(Int16);
                case SqlDbType.SmallMoney: return typeof(Decimal);
                case SqlDbType.Text: return typeof(String);
                case SqlDbType.Timestamp: return typeof(Object);
                case SqlDbType.TinyInt: return typeof(Byte);
                case SqlDbType.Udt: return typeof(Object); //自定义的数据类型
                case SqlDbType.UniqueIdentifier: return typeof(Object);
                case SqlDbType.VarBinary: return typeof(Object);
                case SqlDbType.VarChar: return typeof(String);
                case SqlDbType.Variant: return typeof(Object);
                case SqlDbType.Xml: return typeof(Object);
                default: return null;
            }
        }

        public static void UpdateMd5Old(List<Md5Result> changedMd5, int tableID, SqlConnection Conn, DamaiDataSet.SyncMD5OldDataTable table)
        {
            //            string sqlCmd = "Select * from SyncMd5Old Where TableID=" + tableID.ToString();    // 必需和 CalcCompMd5 內一致
            var dic = new Dictionary<Guid, DamaiDataSet.SyncMD5OldRow>();  //加速用
            foreach (var r in table)
            {
                if (r.RowState == DataRowState.Deleted) continue;
                if (dic.ContainsKey(r.PrimaryKey)) r.Delete();
                else                               dic.Add(r.PrimaryKey, r);
            }
            foreach (var md5 in changedMd5)
            {
                if (md5.Status == DB.RowStatus.Unchanged) continue;
                DamaiDataSet.SyncMD5OldRow row = null;
                dic.TryGetValue(md5.PrimaryKey, out row);
                if (md5.Status == DB.RowStatus.Deleted)
                {
                    if (row != null) row.Delete();
                }
                else
                {
                    if (row == null)
                    {
                        row = table.NewSyncMD5OldRow();
                        row.ID = Guid.NewGuid();
                        row.MD5 = md5.Md5Now;
                        row.PrimaryKey = md5.PrimaryKey;
                        row.TableID = tableID;
                        table.AddSyncMD5OldRow(row);
                    }
                    else
                        row.MD5 = md5.Md5Now;
                }
            }
            var adapter = new DamaiDataSetTableAdapters.SyncMD5OldTableAdapter();
            adapter.Connection = Conn;
            //adapter.Adapter.SelectCommand = new SqlCommand(sqlCmd);   // 此行無效,因為Update或Fill的預設動作,都會被蓋掉,看
            try
            {
                adapter.Update(table);
            }
            catch { }
        }

    }
}
