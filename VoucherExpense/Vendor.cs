//#define UseSQLServer
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
            DamaiDataSet.VendorDataTable table = MyFunction.SaveCheck<DamaiDataSet.VendorDataTable>(
                                            this, vendorBindingSource, damaiDataSet.Vendor);
            if (table == null) return;
            MyFunction.SetGlobalFlag(GlobalFlag.basicDataModified);
            foreach (DamaiDataSet.VendorRow r in table)
            {
                if (r.RowState != DataRowState.Deleted)
                {
                    r.BeginEdit();
                    r.LastUpdated = DateTime.Now;
                    r.EndEdit();
                }
            }
            damaiDataSet.Vendor.Merge(table);
            this.vendorSQLAdapter.Update(damaiDataSet.Vendor);
            damaiDataSet.Vendor.AcceptChanges();
        }


        private void Vendor_Load(object sender, EventArgs e)
        {
            this.vendorBindingSource.DataSource = damaiDataSet;
            this.vendorSQLAdapter.Connection.ConnectionString = DB.SqlConnectString(MyFunction.HardwareCfg);
            this.vendorSQLAdapter.Fill(this.damaiDataSet.Vendor);
            MyFunction.SetFieldLength(vendorDataGridView, damaiDataSet.Vendor);
            MyFunction.SetControlLengthFromDB(this, damaiDataSet.Vendor);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyFunction.AddNewItem(vendorDataGridView, "columnVendorID", "VendorID", damaiDataSet.Vendor);
        }

        private void vendorDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!MyFunction.ColumnIDGood(vendorDataGridView, "columnVendorID", e.RowIndex))
                e.Cancel = true;
        }
    }
}