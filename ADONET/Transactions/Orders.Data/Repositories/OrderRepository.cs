using System;
using System.Data;
using System.Data.SqlClient;
using Orders.Data.DataClasses;

//TODO Vragen stellen over duplicate code?

namespace Orders.Data.Repositories
{
    public class OrderRepository
    {
        public static Order GetLastOrder()
        {
            
            Order order = new Order();
            SqlCommand command = null;
            string selectStatement =
                "SELECT OrderId, MAX(OrderDate), Username, Firstname, Lastname, Address, City, State, PostalCode, Country, Phone, Email, Total " +
                "FROM Orders " +
                "GROUP BY OrderId, Username, Firstname, Lastname, Address, City, State, PostalCode, Country, Phone, Email, Total";

            try
            {
                command = new SqlCommand(selectStatement, MusicStoreDb.GetConnection());
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                int orderIdOrdinal = reader.GetOrdinal("OrderId");
                int usernameOrdinal = reader.GetOrdinal("Username");
                int firstNameOrdinal = reader.GetOrdinal("Firstname");
                int lastNameOrdinal = reader.GetOrdinal("Lastname");
                int addressOrdinal = reader.GetOrdinal("Address");
                int cityOrdinal = reader.GetOrdinal("City");
                int stateOrdinal = reader.GetOrdinal("State");
                int postalCodeOrdinal = reader.GetOrdinal("PostalCode");
                int countryOrdinal = reader.GetOrdinal("Country");
                int phoneOrdinal = reader.GetOrdinal("Phone");
                int emailOrdinal = reader.GetOrdinal("Email");
                int totalOrdinal = reader.GetOrdinal("Total");

                
                while (reader.Read())
                {
                    order.OrderId = reader.GetInt32(orderIdOrdinal);
                    order.UserName = reader.GetString(usernameOrdinal);
                    order.FirstName = reader.GetString(firstNameOrdinal);
                    order.LastName = reader.GetString(lastNameOrdinal);
                    order.Address = reader.GetString(addressOrdinal);
                    order.City = reader.GetString(cityOrdinal);
                    order.State = reader.GetString(stateOrdinal);
                    order.PostalCode = reader.GetString(postalCodeOrdinal);
                    order.Country = reader.GetString(countryOrdinal);
                    order.Phone = reader.GetString(phoneOrdinal);
                    order.Email = reader.GetString(emailOrdinal);
                    order.Total = Convert.ToDouble(reader.GetDecimal(totalOrdinal));
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                command.Connection.Close();
            }

            return order;
        }

        public static Order GetOrderByOrderId(int OrderId)
        {
            Order order = new Order();
            SqlCommand command = null;
            string selectStatement =
                "SELECT OrderId, OrderDate, Username, Firstname, Lastname, Address, City, State, PostalCode, Country, Phone, Email, Total " +
                "FROM Orders " +
                "WHERE OrderId=@orderId";

            try
            {
                command = new SqlCommand(selectStatement, MusicStoreDb.GetConnection());
                command.Parameters.Add(new SqlParameter("@orderId", OrderId));
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                int orderIdOrdinal = reader.GetOrdinal("OrderId");
                int orderDateOrdinal = reader.GetOrdinal("OrderDate");
                int usernameOrdinal = reader.GetOrdinal("Username");
                int firstNameOrdinal = reader.GetOrdinal("Firstname");
                int lastNameOrdinal = reader.GetOrdinal("Lastname");
                int addressOrdinal = reader.GetOrdinal("Address");
                int cityOrdinal = reader.GetOrdinal("City");
                int stateOrdinal = reader.GetOrdinal("State");
                int postalCodeOrdinal = reader.GetOrdinal("PostalCode");
                int countryOrdinal = reader.GetOrdinal("Country");
                int phoneOrdinal = reader.GetOrdinal("Phone");
                int emailOrdinal = reader.GetOrdinal("Email");
                int totalOrdinal = reader.GetOrdinal("Total");


                while (reader.Read())
                {
                    order.OrderId = reader.GetInt32(orderIdOrdinal);
                    order.OrderDate = reader.IsDBNull(orderDateOrdinal) ? DateTime.Now.Date : reader.GetDateTime(orderDateOrdinal);
                    order.UserName = reader.GetString(usernameOrdinal);
                    order.FirstName = reader.GetString(firstNameOrdinal);
                    order.LastName = reader.GetString(lastNameOrdinal);
                    order.Address = reader.GetString(addressOrdinal);
                    order.City = reader.GetString(cityOrdinal);
                    order.State = reader.GetString(stateOrdinal);
                    order.PostalCode = reader.GetString(postalCodeOrdinal);
                    order.Country = reader.GetString(countryOrdinal);
                    order.Phone = reader.GetString(phoneOrdinal);
                    order.Email = reader.GetString(emailOrdinal);
                    order.Total = Convert.ToDouble(reader.GetDecimal(totalOrdinal));

                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                command.Connection.Close();
            }

            return order;
        }

        public static Boolean OrderExists(int orderId)
        {
            Order order = GetOrderByOrderId(orderId);

            return order.OrderId != -1 ? true : false;
        }

        public static int GetHighestOrderId()
        {
            int highestOrderId = 0;
            SqlCommand command = null;
            string selectStatement = "SELECT MAX(OrderId) " +
                                     "FROM Orders";

            try
            {
                command = new SqlCommand(selectStatement, MusicStoreDb.GetConnection());
                command.Connection.Open();
                highestOrderId = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                command.Connection?.Close();
            }

            return highestOrderId;
        }
    }
}
