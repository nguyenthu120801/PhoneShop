using System.Data;
using System.Data.SqlClient;
namespace WebMVC.Connection
{
    public class ConnectDatabase
    {
        protected SqlConnection connect;
        public ConnectDatabase()
        {    
            string server = @"DESKTOP-L8PU1VQ";
            string database = "PHONE_SHOPPING";
            string StrConnect = "server=" + server + ";database=" + database + ";Integrated security = true;TrustServerCertificate= true";
            connect = new SqlConnection(StrConnect);
        }
        // get data based on sql
        public DataTable getData(string sql)
        {
            DataTable data = new DataTable();
            // create sql command 
            SqlCommand command = new SqlCommand(sql, connect);
            SqlDataAdapter adapter = new SqlDataAdapter();
            // select command
            adapter.SelectCommand = command;
            // fill in data
            adapter.Fill(data);
            return data;
        }
    }
}
