using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BakeryOrder
{
    public partial class FormReturnCheckout : Form
    {
        int m_X = 0, m_Y = 0;
        public FormReturnCheckout(int x, int y, BakeryOrderSet.OrderRow order, decimal total)
        {
            m_X = x;
            m_Y = y;
            m_Order = order;
            m_Total = total;
            m_Income = total;
            InitializeComponent();
        }

        private void FormReturnCheckout_Load(object sender, EventArgs e)
        {
            Location = new Point(m_X, m_Y);
                labelTotal.Text = m_Total.ToString();
                labelIncome.Text = m_Total.ToString();
                dateTimePicker1.MaxDate = DateTime.Now;
                btnNumber0.Click += btnNumberX_Click;
                btnNumber1.Click += btnNumberX_Click;
                btnNumber2.Click += btnNumberX_Click;
                btnNumber3.Click += btnNumberX_Click;
                btnNumber4.Click += btnNumberX_Click;
                btnNumber5.Click += btnNumberX_Click;
                btnNumber6.Click += btnNumberX_Click;
                btnNumber7.Click += btnNumberX_Click;
                btnNumber8.Click += btnNumberX_Click;
                btnNumber9.Click += btnNumberX_Click;
                btnNumber100.Click += btnNumberX_Click;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
                BakeryOrderSet.OrderRow m_Order;
        decimal m_Total;
        decimal m_MoneyGot;
        decimal m_Debuct = 0;
        decimal m_Income;
        char m_PayBy='A';
        //public FormCheckout(int x,int y,BakeryOrderSet.OrderRow order,decimal total)
        //{
        //    m_X = x;
        //    m_Y = y;
        //    m_Order = order;
        //    m_Total = total;
        //    m_Income = total;
        //    InitializeComponent();
        //}

        private void btnPayCheck_Click(object sender, EventArgs e)
        {
            if (checkOldOrder())//检查旧单时间是否符合事实
            {
                DialogResult = DialogResult.OK;
                if (m_PayBy == 'A')
                    Tag = m_MoneyGot;
                else if (m_PayBy == 'B' || m_PayBy == 'C')  // 刷卡及券沒有 實收
                    Tag = 0;
                else
                {
                    MessageBox.Show("未知的付款方式!");
                    return;
                }
                int oldOrderID = OldOrderID();
                if (oldOrderID == 0)
                {
                    MessageBox.Show("退货失败!");
                    return;
                }
                m_Order.OldID = oldOrderID;
                m_Order.Deduct = m_Debuct;
                m_Order.Income = m_Income;   
                Close();
            }
        }

        //private void btnCancel_Click(object sender, EventArgs e)
        //{
        //    DialogResult = DialogResult.Cancel;
        //    Close();
        //}


        TextBox m_Current = null;
        private void btnNumberX_Click(object sender, EventArgs e)
        {
            if (m_Current == null) return;
            Button btn = sender as Button;
            m_Current.Focus();
            SendKeys.Send(btn.Text);
        }

        private void textBoxCashGot_Enter(object sender, EventArgs e)
        {
            if (m_Current != sender)
                m_Current = sender as TextBox;
        }

        private void textBoxDeduct_Enter(object sender, EventArgs e)
        {
            if (m_Current != sender)
                m_Current = sender as TextBox;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (m_Current == null) return;
            Button btn = sender as Button;
            m_Current.Focus();
            m_Current.SelectAll();
            SendKeys.Send("\b");
        }

        //private void btnNumber100_Click(object sender, EventArgs e)
        //{

        //}

        private void btnCalc_Click(object sender, EventArgs e)
        {
            decimal cashGot = 0, deduct = 0, change = 0;
            if (!decimal.TryParse(textBoxDeduct.Text, out deduct) || deduct == 0)
                labelDeduct.Text = "";
            else
            {
                if ((m_Total - deduct) >0)
                {
                    MessageBox.Show("應收不可為負值!");
                    return;
                }
                labelDeduct.Text = deduct.ToString();
            }
            m_Income = m_Total + deduct;
            labelIncome.Text = m_Income.ToString();
                    
            if (!decimal.TryParse(textBoxCashGot.Text, out cashGot) || cashGot == 0)
                labelChange.Text = labelCashGot.Text = "";
            else
            {
                if (cashGot <0)
                {
                    MessageBox.Show("收現不可為負值!");
                    return;
                }
                change = cashGot + m_Total + deduct;
                if (change < 0)
                {
                    MessageBox.Show("找零不可為負值!");
                    return;
                }
                labelCashGot.Text = (-cashGot).ToString();
                labelChange.Text = change.ToString();
            }

            m_MoneyGot =-cashGot;
            m_Debuct = -deduct;
        }

        private void FormCheckout_Shown(object sender, EventArgs e)
        {
            textBoxCashGot.Focus();
        }

        private void textBoxOldOrder_Enter(object sender, EventArgs e)
        {
            if (m_Current != sender)
                m_Current = sender as TextBox;
        }

        private void textBoxOldOrder_TextChanged(object sender, EventArgs e)
        {
            if (textBoxOldOrder.Text.Length >8)
            {
                btnPayCheck.Enabled = true;
            }
            else
            {
                btnPayCheck.Enabled = false;
            }
        }
        bool checkOldOrder()
        {
            string oldorder = textBoxOldOrder.Text;
            string s = oldorder.Remove(4);
            if (Convert.ToInt32(s) > 1231)
            {
                MessageBox.Show("旧单信息填写不正确！");
                return false;
            }
            string s1 = oldorder.Insert(2, "/");
            string s2 = s1.Remove(5);
            if (DateTime.Parse(s2) > DateTime.Now)
            {
                MessageBox.Show("旧单信息填写不正确！");
                return false;
            }
            string s3 = oldorder.Remove(0, 4).Remove(1);
            if (Convert.ToInt32(s3)<=0)
            {
                MessageBox.Show("旧单信息填写不正确！");
                return false;
            }
            return true;
        }
        int OldOrderID()
        {
            try
            {
                string oldorder = textBoxOldOrder.Text;
                string s = oldorder.Remove(4);
                string s1 = oldorder.Remove(0, 4).Remove(1);
                string s2 = oldorder.Remove(0, 5);
                int id = (Convert.ToInt32(s) * 10 + Convert.ToInt32(s1)) * 100000 + Convert.ToInt32(s2);
                return id;
            }
            catch
            {
                return 0;
            }
        }

        private void tBPosId_TextChanged(object sender, EventArgs e)
        {
            if (tBPosId.TextLength == tBPosId.MaxLength)
            {
                tBNo.Focus(); oldordertext();
            }
        }

        private void tBDateY_Enter(object sender, EventArgs e)
        {
            if (m_Current != sender)
                m_Current = sender as TextBox;
        }

        private void tBDateM_Enter(object sender, EventArgs e)
        {
            if (m_Current != sender)
                m_Current = sender as TextBox;
        }

        private void tBDateD_Enter(object sender, EventArgs e)
        {
            if (m_Current != sender)
                m_Current = sender as TextBox;
        }

        private void tBPosId_Enter(object sender, EventArgs e)
        {
            if (m_Current != sender)
                m_Current = sender as TextBox;
        }

        private void tBNo_Enter(object sender, EventArgs e)
        {
            if (m_Current != sender)
                m_Current = sender as TextBox;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tBPosId.Focus();
          oldordertext ();
        }
        void oldordertext ()
    {
        string[] s = dateTimePicker1.Text.Split('/');
        if (s[1].Length==1)
        {
            s[1] = 0 + s[1];
        }
        if (s[2].Length == 1)
        {
            s[2] = 0 + s[2];
        }
        textBoxOldOrder.Text = s[1] + s[2] + tBPosId.Text + tBNo.Text;
        }

        private void tBNo_TextChanged(object sender, EventArgs e)
        {
            oldordertext();
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            SetButtonVisualStyleExcept(sender as Button);
            //labelCashGot.Visible = labelChange.Visible = true;
            m_PayBy = 'A';  // 請參照FormCashier的 Dictionary<char,string> DicPayBy
            //textBoxCashGot.Enabled = true;
            dateTimePicker1.Enabled = true;
        }

        private void btnCard_Click(object sender, EventArgs e)
        {
            SetButtonVisualStyleExcept(sender as Button);
           // labelCashGot.Visible = labelChange.Visible = false;
            m_PayBy = 'B';
           // textBoxCashGot.Enabled = false;
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker1.Enabled = false;
        }

        private void btnCoupon_Click(object sender, EventArgs e)
        {
            SetButtonVisualStyleExcept(sender as Button);
            //labelCashGot.Visible = labelChange.Visible = false;
            m_PayBy = 'C';
            //textBoxCashGot.Enabled = false;
        }
        void SetButtonVisualStyleExcept(Button btn)
        {
            btnCard.UseVisualStyleBackColor = true;
            btnCash.UseVisualStyleBackColor = true;
            btnCoupon.UseVisualStyleBackColor = true;
            btn.UseVisualStyleBackColor = false;
        }
    }
}
