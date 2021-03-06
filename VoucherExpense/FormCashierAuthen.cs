﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Drawing.Printing;
using System.Collections;
using System.IO;

using MyDataSet         = VoucherExpense.DamaiDataSet;
using MyOrderSet        = VoucherExpense.DamaiDataSet;
using MyCashierTable    = VoucherExpense.DamaiDataSet.CashierDataTable;
using MyHeaderRow       = VoucherExpense.DamaiDataSet.HeaderRow;
using MyCashierRow      = VoucherExpense.DamaiDataSet.CashierRow;
using MyOrderRow        = VoucherExpense.DamaiDataSet.OrderRow;
using MyProductRow      = VoucherExpense.DamaiDataSet.ProductRow;
using MyHeaderAdapter       = VoucherExpense.DamaiDataSetTableAdapters.HeaderTableAdapter;
using MyCashierAdapter      = VoucherExpense.DamaiDataSetTableAdapters.CashierTableAdapter;
using MyProductAdapter      = VoucherExpense.DamaiDataSetTableAdapters.ProductTableAdapter;

using MyOrderAdapter        = VoucherExpense.DamaiOrderAdapter;
using MyOrderItemAdapter    = VoucherExpense.DamaiOrderItemAdapter;
using MyDrawerRecordAdapter = VoucherExpense.DamaiDrawerRecordAdapter;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace VoucherExpense
{
    public partial class FormCashierAuthen : Form
    {
        DamaiDataSet.ApartmentRow m_DefaultApartment;
        public FormCashierAuthen(DamaiDataSet.ApartmentRow defaultApartment)
        {
            m_DefaultApartment = defaultApartment;
            InitializeComponent();
        }

        HardwareConfig m_Cfg; //=new HardwareConfig();
        // 店長DB
        MyDataSet m_DataSet = new MyDataSet();
        MyOrderSet m_OrderSet;
        MyHeaderAdapter HeaderAdapter       = new MyHeaderAdapter();
        MyCashierAdapter CashierAdapter     = new MyCashierAdapter();
        MyOrderAdapter OrderAdapter         = new MyOrderAdapter();
        MyOrderItemAdapter OrderItemAdapter = new MyOrderItemAdapter();
        MyDrawerRecordAdapter DrawerAdapter = new MyDrawerRecordAdapter();
        MyProductAdapter ProductAdapter     = new MyProductAdapter();
        int m_StoreID=0;
        private void FormCashierAuthen_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'damaiDataSet.Cashier' 資料表。您可以視需要進行移動或移除。
            this.cashierTableAdapter.Fill(this.damaiDataSet.Cashier);
            m_Cfg= MyFunction.HardwareCfg;
            btnCloundSyncAuto.Visible = m_Cfg.EnableCloudSync;


            HideBackupOption();
            m_OrderSet = m_DataSet;
            var operatorAdapter = new VoucherExpense.DamaiDataSetTableAdapters.OperatorTableAdapter();
            operatorAdapter.Connection.ConnectionString = DB.SqlConnectString(MyFunction.HardwareCfg);
            ProductAdapter.Connection.ConnectionString  = DB.SqlConnectString(MyFunction.HardwareCfg);
            PhotoAdapter.Connection.ConnectionString    = DB.SqlConnectString(MyFunction.HardwareCfg);

            //var apartmentAdapter = new VoucherExpense.DamaiDataSetTableAdapters.ApartmentTableAdapter();
            //apartmentAdapter.Connection.ConnectionString = DB.SqlConnectString(MyFunction.HardwareCfg);

            cashierBindingSource.DataSource  = m_OrderSet;
            operatorBindingSource.DataSource = m_DataSet;
            try
            {
                operatorAdapter.Fill(m_DataSet.Operator);
                CashierAdapter.Fill (m_OrderSet.Cashier);
                //apartmentAdapter.Fill(m_DataSet.Apartment);
                //if (m_DataSet.Apartment.Rows.Count != 0)
                //{
                //    var a0 = m_DataSet.Apartment[0];
                //    foreach (var a in m_DataSet.Apartment)
                //    {
                //        if (!a.IsIsCurrentNull() && a.IsCurrent)
                //        {
                //            a0 = a;
                //            break;
                //        }
                //    }
                //    if (!a0.IsAppartementCodeNull())
                //    {
                //        m_StoreID = a0.AppartementCode;
                //    }
                //}
                if (!m_DefaultApartment.IsAppartementCodeNull())
                    m_StoreID = m_DefaultApartment.AppartementCode;

                labelStoreID.Text = m_StoreID.ToString();
                chBoxOnlyInPosition_CheckedChanged(null, null);
                DateTime now = DateTime.Now;
                todayPicker.MinDate = new DateTime(MyFunction.IntHeaderYear, 1, 1);
                todayPicker.MaxDate = new DateTime(MyFunction.IntHeaderYear, 12, 31);
                if (now.Date < todayPicker.MinDate) todayPicker.Value = todayPicker.MinDate;
                else if (now.Date > todayPicker.MaxDate) todayPicker.Value = todayPicker.MaxDate;
                else todayPicker.Value = now.Date;
                LoadCfg();
                BakeryConfig = new BakeryConfig(MapPath.DataDir);
                LoadBakeryConfig();
                LoadLetterConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤:" + ex.Message);
            }
            m_TextBoxPaths.Add(textBoxPOS1);
            m_TextBoxPaths.Add(textBoxPOS2);
            m_TextBoxPaths.Add(textBoxPOS3);
            m_TextBoxPaths.Add(textBoxPOS4);
            m_TextBoxPaths.Add(textBoxPOS5);
            m_TextBoxPaths.Add(textBoxPOS6);

//            btnCloundSyncAuto.Text = "雲端同步\n\n收取收銀机資料\n\n自動循環";
        }

        void HideBackupOption()
        {
            textBoxBackupDir.Visible=false;
            btnBackupDir.Visible=false;
        }


        List<TextBox> m_TextBoxPaths=new List<TextBox>();
        private void cashierBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            MyCashierTable table = MyFunction.SaveCheck<MyCashierTable>(
                                            this, cashierBindingSource, m_OrderSet.Cashier);
            if (table == null)
            {
                if (MessageBox.Show("資料沒有修改,仍要傳遞收銀權限至各收銀机嗎?","",MessageBoxButtons.YesNo)!=DialogResult.Yes)
                    return;
            }
            ClearMessage();
            if (table != null)
            {
                Message("設定店長本机收銀授權!");
                foreach (var r in table)
                {
                    if (r.RowState == DataRowState.Deleted) continue;
                    r.BeginEdit();
                    r.LastUpdated = DateTime.Now;
                    r.AuthenID = MyFunction.OperatorID;
                    r.EndEdit();
                    if (r.IsCashierPasswordNull() || r.CashierPassword.Length < 5) Message("==>收銀員 " + r.CashierID.ToString() + " 密碼太短,無法登入!");
                    else
                    {
                        foreach (char c in r.CashierPassword)
                        {
                            if (!char.IsDigit(c))
                            {
                                Message("==>收銀員 " + r.CashierID.ToString() + " 密碼含有非數字,無法登入!");
                                break;
                            }
                        }
                    }
                }
                m_OrderSet.Cashier.Merge(table);
                CashierAdapter.Update(m_OrderSet.Cashier);
                m_OrderSet.Cashier.AcceptChanges();
            }
            this.cashierBindingSource.ResetBindings(false);
            // 更改收銀机授權,因不知歷史, 用全面覆蓋,反正資料庫小
            for(int i=0;i<m_TextBoxPaths.Count;i++)
            {
                string dir = m_TextBoxPaths[i].Text.Trim();
                if (dir.Length == 0) continue;
                string PosID=(i+1).ToString();
                Message("設定收銀机<" + PosID + ">");
                string connStr = MapPath.ConnectString(dir + "\\BakeryOrder.mdb", MapPath.BakeryPass + "Bakery");
                BakeryOrderSet posBakerySet = new BakeryOrderSet();    // 收銀机使用MDB版
                System.Data.OleDb.OleDbConnection dbConnection = new System.Data.OleDb.OleDbConnection(connStr);
                BakeryOrderSetTableAdapters.CashierTableAdapter adapter = new BakeryOrderSetTableAdapters.CashierTableAdapter();
                adapter.Connection = dbConnection;
                try
                {
                    adapter.Fill(posBakerySet.Cashier);
                    //// 先加入PosID <== 己經改至[BakeryConfig]
                    //var posCashiers = from row in posBakerySet.Cashier where (row.CashierID == int.MinValue) select row;
                    //if (posCashiers.Count() > 0)
                    //{
                    //    BakeryOrderSet.CashierRow cashier = posCashiers.First();
                    //    cashier.CashierName = "PosID="+PosID;
                    //}
                    //else
                    //{
                    //    var pos = posBakerySet.Cashier.NewCashierRow();  // 沒有關聯,所以沒必要BeginEdit EndEdit
                    //    pos.CashierID = int.MinValue;
                    //    pos.CashierName = "PosID=" + PosID;
                    //    posBakerySet.Cashier.AddCashierRow(pos);
                    //}
                    // 先看POS裏面有的
                    foreach (BakeryOrderSet.CashierRow pos in posBakerySet.Cashier)
                    {
                        if (pos.CashierID == int.MinValue) continue;    // 是PosID,保留
                        var cashiers = from row in m_OrderSet.Cashier where (row.CashierID == pos.CashierID) select row;
                        MyCashierRow cashier;
                        if (cashiers.Count() <= 0)    // 此記錄店長資料庫不存在
                            pos.Delete();
                        else
                        {
                            cashier = cashiers.First();
                            if (cashier.IsCashierNameNull() || cashier.IsLastUpdatedNull() || pos.IsCashierNameNull() || pos.IsLastUpdatedNull())
                                CopyCashier(cashier, pos);      // pos.ItemArray = cashier.ItemArray;
                            else if ((cashier.CashierName == pos.CashierName) && (pos.LastUpdated > cashier.LastUpdated))   // ID Name相同,POS端還晚,表示修改過密碼
                            {                                                                                               // 要保留LastUpdated和CashierPassword           
                                pos.AuthenID = cashier.AuthenID;
                                pos.InPosition = cashier.InPosition;
                            }
                            else
                            {
                                //pos.ItemArray = cashier.ItemArray;
                                CopyCashier(cashier, pos);
                            }
                        }
                    }
                    // 加入POS裏面沒有的
                    foreach (var cashier in m_OrderSet.Cashier)
                    {
                        if (cashier.RowState == DataRowState.Deleted) continue;
                        var rows = from row in posBakerySet.Cashier where (row.RowState!=DataRowState.Deleted) && (row.CashierID == cashier.CashierID) select row;
                        if (rows.Count() > 0) continue;                 // 己經存在了
                        var pos=posBakerySet.Cashier.NewCashierRow();   // 沒有關聯,所以沒必要BeginEdit EndEdit
                        CopyCashier(cashier, pos);                      // pos.ItemArray = cashier.ItemArray;
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

        void CopyCashier(MyCashierRow cashier, BakeryOrderSet.CashierRow pos)
        {
            pos.ItemArray = cashier.ItemArray;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyFunction.AddNewItem(dgvCashier, "CashierIDColumn", "CashierID", m_OrderSet.Cashier);
            DataGridViewRow row = dgvCashier.CurrentRow;
            DataRowView rowView = row.DataBoundItem as DataRowView;
            var cashier = rowView.Row as MyCashierRow;
            cashier.InPosition = true;
            cashier.CashierName = "Cashier"+cashier.CashierID.ToString();
            try
            {
                DataGridViewCell cell = row.Cells["ColumnCashierName"];
                dgvCashier.CurrentCell = cell;
            }
            catch (Exception ex)
            {
                MessageBox.Show("程式錯誤, 可能ColumnCashierName定義有問題:" + ex.Message);
            }
        }

        private void cashierDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != -1 && this.dgvCashier.Columns[e.ColumnIndex].Name ==  "PasswordColumn")
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

        bool PathSameWarning(string path, string path1, string IDPath1)
        {
            if (path.ToLower() == path1.ToLower())
            {
                MessageBox.Show("不能和"+IDPath1+"的路徑相同!");
                return true;
            }
            return false;
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            string path=folderBrowserDialog.SelectedPath.Trim();
            if (path.Length == 0)
            {
                textBoxPOS1.Text = "";
                return;
            }
            if (PathSameWarning(path, Application.StartupPath, "本程式")) return;
            if (PathSameWarning(path, textBoxPOS2.Text, "收銀机2")) return;
            if (PathSameWarning(path, textBoxPOS3.Text, "收銀机3")) return;
            if (PathSameWarning(path, textBoxPOS4.Text, "收銀机4")) return;
            if (PathSameWarning(path, textBoxPOS5.Text, "收銀机5")) return;
            if (PathSameWarning(path, textBoxPOS6.Text, "收銀机6")) return;
            if (PathSameWarning(path, textBoxBackupDir.Text, "備份位置")) return;
            textBoxPOS1.Text = path;
        }
        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            string path = folderBrowserDialog.SelectedPath.Trim();
            if (path.Length == 0)
            {
                textBoxPOS2.Text = "";
                return;
            }
            if (PathSameWarning(path, Application.StartupPath, "本程式")) return;
            if (PathSameWarning(path, textBoxPOS1.Text, "收銀机1")) return;
            if (PathSameWarning(path, textBoxPOS3.Text, "收銀机3")) return;
            if (PathSameWarning(path, textBoxPOS4.Text, "收銀机4")) return;
            if (PathSameWarning(path, textBoxPOS5.Text, "收銀机5")) return;
            if (PathSameWarning(path, textBoxPOS6.Text, "收銀机6")) return;
            if (PathSameWarning(path, textBoxBackupDir.Text, "備份位置")) return;
            textBoxPOS2.Text = path;
        }
        private void btnBrowse3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            string path = folderBrowserDialog.SelectedPath.Trim();
            if (path.Length == 0)
            {
                textBoxPOS3.Text = "";
                return;
            }
            if (PathSameWarning(path, Application.StartupPath, "本程式")) return;
            if (PathSameWarning(path, textBoxPOS1.Text, "收銀机1")) return;
            if (PathSameWarning(path, textBoxPOS2.Text, "收銀机2")) return;
            if (PathSameWarning(path, textBoxPOS4.Text, "收銀机4")) return;
            if (PathSameWarning(path, textBoxPOS5.Text, "收銀机5")) return;
            if (PathSameWarning(path, textBoxPOS6.Text, "收銀机6")) return;
            if (PathSameWarning(path, textBoxBackupDir.Text, "備份位置")) return;
            textBoxPOS3.Text = path;
        }

        private void btnBrowse4_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            string path = folderBrowserDialog.SelectedPath.Trim();
            if (path.Length == 0)
            {
                textBoxPOS4.Text = "";
                return;
            }
            if (PathSameWarning(path, Application.StartupPath, "本程式")) return;
            if (PathSameWarning(path, textBoxPOS1.Text, "收銀机1")) return;
            if (PathSameWarning(path, textBoxPOS2.Text, "收銀机2")) return;
            if (PathSameWarning(path, textBoxPOS3.Text, "收銀机3")) return;
            if (PathSameWarning(path, textBoxPOS5.Text, "收銀机5")) return;
            if (PathSameWarning(path, textBoxPOS6.Text, "收銀机6")) return;
            if (PathSameWarning(path, textBoxBackupDir.Text, "備份位置")) return;
            textBoxPOS4.Text = path;

        }

        private void btnBrowse5_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            string path = folderBrowserDialog.SelectedPath.Trim();
            if (path.Length == 0)
            {
                textBoxPOS5.Text = "";
                return;
            }
            if (PathSameWarning(path, Application.StartupPath, "本程式")) return;
            if (PathSameWarning(path, textBoxPOS1.Text, "收銀机1")) return;
            if (PathSameWarning(path, textBoxPOS2.Text, "收銀机2")) return;
            if (PathSameWarning(path, textBoxPOS3.Text, "收銀机3")) return;
            if (PathSameWarning(path, textBoxPOS4.Text, "收銀机4")) return;
            if (PathSameWarning(path, textBoxPOS6.Text, "收銀机6")) return;
            if (PathSameWarning(path, textBoxBackupDir.Text, "備份位置")) return;
            textBoxPOS5.Text = path;

        }

        private void btnBrowse6_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            string path = folderBrowserDialog.SelectedPath.Trim();
            if (path.Length == 0)
            {
                textBoxPOS6.Text = "";
                return;
            }
            if (PathSameWarning(path, Application.StartupPath, "本程式")) return;
            if (PathSameWarning(path, textBoxPOS1.Text, "收銀机1")) return;
            if (PathSameWarning(path, textBoxPOS2.Text, "收銀机2")) return;
            if (PathSameWarning(path, textBoxPOS3.Text, "收銀机3")) return;
            if (PathSameWarning(path, textBoxPOS4.Text, "收銀机4")) return;
            if (PathSameWarning(path, textBoxPOS5.Text, "收銀机5")) return;
            if (PathSameWarning(path, textBoxBackupDir.Text, "備份位置")) return;
            textBoxPOS6.Text = path;

        }


        private void btnBackupDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            string path = folderBrowserDialog.SelectedPath.Trim();
            if (path.Length == 0)
            {
                textBoxBackupDir.Text = "";
                return;
            }
            if (PathSameWarning(path, Application.StartupPath, "本程式")) return;
            if (PathSameWarning(path, textBoxPOS1.Text, "收銀机1")) return;
            if (PathSameWarning(path, textBoxPOS2.Text, "收銀机2")) return;
            if (PathSameWarning(path, textBoxPOS3.Text, "收銀机3")) return;
            if (PathSameWarning(path, textBoxPOS4.Text, "收銀机4")) return;
            if (PathSameWarning(path, textBoxPOS5.Text, "收銀机5")) return;
            if (PathSameWarning(path, textBoxPOS6.Text, "收銀机6")) return;
            textBoxBackupDir.Text = path;
        }

        Config Cfg = new Config();
        string ConfigName = "CashierAuthen";
        string TableName = "DirectoryPath";
        private void btnConfigSave_Click(object sender, EventArgs e)
        {
            ClearMessage();
            int count=m_TextBoxPaths.Count;
            StringBuilder xml = new StringBuilder("<" + ConfigName + " Name=\"" + TableName + "\">", 512);
            for(int i=0;i<count;i++)
                xml.Append("<POS"+(i+1).ToString()+" Dir=\""+m_TextBoxPaths[i].Text.Trim()+"\" />");
            xml.Append("<Backup Dir=\"" + textBoxBackupDir.Text.Trim() + "\" />");
            xml.Append("</" + ConfigName + ">");
            Cfg.Save(ConfigName, TableName, xml.ToString());
            Message("網路位置存檔完成!",true);
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
                else if (node.Name == "POS4") textBoxPOS4.Text = dir.Value;
                else if (node.Name == "POS5") textBoxPOS5.Text = dir.Value;
                else if (node.Name == "POS6") textBoxPOS6.Text = dir.Value;
                else if (node.Name == "Backup") textBoxBackupDir.Text = dir.Value;
            }
        }

        MD5 m_MD5 = new MD5CryptoServiceProvider();
        void CopyOrderRow_SpecialInDeleted(BakeryOrderSet.OrderRow order, MyOrderRow newOrder)
        {
            string str = "";
            if (!order.IsBranchIDNull())
            {
                newOrder.BranchID = order.BranchID;
                str += order.BranchID.ToString();
            }
            if (!order.IsCashierIDNull())
            {
                newOrder.CashierID = order.CashierID;
                str += order.CashierID.ToString();
            }
            if (!order.IsDeductNull())
            {
                newOrder.Deduct = order.Deduct;
                str += order.Deduct.ToString("N2");
            }
            if (!order.IsDeletedNull())
            {
                // POS沒刪, 店長電腦有狀態,則保留店長狀態
                //if (newOrder.IsDeletedNull())       // 店長電腦無刪除狀態,以POS為準
                //    newOrder.Deleted = order.Deleted;
                //else if (order.Deleted)             // POS是刪除的,一定上傳
                    newOrder.Deleted = order.Deleted;
                if (newOrder.Deleted) str += '1';     // SQL的bit是0 1
                else                  str += '0';
            }
            if (!order.IsDiscountRateNull())
            {
                newOrder.DiscountRate = order.DiscountRate;    
                str += order.DiscountRate.ToString("N2");  // decimal都被CAST成二位小數
            }
            if (!order.IsIncomeNull())
            {
                newOrder.Income = order.Income;
                str += order.Income.ToString("N2");
            }
            if (!order.IsPayByNull())
            {
                newOrder.PayBy = order.PayBy;
                str+= order.PayBy.ToString();
            }
            if (!order.IsTradeNoNull())
            {                                                  
                newOrder.TradeNo = order.TradeNo;        
                str += order.TradeNo;
            }                                                  
            if (!order.IsOpenIDNull())
            {
                newOrder.OpenID = order.OpenID;
                str += order.OpenID;
            }
            if (!order.IsCashIncomeNull())
            {
                newOrder.CashIncome = order.CashIncome;
                str += order.CashIncome.ToString("N2");
            }
            if (!order.IsCouponIncomeNull())
            {
                newOrder.CouponIncome = order.CouponIncome;
                str += order.CouponIncome.ToString("N2");
            }
            //if (!order.IsMemberIDNull())
            //{
            //    newOrder.MemberId = order.MemberID;
            //    str += order.MemberID;
            //}
            //if (!order.IsExBreadNull())
            //{
            //    newOrder.ExBread = order.ExBread;
            //    str += order.ExBread;
            //}
            if (!order.IsPrintTimeNull())
            {
                newOrder.PrintTime = order.PrintTime;           
                DateTime t = order.PrintTime;
                str += t.ToString("yyyy-MM-dd hh:mm:ss");      // SQL CAST時是直接去million second
            }
            if (!order.IsOldIDNull())       newOrder.OldID      = order.OldID;
            if (!order.IsRCashierIDNull())  newOrder.RCashierID = order.RCashierID;
            str += newOrder.OldID.ToString();        // 這二個在SQL裏是NotNULL
            str += newOrder.RCashierID.ToString();
            if (!order.IsMemberIDNull())
            {
                newOrder.MemberID = order.MemberID;
                str += order.MemberID.ToString();
            }
            // 計算MD5
#if (UseSQLServer)
            byte[] md5 = m_MD5.ComputeHash(Encoding.Unicode.GetBytes(str));
            newOrder.MD5 = md5;
#endif 
        }


        
        void CopyOrder(BakeryOrderSet.OrderRow order,int posID)
        {
            int newID = OrderIDWithPOS(order.ID, posID);
            var mainOrders = from row in m_OrderSet.Order
                             where row.ID == newID
                             select row;
            MyOrderRow newOrder;
            if (mainOrders.Count() > 0)
            {
                newOrder = mainOrders.First();
                newOrder.BeginEdit();
//                newOrder.ItemArray = order.ItemArray;   // ID應該是相同的
                order.BranchID = m_StoreID;  // 不管POS怎麼設 , 店長收來時再強制設一次 BranchID
                CopyOrderRow_SpecialInDeleted(order, newOrder);
                newOrder.EndEdit();
            }
            else
            {
                newOrder = m_OrderSet.Order.NewOrderRow();
             
                newOrder.BeginEdit();
               // newOrder.ItemArray = order.ItemArray;
                order.BranchID = m_StoreID;  // 不管POS怎麼設 , 店長收來時再強制設一次 BranchID
                CopyOrderRow_SpecialInDeleted(order, newOrder);
                newOrder.ID = newID;
                newOrder.EndEdit();
                m_OrderSet.Order.AddOrderRow(newOrder);
            }
            var mainItems=newOrder.GetOrderItemRows();
            int count=mainItems.Count();
            int index=0;
            foreach (BakeryOrderSet.OrderItemRow item in order.GetOrderItemRows())
            {
                if (index >= count)  // 假設己經按順序,BakeryOrder那裏己經把Index放好
                {
                    var newItem = m_OrderSet.OrderItem.NewOrderItemRow();
                    newItem.BeginEdit();
                    //newItem.ItemArray = item.ItemArray;     // item是MDB來的, newItem是寫入SQL
                    if (!item.IsProductIDNull()) newItem.ProductID  = item.ProductID;
                    if (!item.IsNoNull())        newItem.No         = item.No;
                    if (!item.IsPriceNull())     newItem.Price      = item.Price;
                    if (!item.IsDiscountNull())  newItem.Discount   = item.Discount;
                    newItem.ID      = newOrder.ID;
                    newItem.Index = (short)index;
#if UseSQLServer
                    newItem.ItemID = newOrder.ID;
#endif
                    newItem.SetParentRow(newOrder);
                    newItem.EndEdit();
                    m_OrderSet.OrderItem.AddOrderItemRow(newItem);
                }
                else
                {
                    var oldItem = mainItems[index];
                    oldItem.BeginEdit();
                    //                    oldItem.ItemArray = item.ItemArray;
                    if (!item.IsDiscountNull())  oldItem.Discount  = item.Discount;
                    if (!item.IsNoNull())        oldItem.No        = item.No;
                    if (!item.IsPriceNull())     oldItem.Price     = item.Price;
                    if (!item.IsProductIDNull()) oldItem.ProductID = item.ProductID;

                    oldItem.SetParentRow(newOrder);
                    oldItem.EndEdit();
                }
                index++;
            }
            // 要刪除不在mdb內的OrderItemRow
            if (index < count)   // 店長端的OrderItem比較多,一定是換Pos號收取資料了,多的要刪
            {
                for (int i = index; i < count; i++)
                    mainItems[i].Delete();
            }
        }

        string SqlOrder ;    // 資料定義為 MMDDN99999  N POS机号, 店長收資料時,再自動填上        
        string SqlDrawer;    // 資料定義為 MMDDN99999  N POS机号, id最多10萬筆
        string SqlOrderMdb;
        string SqlDrawerMdb;
        bool CheckPOSSetup(int storeID, int posID, string dir)
        {
            BakeryConfigMDB posConfig = new BakeryConfigMDB(dir);
            XmlNode root=posConfig.Load(BakeryConfigName, BakeryTableName);
            if (root == null)
            {
                Message("無法檢查收銀机<" + posConfig + ">設定,請檢查POS是否开机中!");
                return false;
            }
            XmlNode node = root.FirstChild;
            if (node == null)
            {
                Message("讀不到收銀机<" + posID + ">机号及店号設定, 請檢查印表机設定 或 收銀机網路位置!");
                return false;
            }
            int pos=0, store=0;
            if (node.Name == "Print")
            {
                XmlAttribute attr;
                attr = node.Attributes["PosNo"];
                if (attr != null && attr.Value != null) int.TryParse(attr.Value, out pos);
                attr = node.Attributes["StoreID"];
                if (attr != null && attr.Value != null) int.TryParse(attr.Value, out store);
            }
            if (pos == 0 || store == 0 || pos!=posID || store!=storeID)
            {
                Message("收銀机<" + posID + "> 其机号<" + pos + ">店号<" + store + ">,顯然有誤.請檢查印表机設定 或 收銀机網路位置!");
                return false;
            }
            return true;
        }

        bool GetCashierData(int storeID,int posID, string dir,DateTime today)
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
            string connStr = MapPath.ConnectString(dir + "\\BakeryOrder.mdb", MapPath.BakeryPass + "Bakery");
            BakeryOrderSet posBakerySet = new BakeryOrderSet();
            System.Data.OleDb.OleDbConnection dbConnection = new System.Data.OleDb.OleDbConnection(connStr);
            BakeryOrderAdapter orderAdapter = new BakeryOrderAdapter();
            BakeryOrderItemAdapter itemAdapter = new BakeryOrderItemAdapter();
            BakeryDrawerRecordAdapter drawerAdapter = new BakeryDrawerRecordAdapter();
            
            drawerAdapter.Connection = dbConnection;
            orderAdapter.Connection = dbConnection;
            itemAdapter.Connection = dbConnection;

            Message("------檢查收銀机設定--------");
            if (!CheckPOSSetup(storeID, posID, dir)) return false;
            Message("--------開始匯入" + sID);
            // 收銀机DB
            try
            {
                Message("讀取本日交易明細!");
                orderAdapter.FillBySelectStr (posBakerySet.Order       , "Select * From [Order] "       + SqlOrderMdb + " Order by ID");
                itemAdapter.FillBySelectStr  (posBakerySet.OrderItem   , "Select * From [OrderItem] "   + SqlOrderMdb);
                foreach (BakeryOrderSet.OrderRow order in posBakerySet.Order)
                    CopyOrder(order,posID);
                // 刪除沒有在posBakerySet.Order的
                foreach(var order in m_OrderSet.Order)
                {
                    if (order.RowState == DataRowState.Unchanged)  // 只有Unchanged才有可能是多的,進去查下ID
                    {
                        int no=order.ID%1000000;  // 只檢查單號,忽略日期
                        if (no / 100000 != posID) continue;
                        no %= 100000;
                        var posOrders = from posOrder in posBakerySet.Order where (posOrder.ID % 100000) == no select posOrder;
                        if (posOrders.Count() <= 0)   // POS mdb中找不到這筆,一定是換POS交叉抓了, 刪掉. 因為FK設為Cascade所以自動刪對應的OrderItem
                            order.Delete();
                    }
                }
                Message("寫入本地資料庫! 共 "+posBakerySet.Order.Count.ToString()+" 筆");
                OrderAdapter.Update(m_OrderSet.Order);
                OrderItemAdapter.Update(m_OrderSet.OrderItem);
                // 寫入Header
                var headers = from row in m_OrderSet.Header where row.DataDate == today.Date select row;
                if (headers.Count() <=0)   // 無今日資料再加, 是否己封印,呼叫端己檢查
                {
                    m_OrderSet.Header.AddHeaderRow(today.Date,false,0,0,0,0);
                    HeaderAdapter.Update(m_OrderSet.Header);
                }

                Message("匯入錢箱記錄!");
                drawerAdapter.FillBySelectStr(posBakerySet.DrawerRecord, "Select * From [DrawerRecord] "+ SqlDrawerMdb);
                foreach (BakeryOrderSet.DrawerRecordRow drawer in posBakerySet.DrawerRecord)
                {
                    var mainDrawers = from row in m_OrderSet.DrawerRecord
                                      where row.DrawerRecordID == drawer.DrawerRecordID
                                      select row;
                    if (mainDrawers.Count() > 0)
                    {
                        var oldDrawer = mainDrawers.First();
                        oldDrawer.BeginEdit();
//                        oldDrawer.ItemArray = drawer.ItemArray;  // 同一ID不能再指定一次
                        oldDrawer.AssociateOrderID = OrderIDWithPOS(drawer.AssociateOrderID, posID);
                        if (!drawer.IsCashierIDNull()) oldDrawer.CashierID = drawer.CashierID;
                        if (!drawer.IsOpenTimeNull())  oldDrawer.OpenTime  = drawer.OpenTime;
                        oldDrawer.EndEdit();
                    }
                    else
                    {
                        var newDrawer = m_OrderSet.DrawerRecord.NewDrawerRecordRow();
                        newDrawer.BeginEdit();
                        //newDrawer.ItemArray = drawer.ItemArray;
                        newDrawer.AssociateOrderID  = OrderIDWithPOS(drawer.AssociateOrderID, posID);
                        if (!drawer.IsCashierIDNull()) newDrawer.CashierID = drawer.CashierID;
                        if (!drawer.IsOpenTimeNull())  newDrawer.OpenTime  = drawer.OpenTime;
                        newDrawer.DrawerRecordID = drawer.DrawerRecordID;
                        newDrawer.EndEdit();
                        m_OrderSet.DrawerRecord.AddDrawerRecordRow(newDrawer);
                    }
                }
                DrawerAdapter.Update(m_OrderSet.DrawerRecord);
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
            if (m_StoreID==0)
            {
                MessageBox.Show("没有设置当前店部门编码，请系統管理員修改部门资料再收取数据");
                return;
            }
            DateTime today = todayPicker.Value;
            DialogResult result = MessageBox.Show("從收銀机匯整<" + today.ToShortDateString() + ">資料!", "", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel) return;
            ClearMessage();
            Message("載入店長端資料庫!");
#if (UseSQLServer)
            string Floor="FLOOR";
#else
            string Floor="INT";
#endif
            string todayStr=today.Month.ToString("d2") + today.Day.ToString("d2");
            SqlOrder  = "Where "+Floor+"(ID/1000000)="             + todayStr;   // 資料定義為 MMDDN99999  N POS机号,店長收資料時,再自動填上        
            SqlDrawer = "Where "+Floor+"(DrawerRecordID/1000000)=" + todayStr;   // 資料定義為 MMDDN99999  N POS机号, id最多10萬筆
            SqlOrderMdb = "Where INT(ID/1000000)=" + todayStr;
            SqlDrawerMdb = "Where INT(DrawerRecordID/1000000)=" + todayStr;
            try
            {
                HeaderAdapter.Fill(m_OrderSet.Header);
                var headers = from row in m_OrderSet.Header where row.DataDate == today.Date select row;
                if (headers.Count() > 0)
                {
                    var header = headers.First();
                    if (!header.IsClosedNull() && header.Closed)
                    {
                        Message("今日資料己封印！ 無法再轉檔!",true);
                        return;
                    }
                }
                // Order及OrderItem的MD5由AP處理, Drawer不用MD5,忽略刪除記錄的同步
                OrderAdapter.FillBySelectStr    (m_OrderSet.Order        , "Select * From [Order] "        + SqlOrder + " Order by ID");
                OrderItemAdapter.FillBySelectStr(m_OrderSet.OrderItem    , "Select * From [OrderItem] "    + SqlOrder );
                DrawerAdapter.FillBySelectStr   (m_OrderSet.DrawerRecord , "Select * From [DrawerRecord] " + SqlDrawer);
            }
            catch (Exception ex)
            {
                Message("載入店長端資料庫錯誤:" + ex.Message);
                return;
            }
            int count = m_TextBoxPaths.Count;
            int success = 0;
            for (int i = 0; i < count; i++)
            {
                string dir=m_TextBoxPaths[i].Text;
                if (GetCashierData(m_StoreID,i + 1,dir , today)) success++;
            }
            Message("共成功匯入了 " + success.ToString() + " 台收銀机的資料!");
        }

        void ClearMessage()
        {
            listBoxReadme.Items.Clear();
        }

        void Message(string msg,bool showWarning=false)
        {
            listBoxReadme.Items.Add(msg);
            if (showWarning)
                MessageBox.Show(msg);
            else
                Application.DoEvents();
        }

        private void DoSqlBackup()
        {
            string strWeekDay = DateTime.Now.DayOfWeek.ToString().Substring(0, 3);
            string name=m_Cfg.Database + "_" + strWeekDay + ".bak";
            try
            {
                string cmdTxt = "Backup Database " + m_Cfg.Database + " TO DISK='"+name+"' WITH INIT";
                SqlConnection conn = new SqlConnection(DB.SqlConnectString(m_Cfg.Local,m_Cfg.Database));
                conn.Open();
                SqlCommand sqlCmd = new SqlCommand(cmdTxt, conn);
                sqlCmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Message("備份數據庫時出錯,錯誤:" + ex.Message, true);
            }
            Message("己備份至 <" + name+">!");
        }

        private void btnClosedBackup_Click(object sender, EventArgs e)
        {
            DateTime today = todayPicker.Value;
            HeaderAdapter.Fill(m_OrderSet.Header);
            var headers = from row in m_OrderSet.Header where row.DataDate == today.Date select row;
            ClearMessage();
            MyHeaderRow mainHeader = null;
            if (headers.Count() > 0)
            {
                mainHeader = headers.First();
                if (!mainHeader.IsClosedNull() && mainHeader.Closed)
                {
                    Message("今日資料己封印！ 不用再做",true);
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
                        posBakerySet.Header.AddHeaderRow(today.Date,true);
                    }
                    adapter.Update(posBakerySet.Header);
                }
                catch(Exception ex)
                {
                    Message("錯誤:" + ex.Message, true);
                    return;
                }
            }
            Message("封印店長端 <"+today.ToShortDateString()+"> 營收資料!");
            try  
            {
                var revenue = new RevenueCalcBakery(today, 0m);   // 先不管手續費, 這里只要總營收
                revenue.LoadData(m_OrderSet, today.Month, today.Day);
                var s=revenue.Statics(m_OrderSet);
#if (UseSQLServer)
                mainHeader.Revenue      = s.Revenue;
                mainHeader.Cash         = s.Cash;
                mainHeader.CreditCard   = s.CreditCard;
                mainHeader.Coupond      = s.Alipay;
#endif
                mainHeader.Closed = true;
                HeaderAdapter.Update(m_OrderSet.Header);
            }
            catch (Exception ex)
            {
                Message("更新店長封印資訊時,錯誤:" + ex.Message,true);
            }
            DoSqlBackup();

                Message("封印完成！");
        }


        void CopyProductRow(MyProductRow fromProduct, BakeryOrderSet.ProductRow toProduct)
        {   // ProductID不在此拷貝
            if (!fromProduct.IsCodeNull())  toProduct.Code  = fromProduct.Code;
            if (!fromProduct.IsClassNull()) toProduct.Class = fromProduct.Class;
            if (!fromProduct.IsNameNull())  toProduct.Name  = fromProduct.Name;
            if (!fromProduct.IsPriceNull()) toProduct.Price = fromProduct.Price;
            if (!fromProduct.IsMenuXNull()) toProduct.MenuX = fromProduct.MenuX;
            if (!fromProduct.IsMenuYNull()) toProduct.MenuY = fromProduct.MenuY;
            if (!fromProduct.IsUnitNull())  toProduct.Unit  = fromProduct.Unit;
            if (!fromProduct.IsTitleCodeNull()) toProduct.TitleCode = fromProduct.TitleCode;
            if (!fromProduct.IsEvaluatedCostNull()) toProduct.EvaluatedCost = fromProduct.EvaluatedCost;
        }
