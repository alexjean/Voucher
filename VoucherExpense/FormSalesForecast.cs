using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using VoucherExpense.DamaiDataSetTableAdapters;
using System.Data.SqlClient;

using System.Reflection;

namespace VoucherExpense
{
    public partial class FormSalesForecast : Form
    {
        public FormSalesForecast()
        {
            InitializeComponent();
        }

        //private DamaiDataSet m_dataset = new DamaiDataSet  ();
        //private ProductAdapter m_PAdapter = new ProductAdapter ();
        //private UnitSalesTableAdapter m_VAdapter = new UnitSalesTableAdapter();
        private DataTable m_dtSales;
       // private DataTable m_dtSalesScrapped;
        private DateTime m_CurrentTime;
        private void btForecast_Click(object sender, EventArgs e)
        {
                m_CurrentTime = dateTimePicker1.Value;
                string c = dateTimePicker1.Value.AddDays(-7).ToString("yyyyMMdd");
                string b = dateTimePicker1.Value.AddDays(-14).ToString("yyyyMMdd");
                string a = dateTimePicker1.Value.AddDays(-21).ToString("yyyyMMdd");
               // select * from news wheresubstring(Convert(char(10),date,112),1,8)='20090112'
                //按日查substring(Convert(char(10),date,112),1,8)='20090112'
                //按月查substring(Convert(char(10),date,112),1,6)='200901'
                //按年查substring(Convert(char(10),date,112),1,4)='2009'
               try
               {
                   string sqlstr=@" select a.name as 名称, max(case when sds='"+a+"' then dd else 0 end) as '"+a+"',max(case when sds= '"+b+"' then dd else 0 end) as '"+b+"',max(case when sds= '"+c+"' then dd else 0 end) as '"+c+"'" 
                   +"from (SELECT  SUBSTRING(CONVERT(char(10), printtime,112),1,8) as sds,ProductID,count(no) as dd ,name FROM View_UnitSales where SUBSTRING(CONVERT(char(10),printtime,112),1,8)=SUBSTRING(CONVERT(char(10),printtime,112),1,8) group by ProductID,SUBSTRING(CONVERT(char(10),printtime,112),1,8) ,name ) a GROUP BY a.name";
               //    string ss = "SELECT  [ProductID],[PrintTime] ,[Name],[No] FROM View_UnitSales "
               //    + "where SUBSTRING(CONVERT(char(10),printtime,112),1,8)='" + a.ToString() + "' "
               //    + "or SUBSTRING(CONVERT(char(10),printtime,112),1,8)='" + b.ToString() + "' "
               //    + "or SUBSTRING(CONVERT(char(10),printtime,112),1,8)='" + c.ToString() + "'";
               //m_VAdapter.FillBySelectStr(m_dataset.View_UnitSales, "SELECT  [ProductID],[PrintTime] ,[Name],[No] FROM View_UnitSales "
               //    +"where SUBSTRING(CONVERT(char(10),printtime,112),1,8)='"+a.ToString()+"' "
               //    +"or SUBSTRING(CONVERT(char(10),printtime,112),1,8)='"+b.ToString()+"' "
               //    +"or SUBSTRING(CONVERT(char(10),printtime,112),1,8)='"+c.ToString()+"'");
               //    MessageBox.Show("计算成功")
                   string str = " Data Source=" + MyFunction.HardwareCfg.SqlServerIP + " ; DataBase=" + MyFunction.HardwareCfg.SqlDatabase + ";uid=" + MyFunction.HardwareCfg.SqlUserID + ";pwd=" + MyFunction.HardwareCfg.SqlPassword + ";"; 
                       SqlConnection con=new SqlConnection (str);
                   SqlCommand com=new SqlCommand (sqlstr,con);
                   SqlDataAdapter adapter=new SqlDataAdapter (com);
                   m_dtSales = new DataTable();
                   adapter.Fill(m_dtSales);
                   m_dtSales.Columns.Add(dateTimePicker1.Value.ToString("yyyyMMdd"));
                   for (int i = 0; i < m_dtSales.Rows.Count; i++)
                   {
                       //if (true)
                       //{
                       //    var currentrow=m_dtSales.Select("ProductID="+m_dtSales.Rows[i][4].ToString());
                       //}
                       m_dtSales.Rows[i][4] = calculate(Convert.ToInt32(m_dtSales.Rows[i][1]), Convert.ToInt32(m_dtSales.Rows[i][2]),Convert.ToInt32( m_dtSales.Rows[i][3])); 

                   }
                   dataGridView1.DataSource = m_dtSales;
               }
               catch (Exception)
               {
                   throw;
               }
               
        }
         
