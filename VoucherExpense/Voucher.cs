using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Linq;


namespace VoucherExpense
{
    public partial class Voucher : Form
    {
        public Voucher()
        {
            InitializeComponent();
            checkMode = false;
        }

        bool checkMode;
        public Voucher(bool isCheckMode)
        {
            checkMode = isCheckMode;
            InitializeComponent();
            if (checkMode) BackColor = Color.Azure;
        }

        private void voucherBindingNavigatorSaveItem_Click(object sender, EventArgs e)
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
            this.voucherBindingSource.EndEdit();
            this.voucherVoucherDetailBindingSource.EndEdit();

            VEDataSet.VoucherDataTable table = (VEDataSet.VoucherDataTable)vEDataSet.Voucher.GetChanges();
            VEDataSet.VoucherDetailDataTable detail = (VEDataSet.VoucherDetailDataTable)vEDataSet.VoucherDetail.GetChanges();
            if (table == null && detail==null)
            {
                MessageBox.Show("沒有改動任何資料! 不用存");
                return;
            }
            if (table != null)
            {
                foreach (VEDataSet.VoucherRow r in table)
                    if (r.RowState != DataRowState.Deleted)
                    {
                        if (r.IsStockTimeNull())
                        {
                            MessageBox.Show("進貨單<" + r.ID.ToString() + ">沒有日期,不顯示在某單月,只顯示在全年度!");
                        }
                        r.BeginEdit();
                        if (!checkMode)   // checkMode不更新 輸入者
                            r.KeyinID = MyFunction.OperatorID;
                        r.LastUpdated = DateTime.Now;
                        r.EndEdit();
                    }
                try
                {
                    vEDataSet.Voucher.Merge(table);
                    voucherTableAdapter.Update(this.vEDataSet.Voucher);
                    vEDataSet.Voucher.AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("存Voucher時,ex:" + ex.Message);
                }
            }
            if (checkMode)  // 查核模式會更新會計科目
            {
                MyFunction.SetGlobalFlag(GlobalFlag.basicDataModified);
//                return;
            }
            if (detail != null)
            {
                try
                {
                    vEDataSet.VoucherDetail.Merge(detail);
                    voucherDetailTableAdapter.Update(vEDataSet.VoucherDetail);
                    vEDataSet.VoucherDetail.AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("存VoucherDetail時,ex:" + ex.Message);
                }
            }
        }

        private void Voucher_Load(object sender, EventArgs e)
        {
            voucherDetailTableAdapter.Connection    = MapPath.VEConnection;
            operatorTableAdapter.Connection         = MapPath.VEConnection;
            IngredientTableAdapter.Connection       = MapPath.VEConnection;
            accountingTitleTableAdapter.Connection  = MapPath.VEConnection;
            vendorTableAdapter.Connection           = MapPath.VEConnection;
            voucherTableAdapter.Connection          = MapPath.VEConnection;

            this.voucherDetailTableAdapter.Fill(this.vEDataSet.VoucherDetail);
            this.operatorTableAdapter.Fill(this.vEDataSet.Operator);
            this.IngredientTableAdapter.Fill(this.vEDataSet.Ingredient);
            this.accountingTitleTableAdapter.Fill(this.vEDataSet.AccountingTitle);
            this.vendorTableAdapter.Fill(this.vEDataSet.Vendor);
            this.voucherTableAdapter.Fill(this.vEDataSet.Voucher);
            MyFunction.SetControlLengthFromDB(this,vEDataSet.Voucher);

            if (checkMode)
            {
                this.Text = "查核進貨";
                blockEdit();
                voucherDataGridView.Columns["columnCheck"].ReadOnly = false;
                ckBoxAllowEdit.Visible = true;
            }
            if (MyFunction.LockAll)
            {
                blockEdit();
                ckBoxAllowEdit.Visible = false;
            }
            if (MyFunction.IntHeaderYear != DateTime.Now.Year)
                comboBoxMonth.SelectedIndex = comboBoxMonth.Items.Count - 1;
            else
                comboBoxMonth.SelectedIndex = DateTime.Now.Month;
 //           this.btnEditable.BringToFront();
            BuildTitleCodeMenu();
            dateTimePicker1.MaxDate = new DateTime(MyFunction.IntHeaderYear, 12, 31);
            dateTimePicker1.MinDate = new DateTime(MyFunction.IntHeaderYear, 1, 1);
        }

