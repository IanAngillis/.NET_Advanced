using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Data
{
    public class ArtistRepository
    {
        public static string GetArtistNameById(int artistId)
        {
            SqlCommand command = null;
            string artistName;
            string selectStatement = "SELECT Name " +
                                     "FROM Artist " +
                                     "WHERE ArtistId = @ArtistId";

            try
            {
                command = new SqlCommand(selectStatement, MusicStoreDb.GetConnection());
                command.Parameters.Add(new SqlParameter("@ArtistId", artistId));

                command.Connection.Open();
                artistName = command.ExecuteScalar().ToString();

            }
            finally
            {
                command.Connection?.Close();
            }

            return artistName;
        }
    }
}
