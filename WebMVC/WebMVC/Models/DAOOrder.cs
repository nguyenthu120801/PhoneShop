using WebMVC.Connection;
using WebMVC.Entity;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace WebMVC.Models
{
    public class DAOOrder : ConnectDatabase
    {
        // add order

        public int AddOrder(Order order)
        {
            int number = 0;// number of row affected
            string sql = "INSERT INTO [dbo].[Order]([CustomerID],[status],[TotalPrice],[OrderDate],[address]) " +
                "VALUES(@ID, @status, @TotalPrice, @OrderDate, @address)";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            // set value for parameter
            cmd.Parameters.AddWithValue("@ID", order.CustomerID);
            cmd.Parameters.AddWithValue("@status", order.status);
            cmd.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
            cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
            cmd.Parameters.AddWithValue("@address", order.Address);
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

        // get order id
        public int getOrderID()
        {
            int ID = 0;
            String sql = "SELECT top 1* FROM [dbo].[Order]\n"
                    + "ORDER BY [OrderID] DESC";
            // get data from sql
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                ID = Convert.ToInt32(dr["OrderID"]);
            }
            return ID;
        }

        // get list order based on  id
        public List<Order> GetListOrder(string ID, string value)
        {
            List<Order> list = new List<Order>();
            string sql = "SELECT * FROM [dbo].[Order]\n"
                    + "WHERE [" + ID + "] = " + value;
            // get data
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                Order order = new Order()
                {
                    OrderID = (int) dr["OrderID"],
                    CustomerID = (int)dr["CustomerID"],
                    status = dr["status"].ToString(),
                    TotalPrice = (int) dr["TotalPrice"],
                    OrderDate = dr["OrderDate"].ToString(),
                    ShippedDate = dr["ShippedDate"] == null?"": dr["ShippedDate"].ToString(),
                    ShipID = dr["ShipID"] == null ? "" : dr["ShipID"].ToString(),
                    Address = dr["address"].ToString()
                };
                list.Add(order);
            }
             return list;
        }

        // check order 
        public bool CheckOrder(int ID)
        {
            List<Order> list = new DAOOrder().GetListOrder("CustomerID", ID.ToString());
            // if customer not have order
            if (list.Count == 0)
            {
                return true;
            }
            // loop for traverse all list order
            foreach (Order order in list)
            {
                // if status order is done or cancel
                if (order.status.Equals("Done") || order.status.Equals("Cancel"))
                {
                    return true;
                }
            }
            return false;
        }

        // delete order
        public int DeleteOrder(int OrderID)
        {
            int number = 0;// number of row affected
            string sql = "DELETE FROM [dbo].[Order]\n"
                    + "      WHERE [OrderID] = " + OrderID;
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

        // get order
        public Order getOrder(int ID)
        {
            string sql = "SELECT * FROM [dbo].[Order]\n"
                    + "WHERE [OrderID] = " + ID;
            // get data
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                Order order = new Order()
                {
                    OrderID = (int)dr["OrderID"],
                    CustomerID = (int)dr["CustomerID"],
                    status = dr["status"].ToString(),
                    TotalPrice = (int)dr["TotalPrice"],
                    OrderDate = dr["OrderDate"].ToString(),
                    ShippedDate = dr["ShippedDate"] == null ? "" : dr["ShippedDate"].ToString(),
                    ShipID = dr["ShipID"] == null ? "" : dr["ShipID"].ToString(),
                    Address = dr["address"].ToString()
                };
                return order;
            }
            return null;
        }
        // get all order
        public List<Order> GetAllOrder()
        {
            List<Order> list = new List<Order>();
            string sql = "SELECT * FROM [dbo].[Order]";
            // get data
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                Order order = new Order()
                {
                    OrderID = (int)dr["OrderID"],
                    CustomerID = (int)dr["CustomerID"],
                    status = dr["status"].ToString(),
                    TotalPrice = (int)dr["TotalPrice"],
                    OrderDate = dr["OrderDate"].ToString(),
                    ShippedDate = dr["ShippedDate"] == null ? "" : dr["ShippedDate"].ToString(),
                    ShipID = dr["ShipID"] == null ? "" : dr["ShipID"].ToString(),
                    Address = dr["address"].ToString()
                };
                list.Add(order);
            }
            return list;
        }

        public List<Order> GetListOrder(string Status)
        {
            List<Order> list = new List<Order>();
            string sql = "SELECT * FROM [dbo].[Order] where [status] = '"+ Status + "'";
            // get data
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                Order order = new Order()
                {
                    OrderID = (int)dr["OrderID"],
                    CustomerID = (int)dr["CustomerID"],
                    status = dr["status"].ToString(),
                    TotalPrice = (int)dr["TotalPrice"],
                    OrderDate = dr["OrderDate"].ToString(),
                    ShippedDate = dr["ShippedDate"] == null ? "" : dr["ShippedDate"].ToString(),
                    ShipID = dr["ShipID"] == null ? "" : dr["ShipID"].ToString(),
                    Address = dr["address"].ToString()
                };
                list.Add(order);
            }
            return list;
        }

        // update status
        public int UpdateStatus(string status, int ID)
        {
            int number = 0;// number of row affected
            string sql = "UPDATE [dbo].[Order]\n"
                    + "SET [status] = @status\n"
                    + "WHERE [OrderID] = @ID";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            // set value for parameter
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@status", status);
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

        // update ship id
        public int UpdateShipID(string ShipID, int OrderID)
        {
            int number = 0;// number of row affected
            string sql;
            // if set no shipper
            if(ShipID == null)
            {
                sql = "UPDATE [dbo].[Order]\n"
                    + "SET [ShipID] = NULL\n"
                    + "WHERE [OrderID] = @order";
            }
            else
            {
                 sql = "UPDATE [dbo].[Order]\n"
                    + "SET [ShipID] = @ship\n"
                    + "WHERE [OrderID] = @order";
            }

            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            // set value for parameter
            cmd.Parameters.AddWithValue("@order", OrderID);
            // if set shipper
            if(ShipID != null)
            {
             cmd.Parameters.AddWithValue("@ship", ShipID);
            }
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

        // update ship date
        public int UpdateShipDate(string date, int OrderID)
        {
            int number = 0;// number of row affected
            string sql;
            // if not set ship date
            if (date == null)
            {
                sql = "UPDATE [dbo].[Order]\n"
                    + "SET [ShippedDate] = NULL\n"
                    + "WHERE [OrderID] = @order";
            }
            else
            {
                sql = "UPDATE [dbo].[Order]\n"
                   + "SET [ShippedDate] = @ship\n"
                   + "WHERE [OrderID] = @order";
            }

            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            // set value for parameter
            cmd.Parameters.AddWithValue("@order", OrderID);
            // if set ship date
            if (date != null)
            {
                cmd.Parameters.AddWithValue("@ship", date);
            }
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
    }
}
