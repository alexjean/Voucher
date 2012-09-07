﻿namespace VoucherExpense
{
    partial class FormHome
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
            this.menu1 = new System.Windows.Forms.MenuStrip();
            this.基本資料MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.員工MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.供應商MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.食材表MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.會計科目MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.銀行帳號MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.傳票設定MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.操作員MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.環境設定MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.年初開帳MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.編修菜單ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.費用MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.進貨MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.收入MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.月報ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.明細ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.銀行MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.細目編修ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.匯入XLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.合併銀行細目MdbMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.會計MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.損益報表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.轉帳傳票MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.合併傳票MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.庫存MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.耗料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.盤點ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.人事MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.考勤MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.排班表MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.資料卡MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.月報表MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.統計廠商MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.付款總表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.進銷比ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查核MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查核費用MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查核進貨MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查核傳票MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.鎖定資料庫MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.備份資料庫ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改密碼MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.headerTableAdapter = new VoucherExpense.VEDataSetTableAdapters.HeaderTableAdapter();
            this.編修部門MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // menu1
            // 
            this.menu1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menu1.BackgroundImage")));
            this.menu1.Font = new System.Drawing.Font("細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.menu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.基本資料MenuItem,
            this.費用MenuItem,
            this.進貨MenuItem,
            this.收入MenuItem,
            this.銀行MenuItem,
            this.會計MenuItem,
            this.庫存MenuItem,
            this.人事MenuItem,
            this.月報表MenuItem,
            this.查核MenuItem,
            this.修改密碼MenuItem});
            this.menu1.Location = new System.Drawing.Point(0, 0);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(912, 24);
            this.menu1.TabIndex = 6;
            this.menu1.Text = "menuStrip1";
            // 
            // 基本資料MenuItem
            // 
            this.基本資料MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.員工MenuItem,
            this.供應商MenuItem,
            this.食材表MenuItem,
            this.會計科目MenuItem,
            this.銀行帳號MenuItem,
            this.傳票設定MenuItem,
            this.操作員MenuItem,
            this.環境設定MenuItem,
            this.年初開帳MenuItem,
            this.編修菜單ToolStripMenuItem,
            this.編修部門MenuItem});
            this.基本資料MenuItem.Name = "基本資料MenuItem";
            this.基本資料MenuItem.Size = new System.Drawing.Size(84, 20);
            this.基本資料MenuItem.Text = "基本資料";
            // 
            // 員工MenuItem
            // 
            this.員工MenuItem.Name = "員工MenuItem";
            this.員工MenuItem.Size = new System.Drawing.Size(152, 22);
            this.員工MenuItem.Text = "員工";
            this.員工MenuItem.Click += new System.EventHandler(this.員工MenuItem_Click);
            // 
            // 供應商MenuItem
            // 
            this.供應商MenuItem.Name = "供應商MenuItem";
            this.供應商MenuItem.Size = new System.Drawing.Size(152, 22);
            this.供應商MenuItem.Text = "供應商";
            this.供應商MenuItem.Click += new System.EventHandler(this.供應商MenuItem_Click);
            // 
            // 食材表MenuItem
            // 
            this.食材表MenuItem.Name = "食材表MenuItem";
            this.食材表MenuItem.Size = new System.Drawing.Size(152, 22);
            this.食材表MenuItem.Text = "食材表";
            this.食材表MenuItem.Click += new System.EventHandler(this.食材表MenuItem_Click);
            // 
            // 會計科目MenuItem
            // 
            this.會計科目MenuItem.Name = "會計科目MenuItem";
            this.會計科目MenuItem.Size = new System.Drawing.Size(152, 22);
            this.會計科目MenuItem.Text = "會計科目";
            this.會計科目MenuItem.Click += new System.EventHandler(this.會計科目MenuItem_Click);
            // 
            // 銀行帳號MenuItem
            // 
            this.銀行帳號MenuItem.Name = "銀行帳號MenuItem";
            this.銀行帳號MenuItem.Size = new System.Drawing.Size(152, 22);
            this.銀行帳號MenuItem.Text = "銀行帳號";
            this.銀行帳號MenuItem.Visible = false;
            this.銀行帳號MenuItem.Click += new System.EventHandler(this.銀行帳號ToolStripMenuItem_Click);
            // 
            // 傳票設定MenuItem
            // 
            this.傳票設定MenuItem.Name = "傳票設定MenuItem";
            this.傳票設定MenuItem.Size = new System.Drawing.Size(152, 22);
            this.傳票設定MenuItem.Text = "傳票設定";
            this.傳票設定MenuItem.Click += new System.EventHandler(this.傳票設定MenuItem_Click);
            // 
            // 操作員MenuItem
            // 
            this.操作員MenuItem.Name = "操作員MenuItem";
            this.操作員MenuItem.Size = new System.Drawing.Size(152, 22);
            this.操作員MenuItem.Text = "帳號權限";
            this.操作員MenuItem.Click += new System.EventHandler(this.操作員MenuItem_Click);
            // 
            // 環境設定MenuItem
            // 
            this.環境設定MenuItem.Name = "環境設定MenuItem";
            this.環境設定MenuItem.Size = new System.Drawing.Size(152, 22);
            this.環境設定MenuItem.Text = "硬體環境";
            this.環境設定MenuItem.Click += new System.EventHandler(this.環境設定MenuItem_Click);
            // 
            // 年初開帳MenuItem
            // 
            this.年初開帳MenuItem.Name = "年初開帳MenuItem";
            this.年初開帳MenuItem.Size = new System.Drawing.Size(152, 22);
            this.年初開帳MenuItem.Text = "年初開帳";
            this.年初開帳MenuItem.Click += new System.EventHandler(this.年初開帳ToolStripMenuItem_Click);
            // 
            // 編修菜單ToolStripMenuItem
            // 
            this.編修菜單ToolStripMenuItem.Name = "編修菜單ToolStripMenuItem";
            this.編修菜單ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.編修菜單ToolStripMenuItem.Text = "編修菜單";
            this.編修菜單ToolStripMenuItem.Click += new System.EventHandler(this.編點菜單ToolStripMenuItem_Click);
            // 
            // 費用MenuItem
            // 
            this.費用MenuItem.Name = "費用MenuItem";
            this.費用MenuItem.Size = new System.Drawing.Size(52, 20);
            this.費用MenuItem.Text = "費用";
            this.費用MenuItem.Click += new System.EventHandler(this.費用MenuItem_Click);
            // 
            // 進貨MenuItem
            // 
            this.進貨MenuItem.Name = "進貨MenuItem";
            this.進貨MenuItem.Size = new System.Drawing.Size(52, 20);
            this.進貨MenuItem.Text = "進貨";
            this.進貨MenuItem.Click += new System.EventHandler(this.進貨MenuItem_Click);
            // 
            // 收入MenuItem
            // 
            this.收入MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.月報ToolStripMenuItem,
            this.明細ToolStripMenuItem});
            this.收入MenuItem.Name = "收入MenuItem";
            this.收入MenuItem.Size = new System.Drawing.Size(52, 20);
            this.收入MenuItem.Text = "收入";
            // 
            // 月報ToolStripMenuItem
            // 
            this.月報ToolStripMenuItem.Name = "月報ToolStripMenuItem";
            this.月報ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.月報ToolStripMenuItem.Text = "月報";
            this.月報ToolStripMenuItem.Click += new System.EventHandler(this.月報ToolStripMenuItem_Click);
            // 
            // 明細ToolStripMenuItem
            // 
            this.明細ToolStripMenuItem.Name = "明細ToolStripMenuItem";
            this.明細ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.明細ToolStripMenuItem.Text = "明細";
            this.明細ToolStripMenuItem.Click += new System.EventHandler(this.明細ToolStripMenuItem_Click);
            // 
            // 銀行MenuItem
            // 
            this.銀行MenuItem.Checked = true;
            this.銀行MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.銀行MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.細目編修ToolStripMenuItem,
            this.匯入XLSToolStripMenuItem,
            this.合併銀行細目MdbMenuItem});
            this.銀行MenuItem.Name = "銀行MenuItem";
            this.銀行MenuItem.Size = new System.Drawing.Size(52, 20);
            this.銀行MenuItem.Text = "銀行";
            // 
            // 細目編修ToolStripMenuItem
            // 
            this.細目編修ToolStripMenuItem.Name = "細目編修ToolStripMenuItem";
            this.細目編修ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.細目編修ToolStripMenuItem.Text = "細目編修";
            this.細目編修ToolStripMenuItem.Click += new System.EventHandler(this.細目編修ToolStripMenuItem_Click);
            // 
            // 匯入XLSToolStripMenuItem
            // 
            this.匯入XLSToolStripMenuItem.Name = "匯入XLSToolStripMenuItem";
            this.匯入XLSToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.匯入XLSToolStripMenuItem.Text = "匯入 xls";
            this.匯入XLSToolStripMenuItem.Click += new System.EventHandler(this.匯入XLSToolStripMenuItem_Click);
            // 
            // 合併銀行細目MdbMenuItem
            // 
            this.合併銀行細目MdbMenuItem.Name = "合併銀行細目MdbMenuItem";
            this.合併銀行細目MdbMenuItem.Size = new System.Drawing.Size(148, 22);
            this.合併銀行細目MdbMenuItem.Text = "合併 mdb";
            this.合併銀行細目MdbMenuItem.Click += new System.EventHandler(this.合併銀行細目MdbMenuItem_Click);
            // 
            // 會計MenuItem
            // 
            this.會計MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.損益報表ToolStripMenuItem,
            this.轉帳傳票MenuItem,
            this.合併傳票MenuItem});
            this.會計MenuItem.Name = "會計MenuItem";
            this.會計MenuItem.Size = new System.Drawing.Size(52, 20);
            this.會計MenuItem.Text = "會計";
            // 
            // 損益報表ToolStripMenuItem
            // 
            this.損益報表ToolStripMenuItem.Name = "損益報表ToolStripMenuItem";
            this.損益報表ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.損益報表ToolStripMenuItem.Text = "損益報表";
            this.損益報表ToolStripMenuItem.Click += new System.EventHandler(this.損益報表ToolStripMenuItem_Click);
            // 
            // 轉帳傳票MenuItem
            // 
            this.轉帳傳票MenuItem.Name = "轉帳傳票MenuItem";
            this.轉帳傳票MenuItem.Size = new System.Drawing.Size(148, 22);
            this.轉帳傳票MenuItem.Text = "轉帳傳票";
            this.轉帳傳票MenuItem.Click += new System.EventHandler(this.轉帳傳票MenuItem_Click);
            // 
            // 合併傳票MenuItem
            // 
            this.合併傳票MenuItem.Name = "合併傳票MenuItem";
            this.合併傳票MenuItem.Size = new System.Drawing.Size(148, 22);
            this.合併傳票MenuItem.Text = "合併 mdb";
            this.合併傳票MenuItem.Click += new System.EventHandler(this.合併傳票MdbMenuItem_Click);
            // 
            // 庫存MenuItem
            // 
            this.庫存MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.耗料ToolStripMenuItem,
            this.盤點ToolStripMenuItem});
            this.庫存MenuItem.Name = "庫存MenuItem";
            this.庫存MenuItem.Size = new System.Drawing.Size(52, 20);
            this.庫存MenuItem.Text = "倉管";
            // 
            // 耗料ToolStripMenuItem
            // 
            this.耗料ToolStripMenuItem.Name = "耗料ToolStripMenuItem";
            this.耗料ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.耗料ToolStripMenuItem.Text = "售出統計";
            this.耗料ToolStripMenuItem.Click += new System.EventHandler(this.耗料ToolStripMenuItem_Click);
            // 
            // 盤點ToolStripMenuItem
            // 
            this.盤點ToolStripMenuItem.Name = "盤點ToolStripMenuItem";
            this.盤點ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.盤點ToolStripMenuItem.Text = "盤點";
            this.盤點ToolStripMenuItem.Click += new System.EventHandler(this.盤點ToolStripMenuItem_Click);
            // 
            // 人事MenuItem
            // 
            this.人事MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.考勤MenuItem,
            this.排班表MenuItem,
            this.資料卡MenuItem});
            this.人事MenuItem.Name = "人事MenuItem";
            this.人事MenuItem.Size = new System.Drawing.Size(52, 20);
            this.人事MenuItem.Text = "人事";
            // 
            // 考勤MenuItem
            // 
            this.考勤MenuItem.Name = "考勤MenuItem";
            this.考勤MenuItem.Size = new System.Drawing.Size(132, 22);
            this.考勤MenuItem.Text = "考勤";
            this.考勤MenuItem.Click += new System.EventHandler(this.考勤MenuItem_Click);
            // 
            // 排班表MenuItem
            // 
            this.排班表MenuItem.Name = "排班表MenuItem";
            this.排班表MenuItem.Size = new System.Drawing.Size(132, 22);
            this.排班表MenuItem.Text = "排班表";
            this.排班表MenuItem.Click += new System.EventHandler(this.排班表MenuItem_Click);
            // 
            // 資料卡MenuItem
            // 
            this.資料卡MenuItem.Name = "資料卡MenuItem";
            this.資料卡MenuItem.Size = new System.Drawing.Size(132, 22);
            this.資料卡MenuItem.Text = "資料卡";
            this.資料卡MenuItem.Click += new System.EventHandler(this.資料卡MenuItem_Click);
            // 
            // 月報表MenuItem
            // 
            this.月報表MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.統計廠商MenuItem,
            this.付款總表ToolStripMenuItem,
            this.進銷比ToolStripMenuItem});
            this.月報表MenuItem.Name = "月報表MenuItem";
            this.月報表MenuItem.Size = new System.Drawing.Size(68, 20);
            this.月報表MenuItem.Text = "月報表";
            // 
            // 統計廠商MenuItem
            // 
            this.統計廠商MenuItem.Name = "統計廠商MenuItem";
            this.統計廠商MenuItem.Size = new System.Drawing.Size(148, 22);
            this.統計廠商MenuItem.Text = "廠商別";
            this.統計廠商MenuItem.Click += new System.EventHandler(this.統計廠商MenuItem_Click);
            // 
            // 付款總表ToolStripMenuItem
            // 
            this.付款總表ToolStripMenuItem.Name = "付款總表ToolStripMenuItem";
            this.付款總表ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.付款總表ToolStripMenuItem.Text = "付款總表";
            this.付款總表ToolStripMenuItem.Click += new System.EventHandler(this.付款總表ToolStripMenuItem_Click);
            // 
            // 進銷比ToolStripMenuItem
            // 
            this.進銷比ToolStripMenuItem.Name = "進銷比ToolStripMenuItem";
            this.進銷比ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.進銷比ToolStripMenuItem.Text = "進銷比";
            this.進銷比ToolStripMenuItem.Click += new System.EventHandler(this.進銷比ToolStripMenuItem_Click);
            // 
            // 查核MenuItem
            // 
            this.查核MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查核費用MenuItem,
            this.查核進貨MenuItem,
            this.查核傳票MenuItem,
            this.鎖定資料庫MenuItem,
            this.備份資料庫ToolStripMenuItem});
            this.查核MenuItem.Name = "查核MenuItem";
            this.查核MenuItem.Size = new System.Drawing.Size(52, 20);
            this.查核MenuItem.Text = "查核";
            // 
            // 查核費用MenuItem
            // 
            this.查核費用MenuItem.Name = "查核費用MenuItem";
            this.查核費用MenuItem.Size = new System.Drawing.Size(164, 22);
            this.查核費用MenuItem.Text = "費用";
            this.查核費用MenuItem.Click += new System.EventHandler(this.費用MenuItem1_Click);
            // 
            // 查核進貨MenuItem
            // 
            this.查核進貨MenuItem.Name = "查核進貨MenuItem";
            this.查核進貨MenuItem.Size = new System.Drawing.Size(164, 22);
            this.查核進貨MenuItem.Text = "進貨";
            this.查核進貨MenuItem.Click += new System.EventHandler(this.進貨MenuItem1_Click);
            // 
            // 查核傳票MenuItem
            // 
            this.查核傳票MenuItem.Name = "查核傳票MenuItem";
            this.查核傳票MenuItem.Size = new System.Drawing.Size(164, 22);
            this.查核傳票MenuItem.Text = "傳票";
            this.查核傳票MenuItem.Click += new System.EventHandler(this.查核傳票MenuItem_Click);
            // 
            // 鎖定資料庫MenuItem
            // 
            this.鎖定資料庫MenuItem.Name = "鎖定資料庫MenuItem";
            this.鎖定資料庫MenuItem.Size = new System.Drawing.Size(164, 22);
            this.鎖定資料庫MenuItem.Text = "鎖定資料庫";
            this.鎖定資料庫MenuItem.Click += new System.EventHandler(this.鎖定資料庫ToolStripMenuItem_Click);
            // 
            // 備份資料庫ToolStripMenuItem
            // 
            this.備份資料庫ToolStripMenuItem.Name = "備份資料庫ToolStripMenuItem";
            this.備份資料庫ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.備份資料庫ToolStripMenuItem.Text = "備份資料庫";
            this.備份資料庫ToolStripMenuItem.Click += new System.EventHandler(this.備份資料庫ToolStripMenuItem_Click);
            // 
            // 修改密碼MenuItem
            // 
            this.修改密碼MenuItem.Name = "修改密碼MenuItem";
            this.修改密碼MenuItem.Size = new System.Drawing.Size(84, 20);
            this.修改密碼MenuItem.Text = "修改密碼";
            this.修改密碼MenuItem.Click += new System.EventHandler(this.修改密碼MenuItem_Click);
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // headerTableAdapter
            // 
            this.headerTableAdapter.ClearBeforeFill = true;
            // 
            // 編修部門MenuItem
            // 
            this.編修部門MenuItem.Name = "編修部門MenuItem";
            this.編修部門MenuItem.Size = new System.Drawing.Size(152, 22);
            this.編修部門MenuItem.Text = "編修部門";
            this.編修部門MenuItem.Click += new System.EventHandler(this.編修部門ToolStripMenuItem_Click);
            // 
            // FormHome
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(912, 674);
            this.Controls.Add(this.menu1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menu1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormHome_FormClosing);
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.SizeChanged += new System.EventHandler(this.FormHome_SizeChanged);
            this.menu1.ResumeLayout(false);
            this.menu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu1;
        private System.Windows.Forms.ToolStripMenuItem 基本資料MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 員工MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 供應商MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 食材表MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 會計科目MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 費用MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 進貨MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查核MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查核費用MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查核進貨MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改密碼MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 月報表MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 統計廠商MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 付款總表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 鎖定資料庫MenuItem;
        private VEDataSet vEDataSet;
        private VoucherExpense.VEDataSetTableAdapters.HeaderTableAdapter headerTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem 收入MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 庫存MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 銀行帳號MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 銀行MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 會計MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 月報ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 明細ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 進銷比ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 傳票設定MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 細目編修ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 匯入XLSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 耗料ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 盤點ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 操作員MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 環境設定MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 備份資料庫ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 損益報表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 轉帳傳票MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查核傳票MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 人事MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 考勤MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 資料卡MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 合併銀行細目MdbMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 合併傳票MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 年初開帳MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 排班表MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 編修菜單ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 編修部門MenuItem;

    }
}

