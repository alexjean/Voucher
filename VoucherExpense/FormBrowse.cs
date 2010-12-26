using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Drawing.Printing;
using System.Data.OleDb;
using System.Xml;

namespace VoucherExpense
{
    public partial class FormBrowse : Form
    {
//        string MDB_Name = "BasicData.mdb";
//        string ClosedMDB_Name = "Closed.mdb";
//        string m_Provider = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
//        string m_Password = ";Persist Security Info=True;Jet OLEDB:Database Password=loveyou";
        public FormBrowse()
        {
            InitializeComponent();
        }

        
        int MaxID;
        bool ListViewItemCheck=false;  // 為了控制ItemChecked 在資料庫寫入時,不要有動作
        bool CanModify=true;
        OrderAdapter m_OrderAdapter = new OrderAdapter();
        OrderItemAdapter m_OrderItemAdapter = new OrderItemAdapter();

        class OrderAdapter : BasicDataSetTableAdapters.OrderTableAdapter
        {
            string SaveStr;
            public int FillBySelectStr(BasicDataSet.OrderDataTable dataTable,string SelectStr)
            {
                SaveStr=base.CommandCollection[0].CommandText;      
                base.CommandCollection[0].CommandText = SelectStr;
                int result=Fill(dataTable);
                base.CommandCollection[0].CommandText = SaveStr;
                return result;
            }
        }
        class OrderItemAdapter : BasicDataSetTableAdapters.OrderItemTableAdapter
        {
            string SaveStr;
            public int FillBySelectStr(BasicDataSet.OrderItemDataTable dataTable, string SelectStr)
            {
                SaveStr = base.CommandCollection[0].CommandText;
                base.CommandCollection[0].CommandText = SelectStr;
                int result = Fill(dataTable);
                base.CommandCollection[0].CommandText = SaveStr;
                return result;
            }
        }

        string DateStr(int y, int m, int d)
        {
            return (y % 100).ToString() + m.ToString("d2") + d.ToString("d2");
        }
        string CreateSql(int year, int month, int day)
        {
            string str1 = DateStr(year, month, day);
            if (!checkBoxUse12.Checked)
                return "Where INT(ID/10000)=" + str1;
            DateTime prev=new DateTime(year,month,day);
            prev = prev.Subtract(new TimeSpan(24, 0, 0));
            return "Where (INT(ID/10000)=" + DateStr(prev.Year,prev.Month,prev.Day)
                  +   " OR INT(ID/10000)=" +str1+")";
        }

        void LoadData(int year,int month, int day)
        {
            string sql = "80101";
            int count = basicDataSet1.Header.Rows.Count;
            if (count != 0)
            {
                BasicDataSet.HeaderRow row = (BasicDataSet.HeaderRow)basicDataSet1.Header.Rows[count - 1]; // 沒指定用最後一個
                if (month != 0 && day > 0)         // 有指定找到那天
                {
                    foreach (BasicDataSet.HeaderRow r in basicDataSet1.Header.Rows)
                    {
                        if (r.DataDate.Month != month) continue;
                        if (r.DataDate.Year != year) continue;
                        if (r.DataDate.Day == day)
                        {
                            row = r;
                            break;
                        }
                    }
                }
                else
                    SetupSelectCombo(row.DataDate.Month);
                sql = CreateSql(row.DataDate.Year, row.DataDate.Month, row.DataDate.Day);
                //    "Where INT(ID/10000)=" + (row.DataDate.Year % 100).ToString() + row.DataDate.Month.ToString("d2") + row.DataDate.Day.ToString("d2");
                SetTitle(row.DataDate, row.Closed);
            }
            else
            {
                sql = CreateSql(2000,1,1);
                SetTitle(new DateTime(2000, 1, 1), false);
            }
            MaxID = 0;
            try
            {
//                orderTableAdapter1.Fill(basicDataSet1.Order);
//                orderItemTableAdapter1.Fill(basicDataSet1.OrderItem);
                if (checkBoxUse12.Checked)
                {
                    BasicDataSet.OrderDataTable temp=new BasicDataSet.OrderDataTable();
                    m_OrderAdapter.FillBySelectStr(temp, "Select * From [Order] " + sql + " Order by ID");
                    int todayID = WorkingDay.IDTagHead(year,month,day);
                    DateTime d=new DateTime(year,month,day);
                    d=d.Subtract(new TimeSpan(24, 0, 0));
                    int prevID  = WorkingDay.IDTagHead(d.Year,d.Month,d.Day);
                    basicDataSet1.Order.Clear();
                    foreach (BasicDataSet.OrderRow r in temp)
                    {
                        int idHead=r.ID/10000;
                        if (idHead == todayID)
                        {
                            if (r.PrintTime.Hour < 7) continue;
                        }
                        else if (idHead == prevID)
                        {
                            if (r.PrintTime.Hour >= 7) continue;
                        }
                        BasicDataSet.OrderRow oRow = basicDataSet1.Order.NewOrderRow();
                        oRow.ItemArray = r.ItemArray;
                        basicDataSet1.Order.AddOrderRow(oRow);
                    }
                }
                else
                    m_OrderAdapter.FillBySelectStr(basicDataSet1.Order, "Select * From [Order] " + sql + " Order by ID");
                m_OrderItemAdapter.FillBySelectStr(basicDataSet1.OrderItem, "Select * From [OrderItem] " + sql);
                foreach (BasicDataSet.OrderRow R in basicDataSet1.Order.Rows)
                {
                    int id = R.ID % 10000;
                    if (id > MaxID) MaxID = id;
                }
            }
            catch(Exception ex)
            {
                string str = ex.Message;
                MessageBox.Show("訂菜單資料庫讀取錯誤!");
            }
            Table2ListView();
        }


