﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BakeryOrder
{
    public partial class ModifyPassword : Form
    {
        BakeryOrderSet m_BakeryOrderSet;
        int m_CashierID;
        public ModifyPassword(BakeryOrderSet bakeryOrderSet,int id)
        {
            m_CashierID = id;
            m_BakeryOrderSet = bakeryOrderSet;
            InitializeComponent();
        }

        void MessageBoxShow(string msg)
        {
            Form form = new FormMessage(msg);
            form.ShowDialog();
        }

        private void ModifyPassword_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            for (int i = 0; i <= 9; i++)
            {
                string name = "btnNumber" + i.ToString();
                foreach (Control ctl in this.Controls)
                    if (ctl.Name == name)
                    {
                        ctl.Click += this.btnNumberX_Click;
                        break;
                    }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            MessageBoxShow("己取消,密碼未更改!");
        }

        private BakeryOrderSet.CashierRow GetRecord()
        {
            foreach (BakeryOrderSet.CashierRow r in m_BakeryOrderSet.Cashier)
            {
                if (r.CashierID == m_CashierID) return r;
            }
            return null;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string newPass=newPassTextBox.Text.Trim();
            if (newPass.Length<5)
            {
                MessageBoxShow("新密碼長度太短!");
                return;
            }
            if (newPass!=comfirmPassTextBox.Text.Trim())
            {
                MessageBoxShow("確認密碼和新密碼不同!");
                return;
            }
            string oldPass=oldPassTextBox.Text.Trim();
            if (newPass == oldPass)
            {
                MessageBoxShow("不要玩了!新舊密碼都一樣");
                return;
            }
            BakeryOrderSet.CashierRow row = GetRecord();
            if (row==null)
            {
                MessageBoxShow("對不起!系統發生錯誤,找不到你的密碼!");
                Close();
                return;
            }
            if (row.CashierPassword.Trim()!=oldPass)
            {
                MessageBoxShow("舊密碼不符!");
                return;
            }
            try
            {
                row.BeginEdit();
                row.CashierPassword=newPass;
                row.LastUpdated = DateTime.Now;       // 必需更新,以便店長端來覆蓋時能判斷
                row.EndEdit();
                this.cashierTableAdapter.Update(row);
            }
            catch(Exception ex)
            {
                MessageBoxShow("更新密碼時出錯," + ex.Message);
                return;
            }
            Close();
            MessageBoxShow("更改成功, 請記住新密碼!\r\n新密碼只在本机有效,店長無法知曉!\r\n店長再次設定時,新密碼將被店長設定取代");
        }

        TextBox m_Current = null;
        private void btnNumberX_Click(object sender, EventArgs e)
        {
            if (m_Current == null) return;
            Button btn = sender as Button;
            m_Current.Focus();
            SendKeys.Send(btn.Text);
        }

        private void oldPassTextBox_Enter(object sender, EventArgs e)
        {
            if (m_Current != sender)
                m_Current = sender as TextBox;
        }

        private void newPassTextBox_Enter(object sender, EventArgs e)
        {
            if (m_Current != sender)
                m_Current = sender as TextBox;
        }

        private void comfirmPassTextBox_Enter(object sender, EventArgs e)
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

     

    }
}