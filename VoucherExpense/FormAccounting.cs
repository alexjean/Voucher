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
    public partial class FormAccounting : Form
    {
        public FormAccounting()
        {
            InitializeComponent();
        }

        public class CID
        {
            public string Name  { set; get; }
            public short ID     { set; get; }
            public CID()        { Name = ""; ID = 0; }
            public CID(short id, string name)   { ID = id; Name = name;  }
            override public string ToString()   { return Name;           }
        }

        TitleSetup Setup = new TitleSetup();
        public List<CID> SourceNames = new List<CID>() { new CID(1,"手工"), new CID(2,"進貨"), new CID(3,"費用"),new CID(4,"POS"),new CID(5,"出貨"),new CID(6,"銀行"),new CID(7,"未知")};
        public enum AccDataSource { MenualInput=1, Voucher, Expense, PosRevenue, Shipment, Bank }
        private void FormAccounting_Load(object sender, EventArgs e)
        {
            try
            {
                this.bankAccountTableAdapter.Fill(this.damaiDataSet.BankAccount);
                this.customerTableAdapter.Fill(this.damaiDataSet.Customer);
                this.vendorTableAdapter.Fill(this.damaiDataSet.Vendor);

                operatorTableAdapter.Connection.ConnectionString = DB.SqlConnectString(MyFunction.HardwareCfg);
                this.operatorTableAdapter.Fill(this.damaiDataSet.Operator);

                this.hRTableAdapter.Fill(this.damaiDataSet.HR);
                this.accountingTitleTableAdapter.Fill(this.damaiDataSet.AccountingTitle);

                this.shipmentTableAdapter.Fill(this.damaiDataSet1.Shipment);
                this.headerTableAdapter.Fill(this.damaiDataSet1.Header);
                this.expenseTableAdapter.Fill(this.damaiDataSet1.Expense);
                this.voucherTableAdapter.Fill(this.damaiDataSet1.Voucher);
                this.bankDetailTableAdapter.Fill(this.damaiDataSet1.BankDetail);

                this.accVouchTableAdapter.Fill(this.damaiDataSet.AccVouch);
                this.accVouchDetailTableAdapter.Fill(this.damaiDataSet.AccVouchDetail);
                Setup.Load();
                CopyDataNotInAccVouch(AccDataSource.MenualInput,damaiDataSet1,damaiDataSet,damaiDataSet.AccVouchDetail);
                cIDBindingSource.DataSource = SourceNames;
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入資料時發生錯誤,原因:" + ex.Message);
            }
            dateTimePicker1.MaxDate = new DateTime(MyFunction.IntHeaderYear, 12, 31);
            dateTimePicker1.MinDate = new DateTime(MyFunction.IntHeaderYear, 1, 1);
        }

        // MenualInput代表全部
        void CopyDataNotInAccVouch(AccDataSource working,DamaiDataSet sourceDS,DamaiDataSet destDS,DamaiDataSet.AccVouchDetailDataTable accDetailTable)
        {
            switch(working)
            {
                case AccDataSource.Bank:        destDS.BankDetail.Rows.Clear();
                                                foreach(var r in sourceDS.BankDetail)  destDS.BankDetail.ImportRow(r);
                                                break;
                case AccDataSource.Expense:     destDS.Expense.Rows.Clear();
                                                foreach (var r in sourceDS.Expense) destDS.Expense.ImportRow(r);
                                                break;
                case AccDataSource.PosRevenue:  destDS.Header.Rows.Clear();
                                                foreach (var r in sourceDS.Header) destDS.Header.ImportRow(r);
                                                break;
                case AccDataSource.Shipment:    destDS.Shipment.Rows.Clear();
                                                foreach (var r in sourceDS.Shipment) destDS.Shipment.ImportRow(r);
                                                break;
                case AccDataSource.Voucher:     destDS.Voucher.Rows.Clear();
                                                foreach (var r in sourceDS.Voucher) destDS.Voucher.ImportRow(r);
                                                break;
                default:
                    destDS.BankDetail.Rows.Clear();
                    destDS.Expense.Rows.Clear();
                    destDS.Header.Rows.Clear();
                    destDS.Shipment.Rows.Clear();
                    destDS.Voucher.Rows.Clear();
                    foreach (var r in sourceDS.BankDetail) destDS.BankDetail.ImportRow(r);
                    foreach (var r in sourceDS.Expense)    destDS.Expense.ImportRow(r);
                    foreach (var r in sourceDS.Header)     destDS.Header.ImportRow(r);
                    foreach (var r in sourceDS.Shipment)   destDS.Shipment.ImportRow(r);
                    foreach (var r in sourceDS.Voucher)    destDS.Voucher.ImportRow(r);
                    break;
            }
            //var accDetailRows=from r in accDetailTable 
            //                  where (!r.IsSourceDataTypeNull()) && (r.SourceDataID!=(short)AccDataSource.MenualInput) 
            //                  orderby r.SourceDataType,r.SourceDataID
            //                  select r ;
            foreach (var acc in accDetailTable)
            {
                if (acc.IsSourceDataTypeNull() || acc.IsSourceDataIDNull()) continue;
                if (acc.SourceDataType == (short)AccDataSource.MenualInput) continue;
                if (working != AccDataSource.MenualInput)
                {
                    if (acc.SourceDataType != (short)working) continue;
                }
                switch ((AccDataSource)acc.SourceDataType)
                {
                    case AccDataSource.Bank:    var bankRow=destDS.BankDetail.FindByID(acc.SourceDataID);
                                                if (bankRow!=null) destDS.BankDetail.RemoveBankDetailRow(bankRow);
                                                break;
                    case AccDataSource.Expense: var expenseRow=destDS.Expense.FindByID(acc.SourceDataID);
                                                if (expenseRow!=null) destDS.Expense.RemoveExpenseRow(expenseRow);
                                                break;
                    case AccDataSource.PosRevenue:
                                                var posRow=destDS.Header.FindByDataDate(Int2Date(acc.SourceDataID));
                                                if (posRow!=null) destDS.Header.RemoveHeaderRow(posRow);
                                                break;
                    case AccDataSource.Shipment:
                                                var shipmentRow=destDS.Shipment.FindByID(acc.SourceDataID);
                                                if (shipmentRow!=null) destDS.Shipment.RemoveShipmentRow(shipmentRow);
                                                break;
                    case AccDataSource.Voucher: var voucherRow=destDS.Voucher.FindByID(acc.SourceDataID);
                                                if (voucherRow!=null) destDS.Voucher.RemoveVoucherRow(voucherRow);
                                                break;
                }
            }
        }

        DateTime Int2Date(int i)
        {
            if (i<=0) return DateTime.MinValue;
            int d = i % 32;
            int m = i / 32;
            int y = m / 16;
            m %= 16;
            if (d>31) return DateTime.MinValue;
            if (m>12) return DateTime.MinValue;
            return new DateTime(y, m, d);
        }

        int Date2Int(DateTime dt)
        {
            return dt.Day + dt.Month * 32 + dt.Year * 32 * 16;
        }


        
        #region ====== DragDrop Function ======
        class AccDragItem
        {
            public AccDataSource dataSourceType;
            public int      intDragID;
            public DataGridView dgv;
            public DataGridViewRow row;
        }

        private void DGV_DoDragDrop(DataGridView dgv,string columnName,DataGridViewCellMouseEventArgs e,AccDataSource sourceType)
        {
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0)
                {
                    return;
                }
                List<AccDragItem> list = new List<AccDragItem>();
                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    AccDragItem item = new AccDragItem();
                    item.dataSourceType = sourceType;
                    item.dgv = dgv;
                    if (sourceType == AccDataSource.PosRevenue)
                        item.intDragID = Date2Int((DateTime)row.Cells[columnName].Value);
                    else
                        item.intDragID = (int)row.Cells[columnName].Value;
                    item.row = row;
                    list.Add(item);
                }
                if (list.Count!=0)
                    DoDragDrop(list, DragDropEffects.Copy);
            }
            catch { }
        }

        private void dgvVoucher_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            DGV_DoDragDrop(sender as DataGridView,"voucherColumnID",e,AccDataSource.Voucher);
        }

        private void dgvExpense_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            DGV_DoDragDrop(sender as DataGridView,"expenseColumnID", e, AccDataSource.Expense);
        }

        private void headerDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            DGV_DoDragDrop(sender as DataGridView, "revenueColumnDate", e, AccDataSource.PosRevenue);
        }

        private void shipmentDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            DGV_DoDragDrop(sender as DataGridView,"shipmentColumnID", e, AccDataSource.Shipment);

        }

        private void dgvBankDetail_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            DGV_DoDragDrop(sender as DataGridView,"bankColumnID", e, AccDataSource.Bank);
        }


        private void accVoucherDetailDataGridView_DragEnter(object sender, DragEventArgs e)
        {
            var view = sender as DataGridView;
            view.BackgroundColor = Color.SeaShell;
            e.Effect = DragDropEffects.Copy;
        }

        private void accVoucherDetailDataGridView_DragLeave(object sender, EventArgs e)
        {
            var view = sender as DataGridView;
            view.BackgroundColor = Color.FromArgb(216, 228, 248);
        }

        private void accVoucherDetailDataGridView_DragDrop(object sender, DragEventArgs e)
        {
            var view = sender as DataGridView;
            view.BackgroundColor = Color.FromArgb(216, 228, 248);
            if (dgvAccVoucher.Rows.Count == 0)
            {
                MessageBox.Show("請新增傳票,再拖資料!");
                return;
            }
            var list=e.Data.GetData(typeof(List<AccDragItem>)) as List<AccDragItem>;
            if (list.Count != 0)
            {
                var rowView = accVouchBindingSource.Current as DataRowView;
                DamaiDataSet.AccVouchRow parent = rowView.Row as DamaiDataSet.AccVouchRow;
                if (parent != null)
                {
                    foreach (var item in list)
                    {
                        if (AddAccVoucherDetail(item, parent))
                            item.dgv.Rows.Remove(item.row);
                    }
                }
                CalcTotalAndSetMoney();
            }
            accVouchBindingSource.ResetBindings(false);
        }
        #endregion

        private DamaiDataSet.AccVouchRow CalcTotalAndSetMoney()
        {
            var rowView = accVouchBindingSource.Current as DataRowView;
            if (rowView == null) return null;
            DamaiDataSet.AccVouchRow parent = rowView.Row as DamaiDataSet.AccVouchRow;
            if (parent == null) return parent;
            decimal credit = 0, debt = 0;
            var details = parent.GetAccVouchDetailRows();
            foreach (var row in details)
            {
                if (!row.IsCreditNull()) credit += row.Credit;
                if (!row.IsDebtNull())   debt   += row.Debt;
            }
            labelDebt.Text = debt.ToString("N2");
            labelCredit.Text = credit.ToString("N2");
            if (parent.IsMoneyNull() || parent.Money!=debt) parent.Money = debt;
            return parent;
        }

        private string SafeNote(string note)
        {
            int maxLen=damaiDataSet.AccVouchDetail.NoteColumn.MaxLength;
            if (note.Length > maxLen) return note.Substring(0, maxLen);
            return note;
        }

        private bool AddAccVoucherDetail(AccDragItem item,DamaiDataSet.AccVouchRow parent)
        {
            if (parent == null) return false;
            if (item.row == null) return false;
            if (item.row.DataBoundItem == null || item.row.DataBoundItem == DBNull.Value) return false;
            string note = "",note1;
            string creditCode="", debtCode = "";
            var sourceRowView = item.row.DataBoundItem as DataRowView;
            if (sourceRowView==null) return false;
            if (sourceRowView.Row==null) return false;
            var detailTable = damaiDataSet.AccVouchDetail;
            try
            {
                short shType=(short)item.dataSourceType;
                string strDay;
                switch (item.dataSourceType)
                {
                    case AccDataSource.Voucher:
                        var voucherRow = sourceRowView.Row as DamaiDataSet.VoucherRow;
                        note = SafeNote(voucherRow.VendorRow.Name + " " + voucherRow.StockTime.Month.ToString() + "月貨款") ;
                        string dotVendorID="."+(voucherRow.IsVendorIDNull()?"x":voucherRow.VendorID.ToString());
                        note1=SafeNote(note + voucherRow.VoucherID);
                        detailTable.AddAccVouchDetailRow(Guid.NewGuid(), parent, Setup.AssetIngredients              , voucherRow.Cost,0, note1, shType, item.intDragID);
                        detailTable.AddAccVouchDetailRow(Guid.NewGuid(), parent, Setup.VoucherShouldPay + dotVendorID, 0,voucherRow.Cost, note1, shType, item.intDragID);
                        if (parent.IsNoteNull()) parent.Note = note;
                        return true;
                    case AccDataSource.Expense:
                        var expenseRow = sourceRowView.Row as DamaiDataSet.ExpenseRow;
                        strDay=expenseRow.IsApplyTimeNull()?"":expenseRow.ApplyTime.ToString("M/dd");
                        if (!expenseRow.IsNoteNull()) note = SafeNote(expenseRow.Note);
                        if (expenseRow.IsTitleCodeCreditNull())
                            creditCode = damaiDataSet.BankAccount[0].AccountTitleCode;
                        else
                            creditCode = expenseRow.TitleCodeCredit;
                        if (!expenseRow.IsTitleCodeNull()) debtCode = expenseRow.TitleCode;
                        detailTable.AddAccVouchDetailRow(Guid.NewGuid(), parent, debtCode   , expenseRow.Money, 0 , strDay+note, shType, item.intDragID);
                        detailTable.AddAccVouchDetailRow(Guid.NewGuid(), parent, creditCode , 0,  expenseRow.Money, strDay+note, shType, item.intDragID);
                        if (parent.IsNoteNull())
                            parent.Note = "零用金 "+note + " ...";
                        return true;
                    case AccDataSource.PosRevenue: 
                        var revenueRow = sourceRowView.Row as DamaiDataSet.HeaderRow;
                        note = SafeNote(revenueRow.DataDate.ToString("M/dd"));
                        if (!revenueRow.IsRevenueNull()   && revenueRow.IsCashNull() &&
                            revenueRow.IsCreditCardNull() && revenueRow.IsCoupondNull())
                        {
                            detailTable.AddAccVouchDetailRow(Guid.NewGuid(), parent, Setup.CashIncome    , 0 , revenueRow.Revenue , note + "營收", shType, item.intDragID);
                            detailTable.AddAccVouchDetailRow(Guid.NewGuid(), parent, Setup.CashReceivable, revenueRow.Revenue , 0 , note + "营收", shType, item.intDragID);
                        }
                        if (!revenueRow.IsCashNull() && revenueRow.Cash!=0)
                        {
                            detailTable.AddAccVouchDetailRow(Guid.NewGuid(), parent, Setup.CashIncome    , 0, revenueRow.Cash, note + "现金营收", shType, item.intDragID);
                            detailTable.AddAccVouchDetailRow(Guid.NewGuid(), parent, Setup.CashReceivable, revenueRow.Cash,0 , note + "现金营收", shType, item.intDragID);
                        }
                        if (!revenueRow.IsCreditCardNull() && revenueRow.CreditCard!=0)
                        {
                            detailTable.AddAccVouchDetailRow(Guid.NewGuid(), parent, Setup.CardIncome    , 0, revenueRow.CreditCard, note + "刷卡营收", shType, item.intDragID);
                            detailTable.AddAccVouchDetailRow(Guid.NewGuid(), parent, Setup.CardReceivable, revenueRow.CreditCard, 0, note + "刷卡营收", shType, item.intDragID);
                        }
                        if (!revenueRow.IsCoupondNull() && revenueRow.Coupond!=0)
                        {
                            detailTable.AddAccVouchDetailRow(Guid.NewGuid(), parent, Setup.SoldOnCreditIncome, 0 , revenueRow.Coupond, note + "赊销-劵", shType, item.intDragID);
                            detailTable.AddAccVouchDetailRow(Guid.NewGuid(), parent, Setup.SoldOnCreditReceivable, revenueRow.Coupond, 0, note + "赊销-劵", shType, item.intDragID);
                        }
                        if (parent.IsNoteNull())
                            parent.Note = note + "營收";
                        return true;
                    case AccDataSource.Bank:
                        var bankRow = sourceRowView.Row as DamaiDataSet.BankDetailRow;
                        if (bankRow==null) return false;
                        int bankID=bankRow.BankID;
                        var bankAccRow= damaiDataSet.BankAccount.FindByID(bankID);
                        string bankName = "銀行" + bankID.ToString();
                        if (bankAccRow != null && !bankAccRow.IsShowNameNull())
                            bankName=bankAccRow.ShowName;
                        strDay =(bankRow.IsDayNull()?"":bankRow.Day.ToString("M/dd")) ;
                        note =SafeNote("<"+bankName+strDay+ ">" + (bankRow.IsNoteNull() ? "" : bankRow.Note) );
                        creditCode = bankAccRow.AccountTitleCode+"."+bankID.ToString();
                        debtCode = bankRow.IsTitleCodeNull() ? "" : bankRow.TitleCode;
                        if (bankRow.IsIsCreditNull() || !bankRow.IsCredit)  // 存款增加  
                        {
                            detailTable.AddAccVouchDetailRow(Guid.NewGuid(), parent, creditCode  , bankRow.Money,0 , note, (short)item.dataSourceType, item.intDragID);
                            detailTable.AddAccVouchDetailRow(Guid.NewGuid(), parent, debtCode, 0,bankRow.Money , note, (short)item.dataSourceType, item.intDragID);
                        }
                        else
                        {
                            detailTable.AddAccVouchDetailRow(Guid.NewGuid(), parent, creditCode, 0, bankRow.Money, note, (short)item.dataSourceType, item.intDragID);
                            detailTable.AddAccVouchDetailRow(Guid.NewGuid(), parent, debtCode  , bankRow.Money, 0, note, (short)item.dataSourceType, item.intDragID);
                        }
                        if (parent.IsNoteNull()) parent.Note = note;
                        return true;
                    case AccDataSource.Shipment:
                        var shipmentRow = sourceRowView.Row as DamaiDataSet.ShipmentRow;
                        if (shipmentRow.IsCustomerNull())
                             note  = "";
                        else note  = shipmentRow.CustomerRow.Name + " " ;
                        if (!shipmentRow.IsShipTimeNull())
                             note += shipmentRow.ShipTime.Month.ToString() + "月進貨";
                        note1 = SafeNote(note + (shipmentRow.IsShipCodeNull() ? "" : shipmentRow.ShipCode.ToString()) );
                        string dotCumstomerID = "." + (shipmentRow.IsCustomerNull()?"x":shipmentRow.Customer.ToString());
                        debtCode = Setup.SoldOnCreditReceivable +dotCumstomerID;
                        creditCode=Setup.SoldOnCreditIncome     +dotCumstomerID;
                        decimal cost = (shipmentRow.IsCostNull()?0:shipmentRow.Cost);
                        detailTable.AddAccVouchDetailRow(Guid.NewGuid(), parent, debtCode  , cost, 0 ,note1,  (short)item.dataSourceType, item.intDragID);
                        detailTable.AddAccVouchDetailRow(Guid.NewGuid(), parent,creditCode   , 0,  cost,note1,  (short)item.dataSourceType, item.intDragID);
                        if (parent.IsNoteNull())
                            parent.Note = SafeNote("赊销 " + note);
                        return true;
                    default: return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("加入傳票項目時出錯,原因:" + ex.Message);
                return false;
            }
        }


        private void accVoucherDetailDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e==null) return;
            int col = e.ColumnIndex;
            if (col < 0) return;
            if (e.RowIndex < 0) return;
            var view = sender as DataGridView;
            DataGridViewRow viewRow = view.Rows[e.RowIndex];
            var cell = viewRow.Cells[col];
            if (cell == null) return;
            var sourceType = viewRow.Cells["ColumnSourceDataType"];
            if (sourceType != null)
            {
                int i=(int)AccDataSource.MenualInput;
                int j = i;
                if (sourceType.Value!=null && sourceType.Value!=DBNull.Value) j=(short)sourceType.Value;
                if (i!=j) e.CellStyle.BackColor = Color.Azure;
            }
            string columnName = view.Columns[col].Name;
            if (columnName == "ColumnDebt" || columnName == "ColumnCredit")
            {
                if (cell.Value == DBNull.Value || cell.Value == null || ((decimal)cell.Value == 0m))
                {
                    e.Value = "";
                }
            }
            else if (columnName == "ColumnAccName")
            {
                var codeCell = viewRow.Cells["ColumnAccCode"];
                if (codeCell!=null && codeCell.Value!=null)
                {
                    string code = codeCell.Value as string;
                    if (code!=null && code.Length > 0)
                    {
                        int n = code.IndexOf('.');
                        if (n >= 0 && n < code.Length) code = code.Substring(0, n);
                        var acc = damaiDataSet.AccountingTitle.FindByTitleCode(code);
                        if (acc == null)
                             e.Value = "";
                        else e.Value = acc.Name;
                    }
                }
            }
            //else if (columnName == "ColumnSourceDataType")
            //{
            //    DataRowView rowView= viewRow.DataBoundItem as DataRowView;
            //    if (rowView != null)
            //    {
            //        var row = rowView.Row as DamaiDataSet.AccVouchDetailRow;
            //        if (row != null)
            //        {
            //            if (!row.IsSourceDataTypeNull() && !row.IsSourceDataIDNull() && row.SourceDataType != (short)AccDataSource.MenualInput)
            //                cell.ToolTipText = ((AccDataSource)row.SourceDataType).ToString() + row.SourceDataID.ToString();
            //        }
            //    }
            //}
        }

        private void dgvAccVoucherDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e == null) return;
            int col = e.ColumnIndex;
            if (col < 0) return;
            if (e.RowIndex < 0) return;
            var view = sender as DataGridView;
            var viewRow = view.Rows[e.RowIndex];
            var cell = viewRow.Cells[col];
            if (cell == null) return;
            string columnName = view.Columns[col].Name;
            if (columnName == "ColumnDebt")
            {
                decimal money = 0;
                foreach (DataGridViewRow row in view.Rows)
                {
                    var cel = row.Cells[col];
                    if (cel.Value == DBNull.Value || cel.Value == null) continue;
                    money += (decimal)cel.Value;
                }
                labelDebt.Text = money.ToString("N2");
            }
            else if (columnName == "ColumnCredit")
            {
                decimal money = 0;
                foreach (DataGridViewRow row in view.Rows)
                {
                    var cel = row.Cells[col];
                    if (cel.Value == DBNull.Value || cel.Value == null) continue;
                    money += (decimal)cel.Value;
                }
                labelCredit.Text = money.ToString("N2");
            }
            else if (columnName == "ColumnAccCode")
            {
                view.InvalidateCell(viewRow.Cells["ColumnAccName"]);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (m_SelectedMonth <= 0 || m_SelectedMonth > 12)
            {
                MessageBox.Show("請選擇月份再新增!");
                return;
            }
            try
            {
                accVouchBindingSource.AddNew();
                MyFunction.AddNewItem(dgvAccVoucher, "ColumnAccVoucherID", "ID", damaiDataSet.AccVouch);
                var rowView = (DataRowView)accVouchBindingSource.Current;
                var accVouch = rowView.Row as DamaiDataSet.AccVouchRow;
                accVouch.Money = 0;
                if (m_SelectedMonth > 0 && m_SelectedMonth <= 12)
                {
                    int year=MyFunction.IntHeaderYear;
                    accVoucherTimeTextBox.Text = (new DateTime(year, m_SelectedMonth, 28)).ToShortDateString();
                    var serials = from r in damaiDataSet.AccVouch
                                  where !r.IsAccVoucherTimeNull() && r.AccVoucherTime.Month == m_SelectedMonth && !r.IsAccVoucherIDNull()
                                  select r.AccVoucherID % 1000;
                    int no =1;
                    if (serials.Count()!=0) no= serials.Max() + 1;
                    accVoucherIDTextBox.Text = (year % 100).ToString("d2") + m_SelectedMonth.ToString("d2")+no.ToString("d3");
                }
                accVouchBindingSource.EndEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("加入新傳票時出錯,原因:" + ex.Message);
            }
        }

        private void dgvAccVoucherDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            int col = e.ColumnIndex;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            accVoucherTimeTextBox.Text = dateTimePicker1.Value.ToShortDateString();
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
            this.accVouchBindingSource.EndEdit();
            this.accVouchDetailBindingSource.EndEdit();
            var table  = (DamaiDataSet.AccVouchDataTable)damaiDataSet.AccVouch.GetChanges();
            var detail = (DamaiDataSet.AccVouchDetailDataTable)damaiDataSet.AccVouchDetail.GetChanges();
            if ((table == null || table.Rows.Count <= 0) && (detail == null || detail.Rows.Count <= 0))
            {
                MessageBox.Show("沒有改變,無需存檔!");
                return;
            }
            try
            {
                if (detail != null)
                {   // 處理刪除的部分(因為FK設定為Cascade,不能先刪主記錄)
                    var deletedDetails = from d in detail where d.RowState == DataRowState.Deleted select d;
                    if (deletedDetails!=null && deletedDetails.Count()>0)
                        accVouchDetailTableAdapter.Update(deletedDetails.ToArray());
                }
                if (table != null && table.Rows.Count > 0)
                {
                    this.damaiDataSet.AccVouch.Merge(table);
                    accVouchTableAdapter.Update(damaiDataSet.AccVouch);
                    damaiDataSet.AccVouch.AcceptChanges();
                }
                if (detail != null && detail.Rows.Count > 0)
                {
                    var modifiedDetails = from d in detail where d.RowState != DataRowState.Deleted select d;
                    if (modifiedDetails != null && modifiedDetails.Count() > 0)
                        accVouchDetailTableAdapter.Update(modifiedDetails.ToArray());
                    this.damaiDataSet.AccVouchDetail.Merge(detail);
                    damaiDataSet.AccVouchDetail.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("存檔失敗! 原因:" + ex.Message);
                return;
            }
            MessageBox.Show("己存檔!");
        }

        // 要等到Form_Shown再綁上這個EventHandler,要不然 parent.GetAccVouchDetailRows() 會沒有record,莫明所以
        private void accVouchBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            CalcTotalAndSetMoney();
        }

        private void FormAccounting_Shown(object sender, EventArgs e)
        {
            CalcTotalAndSetMoney();
            accVouchBindingSource.CurrentChanged += new EventHandler(this.accVouchBindingSource_CurrentChanged);
        }

        private void dgvAccVoucherDetail_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridViewRow row = e.Row;
            row.Cells["ColumnDetailID"].Value = Guid.NewGuid();
        }

        private void DeleteRelatedDGV(AccDataSource sourceType, List<int> list)
        {
            if (list == null) return;
            switch (sourceType)
            {
                case AccDataSource.Bank: 
                    foreach (int id in list)
                    {
                        var bankRow = damaiDataSet.BankDetail.FindByID(id);
                        if (bankRow == null)
                        {
                            var bankRow1 = damaiDataSet1.BankDetail.FindByID(id);
                            damaiDataSet.BankDetail.ImportRow(bankRow1);
                        }
                    }
                    bankBindingSource.ResetBindings(false);
                    break;
                case AccDataSource.Expense:
                    foreach (int id in list)
                    {
                        var expenseRow = damaiDataSet.Expense.FindByID(id);
                        if (expenseRow == null)
                        {
                            var expenseRow1 = damaiDataSet1.Expense.FindByID(id);
                            damaiDataSet.Expense.ImportRow(expenseRow1);
                        }
                    }
                    expenseBindingSource.ResetBindings(false);
                    break;
                case AccDataSource.PosRevenue:
                    foreach (int d in list)
                    {
                        DateTime da=Int2Date(d);
                        var revenueRow = damaiDataSet.Header.FindByDataDate(da);
                        if (revenueRow==null)
                        {
                            var revenueRow1=damaiDataSet1.Header.FindByDataDate(da);
                            damaiDataSet.Header.ImportRow(revenueRow1);
                        }
                    }
                    headerBindingSource.ResetBindings(false);
                    break;
                case AccDataSource.Shipment:
                    foreach (int id in list)
                    {
                        var shipmentRow = damaiDataSet.Shipment.FindByID(id);
                        if (shipmentRow == null)
                        {
                            var shipmentRow1 = damaiDataSet1.Shipment.FindByID(id);
                            damaiDataSet.Shipment.ImportRow(shipmentRow1);
                        }
                    }
                    shipmentBindingSource.ResetBindings(false);
                    break;
                case AccDataSource.Voucher:
                    foreach (int id in list)
                    {
                        var voucherRow = damaiDataSet.Voucher.FindByID(id);
                        if (voucherRow == null)
                        {
                            var voucherRow1 = damaiDataSet1.Voucher.FindByID(id);
                            damaiDataSet.Voucher.ImportRow(voucherRow1);
                        }
                    }
                    voucherBindingSource.ResetBindings(false);
                    break;
            }
        }

        private void dgvAccVoucherDetail_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var view = sender as DataGridView;
            DataGridViewRow viewRow = e.Row;
            var rowView= viewRow.DataBoundItem as DataRowView;
            if (rowView == null) return;
            var acc=rowView.Row as DamaiDataSet.AccVouchDetailRow;
            if (acc.IsSourceDataTypeNull()) return;
            if (acc.IsSourceDataIDNull()) return;
            if (acc.SourceDataType == (short)AccDataSource.MenualInput) return;
            //if (acc.SourceDataType == (short)AccDataSource.PosRevenue ) return;
            //if (acc.SourceDataType == (short)AccDataSource.Bank       ) return;
            e.Cancel = true;
            short sourceType = acc.SourceDataType;
            int sourceID = acc.SourceDataID;
            List<int> list = new List<int>();
            for (int i = view.Rows.Count-1; i >=0;i--)
            {
                var rowView1 = view.Rows[i].DataBoundItem as DataRowView;
                if (rowView1 == null) continue;  // 最後一行,有*号的為Detached會這樣
                var acc1 = rowView1.Row as DamaiDataSet.AccVouchDetailRow;
                if (acc1 == null) continue;
                if (acc1.IsSourceDataTypeNull()) continue;
                if (acc1.IsSourceDataIDNull()) continue;
                if (acc1.SourceDataType != sourceType) continue;
                if (acc1.SourceDataID != sourceID) continue;
                list.Add(acc1.SourceDataID);
                view.Rows.RemoveAt(i);     // 移除同一來源的資料
            }
            DeleteRelatedDGV((AccDataSource)sourceType, list);
            CalcTotalAndSetMoney();
        }

        private void dgvAccVoucher_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var view = sender as DataGridView;
            DataGridViewRow viewRow = e.Row;
            var rowView = viewRow.DataBoundItem as DataRowView;
            if (rowView == null) return;
            DamaiDataSet.AccVouchRow acc = rowView.Row as DamaiDataSet.AccVouchRow;
            var details = acc.GetAccVouchDetailRows();
            var dic = new Dictionary<AccDataSource, List<int>>();
            dic.Add(AccDataSource.Voucher   , new List<int>());
            dic.Add(AccDataSource.Expense   , new List<int>());
            dic.Add(AccDataSource.PosRevenue, new List<int>());
            dic.Add(AccDataSource.Shipment  , new List<int>());
            dic.Add(AccDataSource.Bank      , new List<int>());
            List<int> list = new List<int>();
            foreach (var acc1 in details)
            {
                if ((!acc1.IsSourceDataTypeNull()) && (!acc1.IsSourceDataIDNull()))
                {
                    if (dic.TryGetValue((AccDataSource)acc1.SourceDataType, out list))
                        list.Add(acc1.SourceDataID);
                }
                acc1.Delete();
            }
            foreach (var pair in dic)
                DeleteRelatedDGV(pair.Key, pair.Value);
        }

        int m_SelectedMonth = -1;
        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            int index = m_SelectedMonth=comboBox.SelectedIndex;
            string strYearDash = MyFunction.IntHeaderYear.ToString()+"-";
            if (index <= 0 || index > 12)
                accVouchBindingSource.RemoveFilter();
            else
            {
                if (index == 1)
                    accVouchBindingSource.Filter = "AccVoucherTime<'" + strYearDash + "02-01'";
                else if (index == 12)
                    accVouchBindingSource.Filter = "AccVoucherTime>='" + strYearDash + "12-01'";
                else
                {
                    string strMon = index.ToString();
                    string nextMon = (index + 1).ToString();
                    accVouchBindingSource.Filter = "AccVoucherTime>='" + strYearDash +strMon+"-01' And AccVoucherTime<'"+strYearDash+nextMon+"-01'";
                }
            }

        }

        private void dgvTitleTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvTitleTable.Visible = false;
        }

        private void dgvAccVoucherDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex < 0) return;
            var view = sender as DataGridView;
            string colName = view.Columns[e.ColumnIndex].Name;
            if (colName == "ColumnAccName")
            {
                dgvTitleTable.Visible = true;
            }
        }

        private void dgvTitleTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvTitleTable.Visible = false;
        }

        private void dgvAccVoucherDetail_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex < 0) return;
            var view = sender as DataGridView;
            string colName = view.Columns[e.ColumnIndex].Name;
            if (colName == "ColumnDebt" || colName=="ColumnCredit")
            {
                var viewRow = view.Rows[e.RowIndex];
                var idCell= viewRow.Cells["ColumnSourceDataID"];
                if (idCell.Value != null && idCell.Value != DBNull.Value)
                {
                    e.Cancel = true;
                    return;
                }
            }
            
        }
    }
}
