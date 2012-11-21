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
    public partial class FormLedger : Form
    {
        public FormLedger()
        {
            InitializeComponent();
        }

#if Define_Bakery
        RevenueCalcBakery m_Revenue;
        BakeryOrderSetTableAdapters.HeaderTableAdapter headerTableAdapter = new BakeryOrderSetTableAdapters.HeaderTableAdapter();
        BakeryOrderSet bakeryOrderSet = new BakeryOrderSet();
#else
        RevenueCalc m_Revenue;
        BasicDataSetTableAdapters.HeaderTableAdapter headerTableAdapter = new BasicDataSetTableAdapters.HeaderTableAdapter();
        BasicDataSet basicDataSet=new BasicDataSet();
#endif
        string m_SelectedTitleCode = "";
        int m_SelectedMonth = -1;
        AccTitleList AccList    = new AccTitleList();
        AccTitleList AccList1   = new AccTitleList();      // Copy有初值的空表用

//        VoucherExpense.MonthlyReportData[] RevenueCache; // 計算加速用
//        CMonthBalance[] MonthBalances;                   // 存月比較表用 
        TitleSetup Setup = new TitleSetup();

        LedgerTableGenerator m_Generator;

        private void FormLedger_Load(object sender, EventArgs e)
        {

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
            //RevenueCache = new MonthlyReportData[12];
            //MonthBalances = new CMonthBalance[13];
            //for (int i = 0; i < 13; i++)
            //{
            //    MonthBalances[i] = new CMonthBalance();
            //    MonthBalances[i].Month = i + 1;
            //}
            //MonthBalances[12].Month = 0;   // 第13月統計用

            accountingTitleTableAdapter.Connection = MapPath.VEConnection;
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
                accountingTitleTableAdapter.Fill(vEDataSet.AccountingTitle);
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
                cLedgerTableDataGridView.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show("資料庫讀取錯誤! 原因:"+ex.Message);
            }
        
            // 設置comboBoxAccTitle的初值為 <零用金>
            if (vEDataSet.BankAccount.Rows.Count>1)
            {
                VEDataSet.BankAccountRow bank=vEDataSet.BankAccount[0];
                if (bank.IsAccountTitleCodeNull())
                    comboBoxAccTitle.SelectedIndex=0;
                else
                    comboBoxAccTitle.SelectedValue=bank.AccountTitleCode;
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

 


        private void btnExport2Excel_Click(object sender, EventArgs e)
        {
            if (m_SelectedMonth<0) 
            {
                labelMessage.Text="請先選擇月份!!";
                return;
            }
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Worksheet sheet;
            Microsoft.Office.Interop.Excel.Workbook book;
            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                book = excel.Application.Workbooks.Add(true);
                sheet = book.Worksheets[1];
                sheet.Name = comboBoxMonth.SelectedItem.ToString() + "費用";
            }
            catch (Exception ex)
            {
                MessageBox.Show("開啟Excel出錯,原因:" + ex.Message);
                return;
            }
            excel.Visible = true;
            DataGridView view = cLedgerTableDataGridView;
            Microsoft.Office.Interop.Excel.Range range;
            int i = 1;
            // 插入Logo圖片
            int imgHeight = 48;
            range = sheet.Rows[1];
            range.RowHeight = imgHeight + 2;
            Bitmap img = MyFunction.GetThumbnail(global::VoucherExpense.Properties.Resources.LogoVI, imgHeight * 4 / 3);   // 一般圖是96DPI,換算就是4pixels=3單位
            range = sheet.Cells[1, 1];
            Clipboard.SetDataObject(img, true);
            sheet.Paste(range, "LogoVI");

            //欄位表頭
            i++;

            sheet.Cells[i, 1] = "日期";
            range = sheet.Columns[1];
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            range.ColumnWidth = 10;

            sheet.Cells[i, 2] = "摘要";
            range = sheet.Columns[2];
            range.ColumnWidth = 30;

            sheet.Cells[i, 3] = "借方";
            range = sheet.Columns[3];
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            sheet.Cells[i, 4] = "貸方";
            range = sheet.Columns[4];
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

            sheet.Cells[i, 5] = "餘額";
            range = sheet.Columns[5];
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

            sheet.Cells[i, 6] = "科目";


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

    }
}