#if (UseSQLServer)
        public class MyPhotoAdapter : DamaiDataSetTableAdapters.PhotosTableAdapter
        {
            string SaveStr;
            public int FillBySelectStr(DamaiDataSet.PhotosDataTable dataTable, string SelectStr)
            {
                ClearBeforeFill = false;
                SaveStr = base.CommandCollection[0].CommandText;
                base.CommandCollection[0].CommandText = SelectStr;
                int result = Fill(dataTable);
                base.CommandCollection[0].CommandText = SaveStr;
                return result;
            }
        }
        MyPhotoAdapter PhotoAdapter = new MyPhotoAdapter();

        class MyFileInfo
        {
            public string Name;
            public DateTime CreationTime;
            public int ProductID;
        }
        List<MyFileInfo> GetFileInfoFromPhotosDB(short tableID)
        {  // 只填檔案名, 時間
            try
            {
                MyDataSet.PhotosDataTable photosDB = new MyDataSet.PhotosDataTable();
                // 不讀入圖以節省時間
                PhotoAdapter.FillBySelectStr(photosDB, "Select [TableID],[PhotoID],[UpdatedTime] from [dbo].[Photos] where TableID=" + tableID.ToString());
                List<MyFileInfo> list = new List<MyFileInfo>();
                foreach (var row in photosDB)
                {
                    MyFileInfo info = new MyFileInfo();
                    info.ProductID      = row.PhotoID;
                    info.Name           = row.PhotoID.ToString() + ".jpg";
                    info.CreationTime   = row.UpdatedTime;
                    list.Add(info);
                }
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("從資料庫讀取產品照片資訊時出錯,原因:" + ex.Message);
                return null;
            }
        } 

        bool CopyPhotoFromDB(int productID, string destName)
        {
            short tableID=(short)PhotoTableID.Product;
            var photos = from r in m_DataSet.Photos where productID == r.PhotoID && r.TableID == tableID select r;
            DamaiDataSet.PhotosRow photo;
            if (photos.Count() > 0) // 有資料直接拿
                photo = photos.First();
            else
            {
                try
                {
                    string sqlStr = "Select * From [dbo].[Photos] where TableID=" + tableID.ToString() + " And PhotoID=" + productID.ToString();
                    if (PhotoAdapter.FillBySelectStr(m_DataSet.Photos, sqlStr) < 1) return false;
                    photos = from r in m_DataSet.Photos where productID == r.PhotoID && r.TableID == tableID select r;
                    if (photos.Count() <= 0) return false;
                    photo = photos.First();
                }
                catch { return false; }
            }
            try
            {
                Bitmap img = (Bitmap)Image.FromStream(new MemoryStream(photo.Photo));
                img.Save(destName);
            }
            catch { return false; }
            return true;
        }
