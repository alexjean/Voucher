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

        DataTable shrinkDT =null;
        private void FormShrink_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“sQLVEDataSet.Inventory”中。您可以根据需要移动或删除它。
            loaddata("");
        }
         private void loaddata(string str)
        {
            shrinkDT = new DataTable("shrink");
            shrinkDT.Columns.Add("序号",Type.GetType("System.Int32"));
            shrinkDT.Columns[0].AutoIncrement = true;
            shrinkDT.Columns[0].AutoIncrementSeed = 1;
            shrinkDT.Columns[0].AutoIncrementStep = 1;
            //shrinkDT.Columns.Add("DateTime", Type.GetType("System.String"));
            //shrinkDT.Columns.Add("IngredientsCosta", Type.GetType("System.Int32"));
            //shrinkDT.Columns.Add("IngredientsCostb", Type.GetType("System.Int32"));
            //shrinkDT.Columns.Add("ProductsCosta", Type.GetType("System.Int32")); 
            //shrinkDT.Columns.Add("ProductsCostb", Type.GetType("System.Int32"));
            shrinkDT.Columns.Add("时间", Type.GetType("System.String"));
            shrinkDT.Columns.Add("食材前库存", Type.GetType("System.Int32"));
            shrinkDT.Columns.Add("食材后库存", Type.GetType("System.Int32"));
            shrinkDT.Columns.Add("进货", Type.GetType("System.Int32"));
            shrinkDT.Columns.Add("产品前库存", Type.GetType("System.Int32"));
            shrinkDT.Columns.Add("产品后库存", Type.GetType("System.Int32"));
            shrinkDT.Columns.Add("报废", Type.GetType("System.Int32"));
            shrinkDT.Columns.Add("售出", Type.GetType("System.Int32"));
            shrinkDT.Columns.Add("未知损耗", Type.GetType("System.Int32"));
           // shrinkDT.Columns.Add("月份", Type.GetType("System.String"));
            //导入数据
            SQLVEDataSet.InventoryDataTable Inventory = new SQLVEDataSet.InventoryDataTable();
            SQLVEDataSetTableAdapters.InventoryTableAdapter inventoryTableAdapter = new SQLVEDataSetTableAdapters.InventoryTableAdapter();
            inventoryTableAdapter.Fill(Inventory);
            SQLVEDataSet.ProductScrappedDataTable ProductScrapped = new SQLVEDataSet.ProductScrappedDataTable();
            SQLVEDataSetTableAdapters.ProductScrappedTableAdapter ProductScrappedTableAdapter = new SQLVEDataSetTableAdapters.ProductScrappedTableAdapter();
            ProductScrappedTableAdapter.Fill(ProductScrapped);
            BakeryOrderSet.OrderDataTable Order = new BakeryOrderSet.OrderDataTable();
            BakeryOrderSet.OrderItemDataTable OrderItem = new BakeryOrderSet.OrderItemDataTable();
            BakeryOrderSet.ProductDataTable Product = new BakeryOrderSet.ProductDataTable();
            BakeryOrderSetTableAdapters.OrderTableAdapter orderTableAdapter = new BakeryOrderSetTableAdapters.OrderTableAdapter();
            orderTableAdapter.Fill(Order);
            BakeryOrderSetTableAdapters.OrderItemTableAdapter orderItemTableAdapter = new BakeryOrderSetTableAdapters.OrderItemTableAdapter();
            orderItemTableAdapter.Fill(OrderItem);
            BakeryOrderSetTableAdapters.ProductTableAdapter productTableAdapter = new BakeryOrderSetTableAdapters.ProductTableAdapter();
            productTableAdapter.Fill(Product);
            var Inventoryrows =  Inventory.Select();

            for (int i = 0; i < Inventoryrows.Length-1; i++)
            {
                //计算时间段报废 
                int baofei = 0;
                var ProductScrappedrows = ProductScrapped.Select("ScrappedDate<='"+Inventory[i+1]["checkday"]+"'and ScrappedDate>'"+Inventory[i]["checkday"]+"'");//大于前期日期，小于等于本期日期的报废
                for (int j = 0; j < ProductScrappedrows.Length; j++)
                {
                    baofei +=Convert.ToInt32( ProductScrappedrows[j]["IngredientsCost"]);//计算时间段内报废和
                }
                //计算售出
                int shouchu = 0;
                var ProductRow = Product.Select();
                foreach (var item in ProductRow)
                {
                    var OrderItemrow = OrderItem.Select("ID>'" + Convert.ToDateTime(Inventoryrows[i]["checkday"]).ToString("MMdd") + "100000'" + "and ID<='" + Convert.ToDateTime(Inventoryrows[i+1]["checkday"]).ToString("MMdd") + "999999'"+"and ProductID='"+item["ProductID"]+"'");
                    foreach (var item1 in OrderItemrow)
	                {
		                shouchu +=Convert.ToInt32(item1["No"])*Convert.ToInt32(item["Price"]);
	                }
                }     
                shrinkDT.Rows.Add(new object[] { null, 
                    Inventoryrows[i]["checkday"].ToString().Remove(10) + "- " + Inventoryrows[i + 1]["CheckDay"].ToString().Remove(10), //时间
                    Inventoryrows[i]["IngredientsCost"],       //食材前库存
                    Inventoryrows[i + 1]["IngredientsCost"],    //食材后库存
                    (decimal) Inventoryrows[i + 1]["IngredientsLost"]+(decimal)Inventoryrows[i + 1]["IngredientsCost"]-(decimal)Inventoryrows[i]["IngredientsCost"]  ,  //进货= 后库存加损失减前库存
                    Inventoryrows[i]["ProductsCost"],           //产品前库存
                    Inventoryrows[i+1]["ProductsCost"],         //产品后库存
                    baofei,                              //报废和 
                    shouchu,                           //售出
                    (decimal)Inventoryrows[i]["IngredientsCost"]+(decimal)Inventoryrows[i]["ProductsCost"]+((decimal) Inventoryrows[i + 1]["IngredientsLost"]+(decimal)Inventoryrows[i + 1]["IngredientsCost"]-(decimal)Inventoryrows[i]["IngredientsCost"] )-(decimal)Inventoryrows[i + 1]["IngredientsCost"]-(decimal)Inventoryrows[i+1]["ProductsCost"]-baofei-shouchu
                   // ,Convert.ToInt32(((DateTime)Inventoryrows[i]["checkday"]).ToString("MM"))
                });
            }  
            //DataTable dt=null;
            dataGridView1.DataSource =shrinkDT;
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMonth.SelectedIndex == 0)
            {
                return;
            }
            else
            {
                loaddata("月份='"+comboBoxMonth.SelectedIndex+"'");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loaddata("");
        }
    }
}
 