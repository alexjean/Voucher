using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VoucherExpense
{
    public partial class FormShiftDetail : Form
    {
        VEDataSet vEDataSet;
        VEDataSet.ShiftTableRow Row;
        int       m_DayCount;
        DayOfWeek m_DayOfWeek;
        List<CShiftCode> m_ShiftCodeList;
        public FormShiftDetail(VEDataSet dataSet,VEDataSet.ShiftTableRow row,List<CShiftCode> list)
        {
            vEDataSet = dataSet;
            Row = row;
            m_ShiftCodeList = list;
            InitializeComponent();
        }

        class tempHR
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public Panel Pan { get; set; }
            public List<TextBox> UpList;
            public List<TextBox> DownList;
            public TextBox UpTotal;
            public TextBox DownTotal;
            public int iUpTotal;
            public int iDownTotal;
            public tempHR(int id, string na)
            {
                ID = id;
                Name = na;
            }
            override public string ToString() { return Name; }
        }
        private void FormShiftDetail_Load(object sender, EventArgs e)
        {
            if (Row != null)
                Text = Row.TableMonth.ToString() + "月" + Row.TableName;
            if (Row.IsTableMonthNull())
            {
                MessageBox.Show("錯誤!沒有月份");
                Close();
                return;
            }

            foreach (VEDataSet.HRRow hr in vEDataSet.HR)
            {
                if (hr.IsInPositionNull() || (!hr.InPosition)) continue;
                checkedListBoxEmployee.Items.Add(new tempHR(hr.EmployeeID,hr.EmployeeName));
            }

            int mon = Row.TableMonth;
            m_DayCount = MyFunction.DayCountOfMonth(mon);
            m_DayOfWeek = (new DateTime(MyFunction.IntHeaderYear, mon, 1)).DayOfWeek;
            VEDataSet.ShiftDetailRow[] rows = Row.GetShiftDetailRows();
            if (rows.Count() != 0) listBoxHelp.Visible = false;
            foreach (VEDataSet.ShiftDetailRow ro in rows)
            {
                tempHR hr=null;
                foreach(object o in checkedListBoxEmployee.Items)
                {
                    tempHR h = o as tempHR;
                    if (h.ID == ro.EmpolyeeID)
                    {
                        hr = h;
                        break;
                    }
                }
                if (hr == null)
                {
                    foreach (VEDataSet.HRRow h in vEDataSet.HR)              // 找不在職的
                    {
                        if (h.IsInPositionNull() || h.InPosition) continue;  // InPosition 己經在m_HRList
                        if (h.EmployeeID != ro.EmpolyeeID) continue;
                        hr = new tempHR(h.EmployeeID, h.EmployeeName);
                        break;
                    }
                    if (hr == null) hr = new tempHR(ro.EmpolyeeID, "員工" + ro.EmpolyeeID.ToString());
                }
                MoveOne(m_DayCount, m_DayOfWeek, hr);
                ShiftDetail2PanelData(ro, hr);
                // UpdateTotal(hr); 代碼可能變更意思,進去不算
            }
        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box=sender as CheckBox;
            bool b=box.Checked;
            int count=checkedListBoxEmployee.Items.Count;
            for (int i=0;i<count;i++)
            {
                checkedListBoxEmployee.SetItemChecked(i, b);
            }
        }

        const int PanelHeight= TextBoxHeight*2+8;
        const int LabelWidth = 80;
        const int LabelHeight = 40;
        const int TextBoxWidth = 16;
        const int TextBoxHeight = 30;
        Panel CreatePanel(tempHR hr,DayOfWeek dayOfWeek,int dayCount)
        {
            Panel pan = new Panel();
            string panName = "pan" + hr.ID.ToString();
            pan.Name = panName;
            pan.Size = new Size(720, PanelHeight-2);
            pan.BackColor = Color.Azure;
            Label label = new Label();
            label.Size = new Size(LabelWidth, LabelHeight);
            label.Text = hr.Name;
            label.Location = new Point(3, (PanelHeight-LabelHeight-2)/2);
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Name = panName + "Label";
            label.DoubleClick += new EventHandler(label_DoubleClick);
            pan.Controls.Add(label);
            int x = LabelWidth + 4;
            hr.UpList = new List<TextBox>();
            hr.DownList = new List<TextBox>();
            for (int i = 1; i <= dayCount; i++)
            {
                TextBox box = new TextBox();
                box.Name = panName + "TBU" + i.ToString();
                box.Size = new Size(TextBoxWidth+1, TextBoxHeight);
                box.MaxLength = 1;
                box.TextAlign = HorizontalAlignment.Center;
                box.Location = new Point(x, 3);
                box.KeyUp += new KeyEventHandler(textBox_KeyUp);

                TextBox box1 = new TextBox();
                box1.Name = panName + "TBD" + i.ToString();
                box1.Size = new Size(TextBoxWidth+1, TextBoxHeight);
                box1.MaxLength = 1;
                box1.TextAlign = HorizontalAlignment.Center;
                box1.Location = new Point(x, 3 + TextBoxHeight);
                box1.KeyUp += new KeyEventHandler(textBox_KeyUp);
                x += TextBoxWidth;
                if ((i % 10) == 0) x += 6;
                if (dayOfWeek == DayOfWeek.Sunday)
                    box.BackColor =  Color.SeaShell;
                else
                    box.BackColor = Color.Azure;
                box1.BackColor = Color.Azure;

                box.Tag = hr;
                box1.Tag = hr;
                hr.UpList.Add(box);
                hr.DownList.Add(box1);
                pan.Controls.Add(box);
                pan.Controls.Add(box1);

                if (++dayOfWeek > DayOfWeek.Saturday) dayOfWeek=DayOfWeek.Sunday;
            }
            x=LabelWidth + 20+ 32*TextBoxWidth;
            TextBox textBox = new TextBox();
            textBox.Size = new Size(TextBoxWidth * 6, TextBoxHeight);
            textBox.Location=new Point(x,3);
            textBox.Text  = "排定     小時";
            hr.UpTotal = textBox;
            pan.Controls.Add(textBox);

            TextBox textBox1=new TextBox();
            textBox1.Size= new Size(TextBoxWidth * 6, TextBoxHeight);
            textBox1.Location=new Point(x,3+TextBoxHeight);
            textBox1.Text = "出勤     小時";
            hr.DownTotal = textBox1;
            pan.Controls.Add(textBox1);

            return pan;
        }

        void label_DoubleClick(object sender, EventArgs e)
        {
            Label l = sender as Label;
            tempHR temp = l.Parent.Tag as tempHR;
            checkedListBoxEmployee.Items.Add(temp);
            m_HRList.Remove(temp);
            panelBase.Controls.Remove(temp.Pan);
            foreach (tempHR hr in m_HRList)
            {
                int i = m_HRList.IndexOf(hr);
                hr.Pan.Location = new Point(3, i * 80 + 3);
            }
        }

        List<tempHR> m_HRList=new List<tempHR>();
        private void btnMove_Click(object sender, EventArgs e)
        {
            if (checkedListBoxEmployee.CheckedIndices.Count <= 0) return;
            listBoxHelp.Visible = false;
            List<tempHR> list = new List<tempHR>();
            foreach (object item in checkedListBoxEmployee.CheckedItems)
                list.Add(item as tempHR);
            foreach(tempHR hr in list)
                MoveOne(m_DayCount, m_DayOfWeek,hr);
        }

        void MoveOne(int dayCount, DayOfWeek dayOfWeek,tempHR temp)
        {
            Panel panel = CreatePanel(temp, dayOfWeek, dayCount);
            panel.BorderStyle = BorderStyle.Fixed3D;
            temp.Pan = panel;
            panel.Tag = temp;
            m_HRList.Add(temp);
            checkedListBoxEmployee.Items.Remove(temp);
            int i = m_HRList.IndexOf(temp);
            panel.Location = new Point(3, i * 80 + 3);
            panelBase.Controls.Add(panel);
        }

        CShiftCode GetShiftCode(char c)
        {
            foreach (CShiftCode sc in m_ShiftCodeList)
                if (c == sc.Code)
                    return sc;
            return null;
        }

        void UpdateTotal(tempHR hr)
        {
            CShiftCode sc;
            char c;
            int total = 0;
            foreach (TextBox t in hr.UpList)
            {
                if (t.Text.Length <= 0) continue;
                c = t.Text[0];
                if (char.IsDigit(c))
                    total += c - '0';
                else
                {
                    sc = GetShiftCode(char.ToUpper(c));
                    if (sc != null)
                        total += sc.Hour;
                }
            }
            hr.UpTotal.Text = "排班 " + total.ToString() + "時";
            hr.iUpTotal = total;
            total = 0;
            foreach (TextBox t in hr.DownList)
            {
                if (t.Text.Length <= 0) continue;
                c = t.Text[0];
                if (char.IsDigit(c))
                    total += c - '0';
                else
                {
                    sc = GetShiftCode(char.ToUpper(c));
                    if (sc != null)
                        total += sc.Hour;
                }
            }
            hr.DownTotal.Text = "出勤 " + total.ToString() + "時";
            hr.iDownTotal = total;
        }
        // 假設名字是TextBox99
        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox box = sender as TextBox;
            CShiftCode sc;
            char c;
            if (box.Text.Length > 0)
            {
                c = box.Text[0];
                if (char.IsDigit(c))
                    box.ForeColor = SystemColors.WindowText;
                else
                {
                    sc = GetShiftCode(char.ToUpper(c));
                    if (sc == null) box.ForeColor = Color.Red;
                    else box.ForeColor = SystemColors.WindowText;
                }
            }
            if (box.Tag.GetType() == typeof(tempHR)) UpdateTotal(box.Tag as tempHR);
            string name = box.Name;
            int len = name.Length;
            int i = len-1;
            for (; i >=0; i--)                 //從尾巴找回來,第一個不是數字的
                if (!char.IsDigit(name[i])) break;
            
            if (i >= 0 && i<len-1)
            {
                int n;
                i++;
                if (Int32.TryParse(name.Substring(i, len - i), out n))
                {
                    string next=null;
                    if (e.KeyCode==Keys.Left)
                    {
                        if (n > 0) next = name.Substring(0, i) + (n - 1).ToString();
                    }
                    else if (e.KeyCode==Keys.Back || e.KeyCode==Keys.Delete) return;     
                    else
                        next = name.Substring(0, i) + (n + 1).ToString();
                    Control[] controls = box.Parent.Controls.Find(next, true);
                    if (controls.Length >0)
                    {
                        Control control = controls[0];
                        control.Select();
                        if (control.GetType() == typeof(TextBox))
                            ((TextBox)control).SelectAll();
                    }
                }
            }
        }

        private void checkedListBoxEmployee_DoubleClick(object sender, EventArgs e)
        {
            listBoxHelp.Visible = false;
            int mon=Row.TableMonth;
            int dayCount = MyFunction.DayCountOfMonth(mon);
            DayOfWeek dayOfWeek = (new DateTime(MyFunction.IntHeaderYear, mon, 1)).DayOfWeek;
            CheckedListBox box = sender as CheckedListBox;

            if (checkedListBoxEmployee.SelectedItem == null) return;
            
            tempHR temp = checkedListBoxEmployee.SelectedItem as tempHR;
            Panel panel=CreatePanel(temp,dayOfWeek,dayCount);
            panel.BorderStyle = BorderStyle.Fixed3D;
            temp.Pan = panel;
            panel.Tag = temp;
            m_HRList.Add(temp);
            int i = m_HRList.IndexOf(temp);
            panel.Location = new Point(3, i * 80 + 3);
            panelBase.Controls.Add(panel);

            checkedListBoxEmployee.Items.Remove(temp);          
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            Close();
        }

        void PanelData2ShiftDetail(tempHR hr, VEDataSet.ShiftDetailRow detail)
        {
            detail.EmpolyeeID = hr.ID;
            Panel pan = hr.Pan;
            string panName = pan.Name;
            string shiftData = "";
            string realData = "";
            for (int d = 1; d <= m_DayCount; d++)
            {
                string labelName = panName + "TBU" + d.ToString();
                Control[] controls=pan.Controls.Find(labelName, true);
                TextBox tb;
                if (controls.Count() > 0)
                {
                    tb = (TextBox)controls[0];
                    if (tb.Text.Length > 0)
                        shiftData += tb.Text[0];
                    else shiftData += " ";
                }
                labelName = panName + "TBD" + d.ToString();
                controls = pan.Controls.Find(labelName, true);
                if (controls.Count() > 0)
                {
                    tb = (TextBox)controls[0];
                    if (tb.Text.Length > 0)
                        realData += tb.Text[0];
                    else realData += " ";
                }
            }
            detail.ShiftData = shiftData;
            detail.RealData  = realData;
            detail.ShiftHours = hr.iUpTotal;
            detail.RealHours = hr.iDownTotal;
        }

        void ShiftDetail2PanelData(VEDataSet.ShiftDetailRow detail, tempHR hr)
        {
            Panel pan = hr.Pan;
            string panName = pan.Name;
            string shiftData = detail.ShiftData;
            string realData =  detail.RealData;
            for (int d = 1; d <= m_DayCount; d++)
            {
                string labelName = panName + "TBU" + d.ToString();
                Control[] controls = pan.Controls.Find(labelName, true);
                TextBox tb;
                char c;
                if (controls.Count() > 0 && shiftData.Length>=d)
                {
                    tb = (TextBox)controls[0];
                    c=shiftData[d - 1];
                    if (c==' ') tb.Text="";
                    else        tb.Text=c.ToString();
                }
                labelName = panName + "TBD" + d.ToString();
                controls = pan.Controls.Find(labelName, true);
                if (controls.Count() > 0 && realData.Length>=d)
                {
                    tb = (TextBox)controls[0];
                    c = realData[d - 1];
                    if (c == ' ') tb.Text = "";
                    else          tb.Text = c.ToString();
                }
            }
            hr.iUpTotal=detail.ShiftHours;
            hr.iDownTotal=detail.RealHours;
            hr.UpTotal.Text = "排班 " + hr.iUpTotal.ToString() + "時";
            hr.DownTotal.Text = "出勤 " + hr.iDownTotal.ToString() + "時";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            VEDataSet.ShiftDetailRow[] details = Row.GetShiftDetailRows();
            int i = 0;
            int count = m_HRList.Count;
            foreach (VEDataSet.ShiftDetailRow detail in details)
            {
                if (i >= count)
                    detail.Delete();
                else
                {
                    tempHR hr = m_HRList[i];
                    PanelData2ShiftDetail(hr,detail);
                }
                i++;
            }
            for (; i < count; i++)
            {
                VEDataSet.ShiftDetailRow detail = vEDataSet.ShiftDetail.NewShiftDetailRow();
                detail.ID = Guid.NewGuid();
                detail.SetParentRow(Row);
                tempHR hr=m_HRList[i];
                PanelData2ShiftDetail(hr, detail);
                vEDataSet.ShiftDetail.Rows.Add(detail);
            }
            try
            {
                VEDataSet.ShiftDetailDataTable table = vEDataSet.ShiftDetail.GetChanges() as VEDataSet.ShiftDetailDataTable;
                shiftDetailTableAdapter.Update(table);
                vEDataSet.ShiftDetail.Merge(table);
                vEDataSet.ShiftDetail.AcceptChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show("更新ShiftDetail資料出錯:"+ex.Message);
            }

        }

     
    }
}