        public class TitleCode
        {
            public int Code { get; set; }
            public string Name { get; set; }
            public TitleCode(int co, string na) { Code = co; Name = na; }
        }

        List<TitleCode> m_TitleList = new List<TitleCode>();
        private void BuildTitleCodeMenu()
        {
            m_TitleList.Add(new TitleCode(0,"全部"));
            foreach (VEDataSet.AccountingTitleRow row in vEDataSet.AccountingTitle)
            {
                string sCode = row.TitleCode;
                if (sCode[0] != '5') continue;
                int code=Convert.ToInt32(sCode);
                m_TitleList.Add(new TitleCode(code, row.Name));
            }
            this.cbBoxIngredientSelector.DataSource = m_TitleList;
        }

        private void SetBackColor(Color Co)
        {
            this.BackColor = Co;
            this.iDTextBox.BackColor = Co;
            this.entryTimeTextBox.BackColor = Co;
            this.lastUpdatedTextBox.BackColor = Co;
        }

        AlphaPanel alphapanel = null;
        private void blockEdit()
        {
            if (alphapanel == null)
            {
                int x=voucherDataGridView.Right;
                int y=voucherBindingNavigator.Bottom;
                int width;
                if (checkMode) width=this.costTextBox.Right-x;     // scroll 和會計科目都可以動
                else           width = voucherDetailDataGridView.Right - x - 20; // scroll用的到
                int height=this.Bottom-y;
                alphapanel = new AlphaPanel();
                alphapanel.Location = new Point(x,y);
                alphapanel.Size=new Size(width,height);
                this.Controls.Add(alphapanel);
            }
            SetBackColor(Color.Azure);
            alphapanel.BringToFront();
        }

        private void unblockEdit()
        {
            if (alphapanel==null) return;
            SetBackColor(Color.FromArgb(216, 228, 248));
            this.Controls.Remove(alphapanel);
            alphapanel = null;
        }

