 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;
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

            //SQLVEDataSet.ShipmentDataTable table = (SQLVEDataSet.ShipmentDataTable)sQLVEDataSet.Shipment.GetChanges();
            //SQLVEDataSet.ShipmentDetailDataTable detail = (SQLVEDataSet.ShipmentDetailDataTable)sQLVEDataSet.ShipmentDetail.GetChanges();

            DamaiDataSet.ShipmentDataTable table = (DamaiDataSet.ShipmentDataTable)damaiDataSet.Shipment.GetChanges();
            DamaiDataSet.ShipmentDetailDataTable detail = (DamaiDataSet.ShipmentDetailDataTable)damaiDataSet.ShipmentDetail.GetChanges();
            if (table == null && detail == null)
            {
                MessageBox.Show("沒有改動任何資料! 不用存");
                return;
            }
            if (table != null)
            {
                //foreach (SQLVEDataSet.ShipmentRow r in table)
                foreach (DamaiDataSet.ShipmentRow r in table)
                    if (r.RowState != DataRowState.Deleted)
                    {

                        r.BeginEdit();
                        if (!ischecked)
                        {
                            r.KeyinID = MyFunction.OperatorID;
                            r.CheckedID = -1;
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
                    //sQLVEDataSet.Shipment.Merge(table);
                    //this.shipmentTableAdapter.Update(this.sQLVEDataSet.Shipment);
                    //sQLVEDataSet.Shipment.AcceptChanges();
                    damaiDataSet.Shipment.Merge(table);
                    this.shipmentTableAdapter1.Update(this.damaiDataSet.Shipment);
                    damaiDataSet.Shipment.AcceptChanges();
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
                    //sQLVEDataSet.ShipmentDetail.Merge(detail);
                    //shipmentDetailTableAdapter.Update(sQLVEDataSet.ShipmentDetail);
                    //sQLVEDataSet.ShipmentDetail.AcceptChanges();
                    damaiDataSet.ShipmentDetail.Merge(detail);
                    shipmentDetailTableAdapter1.Update(damaiDataSet.ShipmentDetail);
                    damaiDataSet.ShipmentDetail.AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("存ShipmentDetail時,ex:" + ex.Message);
                }
            }

        }
        bool m_edit = false;
        bool m_check = false;
        private void FormShipment_Load(object sender, EventArgs e)
        {
         try
            {         // TODO: 这行代码将数据加载到表“damaiDataSet.ProductClass”中。您可以根据需要移动或删除它。
            this.productClassTableAdapter.Fill(this.damaiDataSet.ProductClass);
            // TODO: 这行代码将数据加载到表“damaiDataSet.ShipmentDetail”中。您可以根据需要移动或删除它。
            this.shipmentDetailTableAdapter1.Fill(this.damaiDataSet.ShipmentDetail);
            // TODO: 这行代码将数据加载到表“damaiDataSet.Product”中。您可以根据需要移动或删除它。
            this.productTableAdapter1.Fill(this.damaiDataSet.Product);
            // TODO: 这行代码将数据加载到表“damaiDataSet.Customer”中。您可以根据需要移动或删除它。
            this.customerTableAdapter1.Fill(this.damaiDataSet.Customer);
            // TODO: 这行代码将数据加载到表“damaiDataSet.AccountingTitle”中。您可以根据需要移动或删除它。
            this.accountingTitleTableAdapter1.Fill(this.damaiDataSet.AccountingTitle);
            // TODO: 这行代码将数据加载到表“damaiDataSet.Operator”中。您可以根据需要移动或删除它。
            this.operatorTableAdapter1.Fill(this.damaiDataSet.Operator);
            // TODO: 这行代码将数据加载到表“damaiDataSet.Shipment”中。您可以根据需要移动或删除它。
            this.shipmentTableAdapter1.Fill(this.damaiDataSet.Shipment);
      
                this.apartmentTableAdapter.Fill(this.damaiDataSet.Apartment);
                // TODO: 这行代码将数据加载到表“vEDataSet.AccountingTitle”中。您可以根据需要移动或删除它。
             //   this.accountingTitleTableAdapter.Fill(this.vEDataSet.AccountingTitle);
                // TODO: 这行代码将数据加载到表“vEDataSet.Operator”中。您可以根据需要移动或删除它。
             //   this.operatorTableAdapter.Fill(this.vEDataSet.Operator);
                // TODO: 这行代码将数据加载到表“bakeryOrderSet.Product”中。您可以根据需要移动或删除它。
               // this.productTableAdapter.Fill(this.bakeryOrderSet.Product);
                // TODO: 这行代码将数据加载到表“sQLVEDataSet.ShipmentDetail”中。您可以根据需要移动或删除它。
            //    this.shipmentDetailTableAdapter.Fill(this.sQLVEDataSet.ShipmentDetail);
                // TODO: 这行代码将数据加载到表“sQLVEDataSet.Shipment”中。您可以根据需要移动或删除它。
             //   this.shipmentTableAdapter.Fill(this.sQLVEDataSet.Shipment);
               // this.customerTableAdapter.Fill(this.sQLVEDataSet.Customer);
                // var operatorrow=vEDataSet.Operator.Select("OperatorID='" + MyFunction.OperatorID + "'");
              //  var opertatorrow = from row in vEDataSet.Operator where row.OperatorID == MyFunction.OperatorID select row;
                var opertatorrow = from row in damaiDataSet.Operator where row.OperatorID == MyFunction.OperatorID select row;
                var ro = opertatorrow.First();
                if (ro.IsEditShipmentNull())
                {
                    m_edit = false;
                }
                else
                {
                    m_edit = ro.EditShipment;
                }
                if (ro.IsLockShipmentNull())
                {
                    m_check = false;
                }
                else
                {
                    m_check = ro.LockShipment;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("出货界面加载时出现异常" + ex.ToString());
            }
            if (MyFunction.IntHeaderYear != DateTime.Now.Year)
                comboBoxMonth.SelectedIndex = comboBoxMonth.Items.Count - 1;
            else
                comboBoxMonth.SelectedIndex = DateTime.Now.Month;
            setVisible(m_check);

        }
        void setVisible(bool bo)
        {
            shipmentDataGridView.Columns["Checked"].Visible = bo;
            checkedLabel.Visible = bo;
            checkedCheckBox.Visible = bo;
            comboBox2.Visible = bo;
            comboBox1.Visible = bo;
            keyinIDLabel.Visible = bo;
            checkedIDLabel.Visible = bo;
        }
        private void shipmentDetailDataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridViewRow row = e.Row;
            DataGridViewCell cellID = row.Cells["detailColumnID"];
            cellID.Value = Guid.NewGuid();
        }
        int m_Month = 0;
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
            m_Month = month;
            panel1.Visible = true;
        }

        private bool addNew(int month, int productClass)
        { 

            int ma = MyFunction.MaxNoInDB("ID", damaiDataSet.Shipment);
            int i = MyFunction.SetCellMaxNo("ColumnID", shipmentDataGridView, ma);
            if (i > 0)
            {
                this.iDLabel1.Text = i.ToString();
                
                //removedCheckBox.Checked = false;                           // 只有對DateTime的Binding會受影響, bool不會,所以可以放ResetBindings前  
                //checkedCheckBox.Checked = false;
                       // 這行加了會把stockTimeTextBox.Text和entryTimeTextBox.Text給清成空白,所以放前面
                if (CreateNewShipmentDetailDataTable(i, productClass).Count == 0)
                {
                    return false;
                }
                foreach (var item in CreateNewShipmentDetailDataTable(i,productClass))
                {
                    DamaiDataSet.ShipmentDetailRow r;
                    r = item;
                    this.damaiDataSet.ShipmentDetail.ImportRow(r);
                }
                this.shipmentBindingSource.ResetBindings(false);    
                this.shipmentDetailBindingSource.ResetBindings(false);   // 有id了,可以刷新下面的detail表
                removedCheckBox.Checked = false;
                checkedCheckBox.Checked = false;
                this.shipCodeTextBox.Text = GetShipCode(month);
                // 初始時間, 放在ResetBindings後面
                int year = MyFunction.IntHeaderYear;
                DateTime t = DateTime.Now;
                disableDateTimePicker = true;
                this.dateTimePicker1.Value = new DateTime(year, month, 1);     // 代入的是資料庫的年份,選的月份
                disableDateTimePicker = false;
                // 有選月份時,先強設日期,否則在當月看不到
                DateTime stockTime = new DateTime(year, month, MyFunction.DayCountOfMonth(month));   // 資料月份,設成該月最後一天
                shipTimeTextBox.Text = stockTime.ToShortDateString();
                return true;
            }
            return false;
        }
        /// <summary>
        /// 凭证号
        /// </summary>
        /// <param name="month">指定月份</param>

        string GetShipCode(int month)
        {
            string currentYear = MyFunction.IntHeaderYear.ToString().Substring(2, 2);
            string currentMaxYear = MyFunction.IntHeaderYear.ToString().Substring(2, 2);
            if (month.ToString().Length > 1)
            {
                currentYear += month.ToString() + "001";
                currentMaxYear += month.ToString() + "999";
            }
            else
            {
                currentYear += "0" + month.ToString() + "001";
                currentMaxYear += "0" + month.ToString() + "999";
            }
           // this.shipmentTableAdapter.Fill(this.sQLVEDataSet.Shipment);
            //var shipment = this.sQLVEDataSet.Shipment.Select("shipcode>" + currentYear);//指定月份的最大所以先筛选指定月份的数据
            //var dt = shipment.CopyToDataTable();
            //var sdt = dt as SQLVEDataSet.ShipmentDataTable;
            //var shipmentrows = from r in this.sQLVEDataSet.Shipment where (r.ShipCode >= Convert.ToInt32(currentYear) || r.ShipCode < Convert.ToInt32(currentMaxYear)) orderby r.ShipCode descending select r;
            var shipmentrows = from r in this.damaiDataSet.Shipment where (!r.IsShipCodeNull()&&r.ShipCode >= Convert.ToInt32(currentYear) && r.ShipCode < Convert.ToInt32(currentMaxYear)) orderby r.ShipCode descending select r;
            if (shipmentrows.ToArray().Length>0)
            {
                //var shipmentrow = shipmentrows.First<SQLVEDataSet.ShipmentRow>();
                var shipmentrow = shipmentrows.First<DamaiDataSet.ShipmentRow>();
                if (shipmentrow == null)
                {
                    return currentYear;
                }
                else
                {
                    return (shipmentrow.ShipCode+1).ToString();
                }
            }
            else
            {
                return currentYear;
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
            else if (cellName == "dgvColumnProductID")
            {
                DataGridViewRow dgRow = view.Rows[e.RowIndex];
                DataGridViewCell cell = dgRow.Cells[e.ColumnIndex];
                if (cell.ValueType != typeof(int)) return;  // IngridentCode是int
                if (cell.Value == null || cell.Value == DBNull.Value) return;
                int productID = (int)cell.Value;
                try
                {
                    //string str="ID="+code.ToString();
                    //VEDataSet.IngredientRow[] row = (VEDataSet.IngredientRow[])vEDataSet.Ingredient.Select(str);
                   // var rows = from row in bakeryOrderSet.Product where (row.ProductID == productID) select row;
                    var rows = from row in damaiDataSet.Product where (row.ProductID == productID) select row;
                    if (rows.Count() > 0)
                    {
                       // BakeryOrderSet.ProductRow row = rows.First();
                        DamaiDataSet.ProductRow row = rows.First();
                        if (!row.IsTitleCodeNull())
                            dgRow.Cells["dgvColumnTitleCode"].Value = row.TitleCode;
                    }
                }
                catch { }
            }
            else if (cellName == "dgvColumnVolume")
            {
                try
                {
                    DataGridViewRow dgRow = view.Rows[e.RowIndex];
                    DataGridViewCell costCell = dgRow.Cells["dgvCostColumn"];
                    if (costCell.ValueType != typeof(decimal)) return;  // Cost不是decimal,資料庫定義必然被改過了,程式碼失效
                    if (costCell.Value == null) return;
                    //if (costCell.Value != DBNull.Value) return;         // Cost有資料時就不改
                    DataRowView rowView = dgRow.DataBoundItem as DataRowView;
                    //SQLVEDataSet.ShipmentDetailRow shipmentDetailRow = rowView.Row as SQLVEDataSet.ShipmentDetailRow;
                    DamaiDataSet.ShipmentDetailRow shipmentDetailRow = rowView.Row as DamaiDataSet.ShipmentDetailRow;
                    // 查出食材表中相對應記錄
                    //var rows = from ro in bakeryOrderSet.Product
                    //           where (ro.ProductID == shipmentDetailRow.ProductID)
                    //           select ro;
                    var rows = from ro in damaiDataSet.Product
                               where (ro.ProductID == shipmentDetailRow.ProductID)
                               select ro;
                    if (rows.Count() <= 0) return;
                    //BakeryOrderSet.ProductRow row = rows.First();
                    DamaiDataSet.ProductRow row = rows.First();
                    if (row.IsPriceNull()) return;
                    if (row.Price <= 0) return;                      // 參考價不合理
                    costCell.Value = shipmentDetailRow.Volume * (decimal)row.Price;
                }
                catch { }
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
            //if (removedCheckBox.Checked)
            //{
            //    if (checkedCheckBox.Checked)
            //    {
            //        checkedCheckBox.Checked = false;
            //    }
            //    else
            //    {
            //        checkedCheckBox.Checked = true;
            //    }
            //}

        }

        private void shipmentDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            DataGridViewRow row = view.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells["Removed"];
            DataGridViewCell cell1 = row.Cells["Checked"];
            if (cell.ValueType != typeof(bool)) return;    // 不應該
            bool removed = false;
            if (cell.Value != null && cell.Value != DBNull.Value)
                removed = (bool)cell.Value;
            Color color;
            if (removed)
            { color = Color.DarkGoldenrod;
            cell1.ReadOnly = true;
            }
            else if ((e.RowIndex % 2) != 0)
                color = Color.Azure;
            else
                color = Color.White;
            row.DefaultCellStyle.BackColor = color;
        }

        private void shipmentDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            productClassComboBox.SelectedValue = 0;
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
            if (removed)
            {//废除单
                customerComboBox.Enabled = false;
                dateTimePicker1.Enabled = false;
                shipTimeTextBox.Enabled = false;
                shipCodeTextBox.Enabled = false;
                costTextBox.Enabled = false;
                shipmentDetailDataGridView.Enabled = false;
                checkedCheckBox.Enabled = false;
            }
            else
            {
                if (m_edit)
                {
                    customerComboBox.Enabled = true;
                    dateTimePicker1.Enabled = true;
                    shipTimeTextBox.Enabled = true;
                    shipCodeTextBox.Enabled = true;
                    costTextBox.Enabled = true;
                    shipmentDetailDataGridView.Enabled = true;
                    removedCheckBox.Enabled = true;
                }
                if (m_check)
                    checkedCheckBox.Enabled = true;
               

            }
            if (ischecked)//已核
            {
                customerComboBox.Enabled = false;
                dateTimePicker1.Enabled = false;
                shipTimeTextBox.Enabled = false;
                shipCodeTextBox.Enabled = false;
                costTextBox.Enabled = false;
                shipmentDetailDataGridView.Enabled = false;
                if (m_check)
                { checkedCheckBox.Enabled = true; }
                else
                {
                    checkedCheckBox.Enabled = false;
                }
                if (m_edit) { removedCheckBox.Enabled = true; }
                else
                {
                    removedCheckBox.Enabled = false;
                }
            }
            else
            {

                if (m_check)
                { checkedCheckBox.Enabled = true; }
                else
                {
                    checkedCheckBox.Enabled = false;
                }
                if (m_edit) { removedCheckBox.Enabled = true; }
                else
                {
                    customerComboBox.Enabled = true;
                    dateTimePicker1.Enabled = true;
                    shipTimeTextBox.Enabled = true;
                    shipCodeTextBox.Enabled = true;
                    costTextBox.Enabled = true;
                    shipmentDetailDataGridView.Enabled = true;
                    removedCheckBox.Enabled = false;
                }
            }   
            if (ischecked)
            {
                row.ReadOnly=true;
            }
            Color color;
            if (removed)
            {
                color = Color.DarkCyan;
                row.ReadOnly = true;
            }
            else
            {
                if ((e.RowIndex % 2) != 0)
                    color = Color.Azure;
                else
                    color = Color.White;
                row.DefaultCellStyle.BackColor = color;
            }         
        }

        private void shipmentDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex < 0)
            {
                MessageBox.Show("Shipment第" + e.RowIndex.ToString() + "行錯誤:" + e.Exception.Message);
                return;
            }
            DataGridViewCell cell = view.Rows[e.RowIndex].Cells[e.ColumnIndex];
            MessageBox.Show(string.Format("Shipment on Row{0} Col[{1}]:{2}", e.RowIndex, view.Columns[e.ColumnIndex].Name, e.Exception.Message));
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            int i = box.SelectedIndex;
            //            if (i == 0) return;
            string y = "#" + MyFunction.HeaderYear + "/";
            string m1, m2;
            if (i == 0)
                shipmentBindingSource.Filter = "";
            else
                if (i < 12)
                {
                    m1 = y + i.ToString("d2") + "/01#";
                    m2 = y + (i + 1).ToString("d2") + "/01#";
                    shipmentBindingSource.Filter = "(ShipTime>=" + m1 + ") AND (ShipTime<" + m2 + ")";
                }
                else if (i == 12)
                {
                    m1 = y + "12/01#";
                    m2 = y + "12/31#";
                    shipmentBindingSource.Filter = "(ShipTime>=" + m1 + ") AND (ShipTime<=" + m2 + ")";
                }
            this.shipmentDataGridView.Focus();
        }

        Shipmentprint smp = new Shipmentprint();
        private void tsbtPrint_Click(object sender, EventArgs e)
        {
            string apartmentName = "";
            if (this.damaiDataSet.Apartment.Rows.Count != 0)
            {
                var a0 = this.damaiDataSet.Apartment[0];
                foreach (var a in this.damaiDataSet.Apartment)
                {
                    if (!a.IsIsCurrentNull() && a.IsCurrent)
                    {
                        a0 = a;
                        break;
                    }
                }
                if (a0.IsApartmentNameNull())
                    apartmentName = a0.ApartmentAllName;
                else
                    apartmentName = a0.ApartmentAllName;
            }
            DataRowView rowview = shipmentBindingSource.Current as DataRowView;
            DamaiDataSet.ShipmentRow row = rowview.Row as DamaiDataSet.ShipmentRow;
            if (row.IsCustomerNull())
            {
                MessageBox.Show("客户不能为空！");
                return;
            }
            if (row.IsCostNull())
            {
                MessageBox.Show("总金额为空！");
                return;
            }
            var customerrows = from ro in damaiDataSet.Customer where (ro.CustomerID == row.Customer) select ro;
            var customerrow = customerrows.First();
            
            smp.ApartmentName = apartmentName;
            smp.ShipmentNumber = row.ShipCode.ToString();
            smp.ContactPeople = customerrow.ContactPeople;
            smp.CustomerName = customerrow.Name;
            smp.ShipAddress = customerrow.Address;
            smp.ContactPhone = customerrow.Telephone;
            smp.EntryTime = row.LastUpdated.ToString("yyyyMMdd");
            smp.ShipTime = row.ShipTime.ToString("yyyyMMdd");
            smp.CostAllCount = row.Cost;
            var shipmetdetailrows = row.GetShipmentDetailRows();
            if (shipmetdetailrows.Count() == 0)
                return;
            List<List<Shipmentdetailprint>> lists = new List<List<Shipmentdetailprint>>();
          //  int inttemp = shipmetdetailrows.Count() / 1000;
         //  for (int j = 0; j <= inttemp; j++)
           //{

                List<Shipmentdetailprint> listshipmentdetail = new List<Shipmentdetailprint>();
                //for (int i = j*999; i < shipmetdetailrows.Count(); i++)
                    for (int i =0; i < shipmetdetailrows.Count(); i++)
                {
                    //if (i < (j + 1) * 999)
                       // if (i < (j + 1) * 999)
                  // {
                        var temrow = shipmetdetailrows[i];
                        var productrow = from r in damaiDataSet.Product where (r.ProductID == temrow.ProductID) select r;
                        var productfirst = productrow.First();
                        Shipmentdetailprint smdp = new Shipmentdetailprint();
                       // smdp.PageNumCount = inttemp + 1;
                        //smdp.Num = i+1;
                        smdp.ProductName = productrow.First().Name;
                        smdp.ProductCode = productrow.First().Code;
                        if (productfirst.IsUnitNull())
                        {
                            smdp.Unit = "";
                        }
                        else
                        {
                            smdp.Unit = productrow.First().Unit;
                        }
                        if (productfirst.IsPriceNull())
                        {
                            MessageBox.Show("产品" + productfirst.Name + "所在行资料不全无法打印");
                            return;
                        }
                        else
                        {
                            smdp.Cost = productrow.First().Price;
                        }
                        smdp.Volum = temrow.Volume;
                        if (temrow.IsCostNull())
                        {
                            MessageBox.Show("产品" + productfirst.Name + "所在行资料不全无法打印");
                            return;
                        }
                        else
                        {
                            smdp.AllCost = temrow.Cost;

                        }
                        listshipmentdetail.Add(smdp);
                       
                   // } 
                     
               }   listshipmentdetail.Sort(compare);
                lists.Add(listshipmentdetail);
           // }
            smp.ShipmentDetileProduct = lists;
            printPageHeight = lists[0].Count * 14 + 110 + 552;

            try
            {
                Config = MyFunction.HardwareCfg;
                PrinterSettings ps = new PrinterSettings();
                ps.PrinterName = Config.DotPrinterName;
                var ss = ps.PaperSizes;
               
                System.Drawing.Printing.PageSettings df =  ps.DefaultPageSettings ;                     
                printDocument1.PrinterSettings = ps;
                printDocument1.Print();
            }
            catch
            { }
            //FormShipmentPrint form = new FormShipmentPrint(smp);
            //form.Show();
        } HardwareConfig Config;
        private void costTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void costTextBox_Validated(object sender, EventArgs e)
        {

        }
        private int compare(Shipmentdetailprint student1, Shipmentdetailprint student2)
        {
            return student1.ProductCode - student2.ProductCode;
        }
        private void shipmentDetailDataGridView_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex < 0)
            {
                MessageBox.Show("ShipmentDetail第" + e.RowIndex.ToString() + "行錯誤:" + e.Exception.Message);
                return;
            }
            //DataGridViewCell cell = view.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //MessageBox.Show(string.Format("ShipmentDetail on Row{0} Col[{1}]:{2}", e.RowIndex, view.Columns[e.ColumnIndex].Name, e.Exception.Message));
        }
        int m_ProductClass = 0;
        private void productClassComboBox_SelectedValueChanged(object sender, EventArgs e)
        {           
            if (productClassComboBox.SelectedValue == null||(int)productClassComboBox.SelectedValue <1)
            { return; }
        //var cr = this.shipmentBindingSource.Current as DataRowView;
        //if (cr==null)
        //{
        //    return;
        //}
        //    if (cr.Row.RowState==DataRowState.Detached)
        //    {

          //  SetProductFilter((int)productClassComboBox.SelectedValue);
           
        //    DamaiDataSet.ShipmentRow sr = cr.Row as DamaiDataSet.ShipmentRow;
        //    foreach (var item in CreateNewShipmentDetailDataTable(sr.ID))
        //    {
        //    this.damaiDataSet.ShipmentDetail.Rows.Add(item);
        //    }
        //    this.shipmentDetailBindingSource.ResetBindings(false);
        //    }
        if (productClassComboBox.SelectedText==null)
        {
            return;
        }
        m_ProductClass = (int)productClassComboBox.SelectedValue;
        }
        DamaiDataSet.ShipmentDetailDataTable CreateNewShipmentDetailDataTable(int id,int productClass)
        {
            DamaiDataSet.ShipmentDetailDataTable dt = new DamaiDataSet.ShipmentDetailDataTable();
            foreach (DataRowView item in productBindingSource)
            {

                DataRow dr = item.Row as DataRow;
                DamaiDataSet.ProductRow pr = dr as DamaiDataSet.ProductRow;
                if (pr.Class!=productClass)
                {
                    continue;
                }
                DamaiDataSet.ShipmentDetailRow r = dt.NewRow() as DamaiDataSet.ShipmentDetailRow;
                r.ProductID = pr.ProductID;
                r.ShipmentID = id;
                r.Volume = 0;
                r.ID = Guid.NewGuid();
                r.Cost = 0;
                dt.AddShipmentDetailRow(r);
            }
            return dt;
        }

        void SetProductFilter(int ProductClassID)
        {
            string Select = "code>0 ";
            if (ProductClassID >0)
                Select += "and class=" + ProductClassID.ToString();
            ModifyProductFilterForSafe(Select);
            this.shipmentDetailBindingSource.ResetBindings(false);
            shipmentDetailDataGridView.Refresh();
        }
        private void ModifyProductFilterForSafe(string Select)
        {   // 避免出現ComboBox沒有的
            //foreach (DataGridViewRow row in shipmentDetailDataGridView.Rows)
            //{
            //    DataGridViewCell cell = row.Cells["dgvColumnProductID"];
            //    if (cell == null) continue;
            //    if (cell.Value == null) continue;
            //    if (cell.Value == DBNull.Value) continue;
            //    Select += " OR ProductID=" + cell.Value.ToString();
            //}
            productBindingSource.Filter = Select;
        }

        private void checkedCheckBox_Click(object sender, EventArgs e)
        {
            if (removedCheckBox.Checked)
            {
                MessageBox.Show("废除的单子没必要审核！");
                if (checkedCheckBox.Checked)
                {
                    checkedCheckBox.Checked = false;
                }
                else
                {
                    checkedCheckBox.Checked = true;
                }
            }
        }

        int printPageHeight = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (smp==null)
            {
                return;
            }  
            Graphics g = e.Graphics;
            Font font = new Font("新宋体", 13);
            Font font1 = new Font("新宋体", 9);
            Brush brush = new SolidBrush(Color.Black);
            string aName=smp.ApartmentName;
            if (aName.Length < 15)
            {
                for (int temp = 0; temp < (15 - aName.Length) % 2; temp++)
                    {
                        aName = aName.Insert(0, " ");
                    }
            }
            g.DrawString(smp.ApartmentName+"出货单", new Font("新宋体", 15), brush, new Point(200, 30));
            g.DrawString("客户名称：", font, brush, new Point(30, 60)); g.DrawString(smp.CustomerName, font, brush, new Point(110, 60));
            g.DrawString("联系人：", font, brush, new Point(410, 60)); g.DrawString(smp.ContactPeople, font, brush, new Point(480, 60));
            g.DrawString("联系电话：", font, brush, new Point(600, 60)); g.DrawString(smp.ContactPhone, font, brush, new Point(685, 60));
            g.DrawString("送货地址：", font, brush, new Point(30, 80));      
            if (smp.ShipAddress.Length > 21)
            {
                g.DrawString(smp.ShipAddress.Substring(0, 20), font1, brush, new Point(110, 80));
                g.DrawString(smp.ShipAddress.Substring(21), font1, brush, new Point(110, 96));
            }
            else { g.DrawString(smp.ShipAddress, font1, brush, new Point(110, 80));}
            g.DrawString("出货日期：", font, brush, new Point(410, 80)); g.DrawString(smp.ShipTime, font, brush, new Point(495, 80));
            g.DrawString("凭证号：", font, brush, new Point(600, 80)); g.DrawString(smp.ShipmentNumber, font, brush, new Point(685, 80));
            g.DrawString("序号", font1, brush, new Point(35, 110));
           // g.DrawString("代码", font1, brush, new Point(75, 110));
            g.DrawString("名称", font1, brush, new Point(95, 110));
            g.DrawString("单位", font1, brush, new Point(180, 110));
            g.DrawString("数量", font1, brush, new Point(225, 110));
            g.DrawString("单价", font1, brush, new Point(275, 110));
            g.DrawString("金额", font1, brush, new Point(350, 110));
           // g.DrawString("其他", font1, brush, new Point(380, 110));
            g.DrawString("序号", font1, brush, new Point(370 + 35, 110));
           // g.DrawString("代码", font1, brush, new Point(370 + 75, 110));
            g.DrawString("名称", font1, brush, new Point(370 + 95, 110));
            g.DrawString("单位", font1, brush, new Point(370 + 180, 110));
            g.DrawString("数量", font1, brush, new Point(370 + 225, 110));
            g.DrawString("单价", font1, brush, new Point(370 + 275, 110));
            g.DrawString("金额", font1, brush, new Point(370 + 350, 110));
            int i = 0;
            foreach (var item in smp.ShipmentDetileProduct)
            {

                foreach (var item1 in item)
                {
                    if (i % 2 == 0)
                    {
                        g.DrawString((i + 1).ToString(), font1, brush, new Point(35, 130 + i * 8));
                       // g.DrawString(item1.ProductCode.ToString(), font1, brush, new Point(65, 130 + i * 8));
                        g.DrawString(item1.ProductName, font1, brush, new Point(65, 130 + i * 8));
                        g.DrawString(item1.Unit, font1, brush, new Point(185, 130 + i * 8));
                    }
                    else
                    {
                        g.DrawString((i + 1).ToString(), font1, brush, new Point(370 + 35, 130 + (i - 1) * 8));
                      //  g.DrawString(item1.ProductCode.ToString(), font1, brush, new Point(370 + 65, 130 + (i - 1) * 8));
                        g.DrawString(item1.ProductName, font1, brush, new Point(370 + 65, 130 + (i - 1) * 8));
                        g.DrawString(item1.Unit, font1, brush, new Point(370 + 185, 130 + (i - 1) * 8));
                    }
                    int l2 = item1.Volum.ToString().Length;
                    string strvolum = item1.Volum.ToString();
                    for (int ii = 0; ii < 5 - l2; ii++)
                    {
                        strvolum = strvolum.Insert(0, " ");
                    }
                    int l1 = item1.Cost.ToString().Length;
                    string strdanjia = item1.Cost.ToString("0.00");
                    for (int ii = 0; ii < 8 - l1; ii++)
                    {
                        strdanjia = strdanjia.Insert(0, " ");
                    }
                    if (i % 2 == 0)
                    {
                        g.DrawString(strvolum, font1, brush, new Point(210, 130 + i * 8));
                    }
                    else
                    {
                        g.DrawString(strvolum, font1, brush, new Point(370 + 210, 130 + (i - 1) * 8));
                    }
                    int l = item1.AllCost.ToString("0.00").Length;
                    string strjine = item1.AllCost.ToString("0.00");
                    for (int ii = 0; ii < 9 - l; ii++)
                    {
                        strjine = strjine.Insert(0, " ");
                    }
                    if (i % 2 == 0)
                    {
                        g.DrawString(strdanjia, font1, brush, new Point(235, 130 + i * 8));
                        g.DrawString(strjine, font1, brush, new Point(330, 130 + i * 8));
                    }
                    else
                    {
                        g.DrawString(strdanjia, font1, brush, new Point(370 + 235, 130 + (i - 1) * 8));
                        g.DrawString(strjine, font1, brush, new Point(370 + 330, 130 + (i - 1) * 8));
                    }
                   // g.DrawString("", font1, brush, new Point(730, 130 + i * 8));
                    if (i % 20 == 0)
                    {
                        if (i == 0)
                        {
                            g.DrawLine(new Pen(brush), new Point(34, 130 + i * 8 - 24), new Point(780, 130 + i * 8 - 24));
                        }
                        else
                        {
                            g.DrawLine(new Pen(brush), new Point(34, 130 + i * 8 ), new Point(780, 130 + i * 8 ));
                        }
                    }
                    i++; 
                }          
            }
            g.DrawString("总计：", new Font("新宋体", 15), brush, new Point(200, 130 + i * 8 + 10)); g.DrawString(smp.CostAllCount.ToString("0.00"), font, brush, new Point(300, 130 + i * 8 + 10));
            g.DrawString("收货单位及经手人：", font, brush, new Point(30, 130 + i * 8 + 40)); 
            g.DrawString("出货单位及经手人：", font, brush, new Point(410, 130 + i * 8 + 40));
            g.DrawLine(new Pen(brush), new Point(34, 58), new Point(34, 130 + i * 8 + 60));
            g.DrawLine(new Pen(brush), new Point(405, 58), new Point(405, 130 + i * 8 + 60));
            g.DrawLine(new Pen(brush), new Point(780, 58), new Point(780, 130 + i * 8 + 60));
            g.DrawLine(new Pen(brush), new Point(34, 58), new Point(780, 58));
            g.DrawLine(new Pen(brush), new Point(34, 130 + i * 8 + 60), new Point(780, 130 + i * 8 + 60));

        }

        private void printDocument1_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
            //e.PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 850, printPageHeight);
            //e.PageSettings.Margins = new Margins(0, 0, 0, 0);
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            if (!addNew(m_Month, m_ProductClass))
            { MessageBox.Show("没有符合的产品，请退出出货界面重新进入后再继续进行其他操作！"); }
        }

    }


}
