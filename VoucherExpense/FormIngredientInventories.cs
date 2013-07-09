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
    public partial class FormIngredientInventories : Form
    {
        public FormIngredientInventories()
        {
            InitializeComponent();
        }

        private void inventoryBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.inventoryBindingSource.EndEdit();
            inventoryDetailBindingSource.EndEdit();
            DateTime now = DateTime.Now;
            var detailTable = vEDataSet.InventoryDetail.GetChanges() as VEDataSet.InventoryDetailDataTable;
            if (detailTable != null)   // 把有更改的InventoryDetail填 Inventory.Lastupdated的值
            {
                var IDs = (from r in detailTable 
                           where (r.RowState!=DataRowState.Deleted) && (!r.IsInventoryIDNull())
                           select r.InventoryID).Distinct();
                foreach (int id in IDs)
                {
                    var rows = from r in vEDataSet.Inventory select r;
                    if (rows.Count() != 0)
                        rows.First().LastUpdated=now;
                }
            }

            var table = vEDataSet.Inventory.GetChanges() as VEDataSet.InventoryDataTable;
            if (table == null && detailTable == null)
            {
                MessageBox.Show("沒有更改,不用存檔!");
                return;
            }
            try
            {
                int deleted = 0, updated = 0;
                if (detailTable != null) inventoryDetailTableAdapter.Update(vEDataSet.InventoryDetail);
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
                        updated++;
                    }
                    inventoryTableAdapter.Update(table);
                    vEDataSet.Inventory.Merge(table);
                    vEDataSet.Inventory.AcceptChanges();
                }
                string msg = "共 ";
                if (updated > 0) msg += updated.ToString() + "筆更改,";
                if (deleted > 0) msg += deleted.ToString() + "筆刪除,";
                MessageBox.Show( msg+" 己存檔!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("存檔錯誤! 錯誤<" + ex.Message + ">");
                return;
            }
            bindingNavigatorAddNewItem.Enabled = true;
        }

        private void FormIngredientInventories_Load(object sender, EventArgs e)
        {
            this.ingredientTableAdapter.Fill(this.vEDataSet.Ingredient);
            this.inventoryTableAdapter.Fill(this.vEDataSet.Inventory);
            this.inventoryDetailTableAdapter.Fill(this.vEDataSet.InventoryDetail);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            DateTime maxDate = new DateTime(MyFunction.IntHeaderYear, 1, 1);
            foreach (var r in vEDataSet.Inventory)
            {
                if (r.RowState == DataRowState.Deleted) continue;
                if (!r.IsCheckDayNull())
                {
                    if (r.CheckDay >= maxDate) maxDate = r.CheckDay.AddDays(1); // 設定盤點日為最大那張的加一天
                }
                if ((!r.IsLockedNull()) && r.Locked == true) continue;
                MessageBox.Show("有尚未核可的單子,無法新增盤點表!");
                return;
            }
            if (maxDate.Year != MyFunction.IntHeaderYear)
            {
                MessageBox.Show("預計的盤點日超過資料年<"+MyFunction.HeaderYear+">");
                return;
            }
            this.inventoryBindingSource.AddNew();
            DataGridViewRow row = dgvInventories.CurrentRow;
            DataGridViewCell cell = row.Cells["ColumnInventoryID"];
            if (cell == null)
            {
                MessageBox.Show("程式或資料庫版本錯誤, <dgvInventories>沒有<ColumnInventoryID>!");
                return;
            }
            if (Convert.IsDBNull(cell.Value))
            {
                try
                {
                    MyFunction.AddNewItem(dgvInventories, "ColumnInventoryID", "InventoryID", vEDataSet.Inventory);
                    bindingNavigatorAddNewItem.Enabled = false;
                    DataRowView rowView = row.DataBoundItem as DataRowView;
                    VEDataSet.InventoryRow data = rowView.Row as VEDataSet.InventoryRow;
                    data.CheckDay = maxDate;       // 盤點日
                    int inventoryID = data.InventoryID;
                    // 從食材表中有Code的,加入vEDataSet.InventoryDetail
                    foreach (VEDataSet.IngredientRow ingredient in vEDataSet.Ingredient)
                    {
                        if (ingredient.IsCodeNull()) continue;
                        if (ingredient.Code <= 0) continue;    // 無代号食材不納入盤點
                        VEDataSet.InventoryDetailRow detail = vEDataSet.InventoryDetail.NewInventoryDetailRow();
                        detail.ID = Guid.NewGuid();
                        detail.IngredientID = ingredient.IngredientID;
                        detail.InventoryID  = inventoryID;
                        vEDataSet.InventoryDetail.AddInventoryDetailRow(detail);
                    }

                    inventoryBindingSource.ResetBindings(false);  // inventoryDetailBindingSource 會連動,不用自己呼叫
                    chBoxHide.Checked = false;                    // 初創立,要看到所有有產品碼的
                }
                catch (Exception ex)
                {
                    MessageBox.Show("新增時錯誤,原因<" + ex.Message + ">");
                    return;
                }
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvInventories.CurrentRow;
            if (row == null)
            {
                MessageBox.Show("無單可刪!");
                return;
            }
            DataGridViewCell cell = row.Cells["ColumnLocked"];
            if (cell == null)
            {
                MessageBox.Show("程式或資料庫版本錯誤, <dgvInventories>沒有<ColumnLocked>!");
                return;
            }
            object obj = cell.Value;
            if (!Convert.IsDBNull(obj))
            {
                if (typeof(bool) == obj.GetType())
                {
                    if (((bool)obj) == true)
                    {
                        MessageBox.Show("己核可的盤點單無法刪除!");
                        return;
                    }
                }
            }
            DataRowView rowView = row.DataBoundItem as DataRowView;
            VEDataSet.InventoryRow inventory = rowView.Row as VEDataSet.InventoryRow;
            int id = inventory.InventoryID;
            var rows = from r in vEDataSet.InventoryDetail where r.InventoryID == id select r;
            List<VEDataSet.InventoryDetailRow> list = rows.ToList<VEDataSet.InventoryDetailRow>();    // 直接用linq的Collection會說枚舉己經改變
            foreach (VEDataSet.InventoryDetailRow r in list)     // 用RemoveInventoryDetailRow() 會只是Remove, 不是留下要Delete的tag
                r.Delete();
            inventoryBindingSource.RemoveCurrent();              // 要放在後面,因為還要取出 Current的IventoryID
            bindingNavigatorDeleteItem.Enabled = false;
        }

        void SetDetailLocked(bool locked)
        {
            checkDayDateTimePicker.Enabled = !locked;
            btnEvaluate.Enabled = !locked;
            ColumnStockChecked.ReadOnly = locked;
            ColumnPosition.ReadOnly = locked;
        }

        private void dgvInventories_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView view=sender as DataGridView;
                DataGridViewRow dgvRow=view.Rows[e.RowIndex];
                DataRowView rowView= dgvRow.DataBoundItem as DataRowView;
                VEDataSet.InventoryRow dataRow = rowView.Row as VEDataSet.InventoryRow;
                if (dataRow.IsLockedNull())
                     SetDetailLocked(false);
                else SetDetailLocked(dataRow.Locked);
            }
            catch{};
            chBoxHide_CheckedChanged(null, null);
            inventoryDetailBindingSource.ResetBindings(false);
        }

        private void chBoxHide_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxHide.Checked)
                inventoryDetailBindingSource.Filter = "StockVolume>0";
            else
                inventoryDetailBindingSource.RemoveFilter();
        }

        private void dgvInventoryDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView view = sender as DataGridView;
            int iCol = e.ColumnIndex;
            int iRow = e.RowIndex;
            DataGridViewColumn column = view.Columns[iCol];
            if (column.Name == "ColumnStockChecked")
            {
                MessageBox.Show("第" + iRow.ToString() + "行<盤點>資料錯誤,原因:" + e.Exception.Message);
                e.Cancel = true;
            }
            else if (column.Name == "ColumnPosition")
            {
                MessageBox.Show("第"+iRow.ToString()+"行<位於>資料錯誤,原因:"+e.Exception.Message);
                e.Cancel = true;
            }
        }

        private void checkDayDateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            DateTimePicker picker = sender as DateTimePicker;
            DateTime date = picker.Value.Date;
            if (date.Year != MyFunction.IntHeaderYear)
            {
                MessageBox.Show("只能選" + MyFunction.HeaderYear + "年");
                e.Cancel = true;
                return;
            }
            foreach (var row in vEDataSet.Inventory)
            {
                if (row.IsLockedNull()) continue;
                if (!row.Locked) continue;
                if (row.IsCheckDayNull()) continue;
                if (row.CheckDay.Date >= date)
                {
                    MessageBox.Show("己有盤點單日期為<"+row.CheckDay.Date.ToShortDateString()+"> 不可小於等於該日期!");
                    e.Cancel = true;
                    return;
                }

            }
        }

        private void dgvInventoryDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            labelIngredientsCount.Text = dgvInventoryDetail.Rows.Count.ToString();
        }
    }
}