        private void voucherIDTextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox box=(TextBox)sender;
            e.Cancel=!MyFunction.UintValidate(box.Text);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (MyFunction.LockAll)
            {
                MessageBox.Show("鎖定中,新增無用");
            }
            int month = comboBoxMonth.SelectedIndex;
            if (month < 1 || month > 12)
            {
                month = DateTime.Now.Month;
                MessageBox.Show("你未選擇月份, 電腦設定新增為<"+month.ToString()+"月>單子!");
            }
            
//            int count=this.voucherBindingNavigator.PositionItem.
            int ma = MyFunction.MaxNoInDB("ID", vEDataSet.Voucher);
            int i=MyFunction.SetCellMaxNo("columnID", voucherDataGridView,ma);
            if (i > 0)
            {
                this.iDTextBox.Text = i.ToString();
                lockedCheckBox.Checked = false;                           // 只有對DateTime的Binding會受影響, bool不會,所以可以放ResetBindings前  
                this.voucherBindingSource.ResetBindings(false);           // 這行加了會把stockTimeTextBox.Text和entryTimeTextBox.Text給清成空白,所以放前面
                voucherVoucherDetailBindingSource.ResetBindings(false);   // 有id了,可以刷新下面的detail表
                
                // 初始時間, 放在ResetBindings後面
                int year = MyFunction.IntHeaderYear;
                DateTime t = DateTime.Now;
                entryTimeTextBox.Text = t.ToString();
                disableDateTimePicker = true;
                this.dateTimePicker1.Value = new DateTime(year, month, 1);     // 代入的是資料庫的年份,選的月份
                disableDateTimePicker = false;
                // 有選月份時,先強設日期,否則在當月看不到
                DateTime stockTime = new DateTime(year,month,MyFunction.DayCountOfMonth(month));   // 資料月份,設成該月最後一天
                stockTimeTextBox.Text = stockTime.ToShortDateString();
                MessageBox.Show("進貨日期己暫時設定, 請設成正確日期!");   
            }
        }

        private void voucherDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            if (view.Columns[e.ColumnIndex].Name != "columnIngredient")
            {
                MessageBox.Show("第" + row.ToString() + "行,第" + col.ToString() + "欄資料" + e.Exception.Message);
                e.Cancel = true;
            }
            else
            {   // 這個欄位是IngredientID的 comboBox, 如果 CanPurchase被勾掉了就看不到
                DataGridViewCell cell = view.Rows[row].Cells[col];
                int code=0;
                try
                {
                    code =(int)(cell.Value);
                    cell.ErrorText="食材<" + code.ToString() + ">";
                }
                catch
                {
                    cell.ErrorText = "未知錯誤";
                }
            }
        }

        private bool disableDateTimePicker = false;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (disableDateTimePicker) return;
            DateTimePicker picker=sender as DateTimePicker;
            this.stockTimeTextBox.Text = picker.Text;
        }

        private void lockedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MyFunction.LockAll) return;   // 鎖時永遠block
            if (checkMode)
            {
                if (!ckBoxAllowEdit.Checked)
                    return; 
            }
            CheckBox check = sender as CheckBox;
            if (check.CheckState == CheckState.Checked) blockEdit();
            else unblockEdit();
        }

        enum CellStatus { CellNull, ValueNull, Good };

        private decimal ToDecimal(string str)
        {
            try
            {
                return Convert.ToDecimal(str);
            }
            catch
            {
                return 0;
            }
        }

        private decimal CostTotal()
        {
            DataGridView view = this.voucherDetailDataGridView;
            int columnIndex = view.Columns["dgCostColumn"].Index;
            decimal cost = 0;
            foreach (DataGridViewRow row in view.Rows)
                cost += ToDecimal((string)row.Cells[columnIndex].FormattedValue);
            return cost;
        }

        private void costTextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox box = sender as TextBox;
            decimal cost = CostTotal();
            if (cost != ToDecimal(box.Text))
            {
                MessageBox.Show("總計不等於小計之和,將自動計算!");
                box.Text = cost.ToString();
            }
        }

        private void voucherDetailDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            string cellName = view.Columns[e.ColumnIndex].Name;
            if (cellName == "dgCostColumn")
            {
                this.costTextBox.Text=CostTotal().ToString();
            }
            else if (cellName == "dgIngredientIDColumn")
            {
                DataGridViewRow dgRow = view.Rows[e.RowIndex];
                DataGridViewCell cell=dgRow.Cells[e.ColumnIndex];
                if (cell.ValueType!=typeof(int)) return;  // IngridentCode是int
                if (cell.Value==null || cell.Value==DBNull.Value) return;
                int ingredientID=(int)cell.Value;
                try
                {
                    //string str="ID="+code.ToString();
                    //VEDataSet.IngredientRow[] row = (VEDataSet.IngredientRow[])vEDataSet.Ingredient.Select(str);
                    var rows = from row in vEDataSet.Ingredient where (row.IngredientID == ingredientID) select row;
                    if (rows.Count()>0)
                    {
                        VEDataSet.IngredientRow row = rows.First();
                        if (!row.IsTitleCodeNull())
                            dgRow.Cells["columnTitleCode"].Value = row.TitleCode;
                    }
                }
                catch { }
            }
            else if (cellName == "dgVolumeColumn")
            {
                try
                {
                    DataGridViewRow dgRow = view.Rows[e.RowIndex];
                    DataGridViewCell costCell = dgRow.Cells["dgCostColumn"];
                    if (costCell.ValueType != typeof(decimal)) return;  // Cost不是decimal,資料庫定義必然被改過了,程式碼失效
                    if (costCell.Value == null) return;
                    if (costCell.Value != DBNull.Value) return;         // Cost有資料時就不改
                    DataRowView rowView=dgRow.DataBoundItem as DataRowView;
                    VEDataSet.VoucherDetailRow voucherDetailRow=rowView.Row as VEDataSet.VoucherDetailRow;
                    // 查出食材表中相對應記錄
                    var rows = from ro in vEDataSet.Ingredient
                               where (ro.IngredientID == voucherDetailRow.IngredientID) select ro;
                    if (rows.Count()<=0) return;
                    VEDataSet.IngredientRow row = rows.First();
                    if (row.IsPriceNull()) return;
                    if (row.Price<=0)      return;                      // 參考價不合理
                    costCell.Value = voucherDetailRow.Volume * (decimal)row.Price;
                }
                catch{}
            }
        }

        private void voucherDetailDataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.costTextBox.Text = CostTotal().ToString();
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            int i = box.SelectedIndex;
//            if (i == 0) return;
            string y="#"+MyFunction.HeaderYear+"/";
            string m1,m2;
            if (i == 0)
                voucherBindingSource.Filter = "";
            else
            if (i < 12)
            {
                m1 = y + i.ToString("d2") + "/01#";
                m2 = y + (i + 1).ToString("d2") + "/01#";
                voucherBindingSource.Filter = "(StockTime>=" + m1 + ") AND (StockTime<" + m2 + ")";
            }
            else if (i == 12)
            {
                m1 = y + "12/01#";
                m2 = y + "12/31#";
                voucherBindingSource.Filter = "(StockTime>=" + m1 +") AND (StockTime<=" + m2 + ")";
            }
            this.voucherDataGridView.Focus();
        }

        public bool m_PrintSelectedVouchers = false;     // true 表示要列印所選的單子
        public List<CSelectedVoucher> m_SelectedVoucher = null;
        public List<int> m_SelectedVenderID = new List<int>();
        public List<string> m_SelectedVenderName =new List<string>();
        private int CompareVoucherID(CSelectedVoucher v1, CSelectedVoucher v2)
        {
            if (v1 == null)
            {
                if (v2 == null) return 0;
                return -1;
            }
            if (v2 == null) return 1;
            if (v1.ID > v2.ID) return 1;
            if (v1.ID < v2.ID) return -1;
            return 0;
        }
        private void 列印PToolStripButton_Click(object sender, EventArgs e)
        {
            m_SelectedVoucher = new List<CSelectedVoucher>();
            Comparison<CSelectedVoucher> comparer = new Comparison<CSelectedVoucher>(CompareVoucherID);
            foreach(DataGridViewRow row in voucherDataGridView.SelectedRows)
            {
//                CSelectedVoucher select = new CSelectedVoucher();
                try
                {
                    //select.ID   = Convert.ToInt32(row.Cells["columnID"].FormattedValue);
                    //select.Cost = Convert.ToDecimal(row.Cells["columnCost"].FormattedValue);
                    DataRowView rowView = row.DataBoundItem as DataRowView;
                    VEDataSet.VoucherRow dataRow = rowView.Row as VEDataSet.VoucherRow;
                    if (dataRow.IsRemovedNull()) continue;  // 己移除的無法選入 
                    if (dataRow.Removed)        continue;
                    //if (dataRow.IsLockedNull()) continue;   // 未核可的
                    //if (!dataRow.Locked)        continue;
                    decimal cost = dataRow.IsCostNull()? 0m : dataRow.Cost;
                    m_SelectedVoucher.Add(new CSelectedVoucher(dataRow.ID,cost));
                }
                catch(Exception ex)
                {
                    Trace.WriteLine("PrintVoucher:" + ex.Message);
                }
            }
            m_SelectedVoucher.Sort(comparer);
            m_PrintSelectedVouchers = false;
            Form form = new FormPrintSelect(this);
            if (form.ShowDialog() != DialogResult.OK) return;
            if (m_PrintSelectedVouchers)   
            {
                MessageBox.Show("本功能施工中...");
            }
            else if (m_SelectedVenderID.Count> 0)
                  printDocument.Print();
        }

