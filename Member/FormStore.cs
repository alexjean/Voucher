using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Member
{
    public partial class FormStore : Form
    {
        WheatEntities db = new WheatEntities();
        public FormStore()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          this.tbStoreBindingSource.DataSource = db.CreateObjectSet<tbStore>().AsQueryable();
        }

        private void tbStoreBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }
    }
}
