using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreData
{
    public class GenreRepository
    {
        public static string GetGenreById(int genreId)
        {
            SqlCommand command = null;
            string selectStatement = "SELECT Name FROM Genre WHERE GenreId=@genreId";
            string genre = "";

            try
            {
                command = new SqlCommand(selectStatement, MusicStoreDb.GetConnection());
                command.Parameters.Add(new SqlParameter("@genreId", genreId));
                command.Connection.Open();
                genre = (string)command.ExecuteScalar();
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

            return genre;
        }

        public static IList<Genre> GetAllGenres()
        {
            IList<Genre> genreList = new List<Genre>();
            SqlCommand command = null;
            string selectStatement = "SELECT GenreId, Name, Description FROM Genre";

            try
            {
                command = new SqlCommand(selectStatement, MusicStoreDb.GetConnection());

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                int genreIdOrdinal = reader.GetOrdinal("GenreId");
                int nameOrdinal = reader.GetOrdinal("Name");
                int descriptionOrdinal = reader.GetOrdinal("Description");

                while (reader.Read())
                {
                    Genre genre = new Genre();

                    genre.GenreId = reader.GetInt32(genreIdOrdinal);
                    genre.Name = reader.GetString(nameOrdinal);
                    genre.Description = reader.GetString(descriptionOrdinal);

                    genreList.Add(genre);
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

            return genreList;
        }
    }
}
