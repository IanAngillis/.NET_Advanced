using System.Data.SqlClient;
using System.Configuration;

namespace MusicStore.Data
{
    class MusicStoreDb
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MvcMusicStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
