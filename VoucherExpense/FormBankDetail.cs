using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
#if UseSQLServer
using MyDataSet = VoucherExpense.DamaiDataSet;
using MyBankDetailTable = VoucherExpense.DamaiDataSet.BankDetailDataTable;
using MyBankDetailAdapter = VoucherExpense.DamaiDataSetTableAdapters.BankDetailTableAdapter;
#else
using MyDataSet = VoucherExpense.VEDataSet;
using MyBankDetailTable = VoucherExpense.VEDataSet.BankDetailDataTable;
using MyBankDetailAdapter = VoucherExpense.VEDataSetTableAdapters.BankDetailTableAdapter;
#endif

namespace VoucherExpense
{
    public partial class FormBankDetail : Form
    {
        class BankDefault
        {
            public string BankCode;
            public string DefaultCode;
            public AccTitle DefaultTitle;
            public decimal InitialValue=0;
            public BankDefault(string bankCode, string defaultCode) { BankCode = bankCode; DefaultCode = defaultCode; }
        }
        Dictionary<int, BankDefault> BankDictionary=new Dictionary<int,BankDefault>();
        TitleSetup Setup = new TitleSetup();

        public FormBankDetail()
        {
            InitializeComponent();
        }

        MyDataSet m_DataSet = new MyDataSet();
        MyBankDetailAdapter bankDetailAdapter=new MyBankDetailAdapter();
        private void FormBankDetail_Load(object sender, EventArgs e)
        {
            SetupBindingSource();
#if UseSQLServer
            var bankAccountAdapter      = new VoucherExpense.DamaiDataSetTableAdapters.BankAccountTableAdapter();
            var accountingTitleAdapter  = new VoucherExpense.DamaiDataSetTableAdapters.AccountingTitleTableAdapter();
#else
            var bankAccountAdapter      = new VoucherExpense.VEDataSetTableAdapters.BankAccountTableAdapter();
            var accountingTitleAdapter  = new VoucherExpense.VEDataSetTableAdapters.AccountingTitleTableAdapter();
            bankAccountAdapter.Connection      = MapPath.VEConnection;
            accountingTitleAdapter.Connection  = MapPath.VEConnection;
            bankDetailAdapter.Connection       = MapPath.VEConnection;
#endif

            bankAccountAdapter.Fill(m_DataSet.BankAccount);
            accountingTitleAdapter.Fill(m_DataSet.AccountingTitle);
            bankDetailAdapter.Fill(m_DataSet.BankDetail);
            //accountingTitleBindingSource.Filter = 
            //    "(TitleCode like '1*' or TitleCode like '2*')";
            int btm = bankDetailBindingNavigator.Bottom + 5;
            bankDetailDataGridView.Top = btm - Top;
            bankDetailDataGridView.Height = Height - bankDetailDataGridView.Top - 5;

            calendar.MaxDate = new DateTime(MyFunction.IntHeaderYear, 12, 31);
            calendar.MinDate = new DateTime(MyFunction.IntHeaderYear, 1, 1);

            MakeBankAccountComboBox();

            List<AccTitle> AssetList = new List<AccTitle>();
            foreach (var r in m_DataSet.AccountingTitle)
            {
                if (r.TitleCode.Length == 0) continue;
                AccTitle item = new AccTitle(r.TitleCode, r.Name);
                if (r.IsInitialValueNull())
                    item.Money = 0;
                else
                    item.Money = r.InitialValue;
                char c = r.TitleCode[0];
                if (c == '1') AssetList.Add(item);
            }

            foreach (var r in m_DataSet.BankAccount)
            {
                BankDictionary.Add(r.ID, new BankDefault(r.AccountTitleCode, r.DefaultTitleCode));
            }

            AccTitle defaultAsset = Find(Setup.DefaultAsset, AssetList, null);
            foreach (KeyValuePair<int, BankDefault> pair in BankDictionary)
            {
                BankDefault bank = pair.Value;
                bank.DefaultTitle = Find(bank.DefaultCode, AssetList, defaultAsset);
                AccTitle title = Find(bank.BankCode, AssetList, defaultAsset);
                if (title != null)
                    bank.InitialValue = title.Money;
            }

            if (cbSelectBank.Items.Count > 1)
                cbSelectBank.SelectedIndex = cbSelectBank.Items.Count - 1;
            if (MyFunction.LockAll)
                bankDetailDataGridView.ReadOnly = true;

        }