        int  calculate(int y1,int y2,int y3)
        {
            
            //二次函数只适用于值非常接近的时候
                ////a = y1 / (x1 - x2) / (x1 - x3) + y2 / (x2 - x1) / (x2 - x3) + y3 / (x3 - x1) / (x3 - x2)
                ////b = -y1 * (x2 + x3) / (搜索x1 - x2) / (x1 - x3) - y2 * (x1 + x3) / (x2 - x1) / (x2 - x3) - y3 * (x1 + x2) / (x3 - x1) / (x3 - x2)
                ////c = y1 * x2 * x3 / (x1 - x2) / (x1 - x3) + y2 * x1 * x3 / (x2 - x1) / (x2 - x3) + y3 * x1 * x2 / (x3 - x1) / (x3 - x2)
                //int a = y1 / 2 - y2 + y3 / 2;
                //int b=-5*y1/2+4*y2-3*y3/2;
                //int c=3*y1-3*y2+y3;
                //return a * 4 * 4 + b * 4 + c;
            return (int)Math.Ceiling(Convert.ToDouble((y1 + y2 + y3) / 3));
        }

        private void FormSalesForecast_Load(object sender, EventArgs e)
        {
            //m_PAdapter.FillBySelectStr(m_dataset.Product,"select * from Product where code>0"); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            if (app == null)
            {
                throw new Exception("Excel无法启动");
            }
            app.Visible = true;
            Microsoft.Office.Interop.Excel.Workbooks wbs = app.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook wb = wbs.Add(Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

            int cnt = m_dtSales.Rows.Count;
            int columncnt = m_dtSales.Columns.Count;

            // *****************获取数据********************
            object[,] objData = new Object[cnt + 1, columncnt];  // 创建缓存数据
            // 获取列标题
            for (int i = 0; i < columncnt; i++)
            {
                objData[0, i] = m_dtSales.Columns[i].ColumnName;
            }
            // 获取具体数据
            for (int i = 0; i < cnt; i++)
            {
                System.Data.DataRow dr = m_dtSales.Rows[i];
                for (int j = 0; j < columncnt; j++)
                {
                    objData[i + 1, j] = dr[j];
                }
            }

            //********************* 写入Excel******************
            Microsoft.Office.Interop.Excel.Range r = ws.Range[app.Cells[1, 1], app.Cells[cnt + 1, columncnt]];
            r.NumberFormat = "@";
            //r = r.get_Resize(cnt+1, columncnt);
            r.Value2 = objData;
            r.EntireColumn.AutoFit();

            app = null;
      
        }
    }
    //public class ProductAdapter :ProductTableAdapter
    //{
    //    string SaveStr;
    //    public int FillBySelectStr(DamaiDataSet.ProductDataTable dataTable, string SelectStr)
    //    {
    //        SaveStr = base.CommandCollection[0].CommandText;
    //        base.CommandCollection[0].CommandText = SelectStr;
    //        int result = Fill(dataTable);
    //        base.CommandCollection[0].CommandText = SaveStr;
    //        return result;
    //    }
    //}
    //public class UnitSalesTableAdapter : View_UnitSalesTableAdapter
    //{
    //    string SaveStr;
    //    public int FillBySelectStr(DamaiDataSet.View_UnitSalesDataTable dataTable, string SelectStr)
    //    {
    //        SaveStr = base.CommandCollection[0].CommandText;
    //        base.CommandCollection[0].CommandText = SelectStr;
    //        int result = Fill(dataTable);
    //        base.CommandCollection[0].CommandText = SaveStr;
    //        return result;
    //    }
    //}
}
