using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VoucherExpense
{
    class BakeryOrderAdapter : BakeryOrderSetTableAdapters.OrderTableAdapter
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
    class BakeryOrderItemAdapter : BakeryOrderSetTableAdapters.OrderItemTableAdapter
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
    class BakeryDrawerRecordAdapter : BakeryOrderSetTableAdapters.DrawerRecordTableAdapter
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

    class DamaiOrderAdapter : DamaiDataSetTableAdapters.OrderTableAdapter
    {
        string SaveStr;
        public int FillBySelectStr(DamaiDataSet.OrderDataTable dataTable, string SelectStr)
        {
            SaveStr = base.CommandCollection[0].CommandText;
            base.CommandCollection[0].CommandText = SelectStr;
            int result = Fill(dataTable);
            base.CommandCollection[0].CommandText = SaveStr;
            return result;
        }
    }
    class DamaiOrderItemAdapter : DamaiDataSetTableAdapters.OrderItemTableAdapter
    {
        string SaveStr;
        public int FillBySelectStr(DamaiDataSet.OrderItemDataTable dataTable, string SelectStr)
        {
            SaveStr = base.CommandCollection[0].CommandText;
            base.CommandCollection[0].CommandText = SelectStr;
            int result = Fill(dataTable);
            base.CommandCollection[0].CommandText = SaveStr;
            return result;
        }
    }
    class DamaiDrawerRecordAdapter : DamaiDataSetTableAdapters.DrawerRecordTableAdapter
    {
        string SaveStr;
        public int FillBySelectStr(DamaiDataSet.DrawerRecordDataTable dataTable, string SelectStr)
        {
            SaveStr = base.CommandCollection[0].CommandText;
            base.CommandCollection[0].CommandText = SelectStr;
            int result = Fill(dataTable);
            base.CommandCollection[0].CommandText = SaveStr;
            return result;
        }
    }

    

}
