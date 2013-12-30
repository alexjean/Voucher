using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
#if UseSQLServer
using MyDataSet                 = VoucherExpense.DamaiDataSet;
using MyOrderSet                = VoucherExpense.DamaiDataSet;
using MyInventoryAdapter        = VoucherExpense.DamaiDataSetTableAdapters.InventoryTableAdapter;
using MyInventoryProductsAdapter= VoucherExpense.DamaiDataSetTableAdapters.InventoryProductsTableAdapter;
using MyInventoryDetailAdapter  = VoucherExpense.DamaiDataSetTableAdapters.InventoryDetailTableAdapter;
using MyInventoryRow            = VoucherExpense.DamaiDataSet.InventoryRow;
using MyInventoryDetailRow      = VoucherExpense.DamaiDataSet.InventoryDetailRow;
using MyInventoryProductsRow    = VoucherExpense.DamaiDataSet.InventoryProductsRow;
using MyInventoryTable          = VoucherExpense.DamaiDataSet.InventoryDataTable;
using MyInventoryDetailTable    = VoucherExpense.DamaiDataSet.InventoryDetailDataTable;
using MyInventoryProductsTable  = VoucherExpense.DamaiDataSet.InventoryProductsDataTable;
using MyVoucherAdapter          = VoucherExpense.DamaiDataSetTableAdapters.VoucherTableAdapter;
using MyVoucherDetailAdapter    = VoucherExpense.DamaiDataSetTableAdapters.VoucherDetailTableAdapter;
#else
using MyDataSet                 = VoucherExpense.VEDataSet;
using MyOrderSet                = VoucherExpense.BakeryOrderSet;
using MyInventoryAdapter        = VoucherExpense.VEDataSetTableAdapters.InventoryTableAdapter;
using MyInventoryProductsAdapter= VoucherExpense.VEDataSetTableAdapters.InventoryProductsTableAdapter;
using MyInventoryDetailAdapter  = VoucherExpense.VEDataSetTableAdapters.InventoryDetailTableAdapter;
using MyInventoryRow            = VoucherExpense.VEDataSet.InventoryRow;
using MyInventoryDetailRow      = VoucherExpense.VEDataSet.InventoryDetailRow;
using MyInventoryProductsRow    = VoucherExpense.VEDataSet.InventoryProductsRow;
using MyInventoryTable          = VoucherExpense.VEDataSet.InventoryDataTable;
using MyInventoryDetailTable    = VoucherExpense.VEDataSet.InventoryDetailDataTable;
using MyInventoryProductsTable  = VoucherExpense.VEDataSet.InventoryProductsDataTable;
using MyVoucherAdapter          = VoucherExpense.VEDataSetTableAdapters.VoucherTableAdapter;
using MyVoucherDetailAdapter    = VoucherExpense.VEDataSetTableAdapters.VoucherDetailTableAdapter;
#endif

namespace VoucherExpense
{
    public partial class FormInventories : Form
    {
        public FormInventories()
        {
            InitializeComponent();
        }

        void SetupBindingSource()
        {
            ingredientBindingSource.DataSource  = m_DataSet;
            operatorBindingSource.DataSource    = m_DataSet;
            inventoryBindingSource.DataSource   = m_DataSet;
#if (UseSQLServer)
            m_OrderSet = m_DataSet;
            fKInventoryDetailInventoryBindingSource.DataSource = inventoryBindingSource;
            fKInventoryProductsInventoryBindingSource.DataSource = inventoryBindingSource;
            fKInventoryDetailInventoryBindingSource.Sort         = "IngredientID desc";
#else
            m_OrderSet=new MyOrderSet();
            inventoryDetailBindingSource.DataSource              = inventoryBindingSource;
            inventoryProductsBindingSource.DataSource            = inventoryBindingSource;
            inventoryDetailBindingSource.Sort                    = "IngredientID desc";
#endif
            productBindingSource.DataSource = m_OrderSet;
        }

