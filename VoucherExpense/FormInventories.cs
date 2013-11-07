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
    public partial class FormInventories : Form
    {
        public FormInventories()
        {
            InitializeComponent();
        }

        private void inventoryBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.inventoryBindingSource1.EndEdit();
            inventoryDetailBindingSource1.EndEdit();
            inventoryProductsBindingSource1.EndEdit();

            DateTime now = DateTime.Now;
            var detailTable = sQLVEDataSet.InventoryDetail.GetChanges() as SQLVEDataSet.InventoryDetailDataTable;
            if (detailTable != null)   // 把有更改的InventoryDetail填 Inventory.Lastupdated的值
            {
                var IDs = (from r in detailTable 
                           where (r.RowState!=DataRowState.Deleted) && (!r.IsInventoryIDNull())
                           select r.InventoryID).Distinct();
                foreach (int id in IDs)
                {
                    var rows = from r in sQLVEDataSet.Inventory where (r.RowState != DataRowState.Deleted) && (id == r.InventoryID) select r;
                    if (rows.Count() != 0)
                        rows.First().LastUpdated=now;
                }
            }
            var productDetailTable = sQLVEDataSet.InventoryProducts.GetChanges() as SQLVEDataSet.InventoryProductsDataTable;
            if (productDetailTable != null)  // 把有更改的InventoryProducts填 Inventory.Lastupdated的值
            {
                var IDs = (from r in productDetailTable
                           where (r.RowState != DataRowState.Deleted) && (!r.IsInventoryIDNull())
                           select r.InventoryID).Distinct();
                foreach (int id in IDs)
                {
                    var rows = from r in sQLVEDataSet.Inventory where (r.RowState != DataRowState.Deleted) && (id == r.InventoryID) select r;
                    if (rows.Count() != 0)
                        rows.First().LastUpdated = now;
                }
            }

            var table = sQLVEDataSet.Inventory.GetChanges() as SQLVEDataSet.InventoryDataTable;
            if (table == null && detailTable == null)
            {
                MessageBox.Show("沒有更改,不用存檔!");
                return;
            }
            try
            {
                int deleted = 0, updated = 0;
                if (isDelete)
                {
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
 if (detailTable != null) inventoryDetailTableAdapter1.Update(sQLVEDataSet.InventoryDetail);
                    if (productDetailTable != null) inventoryProductsTableAdapter1.Update(sQLVEDataSet.InventoryProducts);
                        inventoryTableAdapter1.Update(table);
                        sQLVEDataSet.Inventory.Merge(table);
                        sQLVEDataSet.Inventory.AcceptChanges();
                    }
                   
                    
                }
                else
                {
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
                   
                    inventoryTableAdapter1.Update(table);
                    sQLVEDataSet.Inventory.Merge(table);
                    sQLVEDataSet.Inventory.AcceptChanges();
                }
                    if (detailTable != null) inventoryDetailTableAdapter1.Update(sQLVEDataSet.InventoryDetail);
                    if (productDetailTable != null) inventoryProductsTableAdapter1.Update(sQLVEDataSet.InventoryProducts);
                    
                }

                isDelete = false;
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
            // TODO: 这行代码将数据加载到表“sQLVEDataSet.InventoryProducts”中。您可以根据需要移动或删除它。
            this.inventoryProductsTableAdapter1.Fill(this.sQLVEDataSet.InventoryProducts);
            // TODO: 这行代码将数据加载到表“sQLVEDataSet.InventoryDetail”中。您可以根据需要移动或删除它。
            this.inventoryDetailTableAdapter1.Fill(this.sQLVEDataSet.InventoryDetail);
            // TODO: 这行代码将数据加载到表“sQLVEDataSet.InventoryProducts”中。您可以根据需要移动或删除它。
            //this.inventoryProductsTableAdapter1.Fill(this.sQLVEDataSet.InventoryProducts);
            //// TODO: 这行代码将数据加载到表“sQLVEDataSet.InventoryDetail”中。您可以根据需要移动或删除它。
            //this.inventoryDetailTableAdapter1.Fill(this.sQLVEDataSet.InventoryDetail);
            //// TODO: 这行代码将数据加载到表“sQLVEDataSet.Inventory”中。您可以根据需要移动或删除它。
            //this.inventoryTableAdapter1.Fill(this.sQLVEDataSet.Inventory);
            productTableAdapter.Connection          = MapPath.BakeryConnection;
            operatorTableAdapter.Connection         = MapPath.VEConnection;
            ingredientTableAdapter.Connection       = MapPath.VEConnection;
            //inventoryTableAdapter.Connection        = MapPath.VEConnection;
            //inventoryDetailTableAdapter.Connection  = MapPath.VEConnection;
            //inventoryProductsTableAdapter.Connection= MapPath.VEConnection;
            try
            {
                productTableAdapter.Fill(bakeryOrderSet.Product);
                operatorTableAdapter.Fill(vEDataSet.Operator);
                ingredientTableAdapter.Fill(vEDataSet.Ingredient);
                //inventoryTableAdapter.Fill      (vEDataSet.Inventory);
                //inventoryDetailTableAdapter.Fill  (vEDataSet.InventoryDetail);
                //inventoryProductsTableAdapter.Fill(vEDataSet.InventoryProducts);

                inventoryTableAdapter1.Fill(sQLVEDataSet.Inventory);
                inventoryDetailTableAdapter1.Fill(sQLVEDataSet.InventoryDetail);
                inventoryProductsTableAdapter1.Fill(sQLVEDataSet.InventoryProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤訊息:" + ex.Message);
            }
            ColumnLocked.ReadOnly = !MyFunction.LockInventory;
            if (MyFunction.LockInventory)
            {
                dgvColumnCurrentIn.Visible = true;
                dgvColumnLostMoney.Visible = true;
                dgvColumnPrevStockVolume.Visible = true;
            }
            else
            {
                dgvColumnCurrentIn.Visible = false;
                dgvColumnLostMoney.Visible = false;
                dgvColumnPrevStockVolume.Visible = false;
            }
//            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
        }
        bool isFrist = false;
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            DateTime maxDate = new DateTime(MyFunction.IntHeaderYear, 1, 1);
            SQLVEDataSet.InventoryRow rowIsnull=null;
            foreach (var r in sQLVEDataSet.Inventory)
            {
                rowIsnull = r;
                if (r.RowState == DataRowState.Deleted) continue;
                if (!r.IsCheckDayNull())
                {
                    if (r.CheckDay >= maxDate) maxDate = r.CheckDay.AddDays(1); // 設定盤點日為最大那張的加一天
                }
                if (r.Locked ) continue;
                MessageBox.Show("有尚未核可的單子,無法新增盤點表!");
                return;
            }
            if (rowIsnull == null)
            {
                MessageBox.Show("初值，请输入食材的盘点、金额和产品的本期");
                prevVolumeColumn.Visible = false;
                dgvColumnCurrentIn.Visible = false;
                dgvColumnPrevStockVolume.Visible = false;
                StockMoneyColumn.ReadOnly = false;
                dgvColumnLostMoney.Visible = false;
                isFrist = true;
            }
            else
            {
                prevVolumeColumn.Visible = true;
                dgvColumnCurrentIn.Visible = true;
                dgvColumnPrevStockVolume.Visible = true;
                StockMoneyColumn.ReadOnly = true;
                dgvColumnLostMoney.Visible = true;
                isFrist = false;
            }
            if (maxDate.Year != MyFunction.IntHeaderYear)
            {
                MessageBox.Show("預計的盤點日超過資料年<"+MyFunction.HeaderYear+">");
                return;
            }
            this.inventoryBindingSource1.AddNew();
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
                    MyFunction.AddNewItem(dgvInventories, "ColumnInventoryID", "InventoryID", sQLVEDataSet.Inventory);
                    bindingNavigatorAddNewItem.Enabled = false;
                    DataRowView rowView = row.DataBoundItem as DataRowView;
                    SQLVEDataSet.InventoryRow data = rowView.Row as SQLVEDataSet.InventoryRow;
                    data.CheckDay = maxDate;       // 盤點日
                    int inventoryID = data.InventoryID;
                    // 從食材表中有Code的,加入vEDataSet.InventoryDetail
                    foreach (VEDataSet.IngredientRow ingredient in vEDataSet.Ingredient)
                    {
                        if (ingredient.IsCodeNull()) continue;
                        if (ingredient.Code <= 0) continue;    // 無代号食材不納入盤點
                        SQLVEDataSet.InventoryDetailRow detail = sQLVEDataSet.InventoryDetail.NewInventoryDetailRow();
                        detail.ID = Guid.NewGuid();
                        detail.IngredientID = ingredient.IngredientID;
                        detail.InventoryID  = inventoryID;
                        sQLVEDataSet.InventoryDetail.AddInventoryDetailRow(detail);
                    }
                    // 產品表中有Code的,加入vEDataSet.InventoryProducts
                    foreach (BakeryOrderSet.ProductRow product in bakeryOrderSet.Product)
                    {
                        if (product.IsClassNull()) continue;
                        if (product.Code <= 0) continue;
                        SQLVEDataSet.InventoryProductsRow inventoryProducts = sQLVEDataSet.InventoryProducts.NewInventoryProductsRow();
                        inventoryProducts.ID = Guid.NewGuid();
                        inventoryProducts.ProductID = product.ProductID;
                        inventoryProducts.InventoryID = inventoryID;
                        sQLVEDataSet.InventoryProducts.AddInventoryProductsRow(inventoryProducts);
                    }

                    inventoryBindingSource1.ResetBindings(false);  // inventoryDetailBindingSource 會連動,不用自己呼叫
                    chBoxHide.Checked = false;                    // 初創立,要看到所有有產品碼的
                }
                catch (Exception ex)
                {
                    MessageBox.Show("新增時錯誤,原因<" + ex.Message + ">");
                    return;
                }
            }
        }
        bool isDelete = false;
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            isDelete = true;
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
            SQLVEDataSet.InventoryRow inventory = rowView.Row as SQLVEDataSet.InventoryRow;
            int id = inventory.InventoryID;
            // 刪除本盤點單 食材
            var rows = from r in sQLVEDataSet.InventoryDetail where r.InventoryID == id select r;
            List<SQLVEDataSet.InventoryDetailRow> list = rows.ToList<SQLVEDataSet.InventoryDetailRow>();    // 直接用linq的Collection會說枚舉己經改變
            foreach (SQLVEDataSet.InventoryDetailRow r in list)     // 用RemoveInventoryDetailRow() 會只是Remove, 不是留下要Delete的tag
                r.Delete();
            // 刪除本盤點單 產品
            var rows1 = from r in sQLVEDataSet.InventoryProducts where r.InventoryID == id select r;
            List<SQLVEDataSet.InventoryProductsRow> list1 = rows1.ToList<SQLVEDataSet.InventoryProductsRow>();    // 直接用linq的Collection會說枚舉己經改變
            foreach (SQLVEDataSet.InventoryProductsRow r in list1)     // 用RemoveInventoryDetailRow() 會只是Remove, 不是留下要Delete的tag
                r.Delete();
            inventoryBindingSource1.RemoveCurrent();              // 要放在後面,因為還要取出 Current的IventoryID
            bindingNavigatorDeleteItem.Enabled = false;
            bindingNavigatorAddNewItem.Enabled = false;          // 刪完不准新增,以免有己刪除的被操作
        }

        void SetDetailLocked(bool locked)
        {
            checkDayDateTimePicker.Enabled = !locked;
            btnEvaluate.Enabled = !locked;
            ColumnStockChecked.ReadOnly = locked;
            ColumnPosition.ReadOnly = locked;

            ColumnProductVolume.ReadOnly = locked;
        }

        private void dgvInventories_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == 0)
                {
                    prevVolumeColumn.Visible = false;
                    dgvColumnCurrentIn.Visible = false;
                    dgvColumnPrevStockVolume.Visible = false;
                    StockMoneyColumn.ReadOnly = false;
                    dgvColumnLostMoney.Visible = false;   
                }
                else
                {
                    prevVolumeColumn.Visible = true;
                    dgvColumnCurrentIn.Visible = true;
                    dgvColumnPrevStockVolume.Visible = true;
                    StockMoneyColumn.ReadOnly = true;
                    dgvColumnLostMoney.Visible = true;
                }
                DataGridView view=sender as DataGridView;
                DataGridViewRow dgvRow=view.Rows[e.RowIndex];
                DataRowView rowView= dgvRow.DataBoundItem as DataRowView;
                SQLVEDataSet.InventoryRow dataRow = rowView.Row as SQLVEDataSet.InventoryRow;
                if (dataRow.IsLockedNull())
                {
                    dataRow.Locked = false;//为空值是设为false
                    SetDetailLocked(false);
                }
                else { SetDetailLocked(dataRow.Locked); }

                checkDayDateTimePicker.ValueChanged -= this.checkDayDateTimePicker_ValueChanged;
                if (!dataRow.IsCheckDayNull())
                    checkDayDateTimePicker.Value = dataRow.CheckDay;
                checkDayDateTimePicker.ValueChanged += this.checkDayDateTimePicker_ValueChanged;
            }
            catch(Exception ex)
            {
                MessageBox.Show("dgvInventories Row_Enter產生錯誤, 原因:" + ex.Message);
            }
            chBoxHide_CheckedChanged(null, null);
            inventoryDetailBindingSource1.ResetBindings(false);
        }

        private void chBoxHide_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxHide.Checked)
            {
                //inventoryDetailBindingSource1.Filter = "StockVolume>0 OR PrevStockVolume>0 OR CurrentIn>0";
                //inventoryProductsBindingSource1.Filter = "PrevVolume>0 OR Volume>0";
                fKInventoryDetailInventoryBindingSource.Filter = "StockVolume>0 OR PrevStockVolume>0 OR CurrentIn>0";
                fKInventoryProductsInventoryBindingSource.Filter = "PrevVolume>0 OR Volume>0";
            }
            else
            {
                //inventoryDetailBindingSource1.RemoveFilter();
                //inventoryProductsBindingSource1.RemoveFilter();
                fKInventoryDetailInventoryBindingSource.RemoveFilter();
                fKInventoryProductsInventoryBindingSource.RemoveFilter();
            }
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

 
        private void dgvInventoryDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            labelIngredientsCount.Text = dgvInventoryDetail.Rows.Count.ToString();
        }

        private void dgvProducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            labelProductsCount.Text = dgvProducts.Rows.Count.ToString();
        }

        // 檢查Locked 狀況
        bool ValidateLocked(bool locked,SQLVEDataSet.InventoryRow current)
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
                maxID = (from r in sQLVEDataSet.Inventory select r.InventoryID).Max();
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

        private void dgvInventories_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
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
                bool locked=(bool)e.FormattedValue;
                if (!ValidateLocked(locked, rowView.Row as SQLVEDataSet.InventoryRow))
                {
                    e.Cancel = true;
                    cell.Value = !locked;
                }
            }
            catch { }
        }

        class CalcInventory
        {
            public double StockVolume=0;
            public decimal CurrInMoney=0;
        }
        VEDataSetTableAdapters.VoucherDetailTableAdapter m_VoucherDetailAdapter = null;
        VEDataSetTableAdapters.VoucherTableAdapter m_VoucherAdapter = null;
        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            // 先把螢幕內容存回
            inventoryBindingSource1.EndEdit();
            inventoryDetailBindingSource1.EndEdit();

            inventoryProductsBindingSource1.EndEdit();
            try
            {

                DataRowView rowView = inventoryBindingSource1.Current as DataRowView;
                if (rowView == null)
                {
                    MessageBox.Show("沒有記錄,請先新增一筆!");
                    return;
                }
                SQLVEDataSet.InventoryRow curr = rowView.Row as SQLVEDataSet.InventoryRow;
                var details = curr.GetInventoryDetailRows();
                var productDetails=curr.GetInventoryProductsRows();
                // 清除本單的進貨及金額
                if (!isFrist)
                foreach (var dRow in details)
                {
                    dRow.StockMoney = 0;
                    dRow.LostMoney = 0;
                    dRow.CurrentIn = 0;
                }
                SQLVEDataSet.InventoryRow prev = null;
                foreach (SQLVEDataSet.InventoryRow r in sQLVEDataSet.Inventory)   // 找到前一張單子
                {
                    if (r.InventoryID >= curr.InventoryID) continue;
                    if (prev == null) prev = r;
                    else if (prev.InventoryID < r.InventoryID)
                            prev = r;
                }
                if (prev == null) // 這是本年第一張
                {
                    //var detailTable = sQLVEDataSet.InventoryDetail.GetChanges() as SQLVEDataSet.InventoryDetailDataTable;
                    //if (detailTable != null) inventoryDetailTableAdapter1.Update(sQLVEDataSet.InventoryDetail);
                    //details = curr.GetInventoryDetailRows();
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

                //inventoryBindingSource.SuspendBinding();
                //inventoryDetailBindingSource.SuspendBinding();     // DataGridView是複雜Binding ,使用無效

                // 算先進先出成本,暫存未計算成本的庫存量
                Dictionary<int, CalcInventory> dicCalcStock = new Dictionary<int, CalcInventory>();

                // 填CalcInventory 內容
                if (prev != null)
                foreach (SQLVEDataSet.InventoryDetailRow d in details)
                {
                    CalcInventory inv = new CalcInventory();
                    int id=d.IngredientID;
                    if (d.IsStockVolumeNull())
                        inv.StockVolume = 0;
                    else
                        inv.StockVolume=d.StockVolume;
                    if (!d.IsAreaCodeNull())
                    {
                        if (d.AreaCode == "???") d.AreaCode = "";     // 清除??? ,後面再設上去
                    }
                    if (dicCalcStock.Keys.Contains(id))   // 表不正常, 重覆了
                         d.Delete();    // 刪除重的這筆
                    else dicCalcStock.Add(id,inv);
                }
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
                        CalcInventory inv = dicCalcStock[de1.IngredientID];
                        decimal dCost = 0;
                        if (!d.IsCostNull()) dCost = d.Cost;
                        inv.CurrInMoney += dCost;
                        // 算出相對應庫存的成本
                        if (inv.StockVolume >= vol)
                        {
                            de1.StockMoney += dCost;
                            inv.StockVolume-= vol;
                        }
                        else if (inv.StockVolume>0)
                        {
                            de1.StockMoney += (dCost / (decimal)vol * (decimal)inv.StockVolume);   // 小於
                            inv.StockVolume = 0;
                        }
                    }
                }
                // 將前期盤點及位置 資料填入, 並計算多於進貨remainStock的成本
                if (prev == null)
                {
                    //foreach (SQLVEDataSet.InventoryDetailRow d in details) 
                    //{
                    //    d.PrevStockVolume = 0;
                    //    CalcInventory inv = dicCalcStock[d.IngredientID];
                    //    if (inv.StockVolume > 0)
                    //        RemainStockWarning(d, inv.StockVolume);
                    //    d.LostMoney = inv.CurrInMoney - d.StockMoney;     // 沒有前期
                    //}
                    //foreach (var p in productDetails)
                    //    p.PrevVolume = 0;
                }
                else
                {
                    // 找出食材前期值代入
                    var prevDetails = prev.GetInventoryDetailRows();
                    foreach (SQLVEDataSet.InventoryDetailRow d in details)
                    {
                        d.PrevStockVolume = 0;
                        int dIngredientID = d.IngredientID;
                        CalcInventory inv = dicCalcStock[dIngredientID];
                        double remainStock = inv.StockVolume;
                        var ds = from r in prevDetails where r.IngredientID == dIngredientID select r;
                        if (ds.Count() <= 0)
                        {
                            if (remainStock > 0)
                                RemainStockWarning(d, remainStock);
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
                                        var ings = from r in vEDataSet.Ingredient where r.IngredientID == dIngredientID select r;
                                        if (ings.Count() > 0)
                                        {
                                            VEDataSet.IngredientRow ing = ings.First();
                                            MessageBox.Show("產品<" + ing.Name + "> ,庫存量大於(本期進貨+前期庫存) " + (remainStock - p.StockVolume).ToString() + ing.Unit + ",多餘部分 估值為 0 !!!");
                                            d.AreaCode = "???";
                                        }
                                    }
                                    else d.StockMoney += p.StockMoney / (decimal)p.StockVolume * (decimal)remainStock;
                                }
                                else
                                    RemainStockWarning(d, remainStock);
                            }
                        }
                        else
                        {
                            if (remainStock > 0)
                                RemainStockWarning(d, remainStock);
                        }
                        // 計算損失金額, 必需在RemainStock計算完之後d.StockMoney才有值
                        if (!p.IsStockMoneyNull())
                            d.LostMoney = inv.CurrInMoney + p.StockMoney - d.StockMoney;
                        else
                            d.LostMoney = inv.CurrInMoney - d.StockMoney;

                    }
                    // 找出前期產品庫存值代入 
                    var prevProducts = prev.GetInventoryProductsRows();
                    foreach (SQLVEDataSet.InventoryProductsRow pd in productDetails)
                    {
                        var ds = from r in prevProducts where r.ProductID == pd.ProductID select r;
                        if (ds.Count() > 0)
                        {
                            var d = ds.First();
                            if (!d.IsVolumeNull())
                                pd.PrevVolume = d.Volume;
                        }
                        else
                            pd.PrevVolume = 0;
                    }
                }
                // 找出產品表.EvaluatedCost 計算產品Cost
                decimal productCost = 0;
                foreach (SQLVEDataSet.InventoryProductsRow pd in productDetails)
                {
                    pd.Cost = 0m;
                    if ((!pd.IsVolumeNull()) && pd.Volume > 0)
                    {
                        var ps = from r in bakeryOrderSet.Product where r.ProductID == pd.ProductID select r;
                        if (ps.Count() > 0)
                        {
                            var p = ps.First();
                            if (!p.IsEvaluatedCostNull())
                            {
                                pd.Cost = p.EvaluatedCost * (decimal)pd.Volume;
                                productCost += pd.Cost;
                            }
                        }
                    }
                }
                // 計算總食材庫材及損失

                    decimal ingredientsCost = 0, ingredientsLost = 0;
                    foreach (var d in details)
                    {
                        if (!d.IsStockMoneyNull())
                            ingredientsCost += d.StockMoney;
                        if (!d.IsLostMoneyNull())
                            ingredientsLost += d.LostMoney;
                    }

                curr.IngredientsCost  = Math.Round(ingredientsCost,1);
                curr.IngredientsLost  = Math.Round(ingredientsLost,1);
                curr.ProductsCost     = Math.Round(productCost    ,1);
                curr.EvaluatedDate    = DateTime.Now;

                inventoryBindingSource1.ResetBindings(false);
                inventoryDetailBindingSource1.ResetBindings(false);
                inventoryProductsBindingSource1.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("計算估值時發生錯誤,原因:" + ex.Message);
            }
        }


        void RemainStockWarning(SQLVEDataSet.InventoryDetailRow detail,double remainStock)
        {
            int ingredientID = detail.IngredientID;
            detail.AreaCode = "???";
            var ings=from r in vEDataSet.Ingredient where r.IngredientID==ingredientID select r;
            if (ings.Count()>0)
            {
                VEDataSet.IngredientRow ing=ings.First();
                MessageBox.Show("產品<" + ing.Name + "> 前期盤點無庫存,庫存量大於本期進貨 "+remainStock.ToString()+ing.Unit+",多餘部分 估值為 0 !!!");
            }
        }

        private void dgvInventoryDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var view = sender as DataGridView;
            int iCol = e.ColumnIndex;
            DataGridViewColumn column = view.Columns[iCol];
            if (column == null) return;
            if (column.Name == "ColumnStockChecked")   // 一改庫存,EvaluatedDate就DBNull
            {
                DataRowView rowView = inventoryBindingSource1.Current as DataRowView;
                SQLVEDataSet.InventoryRow curr = rowView.Row as SQLVEDataSet.InventoryRow;
                if (!curr.IsEvaluatedDateNull()) curr.SetEvaluatedDateNull();
            }
        }

        private void dgvProducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var view = sender as DataGridView;
            int iCol = e.ColumnIndex;
            DataGridViewColumn column = view.Columns[iCol];
            if (column == null) return;
            if (column.Name == "ColumnProductVolume")   // 一改庫存,EvaluatedDate就DBNull
            {
                DataRowView rowView = inventoryBindingSource1.Current as DataRowView;
                SQLVEDataSet.InventoryRow curr = rowView.Row as SQLVEDataSet.InventoryRow;
                if (!curr.IsEvaluatedDateNull()) curr.SetEvaluatedDateNull();
            }
        }


        // 剛Binding時賦值,EnterRow,都會呼叫, 所以...只好取消Binding, 自己綁
        private void checkDayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker picker = sender as DateTimePicker;
            DataRowView rowView = inventoryBindingSource1.Current as DataRowView;
            if (rowView == null) return;    // 還沒有任何記錄
            SQLVEDataSet.InventoryRow curr = rowView.Row as SQLVEDataSet.InventoryRow;
            DateTime date = picker.Value.Date;
            if (date.Year != MyFunction.IntHeaderYear)
            {
                MessageBox.Show("只能選" + MyFunction.HeaderYear + "年");
                picker.Value = curr.CheckDay;     // 從DataGridView 抓值回來
                return;
            }
            var dataRow = rowView.Row as SQLVEDataSet.InventoryRow;
            foreach (var row in sQLVEDataSet.Inventory)
            {
                if (row.InventoryID == dataRow.InventoryID) continue; // 自己跳過
                if (row.IsCheckDayNull()) continue;
                if (row.CheckDay.Date >= date)
                {
                    MessageBox.Show("己有盤點單日期為<" + row.CheckDay.Date.ToShortDateString() + "> 不可小於等於該日期!");
                    picker.Value = curr.CheckDay;
                    return;
                }
            }
            // 主動去更改DataGridView ,要不然要手動去那格使用者體驗不佳,有時又因為主表倒覆蓋回來,改不動
            curr.CheckDay = picker.Value; ;
            curr.SetEvaluatedDateNull();         // 若有Binding ,此行一設 DateTimePicker值又會被重設,所以要放 curr.CheckDay=picker.Value後面
            inventoryBindingSource.ResetBindings(false);
        }

        private void dgvProducts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void FormInventories_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvProducts.Visible = false;
            dgvInventoryDetail.Visible = false;
            dgvInventories.Visible = false;
        }

        private void dgvInventories_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("错误：行"+e.RowIndex+"列"+e.ColumnIndex);
        }



     }
}
