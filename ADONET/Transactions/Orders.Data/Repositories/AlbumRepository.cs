using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Data.DataClasses;

namespace Orders.Data.Repositories
{
    public class AlbumRepository
    {
        public static IList<Album> GetAlbums()
        {
            IList<Album> albumList = new List<Album>();
            SqlCommand command = null;
            string selectStament = "SELECT AlbumId, GenreId, ArtistId, Title, Price, AlbumArtUrl " +
                                   "FROM ALBUM";
           

            try
            {
                command = new SqlCommand(selectStament, MusicStoreDb.GetConnection());
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                int albumIdOrdinal = reader.GetOrdinal("AlbumId");
                int genreIdOrdinal = reader.GetOrdinal("GenreId");
                int artistIdOrdinal = reader.GetOrdinal("ArtistId");
                int titleOrdinal = reader.GetOrdinal("Title");
                int priceOrdinal = reader.GetOrdinal("Price");
                int albumArtUrlOrdinal = reader.GetOrdinal("AlbumArtUrl");

                while (reader.Read())
                {
                    Album album = new Album();

                    album.AlbumId = reader.GetInt32(albumIdOrdinal);
                    album.GenreId = reader.GetInt32(genreIdOrdinal);
                    album.ArtistId = reader.GetInt32(artistIdOrdinal);
                    album.Title = reader.GetString(titleOrdinal);
                    album.Price = reader.GetSqlDecimal(priceOrdinal).ToDouble();
                    album.AlbumArtUrl = reader.GetString(albumArtUrlOrdinal);

                    albumList.Add(album);
                }

                reader.Close();

            }
            catch (SqlException ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                command.Connection?.Close();
            }

            return albumList;
        }


    }
}
