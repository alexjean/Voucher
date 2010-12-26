using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace VoucherExpense
{
    public partial class FormTitleSetup : Form
    {
        TitleSetup Setup=new TitleSetup();
//        Config  Cfg  =new Config();
        
        public FormTitleSetup()
        {
            InitializeComponent();
        }

        private void FormTitleSetup_Load(object sender, EventArgs e)
        {
            accountingTitleTableAdapter.Connection = MapPath.VEConnection;
            accountingTitleTableAdapter.Fill(this.vEDataSet.AccountingTitle);
            Setup.Load();
            titleSetupBindingSource.DataSource = Setup;
        }
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Setup.Save())
                MessageBox.Show("存檔成功!");
            else
                MessageBox.Show("存檔失敗!");
        }
    }
}
