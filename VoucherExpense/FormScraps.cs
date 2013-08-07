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
            this.productScrappedDetailBindingSource.EndEdit();

            DateTime now = DateTime.Now;
            var detailTable = vEDataSet.ProductScrappedDetail.GetChanges() as VEDataSet.ProductScrappedDetailDataTable;
            if (detailTable != null)   // 把有更改的InventoryDetail填 Inventory.Lastupdated的值
            {
                var IDs = (from r in detailTable
                           where (r.RowState != DataRowState.Deleted) && (!r.IsProdcutScrappedIDNull())
                           select r.ProdcutScrappedID).Distinct();
                foreach (int id in IDs)
                {
                    var rows = from r in vEDataSet.ProductScrapped where (r.RowState != DataRowState.Deleted) && (id == r.ProductScrappedID) select r;
                    if (rows.Count() != 0)
                        rows.First().LastUpdated = now;
                }
            }

            var table = vEDataSet.ProductScrapped.GetChanges() as VEDataSet.ProductScrappedDataTable;
            if (table == null && detailTable == null)
            {
                MessageBox.Show("沒有更改,不用存檔!");
                return;
            }
            try
            {
                int deleted = 0, updated = 0;
                if (detailTable != null) this.productScrappedDetailTableAdapter.Update(vEDataSet.ProductScrappedDetail);
                if (table != null)
                {
                    foreach (var r in table)
                    {
                        if (r.RowState == DataRowState.Deleted)
                        {
                            deleted++;
                            continue;
                        }
                        r.LastUpdated = now;
                        r.KeyinID = MyFunction.OperatorID;
                        updated++;
                    }
                    productScrappedTableAdapter.Update(table);
                    vEDataSet.ProductScrapped.Merge(table);
                    vEDataSet.ProductScrapped.AcceptChanges();
                }
                string msg = "共 ";
                if (updated > 0) msg += updated.ToString() + "筆更改,";
                if (deleted > 0) msg += deleted.ToString() + "筆刪除,";
                MessageBox.Show(msg + " 己存檔!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("存檔錯誤! 錯誤<" + ex.Message + ">");
                return;
            }
            bindingNavigatorAddNewItem.Enabled = true;
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

            m_TableTypeList.Add(new CNameIDForComboBox(0, " "));
            m_TableTypeList.Add(new CNameIDForComboBox(1, "日報癈"));
            m_TableTypeList.Add(new CNameIDForComboBox(2, "試吃"));
            m_TableTypeList.Add(new CNameIDForComboBox(3, "其他"));
            cNameIDForComboBoxBindingSource.DataSource = m_TableTypeList;

            ColumnLocked.ReadOnly = !MyFunction.LockInventory;
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
                DataGridViewCell cell = view.Rows[iRow].Cells[iCol];
                MessageBox.Show("第" + iRow.ToString() + "行["+column.HeaderText+"]資料錯誤,原因:" + e.Exception.Message);
                e.Cancel = true;
            }
        }

        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            // 先回存螢幕
            this.productScrappedBindingSource.EndEdit();
            this.productScrappedDetailBindingSource.EndEdit();
            try
            {
                DataRowView rowView = productScrappedBindingSource.Current as DataRowView;
                var curr = rowView.Row as VEDataSet.ProductScrappedRow;
                var details = curr.GetProductScrappedDetailRows();
                decimal value = 0, cost = 0;
                foreach (var d in details)
                {
                    if (d.IsVolumeNull()) continue;
                    if (d.IsProductIDNull()) continue;
                    var rows=from r in bakeryOrderSet.Product where r.ProductID==d.ProductID select r;
                    if (rows.Count() > 0)  // 有找到此產品,重新帶入Price及EvaluatedCost
                    {
                        var r1 = rows.First();
                        if (!r1.IsPriceNull())         d.Price = (decimal)r1.Price;
                        if (!r1.IsEvaluatedCostNull()) d.EvaluatedCost = r1.EvaluatedCost;
                    }
                    if (!d.IsPriceNull())
                        value += d.Price * d.Volume;
                    if (!d.IsEvaluatedCostNull())
                        cost += d.EvaluatedCost * d.Volume;
                }
                DateTime now = DateTime.Now;
                curr.SoldValue = Math.Round(value,2);
                curr.IngredientsCost = Math.Round(cost,2);
                curr.EvaluatedDate = now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("計算估值時發生錯誤,原因:" + ex.Message);
            }

          

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dgvProductScrapped.CurrentRow;
            if (row == null)
            {
                MessageBox.Show("無單可刪!");
                return;
            }
            DataGridViewCell cell = row.Cells["ColumnLocked"];
            if (cell == null)
            {
                MessageBox.Show("程式或資料庫版本錯誤, <dgvProdcutScrapped>沒有<ColumnLocked>!");
                return;
            }
            object obj = cell.Value;
            if (!Convert.IsDBNull(obj))
            {
                if (typeof(bool) == obj.GetType())
                {
                    if (((bool)obj) == true)
                    {
                        MessageBox.Show("己核可的報癈單無法刪除!");
                        return;
                    }
                }
            }
            // Delete Detail資料庫
            DataRowView rowView = row.DataBoundItem as DataRowView;
            var productScrapped = rowView.Row as VEDataSet.ProductScrappedRow;
            int id = productScrapped.ProductScrappedID;
            var rows = from r in vEDataSet.ProductScrappedDetail where r.ProdcutScrappedID == id select r;
            var list = rows.ToList<VEDataSet.ProductScrappedDetailRow>(); // 用Collection,delete 會影響枚舉
            foreach (var r in list)                                     // 用RemoveProductScrappedDetailRow() 會只是Remove, 不是留下要Delete的tag
                r.Delete();
            productScrappedBindingSource.RemoveCurrent();               // 要放在後面,因為還要取出 Current的prodcutScrappedID
            bindingNavigatorDeleteItem.Enabled = false;

        }

        void SetDetailLocked(bool locked)
        {
            scrappedDateDateTimePicker.Enabled = !locked;
            btnEvaluate.Enabled = !locked;
            ColumnVolume.ReadOnly = locked;
        }

        private void dgvProductScrapped_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView view = sender as DataGridView;
                DataGridViewRow dgvRow = view.Rows[e.RowIndex];
                DataRowView rowView = dgvRow.DataBoundItem as DataRowView;
                var dataRow = rowView.Row as VEDataSet.ProductScrappedRow;
                if (dataRow.IsLockedNull())
                    SetDetailLocked(false);
                else SetDetailLocked(dataRow.Locked);
            }
            catch { };
            chBoxHide_CheckedChanged(null, null);
            productScrappedDetailBindingSource.ResetBindings(false);
        }

        private void dgvScrappedDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var view = sender as DataGridView;
            int iCol = e.ColumnIndex;
            DataGridViewColumn column = view.Columns[iCol];
            if (column == null) return;
            if (column.Name == "ColumnVolume")   // 一改 量,EvaluatedDate就DBNull
            {
                DataRowView rowView = productScrappedBindingSource.Current as DataRowView;
                var curr = rowView.Row as VEDataSet.ProductScrappedRow;
                curr.SetEvaluatedDateNull();
            }
        }

        private void dgvProductScrapped_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = sender as DataGridView;
            DataGridViewColumn column = view.Columns[e.ColumnIndex];
            if (column == null) return;
            if (column.Name != "ColumnLocked") return;  // 只檢查 '核可' 這個欄位
            try
            {
                DataGridViewRow dgvRow = view.Rows[e.RowIndex];
                DataGridViewCell cell = dgvRow.Cells[e.ColumnIndex];
                if (cell.ValueType != typeof(bool))
                {
                    MessageBox.Show("ColumnLocked的資料不是bool ,程式有錯誤!");
                    return;
                }
                DataRowView rowView = view.Rows[e.RowIndex].DataBoundItem as DataRowView;
                bool locked = (bool)cell.Value;
                var current = rowView.Row as VEDataSet.ProductScrappedRow;
                if (locked)    // 檢查 核可 打勾情況
                {
                    if (current.IsEvaluatedDateNull() || current.EvaluatedDate.Year < 2000)
                    {
                        MessageBox.Show("此盤點單未曾估值!");
                        cell.Value = false;
                    }
                }
            }
            catch { }
        }

        private void FormScraps_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvScrappedDetail.Visible = false;
            dgvProductScrapped.Visible = false;
        }
    }
}
