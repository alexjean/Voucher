using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
#if UseSQLServer
using MyDataSet = VoucherExpense.DamaiDataSet;
using MyBankDetailAdapter = VoucherExpense.DamaiDataSetTableAdapters.BankDetailTableAdapter;
using MyBankDetailTable = VoucherExpense.DamaiDataSet.BankDetailDataTable;
#else
using MyDataSet = VoucherExpense.VEDataSet;
using MyBankDetailAdapter = VoucherExpense.VEDataSetTableAdapters.BankDetailTableAdapter;
using MyBankDetailTable = VoucherExpense.VEDataSet.BankDetailDataTable;
#endif

namespace VoucherExpense
{
    public partial class FormImportBankExcel : Form
    {
        public FormImportBankExcel()
        {
            InitializeComponent();
        }

        string m_FileName;
        bool m_CloseForm = false;
        ExcelLib excel = null;

        MyDataSet m_DataSet = new MyDataSet();
        MyBankDetailAdapter BankDetailAdapter = new MyBankDetailAdapter();

        //private void MakeBankAccountComboBox()
        //{
        //    BankAccountAdapter.Fill(this.m_DataSet.BankAccount);
        //    List<CBankAccountForComboBox> list = new List<CBankAccountForComboBox>();
        //    CBankAccountForComboBox acc = new CBankAccountForComboBox();
        //    list.Add(acc);
        //    foreach (var r in m_DataSet.BankAccount)
        //    {
        //        if (r.ID != 1)   // ID 1是給零用金的特殊帳號
        //        {
        //            acc = new CBankAccountForComboBox();
        //            acc.Name = r.ShowName;
        //            acc.ID   = r.ID;
        //            list.Add(acc);
        //        }
        //    }
        //    cbBankAccount.DataSource = list;
        //}

        private void FormImportBankExcel_Load(object sender, EventArgs e)
        {
            string[] names = null;
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                m_CloseForm = true;
                return;
            }
            m_FileName = openFileDialog1.FileName;
            try
            {
                excel = new ExcelLib();
                names = excel.SheetNames(m_FileName);
                if (names == null || names.Length < 1)
                {
                    MessageBox.Show("找不到<" + m_FileName + ">!");
                    m_CloseForm = true;
                    return;
                }
                cbSheetNames.Items.Clear();
                foreach (string name in names)
                    cbSheetNames.Items.Add(name);
            }
            catch
            {
                MessageBox.Show("轉換Excel表過程出錯! 是否沒有安裝Excel或 Microsoft.Office.Interop.Excel.dll不存在!");
                m_CloseForm = true;
            }
#if (UseSQLServer)
            var bankAccountAdapter = new VoucherExpense.DamaiDataSetTableAdapters.BankAccountTableAdapter();
#else
            var bankAccountAdapter = new VoucherExpense.VEDataSetTableAdapters.BankAccountTableAdapter();
            BankDetailAdapter.Connection  = MapPath.VEConnection;
            bankAccountAdapter.Connection = MapPath.VEConnection;    //必需在 MakeBankAccountComboBox()之前
#endif
            //            MakeBankAccountComboBox();
            bankAccountAdapter.Fill(this.m_DataSet.BankAccount);
            List<CBankAccountForComboBox> list = new List<CBankAccountForComboBox>();
            CBankAccountForComboBox acc = new CBankAccountForComboBox();
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
            cbBankAccount.DataSource = list;
        }

