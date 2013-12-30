using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Data.OleDb;
using System.Drawing.Drawing2D;

namespace VoucherExpense
{

    public class AlphaPanel : Panel
    {
        const int WS_EX_TRANSPARENT = 0x00000020;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_TRANSPARENT;
                return cp;
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {//do not paint the background
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.Transparent);
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, this.Width, this.Height));
        }
    }
    enum GlobalFlag    // count 必需是個數,後面用來new的
    {
        basicDataModified=0, employeeModified=1,count=2
    }

    static class MyFunction
    {

        #region Validating Function
        static public bool UintValidate(string intStr)
        {
            string error = "";
            bool flag = UintValidate(intStr, out error);
            if (!flag)
                MessageBox.Show(error);
            return flag;
        }
        static public bool UintValidate(string intStr, out string errorStr)
        {
            errorStr="";
            string str=intStr.Trim();
            if (str == "") return true;
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                {
                    errorStr="只能是數字!";
                    return false;
                }
            }
            if (str.Length < Int32.MaxValue.ToString().Length) return true;
            errorStr = "數字太大!";
            return false;  
        }
        static public bool DateValidate(string datestr)
        {
            string error = "";
            bool flag = DateValidate(datestr, out error);
            if (!flag) MessageBox.Show(error);
            return flag;
        }
        static public bool DateValidate(string dateStr,out string errorStr)
        {
            errorStr = "";
            if (dateStr.Trim() == "") return true;
            foreach (char c in dateStr)
            {
                if (c != '/')
                    if (!char.IsDigit(c))
                    {
                        errorStr="只能是數字和/";
                        return false;
                    }
            }
            char[] seprator={'/'};
            try
            {
                string[] str=dateStr.Split(seprator, 3);
                if (str.Length != 3)
                {
                    errorStr = "格式為YYYY/MM/DD";
                    return false;
                }
                int l;
                l = str[0].Length; if (l > 4 || l < 1) { errorStr="年是1-4位數"; return false; }
                l = str[1].Length; if (l > 2 || l < 1) { errorStr="月是1-2位數"; return false; }
                l = str[2].Length; if (l > 2 || l < 1) { errorStr="日是1-2位數"; return false; }
                int y=Convert.ToInt32(str[0]);
                if (y < 1900 || y > 2030) // 現在資料輸入不可能小於1900年, 程式用至2030年也夠本了
                {
                    errorStr = "年只接受1900-2030!";
                    return false;
                }
                int m = Convert.ToInt32(str[1]);
                if (m < 1 || m > 12)    { errorStr="只有1-12月!";    return false; }         // 1-12月
                int d = Convert.ToInt32(str[2]);
                if (d < 1 || d > 31)    { errorStr="只有1-31日!";    return false; }         // 1-31日
                if (m == 2)
                {
                    if (d < 29) return true;
                    if (d > 29)       { errorStr="2月沒那麼多天!"; return false; }
                    if ((y % 4) != 0) { errorStr = "這年2月沒29日!"; return false; }
                    if ((y % 100) == 0) { errorStr = "這年2月沒29日!"; return false; }
                    return true;
                }
                if (d<31) return true;
                switch(m)
                {
                    case 4: break;
                    case 6: break;
                    case 9: break;
                    case 11: break;
                    default: return true;
                }
                errorStr=m.ToString() + "月沒31日!";
                return false;
            }
            catch
            {
                errorStr="檢查日期發生未知錯誤!";
                return false;
            }
        }
        static public bool DecimalValidate(string decimalStr)
        {
            string str = decimalStr.Trim();
            if (str == "") return true;
            bool dotted = false;
            if (str[0] == '-') str = str.Substring(1);
            foreach (char c in str)
            {
                if (!char.IsDigit(c) && c!=',')
                {
                    if (c == '.')
                    {
                        if (dotted)
                        {
                            MessageBox.Show("小數點最多只能一個!");
                            return false;
                        }
                        dotted = true;
                    }
                    else
                    {
                        MessageBox.Show("只能填數字或小數點!");
                        return false;
                    }
                }
            }
            int len = 0;
            if (dotted)
            {
                len = str.IndexOf('.');
            }
            else len = str.Length;
//          if (len < Decimal.MaxValue.ToString().Length) return true;
            if (len < 29) return true;
            MessageBox.Show("數字太大!");
            return false;  
        }
        #endregion

        #region GlobalFlag
        static bool[] globalFlag;
        static public void SetGlobalFlag(GlobalFlag f)
        {
            if (globalFlag == null)
                globalFlag = new bool[(int)GlobalFlag.count];
            globalFlag[(int)f] = true;
        }
        static public bool GetThenResetGlobalFlag(GlobalFlag f)
        {
            if (globalFlag == null)
                globalFlag = new bool[(int)GlobalFlag.count];
            bool flag = globalFlag[(int)f];
            globalFlag[(int)f] = false;
            return flag;
        }
        #endregion 

        static public void SetFieldLength(DataGridView view, DataTable table)
        {
            try
            {
                foreach (DataGridViewColumn col in view.Columns)
                {
                    if (col.ReadOnly) continue;  // 由程式填的資料,不用去管長度
                    if (col.GetType() == typeof(DataGridViewComboBoxColumn)) continue; // ComboBox不去設
                    string str = col.DataPropertyName;
                    if (string.IsNullOrEmpty(str)) continue;
                    DataColumn dCol = table.Columns[str];
                    if (dCol == null) continue;
                    Type type = dCol.DataType;
                    if (type.Name == "String")  // 假定都是textBox沒有ComboBox
                    {
                        DataGridViewTextBoxColumn textCol = (DataGridViewTextBoxColumn)col;
                        textCol.MaxInputLength = dCol.MaxLength;
                    }
                    else if (type.Name == "DateTime")
                    {
                        DataGridViewTextBoxColumn textCol = (DataGridViewTextBoxColumn)col;
                        textCol.MaxInputLength = 10;  // YYYY/MM/DD 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("設定View欄寬時出錯!" + ex.Message);
            }
        }

        static public void SetControlLengthFromDB(Form form,DataTable table)
        {
            foreach (Control ctl in form.Controls)
            {
                if (!ctl.Enabled) continue;
                string str = ctl.Name;
                if (str.Contains("TextBox"))                        // 假如沒手改,預設的會有 xxxxTextBox
                {
                    TextBox textBox = (TextBox)ctl;
                    if (textBox.ReadOnly) continue;                 // 程式填資料,不管
                    if (textBox.DataBindings.Count <= 0) continue;  // 沒有Binding的Control不管
                    try                                             // 出錯就不管
                    {
                        Binding bind = textBox.DataBindings[0];
                        if (bind == null) continue;
                        string member = bind.BindingMemberInfo.BindingMember;
                        if (string.IsNullOrEmpty(member)) continue;
                        foreach (DataColumn dCol in table.Columns)
                        {
                            if (dCol.ColumnName == member)
                            {
                                string type=dCol.DataType.Name;
                                if (type == "String")
                                    textBox.MaxLength = dCol.MaxLength;
                                else if (type == "DateTime")   // 一律當做ShortDate
                                    textBox.MaxLength = 10;
                                else if (type == "Int16")
                                    textBox.MaxLength = Int16.MaxValue.ToString().Length - 1;
                                else if (type == "Int32")
                                    textBox.MaxLength = Int32.MaxValue.ToString().Length - 1;
                                else if (type == "Single")
                                    textBox.MaxLength = Single.MaxValue.ToString().Length - 1;
                                else if (type == "Double")
                                    textBox.MaxLength = Double.MaxValue.ToString().Length - 1;
                                else if (type == "Decimal")
                                    textBox.MaxLength = Decimal.MaxValue.ToString().Length - 1;
                                break;
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("設定Control欄寬時出錯!" + ex.Message);
                    }
                }
            }

        }

        static public int MaxNoInDB(string fieldName, DataTable table)
        {
            int m = 0;
            int n;
            foreach (DataRow r in table.Rows)
            {
                try
                {
                    n = Convert.ToInt32(r[fieldName]);
                    if (n > m) m = n;
                }
                catch { }
            }
            return m;
        }

        static public bool IsNullDBNull(object obj)
        {
            if (obj == null) return true;
            if (obj == DBNull.Value) return true;
            return false;
        }

        // 把CurrentRow的Cells[cellName]設成整張表最大的+1,假如自己是最大的那個,就不加1
        static public int SetCellMaxNo(string cellName, DataGridView view,int maxInDB)
        {
            DataGridViewRow row = view.CurrentRow;
            object obj;
            int intValue=0;
            obj=row.Cells[cellName].Value;
            if (!Convert.IsDBNull(obj))
            {
                if (obj.GetType()==typeof(int))
                    intValue=(int)obj;
            }
            if ( intValue<=0)  // if CuurrentRow己經有值就不加,否則給maxInDB+1
            {
                int m = maxInDB, n = 0;
                foreach (DataGridViewRow r in view.Rows)
                {
                    obj = r.Cells[cellName].Value;
                    if (IsNullDBNull(obj)) continue;
                    n = (int)obj;
                    if (n > m) m = n;
                }
                DataGridViewCell cell = row.Cells[cellName];
                obj = cell.Value;
                if (!IsNullDBNull(obj))
                {
                    if (obj.GetType() == typeof(int))
                    {
                        if (((int)obj) == m) return m;    // 自己就是最大的那個
                    }
                }
                cell.Value = m + 1;
                view.InvalidateCell(cell);
                return m + 1;
            }
            return -1;
        }

        static public bool ColumnIDGood(DataGridView view, string columnID, int rowIndex)
        {
            DataGridViewRow row = view.Rows[rowIndex];
            DataGridViewCell cell = row.Cells[columnID];
            object id = cell.Value;
            if (id == null || id == DBNull.Value || (int)id <= 0)
            {
                MessageBox.Show("必需有編號, 請按新增設定編號");
                return false;
            }
            return true;
        }

        static public void AddNewItem(DataGridView view, string columnID, string dbID, DataTable table)
        {
            if (MyFunction.LockAll)
            {
                MessageBox.Show("鎖定中,新增無用");
            }
            int ma = MyFunction.MaxNoInDB(dbID, table);
            MyFunction.SetCellMaxNo(columnID, view, ma);
        }

        static public T SaveCheck<T>(Form form,BindingSource binding,T dataTable) where T:DataTable
        {
            if (MyFunction.LockAll)
            {
                MessageBox.Show("鎖定中,不能存檔");
                return default(T);
            }
            if (!form.Validate())
            {
                MessageBox.Show("有資料錯誤, 請改好再存!");
                return default(T);
            }
            binding.EndEdit();
            T table = (T)dataTable.GetChanges();
            if (table == null)
            {
                MessageBox.Show("沒有改動任何資料! 不用存");
                return default(T);
            }
            return table;
        }

        // 假設年放在 IntHeaderYear
        static public int DayCountOfMonth(int month)
        {
            if (month < 1 || month > 12) return 0;
            if (month == 2)  // 3月1號去一天, 算潤年
            {
                DateTime day = new DateTime(IntHeaderYear, 3, 1).Subtract(new TimeSpan(1, 0, 0, 0));
                return day.Day;
            }
            int[] dayCount = new int[12] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            return dayCount[month-1];
        }

        static public int OperatorID { get; set; }
        static public bool IsManager { get; set; }
        static public bool LockHR    { get; set; }
        static public bool LockInventory { get; set; } // 偷懶還是這樣寫,應該把權限全讀入 
        static public string HeaderYear="2008";
        static public int IntHeaderYear = 2008;
        static public int IntHeaderMonth = 1;
        static public bool LockAll = true;
        static public HardwareConfig HardwareCfg = null;

        public static bool CompressFileToBuf(string sourceFile, out byte[] zippedDest,out byte[] md5)
        {
            zippedDest = null;
            md5 = null;
            if (!File.Exists(sourceFile)) return false;
            FileStream sourceStream = null;
            byte[] buffer;
            try
            {
                sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                buffer = new byte[sourceStream.Length];
                int checkCounter = sourceStream.Read(buffer, 0, buffer.Length);
                if (checkCounter != buffer.Length)
                {
                    MessageBox.Show(sourceFile + "長度不對!");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(sourceFile + "讀取失敗!");
                return false;
            }
            finally
            {
                if (sourceStream != null) sourceStream.Close();
            }
            md5 = Encoder.GetMD5(buffer);
            MemoryStream destStream = null;
            GZipStream zipStream = null;
            bool flag = true;
            try
            {
                destStream = new MemoryStream();
                zipStream = new GZipStream(destStream, CompressionMode.Compress, true);
                zipStream.Write(buffer, 0, buffer.Length);
            }
            catch
            {
                MessageBox.Show( "壓縮 失敗!");
                flag = false;
            }
            if (zipStream != null) zipStream.Close();
            if (destStream != null)
            {
                zippedDest=destStream.ToArray();
                destStream.Close();
            }
            return flag;
        }

        public static bool Decompress(byte[] source,string fName)
        {
            byte[] dest=Decompress(source);
            return WriteBufferToFile(dest, fName, dest.Length);
        }

        static public byte[] Decompress(byte[] source)
        {
            if ((source == null) || source.Length < 6) return null;
            MemoryStream sourceStream = null;
            GZipStream decompressedStream = null;
            byte[] quarterBuffer = new byte[4];
            byte[] buffer = null;
            int total = 0;
            try
            {
                sourceStream = new MemoryStream(source);
                decompressedStream = new GZipStream(sourceStream, CompressionMode.Decompress, true);
                long position = sourceStream.Length - 4;
                sourceStream.Position = position;
                sourceStream.Read(quarterBuffer, 0, 4);
                sourceStream.Position = 0;
                int checkLength = BitConverter.ToInt32(quarterBuffer, 0);
                buffer = new byte[checkLength + 256];
                int offset = 0;
                while (true)
                {
                    int byteRead = decompressedStream.Read(buffer, offset, 256);
                    if (byteRead == 0) break;
                    offset += byteRead;
                    total += byteRead;
                }
            }
            catch
            {
                MessageBox.Show("壓縮來源" + source + "讀取失敗!");
                return null;
            }
            finally
            {
                if (sourceStream != null) sourceStream.Close();
                if (decompressedStream != null) decompressedStream.Close();
            }
            if (buffer == null) return null;
            byte[] newBuf = new byte[total];
            for(int i=0;i<total;i++) newBuf[i]=buffer[i];
            return newBuf;
//            return WriteBufferToFile(buffer, destination, total);
        }
        static public bool WriteBufferToFile(byte[] buffer, string destination, int total)
        {
            FileStream destStream = null;
            bool flag = true;
            try
            {
                destStream = new FileStream(destination, FileMode.Create);
                destStream.Write(buffer, 0, total);
                destStream.Flush();
            }
            catch
            {
                MessageBox.Show(destination + "寫出失敗!");
                flag = false;
            }
            finally
            {
                if (destStream != null) destStream.Close();
            }
            return flag;
        }

        static public Bitmap GetThumbnail(Bitmap img, int newHeight)
        {
            int x = img.Size.Width;
            int y = img.Size.Height;
            int y1 = newHeight;
            int x1 = x * y1 / y;
            Bitmap newbmp = new Bitmap(x1, y1);
            Graphics g = Graphics.FromImage(newbmp);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.DrawImage(img, new Rectangle(0, 0, x1, y1), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
            g.Dispose();
            return newbmp;
        }

        static public Bitmap ShrinkBitmap(Bitmap img, int newWidth,int newHeight)
        {
            int x = img.Size.Width;
            int y = img.Size.Height;
            if (y<=0 || x<=0) return img;
            if (x <= newWidth && y <= newHeight) return img; // 原圖己經比較小了,不放大
            int y1 = newHeight;    
            int x1 = x * y1 / y;
            if (x1 > newWidth)   // 太寬,縮高度
            {
                x1 = newWidth;
                y1 = y * x1 / x;
            }
            Bitmap newbmp = new Bitmap(x1, y1);
            Graphics g = Graphics.FromImage(newbmp);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.DrawImage(img, new Rectangle(0, 0, x1, y1), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
            g.Dispose();
            return newbmp;

        }

    }
}
