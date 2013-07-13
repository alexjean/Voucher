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

        List<CNameIDForComboBox> m_TableTypeList = new List<CNameIDForComboBox>();
        private void FormScraps_Load(object sender, EventArgs e)
        {
            productTableAdapter.Connection               = MapPath.BakeryConnection;
            operatorTableAdapter.Connection              = MapPath.VEConnection;
            productScrappedTableAdapter.Connection       = MapPath.VEConnection;
            productScrappedDetailTableAdapter.Connection = MapPath.VEConnection;

            productTableAdapter.Fill(bakeryOrderSet.Product);
            operatorTableAdapter.Fill               (vEDataSet.Operator);
            productScrappedDetailTableAdapter.Fill  (vEDataSet.ProductScrappedDetail);
            productScrappedTableAdapter.Fill        (vEDataSet.ProductScrapped);

            m_TableTypeList.Add(new CNameIDForComboBox(1, "报废"));
            m_TableTypeList.Add(new CNameIDForComboBox(2, "试吃"));
            cNameIDForComboBoxBindingSource.DataSource = m_TableTypeList;
            
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            DateTime maxDate = new DateTime(MyFunction.IntHeaderYear, 1, 1);
            foreach (var r in vEDataSet.ProductScrapped)
            {
                if (r.RowState == DataRowState.Deleted) continue;
                if (!r.IsScrappedDateNull())
                {
                    if (r.ScrappedDate >= maxDate) maxDate = r.ScrappedDate.AddDays(1); // 設定盤點日為最大那張的加一天
                }
                if ((!r.IsLockedNull()) && r.Locked == true) continue;
            }
            if (maxDate.Year != MyFunction.IntHeaderYear)
            {
                MessageBox.Show("預計的日期超過資料年<" + MyFunction.HeaderYear + ">");
                return;
            }
            this.productScrappedBindingSource.AddNew();
            DataGridViewRow row = dgvProductScrapped.CurrentRow;
            DataGridViewCell cell = row.Cells["ColumnProductScrappedID"];
            if (cell == null)
            {
                MessageBox.Show("程式或資料庫版本錯誤, <dgvProductScrapped>沒有<ColumnProductScrappedID>!");
                return;
            }
            if (Convert.IsDBNull(cell.Value))
            {
                try
                {
                    MyFunction.AddNewItem(dgvProductScrapped, "ColumnProductScrappedID", "ProductScrappedID", vEDataSet.ProductScrapped);
                    bindingNavigatorAddNewItem.Enabled = false;
                    var rowView = row.DataBoundItem as DataRowView;
                    var data = rowView.Row as VEDataSet.ProductScrappedRow;
                    data.ScrappedDate = maxDate;       // 盤點日
                    int productScrappedID = data.ProductScrappedID;
                    // 從產品表中有Code的,加入vEDataSet.ProductScrappedDetail
                    foreach (BakeryOrderSet.ProductRow product in bakeryOrderSet.Product)
                    {
                        if (product.IsCodeNull()) continue;
                        if (product.Code <= 0) continue;    // 無代号產品不納入報癈
                        VEDataSet.ProductScrappedDetailRow detail = vEDataSet.ProductScrappedDetail.NewProductScrappedDetailRow();
                        detail.ID = Guid.NewGuid();
                        detail.ProductID = product.ProductID;
                        detail.ProdcutScrappedID = productScrappedID;
                        if (!product.IsPriceNull())
                            detail.Price = (decimal)product.Price;
                        if (!product.IsEvaluatedCostNull())
                            detail.EvaluatedCost = product.EvaluatedCost;
                        vEDataSet.ProductScrappedDetail.AddProductScrappedDetailRow(detail);
                    }

                    productScrappedBindingSource.ResetBindings(false);  // productScrappedDetailBindingSource 會連動,不用自己呼叫
                    chBoxHide.Checked = false;                    // 初創立,要看到所有有產品碼的
                }
                catch (Exception ex)
                {
                    MessageBox.Show("新增時錯誤,原因<" + ex.Message + ">");
                    return;
                }
            }

        }

        private void chBoxHide_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxHide.Checked)
                this.productScrappedDetailBindingSource.Filter = "Volume>0";
            else
                this.productScrappedDetailBindingSource.RemoveFilter();

        }

        private void dgvProductScrapped_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView view = sender as DataGridView;
            int iCol = e.ColumnIndex;
            int iRow = e.RowIndex;
            DataGridViewColumn column = view.Columns[iCol];
            {
                MessageBox.Show("第" + iRow.ToString() + "行["+column.HeaderText+"]資料錯誤,原因:" + e.Exception.Message);
                e.Cancel = true;
            }
        }
    }
}
