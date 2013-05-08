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
        public class CSelectedVoucher
        {
            int id;
            decimal cot;
            public int ID { get { return id; } set { id = value; } }
            public decimal Cost { get { return cot; } set { cot = value; } }
            public VEDataSet.VoucherRow Voucher;
            public CSelectedVoucher(int i, decimal d, VEDataSet.VoucherRow voucher) { id = i; cot = d; Voucher = voucher;  }
        }


        public bool m_PrintSelectedVouchers = false;     // true 表示要列印所選的單子
        public List<CSelectedVoucher> m_SelectedVoucher = null;
        public List<int> m_SelectedVenderID = new List<int>();
        public List<string> m_SelectedVenderName = new List<string>();
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
            foreach (DataGridViewRow row in voucherDataGridView.SelectedRows)
            {
                try
                {
                    DataRowView rowView = row.DataBoundItem as DataRowView;
                    VEDataSet.VoucherRow dataRow = rowView.Row as VEDataSet.VoucherRow;
                    if (dataRow.IsRemovedNull()) continue;  // 己移除的無法選入 
                    if (dataRow.Removed) continue;
                    decimal cost = dataRow.IsCostNull() ? 0m : dataRow.Cost;
                    m_SelectedVoucher.Add(new CSelectedVoucher(dataRow.ID, cost,dataRow));
                }
                catch (Exception ex)
                {
                    Trace.WriteLine("PrintVoucher:" + ex.Message);
                }
            }
            m_SelectedVoucher.Sort(comparer);
            m_PrintSelectedVouchers = false;
            Form form = new FormPrintSelect(this);
            if (form.ShowDialog() != DialogResult.OK) return;
            if (m_PrintSelectedVouchers)
                printDocument.Print();
            else if (m_SelectedVenderID.Count > 0)
                printDocument.Print();
        }

        Graphics m_Graphics = null;
        Font m_Font = null;
        Brush m_Brush = null;
        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            m_More = -1;
        }

        void OneDetailLine(int x,int y,int CostOffset,VEDataSet.VoucherRow row)
        {
            const int IngredientOffset = 100;
            string str;
            str = row.VoucherID.ToString();                 m_Graphics.DrawString(str, m_Font, m_Brush, x, y);
            str = row.StockTime.Day.ToString("d02");        m_Graphics.DrawString(str, m_Font, m_Brush, x + 88, y);
            decimal dCost = row.IsCostNull() ? 0m : row.Cost;
            str = dCost.ToString("f1");                     float w = m_Graphics.MeasureString(str, m_Font).Width;
                                                            m_Graphics.DrawString(str, m_Font, m_Brush, x + CostOffset + 40 - w, y);
            try
            {
                VEDataSet.VoucherDetailRow[] dRows = row.GetVoucherDetailRows();
                str = "";
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
                    if (name.Length > 8) name = name.Substring(0,8);
                    str += ("  " + name + " " + vol + " (" + cost + ")");
                    if (str.Length < 20)
                        for (int k = str.Length; k < 20; k++)
                            str += " ";
                }
            }
            catch { }
            m_Graphics.DrawString(str, m_Font, m_Brush, x + IngredientOffset, y);
        }

        int printOneVender(int x, int y, int height, int month, int venderID, string venderName, ref int more, int lastItemHeight)
        {
           const int CostOffset = 600;
           string str = "       " + MyFunction.HeaderYear + "年 " + month.ToString() + "月           供應商: " + venderName;

            m_Graphics.DrawString(str, m_Font, m_Brush, x, y);
            y += height;
            str = "憑証號    日";            m_Graphics.DrawString(str, m_Font, m_Brush, x, y);
            str = "金額";                    m_Graphics.DrawString(str, m_Font, m_Brush, x + CostOffset, y);
            int count = 0;
            decimal total = 0;
            int lineCount = 0;
            int mo = more;
            bool NeedMore = false;

            foreach (VEDataSet.VoucherRow row in vEDataSet.Voucher)
            {
                if (row.IsVendorIDNull()) continue;
                if (row.VendorID != venderID) continue;
                if (row.IsStockTimeNull()) continue;
                if (row.StockTime.Month != month) continue;
                if (row.StockTime.Year != MyFunction.IntHeaderYear) continue;
                if (row.IsVoucherIDNull()) continue;
//                if (row.IsCostNull()) continue;
                if (mo > 0)
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
                count++;
                total += (row.IsCostNull() ? 0m : row.Cost);

                OneDetailLine(x, y, CostOffset, row);
            }
            y += 2 * height;
            str = "   共 " + count.ToString() + "張";            m_Graphics.DrawString(str, m_Font, m_Brush, x, y);
            str = "小計 " + total.ToString("f1");                float w = m_Graphics.MeasureString(str, m_Font).Width;
                                                                 m_Graphics.DrawString(str, m_Font, m_Brush, x + CostOffset + 40 - w, y);
            y += height;
            m_Graphics.DrawLine(SystemPens.WindowText, x, y, x + CostOffset + 40, y);
            if (!NeedMore) more = -1;
            return y + height;
        }

        bool PrintByVender(int x, int y, int height, int month, int itemLastHeight)  // return more
        {
            if (m_SelectedVenderID.Count > 0)
                while (m_SelectedVenderID.Count > 0)
                {
                    int venderID = m_SelectedVenderID[0];
                    int more = m_More;
                    y = printOneVender(x, y, height, month, venderID, m_SelectedVenderName[0], ref more,itemLastHeight );
                    if (more != -1)
                    {
                        m_More = more;
                        return true;   
                    }
                    m_SelectedVenderName.RemoveAt(0);
                    m_SelectedVenderID.RemoveAt(0);
                }
            return false;
        }

        bool PrintUserSelected(int x, int y, int height, int month, int itemLastHeight)
        {
            const int CostOffset = 600;
            string str = "       " + MyFunction.HeaderYear + "年 " + month.ToString() + "月";

            m_Graphics.DrawString(str, m_Font, m_Brush, x, y);
            y += height;
            str = "憑証號    日";            m_Graphics.DrawString(str, m_Font, m_Brush, x, y);
            str = "金額";                    m_Graphics.DrawString(str, m_Font, m_Brush, x + CostOffset, y);
            int count = 0;
            decimal total = 0;
            int lineCount = 0;
            bool NeedMore = false;
            foreach (CSelectedVoucher cVoucher in m_SelectedVoucher)
            {
                var row = cVoucher.Voucher;
                if (row == null || Convert.IsDBNull(row)) continue;
                if (row.IsVoucherIDNull()) continue;
                lineCount++;
                if (y > itemLastHeight || lineCount > 35)
                {
                    NeedMore = true;
                    break;
                }
                y += height;
                count++;
                total += (row.IsCostNull() ? 0m : row.Cost);
                OneDetailLine(x, y, CostOffset, row);
            }
            y += 2 * height;
            str = "   共 " + count.ToString() + "張";             m_Graphics.DrawString(str, m_Font, m_Brush, x, y);
            str = "小計 " + total.ToString("f1");                 float w = m_Graphics.MeasureString(str, m_Font).Width;
                                                                  m_Graphics.DrawString(str, m_Font, m_Brush, x + CostOffset + 40 - w, y);
            y += height;
            m_Graphics.DrawLine(SystemPens.WindowText, x, y, x + CostOffset + 40, y);
            return NeedMore;
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
            int month = comboBoxMonth.SelectedIndex;
            if (m_PrintSelectedVouchers)
                e.HasMorePages = PrintUserSelected(x, y, height, month, inner.Bottom - 5 * height);
            else
                e.HasMorePages = PrintByVender(x, y, height, month, inner.Bottom - 5 * height);
            m_Graphics.DrawString("收到以上單據無誤    接收人:", m_Font, m_Brush, x, inner.Bottom - height);
        }

   
    }
}
