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
        public FormSwitchApartment(DamaiDataSet.ApartmentDataTable authorizedApartment)
        {
            m_AuthorizedApartment = authorizedApartment;
            InitializeComponent();
        }

        private void FormSwitchApartment_Load(object sender, EventArgs e)
        {
            apartmentBindingSource.DataSource = m_AuthorizedApartment;
        }
    }
}
