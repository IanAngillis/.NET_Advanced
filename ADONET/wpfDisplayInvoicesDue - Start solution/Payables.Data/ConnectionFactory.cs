using System.Configuration;
using System.Data.SqlClient;

namespace Payables.Data
{
    public class ConnectionFactory
    {
        public static SqlConnection CreatePayablesConnection()
        {
            //string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Payables;Integrated Security=True;";

            string connectionString = ConfigurationManager.ConnectionStrings["PayablesConnectionString"].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
}