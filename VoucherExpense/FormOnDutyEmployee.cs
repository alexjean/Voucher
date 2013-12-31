using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
#if UseSQLServer
using MyDataSet=VoucherExpense.DamaiDataSet;
using MyHRRow = VoucherExpense.DamaiDataSet.HRRow;
using MyOnDutyDataAdapter = VoucherExpense.DamaiDataSetTableAdapters.OnDutyDataTableAdapter;
#else
using MyDataSet=VoucherExpense.VEDataSet;
using MyHRRow = VoucherExpense.VEDataSet.HRRow;
using MyOnDutyDataAdapter = VoucherExpense.VEDataSetTableAdapters.OnDutyDataTableAdapter;
#endif

namespace VoucherExpense
{
    public partial class FormOnDutyEmployee : Form
    {
        public FormOnDutyEmployee()
        {
            InitializeComponent();
        }

        MyDataSet m_DataSet = new MyDataSet();
        MyOnDutyDataAdapter OnDutyDataAdapter = new MyOnDutyDataAdapter();
        private void FormOnDutyEmployee_Load(object sender, EventArgs e)
        {
            SetupBindingSource();
#if UseSQLServer
            var apartmentAdapter    = new VoucherExpense.DamaiDataSetTableAdapters.ApartmentTableAdapter();
            var HRAdapter           = new VoucherExpense.DamaiDataSetTableAdapters.HRTableAdapter();
#else
            var apartmentAdapter    = new VoucherExpense.VEDataSetTableAdapters.ApartmentTableAdapter();
            var HRAdapter           = new VoucherExpense.VEDataSetTableAdapters.HRTableAdapter();
            apartmentAdapter.Connection   = MapPath.VEConnection;
            HRAdapter.Connection          = MapPath.VEConnection;
            OnDutyDataAdapter.Connection  = MapPath.VEConnection;
#endif
            try
            {
                apartmentAdapter.Fill   (m_DataSet.Apartment);
                HRAdapter.Fill          (m_DataSet.HR);
                OnDutyDataAdapter.Fill  (m_DataSet.OnDutyData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ex:" + ex.Message);
            }
            int index=DateTime.Now.Month - 2;
            if (index<0) index=0;
            this.comboBoxMonth.SelectedIndex = index;
            ckBoxShowAll_CheckedChanged(null,null);
            //comboBoxApartment.DataSource = GetApartmentList();
        }

        void SetupBindingSource()
        {
            hRBindingSource.DataSource = m_DataSet;
            apartmentBindingSource.DataSource = m_DataSet;
        }

        //List<CNameIDForComboBox> GetApartmentList()
        //{
        //    List<CNameIDForComboBox> list = new List<CNameIDForComboBox>();
        //    if (m_DataSet.Apartment.Rows.Count > 1)               // 多於一個才有全部這個選項
        //    {
        //        list.Add(new CNameIDForComboBox(0, " "));
        //        comboBoxApartment.Enabled = true;
        //    }
        //    else
        //        comboBoxApartment.Enabled = false;
        //    foreach (var row in m_DataSet.Apartment)
        //    {
        //        if (row.IsApartmentNameNull()) continue;
        //        list.Add(new CNameIDForComboBox(row.ApartmentID, row.ApartmentName));
        //    }
        //    return list;
        //}

        private void dgvOnDutyEmployee_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView view=sender as DataGridView;
            MyHRRow hRRow;
            try
            {
                DataRowView rv=view.CurrentRow.DataBoundItem as DataRowView;
                hRRow = rv.Row as MyHRRow;
            }
            catch
            {
                return;
            }
            if (hRRow == null) return;
            if (hRRow.IsFingerPintNoNull()) return;
            if (hRRow.IsEmployeeNameNull()) return;
            if (hRRow.IsFingerprintmachineNull()) return;
      
            labelName.Text = hRRow.EmployeeName;
            int dutyCode = hRRow.FingerPintNo;
            int month = comboBoxMonth.SelectedIndex + 1;
            int count = MyFunction.DayCountOfMonth(month);
            string[] str = new string[count];
            for (int i = 0; i < count; i++) str[i] = (i+1).ToString("d2")+"日";

            int d, h;
           // VEDataSet.OnDutyDataRow[] rows=hRRow.GetOnDutyDataRows();
            //VEDataSet.OnDutyDataRow[] rows = (VEDataSet.OnDutyDataRow[])vEDataSet.OnDutyData.Select("Fingerprintmachine=" + hRRow.Fingerprintmachine + "and " + "OnDutyCode=" + hRRow.FingerPintNo);
            var rows = from r in m_DataSet.OnDutyData 
                       where (r.Fingerprintmachine == hRRow.Fingerprintmachine) && (r.OnDutyCode == hRRow.FingerPintNo)
                       select r;
            foreach (var row in rows)
            {
                try
                {
                    DateTime t=row.TimeMark;
                    if (t.Month == month)
                    {
                        d = t.Day - 1;
                        h = t.Hour;
                        if (h < 4) d--;
                        if (d < 0) continue;
                    }
                    else if (t.Month == (month + 1))    // 下個月4點前的算到上個月去
                    {
                        d = t.Day - 1;
                        if (d != 0) continue;
                        h = t.Hour;
                        if (h < 4) continue;
                        d = count - 1;
                    }
                    else continue;
                    str[d] += " " + h.ToString("d2")+":"+t.Minute.ToString("d2")+" ";
                }
                catch { }
            }
            checkedListBox1.Items.Clear();
            foreach (string s in str)
                checkedListBox1.Items.Add(s);
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvOnDutyEmployee_SelectionChanged(dgvOnDutyEmployee, null);
        }

