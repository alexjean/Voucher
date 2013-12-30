using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Security.Cryptography;

namespace SyncCloud
{
    public class XmlConfig
    {
        public static string CfgFileName = "SyncCloudCfg.xml";
        public string LocalServer;
        public string LocalDatabase;
        public string LocalUserId;
        public string LocalPassword;
        public string CloudServer;
        public string CloudDatabase;
        public string CloudUserId;
        public string CloudPassword;
        public string Password="loveAlexLord";

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
                byte[] bufs = RC2Decrypt(Convert.FromBase64String(str), Key);
                name = Encoding.Unicode.GetString(bufs);
            }
            catch
            {
                name = null;
            }
        }      
        
        #region ====== RC2 ======
        static byte[] MySalt = { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };
        public static byte[] RC2Encrypt(byte[] clearData, string Password)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, MySalt);
            MemoryStream ms = new MemoryStream();
            RC2 alg = RC2.Create();
            alg.Key = pdb.GetBytes(8);
            alg.IV = pdb.GetBytes(8);
            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearData, 0, clearData.Length);
            cs.Close();
            byte[] encryptedData = ms.ToArray();
            return encryptedData;
        }

        public static byte[] RC2Decrypt(byte[] cipherData, string Password)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, MySalt);
            MemoryStream ms = new MemoryStream();
            RC2 alg = RC2.Create();
            alg.Key = pdb.GetBytes(8);
            alg.IV = pdb.GetBytes(8);
            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();
            byte[] decryptedData = ms.ToArray();
            return decryptedData;
        }
        #endregion

        public void Load()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(CfgFileName);
                XmlNode root = doc.DocumentElement;
                XmlNode Server = root.SelectSingleNode("ServerCfg");
                if (Server != null)
                {
                    GetEncryptedAttrib(Server, "Password"       , ref Password);
                    GetEncryptedAttrib(Server, "CloudServer"    , ref CloudServer);
                    GetEncryptedAttrib(Server, "CloudUserId"    , ref CloudUserId  );
                    GetEncryptedAttrib(Server, "CloudPassword"  , ref CloudPassword);
                    GetEncryptedAttrib(Server, "CloudDatabase"  , ref CloudDatabase);
                    GetEncryptedAttrib(Server, "LocalServer"    , ref LocalServer);
                    GetEncryptedAttrib(Server, "LocalUserId"    , ref LocalUserId);
                    GetEncryptedAttrib(Server, "LocalPassword"  , ref LocalPassword);
                    GetEncryptedAttrib(Server, "LocalDatabase"  , ref LocalDatabase);
                }
            }
            catch { }
        }

        public void Save()
        {
            SaveTo(".");
        }

        public void SaveTo(string dir)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(@"<SyncCloudCfg />");
            XmlNode root = doc.FirstChild;
            UpdateXmlAttribEncrypted(doc, root, "ServerCfg", "Password", Password);

            UpdateXmlAttribEncrypted(doc, root, "ServerCfg", "CloudServer"  , CloudServer);
            UpdateXmlAttribEncrypted(doc, root, "ServerCfg", "CloudDatabase", CloudDatabase);
            UpdateXmlAttribEncrypted(doc, root, "ServerCfg", "CloudUserId"  , CloudUserId);
            UpdateXmlAttribEncrypted(doc, root, "ServerCfg", "CloudPassword", CloudPassword);

            UpdateXmlAttribEncrypted(doc, root, "ServerCfg", "LocalServer"  , LocalServer);
            UpdateXmlAttribEncrypted(doc, root, "ServerCfg", "LocalDatabase", LocalDatabase);
            UpdateXmlAttribEncrypted(doc, root, "ServerCfg", "LocalUserId"  , LocalUserId);
            UpdateXmlAttribEncrypted(doc, root, "ServerCfg", "LocalPassword", LocalPassword);

            
            doc.Save(dir+"\\"+CfgFileName);
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
            if (Value == null) return;
            XmlAttribute att = xml.CreateAttribute(Attrib);

            byte[] bufs=RC2Encrypt(Encoding.Unicode.GetBytes(Value),Key);
            att.Value = Convert.ToBase64String(bufs);

            node.Attributes.Append(att);
        }
    }
}
