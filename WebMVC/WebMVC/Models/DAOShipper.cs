using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebMVC.Connection;
using WebMVC.Entity;
namespace WebMVC.Models
{
    public class DAOShipper: ConnectDatabase
    {
        // get profile
        public Shipper getProfile(string username)
        {
            string sql = "SELECT [FullName],[phone],[email],[gender]\n"
                    + "FROM [dbo].[Shipper]\n"
                    + "WHERE [username]='" + username + "'";
            // get data from sql
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                Shipper shipper = new Shipper()
                {
                    FullName = dr["FullName"].ToString(),
                    Phone = dr["phone"].ToString(),
                    Email = dr["email"] == null ? "" : dr["email"].ToString(),
                    Gender = (bool)dr["gender"]
                };
                return shipper;
            }
            return null;
        }

        // get id based on username
        public int getID(string username)
        {
            int ID = 0;
            string sql = "SELECT [ID]\n"
                    + "FROM [dbo].[Shipper]\n"
                    + "where [username]='" + username + "'";
            // get data from sql
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                ID = (int)dr["ID"];
            }

            return ID;
        }

        // update shipper
        public int UpdateShipper(Shipper shipper)
        {
            int number = 0;// number of row affected
            string sql;
            // if not set email
            if (shipper.Email == null)
            {
                sql = "UPDATE [dbo].[Shipper]\n"
                 + "SET [FullName] = @name,\n"
                 + "[phone] = @phone,\n"
                 + "[email] = NULL,\n"
                 + "[gender] = @gender\n"
                 + "WHERE [username] = @username";
            }
            else
            {
                sql = "UPDATE [dbo].[Shipper]\n"
                + "SET [FullName] = @name,\n"
                + "[phone] = @phone,\n"
                + "[email] = @email,\n"
                + "[gender] = @gender\n"
                + "WHERE [username] = @username";
            }

            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            // set value for parameter
            cmd.Parameters.AddWithValue("@name", shipper.FullName);
            cmd.Parameters.AddWithValue("@phone", shipper.Phone);
            // if set email
            if (shipper.Email != null)
            {
                cmd.Parameters.AddWithValue("@email", shipper.Email);
            }
            cmd.Parameters.AddWithValue("@gender", shipper.Gender);
            cmd.Parameters.AddWithValue("@username", shipper.Username);
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

        // add shipper
        public int AddShipper(Shipper shipper)
        {
            int number = 0;// number of row affected
            string sql ;
            // if not set email
            if(shipper.Email == null)
            {
                sql = "INSERT INTO [dbo].[Shipper]\n"
                       + "           ([FullName]\n"
                       + "           ,[phone]\n"
                       + "           ,[email]\n"
                       + "           ,[gender]\n"
                       + "           ,[active]\n"
                       + "           ,[username]) VALUES\n"
                       + "(@name,@phone,NULL,@gender,@active,@username)";
            }
            else
            {
                sql = "INSERT INTO [dbo].[Shipper]\n"
                       + "           ([FullName]\n"
                       + "           ,[phone]\n"
                       + "           ,[email]\n"
                       + "           ,[gender]\n"
                       + "           ,[active]\n"
                       + "           ,[username]) VALUES\n"
                        + "(@name,@phone,@email,@gender,@active,@username)";
            }
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            // set value for parameter
            cmd.Parameters.AddWithValue("@name", shipper.FullName);
            cmd.Parameters.AddWithValue("@phone", shipper.Phone);
            // if set email
            if (shipper.Email != null)
            {
                cmd.Parameters.AddWithValue("@email", shipper.Email);
            }
            cmd.Parameters.AddWithValue("@active", shipper.active);
            cmd.Parameters.AddWithValue("@gender", shipper.Gender);
            cmd.Parameters.AddWithValue("@username", shipper.Username);
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

        // get all shipper
        public List<Shipper> GetAllShipper()
        {
            List<Shipper> list = new List<Shipper>();
            string sql = "SELECT * FROM [dbo].[Shipper]";
            // get data from sql
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                Shipper shipper = new Shipper()
                {
                    ID = (int)dr["ID"],
                    FullName = dr["FullName"].ToString(),
                    Phone = dr["phone"].ToString(),
                    Email = dr["email"] == null ? "" : dr["email"].ToString(),
                    Gender = (bool) dr["gender"],
                    active = (bool) dr["active"],
                    Username = dr["username"].ToString()
                };
                list.Add(shipper);
            }
            return list;
        }

        // update active shipper
        public int UpdateShipper(bool active, int ShipID)
        {
            int number = 0;// number of row affected
            string sql = "UPDATE [dbo].[Shipper]\n"
                    + "SET [active] = @active\n"
                    + "WHERE [ID] = @ID";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            // set value for parameter
            cmd.Parameters.AddWithValue("@active", active);
            cmd.Parameters.AddWithValue("@ID", ShipID);
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
