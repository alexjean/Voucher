using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VoucherExpense
{
    public partial class FormShift : Form
    {
        public FormShift()
        {
            InitializeComponent();
        }

        const string strDay = "Day";
        private void FormShift_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 31; i++)
            {
                string str = i.ToString("d02");
                DataGridViewCheckBoxCell cbCell = new DataGridViewCheckBoxCell();
                cbCell.Value = false;
                DataGridViewColumn col = new DataGridViewColumn(cbCell);
                col.Name = strDay + str;
                col.HeaderText = str;
                col.Width = 24;
                col.Visible = true;

                try
                {
                    dgvShift.Columns.Add(col);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "產生dgvShift.Column錯誤");
                    break;
                }
            }
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;
            int i = box.SelectedIndex;
            if (i > 0 && i <= 12)
            {
                int count = MyFunction.DayCountOfMonth(i);
                foreach (DataGridViewColumn co in dgvShift.Columns)
                {
                    string name = co.Name;
                    if (name.Substring(0, 3).Equals(strDay))
                    {
                        int d = 0;
                        try
                        {
                            d = Convert.ToInt32(name.Substring(3, 2));
                            if (d <= count)
                                co.Visible = true;
                            else co.Visible = false;
                        }
                        catch { }
                    }
                }
            }
        }

        private void dgvShift_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Type type = dgvShift.Columns[e.ColumnIndex].CellType;
            if (type == typeof(DataGridViewCheckBoxCell)) return;
            MessageBox.Show(e.Exception.Message,"DataError!");
        }

        private void FormShift_SizeChanged(object sender, EventArgs e)
        {
            dgvShift.Height = Height - this.comboBoxMonth.Height + this.Top -40;
        }
    }
}
