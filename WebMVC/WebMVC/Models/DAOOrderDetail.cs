using WebMVC.Connection;
using WebMVC.Entity;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace WebMVC.Models
{
    public class DAOOrderDetail : ConnectDatabase
    {
        // add order detail
        public int AddOrderDetail(OrderDetail detail)
        {
            String sql = "INSERT INTO [dbo].[OrderDetail]([OrderID],[DetailID],[ProductID],[quantity],[price]) VALUES(@OrderID,@DetailID,@ProductID,@quantity,@price)";
            int number = 0; // number of row affected
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            // set value for parameter
            cmd.Parameters.AddWithValue("@OrderID", detail.OrderID);
            cmd.Parameters.AddWithValue("@DetailID", detail.DetailID);
            cmd.Parameters.AddWithValue("@ProductID",detail.ProductID);
            cmd.Parameters.AddWithValue("@quantity", detail.Quantity);
            cmd.Parameters.AddWithValue("@price", detail.Price);
            try
            {
                // set connection
                cmd.Connection = connect;
                cmd.Connection.Open();
                // execute sql
                number = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return number;
        }

        // delete order detail
        public int DeleteOrderDetail(int ID)
        {
            int number = 0;// number of row affected
            string sql = "DELETE FROM [dbo].[OrderDetail]\n"
                    + "      WHERE [OrderID] = " + ID;
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            try
            {
                // set connection
                cmd.Connection = connect;
                cmd.Connection.Open();
                // execute sql
                number = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return number;
        }
        // get list order 
        public List<OrderDetail> GetListOrder(int productID)
        {
            List<OrderDetail> list = new List<OrderDetail>();
            string sql = "SELECT * FROM [dbo].[OrderDetail] where [ProductID] = " + productID;
            // get data
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                OrderDetail detail = new OrderDetail()
                {
                    OrderID = (int) dr["OrderID"],
                    DetailID = (int)dr["DetailID"],
                    ProductID = (int)dr["ProductID"],
                    Quantity = (int) dr["quantity"],
                    Price = (int) dr["price"]
                };
                list.Add(detail);
            }
            return list;
        }

        // check order product buy
        public bool CheckOrder(int ID)
        {
            List<OrderDetail> list = GetListOrder(ID);
            // if list empty
            if(list.Count == 0)
            {
                return false;
            }
            foreach(OrderDetail detail in list)
            {
                Order order = new DAOOrder().getOrder(detail.OrderID);
                // if order is new or process
                if(order.status.Equals("New") || order.status.Equals("Process"))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
