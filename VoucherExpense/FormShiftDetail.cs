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
        public FormShiftDetail(VEDataSet dataSet,VEDataSet.ShiftTableRow row)
        {
            vEDataSet = dataSet;
            Row = row;
            InitializeComponent();
        }

        class tempHR
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public Panel Pan { get; set; }
            public tempHR(int id, string na)
            {
                ID = id;
                Name = na;
            }
            override public string ToString() { return Name; }
        }
        List<VEDataSet.ShiftDetailRow> m_Details;
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

            VEDataSet.ShiftDetailRow[] rows = Row.GetShiftDetailRows();
            m_Details = new List<VEDataSet.ShiftDetailRow>();
            foreach (VEDataSet.ShiftDetailRow ro in rows)
                m_Details.Add(ro);
            foreach (VEDataSet.HRRow hr in vEDataSet.HR)
            {
                if (hr.IsInPositionNull() || (!hr.InPosition)) continue;
                checkedListBoxEmployee.Items.Add(new tempHR(hr.EmployeeID,hr.EmployeeName));
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
        Panel CreatePanel(int id, string name,DayOfWeek dayOfWeek,int dayCount)
        {
            Panel pan = new Panel();
            string panName = "pan" + id.ToString();
            pan.Name = panName;
            pan.Size = new Size(720, PanelHeight-2);
            pan.BackColor = Color.Azure;
            Label label = new Label();
            label.Size = new Size(LabelWidth, LabelHeight);
            label.Text = name;
            label.Location = new Point(3, (PanelHeight-LabelHeight-2)/2);
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Name = panName + "Label";
            label.DoubleClick += new EventHandler(label_DoubleClick);
            pan.Controls.Add(label);
            int x = LabelWidth + 4;
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
                pan.Controls.Add(box);
                pan.Controls.Add(box1);
                if (++dayOfWeek > DayOfWeek.Saturday) dayOfWeek=DayOfWeek.Sunday;
            }
            x=LabelWidth + 20+ 32*TextBoxWidth;
            TextBox textBox = new TextBox();
            textBox.Size = new Size(TextBoxWidth * 6, TextBoxHeight);
            textBox.Location=new Point(x,3);
            textBox.Text  = "排定     小時";
            pan.Controls.Add(textBox);

            TextBox textBox1=new TextBox();
            textBox1.Size= new Size(TextBoxWidth * 6, TextBoxHeight);
            textBox1.Location=new Point(x,3+TextBoxHeight);
            textBox1.Text = "出勤     小時";
            pan.Controls.Add(textBox1);

            return pan;
        }

        void label_DoubleClick(object sender, EventArgs e)
        {
            Label l = sender as Label;
            tempHR temp = l.Parent.Tag as tempHR;
            checkedListBoxEmployee.Items.Add(temp);
            m_List.Remove(temp);
            panelBase.Controls.Remove(temp.Pan);
            foreach (tempHR hr in m_List)
            {
                int i = m_List.IndexOf(hr);
                hr.Pan.Location = new Point(3, i * 80 + 3);
            }
        }

        List<tempHR> m_List=new List<tempHR>();
        private void btnMove_Click(object sender, EventArgs e)
        {
            if (checkedListBoxEmployee.CheckedIndices.Count <= 0) return;
            listBoxHelp.Visible = false;
            int mon=Row.TableMonth;
            int dayCount = MyFunction.DayCountOfMonth(mon);
            DayOfWeek dayOfWeek = (new DateTime(MyFunction.IntHeaderYear, mon, 1)).DayOfWeek;
            foreach (object item in checkedListBoxEmployee.CheckedItems)
            {
                tempHR temp = item as tempHR;
                Panel panel=CreatePanel(temp.ID,temp.Name,dayOfWeek,dayCount);
                panel.BorderStyle = BorderStyle.Fixed3D;
                temp.Pan = panel;
                panel.Tag = temp;
                m_List.Add(temp);
                int i = m_List.IndexOf(temp);
                panel.Location = new Point(3, i * 80 + 3);
                panelBase.Controls.Add(panel);
            }
            foreach (tempHR hr in m_List)
                checkedListBoxEmployee.Items.Remove(hr);

        }

        // 假設名字是TextBox99
        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox box = sender as TextBox;
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
                        control.Focus();
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
            Panel panel=CreatePanel(temp.ID,temp.Name,dayOfWeek,dayCount);
            panel.BorderStyle = BorderStyle.Fixed3D;
            temp.Pan = panel;
            panel.Tag = temp;
            m_List.Add(temp);
            int i = m_List.IndexOf(temp);
            panel.Location = new Point(3, i * 80 + 3);
            panelBase.Controls.Add(panel);

            checkedListBoxEmployee.Items.Remove(temp);          
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            Close();
        }

     
    }
}
