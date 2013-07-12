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
                    var rows = from r in vEDataSet.Inventory where id==r.InventoryID select r;
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
                        r.KeyinID = MyFunction.OperatorID;
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
            operatorTableAdapter.Connection         = MapPath.VEConnection;
            ingredientTableAdapter.Connection       = MapPath.VEConnection;
            inventoryTableAdapter.Connection        = MapPath.VEConnection;
            inventoryDetailTableAdapter.Connection  = MapPath.VEConnection;

            operatorTableAdapter.Fill       (vEDataSet.Operator);
            ingredientTableAdapter.Fill     (vEDataSet.Ingredient);
            inventoryTableAdapter.Fill      (vEDataSet.Inventory);
            inventoryDetailTableAdapter.Fill(vEDataSet.InventoryDetail);
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
                inventoryDetailBindingSource.Filter = "StockVolume>0 OR PrevStockVolume>0 OR CurrentIn>0";
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

        // 檢查盤點單日期為一路向上
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
            var rowView = inventoryBindingSource.Current as DataRowView;
            var dataRow = rowView.Row as VEDataSet.InventoryRow;
            foreach (var row in vEDataSet.Inventory)
            {
                if (row.InventoryID == dataRow.InventoryID) continue; // 自己跳過
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

        // 檢查Locked 狀況
        bool ValidateLocked(bool locked,VEDataSet.InventoryRow current)
        {
            if (locked)    // 檢查 核可 打勾情況
            {
                if (current.IsEvaluatedDateNull() || current.EvaluatedDate.Year < 2000)
                {
                    MessageBox.Show("此盤點單未曾估值!");
                    return false;
                }
                return true;
            }
            // 只有最後一張可以取消核可
            int maxID = 0;
            try
            {
                maxID = (from r in vEDataSet.Inventory select r.InventoryID).Max();
            } catch{}
            if (current.InventoryID != maxID)
            {
                if (current.IsEvaluatedDateNull() || current.EvaluatedDate.Year < 2000)
                {
                    MessageBox.Show("此盤點單未曾估值 又不是最後一張, 請速處理!");
                    return true;
                }
                MessageBox.Show("只有最後一張才能取消核可!");
                return false;
            }
            return true;
        }

        private void dgvInventories_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = sender as DataGridView;
            DataGridViewColumn column = view.Columns[e.ColumnIndex];
            if (column==null) return;
            if (column.Name != "ColumnLocked") return;  // 只檢查 '核可' 這個欄位
            try
            {
                DataGridViewRow dgvRow=view.Rows[e.RowIndex];
                DataGridViewCell cell=dgvRow.Cells[e.ColumnIndex];
                if (cell.ValueType!=typeof(bool))
                {
                    MessageBox.Show("ColumnLocked的資料不是bool ,程式有錯誤!");
                    return;
                }
                DataRowView rowView = view.Rows[e.RowIndex].DataBoundItem as DataRowView;
                bool locked = (bool)cell.Value;
                if (!ValidateLocked(locked, rowView.Row as VEDataSet.InventoryRow))
                    cell.Value = !locked;
            }
            catch { }

        }

        VEDataSetTableAdapters.VoucherDetailTableAdapter m_VoucherDetailAdapter = null;
        VEDataSetTableAdapters.VoucherTableAdapter m_VoucherAdapter = null;
        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            // 先把螢幕內容存回
            inventoryBindingSource.EndEdit();
            inventoryDetailBindingSource.EndEdit();
            try
            {
                DataRowView rowView = inventoryBindingSource.Current as DataRowView;
                VEDataSet.InventoryRow curr = rowView.Row as VEDataSet.InventoryRow;
                var details = curr.GetInventoryDetailRows();
                // 清除本單的進貨及金額
                foreach (var dRow in details)
                {
                    dRow.StockMoney = 0;
                    dRow.LostMoney = 0;
                    dRow.CurrentIn = 0;
                }
                VEDataSet.InventoryRow prev = null;
                foreach (VEDataSet.InventoryRow r in vEDataSet.Inventory)   // 找到前一張單子
                {
                    if (r.InventoryID >= curr.InventoryID) continue;
                    if (prev == null) prev = r;
                    else if (prev.InventoryID < r.InventoryID)
                            prev = r;
                }
                if (prev == null) // 這是本年第一張
                {
                }
                else if (prev.IsCheckDayNull())
                {
                    MessageBox.Show("前期盤點單無日期,無法查找 進貨數量及估值!");
                    return;
                }
                else if (prev.Locked == false)
                {
                    MessageBox.Show("前期" + prev.CheckDay.ToShortDateString() + "盤點單尚未核可, 本期估值無法進行!");
                    return;
                }
                else if (curr.IsCheckDayNull())
                {
                    MessageBox.Show("本盤點單無日期,無法查找 進貨數量及估值!");
                    return;
                }
                else if (curr.CheckDay.Year!=MyFunction.IntHeaderYear)
                {
                    MessageBox.Show("本單盤點日期有誤, 和資料年"+MyFunction.IntHeaderYear.ToString()+"不同,,無法查找 進貨數量及估值!");
                    return;
                }
                else if (curr.CheckDay.Date <= prev.CheckDay.Date)
                {
                    MessageBox.Show("盤點單日期有誤, 比前期盤點表日期還早!");
                    return;
                }

                // 載入進貨單資料
                if (m_VoucherAdapter == null)
                {
                    m_VoucherAdapter = new VEDataSetTableAdapters.VoucherTableAdapter();
                    m_VoucherAdapter.Connection = MapPath.VEConnection;
                    m_VoucherAdapter.Fill(vEDataSet.Voucher);
                }
                if (m_VoucherDetailAdapter == null)
                {
                    m_VoucherDetailAdapter = new VEDataSetTableAdapters.VoucherDetailTableAdapter();
                    m_VoucherDetailAdapter.Connection = MapPath.VEConnection;
                    m_VoucherDetailAdapter.Fill(vEDataSet.VoucherDetail);
                }
                // 借 d.PrevStockVolume欄位來存,先進先出的盤點量
                foreach (VEDataSet.InventoryDetailRow d in details)
                    if (d.IsStockVolumeNull())
                        d.PrevStockVolume = 0;
                    else
                        d.PrevStockVolume = d.StockVolume;
                // 找出期間的進貨單
                DateTime prevDate=new DateTime(MyFunction.IntHeaderYear-1,12,31);
                if (prev!=null) prevDate=prev.CheckDay.Date;     // 盤點日當天的進貨單,都計入是本期的
                var vouchers = from vo in vEDataSet.Voucher
                               where (vo.StockTime.Date > prevDate) && (vo.StockTime.Date <= curr.CheckDay.Date) && (!vo.Removed)
                               orderby vo.StockTime descending
                               select vo;
                // 計算本期進貨
                foreach (VEDataSet.VoucherRow vo in vouchers)
                {
                    var ds=vo.GetVoucherDetailRows();
                    foreach (var d in ds)
                    {
                        if (d.IsIngredientIDNull()) continue; 
                        if (d.IsVolumeNull()) continue;   // 沒有數量
                        if (d.Volume <= 0) continue;
                        int id = d.IngredientID;
                        var des = from de in details where de.IngredientID == id select de;
                        if (des.Count() <= 0) continue;   // 盤點單找不到此食材
                        var de1 = des.First();
                        double vol=(double)d.Volume;
                        de1.CurrentIn+=vol;
                        // 算出相對應庫存的成本
                        if (de1.PrevStockVolume >= vol)
                        {
                            de1.StockMoney += d.Cost;
                            de1.PrevStockVolume -= vol;
                        }
                        else if (de1.PrevStockVolume>0)
                        {
                            de1.StockMoney += (d.Cost / (decimal)vol * (decimal)de1.PrevStockVolume);   // 小於
                            de1.PrevStockVolume = 0;
                        }
                    }
                }
                // 將前期盤點及位置 資料填入, 並計算多於進貨remainStock的成本
                if (prev == null)
                {
                    foreach (VEDataSet.InventoryDetailRow d in details)   // 前面有借用 d.PrevStockVolume, 先清成0
                    {
                        if (d.PrevStockVolume > 0)
                            RemainStockWarning(d.IngredientID, d.PrevStockVolume);
                        d.PrevStockVolume = 0;
                    }
                }
                else
                {
                    var prevDetails = prev.GetInventoryDetailRows();
                    foreach (VEDataSet.InventoryDetailRow d in details)
                    {
                        double remainStock=d.PrevStockVolume; // 借用PrevStockVolume計算先進先出
                        d.PrevStockVolume=0;
                        var ds = from r in prevDetails where r.IngredientID == d.IngredientID select r;
                        if (ds.Count() <= 0)
                        {
                            if (remainStock > 0) RemainStockWarning(d.IngredientID, remainStock);
                            continue;
                        }
                        var p = ds.First();
                        if (!p.IsAreaCodeNull())   
                        {
                            if (d.IsAreaCodeNull() || d.AreaCode.Trim().Count() == 0) // 沒有位置資料才從前期代入
                                d.AreaCode = p.AreaCode;
                        }
                        if (!p.IsStockVolumeNull())
                        {
                            d.PrevStockVolume = p.StockVolume;
                            if (remainStock > 0)  // 庫存量大於進貨量,所以從前一張盤點單算平均成本
                            {
                                if (p.StockVolume > 0) 
                                {
                                    if (remainStock > p.StockVolume)
                                    {
                                        d.StockMoney += p.StockMoney;
                                        var ings = from r in vEDataSet.Ingredient where r.IngredientID == p.IngredientID select r;
                                        if (ings.Count() > 0)
                                        {
                                            VEDataSet.IngredientRow ing = ings.First();
                                            MessageBox.Show("產品<" + ing.Name + "> ,庫存量大於(本期進貨+前期庫存) " + (remainStock-p.StockVolume).ToString() + ing.Unit + ",多餘部分 估值為 0 !!!");
                                        }
                                    }
                                    else d.StockMoney += p.StockMoney / (decimal)p.StockVolume * (decimal)remainStock;
                                }
                                else
                                    RemainStockWarning(p.IngredientID,remainStock);
                            }
                        }
                    }
                }
                decimal totalStockMoney = 0;
                foreach (var d in details)
                {
                    if (!d.IsStockMoneyNull())
                        totalStockMoney += d.StockMoney;
                }
                curr.TotalStockMoney = totalStockMoney;
                // Table資料反映至DataGridView
                inventoryBindingSource.ResetBindings(false);
                inventoryDetailBindingSource.ResetBindings(false);
                curr.EvaluatedDate = DateTime.Now;

            }
            catch (Exception ex)
            {
                MessageBox.Show("計算估值時發生錯誤,原因:" + ex.Message);
            }
        }


        void RemainStockWarning(int ingredientID,double remainStock)
        {
            var ings=from r in vEDataSet.Ingredient where r.IngredientID==ingredientID select r;
            if (ings.Count()>0)
            {
                VEDataSet.IngredientRow ing=ings.First();
                MessageBox.Show("產品<" + ing.Name + "> 前期盤點無庫存,庫存量大於本期進貨 "+remainStock.ToString()+ing.Unit+",多餘部分 估值為 0 !!!");
            }
        }
    }
}
