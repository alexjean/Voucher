using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using MyDataSet = VoucherExpense.DamaiDataSet;
using MyShiftTable = VoucherExpense.DamaiDataSet.ShiftTableDataTable;
using MyShiftDetailTable = VoucherExpense.DamaiDataSet.ShiftDetailDataTable;
using MyShiftAdapter = VoucherExpense.DamaiDataSetTableAdapters.ShiftTableTableAdapter;
using MyShiftRow = VoucherExpense.DamaiDataSet.ShiftTableRow;

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

        MyDataSet m_DataSet = new MyDataSet();
        MyShiftAdapter ShiftAdapter = new MyShiftAdapter();
        private void FormShift_Load(object sender, EventArgs e)
        {
            SetupBindingSource();

            var shiftDetailAdapter  = new VoucherExpense.DamaiDataSetTableAdapters.ShiftDetailTableAdapter();
            var hRAdapter           = new VoucherExpense.DamaiDataSetTableAdapters.HRTableAdapter();
            var operatorAdapter     = new VoucherExpense.DamaiDataSetTableAdapters.OperatorTableAdapter();
            operatorAdapter.Connection.ConnectionString = DB.SqlConnectString(MyFunction.HardwareCfg);

            try
            {
                ShiftAdapter.Fill      (m_DataSet.ShiftTable);
                shiftDetailAdapter.Fill(m_DataSet.ShiftDetail);
                hRAdapter.Fill         (m_DataSet.HR);
                operatorAdapter.Fill   (m_DataSet.Operator);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ex:" + ex.Message);
            }
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

        void SetupBindingSource()
        {
            shiftTableBindingSource.DataSource = m_DataSet;
            hRBindingSource.DataSource = m_DataSet;
            operatorBindingSource.DataSource = m_DataSet;
        }

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
            var  table  = (MyShiftTable )m_DataSet.ShiftTable.GetChanges();
            MyShiftDetailTable detail = null;
            if (table == null && detail == null)
            {
                MessageBox.Show("沒有改動任何資料! 不用存");
                return;
            }
            // 設定修改人及修改日期
            if (table != null)
            {
                foreach (var r in table)
                    if (r.RowState != DataRowState.Deleted)
                    {
                        r.BeginEdit();
                        r.KeyinID = MyFunction.OperatorID;
                        r.LastUpdated = DateTime.Now;
                        r.EndEdit();
                    }
                m_DataSet.ShiftTable.Merge(table);
                try
                {
                    ShiftAdapter.Update(m_DataSet.ShiftTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("更新時出錯,原因:" + ex.Message);
                }
                m_DataSet.ShiftTable.AcceptChanges();
            }
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
            var row = rowView.Row as MyShiftRow;
            if ((!row.IsLockedNull()) && row.Locked)
            {
                MessageBox.Show("己核可無法刪除!");
                return;
            }
            var details = row.GetShiftDetailRows();   
//            var details = from r in m_DataSet.ShiftDetail where r.ShiftID == row.ShiftID select r;
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
            var row = rowView.Row as MyShiftRow;
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
            if (row.RowState != DataRowState.Unchanged)  // 新的Row若不存,在Detail表內存會因為FK設為Cascade而錯誤
                儲存SToolStripButton_Click(null, null);
            Form form = new FormShiftDetail(m_DataSet,row,m_ShiftCodeList);
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

        Config Cfg=new Config();
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
