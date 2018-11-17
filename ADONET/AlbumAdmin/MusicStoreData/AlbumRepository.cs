using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreData
{
    public class AlbumRepository
    {
        public static IList<Album> GetAlbums()
        {
            IList<Album> albumList = new List<Album>();
            SqlCommand command = null;
            string selectStatement = "SELECT AlbumId, GenreId, ArtistId, Title, Price, AlbumArtUrl " +
                                     "FROM Album";

            try
            {
                command = new SqlCommand(selectStatement, MusicStoreDb.GetConnection());

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                int albumIdOrdinal = reader.GetOrdinal("AlbumId");
                int genreIdOrdinal = reader.GetOrdinal("GenreId");
                int artistIdOrdinal = reader.GetOrdinal("ArtistId");
                int titleOrdinal = reader.GetOrdinal("Title");
                int priceOrdinal = reader.GetOrdinal("Price");
                int albumArtUrlOrdinal = reader.GetOrdinal("AlbumArturl");

                while (reader.Read())
                {
                    Album album = new Album();

                    album.AlbumId = reader.GetInt32(albumIdOrdinal);
                    album.GenreId = reader.GetInt32(genreIdOrdinal);
                    album.ArtistId = reader.GetInt32(artistIdOrdinal);
                    album.Title = reader.GetString(titleOrdinal);
                    album.Price = string.Format("€{0:#.00}", reader.GetSqlDecimal(priceOrdinal));
                    album.AlbumArtUrl = reader.IsDBNull(albumArtUrlOrdinal) ? null : reader.GetString(albumArtUrlOrdinal);

                    albumList.Add(album);

                }

                reader.Close();

            }
            catch (SqlException ex)
            {

            }
            finally
            {
                command.Connection?.Close();
            }

            return albumList;
        }

        public static Album GetAlbumById(int albumId)
        {
            SqlCommand command = null;
            string selectStatement = "SELECT AlbumId, GenreId, ArtistId, Title, Price, AlbumArtUrl " +
                                     "FROM Album WHERE AlbumId=@albumId";
            Album album = new Album();


            try
            {
                command = new SqlCommand(selectStatement, MusicStoreDb.GetConnection());
                command.Parameters.Add(new SqlParameter("@albumId", albumId));
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                int albumIdOrdinal = reader.GetOrdinal("AlbumId");
                int genreIdOrdinal = reader.GetOrdinal("GenreId");
                int artistIdOrdinal = reader.GetOrdinal("ArtistId");
                int titleOrdinal = reader.GetOrdinal("Title");
                int priceOrdinal = reader.GetOrdinal("Price");
                int albumArtUrlOrdinal = reader.GetOrdinal("AlbumArturl");

                while (reader.Read())
                {
                    album.AlbumId = reader.GetInt32(albumIdOrdinal);
                    album.GenreId = reader.GetInt32(genreIdOrdinal);
                    album.ArtistId = reader.GetInt32(artistIdOrdinal);
                    album.Title = reader.GetString(titleOrdinal);
                    album.Price = string.Format("€{0:#.00}", reader.GetSqlDecimal(priceOrdinal));
                    album.AlbumArtUrl = reader.IsDBNull(albumArtUrlOrdinal) ? null : reader.GetString(albumArtUrlOrdinal);
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

            return album;
        }

        public static void UpdateAlbumByAlbumId(Album updatedAlbum)
        {
            SqlCommand command = null;
            string activeQuery =
                "UPDATE Album " +
                "SET GenreId=@genreId, ArtistId=@artistId, Title=@title, Price=@Price, AlbumArtUrl=@albumArtUrl " +
                "WHERE AlbumId=@albumId";

            try
            {
                command = new SqlCommand(activeQuery, MusicStoreDb.GetConnection());
                command.Parameters.Add(new SqlParameter("@albumId", updatedAlbum.AlbumId));
                command.Parameters.Add(new SqlParameter("@genreId", updatedAlbum.GenreId));
                command.Parameters.Add(new SqlParameter("@artistId", updatedAlbum.ArtistId));
                command.Parameters.Add(new SqlParameter("@title", updatedAlbum.Title));
                command.Parameters.Add(new SqlParameter("@Price", 8.99));
                command.Parameters.Add(new SqlParameter("@albumArtUrl", updatedAlbum.AlbumArtUrl));

                command.Connection.Open();
                int result = command.ExecuteNonQuery();

                if (result != 1)
                {
                    throw new Exception("Operation failed");
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                command.Connection?.Close();
            }

        }

    }
}
