using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DataCollection
{

    public partial class Form1 : Form
    {
        public static List<Configure> mList;
        public Form1()
        {
            InitializeComponent();
        }

        public void Read(string path, out string res)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            res = null;
            while ((line = sr.ReadLine()) != null)
            {
                res = res + line.ToString();
            }
            sr.Close();
        }
        public void Write(string path, string str)
        {

            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            fs.Seek(0, SeekOrigin.Begin);
            fs.SetLength(0);
            fs.Close();
            FileStream fs1 = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs1);
            //开始写入
            sw.Write(str);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs1.Close();

        }
        string strPath = System.Environment.CurrentDirectory + "\\DataCollection.txt";
        private void Form1_Load(object sender, EventArgs e)
        {
            databind();
        }
        void databind()
        {
            List<Configure> listo = new List<Configure>();
            string str;
            Read(strPath, out str);
            string[] strs = str.Split(';');
            foreach (var item in strs)
            {
                string[] items = item.Split(',');
                if (items != null && items[0] != "")
                {
                    Configure c = new Configure();
                    c.StoreName = items[0];
                    c.IpAddress = items[1];
                    c.DataSouce = items[2];
                    c.UserName = items[3];
                    c.Pwd = items[4];
                    listo.Add(c);
                }
            }
            dataGridView1.DataSource = new BindingList<Configure>(listo);
            mList = listo;
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            StringBuilder dataStr = new StringBuilder();
            for (int count = 0; count < dataGridView1.Rows.Count - 1; count++)
            {
                for (int countsub = 0; countsub < dataGridView1.Columns.Count; countsub++)
                {
                    dataStr.Append(dataGridView1.Rows[count].Cells[countsub].Value.ToString());
                    dataStr.Append(",");
                }

                dataStr.Append(";");
            }
            if (dataStr != null)
            {
                Write(strPath, dataStr.ToString());
                databind();
            }
        }




    }
    /// <summary>
    /// 
    /// </summary>

    public class Configure
    {
        private string storeName;
        private string ipAddress;
        private string dataSouce;
        private string userName;
        private string pwd;
        public string StoreName
        {
            get { return storeName; }
            set { storeName = value; }
        }
        public string IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }
        public string DataSouce
        {
            get { return dataSouce; }
            set { dataSouce = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }
    }
    public class OPState
    {
        public string dbName { get; set; }
        public string tbName { get; set; }
        public int readState { get; set; } //1读取成功；0未进行此操作；-1读取失败
        public int writeState { get; set; }//1读取成功；0未进行此操作；-1读取失败 
    }
}
