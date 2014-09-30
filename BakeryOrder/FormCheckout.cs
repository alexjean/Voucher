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
    public partial class FormCheckout : Form
    {
        int m_X = 0, m_Y=0;
        BakeryOrderSet.OrderRow m_Order;
        decimal m_Total;
        decimal m_MoneyGot;
        decimal m_Debuct = 0;
        decimal m_Income;
        char m_PayBy='A';
        decimal m_DiscountRate = 1;
        public FormCheckout(int x,int y,BakeryOrderSet.OrderRow order,decimal total)
        {
            m_X = x;
            m_Y = y;
            m_Order = order;
            m_Total = total;
            m_Income = total;
            InitializeComponent();
        }

        private void btnPayCheck_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            if (m_PayBy == 'A')
                Tag = m_MoneyGot;
            else if (m_PayBy == 'B' || m_PayBy=='C')  // 刷卡及券沒有 實收
                Tag = 0;
            else
            {
                MessageBox.Show("未知的付款方式!");
                return;
            }
            m_Order.Deduct = m_Debuct;
            m_Order.Income = m_Income;
            m_Order.PayBy = m_PayBy.ToString();
            m_Order.DiscountRate = m_DiscountRate;
            m_Order.OldID = 0;
            m_Order.RCashierID = 0;
            m_Order.MemberID = MemberInfo.MemberId;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormCheckout_Load(object sender, EventArgs e)
        {
            Location = new Point(m_X, m_Y);
            labelTotal.Text = m_Total.ToString();
            labelIncome.Text = m_Total.ToString();

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

        void SetButtonVisualStyleExcept(Button btn)
        {
            btnCard.UseVisualStyleBackColor = true;
            btnCash.UseVisualStyleBackColor = true;
            btnCoupon.UseVisualStyleBackColor = true;
            btn.UseVisualStyleBackColor = false;
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            SetButtonVisualStyleExcept(sender as Button);
            labelCashGot.Visible = labelChange.Visible = true;
            m_PayBy = 'A';  // 請參照FormCashier的 Dictionary<char,string> DicPayBy
            textBoxCashGot.Enabled = true;
        }

        private void btnCard_Click(object sender, EventArgs e)
        {
            SetButtonVisualStyleExcept(sender as Button);
            labelCashGot.Visible=labelChange.Visible = false;
            m_PayBy = 'B';
            textBoxCashGot.Enabled = false;
        }

        private void btnCoupon_Click(object sender, EventArgs e)
        {
            SetButtonVisualStyleExcept(sender as Button);
            labelCashGot.Visible = labelChange.Visible = false;
            m_PayBy = 'C';
            textBoxCashGot.Enabled = false;
        }


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

        private void btnNumber100_Click(object sender, EventArgs e)
        {

        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            decimal cashGot = 0, deduct = 0, change = 0, discount = 0;
            if (!decimal.TryParse(labelDiscount.Text, out discount) || discount == 0)
            { labelDiscount.Text = ""; }
            if (!decimal.TryParse(textBoxDeduct.Text, out deduct) || deduct == 0)
                labelDeduct.Text = "";
            else
            {
                if ((m_Total - deduct) < 0)
                {
                    MessageBox.Show("應收不可為負值!");
                    return;
                }
                labelDeduct.Text = deduct.ToString();
            }
            m_Income = m_Total - deduct - discount;
            labelIncome.Text = m_Income.ToString();

            if (!decimal.TryParse(textBoxCashGot.Text, out cashGot) || cashGot == 0)
                labelChange.Text=labelCashGot.Text = "";
            else
            {
                if (cashGot < 0)
                {
                    MessageBox.Show("收現不可為負值!");
                    return;
                }
                change = cashGot - m_Total + deduct + discount;
                if (change < 0)
                {
                    MessageBox.Show("找零不可為負值!");
                    return;
                }
                labelCashGot.Text = cashGot.ToString();
                labelChange.Text = change.ToString();
            }

            m_MoneyGot = cashGot;
            m_Debuct   = deduct;
        }

        private void FormCheckout_Shown(object sender, EventArgs e)
        {
            textBoxCashGot.Focus();
        }

        private void btZhekou85_Click(object sender, EventArgs e)
        {
            SetZhekouButtonVisualStyleExcept(sender as Button);
            //textBoxDeduct.Text = (m_Total - Math.Floor(m_Total * (decimal)0.85)).ToString();//直接移除小数
            //m_PayBy ='D';
            m_DiscountRate = 0.85m;
            labelDiscount.Text = (m_Total - Math.Floor(m_Total * (decimal)0.85)).ToString();//直接移除小数
        }

        private void btZhekou88_Click(object sender, EventArgs e)
        {
            SetZhekouButtonVisualStyleExcept(sender as Button);
            //textBoxDeduct.Text = ((m_Total - Math.Floor(m_Total * (decimal)0.88)).ToString("0"));//直接移除小数
            //m_PayBy = 'E';
            m_DiscountRate = 0.88m;
            labelDiscount.Text = (m_Total - Math.Floor(m_Total * (decimal)0.88)).ToString();//直接移除小数
        }

        private void btZhekou8_Click(object sender, EventArgs e)
        {
            SetZhekouButtonVisualStyleExcept(sender as Button);
            m_DiscountRate = 0.8m;
            labelDiscount.Text = (m_Total - Math.Floor(m_Total * (decimal)0.8)).ToString();//直接移除小数
        }

        void SetZhekouButtonVisualStyleExcept(Button btn)
        {
            btZhekou8.UseVisualStyleBackColor = true;
            btZhekou85.UseVisualStyleBackColor = true;
            btZhekou88.UseVisualStyleBackColor = true;
            btn.UseVisualStyleBackColor = false;
        }


       

      
    }
}
