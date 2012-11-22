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

        bool CodeInSetup(TitleSetup Setup, string code)
        {
            if (Setup.CashIncome == code)       return true;
            if (Setup.CashReceivable == code)   return true;
            if (Setup.CreditIncome== code)      return true;
            if (Setup.CreditReceivable == code) return true;
            if (Setup.DefaultAsset == code)     return true;
            if (Setup.DefaultCost == code)      return true;
            if (Setup.DefaultExpense == code)   return true;
            if (Setup.DefaultIncome == code)    return true;
            if (Setup.DefualtLiability == code) return true;
            if (Setup.OwnersEquity == code)     return true;
            if (Setup.VoucherShouldPay == code) return true;
            return false;
        }

        private void DeletetoolStripButton_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection cells = accountingTitleDataGridView.SelectedCells;
            if (cells.Count <= 0)
            {
                MessageBox.Show("請選擇要刪除的科目!");
                return;
            }
            DataRowView rowView = cells[0].OwningRow.DataBoundItem as DataRowView;
            VEDataSet.AccountingTitleRow row = rowView.Row as VEDataSet.AccountingTitleRow;
            if (Convert.IsDBNull(cells[0].OwningRow.Cells[0].Value))    // 只有新增未存檔的才可能沒資料
            {
                accountingTitleBindingSource.RemoveCurrent();
                return;
            }
            string titleCode=row.TitleCode.Trim();

            string titleName = "";
            if (!row.IsNameNull()) titleName=row.Name;
            if (titleCode.Length == 0)
            {
                MessageBox.Show("沒有科目代碼!");
                return;
            }
            LoadLedgerData();
            if (CodeInSetup(Setup, titleCode))
            {
                MessageBox.Show("科目<"+titleCode+">"+titleName+" 出現在傳票設定中,無法刪除!");
                return;
            }
            List<CLedgerRow> list=m_Generator.CreateTable(0, titleCode, AccList1);   
            bool used;
            if (list.Count == 0)        used = false;
            else if (list.Count > 2)    used = true;
            else if (AccTitleList.IsVirtualTitle(titleCode))
                                        used = true;    // 虛科目有一行就不行
            else if (list[0].Sum != 0)  used = true;    // 實科目第一行是餘額,不是0 ,代表上年度有餘額
            else                        used = false;
            if (used)
            {
                dgvLedgerTable.DataSource = list;
                dgvLedgerTable.Visible = true;
                dgvLedgerTable.BringToFront();
                MessageBox.Show("科目<" + titleCode + ">"+titleName+" 己經被引用, 無法刪除!");
                dgvLedgerTable.Visible = false;
                return;
            }
            else 
            {
                if (MessageBox.Show("科目<" + titleCode + ">"+titleName+" 還沒被引用可以刪除,按確定刪除", "科目" + titleCode, MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;
                accountingTitleBindingSource.RemoveCurrent();
                MessageBox.Show("科目<" + titleCode + ">" + titleName + "己刪除,請按存檔!");
            }


        }

        #region ====== LedgerData Gloal======
#if Define_Bakery
        RevenueCalcBakery m_Revenue;
        BakeryOrderSetTableAdapters.HeaderTableAdapter headerTableAdapter = new BakeryOrderSetTableAdapters.HeaderTableAdapter();
        BakeryOrderSet bakeryOrderSet = new BakeryOrderSet();
#else
        RevenueCalc m_Revenue;
        BasicDataSetTableAdapters.HeaderTableAdapter headerTableAdapter = new BasicDataSetTableAdapters.HeaderTableAdapter();
        BasicDataSet basicDataSet=new BasicDataSet();
#endif
        AccTitleList AccList = new AccTitleList();
        AccTitleList AccList1 = new AccTitleList();      // Copy有初值的空表用
        TitleSetup Setup = new TitleSetup();
        LedgerTableGenerator m_Generator;

        bool DataPrepared=false;
        private void LoadLedgerData()
        {
            if (DataPrepared) return;
            #if Define_Bakery
            try
            {
                headerTableAdapter.Connection = MapPath.BakeryConnection;
                headerTableAdapter.Fill(bakeryOrderSet.Header);
            }
            catch { MessageBox.Show("標頭資料讀取錯誤,你的資料庫版本可能不對"); }
            int count = bakeryOrderSet.Header.Count;
            if (count == 0)
            {
                MessageBox.Show("無資料!");
                Close();
                return;
            }
            BakeryOrderSet.HeaderRow row = bakeryOrderSet.Header[count - 1];
            m_Revenue = new RevenueCalcBakery(row.DataDate, 0);
#else
            try
            {
                headerTableAdapter.Connection = MapPath.BasicConnection;
                headerTableAdapter.Fill(basicDataSet.Header);
            }
            catch { MessageBox.Show("標頭資料讀取錯誤,你的資料庫版本可能不對"); }
            int count = basicDataSet.Header.Count;
            if (count == 0)
            {
                MessageBox.Show("無資料!");
                Close();
                return;
            }
            BasicDataSet.HeaderRow row = basicDataSet.Header[count - 1];
            m_Revenue = new RevenueCalc(row.DataDate,0);
#endif
            AccList.NewAll();
 
            //accountingTitleTableAdapter.Connection = MapPath.VEConnection;
            bankAccountTableAdapter.Connection     = MapPath.VEConnection;
            expenseTableAdapter.Connection         = MapPath.VEConnection;
            voucherTableAdapter.Connection         = MapPath.VEConnection;
            voucherDetailTableAdapter.Connection   = MapPath.VEConnection;
            bankDetailTableAdapter.Connection      = MapPath.VEConnection;
            accVoucherTableAdapter.Connection      = MapPath.VEConnection;
            vendorTableAdapter.Connection          = MapPath.VEConnection;
            ingredientTableAdapter.Connection      = MapPath.VEConnection;

            try
            {
                //accountingTitleTableAdapter.Fill(vEDataSet.AccountingTitle); 外面Load過了,再Load DataGridView會全亂掉
                bankAccountTableAdapter.Fill(vEDataSet.BankAccount);
                expenseTableAdapter.Fill(vEDataSet.Expense);    // expense檔案小,先全部讀進記憶體
                voucherTableAdapter.Fill(vEDataSet.Voucher);
                voucherDetailTableAdapter.Fill(vEDataSet.VoucherDetail);
                bankDetailTableAdapter.Fill(vEDataSet.BankDetail);
                accVoucherTableAdapter.Fill(vEDataSet.AccVoucher);
                vendorTableAdapter.Fill(vEDataSet.Vendor);
                ingredientTableAdapter.Fill(vEDataSet.Ingredient);
                foreach (VEDataSet.AccountingTitleRow r in vEDataSet.AccountingTitle.Rows)
                {
                    AccTitle item=new AccTitle(r.TitleCode,r.Name);
                    if (r.IsInitialValueNull())
                        item.Money = 0;
                    else 
                        item.Money = r.InitialValue;
                    if (r.TitleCode.Length == 0) continue;
                    AccList.Add(item);
                }
                AccList1.CopyTableFrom(AccList);

                Setup.Load();
                m_Generator = new LedgerTableGenerator(labelMessage,Setup,vEDataSet,new CalcRevenueDelegate(CalcRevenue));
            }
            catch (Exception ex)
            {
                MessageBox.Show("資料庫讀取錯誤! 原因:" + ex.Message);
                return;
            }
            DataPrepared = true;
        }

        // RevenueCalc需要Header.Date 己經在FormLoad時給值
        MonthlyReportData CalcRevenue(int month, out List<MonthlyReportData> reportList)
        {
            int year = m_Revenue.Year;
            reportList = null;
            if (month < 1 || month > 12)
            {
                MessageBox.Show("所選月份不對!");
                return null;
            }
            labelMessage.Text = "計算 " + month.ToString() + "月營業額";
            //if (RevenueCache[month - 1] != null)    // 不能用Cache了
            //    return RevenueCache[month - 1];
            int count = MyFunction.DayCountOfMonth(month);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = count;
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            List<MonthlyReportData> list = new List<MonthlyReportData>();
            for (int i = 1; i <= count; i++)
            {
#if Define_Bakery
                if (m_Revenue.LoadData(bakeryOrderSet, month, i))
                    list.Add(m_Revenue.Statics(bakeryOrderSet));
#else
                if (m_Revenue.LoadData(basicDataSet, year, month, i, true))
                    list.Add(m_Revenue.Statics(basicDataSet));
#endif
                progressBar1.Value = i;
                Application.DoEvents();
            }
            progressBar1.Visible = false;
            MonthlyReportData total = new MonthlyReportData();
            foreach (MonthlyReportData d in list)
            {
                total.Revenue += d.Revenue;
                total.OrderCount += d.OrderCount;
                total.Cash += d.Cash;
                total.CreditCard += d.CreditCard;
            }
            reportList = list;
            return total;
        }

        #endregion

        private void accountingTitleDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView view = sender as DataGridView;
            if (view.Columns[e.ColumnIndex].Name == "TitleCode")
            {
                DataGridViewCell cell = view.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value == Convert.DBNull || cell.Value == null || cell.Value.ToString()=="")
                    return;
                e.Cancel = true;
            }
        }

        private void accountingTitleDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

     


    }

}