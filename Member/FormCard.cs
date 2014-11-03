using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
           OpenFileDialog openFileDialog=new OpenFileDialog ();
           
           if (openFileDialog.ShowDialog()==DialogResult.OK)
           {var maxid=db.tbCard.Max(s => s.CardId);
               DataSet ds=LoadData(openFileDialog.FileName, "sheet1");
               if (ds!=null)
               {
                   var table=ds.Tables[0];
                   for (int i = 0; i < table.Rows.Count; i++)
                   {
                       if (Convert.ToInt32(table.Rows[i][0])>maxid)
                       {
                           tbCard card = new tbCard();
                           card.CardId = Convert.ToInt32(table.Rows[i][0]);
                           card.CardNumber = table.Rows[i][1].ToString();
                           card.CardStatus = Convert.ToInt32(table.Rows[i][2]);
                           card.CardCDKEY = table.Rows[i][3].ToString();
                           card.CardClassId = Convert.ToInt32(table.Rows[i][4]);
                           db.CreateObjectSet<tbCard>().AddObject(card);      
                       } 
                   } 
               }
           } db.SaveChanges(); this.FormCard_Load(sender, e);
        }
        public DataSet LoadData(string filePath, string sheet)
        {
            try
            {
                string strConn;
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'"; 
                OleDbConnection OleConn = new OleDbConnection(strConn);
                OleConn.Open();
                String sql = "SELECT * FROM  [" + sheet + "$]";

                OleDbDataAdapter DaExcel = new OleDbDataAdapter(sql, OleConn);
                DataSet DsExcle = new DataSet();
                DaExcel.Fill(DsExcle, sheet);
                OleConn.Close();
                return DsExcle;
            }
            catch (Exception err)
            {
                MessageBox.Show("讀入Excel失敗!原因：" + err.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }
    }
}
