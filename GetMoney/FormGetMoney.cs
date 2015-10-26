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

        private void requestsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.requestsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.getMoneyDataSet);

        }

        private void FormGetMoney_Load(object sender, EventArgs e)
        {
            this.requestsTableAdapter.Fill(this.getMoneyDataSet.Requests);

        }


        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            //IsEnabled(true);//资料设置为可编辑
            departmentTextBox.Focus();
            //newRequests();
        }
    }
}
