using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace VoucherExpense
{
    public partial class ShowStructures : Form
    {
        public ShowStructures()
        {
            InitializeComponent();
        }

        
        private void ShowStructures_Load(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(Properties.Settings.Default.VoucherExpenseConnectionString);
            DataTable SchemaTable;
            try
            {
                con.Open();
                SchemaTable=con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
//                foreach (DataColumn c in SchemaTable.Columns)
//                    listBoxTables.Items.Add(c.ColumnName);
                foreach (DataRow r in SchemaTable.Rows)
                    listBoxTables.Items.Add(r[2].ToString());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void listBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox box = (ListBox)sender;
            string name;
            try {  name = box.SelectedItem.ToString(); }
            catch { return; }
            OleDbConnection con = new OleDbConnection(Properties.Settings.Default.VoucherExpenseConnectionString);
            DataTable ColumnTable;
            listBoxColumns.Items.Clear();
            try
            {
                con.Open();
                ColumnTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, name });
//                foreach (DataColumn c in ColumnTable.Columns)
//                    listBoxColumns.Items.Add(c.ColumnName);
                foreach (DataRow r in ColumnTable.Rows)
                    listBoxColumns.Items.Add(r["COLUMN_NAME"].ToString() + " " + r["DATA_TYPE"].ToString());

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}