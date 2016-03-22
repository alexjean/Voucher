using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using MyDataSet      = VoucherExpense.DamaiDataSet;
using MyVoucherTable = VoucherExpense.DamaiDataSet.VoucherDataTable;
using MyVoucherRow   = VoucherExpense.DamaiDataSet.VoucherRow;

namespace VoucherExpense
{
    public partial class ReportByVender : Form
    {
        public ReportByVender()
        {
            InitializeComponent();
        }

        List<CNameIDForComboBox> vendors = new List<CNameIDForComboBox>();

        MyDataSet m_DataSet = new MyDataSet();
        private void ReportByVender_Load(object sender, EventArgs e)
        {
            SetupBindingSource();
            var vendorAdapter       = new VoucherExpense.DamaiDataSetTableAdapters.VendorTableAdapter();
            var voucherAdapter      = new VoucherExpense.DamaiDataSetTableAdapters.VoucherTableAdapter();
            var voucherDetailAdapter= new VoucherExpense.DamaiDataSetTableAdapters.VoucherDetailTableAdapter();
            var IngredientAdapter   = new VoucherExpense.DamaiDataSetTableAdapters.IngredientTableAdapter();

            vendorAdapter.Connection.ConnectionString     = DB.SqlConnectString(MyFunction.HardwareCfg);
            IngredientAdapter.Connection.ConnectionString = DB.SqlConnectString(MyFunction.HardwareCfg);

            try
            {
                vendorAdapter.Fill       (m_DataSet.Vendor);
                voucherAdapter.Fill      (m_DataSet.Voucher);
                voucherDetailAdapter.Fill(m_DataSet.VoucherDetail);
                IngredientAdapter.Fill   (m_DataSet.Ingredient);
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入資料庫發生錯誤! 原因:" + ex.Message);
            }
            vendors.Add(new CNameIDForComboBox(0, " "));
            foreach (var v in m_DataSet.Vendor)
                vendors.Add(new CNameIDForComboBox(v.VendorID, v.Name));
            vendors.Add(new CNameIDForComboBox(int.MaxValue, "全部"));
            vendorIDComboBox.DataSource = vendors;
            cbBoxMonth.SelectedIndex=DateTime.Now.Month;
            this.voucherDGView.DataSource = null;  // 原本先用了 vEDataSet.Voucher做格式
        }

        void SetupBindingSource()
        {
            voucherBindingSource.DataSource = m_DataSet;
            voucherDetailBindingSource.DataSource = m_DataSet;
            IngredientBindingSource.DataSource = m_DataSet;
        }

        private void Add2List(SortableBindingList<CIngredient> list,int id, decimal cost, decimal volume)
        {
            foreach (CIngredient p in list)
            {
                if (p.ID == id)
                {
                    p.TotalCost += cost;
                    p.OrderCount++;
                    p.Volume += volume;
                    if (p.Volume != 0)
                        p.UnitCost = p.TotalCost / p.Volume;
                    return;
                }
            }
            CIngredient p1=new CIngredient(id);
            p1.TotalCost += cost;
            p1.OrderCount++;
            p1.Volume += volume;
            if (p1.Volume != 0)
                p1.UnitCost = p1.TotalCost / p1.Volume;
            list.Add(p1);
        }