        MyDataSet m_DataSet = new MyDataSet();
        MyOrderSet m_OrderSet;
        MyInventoryAdapter InventoryAdapter                 = new MyInventoryAdapter();
        MyInventoryProductsAdapter InventoryProductsAdapter = new MyInventoryProductsAdapter();
        MyInventoryDetailAdapter InventoryDetailAdapter     = new MyInventoryDetailAdapter();
        private void FormIngredientInventories_Load(object sender, EventArgs e)
        {
            SetupBindingSource();
#if UseSQLServer
            dgvInventories.DataSource = inventoryBindingSource;
            dgvInventoryDetail.DataSource = fKInventoryDetailInventoryBindingSource;
            dgvProducts.DataSource        = fKInventoryProductsInventoryBindingSource;
            var productAdapter      = new VoucherExpense.DamaiDataSetTableAdapters.ProductTableAdapter();
            var operatorAdapter     = new VoucherExpense.DamaiDataSetTableAdapters.OperatorTableAdapter();
            var ingredientAdapter   = new VoucherExpense.DamaiDataSetTableAdapters.IngredientTableAdapter();
#else
            dgvInventories.DataSource = inventoryBindingSource;
            dgvInventoryDetail.DataSource = inventoryDetailBindingSource;
            dgvProducts.DataSource        = inventoryProductsBindingSource;

            var productAdapter      = new VoucherExpense.BakeryOrderSetTableAdapters.ProductTableAdapter();
            var operatorAdapter     = new VoucherExpense.VEDataSetTableAdapters.OperatorTableAdapter();
            var ingredientAdapter   = new VoucherExpense.VEDataSetTableAdapters.IngredientTableAdapter();
            productAdapter.Connection           = MapPath.BakeryConnection;
            operatorAdapter.Connection          = MapPath.VEConnection;
            ingredientAdapter.Connection        = MapPath.VEConnection;
            InventoryAdapter.Connection         = MapPath.VEConnection;
            InventoryDetailAdapter.Connection   = MapPath.VEConnection;
            InventoryProductsAdapter.Connection = MapPath.VEConnection;
#endif
            try
            {
                productAdapter.Fill     (m_OrderSet.Product);
                operatorAdapter.Fill    (m_DataSet.Operator);
                ingredientAdapter.Fill  (m_DataSet.Ingredient);

                InventoryAdapter.Fill        (m_DataSet.Inventory);
                InventoryDetailAdapter.Fill  (m_DataSet.InventoryDetail);
                InventoryProductsAdapter.Fill(m_DataSet.InventoryProducts);
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
            MyInventoryRow rowIsnull = null;
            foreach (var r in m_DataSet.Inventory)
            {
                rowIsnull = r;
                if (r.RowState == DataRowState.Deleted) continue;
                if (!r.IsCheckDayNull())
                {
                    if (r.CheckDay >= maxDate) maxDate = r.CheckDay.AddDays(1); // 設定盤點日為最大那張的加一天
                }
                if (r.Locked) continue;
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
                MessageBox.Show("預計的盤點日超過資料年<" + MyFunction.HeaderYear + ">");
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
                    MyFunction.AddNewItem(dgvInventories, "ColumnInventoryID", "InventoryID", m_DataSet.Inventory);
                    bindingNavigatorAddNewItem.Enabled = false;
                    DataRowView rowView = row.DataBoundItem as DataRowView;
                    var data = rowView.Row as MyInventoryRow;
                    data.CheckDay = maxDate;       // 盤點日
                    int inventoryID = data.InventoryID;
                    // 從食材表中有Code的,加入vEDataSet.InventoryDetail
                    foreach (var ingredient in m_DataSet.Ingredient)
                    {
                        if (ingredient.IsCodeNull()) continue;
                        if (ingredient.Code <= 0) continue;    // 無代号食材不納入盤點
                        var detail = m_DataSet.InventoryDetail.NewInventoryDetailRow();
                        detail.ID = Guid.NewGuid();
                        detail.IngredientID = ingredient.IngredientID;
                        detail.InventoryID = inventoryID;
                        m_DataSet.InventoryDetail.AddInventoryDetailRow(detail);
                    }
                    // 產品表中有Code的,加入vEDataSet.InventoryProducts
                    foreach (var product in m_OrderSet.Product)
                    {
                        if (product.IsClassNull()) continue;
                        if (product.Code <= 0) continue;
                        var inventoryProducts = m_DataSet.InventoryProducts.NewInventoryProductsRow();
                        inventoryProducts.ID = Guid.NewGuid();
                        inventoryProducts.ProductID = product.ProductID;
                        inventoryProducts.InventoryID = inventoryID;
                        m_DataSet.InventoryProducts.AddInventoryProductsRow(inventoryProducts);
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

        void DetailBindingSource(bool SaveToDataTable)
        {
#if (UseSQLServer)
            if (SaveToDataTable)
            {
                fKInventoryDetailInventoryBindingSource.EndEdit();
                fKInventoryProductsInventoryBindingSource.EndEdit();
            }
            else
            {
                fKInventoryDetailInventoryBindingSource.ResetBindings(false);
                fKInventoryProductsInventoryBindingSource.ResetBindings(false);
            }
#else
            if (SaveToDataTable)
            {
                inventoryDetailBindingSource.EndEdit();
                inventoryProductsBindingSource.EndEdit();
            }
            else
            {
                inventoryDetailBindingSource.ResetBindings(false);
                inventoryProductsBindingSource.ResetBindings(false);
            }
#endif
        }

        private void inventoryBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.inventoryBindingSource.EndEdit();
            DetailBindingSource(SaveToDataTable : true);
            DateTime now = DateTime.Now;
            var detailTable = m_DataSet.InventoryDetail.GetChanges() as MyInventoryDetailTable;
            if (detailTable != null)   // 把有更改的InventoryDetail填 Inventory.Lastupdated的值
            {
                var IDs = (from r in detailTable 
                           where (r.RowState!=DataRowState.Deleted) && (!r.IsInventoryIDNull())
                           select r.InventoryID).Distinct();
                foreach (int id in IDs)
                {
                    var rows = from r in m_DataSet.Inventory where (r.RowState != DataRowState.Deleted) && (id == r.InventoryID) select r;
                    if (rows.Count() != 0)
                        rows.First().LastUpdated=now;
                }
            }
            var productDetailTable = m_DataSet.InventoryProducts.GetChanges() as MyInventoryProductsTable;
            if (productDetailTable != null)  // 把有更改的InventoryProducts填 Inventory.Lastupdated的值
            {
                var IDs = (from r in productDetailTable
                           where (r.RowState != DataRowState.Deleted) && (!r.IsInventoryIDNull())
                           select r.InventoryID).Distinct();
                foreach (int id in IDs)
                {
                    var rows = from r in m_DataSet.Inventory where (r.RowState != DataRowState.Deleted) && (id == r.InventoryID) select r;
                    if (rows.Count() != 0)
                        rows.First().LastUpdated = now;
                }
            }

            var table = m_DataSet.Inventory.GetChanges() as MyInventoryTable;
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
                        if (detailTable != null)        InventoryDetailAdapter.Update(m_DataSet.InventoryDetail);
                        if (productDetailTable != null) InventoryProductsAdapter.Update(m_DataSet.InventoryProducts);
                        InventoryAdapter.Update(table);
                        m_DataSet.Inventory.Merge(table);
                        m_DataSet.Inventory.AcceptChanges();
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
                   
                        InventoryAdapter.Update(table);
                        m_DataSet.Inventory.Merge(table);
                        m_DataSet.Inventory.AcceptChanges();
                    }
                    if (detailTable         != null) InventoryDetailAdapter.Update(m_DataSet.InventoryDetail);
                    if (productDetailTable  != null) InventoryProductsAdapter.Update(m_DataSet.InventoryProducts);
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
            var inventory = rowView.Row as MyInventoryRow;
            int id = inventory.InventoryID;
            // 刪除本盤點單 食材
            var rows = from r in m_DataSet.InventoryDetail where r.InventoryID == id select r;
            var list = rows.ToList<MyInventoryDetailRow>();    // 直接用linq的Collection會說枚舉己經改變
            foreach (var r in list)     // 用RemoveInventoryDetailRow() 會只是Remove, 不是留下要Delete的tag
                r.Delete();
            // 刪除本盤點單 產品
            var rows1 = from r in m_DataSet.InventoryProducts where r.InventoryID == id select r;
            var list1 = rows1.ToList<MyInventoryProductsRow>();    // 直接用linq的Collection會說枚舉己經改變
            foreach (var r in list1)     // 用RemoveInventoryDetailRow() 會只是Remove, 不是留下要Delete的tag
                r.Delete();
            inventoryBindingSource.RemoveCurrent();              // 要放在後面,因為還要取出 Current的IventoryID
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
            //inventoryBindingSource.EndEdit();
            //inventoryDetailBindingSource.EndEdit();
            //inventoryProductsBindingSource.EndEdit();
            try
            {
                if (e.RowIndex == 0)
                {
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
                DataGridView view=sender as DataGridView;
                DataGridViewRow dgvRow=view.Rows[e.RowIndex];
                DataRowView rowView= dgvRow.DataBoundItem as DataRowView;
                var dataRow = rowView.Row as MyInventoryRow;
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
            inventoryDetailBindingSource.ResetBindings(false);
            inventoryProductsBindingSource.ResetBindings(false);
//            fKInventoryDetailInventoryBindingSource.EndEdit();
           
        }

        private void chBoxHide_CheckedChanged(object sender, EventArgs e)
        {
#if UseSQLServer
            if (chBoxHide.Checked)
            {
                fKInventoryDetailInventoryBindingSource.Filter = "StockVolume>0 OR PrevStockVolume>0 OR CurrentIn>0";
                fKInventoryProductsInventoryBindingSource.Filter = "PrevVolume>0 OR Volume>0";
            }
            else
            {
                fKInventoryDetailInventoryBindingSource.RemoveFilter();
                fKInventoryProductsInventoryBindingSource.RemoveFilter();
            }
#else
            if (chBoxHide.Checked)
            {
                inventoryDetailBindingSource.Filter = "StockVolume>0 OR PrevStockVolume>0 OR CurrentIn>0";
                inventoryProductsBindingSource.Filter = "PrevVolume>0 OR Volume>0";
            }
            else
            {
                inventoryDetailBindingSource.RemoveFilter();
                inventoryProductsBindingSource.RemoveFilter();
            }
#endif
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
        bool ValidateLocked(bool locked,MyInventoryRow current)
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
                maxID = (from r in m_DataSet.Inventory select r.InventoryID).Max();
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
                if (!ValidateLocked(locked, rowView.Row as MyInventoryRow))
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
        MyVoucherDetailAdapter  m_VoucherDetailAdapter = null;
        MyVoucherAdapter        m_VoucherAdapter = null;
        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            // 先把螢幕內容存回
            inventoryBindingSource.EndEdit();
            DetailBindingSource(SaveToDataTable: true);
            try
            {

                DataRowView rowView = inventoryBindingSource.Current as DataRowView;
                if (rowView == null)
                {
                    MessageBox.Show("沒有記錄,請先新增一筆!");
                    return;
                }
                var curr = rowView.Row as MyInventoryRow;
                
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
                MyInventoryRow prev = null;
                foreach (var r in m_DataSet.Inventory)   // 找到前一張單子
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
                    m_VoucherAdapter = new MyVoucherAdapter();
#if (!UseSQLServer)                    
                    m_VoucherAdapter.Connection = MapPath.VEConnection;
#endif
                    m_VoucherAdapter.Fill(m_DataSet.Voucher); 
                }
                if (m_VoucherDetailAdapter == null)
                {
                    m_VoucherDetailAdapter = new MyVoucherDetailAdapter();
#if (!UseSQLServer)
                    m_VoucherDetailAdapter.Connection = MapPath.VEConnection;
#endif
                    m_VoucherDetailAdapter.Fill(m_DataSet.VoucherDetail);
                }

                //inventoryBindingSource.SuspendBinding();
                //inventoryDetailBindingSource.SuspendBinding();     // DataGridView是複雜Binding ,使用無效

                // 算先進先出成本,暫存未計算成本的庫存量
                Dictionary<int, CalcInventory> dicCalcStock = new Dictionary<int, CalcInventory>();

                // 填CalcInventory 內容
                if (prev != null)
                foreach (var d in details)
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
                var vouchers = from vo in m_DataSet.Voucher
                               where(!vo.IsStockTimeNull()) && (vo.StockTime.Date > prevDate) && (vo.StockTime.Date <= curr.CheckDay.Date) && (vo.IsRemovedNull() || (!vo.Removed))
                               orderby vo.StockTime descending
                               select vo;
                // 計算本期進貨
                if (isFrist)
                {

                }
                else
                {
                    foreach (var vo in vouchers)
                    {
                        var ds = vo.GetVoucherDetailRows();
                        foreach (var d in ds)
                        {
                            if (d.IsIngredientIDNull()) continue;
                            if (d.IsVolumeNull()) continue;   // 沒有數量
                            if (d.Volume <= 0) continue;
                            int id = d.IngredientID;
                            var des = from de in details where de.IngredientID == id select de;
                            if (des.Count() <= 0) continue;   // 盤點單找不到此食材
                            var de1 = des.First();
                            double vol = (double)d.Volume;
                            de1.CurrentIn += vol;
                            CalcInventory inv = dicCalcStock[de1.IngredientID];
                            decimal dCost = 0;
                            if (!d.IsCostNull()) dCost = d.Cost;
                            inv.CurrInMoney += dCost;
                            // 算出相對應庫存的成本
                            if (inv.StockVolume >= vol)
                            {
                                de1.StockMoney += dCost;
                                inv.StockVolume -= vol;
                            }
                            else if (inv.StockVolume > 0)
                            {
                                de1.StockMoney += (dCost / (decimal)vol * (decimal)inv.StockVolume);   // 小於
                                inv.StockVolume = 0;
                            }
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

                    try
                    {
                        DataRowView inventoryrow = inventoryBindingSource.Current as DataRowView;
                        if (rowView == null) return; 
                        var inventory = rowView.Row as MyInventoryRow;
                        inventory.IngredientsCost = 0;
                        var detailrows = inventory.GetInventoryDetailRows();
                        foreach (var item in detailrows)
                        {
                            if (item.IsStockMoneyNull())//计算初值时，如果输入初值金额，就不估算，没有就估算
                            {
                                var ingredientrows = from r in m_DataSet.Ingredient where r.IngredientID == item.IngredientID select r;
//                                                     vEDataSet.Ingredient.Select("IngredientID=" + item.IngredientID);
                                if (item.IsStockVolumeNull())   continue;
                                if (ingredientrows.Count() ==0) continue;
                                item.StockMoney = (decimal)(item.StockVolume * ingredientrows.First().Price);
                            }
                            inventory.IngredientsCost += item.StockMoney;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("错误：" + ex.Message); };
                }
                else
                {
                    // 找出食材前期值代入
                    var prevDetails = prev.GetInventoryDetailRows();
                    foreach (var d in details)
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
                                        var ings = from r in m_DataSet.Ingredient where r.IngredientID == dIngredientID select r;
                                        if (ings.Count() > 0)
                                        {
                                            var ing = ings.First();
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
                    foreach (var pd in productDetails)
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
                foreach (var pd in productDetails)
                {
                    pd.Cost = 0m;
                    if ((!pd.IsVolumeNull()) && pd.Volume > 0)
                    {
                        var ps = from r in m_OrderSet.Product where r.ProductID == pd.ProductID select r;
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

                inventoryBindingSource.ResetBindings(false);
                DetailBindingSource(SaveToDataTable: false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("計算估值時發生錯誤,原因:" + ex.Message);
            }
        }


        void RemainStockWarning(MyInventoryDetailRow detail,double remainStock)
        {
            int ingredientID = detail.IngredientID;
            detail.AreaCode = "???";
            var ings=from r in m_DataSet.Ingredient where r.IngredientID==ingredientID select r;
            if (ings.Count()>0)
            {
                var ing=ings.First();
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
                DataRowView rowView = inventoryBindingSource.Current as DataRowView;
                var curr = rowView.Row as MyInventoryRow;
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
                DataRowView rowView = inventoryBindingSource.Current as DataRowView;
                var curr = rowView.Row as MyInventoryRow;
                if (!curr.IsEvaluatedDateNull()) curr.SetEvaluatedDateNull();
            }
        }


        // 剛Binding時賦值,EnterRow,都會呼叫, 所以...只好取消Binding, 自己綁
        private void checkDayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker picker = sender as DateTimePicker;
            DataRowView rowView = inventoryBindingSource.Current as DataRowView;
            if (rowView == null) return;    // 還沒有任何記錄
            var curr = rowView.Row as MyInventoryRow;
            DateTime date = picker.Value.Date;
            if (date.Year != MyFunction.IntHeaderYear)
            {
                MessageBox.Show("只能選" + MyFunction.HeaderYear + "年");
                picker.Value = curr.CheckDay;     // 從DataGridView 抓值回來
                return;
            }
            var dataRow = rowView.Row as MyInventoryRow;
            foreach (var row in m_DataSet.Inventory)
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
            MessageBox.Show("错误：行" + e.RowIndex + "列" + e.ColumnIndex);
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

        private void tbxIngredientsLost_TextChanged(object sender, EventArgs e)
        {

        }



     }
}
