using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreData
{
    public class ArtistRepository
    {

        public static string GetArtistById(int artistId)
        {
            SqlCommand command = null;
            string selectStatement = "SELECT Name FROM Artist WHERE ArtistId=@artistId";
            string artistName = "";

            try
            {
                command = new SqlCommand(selectStatement, MusicStoreDb.GetConnection());
                command.Parameters.Add(new SqlParameter("@artistId", artistId));
                command.Connection.Open();
                artistName = (string) command.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                //
            }
            catch (FormatException ex)
            {
                //

            }
            finally
            {
                command.Connection?.Close();
            }

            return artistName;

        }

        public static IList<Artist> GetAllArtists()
        {
            IList<Artist> artistList = new List<Artist>();
            SqlCommand command = null;
            string selectStatement = "SELECT ArtistId, Name FROM Artist";

            try
            {
                command = new SqlCommand(selectStatement, MusicStoreDb.GetConnection());
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                int artistIdOrdinal = reader.GetOrdinal("ArtistId");
                int nameOrdinal = reader.GetOrdinal("Name");

                while (reader.Read())
                {
                    Artist artist = new Artist();

                    artist.ArtistId = reader.GetInt32(artistIdOrdinal);
                    artist.Name = reader.GetString(nameOrdinal);

                    artistList.Add(artist);
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                command.Connection?.Close();
            }


            return artistList;
        }
        
    }
}