//        int m_PrintIndex ;
        Graphics m_Graphics = null;
        Font m_Font = null;
        Brush m_Brush = null;
        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
//            m_PrintIndex = 1;
            m_More = -1;

        }

        int printOneVender(int x, int y, int height, int month,int venderID,string venderName,ref int more,int lastItemHeight)
        {
            
            string str = "       " + MyFunction.HeaderYear + "年 " + month.ToString() + "月           供應商: " + venderName;
            const int CostOffset = 600;
            const int IngredientOffset = 100;

            m_Graphics.DrawString(str, m_Font, m_Brush, x, y);
            y += height;
            str = "憑証號    日";
            m_Graphics.DrawString(str, m_Font, m_Brush, x, y);
            str = "金額";
            m_Graphics.DrawString(str, m_Font, m_Brush, x + CostOffset, y);
            int count = 0;
            decimal total = 0;
            float w;
            int lineCount = 0;
            int mo=more;
            bool NeedMore = false;
            foreach (VEDataSet.VoucherRow row in vEDataSet.Voucher)
            {
                if (row.IsVendorIDNull()) continue;
                if (row.VendorID != venderID) continue;
                if (row.IsStockTimeNull()) continue;
                if (row.StockTime.Month != month) continue;
                if (row.StockTime.Year != MyFunction.IntHeaderYear) continue;
                if (row.IsVoucherIDNull()) continue;
                if (row.IsCostNull()) continue;
                if (mo> 0)
                {
                    mo--;
                    continue;
                }
                lineCount++;
                if (y > lastItemHeight || lineCount > 35)
                {
                    more += lineCount;
                    NeedMore = true;
                    break;
                }
                y += height;
                str = row.VoucherID.ToString();
                m_Graphics.DrawString(str, m_Font, m_Brush, x, y);
                str = row.StockTime.Day.ToString("d02");
                m_Graphics.DrawString(str, m_Font, m_Brush, x + 88, y);
                str = row.Cost.ToString("f1");
                w = m_Graphics.MeasureString(str, m_Font).Width;
                m_Graphics.DrawString(str, m_Font, m_Brush, x + CostOffset + 40 - w, y);
                try
                {
                    VEDataSet.VoucherDetailRow[] dRows = row.GetVoucherDetailRows();
                    str = "";
                    count++;
                    total += row.Cost;

                    foreach (VEDataSet.VoucherDetailRow r in dRows)
                    {

                        if (r.IsVolumeNull()) continue;
                        if (str.Length > 20)
                        {
                            str += "...";
                            break;
                        }
                        string name = r.IngredientRow.Name.ToString();
                        string vol = r.Volume.ToString();
                        string cost = r.Cost.ToString("f1");
                        if (name.Length > 8) name = name.Substring(8);
                        str += ("  " + name + " " + vol + " (" + cost + ")");
                        if (str.Length < 20)
                            for (int k = str.Length; k < 20; k++)
                                str += " ";
                    }
                }
                catch { }
                m_Graphics.DrawString(str, m_Font, m_Brush, x + IngredientOffset, y);

            }
            y += 2 * height;
            str = "   共 " + count.ToString() + "張";
            m_Graphics.DrawString(str, m_Font, m_Brush, x, y);
            str = "小計 " + total.ToString("f1");
            w = m_Graphics.MeasureString(str, m_Font).Width;
            m_Graphics.DrawString(str, m_Font, m_Brush, x + CostOffset + 40 - w, y);
            y += height;
            m_Graphics.DrawLine(SystemPens.WindowText, x, y, x + CostOffset + 40, y);
            if (!NeedMore) more = -1;
            return y+height;
        }

        int m_More = -1;
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            m_Graphics = e.Graphics;
            m_Font = new Font("細明體", 12.0f);
            m_Brush = SystemBrushes.WindowText; 
            
            PageSettings settings = e.PageSettings;
            Rectangle inner = e.MarginBounds;
            Rectangle outter = e.PageBounds;

            e.HasMorePages = false;
            int x = inner.Left;
            int y = inner.Top;
            int height = inner.Height / 40;
            int month=comboBoxMonth.SelectedIndex;
            if (m_SelectedVenderID.Count > 0)
                while(m_SelectedVenderID.Count>0)
                {
                    int venderID = m_SelectedVenderID[0];
                    int more=m_More;
                    y=printOneVender(x, y, height, month, venderID, m_SelectedVenderName[0],ref more,inner.Bottom-5*height);
                    if (more != -1)
                    {
                        e.HasMorePages = true;
                        m_More = more;
                        break;
                    }
                    m_SelectedVenderName.RemoveAt(0);
                    m_SelectedVenderID.RemoveAt(0);
                }
            m_Graphics.DrawString("收到以上單據無誤    接收人:", m_Font, m_Brush, x, inner.Bottom - height);
        }

        private void voucherDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            DataGridViewRow row = view.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells["columnRemoved"];
            if (cell.ValueType != typeof(bool)) return;    // 不應該
            bool removed = false;
            if (cell.Value != null && cell.Value != DBNull.Value)
                removed = (bool)cell.Value;
            Color color;
            if (removed)
                color = Color.DarkCyan;
            else if ((e.RowIndex % 2) != 0)
                color = Color.Azure;
            else
                color = Color.White;
            row.DefaultCellStyle.BackColor = color;
        }

        private void ckBoxAllowEdit_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            if (box.Checked)
                unblockEdit();
            else
                blockEdit();
        }

        private void ModifyIngredientFilterForSafe(string Select)
        {   // 避免出現ComboBox沒有的
            foreach (DataGridViewRow row in voucherDetailDataGridView.Rows)
            {
                DataGridViewCell cell = row.Cells["dgIngredientIDColumn"];
                if (cell == null) continue;
                if (cell.Value == null) continue;
                if (cell.Value == DBNull.Value) continue;
                Select += " OR IngredientID=" + cell.Value.ToString();
            }
            IngredientBindingSource.Filter = Select;
        }

        private void voucherDataGridView_SelectionChanged(object sender, EventArgs e)
        {   // 編修模式,ckBoxAllowEdit不顥示
            ModifyIngredientFilterForSafe("CanPurchase=true");
            if (cbBoxIngredientSelector.Items.Count>0)
                cbBoxIngredientSelector.SelectedIndex = 0;
            if (checkMode)
                ckBoxAllowEdit.Checked = false;
        }

        int m_UserSelectedTitleCode = 0;
        private void cbBoxIngredientSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            TitleCode title = (TitleCode)box.SelectedItem;
            if (title == null) return;
            m_UserSelectedTitleCode = title.Code;
            SetIngredientFilter(m_UserSelectedTitleCode, m_UserSelectedVendorID);
        }

        void SetIngredientFilter(int titleCode, int vendorID)
        {
            string Select = "CanPurchase=true";
            if (titleCode != 0)
                Select += " And TitleCode=" + titleCode.ToString();
            if (m_UserSelectedVendorID > 0)
                Select += " And VendorID=" + vendorID.ToString();
            ModifyIngredientFilterForSafe(Select);      
        }

        int m_UserSelectedVendorID = -1;
        private void vendorIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView rowView = (DataRowView)vendorIDComboBox.SelectedItem;
            if (rowView == null)  // 沒有選,空白時也是rowView為null
            {
                m_UserSelectedVendorID = -1;
                goto ret;
            }
            if (rowView.Row == null)
            {
                m_UserSelectedVendorID = -1;
                goto ret;
            }
            VEDataSet.VendorRow vendor = (VEDataSet.VendorRow)(rowView.Row);
            m_UserSelectedVendorID = vendor.VendorID;
        ret:
            SetIngredientFilter(m_UserSelectedTitleCode, m_UserSelectedVendorID);
        }


        private CellStatus IsCellNull(DataGridViewRow row, string name, out object obj)
        {
            obj = null;
            DataGridViewCell cell = row.Cells[name];
            if (cell == null) return CellStatus.CellNull;
            obj = cell.Value;
            if (obj == null || obj == DBNull.Value) return CellStatus.ValueNull;
            return CellStatus.Good;
        }

        private bool CostColorChanged(DataGridViewRow row,out DataGridViewCell costCell)
        {
            object obj;
            costCell = null;
            if (IsCellNull(row, "dgCostColumn", out obj)!=CellStatus.Good) return false;
            if (obj.GetType() != typeof(decimal)) return false; // 應該不可能
            decimal cost = (decimal)obj;
            if (IsCellNull(row, "dgVolumeColumn", out obj) != CellStatus.Good) return false;
            if (obj.GetType() != typeof(decimal)) return false;
            decimal volume = (decimal)obj;
            if (IsCellNull(row, "dgIngredientIDColumn", out obj) != CellStatus.Good) return false;
            int ingredientID = (int)obj;
            // Code 己經被改成IngredientID
            //VEDataSet.IngredientRow[] Rows = (VEDataSet.IngredientRow[])vEDataSet.Ingredient.Select("Code =" + code.ToString());  
            //if (Rows == null || Rows.Length == 0) return false;
            var rows = from ro in vEDataSet.Ingredient where (ro.IngredientID == ingredientID) select ro;
            if (rows.Count() <= 0) return false;
            VEDataSet.IngredientRow ingredient=rows.First();
            double price=0;
            if (!ingredient.IsPriceNull()) price=ingredient.Price;
            costCell = row.Cells["dgCostColumn"];
            double diff = (double)cost - price * (double)volume;
            if (volume != 0) costCell.ToolTipText = (cost / volume).ToString("f2");
            Color change;
            if (diff > 0.04) change = Color.Red;
            else if (diff < -0.04) change = Color.Green;
            else change = Color.Black;
            if (change == costCell.Style.ForeColor) return false;
            costCell.Style.ForeColor = change;         // 要在Cell_Formating event之後才設的進去,要不然 e.CellStyle會蓋掉
            return true;
        }

        private void voucherDetailDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            string cellName = view.Columns[e.ColumnIndex].Name;
            if (cellName == "dgCostColumn" || cellName == "dgVolumeColumn")
            {
                if (!MyFunction.DecimalValidate((string)e.FormattedValue))
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void voucherDetailDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            string cellName = view.Columns[e.ColumnIndex].Name;
            if (cellName == "dgVolumeColumn" || cellName == "dgIngredientIDColumn" || cellName == "dgCostColumn")
            {
                DataGridViewCell costCell;
                if (CostColorChanged(view.Rows[e.RowIndex],out costCell))
                    view.InvalidateCell(costCell);
            }
        }

        private void voucherDetailDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            DataGridViewCell cell=view.Rows[e.RowIndex].Cells[e.ColumnIndex];
