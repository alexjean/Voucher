using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace VoucherExpense
{
    class Editor
    {
        protected void BeginEdit(DataGridView view, string columnID, string dbID, DataTable table, int rowIndex)
        {
            DataGridViewRow row = view.Rows[rowIndex];
            DataGridViewCell cell = row.Cells[columnID];
            object id = cell.Value;
            if (id == null || id == DBNull.Value || (int)id <= 0)
            {
                MessageBox.Show("必需有編號, 將自動設定");
                int ma = MyFunction.MaxNoInDB(columnID, table);
                int i = MyFunction.SetCellMaxNo(dbID, view, ma);
            }
        }

        protected void AddNewItem(DataGridView view, string columnID, string dbID, DataTable table)
        {
            if (MyFunction.LockAll)
            {
                MessageBox.Show("鎖定中,新增無用");
            }
            int ma = MyFunction.MaxNoInDB(dbID, table);
            int i = MyFunction.SetCellMaxNo(columnID, view, ma);
        }
    }
}
