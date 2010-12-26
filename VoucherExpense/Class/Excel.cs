using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Microsoft.Office.Interop;

namespace VoucherExpense
{
    class ExcelLib
    {
        static Microsoft.Office.Interop.Excel.Application ExcelApp = null;
        object Val = Type.Missing;
        public ExcelLib()
        {
            ExcelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
        }

        public void QuitExcel()
        {
            ExcelApp.Quit();
            ExcelApp = null;
        }

        public string[] SheetNames(string filename)
        {
            Microsoft.Office.Interop.Excel.Workbook workbook = ExcelApp.Workbooks.Open(filename,
                                                Val, Val, Val, Val, Val, Val, Val,
                                                Val, Val, Val, Val, Val, Val, Val);
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            int count = workbook.Worksheets.Count;
            if (count == 0) return null;
            string[] result=new string[count];
            for (int i = 0; i < count; i++)
            {
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[i+1];
                result[i] = worksheet.Name;
            }
            return result;
        }

        public DataSet LoadData(string filePath,string sheet)
        {
            try 
            { 
                string strConn; 
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'"; 
                OleDbConnection OleConn = new OleDbConnection(strConn); 
                OleConn.Open(); 
                String sql = "SELECT * FROM  ["+sheet+"$]";

                OleDbDataAdapter DaExcel = new OleDbDataAdapter(sql, OleConn); 
                DataSet DsExcle = new DataSet(); 
                DaExcel.Fill(DsExcle, sheet); 
                OleConn.Close(); 
                return DsExcle; 
            } 
            catch (Exception err) 
            { 
                MessageBox.Show("讀入Excel失敗!原因：" + err.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                return null; 
            } 
        }
    }
}
