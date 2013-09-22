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
    public partial class FormBillList : Form
    {
        public FormBillList()
        {
            InitializeComponent();
        }



        private void FormBillList_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'vEDataSet.Requests' 資料表。您可以視需要進行移動或移除。
            this.requestsTableAdapter.Fill(this.vEDataSet.Requests);

        }


        VEDataSet.RequestsRow Addrow;

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
            if (txbDepartment.Text!="")
            {
                 Addrow.Department = txbDepartment.Text;
            }

            if (txbApplicant.Text != "")
            {
                Addrow.Applicant = txbApplicant.Text;
            }
            if (txbRequestsUse.Text != "")
            {
                Addrow.RequestsUse = txbRequestsUse.Text;
            }
            if (txbUintName.Text != "")
            {
                Addrow.UintName = txbUintName.Text;
            }
            if (txbBankOfDeposit.Text != "")
            {
                Addrow.BankOfDeposit = txbBankOfDeposit.Text;
            }
            if (txbAccount.Text != "")
            {
                Addrow.Account = txbAccount.Text;
            }
            if (txbMoneyA.Text != "")
            {
                Addrow.MoneyA = Convert.ToDecimal(txbMoneyA.Text);
            }
            if (txbMoneyAa.Text != "")
            {
                Addrow.MoneyAa = Convert.ToDecimal(txbMoneyAa.Text);
            }

            if (txbPaymentMethods.Text != "")
            {
                Addrow.PaymenMethods = txbPaymentMethods.Text;
            }
            if (txbHandoverPeople.Text != "")
            {
                Addrow.HandoverPoeple = txbHandoverPeople.Text;
            } 
            Addrow.EndEdit();
            vEDataSet.Requests.Rows.Add(Addrow);
            this.requestsTableAdapter.Update(vEDataSet.Requests);
            this.bindingNavigatorAddNewItem.Enabled = true;
        }

        private void bindingNavigatorAddNewItem_Click_1(object sender, EventArgs e)
        {
            this.bindingNavigatorAddNewItem.Enabled = false;

            int maxID = 0;
            int maxCode = 0;
            foreach (VEDataSet.RequestsRow item in vEDataSet.Requests)
            {
                if (item.RequestsID > maxID)
                {
                    maxID = item.RequestsID;
                }
                if (item.ListNumber > maxCode)
                {
                    maxCode = item.ListNumber;
                }
            }
            Addrow = vEDataSet.Requests.NewRequestsRow();
            Addrow.RequestsID = maxID + 1;
            Addrow.ListNumber = maxCode + 1;
            Addrow.SetAccountNull();
            Addrow.SetOperatorIDNull();
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
            Addrow.SetIsCancelNull();
            Addrow.SetIsCancelNull();
            txbListNum.Text = intToint6(Addrow.ListNumber, 6);
            Addrow.EndEdit();
            
        }

    }
}
