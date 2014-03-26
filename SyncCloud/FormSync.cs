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

        private void btnEditPass_Click(object sender, EventArgs e)
        {
            Form form = new FormEditPass();
            form.ShowDialog();
            m_Cfg.Load();
        }

        bool ConnectBothServer()
        {
            try
            {
                Message("開啟本地資料庫!");
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
                Message("開啟雲端資料庫!");
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

        bool DoCheckSyncTable(string title, SqlConnection conn,ref Dictionary<string,List<DB.SqlColumnStruct>> dicStruct,ref Dictionary<string,int> dicTableID)
        {
            if (!dicStruct.Keys.Contains("SyncTable"))
            {
                if (!DB.AskCreateDataTable(title, DB.SyncDataTable.SyncTable, conn))
                    return false;
                if (!DB.DropTable("SyncMD5Old", conn)) return false;
            }
            if (!DB.CheckSyncTable(conn, title))                 // 檢查SyncTable存在
            {
                Message(title+"SyncTable檢查失敗!");
                return false;
            }
            dicTableID = DB.GetTableID(conn);                   // 分別載入Local及Cloud的存在SyncTable中的TableID
            return true;
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            if (!ConnectBothServer()) return;                           // 連本机 連雲端
            Dictionary<string,List<DB.SqlColumnStruct>> StructLocal = DB.GetTablesName(LocalServer);   // 本机所有TableName
            Dictionary<string,List<DB.SqlColumnStruct>> StructCloud = DB.GetTablesName(CloudServer);
            Dictionary<string, int> LocalTableID = new Dictionary<string, int>();
            Dictionary<string, int> CloudTableID = new Dictionary<string, int>();
            if (!StructCloud.Keys.Contains("SyncUpdatedVersion"))
            {
                if (!DB.AskCreateDataTable("雲端", DB.SyncDataTable.SyncUpdatedVersion, CloudServer))
                    return;
            }
            if (!DoCheckSyncTable("本地", LocalServer, ref StructLocal, ref LocalTableID)) return;
            if (!DoCheckSyncTable("雲端", CloudServer, ref StructCloud, ref CloudTableID)) return;

            int updatedVersion;
            if (!DB.GetDeletedVersion(CloudServer, out updatedVersion))  // 雲端Deleted的版本号
            {
                MessageBox.Show("無法取得或鎖定雲端己更新版本号!");
                return;
            }
            Message("雲端己更新版本号為<"+updatedVersion.ToString()+">");
            Message("=================================");
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
                if (StructCloud.Keys.Contains(local))
                {
                    StructLocal[local] = DB.GetStruct(local, LocalServer);
                    if (!DB.SameStruct(local, LocalServer, CloudServer))
                    {
                        Message("不同    " + local);
                        if (local.Length > 4 && local.Substring(0, 4) == "Sync")
                        {
                            MessageBox.Show("Table[Sync*] 為同步所需檔案,不可不同,同步停止!");
                            return;
                        }
                        if (local.EndsWith("Detail")) StructLocal.Remove(local.Substring(0, local.Length - 6));  // 副檔不同,主檔也不同步
                        if (local.EndsWith("Item"))   StructLocal.Remove(local.Substring(0, local.Length - 4));  // 副檔不同,主檔也不同步
                        StructLocal.Remove(local);
                    }
                }
                else
                {
                    Message("雲端無 " + local);
                    StructLocal.Remove(local);
                }
                if (local.EndsWith("Detail") || local.EndsWith("Item")) StructLocal.Remove(local);  // 副檔案不用各別計算 
            }
            Message("============ 以上資料庫將不進行同步!");
            // 鎖定同步

            // 比對 MD5Old 找出Deleted
            if (!StructLocal.Keys.Contains("SyncMD5Old"))   // SyncMD5Old不存在
            {
                if (!DB.AskCreateDataTable("本地", DB.SyncDataTable.SyncMD5Old, LocalServer))
                    return;
            }
            else
            {
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
                // 找出MD5Old和現有Record的不同
                foreach(var table in StructLocal)
                {
                    if (table.Key.StartsWith("Sync")) continue;                            // 同步系統用檔案不用算Md5
                    List<DB.Md5Result> md5s=DB.CalcCompMd5(table.Key, LocalServer,table.Value,LocalTableID);
                    if (md5s == null)
                        Message("計算比較<" +table.Key + "> Md5時出錯!");
                }
            }

            // 記錄 Deleted 到雲端資料庫,記錄為(雲端Deleted版本号+1), 刪除雲端相對記錄
            // Call雲端StoredProcedure 比對MD5Old和現有Record,去除己在Deleleted之外 為雲端這段時間 Deleted
            // 查目前版本号後的Deleted, 執行刪除本地. Deleted版本号設為 為雲端Deleted版本号+1
            // Deleted如果有新增 雲端Deleted版本號++

            // 算出 所有Table MD5Now
            // 比對新舊MD5 找出變更及新增資料 建本地差異表
            // 呼叫StoredProcedure算雲端的MD5Now (Order OrderItem及Drawer不算)
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
        }


    }
}
