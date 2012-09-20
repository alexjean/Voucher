using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VoucherExpense
{
    public partial class FormStock : Form
    {
        public FormStock()
        {
            InitializeComponent();
        }

        private void FormStock_Load(object sender, EventArgs e)
        {
            this.ingredientTableAdapter.Fill(this.vEDataSet.Ingredient);
            this.stockTableAdapter.Fill(this.vEDataSet.Stock);

        }
    }
}
