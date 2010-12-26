using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VoucherExpense
{
    public partial class FormPrintSelect : Form
    {
        Voucher m_FormVoucher = null;
        public FormPrintSelect(Voucher form)
        {
            m_FormVoucher = form;
            InitializeComponent();
        }

        private void vendorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.vendorBindingSource.EndEdit();
            this.vendorTableAdapter.Update(this.veDataSet1.Vendor);

        }

        private void FormPrintSelect_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'veDataSet1.Vendor' 資料表。您可以視需要進行移動或移除。
            this.vendorTableAdapter.Fill(this.veDataSet1.Vendor);
            dgViewUserSelected.DataSource = m_FormVoucher.m_SelectedVoucher;
            decimal sum = 0;
            foreach (CSelectedVoucher v in m_FormVoucher.m_SelectedVoucher)
                sum += v.Cost;
            labelSum.Text = sum.ToString("f1");
            labelCount.Text = "共 " + this.m_FormVoucher.m_SelectedVoucher.Count.ToString() + "單";
        }

        private void 供貨商ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string venderName = "";
            List<string> name = new List<string>();
            List<int> id = new List<int>();
            foreach (DataGridViewRow row in vendorDataGridView.SelectedRows)
            {
                //            DataGridViewRow row=vendorDataGridView.SelectedRows[0];
                int vendorID = -1;
                if (!int.TryParse(row.Cells["columnVendorID"].FormattedValue.ToString(), out vendorID))
                {
                    MessageBox.Show("供貨商代碼不正確!");
                    return;
                }
                name.Add(row.Cells["columnVendorName"].FormattedValue.ToString());
                id.Add(vendorID);
                venderName += row.Cells["columnVendorName"].FormattedValue.ToString()+" ";
            }
            DialogResult result=MessageBox.Show("確定列出<"+venderName+">本月供貨明細?(無憑証號及未核可單不會印出)"
                                                ,"",MessageBoxButtons.OKCancel);
            if (result==DialogResult.OK)
            {
                m_FormVoucher.m_SelectedVenderID = id;
                m_FormVoucher.m_SelectedVenderName = name;
                Close();
            }
        }
        /*
        private void 列印選擇的單子ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result=MessageBox.Show("確定印出選擇的"+labelCount.Text+"張供貨明細?"
                                                ,"",MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                m_FormVoucher.m_SelectedVenderID = Voucher.m_PrintSelected;
                Close();
            }
        }
        */
    }
}