using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VoucherExpense
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void voucherBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!this.Validate())
            {
                MessageBox.Show("有資料錯誤, 請改好再存!");
                return;
            }
            this.voucherBindingSource.EndEdit();

            VEDataSet.VoucherDataTable table = (VEDataSet.VoucherDataTable)vEDataSet.Voucher.GetChanges();
            if (table == null)
            {
                MessageBox.Show("沒有改動任何資料! 不用存");
                return;
            }
            foreach (VEDataSet.VoucherRow r in table)
            {
                if (r.RowState != DataRowState.Deleted)
                {
                    r.BeginEdit();
                    r.KeyinID = MyFunction.OperatorID;
                    r.LastUpdated = DateTime.Now;
                    r.EndEdit();
                }
            }
            vEDataSet.Voucher.Merge(table);
            this.voucherTableAdapter.Update(this.vEDataSet.Voucher);
            this.vEDataSet.Voucher.AcceptChanges();

        }

        private void test_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'vEDataSet.Voucher' 資料表。您可以視需要進行移動或移除。
            this.voucherTableAdapter.Fill(this.vEDataSet.Voucher);

        }
    }
}