using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VoucherExpense
{
    public partial class FormOrder : Form
    {
        public FormOrder(BasicDataSet DS1,BasicDataSet.OrderRow Row,FormBrowse Browse,string PortName,bool CheckOnly)
        {
            DataSet1=DS1;
            CurrentOrder = Row;
            BrowseForm = Browse;
            ComPortName = PortName;
            FormOnlyForCheck = CheckOnly;
//          if (Row.RowState != DataRowState.Detached)
                OrderDetail = Row.GetOrderItemRows();       
//          else
//            OrderDetail = null;
            InitializeComponent();
            InitializeMenu();       // 必需放後面,因為有用到前面設定
            if (OrderDetail == null) return;    // 即使沒資料會是 OrderItemRow[0] 不會是null
            comboBoxGuoDi.SelectedIndex = MyConstant.MaxNo;
        }

        private System.Windows.Forms.Label[,] FoodMenu;
        private System.Windows.Forms.Label[,] FoodItemNo;
        private System.Windows.Forms.Label[] WineMenu;
        private System.Windows.Forms.Label[] WineItemNo;
        private int WineItemCount;
        class MenuItem
        {
            public int code;
            public string name;
            public double No;
            public double Price;
            public short classcode;
            public System.Windows.Forms.Label LabelNo;
            public double Money() { return Price * No; }
            public void SetZero() { No = 0; }
            public string NoToString() { return No.ToString();  }
        }
        private static class MyConstant
        {
            public static int FreePeopleNo  = 4;    // 鍋底免費人數
            public static int NapkinCode    = 6;    // 毛巾代碼
            public static int MaxNo = 6;
            public static int CanDiscountClass = 2;
            public static int TableNoStartCode = 400;
            public static int TitleDelayTime = 400;  
            public static int MaxTableNo = 44;
            public static int[] AddPeopleCode ={ 5, 5, 101, 0, 0 };
            public static int[] Code         = { 1, 2, 3 ,117, 128,253,4};
            public static int[] OneDollorCode ={ 131, 132, 133, 134,135,253, 4 };
            public static int ColaCode = 240;
        }
        private static class MyLayout
        {
            public static int NoX = 4;
            public static int NoY = 26;
            public static int OffsetX = 10;
            public static int OffsetY = 20;
            public static int NoWidth = 40;
        }

        private MenuItem[] GuoDi,OneDollorGuoDi;
        private GroupBox groupBoxWine;  // 用來複製 groupBoxFood
        private BasicDataSet DataSet1;
        private BasicDataSet.OrderRow CurrentOrder;
        private BasicDataSet.OrderItemRow[] OrderDetail;
        private FormBrowse BrowseForm;
        private string ComPortName = "COM1";
        private bool FormOnlyForCheck;

        private BasicDataSet.ProductRow GetFoodMenuItem(int x, int y)
        {
            foreach (BasicDataSet.ProductRow Row in DataSet1.Product.Rows)
            {
                if (Row.MenuX==x && Row.MenuY==y) return Row;
            }
            return null;
        }
        private BasicDataSet.ProductRow GetMenuItemByCode(int code)
        {
            foreach (BasicDataSet.ProductRow Row in DataSet1.Product.Rows)
            {
                if (Row.Code==code) return Row;
            }
            return null;
        }

        private GroupBox CopyGroupBox(GroupBox grBox,string name,string text)
        {
            GroupBox Box;
            Box             = new GroupBox();
            Box.Location    = new System.Drawing.Point(grBox.Location.X,grBox.Location.Y);
            Box.Size        = new System.Drawing.Size(grBox.Size.Width,grBox.Size.Height);
            Box.FlatStyle   = grBox.FlatStyle;
            Box.TabIndex    = grBox.TabIndex;
            Box.TabStop     = grBox.TabStop;
            Box.Name        = name;
            Box.Text        = text;
            return Box;
        }
        private void InitFoodMenu(GroupBox grBox)
        {
            int WidthX  = (grBox.Width  - MyLayout.OffsetX) / MyLayout.NoX;
            int HeightY = (grBox.Height - MyLayout.OffsetY) / MyLayout.NoY;
            FoodMenu    = new System.Windows.Forms.Label[MyLayout.NoX, MyLayout.NoY];
            FoodItemNo  = new System.Windows.Forms.Label[MyLayout.NoX, MyLayout.NoY];
            int x, y;
            for (x = 0; x < MyLayout.NoX; x++)
                for (y = 0; y < MyLayout.NoY; y++)
                {
                    int xx, yy;
                    xx = MyLayout.OffsetX + x * WidthX;
                    yy = MyLayout.OffsetY + y * HeightY;
                    Label l = new Label();
                    // Create No Label
                    FoodItemNo[x, y] = l;
                    l.Location = new System.Drawing.Point(xx + WidthX - MyLayout.NoWidth, yy);
                    l.Name = "FoodlabelX" + x.ToString() + "Y" + y.ToString();
                    l.Size = new System.Drawing.Size(MyLayout.NoWidth, HeightY - 2);
                    l.TabIndex = 0;
                    l.Text = "";
                    l.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    l.BorderStyle = BorderStyle.None;
                    grBox.Controls.Add(l);
                    // Create Name Label
                    l = new Label();
                    FoodMenu[x, y] = l;
                    l.AutoSize = false;
                    l.Location = new System.Drawing.Point(xx, yy);
                    l.Name = "FoodNoLabelX" + x.ToString() + "Y" + y.ToString();
                    l.Size = new System.Drawing.Size(WidthX - MyLayout.NoWidth - 2, HeightY - 2);
                    l.TabIndex = 0;
                    // 新細明體10pt
 //                   l.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                    

                    BasicDataSet.ProductRow Row = GetFoodMenuItem(x, y);
                    if (Row != null)
                    {
                        MenuItem content = new MenuItem();
                        content.No = 0;
                        content.Price = Row.Price;
                        content.code = Row.Code;
                        content.classcode = Row.Class;
                        content.LabelNo = FoodItemNo[x, y];
                        content.name = Row.Name.ToString();
                        l.Tag = content;
                        l.Text = content.name;
                        if (!FormOnlyForCheck)
                            l.MouseClick += new MouseEventHandler(this.MenuClick);
                    }
                    else
                    {
                        l.Tag = null;
                        l.Text = "";
                    }
                    l.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    l.BorderStyle = BorderStyle.None;
                    grBox.Controls.Add(l);
                }
        }

        private void SetWineMenuItem(BasicDataSet.ProductRow Row, int i, bool EnableOrNot, int WidthX, int HeightY, GroupBox grBox)
        {
            int x = i / MyLayout.NoY;
            int y = i % MyLayout.NoY;
            if (x >= MyLayout.NoX) return; // 資料太多了
            int xx, yy;
            xx = MyLayout.OffsetX + x * WidthX;
            yy = MyLayout.OffsetY + y * HeightY;
            Label l = new Label();
            // Create No Label
            WineItemNo[i] = l;
            l.Location = new System.Drawing.Point(xx + WidthX - MyLayout.NoWidth, yy);
            l.Name = "WinelabelX" + x.ToString() + "Y" + y.ToString();
            l.Size = new System.Drawing.Size(MyLayout.NoWidth, HeightY - 2);
            l.TabIndex = 0;
            l.Text = "";
            l.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            l.BorderStyle = BorderStyle.None;
            grBox.Controls.Add(l);
            // Create Name Label
            l = new Label();
            WineMenu[i] = l;
            l.AutoSize = false;
            l.Location = new System.Drawing.Point(xx, yy);
            l.Name = "WineNoLabelX" + x.ToString() + "Y" + y.ToString();
            l.Size = new System.Drawing.Size(WidthX - MyLayout.NoWidth - 2, HeightY - 2);
            l.TabIndex = 0;
            l.Enabled = EnableOrNot;
            // 新細明體10pt
            //                l.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));

            if (Row != null)
            {
                MenuItem content = new MenuItem();
                content.No = 0;
                content.Price = Row.Price;
                content.code = (int)Row.Code;
                content.classcode = Row.Class;
                content.LabelNo = WineItemNo[i];
                content.name = Row.Name.ToString();
                l.Tag = content;
                l.Text = content.name;
                if (!FormOnlyForCheck)
                    l.MouseClick += new MouseEventHandler(this.MenuClick);
            }
            else
            {
                l.Tag = null;
                l.Text = "";
            }
            l.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            l.BorderStyle = BorderStyle.None;
            grBox.Controls.Add(l);
        }

        private void InitWineMenu(GroupBox grBox)
        {
            int WidthX  = (grBox.Width  - MyLayout.OffsetX) / MyLayout.NoX;
            int HeightY = (grBox.Height - MyLayout.OffsetY) / MyLayout.NoY;
            WineMenu    = new System.Windows.Forms.Label[MyLayout.NoX* MyLayout.NoY];
            WineItemNo  = new System.Windows.Forms.Label[MyLayout.NoX* MyLayout.NoY];
            int i=0,n;
            // 先加鍋底
            for (n = 0; n < MyConstant.MaxNo; n++)
            {
                foreach (BasicDataSet.ProductRow Row in DataSet1.Product.Rows)
                {
                    if (Row.MenuX != -2) continue;  // MenuX -2 是酒水單的項目
                    if (Row.Code == MyConstant.Code[n])
                    {
                        SetWineMenuItem(Row, i, false, WidthX, HeightY, grBox);
                        i++;
                        break;
                    }
                }
            }
            // 再加其他項
            foreach (BasicDataSet.ProductRow Row in DataSet1.Product.Rows)
            {
                if (Row.MenuX != -2) continue;
                for (n = 0; n < MyConstant.MaxNo; n++)
                    if (Row.Code == MyConstant.Code[n]) break;
                if (n < MyConstant.MaxNo) continue;
                SetWineMenuItem(Row, i, true, WidthX, HeightY, grBox);
                i++;
            }
            WineItemCount = i;
        }
        private void InitGuoDi()
        {
            int i;
            GuoDi = new MenuItem[MyConstant.MaxNo];
            OneDollorGuoDi = new MenuItem[MyConstant.MaxNo];
            comboBoxGuoDi.Items.Clear();
            for (i = 0; i < MyConstant.MaxNo; i++)
            {
                MenuItem content = GuoDi[i] = new MenuItem();
                int code = MyConstant.Code[i];   
                BasicDataSet.ProductRow Row= GetMenuItemByCode(code);
                if (Row == null)
                {
                    MessageBox.Show("鍋底代碼 " + code.ToString() + ",資料庫內找不到");
                    continue;
                }
                content.No = 0;
                content.Price = Row.Price;
                content.code = (int)Row.Code;
                content.classcode = Row.Class;
                content.LabelNo = null;
                content.name = Row.Name;
                comboBoxGuoDi.Items.Add(Row.Name);

                // 一元鍋底
                content = OneDollorGuoDi[i]=new MenuItem();
                code = MyConstant.OneDollorCode[i];
                Row = GetMenuItemByCode(code);
                if (Row == null)
                {
                    MessageBox.Show("一元鍋底代碼 " + code.ToString() + ",資料庫內找不到");
                    checkOneDollor.Enabled = false;
                    continue;
                }
                content.No = 0;
                content.Price = Row.Price;
                content.code = (int)Row.Code;
                content.classcode = Row.Class;
                content.LabelNo = null;
                content.name = Row.Name;
            }
            comboBoxGuoDi.Items.Add("由酒水單点");
        }

        enum MenuList { food, wine };
        private void SetMenuTo(MenuList ml)
        {
            if (ml == MenuList.food)
            {
                groupBoxFood.Visible = true;
                groupBoxWine.Visible = false;
                btnSelectMenu.Text = "&Z 酒水單";
            }
            else
            {
                groupBoxFood.Visible = false;
                groupBoxWine.Visible = true;
                btnSelectMenu.Text = "&Z 點菜單";
            }

        }

        private void InitializeMenu()
        {
            this.SuspendLayout();

            InitFoodMenu(groupBoxFood); // 設定菜單
            groupBoxWine=CopyGroupBox(groupBoxFood,"groupBoxWine","酒水單");
            this.Controls.Add(groupBoxWine);
            InitWineMenu(groupBoxWine); // 設定酒水單
            InitGuoDi();                // 設定鍋底 ,鍋底要後設,因為有用到WineMenu
            SetMenuTo(MenuList.food);
            if (FormOnlyForCheck)
            {
                comboBoxGuoDi.Enabled = false;
                textBoxTable.Enabled = false;
                mtbOrderNo.Enabled = false;
                mtbInvoiceID.Enabled = false;
                mtbDeduct.Enabled = false;
                mtbServant.Enabled = false;
                comboBoxPeopleNo.Enabled = false;
                btnSave.Enabled = false;
                btnSaveBack.Enabled = false;
                checkDiscount.Enabled = false;
                textBoxCode.Visible = false;
                textBoxVolume.Visible = false;
                btnCodeEntry.Visible = false;
                mtbCreditID.Enabled = false;
            }
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void item2List(MenuItem item,MouseButtons btn)
        {
            if (item == null) return;
            if (btn == MouseButtons.Right)
            {
                if (item.No == 0) return;
                item.No-=1;
                if (item.No <= 0) item.No = 0;
                Sub2List(item);
            }
            else if (btn == MouseButtons.Left)
            {
                item.No+=1;
                Add2List(item,false);
            }
            return;
        }
       
        private void MenuClick(object sender, MouseEventArgs e)
        {
            Label l = (Label)sender;
            MenuItem item=(MenuItem)l.Tag;
            item2List(item,e.Button);
            if (item.No > 0)
                 l.BorderStyle = BorderStyle.FixedSingle;
            else l.BorderStyle = BorderStyle.None;
             if (item.No == 1 || item.No == 0)
                 item.LabelNo.Text = "";
             else
                 item.LabelNo.Text = item.NoToString();
         }

        private ListViewItem FindByCode(int code)
        {
            foreach (ListViewItem lvItem in lvNoDiscount.Items)
            {
                MenuItem item = (MenuItem)lvItem.Tag;
                if (code == item.code) return lvItem;
            }
            foreach (ListViewItem lvItem in lvCanDiscount.Items)
            {
                MenuItem item = (MenuItem)lvItem.Tag;
                if (code == item.code) return lvItem;
            }
            return null;
        }

        // ListView的tag 指向MenuItem
        private bool Sub2List(MenuItem item)
        {
            ListViewItem lvItem = FindByCode(item.code);
            if (lvItem == null) return false; // 沒東西刪
            if (item.No > 0)
            {
                lvItem.SubItems[2].Text = item.NoToString();
                lvItem.SubItems[3].Text = item.Money().ToString();
            }
            else
            {
                lvItem.Remove();
            }
            CalcTotal();
            return true;            // 刪除成功
        }
        private void Add2List(MenuItem item,bool AtFirst)
        {
            if (item.No == 0)
            {
                Sub2List(item);
                return;
            }

            ListViewItem lvItem=FindByCode(item.code);
            double no = item.No;
            
            double money = item.Money();
            if (lvItem != null)
            {
                lvItem.SubItems[2].Text = no.ToString();
                lvItem.SubItems[3].Text = money.ToString(); ;
            }
            else
            {
                if (item.classcode != MyConstant.CanDiscountClass)
                {
                    if (AtFirst)
                        lvItem = lvNoDiscount.Items.Insert(0, item.code.ToString());
                    else
                        lvItem = lvNoDiscount.Items.Add(item.code.ToString());
                }
                else
                {
                    if (AtFirst)
                        lvItem = lvCanDiscount.Items.Insert(0, item.code.ToString());
                    else
                        lvItem = lvCanDiscount.Items.Add(item.code.ToString());
                }
                lvItem.SubItems.Add(item.name);
                lvItem.SubItems.Add(no.ToString());
                lvItem.SubItems.Add(money.ToString());
            }
            lvItem.Tag = item;
            CalcTotal();
        }

        private double CalcTotal()
        {
            double total=0;
            double no=0,sum=0;
            foreach (ListViewItem lvItem in lvNoDiscount.Items)
            {
                MenuItem item = (MenuItem)lvItem.Tag;
                sum += item.Money();
                no+=item.No;
            }
            sum = Math.Round(sum, 1);
            lvNoDiscount.Columns[2].Text = no.ToString();
            lvNoDiscount.Columns[3].Text = sum.ToString();
            total = sum;
            sum = no = 0;
            foreach (ListViewItem lvItem in lvCanDiscount.Items)
            {
                MenuItem item = (MenuItem)lvItem.Tag;
                sum += item.Money();
                no+=item.No;
            }
            if (checkDiscount.Checked)
                sum = sum * 0.88;
            sum = Math.Round(sum, 0, MidpointRounding.AwayFromZero);
//            sum = Math.Round(sum, 1);  銀行家捨入
            lvCanDiscount.Columns[2].Text = no.ToString();
            lvCanDiscount.Columns[3].Text = sum.ToString();
            total += sum ;
            if (mtbDeduct.Text != "")
            {
                int deduct = Int32.Parse(mtbDeduct.Text);
                total -= deduct;
            }
            total = Math.Round(total,0,MidpointRounding.AwayFromZero);
            labelTotal.Text = total.ToString();
            return total;
        }

        private char EAN13_CheckSum(string Code)
        {
            if (Code.Length != 12) return 'F';
            int i,checksum,weight;
            for(checksum=0,i=0;i<12;i++)
            {
                if (!char.IsDigit(Code[i])) return 'F';
                if ((i %2)==0) weight=1;
                else weight=3;
                checksum+=(Code[i]-'0')*weight;
            }
            checksum%=10;
            checksum = (10-checksum)+'0';
            return( (char)checksum);
        }
        
        private bool WineLabelTagCodeIs(Label menu,int code)
        {
            if (menu != null)
            {
                object obj = menu.Tag;
                if (obj != null)
                {
                    MenuItem item = (MenuItem)obj;
                    if (item.code == code) return true;
                }
            }
            return false;
        }

        private void EnableGuoDiInWineMenu(bool Enable)
        {
            if (Enable)
            {
                int co;
                for (int i = 0; i < MyConstant.MaxNo; i++)
                {
                    co=GuoDi[i].code;
                    for (int j = 0; j < WineItemCount; j++)
                    {
                        if (WineLabelTagCodeIs(WineMenu[j],co)) 
                        {
                            WineMenu[j].Enabled = true;
                            break;
                        }
                    }
                }
                for (int i = 0; i < MyConstant.MaxNo; i++)
                {
                    co=OneDollorGuoDi[i].code;
                    for (int j = WineItemCount-1; j >=0; j--)  // 反過來的,因為一元鍋底加在後面
                    {
                        if (WineLabelTagCodeIs(WineMenu[j],co))
                        {
                            WineMenu[j].Enabled = true;
                            break;
                        }
                    }
                }
                return;
            }
            Label l;
            for (int i = 0; i < MyConstant.MaxNo; i++)
            {
                int co = GuoDi[i].code;
                for (int j = 0; j < WineItemCount; j++)
                {
                    if (WineLabelTagCodeIs(WineMenu[j], co))
                    {
                        l = WineMenu[j];
                        ((MenuItem)l.Tag).SetZero();
                        l.Enabled = false;
                        l.BorderStyle = BorderStyle.None;
                        WineItemNo[j].Text = "";
                        break;
                    }
                }
            }
            for (int i = 0; i < MyConstant.MaxNo; i++)  
            {
                int co = OneDollorGuoDi[i].code;
                for (int j = WineItemCount - 1; j >= 0; j--)
                {
                    if (WineLabelTagCodeIs(WineMenu[j], co))
                    {
                        l = WineMenu[j];
                        ((MenuItem)l.Tag).SetZero();
                        l.Enabled = false;
                        l.BorderStyle = BorderStyle.None;
                        WineItemNo[j].Text = "";
                        break;
                    }
                }
            }
        }

        private void comboBoxGuoDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = comboBoxGuoDi.SelectedIndex;
            if (n < 0 || n > MyConstant.MaxNo) return;  // bug 或清 0
            foreach(MenuItem item in GuoDi)
            {
                item.SetZero();
                while (Sub2List(item)) ;
            }
            foreach (MenuItem item in OneDollorGuoDi)
            {
                item.SetZero();
                while (Sub2List(item)) ;
            }
            if (n == MyConstant.MaxNo)  // 由酒水單點
            {
                EnableGuoDiInWineMenu(true);
                if (checkOneDollor.Checked)          // 因為 checked有呼叫這,避免circular
                    checkOneDollor.Checked = false;  // 由酒水單點一元鍋底沒意義
                checkOneDollor.Enabled = false;
            }
            else
            {
                checkOneDollor.Enabled = true;
                EnableGuoDiInWineMenu(false);
                if (checkOneDollor.Checked)
                {
                    OneDollorGuoDi[n].No = 1;
                    Add2List(OneDollorGuoDi[n], true);
                }
                else
                {
                    GuoDi[n].No = 1;
                    Add2List(GuoDi[n], true);
                }
                comboBoxPeopleNo_SelectedIndexChanged(null, null);  // 自動設毛巾和帶人數
            }
        }
        private void textBoxTable_Validating(object sender, CancelEventArgs e)
        {
            string str = textBoxTable.Text.Trim();
            if (str.Length == 0) return;    // 要打單再說
            textBoxTable.Text = str;
/*
            if (!Char.IsLetter(str[0]))
            {
                MessageBox.Show("第一個字必需是英文");
                textBoxTable.Focus();
                textBoxTable.Select(0, 1);
            }
            else
 */
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (!Char.IsLetterOrDigit(str[i]))
                    {
                        MessageBox.Show("必需是英文或數字");
                        textBoxTable.Focus();
                        textBoxTable.Select(i, 1);
                        return;
                    }
                }
            }
        }

        private bool m_DisablePeopleNoSelect = true;
        private void comboBoxPeopleNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_DisablePeopleNoSelect) return;    // Load時不能來改
            // 毛巾的Code NapkinCode
            try
            {
                int no = comboBoxPeopleNo.SelectedIndex;
                if (no>0)          // 設毛巾人數
                    Row2ListAndMenu(MyConstant.NapkinCode, no);
                int i = comboBoxGuoDi.SelectedIndex;
                if (i < MyConstant.MaxNo)  // 若不是自酒水單帶,就要算加人數鍋底
                {
                    // 先清掉
                    int n=MyConstant.AddPeopleCode[i];
                    foreach (int code in MyConstant.AddPeopleCode)
                    {
                        if (code == 0) continue;
                        Row2ListAndMenu(code, 0);
                    }
                    // 一元鍋底時,不算加人數
                    if (!checkOneDollor.Checked)
                    {
                        if (no > MyConstant.FreePeopleNo)
                        {
                            if (n != 0)
                                Row2ListAndMenu(n, no - MyConstant.FreePeopleNo);
                        }
                    }
                }
            }
            catch { }
        }

        private void btnSelectMenu_Click(object sender, EventArgs e)
        {
                 SetMenuTo(groupBoxFood.Visible?MenuList.wine:MenuList.food);
        }

        private void ShowTime()
        {
            labelSaveTime.Text = "存單時間 ";
            if (!CurrentOrder.IsSaveTimeNull())
                if (CurrentOrder.SaveTime.Year >= 2007)
                    labelSaveTime.Text += CurrentOrder.SaveTime.ToShortTimeString();
            labelPrintTime.Text = "打單時間 ";
            if (!CurrentOrder.IsPrintTimeNull())
                if (CurrentOrder.PrintTime.Year >= 2007)
                    labelPrintTime.Text += CurrentOrder.PrintTime.ToShortTimeString();
        }


        private void FormOrder_Load(object sender, EventArgs e)
        {
            orderTableAdapter.Connection = MapPath.BasicConnection;
            this.orderTableAdapter.Fill(this.basicDataSet.Order);
            try { textBoxTable.Text = CurrentOrder.TableID;   }
            catch{}
            try { comboBoxPeopleNo.Text = CurrentOrder.PeopleNo.ToString(); }
            catch { }
            try { mtbServant.Text = CurrentOrder.ServantID.ToString(); }
            catch { }
            try { mtbOrderNo.Text = CurrentOrder.OrderID.ToString(); }
            catch { }
            try { mtbInvoiceID.Text = CurrentOrder.InvoiceID.ToString(); }
            catch { }
            ShowTime();
            try { mtbDeduct.Text = ((int)CurrentOrder.Deduct).ToString(); }
            catch { }
            try 
            {
                if (CurrentOrder.IsCreditIDNull() || CurrentOrder.CreditID == 0)
                    mtbCreditID.Text = "";
                else
                    mtbCreditID.Text = CurrentOrder.CreditID.ToString();
            }
            catch { }
            try { if (CurrentOrder.DiscountRate != 1M) checkDiscount.Checked = true; }
            catch { }
            if (checkDiscount.Checked)
            {
                btnPrintDiscountPart.Enabled = true;
                btnPrintUndiscountPart.Enabled = true;
            }
            else
            {
                btnPrintDiscountPart.Enabled = false;
                btnPrintUndiscountPart.Enabled = false;
            }
            foreach (BasicDataSet.OrderItemRow Ro in OrderDetail)
                Row2ListAndMenu(Ro.Code, (double)Ro.No);
            m_DisablePeopleNoSelect = false;
        }

        private void Row2ListAndMenu(int Code, double No)
        {
            Label l = FindMenuLabel(Code);
            if (l == null) return;
            MenuItem item = (MenuItem)l.Tag;
            if (item == null) return;
            item.No = No;
            if (item.No > 0) l.BorderStyle = BorderStyle.FixedSingle;
            else l.BorderStyle = BorderStyle.None;
            if (item.No > 1) item.LabelNo.Text = item.NoToString();
            else item.LabelNo.Text = "";
            Add2List(item, false);
        }

        private Label FindMenuLabel(int Code)
        {
            MenuItem item;
            foreach (Label l in WineMenu)
            {
                if (l == null) break;
                item = (MenuItem)l.Tag;
                if (item == null) continue;
                if (item.code == Code) return l;
            }
            foreach (Label l in FoodMenu)
            {
                if (l == null) continue;   // 因為Food可能有空洞所以continue;
                item = (MenuItem)l.Tag;
                if (item == null) continue;
                if (item.code == Code) return l;
            }
            return null;
        }

        private bool IsGuoDi(int code)
        {
            foreach (int i in MyConstant.Code)
                if (code == i) return true;
            foreach (int i in MyConstant.OneDollorCode)
                if (code == i) return true;
            return false;
        }

        // 0 相同 1 小可樂不同 2 毛巾不同 3 都不同
        private int  PeopleNoDifferent()
        {
            int no = 0;
            int colaNo = 0;     
            int napkinNo = 0;
            try
            {
                no = comboBoxPeopleNo.SelectedIndex;
            }
            catch { }
            foreach (ListViewItem item in lvNoDiscount.Items)
            {
                MenuItem mItem = (MenuItem)item.Tag;
                if      (mItem.code == MyConstant.ColaCode  ) colaNo   =(int)mItem.No;
                else if (mItem.code == MyConstant.NapkinCode) napkinNo =(int)mItem.No;
            }
            if (no != colaNo && no != napkinNo) return 3;
            if (no != colaNo  )                 return 1;
            if (no != napkinNo)                 return 2;
            return 0;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lvNoDiscount.Items.Clear();
            for(int x=0;x<MyLayout.NoX;x++)
                for (int y = 0; y < MyLayout.NoY; y++)
                {
                    FoodMenu[x, y].BorderStyle = BorderStyle.None;
                    FoodItemNo[x, y].Text = "";
                    if (FoodMenu[x, y].Tag != null)
                        ((MenuItem)FoodMenu[x, y].Tag).SetZero();
                }
            for (int i = 0; i < MyLayout.NoX * MyLayout.NoY; i++)
            {
                if (WineMenu[i] == null) break;
                WineMenu[i].BorderStyle = BorderStyle.None;
                WineItemNo[i].Text = "";
                if (WineMenu[i].Tag!=null)
                    ((MenuItem)WineMenu[i].Tag).SetZero();
            }
            labelTotal.Text = "";
            comboBoxGuoDi.SelectedIndex = -1;
            foreach (MenuItem item in GuoDi) item.SetZero();
            foreach (MenuItem item in OneDollorGuoDi) item.SetZero();
            mtbOrderNo.Text = "";
            textBoxTable.Text = "";
        }

        private long Int64Parse(string str)
        {
            if (str == null) return 0;
            long i;
            try
            {
                i = Int64.Parse(str);
                return i;
            }
            catch
            {
                return 0;
            }
        }

        private int Int32Parse(string str)
        {
            if (str == null) return 0;
            int i;
            try
            {
                i = Int32.Parse(str);
                return i;
            }
            catch
            {
                return 0;
            }
        }

        void SetOrderItemFromListViewItem(BasicDataSet.OrderItemRow Row,ListViewItem lvItem,int i)
        {
            MenuItem item = (MenuItem)lvItem.Tag;
            Row.No = (decimal)item.No;
            Row.Code = item.code;
            Row.Price =(decimal)item.Price;
            Row.Index = (short)i;
            if (item.classcode == MyConstant.CanDiscountClass )
                Row.Discount = true;
            else Row.Discount = false;
        }

        private void btnSaveBack_Click(object sender, EventArgs e)
        {
            SaveOrder();
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveOrder();
        }

        private void SaveOrder()
        {
            if (FormOnlyForCheck) return;  
            bool IsNewRecord = (CurrentOrder.RowState == DataRowState.Detached);
            CurrentOrder.InvoiceID = Int32Parse(mtbInvoiceID.Text);
            CurrentOrder.ServantID = Int32Parse(mtbServant.Text);
            CurrentOrder.PeopleNo = (byte)Int32Parse(comboBoxPeopleNo.Text);
            CurrentOrder.OrderID = Int32Parse(mtbOrderNo.Text);
            CurrentOrder.Deduct = Int32Parse(mtbDeduct.Text);
            CurrentOrder.Income = (decimal)CalcTotal();
            CurrentOrder.CreditID = Int64Parse(mtbCreditID.Text);
            if (checkDiscount.Checked)
                CurrentOrder.DiscountRate = 0.88M;
            else
                CurrentOrder.DiscountRate = 1M;
            CurrentOrder.TableID = textBoxTable.Text;
            if (CurrentOrder.IsSaveTimeNull())
                CurrentOrder.SaveTime = DateTime.Now;
            if (CurrentOrder.SaveTime.Year < 2007)     // 初值設成 2000.1.1
                CurrentOrder.SaveTime= DateTime.Now;

            try
            {
                if (IsNewRecord)  // get autonumber 處理如此複雜,只好忍痛把AutoNumber 拿掉
                    DataSet1.Order.AddOrderRow(CurrentOrder);
                // Update OrderItem
                try
                {
                    int count = lvNoDiscount.Items.Count + lvCanDiscount.Items.Count;
                    BasicDataSet.OrderItemRow[] ItemRows=new BasicDataSet.OrderItemRow[count];
   //               OrderDetail = CurrentOrder.GetOrderItemRows();
                    if (OrderDetail!=null)
                        foreach (BasicDataSet.OrderItemRow Row in OrderDetail)
                        {
                            if (Row.Index < count)
                            {
//                              Row.SetParentRow(CurrentOrder);
                                ItemRows[Row.Index] = Row;
                            }
                            else Row.Delete();
                        }
                    int i = 0;
                    foreach (ListViewItem lvItem in lvCanDiscount.Items)
                    {
                        if (i >= count) break;  // 不應發生,以防萬一
                        if (ItemRows[i] == null)
                        {
                            BasicDataSet.OrderItemRow Row = DataSet1.OrderItem.NewOrderItemRow();
                            SetOrderItemFromListViewItem(Row, lvItem, i);
                            Row.SetParentRow(CurrentOrder);
                            DataSet1.OrderItem.AddOrderItemRow(Row);
                            ItemRows[i] = Row;
                        }
                        else
                        {
                            ItemRows[i].BeginEdit();
                            SetOrderItemFromListViewItem(ItemRows[i], lvItem, i);  // 原始的資料應該己經設了ParentRow
                            ItemRows[i].EndEdit();
                        }
                        i++;
                    }
                    foreach (ListViewItem lvItem in lvNoDiscount.Items)
                    {
                        if (i >= count) break;  // 不應發生,以防萬一
                        if (ItemRows[i] == null)
                        {
                            BasicDataSet.OrderItemRow Row = DataSet1.OrderItem.NewOrderItemRow();
                            SetOrderItemFromListViewItem(Row, lvItem, i);
                            Row.SetParentRow(CurrentOrder);
                            DataSet1.OrderItem.AddOrderItemRow(Row);
                            ItemRows[i] = Row;
                        }
                        else
                        {
                            ItemRows[i].BeginEdit();
                            SetOrderItemFromListViewItem(ItemRows[i], lvItem, i);  // 原始的資料應該己經設了ParentRow
                            ItemRows[i].EndEdit();
                        }
                        i++;
                    }

                    OrderDetail = ItemRows;
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message+"<OrderItem更新出錯>");
                    return;
                }
            }
            catch (System.Exception E)
            {
                MessageBox.Show(E.Message+"  <Order更新出錯>");
                return;
            }
            try
            {
                BasicDataSetTableAdapters.OrderTableAdapter adapter = new BasicDataSetTableAdapters.OrderTableAdapter();
                adapter.Connection = MapPath.BasicConnection;
                adapter.ClearBeforeFill = true;
                adapter.Update(CurrentOrder);
                CurrentOrder.AcceptChanges();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message + "Update(CurrentOrder) 出錯");
                return;
            }
            try // 必須把TableAdapter偵側并行違規關掉,否則第二次就存不入
            {
                BasicDataSetTableAdapters.OrderItemTableAdapter adapterItem = new BasicDataSetTableAdapters.OrderItemTableAdapter();
                adapterItem.ClearBeforeFill = true;
                adapterItem.Connection = MapPath.BasicConnection;
                adapterItem.Update(OrderDetail);
                DataSet1.OrderItem.AcceptChanges();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message + "Update(OrderItem)出錯");
            }
        }
        
        private void checkDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDiscount.Checked)
            {
                btnPrintDiscountPart.Enabled = true;
                btnPrintUndiscountPart.Enabled = true;
            }
            else
            {
                btnPrintDiscountPart.Enabled = false;
                btnPrintUndiscountPart.Enabled = false;
            }
            CalcTotal();
        }

        private void maskedTextBoxDeduct_Validated(object sender, EventArgs e)
        {
            CalcTotal();
        }

        private void FormOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            BrowseForm.Table2ListView();
            BrowseForm.WindowState = FormWindowState.Maximized;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DoTitleDelay(ref bool titleDelayed)
        {
            if (!titleDelayed)
            {
                titleDelayed = true;
                System.Threading.Thread.Sleep(MyConstant.TitleDelayTime);
            }
        }

        private void btnCodeEntry_Click(object sender, EventArgs e)
        {
            int code;
            decimal volume;
            double d;
            try
            {
                code = Int32.Parse(textBoxCode.Text);
            }
            catch
            {
                MessageBox.Show("代碼只能打入數字");
                textBoxCode.Focus();
                return;
            }
            try
            {
                volume = decimal.Parse(textBoxVolume.Text);
                d =(double)decimal.Round(volume,1);
            }
            catch 
            {
                MessageBox.Show("只能輸入數字和小數點");
                textBoxVolume.Focus();
                return;
            }
            Label l = FindMenuLabel(code);
            if (l == null)
            {
                MessageBox.Show("代碼錯誤,無此商品");
                textBoxCode.Focus();
                return;
            }
            MenuItem item = (MenuItem)l.Tag;
            if (item == null) return;
            item.No = d;
            if (item.No > 0) l.BorderStyle = BorderStyle.FixedSingle;
            else l.BorderStyle = BorderStyle.None;
            if (item.No > 1) item.LabelNo.Text = item.No.ToString();
            else item.LabelNo.Text = "";
            Add2List(item, false);
            textBoxCode.Text = "";
            textBoxVolume.Text = "1";
        }


        private void lvCanDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            ListView listView = (ListView)sender;
            if (listView.SelectedItems.Count <= 0) return;
            if (Keys.Delete == e.KeyData)
            {
                MenuItem item = (MenuItem)(listView.SelectedItems[0].Tag);
                Row2ListAndMenu(item.code, 0);
            }
        }

        private void lvNoDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            ListView listView = (ListView)sender;
            if (listView.SelectedItems.Count <= 0) return;
            if (Keys.Delete == e.KeyData)
            {
                MenuItem item = (MenuItem)(listView.SelectedItems[0].Tag);
                if (item.code == MyConstant.NapkinCode)
                {
                    MessageBox.Show("毛巾請用別的方式刪!");
                    return;
                }
                foreach (int code in MyConstant.AddPeopleCode)
                {
                    if (code == item.code)
                    {
                        MessageBox.Show("加人數請用別的方式刪!");
                        return;
                    }
                }
                foreach (int code in MyConstant.Code)
                {
                    if (code == item.code)
                    {
                        MessageBox.Show("鍋底請用別的方式刪!");
                        return;
                    }
                }
                foreach (int code in MyConstant.OneDollorCode)
                {
                    if (code == item.code)
                    {
                        MessageBox.Show("鍋底請用別的方式刪!");
                        return;
                    }
                }
                Row2ListAndMenu(item.code, 0);
            }
        }

        private void checkOneDollor_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBoxGuoDi.SelectedIndex != MyConstant.MaxNo)  // 理論上己經disable了,不可能叫到,for safe sake
            {
                comboBoxGuoDi_SelectedIndexChanged(null, null);
            }
        }

        private void checkBoxCreditCard_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = sender as CheckBox;
            mtbCreditID.Visible = box.Checked;
        }


    }
}