        private void FormBrowse_Load(object sender, EventArgs e)
        {
/*
            if (!File.Exists(MDB_Name))
            {
                MessageBox.Show("資料庫不存在,無資料庫後續無法執行!", "", MessageBoxButtons.OK);
                Close();
                return;
            }
*/
            m_OrderAdapter.Connection       = MapPath.BasicConnection;
            m_OrderItemAdapter.Connection   = MapPath.BasicConnection;
            try
            {
                BasicDataSetTableAdapters.ProductTableAdapter adapter = new BasicDataSetTableAdapters.ProductTableAdapter();
                adapter.Connection = MapPath.BasicConnection;
                adapter.Fill(basicDataSet1.Product);
            }
            catch
            {
                MessageBox.Show("菜單酒水資料庫讀取錯誤, 後續動作無法正常");
            }
            try
            {
                headerTableAdapter1.Connection = MapPath.BasicConnection;
                headerTableAdapter1.Fill(basicDataSet1.Header);
            }
            catch
            {
                MessageBox.Show("標頭資料讀取錯誤,你的資料庫版本可能不對");
            }
            int count = basicDataSet1.Header.Rows.Count;
            DateTime dt;
            if (count != 0)
            {
                BasicDataSet.HeaderRow row = (BasicDataSet.HeaderRow)basicDataSet1.Header.Rows[count - 1]; // 沒指定用最後一個
                dt = row.DataDate;
                SetupSelectCombo(row.DataDate.Month);
            }
            else
            {
                dt = new DateTime(2008, 1, 1);
                SetupSelectCombo(1);
            }
            LoadData(dt.Year,dt.Month,dt.Day);
        }

        private void SetupSelectCombo(int month)
        {

            if (month <= 0 || month > 12)
            {
                MessageBox.Show("月份不正確!");
                Close();
                return;
            }
            comboBoxDay.Items.Clear();
            comboBoxDay.Items.Add("今日");
            comboBoxMonth.SelectedIndexChanged -= comboBoxMonth_SelectedIndexChanged;
            comboBoxMonth.Items.Clear();
            for (int i = 0; i < 12; i++)
            {
                comboBoxMonth.Items.Add((i+1).ToString("d2") + "月");
            }
            comboBoxMonth.SelectedIndex = month-1;
            comboBoxMonth.SelectedIndexChanged += comboBoxMonth_SelectedIndexChanged;
            List<int> listDay = new List<int>();
            foreach (BasicDataSet.HeaderRow row in basicDataSet1.Header)
            {
                if (row.DataDate.Month == month)
                    listDay.Add(row.DataDate.Day);
            }
            listDay.Sort();
            foreach (int day in listDay)
                comboBoxDay.Items.Add(day.ToString()+"日");
        }

