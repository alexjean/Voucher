using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace VoucherExpense
{
    public class HardwareConfig
    {
        public static string CfgFileName = "HardwareCfg.xml";
        public string PrinterName;
        public string ComPortName;
        public string DataDir;
        public string UserName;
        public string Password;
        public bool   IsServer;
        public string BackupDir;


        public string MaskDataDir()
        {
            if (DataDir == null) return "";
            int len=DataDir.Length;
            if (len==0) return "";
            string str ;
            if (DataDir[len - 1] == '\\') len--;
            str = DataDir.Substring(0, len);
            int i=str.LastIndexOf('\\')+2;
            if   (i >= len) i = len - 1;
            StringBuilder sb= new StringBuilder(str.Substring(0, i));
            for (; i < len; i++) sb.Append('*');
            return sb.ToString();
        }

        public HardwareConfig()
        {
            IsServer = true;
        }

        void GetAttrib(XmlNode node,string attrib,ref string name)
        {
            if (node == null) return;
            XmlAttribute att = node.Attributes[attrib];
            if (att == null)
            {
                name = null;
                return;
            }
            string str = att.Value;    // 沒有這個attrib 則 name=null
            name = str;
        }

        const string Key = "LordAlex";
        void GetEncryptedAttrib(XmlNode node, string attrib, ref string name)
        {
            if (node == null) return;
            XmlAttribute att = node.Attributes[attrib];
            if (att == null)
            {
                name = null;
                return;
            }
            string str = att.Value;    // 沒有這個attrib 則 name=null
            if (str == null || str.Length ==0)
            {
                name = "";
                return;
            }
            try
            {
                byte[] bufs = Encoder.RC2Decrypt(Convert.FromBase64String(str), Key);
                name = Encoding.Unicode.GetString(bufs);
            }
            catch
            {
                name = null;
            }
        }

        public void Load()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(CfgFileName);
                XmlNode root = doc.DocumentElement;
                GetAttrib(root.SelectSingleNode("ComPort")       ,"Name", ref ComPortName);
                GetAttrib(root.SelectSingleNode("ReceiptPrinter"),"Name", ref PrinterName);

                XmlNode Server = root.SelectSingleNode("DataSource");
                if (Server != null)
                {
                    string str = "";
                    GetAttrib(Server, "IsServer", ref str);
                    if (str != null && str.ToUpper() == "NO") IsServer = false;
                    else IsServer = true;
                    GetEncryptedAttrib(Server, "DataDir", ref DataDir);
                    GetEncryptedAttrib(Server, "UserName", ref UserName);
                    GetEncryptedAttrib(Server, "Password", ref Password);
                    GetEncryptedAttrib(Server, "BackupDir", ref BackupDir);
                }
            }
            catch { }
        }

        public void Save()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(@"<HardwareConfig />");
            XmlNode root = doc.FirstChild;
            UpdateXmlAttrib(doc, root, "ComPort"       , "Name" , ComPortName);
            UpdateXmlAttrib(doc, root, "ReceiptPrinter", "Name" , PrinterName);
            UpdateXmlAttrib(doc, root, "DataSource", "IsServer" , (IsServer ? "YES" : "NO"));
            UpdateXmlAttribEncrypted(doc, root, "DataSource", "DataDir", DataDir);
            UpdateXmlAttribEncrypted(doc, root, "DataSource", "UserName", UserName);
            UpdateXmlAttribEncrypted(doc, root, "DataSource", "Password", Password);
            UpdateXmlAttribEncrypted(doc, root, "DataSource", "BackupDir", BackupDir);
            doc.Save(CfgFileName);
        }

        protected void UpdateXmlText(XmlDocument xml, XmlNode root, string Name, string Text)
        {
            XmlNode node = root.SelectSingleNode(Name);
            if (node == null)
            {
                node = xml.CreateElement(Name);
                root.AppendChild(node);
            }
            XmlText text = xml.CreateTextNode(Text);
            node.AppendChild(text);
        }

        protected void UpdateXmlAttrib(XmlDocument xml, XmlNode root, string Name, string Attrib, string Value)
        {
            XmlNode node = root.SelectSingleNode(Name);
            if (node == null)
            {
                node = xml.CreateElement(Name);
                root.AppendChild(node);
            }
            XmlAttribute att = xml.CreateAttribute(Attrib);
            att.Value = Value;
            node.Attributes.Append(att);
        }

        protected void UpdateXmlAttribEncrypted(XmlDocument xml, XmlNode root, string Name, string Attrib, string Value)
        {
            XmlNode node = root.SelectSingleNode(Name);
            if (node == null)
            {
                node = xml.CreateElement(Name);
                root.AppendChild(node);
            }
            XmlAttribute att = xml.CreateAttribute(Attrib);

            byte[] bufs=Encoder.RC2Encrypt(Encoding.Unicode.GetBytes(Value),Key);
            att.Value = Convert.ToBase64String(bufs);

            node.Attributes.Append(att);
        }


    }
}
