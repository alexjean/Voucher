using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace VoucherExpense
{
    public partial class FormBillPrint : Form
    {
        public FormBillPrint()
        {
            InitializeComponent();
        }
        VEDataSet.RequestsRow Addrow;
        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                pD.Print();
                if (true)
                {
                    
                }
                //Addrow.OperatorID="";
               Addrow.Department=txbDepartment.Text;
                Addrow.Applicant=txbApplicant.Text;
               Addrow.RequestsUse=txbRequestsUse.Text;
               Addrow.UintName=txbUintName.Text;
                Addrow.BankOfDeposit=txbBankOfDeposit.Text;
                Addrow.Account=txbAccount.Text;
                Addrow.MoneyA=Convert.ToDecimal(txbMoneyA.Text);
                Addrow.MoneyAa=Convert.ToDecimal(txbMoneyAa.Text);
                Addrow.PaymenMethods=txbPaymentMethods.Text;
                Addrow.HandoverPoeple=txbHandoverPeople.Text;
                //Addrow.BillingDate=;
                //Addrow.DateOfPayment=;
                Addrow.EndEdit();
                vEDataSet.Requests.Rows.Add(Addrow);
                this.requestsTableAdapter.Update(vEDataSet.Requests);
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印出错" + ex.ToString());
            }
        }

        private void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           // 获取Graphics
            Graphics g = e.Graphics;
            //DrawImage(g);
            Font font = new Font("宋体", 12, GraphicsUnit.Pixel);
            Brush brush = new SolidBrush(Color.Black);
            List<TextBox> ctxts = GetCTextBoxes(this.panel1);
            
            Image image = panel1.BackgroundImage;
            Graphics g1 = Graphics.FromImage(image);
            foreach (TextBox ctxt in ctxts)
            {
                    g1.DrawString(ctxt.Text, font, brush, ctxt.Location.X, ctxt.Location.Y);
            }
            g.DrawImage(image, new Point(0, 0));
            
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
        
        private void FormBillPrint_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'vEDataSet.Requests' 資料表。您可以視需要進行移動或移除。
            this.requestsTableAdapter.Fill(this.vEDataSet.Requests);

            int maxID = 0;
            int maxCode = 0;
            foreach (VEDataSet.RequestsRow item in vEDataSet.Requests)
            {
                if (item.RequestsID > maxID)
                {
                    maxID = item.RequestsID;
                }
                if (item.ListNumber>maxCode)
                {
                    maxCode = item.ListNumber;
                }
            }
            Addrow = vEDataSet.Requests.NewRequestsRow();
           Addrow.RequestsID = maxID + 1;
           Addrow.ListNumber = maxCode + 1;
           txbListNum.Text = intToint6(Addrow.ListNumber,6);
           Addrow.EndEdit();
            
        }
        string intToint6(int num,int numlength)
        { 
            string number=num.ToString();
            int len = number.Length;
            if (len<numlength)
            {
                for (int i = 0; i < numlength-len; i++)
                {
                    number ="0"+ number;
                }
            }
            return number;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
