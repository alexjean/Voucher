using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DataCollection
{
   public  static class Log
    {
       static string strPath = System.Environment.CurrentDirectory + "\\Log.txt";
        public static void  Write(string str)
        {
            Write(strPath, str);
        }
        public static void Read(out string res)
        {
            Read(strPath,out res);
        }
        public static void Read(string path, out string res)
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
        public static void Write(string path, string str)
        {

            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs); 
            //开始写入
            sw.WriteLine(DateTime.Now+str);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();

        }
        
    }
}