        private void bankDetailBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (MyFunction.LockAll)
            {
                MessageBox.Show("鎖定中,不能存檔");
                return;
            }
            this.Validate();
            this.bankDetailBindingSource.EndEdit();
            var table = (MyBankDetailTable)m_DataSet.BankDetail.GetChanges();
            if (table==null || table.Count == 0)
            {
                MessageBox.Show("沒有修改,不需要存!");
                return;
            }
            bankDetailAdapter.Update(table);
            m_DataSet.BankDetail.AcceptChanges();
        }

        void SetupBindingSource()
        {
            bankDetailBindingSource.DataSource      = m_DataSet;
            accountingTitleBindingSource.DataSource = m_DataSet;
            bankAccountBindingSource.DataSource     = m_DataSet;
        }

        AccTitle Find(string code, List<AccTitle> table, AccTitle defaultTitle)
        {
            foreach (AccTitle r in table)
            {
                if (code == r.Code) return r;
            }
            return defaultTitle;
        }

        private void MakeBankAccountComboBox()
        {
            List<CBankAccountForComboBox> list = new List<CBankAccountForComboBox>();
            CBankAccountForComboBox acc = new CBankAccountForComboBox();
            acc.Name = "全部";
            list.Add(acc);
            foreach (var r in m_DataSet.BankAccount)
            {
                if (r.ID != 1)   // ID 1是給零用金的特殊帳號
                {
                    acc = new CBankAccountForComboBox();
                    acc.Name = r.ShowName;
                    acc.ID = r.ID;
                    list.Add(acc);
                }
            }
            cbSelectBank.DataSource = list;
        }



