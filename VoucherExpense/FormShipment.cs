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
    public partial class FormShipment : Form
    {
        public FormShipment()
        {
            InitializeComponent();
        }
        bool ischecked = false;
        private void shipmentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (MyFunction.LockAll)
            {
                MessageBox.Show("鎖定中,不能存檔");
                return;
            }
            if (!this.Validate())
            {
                MessageBox.Show("有資料錯誤, 請改好再存!");
                return;
            }
            this.shipmentBindingSource.EndEdit();
            this.shipmentDetailBindingSource.EndEdit();

            SQLVEDataSet.ShipmentDataTable table = (SQLVEDataSet.ShipmentDataTable)sQLVEDataSet.Shipment.GetChanges();
            SQLVEDataSet.ShipmentDetailDataTable detail = (SQLVEDataSet.ShipmentDetailDataTable)sQLVEDataSet.ShipmentDetail.GetChanges();
            if (table == null && detail == null)
            {
                MessageBox.Show("沒有改動任何資料! 不用存");
                return;
            }
            if (table != null)
            {
                foreach (SQLVEDataSet.ShipmentRow r in table)
                    if (r.RowState != DataRowState.Deleted)
                    {
                        //if (r.IsStockTimeNull())
                        //{r.time
                        //    MessageBox.Show("進貨單<" + r.ID.ToString() + ">沒有日期,不顯示在某單月,只顯示在全年度!");
                        //}
                        r.BeginEdit();
                        if (!ischecked)
                        {
                            r.KeyinID = MyFunction.OperatorID;
                            r.CheckedID=-1;
                        }
                        else
                        {
                            r.CheckedID = MyFunction.OperatorID;
                        }
                        r.LastUpdated = DateTime.Now;
                        r.EndEdit();
                    }
                try
                {
                    sQLVEDataSet.Shipment.Merge(table);
                    this.shipmentTableAdapter.Update(this.sQLVEDataSet.Shipment);
                    sQLVEDataSet.Shipment.AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("存Shipment時,ex:" + ex.Message);
                }
            }
            //if (checkMode)  // 查核模式會更新會計科目
            //{
            //    MyFunction.SetGlobalFlag(GlobalFlag.basicDataModified);
            //    //                return;
            //}
            if (detail != null)
            {
                try
                {
                    sQLVEDataSet.ShipmentDetail.Merge(detail);
                    shipmentDetailTableAdapter.Update(sQLVEDataSet.ShipmentDetail);
                    sQLVEDataSet.ShipmentDetail.AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("存ShipmentDetail時,ex:" + ex.Message);
                }
            }


        }

        private void FormShipment_Load(object sender, EventArgs e)
        {
            try
            {

            // TODO: 这行代码将数据加载到表“vEDataSet.Operator”中。您可以根据需要移动或删除它。
            this.operatorTableAdapter.Fill(this.vEDataSet.Operator);
        
            // TODO: 这行代码将数据加载到表“bakeryOrderSet.Product”中。您可以根据需要移动或删除它。
            this.productTableAdapter.Fill(this.bakeryOrderSet.Product);
            // TODO: 这行代码将数据加载到表“bakeryOrderSet.Product”中。您可以根据需要移动或删除它。
            this.productTableAdapter.Fill(this.bakeryOrderSet.Product);
            // TODO: 这行代码将数据加载到表“sQLVEDataSet.ShipmentDetail”中。您可以根据需要移动或删除它。
            this.shipmentDetailTableAdapter.Fill(this.sQLVEDataSet.ShipmentDetail);
            // TODO: 这行代码将数据加载到表“sQLVEDataSet.Shipment”中。您可以根据需要移动或删除它。
            this.shipmentTableAdapter.Fill(this.sQLVEDataSet.Shipment);
            this.supplierTableAdapter.Fill(this.sQLVEDataSet.Supplier);
            var operatorrow=vEDataSet.Operator.Select("OperatorID='" + MyFunction.OperatorID + "'");
            if ((bool)operatorrow[0]["LockShipment"])
                checkedCheckBox.Enabled = true;//当前用户具有审核权限时，设审核可操作
            if ((bool)operatorrow[0]["EditShipment"])//用户具有编辑权限是，才可编辑
            {
                supplierComboBox.Enabled = true;
                dateTimePicker1.Enabled = true;
                shipCodeTextBox.Enabled = true;
                costTextBox.Enabled = true;
                shipTimeTextBox.Enabled = true;
                removedCheckBox.Enabled = true;
            }
            }
            catch (Exception ex)
            {

                MessageBox.Show("出货界面加载时出现异常" + ex.ToString());
            }
        }

        private void shipmentDetailDataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridViewRow row = e.Row;
            DataGridViewCell cellID = row.Cells["detailColumnID"];
            cellID.Value = Guid.NewGuid();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (MyFunction.LockAll)
            {
                MessageBox.Show("鎖定中,新增無用");
            }
            int month = comboBoxMonth.SelectedIndex;
            if (month < 1 || month > 12)
            {
                month = DateTime.Now.Month;
                MessageBox.Show("你未選擇月份, 電腦設定新增為<" + month.ToString() + "月>單子!");
            }

            //            int count=this.voucherBindingNavigator.PositionItem.
            int ma = MyFunction.MaxNoInDB("ID", sQLVEDataSet.Shipment);
            int i = MyFunction.SetCellMaxNo("ColumnID", shipmentDataGridView, ma);
            if (i > 0)
            {
                this.iDLabel1.Text = i.ToString();
                //removedCheckBox.Checked = false;                           // 只有對DateTime的Binding會受影響, bool不會,所以可以放ResetBindings前  
                //checkedCheckBox.Checked = false;
                this.shipmentBindingSource.ResetBindings(false);           // 這行加了會把stockTimeTextBox.Text和entryTimeTextBox.Text給清成空白,所以放前面
                this.shipmentDetailBindingSource.ResetBindings(false);   // 有id了,可以刷新下面的detail表
                removedCheckBox.Checked = false;                         
                checkedCheckBox.Checked = false;
                // 初始時間, 放在ResetBindings後面
                int year = MyFunction.IntHeaderYear;
                DateTime t = DateTime.Now;
                entryTimeLabel1.Text = t.ToString() ;
                disableDateTimePicker = true;
                this.dateTimePicker1.Value = new DateTime(year, month, 1);     // 代入的是資料庫的年份,選的月份
                disableDateTimePicker = false;
                // 有選月份時,先強設日期,否則在當月看不到
                DateTime stockTime = new DateTime(year, month, MyFunction.DayCountOfMonth(month));   // 資料月份,設成該月最後一天
                //stockTimeTextBox.Text = stockTime.ToShortDateString();
                MessageBox.Show("請設成正確出货日期!"); 
            }
        }
        private bool disableDateTimePicker = false;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (disableDateTimePicker) return;
            DateTimePicker picker = sender as DateTimePicker;
            this.shipTimeTextBox.Text = picker.Text;
        }

        private void shipmentDetailDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            string cellName = view.Columns[e.ColumnIndex].Name;
            if (cellName == "dgvCostColumn")
            {
                this.costTextBox.Text = CostTotal().ToString();
            }
        }
        private decimal CostTotal()
        {
            DataGridView view = this.shipmentDetailDataGridView;
            int columnIndex = view.Columns["dgvCostColumn"].Index;
            decimal cost = 0;
            foreach (DataGridViewRow row in view.Rows)
                cost += ToDecimal((string)row.Cells[columnIndex].FormattedValue);
            return cost;
        }
        private decimal ToDecimal(string str)
        {
            try
            {
                return Convert.ToDecimal(str);
            }
            catch
            {
                return 0;
            }
        }

        private void removedCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ischecked = checkedCheckBox.Checked;
        }

        private void shipmentDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            DataGridViewRow row = view.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells["Removed"];
            if (cell.ValueType != typeof(bool)) return;    // 不應該
            bool removed = false;
            if (cell.Value != null && cell.Value != DBNull.Value)
                removed = (bool)cell.Value;
            Color color;
            if (removed)
                color = Color.DarkCyan;
            else if ((e.RowIndex % 2) != 0)
                color = Color.Azure;
            else
                color = Color.White;
            row.DefaultCellStyle.BackColor = color;
        }

        private void shipmentDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            DataGridViewRow row = view.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells["Removed"];
            DataGridViewCell cell1 = row.Cells["Checked"];
            if (cell.ValueType != typeof(bool)) return;    // 不應該
            if (cell1.ValueType != typeof(bool)) return;    // 不應該
            bool removed = false;
            bool ischecked = false;
            if (cell.Value != null && cell.Value != DBNull.Value)
                removed = (bool)cell.Value;
            if (cell1.Value != null && cell1.Value != DBNull.Value)
                ischecked = (bool)cell1.Value;
           // if (removed)//废除单
                //
           // if(ischecked)//已核
            Color color;
            if (removed)
                color = Color.DarkCyan;
            else if ((e.RowIndex % 2) != 0)
                color = Color.Azure;
            else
                color = Color.White;
            row.DefaultCellStyle.BackColor = color;
        }

        private void 列印PToolStripButton_Click(object sender, EventArgs e)
        {
            this.panel1.BackColor = Color.FromArgb(200, Color.White);//
            this.panel1.Visible = true;
            this.listBox1.Items.Add(this.supplierComboBox.Text + "(" + this.supplierComboBox.SelectedValue + ")" + "&时间:" + "(" + this.entryTimeLabel1.Text + ")" + "(" + entryTimeLabel1.Text + ")");
        }

        private void btremove_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Remove(this.listBox1.SelectedItem);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {

            this.listBox1.Items.Add(this.comboBox3.Text + "(" + this.comboBox3.SelectedValue + ")" + "&时间:" + "(" + this.dateTimePicker2.Text + ")" + "(" + dateTimePicker3.Text + ")");
        }

        private void btclosepanel_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            this.panel1.Visible = false;
        }
        string[] str=null;
        DataTable printdt =null;

            
         
        private void btprint_Click(object sender, EventArgs e)
        {
            printdt = new DataTable("printdt");
            printdt.Columns.Add("内容", Type.GetType("System.String"));
            printdt.Columns.Add("居左", Type.GetType("System.Int32"));
            printdt.Columns.Add("居上", Type.GetType("System.Int32"));
            if (this.listBox1.Items.Count == 0)
            {
                return;
            }
            int x=0;
            int y=0;//距离顶端距离
            for (int i = 0; i < this.listBox1.Items.Count;i++ )
            {
            string s = this.listBox1.Items[i].ToString();
            str = s.Split(new char[] { '(', ')' });
                //查询数据

            var selectShiptmentrow = sQLVEDataSet.Shipment.Select("Supplier='" + str[1] + "'and entrytime>=#" + Convert.ToDateTime(str[3]) + "#and entrytime<=#" + Convert.ToDateTime(str[5])+"#" );
            foreach (var item in selectShiptmentrow)
            {  
                y=y+30;
                printdt.Rows.Add(new object[] { "客户：" + str[0] + "   凭证号：" + item["ShipCode"] + "    出货时间：" + ((DateTime)item["shipTime"]).ToShortDateString() + "    总金额" + item[3], 20, y });//
                y=y+20;
                printdt.Rows.Add(new object[]{"名称",35,y});
                printdt.Rows.Add(new object[] { "数量", 155, y });
                printdt.Rows.Add(new object[] { "金额", 275, y });
                var selectShipmentdetailrow = sQLVEDataSet.ShipmentDetail.Select("shipmentid='" + item["id"].ToString() + "'");
                foreach (var item1 in selectShipmentdetailrow)
                {
                    var productrow=bakeryOrderSet.Product.Select("ProductID='"+item1["ProductID"].ToString()+"'");
                    if (productrow==null)
                        break;
                    y=y+20;
                    printdt.Rows.Add(new object[] {  productrow[0]["Name"] , 35, y });
                    printdt.Rows.Add(new object[] { item1["Volume"], 155, y });
                    printdt.Rows.Add(new object[] { item1["Cost"], 275, y });
                }
            }
                
            }
            pD.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (printdt == null)
                return;
            Font font = new Font("新宋体", 15, GraphicsUnit.Pixel);
            Brush brush = new SolidBrush(Color.Black);
            for (int i = 0; i < printdt.Rows.Count; i++)
            {
                e.Graphics.DrawString(printdt.Rows[i][0].ToString(), font, brush, (int)printdt.Rows[i][1], (int)printdt.Rows[i][2]);
            }
     
        }


    }
}