        private void ckBoxShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBoxShowAll.Checked)
                hRBindingSource.Filter = "";
            else
                hRBindingSource.Filter = "InPosition=true";
//            onDutyEmployeeBindingSource.ResetBindings(false);
        }

        string m_FileName = null;
        private void btnImport_Click(object sender, EventArgs e)
        {
            DialogResult result=openFileDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            m_FileName = openFileDialog1.FileName;
            string[] data = System.IO.File.ReadAllLines(m_FileName);
            char[] sept= new char[1] {','};
            checkedListBox1.Items.Clear();
            string[] l;
            foreach (string s in data)
            {
                l=s.Split(sept);
                if (l.Length<1) continue;
                if (l.Length < 2)
                    checkedListBox1.Items.Add(l[0]);
                else
                {
                    checkedListBox1.Items.Add(l[0] + "," + l[1]);
                }
            }
            labelName.Text = "若下方資料無誤,請按 ==>";
            btnConfirmTrans.Visible = true;
        }

        private void btnConfirmTrans_Click(object sender, EventArgs e)
        {
            string[] data = System.IO.File.ReadAllLines(m_FileName);
            char[] sept= new char[3] {',',' ','\t'};
            string[] l;
            int code;
            int machineno;
            DateTime dt;
            int max=0,success=0,error=0,repeat=0;
            progressBar1.Maximum = 0;
            progressBar1.Maximum = data.Length+1;       // +1 nothing buf for safe
            progressBar1.Step = 1;
            progressBar1.Visible = true;
            foreach (var r in m_DataSet.OnDutyData)
                if (r.ID > max) max = r.ID;
            foreach (string s in data)
            {
                l = s.Split(sept,StringSplitOptions.RemoveEmptyEntries);
                if (l.Length < 7) continue;
                try
                {
                    //if (!int.TryParse(l[0]         , out code   )) continue;
                    //if (!DateTime.TryParse(l[1], out dt      )) continue;
                    if (!int.TryParse(l[1], out machineno)) continue;
                    if (!int.TryParse(l[2], out code)) continue;
                    if (!DateTime.TryParse(l[5]+" "+l[6],out dt)) continue;
                    if (dt.Year != MyFunction.IntHeaderYear) continue;       // 不是今年的資料,不收錄
                    var linqRow = from lr in m_DataSet.OnDutyData
                                  where (lr.TimeMark.Date == dt.Date && lr.TimeMark.Hour == dt.Hour && lr.TimeMark.Minute == dt.Minute && lr.OnDutyCode == code && lr.Fingerprintmachine == machineno)
                                  select lr.RowState;
                    if (linqRow.Count() > 0)
                    {
                        bool allDeleted = true;
                        foreach (DataRowState state in linqRow)
                            if (state != DataRowState.Deleted)
                            {
                                allDeleted = false;
                                break;
                            }
                        if (!allDeleted)
                        {
                            repeat++;
                            progressBar1.PerformStep();
                            Application.DoEvents();
                            continue;
                        }
                    }
                    var row = m_DataSet.OnDutyData.NewOnDutyDataRow();
                    row.ID = (++max);
                    row.OnDutyCode = code;
                    row.TimeMark = dt;
                    row.Fingerprintmachine = Convert.ToInt16(machineno);
                    m_DataSet.OnDutyData.AddOnDutyDataRow(row);
                    success++;
                }
                catch { error++; }
                progressBar1.PerformStep();
                Application.DoEvents();
            }
            // Adapter.Update
            OnDutyDataAdapter.Update(m_DataSet.OnDutyData);
            m_DataSet.OnDutyData.AcceptChanges();
            btnConfirmTrans.Visible=false;
            progressBar1.Visible = false;
            labelName.Text="轉檔完成" ;
            MessageBox.Show("轉檔完成! 共成功轉入" + success.ToString() + "筆! 失敗" + error.ToString() + "筆! 重複"+repeat.ToString()+"筆!");
            checkedListBox1.Items.Clear();
        }

//        string ColApartment = "ColumnApartmentID";
//        int iColApartment = -1;
        private void dgvOnDutyEmployee_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //if (iColApartment < 0)
            //{
            //    try { iColApartment = dgvOnDutyEmployee.Columns[ColApartment].Index; }
            //    catch { }
            //}
            //if (iColApartment != e.ColumnIndex) return;
            //DataGridViewRow row = dgvOnDutyEmployee.Rows[e.RowIndex];
            //row.Cells[iColApartment].FormattedValue = "******";
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            int month = comboBoxMonth.SelectedIndex + 1;
            if (month < 1 || month >12)
            {
                MessageBox.Show("請先選擇月份!!");
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
                sheet.Name = comboBoxMonth.SelectedItem.ToString()+"打卡明細";
            }
            catch (Exception ex)
            {
                MessageBox.Show("開啟Excel出錯,原因:" + ex.Message);
                return;
            }
            excel.Visible = true;
//            DataGridView view = cLedgerTableDataGridView;
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
            sheet.Cells[1, 3] = sheet.Name;
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
/*
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
 */
            sheet.Cells[i++, 2] = "'================================================";
            excel.Quit();
        }
    }
}
