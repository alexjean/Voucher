using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VoucherExpense
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void employeeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            VEDataSet.EmployeeDataTable table = MyFunction.SaveCheck<VEDataSet.EmployeeDataTable>(
                                                          this, employeeBindingSource, vEDataSet.Employee);
            if (table == null) return;
//            MyFunction.SetGlobalFlag(GlobalFlag.employeeModified);
            foreach (VEDataSet.EmployeeRow r in table)
            {
                if (r.RowState != DataRowState.Deleted)
                {
                    r.BeginEdit();
                    r.LastUpdated = DateTime.Now;
                    r.EndEdit();
                }
            }
            vEDataSet.Employee.Merge(table);
            this.employeeTableAdapter.Update(this.vEDataSet.Employee);
            this.vEDataSet.Employee.AcceptChanges();

        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            employeeTableAdapter.Connection = MapPath.VEConnection;
            this.employeeTableAdapter.Fill(this.vEDataSet.Employee);
            MyFunction.SetFieldLength(employeeDataGridView, vEDataSet.Employee);
        }

        private void employeeDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
/*
            string cellName="EmployeeID";
            if (e.RowIndex < 0) return;
            DataGridView view = (DataGridView)sender;
            DataGridViewRow row = view.Rows[e.RowIndex];
            if (Convert.IsDBNull(row.Cells[cellName].Value))
            {
                int m = 0, n = 0;
                foreach (DataGridViewRow r in view.Rows)
                {
                    object obj = r.Cells[cellName].Value;
                    if (obj == null) continue;
                    if (Convert.IsDBNull(obj)) continue;
                    n = (int)obj;
                    if (n > m) m = n;
                }
                row.Cells[cellName].Value = m + 1;
            }
*/
        }

        private void employeeDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            string cellName = view.Columns[e.ColumnIndex].Name;
            if (cellName == "Birthday" || cellName == "StartWorkingDay")
            {
                e.Cancel=!MyFunction.DateValidate(e.FormattedValue.ToString());
            }
            else if (cellName == "columnSalary" || cellName == "columnEmployeeCode")
            {
                e.Cancel = !MyFunction.UintValidate(e.FormattedValue.ToString());
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyFunction.AddNewItem(employeeDataGridView,"EmployeeID","ID",vEDataSet.Employee);
        }

 
    }
}