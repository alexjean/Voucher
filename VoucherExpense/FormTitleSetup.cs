using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
#if UseSQLServer
using MyDataSet  = VoucherExpense.DamaiDataSet;
using MyAccTitleAdapter = VoucherExpense.DamaiDataSetTableAdapters.AccountingTitleTableAdapter;
#else
using MyDataSet = VoucherExpense.VEDataSet;
using MyAccTitleAdapter = VoucherExpense.VEDataSetTableAdapters.AccountingTitleTableAdapter;
#endif

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
        MyDataSet m_DataSet = new MyDataSet();
        MyAccTitleAdapter AccTitleAdapter = new MyAccTitleAdapter();
        private void FormTitleSetup_Load(object sender, EventArgs e)
        {
            SetupBindingSource();
#if (!UseSQLServer)
            AccTitleAdapter.Connection = MapPath.VEConnection;
#endif
            AccTitleAdapter.Fill(m_DataSet.AccountingTitle);
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

        void SetupBindingSource()
        {
            assetBindingSource.DataSource = m_DataSet;
            asset1BindingSource.DataSource = m_DataSet;
            asset2BindingSource.DataSource = m_DataSet;
            asset3BindingSource.DataSource = m_DataSet;
            incomeBindingSource.DataSource = m_DataSet;
            income1BindingSource.DataSource = m_DataSet;
            income2BindingSource.DataSource = m_DataSet;
            income3BindingSource.DataSource = m_DataSet;
            liabilityTitleBindingSource.DataSource = m_DataSet;
            liability2BindingSource.DataSource = m_DataSet;
            ownersEquityBindingSource.DataSource = m_DataSet;
            costBindingSource.DataSource = m_DataSet;
            expenseBindingSource.DataSource = m_DataSet;

        }
    }
}
