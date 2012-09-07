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
    public partial class FormHR : Form
    {
        public FormHR()
        {
            InitializeComponent();
        }

        private void hRBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.hRBindingSource.EndEdit();
            this.hRTableAdapter.Update(this.vEDataSet.HR);

        }

        private void FormHR_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'vEDataSet.HRDetail' 資料表。您可以視需要進行移動或移除。
            this.hRDetailTableAdapter.Fill(this.vEDataSet.HRDetail);
            // TODO: 這行程式碼會將資料載入 'vEDataSet.HR' 資料表。您可以視需要進行移動或移除。
            this.hRTableAdapter.Fill(this.vEDataSet.HR);

        }

        private void hRDetailDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