        private void bankDetailDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            DataGridViewCell cell = view.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.ValueType != typeof(DateTime)) return;
            DateTime day;
            if (cell.Value == null || cell.Value == DBNull.Value)
            {
                if (DateTime.Now.Year == MyFunction.IntHeaderYear)
                    day = DateTime.Now;
                else
                    day = new DateTime(MyFunction.IntHeaderYear, 12, 31);
            }
            else
                day = (DateTime)cell.Value;
            calendar.TodayDate = day;
            calendar.Visible = true;
            calendar.BringToFront();
        }

        string DayFilter = null;
        string BankFilter = null;
        void SetFilter(string day, string bank)
        {
            string filter;
            if (day == null && bank == null) filter = "";
            else if (day == null)            filter = bank;
            else if (bank == null)           filter = day;
            else                             filter = day + " And " + bank;
            bankDetailBindingSource.Filter = filter;
//            CalcTotal();
        }


        private void cbSelectBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            int id;
            try
            {
                id = (int)box.SelectedValue;
            }
            catch
            {
                MessageBox.Show("資料庫或程式出錯! 找不到BankID!");
                return;
            }
            if (id == 0)
                BankFilter = null;   // 全部
            else 
                BankFilter = "(BankID=" + id.ToString() + ")";       // 這裏有風險 , BankID跳號不依序,均會出錯
            checkBoxSort.Checked = true;
            SetFilter(DayFilter, BankFilter);
            bankDetailDataGridView.Focus();
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            int month = box.SelectedIndex;
            if (month == 0)
                DayFilter = null;
            else
            {
                if (month < 1 || month > 12) return;
                string toStr = MyFunction.DayCountOfMonth(month).ToString("d2");
                string y = "#" + MyFunction.HeaderYear + "/";
                string m1, m2;
                m1 = y + month.ToString("d2") + "/01#";
                m2 = y + month.ToString("d2") + "/" + toStr + "#";
                DayFilter = "(Day>=" + m1 + ") AND (Day<=" + m2 + ")";
            }
            SetFilter(DayFilter, BankFilter);
            bankDetailDataGridView.Focus();
        }

        private void calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            calendar.Visible = false;
            DataGridView view = bankDetailDataGridView;
            DataGridViewCell cell = view.CurrentRow.Cells["columnDay"];
            DateTime day = calendar.SelectionStart;
            if (day.Year != MyFunction.IntHeaderYear)
                day = new DateTime(MyFunction.IntHeaderYear, 12, 31);
            cell.Value = calendar.SelectionStart;
            view.InvalidateCell(cell);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (MyFunction.LockAll)
                MessageBox.Show("鎖定中,新增無用");
            if (checkBoxSort.Checked)
                checkBoxSort.Checked = false;
            MyFunction.AddNewItem(bankDetailDataGridView, "columnID", "ID", m_DataSet.BankDetail);
            DataGridViewRow row = bankDetailDataGridView.CurrentRow;
            DataGridViewCell cell = row.Cells["columnAccount"];
            if (cbSelectBank.SelectedIndex < 1)   // 第一個是 全部
            {
                MessageBox.Show("未選戶頭! 己預設");
                cell.Value = 2;
                return;
            }
            cell.Value = cbSelectBank.SelectedValue;
        }

        bool IsDataWrong(Type type, object val)
        {
            if (val == null) return true;
            if (Convert.IsDBNull(val)) return true;
            if (val.GetType() != type) return true;
            return false;
        }


        void CalcTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow r in bankDetailDataGridView.Rows)
            {
                DataGridViewCell cell = r.Cells["columnMoney"];
                if (IsDataWrong(typeof(decimal), cell.Value)) continue;
                bool IsPay = false;
                DataGridViewCell cellIsPay = r.Cells["columnIsCredit"];
                if (!IsDataWrong(typeof(bool), cellIsPay.Value))
                    if ((bool)cellIsPay.Value == true) IsPay = true;
                if (IsPay) total -= (decimal)cell.Value;
                else       total += (decimal)cell.Value;
            }
            DataGridViewColumn col = bankDetailDataGridView.Columns["columnMoney"];
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            col.HeaderCell.Value = total.ToString("f2");
        }

        private void bankDetailDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void checkBoxSort_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            if (box.Checked)
                bankDetailBindingSource.Sort="Day";
            else
                bankDetailBindingSource.RemoveSort();
        }

        bool ValueValid(DataGridViewCell cell)
        {
            object obj = cell.Value;
            if (obj == null) return false;
            if (obj == DBNull.Value) return false;
            return true;
        }

        private void bankDetailDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView view=sender as DataGridView;
            decimal total=0,val;
            bool isPay;
            
            try
            {
                int index=cbSelectBank.SelectedIndex;
                if (index < 0) return;   // 剛開始進來,不用算

                if (index == 0)
                {
                    foreach (KeyValuePair<int, BankDefault> pair in BankDictionary)
                        total += pair.Value.InitialValue;
                }
                else
                {
                    index = (int)cbSelectBank.SelectedValue;
                    BankDefault found;
                    if (BankDictionary.TryGetValue(index, out found))
                        total += found.InitialValue;
                }
                for (int i = 0; i < view.Rows.Count; i++)
                {
                    DataGridViewRow curr = view.Rows[i];
                    DataGridViewCell cell=curr.Cells["columnIsCredit"];
                    if (ValueValid(cell))
                        isPay = (bool)cell.Value;
                    else
                        isPay = false;
                    cell=curr.Cells["columnMoney"];
                    if (ValueValid(cell))
                        val = (decimal)cell.Value;
                    else
                        val = 0;
                    if (isPay) val = -val;
                    total += val;
                    curr.Cells["columnTotal"].Value = total;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("發生違例<"+ex.Message+">! 可能資料庫與程式版本不合!");
            }
        }

        private void bankDetailDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            DataGridViewRow row = view.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells["columnIsCredit"];
            if (cell.ValueType != typeof(bool)) return;    // 不應該
            bool isPay = false;
            if (cell.Value != null && cell.Value != DBNull.Value)
                isPay = (bool)cell.Value;
            Color color;
            if (isPay)
                color = Color.Red;
            else
                color = Color.Black;
            row.DefaultCellStyle.ForeColor = color;
        }

        //private void FormBankDetail_SizeChanged(object sender, EventArgs e)
        //{
        //    int top;
        //    top= bankDetailBindingNavigator.Bottom +7;
        //    bankDetailDataGridView.Height = ClientRectangle.Height - top ;
        //}
    }
}