#endif

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            ClearMessage();
            DirectoryInfo mainDirInfo = new DirectoryInfo(MapPath.DataDir+"Photos\\Products");
            List<MyFileInfo> mainFileInfos;
            try
            {
                ProductAdapter.Fill(m_OrderSet.Product);
                mainFileInfos = GetFileInfoFromPhotosDB((short)PhotoTableID.Product);
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

                    foreach (var pr in m_OrderSet.Product)
                    {
                        var posProducts = from row in posBakerySet.Product where (pr.ProductID==row.ProductID) select row;
                        BakeryOrderSet.ProductRow posProduct;
                        if (posProducts.Count() > 0)
                        {
                            posProduct = posProducts.First();
                            posProduct.BeginEdit();
                            CopyProductRow(pr, posProduct);
                            //posProduct.ItemArray = pr.ItemArray;
                            posProduct.EndEdit();
                            updated++;
                        }
                        else
                        {
                            posProduct = posBakerySet.Product.NewProductRow();
                            posProduct.BeginEdit();
                            CopyProductRow(pr, posProduct);
                            posProduct.ProductID = pr.ProductID;
                            posProduct.EndEdit();
                            //posProduct.ItemArray = pr.ItemArray;
                            posBakerySet.Product.AddProductRow(posProduct);
                            added++;
                        }
                    }
                    // 刪除不在店長資料庫的
                    int deleted = 0;
                    foreach (var pr in posBakerySet.Product)
                    {
                        var Products = from row in m_OrderSet.Product where (pr.ProductID == row.ProductID) select row;
                        if (Products.Count() > 0) continue;
                        pr.Delete();
                        deleted++;
                    }
                    int succeed=adapter.Update(posBakerySet.Product);
                    Message("更新 " + updated.ToString() + "筆,新增 " + added.ToString() + "筆,刪除 " + deleted.ToString() + "筆=>寫出"+succeed.ToString()+"筆");
                    // 更新Photos\\Product
                    updated = added = deleted = 0;
                    string productsDir = dir + "\\Photos\\Products";
                    DirectoryInfo dirInfo = new DirectoryInfo(productsDir);
                    List<FileInfo> fileInfos=dirInfo.GetFiles("*.jpg").ToList<FileInfo>();
                    bool smallExist = Directory.Exists(productsDir + "\\Small");
                    if (mainFileInfos != null)   // 讀取照片檔案出錯了,就不更新
                    {
                        foreach (var mainFile in mainFileInfos)
                        {
                            string name = mainFile.Name;
                            string destName = productsDir + "\\" + name;
                            var dests = from fi in fileInfos where (fi.Name == name) select fi;
                            FileInfo fileInfo;
                            if (dests.Count() > 0)
                            {
                                fileInfo = dests.First();
                                if (fileInfo.CreationTime == mainFile.CreationTime)
                                {
                                    fileInfos.Remove(fileInfo);
                                    continue;       // 名字,創立時間都相同,視為相同
                                }
                                File.Delete(fileInfo.FullName);
                                fileInfos.Remove(fileInfo);
                                updated++;
                            }
                            else
                                added++;
#if (UseSQLServer)
                            CopyPhotoFromDB(mainFile.ProductID, destName);
#else
                            File.Copy(mainFile.FullName, destName);
#endif
                            File.SetCreationTime(destName, mainFile.CreationTime);
                            if (smallExist) File.Delete(productsDir + "\\Small\\" + name);
                        }
                        // 剩下的都要刪掉
                        foreach (FileInfo fi in fileInfos)
                        {
                            File.Delete(fi.FullName);
                            if (smallExist) File.Delete(productsDir + "\\Small\\" + fi.Name);
                            deleted++;
                        }
                        Message("更新 " + updated.ToString() + "張產品照片,新增 " + added.ToString() + "張,刪除 " + deleted.ToString() + "張");
                    }
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
        
        // 這個存在每個POS机, [BakeryOrder.BakeryConfig]
        BakeryConfig BakeryConfig = null;
        string BakeryConfigName = "FormCashier";
        string BakeryTableName  = "PrintTitle";
        string LetterTableName = "Letter";
        int LetterNumber = 7;
        string PrintBakeryConfig2Xml(string configName, string tableName,int posID,int storeID)
        {
            string title = textBoxPrintTitle.Text.TrimEnd();
            string addr  = textBoxPrintAddress.Text.TrimEnd();
            string tel   = textBoxPrintTelephone.Text.TrimEnd();
            string alipayTitle = textBoxAlipayTitle.Text.Trim();

            StringBuilder xml = new StringBuilder("<" + configName + " Name=\"" + tableName + "\">", 512);
            xml.Append("<Print Title=\""+title+"\" Addr=\""+addr+"\" Tel=\""+tel+"\"");
            xml.Append(" AlipayTitle=\""+alipayTitle+"\"");
            if (storeID > 0 && storeID <=999)
            {
                xml.Append(" StoreID=\"" + storeID.ToString() + "\"");
            }
            if (posID > 0 && posID <= 9)
            {
                xml.Append(" PosNo=\"" + posID.ToString() + "\"");
            }
            xml.Append(" />");
            xml.Append("</" + configName + ">");
            return xml.ToString();
        }

        void LoadBakeryConfig()
        {
            XmlNode root = BakeryConfig.Load(BakeryConfigName, BakeryTableName);
            if (root == null) return;
            XmlNode node = root.FirstChild;
            if (node == null) return;
            if (node.Name == "Print")
            {
                XmlAttribute attr;
                attr = node.Attributes["Title"];
                if (attr != null) textBoxPrintTitle.Text = attr.Value;
                attr = node.Attributes["Addr"];
                if (attr != null) textBoxPrintAddress.Text = attr.Value;
                attr = node.Attributes["Tel"];
                if (attr != null) textBoxPrintTelephone.Text = attr.Value;
                attr = node.Attributes["AlipayTitle"];
                if (attr != null) textBoxAlipayTitle.Text = attr.Value;
            }
        }

        class StrBool
        {
            public string Text;
            public bool   Checked;
            public StrBool(string text,bool b)
            {
                Text = text;
                Checked = b;
            }
        }
        string PrintLetterConfig2Xml(string configName, string tableName)
        {
            List<StrBool> list=new List<StrBool>();
            for(int i=1;i<=LetterNumber;i++)
            {
                Control[] controls;
                string controlName ="textBoxLetter"+i.ToString();
                string checkBoxName="checkBoxLetter"+i.ToString();
                controls=Controls.Find(checkBoxName,true);
                if (controls.Length>0 && controls[0].GetType()==typeof(CheckBox))
                {
                    CheckBox checkBox=(CheckBox)controls[0];
                    controls=Controls.Find(controlName,true);     // 這種找法,所以最多只能有9個 1-9
                    if (controls.Length>0 && controls[0].GetType()==typeof(TextBox))
                    {
                        TextBox textBox=(TextBox)controls[0]; 
                        StrBool sb=new StrBool(textBox.Text.TrimEnd(),checkBox.Checked);
                        list.Add(sb);
                    }
                }
            }
            StringBuilder xml = new StringBuilder("<" + configName + " Name=\"" + tableName + "\">", 512);
            foreach(StrBool sb in list)
            {
                xml.Append("<LetterText Checked=\"");
                if (sb.Checked) xml.Append("YES");
                else            xml.Append("NO");
                xml.Append("\">");
                xml.Append(sb.Text);
                xml.Append("</LetterText>");
            }
            xml.Append("</" + configName + ">");
            return xml.ToString();
        }


        void LoadLetterConfig()
        {
            XmlNode root = BakeryConfig.Load(BakeryConfigName, LetterTableName);
            if (root == null) return;
            XmlNode node = root.FirstChild;
            for (int i = 1; i <= LetterNumber; i++)
            {
                if (node == null) return;
                string textBoxName  = "textBoxLetter"  + i.ToString();
                Control[] controls= Controls.Find(textBoxName,true);
                if (controls.Length <= 0)
                {
                    MessageBox.Show("程式出錯,<" + textBoxName + "> 找不到!");
                    break;
                }
                if (controls[0].GetType() != typeof(TextBox))
                {
                    MessageBox.Show("程式出錯,<" + textBoxName + "> 不是TextBox!");
                    break;   
                }
                TextBox textBox=(TextBox)controls[0];
                if (node.Name == "LetterText")
                {
                    textBox.Text = node.InnerText;
                }
                string checkBoxName = "checkBoxLetter" + i.ToString();
                controls = Controls.Find(checkBoxName, true);
                if (controls.Length <= 0)
                {
                    MessageBox.Show("程式出錯,<" + checkBoxName + "> 找不到!");
                    break;
                }
                if (controls[0].GetType() != typeof(CheckBox))
                {
                    MessageBox.Show("程式出錯,<" + checkBoxName + "> 不是CheckBox!");
                    break;
                }
                CheckBox checkBox = (CheckBox)controls[0];
                XmlAttribute attr = node.Attributes["Checked"];
                if (attr != null && attr.Value == "YES")
                     checkBox.Checked = true;
                else checkBox.Checked = false;
                node = node.NextSibling;
            }   // end of for
        }

        private void btnSavePrintTitle_Click(object sender, EventArgs e)
        {
            string content=PrintBakeryConfig2Xml(BakeryConfigName,BakeryTableName,posID:0,storeID:m_StoreID);
            if (BakeryConfig.Save(BakeryConfigName, BakeryTableName, content))
                MessageBox.Show("本机存檔成功!");
        }

        private void btnSaveLetter_Click(object sender, EventArgs e)
        {
            tabPageReadme.Show();
            ClearMessage();
            string content = PrintLetterConfig2Xml(BakeryConfigName, LetterTableName);
            if (BakeryConfig.Save(BakeryConfigName,LetterTableName,content))
                Message("軟文設定本机存檔成功!"); 
            int i = 0;
            string dir;
            foreach (TextBox box in m_TextBoxPaths)
            {
                dir = box.Text.Trim();
                i++;
                if (dir.Length <= 0) continue;
                BakeryConfigMDB bakeryConfig = new BakeryConfigMDB(dir);
                Message("更新收銀机<" + i.ToString() + "> 軟文設定");
                bakeryConfig.Save(BakeryConfigName, LetterTableName, content);
            }
            Message("所有收銀机軟文設定都更新完畢!");
            Message("收銀机必需重新登入更新才會生效!");

        }

        // 各POS存的和店長處不同,多了PosNo
        private void btnSaveToAllPos_Click(object sender, EventArgs e)
        {
            int i = 0;
            string dir;
            string xmlContent;
            ClearMessage();
            foreach (TextBox box in m_TextBoxPaths)
            {
                dir = box.Text.Trim();
                i++;
                if (dir.Length <= 0) continue;
                BakeryConfigMDB bakeryConfig = new BakeryConfigMDB(dir);
                Message("更新收銀机<" + i.ToString() + "> 印表抬頭設定");
                xmlContent=PrintBakeryConfig2Xml(BakeryConfigName,BakeryTableName,posID:i,storeID:m_StoreID);
                bakeryConfig.Save(BakeryConfigName, BakeryTableName,xmlContent);
            }
            Message("所有收銀机都更新完畢!");
            Message("收銀机必需重新登入更新才會生效!");
        }

        #region ====== Print Function ======
        int PageIndex = -1;
        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            PrintAction action = e.PrintAction;
            PageIndex = 1;
        }

        Graphics m_Graphics = null;
        Font m_Font = null;
        Brush m_Brush = null;
        void PrintMoney(string str,decimal money, int x, int y, int width,string format="f2")
        {
            m_Graphics.DrawString(str, m_Font, m_Brush, new PointF(x, y));
            string sMoney=money.ToString(format);
            SizeF size = m_Graphics.MeasureString(sMoney, m_Font);
            x += (int)(width - size.Width);
            m_Graphics.DrawString(sMoney, m_Font, m_Brush, new PointF(x, y));
        }
  
        //private void Draw2Line(int x, int y, int x1, int y1, int offset)
        //{
        //    Pen pen = SystemPens.WindowText;
        //    m_Graphics.DrawLine(pen, x, y, x1, y1);
        //    m_Graphics.DrawLine(pen, x, y + offset, x1, y1 + offset);
        //}

        //private void Draw2Str(string str, int x, int y, int offset)
        //{
        //    m_Graphics.DrawString(str, m_Font, m_Brush, x, y);
        //    m_Graphics.DrawString(str, m_Font, m_Brush, x, y + offset);
        //}

        private void DrawLine(int x, int y, int x1, int y1)
        {
            Pen pen = SystemPens.WindowText;
            m_Graphics.DrawLine(pen, x, y, x1, y1);
        }

        private void DrawStr(string str, int x, int y)
        {
            m_Graphics.DrawString(str, m_Font, m_Brush, x, y);
        }


        private void GetStatics(out int orderCount, out decimal sum, out decimal averagePerOrder, out decimal cash, out decimal credit,out decimal alipay
                                ,out decimal couponA,out decimal couponB,out decimal wxpay,out Dictionary<int,decimal> cashiers)
        {
            sum = 0;
            orderCount = 0;
            cash = credit = alipay = couponA=couponB=wxpay=0;
            averagePerOrder = 0;
            cashiers = new Dictionary<int,decimal>();
            foreach (var Row in m_OrderSet.Order)
            {
                if (!Row.IsDeletedNull() && Row.Deleted) continue;
                int id=Row.CashierID;
                if (!cashiers.Keys.Contains(id))
                    cashiers.Add(id, 0m);
                decimal income = Row.Income;
                sum += income;
                orderCount++;
                if (Row.IsPayByNull() || Row.PayBy.Length <= 0)
                {
                    cashiers[id] = cashiers[id] + income;
                    cash += income;
                }
                else if (Row.PayBy[0] == 'B') credit += income;
                else if (Row.PayBy[0] == 'C') alipay += income;
                else if (Row.PayBy[0] == 'E') wxpay  += income;
                else if (Row.PayBy[0] == 'D')
                {
                    if (!Row.IsCouponIncomeNull() && Row.CouponIncome >= income) // 收券額大於應收,只計入應收
                        couponA += income;
                    else
                        couponA += Row.CouponIncome;
                    if (!Row.IsCashIncomeNull())
                    {
                        cashiers[id] += Row.CashIncome;
                        cash += Row.CashIncome;
                    }
                }
                else if (Row.PayBy[0] == 'F')
                {
                    if (!Row.IsCouponIncomeNull() && Row.CouponIncome >= income) // 收券額大於應收,只計入應收
                        couponB += income;
                    else
                        couponB += Row.CouponIncome;
                    if (!Row.IsCashIncomeNull())
                    {
                        cashiers[id] += Row.CashIncome;
                        cash += Row.CashIncome;
                    }
                }
                else
                {
                    cashiers[id] = cashiers[id] + income;
                    cash += income;
                }
            }
            if (orderCount!=0)
                averagePerOrder = sum / orderCount;
        }

        private void DrawStatics(int x, int y, int height, int width)
        {
            int no;
            decimal ave, sum, cash, credit, alipay,couponA,couponB,wxpay;
            Dictionary<int,decimal> cashiers;
            GetStatics(out no, out sum, out ave, out cash, out credit, out alipay,out couponA,out couponB,out wxpay,out  cashiers);
            int w = width / 2 - 30;
            PrintMoney("營收" , sum, x, y, w);
            y += height;
            PrintMoney("現金" , cash   , x , y               , w);
            PrintMoney("刷卡" , credit , x , y + height      , w);
            PrintMoney("支宝" , alipay , x , y + height * 2  , w);
            PrintMoney("微信" , wxpay  , x , y + height * 3  , w);
            PrintMoney("券A " , couponA, x , y + height * 4  , w);
            PrintMoney("券B " , couponB, x , y + height * 5  , w);
            PrintMoney("檔數" , no     , x , y + height * 6  , w, "f0");
            PrintMoney("單均" , ave    , x , y + height * 7  , w);

            int x1 = x + width / 2;
            int y1 = y;
            foreach (KeyValuePair<int, decimal> cashier in cashiers)
            {
                PrintMoney("收銀" + cashier.Key.ToString() , cashier.Value, x1, y1 ,w);
                y1 += height;
            }
        }


        const int LinePerPage = 50;
        const int NoPerBlock = 38;
        const int BlockWidth = 330;

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            m_Graphics = e.Graphics;
            PageSettings settings = e.PageSettings;
            Rectangle inner = e.MarginBounds;
            Rectangle outter = e.PageBounds;

            int start = (PageIndex - 1) * LinePerPage;
            int end = start + LinePerPage;
            e.HasMorePages = false;

            m_Font = new Font("細明體", 12.0f);
            m_Brush = SystemBrushes.WindowText;
            int x = inner.Left;
            int height = 23;
            int y = outter.Top + height;
            string sDate = m_Revenue.m_WorkingDay.ChineseDateString();
            string str = "     "+textBoxPrintTitle.Text +"  "+sDate+" 營收日報表";
            DrawStr(str, x, y);

            y = outter.Top + 2 * height;
            // DrawRectangle
            Pen pen = SystemPens.WindowText;
            int h = height * (NoPerBlock-7) + height;      // 不用到全頁,為了折成5吋高傳票
            int half = height + height * NoPerBlock / 2;
            int w = BlockWidth;
            int x1 = inner.Left;
            for (; x1 <= inner.Left + BlockWidth ; x1 += BlockWidth)
                    m_Graphics.DrawRectangle(pen, new Rectangle(x1, y - 2, w, h));   // 方框寬w 高h
            x1 = inner.Left;
            int y2 = half-height;
            DrawStr("收銀對帳單浮貼處"    , x1, y);
            DrawStr("銀行回單附於本表後方", x1, y2 - height);
            DrawStr("異常單說明"         , x1, y2);
            x1 = inner.Left + BlockWidth;
            DrawStr("刷卡日結單浮貼處"              , x1, y);
            DrawStr("以下數字若有手寫修改,需在旁簽名", x1, y2 - height);
            DrawLine(inner.Left, y2, inner.Left + w*2, y2);  // 中間橫線

            //y2 = y2 + height * 9;
            //DrawLine(x1, y2 - 2, x1 + w, y2 - 2);   // 統計那格上方那條橫線
            DrawStatics(x1, y2, height, w);

            y2 = y2 + height * 8;
