using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataCollection
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        WheatEntities db = new WheatEntities();
        IQueryable<tbStore> stores;

        private void FormStart_Load(object sender, EventArgs e)
        {
            stores = db.CreateObjectSet<tbStore>().AsQueryable();
            if (DateTime.Now.Hour > 15 && DateTime.Now.Hour < 24)
            {

                foreach (var item in stores)
                {
                    op.ReadAndWriteOrder(item);
                }
            }
            this.Close();
        }
        OP op = new OP();
        private void button1_Click(object sender, EventArgs e)
        {

            foreach (var item in stores)
            {
                op.ReadAndWriteProduct(item);
            }
            //insert into tbProduct
            //select *,1 from [Damai2014].[dbo].[Product] where Product.Code>0
        }

        private void button2_Click(object sender, EventArgs e)
        {

            foreach (var item in stores)
            {
                op.ReadAndWritePhotos(item);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            foreach (var item in stores)
            {
                op.ReadAndWriteOrder(item);
            }
        }
    }
}
