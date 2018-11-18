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
    public class DataInserter
    {
        public static int UpdateOrderAndOrderDetail(Order order, OrderDetail orderDetail)
        {
            int orderResult = 0;
            int orderDetailResult = 0;
            int result = 0;
            SqlCommand orderCommand = null;
            SqlCommand orderDetailCommand = null;
            SqlConnection connection = MusicStoreDb.GetConnection();
            SqlTransaction transaction = null;
            SqlParameter orderId = new SqlParameter("@orderId", SqlDbType.Int);
            orderId.Direction = ParameterDirection.Output;
            string orderInsertStatement ="InsertOrder";

            string orderDetailInsertStatement = "INSERT INTO ORDERDETAIL(OrderId, AlbumId, Quantity, UnitPrice) " +
                                          "VALUES(@orderId, @albumId, @quantity, @unitPrice)";
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                orderCommand = new SqlCommand(orderInsertStatement, connection, transaction);
                orderCommand.CommandType = CommandType.StoredProcedure;
                orderDetailCommand = new SqlCommand(orderDetailInsertStatement, connection, transaction);

                orderCommand.Parameters.Add(orderId);
                orderCommand.Parameters.Add(new SqlParameter("@orderDate", order.OrderDate));
                orderCommand.Parameters.Add(new SqlParameter("@username", order.UserName));
                orderCommand.Parameters.Add(new SqlParameter("@firstName", order.FirstName));
                orderCommand.Parameters.Add(new SqlParameter("@lastName", order.LastName));
                orderCommand.Parameters.Add(new SqlParameter("@address", order.Address));
                orderCommand.Parameters.Add(new SqlParameter("@city", order.City));
                orderCommand.Parameters.Add(new SqlParameter("@state", order.State));
                orderCommand.Parameters.Add(new SqlParameter("@postalCode", order.PostalCode));
                orderCommand.Parameters.Add(new SqlParameter("@country", order.Country));
                orderCommand.Parameters.Add(new SqlParameter("@phone", "00/123456789"));
                orderCommand.Parameters.Add(new SqlParameter("@email", "default@default.com"));
                orderCommand.Parameters.Add(new SqlParameter("@total", order.Total));

                orderResult = orderCommand.ExecuteNonQuery();

                orderDetailCommand.Parameters.Add(new SqlParameter("@orderId", orderId.Value));
                orderDetailCommand.Parameters.Add(new SqlParameter("@albumId", orderDetail.AlbumId));
                orderDetailCommand.Parameters.Add(new SqlParameter("@quantity", orderDetail.Quantity));
                orderDetailCommand.Parameters.Add(new SqlParameter("@unitPrice", orderDetail.UnitPrice));

                orderDetailResult = orderDetailCommand.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();

            }
            finally
            {
                connection?.Close();
            }

            if (orderResult > 0 && orderDetailResult > 0)
            {
                result = 1;
            }

            return result;
        }
    }
}