        // id= int.MaxValue 統計全部供貨商
        void Calculate(int monthFrom,int dayFrom,int monthTo,int dayTo,int id,string name)
        {
            if (id <= 0) return;  // 沒有選擇供貨商
            SortableBindingList<CIngredient> list = new SortableBindingList<CIngredient>();
            var voucher = new MyVoucherTable();
            int count = 0,checkedCount=0;
            foreach (var vr in m_DataSet.Voucher)
            {
                if (vr.IsStockTimeNull()) continue;
                if (vr.StockTime.Year != MyFunction.IntHeaderYear) continue;
                if (id != int.MaxValue)
                {
                    if (vr.IsVendorIDNull()) continue;
                    if (vr.VendorID != id) continue;
                }
                int month=vr.StockTime.Month;
                if (month < monthFrom) continue;
                else if (month == monthFrom)
                {
                    if (vr.StockTime.Day<dayFrom) continue;
                }
                if (month > monthTo)   continue;
                else if (month == monthTo)
                {
                    if (vr.StockTime.Day>dayTo) continue;
                }
                if (!vr.IsRemovedNull())
                    if (vr.Removed) continue;
                var row = voucher.NewVoucherRow();
                row.ItemArray = vr.ItemArray;
                voucher.AddVoucherRow(row);
                count++;
                if (vr.Locked) checkedCount++;
                decimal checkSum = 0;
                foreach (var dr in vr.GetVoucherDetailRows())
                {
                    if (dr.IsIngredientIDNull()) continue;
                    decimal co=0,vo=0;
                    if (!dr.IsCostNull())   co = dr.Cost;
                    if (!dr.IsVolumeNull()) vo = dr.Volume;
                    checkSum += co;
                    Add2List(list,dr.IngredientID, co, vo);
                }
                decimal vrCost=0;
                if (!vr.IsCostNull()) vrCost = vr.Cost;
                if (checkSum != vrCost)
                    MessageBox.Show("警告!<序号" + vr.ID.ToString() +
                        ">號細項和"+checkSum.ToString("f1")+
                        "和總和"   +vrCost.ToString("f1")+"不符!");
            }
            decimal sum=0;
            foreach (CIngredient p in list)
                sum+=p.TotalCost;
            textBox1.Text = sum.ToString("N1");
            labelCount.Text = "己核可 " + checkedCount.ToString() + "單(共"+count.ToString()+"單)";
            this.dataGridView1.DataSource = list;
            this.voucherDGView.DataSource = voucher;
            if (list.Count == 0)
            {
                MessageBox.Show(monthFrom.ToString() + "至"+monthTo.ToString()+"月份 供貨商<" + name + ">無進貨!");
            }
        }


        private void ReportByVender_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataGridView1.DataSource = null;  // 先設成null,避免表中的DataGridView 因某些table己經沒了而出錯
        }

