using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VoucherExpense
{
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
