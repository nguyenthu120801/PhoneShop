using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebMVC.Connection;
using WebMVC.Entity;
namespace WebMVC.Models
{
    public class DAOCustomer : ConnectDatabase
    {
        // get customer id
        public int getCustomerID(string username)
        {
            int ID = 0;
            string sql = "SELECT [ID] FROM [dbo].[Customer] where [username] = '" + username + "'";
            // get data from sql
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                ID = (int) dr["ID"];
            }
            
            return ID;
        }

        // add customer

        public int AddCustomer(Customer customer)
        {
            int number = 0;// number of row affected
            string sql;
            // if not set email
            if(customer.Email == null)
            {
                sql = "INSERT INTO [dbo].[Customer]([FullName],[phone],[gender],[username]) VALUES\n"
                    + "(@name,@phone,@gender,@username)";
            }
            else
            {
                sql = "INSERT INTO [dbo].[Customer]([FullName],[phone],[email],[gender],[username]) VALUES\n"
                    + "(@name,@phone,@email,@gender,@username)";
            }
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            // set value for parameter
            cmd.Parameters.AddWithValue("@name", customer.FullName);
            cmd.Parameters.AddWithValue("@phone", customer.Phone);
            // if set email
            if(customer.Email != null)
            {
            cmd.Parameters.AddWithValue("@email", customer.Email);
            }          
            cmd.Parameters.AddWithValue("@gender", customer.Gender);
            cmd.Parameters.AddWithValue("@username", customer.Username);
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
        // get profile
        public Customer getProfile(string username)
        {
            string sql = "SELECT [FullName],[phone],[email],[gender]\n"
                    + "FROM [dbo].[Customer]\n"
                    + "where [username] ='" + username + "'";
            // get data from sql
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                Customer customer = new Customer()
                {
                    FullName = dr["FullName"].ToString(),
                    Phone = dr["phone"].ToString(),
                    Email = dr["email"] == null ? "" : dr["email"].ToString(),
                    Gender = (bool) dr["gender"]
                };
                return customer;
            }
             return null;
        }

        // update customer
        public int UpdateCustomer(Customer customer)
        {
            int number = 0;// number of row affected
            string sql;
            // if not set email
            if(customer.Email == null)
            {
                   sql = "UPDATE [dbo].[Customer]\n"
                    + "SET [FullName] = @name,\n"
                    + "[phone] = @phone,\n"
                    + "[email] = NULL,\n"
                    + "[gender] = @gender\n"
                    + "WHERE [username] = @username";
            }
            else
            {
                sql = "UPDATE [dbo].[Customer]\n"
                + "SET [FullName] = @name,\n"
                + "[phone] = @phone,\n"
                + "[email] = @email,\n"
                + "[gender] = @gender\n"
                + "WHERE [username] = @username";
            }
                               
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            // set value for parameter
            cmd.Parameters.AddWithValue("@name", customer.FullName);
            cmd.Parameters.AddWithValue("@phone", customer.Phone);
            // if set email
            if (customer.Email != null)
            {
                cmd.Parameters.AddWithValue("@email", customer.Email);
            }
            cmd.Parameters.AddWithValue("@gender", customer.Gender);
            cmd.Parameters.AddWithValue("@username", customer.Username);
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
        // delete customer
        public int DeleteCustomer(string username)
        {
            int number = 0;// number of row affected
            string sql = "DELETE FROM [dbo].[Customer] WHERE [username]='" + username + "'";
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

        // get all customer
        public List<Customer> GetAllCustomer()
        {
            List<Customer> list = new List<Customer>();
            string sql = "SELECT * FROM [dbo].[Customer]";
            // get data from sql
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                Customer customer = new Customer()
                {
                    ID = (int) dr["ID"],
                    FullName = dr["FullName"].ToString(),
                    Phone = dr["phone"].ToString(),
                    Email = dr["email"] == null ? "": dr["email"].ToString(),
                    Gender = (bool) dr["gender"],
                    Username = dr["username"].ToString()
                };
                list.Add(customer);
            }
             return list;
        }
    }
}
