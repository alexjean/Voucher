using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyDataSet = VoucherExpense.DamaiDataSet;
using MyOperatorRow = VoucherExpense.DamaiDataSet.OperatorRow;


namespace VoucherExpense
{
    public partial class ModifyPassword : Form
    {
        public ModifyPassword()
        {
            InitializeComponent();
        }

        MyDataSet m_DataSet = new MyDataSet();
        VoucherExpense.DamaiDataSetTableAdapters.OperatorTableAdapter operatorAdapter = new DamaiDataSetTableAdapters.OperatorTableAdapter();
        private void ModifyPassword_Load(object sender, EventArgs e)
        {
            try
            {
                operatorAdapter.Connection.ConnectionString = DB.SqlConnectString(MyFunction.HardwareCfg);
                operatorAdapter.Fill(m_DataSet.Operator);
            }
            catch
            {
                MessageBox.Show("操作員資料庫讀取失敗,無法更改密碼!");
                Close();
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            MessageBox.Show("己取消,密碼未更改!");
        }

        private MyOperatorRow GetRecord()
        {
            int id = MyFunction.OperatorID;
            foreach (var r in m_DataSet.Operator)
            {
                if (r.OperatorID == id) return r;
            }
            return null;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string newPass=newPassTextBox.Text.Trim();
            if (newPass.Length<5)
            {
                MessageBox.Show("新密碼長度太短!");
                return;
            }
            if (newPass!=comfirmPassTextBox.Text.Trim())
            {
                MessageBox.Show("確認密碼和新密碼不同!");
                return;
            }
            string oldPass=oldPassTextBox.Text.Trim();
            if (newPass == oldPass)
            {
                MessageBox.Show("不要玩了!新舊密碼都一樣");
                return;
            }
            var row = GetRecord();
            if (row==null)
            {
                MessageBox.Show("對不起!系統發生錯誤,找不到你的密碼!");
                Close();
                return;
            }
            if (row.Password.Trim()!=oldPass)
            {
                MessageBox.Show("舊密碼不符!");
                return;
            }
            try
            {
                row.BeginEdit();
                row.Password=newPass;
                row.EndEdit();
                operatorAdapter.Update(row);
            }
            catch(Exception ex)
            {
                MessageBox.Show("更新密碼時出錯," + ex.Message);
                return;
            }
            Close();
            MessageBox.Show("更改成功, 請記住新密碼, 經理無法為你重設密碼!");
        }

    }
}