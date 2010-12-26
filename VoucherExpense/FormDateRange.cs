using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VoucherExpense
{

    public interface FormWantDate
    {
        void SetDateRange(int from, int date);
    }

    public partial class FormDateRange : Form
    {
        int m_Month=0;
        FormWantDate m_Form;
        public FormDateRange(int month, FormWantDate form)
        {
            m_Month = month;
            m_Form = form;
            InitializeComponent();
        }

        private void FormDateRange_Load(object sender, EventArgs e)
        {
            int[] MonthNo ={ 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (m_Month <= 0 || m_Month>12)
            {
                MessageBox.Show("請先選擇月份!");
                Close();
                return;
            }
            comboBoxFrom.Items.Clear();
            comboBoxTo.Items.Clear();
            int no=MonthNo[m_Month-1];
            comboBoxFrom.Items.Add(" ");
            comboBoxTo.Items.Add(" ");
            for (int i = 1; i <= no; i++)
            {
                comboBoxFrom.Items.Add(i.ToString()+"日");
                comboBoxTo.Items.Add(i.ToString() + "日");
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int from,to;
            from=comboBoxFrom.SelectedIndex;
            to=comboBoxTo.SelectedIndex;
            if (from == 0) from = 1;
            if (to == 0) to = 31;
            if (from > to)
            {
                MessageBox.Show("開始日大於結束日");
                return;
            }
            m_Form.SetDateRange(from, to);
            Close();
        }
    }
}