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
    public partial class FormLedgerNew : Form
    {
        string m_SelectedTitleCode = "";
        int m_SelectedMonth = -1;

        public FormLedgerNew()
        {
            InitializeComponent();
        }

        private void FormLedgerNew_Load(object sender, EventArgs e)
        {
            var bankAccountAdapter      = new DamaiDataSetTableAdapters.BankAccountTableAdapter();
            var accTitleAdapter         = new DamaiDataSetTableAdapters.AccountingTitleTableAdapter();
            var accVouchAdapter         = new DamaiDataSetTableAdapters.AccVouchTableAdapter();
            var accVouchDetailAdapter   = new DamaiDataSetTableAdapters.AccVouchDetailTableAdapter();
            try
            {
                bankAccountAdapter.Fill (damaiDataSet.BankAccount);
                accTitleAdapter.Fill(damaiDataSet.AccountingTitle);
                accVouchAdapter.Fill(damaiDataSet.AccVouch);
                accVouchDetailAdapter.Fill(damaiDataSet.AccVouchDetail);
                dgvCLedgerTable.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("資料庫讀取錯誤! 原因:" + ex.Message);
            }
            // 設置comboBoxAccTitle的初值為 <零用金>
            if (damaiDataSet.BankAccount.Rows.Count > 1)
            {
                var bank = damaiDataSet.BankAccount[0];
                if (bank.IsAccountTitleCodeNull())
                    comboBoxAccTitle.SelectedIndex = 0;
                else
                    comboBoxAccTitle.SelectedValue = bank.AccountTitleCode;
            }
            DontRefresh = false;     // Form剛Load不Refresh DataGridView
        }

        bool DontRefresh = true;
        private void comboBoxAccTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;
            if (box.SelectedValue == null) return;
            m_SelectedTitleCode = box.SelectedValue.ToString();
            if (DontRefresh) return;
            if (m_SelectedMonth < 0 || m_SelectedMonth > 12)
            {
                labelMessage.Text = "請選擇月份!!!";
                return;
            }
            SortableBindingList<CLedgerRow> lendgerTable = CalcLedger(m_SelectedMonth, m_SelectedTitleCode);
            dgvCLedgerTable.DataSource = lendgerTable;
            dgvCLedgerTable.Focus();
        }

        SortableBindingList<CLedgerRow> CalcLedger(int mon, string selectedTitleCode)
        {
            SortableBindingList<CLedgerRow> LedgerTable = new SortableBindingList<CLedgerRow>();
            var accTitle=damaiDataSet.AccountingTitle.FindByTitleCode(selectedTitleCode);
            if (accTitle==null) return LedgerTable;
            bool isVirtual = accTitle.IsIsVirtualNull()?false : accTitle.IsVirtual;
            bool isDebt    = accTitle.IsIsDebtNull()   ?false : accTitle.IsDebt;
            Decimal DebtSum = 0,CreditSum=0;
            List<DamaiDataSet.AccVouchRow> accList=new List<DamaiDataSet.AccVouchRow>();
            bool wholeYear = (mon <= 0 || mon > 12);
            if (wholeYear)
            {
                var nullList = from acc in damaiDataSet.AccVouch
                               where acc.IsAccVoucherTimeNull()
                               select acc;
                foreach (var r in nullList) accList.Add(r);
            }
            var nonNullList = from acc in damaiDataSet.AccVouch
                              where !acc.IsAccVoucherTimeNull()
                              orderby acc.AccVoucherTime
                              select acc;
            foreach (var r in nonNullList) accList.Add(r);
            foreach (var acc in accList)
            {
                bool isCurrent = true;
                if (acc.IsAccVoucherTimeNull())
                {
                    if (!wholeYear) continue;
                }
                else
                {
                    if (acc.AccVoucherTime.Year != MyFunction.IntHeaderYear) continue;
                    if (!wholeYear)
                    {
                        if (acc.AccVoucherTime.Month != mon) isCurrent = false;
                        if (acc.AccVoucherTime.Month >  mon) continue;
                    }
                }
                if (isVirtual && !isCurrent) continue; // 虛科目非當期 不用累加
                var details = acc.GetAccVouchDetailRows();
                if (details == null || details.Count() == 0) continue;
                foreach(var d in details)
                {
                    string titleCode = d.TitleCode;
                    int i = titleCode.IndexOf('.');
                    if (i >= 0) titleCode = titleCode.Substring(0, i);
                    if (titleCode != selectedTitleCode) continue;
                    DebtSum   += d.Debt;
                    CreditSum += d.Credit;
                    if (!isCurrent) continue;
                    CLedgerRow row = new CLedgerRow();
                    if (!acc.IsAccVoucherTimeNull())
                        row.Date    = acc.AccVoucherTime;
                    row.Debt    =d.Debt;
                    row.Credit  =d.Credit;
                    if (isDebt)
                        row.Sum = DebtSum - CreditSum;
                    else
                        row.Sum = CreditSum - DebtSum;
                    row.Note = d.Note.TrimEnd();            // row.sum最後再一起算
                    //string titleName = "";
                    //if (othersideTitle != null)
                    //{
                    //    if (char.IsDigit(othersideTitle[0]))
                    //    {
                    //        int tmp;
                    //        AccTitle t = NewList.FindTitleByCode(othersideTitle, out tmp);
                    //        if (t != null) titleName = t.Name;
                    //    }
                    //    else
                    //        titleName = othersideTitle;
                    //}
                    //row.OthersideAccTitle = titleName;
                    LedgerTable.Add(row);
                }
            }
            return LedgerTable;
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;
            int i = box.SelectedIndex;
            if (i < 0 || i > 12) return;
            if (DontRefresh) return;
            SortableBindingList<CLedgerRow> ledgerTable = CalcLedger(m_SelectedMonth = i, m_SelectedTitleCode);
            dgvCLedgerTable.DataSource = ledgerTable;
            dgvCLedgerTable.Focus();

        }

    }
}