//            DrawStr("單據 授權 電腦"  , x1, y2);
            y2 += height;
            DrawStr("各金額均核對無誤!", x1, y2);
            y2 += height;
            DrawLine(x1, y2, x1 + w, y2);           // 簽字上方那條橫線
//            DrawStr("店長簽字", x1, y2);
            x1 = x1 + w / 2;
            DrawLine(x1, y2, x1, y-2+h);  // 二人簽名中間那條直線  
            DrawStr("店長簽字", x1, y2);
    
        }

        private void printDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            PageIndex = -1;
        }
        #endregion ===============

        RevenueCalcBakery m_Revenue = null;
        private void btnDailyReport_Click(object sender, EventArgs e)
        {
            ClearMessage();
            try
            {
                HeaderAdapter.Fill(m_OrderSet.Header);
            }
            catch (Exception ex)
            {
                Message("讀取[BakeryOrder.Header]出錯:"+ex.Message,true);
                return;
            }
            DateTime today = todayPicker.Value.Date;
            m_Revenue = new RevenueCalcBakery(today, 0m);   // 先不管手續費,日報表不用印
            m_Revenue.LoadData(m_OrderSet, today.Month, today.Day);
            try
            {
                printDocument1.Print();
                Message("營收日報印表完成!");
            }
            catch (Exception ex)
            {
                Message("印表出錯:" + ex.Message,true);
            }
        }
                
        private void FormCashierAuthen_FormClosing(object sender, FormClosingEventArgs e)
        {
            //搶先在BindingSource被Dispose前,把DataGridView Dispose,否則Win8下先Dispose BindingSource會DataError 
            dgvCashier.Visible=false;
        }

  
        private void cashierDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var view=(DataGridView)sender;
            string colName=view.Columns[e.ColumnIndex].Name;
            if (colName == "ComboBoxAuthorizer") return;     // 授權者因為Operator重整過,錯誤就不管了
            Message("dgvCashier資料 第" + e.RowIndex.ToString() + "行" +
                  e.ColumnIndex.ToString() + "列錯誤!原因:" + e.Exception.Message);
        }

        private void btnCloundSyncAuto_Click(object sender, EventArgs e)
        {
            Form form = new FormAutoSync();
            form.ShowDialog();
        }
    }
}
