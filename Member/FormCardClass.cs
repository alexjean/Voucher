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
    public partial class FormCardClass : Form
    {
        public FormCardClass()
        {
            InitializeComponent();
        }
        WheatEntities db = new WheatEntities();
        private void FormCardClass_Load(object sender, EventArgs e)
        {
            this.tbCardClassBindingSource.DataSource = db.CreateObjectSet<tbCardClass>().AsQueryable();
        }

        private void tbCardClassBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }     
        }
    }
}
