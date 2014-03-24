using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace VoucherExpense
{
    public partial class FormShipmentPrint : Form
    {
        public FormShipmentPrint()
        {
            InitializeComponent();
        }
        Shipmentprint m_shipmentprint = new Shipmentprint();
        public FormShipmentPrint(Shipmentprint smp)
        {
            InitializeComponent();
            m_shipmentprint = smp;
        }
        private void FormShipmentPrint_Load(object sender, EventArgs e)
        {
            int num = 0;

            if (m_shipmentprint == null)
            {
                MessageBox.Show("没有单子！");
            }
            else
            {
                List<List<Shipmentdetailprint>> list = m_shipmentprint.ShipmentDetileProduct;
                int i = 0;//序号
                foreach (var item in list)
                {
                    num = num + 1;
                    TabPage tp = new TabPage();
                    tp.Text = "第" + num + "页";
                    tp.BackgroundImage = VoucherExpense.Properties.Resources.shipment1;
                    tp.BackgroundImageLayout = ImageLayout.Stretch;
                    tp.BackColor = Color.White;
                    Label shipmentnum = new Label();
                    shipmentnum.Text = m_shipmentprint.ShipmentNumber;
                    shipmentnum.Font = new Font("宋体", 10);
                    shipmentnum.Location = new Point(590, 10);
                    shipmentnum.BackColor = Color.Transparent;
                    shipmentnum.AutoSize = true;
                    Label customername = new Label();
                    customername.Text = m_shipmentprint.CustomerName;
                    customername.Font = new Font("宋体", 10);
                    customername.Location = new Point(80, 38);
                    customername.BackColor = Color.Transparent;
                    customername.AutoSize = true;
                    Label contactpeople = new Label();
                    contactpeople.Text = m_shipmentprint.ContactPeople;
                    contactpeople.Font = new Font("宋体", 10);
                    contactpeople.Location = new Point(362, 38);
                    contactpeople.BackColor = Color.Transparent;
                    contactpeople.AutoSize = true;
                    Label contactphone = new Label();
                    contactphone.Text = m_shipmentprint.ContactPhone;
                    contactphone.Font = new Font("宋体", 10);
                    contactphone.Location = new Point(570, 38);
                    contactphone.BackColor = Color.Transparent;
                    contactphone.AutoSize = true;
                    Label entrytime = new Label();
                    entrytime.Text = m_shipmentprint.EntryTime;
                    entrytime.Font = new Font("宋体", 10);
                    entrytime.Location = new Point(600, 66);
                    entrytime.BackColor = Color.Transparent;
                    entrytime.AutoSize = true;
                    Label shipaddress = new Label();
                    shipaddress.Text = m_shipmentprint.ShipAddress;
                    shipaddress.Font = new Font("宋体", 10);
                    shipaddress.Location = new Point(78, 66);
                    shipaddress.BackColor = Color.Transparent;
                    shipaddress.AutoSize = true;
                    Label shiptime = new Label();
                    shiptime.Text = m_shipmentprint.ShipTime;
                    shiptime.Font = new Font("宋体", 10);
                    shiptime.Location = new Point(428, 66);
                    shiptime.BackColor = Color.Transparent;
                    shiptime.AutoSize = true;
                    Label numlabel = new Label();
                    numlabel.Text = num.ToString() + "/" + list.Count().ToString();
                    numlabel.Font = new Font("宋体", 10);
                    numlabel.Location = new Point(520, 448);
                    numlabel.BackColor = Color.Transparent;
                    numlabel.AutoSize = true;
                    //Label numcountlabel = new Label();
                    //numcountlabel.Text = list.Count().ToString();
                    //numcountlabel.Font = new Font("宋体", 10);
                    //numcountlabel.Location = new Point(540, 468);
                    //numcountlabel.BackColor = Color.Transparent;
                    //numcountlabel.AutoSize = true;
                    // tp.Controls.Add(numcountlabel);
                    tp.Controls.Add(numlabel);
                    tp.Controls.Add(shipmentnum);
                    tp.Controls.Add(customername);
                    tp.Controls.Add(contactpeople);
                    tp.Controls.Add(contactphone);
                    tp.Controls.Add(entrytime);
                    tp.Controls.Add(shipaddress);
                    tp.Controls.Add(shiptime);
                    int y = 90;
                    decimal pageCount = 0;
                    foreach (var item1 in item)
                    {
                        pageCount = pageCount + item1.AllCost;
                        y = y + 18;
                        i++;
                        Label xuhao = new Label();
                        xuhao.Text = i.ToString();
                        xuhao.Font = new Font("宋体", 10);
                        xuhao.Location = new Point(33, y);
                        xuhao.BackColor = Color.Transparent;
                        xuhao.AutoSize = true;
                        tp.Controls.Add(xuhao);

                        Label code = new Label();
                        code.Text = item1.ProductCode.ToString(); ;
                        code.Font = new Font("宋体", 10);
                        code.Location = new Point(84, y);
                        code.BackColor = Color.Transparent;
                        code.AutoSize = true;
                        tp.Controls.Add(code);

                        Label productname = new Label();
                        productname.Text = item1.ProductName;
                        productname.Font = new Font("宋体", 10);
                        productname.Location = new Point(170, y);
                        productname.BackColor = Color.Transparent;
                        productname.AutoSize = true;
                        tp.Controls.Add(productname);

                        Label danwei = new Label();
                        if (item1.Unit==null)
                        {
                            danwei.Text = item1.Unit;
                        }
                        else
	{
danwei.Text = item1.Unit;
	}
                        
                        danwei.Font = new Font("宋体", 10);
                        danwei.Location = new Point(315, y);
                        danwei.BackColor = Color.Transparent;
                        danwei.AutoSize = true;
                        tp.Controls.Add(danwei);
                        //规格
                        //。。。。。。。。
                        Label volum = new Label();
                       // volum.Text = item1.Volum.ToString();
                        int l2 = item1.Volum.ToString().Length;
                        string strvolum = item1.Volum.ToString(); 
                        for (int ii = 0; ii < 5 - l2; ii++)
                        {
                            strvolum = strvolum.Insert(0, " ");
                        }
                        volum.Text = strvolum;
                        volum.Font = new Font("宋体", 10);
                        volum.Location = new Point(359, y);
                        volum.BackColor = Color.Transparent;
                        volum.Tag = "Right";
                        volum.AutoSize = true;
                        tp.Controls.Add(volum);

                        Label danjia = new Label();
                        //danjia.Text = item1.Cost.ToString();
                        int l1 = item1.Cost.ToString().Length;
                        string strdanjia = item1.Cost.ToString(); 
                        for (int ii = 0; ii < 5 - l1; ii++)
                        {
                            strdanjia = strdanjia.Insert(0, " ");
                        }
                        danjia.Text = strdanjia;
                        danjia.Font = new Font("宋体", 10);
                        danjia.Location = new Point(425, y);
                        danjia.BackColor = Color.Transparent;
                        danjia.Tag = "Right";
                        danjia.AutoSize = true;
                        tp.Controls.Add(danjia);

                        Label jine = new Label();
                        int l = item1.AllCost.ToString("0.00").Length;
                        string strjine=item1.AllCost.ToString("0.00");
                        for (int ii = 0; ii< 9-l; ii++)
                        {
                            strjine = strjine.Insert(0, " ");
                        }
                        jine.Text = strjine;
                        jine.Font = new Font("宋体", 10);
                        jine.Location = new Point(495, y);
                        jine.BackColor = Color.Transparent;
                        jine.Tag = "Right";
                        jine.AutoSize = true;
                        tp.Controls.Add(jine);

                    }
                    if (num == list.Count)
                    {
                        Label allPageCostCount = new Label();
                        allPageCostCount.Text ="总金额："+ m_shipmentprint.CostAllCount.ToString("0.00");
                        allPageCostCount.Font = new Font("宋体", 10);
                        allPageCostCount.Location = new Point(548,376);
                        allPageCostCount.BackColor = Color.Transparent;
                        allPageCostCount.AutoSize = true;
                        tp.Controls.Add(allPageCostCount);
                    }
                    Label thisPageCostCount = new Label();
                    thisPageCostCount.Text = pageCount.ToString("0.00");
                    thisPageCostCount.Font = new Font("宋体", 10);
                    thisPageCostCount.Location = new Point(460, 376);
                    thisPageCostCount.BackColor = Color.Transparent;
                    thisPageCostCount.AutoSize = true;
                    int b = thisPageCostCount.Width;
                    tp.Controls.Add(thisPageCostCount);
                    Label apartmentName = new Label();
                    apartmentName.Text = m_shipmentprint.ApartmentName+"出货单";
                    apartmentName.Font = new Font("宋体", 12);
                    apartmentName.Location = new Point(240, 4);
                    apartmentName.BackColor = Color.Transparent;
                    apartmentName.AutoSize = true;
                    int a = apartmentName.Width;
                    tp.Controls.Add(apartmentName);
                    tabControl1.TabPages.Add(tp);

                }
            }
        }

        private void pD_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (myPrint(e.Graphics))
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }
        HardwareConfig Config;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Config = MyFunction.HardwareCfg;
                PrinterSettings ps = new PrinterSettings();
                ps.PrinterName = Config.DotPrinterName;
                pD.PrinterSettings = ps;
                 pD.Print();
                 this.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }
        int a = 0;   //起始页
        int b = 1;   //总页数
        private bool myPrint(Graphics g)
        {
           Image image = global::VoucherExpense.Properties.Resources.shipment1;
          // Font font = new Font("宋体", 9); 
           Brush brush = new SolidBrush(Color.Black); if (a == b)
           { g.DrawString("", new Font("", 9), brush, new PointF(0, 0)); }
           else
           {
               Graphics g1 = Graphics.FromImage(image);
               b = tabControl1.TabPages.Count;

               foreach (Control c in tabControl1.TabPages[a].Controls)
               {
                   //if (c.Tag.ToString() == "Right")
                   //{
                   //    //PrintNum(g1, c.Font, brush, c.Text, c.Location.X * 2, c.Location.Y * 2);
                   //    SizeF size = g1.MeasureString(c.Text, c.Font);
                   //    g1.DrawString(c.Text, c.Font, brush, new PointF(c.Location.X * 2-(int)size.Width*2, c.Location.Y * 2));
                   //}
                   //else
                   //{
                   g1.DrawString(c.Text, c.Font, brush, c.Location.X * 2, c.Location.Y * 2);
                   //}
               }
               g1.DrawString(DateTime.Now.ToString(), new Font("宋体", 7), brush, 565 * 2, 450 * 2);
               g.DrawImage(image, new Point(0, -5));
           }
            //g.DrawImage(VoucherExpense.Properties.Resources.shipment1, 0, 0, 800, 510);
            a += 1;
      
            if (a < b+1)
            {
                return true;
            }
            return false;
        }
        private void pD_QueryPageSettings(object sender, System.Drawing.Printing.QueryPageSettingsEventArgs e)
        {
            e.PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("", 850, 552);
            e.PageSettings.Margins = new Margins(0, 0, 0, 0);
        }
        //void PrintNum(Graphics g, Font font,Brush brush, string str,  int x, int y)
        //{
        //    SizeF size = g.MeasureString(str, font);
        //    x =x-(int)size.Width;
        //    g.DrawString(str, font, brush, new PointF(x, y));
        //}
    }
    public class Shipmentprint
    {
        public string ApartmentName { get; set; }
        public string ShipmentNumber{get;set;}
        public string CustomerName { get; set; }
        public string ContactPeople { get; set; }
        public string ContactPhone { get; set; }
        public string EntryTime { get; set; }
        public string ShipAddress { get; set; }
        public string ShipTime { get; set; }
        public decimal CostAllCount { get; set; }
        public List<List<Shipmentdetailprint>> ShipmentDetileProduct { get; set; }//{第几页,共几页，产品，规格，单位，数量；第几页共几页，产品，规格，单位，数量；第几页共几页，产品，规格，单位，数量}
                                             //{第几页共几页，产品，规格，单位，数量；第几页共几页，产品，规格，单位，数量；第几页共几页，产品，规格，单位，数量}
    }
    public class Shipmentdetailprint
    {
        public int Num { get; set; }
        public int PageNum { get; set; }
        public int PageNumCount{get;set;}
        public string ProductName { get; set; }
        public int ProductCode { get; set; }
        public string Unit { get; set; }
        public int Volum { get; set; }
        public double Cost { get; set; }
        public decimal AllCost { get; set; }
    }
}
