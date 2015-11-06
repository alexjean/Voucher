using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetMoney
{
    public partial class FormGetMoney : Form
    {
        public FormGetMoney()
        {
            InitializeComponent();
        }

        RequestsAdapter m_RequestsAdapter = new RequestsAdapter();
        public class RequestsAdapter : GetMoneyDataSetTableAdapters.RequestsTableAdapter
        {
            string SaveStr;
            public int FillBySelectStr(GetMoneyDataSet.RequestsDataTable dataTable, string SelectStr)
            {
                SaveStr = base.CommandCollection[0].CommandText;
                base.CommandCollection[0].CommandText = SelectStr;
                int result = Fill(dataTable);
                base.CommandCollection[0].CommandText = SaveStr;
                return result;
            }
        }

        string DateStr(DateTime t)
        {
            return "#" + t.Year.ToString("d4") + "/" + t.Month.ToString("d2") + "/" + t.Day.ToString("d2") + "#";
        }

        string CreateSql(int year, int month)
        {
            int m = month + 1;
            DateTime EndofMonth;
            if (m > 12)
                EndofMonth = new DateTime(year, 12, 31);
            else
                EndofMonth = (new DateTime(year, m, 1) - new TimeSpan(0, 0, 1)).Date;
            string str1 = DateStr(new DateTime(year,month,1));
            string str2 = DateStr(EndofMonth);
            return "Where (BillingDate>=" + str1+") AND (BillingDate<=" + str2 + ")";
        }

        public bool LoadData(int year, int month)
        {
            if (month < 1   || month > 12 ) return false;
            if (year < 2008 || year > 2030) return false;
            string sql = CreateSql(year,month);
            try
            {
                m_RequestsAdapter.FillBySelectStr(getMoneyDataSet.Requests, "Select * From [Requests] " + sql + " Order by [ListNumber]");
                return true;
            }
            catch (Exception ex)
            {
                //LastErrorString = ex.Message;
            }
            return false;
        }


        private void requestsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.requestsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.getMoneyDataSet);

        }

        private void FormGetMoney_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'getMoneyDataSet.CorpList' 資料表。您可以視需要進行移動或移除。
            this.corpListTableAdapter.Fill(this.getMoneyDataSet.CorpList);
            //this.requestsTableAdapter.Fill(this.getMoneyDataSet.Requests);
            GetMoneyDataSetTableAdapters.CorpListTableAdapter corpAdapter = new GetMoneyDataSetTableAdapters.CorpListTableAdapter();
            corpAdapter.ClearBeforeFill = true;
            corpAdapter.Fill(getMoneyDataSet.CorpList);
            cbCorp.DataSource = getMoneyDataSet.CorpList;
        }


        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            //IsEnabled(true);//资料设置为可编辑
            departmentTextBox.Focus();
            //newRequests();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
