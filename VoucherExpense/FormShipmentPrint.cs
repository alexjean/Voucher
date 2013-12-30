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
                    shipmentnum.Font = new Font("黑体", 10);
                    shipmentnum.Location = new Point(650, 15);
                    shipmentnum.BackColor = Color.Transparent;
                    shipmentnum.AutoSize = true;
                    Label customername = new Label();
                    customername.Text = m_shipmentprint.CustomerName;
                    customername.Font = new Font("黑体", 10);
                    customername.Location = new Point(70, 48);
                    customername.BackColor = Color.Transparent;
                    customername.AutoSize = true;
                    Label contactpeople= new Label();
                    contactpeople.Text = m_shipmentprint.ContactPeople;
                    contactpeople.Font = new Font("黑体", 10);
                    contactpeople.Location = new Point(245, 48);
                    contactpeople.BackColor = Color.Transparent;
                    contactpeople.AutoSize = true;
                    Label contactphone = new Label();
                    contactphone.Text = m_shipmentprint.ContactPhone;
                    contactphone.Font = new Font("黑体", 10);
                    contactphone.Location = new Point(470, 48);
                    contactphone.BackColor = Color.Transparent;
                    contactphone.AutoSize = true;
                    Label entrytime = new Label();
                    entrytime.Text = m_shipmentprint.EntryTime;
                    entrytime.Font = new Font("黑体", 10);
                    entrytime.Location = new Point(680, 48);
                    entrytime.BackColor = Color.Transparent;
                    entrytime.AutoSize = true;
                    Label shipaddress = new Label();
                    shipaddress.Text = m_shipmentprint.ShipAddress;
                    shipaddress.Font = new Font("黑体", 10);
                    shipaddress.Location = new Point(70, 73);
                    shipaddress.BackColor = Color.Transparent;
                    shipaddress.AutoSize = true;
                    Label shiptime = new Label();
                    shiptime.Text = m_shipmentprint.ShipTime;
                    shiptime.Font = new Font("黑体", 10);
                    shiptime.Location = new Point(470, 73);
                    shiptime.BackColor = Color.Transparent;
                    shiptime.AutoSize = true;
                    Label numlabel = new Label();
                    numlabel.Text = num.ToString();
                    numlabel.Font = new Font("黑体", 10);
                    numlabel.Location = new Point(620, 502);
                    numlabel.BackColor = Color.Transparent;
                    numlabel.AutoSize = true;
                    Label numcountlabel = new Label();
                    numcountlabel.Text = list.Count().ToString();
                    numcountlabel.Font = new Font("黑体", 10);
                    numcountlabel.Location = new Point(692, 502);
                    numcountlabel.BackColor = Color.Transparent;
                    numcountlabel.AutoSize = true;
                    tp.Controls.Add(numcountlabel);
                    tp.Controls.Add(numlabel);
                    tp.Controls.Add(shipmentnum);
                    tp.Controls.Add(customername);
                    tp.Controls.Add(contactpeople);
                    tp.Controls.Add(contactphone);
                    tp.Controls.Add(entrytime);
                    tp.Controls.Add(shipaddress);
                    tp.Controls.Add(shiptime);
                    int y = 100;
                    foreach (var item1 in item)
                    {
                        y = y + 24;
                        Label productname = new Label();
                        productname.Text = item1.ProductName;
                        productname.Font = new Font("黑体", 10);
                        productname.Location = new Point(40,y );
                        productname.BackColor = Color.Transparent;
                        productname.AutoSize = true;
                        tp.Controls.Add(productname);
                        //规格
                        //。。。。。。。。
                        Label unit = new Label();
                        unit.Text = item1.Unit;
                        unit.Font = new Font("黑体", 10);
                        unit.Location = new Point(425, y);
                        unit.BackColor = Color.Transparent;
                        unit.AutoSize = true;
                        tp.Controls.Add(unit);
                        Label volum = new Label();
                        volum.Text = item1.Volum.ToString();
                        volum.Font = new Font("黑体", 10);
                        volum.Location = new Point(500, y);
                        volum.BackColor = Color.Transparent;
                        volum.AutoSize = true;
                        tp.Controls.Add(volum);
                    }
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
            Font font = new Font("黑体", 10);
            Brush brush = new SolidBrush(Color.Black);
            b = tabControl1.TabPages.Count;
            foreach (Control c in tabControl1.TabPages[a].Controls)
            {
                g.DrawString(c.Text, font, brush,  c.Location.X,  c.Location.Y );

            }
            g.DrawImage(VoucherExpense.Properties.Resources.shipment1, 0, 0, 800, 520);
            a += 1;
            if (a < b)
            {
                return true;
            }
            return false;

        }
        private void pD_QueryPageSettings(object sender, System.Drawing.Printing.QueryPageSettingsEventArgs e)
        {
            e.PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("", 850, 550);
        }
    }
    public class Shipmentprint
    {
        public string ShipmentNumber{get;set;}
        public string CustomerName { get; set; }
        public string ContactPeople { get; set; }
        public string ContactPhone { get; set; }
        public string EntryTime { get; set; }
        public string ShipAddress { get; set; }
        public string ShipTime { get; set; }
        public List<List<Shipmentdetailprint>> ShipmentDetileProduct { get; set; }//{第几页,共几页，产品，规格，单位，数量；第几页共几页，产品，规格，单位，数量；第几页共几页，产品，规格，单位，数量}
                                                                //{第几页共几页，产品，规格，单位，数量；第几页共几页，产品，规格，单位，数量；第几页共几页，产品，规格，单位，数量}
    }
    public class Shipmentdetailprint
    {
        public int Num { get; set; }
        public int NumCount{get;set;}
        public string ProductName { get; set; }
        public string ProductSpecifications { get; set; }
        public string Unit { get; set; }
        public int Volum { get; set; }
    }
}
