using System;
using System.Data;
using System.Windows.Forms;

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
            operatorBindingSource.DataSource = m_DataSet;
            try
            {
                this.operatorAdapter.Fill(m_DataSet.Operator);
                this.authListAdapter.Fill(m_DataSet.OperatorAuthList);
                this.operatorBindingSource.DataSource = m_DataSet;
                MyFunction.SetFieldLength(operatorDataGridView, m_DataSet.Operator);
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入操作員權限錯誤:" + ex.Message);
            }
        }

        private void operatorDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // 自動產生內碼
            DataGridView view = (DataGridView)sender;
            MyFunction.SetCellMaxNo("OperatorID", view,0);
            DataGridViewRow row = view.CurrentRow;
            object ob=row.Cells["LoginName"].Value;
            if (ob != null)
                if (!Convert.IsDBNull(ob))
                {
                    string str=((string)ob).Trim();
                    if (str.Length < 5)
                    {
                        MessageBox.Show("登入名太短了!");
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
            if (cellName == "LoginName")
            {
                string str = e.FormattedValue.ToString().Trim();
                if (str.Length < 5)
                {
                    MessageBox.Show("登入名太短了! 系統自動加入8888");
                    row.Cells[cellName].Value += "8888";
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
            MessageBox.Show(e.RowIndex.ToString()+" OperatorID="+cell.Value.ToString());
        }

        private void operatorDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            foreach (DataGridViewRow row in view.Rows)
            {
                DataGridViewCell cell;
                try {  cell = row.Cells[BtnName];  }
                catch (Exception ex)
                {
                    MessageBox.Show("程式錯誤! DataGridView.Columns[" + BtnName + "] 找不到!請找碼農.訊息<"+ex.Message+">");
                    return;
                }
                if (cell.GetType() != typeof(DataGridViewButtonCell))
                {
                    MessageBox.Show("程式錯誤! DataGridView.Columns[" + BtnName + "] 不是ButtonCell!請找碼農");
                    return;
                }
                DataGridViewButtonCell btnCell = (DataGridViewButtonCell)cell;
                btnCell.Value = row.Cells["OperatorID"].Value.ToString();
            }
        }
    }
}