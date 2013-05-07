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
            try
            {
                this.vendorTableAdapter.Fill(this.veDataSet1.Vendor);
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取供貨商時出錯,原因:" + ex.Message);
                Close();
                return;
            }
            dgViewUserSelected.DataSource = m_FormVoucher.m_SelectedVoucher;
            decimal sum = 0;
            foreach (CSelectedVoucher v in m_FormVoucher.m_SelectedVoucher)
                sum += v.Cost;
            labelSum.Text = sum.ToString("f1");
            int count=this.m_FormVoucher.m_SelectedVoucher.Count;
            labelCount.Text = "共 " + count.ToString() + "單";
            if (count == 0) btnPrintUserSelected.Enabled = false;
            ShowSelectedVenders();
        }

        void GetSelectedSupplier(ref List<int> ids, ref List<string> names)
        {
            foreach (DataGridViewRow row in vendorDataGridView.SelectedRows)
            {
                int vendorID = -1;
                if (!int.TryParse(row.Cells["columnVendorID"].FormattedValue.ToString(), out vendorID))
                {
                    MessageBox.Show("供貨商代碼不正確!");
                    continue;
                }
                names.Add(row.Cells["columnVendorName"].FormattedValue.ToString());
                ids.Add(vendorID);
            }
        }


        void PrintSelectedSupplier()
        {
            List<string> names = new List<string>();
            List<int> ids = new List<int>();
            GetSelectedSupplier(ref ids, ref names);
            if (ids.Count <= 0)
            {
                MessageBox.Show("沒有選擇任何供貨商!");
                return;
            }
            string msg="確定列出<";
            foreach(string name in names)  msg+=(name+" ");
            msg+= ">本月供貨明細?(無憑証號及未核可單不會印出)";
            DialogResult result = MessageBox.Show(msg, "", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                m_FormVoucher.m_SelectedVenderID = ids;
                m_FormVoucher.m_SelectedVenderName = names;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnPrintSelected_Click(object sender, EventArgs e)
        {
            PrintSelectedSupplier();
        }

        void ShowSelectedVenders()
        {
            List<string> names = new List<string>();
            List<int> ids = new List<int>();
            GetSelectedSupplier(ref ids, ref names);
            if (ids.Count <= 0)
            {
                labelSelectedSupplier.Text = "未選任何供貨商";
                return;
            }
            string msg = "";
            foreach (string name in names) msg += (name + " ");
            labelSelectedSupplier.Text = msg;
        }

        private void vendorDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowSelectedVenders();
        }

        //private void 列印選擇的單子()
        //{
        //    
        //}

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            this.vendorDataGridView.SelectAll();
            ShowSelectedVenders();
        }

        private void btnPrintUserSelected_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定印出選擇的" + labelCount.Text + "張供貨明細?", "", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                m_FormVoucher.m_PrintSelectedVouchers = true;
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

    }
}