//#define UseSQLServer
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            this.apartmentSQLAdapter.Update(this.damaiDataSet.Apartment);
        }

        private void FormApartment_Load(object sender, EventArgs e)
        {
            try
            {
                this.apartmentBindingSource.DataSource = damaiDataSet;
                this.apartmentSQLAdapter.Fill(this.damaiDataSet.Apartment);
                MyFunction.SetFieldLength(apartmentDataGridView, this.damaiDataSet.Apartment);
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取部門資料庫錯誤:" + ex.Message);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyFunction.AddNewItem(this.apartmentDataGridView, "columnApartmentID", "ApartmentID", this.damaiDataSet.Apartment);
        }
    }
}
