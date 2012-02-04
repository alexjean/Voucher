using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;

namespace VoucherExpense
{
    static class SystemErrorMessage
    {
        const int FORMAT_MESSAGE_FROM_SYSTEM = 0x1000;
        const int FORMAT_MESSAGE_IGNORE_INSERTS = 0x200;
        [DllImport("Kernel32.dll")]
        public static extern int FormatMessage(uint dwFlags, IntPtr lpSource, uint dwMessageId, uint dwLanguageId, 
                                                [Out]StringBuilder lpBuffer, uint nSize, IntPtr arguments);

        static public string Get(uint MessageID)
        {
            uint dwFlags = FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS;
            StringBuilder lpBuffer = new StringBuilder(260);
            int count = FormatMessage(dwFlags, IntPtr.Zero, MessageID, 0, lpBuffer, 260, IntPtr.Zero);
            if (count > 0)
            {
                return lpBuffer.ToString().Trim();
            }
            return "找不到系統錯誤信息<" + MessageID.ToString() + ">";
        }

    }
}
