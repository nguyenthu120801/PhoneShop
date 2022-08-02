using WebMVC.Connection;
using WebMVC.Entity;
using System.Collections.Generic;
using System.Data;
namespace WebMVC.Models
{
    public class DAOCategory : ConnectDatabase
    {
        // get all category
        public List<Category> GetAllCategory()
        {
            List<Category> list = new List<Category>();
            string sql = "SELECT * FROM [dbo].[Category]";
            // get data
            DataTable data = getData(sql);
            // loop for traverse through all row
            foreach (DataRow dr in data.Rows)
            {
                Category category = new Category()
                {
                    ID = (int) dr["ID"],
                    name = dr["name"].ToString()
                };
                list.Add(category);
            }
                return list;
        }
    }
}
