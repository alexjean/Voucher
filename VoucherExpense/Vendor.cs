using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VoucherExpense
{
    public partial class Vendor : Form
    {
        public Vendor()
        {
            InitializeComponent();
        }

        private void vendorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            VEDataSet.VendorDataTable table = MyFunction.SaveCheck<VEDataSet.VendorDataTable>(
                                                        this, vendorBindingSource, vEDataSet.Vendor);
            if (table == null) return;
            MyFunction.SetGlobalFlag(GlobalFlag.basicDataModified);
            foreach (VEDataSet.VendorRow r in table)
            {
                if (r.RowState != DataRowState.Deleted)
                {
                    r.BeginEdit();
                    r.LastUpdated = DateTime.Now;
                    r.EndEdit();
                }
            }
            vEDataSet.Vendor.Merge(table);
            this.vendorTableAdapter.Update(this.vEDataSet.Vendor);
            vEDataSet.Vendor.AcceptChanges();
        }


        private void Vendor_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'vEDataSet.Vendor' 資料表。您可以視需要進行移動或移除。
            vendorTableAdapter.Connection = MapPath.VEConnection;
            this.vendorTableAdapter.Fill(this.vEDataSet.Vendor);
            MyFunction.SetFieldLength(vendorDataGridView, vEDataSet.Vendor);
            MyFunction.SetControlLengthFromDB(this,vEDataSet.Vendor);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyFunction.AddNewItem(vendorDataGridView, "columnVendorID", "VendorID", vEDataSet.Vendor);
 
        }

        private void vendorDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!MyFunction.ColumnIDGood(vendorDataGridView, "columnVendorID", e.RowIndex))
                e.Cancel = true;
        }
    }
}