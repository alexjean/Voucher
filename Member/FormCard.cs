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
    public partial class FormCard : Form
    {
        public FormCard()
        {
            InitializeComponent();
        }
        WheatEntities db = new WheatEntities();
        private void FormCard_Load(object sender, EventArgs e)
        {
            tbCardBindingSource.DataSource = db.CreateObjectSet<tbCard>().AsQueryable();
            tbCardClassBindingSource.DataSource = db.CreateObjectSet<tbCardClass>().AsQueryable();
        }

        private void tbCardBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }
    }
}
