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
    public partial class FormApartment : Form
    {
        public FormApartment()
        {
            InitializeComponent();
        }

        private void apartmentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.apartmentBindingSource.EndEdit();
            this.apartmentTableAdapter.Update(this.vEDataSet.Apartment);
        }

        private void FormApartment_Load(object sender, EventArgs e)
        {
            apartmentTableAdapter.Connection = MapPath.VEConnection;
            this.apartmentTableAdapter.Fill(this.vEDataSet.Apartment);
            MyFunction.SetFieldLength(apartmentDataGridView, vEDataSet.Apartment);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyFunction.AddNewItem(this.apartmentDataGridView, "columnApartmentID", "ApartmentID", vEDataSet.Apartment);
        }
    }
}
