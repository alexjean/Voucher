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
    public partial class FormAccounting : Form
    {
        public FormAccounting()
        {
            InitializeComponent();
        }

        private void FormAccounting_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'damaiDataSet.AccVoucherDetail' 資料表。您可以視需要進行移動或移除。
            this.accVoucherDetailTableAdapter.Fill(this.damaiDataSet.AccVoucherDetail);
            // TODO: 這行程式碼會將資料載入 'damaiDataSet.Operator' 資料表。您可以視需要進行移動或移除。
            this.operatorTableAdapter.Fill(this.damaiDataSet.Operator);
            // TODO: 這行程式碼會將資料載入 'damaiDataSet.HR' 資料表。您可以視需要進行移動或移除。
            this.hRTableAdapter.Fill(this.damaiDataSet.HR);
            // TODO: 這行程式碼會將資料載入 'damaiDataSet.AccountingTitle' 資料表。您可以視需要進行移動或移除。
            this.accountingTitleTableAdapter.Fill(this.damaiDataSet.AccountingTitle);
            // TODO: 這行程式碼會將資料載入 'damaiDataSet.AccVoucher' 資料表。您可以視需要進行移動或移除。
            this.accVoucherTableAdapter.Fill(this.damaiDataSet.AccVoucher);

        }
    }
}
