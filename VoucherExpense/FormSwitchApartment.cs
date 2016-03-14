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
    public partial class FormSwitchApartment : Form
    {
        DamaiDataSet.ApartmentDataTable m_AuthorizedApartment;
        public delegate void DelegateApartmentSwitchTo(int apartmentID);
        DelegateApartmentSwitchTo m_ApartmentSwitchTo = null;
        public FormSwitchApartment(DamaiDataSet.ApartmentDataTable authorizedApartment,DelegateApartmentSwitchTo apartmentSwitchTo)
        {
            m_AuthorizedApartment   = authorizedApartment;
            m_ApartmentSwitchTo     = apartmentSwitchTo;
            InitializeComponent();
        }

        private void FormSwitchApartment_Load(object sender, EventArgs e)
        {
            apartmentBindingSource.DataSource = m_AuthorizedApartment;
        }

        private void apartmentDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var view = (DataGridView)sender;
            DataGridViewRow row = view.Rows[e.RowIndex];
            if (row == null) return;
            DataRowView rowView=(DataRowView)row.DataBoundItem;
            var apRow=(DamaiDataSet.ApartmentRow)rowView.Row;
            this.Visible = false; // 叫m_ApartmentSwitchTo時會關掉這個Form, 不隱藏會有DataError
            m_ApartmentSwitchTo(apRow.ApartmentID);
            Close();
        }
    }
}
