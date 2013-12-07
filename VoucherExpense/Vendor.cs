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
#if (UseSQLServer)
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

#else
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
#endif
        }


        private void Vendor_Load(object sender, EventArgs e)
        {
#if (UseSQLServer)
            this.vendorBindingSource.DataSource = damaiDataSet;
            this.vendorSQLAdapter.Fill(this.damaiDataSet.Vendor);
            MyFunction.SetFieldLength(vendorDataGridView, damaiDataSet.Vendor);
            MyFunction.SetControlLengthFromDB(this, damaiDataSet.Vendor);
#else
            this.vendorBindingSource.DataSource = vEDataSet;
            vendorTableAdapter.Connection = MapPath.VEConnection;
            this.vendorTableAdapter.Fill(this.vEDataSet.Vendor);
            MyFunction.SetFieldLength(vendorDataGridView, vEDataSet.Vendor);
            MyFunction.SetControlLengthFromDB(this,vEDataSet.Vendor);
#endif
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
#if (UseSQLServer)
            MyFunction.AddNewItem(vendorDataGridView, "columnVendorID", "VendorID", damaiDataSet.Vendor);
#else
            MyFunction.AddNewItem(vendorDataGridView, "columnVendorID", "VendorID", vEDataSet.Vendor);
#endif
        }

        private void vendorDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!MyFunction.ColumnIDGood(vendorDataGridView, "columnVendorID", e.RowIndex))
                e.Cancel = true;
        }
    }
}