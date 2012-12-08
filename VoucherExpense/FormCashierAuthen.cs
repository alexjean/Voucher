using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace VoucherExpense
{
    public partial class FormCashierAuthen : Form
    {
        public FormCashierAuthen()
        {
            InitializeComponent();
        }

        private void cashierBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            BakeryOrderSet.CashierDataTable table = MyFunction.SaveCheck<BakeryOrderSet.CashierDataTable>(
                                            this, cashierBindingSource, bakeryOrderSet.Cashier);
            if (table == null) return;
            foreach (BakeryOrderSet.CashierRow r in table.Rows)
            {
                if (r.RowState == DataRowState.Deleted) continue;
                r.BeginEdit();
                r.LastUpdated = DateTime.Now;
                r.AuthenID = MyFunction.OperatorID;
                r.EndEdit();
            }
            bakeryOrderSet.Cashier.Merge(table);
            this.cashierTableAdapter.Update(bakeryOrderSet.Cashier);
            bakeryOrderSet.Cashier.AcceptChanges();
            this.cashierBindingSource.ResetBindings(false);
        }

        // 店長DB
        BakeryOrderSetTableAdapters.HeaderTableAdapter
                         headerTableAdapter    = new BakeryOrderSetTableAdapters.HeaderTableAdapter();
        OrderAdapter     orderTableAdapter     = new OrderAdapter();
        OrderItemAdapter orderItemTableAdapter = new OrderItemAdapter();
        DrawerRecordAdapter drawerTableAdapter = new DrawerRecordAdapter();

        private void FormCashierAuthen_Load(object sender, EventArgs e)
        {
            headerTableAdapter.Connection    = MapPath.BakeryConnection;
            orderTableAdapter.Connection     = MapPath.BakeryConnection;
            orderItemTableAdapter.Connection = MapPath.BakeryConnection;
            drawerTableAdapter.Connection    = MapPath.BakeryConnection;
            cashierTableAdapter.Connection   = MapPath.BakeryConnection;     // cashierTableAdapter宣告位置不同

            this.operatorTableAdapter.Fill(this.vEDataSet.Operator);
            this.cashierTableAdapter.Fill(this.bakeryOrderSet.Cashier);
            chBoxOnlyInPosition_CheckedChanged(null, null);
            DateTime now = DateTime.Now;
            todayPicker.MinDate = new DateTime(MyFunction.IntHeaderYear, 1, 1);
            todayPicker.MaxDate = new DateTime(MyFunction.IntHeaderYear, 12, 31);
            todayPicker.Value = now;
            LoadCfg();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyFunction.AddNewItem(cashierDataGridView, "CashierIDColumn", "CashierID", bakeryOrderSet.Cashier);
            DataGridViewRow row = cashierDataGridView.CurrentRow;
        }

        private void cashierDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != -1 && this.cashierDataGridView.Columns[e.ColumnIndex].Name ==  "PasswordColumn")
            {
                if (e.Value != null)
                {
                    String st = new String('*', e.Value.ToString().Length);
                    e.Value = st;
                }
            }
        }

        private void chBoxOnlyInPosition_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxOnlyInPosition.Checked)
                this.cashierBindingSource.Filter = "InPosition";
            else
                this.cashierBindingSource.RemoveFilter();
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            textBoxPOS1.Text = folderBrowserDialog.SelectedPath;
        }
        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            textBoxPOS2.Text = folderBrowserDialog.SelectedPath;
        }
        private void btnBrowse3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            textBoxPOS3.Text = folderBrowserDialog.SelectedPath;
        }


        Config Cfg = new Config();
        string ConfigName = "CashierAuthen";
        string TableName = "DirectoryPath";
        private void btnConfigSave_Click(object sender, EventArgs e)
        {
            string[] paths=new string[3];
            paths[0] = textBoxPOS1.Text.Trim();
            paths[1] = textBoxPOS2.Text.Trim();
            paths[2] = textBoxPOS3.Text.Trim();
            StringBuilder xml = new StringBuilder("<" + ConfigName + " Name=\"" + TableName + "\">", 512);
            for(int i=0;i<3;i++)
                xml.Append("<POS"+(i+1).ToString()+" Dir=\""+paths[i]+"\" />");

            xml.Append("</" + ConfigName + ">");
            Cfg.Save(ConfigName, TableName, xml.ToString());
        }

        void LoadCfg()
        {
            XmlNode list = Cfg.Load(ConfigName, TableName);
            if (list == null) return;
            foreach (XmlNode node in list)
            {
                XmlAttribute dir = node.Attributes["Dir"];
                if (dir == null) continue;
                if      (node.Name == "POS1") textBoxPOS1.Text = dir.Value;
                else if (node.Name == "POS2") textBoxPOS2.Text = dir.Value;
                else if (node.Name == "POS3") textBoxPOS3.Text = dir.Value;
            }
        }

        void CopyOrder(BakeryOrderSet.OrderRow order,int posID)
        {
            int newID = OrderIDWithPOS(order.ID, posID);
            var mainOrders = from row in bakeryOrderSet.Order
                             where row.ID == newID
                             select row;
            BakeryOrderSet.OrderRow newOrder;
            if (mainOrders.Count() > 0)
            {
                newOrder = mainOrders.First();
                newOrder.BeginEdit();
                newOrder.ItemArray = order.ItemArray;   // ID應該是相同的
                newOrder.EndEdit();
            }
            else
            {
                newOrder = bakeryOrderSet.Order.NewOrderRow();
                newOrder.ItemArray = order.ItemArray;
                newOrder.ID = newID;
                bakeryOrderSet.Order.AddOrderRow(newOrder);
            }
            BakeryOrderSet.OrderItemRow[] mainItems=newOrder.GetOrderItemRows();
            int count=mainItems.Count();
            int index=0;
            foreach (BakeryOrderSet.OrderItemRow item in order.GetOrderItemRows())
            {
                if (index >= count)  // 假設己經按順序,BakeryOrder那裏己經把Index放好
                {
                    BakeryOrderSet.OrderItemRow newItem = bakeryOrderSet.OrderItem.NewOrderItemRow();
                    newItem.BeginEdit();
                    newItem.ItemArray = item.ItemArray;
                    newItem.SetParentRow(newOrder);
                    newItem.EndEdit();
                    bakeryOrderSet.OrderItem.AddOrderItemRow(newItem);
                }
                else
                {
                    BakeryOrderSet.OrderItemRow oldItem = mainItems[index];
                    oldItem.BeginEdit();
                    oldItem.ItemArray = item.ItemArray;
                    oldItem.SetParentRow(newOrder);
                    oldItem.EndEdit();
                }
                index++;
            }
        }

        string SqlOrder ;    // 資料定義為 MMDDN99999  N POS机号, 店長收資料時,再自動填上        
        string SqlDrawer;    // 資料定義為 MMDDN99999  N POS机号, id最多10萬筆
        bool GetCashierData(int posID, string dir,DateTime today)
        {
            string sID = "收銀机<" + posID.ToString() + "> ";
            dir = dir.Trim();
            if (dir.Length == 0)
            {
                Message(sID + "不存在!");
                return false;
            }
            if (dir.Length < 5)
            {
                Message(sID+ " 網路位置過短!",true);
                return false;
            }
            Message("--------開始匯入" + sID);
            string connStr=MapPath.ConnectString(dir+"\\BakeryOrder.mdb",MapPath.BakeryPass+"Bakery");
            BakeryOrderSet posBakerySet = new BakeryOrderSet();
            System.Data.OleDb.OleDbConnection dbConnection   = new System.Data.OleDb.OleDbConnection(connStr);
            // 收銀机DB
            OrderAdapter        orderAdapter   = new OrderAdapter();
            OrderItemAdapter    itemAdapter    = new OrderItemAdapter();
            DrawerRecordAdapter drawerAdapter  = new DrawerRecordAdapter();
            drawerAdapter.Connection    = dbConnection;
            orderAdapter.Connection     = dbConnection;
            itemAdapter.Connection      = dbConnection;
            try
            {
                Message("讀取本日交易明細!");
                orderAdapter.FillBySelectStr (posBakerySet.Order       , "Select * From [Order] "       + SqlOrder + " Order by ID");
                itemAdapter.FillBySelectStr  (posBakerySet.OrderItem   , "Select * From [OrderItem] "   + SqlOrder);
                foreach (BakeryOrderSet.OrderRow order in posBakerySet.Order)
                    CopyOrder(order,posID);
                Message("寫入本地資料庫! 共 "+posBakerySet.Order.Count.ToString()+" 筆");
                orderTableAdapter.Update(bakeryOrderSet.Order);
                orderItemTableAdapter.Update(bakeryOrderSet.OrderItem);
                // 寫入Header
                var headers = from row in bakeryOrderSet.Header where row.DataDate == today.Date select row;
                if (headers.Count() <=0)   // 無今日資料再加, 是否己封印,呼叫端己檢查
                {
                    BakeryOrderSet.HeaderRow header = bakeryOrderSet.Header.NewHeaderRow();
                    header.DataDate = today.Date;
                    header.Closed = false;
                    bakeryOrderSet.Header.AddHeaderRow(header);
                    headerTableAdapter.Update(bakeryOrderSet.Header);
                }

                Message("匯入錢箱記錄!");
                drawerAdapter.FillBySelectStr(posBakerySet.DrawerRecord, "Select * From [DrawerRecord] "+ SqlDrawer);
                foreach (BakeryOrderSet.DrawerRecordRow drawer in posBakerySet.DrawerRecord)
                {
                    var mainDrawers = from row in bakeryOrderSet.DrawerRecord
                                      where row.DrawerRecordID == drawer.DrawerRecordID
                                      select row;
                    if (mainDrawers.Count() > 0)
                    {
                        BakeryOrderSet.DrawerRecordRow oldDrawer = mainDrawers.First();
                        oldDrawer.BeginEdit();
                        oldDrawer.ItemArray = drawer.ItemArray;
                        oldDrawer.AssociateOrderID = OrderIDWithPOS(drawer.AssociateOrderID, posID);
                        oldDrawer.EndEdit();
                    }
                    else
                    {
                        BakeryOrderSet.DrawerRecordRow newDrawer = bakeryOrderSet.DrawerRecord.NewDrawerRecordRow();
                        newDrawer.BeginEdit();
                        newDrawer.ItemArray = drawer.ItemArray;
                        newDrawer.AssociateOrderID  = OrderIDWithPOS(drawer.AssociateOrderID, posID);
                        newDrawer.EndEdit();
                        bakeryOrderSet.DrawerRecord.AddDrawerRecordRow(newDrawer);
                    }
                }
                drawerTableAdapter.Update(bakeryOrderSet.DrawerRecord);
                Message("共 " + posBakerySet.DrawerRecord.Count.ToString()+" 筆");
            }
            catch(Exception ex)
            {
                Message("取收銀机<" + posID.ToString() + ">時錯誤,原因:" + ex.Message,true);
                Message("--------");
                return false;
            }
            Message("--------"+sID + "匯入完成!");
            return true;
        }

        int OrderIDWithPOS(int id,int pos)
        {
            int dayPart = ((int)(id / 1000000))*1000000;
            int serialPart = id % 100000;
            return dayPart + serialPart + pos * 100000;
        }


        private void btnGetDataFromPOS_Click(object sender, EventArgs e)
        {
            DateTime today = todayPicker.Value;
            DialogResult result = MessageBox.Show("從收銀机匯整<" + today.ToShortDateString() + ">資料!", "", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel) return;
            listBoxReadme.Items.Clear();
            Message("載入店長端資料庫!");
            SqlOrder  = "Where INT(ID/1000000)="             + today.Month.ToString("d2") + today.Day.ToString("d2");   // 資料定義為 MMDDN99999  N POS机号,店長收資料時,再自動填上        
            SqlDrawer = "Where INT(DrawerRecordID/1000000)=" + today.Month.ToString("d2") + today.Day.ToString("d2");   // 資料定義為 MMDDN99999  N POS机号, id最多10萬筆
            try
            {
                headerTableAdapter.Fill              (bakeryOrderSet.Header);
                var headers = from row in bakeryOrderSet.Header where row.DataDate == today.Date select row;
                if (headers.Count() > 0)
                {
                    var header = headers.First();
                    if (!header.IsClosedNull() && header.Closed)
                    {
                        Message("今日資料己封印! 無法再轉檔!");
                        return;
                    }
                }
                orderTableAdapter.FillBySelectStr    (bakeryOrderSet.Order        , "Select * From [Order] "        + SqlOrder + " Order by ID");
                orderItemTableAdapter.FillBySelectStr(bakeryOrderSet.OrderItem    , "Select * From [OrderItem] "    + SqlOrder );
                drawerTableAdapter.FillBySelectStr   (bakeryOrderSet.DrawerRecord , "Select * From [DrawerRecord] " + SqlDrawer);
            }
            catch (Exception ex)
            {
                Message("載入店長端資料庫錯誤:" + ex.Message);
                return;
            }
            int count=0;
            if (GetCashierData(1, textBoxPOS1.Text, today)) count++;
            if (GetCashierData(2, textBoxPOS2.Text, today)) count++;
            if (GetCashierData(3, textBoxPOS3.Text, today)) count++;
            Message("共成功匯入了 " + count.ToString() + " 台收銀机的資料!");
        }

        void Message(string msg,bool showWarning=false)
        {
            listBoxReadme.Items.Add(msg);
            if (showWarning)
                MessageBox.Show(msg);
        }
    }
}
