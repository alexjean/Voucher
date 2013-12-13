//#define UseSQLServer
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
#if UseSQLServer
using MyDataSet = VoucherExpense.DamaiDataSet;
using MyOrderSet= VoucherExpense.DamaiDataSet;
using MyHeaderAdapter=VoucherExpense.DamaiDataSetTableAdapters.HeaderTableAdapter;
#else
using MyDataSet = VoucherExpense.VEDataSet;
using MyOrderSet= VoucherExpense.BakeryOrderSet;
using MyHeaderAdapter=VoucherExpense.BakeryOrderSetTableAdapters.HeaderTableAdapter;
#endif
namespace VoucherExpense
{
    public partial class FormLedger : Form
    {
        public FormLedger()
        {
            InitializeComponent();
        }

        RevenueCalcBakery m_Revenue;
        string m_SelectedTitleCode = "";
        int m_SelectedMonth = -1;
        AccTitleList AccList    = new AccTitleList();
        AccTitleList AccList1   = new AccTitleList();      // Copy有初值的空表用

//        VoucherExpense.MonthlyReportData[] RevenueCache; // 計算加速用
//        CMonthBalance[] MonthBalances;                   // 存月比較表用 
        TitleSetup Setup = new TitleSetup();

        LedgerTableGenerator m_Generator;
        MyDataSet m_DataSet = new MyDataSet();
        MyOrderSet m_OrderSet=new MyOrderSet();
        MyHeaderAdapter headerAdapter = new MyHeaderAdapter();