        private void SetTitle(DateTime t,bool Closed)
        {
            string msg = this.Text.Substring(0, 2)+" "+t.ToShortDateString();
            if (Closed) msg += "  己封印";
            this.Text = msg;
            m_WorkingDay.Set(t);              // 在新增時要加在ID上的
            CanModify = !Closed;
        }

        public void Table2ListView()
        {
            bool ShowFullID = checkBoxUse12.Checked;
            int selectedIndex=-1;
            if (listViewBrowse.SelectedIndices.Count>0)
                selectedIndex= listViewBrowse.SelectedIndices[0];
            listViewBrowse.ListViewItemSorter = null;       // 每次重算都不排序
            ListViewItemCheck = false;
            listViewBrowse.Items.Clear();
            bool filterInvoiceID    = checkBox1.Checked;
            bool filterAlreadyPrint = checkBox2.Checked;
            bool filterChecked      = checkBox3.Checked;
            int  sum = 0, people = 0, total = 0,receivedCash=0,credit=0,midnight=0,normal=0;
            foreach (BasicDataSet.OrderRow Row in basicDataSet1.Order.Rows)
            {
                // 有印出時間或是有收款單號,就是己經收到錢的
                int income=(int)Row.Income;
                if (Row.InvoiceID != 0)
                {
                    if (Row.IsCreditIDNull())
                        receivedCash += income;
                    else if (Row.CreditID == 0)
                        receivedCash += income;
                    else
                        credit += income;
                }
                else if (!Row.IsPrintTimeNull())
                {
                    if (Row.PrintTime.Year >= 2007)
                    {
                        receivedCash += income;
                    }
                }
                if (Row.PrintTime.Hour < 6)
                    midnight += income;
                else
                    normal += income;
                if (filterInvoiceID && Row.InvoiceID != 0) continue;
                if (!Row.IsPrintTimeNull())
                    if (filterAlreadyPrint && Row.PrintTime.Year >= 2007)
                        continue;
                if (filterChecked && Row.Checked) continue;
                total++;    
                ListViewItem lvItem;
                int id ;
                if (ShowFullID) id = Row.ID % 100000000;
                else            id = Row.ID % 10000;
                lvItem = listViewBrowse.Items.Add(id.ToString("d3"));
                lvItem.SubItems.Add(Row.TableID);
                lvItem.SubItems.Add(Row.SaveTime.ToShortTimeString());
                lvItem.SubItems.Add(Row.PeopleNo.ToString());
                lvItem.SubItems.Add(Row.Income.ToString());
                lvItem.SubItems.Add(Row.OrderID.ToString());
                lvItem.SubItems.Add(Row.InvoiceID.ToString());
                if (Row.IsCreditIDNull() || Row.CreditID < 0.0001m)
                    lvItem.SubItems.Add(" ");
                else
                    lvItem.SubItems.Add(Row.CreditID.ToString());
                lvItem.Checked = Row.Checked;
                lvItem.Tag = Row;
                sum += (int)Row.Income;
                people+=Row.PeopleNo;
            }
            labelTotalOrdeNo.Text = total.ToString();
            labelSum.Text = sum.ToString();
            labelPepoleNo.Text = people.ToString();
            labelReceived.Text = receivedCash.ToString();
            labelCreditCard.Text = credit.ToString();
            labelPayed.Text = (receivedCash+credit).ToString();
            labelMidnight.Text = midnight.ToString();
            labelNormal.Text = normal.ToString();
            if (selectedIndex > 0 && selectedIndex < listViewBrowse.Items.Count)
            {
//                listViewBrowse.SelectedIndices.Clear();
                listViewBrowse.SelectedIndices.Add(selectedIndex);
            }
            this.Visible = true;
            listViewBrowse.Sort();
            ListViewItemCheck = true;
        }

