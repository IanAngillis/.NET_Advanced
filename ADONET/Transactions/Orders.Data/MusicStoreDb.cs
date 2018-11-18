using System.Configuration;
using System.Data.SqlClient;

namespace Orders.Data
{
    public class MusicStoreDb
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MusicStoreConnectionString"].ConnectionString);
        }
    }
}
