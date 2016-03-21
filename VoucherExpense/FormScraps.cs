using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MyDataSet                     = VoucherExpense.DamaiDataSet;
using MyOrderSet                    = VoucherExpense.DamaiDataSet;
using MyProductScrappedRow          = VoucherExpense.DamaiDataSet.ProductScrappedRow;
using MyProductScrappedDetailRow    = VoucherExpense.DamaiDataSet.ProductScrappedDetailRow;
using MyProductScrappedTable        = VoucherExpense.DamaiDataSet.ProductScrappedDataTable;
using MyProductScrappedDetailTable  = VoucherExpense.DamaiDataSet.ProductScrappedDetailDataTable;
using MyProductScrappedAdapter      = VoucherExpense.DamaiDataSetTableAdapters.ProductScrappedTableAdapter;
using MyProductScrappedDetailAdapter= VoucherExpense.DamaiDataSetTableAdapters.ProductScrappedDetailTableAdapter;

namespace VoucherExpense
{
    public partial class FormScraps : Form
    {
        public FormScraps()
        {
            InitializeComponent();
        }

        void SetupBindingSource()
        {
            productBindingSource.DataSource = m_OrderSet;
            operatorBindingSource.DataSource = m_DataSet;
            productScrappedBindingSource.DataSource = m_DataSet;   // productScrappedBindingSource1不用,只用來通知設計工具
        }

