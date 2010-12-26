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
            // TODO: 這行程式碼會將資料載入 'vEDataSet.Ingredient' 資料表。您可以視需要進行移動或移除。
            this.ingredientTableAdapter.Fill(this.vEDataSet.Ingredient);
            // TODO: 這行程式碼會將資料載入 'vEDataSet.Stock' 資料表。您可以視需要進行移動或移除。
            this.stockTableAdapter.Fill(this.vEDataSet.Stock);

        }
    }
}
