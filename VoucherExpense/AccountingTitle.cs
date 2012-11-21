using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VoucherExpense
{
    public partial class AccountingTitle : Form
    {
        public AccountingTitle()
        {
            InitializeComponent();
        }

        private void accountingTitleBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (MyFunction.LockAll)
            {
                MessageBox.Show("鎖定中,不能存檔");
                return;
            }
            // 因為可以只編名稱,沒填代碼,又不能加在RowValidating (在刪除時,index會放在新row會出錯)
/*
            string error = "";
            DataGridView view = (DataGridView)this.accountingTitleDataGridView;
            for(int i=0;i<view.Rows.Count;i++)
            {
                DataGridViewRow row=view.Rows[i];
                if (!ValidateTitleCode(row.Cells["TitleCode"].FormattedValue, out error))
                {
                    MessageBox.Show("第" + (i+1).ToString() + "行" + error);
                    return;
                }
            }
*/
            VEDataSet.AccountingTitleDataTable table = MyFunction.SaveCheck<VEDataSet.AccountingTitleDataTable>(
                                                              this, accountingTitleBindingSource, vEDataSet.AccountingTitle);
            if (table == null) return;
            MyFunction.SetGlobalFlag(GlobalFlag.basicDataModified);

            foreach (VEDataSet.AccountingTitleRow r in table)
            {
                if (r.RowState != DataRowState.Deleted)
                {
                    r.BeginEdit();   
                    r.LastUpdated = DateTime.Now;
                    if (!r.IsNameNull())
                        r.Name = r.Name.Trim();
                    r.TitleCode = r.TitleCode.Trim();
                    r.EndEdit();
                }
            }
            vEDataSet.AccountingTitle.Merge(table);
            this.accountingTitleTableAdapter.Update(this.vEDataSet.AccountingTitle);
            vEDataSet.AccountingTitle.AcceptChanges();
        }

        private void FormAccountingTitle_Load(object sender, EventArgs e)
        {
            accountingTitleTableAdapter.Connection = MapPath.VEConnection;
            this.accountingTitleTableAdapter.Fill(this.vEDataSet.AccountingTitle);
            MyFunction.SetFieldLength(accountingTitleDataGridView, vEDataSet.AccountingTitle);
        }

        private bool ValidateTitleCode(object obj,out string error)
        {
            if (MyFunction.IsNullDBNull(obj))
            {
                error="必須有科目編號!";
                return false;
            }
            string str = obj.ToString();
            if (string.IsNullOrEmpty(str))
            {
                error="必須有科目編號!";
                return false;
            }
            if (str.Length < 3)
            {
                error="科目編號太短!";
                return false;
            }
            if (MyFunction.UintValidate(str, out error)) return true;
            return false;
        }

        private void accountingTitleDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            DataGridViewRow row = view.Rows[e.RowIndex];
            if (row.IsNewRow) return;     // 最新的沒改的那行,不用檢查
            string cellName = view.Columns[e.ColumnIndex].Name;
            if (cellName=="TitleCode")
            {
                string error="";
                if (!ValidateTitleCode(e.FormattedValue, out error))
                {
                    e.Cancel = true;
                    MessageBox.Show(error);
                    return;
                }
                // 檢查重號
                string code = e.FormattedValue.ToString().Trim();
                for (int i = 0; i < view.Rows.Count; i++)
                {
                    if (i == e.RowIndex) continue;
                    DataGridViewCell c = view.Rows[i].Cells["TitleCode"];
                    if (c.FormattedValue.ToString().Trim() == code)
                    {
                        MessageBox.Show("科目編號<" + code + ">和第" + (i + 1).ToString() + "行重複!");
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }
        private void accountingTitleDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            DataGridViewRow row = view.Rows[e.RowIndex];
            if (row.IsNewRow) return;     // 最新的沒改的那行,不用檢查
            DataGridViewCell cell = row.Cells["TitleCode"];
            string error = "";
            if (!ValidateTitleCode(cell.FormattedValue, out error))
            {
                e.Cancel = true;
                MessageBox.Show(error);
                return;
            }
            string titleCode = cell.FormattedValue.ToString();
            cell = row.Cells["columnTitleName"];
            if (cell==null)
            {
                MessageBox.Show("程式錯誤,AccountingTitleDataGridView沒有columnTitleName!");
                return;
            }
            if (Convert.IsDBNull(cell.Value))
            {
                e.Cancel = true;
                MessageBox.Show("科目<"+titleCode+">必需有科目名稱!");
                return;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
 //           MyFunction.AddNewItem(this.accountingTitleDataGridView, "TitleCode", "TitleCode", vEDataSet.AccountingTitle);
        }

        private void DeletetoolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("施工中...");
        }

     }

}