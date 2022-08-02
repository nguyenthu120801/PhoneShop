using WebMVC.Connection;
using WebMVC.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace WebMVC.Models
{
    public class DAOAccount : ConnectDatabase
    {
        // check account valid
        public bool CheckAccountValid(string username, string password)
        {
            string sql = "SELECT * FROM [dbo].[Account]";
            // get data from sql
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                // if account valid
                if(username.Equals(dr["username"].ToString()) && password.Equals(dr["password"].ToString()))
                {
                    return true;
                }
            }

            return false;
        }
        // get blocked based on username
        public bool getIsBlocked(string username)
        {
            bool blocked = false;
            string sql = "SELECT * FROM [dbo].[Account] where [username] = '" + username + "'";
            // get data
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                blocked = (bool) dr["IsBlocked"];
            }
            return blocked;
        }
        // get role name based on username
        public string getRoleName(string username)
        {
            string sql = "SELECT [RoleName]\n"
                    + "FROM [dbo].[Account]\n"
                    + "WHERE [username] = '" + username + "'";
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                return dr["RoleName"].ToString();
            }
                return null;
        }
        // check username exist
        public bool CheckUsernameExist(string username)
        {
            string sql = "SELECT * FROM [dbo].[Account]";
            // get data
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                // if username existed
                if (username.Equals(dr["username"].ToString()))
                {
                    return true;
                }
            }

             return false;
        }
        // add account
        public int AddAccount(Account account)
        {
            int number = 0; // number of row affected
            string sql = "INSERT INTO [dbo].[Account]\n"
                    + "           ([username]\n"
                    + "           ,[password]\n"
                    + "           ,[RoleName]\n"
                    + "           ,[IsBlocked])\n"
                    + "     VALUES\n"
                    + "           (@user,@pass,@role,@blocked)";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            // set value for parameter
            cmd.Parameters.AddWithValue("@user", account.Username);
            cmd.Parameters.AddWithValue("@pass", account.Password);
            cmd.Parameters.AddWithValue("@role", account.RoleName);
            cmd.Parameters.AddWithValue("@blocked", account.IsBlocked);
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
        // update account 
        public int UpdateAccount(string username, string password)
        {
            int number = 0; // number of row affected
            string sql = "UPDATE [dbo].[Account]\n"
                    + "SET [password] = @pass\n"
                    + "WHERE [username] = @user";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            // set value for parameter
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@pass", password);
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

        // get all account
        public List<Account> GetAllAccount()
        {
            List<Account> list = new List<Account>();
            String sql = "SELECT * FROM [dbo].[Account]";
            // get data
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                Account account = new Account()
                {
                    Username = dr["username"].ToString(),
                    Password = dr["password"].ToString(),
                    RoleName = dr["RoleName"].ToString(),
                    IsBlocked = (bool)dr["IsBlocked"]
                };
                list.Add(account);
            }

            return list;
        }

        // update blocked
        public int UpdateBlocked(string username, bool blocked)
        {
            int number = 0; // number of row affected
            string sql = "UPDATE [dbo].[Account]\n"
                    + "SET [IsBlocked] = @blocked\n"
                    + "WHERE [username] = @user";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            // set value for parameter
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@blocked", blocked);
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

        // update role
        public int UpdateRole(string role, string username)
        {
            int number = 0; // number of row affected
            string sql = "UPDATE [dbo].[Account]\n"
                    + "SET [RoleName] = @role\n"
                    + "WHERE [username] = @user\n";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            // set value for parameter
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@role", role);
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