        int indexDate = 0;
        int indexDebt = 1;
        int indexCredit = 2;
        int indexNote = 3;
        DataTable m_Table;
        private void cbSheetNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box=(ComboBox)sender;
            string sheet = box.SelectedItem.ToString();
            DataSet data = excel.LoadData(m_FileName, sheet);
            if (data==null || data.Tables.Count == 0)
            {
                MessageBox.Show("無法載入Excel檔! 可能別人正在使用,或多次呼叫Excel.exe當在記憶體中");
                return;
            }
            m_Table = data.Tables[0];
            cbDate.Items.Clear();
            cbDebt.Items.Clear();
            cbCredit.Items.Clear();
            cbNote.Items.Clear();
            if (m_Table.Rows.Count == 0)
            {
                dgViewImport.DataSource=new List<CBankDetail>();
                ShowWarning(true);
                MessageBox.Show("此表沒有資料!");
                return;
            }
            DataColumnCollection cols = m_Table.Columns;
            foreach (DataColumn col in cols)
            {
                string str = col.Caption;
                cbDate.Items.Add(str);
                cbDebt.Items.Add(str);
                cbCredit.Items.Add(str);
                cbNote.Items.Add(str);
            }
            GuessColumns(cols);
            ReadTable(m_Table);
        }

        private void GuessColumns(DataColumnCollection cols)
        {

            indexDate = 0;
            indexDebt = 1;
            indexCredit = 2;
            indexNote = cols.Count - 1;
            int i;
            for (i = 0; i < cols.Count; i++)
            {
                if (cols[i].ColumnName.Contains("日期"))
                {
                    indexDate = i;
                    break;
                }
            }
            for (i = 0; i < cols.Count; i++)
            {
                if (cols[i].ColumnName.Contains("支出"))
                {
                    indexDebt = i;
                    break;
                }
            }
            for (i = 0; i < cols.Count; i++)
            {
                if (cols[i].ColumnName.Contains("存入"))
                {
                    indexCredit = i;
                    break;
                }
            }
            for (i = 0; i < cols.Count; i++)
            {
                if (cols[i].ColumnName.Contains("摘要"))
                {
                    indexNote = i;
                    break;
                }
            }
            cbDate.SelectedIndexChanged     -= cbDate_SelectedIndexChanged;
            cbDebt.SelectedIndexChanged     -= cbDebt_SelectedIndexChanged;
            cbCredit.SelectedIndexChanged   -= cbCredit_SelectedIndexChanged;
            cbNote.SelectedIndexChanged     -= cbNote_SelectedIndexChanged;
            cbDate.SelectedIndex    = indexDate ;
            cbDebt.SelectedIndex    = indexDebt ;
            cbCredit.SelectedIndex  = indexCredit ;
            cbNote.SelectedIndex    = indexNote ;
            cbDate.SelectedIndexChanged     += cbDate_SelectedIndexChanged;
            cbDebt.SelectedIndexChanged     += cbDebt_SelectedIndexChanged;
            cbCredit.SelectedIndexChanged   += cbCredit_SelectedIndexChanged;
            cbNote.SelectedIndexChanged     += cbNote_SelectedIndexChanged;
        }

        void ShowWarning(bool visable)
        {
            labelWarning1.Visible = labelWarning2.Visible = labelWarning3.Visible= visable;
            btnConvert.Enabled = !visable;
        }

        BindingList<CBankDetail> m_ImportDataList=null;

        void ReadTable(DataTable table)
        {
            BindingList<CBankDetail> list = new BindingList<CBankDetail>();
            int correct = 0, error = 0;
            foreach (DataRow row in table.Rows)
            {
                CBankDetail d = new CBankDetail();
                decimal dec;
                try
                {
                    string s = row[indexDate].ToString().Trim();
                    if (s.Length == 0) continue;    // 這個比try快的多, 日期錯,不列入計算行數
                    d.Date = Convert.ToDateTime(s);
                    s = row[indexDebt].ToString().Trim();
                    if (s.Length != 0)
                        if (!Decimal.TryParse(s, out dec)) d.Debt = 0;
                        else                               d.Debt = dec;
                    s = row[indexCredit].ToString().Trim();
                    if (s.Length != 0)
                        if (!Decimal.TryParse(s, out dec)) d.Credit = 0;
                        else                               d.Credit = dec;
                    s = row[indexNote].ToString();
                    if (s != "续存" && s!="自定义") d.Note = s;
                    list.Add(d);
                    correct++;
                }
                catch { error++; }
            }
            ShowWarning(list.Count==0);
            dgViewImport.DataSource = list;
            if (list.Count == 0) m_ImportDataList = null;
            else                 m_ImportDataList = list;
            Application.DoEvents();
            MessageBox.Show("共成功 " + correct.ToString() + "筆! 失敗 " + error.ToString() + "筆!");

        }

        private void FormImportBankExcel_Shown(object sender, EventArgs e)
        {
            if (m_CloseForm) Close();
        }

        private void FormImportBankExcel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (excel!=null)
                excel.QuitExcel();
        }

        private void FormImportBankExcel_SizeChanged(object sender, EventArgs e)
        {
            dgViewImport.Height = ClientRectangle.Height - 102;
        }

        private void cbNote_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexNote = cbNote.SelectedIndex;
            ReadTable(m_Table);
        }

        private void cbCredit_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexCredit = cbCredit.SelectedIndex;
            ReadTable(m_Table);
        }

        private void cbDebt_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexDebt = cbDebt.SelectedIndex;
            ReadTable(m_Table);
        }

        private void cbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexDate = cbDate.SelectedIndex;
            ReadTable(m_Table);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (cbBankAccount.SelectedIndex < 1)
            {
                MessageBox.Show("請先選擇轉入的戶頭!");
                return;
            }
            if (m_ImportDataList==null)
            {
                MessageBox.Show("請選擇有資料的xls表!");
                return;
            }
            BankDetailAdapter.Fill(m_DataSet.BankDetail);

            CBankAccountForComboBox acc = new CBankAccountForComboBox();
            
            try
            {
                acc=(CBankAccountForComboBox)cbBankAccount.SelectedItem;
            }
            catch
            {
                MessageBox.Show("銀行帳號資料庫有誤! 無法設定BankID!");
                return;
            }
            int maxId = 1;
            foreach (var r in m_DataSet.BankDetail)
                if (r.ID > maxId) maxId = r.ID;

            int count=0;
            var table = new MyBankDetailTable();

            int maxNoteLen = table.NoteColumn.MaxLength;
          
            foreach (CBankDetail d in m_ImportDataList)
            {
                count++;
                foreach (var r in m_DataSet.BankDetail)
                {
                    if (r.BankID != acc.ID) continue;
                    if (r.Day != d.Date) continue;
                    if (MessageBox.Show("日期" + d.Date.ToShortDateString() + "己有資料! 按OK繼續, 按取消中斷操作",
                                        "<" + count.ToString() + ">  " + r.Day.ToString("MM/dd") + " " + r.Money.ToString(),
                                        MessageBoxButtons.OKCancel) != DialogResult.OK)
                    {
                        MessageBox.Show("所有資料都沒有轉入! ");
                        return;
                    }
                    break;
                }
                
                var row = table.NewBankDetailRow();
                maxId++;
                row.ID = maxId;
                row.BankID = acc.ID;
                row.Day = d.Date;
                if (d.Debt > 0)
                {
                    row.IsCredit = true;    // 定義反了
                    row.Money = d.Debt;
                    
                }
                else
                {
                    row.IsCredit = false;
                    row.Money = d.Credit;
                }
                
                string s = d.Note;
                if (s != null)
                {
                    if (s.Length <= maxNoteLen)
                        row.Note = s;
                    else
                        row.Note = s.Substring(0, maxNoteLen);
                }
                row.TitleCode = "";///
                table.Rows.Add(row);
            }
            if (table == null || table.Count == 0)
            {
                MessageBox.Show("沒有新資料加入,不需要存!");
                return;
            }
            BankDetailAdapter.Update(table);
            btnConvert.Enabled = false;
            MessageBox.Show("成功轉入<"+acc.Name+"> 共"+count.ToString()+"筆資料!");
        }
    }
}
