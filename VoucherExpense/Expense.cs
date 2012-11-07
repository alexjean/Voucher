using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace VoucherExpense
{
  
    public partial class Expense : Form,FormWantDate
    {
        bool checkMode;
        bool 零用金mode;
        public Expense()
        {
            InitializeComponent();
            checkMode = false;
        }

        public Expense(bool isCheckMode,bool only零用金mode)
        {
            InitializeComponent();
            checkMode = isCheckMode;
            零用金mode = only零用金mode;
        }

        class MyDateTimePicker : DateTimePicker
        {
            [Bindable(true)]
            public new DateTime? Value
            {
                get
                {
                    if (Checked) return new Nullable<DateTime>(base.Value);
                    else return new Nullable<DateTime>();
                }
                set
                {
                    if (value.HasValue == true)
                    {
                        Checked = true;
                        base.Value = value.Value;
                    }
                    else
                    {
                        Checked = false;
                    }
                }
            }
        } 

        private void expenseBindingNavigatorSaveItem_Click(object sender, EventArgs e)
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
            this.expenseBindingSource.EndEdit();

            VEDataSet.ExpenseDataTable table = (VEDataSet.ExpenseDataTable)vEDataSet.Expense.GetChanges();
            if (table == null)
            {
                MessageBox.Show("沒有改動任何資料! 不用存");
                return;
            }
            if (checkMode) // 讓Form Expense Reload
            {
                MyFunction.SetGlobalFlag(GlobalFlag.employeeModified);
            }
            else
                foreach (VEDataSet.ExpenseRow r in table)
                {
                    if (r.RowState != DataRowState.Deleted)
                    {
                        r.BeginEdit();
                        r.KeyinID = MyFunction.OperatorID;
                        r.LastUpdated = DateTime.Now;
                        r.EndEdit();
                    }
                }
            vEDataSet.Expense.Merge(table);
            this.expenseTableAdapter.Update(this.vEDataSet.Expense);
            this.vEDataSet.Expense.AcceptChanges();
        }

        private void Expense_Load(object sender, EventArgs e)
        {
            // 將預設的Connection指到我要重定的位置
            bankAccountTableAdapter.Connection  = MapPath.VEConnection;
            operatorTableAdapter.Connection     = MapPath.VEConnection;
            titleTableAdapter.Connection        = MapPath.VEConnection;
            hRTableAdapter.Connection     = MapPath.VEConnection;
            expenseTableAdapter.Connection      = MapPath.VEConnection;
            
            this.bankAccountTableAdapter.Fill(this.vEDataSet.BankAccount);
            this.operatorTableAdapter.Fill(this.vEDataSet.Operator);
            this.titleTableAdapter.Fill(this.vEDataSet.AccountingTitle);
            this.hRTableAdapter.Fill(this.vEDataSet.HR);
            this.expenseTableAdapter.Fill(this.vEDataSet.Expense);
            MyFunction.SetControlLengthFromDB(this, vEDataSet.Expense);
            if (checkMode)
            {
                this.Text = "查核費用";
                blockEdit();
                expenseDataGridView.Columns["columnCheck"].ReadOnly = false;
                ckBoxAllowEdit.Visible = true;
            }
            else
                ckBoxAllowEdit.Visible = false;

            if (!零用金mode)
            {
                bankAccountIDComboBox.Visible = true;
                labelBank.Visible = true;
                cbSelectBank.Enabled = true;
            }

            cbSelectBank.Items.Clear();
            cbSelectBank.Items.Add("全部");
            foreach (VEDataSet.BankAccountRow r in vEDataSet.BankAccount)
                cbSelectBank.Items.Add(r.ShowName);

            if (cbSelectBank.Items.Count > 1)
                cbSelectBank.SelectedIndex = 1;

            comboBoxMonth.SelectedIndex = DateTime.Now.Month;

            if (MyFunction.LockAll)
            {
                blockEdit();
                ckBoxAllowEdit.Visible = false;
            }
//            comboBoxMonth.SelectedIndex = DateTime.Now.Month;
            dateTimePicker1.MaxDate = new DateTime(MyFunction.IntHeaderYear, 12, 31);
            dateTimePicker1.MinDate = new DateTime(MyFunction.IntHeaderYear, 1, 1);

        }

        private void SetBackColor(Color Co)
        {
            this.BackColor = Co;
            this.iDTextBox.BackColor = Co;
            this.lastUpdatedTextBox.BackColor = Co;
        }

        AlphaPanel alphapanel = null;
        private void blockEdit()
        {
            if (alphapanel == null)
            {
                int x = expenseDataGridView.Right;
                int y = idLabel.Bottom;
                int width = this.Right - x;
                int height = this.Bottom - y;
                alphapanel = new AlphaPanel();
                alphapanel.Location = new Point(x, y);
                alphapanel.Size = new Size(width, height);
                this.Controls.Add(alphapanel);
            }
            SetBackColor(Color.Azure);
            alphapanel.BringToFront();
        }

        private void unblockEdit()
        {
            if (alphapanel == null) return;
            SetBackColor(Color.FromArgb(216, 228, 248));
            this.Controls.Remove(alphapanel);
            alphapanel = null;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (MyFunction.LockAll)
            {
                MessageBox.Show("鎖定中,新增無用");
            }
            int m = MyFunction.MaxNoInDB("ID", vEDataSet.Expense);
            MyFunction.SetCellMaxNo("columnID", expenseDataGridView,m);
            int month = comboBoxMonth.SelectedIndex;
            int mon;
            if (month >= 1 && month <= 12) mon = month;
            else                           mon = DateTime.Now.Month;
            DateTime t = new DateTime(DateTime.Now.Year, mon, MyFunction.DayCountOfMonth(mon));
            DataGridViewRow row = expenseDataGridView.CurrentRow;
            // DataGridView和textBox都設定, 以免日期是空白,日期排序,會跑到最前面
            row.Cells["applyTime"].Value = applyTimeTextBox.Text = t.ToShortDateString();

            MessageBox.Show("申請日期己暫時設定, 請設成正確日期!");
            if (this.cbSelectBank.SelectedIndex > 0)
            {
                bankAccountIDComboBox.SelectedValue = cbSelectBank.SelectedIndex;
            }
            lockedCheckBox.Checked = false;
        }

        private void moneyTextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !MyFunction.DecimalValidate(((TextBox)sender).Text);
        }

        private void expenseIDTextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !MyFunction.UintValidate(((TextBox)sender).Text);
        }

        private void expenseDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            if (view.Columns[e.ColumnIndex].Name != "columnApplier")
            {
                MessageBox.Show("第" + row.ToString() + "行,第" + col.ToString() + "欄資料" + e.Exception.Message);
                e.Cancel = true;
            }
            else
            {   // 這個欄位是ApplierID的 comboBox, 如果 在職 被勾掉了就看不到
                DataGridViewCell cell = view.Rows[row].Cells[col];
                int code = 0;
                try
                {
                    code = (int)(cell.Value);
                    cell.ErrorText = "員工號<" + code.ToString() + ">";
                }
                catch
                {
                    cell.ErrorText = "未知錯誤";
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker picker = sender as DateTimePicker;
            applyTimeTextBox.Text = picker.Text;

        }

        private void lockedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MyFunction.LockAll) return;
            if (checkMode)
            {
                if (!ckBoxAllowEdit.Checked)
                    return;
            }                
            CheckBox check = sender as CheckBox;
            if (check.CheckState==CheckState.Checked) blockEdit();
            else unblockEdit();
        }

        string DayFilter = null;
        string BankFilter = null;
        void SetFilter(string day,string bank)
        {
            if (day == null && bank == null)
                expenseBindingSource.Filter = "";
            else if (day == null)
                expenseBindingSource.Filter = bank;
            else if (bank == null)
                expenseBindingSource.Filter = day;
            else
                expenseBindingSource.Filter = day + " And " + bank;

        }


        

        void CalcTotal()
        {
            decimal total = 0;
            foreach (DataRowView rv in expenseBindingSource)
            {
                VEDataSet.ExpenseRow row = (VEDataSet.ExpenseRow)rv.Row;
                if (!row.IsRemovedNull())
                    if (row.Removed) continue;
                if (row.IsMoneyNull()) continue;
                total += row.Money;
            }
            columnMoney.HeaderText = total.ToString("f1");
        }


        private void SetDayFilter(int month,int from, int to)
        {
            string y = "#" + MyFunction.HeaderYear + "/";
            string m1, m2;
            m1 = y + month.ToString("d2")+"/"+from.ToString("d2")+"#";
            m2 = y + month.ToString("d2")+"/"+to.ToString("d2")  +"#";
            DayFilter="(ApplyTime>=" + m1 + ") AND (ApplyTime<=" + m2 + ")";
            SetFilter(DayFilter, BankFilter);
            CalcTotal();
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;

            int month = box.SelectedIndex ;
            if (month == 0)
            {
                DayFilter = null;
                m_DisableIndexChanged = true;
                SetFilter(DayFilter, BankFilter);
                CalcTotal();
                this.expenseDataGridView.Focus();
                return;
            }
            if (month < 1 || month > 12) return;

            int count = MyFunction.DayCountOfMonth(month);
            cbBoxFrom.Items.Clear();
            cbBoxTo.Items.Clear();
            for (int i = 1; i <= count; i++)
            {
                cbBoxFrom.Items.Add(i.ToString() + "日");
                cbBoxTo.Items.Add(i.ToString() + "日");
            }
            m_DisableIndexChanged = true;
            cbBoxFrom.SelectedIndex = 0;
            cbBoxTo.SelectedIndex = count - 1;
            m_DisableIndexChanged = false;
            SetDayFilter(month,1, count);
            SetAccTitleFilter();
            this.expenseDataGridView.Focus();
        }

        #region ====== Print Function ======
        int m_PrintIndex;
        Graphics m_Graphics = null;
        Font m_Font = null;
        Brush m_Brush = null;
        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            m_PrintIndex = 1;
            m_More = -1;
        }

        int printOneMonth(int x, int y, int height, int month, ref int more)
        {
            string str = "      " + MyFunction.HeaderYear + "年 " + month.ToString() + "月           零用金 " ;
            const int CostOffset = 600;
            const int ReasonOffset = 120;
            m_Graphics.DrawString(str, m_Font, m_Brush, x, y);
            y += height;
            str = "編號      日";
            m_Graphics.DrawString(str, m_Font, m_Brush, x, y);
            str = "金額";
            m_Graphics.DrawString(str, m_Font, m_Brush, x + CostOffset, y);
            int count = 0;
            decimal total = 0;
            float w;
            int lineCount = 0;
            int mo = more;
            bool NeedMore = false;
            foreach (VEDataSet.ExpenseRow row in vEDataSet.Expense)
            {
                if (row.IsApplierIDNull()) continue;
                if (row.IsApplyTimeNull()) continue;
                if (row.ApplyTime.Month != month) continue;
//                if (row.IsExpenseIDNull()) continue;
                if (!row.Locked) continue;
                if (!row.IsRemovedNull())
                    if (row.Removed) continue;
                if (row.IsInnerIDNull()) continue;
                if (row.ApplyTime.Day < m_FromDate) continue;
                if (row.ApplyTime.Day > m_ToDate)   continue;
                if (mo > 0)
                {
                    mo--;
                    continue;
                }
                lineCount++;
                if (lineCount > 35)
                {
                    more += lineCount;
                    NeedMore = true;
                    break;
                }
                y += height;
                str = row.InnerID.ToString();
                m_Graphics.DrawString(str, m_Font, m_Brush, x     , y);
                str = row.ApplyTime.Day.ToString("d02");
                m_Graphics.DrawString(str, m_Font, m_Brush, x + 88, y);
                str = row.Note.ToString();
                str=str.Replace("\r\n"," ");
                if (str.Length > 25) str = str.Substring(0, 25);
                m_Graphics.DrawString(str, m_Font, m_Brush, x + ReasonOffset, y);
                decimal money = 0m;
                if (!row.IsMoneyNull())   // 避免IsMoneyNull
                    money = row.Money;
                str = money.ToString("f1");
                w = m_Graphics.MeasureString(str, m_Font).Width;
                m_Graphics.DrawString(str, m_Font, m_Brush, x + CostOffset + 40 - w, y);
                total += money;
                count++;
            }
            y += (int)(1.5 * height);
            str = "共 " + count.ToString() + "張";
            m_Graphics.DrawString(str, m_Font, m_Brush, x, y);
            str = "小計 " + total.ToString("f1");
            w = m_Graphics.MeasureString(str, m_Font).Width;
            m_Graphics.DrawString(str, m_Font, m_Brush, x + CostOffset + 40 - w, y);

            y += height;
            m_Graphics.DrawLine(SystemPens.WindowText, x, y-2, x + CostOffset + 40, y-2);
            str = "以上單據金額 單號 發票除下列外核對無誤,均有主管核可及領款人簽收";
            m_Graphics.DrawString(str, m_Font, m_Brush, x+60 , y);

            if (!NeedMore) more = -1;
            return y + height;
        }

        int m_More = -1;
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            m_Graphics = e.Graphics;
            m_Font = new Font("細明體", 12.0f);
            m_Brush = SystemBrushes.WindowText;

            System.Drawing.Printing.PageSettings settings = e.PageSettings;
            Rectangle inner = e.MarginBounds;
            Rectangle outter = e.PageBounds;

            e.HasMorePages = false;
            int x = inner.Left;
            int y = inner.Top;
            int height = inner.Height / 40;
            int month = comboBoxMonth.SelectedIndex;
      
            int more = m_More;
            y = printOneMonth(x, y, height, month, ref more);
            if (m_PrintIndex == 1 && more == -1) return;     // 只有一頁的不印碼
            m_Graphics.DrawString("                              Page " + m_PrintIndex.ToString(), m_Font, m_Brush, x, inner.Bottom - height);
            if (more != -1)
            {
                e.HasMorePages = true;
                m_More = more;
                m_PrintIndex++;
            }
        }

        int m_FromDate = 0;
        int m_ToDate = 0;
        public void SetDateRange(int from, int to)
        {
            m_FromDate = from;
            m_ToDate = to;
        }
        
        private void 列印PToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("未核可 無申請者 申請日期或內部編號的單子,均不會被列印.繼續嗎?", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            m_FromDate =m_ToDate= 0;
           
            FormDateRange form = new FormDateRange(comboBoxMonth.SelectedIndex,this);
            form.ShowDialog();
            if (m_FromDate != 0 && m_FromDate<=m_ToDate)
            {
                try
                {
                    printDocument.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"列印中產生錯誤");
                }
            }
        }
        #endregion

        bool m_DisableIndexChanged = false;
        private void cbBoxFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_DisableIndexChanged) return;
            ComboBox box = (ComboBox)sender;
            int begin = box.SelectedIndex;
            if (cbBoxTo.SelectedIndex < begin)
                cbBoxTo.SelectedIndex = begin;
            int end = cbBoxTo.SelectedIndex;
            int i = comboBoxMonth.SelectedIndex;
            if (i < 1 || i > 12) return;
            SetDayFilter(i, begin + 1, end + 1);
        }

        private void cbBoxTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_DisableIndexChanged) return;
            ComboBox box = (ComboBox)sender;
            int end = box.SelectedIndex;
            if (cbBoxFrom.SelectedIndex > end)
                cbBoxFrom.SelectedIndex = end;
            int begin = cbBoxFrom.SelectedIndex;
            int i = comboBoxMonth.SelectedIndex;
            if (i < 1 || i > 12) return;
            SetDayFilter(i, begin + 1, end + 1);
        }

        private void expenseDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView view=(DataGridView)sender;
            DataGridViewRow row = view.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells["columnRemoved"];
            if (cell.ValueType != typeof(bool)) return;    // 不應該
            bool removed=false;
            if (cell.Value!= null && cell.Value != DBNull.Value)
                removed=(bool)cell.Value;
            Color color ;
            if (removed)
                color = Color.DarkCyan;
            else if ((e.RowIndex % 2) != 0)
                color = Color.Azure;
            else
                color = Color.White;
            row.DefaultCellStyle.BackColor = color;
            color = Color.Black;
            if (!removed)
            {
                string code="";
                cell = row.Cells["TitleCode"];
                if (cell.ValueType == typeof(string))
                {
                    if (cell.Value != null && cell.Value != DBNull.Value)
                        code = cell.Value as string;
                    if (code.Length >= 1)
                    {
                        if (code[0] == '1')
                            color = Color.Red;
                        else if (code[0] == '2')    // 負債是貸方科目,減少用紫色
                            color = Color.Purple;
                    }
                }
            }
            row.DefaultCellStyle.ForeColor = color;
        }

        // 目前廢掉此功能
        private void cbSelectBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box=(ComboBox)sender;
            int index=box.SelectedIndex;
            bool visible = true;
            if (index == 0)
                BankFilter = null;   // 全部
            else if (index == 1)
            {
                BankFilter = "(BankAccountID=1 Or BankAccountID is Null)";
                visible = false;
            }
            else
                BankFilter = "(BankAccountID=" + index.ToString() + ")";
            labelCredit.Visible = visible;
            comboBoxCredit.Visible = visible;
            checkBoxAllAccTitle.Visible = !visible;
            if (visible)
            {
                if (!checkBoxAllAccTitle.Checked)
                    checkBoxAllAccTitle.Checked = true;
            }
            SetFilter(DayFilter, BankFilter);   // 設完Filter Current會改變
            CalcTotal();
        }


        string m_OldCode=null;
        string m_OldFilter = null;
        void SetAccTitleFilter()
        {
            try                                         // 把資料抓出來, 重設AccTitleFilter
            {                                           // 因為若TitleCodeComboBox.items沒有相對應資料,SelectedValue會是null 
                DataRowView rv = (DataRowView)expenseBindingSource.Current;
                VEDataSet.ExpenseRow row = (VEDataSet.ExpenseRow)rv.Row;
                string code = row.TitleCode;
                if (checkBoxAllAccTitle.Checked)
                    m_OldFilter =m_OldCode = null;
                else
                {
                    if (m_OldFilter == null)
                    {
                        m_OldCode = code;
                        if (code == null || code.Length == 0 || code[0] == '6') m_OldFilter = "TitleCode like '6*'";
                        else m_OldFilter = "TitleCode like '6*' or TitleCode=" + code;
                    }
                    else
                    {
                        if (code == m_OldCode) return;
                        if (code == null || code.Length == 0 || code[0] == '6')
                        {
                            if (m_OldFilter != null) return;
                            m_OldFilter = "TitleCode like '6*'";
                            m_OldCode = code;
                        }
                        else
                        {
                            m_OldFilter = "TitleCode like '6*' or TitleCode=" + code;
                            m_OldCode = code;
                        }
                    }
                }
                titleBindingSource.Filter = m_OldFilter;        // 一設Filter, SelectdValue就改了,SelectedIndex不變
                titleCodeComboBox.SelectedValue = code;   // 因為Filter改了, 要把SelectedValue改回來  
            }
            catch { }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SetAccTitleFilter();      // 等會設Filter會變掉,再設回來
        }

        private void ckBoxAllowEdit_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            if (box.Checked)
                unblockEdit();
            else
                blockEdit();
        }

        private void expenseDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (checkMode)
                ckBoxAllowEdit.Checked = false;
            SetAccTitleFilter();
         }

        private void expenseDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
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
            DataGridView view = expenseDataGridView;
            Microsoft.Office.Interop.Excel.Range range;
            int i = 1;
            // 插入Logo圖片
            range = sheet.Rows[1];
            range.RowHeight = 50;
            Bitmap img = GetThumbnail(global::VoucherExpense.Properties.Resources.LogoVI, 64);
            range = sheet.Cells[1, 1];
            Clipboard.SetDataObject(img, true);
            sheet.Paste(range, "LogoVI");

            //欄位表頭
            i++;
            sheet.Cells[i, 1] = "编号";

            sheet.Cells[i, 2] = "日期";
            range = sheet.Columns[2];
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            range.ColumnWidth = 10;

            sheet.Cells[i, 3] = "摘要";
            range = sheet.Columns[3];
            range.ColumnWidth = 30;

            sheet.Cells[i, 4] = "金额";
            range = sheet.Columns[4];
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

            sheet.Cells[i, 5] = "科目";

            sheet.Cells[i, 6] = "申請人";

            i ++;
            int n=3;
            try
            {
                n = view.Columns["ApplyTime"].Index;
            }
            catch (Exception ex)
            {
                MessageBox.Show("程式被改錯了,DataGridView內找不到ApplyTime! 錯誤:"+ex.Message);
                excel.Quit();
                return;
            }
            foreach(DataGridViewRow vr in view.Rows)
            {
                sheet.Cells[i, 1] = vr.Cells[n + 2].FormattedValue;    // 編号
                sheet.Cells[i, 2] = vr.Cells[n    ].FormattedValue;    // 日期
                sheet.Cells[i, 3] = vr.Cells[n + 3].FormattedValue;
                sheet.Cells[i, 4] = vr.Cells[n + 4].FormattedValue;
                sheet.Cells[i, 5] = vr.Cells[n + 5].FormattedValue;
                sheet.Cells[i, 6] = vr.Cells[n + 1].FormattedValue;   // 申請人

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
            excel.Quit();
        }

        Bitmap GetThumbnail(Bitmap img,int newHeight)
        {
            int x = img.Size.Width;
            int y = img.Size.Height;
            int y1 = newHeight;
            int x1 = x*y1 / y;
            Bitmap newbmp = new Bitmap(x1, y1);
            Graphics g = Graphics.FromImage(newbmp);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.DrawImage(img, new Rectangle(0, 0, x1, y1), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
            g.Dispose();
            return newbmp;

        }
    }
}