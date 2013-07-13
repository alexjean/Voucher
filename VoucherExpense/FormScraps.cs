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
    public partial class FormScraps : Form
    {
        public FormScraps()
        {
            InitializeComponent();
        }

        private void productScrappedBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productScrappedBindingSource.EndEdit();
            this.productScrappedTableAdapter.Update(this.vEDataSet.ProductScrapped);

        }

        private void FormScraps_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'vEDataSet.ProductScrappedDetail' 資料表。您可以視需要進行移動或移除。
            this.productScrappedDetailTableAdapter.Fill(this.vEDataSet.ProductScrappedDetail);
            // TODO: 這行程式碼會將資料載入 'vEDataSet.ProductScrapped' 資料表。您可以視需要進行移動或移除。
            this.productScrappedTableAdapter.Fill(this.vEDataSet.ProductScrapped);

        }
    }
}
