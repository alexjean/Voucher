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
    public partial class FormShrink : Form
    {
        public FormShrink()
        {
            InitializeComponent();                  
        }

        public class TimeData
        {
            public DateTime InventoryTimeBefore { get; set; }
            public DateTime InventoryTimeAfter { get; set; }
            public string TimeStr { get { return (InventoryTimeBefore.ToString("MM/dd") + "-" + InventoryTimeAfter.ToString("MM/dd")); } }   
            public decimal IngredientsBefore { get; set; }
            public decimal IngredientsAfter { get; set; }
            public decimal ProductBefore { get; set; }
            public decimal ProductAfter { get; set; }
            public decimal Stock { get; set; }
            public decimal Scrap { get; set; }
            public decimal PerScrap { get; set; }
            public decimal Sold { get; set; }
            public decimal PerSold { get; set; }
           // public decimal Shink { get  { return (IngredientsBefore + ProductBefore + Stock - IngredientsAfter - ProductAfter - Scrap - Sold); }  }
            public decimal Shrink { get; set; }
            public decimal PerShrink { get; set; }
        }
        OrderAdapter m_OrderAdapter = new OrderAdapter();
        
        public class OrderAdapter : BakeryOrderSetTableAdapters.OrderTableAdapter
        {
            string SaveStr;
            public int FillBySelectStr(BakeryOrderSet.OrderDataTable dataTable, string SelectStr)
            {
                SaveStr = base.CommandCollection[0].CommandText;
                base.CommandCollection[0].CommandText = SelectStr;
                int result = Fill(dataTable);
                base.CommandCollection[0].CommandText = SaveStr;
                return result;
            }
        }
        OrderItemAdapter m_OrderItemAdapter =new OrderItemAdapter ();

        public class OrderItemAdapter : BakeryOrderSetTableAdapters.OrderItemTableAdapter
        {
            string SaveStr;
            public int FillBySelectStr(BakeryOrderSet.OrderItemDataTable dataTable, string SelectStr)
            {
                SaveStr = base.CommandCollection[0].CommandText;
                base.CommandCollection[0].CommandText = SelectStr;
                int result = Fill(dataTable);
                base.CommandCollection[0].CommandText = SaveStr;
                return result;
            }
        } 
        SQLVEDataSet.InventoryDataTable Inventory = new SQLVEDataSet.InventoryDataTable();
        BakeryOrderSet.ProductDataTable Product = new BakeryOrderSet.ProductDataTable();
        SQLVEDataSet.ProductScrappedDataTable ProductScrapped = new SQLVEDataSet.ProductScrappedDataTable();
        
        private void FormShrink_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“sQLVEDataSet.Inventory”中。您可以根据需要移动或删除它。
           // loaddata("");
            try
            {
                SQLVEDataSetTableAdapters.InventoryTableAdapter inventoryTableAdapter = new SQLVEDataSetTableAdapters.InventoryTableAdapter();
                inventoryTableAdapter.Fill(Inventory);
                BakeryOrderSetTableAdapters.ProductTableAdapter productTableAdapter = new BakeryOrderSetTableAdapters.ProductTableAdapter();
                productTableAdapter.Fill(Product);
                SQLVEDataSetTableAdapters.ProductScrappedTableAdapter ProductScrappedTableAdapter = new SQLVEDataSetTableAdapters.ProductScrappedTableAdapter();
                ProductScrappedTableAdapter.Fill(ProductScrapped);

                Inventorydata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex.Message);
            }
        }

        private void Inventorydata()
        { 
            List<TimeData> data = new List<TimeData>();
                        if (Inventory.Rows.Count < 2) return;
                        for (int i = 0; i < Inventory.Rows.Count - 1; i++)
                        {
                            var inventoryrow = (SQLVEDataSet.InventoryRow)Inventory.Rows[i];
                            var inventoryrow1 = (SQLVEDataSet.InventoryRow)Inventory.Rows[i + 1];
                            var shink = new TimeData();
                            if(!inventoryrow.IsCheckDayNull())
                            shink.InventoryTimeBefore = inventoryrow.CheckDay;
                            if(!inventoryrow1.IsCheckDayNull())
                            shink.InventoryTimeAfter = inventoryrow1.CheckDay;
                            if(!inventoryrow.IsIngredientsCostNull())
                            shink.IngredientsBefore = inventoryrow.IngredientsCost;
                            if (!inventoryrow1.IsIngredientsCostNull() || !inventoryrow1.IsIngredientsCostNull() || !inventoryrow.IsIngredientsCostNull())
                            shink.IngredientsAfter = inventoryrow1.IngredientsCost;
                            if(!inventoryrow1.IsIngredientsLostNull())
                            shink.Stock = inventoryrow1.IngredientsCost + inventoryrow1.IngredientsLost - inventoryrow.IngredientsCost;
                            if(!inventoryrow.IsProductsCostNull())
                            shink.ProductBefore = inventoryrow.ProductsCost;
                            if(!inventoryrow1.IsProductsCostNull())
                            shink.ProductAfter = inventoryrow1.ProductsCost;
                            data.Add(shink);
                        }
                        formShrink_TimeDataDataGridView.DataSource = data;
        }

        private void formShrink_TimeDataDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow dgvr = dgv.CurrentRow;
                dgvr.Cells["Sold"].Value = selectdata((DateTime)dgvr.Cells["InventoryTimeBefore"].Value, (DateTime)dgvr.Cells["InventoryTimeAfter"].Value);
                dgvr.Cells["Scrap"].Value = selectScrap((DateTime)dgvr.Cells["InventoryTimeBefore"].Value, (DateTime)dgvr.Cells["InventoryTimeAfter"].Value);
                //(IngredientsBefore + ProductBefore + Stock - IngredientsAfter - ProductAfter - Scrap - Sold); 
                dgvr.Cells["Shrink"].Value = (decimal)dgvr.Cells["IngredientsBefore"].Value + (decimal)dgvr.Cells["ProductBefore"].Value + (decimal)dgvr.Cells["Stock"].Value - (decimal)dgvr.Cells["IngredientsAfter"].Value - (decimal)dgvr.Cells["ProductAfter"].Value - (decimal)dgvr.Cells["Scrap"].Value - (decimal)dgvr.Cells["Sold"].Value;
                dgvr.Cells["PerShrink"].Value = (decimal)dgvr.Cells["Shrink"].Value / ((decimal)dgvr.Cells["IngredientsBefore"].Value + (decimal)dgvr.Cells["ProductBefore"].Value + (decimal)dgvr.Cells["Stock"].Value - (decimal)dgvr.Cells["IngredientsAfter"].Value - (decimal)dgvr.Cells["ProductAfter"].Value);
                dgvr.Cells["PerSold"].Value = (decimal)dgvr.Cells["Sold"].Value / ((decimal)dgvr.Cells["IngredientsBefore"].Value + (decimal)dgvr.Cells["ProductBefore"].Value + (decimal)dgvr.Cells["Stock"].Value - (decimal)dgvr.Cells["IngredientsAfter"].Value - (decimal)dgvr.Cells["ProductAfter"].Value);
                dgvr.Cells["PerScrap"].Value = (decimal)dgvr.Cells["Scrap"].Value / ((decimal)dgvr.Cells["IngredientsBefore"].Value + (decimal)dgvr.Cells["ProductBefore"].Value + (decimal)dgvr.Cells["Stock"].Value - (decimal)dgvr.Cells["IngredientsAfter"].Value - (decimal)dgvr.Cells["ProductAfter"].Value);
                dgvr.Cells["Shrink"].Style.SelectionBackColor = Color.Lime;
                dgvr.Cells["Shrink"].Style.BackColor = Color.Lime;
                dgvr.Cells["Sold"].Style.SelectionBackColor = Color.Lime;
                dgvr.Cells["Sold"].Style.BackColor = Color.Lime;
                dgvr.Cells["Scrap"].Style.SelectionBackColor = Color.Lime;
                dgvr.Cells["Scrap"].Style.BackColor = Color.Lime;
                dgvr.Cells["PerShrink"].Style.SelectionBackColor = Color.Lime;
                dgvr.Cells["PerShrink"].Style.BackColor = Color.Lime;
                dgvr.Cells["PerSold"].Style.SelectionBackColor = Color.Lime;
                dgvr.Cells["PerSold"].Style.BackColor = Color.Lime;
                dgvr.Cells["PerScrap"].Style.SelectionBackColor = Color.Lime;
                dgvr.Cells["PerScrap"].Style.BackColor = Color.Lime;
                 
            }
            catch(Exception ex)
            {
                MessageBox.Show("数据计算时出现错误" + ex.ToString());
            }
        }
       Dictionary<int, decimal> m_ProductDic = new Dictionary<int, decimal>();

       decimal selectdata(DateTime time1, DateTime time2)
       {
           if (m_ProductDic.Count==0)
           {
               foreach (var pd in Product)
               {
                   if (pd.Code>0)
                   {
                        m_ProductDic.Add(pd.ProductID, pd.EvaluatedCost);
                   }          
               }
           }

           TimeData timedata = new TimeData();
           decimal costtemp = 0;
           string sqlstr = "Where INT(ID/1000000)>" + Convert.ToInt32(time1.ToString("MMdd")) + " and INT(ID/1000000)<=" + Convert.ToInt32(time2.ToString("MMdd"));
           BakeryOrderSet.OrderDataTable Order = new BakeryOrderSet.OrderDataTable();
           BakeryOrderSet.OrderItemDataTable OrderItem = new BakeryOrderSet.OrderItemDataTable();
           //m_OrderAdapter.FillBySelectStr(Order, "Select * From [Order] " + sqlstr + " and oldid=0 And deleted=false Order by ID");
           //m_OrderItemAdapter.FillBySelectStr(OrderItem, "Select * From [OrderItem] " + sqlstr + " Order by ID");
           bakeryOrderSet1.OrderItem.Clear();
           bakeryOrderSet1.Order.Clear();
           try
           {
               m_OrderAdapter.FillBySelectStr(bakeryOrderSet1.Order, "Select * From [Order] " + sqlstr + " Order by ID");
               m_OrderItemAdapter.FillBySelectStr(bakeryOrderSet1.OrderItem, "Select * From [OrderItem] " + sqlstr + " Order by ID");
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
           progressBar1.Visible = true;
           progressBar1.Maximum = bakeryOrderSet1.Order.Count + 1;
           int i = 0;
           foreach (BakeryOrderSet.OrderRow item in bakeryOrderSet1.Order)
           {
               progressBar1.Value = i++;
               if (item.Deleted)
                   continue;
               if (item.OldID != 0)
                   continue;

               //var orderItem = from row in OrderItem where (row.ID == item.ID) select row;
               //foreach (var item1 in orderItem)
               var rows = item.GetOrderItemRows();
               foreach (BakeryOrderSet.OrderItemRow item1 in rows)
               {
                   decimal cost = 0;
                   if (m_ProductDic.TryGetValue(item1.ProductID,out cost))
                   {
                           costtemp += cost * item1.No;
                   }
               }
           }
           progressBar1.Visible = false;

           return costtemp;
       }
       decimal selectScrap(DateTime time1, DateTime time2)
       {
           decimal baofei = 0;
           var ProductScrappeds = from row in ProductScrapped where (row.ScrappedDate <= time2 && row.ScrappedDate > time1) select row;
           foreach (var productScrappedsrow in ProductScrappeds)
           {
               baofei += productScrappedsrow.IngredientsCost;
           }
           return baofei;
       }


    }
}
 