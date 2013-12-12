using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.IO;
#if UseSQLServer
using MyDataSet = VoucherExpense.DamaiDataSet;
using MyConfigAdapter = VoucherExpense.DamaiDataSetTableAdapters.ConfigTableAdapter;
#else
using MyDataSet = VoucherExpense.VEDataSet;
using MyConfigAdapter = VoucherExpense.VEDataSetTableAdapters.ConfigTableAdapter;
#endif

namespace VoucherExpense
{
    class Config
    {
        MyDataSet m_Dataset = new MyDataSet();
        MyConfigAdapter adapter = new MyConfigAdapter();
        public Config()
        {
#if !UseSQLServer
            adapter.Connection = MapPath.VEConnection;
#endif
            try
            {
                adapter.Fill(m_Dataset.Config);
            }
            catch (Exception ex)
            {
                MessageBox.Show("無法讀入Config,原因:" + ex.Message);
            }
        }

        public List<XmlNode> LoadAll(string ConfigName)
        {
            List<XmlNode> list = new List<XmlNode>();
            foreach (var row in m_Dataset.Config)
            {
                if (row.Name.Trim() == ConfigName.Trim())
                {
                    try
                    {
                        XmlDocument xml = new XmlDocument();
                        xml.LoadXml(row.Content);
                        list.Add(xml.DocumentElement);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + " in {" + ConfigName + "}<=\r\n記錄出錯,己自動移除,請存檔");
                        row.Delete();
                    }
                }
            }
            return list;
        }

        public XmlNode Load(string ConfigName,string Name)
        {
            foreach (var row in m_Dataset.Config)
            {
                if (row.Name.Trim() == ConfigName.Trim())
                {
                    try
                    {
                        XmlDocument xml=new XmlDocument();
                        xml.LoadXml(row.Content);
                        XmlNode root = xml.DocumentElement;
                        XmlAttribute attr = root.Attributes["Name"];
                        if (attr == null)
                        {
                            if (Name!=null) continue;
                            return root;
                        }
                        if (attr.Value==Name) return root;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message + " in {" + ConfigName + "}<=\r\n記錄出錯,己自動移除,請存檔");
                        row.Delete();
                    }
                }
            }
            return null;
        }

        public bool Save(string configName,string tableName, string content)
        {
            if (content.Length > 32787) return false;       // 太大了,不讓存
            foreach (var row in m_Dataset.Config)
            {
                if (row.Name.Trim() == configName.Trim())
                {
                    string rootName="";
                    try
                    {
                        XmlDocument xml = new XmlDocument();
                        xml.LoadXml(row.Content);
                        XmlAttribute attr = xml.DocumentElement.Attributes["Name"];
                        if (attr == null)
                        {
                            if (tableName != null)  continue;
                            // 沒有TableName 的Config
                        }
                        else
                        {
                            rootName = attr.Value.Trim();
                            if (rootName != tableName) continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + " in " + configName);
                        row.Delete();   // 壞的,刪掉
                        continue;
                    }

                    row.Content = content;
                    goto Update;
                }
            }
            var r = m_Dataset.Config.NewConfigRow();
            r.Name = configName;
            r.Content = content;
            int max = 0;
            foreach (var row in m_Dataset.Config)
            {
                if (row.ID > max) max = row.ID;
            }
            r.ID = max + 1;
            m_Dataset.Config.AddConfigRow(r);
        Update:
            try
            {
                adapter.Update(m_Dataset.Config);
                return true;
            }
            catch { }
            return false;
        }

        public bool Remove(string configName, string tableName)
        {
            foreach (var row in m_Dataset.Config)
            {
                if (row.Name.Trim() == configName.Trim())
                {
                    string rootName = "";
                    try
                    {
                        XmlDocument xml = new XmlDocument();
                        xml.LoadXml(row.Content);
                        XmlAttribute attr = xml.DocumentElement.Attributes["Name"];
                        if (attr == null)
                        {
                            if (tableName != null) continue;
                            // 沒有TableName 的Config
                        }
                        else
                        {
                            rootName = attr.Value.Trim();
                            if (rootName != tableName) continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + " in " + configName);
                        continue;
                    }
                    try
                    {
                        row.Delete();
                        adapter.Update(m_Dataset.Config);
                        return true;
                    }
                    catch { }
                    return false;
                }
            }
            return false;
        }

        public bool Export(string configName, string tableName,string title)
        {
            if (tableName.Length < 2)
            {
                MessageBox.Show("請輸入正確的匯出名稱!");
                return false;
            }
            XmlNode node = Load(configName, tableName);
            if (node == null)
            {
                MessageBox.Show("查無此設定!請輸入正確的名稱");
                return false;
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Xml | *.xml";
            dialog.FileName = tableName;
            dialog.Title = title;
            DialogResult result = dialog.ShowDialog();
            if (result != DialogResult.OK) return false;
            File.WriteAllText(dialog.FileName, node.OuterXml, Encoding.Unicode);
            MessageBox.Show("己存檔至<" + dialog.FileName + ">");
            return true;
        }

        public bool Import(string configName)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = "";
            dialog.Title = "選擇匯入的檔案";
            dialog.Filter = "Xml|*.xml";
            DialogResult result = dialog.ShowDialog();
            if (result != DialogResult.OK) return false;
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(dialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入XML設定檔失敗! 錯誤<" + ex.Message + "> 請檢查檔案內容是否正確!");
                return false;
            }
            XmlNode root = xml.SelectSingleNode(configName);
            if (root == null)
            {
                MessageBox.Show("你選擇的檔案,並不是<"+configName+">設定檔!");
                return false;
            }
            XmlAttribute attr = root.Attributes["Name"];
            if (attr == null || attr.Value == null || attr.Value.Length < 2)
            {
                MessageBox.Show("設定檔內找不到名稱! 設定檔己經損壞,無法載入");
                return false;
            }
            string name = attr.Value;
            XmlNode node = Load(configName, attr.Value);
            if (node != null)
            {
                if (MessageBox.Show("要覆蓋現有<" + name + ">設定嗎?", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    MessageBox.Show("己取消, 未匯入");
                    return false;
                }
            }
            Save(configName, name, root.OuterXml);
            MessageBox.Show("己匯入設定<" + name + ">");
            return true;
        }
    }
}
