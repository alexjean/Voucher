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
    public partial class FormShift : Form
    {
        public FormShift()
        {
            InitializeComponent();
        }

        public class CMonthForCombo
        {
            public int Index { get; set; }
            public string Name { get; set; }
            public CMonthForCombo(int i, string na)
            {
                Index = i;
                Name = na;
            }
        }

        List<CMonthForCombo> m_MonthList = new List<CMonthForCombo>();
        const string strDay = "Day";

        private void FormShift_Load(object sender, EventArgs e)
        {
            this.shiftTableTableAdapter.Connection  = MapPath.VEConnection;
            this.shiftDetailTableAdapter.Connection = MapPath.VEConnection;
            this.hRTableAdapter.Connection          = MapPath.VEConnection;
            this.operatorTableAdapter.Connection    = MapPath.VEConnection;

            try
            {
                this.shiftTableTableAdapter.Fill(this.vEDataSet.ShiftTable);
                this.shiftDetailTableAdapter.Fill(    vEDataSet.ShiftDetail);
                this.hRTableAdapter.Fill        (this.vEDataSet.HR);
                this.operatorTableAdapter.Fill  (this.vEDataSet.Operator);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ex:" + ex.Message);
            }
            //comboBoxApartment.DataSource = GetApartmentList();
            m_MonthList.Add(new CMonthForCombo(0," "));
            for (int mon = 1; mon <= 12; mon++)
                m_MonthList.Add(new CMonthForCombo(mon,mon.ToString()+"月"));
            cMonthForComboBindingSource.DataSource = m_MonthList;
        }

        //List<CNameIDForComboBox> GetApartmentList()
        //{
        //    List<CNameIDForComboBox> list = new List<CNameIDForComboBox>();
        //    if (vEDataSet.Apartment.Rows.Count > 1)               // 多於一個才有全部這個選項
        //    {
        //        list.Add(new CNameIDForComboBox(0, " "));
        //        comboBoxApartment.Enabled = true;
        //    }
        //    else
        //        comboBoxApartment.Enabled = false;
        //    foreach (VEDataSet.ApartmentRow row in vEDataSet.Apartment)
        //    {
        //        if (row.IsApartmentNameNull()) continue;
        //        list.Add(new CNameIDForComboBox(row.ApartmentID, row.ApartmentName));
        //    }
        //    return list;
        //}


        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;
            int i = box.SelectedIndex;
            if (i > 0 && i <= 12)
            {
                int count = MyFunction.DayCountOfMonth(i);
                foreach (DataGridViewColumn co in dgvShift.Columns)
                {
                    string name = co.Name;
                    if (name.Substring(0, 3).Equals(strDay))
                    {
                        int d = 0;
                        try
                        {
                            d = Convert.ToInt32(name.Substring(3, 2));
                            if (d <= count)
                                co.Visible = true;
                            else co.Visible = false;
                        }
                        catch { }
                    }
                }
            }
        }

        private void dgvShift_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Type type = dgvShift.Columns[e.ColumnIndex].CellType;
            if (type == typeof(DataGridViewCheckBoxCell)) return;
            MessageBox.Show(e.Exception.Message,"DataError!");
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvShift.CurrentRow;
            DataGridViewCell cell=row.Cells["columnShiftID"];
            if (cell==null)
            {
                MessageBox.Show("程式或資料庫版本錯誤, <dgvShift>沒有<columnShiftID>!");
                return;
            }
            if (Convert.IsDBNull(cell.Value))
            {
                cell.Value = Guid.NewGuid();
            }
        }

        private void 儲存SToolStripButton_Click(object sender, EventArgs e)
        {
            if (!this.Validate())
            {
                MessageBox.Show("有資料錯誤, 請改好再存!");
                return;
            }
            this.dgvShift.EndEdit();    // 這行一加,現有RowState一定變成Modified (經查是photo惹的禍)
//            this.dgvShiftDetail.EndEdit();
            VEDataSet.ShiftTableDataTable  table  = (VEDataSet.ShiftTableDataTable )vEDataSet.ShiftTable.GetChanges();
            VEDataSet.ShiftDetailDataTable detail = null;
            //            VEDataSet.ShiftDetailDataTable detail = (VEDataSet.ShiftDetailDataTable)vEDataSet.ShiftDetail.GetChanges();
            if (table == null && detail == null)
            {
                MessageBox.Show("沒有改動任何資料! 不用存");
                return;
            }
            // 設定修改人及修改日期
            if (table != null)
            {
                foreach (VEDataSet.ShiftTableRow r in table)
                    if (r.RowState != DataRowState.Deleted)
                    {
                        r.BeginEdit();
                        r.KeyID = MyFunction.OperatorID;
                        r.LastUpdated = DateTime.Now;
                        r.EndEdit();
                    }
                vEDataSet.ShiftTable.Merge(table);
                try
                {
                    this.shiftTableTableAdapter.Update(this.vEDataSet.ShiftTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ex:" + ex.Message);
                }
                vEDataSet.ShiftTable.AcceptChanges();
            }
        //    if (detail != null)
        //    {
        //        vEDataSet.ShiftDetail.Merge(detail);
        //        this.shiftDetailTableAdapter.Update(vEDataSet.ShiftDetail);
        //        vEDataSet.ShiftDetail.AcceptChanges();
        //    }
        }

        private void dgvShiftDetail_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridViewRow row = e.Row;
            row.Cells["columnID"].Value = Guid.NewGuid();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

      
    }
}
