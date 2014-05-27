using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VoucherExpense
{
    public partial class FormShipmentReport : Form
    {
        public FormShipmentReport()
        {
            InitializeComponent();
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
            if (month > cbBoxMonthTo.SelectedIndex)
                cbBoxMonthTo.SelectedIndex = month;
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


        private void FormShipmentReport_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“damaiDataSet.Customer”中。您可以根据需要移动或删除它。
            this.customerTableAdapter.Fill(this.damaiDataSet.Customer);

        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            int monthFrom = this.cbBoxMonth.SelectedIndex;
            int monthTo = this.cbBoxMonthTo.SelectedIndex;
            if (monthFrom < 1 || monthFrom > 12 || monthTo < 1 || monthTo > 12)
            {
                MessageBox.Show("请选择起止月份月份!");
                return;
            }
            int dayFrom = this.cbBoxFrom.SelectedIndex + 1;
            int dayTo = this.cbBoxTo.SelectedIndex + 1;
            if (dayFrom <= 0 || dayFrom > 31 || dayTo <= 0 || dayTo > 31)
            {
                MessageBox.Show("起止日期有問題!");
                return;
            }
            int id = (int)nameComboBox.SelectedValue;
            if (id <= 0)
            {
                MessageBox.Show("請選擇客户!");
                return;
            }
            Calculate(monthFrom, dayFrom, monthTo, dayTo, id);
        }
        void Calculate(int monthFrom, int dayFrom, int monthTo, int dayTo, int id)
        {
            SqlConnection conn= new SqlConnection();
            conn.ConnectionString="Data Source= "+MyFunction.HardwareCfg.SqlServerIP+" ; uid="+MyFunction.HardwareCfg.SqlUserID+" ;pwd= "+ MyFunction.HardwareCfg.SqlPassword+" ;database ="+MyFunction.HardwareCfg.SqlDatabase;
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "  select p.Name 产品名, count(sd.ProductID) 次数,p.Price 单价,sum(sd.Volume) 总量,cast(sum(sd.Cost) as decimal(38,2))金额 from Product p,Shipment s,ShipmentDetail sd where p.ProductID=sd.ProductID and s.ID=sd.ShipmentID and s.customer= " + id + " and s.ShipTime<'" + MyFunction.IntHeaderYear + monthTo.ToString("00") + dayTo.ToString("00") + "' and s.ShipTime>'" + MyFunction.IntHeaderYear + monthFrom.ToString("00") + dayFrom.ToString("00") + "' and sd.Volume>0 group by p.Name,p.Price" + "  select s.ShipCode 凭证号,s.ShipTime 出货时间,s.Cost 金额 from Shipment s where s.customer= " + id + " and  s.ShipTime>'" + MyFunction.IntHeaderYear + monthFrom.ToString("00") + dayFrom.ToString("00") + "'  and s.ShipTime<'" + MyFunction.IntHeaderYear + monthTo.ToString("00") + dayTo.ToString("00") + "'";
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView2.DataSource= ds.Tables[1];
            object sumObject =ds.Tables[0].Compute("sum(金额)", "TRUE");
            this.tBTotal.Text = sumObject.ToString();
            labelCount.Text = "共" + ds.Tables[1].Rows.Count+ "张";
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            pD.Print();
        }
        Graphics m_Graphics;
        int PageIndex = 1;
        Font m_Font;
        Brush m_Brush;
        private void pD_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            const int LinePerPage = 38;
            m_Graphics = e.Graphics;
           // PageSettings settings = e.PageSettings;
            Rectangle inner = e.MarginBounds;
            Rectangle outter = e.PageBounds;

            //BindingList<CIngredient> list = dataGridView1.DataSource as BindingList<CIngredient>;
            //if (list == null || PageIndex <= 0)
            //{
            //    e.HasMorePages = false;
            //    return;
            //}
            int start = (PageIndex - 1) * LinePerPage;
            int end = start + LinePerPage;
            DataGridView view = this.dataGridView1;
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
            m_Brush = SystemBrushes.WindowText;
            int x = inner.Left;
            int y = inner.Top;
            string str = "       " + cbBoxMonth.Text + cbBoxFrom.Text + "-" + cbBoxMonthTo.Text + cbBoxTo.Text + "        客户:" + nameComboBox.Text;
            DataGridViewColumnCollection columns = view.Columns;
            m_Graphics.DrawString(str, m_Font, m_Brush, new PointF(x, y));
            int height = inner.Height / (LinePerPage + 2);      // 保留二行做頁底
            y += 2 * height;
            for (int j = 0; j < columns.Count; j++)
            {
                DataGridViewColumn col = columns[j];
                str = col.HeaderText;
                PrintColumn(str, x, y, col);
                x += view.Columns[j].Width;
            }
            for (int i = start; i < end; i++)
            {
                DataGridViewRow row = view.Rows[i];
                y += height;
                x = inner.Left;
                for (int j = 0; j < columns.Count; j++)
                {
                    DataGridViewCell cell = row.Cells[j];
                    str = cell.FormattedValue.ToString();
                    PrintColumn(str, x, y, columns[j]);
                    x += columns[j].Width;
                }
            }
            if (e.HasMorePages == false)    // 最後一頁,印出總金額
            {
                int y1 = y + height / 2 + height;
                int x1 = x;
                x = inner.Left;
                m_Graphics.DrawLine(SystemPens.WindowText, x, y1, x1, y1);
                y += 2 * height;
                x += columns[0].Width;
                PrintColumn("总金额", x, y, columns[1]);
                x += columns[1].Width + columns[2].Width;
                //m_TotalMoney = Math.Round(m_TotalMoney, 1);
                PrintColumn(tBTotal.Text.ToString(), x, y, columns[3]);    // 第三欄是總價
            }
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
                x += (int)(col.Width - size.Width);
            }
            m_Graphics.DrawString(str, m_Font, m_Brush, new PointF(x, y));
        }
    }
}
