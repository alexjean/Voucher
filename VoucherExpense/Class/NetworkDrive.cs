using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

namespace VoucherExpense
{
    class NetworkDrive
    {
        #region API
        [DllImport("mpr.dll")]
        private static extern int WNetAddConnection2A(ref structNetResource pstNetRes, string psPassword, string psUsername, int piFlags);
        [DllImport("mpr.dll")]
        private static extern int WNetCancelConnection2A(string psName, int piFlags, int pfForce);
        [DllImport("mpr.dll")]
        private static extern int WNetConnectionDialog(int phWnd, int piType);
        [DllImport("mpr.dll")]
        private static extern int WNetDisconnectDialog(int phWnd, int piType);
        [DllImport("mpr.dll")]
        private static extern int WNetRestoreConnectionW(int phWnd, string psLocalDrive);

        [StructLayout(LayoutKind.Sequential)]
        private struct structNetResource
        {
            public int iScope;
            public int iType;
            public int iDisplayType;
            public int iUsage;
            public string sLocalName;
            public string sRemoteName;
            public string sComment;
            public string sProvider;
        }

        private const int RESOURCETYPE_DISK = 0x1;

        private const int CONNECT_INTERACTIVE    = 0x00000008;  //Standard	
        private const int CONNECT_PROMPT         = 0x00000010;
        private const int CONNECT_UPDATE_PROFILE = 0x00000001;

        private const int CONNECT_REDIRECT       = 0x00000080;  //IE4+

        private const int CONNECT_COMMANDLINE    = 0x00000800;  //NT5 only
        private const int CONNECT_CMD_SAVECRED   = 0x00001000;

        #endregion

        #region Propertys and options

        public bool SaveCredentials      { get; set; }
        public bool Persistent           { get; set; }
        public bool Force                { get; set; }
        public bool PromptForCredentials { get; set; }
        public string ShareName          { get; set; }
        private string ls_Drive = "";    // 例 S:
/*
        public string LocalDrive
        {
            get { return (ls_Drive); }
            set
            {
                if (value.Length >= 1)
                {
                    ls_Drive = value.Substring(0, 1) + ":";
                }
                else
                {
                    ls_Drive = "";
                }
            }
        }
*/
        #endregion

        public NetworkDrive()
        {
            ShareName=@"\\Computer\C$";
            SaveCredentials=false;
            Persistent     =false;
            Force          =false;
            PromptForCredentials = false;
        }

        #region Function mapping

        //  >0 表示出錯
        public int MapDrive()                                 { return zMapDrive(null, null); }
        public int MapDrive(string Password)                  { return zMapDrive(null, Password); }
        public int MapDrive(string Username, string Password) { return zMapDrive(Username, Password); }
        public bool UnMapDrive()
        {
            if (zUnMapDrive(this.Force)>0) return false;
            return true;
        }
        public bool UnMapDrive(string name)
        {
            int iFlags = 0;
            if (Persistent) { iFlags += CONNECT_UPDATE_PROFILE; }
            int i = WNetCancelConnection2A(ShareName, iFlags, Convert.ToInt32(true));
            if (i > 0)
                return false;
            else
                return true;
        }

        public void RestoreDrives()                            { zRestoreDrive(); }
        public void ShowConnectDialog(Form ParentForm)         { zDisplayDialog(ParentForm, 1); }
        public void ShowDisconnectDialog(Form ParentForm)      { zDisplayDialog(ParentForm, 2); }
        #endregion

        #region Core functions

        // Map network drive, >0 表示出錯
        private int zMapDrive(string psUsername, string psPassword)
        {
            //create struct data
            structNetResource stNetRes = new structNetResource();
            stNetRes.iScope = 2;
            stNetRes.iType = RESOURCETYPE_DISK;
            stNetRes.iDisplayType = 3;
            stNetRes.iUsage = 1;
            stNetRes.sRemoteName = ShareName;
            stNetRes.sLocalName = ls_Drive;
            //prepare params
            int iFlags = 0;
            if (SaveCredentials)      { iFlags += CONNECT_CMD_SAVECRED; }
            if (Persistent)           { iFlags += CONNECT_UPDATE_PROFILE; }
            if (PromptForCredentials) { iFlags += CONNECT_INTERACTIVE + CONNECT_PROMPT; }
            if (psUsername == "")     { psUsername = null; }
            if (psPassword == "")     { psPassword = null; }
            //if force, unmap ready for new connection
            if (Force)                { try { zUnMapDrive(true); } catch { } }
            //call and return
            int i = WNetAddConnection2A(ref stNetRes, psPassword, psUsername, iFlags);
            return i;
//            if (i > 0)                   { throw new System.ComponentModel.Win32Exception(i); }
        }

        // Unmap network drive	
        private int zUnMapDrive(bool pfForce)
        {
            //call unmap and return
            int iFlags = 0;
            if (Persistent) { iFlags += CONNECT_UPDATE_PROFILE; }
            int i = WNetCancelConnection2A(ls_Drive, iFlags, Convert.ToInt32(pfForce));
            if (i != 0)
                i = WNetCancelConnection2A(ShareName, iFlags, Convert.ToInt32(pfForce));  //disconnect if localname was null
            return i;
//            if (i > 0) { throw new System.ComponentModel.Win32Exception(i); }
        }

        private void zRestoreDrive()
        {
            int i = WNetRestoreConnectionW(0, null);
            if (i > 0) { throw new System.ComponentModel.Win32Exception(i); }
        }

        private void zDisplayDialog(Form poParentForm, int piDialog)
        {
            int i = -1;
            int iHandle = 0;
            if (poParentForm != null)
                iHandle = poParentForm.Handle.ToInt32();
            if      (piDialog == 1) i = WNetConnectionDialog(iHandle, RESOURCETYPE_DISK);
            else if (piDialog == 2) i = WNetDisconnectDialog(iHandle, RESOURCETYPE_DISK);
            if (i > 0) { throw new System.ComponentModel.Win32Exception(i); }
            poParentForm.BringToFront();
        }


        #endregion

    }
}
