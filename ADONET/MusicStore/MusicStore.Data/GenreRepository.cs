using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace MusicStore.Data
{
    public class GenreRepository
    {
        public static IList<Genre> GetGenres()
        {
            SqlCommand command = null;
            IList<Genre> genreList = new List<Genre>();
            string selectStatement = "SELECT GenreId, name, Description " +
                                 "FROM GENRE";

            try
            {
                command = new SqlCommand(selectStatement, MusicStoreDb.GetConnection());
                SqlDataReader reader = null;

                command.Connection.Open();
                reader = command.ExecuteReader();

                int genreIdOrdinal = reader.GetOrdinal("GenreId");
                int genreNameOrdinal = reader.GetOrdinal("Name");
                int genreDescriptionOrdinal = reader.GetOrdinal("Description");

                while (reader.Read())
                {
                    Genre genre = new Genre();

                    genre.ID = reader.GetInt32(genreIdOrdinal);
                    genre.Name = reader.IsDBNull(genreNameOrdinal) ? null : reader.GetString(genreNameOrdinal);
                    genre.Description = reader.IsDBNull(genreDescriptionOrdinal)
                        ? null
                        : reader.GetString(genreDescriptionOrdinal);

                    genreList.Add(genre);
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

            return genreList;
        }
    }
}
