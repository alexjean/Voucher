using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
#if UseSQLServer
using MyDataSet         = VoucherExpense.DamaiDataSet;
using MyOrderSet        = VoucherExpense.DamaiDataSet;
using MyOrderAdapter    = VoucherExpense.DamaiDataSetTableAdapters.OrderTableAdapter;
using MyOrderItemAdapter= VoucherExpense.DamaiDataSetTableAdapters.OrderItemTableAdapter;
using MyInventoryRow    = VoucherExpense.DamaiDataSet.InventoryRow;
#else
using MyDataSet         = VoucherExpense.VEDataSet;
using MyOrderSet        = VoucherExpense.BakeryOrderSet;
using MyOrderAdapter    = VoucherExpense.BakeryOrderSetTableAdapters.OrderTableAdapter;
using MyOrderItemAdapter= VoucherExpense.BakeryOrderSetTableAdapters.OrderItemTableAdapter;
using MyInventoryRow    = VoucherExpense.VEDataSet.InventoryRow;
#endif
namespace VoucherExpense
{
    public partial class FormShrink : Form
    {
        public FormShrink()
        {
            InitializeComponent();                  
        }

        public class TimeData
        {
            public DateTime InvTimeBefore { get; set; }
            public DateTime InvTimeAfter  { get; set; }
            public string TimeStr               { get { return (InvTimeBefore.ToString("MM/dd") + "-" + InvTimeAfter.ToString("MM/dd")); } }   
            public decimal IngredientsBefore    { get; set; }
            public decimal IngredientsAfter     { get; set; }
            public decimal ProductBefore        { get; set; }
            public decimal ProductAfter         { get; set; }
            public decimal Spent    { get; set; }
            public decimal Stock    { get; set; }
            public decimal Scrap    { get; set; }
            public decimal PerScrap { get; set; }
            public decimal Sold     { get; set; }
            public decimal PerSold  { get; set; }
           // public decimal Shink { get  { return (IngredientsBefore + ProductBefore + Stock - IngredientsAfter - ProductAfter - Scrap - Sold); }  }
            public decimal Shrink   { get; set; }
            public decimal PerShrink { get; set; }

            public decimal CalcSpent() { return IngredientsBefore + ProductBefore + Stock - IngredientsAfter - ProductAfter; }
        }

        OrderAdapter m_OrderAdapter = new OrderAdapter();
        public class OrderAdapter : MyOrderAdapter
        {
            string SaveStr;
            public int FillBySelectStr(MyOrderSet.OrderDataTable dataTable, string SelectStr)
            {
                SaveStr = base.CommandCollection[0].CommandText;
                base.CommandCollection[0].CommandText = SelectStr;
                int result = Fill(dataTable);
                base.CommandCollection[0].CommandText = SaveStr;
                return result;
            }
        }

        OrderItemAdapter m_OrderItemAdapter =new OrderItemAdapter ();
        public class OrderItemAdapter : MyOrderItemAdapter
        {
            string SaveStr;
            public int FillBySelectStr(MyOrderSet.OrderItemDataTable dataTable, string SelectStr)
            {
                SaveStr = base.CommandCollection[0].CommandText;
                base.CommandCollection[0].CommandText = SelectStr;
                int result = Fill(dataTable);
                base.CommandCollection[0].CommandText = SaveStr;
                return result;
            }
        } 

        MyDataSet.InventoryDataTable Inventory  = new MyDataSet.InventoryDataTable();
        MyOrderSet.ProductDataTable  Product    = new MyOrderSet.ProductDataTable();
        MyDataSet.ProductScrappedDataTable ProductScrapped = new MyDataSet.ProductScrappedDataTable();
        MyOrderSet m_OrderSet=new MyOrderSet();
        private void FormShrink_Load(object sender, EventArgs e)
        {
            try
            {
#if (UseSQLServer)
                var inventoryTableAdapter       = new VoucherExpense.DamaiDataSetTableAdapters.InventoryTableAdapter();
                var productTableAdapter         = new VoucherExpense.DamaiDataSetTableAdapters.ProductTableAdapter();
                var ProductScrappedTableAdapter = new VoucherExpense.DamaiDataSetTableAdapters.ProductScrappedTableAdapter();
#else
                var inventoryTableAdapter       = new VEDataSetTableAdapters.InventoryTableAdapter();
                var productTableAdapter         = new BakeryOrderSetTableAdapters.ProductTableAdapter();
                var ProductScrappedTableAdapter = new VEDataSetTableAdapters.ProductScrappedTableAdapter();
#endif
                inventoryTableAdapter.Fill(Inventory);
                productTableAdapter.Fill(Product);
                ProductScrappedTableAdapter.Fill(ProductScrapped);
                InventoryData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex.Message);
            }
        }

        void Message(string msg)
        {
            labelMessage.Text = msg;
            Application.DoEvents();
        }

