using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace VoucherExpense
{
    static class MergeMdb
    {
        static public void 合併銀行細目()
        {
            if (MessageBox.Show("現有檔案和你選的檔案內容若有不同,將覆蓋現有內容,確定嗎?", "合併銀行細目", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "請選擇要併入銀行細目的Mdb檔案";
            dialog.Filter = "mdb|*.mdb|所有檔案|*.*";
            if (dialog.ShowDialog() != DialogResult.OK) return;
            string password = "Voucher";
            password = "Calc" + password + (888).ToString();
            int count = 0;
            VEDataSet.BankDetailDataTable mergeTable = new VEDataSet.BankDetailDataTable();
            try
            {
                VEDataSetTableAdapters.BankDetailTableAdapter fromAdapter = new VEDataSetTableAdapters.BankDetailTableAdapter();
                fromAdapter.Connection = new System.Data.OleDb.OleDbConnection(MapPath.ConnectString(dialog.FileName, password));
                VEDataSet.BankDetailDataTable fromTable = new VEDataSet.BankDetailDataTable();
                fromAdapter.Fill(fromTable);
                VEDataSetTableAdapters.BankDetailTableAdapter mergeAdapter = new VEDataSetTableAdapters.BankDetailTableAdapter();
                mergeAdapter.Connection = MapPath.VEConnection;
                mergeAdapter.Fill(mergeTable);
                count = MergeMdb.MergeBankDetail(fromTable, mergeTable);
                if (count == 0)
                {
                    MessageBox.Show("共比較 " + fromTable.Rows.Count.ToString() + "筆 ! 沒有需要更新的資料!");
                    return;
                }
                count = mergeAdapter.Update(mergeTable);
                MessageBox.Show("共比較 " + fromTable.Rows.Count.ToString() + "筆! 更新了 " + count.ToString() + "筆資料!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("合併檔案失敗!錯誤<" + ex.Message + ">");
                return;
            }
        }
        static int MergeBankDetail(VEDataSet.BankDetailDataTable fromTable, VEDataSet.BankDetailDataTable mergeTable)  // return RowCount that have been updated
        {
            VEDataSet.BankDetailRow temp=mergeTable.NewBankDetailRow();
            int objCount=temp.ItemArray.Count();
            int changed = 0;
            foreach(VEDataSet.BankDetailRow row in fromTable)
            {
                if (row.RowState == DataRowState.Deleted) continue;
                var rs = from r in mergeTable where (row.ID == r.ID && (r.RowState!=DataRowState.Deleted)) select r;        // ID是PrimaryKey,相同一定只有一個
                if (rs.Count() == 0)                                                                // 沒有相同的,直接加進來
                {
                    VEDataSet.BankDetailRow newRow = mergeTable.NewBankDetailRow();
                    newRow.ItemArray = row.ItemArray;
                    mergeTable.AddBankDetailRow(newRow);
                    changed++;
                }
                else
                {
                    VEDataSet.BankDetailRow mergeRow = rs.ElementAt(0) as VEDataSet.BankDetailRow;
                    bool same=true;
                    for (int i = 0; i < objCount; i++)
                    {
                        if (!mergeRow[i].Equals(row[i]))
                        {
                            same = false;
                            break;
                        }
                    }
                    if (same) continue;                                                             // 相同ID,內容也相同,跳過
                    mergeRow.BeginEdit();                                                        // 要傳進來的和原有的不同, 由新的取代
                    mergeRow.ItemArray = row.ItemArray;
                    mergeRow.EndEdit();
                    changed++;
                }
            }
            return changed;
        }

        static public void 合併傳票()
        {
            if (MessageBox.Show("現有檔案和你選的檔案內容若有不同,將覆蓋現有內容,確定嗎?", "合併傳票", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "請選擇要併入傳票的Mdb檔案";
            dialog.Filter = "mdb|*.mdb|所有檔案|*.*";
            if (dialog.ShowDialog() != DialogResult.OK) return;
            string password = "Voucher";
            password = "Calc" + password + (888).ToString();
            int count = 0;
            VEDataSet.AccVoucherDataTable mergeTable = new VEDataSet.AccVoucherDataTable();
            try
            {
                VEDataSetTableAdapters.AccVoucherTableAdapter fromAdapter = new VEDataSetTableAdapters.AccVoucherTableAdapter();
                fromAdapter.Connection = new System.Data.OleDb.OleDbConnection(MapPath.ConnectString(dialog.FileName, password));
                VEDataSet.AccVoucherDataTable fromTable = new VEDataSet.AccVoucherDataTable();
                fromAdapter.Fill(fromTable);
                VEDataSetTableAdapters.AccVoucherTableAdapter mergeAdapter = new VEDataSetTableAdapters.AccVoucherTableAdapter();
                mergeAdapter.Connection = MapPath.VEConnection;
                mergeAdapter.Fill(mergeTable);
                count = MergeMdb.MergeAccVoucher(fromTable, mergeTable);
                if (count == 0)
                {
                    MessageBox.Show("共比較 " + fromTable.Rows.Count.ToString() + "筆 ! 沒有需要更新的資料!");
                    return;
                }
                count = mergeAdapter.Update(mergeTable);
                MessageBox.Show("共比較 " + fromTable.Rows.Count.ToString() + "筆! 更新了 " + count.ToString() + "筆資料!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("合併檔案失敗!錯誤<" + ex.Message + ">");
                return;
            }
        }
        static int MergeAccVoucher(VEDataSet.AccVoucherDataTable fromTable, VEDataSet.AccVoucherDataTable mergeTable)  // return RowCount that have been updated
        {
            VEDataSet.AccVoucherRow temp = mergeTable.NewAccVoucherRow();
            int objCount = temp.ItemArray.Count();
            int changed = 0;
            foreach (VEDataSet.AccVoucherRow row in fromTable)
            {
                if (row.RowState == DataRowState.Deleted) continue;
                var rs = from r in mergeTable where (row.ID == r.ID && (r.RowState != DataRowState.Deleted)) select r;        // ID是PrimaryKey,相同一定只有一個
                if (rs.Count() == 0)                                                                // 沒有相同的,直接加進來
                {
                    VEDataSet.AccVoucherRow newRow = mergeTable.NewAccVoucherRow();
                    newRow.ItemArray = row.ItemArray;
                    mergeTable.AddAccVoucherRow(newRow);
                    changed++;
                }
                else
                {
                    VEDataSet.AccVoucherRow mergeRow = rs.ElementAt(0) as VEDataSet.AccVoucherRow;
                    bool same = true;
                    for (int i = 0; i < objCount; i++)
                    {
                        if (!mergeRow[i].Equals(row[i]))
                        {
                            same = false;
                            break;
                        }
                    }
                    if (same) continue;                                                             // 相同ID,內容也相同,跳過
                    mergeRow.BeginEdit();                                                        // 要傳進來的和原有的不同, 由新的取代
                    mergeRow.ItemArray = row.ItemArray;
                    mergeRow.EndEdit();
                    changed++;
                }
            }
            return changed;
        }

    }
}
