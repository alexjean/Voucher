using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BakeryOrder
{
    class MenuItemForTag
    {
        public int id;
//        public int code;     // 全面改成ProductID
        public int ProductID;
        public string name;
        public double No;
        public double Price;
        public short classcode;
        public Label LabelNo;
        public double Money() { return Price * No; }
        public void SetZero() { No = 0; }
        public string NoToString() { return No.ToString(); }
    }

    class OrderAdapter : BakeryOrderSetTableAdapters.OrderTableAdapter
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
    class OrderItemAdapter : BakeryOrderSetTableAdapters.OrderItemTableAdapter
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
    class DrawerRecordAdapter : BakeryOrderSetTableAdapters.DrawerRecordTableAdapter
    {
        string SaveStr;
        public int FillBySelectStr(BakeryOrderSet.DrawerRecordDataTable dataTable, string SelectStr)
        {
            SaveStr = base.CommandCollection[0].CommandText;
            base.CommandCollection[0].CommandText = SelectStr;
            int result = Fill(dataTable);
            base.CommandCollection[0].CommandText = SaveStr;
            return result;
        }
    }
}
