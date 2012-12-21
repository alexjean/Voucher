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

        List<TextBox> m_TextBoxPaths=new List<TextBox>();
        private void cashierBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            BakeryOrderSet.CashierDataTable table = MyFunction.SaveCheck<BakeryOrderSet.CashierDataTable>(
                                            this, cashierBindingSource, bakeryOrderSet.Cashier);
            if (table == null) return;
            listBoxReadme.Items.Clear();
            Message("設定店長本机收銀授權!");
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
            // 更改收銀机授權,因不知歷史, 用全面覆蓋,反正資料庫小
            for(int i=0;i<m_TextBoxPaths.Count;i++)
            {
                string dir = m_TextBoxPaths[i].Text.Trim();
                if (dir.Length == 0) continue;
                string PosID=(i+1).ToString();
                Message("設定收銀机<" + PosID + ">位於 "+dir);
                string connStr = MapPath.ConnectString(dir + "\\BakeryOrder.mdb", MapPath.BakeryPass + "Bakery");
                BakeryOrderSet posBakerySet = new BakeryOrderSet();
                System.Data.OleDb.OleDbConnection dbConnection = new System.Data.OleDb.OleDbConnection(connStr);
                BakeryOrderSetTableAdapters.CashierTableAdapter adapter = new BakeryOrderSetTableAdapters.CashierTableAdapter();
                adapter.Connection = dbConnection;
                try
                {
                    adapter.Fill(posBakerySet.Cashier);
                    // 先加入PosID
                    var posCashiers = from row in posBakerySet.Cashier where (row.CashierID == int.MinValue) select row;
                    if (posCashiers.Count() > 0)
                    {
                        BakeryOrderSet.CashierRow cashier = posCashiers.First();
                        cashier.CashierName = "PosID="+PosID;
                    }
                    else
                    {
                        var pos = posBakerySet.Cashier.NewCashierRow();  // 沒有關聯,所以沒必要BeginEdit EndEdit
                        pos.CashierID = int.MinValue;
                        pos.CashierName = "PosID=" + PosID;
                        posBakerySet.Cashier.AddCashierRow(pos);
                    }
                    // 先看POS裏面有的
                    foreach (BakeryOrderSet.CashierRow pos in posBakerySet.Cashier)
                    {
                        if (pos.CashierID == int.MinValue) continue;    // 是PosID,保留
                        var cashiers = from row in bakeryOrderSet.Cashier where (row.CashierID == pos.CashierID) select row;
                        BakeryOrderSet.CashierRow cashier;
                        if (cashiers.Count() <= 0)    // 此記錄店長資料庫不存在
                            pos.Delete();
                        else
                        {
                            cashier = cashiers.First();
                            pos.ItemArray = cashier.ItemArray;
                        }
                    }
                    // 加入POS裏面沒有的
                    foreach (BakeryOrderSet.CashierRow cashier in bakeryOrderSet.Cashier)
                    {
                        var rows = from row in posBakerySet.Cashier where (row.CashierID == cashier.CashierID) select row;
                        if (rows.Count() > 0) continue;   // 己經存在了
                        var pos=posBakerySet.Cashier.NewCashierRow();  // 沒有關聯,所以沒必要BeginEdit EndEdit
                        pos.ItemArray = cashier.ItemArray;
                        posBakerySet.Cashier.AddCashierRow(pos);
                    }
                    adapter.Update(posBakerySet.Cashier);
                }
                catch (Exception ex)
                {
                    Message("錯誤:" + ex.Message,true);
                }
            }
            Message("收銀授權完成!");
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
            m_TextBoxPaths.Add(textBoxPOS1);
            m_TextBoxPaths.Add(textBoxPOS2);
            m_TextBoxPaths.Add(textBoxPOS3);
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

        private void btnBackupDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            textBoxBackupDir.Text = folderBrowserDialog.SelectedPath;
        }

        Config Cfg = new Config();
        string ConfigName = "CashierAuthen";
        string TableName = "DirectoryPath";
        private void btnConfigSave_Click(object sender, EventArgs e)
        {
            int count=m_TextBoxPaths.Count;
            StringBuilder xml = new StringBuilder("<" + ConfigName + " Name=\"" + TableName + "\">", 512);
            for(int i=0;i<count;i++)
                xml.Append("<POS"+(i+1).ToString()+" Dir=\""+m_TextBoxPaths[i].Text.Trim()+"\" />");
            xml.Append("<Backup Dir=\"" + textBoxBackupDir.Text.Trim() + "\" />");
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
                else if (node.Name == "Backup") textBoxBackupDir.Text = dir.Value;
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
            Message("--------"+sID + "匯入完成！");
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
                        Message("今日資料己封印！ 無法再轉檔!");
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
            int count = m_TextBoxPaths.Count;
            for (int i = 0; i < count; i++)
                GetCashierData(i + 1, textBoxPOS1.Text, today);
            Message("共成功匯入了 " + count.ToString() + " 台收銀机的資料!");
        }

        void Message(string msg,bool showWarning=false)
        {
            listBoxReadme.Items.Add(msg);
            if (showWarning)
                MessageBox.Show(msg);
        }

        private void btnClosedBackup_Click(object sender, EventArgs e)
        {
            DateTime today = todayPicker.Value;
            headerTableAdapter.Fill(bakeryOrderSet.Header);
            var headers = from row in bakeryOrderSet.Header where row.DataDate == today.Date select row;
            listBoxReadme.Items.Clear();
            if (headers.Count() > 0)
            {
                var header = headers.First();
                if (!header.IsClosedNull() && header.Closed)
                {
                    Message("今日資料己封印！ 不用再做");
                    return;
                }
            }
            else
            {
                Message("找不到"+today.Month+"月"+today.Day+"日 資料, 你確定己經收取了收銀机資料?");
                return;
            }
            if (MessageBox.Show("確定要封印" + today.Month + "月" + today.Day + "日 資料?", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                Message("使用者取消封印!");
                return;
            }
            int i = 0;
            string dir;
            foreach(TextBox box in m_TextBoxPaths)
            {
                dir = box.Text.Trim();
                i++;
                if (dir.Length <= 0) continue;
                Message("封印收銀机<" + i.ToString() + "> " + today.Date.ToShortDateString());
                string connStr = MapPath.ConnectString(dir + "\\BakeryOrder.mdb", MapPath.BakeryPass + "Bakery");
                BakeryOrderSet posBakerySet = new BakeryOrderSet();
                System.Data.OleDb.OleDbConnection dbConnection = new System.Data.OleDb.OleDbConnection(connStr);
                BakeryOrderSetTableAdapters.HeaderTableAdapter adapter=new BakeryOrderSetTableAdapters.HeaderTableAdapter();
                adapter.Connection = dbConnection;
                try
                {
                    adapter.Fill(posBakerySet.Header);
                    var posHeaders = from row in posBakerySet.Header where (row.DataDate == today.Date) select row;
                    BakeryOrderSet.HeaderRow posHeader;
                    if (posHeaders.Count() > 0)
                    {
                        posHeader = posHeaders.First();
                        posHeader.Closed = true;
                    }
                    else
                    {
                        posHeader = posBakerySet.Header.NewHeaderRow();
                        posHeader.DataDate = today.Date;
                        posHeader.Closed = true;
                        posBakerySet.Header.AddHeaderRow(posHeader);
                    }
                    adapter.Update(posBakerySet.Header);
                }
                catch(Exception ex)
                {
                    Message("錯誤:" + ex.Message, true);
                    return;
                }
            }
            dir=textBoxBackupDir.Text.Trim();
            if (dir.Length > 0)
            {
                Message("備份至<" + dir + ">");
                BackupData.DoBackup(".", dir);
                Message("封印及備份完成！");
            }
            else
                Message("封印完成！");
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            listBoxReadme.Items.Clear();
            try
            {
                productTableAdapter.Fill(bakeryOrderSet.Product);
            }
            catch (Exception ex)
            {
                Message("讀取店長產品表出錯,原因:" + ex.Message,true);
                return;
            }
            int i = 0;
            string dir;
            foreach (TextBox box in m_TextBoxPaths)
            {
                dir = box.Text.Trim();
                i++;
                if (dir.Length <= 0) continue;
                Message("更新收銀机<" + i.ToString() + "> 產品表");
                string connStr = MapPath.ConnectString(dir + "\\BakeryOrder.mdb", MapPath.BakeryPass + "Bakery");
                BakeryOrderSet posBakerySet = new BakeryOrderSet();
                System.Data.OleDb.OleDbConnection dbConnection = new System.Data.OleDb.OleDbConnection(connStr);
                BakeryOrderSetTableAdapters.ProductTableAdapter adapter = new BakeryOrderSetTableAdapters.ProductTableAdapter();
                adapter.Connection = dbConnection;
                try
                {
                    adapter.Fill(posBakerySet.Product);
                    int updated=0,added = 0;

                    foreach (var pr in bakeryOrderSet.Product)
                    {
                        var posProducts = from row in posBakerySet.Product where (pr.ProductID==row.ProductID) select row;
                        BakeryOrderSet.ProductRow posProduct;
                        if (posProducts.Count() > 0)
                        {
                            posProduct = posProducts.First();
                            posProduct.BeginEdit();
                            posProduct.ItemArray = pr.ItemArray;
                            posProduct.EndEdit();
                            updated++;
                        }
                        else
                        {
                            posProduct = posBakerySet.Product.NewProductRow();
                            posProduct.ItemArray = pr.ItemArray;
                            posBakerySet.Product.AddProductRow(posProduct);
                            added++;
                        }
                    }
                    // 刪除不在店長資料庫的
                    int deleted = 0;
                    foreach (var pr in posBakerySet.Product)
                    {
                        var Products = from row in bakeryOrderSet.Product where (pr.ProductID == row.ProductID) select row;
                        if (Products.Count() > 0) continue;
                        pr.Delete();
                        deleted++;
                    }
                    adapter.Update(posBakerySet.Product);
                    Message("共更新 " + updated.ToString() + "筆,新增 " + added.ToString() + "筆,刪除 " + deleted.ToString() + "筆");
                    Message("---------------------------------------------");
                }
                catch (Exception ex)
                {
                    Message("錯誤:" + ex.Message, true);
                    return;
                }
            }
            Message("所有收銀机都更新完畢!");
            Message("收銀机必需重新登入更新才會生效!");
        }

 
    }
}
