using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace VoucherExpense
{
    public partial class FormMonthlyPay : Form
    {
        public FormMonthlyPay()
        {
            InitializeComponent();
        }

        private void FormMonthlyPay_Load(object sender, EventArgs e)
        {
            vendorTableAdapter.Connection   = MapPath.VEConnection;
            voucherTableAdapter.Connection  = MapPath.VEConnection;
            this.vendorTableAdapter.Fill(this.vEDataSet.Vendor);
            this.voucherTableAdapter.Fill(this.vEDataSet.Voucher);
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int month = this.comboBoxMonth.SelectedIndex;
            if (month < 1 || month > 12) return;
            Calculate(month);
            dgViewMonthlyPay.Focus();
        }

        public class CMonthlyPay
        {
            public int VenderID   { get; set; }
            public int OrderCount { get; set; }
            public decimal Money  { get; set; }
        }

        CMonthlyPay FindOrAdd(int id, SortableBindingList<CMonthlyPay> list)
        {
            foreach (CMonthlyPay p in list)
            {
                if (p.VenderID == id)
                    return p;
            }
            CMonthlyPay pay=new CMonthlyPay();
            pay.VenderID=id;
            list.Add(pay);
            return pay;
        }

        private void Calculate(int month)
        {
            SortableBindingList<CMonthlyPay> list = new SortableBindingList<CMonthlyPay>();
            foreach (VEDataSet.VoucherRow vr in this.vEDataSet.Voucher)
            {
                if (vr.IsStockTimeNull()) continue;
                if (vr.StockTime.Month != month) continue;
                if (vr.StockTime.Year != MyFunction.IntHeaderYear) continue;
                if (vr.IsVendorIDNull()) continue;
                if (!vr.IsRemovedNull())
                    if (vr.Removed) continue;

                int id=vr.VendorID;
                CMonthlyPay p = FindOrAdd(vr.VendorID, list);
                if (vr.Locked) p.OrderCount++;
                if (!vr.IsCostNull())
                    p.Money += vr.Cost;
            }
            dgViewMonthlyPay.DataSource = list;
            decimal total=0;
            foreach (CMonthlyPay p in list)
            {
                total += p.Money;
            }
            textBoxTotal.Text = total.ToString("F1");
            labelWarning1.Visible = false;
            labelWarning2.Visible = false;
        }

        #region ====== Printing ======
        int PageIndex = -1;
        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            PageIndex = 1;
        }

        bool m_PrintTotal = false;
        Graphics m_Graphics = null;
        Font m_Font = null;
        Brush m_Brush = null;
        Pen m_Pen = null;
        void PrintColumn(string str, int x, int y, int width)
        {
            SizeF size = m_Graphics.MeasureString(str, m_Font);
            x += (int)(width - size.Width);
            m_Graphics.DrawString(str, m_Font, m_Brush, new PointF(x, y));
        }

        void PrintColumn(string str, int x, int y, DataGridViewColumn col)
        {
            DataGridViewContentAlignment alignment = col.DefaultCellStyle.Alignment;

            int width = col.Width;
            if (alignment == DataGridViewContentAlignment.BottomRight ||
                alignment == DataGridViewContentAlignment.MiddleRight ||
                alignment == DataGridViewContentAlignment.TopRight)
            {
                SizeF size = m_Graphics.MeasureString(str, m_Font);
                x += (int)(width - size.Width);

            }
            m_Graphics.DrawString(str, m_Font, m_Brush, new PointF(x, y));
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            const int LinePerPage = 26;
            m_Graphics = e.Graphics;
            PageSettings settings = e.PageSettings;
            Rectangle inner = e.MarginBounds;
            Rectangle outter = e.PageBounds;
            SortableBindingList<CMonthlyPay> list = this.dgViewMonthlyPay.DataSource as SortableBindingList<CMonthlyPay>;
            if (list == null || PageIndex <= 0)
            {
                e.HasMorePages = false;
                return;
            }
            int start = (PageIndex - 1) * LinePerPage;
            int end = start + LinePerPage;
            DataGridView view = this.dgViewMonthlyPay;
            if (end > view.Rows.Count)
            {
                end = view.Rows.Count;
                e.HasMorePages = false;
            }
            else
                e.HasMorePages = true;
            m_Font = new Font("細明體", 18.0f);
            m_Brush = SystemBrushes.WindowText;
            m_Pen = SystemPens.WindowText;
            int x = inner.Left;
            int y = inner.Top;
            string str = "        "+MyFunction.IntHeaderYear.ToString()+"年"+ comboBoxMonth.Text + "廠商貨款總表";
            DataGridViewColumnCollection columns = view.Columns;
            m_Graphics.DrawString(str, m_Font, m_Brush, new PointF(x, y));
            int height = inner.Height / LinePerPage;
            y += 2 * height;
            int top = y - 4;
            m_Graphics.DrawLine(m_Pen, x, top, inner.Right, top);
            for (int j = 0; j < columns.Count; j++)
            {
                DataGridViewColumn col = columns[j];
                str = col.HeaderText;
                PrintColumn(str, x, y, col);
                x += view.Columns[j].Width;
            }
            int middle = x+4;
            int realPayWidth=(inner.Right-middle)/2;
            PrintColumn("實付", x, y, realPayWidth); x += realPayWidth;
            PrintColumn("簽收", x, y, realPayWidth);
            for (int i = start; i < end; i++)
            {
                DataGridViewRow row = view.Rows[i];
                y += height;
                x = inner.Left;
                m_Graphics.DrawLine(m_Pen, x, y - 4, inner.Right, y - 4);
                for (int j = 0; j < columns.Count; j++)
                {
                    DataGridViewCell cell = row.Cells[j];
                    str = cell.FormattedValue.ToString();
                    PrintColumn(str, x, y, columns[j]);
                    x += columns[j].Width;
                }
            }
            int bottom = (y + height) - 4;
            int l=inner.Left,r=inner.Right;
            m_Graphics.DrawLine(m_Pen,l , bottom, r, bottom);
            m_Graphics.DrawLine(m_Pen, l, top, l, bottom);
            m_Graphics.DrawLine(m_Pen, r, top, r, bottom);
            m_Graphics.DrawLine(m_Pen, middle, top, middle, bottom);    middle += realPayWidth;
            m_Graphics.DrawLine(m_Pen, middle, top, middle, bottom);
        
            if (m_PrintTotal && e.HasMorePages == false)    //  這是最後一頁
            {
                m_PrintTotal = false;
                x=inner.Left+columns[0].Width;
                y+=(2*height);
                PrintColumn("小計", x, y, columns[1]);
                x+=columns[1].Width;
                PrintColumn(textBoxTotal.Text, x, y, columns[2]);
            }
        }

        private void printDocument_EndPrint(object sender, PrintEventArgs e)
        {
            PageIndex = -1;
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDocument.PrinterSettings.PrintToFile = false;
            printDocument.Print();
        }

        private void FormMonthlyPay_SizeChanged(object sender, EventArgs e)
        {
            dgViewMonthlyPay.Height = ClientRectangle.Height - comboBoxMonth.Bottom  - 30;
        }

        private void btnIncludeTotal_Click(object sender, EventArgs e)
        {
            printDocument.PrinterSettings.PrintToFile = false;
            m_PrintTotal = true;
            printDocument.Print();
        }
      

    }
}