        class WorkingDay
        {
            private DateTime m_Date;
            public int Year  { get { return m_Date.Year;  } }
            public int Month { get { return m_Date.Month; } }
            public int Day   { get { return m_Date.Day;   } }
            public static int IDTagHead(int y, int m, int d)
            {
                int tag = y % 100;
                tag = tag * 10000 + m * 100 + d;
                return tag ;
            }
            public int IDTag()
            {
                DateTime t = m_Date;
                return IDTagHead(t.Year,t.Month,t.Day)*10000;
            }
            public void Set(DateTime t)
            {
                m_Date = t;
            }
            public BasicDataSet.HeaderRow HeaderRow(BasicDataSet.HeaderDataTable header)
            {
                foreach (BasicDataSet.HeaderRow row in header)
                {
                    if (row.DataDate.Day != m_Date.Day) continue;
                    if (row.DataDate.Month != m_Date.Month) continue;
                    if (row.DataDate.Year != m_Date.Year) continue;
                    return row;
                }
                return null;
            }
            public override string ToString()
            {
                return m_Date.ToShortDateString();
            }
        }
        WorkingDay m_WorkingDay=new WorkingDay();   // 在SetTitle中設定

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Table2ListView();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Table2ListView();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Table2ListView();
        }


        class ListViewItemComparer : System.Collections.IComparer
        {
            private int col;
            public ListViewItemComparer()
            {
                col = 0;
            }
            public ListViewItemComparer(int column)
            {
                col = column;
            }
            public int Compare(object x, object y)
            {
                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }
        }

