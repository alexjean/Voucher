using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataCollection
{
    class OPClass
    {
    }
    public class OP
    {

        string constr = "server=115.28.163.176;uid=sa;database=wheat;pwd=CalcVoucher888;";

       void ReadAndWriteProduct(string storeid) { }
       public  void ReadAndWriteProduct(tbStore store)
        {
            //delete from tbProduct where 1=1;
            //insert into tbProduct
            //select *,1 from ["+store.StoreDBName+"].[dbo].[Product] where Product.Code>0
            string sqlstr = "insert into tbProduct select * ," +  store.StoreID + "from  [" + store.StoreDBName + "].[dbo].[Product] where Product.Code>0";
            using (SqlConnection connection = new SqlConnection(constr))
            {
                Log.Write("--------------------------" + store.StoreName + "------------------------------");
                  try
                    {
                        connection.Open();     Log.Write("连接数据库"+store.StoreDBName+"成功！");

                        using (SqlCommand cmd = new SqlCommand("delete from tbProduct where 1=1", connection))
                        {
                            try
                            {
                                int rows = cmd.ExecuteNonQuery();
                                Log.Write("删除产品数据！" + rows + "行");
                            }
                            catch (Exception ex)
                            {

                                Log.Write("删除产品数据失败！" + "ex:" + ex.Message);

                            }
                        }
                        using (SqlCommand cmd = new SqlCommand(sqlstr, connection))
                        {
                            try
                            {
                                int rows = cmd.ExecuteNonQuery();
                                Log.Write("产品数据成功更新！" + rows + "行");
                            }
                            catch (Exception ex)
                            {

                                Log.Write("产品数据更新失败！" + "ex:" + ex.Message);

                            }
                        }
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        connection.Close();
                        Log.Write("数据库连接失败！" + "ex:" + E.Message);
                    }
            }
        }

        public void ReadAndWritePhotos(tbStore store)
        {
            Log.Write("--------------------------" + store.StoreName + "------------------------------");
            //insert into tbPhotos 
            //select * ,1 from ["+store.StoreDBName+"].[dbo].[Photos] where TableID=1

            string sqlstr = "insert into tbPhotos select [TableID],[PhotoID] ,[Photo],[UpdatedTime] ," + store.StoreID + " from  [" + store.StoreDBName + "].[dbo].[Photos] where TableID=1";
            using (SqlConnection connection = new SqlConnection(constr))
            {
                try
                {
                    connection.Open(); Log.Write("连接数据库" + store.StoreDBName + "成功！");

                    using (SqlCommand cmd = new SqlCommand("delete from tbPhotos where 1=1", connection))
                    {
                        try
                        {
                            int rows = cmd.ExecuteNonQuery();
                            Log.Write("删除产品图片数据！" + rows + "行");
                        }
                        catch (Exception ex)
                        {

                            Log.Write("删除产品图片数据失败！" + "ex:" + ex.Message);

                        }
                    }
                    using (SqlCommand cmd = new SqlCommand(sqlstr, connection))
                    {
                        try
                        {
                            int rows = cmd.ExecuteNonQuery();
                            Log.Write("产品图片数据成功更新！" + rows + "行");
                        }
                        catch (Exception ex)
                        {

                            Log.Write("产品图片数据更新失败！" + "ex:" + ex.Message);

                        }
                    }
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    connection.Close();
                    Log.Write("数据库连接失败！" + "ex:" + E.Message);
                }
            }
        }

       public void ReadAndWriteOrder(tbStore store)
        {
            Log.Write("--------------------------"+store.StoreName+"------------------------------");
            //--订单，详单
            //Use[Wheat]
            //insert into tbOrder
            //select 1,* from ["+store.StoreDBName+"].[dbo].[Order] where PrintTime>'20140918'

            //insert into tbOrderItem
            //select a.*,1 from ["+store.StoreDBName+"].[dbo].[OrderItem] a, ["+store.StoreDBName+"].[dbo].[Order] b where a.ItemID=b.ID  and b.PrintTime>'20140918';


            string sqlstr = "insert into tbOrder select "+store.StoreID+",*,'36C96AD1-9A62-470C-9E63-343EA9C9EDDC',0 from ["+store.StoreDBName+"].[dbo].[Order] where PrintTime>'20140101'";
            string sqlstr1 = "insert into tbOrderItem select a.*," + store.StoreID + " from ["+store.StoreDBName+"].[dbo].[OrderItem] a, ["+store.StoreDBName+"].[dbo].[Order] b where a.ItemID=b.ID  and b.PrintTime>'20140101'";
            using (SqlConnection connection = new SqlConnection(constr))
            {
                try
                {
                    connection.Open(); Log.Write("连接数据库" + store.StoreDBName + "成功！");

                    using (SqlCommand cmd = new SqlCommand(sqlstr, connection))
                    {
                        try
                        {
                            int rows = cmd.ExecuteNonQuery();
                            Log.Write("更新订单数据！" + rows + "行");
                        }
                        catch (Exception ex)
                        {

                            Log.Write("更新订单数据失败！" + "ex:" + ex.Message);

                        }
                    }
                    using (SqlCommand cmd = new SqlCommand(sqlstr1, connection))
                    {
                        try
                        {
                            int rows = cmd.ExecuteNonQuery();
                            Log.Write("更新订单详单数据成功更新！" + rows + "行");
                        }
                        catch (Exception ex)
                        {

                            Log.Write("更新订单详单数据更新失败！" + "ex:" + ex.Message);

                        }
                    }
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    connection.Close();
                    Log.Write("数据库连接失败！" + "ex:" + E.Message);
                }
            }
            //   
        }
        void ReadAndWriteOrderItem()
        {
            //            --产品表和图片表
     
        }
        void DeleteLastUpdate(string tbName)
        {
            string sqlstr = "delete from " + tbName + " where updatetime>" + DateTime.Now.AddDays(-1);
        }

     
    }
}
      

