using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SyncCloud
{
    public partial class FormSync : Form
    {
        public FormSync()
        {
            InitializeComponent();
        }

        XmlConfig m_Cfg = new XmlConfig();
        SqlConnection LocalServer, CloudServer;
        private void FormSync_Load(object sender, EventArgs e)
        {
            m_Cfg.Load();
        }


        bool ConnectBothServer()
        {
            try
            {
                ShowStatus("開啟本地資料庫!");
                LocalServer = new SqlConnection(DB.SqlConnectString(m_Cfg.LocalServer, m_Cfg.LocalDatabase, m_Cfg.LocalUserId, m_Cfg.LocalPassword));
                LocalServer.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("開啟本地服務器失敗,原因:" + ex.Message);
                CloudServer = LocalServer = null;
                return false;
            }
            try
            {
                ShowStatus("開啟雲端資料庫!");
                CloudServer = new SqlConnection(DB.SqlConnectString(m_Cfg.CloudServer, m_Cfg.CloudDatabase, m_Cfg.CloudUserId, m_Cfg.CloudPassword));
                CloudServer.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("開啟雲端服務器失敗,原因:" + ex.Message);
                CloudServer=LocalServer = null;
                return false;
            }
            return true;
        }

        void Message(string msg)
        {
            listBoxMessage.Items.Add(msg);
            Application.DoEvents();
        }

        bool DoCheckSyncTable(string title, SqlConnection conn,ref Dictionary<string,List<DB.SqlColumnStruct>> dicStruct,ref Dictionary<string,DB.TableInfo> dicTableID)
        {
            if (!dicStruct.ContainsKey("SyncTable"))
            {
                if (!DB.AskCreateDataTable(title, DB.SyncDataTable.SyncTable, conn))
                    goto FAIL;
                if (!DB.DropTable("SyncMD5Old", conn)) goto FAIL;
            }
            if (!DB.CheckSyncTable(conn, title))                 // 檢查SyncTable存在
            {
                Message(title+"SyncTable檢查失敗!");
                goto FAIL;
            }
            dicTableID = DB.GetTableID(conn);                   // 分別載入Local及Cloud的存在SyncTable中的TableID
            return true;
         FAIL:
            Message("==============================================");
            return false;
        }

        bool DoCheckSyncMD5Old(string title, SqlConnection conn, ref Dictionary<string,List<DB.SqlColumnStruct>> dicStructs)
        {
            if (!dicStructs.ContainsKey("SyncMD5Old"))
            {
                if (DB.AskCreateDataTable(title, DB.SyncDataTable.SyncMD5Old, conn))
                    MessageBox.Show("己創建"+title+"<SyncMD5Old>, 請再執行同步!");
                Message("======================================================");
                return false;
            }
            return true;
        }

        object FindIntKey(byte[] PrimaryKey, int offset,SqlDbType DbType)
        {
            switch (DbType)
            {
                case SqlDbType.BigInt:      return (object)BitConverter.ToInt64(PrimaryKey, offset); 
                case SqlDbType.Int:         return (object)BitConverter.ToInt32(PrimaryKey, offset); 
                case SqlDbType.SmallInt:    return (object)BitConverter.ToInt16(PrimaryKey, offset);
                case SqlDbType.TinyInt:     return (object)PrimaryKey[offset]; 
            }
            return null;
        }

        DataRow GetRowFromGuidPrimaryKey(Guid guidPrimaryKey, DataTable table, List<DB.SqlColumnStruct> colStruct)
        {
            var Keys=from st in colStruct where st.IsPrimaryKey select st;
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
                        case DB.PrimaryKeyType.IntCombined:      return table.Rows.Find(FindIntKey(PrimaryKey, 0, key.DbType));
                        case DB.PrimaryKeyType.UniqueIdentifier: return table.Rows.Find(guidPrimaryKey);
                        case DB.PrimaryKeyType.String:           return table.Rows.Find(Encoding.Unicode.GetString(PrimaryKey));    // 最多支援8個字的Unicode???
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
            catch(Exception ex)
            {
                Message("程式或資料錯誤！<GetRowFromPrimaryKeyBinary16>["+table.TableName+"] 原因:" + ex.Message);
                throw ex;
            }
            return null;
        }

        void CopyRow(DataRow source,DataRow dest,List<DB.SqlColumnStruct> colStruct)
        {
            foreach (var col in colStruct)
                dest[col.Name] = source[col.Name];
        }

        void UpdateData(string title,string tableName, DataTable table, SqlConnection conn)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From "+tableName,conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(adapter);
            try
            {
                cb.GetUpdateCommand();
                cb.GetInsertCommand();
                cb.GetDeleteCommand();
                adapter.Update(table);
            }
            catch (Exception ex)
            {
                Message(title + "寫出<" + tableName + ">錯誤,原因:" + ex.Message);
            }
        }

        private void menuItemBeginSync_Click(object sender, EventArgs e)
        {
            if (!ConnectBothServer()) return;                                                           // 連本机 連雲端
            Dictionary<string,List<DB.SqlColumnStruct>> StructLocal = DB.GetTablesName(LocalServer);    // 本机所有TableName
            Dictionary<string,List<DB.SqlColumnStruct>> StructCloud = DB.GetTablesName(CloudServer);
            var TableInfoLocal = new Dictionary<string, DB.TableInfo>();                                  // 在SyncTable內的TableName及TableID 
            var TableInfoCloud = new Dictionary<string, DB.TableInfo>();
            //if (!StructCloud.ContainsKey("SyncUpdatedVersion"))
            //{
            //    if (!DB.AskCreateDataTable("雲端", DB.SyncDataTable.SyncUpdatedVersion, CloudServer))
            //        return;
            //}

            if (!DoCheckSyncTable ("本地", LocalServer, ref StructLocal, ref TableInfoLocal)) return;
            if (!DoCheckSyncTable ("雲端", CloudServer, ref StructCloud, ref TableInfoCloud)) return;
            if (!DoCheckSyncMD5Old("本地", LocalServer, ref StructLocal)) return;
            if (!DoCheckSyncMD5Old("雲端", CloudServer, ref StructCloud)) return;

            //int updatedVersion;
            //if (!DB.GetDeletedVersion(CloudServer, out updatedVersion))  // 雲端Deleted的版本号
            //{
            //    MessageBox.Show("無法取得或鎖定雲端己更新版本号!");
            //    return;
            //}
            //Message("雲端己更新版本号為<"+updatedVersion.ToString()+">");
            Message("======比對本地及雲端資料庫================");
            // 比對Local及Cloud每個Table的檔案結構是否相同
            List<string> keys = StructLocal.Keys.ToList<string>();
            foreach(string local in keys) 
            {
                if (local == DB.SyncDataTable.SyncMD5Now.ToString()) continue;    // Md5Now檔案二端同時自動產生, 不用比較
                if (local == "DrawerRecord")
                {
                    StructLocal.Remove(local);
                    continue;                            // 量大此資料不同步                          
                }
                ShowStatus("比對 " + local);
                if (StructCloud.ContainsKey(local))
                {
                    StructLocal[local] = DB.GetStruct(local, LocalServer);
                    StructCloud[local] = DB.GetStruct(local, CloudServer);
                    DB.TableInfo me ,meCloud;
                    if (TableInfoLocal.TryGetValue(local, out me     ))  me.Struct        = StructLocal[local];
                    if (TableInfoCloud.TryGetValue(local, out meCloud))  meCloud.Struct   = StructCloud[local];
                    string fatherName = null;
                    if      (local.EndsWith("Detail"))  fatherName = local.Substring(0, local.Length - 6);
                    else if (local.EndsWith("Item"))    fatherName = local.Substring(0, local.Length - 4);
                    if (!DB.SameStructWithPK(StructLocal[local], StructCloud[local]))
                    {
                        Message("不同    " + local);
                        if (local.Length > 4 && local.Substring(0, 4) == "Sync")
                        {
                            MessageBox.Show("Table[Sync*] 為同步所需檔案,不可不同,同步停止!");
                            return;
                        }
                        StructLocal.Remove(local);
                        if (fatherName != null) StructLocal.Remove(fatherName);  // 副檔不同,主檔也不同步
                    }
                    else
                    {
                        if (fatherName != null)
                        {
                            DB.TableInfo fatherInfo,fatherInfoCloud;
                            if (TableInfoLocal.TryGetValue(fatherName, out fatherInfo))
                            {
                                fatherInfo.ChildName = local;
                                StructLocal.TryGetValue(local, out fatherInfo.ChildStruct);
                            }
                            if (TableInfoCloud.TryGetValue(fatherName, out fatherInfoCloud))
                            {
                                fatherInfoCloud.ChildName = local;
                                StructCloud.TryGetValue(local, out fatherInfoCloud.ChildStruct);
                            }
                        }
                    }
                }
                else
                {
                    Message("雲端無 " + local);
                    StructLocal.Remove(local);
                }
                if (local.EndsWith("Detail") || local.EndsWith("Item")) StructLocal.Remove(local);  // 副檔案不用各別計算 
            }
            ShowStatus("資料庫結構比對完成!");
            Message("============ 以上資料庫將不進行同步! ======");
            // 鎖定同步

            // 比對 MD5Old 找出Deleted
            /*
            if (StructLocal.Keys.Contains(DB.SyncDataTable.SyncMD5Now.ToString()))
            {
                if (MessageBox.Show("系統同步用資料庫SyncMD5Now存在, 要刪除嗎?", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                if (!DB.DropTable(DB.SyncDataTable.SyncMD5Now.ToString(),LocalServer)) return;

            }
            if (!DB.CreateDataTable(DB.SyncDataTable.SyncMD5Now, LocalServer))
            {
                Message("無法創建本地端" + DB.SyncDataTable.SyncMD5Now.ToString() + ",可能之前同步當機,請手工排除!");
                return;
            }
            */
            DamaiDataSet.SyncMD5OldDataTable MD5LocalDataTable = new DamaiDataSet.SyncMD5OldDataTable();
            DamaiDataSet.SyncMD5OldDataTable MD5CloudDataTable = new DamaiDataSet.SyncMD5OldDataTable();

            // 找出MD5Old和現有Record的不同
            foreach(var table in StructLocal)
            {
                string tableName=table.Key;
                if (tableName.StartsWith("Sync")) continue;                            // 同步系統用檔案不用算Md5
                //if (tableName != "Expense") continue;
                DB.TableInfo tableInfo;
                if (!TableInfoLocal.TryGetValue(tableName, out tableInfo)) continue;
                var colStruct = tableInfo.Struct;       // 雲端和本地一定相同,前面己經比對過,所以用同一colStruct
                DataTable localDataTable = new DataTable(tableName);
                //int tableID=DB.FindTableID(tableName,LocalTableID);
                Dictionary<Guid,DB.Md5Result> md5ResultLocal=DB.CalcCompMd5(tableInfo, LocalServer,ref localDataTable,ref MD5LocalDataTable);
                string msg="計算MD5<" + tableName;
                if (tableInfo.ChildName!=null) msg+="-"+tableInfo.ChildName;
                msg+= "> ";
                msg=msg.PadRight(35);
                if (md5ResultLocal == null) msg+=" 本地出錯,";
                else                        msg+=" 本地 Ok ,";
                DataTable cloudDataTable = new DataTable(tableName);
                if (!TableInfoCloud.TryGetValue(tableName, out tableInfo)) continue;
                Dictionary<Guid,DB.Md5Result> md5ResultCloud = DB.CalcCompMd5(tableInfo, CloudServer,ref cloudDataTable,ref MD5CloudDataTable);  // 這個將來一定要在雲端做,Unchanged就不傳回
                if (md5ResultCloud == null) msg+=" 雲端出錯!";
                else                        msg+=" 雲端 Ok !";
                Message(msg);

                foreach (var pair in md5ResultCloud)
                {
                    if (pair.Value.Status == DB.RowStatus.Unchanged) continue;
                    if (md5ResultLocal.ContainsKey(pair.Key))
                    {
                        DB.Md5Result val=pair.Value;    
                        if (val.Status != DB.RowStatus.Unchanged)    // 雲端和本地同時變更的,雲端被蓋
                            val.Status  = DB.RowStatus.Unchanged;
                    }
                }
                if (tableName != "Order")     // Order特殊處理,DB.CalcCompMd5 並未讀入Order,, 雲端不更新本地
                {
                    foreach (var pair in md5ResultLocal)
                    {
                        var re = pair.Value;
                        if (re.Status==DB.RowStatus.Unchanged) continue;
                        // 自本地取資料更新雲端真實檔案
                        try
                        {
                            DataRow localRow = GetRowFromGuidPrimaryKey(re.PrimaryKey, localDataTable, colStruct);
                            DataRow cloudRow = GetRowFromGuidPrimaryKey(re.PrimaryKey, cloudDataTable, colStruct);
                            switch (re.Status)
                            {
                                case DB.RowStatus.New:
                                case DB.RowStatus.Changed:
                                    if (localRow == null) continue;  // 應該不可能
                                    if (cloudRow == null)
                                    {
                                        cloudRow = cloudDataTable.NewRow();
                                        CopyRow(localRow, cloudRow, colStruct);
                                        cloudDataTable.Rows.Add(cloudRow);
                                    }
                                    else CopyRow(localRow, cloudRow, colStruct);
                                    break;
                                case DB.RowStatus.Deleted:
                                    if (cloudRow != null) cloudRow.Delete();
                                    break;
                                default: break;
                            }
                        }
                        catch { break; }
                    }
                    UpdateData("雲端", tableName, cloudDataTable, CloudServer);

                    // 變更雲端部分
                    foreach (var pair in md5ResultCloud)
                    {   // 自雲端取資料更新本地真實檔案
                        var re = pair.Value;
                        if (re.Status == DB.RowStatus.Unchanged) continue;
                        try
                        {
                            DataRow localRow = GetRowFromGuidPrimaryKey(re.PrimaryKey, localDataTable, colStruct);
                            DataRow cloudRow = GetRowFromGuidPrimaryKey(re.PrimaryKey, cloudDataTable, colStruct);
                            switch (re.Status)
                            {
                                case DB.RowStatus.New:
                                case DB.RowStatus.Changed:
                                    if (cloudRow == null) continue;  // 應該不可能
                                    if (localRow == null)
                                    {
                                        localRow = localDataTable.NewRow();
                                        CopyRow(cloudRow, localRow, colStruct);
                                        cloudDataTable.Rows.Add(localRow);
                                    }
                                    else CopyRow(cloudRow, localRow, colStruct);
                                    break;
                                case DB.RowStatus.Deleted:
                                    if (localRow != null) localRow.Delete();
                                    break;
                                default: break;   // 不應該有
                            }
                        }
                        catch { break; }
                    }
                    UpdateData("本地", tableName, localDataTable, LocalServer);
                    var changedLocal=from loc in md5ResultLocal.Values where loc.Status!=DB.RowStatus.Unchanged select loc;
                    var changedCloud=from cld in md5ResultCloud.Values where cld.Status!=DB.RowStatus.Unchanged select cld;
                    List<DB.Md5Result> changedList=changedLocal.ToList();
                    int tableIDLocal=DB.FindTableID(tableName,TableInfoLocal);
                    int tableIDCloud=DB.FindTableID(tableName,TableInfoCloud);
                    changedList.AddRange(changedCloud);
                    DB.UpdateMd5Old(changedList,tableIDLocal, LocalServer, MD5LocalDataTable);
                    DB.UpdateMd5Old(changedList,tableIDCloud, CloudServer, MD5CloudDataTable);
                    GC.Collect();
                }
            }
            // 更新SyncTable
            DB.UpdateSyncTable(TableInfoLocal, LocalServer);
            DB.UpdateSyncTable(TableInfoCloud, CloudServer);


            // 記錄 Deleted 到雲端資料庫,記錄為(雲端Deleted版本号+1), 刪除雲端相對記錄
            // Call雲端StoredProcedure 比對MD5Old和現有Record,去除己在Deleleted之外 為雲端這段時間 Deleted
            // 查目前版本号後的Deleted, 執行刪除本地. Deleted版本号設為 為雲端Deleted版本号+1
            // Deleted如果有新增 雲端Deleted版本號++

            // 算出 所有Table MD5Now
            // 比對新舊MD5 找出變更及新增資料 建本地差異表
            // 算雲端的MD5Now (Order OrderItem及Drawer不算)

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
            Message("=========本次同步完成" + DateTime.Now.ToShortTimeString() + "============");
            ShowStatus("同步完成!");
        }

        private void menuItemModifyPassword_Click(object sender, EventArgs e)
        {
            Form form = new FormEditPass();
            form.ShowDialog();
            m_Cfg.Load();
        }

        private void ShowStatus(string msg)
        {
            labelStatus.Text = msg;
            Application.DoEvents();
        }

        private void listBoxMessage_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(listBox.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }

    }
}
