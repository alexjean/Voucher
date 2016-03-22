using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using MyDataSet  = VoucherExpense.DamaiDataSet;
using MyAccTitleAdapter = VoucherExpense.DamaiDataSetTableAdapters.AccountingTitleTableAdapter;

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
            // TODO: 這行程式碼會將資料載入 'damaiDataSet.AccountingTitle' 資料表。您可以視需要進行移動或移除。
            this.accountingTitleTableAdapter.Fill(this.damaiDataSet.AccountingTitle);
            SetupBindingSource();

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
            assetDefaultBindingSource.DataSource    = m_DataSet;
            assetCashBindingSource.DataSource       = m_DataSet;
            assetCardBindingSource.DataSource       = m_DataSet;
            assetReceivableBindingSource.DataSource = m_DataSet;
            assetIngredientsBindingSource.DataSource= m_DataSet;
            assetProductsBindingSource.DataSource   = m_DataSet;
            incomeDefaultBindingSource.DataSource   = m_DataSet;
            incomeCardBindingSource.DataSource      = m_DataSet;
            incomeCashBindingSource.DataSource      = m_DataSet;
            incomeSoldOnCreditBindingSource.DataSource      = m_DataSet;
            liabilityShouldPayTitleBindingSource.DataSource = m_DataSet;
            liabilityDefaultBindingSource.DataSource= m_DataSet;
            ownersEquityBindingSource.DataSource    = m_DataSet;
            costBindingSource.DataSource            = m_DataSet;
            expenseBindingSource.DataSource         = m_DataSet;
        }
    }
}
