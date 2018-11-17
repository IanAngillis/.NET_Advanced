using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Data
{
    public class AlbumRepository
    {
        public static IList<Album> GetAlbumsByGenre(int genreId)
        {
            IList<Album> albumList = new List<Album>();
            SqlCommand command = null;
            string selectStatement = "SELECT AlbumId, GenreId, ArtistId, Title, Price, AlbumArtUrl " +
                                     "FROM Album " +
                                     "WHERE GenreId = @GenreId";

            try
            {
                command = new SqlCommand(selectStatement, MusicStoreDb.GetConnection());
                command.Parameters.Add(new SqlParameter("@GenreId", genreId));

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                int albumIdOrdinal = reader.GetOrdinal("AlbumId");
                int genreIdOrdinal = reader.GetOrdinal("GenreId");
                int artistOrdinal = reader.GetOrdinal("ArtistId");
                int titleOrdinal = reader.GetOrdinal("Title");
                int priceOrdinal = reader.GetOrdinal("Price");
                int albumArtUrlOrdinal = reader.GetOrdinal("AlbumArtUrl");

                while (reader.Read())
                {
                    Album album = new Album();

                    album.AlbumId = reader.GetInt32(albumIdOrdinal);
                    album.GenreId = reader.GetInt32(genreIdOrdinal);
                    album.ArtistId = reader.GetInt32(artistOrdinal);
                    album.Title = reader.GetString(titleOrdinal);
                    album.Price = reader.GetSqlDecimal(priceOrdinal);
                    album.AlbumArtUrl = reader.IsDBNull(albumArtUrlOrdinal)
                        ? null
                        : reader.GetString(albumArtUrlOrdinal);
             
                    albumList.Add(album);
                }
                reader.Close();

            }
            finally
            {
                command.Connection?.Close();
            }

            return albumList;
        }
    }
}
