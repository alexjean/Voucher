﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using MyDataSet         = VoucherExpense.DamaiDataSet;
using MyRequestsAdapter = VoucherExpense.DamaiDataSetTableAdapters.RequestsTableAdapter;
using MyRequestsRow     = VoucherExpense.DamaiDataSet.RequestsRow;
namespace VoucherExpense
{
    public partial class FormBillList : Form
    {
        DamaiDataSet.ApartmentRow m_DefaultApartment;
        public FormBillList(DamaiDataSet.ApartmentRow defaultApartment)
        {
            m_DefaultApartment = defaultApartment;
            InitializeComponent();
        }
        Image image;
        HardwareConfig Config ;
        string Apartmentname="";
       // bool  StateIsEndit = false;//状态是否编辑
        MyDataSet m_DataSet = new MyDataSet();
        MyRequestsAdapter RequestsAdapter=new MyRequestsAdapter();
        private void FormBillList_Load(object sender, EventArgs e)
        {
            requestsBindingSource.DataSource = m_DataSet;
            var apartmentAdapter = new VoucherExpense.DamaiDataSetTableAdapters.ApartmentTableAdapter();
            apartmentAdapter.Connection.ConnectionString = DB.SqlConnectString(MyFunction.HardwareCfg);

            apartmentAdapter.Fill(m_DataSet.Apartment);
            RequestsAdapter.Fill(m_DataSet.Requests);
            this.requestsBindingSource.Sort = "requestsid desc";
           
            if (m_DefaultApartment.IsApartmentNameNull())
                Apartmentname = m_DefaultApartment.ApartmentAllName;
            else
                Apartmentname = m_DefaultApartment.ApartmentAllName;
            textBox1.Text = Apartmentname;
            //设定打印机
            Config = MyFunction.HardwareCfg;
            PrinterSettings ps = new PrinterSettings();
            ps.PrinterName = Config.DotPrinterName;
            textBoxDotPrinter.Text = Config.DotPrinterName;
            pD.PrinterSettings = ps;
            dateTimetoolStripCbB.SelectedIndex = DateTime.Now.Month;
            if (MyFunction.IntHeaderYear != DateTime.Now.Year)
                dateTimetoolStripCbB.SelectedIndex = dateTimetoolStripCbB.Items.Count - 1;
            else
                dateTimetoolStripCbB.SelectedIndex = DateTime.Now.Month;
        }


        MyRequestsRow Addrow;
        string intToint6(int num, int numlength)
        {
            string number = num.ToString();
            int len = number.Length;
            if (len < numlength)
            {
                for (int i = 0; i < numlength - len; i++)
                {
                    number = "0" + number;
                }
            }
            return number;
        }
        public List<TextBox> GetCTextBoxes(Control control)
        {
            List<TextBox> ctxts = new List<TextBox>();
            foreach (Control con in control.Controls)
            {
                if (con.GetType() == typeof(TextBox))
                {
                    ctxts.Add((TextBox)con);
                }
                if (con.GetType() == typeof(GroupBox))
                {
                    this.GetCTextBoxes(con);
                }
                if (con.GetType() == typeof(SplitContainer))
                {
                    this.GetCTextBoxes(con);
                }
                if (con.GetType() == typeof(SplitterPanel))
                {
                    this.GetCTextBoxes(con);
                }
            }
            return ctxts;
        }

