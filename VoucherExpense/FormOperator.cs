using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;

using MyOperatorRow = VoucherExpense.DamaiDataSet.OperatorRow;
using MyDataSet = VoucherExpense.DamaiDataSet;
using MyOperatorTable = VoucherExpense.DamaiDataSet.OperatorDataTable;

namespace VoucherExpense
{
    public partial class FormOperator : Form
    {
        public FormOperator()
        {
            InitializeComponent();
        }

        MyDataSet m_DataSet = new MyDataSet();
        VoucherExpense.DamaiDataSetTableAdapters.OperatorTableAdapter operatorAdapter = new DamaiDataSetTableAdapters.OperatorTableAdapter();
        VoucherExpense.DamaiDataSetTableAdapters.OperatorAuthListTableAdapter authListAdapter = new DamaiDataSetTableAdapters.OperatorAuthListTableAdapter();

        private void operatorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            var table = MyFunction.SaveCheck<MyOperatorTable>(this, operatorBindingSource, m_DataSet.Operator);
            if (table == null) return;
            foreach (var r in table)
            {
                if (r.RowState == DataRowState.Deleted) continue;
                r.BeginEdit();
                r.LastUpdated = DateTime.Now;
                // 初次密碼設為和帳號相同 
                if (!r.IsPasswordNull())
                {
                    string str = r.Password.ToString().Trim();
                    if (str != "")
                    {
                        r.EndEdit();
                        continue;
                    }
                }
                r.Password = r.LoginName;
                r.EndEdit();
            }
            m_DataSet.Operator.Merge(table);
            this.operatorAdapter.Update(m_DataSet.Operator);
            m_DataSet.Operator.AcceptChanges();
        }
        private void FormOperator_Load(object sender, EventArgs e)
        {
            try
            {
                operatorAdapter.Fill(m_DataSet.Operator);
                authListAdapter.Fill(m_DataSet.OperatorAuthList);
                var apartment = new DamaiDataSetTableAdapters.ApartmentTableAdapter();
                apartment.Fill(m_DataSet.Apartment);
                this.operatorBindingSource.DataSource = m_DataSet;
                MyFunction.SetFieldLength(operatorDataGridView, m_DataSet.Operator);
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入操作員權限錯誤:" + ex.Message);
            }
        }

        string m_LoginName = "LoginName";
        private void operatorDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // 自動產生內碼
            DataGridView view = (DataGridView)sender;
            MyFunction.SetCellMaxNo("OperatorID", view,0);
            DataGridViewRow row = view.CurrentRow;
            object ob=row.Cells[m_LoginName].Value;
            if (ob != null)
                if (!Convert.IsDBNull(ob))
                {
                    string str=((string)ob).Trim();
                    if (str.Length < 5)
                    {
                        MessageBox.Show("登入名太短了! 系統自動加入8888");
                        row.Cells[m_LoginName].Value += "8888";
                        e.Cancel = true;
                    }
                    return;
                }
            MessageBox.Show("必須有登入名稱!");
            e.Cancel = true;
        }

        private void operatorDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
            DataGridView view = (DataGridView)sender;
            string cellName = view.Columns[e.ColumnIndex].Name;
            DataGridViewRow row = view.Rows[e.RowIndex];
            if (cellName == m_LoginName)
            {
                string str = e.FormattedValue.ToString().Trim();
                if (str.Length < 5)
                {
                    MessageBox.Show("登入名太短了! 系統自動加入8888");
                    row.Cells[m_LoginName].Value += "8888";
                    //e.Cancel = true;
                    return;
                }
                for (int i = 0; i < view.Rows.Count; i++)
                {
                    if (i == e.RowIndex) continue;
                    DataGridViewCell c = view.Rows[i].Cells[cellName];
                    if (c.FormattedValue.ToString().Trim() == str)
                    {
                        MessageBox.Show("登入名<" + str + ">和第" + (i + 1).ToString() + "行重複!");
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

/*
        private void operatorDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            string cellName = view.Columns[e.ColumnIndex].Name;
            DataGridViewRow row = view.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells[e.ColumnIndex];
            if (cellName == "IsSuper")
            {
                if (cell.Value==null) return;
                if (Convert.IsDBNull(cell.Value)) return;
                bool isSuper=(bool)cell.Value;
                if (!isSuper) return;
                foreach(DataGridViewCell c in row.Cells) c.ReadOnly=true;
                try
                {
                    cell=row.Cells["OperatorID"];
                    int id = (int)cell.Value;
                    if (id == MyFunction.OperatorID)
                        row.Cells["LoginName"].ReadOnly = false;
                }
                catch{}
                return;
            }
        }
*/

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyFunction.AddNewItem(operatorDataGridView, "operatorID", "operatorID", m_DataSet.Operator);
            DataGridViewRow row = operatorDataGridView.CurrentRow;
            row.Cells["LoginName"].Value = "Name" + row.Cells["operatorID"].Value.ToString();
        }

        string BtnName = "BtnAuthorizedList";
        private void operatorDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view=(DataGridView)sender;
            if (view.Columns[e.ColumnIndex].Name != BtnName) return;
            DataGridViewRow row=view.Rows[e.RowIndex];
            DataGridViewCell cell=row.Cells["OperatorID"];
            if (cell.ValueType != typeof(int))
            {
                MessageBox.Show("程式錯誤! DataGridView里的OperatorID不是int.請找碼農!");
                return;
            }
            FormOperatorAuthList form = new FormOperatorAuthList((int)cell.Value,m_DataSet);
            form.ShowDialog();

        }

        private void operatorDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            foreach (DataGridViewRow row in view.Rows)
            {
                DataGridViewCell cell;
                int operatorID;
                try
                {
                    cell = row.Cells[BtnName];
                    operatorID = (int)(row.Cells["OperatorID"].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("程式錯誤在 DataGridView_DataBindingComplete, 請找碼農.訊息<"+ex.Message+">");
                    return;
                }
                if (cell.GetType() != typeof(DataGridViewButtonCell))
                {
                    MessageBox.Show("程式錯誤! DataGridView.Columns[" + BtnName + "] 不是ButtonCell!請找碼農");
                    return;
                }
                DataGridViewButtonCell btnCell = (DataGridViewButtonCell)cell;
                var authList = from auth in m_DataSet.OperatorAuthList where auth.OperatorID == operatorID select auth;
                if (authList.Count() > 0)
                {
                    string str="";
                    int apID = authList.First().ApartmentID;
                    var ap=m_DataSet.Apartment.FindByApartmentID(apID);
                    if (ap != null) str = ap.ApartmentName.Trim();
                    if (authList.Count() == 1)
                         btnCell.Value = str;
                    else btnCell.Value = str+"(" + authList.Count().ToString() + ")";
                }
            }
        }
    }
}