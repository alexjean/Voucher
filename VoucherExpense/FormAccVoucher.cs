using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VoucherExpense
{
    public partial class FormAccVoucher : Form
    {

        bool CheckMode;

        public FormAccVoucher(bool checkMode)
        {
            CheckMode = checkMode;
            InitializeComponent();
        }

        private void accVoucherBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (MyFunction.LockAll)
            {
                MessageBox.Show("鎖定中,不能存檔");
                return;
            }
            if (!this.Validate())
            {
                MessageBox.Show("有資料錯誤, 請改好再存!");
                return;
            }
            this.accVoucherBindingSource.EndEdit();
            VEDataSet.AccVoucherDataTable table = (VEDataSet.AccVoucherDataTable)vEDataSet.AccVoucher.GetChanges();
            if (table == null || table.Rows.Count <= 0)
            {
                MessageBox.Show("沒有改變,無需存檔!");
                return;
            }
            if (!CheckMode)
                foreach (VEDataSet.AccVoucherRow r in table)
                {
                    if (r.RowState != DataRowState.Deleted)
                    {
                        r.BeginEdit();
                        r.KeyinID = MyFunction.OperatorID;
                        r.LastUpdated = DateTime.Now;
                        r.EndEdit();
                    }
                }

            vEDataSet.AccVoucher.Merge(table);
            accVoucherTableAdapter.Update(vEDataSet.AccVoucher);
            vEDataSet.AccVoucher.AcceptChanges();
            MessageBox.Show("己存檔!");
        }

        private void FormAccVoucher_Load(object sender, EventArgs e)
        {
            // 將預設的Connection指到我要重定的位置
            employeeTableAdapter.Connection        = MapPath.VEConnection;
            operatorTableAdapter.Connection        = MapPath.VEConnection;
            accountingTitleTableAdapter.Connection = MapPath.VEConnection;
            accVoucherTableAdapter.Connection      = MapPath.VEConnection;


            this.employeeTableAdapter.Fill(this.vEDataSet.Employee);
            this.operatorTableAdapter.Fill(this.vEDataSet.Operator);
            this.accountingTitleTableAdapter.Fill(this.vEDataSet.AccountingTitle);
            this.accVoucherTableAdapter.Fill(this.vEDataSet.AccVoucher);

            dateTimePicker1.MaxDate = new DateTime(MyFunction.IntHeaderYear, 12, 31);
            dateTimePicker1.MinDate = new DateTime(MyFunction.IntHeaderYear, 1, 1);

            if (CheckMode)
            {
                this.Text = "傳票查核";
                blockEdit();
                columnCheck.ReadOnly = false;    // DataGridView裏的columnCheck
                ckBoxAllowEdit.Visible = true;
            }
            else
                ckBoxAllowEdit.Visible = false;

            if (MyFunction.LockAll)
            {
                blockEdit();
                ckBoxAllowEdit.Visible = false;
            }
        }

        void SetDebtCredit(bool IsDebt,Button btn, TextBox box)
        {
            if (IsDebt)
            {
                btn.Text = "借  ";
                box.Left = labelDebt.Left;
            }
            else
            {
                btn.Text = "　貸";
                box.Left = labelCredit.Left;
            }
        }

        void SetAllDebtCreditBtn(VEDataSet.AccVoucherRow row)
        {
            SetDebtCredit(row.IsDebt0, btnCD0, money0TextBox);
            SetDebtCredit(row.IsDebt1, btnCD1, money1TextBox);
            SetDebtCredit(row.IsDebt2, btnCD2, money2TextBox);
            SetDebtCredit(row.IsDebt3, btnCD3, money3TextBox);
        }

        private void accVoucherBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            DataRowView view =(DataRowView)accVoucherBindingSource.Current;
            if (view == null) return;
            VEDataSet.AccVoucherRow row = (VEDataSet.AccVoucherRow)view.Row;
            if (row.IsIsDebt0Null()) return;   // 不應該發生,在AddNew時應該設上去, 如同ID要先設
            SetAllDebtCreditBtn(row);
            CalcTotal(row);
        }

        private void btnCD0_Click(object sender, EventArgs e)
        {
            DataRowView view = (DataRowView)accVoucherBindingSource.Current;
            if (view == null) return;
            VEDataSet.AccVoucherRow row = (VEDataSet.AccVoucherRow)view.Row;
            row.IsDebt0 = !row.IsDebt0;                         // new Row時會出問題
            SetDebtCredit(row.IsDebt0, btnCD0, money0TextBox);
            CalcTotal(row);
        }

        private void btnCD1_Click(object sender, EventArgs e)
        {
            DataRowView view = (DataRowView)accVoucherBindingSource.Current;
            if (view == null) return;
            VEDataSet.AccVoucherRow row = (VEDataSet.AccVoucherRow)view.Row;
            row.IsDebt1 = !row.IsDebt1;
            SetDebtCredit(row.IsDebt1, btnCD1, money1TextBox);
            CalcTotal(row);
        }

        private void btnCD2_Click(object sender, EventArgs e)
        {
            DataRowView view = (DataRowView)accVoucherBindingSource.Current;
            if (view == null) return;
            VEDataSet.AccVoucherRow row = (VEDataSet.AccVoucherRow)view.Row;
            row.IsDebt2 = !row.IsDebt2;
            SetDebtCredit(row.IsDebt2, btnCD2, money2TextBox);
            CalcTotal(row);
        }

        private void btnCD3_Click(object sender, EventArgs e)
        {
            DataRowView view = (DataRowView)accVoucherBindingSource.Current;
            if (view == null) return;
            VEDataSet.AccVoucherRow row = (VEDataSet.AccVoucherRow)view.Row;
            row.IsDebt3 = !row.IsDebt3;
            SetDebtCredit(row.IsDebt3, btnCD3, money3TextBox);
            CalcTotal(row);
        }

        private void accVoucherDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            DataGridViewRow row = view.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells["columnRemoved"];
            if (cell.ValueType != typeof(bool)) return;    // 不應該
            bool removed = false;
            if (cell.Value != null && cell.Value != DBNull.Value)
                removed = (bool)cell.Value;
            Color color;
            if (removed)
                color = Color.DarkCyan;
            else if ((e.RowIndex % 2) != 0)
                color = Color.Azure;
            else
                color = Color.White;
            row.DefaultCellStyle.BackColor = color;
            color = Color.Black;
            if (!removed)
            {
                string code = "";
                cell = row.Cells["TitleCode"];
                if (cell.ValueType == typeof(string))
                {
                    if (cell.Value != null && cell.Value != DBNull.Value)
                        code = cell.Value as string;
                    if (code.Length >= 1)
                    {
                        if (code[0] == '1')
                            color = Color.Red;
                        else if (code[0] == '2')    // 負債是貸方科目,減少用紫色
                            color = Color.Purple;
                    }
                }
            }
            row.DefaultCellStyle.ForeColor = color;
        }

        void CalcTotal(VEDataSet.AccVoucherRow row)
        {
            decimal debt = 0m,credit = 0m;
            if (!row.IsMoney0Null())
            {
                if (row.IsDebt0) debt += row.Money0; else credit += row.Money0;
            }
            if (!row.IsMoney1Null())
            {
                if (row.IsDebt1) debt += row.Money1; else credit += row.Money1;
            }
            if (!row.IsMoney2Null())
            {
                if (row.IsDebt2) debt += row.Money2; else credit += row.Money2;
            }
            if (!row.IsMoney3Null())
            {
                if (row.IsDebt3) debt += row.Money3; else credit += row.Money3;
            }
            labelCreditTotal.Text = credit.ToString();
            labelDebtTotal.Text = debt.ToString();
            if (credit != debt)
            {
                labelDebtTotal.ForeColor = Color.Red;
                labelCreditTotal.ForeColor = Color.Red;
            }
            else
            {
                labelDebtTotal.ForeColor = SystemColors.ControlText;
                labelCreditTotal.ForeColor = SystemColors.ControlText;
            }
        }

        private void FormAccVoucher_Validating(object sender, CancelEventArgs e)
        {
            if (labelCreditTotal.ForeColor == Color.Red)
            {
                e.Cancel = true;
                MessageBox.Show("借貸金額不平衡!");
            }
        }

        object DebtTotal(VEDataSet.AccVoucherRow row)
        {
            if (row.IsIsDebt0Null()) return null;  
            decimal debt = 0m, credit = 0m;
            if (!row.IsMoney0Null() && !row.IsTitleCode0Null())
            {
                if (row.IsDebt0) debt += row.Money0; else credit += row.Money0;
            }
            if (!row.IsMoney1Null() && !row.IsTitleCode1Null())
            {
                if (row.IsDebt1) debt += row.Money1; else credit += row.Money1;
            }
            if (!row.IsMoney2Null() && !row.IsTitleCode2Null())
            {
                if (row.IsDebt2) debt += row.Money2; else credit += row.Money2;
            }
            if (!row.IsMoney3Null() && !row.IsTitleCode3Null())
            {
                if (row.IsDebt3) debt += row.Money3; else credit += row.Money3;
            }
            if (credit != debt)
                return null;
            return debt;
        }

        VEDataSet.AccVoucherRow GetAccVoucherRow(DataGridViewRow vr)
        {
            if (vr == null) return null;
//            if (vr.IsNewRow) return null;   // NewRow 沒有DataBoundItem
            object obj;
            try
            {
                obj = vr.DataBoundItem;
            }
            catch(Exception ex)
            {
                string str = ex.Message;
                return null;
            }
            if (obj == null) return null;
            DataRowView rowView = (DataRowView)obj;
            if (rowView == null) return null;
            return ((VEDataSet.AccVoucherRow)rowView.Row);
        }

        private void accVoucherDataGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            if (e.ColumnIndex == view.Columns["columnTotal"].Index)
            {
                if (view.Rows.Count > e.RowIndex)
                {
                    VEDataSet.AccVoucherRow row = GetAccVoucherRow(view.Rows[e.RowIndex]);
                    if (row != null)
                    {
                        e.Value = DebtTotal(row);
                        return;
                    }
                }
                e.Value = null;
                return;
            }
        }

        private void accVoucherDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            if (e.RowIndex >= view.Rows.Count) return;
            DataGridViewRow vr = view.Rows[e.RowIndex];
            VEDataSet.AccVoucherRow row = GetAccVoucherRow(vr);
            if (row == null) return;
            object val= DebtTotal(row);
            if ( val== null)
            {
                int columnIndex = view.Columns["columnTotal"].Index;
                DataGridViewCell cell = vr.Cells[columnIndex];
                cell.Value = val;
                view.UpdateCellValue(columnIndex, e.RowIndex);
                MessageBox.Show("單号<" + row.ID.ToString() + ">借貸不平衡!");
            }
        }

 

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (MyFunction.LockAll)
            {
                MessageBox.Show("鎖定中,新增無用");
            }
            int m = MyFunction.MaxNoInDB("ID", vEDataSet.AccVoucher);
            MyFunction.SetCellMaxNo("columnID", accVoucherDataGridView, m);
            int month = comboBoxMonth.SelectedIndex;
            int mon;
            if (month >= 1 && month <= 12) mon = month;
            else mon = DateTime.Now.Month;
            DateTime t = new DateTime(DateTime.Now.Year, mon, MyFunction.DayCountOfMonth(mon));
            DataGridViewRow row = accVoucherDataGridView.CurrentRow;
            // DataGridView和textBox都設定, 以免日期是空白,日期排序,會跑到最前面
            row.Cells["columnAccVoucherTime"].Value = accVoucherTimeTextBox.Text = t.ToShortDateString();
            try
            {
                DataRowView rv = row.DataBoundItem as DataRowView;
                VEDataSet.AccVoucherRow d = (VEDataSet.AccVoucherRow)rv.Row;
                d.IsDebt0 = true;       
                d.IsDebt1 = d.IsDebt2 = d.IsDebt3 = false;
                SetAllDebtCreditBtn(d);
                CalcTotal(d);
            }
            catch { }

            
            MessageBox.Show("日期己暫時設定, 請設成正確日期!");
            lockedCheckBox.Checked = false;
        }

        // 在DataGridView中 ,沒有Inital的值,在此設定
        private void accVoucherBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            BindingSource binding = sender as BindingSource;
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;

            int month = box.SelectedIndex;
            if (month == 0)
            {
                this.accVoucherBindingSource.Filter = null;
                this.accVoucherDataGridView.Focus();
                return;
            }
            if (month < 1 || month > 12) return;
            SetDayFilter(month, 1, MyFunction.DayCountOfMonth(month));           
            this.accVoucherDataGridView.Focus();
        }

        private void SetDayFilter(int month, int from, int to)
        {
            string y = "#" + MyFunction.HeaderYear + "/";
            string m1, m2;
            m1 = y + month.ToString("d2") + "/" + from.ToString("d2") + "#";
            m2 = y + month.ToString("d2") + "/" + to.ToString("d2") + "#";
            string Filter = "(AccVoucherTime>=" + m1 + ") AND (AccVoucherTime<=" + m2 + ")";
            accVoucherBindingSource.Filter = Filter;
        }


        private void SetBackColor(Color Co)
        {
            this.BackColor = Co;
            this.iDTextBox.BackColor = Co;
            this.lastUpdatedLabel.BackColor = Co;
        }

        AlphaPanel alphapanel = null;
        private void blockEdit()
        {
            if (alphapanel == null)
            {
                int x = accVoucherDataGridView.Right;
                int y = this.accVoucherIDLabel.Top;
                int width = this.Right - x;
                int height = this.Bottom - y;
                alphapanel = new AlphaPanel();
                alphapanel.Location = new Point(x, y);
                alphapanel.Size = new Size(width, height);
                this.Controls.Add(alphapanel);
            }
            SetBackColor(Color.Azure);
            alphapanel.BringToFront();
        }

        private void unblockEdit()
        {
            if (alphapanel == null) return;
            SetBackColor(Color.FromArgb(216, 228, 248));
            this.Controls.Remove(alphapanel);
            alphapanel = null;
        }

        private void ckBoxAllowEdit_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            if (box.Checked)
                unblockEdit();
            else
                blockEdit();
        }

        private void lockedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MyFunction.LockAll) return;
            if (CheckMode)
            {
                if (!ckBoxAllowEdit.Checked)
                    return;
            }
            CheckBox check = sender as CheckBox;
            if (check.CheckState == CheckState.Checked) blockEdit();
            else unblockEdit();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MyFunction.LockAll)
            {
                MessageBox.Show("鎖定中,不可刪除!");
                return;
            }

        }

        private void accVoucherDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (CheckMode)
                ckBoxAllowEdit.Checked = false;
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            DateTimePicker picker = sender as DateTimePicker;
            this.accVoucherTimeTextBox.Text = picker.Text;
        }

     




    }
}
