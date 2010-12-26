using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace VoucherExpense
{
    public partial class ReportByVender : Form
    {
        public ReportByVender()
        {
            InitializeComponent();
        }

        CVendor vendor = new CVendor();
   
        private void ReportByVender_Load(object sender, EventArgs e)
        {
            vendorTableAdapter.Connection        = MapPath.VEConnection;
            voucherTableAdapter.Connection       = MapPath.VEConnection;
            voucherDetailTableAdapter.Connection = MapPath.VEConnection;
            IngredientTableAdapter.Connection    = MapPath.VEConnection;
            this.vendorTableAdapter.Fill(this.vEDataSet.Vendor);
            this.voucherTableAdapter.Fill(this.vEDataSet.Voucher);
            this.voucherDetailTableAdapter.Fill(this.vEDataSet.VoucherDetail);
            this.IngredientTableAdapter.Fill(this.vEDataSet.Ingredient);
            cVendorBindingSource.DataSource = vendor;
            comboBoxMonth.SelectedIndex=DateTime.Now.Month;
            this.voucherDGView.DataSource = null;  // 原本先用了 vEDataSet.Voucher做格式
        }

        private void Add2List(List<CIngredient> list,int id, decimal cost, decimal volume)
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

        void Calculate(int month,int id)
        {
            List<CIngredient> list = new List<CIngredient>();
            VEDataSet.VoucherDataTable voucher = new VEDataSet.VoucherDataTable();
            int count = 0,checkedCount=0;
            foreach (VEDataSet.VoucherRow vr in vEDataSet.Voucher)
            {
                if (month != 0)   
                {
                    if (vr.IsStockTimeNull()) continue;
                    if (vr.StockTime.Month != month) continue;
                }
                if (vr.StockTime.Year != MyFunction.IntHeaderYear) continue;
                if (vr.IsVendorIDNull()) continue;
                if (vr.VendorID != id) continue;
                if (!vr.IsRemovedNull())
                    if (vr.Removed) continue;
                VEDataSet.VoucherRow row = voucher.NewVoucherRow();
                row.ItemArray = vr.ItemArray;
                voucher.AddVoucherRow(row);
                count++;
                if (vr.Locked) checkedCount++;
                decimal checkSum = 0;
                foreach (VEDataSet.VoucherDetailRow dr in vr.GetVoucherDetailRows())
                {
                    if (dr.IsIngredientCodeNull()) continue;
                    decimal co=0,vo=0;
                    if (!dr.IsCostNull())   co = dr.Cost;
                    if (!dr.IsVolumeNull()) vo = dr.Volume;
                    checkSum += co;
                    Add2List(list,dr.IngredientCode, co, vo);
                }
                decimal vrCost=0;
                if (!vr.IsCostNull()) vrCost = vr.Cost;
                if (checkSum != vrCost)
                    MessageBox.Show("警告!<" + vr.VoucherID.ToString() +
                        ">號細項和"+checkSum.ToString("f1")+
                        "和總和"   +vr.Cost.ToString("f1")+"不符!");
            }
            decimal sum=0;
            foreach (CIngredient p in list)
                sum+=p.TotalCost;
            textBox1.Text = sum.ToString("N1");
            labelCount.Text = "共 " + checkedCount.ToString() + "單("+count.ToString()+")";
            this.dataGridView1.DataSource = list;
            this.voucherDGView.DataSource = voucher;
        }

        private void vendorIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cVendorBindingSource.EndEdit();
            if (vendor.ID == 0) return;  // _Load時設的,不處理
            int month=this.comboBoxMonth.SelectedIndex;
            if (month<1 || month>12) month=0;
            Calculate(month,vendor.ID);
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            cVendorBindingSource.EndEdit();
            if (vendor.ID == 0) return;  // 沒有供貨商時,不用處理
            int month = this.comboBoxMonth.SelectedIndex;
            if (month < 1 || month > 12) month = 0;
            Calculate(month, vendor.ID);
         }

        private void ReportByVender_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataGridView1.DataSource = null;  // 先設成null,避免表中的DataGridView 因某些table己經沒了而出錯
        }

        int PageIndex = -1;
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
            const int LinePerPage = 40;
            m_Graphics = e.Graphics;
            PageSettings settings   = e.PageSettings;
            Rectangle    inner      = e.MarginBounds;
            Rectangle    outter     = e.PageBounds;
            List<CIngredient> list = dataGridView1.DataSource as List<CIngredient>;
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
                end = view.Rows.Count ;
                e.HasMorePages = false;
            }
            else
                e.HasMorePages = true;
            m_Font = new Font("細明體", 12.0f);
            m_Brush= SystemBrushes.WindowText;
            int x = inner.Left;
            int y = inner.Top ;
            string str="       "+comboBoxMonth.Text+"           供應商:"+vendorIDComboBox.Text;
            DataGridViewColumnCollection columns = view.Columns;
            m_Graphics.DrawString(str, m_Font, m_Brush, new PointF(x, y));
            int height = inner.Height / LinePerPage;
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
        }

        private void printDocument_EndPrint(object sender, PrintEventArgs e)
        {
            PageIndex = -1;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDocument.PrinterSettings.PrintToFile = false;
            printDocument.Print();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void ReportByVender_SizeChanged(object sender, EventArgs e)
        {
            voucherDGView.Height = dataGridView1.Height = 
                    Height - comboBoxMonth.Bottom + Top - 30;
        }

      

    }
}