        private void requestsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        { 
            IsEnabled(false);//资料设置为不可编辑
           this.requestsBindingSource.EndEdit();
           try
           {
               RequestsAdapter.Update(m_DataSet.Requests);
           }
           catch (Exception ex)
           {
               MessageBox.Show("存請款單錯誤:" + ex.Message);
           }
           requestsBindingSource.ResetBindings(false);
           //RequestsAdapter.Fill  (m_DataSet.Requests);
            this.bindingNavigatorAddNewItem.Enabled = true;
            this.requestsBindingNavigatorSaveItem.Enabled = false;
            this.requestsDataGridView.Enabled = true;
            this.isCancelCheckBox.Enabled = true;
        }
        private void bindingNavigatorAddNewItem_Click_1(object sender, EventArgs e)
        {
            IsEnabled(true);//资料设置为可编辑
            this.isCancelCheckBox.Enabled = false;
            this.bindingNavigatorAddNewItem.Enabled = false; 
           // this.bindingNavigatorDeleteItem.Enabled = true;
            this.requestsBindingNavigatorSaveItem.Enabled = true;
            this.bindingNavigatorMovePreviousItem.Enabled = false;
            this.bindingNavigatorMoveFirstItem.Enabled = false;
            this.requestsDataGridView.Enabled = false;
            //dateTimetoolStripCbB.SelectedIndex = -1;
            departmentTextBox.Focus();
            newRequests();
        }
        int CurrentId=0;
        string CurrentList; string tems = ""; string strtemp = "";
        void newRequests()//创建新单数据
        {

            int maxID = 0;
            int maxCode = 0;
            RequestsAdapter.Fill(m_DataSet.Requests);
            int tem = dateTimetoolStripCbB.SelectedIndex;
            int tems =Convert.ToInt32(DateTime.Now.ToString("MM"));
            if (tem != tems &&tem >0)//打印非当月的单子
            {                    string datetime = DateTime.Now.ToString("yyMM");

                if (MessageBox.Show("确定打印" + dateTimetoolStripCbB.Text + "的请款单?", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    foreach (var item in m_DataSet.Requests)
                    {
                        if (item.RequestsID > maxID)
                        {
                            maxID = item.RequestsID;
                        }

                        strtemp = item.ListNumber.ToString().Substring(2, 2);
                        if (Convert.ToInt32(strtemp) != tem)//只比较选定月份相同的单号
                        {

                        }
                        else
                        {
                            if (tem < 10)
                            {
                                maxCode = Convert.ToInt32(datetime.Remove(2) + "0" + tem + "000");
                            }
                            else
                            {
                                maxCode = Convert.ToInt32(datetime.Remove(2) + tem + "000");
                            }
                            if (Convert.ToInt32(item.ListNumber) > maxCode)
                            {
                                maxCode = Convert.ToInt32(item.ListNumber);
                            }
                        }
                    }
                    if (maxCode == 0)
                    {
                        if (tem<10)
                        {
                            maxCode=Convert.ToInt32(datetime.Remove(2)+"0"+tem+ "000");
                        }
                        else
                        {
                            maxCode = Convert.ToInt32(datetime.Remove(2) + tem + "000");
                        }
                    }

                }
                else { return; }
            }
            else
            {
                foreach (var item in m_DataSet.Requests)
                {
                    if (item.RequestsID > maxID)
                    {
                        maxID = item.RequestsID;
                    }
                    if (Convert.ToInt32(item.ListNumber) > maxCode)
                    {
                        maxCode = Convert.ToInt32(item.ListNumber);
                    }
                }

                string datetime = DateTime.Now.ToString("yyMM");
                string maxcode = "0";
                if (maxCode > 0)
                    maxcode = maxCode.ToString().Remove(4);
                if (Convert.ToInt32(datetime) > Convert.ToInt32(maxcode))
                {
                    maxCode = Convert.ToInt32(datetime + "000");
                }
            }
                Addrow = m_DataSet.Requests.NewRequestsRow();
                Addrow.RequestsID = maxID + 1;
                CurrentId = maxID + 1;
                Addrow.ListNumber = maxCode + 1;
                CurrentList = (maxCode + 1).ToString();
                listNumberTextBox.Text = (maxCode + 1).ToString();
                listNumberTextBox.Text = Addrow.ListNumber.ToString();
                Addrow.SetAccountNull();
                Addrow.OperatorID = MyFunction.OperatorID;
                Addrow.SetDepartmentNull();
                Addrow.SetApplicantNull();
                Addrow.SetRequestsUseNull();
                Addrow.SetUintNameNull();
                Addrow.SetBankOfDepositNull();
                Addrow.SetMoneyAaNull();
                Addrow.SetMoneyANull();
                Addrow.SetPaymenMethodsNull();
                Addrow.SetHandoverPoepleNull();
                Addrow.SetBillingDateNull();
                Addrow.SetDateOfPaymentNull();
                Addrow.IsLock = false;
                Addrow.IsCancel = false;
                Addrow.CreateTime = DateTime.Now;
                Addrow.EndEdit();
                m_DataSet.Requests.Rows.Add(Addrow);
                RequestsAdapter.Update(m_DataSet.Requests);
                RequestsAdapter.Fill(m_DataSet.Requests);
        }
        bool isEmpty=false;
        private void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           image =  global::VoucherExpense.Properties.Resources.Requests;
            //image = Image.FromFile(Application.StartupPath+"\\BillBackground\\Requests.png");//D:\VoucherExpense10\VoucherExpense\
            // 获取Graphics
            Graphics g = e.Graphics;
            //DrawImage(g);
            //fDpiX = g.DpiX;
            //fDpiY = g.DpiY;
            Font font = new Font("新宋体", 30, GraphicsUnit.Pixel);
            Brush brush = new SolidBrush(Color.Black);
            Graphics g1 = Graphics.FromImage(image);
            if (isEmpty)//打印空单
            {
                g1.DrawString(listNumberTextBox.Text, font, brush, 2 * listNumberTextBox.Location.X, 2 * listNumberTextBox.Location.Y + 10);
            }
            else
            {
                List<TextBox> ctxts = GetCTextBoxes(this.panel1);
                foreach (TextBox ctxt in ctxts)
                {
                    g1.DrawString(ctxt.Text, font, brush, 2 * (ctxt.Location.X-5), 2 * ctxt.Location.Y + 10);
                }

            }
            g.DrawImage(image, new Point(0, 0));
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (listNumberTextBox.Text == "")
            {
                MessageBox.Show("无单打印！");
                return;
            }
            if (!this.bindingNavigatorAddNewItem.Enabled )
            {
                MessageBox.Show("请先保存，在打印！");
                return;
            }
            try
            {
                pD.Print();
            }
            catch(Exception ex)
            { 
                MessageBox.Show(ex.ToString());
                return;
            }
        }
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            IsEnabled(false);//资料设置为不可编辑
           // this.bindingNavigatorDeleteItem.Enabled = false;
            this.bindingNavigatorAddNewItem.Enabled = true;
            this.requestsBindingNavigatorSaveItem.Enabled = false;
            this.requestsDataGridView.Enabled = true;
            requestsDataGridView.Rows.Remove(requestsDataGridView.CurrentRow);
        }
        private void moneyAaTextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !MyFunction.DecimalValidate(((TextBox)sender).Text);
        }
        private void dateTimetoolStripCbB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = dateTimetoolStripCbB.SelectedIndex;//月份选择，所选的索引值
            if (i == -1)
            {
                return;
            }
            if (!this.bindingNavigatorAddNewItem.Enabled)
            {
                MessageBox.Show("单子正在编辑！有单未保存, 先按保存");
                return;
            }  
           // string y = "#" + MyFunction.HeaderYear + "/";
            string y =  MyFunction.HeaderYear.Substring(2,2) ;
            //string m1, m2;

            if (i == 0)
            {
                requestsBindingSource.Filter = "";
            }
            else
            {
                if (i>9)
                {
                    requestsBindingSource.Filter = "(ListNumber>=" + Convert.ToInt32(y + i.ToString() + "000") + ") AND (ListNumber<" + Convert.ToInt32(y + i.ToString() + "999") + ")";
                }
                else
                {
                    y = y + "0";
                    requestsBindingSource.Filter = "(ListNumber>=" + Convert.ToInt32(y+i.ToString()+"000" )+ ") AND (ListNumber<" + Convert.ToInt32(y+i.ToString()+"999" ) + ")";
                }
            }
                this.requestsDataGridView.Focus();
        }
        private void isCancelCheckBox_Click(object sender, EventArgs e)
        {
            this.requestsBindingSource.EndEdit();
            RequestsAdapter.Update(m_DataSet.Requests);
            // this.requestsTableAdapter.Fill(this.vEDataSet.Requests);
        }
        private void requestsDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //DataGridView view = (DataGridView)sender;
            //DataGridViewRow row = view.Rows[e.RowIndex];
            //DataGridViewCell cell = row.Cells["IsCancel"];
            //if (cell.ValueType != typeof(bool)) return;    // 不應該
            //bool removed = false;
            //if (cell.Value != null && cell.Value != DBNull.Value)
            //    removed = (bool)cell.Value;
            //Color color;
            //if (removed)
            //    color = Color.DarkCyan;
            //else if ((e.RowIndex % 2) != 0)
            //    color = Color.Azure;
            //else
            //    color = Color.White;
            //row.DefaultCellStyle.BackColor = color;
        }
        private void requestsDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            DataGridViewRow row = view.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells["IsCancel"];
            if (cell.ValueType != typeof(bool)) return;    // 不應該
            bool removed = false;
            if (cell.Value != null && cell.Value != DBNull.Value)
                removed = (bool)cell.Value;
            Color color;
            if (removed)
                color = Color.LightSteelBlue;
            else if ((e.RowIndex % 2) != 0)
                color = Color.OldLace;
            else
                color = Color.FloralWhite;
            row.DefaultCellStyle.BackColor = color;
        }
        private void IsEnabled(bool b)
        {
            this.departmentTextBox.Enabled= b;
            this.applicantTextBox.Enabled = b;
            this.requestsUseTextBox.Enabled = b;
            this.uintNameTextBox.Enabled = b;
            this.bankOfDepositTextBox.Enabled = b;
            this.accountTextBox.Enabled = b;
            this.moneyAaTextBox.Enabled = b;
            this.moneyATextBox.Enabled = b;
            this.paymenMethodsTextBox.Enabled = b;
            this.billingDateDateTimePicker.Enabled = b;
            this.dateOfPaymentDateTimePicker.Enabled = b;
            this.billingDateTextBox.Enabled = b;
            this.dateOfPaymentTextBox.Enabled = b;
        }
        private void tSBtEndit_Click(object sender, EventArgs e)
        {
            if (this.requestsDataGridView.CurrentRow.Cells["dgvColOperatorID"].Value.ToString() == MyFunction.OperatorID.ToString()) {
            if (!this.bindingNavigatorAddNewItem.Enabled)
            {
                MessageBox.Show("单子正在编辑！");
                return;
            }  
          //  StateIsEndit = true;
            IsEnabled(true);  
            this.requestsBindingNavigatorSaveItem.Enabled = true;
            this.bindingNavigatorAddNewItem.Enabled = false;
            //this.bindingNavigatorDeleteItem.Enabled = false;
            this.bindingNavigatorMovePreviousItem.Enabled = false;
            this.bindingNavigatorMoveFirstItem.Enabled = false;
            this.requestsDataGridView.Enabled = false;
            this.bindingNavigatorMoveNextItem.Enabled = false;
            this.bindingNavigatorMoveLastItem.Enabled = false;
            this.isCancelCheckBox.Enabled = false;
            }
            else
            {
                MessageBox.Show("此单不是您建立的无权编辑！");
            }
        }
        private void billingDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            this.billingDateTextBox.Text = billingDateDateTimePicker.Text;
        }
        private void dateOfPaymentDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            this.dateOfPaymentTextBox.Text = dateOfPaymentDateTimePicker.Text;
        }
        private void requestsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            MessageBox.Show("第" + row.ToString() + "行,第" + col.ToString() + "欄資料" + e.Exception.Message);
            e.Cancel = true;
        }

        private void pD_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
            //e.PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("", 850, 552);
            //e.PageSettings.Margins = new Margins(0, 0, 0, 0);
        }

        private void btnFindDotPrinter_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
                textBoxDotPrinter.Text = printDialog1.PrinterSettings.PrinterName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Config.DotPrinterName = textBoxDotPrinter.Text.Trim();
            Config.Save();
            MessageBox.Show("點陣印表机 設定存檔完成! 重新啟動程式後, 設定方生效.");

        }     
    }
}