//           MessageBox.Show(string.Format("Detail on Row{0} Col[{1}]:{2}", e.RowIndex, view.Columns[e.ColumnIndex].Name,e.Exception.Message));
        }

        private void voucherDetailDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            foreach (DataGridViewRow row in view.Rows)
            {
                DataGridViewCell costCell;
                if (CostColorChanged(row, out costCell))
                    view.InvalidateCell(costCell);
            }
        }

        void ModifyReferenceCost(int code,decimal price)
        {
            VEDataSet.IngredientRow[] rows=(VEDataSet.IngredientRow[])vEDataSet.Ingredient.Select(
                                                                            "Code=" + code.ToString());
            if (rows.Length <= 0) return;
            rows[0].Price = (double)price;
            IngredientTableAdapter.Update(rows[0]);
        }

        bool IsDataWrong(Type type, object val)
        {
            if (val == null) return true;
            if (Convert.IsDBNull(val)) return true;
            if (val.GetType() != type) return true;
            return false;
        }

        string PriceForHuman(double price)
        {
            double p = Math.Round(price, 2);
            double diff = price - p;
            if (diff > 0.001) return p.ToString() + "+";
            if (diff < -0.001) return p.ToString() + "-";
            return p.ToString();
        }

        // User 要核可這張單子了, 先檢查和參考價是否相同
        private void voucherDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!checkMode) return;    // 查核模式才能核可
            DataGridView view = (DataGridView)sender;
            if (view.Columns[e.ColumnIndex].Name != "columnCheck") return;
            DataGridViewRow  row  = view.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells[e.ColumnIndex];
            if (cell.FormattedValueType != typeof(bool)) return;
            if ((bool)cell.FormattedValue != true) return;
            foreach (DataGridViewRow r in voucherDetailDataGridView.Rows)
            {
                DataGridViewCell costCell = r.Cells["dgCostColumn"];
                if (IsDataWrong(typeof(decimal),costCell.Value))
                {
                    if (r.IsNewRow) continue;  // 無資料的最後一列
                    MessageBox.Show("小計資料有誤!");
                    goto Error;
                }
                DataGridViewCell ingredientIDCell = r.Cells["dgIngredientIDColumn"];
                if (IsDataWrong( typeof(int),ingredientIDCell.Value))
                {
                    MessageBox.Show("有食材沒有輸入!");
                    goto Error;
                }
                object volume = r.Cells["dgVolumeColumn"].Value;
                if (IsDataWrong(typeof(decimal),volume) || (decimal)volume == 0m)
                {
                    MessageBox.Show(ingredientIDCell.FormattedValue + " 量有問題,請重新輸入!", "", MessageBoxButtons.OK);
                    goto Error;
                }
                Color color=costCell.Style.ForeColor;
                decimal price = (decimal)costCell.Value / (decimal)volume;
                if (color == Color.Green || color==Color.Red)
                {
                    int id;
                    if (int.TryParse(ingredientIDCell.Value.ToString(), out id))
                    {
                        //                    VEDataSet.IngredientRow[] rows = (VEDataSet.IngredientRow[])vEDataSet.Ingredient.Select("Code=" + codeCell.Value.ToString());
                        var rows = from ro in vEDataSet.Ingredient where (ro.IngredientID == id) select ro;
                        if (rows.Count() == 0)
                        {
                            MessageBox.Show("查不到<" + ingredientIDCell.FormattedValue + ">,無法比對價格!");
                            return;
                        }
                        VEDataSet.IngredientRow r0 = rows.First();
                        double price0 = 0;
                        if (!r0.IsPriceNull()) price0 = r0.Price;
                        DialogResult result = MessageBox.Show(ingredientIDCell.FormattedValue + "價格<" + PriceForHuman((double)price)
                            + ">和參考價<" + PriceForHuman(price0) + ">不同,是否改變參考價?", "", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.No) continue;
                        if (result == DialogResult.Cancel) goto Error;
                        if (result == DialogResult.Yes)
                        {
                            r0.Price = (double)price;
                            IngredientTableAdapter.Update(r0);
                        }
                    }
                }
            }
            return;
        Error:
            cell.Value = false;
            row.Selected = true;
          
        }

        private void voucherDetailDataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridViewRow row = e.Row;
            DataGridViewCell cellID = row.Cells["detailColumnID"];
            cellID.Value = Guid.NewGuid();
        }

  
  
    }
}