        private void FormLedger_Load(object sender, EventArgs e)
        {
#if (UseSQLServer)
            m_OrderSet=m_DataSet;
            accountingTitleBindingSource.DataSource = m_DataSet;
            try
            {
                headerAdapter.Fill(m_DataSet.Header);
            }
            catch { MessageBox.Show("標頭資料讀取錯誤,你的資料庫版本可能不對"); }
            int count = m_DataSet.Header.Count;
            if (count == 0)
            {
                MessageBox.Show("無資料!");
                Close();
                return;
            }
            var row = m_DataSet.Header[count - 1];
            m_Revenue = new RevenueCalcBakery(row.DataDate, 0);

            AccList.NewAll();
            var accTitleAdapter     = new DamaiDataSetTableAdapters.AccountingTitleTableAdapter();
            var bankAccountAdapter  = new DamaiDataSetTableAdapters.BankAccountTableAdapter();
            var expenseAdapter      = new DamaiDataSetTableAdapters.ExpenseTableAdapter();
            var voucherAdapter      = new DamaiDataSetTableAdapters.VoucherTableAdapter();
            var voucherDetailAdapter= new DamaiDataSetTableAdapters.VoucherDetailTableAdapter();
            var bankDetailAdapter   = new DamaiDataSetTableAdapters.BankDetailTableAdapter();
            var accVoucherAdapter   = new DamaiDataSetTableAdapters.AccVoucherTableAdapter();
            var vendorAdapter       = new DamaiDataSetTableAdapters.VendorTableAdapter();
            var ingredientAdapter   = new DamaiDataSetTableAdapters.IngredientTableAdapter();

            try
            {
                accTitleAdapter.Fill    (m_DataSet.AccountingTitle);
                bankAccountAdapter.Fill (m_DataSet.BankAccount);
                expenseAdapter.Fill     (m_DataSet.Expense);    // expense檔案小,先全部讀進記憶體
                voucherAdapter.Fill     (m_DataSet.Voucher);
                voucherDetailAdapter.Fill(m_DataSet.VoucherDetail);
                bankDetailAdapter.Fill  (m_DataSet.BankDetail);
                accVoucherAdapter.Fill  (m_DataSet.AccVoucher);
                vendorAdapter.Fill      (m_DataSet.Vendor);
                ingredientAdapter.Fill  (m_DataSet.Ingredient);

#else
            m_OrderSet = new BakeryOrderSet();
            try
            {
                headerAdapter.Connection = MapPath.BakeryConnection;
                headerAdapter.Fill(m_OrderSet.Header);
            }
            catch { MessageBox.Show("標頭資料讀取錯誤,你的資料庫版本可能不對"); }
            int count =m_OrderSet.Header.Count;
            if (count == 0)
            {
                MessageBox.Show("無資料!");
                Close();
                return;
            }
            var row = m_OrderSet.Header[count - 1];
            m_Revenue = new RevenueCalcBakery(row.DataDate, 0);

            AccList.NewAll();

            var accTitleAdapter     = new VEDataSetTableAdapters.AccountingTitleTableAdapter();
            var bankAccountAdapter  = new VEDataSetTableAdapters.BankAccountTableAdapter();
            var expenseAdapter      = new VEDataSetTableAdapters.ExpenseTableAdapter();
            var voucherAdapter      = new VEDataSetTableAdapters.VoucherTableAdapter();
            var voucherDetailAdapter= new VEDataSetTableAdapters.VoucherDetailTableAdapter();
            var bankDetailAdapter   = new VEDataSetTableAdapters.BankDetailTableAdapter();
            var accVoucherAdapter   = new VEDataSetTableAdapters.AccVoucherTableAdapter();
            var vendorAdapter       = new VEDataSetTableAdapters.VendorTableAdapter();
            var ingredientAdapter   = new VEDataSetTableAdapters.IngredientTableAdapter();

            accTitleAdapter.Connection        = MapPath.VEConnection;
            bankAccountAdapter.Connection     = MapPath.VEConnection;
            expenseAdapter.Connection         = MapPath.VEConnection;
            voucherAdapter.Connection         = MapPath.VEConnection;
            voucherDetailAdapter.Connection   = MapPath.VEConnection;
            bankDetailAdapter.Connection      = MapPath.VEConnection;
            accVoucherAdapter.Connection      = MapPath.VEConnection;
            vendorAdapter.Connection          = MapPath.VEConnection;
            ingredientAdapter.Connection      = MapPath.VEConnection;

            try
            {
                accTitleAdapter.Fill(m_DataSet.AccountingTitle);
                bankAccountAdapter.Fill(m_DataSet.BankAccount);
                expenseAdapter.Fill(m_DataSet.Expense);    // expense檔案小,先全部讀進記憶體
                voucherAdapter.Fill(m_DataSet.Voucher);
                voucherDetailAdapter.Fill(m_DataSet.VoucherDetail);
                bankDetailAdapter.Fill(m_DataSet.BankDetail);
                accVoucherAdapter.Fill(m_DataSet.AccVoucher);
                vendorAdapter.Fill(m_DataSet.Vendor);
                ingredientAdapter.Fill(m_DataSet.Ingredient);
#endif
                foreach (var r in m_DataSet.AccountingTitle)
                {
                    AccTitle item = new AccTitle(r.TitleCode, r.Name);
                    if (r.IsInitialValueNull())
                        item.Money = 0;
                    else
                        item.Money = r.InitialValue;
                    if (r.TitleCode.Length == 0) continue;
                    AccList.Add(item);
                }
                AccList1.CopyTableFrom(AccList);

                Setup.Load();
                m_Generator = new LedgerTableGenerator(labelMessage, Setup, m_DataSet, new CalcRevenueDelegate(CalcRevenue));
                cLedgerTableDataGridView.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("資料庫讀取錯誤! 原因:" + ex.Message);
            }

            // 設置comboBoxAccTitle的初值為 <零用金>
            if (m_DataSet.BankAccount.Rows.Count > 1)
            {
                var bank = m_DataSet.BankAccount[0];
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
                labelMessage.Text="請選擇月份!!!";
                return;
            }
            List<CLedgerRow> lendgerTable=m_Generator.CreateTable(m_SelectedMonth,m_SelectedTitleCode,AccList1);
            cLedgerTableDataGridView.DataSource = lendgerTable;
            cLedgerTableDataGridView.Focus();
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;
            int i=box.SelectedIndex;
            if (i < 0 || i > 12) return;
            if (DontRefresh) return;
            List<CLedgerRow> ledgerTable=m_Generator.CreateTable(m_SelectedMonth = i,m_SelectedTitleCode,AccList1);
            cLedgerTableDataGridView.DataSource = ledgerTable;
            cLedgerTableDataGridView.Focus();
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
            labelMessage.Text="計算 " + month.ToString() + "月營業額";
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
#if (UseSQLServer)
                if (m_Revenue.LoadData(m_DataSet, month, i)) list.Add(m_Revenue.Statics(m_DataSet));
#else
                if (m_Revenue.LoadData(m_OrderSet, month, i)) list.Add(m_Revenue.Statics(m_OrderSet));
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

 

        private void btnExport2Excel_Click(object sender, EventArgs e)
        {
            if (m_SelectedMonth<0) 
            {
                labelMessage.Text="請先選擇月份!!";
                return;
            }
            Excel.Application excel;
            Excel.Worksheet sheet;
            Excel.Workbook book;
            try
            {
                excel = new Excel.Application();
                book = excel.Application.Workbooks.Add(true);
                sheet = book.Worksheets[1];
                DataRowView rowView = comboBoxAccTitle.SelectedItem as DataRowView;
                VEDataSet.AccountingTitleRow row = rowView.Row as VEDataSet.AccountingTitleRow;
                sheet.Name = comboBoxMonth.SelectedItem.ToString() + "  " + row.Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show("開啟Excel出錯,原因:" + ex.Message);
                return;
            }
            excel.Visible = true;
            DataGridView view = cLedgerTableDataGridView;
            Excel.Range range;
            int i = 1;
            // 插入Logo圖片
            int imgHeight = 48;
            range = sheet.Rows[1];
            range.RowHeight = imgHeight + 2;
            Bitmap img = MyFunction.GetThumbnail(global::VoucherExpense.Properties.Resources.LogoVI, imgHeight * 4 / 3);   // 一般圖是96DPI,換算就是4pixels=3單位
            range = sheet.Cells[1, 1];
            Clipboard.SetDataObject(img, true);
            sheet.Paste(range, "LogoVI");

            range = sheet.Cells[1, 3];
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            sheet.Cells[1, 3] = sheet.Name+"  分類帳";
            range.Select();

            //欄位表頭
            i++;

            sheet.Cells[i, 1] = "日期";
            range = sheet.Columns[1];
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            range.ColumnWidth = 10;

            sheet.Cells[i, 2] = "摘要";
            range = sheet.Columns[2];
            range.ColumnWidth = 30;

            sheet.Cells[i, 3] = "借方";
            range = sheet.Columns[3];
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
            range.ColumnWidth = 10;
            range.NumberFormat = "#,##0.00";

            sheet.Cells[i, 4] = "貸方";
            range = sheet.Columns[4];
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
            range.ColumnWidth = 10;
            range.NumberFormat = "#,##0.00";    // "0.00";

            sheet.Cells[i, 5] = "餘額";
            range = sheet.Columns[5];
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
            range.ColumnWidth = 10;
            range.NumberFormat = "#,##0.00";

            sheet.Cells[i, 6] = "科目";
            range = sheet.Columns[6];
            range.ColumnWidth = 10;



            i++;
            foreach (DataGridViewRow vr in view.Rows)
            {
                sheet.Cells[i, 1] = vr.Cells[0].FormattedValue;         // 日期
                sheet.Cells[i, 2] = "'" + vr.Cells[1].FormattedValue;   // 摘要
                sheet.Cells[i, 3] = vr.Cells[2].FormattedValue;         // 借方
                sheet.Cells[i, 4] = vr.Cells[3].FormattedValue;         // 貸方
                sheet.Cells[i, 5] = vr.Cells[4].FormattedValue;         // 餘額
                sheet.Cells[i, 6] = vr.Cells[5].FormattedValue;         // 對沖科目

                //DataRowView rowView = vr.DataBoundItem as DataRowView;
                //VEDataSet.ExpenseRow row =  rowView.Row as VEDataSet.ExpenseRow;
                //if (!row.IsInnerIDNull())   sheet.Cells[i, 1] = row.InnerID;
                //                            sheet.Cells[i, 2] = row.ApplyTime;
                //if (!row.IsNoteNull())      sheet.Cells[i, 3] = row.Note;
                //if (!row.IsTitleCodeNull()) sheet.Cells[i, 4] = "'"+row.TitleCode.ToString();
                //if (!row.IsMoneyNull())     sheet.Cells[i, 5] = row.Money;
                //if (!row.IsApplierIDNull())
                //{
                //    sheet.Cells[i, 6] = row.ApplierID;
                //}
                i++;
            }
            sheet.Cells[i++, 2] = "'================================================";
            excel.Quit();

        }

        int m_DebtColumn = -1;
        int m_CreditColumn = -1;
        private void cLedgerTableDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (m_DebtColumn==int.MaxValue) return;   // 發生過錯誤了
            if (m_DebtColumn < 0)
            {
                try
                {
                    m_CreditColumn = cLedgerTableDataGridView.Columns["ColumnCredit"].Index;
                    m_DebtColumn = cLedgerTableDataGridView.Columns["ColumnDebt"].Index;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("程式錯誤! ColumnCredit ,ColumnDebt有問題:" + ex.Message);
                    m_DebtColumn = int.MaxValue;
                    return;
                }
            }
            int iCol = e.ColumnIndex;
            if (iCol == m_DebtColumn || iCol == m_CreditColumn)
            {
                if (e.Value == null || e.Value == DBNull.Value)
                {
                    e.Value = " ";
                }
                else
                {
                    decimal d = (decimal)e.Value;
                    if (d == 0m) e.Value = " ";
                }
            }
        }

    }
}