        int PageIndex = -1;
        decimal m_TotalMoney = 0;
        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            PageIndex = 1;
        }

        Graphics m_Graphics=null;
        Font m_Font=null;
        Brush m_Brush=null;
        void PrintColumn(string str, int x, int y, DataGridViewColumn col)
        {
            DataGridViewContentAlignment alignment = col.DefaultCellStyle.Alignment;

            int width = col.Width;
            if (alignment == DataGridViewContentAlignment.BottomRight ||
                alignment == DataGridViewContentAlignment.MiddleRight ||
                alignment == DataGridViewContentAlignment.TopRight)
            {
                SizeF size = m_Graphics.MeasureString(str, m_Font);
                x += (int)(col.Width - size.Width);
                
            }
            m_Graphics.DrawString(str, m_Font, m_Brush, new PointF(x, y));
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            const int LinePerPage = 38;
            m_Graphics = e.Graphics;
            PageSettings settings   = e.PageSettings;
            Rectangle    inner      = e.MarginBounds;
            Rectangle    outter     = e.PageBounds;
            BindingList<CIngredient> list = dataGridView1.DataSource as BindingList<CIngredient>;
            if (list == null || PageIndex<=0)
            {
                e.HasMorePages = false;
                return;
            }
            int start = (PageIndex - 1) * LinePerPage;
            int end = start + LinePerPage;
            DataGridView view=this.dataGridView1;
            if (end > view.Rows.Count)
            {
                end = view.Rows.Count;
                e.HasMorePages = false;
            }
            else
            {
                e.HasMorePages = true;
                PageIndex++;
            }
            m_Font = new Font("細明體", 12.0f);
            m_Brush= SystemBrushes.WindowText;
            int x = inner.Left;
            int y = inner.Top ;
            string str="       "+cbBoxMonth.Text+cbBoxFrom.Text+"-"+cbBoxMonthTo.Text+cbBoxTo.Text+"        供應商:"+vendorIDComboBox.Text;
            DataGridViewColumnCollection columns = view.Columns;
            m_Graphics.DrawString(str, m_Font, m_Brush, new PointF(x, y));
            int height = inner.Height / (LinePerPage+2);      // 保留二行做頁底
            y += 2*height;
            for (int j = 0; j < columns.Count; j++)
            {
                DataGridViewColumn col = columns[j];
                str = col.HeaderText;
                PrintColumn(str,x,y,col);
                x += view.Columns[j].Width;
            }
            for (int i = start; i < end; i++)
            {
                DataGridViewRow row=view.Rows[i];
                y += height ;
                x =inner.Left;
                for(int j=0;j<columns.Count;j++)
                {
                    DataGridViewCell cell = row.Cells[j];
                    str=cell.FormattedValue.ToString();
                    PrintColumn(str, x, y, columns[j]);
                    x += columns[j].Width;
                }
            }
            if (e.HasMorePages == false)    // 最後一頁,印出總金額
            {
                int y1=y+height/2+height;
                int x1=x;
                x = inner.Left;
                m_Graphics.DrawLine(SystemPens.WindowText, x, y1, x1, y1);
                y += 2 * height;
                x+=columns[0].Width;
                PrintColumn("總金額", x, y, columns[1]);
                x += columns[1].Width + columns[2].Width;
                m_TotalMoney = Math.Round(m_TotalMoney, 1);
                PrintColumn(m_TotalMoney.ToString(), x, y, columns[3]);    // 第三欄是總價
            }
        }

        private void printDocument_EndPrint(object sender, PrintEventArgs e)
        {
            PageIndex = -1;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDocument.PrinterSettings.PrintToFile = false;
            m_TotalMoney = 0;
            foreach (DataGridViewRow dgvRow in voucherDGView.Rows)
            {
                var rowView = dgvRow.DataBoundItem as DataRowView;
                var dataRow = rowView.Row as MyVoucherRow;
                if (!dataRow.IsCostNull()) m_TotalMoney += dataRow.Cost;
            }
            printDocument.Print();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void ReportByVender_SizeChanged(object sender, EventArgs e)
        {
            // 改用Anchor了
            // voucherDGView.Height = dataGridView1.Height = 
            //        ClientRectangle.Height - comboBoxMonth.Bottom  - 30;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            int monthFrom = this.cbBoxMonth.SelectedIndex;
            int monthTo = this.cbBoxMonthTo.SelectedIndex;
            if (monthFrom < 1 || monthFrom > 12 || monthTo < 1 || monthTo > 12)
            {
                MessageBox.Show("請選擇起迄月份!");
                return;
            }
            int dayFrom = this.cbBoxFrom.SelectedIndex+1;
            int dayTo = this.cbBoxTo.SelectedIndex+1;
            if (dayFrom <= 0 || dayFrom > 31 || dayTo <= 0 || dayTo > 31)
            {
                MessageBox.Show("起迄日期有問題!");
                return;
            }
            int id = (int)vendorIDComboBox.SelectedValue;
            if (id <= 0)
            {
                MessageBox.Show("請選擇供貨商!");
                return;
            }
            Calculate(monthFrom,dayFrom,monthTo,dayTo, id, vendorIDComboBox.Text);
            btnPrint.Enabled = true;
        }

        private void cbBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            int month = box.SelectedIndex;
            if (month < 1 || month > 12) return;
            int count = MyFunction.DayCountOfMonth(month);
            cbBoxFrom.Items.Clear();
            for (int i = 1; i <= count; i++)
                cbBoxFrom.Items.Add(i.ToString() + "日");
            cbBoxFrom.SelectedIndex = 0;
            if (month > cbBoxMonthTo.SelectedIndex )
                cbBoxMonthTo.SelectedIndex = month ;
            btnPrint.Enabled = false;
        }

        private void cbBoxMonthTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            int month = box.SelectedIndex;
            if (month < 1 || month > 12) return;
            int count = MyFunction.DayCountOfMonth(month);
            cbBoxTo.Items.Clear();
            for (int i = 1; i <= count; i++)
                cbBoxTo.Items.Add(i.ToString() + "日");
            cbBoxTo.SelectedIndex = count - 1;
            if (month < cbBoxMonth.SelectedIndex)
                cbBoxMonth.SelectedIndex = month;
            btnPrint.Enabled = false;
        }

        private void vendorIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPrint.Enabled = false;
        }

        private void cbBoxFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPrint.Enabled = false;
        }

        private void cbBoxTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPrint.Enabled = false;
        }
    }
}