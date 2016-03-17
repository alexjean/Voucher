using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VoucherExpense
{
    public partial class FormAutoSync : Form
    {
        public FormAutoSync()
        {
            InitializeComponent();
        }

        SqlConnection LocalServer, CloudServer,RegionServer;
        bool AllowLeave = true;
        HardwareConfig m_Cfg ;
        // = new HardwareConfig();

        private void FormAutoSync_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            todayPicker.MinDate = new DateTime(MyFunction.IntHeaderYear, 1, 1);
            todayPicker.MaxDate = new DateTime(MyFunction.IntHeaderYear, 12, 31);
            if (now.Date < todayPicker.MinDate) todayPicker.Value = todayPicker.MinDate;
            else if (now.Date > todayPicker.MaxDate) todayPicker.Value = todayPicker.MaxDate;
            else todayPicker.Value = now.Date;

            //m_Cfg.Load();
            m_Cfg = MyFunction.HardwareCfg;
            statusStrip1.Visible = m_Cfg.EnableCloudSync;
        }

        private void FormAutoSync_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AllowLeave)
            {
                MessageBox.Show("請按<離開>按鈕!");
                e.Cancel = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            AllowLeave = true;
            Close();
        }
        
        SqlConnection ConnectServer(string msg,  string database, DB.SqlCredential lo)
        {
            try
            {
                SqlConnection conn;
                ShowStatus("開啟" + msg + "資料庫!");
//                Message("IP:" + server + " DB:" + database);
//                Message("User:" + userId + " pass:" + password);
                conn = new SqlConnection(DB.SqlConnectString(lo, database));
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("開啟" + msg + "服務器失敗,原因:" + ex.Message);
                return null;
            }
        }

        bool ConnectAllServer()
        {
            LocalServer = ConnectServer("本地",  m_Cfg.Database, m_Cfg.Local);
            if (LocalServer == null) return false;
            CloudServer = ConnectServer("雲端",  m_Cfg.Database, m_Cfg.Cloud);   // 除Region外,共用Local的DatabaseName
            if (CloudServer == null)
            {
                try
                {
                    LocalServer.Close();
                    LocalServer = null;
                }
                catch { }
                return false;
            }
            RegionServer = ConnectServer("區域", m_Cfg.SharedDatabase, m_Cfg.Cloud);
            if (RegionServer == null)
            {
                try
                {
                    LocalServer.Close(); LocalServer = null;
                    CloudServer.Close(); CloudServer = null;
                }
                catch { }
                return false;
            }
            return true;
        }

        void Message(string msg)
        {
            listBoxMessage.Items.Add(msg);
            Application.DoEvents();
        }

        bool DoCheckSyncTable(string title, SqlConnection conn, ref Dictionary<string, List<DB.SqlColumnStruct>> dicStruct, out Dictionary<string, DB.TableInfo> dicTableID)
        {
            if (!dicStruct.ContainsKey("SyncTable"))
            {
                if (!DB.AskCreateDataTable(title, DB.SyncDataTable.SyncTable, conn))
                    goto FAIL;
                if (!DB.DropTable(DB.SyncDataTable.SyncMD5Old.ToString(), conn)) goto FAIL;
            }
            if (!DB.CheckSyncTable(conn, title))                 // 檢查SyncTable存在
            {
                Message(title + "SyncTable檢查失敗!");
                goto FAIL;
            }
            dicTableID = DB.GetTableIDFromSyncTable(conn);                   // 分別載入Local及Cloud的存在SyncTable中的TableID
            return true;
        FAIL:
            Message("==========請重新執行=========================");
            dicTableID = new Dictionary<string, DB.TableInfo>();
            return false;
        }

        bool DoCheckSyncMD5Old(string title, SqlConnection conn, ref Dictionary<string, List<DB.SqlColumnStruct>> dicStructs)
        {
            if (!dicStructs.ContainsKey(DB.SyncDataTable.SyncMD5Old.ToString()))
            {
                if (!DB.AskCreateDataTable(title, DB.SyncDataTable.SyncMD5Old, conn))
                    return false;
                MessageBox.Show("己創建" + title + "同步用記憶表! 請再按開始同步");
                Message("========新創建" + title + "同步用記憶表!=================");
                return false;
            }
            return true;
        }

        object FindIntKey(byte[] PrimaryKey, int offset, SqlDbType DbType)
        {
            switch (DbType)
            {
                case SqlDbType.BigInt: return (object)BitConverter.ToInt64(PrimaryKey, offset);
                case SqlDbType.Int: return (object)BitConverter.ToInt32(PrimaryKey, offset);
                case SqlDbType.SmallInt: return (object)BitConverter.ToInt16(PrimaryKey, offset);
                case SqlDbType.TinyInt: return (object)PrimaryKey[offset];
            }
            return null;
        }

        string GuidPrimaryKeyToString(Guid guidPrimaryKey, DB.SqlColumnStruct key)
        {
            byte[] PrimaryKey = guidPrimaryKey.ToByteArray();
            var keyType = DB.GetKeyType(key.DbType);
            switch (keyType)
            {
                case DB.PrimaryKeyType.IntCombined: return FindIntKey(PrimaryKey, 0, key.DbType).ToString();
                case DB.PrimaryKeyType.UniqueIdentifier: return "'"+guidPrimaryKey.ToString()+"'";
                case DB.PrimaryKeyType.String: 
                    string str=Encoding.Unicode.GetString(PrimaryKey);
                    return str;
            }
            return null;
        }

        string GuidPrimaryKey2ToString(Guid guidPrimaryKey, DB.SqlColumnStruct key)
        {
            if (DB.GetKeyType(key.DbType) != DB.PrimaryKeyType.IntCombined) return null;
            byte[] PrimaryKey = guidPrimaryKey.ToByteArray();
            return FindIntKey(PrimaryKey, 8, key.DbType).ToString();
        }


        DataRow GetRowFromGuidPrimaryKey(Guid guidPrimaryKey, DataTable table, DB.TableInfo tableInfo)
        {
            //            List<DB.SqlColumnStruct> colStruct = tableInfo.Struct;
            var Keys = tableInfo.PrimaryKeys;
            if (Keys.Count() == 0) return null;
            byte[] PrimaryKey = guidPrimaryKey.ToByteArray();

            try
            {
                if (Keys.Count() == 1)
                {
                    var key = Keys.First();
                    var keyType = DB.GetKeyType(key.DbType);
                    switch (keyType)
                    {
                        case DB.PrimaryKeyType.DateTime:
                            return table.Rows.Find(DateTime.FromBinary(BitConverter.ToInt64(PrimaryKey, 0)));
                        case DB.PrimaryKeyType.IntCombined: return table.Rows.Find(FindIntKey(PrimaryKey, 0, key.DbType));
                        case DB.PrimaryKeyType.UniqueIdentifier: return table.Rows.Find(guidPrimaryKey);
                        case DB.PrimaryKeyType.String: return table.Rows.Find(Encoding.Unicode.GetString(PrimaryKey));    // 最多支援8個字的Unicode???
                    }
                    return null;
                }
                else if (Keys.Count() == 2)
                {
                    var key1 = Keys.First();
                    var key2 = Keys.Last();
                    var key1Type = DB.GetKeyType(key1.DbType);
                    var key2Type = DB.GetKeyType(key2.DbType);
                    if (key1Type != DB.PrimaryKeyType.IntCombined) return null; // 複合Key只支援Int類
                    if (key2Type != DB.PrimaryKeyType.IntCombined) return null;
                    object k1 = FindIntKey(PrimaryKey, 0, key1.DbType);
                    object k2 = FindIntKey(PrimaryKey, 8, key2.DbType);
                    if (k1 == null || k2 == null) return null;
                    return table.Rows.Find(new object[2] { k1, k2 });
                }
            }
            catch (Exception ex)
            {
                Message("程式或資料錯誤！<GetRowFromPrimaryKeyBinary16>[" + table.TableName + "] 原因:" + ex.Message);
                throw ex;
            }
            return null;
        }

        void CopyRow(DataRow source, DataRow dest, List<DB.SqlColumnStruct> colStruct)
        {
            foreach (var col in colStruct)
                dest[col.Name] = source[col.Name];
        }

        bool UpdateData(string title, string tableName, DataSet dataSet, SqlConnection conn, DB.TableInfo info)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From [" + tableName + "]", conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(adapter);

            try  // 因為Sql資料主副表連動,外鍵限制 刪父Key 子表還存在會報錯,Update Insert子表沒有父Key會報錯
            {    // 所以規定刪除規則要選Cascade 在子表中直接去除刪除記錄,  新增要主表先
                if (dataSet.Tables[tableName].Rows.Count == 0) return true;    //  NotAllowCloudToLocal的, 又沒有資料要同步的, 這個Table從未載入資料
                adapter.DeleteCommand = cb.GetDeleteCommand();
                adapter.InsertCommand = cb.GetInsertCommand();
                adapter.UpdateCommand = cb.GetUpdateCommand();
                adapter.Update(dataSet, tableName);
                dataSet.Tables[tableName].AcceptChanges();
                if (info.Childs != null)
                    foreach (var child in info.Childs)
                    {
                        var updatedChilds = from DataRow d in dataSet.Tables[child.Name].Rows
                                            where d.RowState == DataRowState.Added || d.RowState == DataRowState.Modified
                                            select d;
                        if (updatedChilds.Count() > 0)
                        {
                            SqlDataAdapter adapter1 = new SqlDataAdapter("Select * From [" + child.Name + "]", conn);
                            SqlCommandBuilder cb1 = new SqlCommandBuilder(adapter1);
                            adapter1.DeleteCommand = cb1.GetDeleteCommand();
                            adapter1.UpdateCommand = cb1.GetUpdateCommand();
                            adapter1.InsertCommand = cb1.GetInsertCommand();
                            DataRow[] rows = updatedChilds.ToArray();
                            adapter1.Update(rows);
                            dataSet.Tables[child.Name].AcceptChanges();
                        }
                    }
            }
            catch (Exception ex)
            {
                Message(title + "寫出<" + tableName + ">錯誤,原因:" + ex.Message);
                return false;
            }
            return true;
        }

        private bool SameKeyExist(DataRow source, List<DataRow> dests, DB.ChildInfo info, out DataRow dest)
        {
            dest = null;
            if (dests == null) return false;
            if (dests.Count() == 0) return false;
            List<DB.SqlColumnStruct> Keys = info.PrimaryKeys;
            if (Keys.Count() == 0) return false;
            try
            {
                DB.SqlColumnStruct key = Keys.First();
                object sourceKey = source[key.Name];
                IEnumerable<DataRow> rows;
                switch (key.DbType)
                {
                    case SqlDbType.UniqueIdentifier:
                        Guid guidKey = (Guid)sourceKey;
                        rows = from r in dests where guidKey == (Guid)r[key.Name] select r;
                        break;
                    case SqlDbType.Int:
                        int intKey = (int)sourceKey;
                        rows = from r in dests where intKey == (int)r[key.Name] select r;
                        break;
                    case SqlDbType.BigInt:
                        Int64 int64Key = (Int64)sourceKey;
                        rows = from r in dests where int64Key == (Int64)r[key.Name] select r;
                        break;
                    case SqlDbType.TinyInt:
                        byte byteKey = (byte)sourceKey;
                        rows = from r in dests where byteKey == (byte)r[key.Name] select r;
                        break;
                    case SqlDbType.SmallInt:
                        Int16 int16Key = (Int16)sourceKey;
                        rows = from r in dests where int16Key == (Int16)r[key.Name] select r;
                        break;
                    default: return false;
                }
                if (rows.Count() == 0) return false;
                if (Keys.Count() == 1)
                {
                    dest = rows.First();
                    return true;
                }
                if (Keys.Count() > 2) return false;
                var key2 = Keys.Last();
                var sourceKey2 = source[key2.Name];
                IEnumerable<DataRow> rows2;
                switch (key2.DbType)
                {
                    case SqlDbType.UniqueIdentifier:
                        Guid guidKey = (Guid)sourceKey2;
                        rows2 = from r in rows where guidKey == (Guid)r[key2.Name] select r;
                        break;
                    case SqlDbType.Int:
                        int intKey = (int)sourceKey2;
                        rows2 = from r in rows where intKey == (int)r[key2.Name] select r;
                        break;
                    case SqlDbType.BigInt:
                        Int64 int64Key = (Int64)sourceKey2;
                        rows2 = from r in rows where int64Key == (Int64)r[key2.Name] select r;
                        break;
                    case SqlDbType.TinyInt:
                        byte byteKey = (byte)sourceKey2;
                        rows2 = from r in rows where byteKey == (byte)r[key2.Name] select r;
                        break;
                    case SqlDbType.SmallInt:
                        Int16 int16Key = (Int16)sourceKey2;
                        rows2 = from r in rows where int16Key == (Int16)r[key2.Name] select r;
                        break;
                    default: return false;
                }
                if (rows2.Count() == 0) return false;
                dest = rows2.First();
                return true;
            }
            catch (Exception ex)
            {
                Message("程式或資料錯誤！<SameKeyExist>[" + source.Table.TableName + "] 原因:" + ex.Message);
                throw ex;
            }
        }

        private bool ProcessChildsRows(string tableName, string msgDest, DataSet dataSetDest, DataRow sourceRow, DataRow destRow,
                                         DB.TableInfo tableInfoSource, DB.TableInfo tableInfoDest)
        {
            if (tableInfoSource.Childs == null) return true;
            foreach (var info in tableInfoSource.Childs)
            {
                var infoDests = from inf in tableInfoDest.Childs where inf.Name == info.Name select inf;
                if (infoDests.Count() != 1) continue;
                var infoDest = infoDests.First();
                DataTable childTableDest = dataSetDest.Tables[infoDest.Name];
                if (childTableDest == null)
                {
                    Message("處理 =>" + msgDest + "[" + tableName + "]時出錯,本表同步停止,原因:找不到子表[" + infoDest.Name + "]");
                    return false;
                }
                DataRow[] childRowsSource = sourceRow.GetChildRows(info.ForeignKeyName);
                List<DataRow> childRowsDest = destRow.GetChildRows(infoDest.ForeignKeyName).ToList();  // 應該不會有,但要預防
                // 分三部分,二個都有的要覆蓋Dest, Source有Dest沒有要新增, Source沒有Dest有要Delete 
                foreach (DataRow s in childRowsSource)
                {
                    DataRow dest;
                    if (SameKeyExist(s, childRowsDest, info, out dest))
                    {
                        CopyRow(s, dest, info.Struct);
                        childRowsDest.Remove(dest);
                    }
                    else
                    {
                        dest = childTableDest.NewRow();
                        CopyRow(s, dest, info.Struct);
                        childTableDest.Rows.Add(dest);
                    }
                }
                foreach (DataRow d in childRowsDest)
                    d.Delete();
            }
            return true;
        }

        bool LoadChangedDataOneByOne(string tableName,string msgDest,DB.TableInfo tableInfo,DataSet dataSet,SqlConnection serverConn,
                                    ref DataTable dataTable,ref List<DB.RunningSet> Runnings,ref List<DB.Md5Result> listChanged)
        {
            if (tableInfo.PrimaryKeys == null || tableInfo.PrimaryKeys.Count == 0 )
            {
                Message("規定"+msgDest+"的[" + tableName + "]資料表, 必需有個PrimaryKey! 本表同步停止!(UpdateRealDataByMd5Result)");
                return false;
            }
            if (tableInfo.PrimaryKeys.Count > 1)
            {
                if (tableInfo.PrimaryKeys.Count > 2)
                {
                    Message("規定" + msgDest + "的[" + tableName + "]資料表,最多二個PrimaryKey! 本表同步停止!(UpdateRealDataByMd5Result)");
                    return false;
                }
                foreach (var key in tableInfo.PrimaryKeys)
                {
                    if (DB.GetKeyType(key.DbType) != DB.PrimaryKeyType.IntCombined)
                    {
                        Message(msgDest + "的[" + tableName + "]資料表,有二個PrimaryKey,只支援整數型態組合! 本表同步停止!(UpdateRealDataByMd5Result)");
                        return false;
                    }
                }
            }
            else if (DB.GetKeyType(tableInfo.PrimaryKeys[0].DbType)==DB.PrimaryKeyType.Unknown)
            {
                 Message( msgDest + "的[" + tableName + "]資料表,PrimaryKey型態不支持! 本表同步停止!(UpdateRealDataByMd5Result)");
                 return false;
            }
            DB.SqlColumnStruct pkDefine = tableInfo.PrimaryKeys[0];
            string pkName = pkDefine.Name;
            DB.SqlColumnStruct pkDefine1 = null;
            string pkName1 = null;
            if (tableInfo.PrimaryKeys.Count == 2)
            {
                pkDefine1 = tableInfo.PrimaryKeys[1];
                pkName1 = pkDefine1.Name;
            }
            DB.PrimaryKeyType keyType = DB.GetKeyType(pkDefine.DbType);
            if (keyType != DB.PrimaryKeyType.IntCombined && keyType != DB.PrimaryKeyType.UniqueIdentifier)
            {
                Message("規定從本地=>雲端的[" + tableName + "]資料表, PrimaryKey只支援整數類或UniqueIdentifier! 本表同步停止!(UpdateRealDataByMd5Result)");
                return false;
            }
            if (dataTable == null)
            {
                dataTable = new DataTable(tableName);
                dataSet.Tables.Add(dataTable);
            }
            if (listChanged.Count <= 0) return true;
            bool firstTime=true;
            StringBuilder sb = new StringBuilder("Select * From [" + tableName + "]");  // 寫Where
            foreach (var r in listChanged)
            {
                if (firstTime) { sb.Append(" Where "); firstTime = false; }
                else sb.Append(" Or ");
                if (pkName1 == null)    // 一個Key,編寫 Where ID=39999 Or ID=40001 ...
                {
                    sb.Append(pkName); sb.Append("=");
                    string str = GuidPrimaryKeyToString(r.PrimaryKey, pkDefine);
                    if (str == null)
                    {
                        Message("處理 =>" + msgDest + "[" + tableName + "]時出錯,本表同步停止, 主Key無法轉換(只支援整數 Guid及8字以下String");
                        return false;
                    }
                    sb.Append(str);
                }
                else                                  // 二個Key,編寫 Where (ID=1234 And Index=1) Or (ID=1234 And Index=2) ....
                {
                    sb.Append("(" + pkName + "=");
                    string str = GuidPrimaryKeyToString(r.PrimaryKey, pkDefine);
                    if (str == null)
                    {
                        Message("處理 =>" + msgDest + "[" + tableName + "]時出錯,本表同步停止, 主Key1無法轉換(只支援整數 Guid及8字以下String");
                        return false;
                    }
                    sb.Append(str + " And ");
                    sb.Append(pkName1 + "=");
                    string str1 = GuidPrimaryKey2ToString(r.PrimaryKey, pkDefine1);
                    if (str1 == null)
                    {
                        Message("處理 =>" + msgDest + "[" + tableName + "]時出錯,本表同步停止, 主Key2無法轉換(只支援整數 Guid及8字以下String");
                        return false;
                    }
                    sb.Append(str1 + ")");
                }
            }
            try
            {
                SqlDataAdapter adapterNow = new SqlDataAdapter(sb.ToString(), serverConn);
                adapterNow.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                adapterNow.Fill(dataSet, tableName);
            }
            catch (Exception ex)
            {
                Message("載入" + msgDest + "[" + tableName + "]出錯,原因:" + ex.Message);
                return false;
            }
            if (tableInfo.Childs != null)
            {
                if (Runnings.Count == 0)
                {
                    foreach (var child in tableInfo.Childs)
                        Runnings.Add(new DB.RunningSet(child));
                    foreach (var run in Runnings)
                    {
                        DB.ChildInfo info = run.childInfo;
                        run.table = new DataTable(info.Name);
                        dataSet.Tables.Add(run.table);
                        run.childType = DB.GetKeyType(info.PrimaryKeys[0].DbType);
                    }
                }
                foreach (var run in Runnings)
                {
                    DB.ChildInfo info = run.childInfo;
                    string pkNameChild = info.ChildKey;
                    var pkDefineChild = (from st in info.Struct where st.Name == pkNameChild select st).First();
                    DB.PrimaryKeyType keyTypeChild = DB.GetKeyType(pkDefineChild.DbType);
                    if (keyTypeChild != DB.PrimaryKeyType.IntCombined && keyTypeChild != DB.PrimaryKeyType.UniqueIdentifier)
                    {
                        Message("規定從本地=>雲端的[" + tableName + "]資料表, PrimaryKey只支援整數類或UniqueIdentifier! 本表同步停止!(UpdateRealDataByMd5Result)");
                        return false;
                    }
                    bool firstTime1=true;
                    StringBuilder sb1 = new StringBuilder("Select * From [" + info.Name + "]");
                    foreach (var r in listChanged)
                    {
                        if (firstTime1) { sb1.Append(" Where "); firstTime1 = false; }
                        else sb1.Append(" Or ");
                        sb1.Append(pkNameChild); sb1.Append("=");
                        string str = GuidPrimaryKeyToString(r.PrimaryKey, pkDefineChild);
                        if (str == null)
                        {
                            Message("處理 =>" + msgDest + "[" + tableName + "]時出錯,本表同步停止, 主Key無法轉換(只支援整數 Guid及8字以下String");
                            return false;
                        }
                        sb1.Append(str);
                    }
                    run.adapter = new SqlDataAdapter(sb1.ToString(), serverConn);
                    run.adapter.Fill(dataSet, info.Name);
                    if (run.relation == null)  // 第一次Fill以後才有Cloums,才能加Relation
                    {
                        run.relation = new DataRelation(info.ForeignKeyName, dataTable.Columns[info.FatherKey], run.table.Columns[info.ChildKey]);
                        dataSet.Relations.Add(run.relation);
                    }
                }
            }
            return true;
        }

        private bool UpdateRealDataByMd5Result(string tableName, string msgDest, SqlConnection serverConnDest, DB.TableInfo tableInfoSource, DB.TableInfo tableInfoDest,
                                                DataSet dataSetSource, DataSet dataSetDest, Dictionary<Guid, DB.Md5Result> dicMd5ResultSource)
        {
            DataTable dataTableSource = dataSetSource.Tables[tableName];
            DataTable dataTableDest = dataSetDest.Tables[tableName];
            var changedMd5Result = (from mr in dicMd5ResultSource.Values where mr.Status != DB.RowStatus.Unchanged select mr).ToList();
            bool loadDataNeeded = !AllowCloudToLocal(tableName) || SpecialMD5(tableName);
            int totalCount = changedMd5Result.Count();
            int addCount = 0;
            var Runnings = new List<DB.RunningSet>();
        LOOP: // 要Update的太大時,分筆寫出
            if (changedMd5Result == null) return true;
            List<DB.Md5Result> listChanged = new List<DB.Md5Result>();
            if (loadDataNeeded)  // 不從雲端更新本地的檔案和程式自己計算的MD5, dataSetDest值沒算過MD5,所以沒有被載入
            {
                int i=0;
                foreach(var r in changedMd5Result)
                {
                    listChanged.Add(r);
                    if (++i >= 100) break;
                }
                foreach (var r in listChanged)
                    changedMd5Result.Remove(r);
                if (!LoadChangedDataOneByOne(tableName, msgDest, tableInfoDest, dataSetDest, serverConnDest, ref dataTableDest, ref Runnings, ref listChanged))
                    return false;
            }
            else
            {   // 可以二邊同步的檔案都小,全部一起來
                listChanged = changedMd5Result;
                changedMd5Result = null;
            }
            if (listChanged.Count > 0)
            {
                foreach (var re in listChanged)
                {   // 自Source取資料更新Dest端真實檔案
                    try
                    {
                        DataRow sourceRow = GetRowFromGuidPrimaryKey(re.PrimaryKey, dataTableSource, tableInfoSource);
                        DataRow destRow = GetRowFromGuidPrimaryKey(re.PrimaryKey, dataTableDest, tableInfoDest);
                        var colStruct = tableInfoSource.Struct;       // 雲端和本地一定相同,前面己經比對過,所以用同一colStruct
                        switch (re.Status)
                        {
                            case DB.RowStatus.New:
                            case DB.RowStatus.Changed:
                                if (sourceRow == null) continue;  // 應該不可能
                                if (destRow == null)
                                {
                                    destRow = dataTableDest.NewRow();
                                    CopyRow(sourceRow, destRow, colStruct);
                                    dataTableDest.Rows.Add(destRow);
                                    if (!ProcessChildsRows(tableName, msgDest, dataSetDest, sourceRow, destRow, tableInfoSource, tableInfoDest)) return false;
                                    // 新增在Update時要先放主表,再插入副表
                                }
                                else
                                {   // 分三部分, Source有Dest沒有要新增, Source沒有Dest有要Delete, 二個都有的要覆蓋Dest(覆蓋不好做)
                                    CopyRow(sourceRow, destRow, colStruct);
                                    if (!ProcessChildsRows(tableName, msgDest, dataSetDest, sourceRow, destRow, tableInfoSource, tableInfoDest)) return false;
                                }
                                break;
                            case DB.RowStatus.Deleted:
                                if (destRow != null)
                                {
                                    if (tableInfoDest.Childs != null)
                                        foreach (var child in tableInfoDest.Childs)
                                        {
                                            var childRows = destRow.GetChildRows(child.ForeignKeyName);   // 前面CalcMd5應該己經建立Relation
                                            DataTable tab = dataSetDest.Tables[child.Name];
                                            foreach (var childRow in childRows)
                                                tab.Rows.Remove(childRow);          // 先刪子表,再刪總表, 規定Delete Cascade, 所以先將Deleted的ChildRow Remove就好
                                        }
                                    destRow.Delete();
                                }
                                break;
                            default:
                                Message("處理 =>" + msgDest + "[" + tableName + "]時出錯,本表同步停止,原因:" + re.Status.ToString() + "我不認得");
                                return false;  // 不可能,出錯了
                        }
                    }
                    catch (Exception ex)
                    {
                        Message("處理 =>" + msgDest + "[" + tableName + "]時出錯,本表同步停止,原因:" + ex.Message);
                        return false;
                    }
                }
                addCount += listChanged.Count;
                ShowStatus("更新" + msgDest + "[" + tableName + "]資料  " + addCount.ToString() + "/" + totalCount.ToString() + "筆!");
                if (!UpdateData(msgDest, tableName, dataSetDest, serverConnDest, tableInfoDest)) return false;
                if (changedMd5Result != null && changedMd5Result.Count() > 0) goto LOOP;
            }
            return true;
        }


        private bool BuildChildInfo(string fatherName, string childName, Dictionary<string, List<DB.SqlColumnStruct>> dicStruct, Dictionary<string, DB.TableInfo> dicTableInfo,
                                    List<DB.ForeignKey> listForeignKey, out DB.TableInfo fatherInfo)
        {
            if (dicTableInfo.TryGetValue(fatherName, out fatherInfo))
            {
                if (fatherInfo.Childs == null) fatherInfo.Childs = new List<DB.ChildInfo>();
                DB.ChildInfo child = new DB.ChildInfo(childName);
                dicStruct.TryGetValue(childName, out child.Struct);
                var fks = from fk in listForeignKey where fk.FatherTable == fatherName && fk.ChildTable == childName select fk;
                if (fks.Count() > 0)
                {
                    DB.ForeignKey fk = fks.First();
                    child.ForeignKeyName = fk.KeyName;
                    child.FatherKey = fk.FatherKey;
                    child.ChildKey = fk.ChildKey;
                    child.DeleteAction = fk.DeleteAction;
                    child.UpdateAction = fk.UpdateAction;
                    var keys = from ke in child.Struct where ke.IsPrimaryKey select ke;
                    if (keys.Count() > 0)
                    {
                        child.PrimaryKeys = new List<DB.SqlColumnStruct>();
                        foreach (var key in keys)
                            child.PrimaryKeys.Add(key);
                    }
                }
                fatherInfo.Childs.Add(child);
            }
            return true;
        }

        private bool AllowCloudToLocal(string tableName)
        {   // Order和OnDutyData只從本地到雲端
            if (tableName == "Order") return false;
            if (tableName == "OnDutyData") return false;
            if (tableName == "ProductScrapped") return false;
            return true;
        }

        private bool SpecialMD5(string tableName)
        {
            if (tableName == "Photos") return true;
            if (tableName == "Program") return true;
            return false;
        }

        List<string> m_CloudBaseTable = new List<string> { "Operator", "Apartment", "OperatorAuthList" };
        private bool RegionDatabase(string tableName)
        {
            foreach (string name in m_CloudBaseTable)
                if (tableName == name) return true;
            return false;            
        }

        void LoadOrderItem(DataSet dataSet, DB.TableInfo tableInfo, SqlConnection conn)
        {
            try
            {
                List<DB.RunningSet> Runnings = new List<DB.RunningSet>();
                if (tableInfo.Childs != null)
                    foreach (var child in tableInfo.Childs)
                        Runnings.Add(new DB.RunningSet(child));
                foreach (var run in Runnings)
                {
                    DB.ChildInfo info = run.childInfo;
                    run.adapter = new SqlDataAdapter("Select * From [" + info.Name + "]", conn);
                    run.table = new DataTable(info.Name);
                    dataSet.Tables.Add(run.table);
                    run.childType = DB.GetKeyType(info.PrimaryKeys[0].DbType);
                    run.adapter.Fill(dataSet, info.Name);
                    run.relation = new DataRelation(info.ForeignKeyName, dataSet.Tables["Order"].Columns[info.FatherKey], run.table.Columns[info.ChildKey]);
                    dataSet.Relations.Add(run.relation);
                }
            }
            catch { }
        }

        string GetFatherByNameRule(string name)
        {
            if      (name.Equals("ShiftDetail"))        return "ShiftTable";
            else if (name.EndsWith("Detail"))           return name.Substring(0, name.Length - 6);
            else if (name.EndsWith("Item"))             return name.Substring(0, name.Length - 4);
            else if (name.Equals("InventoryProducts"))  return "Inventory";
            return null;
        }

        bool BuildStructTable(ref Dictionary<string, List<DB.SqlColumnStruct>> StructLocal, out Dictionary<string, DB.TableInfo> TableInfoLocal,
                              ref Dictionary<string, List<DB.SqlColumnStruct>> StructCloud, out Dictionary<string, DB.TableInfo> TableInfoCloud,
                              ref Dictionary<string,List<DB.SqlColumnStruct>> StructRegion, out Dictionary<string, DB.TableInfo> TableInfoRegion)
        {
            TableInfoCloud = new Dictionary<string, DB.TableInfo>();
            TableInfoLocal = new Dictionary<string, DB.TableInfo>();
            TableInfoRegion = new Dictionary<string, DB.TableInfo>();
            if (!DoCheckSyncTable("本地", LocalServer, ref StructLocal, out TableInfoLocal)) return false;     // 檢查是否存在,再載入存於SyncTable的TableID
            if (!DoCheckSyncTable("雲端", CloudServer, ref StructCloud, out TableInfoCloud)) return false;
            if (!DoCheckSyncMD5Old("本地", LocalServer, ref StructLocal)) return false;
            if (!DoCheckSyncMD5Old("雲端", CloudServer, ref StructCloud)) return false;
            ShowStatus("取得本地ForeignKey定義!");
            List<DB.ForeignKey> listFKLocal = DB.GetForeignKey(LocalServer);
            ShowStatus("取得雲ForeignKey定義!");
            List<DB.ForeignKey> listFKCloud = DB.GetForeignKey(CloudServer);
            // Region資料庫目前沒有ForeignKey

            ShowStatus("取得區域資料庫結構!");
            // 區域資料庫的同步不記憶在SyncMD5, 是雲端直接覆蓋本地, 故不用做[SyncTalbe] Map TableID
            TableInfoRegion=DB.AssignTableID_InitTableInfo(RegionServer, StructRegion);
            if (TableInfoRegion == null)
            {
                Message("=========區域資料庫(Region)結構讀取失敗!==========");
                return false;
            }


            Message("=========比對本地及雲端資料庫==================");
            // 填入 Struct及PrimaryKeys
            DB.FillStructAndTableInfo(LocalServer , ref StructLocal , ref TableInfoLocal);
            DB.FillStructAndTableInfo(CloudServer , ref StructCloud , ref TableInfoCloud);
            DB.FillStructAndTableInfo(RegionServer, ref StructRegion, ref TableInfoRegion);

            // 比對Local及Cloud每個Table的檔案結構是否相同
            List<string> keys = StructLocal.Keys.ToList();
            List<string> cloudKeys = StructCloud.Keys.ToList();
            foreach (string cloud in cloudKeys)              // Cloud Database和Region相同的移除
            {
                if (StructRegion.ContainsKey(cloud))
                    StructCloud.Remove(cloud);
            }
            List<string> shouldRemoved = new List<string>();
            foreach (string local in keys)
            {
                string errMsg;
                string fatherName = null;
                if (local == DB.SyncDataTable.SyncMD5Now.ToString()) continue;    // Md5Now檔案二端同時自動產生, 不用比較
                if (local == "DrawerRecord")
                {
                    shouldRemoved.Add(local);
                    continue;                            // 量大此資料不同步                          
                }
                ShowStatus("比對 " + local);
                if (StructCloud.ContainsKey(local))
                {
                    fatherName = GetFatherByNameRule(local);
                    if (fatherName != null)                                               // 根據命名規則有Father,結果找不到Father檔,有問題
                        if (!StructLocal.ContainsKey(fatherName)) fatherName = null;      // 主檔不存在,表示不是副檔,只是取名為%Detail或%Item
                                                                                          // 例如BankDetail其實不是副檔,沒有主檔叫Bank
                    if (!DB.SameStructWithPK(StructLocal[local], StructCloud[local],out errMsg))
                    {
                        Message(local+"不同 -> " +errMsg);
                        if (local.Length > 4 && local.Substring(0, 4) == "Sync")
                        {
                            MessageBox.Show("Table[Sync*] 為同步所需檔案,不可不同,同步停止!");
                            return false;
                        }
                        shouldRemoved.Add(local);
                        if (fatherName != null) shouldRemoved.Add(fatherName);  // 副檔不同,主檔也不同步. 
                    }
                    else if (DB.GetFirstKeyType(StructLocal[local]) == DB.PrimaryKeyType.Unknown)
                    {
                        Message("未知主Key   <" + local + ">");
                        shouldRemoved.Add(local);
                    }
                    else
                    {
                        if (fatherName != null)  // 建立子表
                        {
                            DB.TableInfo fatherInfo, fatherInfoCloud;
                            BuildChildInfo(fatherName, local, StructLocal, TableInfoLocal, listFKLocal, out fatherInfo);
                            BuildChildInfo(fatherName, local, StructCloud, TableInfoCloud, listFKCloud, out fatherInfoCloud);
                            if (!DB.SameForeignKey(fatherInfo, fatherInfoCloud))
                            {
                                Message("FK不同    <" + fatherName + "-" + local + ">");
                                shouldRemoved.Add(fatherName);
                            }
                            else
                            {
                                if (fatherInfo.PrimaryKeys == null || fatherInfo.PrimaryKeys.Count == 0)
                                {
                                    Message("必需有主Key<" + fatherName + ">");
                                    shouldRemoved.Add(fatherName);
                                    fatherName = null;
                                }
                                else if (!DB.IsForeignKeyDeleteActionCascade(fatherInfo))
                                {
                                    Message("規定FK的刪除規則必需為CASCADE <" + fatherName + "-" + local + ">");
                                    shouldRemoved.Add(fatherName);
                                    fatherName = null;
                                }
                            }
                        }
                    }
                }
                else if (StructRegion.ContainsKey(local))  // 比對區域和本地
                {
                    fatherName = GetFatherByNameRule(local);
                    if (fatherName != null)
                    {
                        shouldRemoved.Add(fatherName);   // 目前區域資料庫同步不支援有子表的
                        Message("區域資料庫暫不支援有子表的 " + fatherName+"+"+local);
                    }
                    else
                    {
                        if (!DB.SameStructWithPK(StructLocal[local], StructRegion[local], out errMsg))
                        {
                            Message(local + "不同 -> " + errMsg);
                            shouldRemoved.Add(local);
                            if (fatherName != null) shouldRemoved.Add(fatherName);  // 副檔不同,主檔也不同步. 
                        }
                        else if (DB.GetFirstKeyType(StructLocal[local]) == DB.PrimaryKeyType.Unknown)
                        {
                            Message("未知主Key   <" + local + ">");
                            shouldRemoved.Add(local);
                        }
                    }
                }
                else
                {
                    Message("雲端及區域無 " + local);
                    shouldRemoved.Add(local);
                }
                if (fatherName != null) shouldRemoved.Add(local);  // 副檔案不用各別計算 
            }
            foreach (string name in shouldRemoved)
            {
                StructLocal.Remove(name);
                StructCloud.Remove(name);
                StructRegion.Remove(name);
            }

            ShowStatus("資料庫結構比對完成!");
            Message("============ 以上資料庫將不進行同步! ===========");
            
            return true;
        }


        private void CloudSyncOnce()
        {
            Message("=========開始同步  " + DateTime.Now.ToShortTimeString() + "  ===================");
            if (!ConnectAllServer()) return;                                                               // 連本机 連雲端
            Dictionary<string, List<DB.SqlColumnStruct>> StructLocal = DB.GetTablesName(LocalServer);      // 本机所有TableName
            Dictionary<string, List<DB.SqlColumnStruct>> StructCloud = DB.GetTablesName(CloudServer);
            Dictionary<string, List<DB.SqlColumnStruct>> StructRegion= DB.GetTablesName(RegionServer);     // Region的同步不使用MD5檔去記憶,所以不需要記憶TableID . 每次生成再指定就好
            
            Dictionary<string, DB.TableInfo> TableInfoLocal;                                   // 在本地SyncTable內的TableName及TableID 
            Dictionary<string, DB.TableInfo> TableInfoCloud;                                   // 在云端SyncTable內的TableName及TableID  
            Dictionary<string, DB.TableInfo> TableInfoRegion;                                  // Region的同步不使用 記憶MD5檔去比對,所以不需要TableID建表 . 每次生成再指定就好       
       
            if (!BuildStructTable(ref StructLocal , out TableInfoLocal, ref StructCloud, out TableInfoCloud,
                                  ref StructRegion, out TableInfoRegion  )) return;

            DamaiDataSet.SyncMD5OldDataTable MD5LocalDataTable = new DamaiDataSet.SyncMD5OldDataTable();
            DamaiDataSet.SyncMD5OldDataTable MD5CloudDataTable = new DamaiDataSet.SyncMD5OldDataTable();

            // 找出MD5Old和現有Record的不同
            foreach (var table in StructLocal)
            {
                string tableName = table.Key;
                if (tableName.StartsWith("Sync")) continue;                            // 同步系統用檔案不用算Md5
                if (RegionDatabase(tableName)) continue;                               // RegionDatabase暫不同步,將來再處理,只准云端蓋本地
                //if (tableName != "Expense") continue;
                DB.TableInfo tableInfoLocal = null, tableInfoCloud = null;
                if (!TableInfoLocal.TryGetValue(tableName, out tableInfoLocal))
                {
                    Message("無法找到本地[" + tableName + "]的TableInfo!");
                    continue;
                }

                DataSet localDataSet = new DataSet();
                string msg = "同步<" + tableName;
                if (tableInfoLocal.Childs != null)
                    foreach (var child in tableInfoLocal.Childs)
                        msg += "-" + child.Name;
                msg += "> ";
                msg = msg.PadRight(35);

                // 算出 所有Table MD5Now
                // 比對新舊MD5 找出變更及新增資料 建差異表md5ResultLocal
                // 算本地的MD5Now (Order OrderItem及DrawerRecord不算)
                Dictionary<Guid, DB.Md5Result> md5ResultLocal = DB.CalcCompMd5(tableInfoLocal, LocalServer, ref localDataSet, ref MD5LocalDataTable);
                if (md5ResultLocal == null)
                {
                    msg += " 本地出錯!";
                    Message(msg);
                    continue;
                }
                else msg += " 本地 Ok";

                DataSet cloudDataSet = new DataSet();
                Dictionary<Guid, DB.Md5Result> md5ResultCloud = null;
                if (!TableInfoCloud.TryGetValue(tableName, out tableInfoCloud)) continue;

                string msgCloud = "";
                if (AllowCloudToLocal(tableName))
                {
                    // 算雲端的MD5Now (Order OrderItem及DrawerRecord不算)
                    // 比對新舊MD5 找出變更及新增資料 建差異表md5ResultCloud
                    md5ResultCloud = DB.CalcCompMd5(tableInfoCloud, CloudServer, ref cloudDataSet, ref MD5CloudDataTable);  // 這個將來一定要在雲端做,Unchanged就不傳回
                    if (md5ResultCloud == null)
                    {
                        msg += " 雲端出錯!";
                        Message(msg);
                        continue;
                    }
                    else msgCloud += " 雲端";
                    foreach (var pair in md5ResultCloud)
                    {
                        if (pair.Value.Status == DB.RowStatus.Unchanged) continue;
                        DB.Md5Result val;
                        if (md5ResultLocal.TryGetValue(pair.Key, out val))
                        {
                            if (val.Status != DB.RowStatus.Unchanged)    // 雲端和本地同時變更的,雲端被蓋
                                val.Status = DB.RowStatus.Unchanged;
                        }
                    }
                }
                else msgCloud += " 雲端不作業";

                if (tableName == "Order")           // Order不會在UpdateComp表裏載入Source的OrderItem資料,要自己來. Dest資料在UpdateRealDataByMd5Result裏進行
                    LoadOrderItem(localDataSet, tableInfoLocal, LocalServer);
                else if (SpecialMD5(tableName))     // 特殊MD5的資料沒有載入本地資料
                {
                    if (localDataSet.Tables[tableName] == null)
                    {
                        DataTable tableSource = new DataTable();
                        try
                        {
                            SqlDataAdapter adapterNow = new SqlDataAdapter("Select * From [" + tableName + "]", LocalServer);
                            adapterNow.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                            adapterNow.Fill(tableSource);
                            localDataSet.Tables.Add(tableSource);
                        }
                        catch (Exception ex) { Message(msg + "載入[" + tableName + "]出錯,原因:" + ex.Message); continue; };
                    }
                }
                var changedLocal = from loc in md5ResultLocal.Values where loc.Status != DB.RowStatus.Unchanged select loc;
                if (changedLocal.Count() != 0)
                {
                    if (!UpdateRealDataByMd5Result(tableName, "雲端", CloudServer, tableInfoLocal, tableInfoCloud, localDataSet, cloudDataSet, md5ResultLocal)) goto Next;
                }
                List<DB.Md5Result> changedList = changedLocal.ToList();
                int localChangedCount = changedLocal.Count();
                int cloudChangedCount = 0;
                if (AllowCloudToLocal(tableName))
                {   // 自雲端取資料改本地部分
                    var changedCloud = (from cld in md5ResultCloud.Values where cld.Status != DB.RowStatus.Unchanged select cld).ToList();
                    if (changedCloud.Count() != 0)
                    {
                        if (SpecialMD5(tableName)) // SpecialMD5的雲端資料還沒取過
                        {
                            var cloudRunnings = new List<DB.RunningSet>();
                            DataTable cloudDataTable = cloudDataSet.Tables[tableName];
                            if (!LoadChangedDataOneByOne(tableName, "雲端", tableInfoCloud, cloudDataSet, CloudServer, ref cloudDataTable, ref cloudRunnings, ref changedCloud))
                            {
                                Message("特殊MD5資料庫<" + tableName + ">逐筆讀取雲端資料時失敗!");
                                continue;
                            }
                        }
                        if (!UpdateRealDataByMd5Result(tableName, "本地", LocalServer, tableInfoCloud, tableInfoLocal, cloudDataSet, localDataSet, md5ResultCloud)) goto Next;
                    }
                    cloudChangedCount = changedCloud.Count();
                    changedList.AddRange(changedCloud);
                    int tableIDCloud = DB.FindTableID(tableName, TableInfoCloud);
                    ShowStatus("更新雲端[" + tableName + " MD5] " + localChangedCount.ToString() + "筆!");
                    DB.UpdateMd5Old(changedList, tableIDCloud, CloudServer, MD5CloudDataTable);
                }

                int tableIDLocal = DB.FindTableID(tableName, TableInfoLocal);
                ShowStatus("更新本地[" + tableName + " MD5] " + changedList.Count().ToString() + "筆!");
                DB.UpdateMd5Old(changedList, tableIDLocal, LocalServer, MD5LocalDataTable);
                msg += "(" + localChangedCount.ToString() + "),";
                msgCloud += "(" + cloudChangedCount.ToString() + ")!";
                Message(msg + msgCloud);
            Next:
                GC.Collect();
            }
            // 更新SyncTable
            DB.UpdateSyncTable(TableInfoLocal, LocalServer);
            DB.UpdateSyncTable(TableInfoCloud, CloudServer);


            // 記錄 Deleted 到雲端資料庫,記錄為(雲端Deleted版本号+1), 刪除雲端相對記錄
            // Call雲端StoredProcedure 比對MD5Old和現有Record,去除己在Deleleted之外 為雲端這段時間 Deleted
            // 查目前版本号後的Deleted, 執行刪除本地. Deleted版本号設為 為雲端Deleted版本号+1
            // Deleted如果有新增 雲端Deleted版本號++



            // 傳回各表總MD5 及雲端差異表

            // 只存在本地差異表抓雲端, 沒有的新建


            // 己有的 (1 雲MD5和本地MD5同不動 2 雲端的MD5和本地Md5Old相同則蓋雲端 3 沒有1 2就本地蓋雲端)

            // 只存在雲端差異表抓本地,沒有的新建
            // 己有   (1 本地MD5和雲相MD5同不動 2 本地的MD5和雲端MD5Old相同者蓋本地 3 沒有1 2 就雲端蓋本地)

            // 同時存在二個差異表的, (1 MD5相同不動 2 雲端MD5和本地MD5Old相同者蓋雲端 3 本地MD5和雲端MD5Old相同者蓋本地 4 看合理LastUpdated新的蓋舊的雙記Log 5 都否本地蓋雲端雙記Log)
            // 
            // 建雲端MD5特徵表, 傳 16*(48) 的三維MD5特徵, 遞迴找出雲端和本地不同者
            // 只有一方有的, 增至另一方.
            // 不同者 ( 1 本地的MD5等於雲端的MD5Old蓋掉本地 2 雲端的MD5和本地的Md5Old同則蓋雲端


            // 將本地及雲端 MD5Now 放到 MD5Old, MD5Now清空
            // 解鎖同步
            Message("=========本次同步完成" + DateTime.Now.ToShortTimeString() + "=================");
            ShowStatus("同步完成!");
        }

        private void ShowStatus(string msg)
        {
            labelStatus.Text = msg;
            Application.DoEvents();
        }

        private void btnClearMessage_Click(object sender, EventArgs e)
        {
            listBoxMessage.Items.Clear();
            Application.DoEvents();
        }

        private void btnStartSync_Click(object sender, EventArgs e)
        {
            AllowLeave = false;
            btnExit.Enabled = false;
            btnClearMessage.Enabled = false;
            btnStartSync.Enabled = false;
            Application.DoEvents();
            CloudSyncOnce();
            btnExit.Enabled = true;
            btnClearMessage.Enabled = true;
            btnStartSync.Enabled = true;
            AllowLeave = true;
        }

        private void listBoxMessage_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index >= 0)
                e.Graphics.DrawString(listBox.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }

        private void btnExit_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = char.ToLower(e.KeyChar);
            switch (c)
            {
                case 's': this.btnClearCloundMemory.Visible =btnClearLocalMemory.Visible= true; break;
            }

        }

        private void btnClearLocalMemory_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("清除本地記憶後同步,會將本地所有資料上傳,\r\n耗癈大量時間,上次同步後在雲端所做變更可能被還原,\r\n確定清除嗎?",
                    "", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            if (LocalServer == null)
                LocalServer = ConnectServer("本地",  m_Cfg.Database, m_Cfg.Local);
            if (LocalServer == null) return;
            if (DB.DropTable(DB.SyncDataTable.SyncMD5Old.ToString(), LocalServer))
            {
                DB.AskCreateDataTable("本地", DB.SyncDataTable.SyncMD5Old, LocalServer);
                Message("========新創建本地同步用記憶表!=================");
                ShowStatus("本地記憶己清除!");
                Message("=========本地記憶己清除!=======================");
            }
            else
                Message("=========本地記憶清除失敗!=====================");

        }

        private void btnClearCloundMemory_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("清除雲端記憶後同步,會將雲端所有資料下載,\r\n耗癈大量時間,上次同步後在本地所做變更可能被還原,\r\n確定清除嗎?",
                    "", MessageBoxButtons.OKCancel) != DialogResult.OK) return;

            if (CloudServer == null)
                CloudServer = ConnectServer("雲端", m_Cfg.Database, m_Cfg.Cloud);
            if (CloudServer == null) return;
            if (DB.DropTable(DB.SyncDataTable.SyncMD5Old.ToString(), CloudServer))
            {
                DB.AskCreateDataTable("雲端", DB.SyncDataTable.SyncMD5Old, CloudServer);
                Message("========新創建雲端同步用記憶表!=================");
                ShowStatus("雲端記憶己清除!");
                Message("=========雲端記憶己清除!=======================");
            }
            else
                Message("=========雲端記憶清除失敗!=====================");
        }



    }
}
