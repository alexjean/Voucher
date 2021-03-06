﻿using System;
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
        public static int ExchangeNo=0;
        int m_X = 0, m_Y=0;
        BakeryOrderSet.OrderRow m_Order;
        decimal m_Total;
        decimal m_MoneyGot;
        decimal m_Deduct = 0;
        decimal m_Income = 0;
        decimal m_CashIncome  =0;
        decimal m_CouponIncome=0;
        char m_PayBy='A';
        decimal m_DiscountRate = 1;
        FormCashier m_Form;
        public FormCheckout(int x,int y,BakeryOrderSet.OrderRow order,decimal total,FormCashier form)
        {
            m_Form = form;
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
            else if (m_PayBy == 'B' || m_PayBy == 'C' || m_PayBy == 'E')  // 刷卡及支付宝 微信沒有 實收 
                Tag = 0;
            else if (m_PayBy == 'D' || m_PayBy == 'F')   // 收券A 券B
            {
                Tag = m_MoneyGot;
            }
            else
            {
                MessageBox.Show("未知的付款方式!");
                return;
            }
            m_Order.Deduct  = m_Deduct;
            m_Order.Income  = m_Income;
            m_Order.PayBy   = m_PayBy.ToString();
            m_Order.DiscountRate = m_DiscountRate;
            m_Order.CashIncome   = m_CashIncome;
            m_Order.CouponIncome = m_CouponIncome;
            m_Order.OldID      = 0;
            m_Order.RCashierID = 0;
            //m_Order.ExBread = ExchangeNo;
            //if (FormCashier.memberInfo == null)
            //{
            //    m_Order.MemberID = "0"; 
            //}
            //else
            //{
            //    m_Order.MemberID = FormCashier.memberInfo.MemberID.ToString();
            //}
            //if (m_Debuct==0&&FormCashier.memberScore!=null)
            //{
            //    Score(FormCashier.memberScore.MemberID.ToString(),FormCashier.BreadNO);
            //}
            //if (m_Debuct > 0 && FormCashier.memberScore != null)F
            //{
            //    //减去兑换面包值，此单不可累计麦子
            //    //Bread(FormCashier.memberScore.MemberID.ToString(), ExchangeNo);
            //    //设定打印 兑换面包数
            //    FormCashier.ExBread = ExchangeNo;
            //    //修改列表中面包数为0，用于打印积分为0，不影响有积分的单子
            //    FormCashier.BreadNO = 0;
            //}
            Close();
        }
        ///// <summary>
        ///// 修改指定会员的积分
        ///// </summary>
        ///// <param name="memberid"></param>
        ///// <param name="AddValue"></param>
        //public static void Score(string memberid,int AddValue)
        //{
        //    using (MemberDBEntities memberdb = new MemberDBEntities())
        //    {
        //        try
        //        {
        //            memberdb.ExecuteStoreCommand("update tbMemberScore set Score=Score+"+AddValue+" where MemberID='"+memberid+"'");
        //        }
        //        catch (Exception ex)
        //        {
        //            Form form = new FormMessage("更新会员积分时出错,原因:" + ex.Message);
        //            form.ShowDialog();
        //        } 
        //    }
          
        //}
        ///// <summary>
        ///// 修改指定会员的可兑换面包数
        ///// </summary>
        ///// <param name="memberid"></param>
        ///// <param name="AddValue"></param>
        //public static void Bread(string memberid, int AddValue)
        //{
        //    using (MemberDBEntities memberdb = new MemberDBEntities())
        //    {
        //        try
        //        {
        //            memberdb.ExecuteStoreCommand("update tbMemberScore set Bread=Bread-" + AddValue + " where MemberID='" + memberid + "'");
        //        }
        //        catch (Exception ex)
        //        {
        //            Form form = new FormMessage("更新会员数据时出错,原因:" + ex.Message);
        //            form.ShowDialog();
        //        }
        //    }

        //}
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
            Application.DoEvents();
        }

        /// <summary>
        /// 计算兑换面包带来的优惠价格
        /// </summary>
        /// <param name="m">面包个数</param>
        /// <param name="n">开始Index 0</param>
        /// <returns></returns>
        double Foo(double m, int n)
        {
            var item =mylist.GetRange(n, 1).FirstOrDefault();
            if ((m - item.No) <= 0)
            {
                return m * item.Price;
            }
            else
            {
                return item.Price * item.No + Foo(m - item.No, n+1);
            }
        }
        List<MenuItemForTag> mylist;
        
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
            if (FormCashier.memberScore!=null)
            {
                if (FormCashier.memberScore.Bread>0)
                {
                    int num = 0;
                    if (FormCashier.BreadNO >= FormCashier.memberScore.Bread)
                    {
                        num = (int)FormCashier.memberScore.Bread;
                    }
                    FormMessage form = new FormMessage("请输入兑换面包数不大于"+num,2);
                    form.ShowDialog();
                    if (ExchangeNo>0)
                    {
                        try
                        {
                            //对面包list进行价格降序排列
                            mylist = (FormCashier.listBread.OrderByDescending(o => o.Price)).ToList();
                            //计算出兑换优惠价格
                            double ExchangeOfMoney = Foo((double)ExchangeNo, 0);
                            textBoxDeduct.Text = ExchangeOfMoney.ToString();
                            textBoxDeduct.Enabled = false;
                        }
                        catch (Exception ex)
                        {
                            FormMessage exForm = new FormMessage("兑换面包后台计算出错，请暂停兑换面包操作并通知技术人员"+ex);
                        }
                    }
                }
            }
            if (m_Form.PayCode!=null && m_Form.PayCode != "")
            {
                textBoxCashGot.Enabled = false;
                btnCouponA.Enabled = false;
                btnCash.Enabled = false;
                btnCard.Enabled = false;
                char c0 = m_Form.PayCode[0];
                char c1 = m_Form.PayCode[1];
                if (c0 == '1' && (c1 > '0' && c1 <= '5'))   // 11-15是微信
                {
                    textBoxCashGot.Text = "刷微信不收现金";
                    m_PayBy = 'E';
                }
                else
                {
                    textBoxCashGot.Text = "刷支付宝不收现金";
                    m_PayBy = 'C';
                }
            }
        }

        void SetButtonVisualStyleExcept(Button btn)
        {
            btnCard.UseVisualStyleBackColor = true;
            btnCash.UseVisualStyleBackColor = true;
            btnCouponA.UseVisualStyleBackColor = true;
            btnCouponB.UseVisualStyleBackColor = true;
            btn.UseVisualStyleBackColor = false;
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            SetButtonVisualStyleExcept(sender as Button);
            labelCashGot.Visible = labelChange.Visible = true;
            m_PayBy = 'A';  // 請參照FormCashier的 Dictionary<char,string> DicPayBy
            labelCouponGot1.Visible = labelCouponGot2.Visible = labelCouponGot.Visible = textBoxCouponGot.Visible = false;
            textBoxCashGot.Enabled = true;
            textBoxCashGot.Focus();
            textBoxCouponGot.Text = "";
        }

        private void btnCard_Click(object sender, EventArgs e)
        {
            SetButtonVisualStyleExcept(sender as Button);
            labelCashGot.Visible=labelChange.Visible = false;
            m_PayBy = 'B';
            labelCouponGot1.Visible = labelCouponGot2.Visible = labelCouponGot.Visible = textBoxCouponGot.Visible = false;
            textBoxCashGot.Enabled = false;
            textBoxCashGot.Text = "";
            textBoxDeduct.Focus();
        }

        private void btnCouponA_Click(object sender, EventArgs e)
        {
            SetButtonVisualStyleExcept(sender as Button);
            labelCashGot.Visible = labelChange.Visible = true;
            m_PayBy = 'D';
            labelCouponGot1.Visible= labelCouponGot2.Visible=labelCouponGot.Visible = textBoxCouponGot.Visible = true;
            textBoxCashGot.Enabled = true;
            textBoxCashGot.Focus();
        }

        private void btnCouponB_Click(object sender, EventArgs e)
        {
            SetButtonVisualStyleExcept(sender as Button);
            labelCashGot.Visible = labelChange.Visible = true;
            m_PayBy = 'F';
            labelCouponGot1.Visible = labelCouponGot2.Visible = labelCouponGot.Visible = textBoxCouponGot.Visible = true;
            textBoxCashGot.Enabled = true;
            textBoxCashGot.Focus();

        }


        private void EnableKeyboard()
        {
            this.KeyUp    -= new System.Windows.Forms.KeyEventHandler(this.FormCheckout_KeyUp);
            this.KeyDown  -= new System.Windows.Forms.KeyEventHandler(this.FormCheckout_KeyDown);
            this.KeyPress -= new System.Windows.Forms.KeyPressEventHandler(this.FormCheckout_KeyPress);
        }

        private void DisableKeyboard()
        {
            this.KeyUp    += new System.Windows.Forms.KeyEventHandler(this.FormCheckout_KeyUp);
            this.KeyDown  += new System.Windows.Forms.KeyEventHandler(this.FormCheckout_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormCheckout_KeyPress);
        }

        TextBox m_Current = null;
        private void btnNumberX_Click(object sender, EventArgs e)
        {
            if (m_Current == null) return;
            Button btn = sender as Button;
            EnableKeyboard();
            m_Current.Focus();
            SendKeys.Send(btn.Text);
            Application.DoEvents();
            DisableKeyboard();

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

        private void textBoxCouponGot_Enter(object sender, EventArgs e)
        {
            if (m_Current != sender)
                m_Current = sender as TextBox;
        }

        private void btnClear_Click(object sender, EventArgs e) 
        {
            ExchangeNo = 0;
            if (m_Current == null) return;
            Button btn = sender as Button;
            EnableKeyboard();
            m_Current.Focus();
            m_Current.SelectAll();
            SendKeys.Send("\b");
            Application.DoEvents();
            DisableKeyboard();
        }

        private void btnNumber100_Click(object sender, EventArgs e)
        {

        }

        // 收券不找零, 所以couponGot可能比Income大, 此時couponIncome=couponGot > Income
        // 收券兼收現時,就會產生cashIncome.
        // 其他收款模式Income為m_Total-deduct-discount , cashIncome忽略不處理
        // 現金收款模式時, cashIncome視同Income,cashIncome不予處理
        private void btnCalc_Click(object sender, EventArgs e)
        {
            decimal cashGot = 0 , deduct = 0, change = 0, discount = 0;
            decimal cashIncome=0, couponIncome = 0;
            if (!decimal.TryParse(labelDiscount.Text, out discount) || discount == 0)
            {
                labelDiscount.Text = "";
            }
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
            {
                labelChange.Text=labelCashGot.Text = "";
                cashGot=0;
            }
            if (cashGot < 0)
            {
                MessageBox.Show("收現不可為負值!");
                return;
            }
            if (m_PayBy=='A')
            {
                change = cashGot - m_Total + deduct + discount;
                cashIncome=m_Income;  // 以前的資料不會填m_Income
                if (change < 0)
                {
                    MessageBox.Show("找零不可為負值!");
                    return;
                }
            }
            else if (m_PayBy == 'D' || m_PayBy=='F')  // 券A=>'D'  券B=>'F'
            {
                if (!decimal.TryParse(textBoxCouponGot.Text, out couponIncome) || couponIncome == 0)
                {
                    MessageBox.Show("券模式, 收券金額不能等於零!");
                    return;
                }
                if (couponIncome<0)
                {
                    MessageBox.Show("券模式, 收券金額不能小於零!");
                    return;
                }
                if (cashGot==0)
                {
                    change=0;
                    cashIncome=0;
                    if (couponIncome < m_Income)
                    {
                        MessageBox.Show("收券金額小於貨款！");
                        return;
                    }
                }
                else
                {
                    if ((couponIncome>=m_Income) && (cashGot>0))
                    {
                        MessageBox.Show("收券金額己大於貨款,不應再收現金,收現請填 0");
                        return;
                    }
                    change = cashGot+couponIncome-m_Total+deduct+discount;
                    if (change < 0)
                    {
                        MessageBox.Show("找零不可為負值!");
                        return;
                    }
                    cashIncome = cashGot-change;
                }
                labelCouponGot2.Text = couponIncome.ToString();
            }
            else
                change = 0;
            labelCashGot.Text = cashGot.ToString();
            labelChange.Text = change.ToString();

            m_MoneyGot = cashGot;
            m_Deduct   = deduct;
            m_CashIncome = cashIncome;
            m_CouponIncome = couponIncome;
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

        private void btZhekou95_Click(object sender, EventArgs e)
        {
            SetZhekouButtonVisualStyleExcept(sender as Button);
            m_DiscountRate = 0.95m;
            labelDiscount.Text = (m_Total - Math.Floor(m_Total * (decimal)0.95)).ToString();//直接移除小数
        }

        void SetZhekouButtonVisualStyleExcept(Button btn)
        {
            btZhekou95.UseVisualStyleBackColor = true;
            btZhekou85.UseVisualStyleBackColor = true;
            btZhekou88.UseVisualStyleBackColor = true;
            btn.UseVisualStyleBackColor = false;
        }

        private void FormCheckout_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void FormCheckout_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void FormCheckout_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        // 因為 Button會攔掉Return, KeyPreview=true也沒用,只好override ProcessDialogKey
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Return)
                return false;      // 吃掉Return
            else
                return base.ProcessDialogKey(keyData);
        }



    
    }
}