        List<CNameIDForComboBox> m_TableTypeList = new List<CNameIDForComboBox>();
        MyDataSet m_DataSet = new MyDataSet();
        MyOrderSet m_OrderSet;
        MyProductScrappedAdapter ProductScrappedAdapter = new MyProductScrappedAdapter();
        MyProductScrappedDetailAdapter ProductScrappedDetailAdapter = new MyProductScrappedDetailAdapter();
        private void FormScraps_Load(object sender, EventArgs e)
        {

            m_OrderSet = m_DataSet;
            var productAdapter  = new VoucherExpense.DamaiDataSetTableAdapters.ProductTableAdapter();
            var operatorAdapter = new VoucherExpense.DamaiDataSetTableAdapters.OperatorTableAdapter();
            productAdapter.Connection.ConnectionString  = DB.SqlConnectString(MyFunction.HardwareCfg);
            operatorAdapter.Connection.ConnectionString = DB.SqlConnectString(MyFunction.HardwareCfg);


            SetupBindingSource();
            productScrappedDetailBindingSource1.DataSource=productScrappedBindingSource;
            dgvScrappedDetail.DataSource = this.productScrappedDetailBindingSource1;

            try
            {
                productAdapter.Fill(m_OrderSet.Product);
                operatorAdapter.Fill(m_DataSet.Operator);
                ProductScrappedAdapter.Fill(m_DataSet.ProductScrapped);
                ProductScrappedDetailAdapter.Fill(m_DataSet.ProductScrappedDetail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤:" + ex.Message);
            }
            List<string> scrapeTypeList=new List<string>{" ","日報癈","試吃","其他"};
            int i=0;
            foreach(string s in scrapeTypeList)
                m_TableTypeList.Add(new CNameIDForComboBox(i++,s));
            checkBox1.Text = scrapeTypeList[1];
            checkBox2.Text = scrapeTypeList[2];
            checkBox3.Text = scrapeTypeList[3];
            fromPicker.MaxDate  = toPicker.MaxDate = new DateTime(MyFunction.IntHeaderYear, 12, 31);
            toPicker.MinDate    = toPicker.MinDate = new DateTime(MyFunction.IntHeaderYear, 1 , 1 );
            cNameIDForComboBoxBindingSource.DataSource = m_TableTypeList;
            ColumnLocked.ReadOnly = !MyFunction.LockInventory;
        }

        private void productScrappedBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productScrappedBindingSource.EndEdit();
//          this.productScrappedDetailBindingSource.EndEdit();
            DetailBindingSource(SaveToDB: true);

            DateTime now = DateTime.Now;
            var detailTable = m_DataSet.ProductScrappedDetail.GetChanges() as MyProductScrappedDetailTable;
            if (detailTable != null)   // 把有更改的InventoryDetail填 Inventory.Lastupdated的值
            {
                var IDs = (from r in detailTable
                           where (r.RowState != DataRowState.Deleted) && (!r.IsProdcutScrappedIDNull())
                           select r.ProdcutScrappedID).Distinct();
                foreach (int id in IDs)
                {
                    var rows = from r in m_DataSet.ProductScrapped where (r.RowState != DataRowState.Deleted) && (id == r.ProductScrappedID) select r;
                    if (rows.Count() != 0)
                        rows.First().LastUpdated = now;
                }
            }

            var table = m_DataSet.ProductScrapped.GetChanges() as MyProductScrappedTable;
            if (table == null && detailTable == null)
            {
                MessageBox.Show("沒有更改,不用存檔!");
                return;
            }
            try
            {
                int deleted = 0, updated = 0;
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
                    ProductScrappedAdapter.Update(table);
                    m_DataSet.ProductScrapped.Merge(table);
                    m_DataSet.ProductScrapped.AcceptChanges();
                }
                if (detailTable != null)
                {
//                    ProductScrappedDetailAdapter.Update(m_DataSet.ProductScrappedDetail);
                    ProductScrappedDetailAdapter.Update(detailTable);
                    m_DataSet.ProductScrappedDetail.Merge(detailTable);
                    m_DataSet.ProductScrappedDetail.AcceptChanges();
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


        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            DateTime maxDate = new DateTime(MyFunction.IntHeaderYear, 1, 1);
            foreach (var r in m_DataSet.ProductScrapped)
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
                    MyFunction.AddNewItem(dgvProductScrapped, "ColumnProductScrappedID", "ProductScrappedID", m_DataSet.ProductScrapped);
                    bindingNavigatorAddNewItem.Enabled = false;
                    var rowView = row.DataBoundItem as DataRowView;
                    var data = rowView.Row as MyProductScrappedRow;
                    data.ScrappedDate = maxDate;       // 盤點日
                    int productScrappedID = data.ProductScrappedID;
                    // 從產品表中有Code的,加入vEDataSet.ProductScrappedDetail
                    foreach (var product in m_OrderSet.Product)
                    {
                        if (product.IsCodeNull()) continue;
                        if (product.Code <= 0) continue;    // 無代号產品不納入報癈
                        var detail = m_DataSet.ProductScrappedDetail.NewProductScrappedDetailRow();
                        detail.ID = Guid.NewGuid();
                        detail.ProductID = product.ProductID;
                        detail.ProdcutScrappedID = productScrappedID;
                        if (!product.IsPriceNull())
                            detail.Price = (decimal)product.Price;
                        if (!product.IsEvaluatedCostNull())
                            detail.EvaluatedCost = product.EvaluatedCost;
                        m_DataSet.ProductScrappedDetail.AddProductScrappedDetailRow(detail);
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
                this.productScrappedDetailBindingSource1.Filter = "Volume>0";
            else
                this.productScrappedDetailBindingSource1.RemoveFilter();

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
            DetailBindingSource(SaveToDB: true);
//            this.productScrappedDetailBindingSource.EndEdit();
            try
            {
                DataRowView rowView = productScrappedBindingSource.Current as DataRowView;
                var curr = rowView.Row as MyProductScrappedRow;
                var details = curr.GetProductScrappedDetailRows();
                decimal value = 0, cost = 0;
                foreach (var d in details)
                {
                    if (d.IsVolumeNull()) continue;
                    if (d.IsProductIDNull()) continue;
                    var rows=from r in m_OrderSet.Product where r.ProductID==d.ProductID select r;
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
            soldValueTextBox.BackColor = ingredientsCostTextBox.BackColor = this.BackColor;
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
            var productScrapped = rowView.Row as MyProductScrappedRow;
            int id = productScrapped.ProductScrappedID;
            var rows = from r in m_DataSet.ProductScrappedDetail where r.ProdcutScrappedID == id select r;
            var list = rows.ToList<MyProductScrappedDetailRow>();       // 用Collection,delete 會影響枚舉
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

        void DetailBindingSource(bool SaveToDB)
        {

            if (SaveToDB)
                productScrappedDetailBindingSource1.EndEdit();
            else
                productScrappedDetailBindingSource1.ResetBindings(false);

        }

        private void FormScraps_Shown(object sender, EventArgs e)
        {
            dgvProductScrapped_RowEnter(null, null);
            dgvProductScrapped.RowEnter+=new DataGridViewCellEventHandler(dgvProductScrapped_RowEnter);   // 為避免為顯示前,不知名的呼叫
        }

        private void dgvProductScrapped_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgvRow = dgvProductScrapped.Rows[e.RowIndex];
                DataRowView rowView = dgvRow.DataBoundItem as DataRowView;
                var dataRow = rowView.Row as MyProductScrappedRow;
                if (dataRow.IsLockedNull())
                {
                    dataRow.Locked = false;//为空时设为false
                    SetDetailLocked(false);
                }
                else { SetDetailLocked(dataRow.Locked); }
                var details=dataRow.GetProductScrappedDetailRows();
                decimal sum = 0,value=0,cost=0;
                foreach (var de in details)
                    if (!de.IsVolumeNull())
                    {
                        sum += de.Volume;
                        if (!de.IsPriceNull())         value += (de.Volume * de.Price);
                        if (!de.IsEvaluatedCostNull()) cost  += (de.Volume * de.EvaluatedCost);
                    }
                volumeTextBox.Text          = sum.ToString("N1");
                soldValueTextBox.Text       = value.ToString("N1");
                ingredientsCostTextBox.Text = cost.ToString("N2");
                if ((!dataRow.IsSoldValueNull()) && (value != dataRow.SoldValue))
                     soldValueTextBox.BackColor       = Color.Red;
                else soldValueTextBox.BackColor       = this.BackColor;
                if ((!dataRow.IsIngredientsCostNull()) && cost != dataRow.IngredientsCost)
                     ingredientsCostTextBox.BackColor = Color.Red;
                else ingredientsCostTextBox.BackColor = this.BackColor;
            }
            catch { };
            chBoxHide_CheckedChanged(null, null);
            DetailBindingSource(SaveToDB: false);
//            productScrappedDetailBindingSource1.ResetBindings(false);
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
                var curr = rowView.Row as MyProductScrappedRow;
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
                var current = rowView.Row as MyProductScrappedRow;
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
            dgvProductScrapped.RowEnter-= new DataGridViewCellEventHandler(dgvProductScrapped_RowEnter);
            dgvScrappedDetail.Visible = false;
            dgvProductScrapped.Visible = false;
            dgvCalc.Visible = false;
        }

        private void dgvScrappedDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //DataGridView view = sender as DataGridView;
            //int iCol = e.ColumnIndex;
            //int iRow = e.RowIndex;
           
            //DataGridViewColumn column = view.Columns[iCol];
            //{
            //    DataGridViewRow row=view.Rows[iRow];
            //    DataRowView  rowview=row.DataBoundItem as DataRowView;
            //    var current=rowview.Row as SQLVEDataSet.ProductScrappedDetailRow;
            //    DataGridViewCell cell = row.Cells[iCol];
            //    if (column.Name == "ProductID")
            //    {
            //        cell.Value="<ID"+current.ProductID.ToString()+">";
                        
            //    }
            //    else
            //    {
            //        if (column.Name == "ProductName")
            //        {
            //            cell.Value = "<ID" + current.ProductID.ToString() + ">";
            //        }
            //        else
            //        {
            //            MessageBox.Show("第" + iRow.ToString() + "行[" + column.HeaderText + "]資料錯誤,原因:" + e.Exception.Message);
            //            e.Cancel = true;
            //        }
            //    }
            //}
        }

        public class CalcScrape
        {
            public int ProductID     { get; set; }
            public decimal Volume    { get; set; }
            public decimal Cost      { get; set; }
            public decimal SoldValue { get; set; }
            public CalcScrape(int id) { ProductID = id; }
        }
        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (fromPicker.Value > toPicker.Value)
            {
                MessageBox.Show("啟始日期不能大於結束日期!");
                return;
            }
            DateTime from=fromPicker.Value;
            DateTime to  =toPicker.Value;
            Dictionary<int, CalcScrape> dic = new Dictionary<int, CalcScrape>();
            if (checkBox1.Checked) DoCalcScrape(from, to, 1, ref dic);
            if (checkBox2.Checked) DoCalcScrape(from, to, 2, ref dic);
            if (checkBox3.Checked) DoCalcScrape(from, to, 3, ref dic);
            SortableBindingList<CalcScrape> list = new SortableBindingList<CalcScrape>();
            decimal volume=0, cost=0, soldValue=0;
            foreach (var v in dic.Values)
                if (v.Volume > 0)
                {
                    volume    += v.Volume;
                    cost      += v.Cost;
                    soldValue += v.SoldValue;
                    list.Add(v);
                }
            txBoxVolume.Text    = volume.ToString("N1");
            txBoxSoldValue.Text = soldValue.ToString("N1");
            txBoxCost.Text = cost.ToString("N2");
            dgvCalc.DataSource = list;

        }

        void DoCalcScrape(DateTime begin, DateTime end, int reason,ref Dictionary<int,CalcScrape> dic)
        {
            var rows = from r in m_DataSet.ProductScrapped
                       where r.ScrappedDate.Date>=begin.Date && r.ScrappedDate.Date<=end.Date && r.Reason == reason
                       select r;
            if (rows.Count()<=0) return;
            foreach (var row in rows)
            {
                var details = row.GetProductScrappedDetailRows();
                foreach (var d in details)
                {
                    CalcScrape scr;
                    int id = d.ProductID;
                    if (!dic.ContainsKey(id)) dic.Add(id, new CalcScrape(id));
                    scr = dic[id];
                    if (d.IsVolumeNull()) continue;
                    scr.Volume += d.Volume;
                    if (!d.IsEvaluatedCostNull()) scr.Cost      += (d.Volume * d.EvaluatedCost);
                    if (!d.IsPriceNull())         scr.SoldValue += (d.Volume * d.Price);
                }
            }
        }
    }
}
