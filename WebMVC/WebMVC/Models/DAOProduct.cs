using WebMVC.Connection;
using WebMVC.Entity;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace WebMVC.Models
{
    public class DAOProduct : ConnectDatabase
    {
        // get all product
        public List<Product> GetAllProduct()
        {
            List<Product> list = new List<Product>();
            string sql = "SELECT * FROM [dbo].[Product]";
            // get data from sql
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                Product product = new Product()
                {
                    ProductID = (int) dr["ProductID"],
                    ProductName = dr["ProductName"].ToString().Trim(),
                    Image = dr["image"].ToString(),
                    Price = Convert.ToInt32(dr["price"].ToString().Trim()) ,
                    CategoryID = (int) dr["CategoryID"],
                    isSell = (bool)dr["isSell"]
                };
                list.Add(product);
            }
                return list;
        }
        // get list product based on category 
        public List<Product> GetListProduct(string CategoryID)
        {
            List<Product> list = new List<Product>();
            string sql = " select * from Product where CategoryID= " + CategoryID;
            // get data from sql
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                Product product = new Product()
                {
                    ProductID = (int)dr["ProductID"],
                    ProductName = dr["ProductName"].ToString().Trim(),
                    Image = dr["image"].ToString(),
                    Price = (int)dr["price"],
                    CategoryID = (int)dr["CategoryID"],
                    isSell = (bool)dr["isSell"]
                };
                list.Add(product);
            }
            return list;
        }

        // get image based on product name
        public string getImage(string name)
        {
            string sql = "SELECT [image]  FROM [dbo].[Product] where [ProductName]='" + name + "'";
            // get data from sql
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                return dr["image"].ToString();
            }
                return null;
        }

        // get price based on product name
        public int getPrice(string name)
        {
            string sql = "SELECT [price]  FROM [dbo].[Product] where [ProductName]='" + name + "'";
            int price = 0;
            // get data from sql
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                price= Convert.ToInt32(dr["price"]);
            }
            return price;
        }
        // get product id based on product name
        public int getProductID(string name)
        {
            String sql = "SELECT [ProductID]  FROM [dbo].[Product] where [ProductName]='" + name + "'";
            int ID = 0;
            // get data from sql
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                ID = (int) dr["ProductID"];
            }
            return ID;
        }

       // update sell product
          public int UpdateProduct(bool sell , int ID)
        {
            int number = 0;// number of row affected
            string sql = "UPDATE [dbo].[Product]\n"
                    + "   SET [isSell] = @sell\n"
                    + " WHERE [ProductID]= @ID";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            // set value for parameter
            cmd.Parameters.AddWithValue("@sell", sell);
            cmd.Parameters.AddWithValue("@ID", ID);
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

        // get product from id
        public Product getProduct(int ID)
        {
            string sql = "SELECT * FROM [dbo].[Product]\n"
                    + "WHERE [ProductID] = " + ID;
            // get data from sql
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                Product product = new Product()
                {
                    ProductID = (int)dr["ProductID"],
                    ProductName = dr["ProductName"].ToString(),
                    Image = dr["image"].ToString(),
                    Price = (int)dr["price"],
                    CategoryID = (int)dr["CategoryID"],
                    isSell = (bool)dr["isSell"]
                };
                return product;
            }
            return null;
        }

        // update product
        public int UpdateProduct(Product product)
        {
            int number = 0;// number of row affected
            string sql = "UPDATE [dbo].[Product]\n"
                    + "   SET [ProductName] = @name\n"
                    + "      ,[image] = @image\n"
                    + "      ,[price] = @price\n"
                    + "      ,[CategoryID] = @catID\n"
                    + " WHERE [ProductID]= @ID";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            // set value for parameter
            cmd.Parameters.AddWithValue("@name", product.ProductName);
            cmd.Parameters.AddWithValue("@image", product.Image);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@catID", product.CategoryID);
            cmd.Parameters.AddWithValue("@ID", product.ProductID);
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

        // delete product
        public int DeleteProduct(int ProductID)
        {
            int number = 0;// number of row affected
            String sql = "DELETE FROM [dbo].[Product]\n"
                    + "WHERE [ProductID]= " + ProductID;
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

        // add product
        public int AddProduct(Product product)
        {
            int number = 0;// number of row affected
            string sql = "INSERT INTO [dbo].[Product]\n"
                    + "           ([ProductName]\n"
                    + "           ,[image]\n"
                    + "           ,[price]\n"
                    + "           ,[CategoryID]\n"
                    + "           ,[isSell])\n"
                    + "     VALUES\n"
                    + "(@name,@img,@price,@category,@sell)";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            // set value for parameter
            cmd.Parameters.AddWithValue("@name", product.ProductName);
            cmd.Parameters.AddWithValue("@img", product.Image);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@category", product.CategoryID);
            cmd.Parameters.AddWithValue("@sell", product.isSell);
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
