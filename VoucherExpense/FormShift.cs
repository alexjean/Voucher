using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

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

        public class CCodeForCombo
        {
            public char Code { get; set; }
            public CCodeForCombo(char code)
            {
                Code = code;
            }
        }

        public class CHourForCombo
        {
            public int Hour { get; set; }
            public CHourForCombo(int hour)
            {
                Hour = hour;
            }
        }


        List<CMonthForCombo> m_MonthList = new List<CMonthForCombo>();
        List<CCodeForCombo>  m_CodeList  = new List<CCodeForCombo>();
        List<CHourForCombo>  m_HourList  = new List<CHourForCombo>();
        List<CShiftCode> m_ShiftCodeList = new List<CShiftCode>();
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

            m_CodeList.Add(new CCodeForCombo(' '));
            for (char c = 'A'; c <= 'Z'; c++) m_CodeList.Add(new CCodeForCombo(c));
            cCodeForComboBindingSource.DataSource = m_CodeList;

            for (int h=0;h<16; h++) m_HourList.Add(new CHourForCombo(h));
            cHourForComboBindingSource.DataSource = m_HourList;

            LoadCfg();
            cShiftCodeBindingSource.DataSource = m_ShiftCodeList;

            columnLocked.ReadOnly = !MyFunction.LockHR;
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
                        r.KeyinID = MyFunction.OperatorID;
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
                    MessageBox.Show("更新時出錯,原因:" + ex.Message);
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

        //private void dgvShiftDetail_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        //{
        //    DataGridViewRow row = e.Row;
        //    row.Cells["columnID"].Value = Guid.NewGuid();
        //    row.Cells["ColumnTableMonth"].Value = 0;
        //}

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            // 檢查是否有子表
            if (dgvShift.SelectedCells.Count <= 0) return;
            DataGridViewRow dgvRow = dgvShift.SelectedCells[0].OwningRow;
            DataRowView     rowView=dgvRow.DataBoundItem as DataRowView;   // 指到BindingSource
            VEDataSet.ShiftTableRow row = rowView.Row as VEDataSet.ShiftTableRow;
            if (row.Locked)
            {
                MessageBox.Show("己核可無法刪除!");
                return;
            }
            VEDataSet.ShiftDetailRow[] details = row.GetShiftDetailRows();
            if (details.Count() != 0)
            {
                MessageBox.Show("此班表己經有員工,不能刪除!");
            }
            else
            {
                string msg="";
                if (!row.IsTableMonthNull()) msg=row.TableMonth.ToString()+"月";
                if (!row.IsTableNameNull())  msg+="<"+row.TableName+">";
                if (MessageBox.Show("確定刪除" + msg, "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    shiftTableBindingSource.RemoveCurrent();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvShift.SelectedCells.Count<=0)
            {
                MessageBox.Show("請選擇要編修的表!");
                return;
            }
            DataGridViewRow dgvRow = dgvShift.SelectedCells[0].OwningRow;
            DataRowView rowView = dgvRow.DataBoundItem as DataRowView;
            VEDataSet.ShiftTableRow row = rowView.Row as VEDataSet.ShiftTableRow;
            if (row.IsTableMonthNull() || row.TableMonth<1)
            {
                MessageBox.Show("請設定月份!");
                return;
            }
            if (row.IsTableNameNull() || row.TableName.Trim().Length==0)
            {
                MessageBox.Show("請輸入該表名稱!");
                return;
            }
            Form form = new FormShiftDetail(vEDataSet,row,m_ShiftCodeList);
            form.ShowDialog();
        }

        private void dgvConfigShiftCode_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridViewRow vr = e.Row;
            if (vr == null) return;
            vr.Cells["columnHour"].Value = 0;
            vr.Cells["columnCode"].Value = ' ';
            vr.Cells["columnNote"].Value = "";
        }

        private void btnSaveCodeConfig_Click(object sender, EventArgs e)
        {
            string str=Config2Xml(ShiftCodeTableName);
            Cfg.Save(ShiftCodeConfigName,ShiftCodeTableName,str);
        }

        Config Cfg = new Config();
        string ShiftCodeConfigName = "ShiftCodeConfig";
        string ShiftCodeTableName = "CodeTable";
        private string Config2Xml(string name)
        {
            StringBuilder xml = new StringBuilder("<" + ShiftCodeConfigName + " Name=\"" + name + "\">", 512);
            foreach (CShiftCode sc in m_ShiftCodeList)
            {
                xml.Append("<CodeConfig Code=\""+sc.Code+"\" Note=\""+sc.Note+"\" Hour=\""+sc.Hour.ToString()+"\" />");
            }
            xml.Append("</"+ShiftCodeConfigName+">");
            return xml.ToString();
        }

        void LoadCfg()
        {
            XmlNode list = Cfg.Load(ShiftCodeConfigName,ShiftCodeTableName);
            if (list == null) return;
            m_ShiftCodeList.Clear();
            foreach (XmlNode node in list)
            {
                XmlAttribute code = node.Attributes["Code"];
                if (code == null) continue;
                XmlAttribute hour = node.Attributes["Hour"];
                if (hour == null) continue;
                XmlAttribute note = node.Attributes["Note"];
                CShiftCode shiftCode=new CShiftCode();
                char co;
                if (char.TryParse(code.Value, out co))
                    shiftCode.Code = co;
                int hr;
                if (int.TryParse(hour.Value, out hr)) shiftCode.Hour = hr;
                if (note != null) shiftCode.Note = note.Value;
                m_ShiftCodeList.Add(shiftCode);
            }
        }


    
      
    }
}