        private void InventoryData()
        {
            List<TimeData> data = new List<TimeData>();
            if (Inventory.Rows.Count < 2) return;
            {
                var row = (MyInventoryRow)Inventory.Rows[0];
                var shink = new TimeData();
                if (!row.IsCheckDayNull())          shink.InvTimeAfter = row.CheckDay;
                if (!row.IsIngredientsCostNull())   shink.IngredientsAfter = row.IngredientsCost;
                if (!row.IsProductsCostNull())      shink.ProductAfter = row.ProductsCost;
                data.Add(shink);
            }
            for (int i = 0; i < Inventory.Rows.Count - 1; i++)
            {
                var row = (MyInventoryRow)Inventory.Rows[i];
                var row1 = (MyInventoryRow)Inventory.Rows[i + 1];
                var shink = new TimeData();
                if (!row.IsCheckDayNull())          shink.InvTimeBefore     = row.CheckDay;
                if (!row1.IsCheckDayNull())         shink.InvTimeAfter      = row1.CheckDay;
                if (!row.IsIngredientsCostNull())   shink.IngredientsBefore = row.IngredientsCost;
                if (!row1.IsIngredientsCostNull())  shink.IngredientsAfter  = row1.IngredientsCost;
                shink.Stock = shink.IngredientsAfter - shink.IngredientsBefore;
                if (!row1.IsIngredientsLostNull())  shink.Stock            += row1.IngredientsLost;
                if (!row.IsProductsCostNull())      shink.ProductBefore     = row.ProductsCost;
                if (!row1.IsProductsCostNull())     shink.ProductAfter      = row1.ProductsCost;
                shink.Spent = shink.CalcSpent();
                data.Add(shink);
            }
            formShrink_TimeDataDataGridView.DataSource = data;
        }

        private void formShrink_TimeDataDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgvRow = ((DataGridView)sender).CurrentRow;
                if (dgvRow.Index == 0)
                {
                    MessageBox.Show("期初值不計算損耗!");
                    return;
                }
                Cursor = Cursors.WaitCursor;
                var data = (TimeData)dgvRow.DataBoundItem;
                data.Sold      = selectData (data.InvTimeBefore, data.InvTimeAfter);
                data.Scrap     = selectScrap(data.InvTimeBefore, data.InvTimeAfter);
                data.Shrink    = data.Spent - data.Scrap - data.Sold;
                data.PerShrink = data.Shrink / data.Spent *100;
                data.PerSold   = data.Sold   / data.Spent *100;
                data.PerScrap  = data.Scrap  / data.Spent *100;
                var cells = dgvRow.Cells;
                foreach (string name in new List<string> { "Shrink", "Sold", "Scrap", "PerShrink", "PerSold", "PerScrap" })
                    cells[name].Style.SelectionBackColor = cells[name].Style.BackColor = Color.Lime;
                Cursor = Cursors.Arrow;
                Message("區間 <"+data.InvTimeBefore.ToString("MMdd")+"-"+data.InvTimeAfter.ToString("MMdd")+"> 計算完成!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("数据计算时出现错误" + ex.Message);
            }
        }
       Dictionary<int, decimal> m_ProductDic = new Dictionary<int, decimal>();

       decimal selectData(DateTime time1, DateTime time2)
       {
           if (m_ProductDic.Count==0)
           {
               Message("載入產品估算成本...");
               foreach (var pd in Product)
                   if (pd.Code>0)  m_ProductDic.Add(pd.ProductID, pd.IsEvaluatedCostNull()? 0 : pd.EvaluatedCost);
           }
           TimeData timedata = new TimeData();
           decimal costtemp = 0;
           string sT1 = time1.ToString("MMdd");
           string sT2 = time2.ToString("MMdd");
           string duration="<"+sT1+"-"+sT2+">";
#if (UseSQLServer)
           string sqlstr = "Where Floor(ID/1000000)>" + sT1 + " and Floor(ID/1000000)<=" + sT2;
#else
           string sqlstr = "Where INT(ID/1000000)>" + sT1 + " and INT(ID/1000000)<=" + sT2;
#endif
           MyOrderSet.OrderDataTable Order          = new MyOrderSet.OrderDataTable();
           MyOrderSet.OrderItemDataTable OrderItem  = new MyOrderSet.OrderItemDataTable();
           //m_OrderAdapter.FillBySelectStr(Order, "Select * From [Order] " + sqlstr + " and oldid=0 And deleted=false Order by ID");
           //m_OrderItemAdapter.FillBySelectStr(OrderItem, "Select * From [OrderItem] " + sqlstr + " Order by ID");
           m_OrderSet.OrderItem.Clear();
           m_OrderSet.Order.Clear();
           //try  // 讓上一級處理
           {
               Message("載入"+duration+"售出單...");
               m_OrderAdapter.FillBySelectStr(m_OrderSet.Order, "Select * From [Order] " + sqlstr + " Order by ID");
               Message("載入" + duration + "售出明細...");
               m_OrderItemAdapter.FillBySelectStr(m_OrderSet.OrderItem, "Select * From [OrderItem] " + sqlstr + " Order by ID");
           }
           //catch (Exception ex) { MessageBox.Show(ex.Message); }
           Message("開始計算" + duration + "銷售品總成本...");
           progressBar1.Visible = true;
           progressBar1.Maximum = m_OrderSet.Order.Count + 1;
           int i = 0;
           foreach (var item in m_OrderSet.Order)
           {
               progressBar1.Value = i++;
               Application.DoEvents();
               if (item.Deleted)    continue;
               if (item.OldID != 0) continue;
               //var orderItem = from row in OrderItem where (row.ID == item.ID) select row;
               //foreach (var item1 in orderItem)
               var rows = item.GetOrderItemRows();
               foreach (MyOrderSet.OrderItemRow item1 in rows)
               {
                   decimal cost = 0;
                   if (m_ProductDic.TryGetValue(item1.ProductID,out cost))
                           costtemp += cost * item1.No;
               }
           }
           progressBar1.Visible = false;
           Application.DoEvents();
           return costtemp;
       }

       decimal selectScrap(DateTime time1, DateTime time2)
       {
           Message("計算區間報廢及試吃...");
           decimal baofei = 0;
           var ProductScrappeds = from row in ProductScrapped where (row.ScrappedDate <= time2 && row.ScrappedDate > time1) select row;
           foreach (var productScrappedsrow in ProductScrappeds)
               baofei += productScrappedsrow.IngredientsCost;
           return baofei;
       }
    }
}
 