        private void listViewBrowse_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            listViewBrowse.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }

        private void listViewBrowse_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (ListViewItemCheck == false) return;
            BasicDataSet.OrderRow Row = (BasicDataSet.OrderRow)e.Item.Tag;
            if (CanModify)
            {
                Row.Checked = e.Item.Checked;
                try
                {
                    m_OrderAdapter.Update(Row);
                }
                catch
                {
                    MessageBox.Show("Order資料庫寫入有誤");
                }
            }
            else
            {
                ListViewItemCheck = false;  // 防止重複進入
                e.Item.Checked = Row.Checked;
                ListViewItemCheck = true;
            }

        }

        private void BuildCommand(OleDbDataAdapter adapter)
        {
            OleDbCommandBuilder Builder=new OleDbCommandBuilder(adapter);
			Builder.QuotePrefix="[";
            Builder.QuoteSuffix="]";
			adapter.UpdateCommand=Builder.GetUpdateCommand();
			adapter.InsertCommand=Builder.GetInsertCommand();
		    adapter.DeleteCommand=Builder.GetDeleteCommand();
        }


        private void ShowMessage(string msg)
        {
            ShowMessage(msg, 1000);
        }
        private void ShowMessage(string msg,int timetick)
        {
            labelMessage.Text = msg;
            labelMessage.Refresh();
            FormMessage Form = new FormMessage(msg, timetick);
            Form.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("請依菜單號排序,再按確定","",MessageBoxButtons.OKCancel);
            if (result==DialogResult.OK)
                printDocument.Print();
        }

        int PageIndex = -1;
        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            PrintAction action = e.PrintAction;
            PageIndex = 1;
        }

        Graphics m_Graphics = null;
        Font m_Font = null;
        Brush m_Brush = null;
        void PrintColumn(string str, int x, int y, int width,bool alignmentRight)
        {
            if (alignmentRight)
            {
                SizeF size = m_Graphics.MeasureString(str, m_Font);
                x += (int)(width - size.Width);
            }
            m_Graphics.DrawString(str, m_Font, m_Brush, new PointF(x, y));
        }

        const int LinePerPage = 50;
        const int NoPerBlock = 20;
        const int BlockWidth = 220;
        void PrintBlock(int left, int y, int start, int end,int height)
        {
            ListView.ListViewItemCollection items = this.listViewBrowse.Items;            
            string[] header = new string[] { "編號", "台號", "人數", "金額" };
            int[] colWidth = new int[] { 50, 50, 50, 60 };
            
            int x = left;
            for (int j = 0; j < header.Length; j++)
            {
                PrintColumn(header[j], x, y, colWidth[j], true);
                x += colWidth[j];
            }
            for (int i = start; i < end; i++)
            {
                BasicDataSet.OrderRow row = items[i].Tag as BasicDataSet.OrderRow;
                y += height;
                x = left;

                PrintColumn(row.OrderID.ToString(), x, y, colWidth[0], true);
                x += colWidth[0];
                PrintColumn(row.TableID.ToString(), x, y, colWidth[1], true);
                x += colWidth[1];
                PrintColumn(row.PeopleNo.ToString(), x, y, colWidth[2], true);
                x += colWidth[2];
                PrintColumn(row.Income.ToString(), x, y, colWidth[3], true);
                x += colWidth[3];
                if (!row.IsCreditIDNull() && row.CreditID != 0)
                    PrintColumn("*", x-4, y, 10, false);
            }
        }

        private void Draw2Line(int x, int y, int x1, int y1,int offset)
        {
            Pen pen = SystemPens.WindowText;
            m_Graphics.DrawLine(pen, x, y, x1 , y1);
            m_Graphics.DrawLine(pen, x, y+offset, x1 , y1+offset);
        }

        private void Draw2Str(string str, int x, int y,int offset)
        {
            m_Graphics.DrawString(str, m_Font, m_Brush, x, y);
            m_Graphics.DrawString(str, m_Font, m_Brush, x, y+offset);
        }

        private void GetStatics(out int tableNo, out decimal sum, out decimal averagePerPerson,out decimal midnight,
                                out decimal cash,out decimal credit)
        {
            sum = 0;
            tableNo = 0;
            midnight = cash=credit=0;
            int peopleNo = 0;
            foreach (BasicDataSet.OrderRow Row in basicDataSet1.Order.Rows)
            {
                tableNo++;
                int income = (int)Row.Income;
                sum += income;
                peopleNo += Row.PeopleNo;
                if (Row.PrintTime.Hour < 6)
                    midnight += (int)Row.Income;
                if (Row.IsCreditIDNull() || Row.CreditID == 0)
                    cash += income;
                else
                    credit += income;
            }
            averagePerPerson = sum / peopleNo;
        }

        private void DrawStatics(int x, int y,int height,int width)
        {
            int no;
            decimal ave, sum,midnight,cash,credit;
            GetStatics(out no, out sum, out ave,out midnight,out cash,out credit);
            m_Graphics.DrawString("營業額  "+sum.ToString(), m_Font, m_Brush, x, y);
//            m_Graphics.DrawString("午夜 " + midnight.ToString("f0"), m_Font, m_Brush, x + width / 2, y);
            y += height;
            m_Graphics.DrawString("菜單號異常說明", m_Font, m_Brush, x, y);
            y += 2*height;
            m_Graphics.DrawString("現金 "+cash.ToString()  , m_Font, m_Brush, x, y);
            m_Graphics.DrawString("刷卡 "+credit.ToString(), m_Font, m_Brush, x+width/2, y);
            y += height;
            m_Graphics.DrawString("檔數 " + no.ToString()     , m_Font, m_Brush, x, y);
            m_Graphics.DrawString("人均 " + ave.ToString("f1"), m_Font, m_Brush, x + width / 2, y);
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            m_Graphics = e.Graphics;
            PageSettings settings = e.PageSettings;
            Rectangle inner = e.MarginBounds;
            Rectangle outter = e.PageBounds;
            if (listViewBrowse.Items.Count==0 || PageIndex <= 0)
            {
                e.HasMorePages = false;
                return;
            }
            int start = (PageIndex - 1) * LinePerPage;
            int end = start + LinePerPage;
            ListView view = this.listViewBrowse;
            if (end > view.Items.Count)
            {
                end = view.Items.Count;
                e.HasMorePages = false;
            }
            else
            {
                e.HasMorePages = true;
                PageIndex++;
            }
            m_Font = new Font("細明體", 12.0f);
            m_Brush = SystemBrushes.WindowText;
            int half=inner.Top+inner.Height/2;
            m_Graphics.DrawLine(SystemPens.WindowText,new Point(inner.Left             ,half),
                                                      new Point(inner.Left+BlockWidth*3,half));
            int x = inner.Left;
            int height = 23;
            int y = outter.Top + height;
            int y1 = half + height;
            string str = m_WorkingDay.ToString()+"   ";
            if (checkBoxUse12.Checked) str += "稅控制";
            else                       str += "自然制";
            m_Graphics.DrawString(str, m_Font, m_Brush, new PointF(x, y ));
            m_Graphics.DrawString(str, m_Font, m_Brush, new PointF(x, y1));
            y = outter.Top + 2 * height;
            y1 = half + 2 * height;
            // DrawRectangle
            Pen pen=SystemPens.WindowText;
            int h = height * NoPerBlock + height;
            int w = BlockWidth;
            int x1 = inner.Left;
            for (; x1 <= inner.Left + BlockWidth * 2; x1 += BlockWidth)
            {
                m_Graphics.DrawRectangle(pen,new Rectangle(x1, y - 2, w, h));
                m_Graphics.DrawRectangle(pen,new Rectangle(x1, y1- 2, w, h));
            }
            x1=inner.Left+BlockWidth*2;
            int y2 = y + height * 11;
            Draw2Line(x1, y2-2, x1 + w, y2-2 ,half);
            DrawStatics(x1, y2       ,height,w);
            DrawStatics(x1, y2 + half,height,w);

            y2 += height * 6;
            Draw2Line(x1, y2, x1+w  , y2             ,half);
            Draw2Str("單據金額授權簽字核對無誤!", x1, y2 - height              ,half);
            Draw2Str("收銀簽字", x1, y2                                        ,half);
            x1=x1+w/2;
            Draw2Line(x1, y2, x1    , y2 + height * 4,half);
            Draw2Str("財務主管", x1, y2                                        ,half);
            if ((end - start) > NoPerBlock)
            {
                int s1 = start + NoPerBlock;
                PrintBlock(x             , y, start , s1 , height);
                PrintBlock(x, y1, start, s1, height);
                start = s1 ;
                s1=start+NoPerBlock;
                if (end > s1)
                {
                    PrintBlock(x + BlockWidth    , y , start , s1 , height);
                    PrintBlock(x + BlockWidth    , y1, start , s1 , height);
                    PrintBlock(x + BlockWidth * 2, y , s1 , end, height);
                    PrintBlock(x + BlockWidth * 2, y1, s1 , end, height);
                }
                else
                {
                    PrintBlock(x + BlockWidth, y, start, end, height);
                    PrintBlock(x + BlockWidth, y1, start, end, height);
                }
            }
            else
            {
                PrintBlock(x, y, start , end, height);
                PrintBlock(x, y1, start, end, height);
            }
        }

        private void printDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            PageIndex = -1;
        }


        bool m_Running = false;
        private void comboBoxDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_Running) return;
            m_Running = true;
            ComboBox box = (ComboBox)sender;
            if (comboBoxMonth.SelectedIndex >= 0 && comboBoxMonth.SelectedIndex < 12)
            {
                string str = box.SelectedItem.ToString();
                int day = 0;
                foreach (char c in str)
                {
                    if (Char.IsDigit(c))
                        day=day*10+c-'0';
                    else break;
                }
                int month = comboBoxMonth.SelectedIndex + 1;
                LoadData(m_WorkingDay.Year, comboBoxMonth.SelectedIndex+1, day);
            }
            else
                MessageBox.Show("選擇月份不對!");
            m_Running = false;
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int month=comboBoxMonth.SelectedIndex;
            if (month >= 0 && month < 12)
                SetupSelectCombo(month + 1);
        }

  
        private void checkBoxUse12_CheckedChanged(object sender, EventArgs e)
        {
             LoadData(m_WorkingDay.Year, m_WorkingDay.Month,m_WorkingDay.Day);
        }

        private void listViewBrowse_DoubleClick(object sender, EventArgs e)
        {
            ListView view = (ListView)sender;
            if (view.SelectedItems.Count < 1) return;
            BasicDataSet.OrderRow Row1 = (BasicDataSet.OrderRow)view.SelectedItems[0].Tag;
            FormOrder Form1 = new FormOrder(basicDataSet1, Row1, this, "None", true);
            Form1.Show();
            this.Visible = false;
            Form1.Focus();
        }
  
    }
}