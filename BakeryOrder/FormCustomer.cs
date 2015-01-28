using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace BakeryOrder
{
    public partial class FormCustomer : Form
    {
        public FormCustomer()
        {
            InitializeComponent();

        }

        string[] m_Files = null;
        string m_Path = "SlideShow";
        string m_Original = "SlideShow\\Original";
        int m_Count = 0;
        const int m_DefaultInterval = 4000;
        private void FormCustomer_Load(object sender, EventArgs e)
        {

            Screen[] scr = Screen.AllScreens;
            if (scr.Count() > 1)
            {
                int i = 0;
                if (scr[i].Primary) i = 1;
                Location = new Point(scr[i].Bounds.X, scr[i].Bounds.Y);
            }
            if (!Directory.Exists(m_Path))
            {
                MessageBox.Show("照片目錄不存在!");
                return;
            }
            // 圖太大的先縮圖
            try
            {
                if (!Directory.Exists(m_Original))
                    Directory.CreateDirectory(m_Original);
                DirectoryInfo dirInfo = new DirectoryInfo(m_Path);
                FileInfo[] infos = dirInfo.GetFiles();
                foreach (FileInfo info in infos)
                {
                    if (info.Extension.ToUpper()!=".JPG") continue;
                    if (info.Length > 1000 * 1024)
                    {
                        string dest=m_Original+"\\"+info.Name;
                        string newName = m_Path + "\\" + "Small_" + info.Name;
                        try
                        {
                            if (File.Exists(dest))
                                File.Replace(info.FullName, dest, null, true);
                            else
                                File.Move(info.FullName, dest);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("轉換" + info.Name + "成小圖時出錯:" + ex.Message);
                        }
                        CreateSmallImage(dest, 1024, 768, newName);
                    }
                }
                
            }
            catch { }
            m_Files = Directory.GetFiles(m_Path,"*.jpg");
            if (m_Files.Count()==0) return;
            imgShow(Image.FromFile(m_Files[m_Count]));
            timer1.Interval = m_DefaultInterval;
            timer1.Start();

        }

        private void imgShow(Image img)
        {
            this.myImgControl1.BackgroundImage = img;
            this.myImgControl1.MyStrColor = Color.Red;
            this.myImgControl1.MyStr = "";
            if (FormCashier.memberInfo!=null)
            {
                this.myImgControl1.changetext("尊敬的会员您好！");  
            }
            else
            {
                this.myImgControl1.changetext("");    
            }
           
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            m_Count++;

            if (m_Count >= m_Files.Count()) m_Count = 0;
            timer1.Interval = m_DefaultInterval;
            //this.panel1.BringToFront();
            //myImgControl1.ImageLocation = m_Files[m_Count];
            //myImgControl1.BackgroundImage = Image.FromFile(m_Files[m_Count]);
            //myImgControl1.MyStr = "333";
           // myImgControl1.Refresh();
            imgShow(Image.FromFile(m_Files[m_Count]));
            if (this.myImgControl1.Dock != DockStyle.Fill)
                this.myImgControl1.Dock = DockStyle.Fill;
        }

        public void SetTimer(int tick)
        {
            timer1.Interval = tick;
            if (this.myImgControl1.Dock != DockStyle.Right)
                this.myImgControl1.Dock = DockStyle.Right;
        }

        public void ShowTotal(double total)
        {
            labelTotal.Text = total.ToString();
        }

        private ListViewItem FindByProductIDFromList(int productID)
        {
            foreach (ListViewItem lvItem in lvCustomer.Items)
            {
                if (productID == (int)lvItem.Tag) return lvItem;
            }
            return null;
        }

        public void Item2List(int productID,string name, double No, double money)
        {
            ListViewItem lvItem=FindByProductIDFromList(productID);
            if (lvItem==null)
            {
                if (No==0) return;
                lvItem = lvCustomer.Items.Add(name);
                lvItem.SubItems.Add(No.ToString());
                lvItem.SubItems.Add(money.ToString());
                lvItem.Tag = productID;
            }
            else
            {
                if (No==0)
                    lvCustomer.Items.Remove(lvItem);
                else
                {                
                    lvItem.SubItems[1].Text = No.ToString();
                    lvItem.SubItems[2].Text = money.ToString(); ;
                }
            }
        }

        public void SetPicture(Image img)
        {
            pictureBoxOrdered.Image = img;
        }

        void CreateSmallImage(string sourceFile, int w, int h, string destFile)
        {
            if (!File.Exists(sourceFile))
            {
                Bitmap img1 = new Bitmap(1, 1);
                img1.Save(destFile);
                return;
            }
            Bitmap img = new Bitmap(sourceFile);
            int x = img.Size.Width;
            int y = img.Size.Height;
            {
                int x1 = w;
                int y1 = y * x1 / x;
                Bitmap newbmp = new Bitmap(x1, y1);//新建一个放大后大小的图片
                double times = ((double)x1) / x;
                if (times >= 1)
                    newbmp = img;
                else
                {
                    Graphics g = Graphics.FromImage(newbmp);
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.DrawImage(img, new Rectangle(0, 0, x1, y1), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                    g.Dispose();
                }
                newbmp.Save(destFile,System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            GC.Collect();
        }

    }
}
