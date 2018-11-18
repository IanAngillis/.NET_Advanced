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
    class OrderDetailRepository
    {
        public static IList<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            IList<OrderDetail> orderDetailList = new List<OrderDetail>();
            SqlCommand command = null;
            string selectStatement =
                "SELECT OrderDetailId, OrderId, AlbumId, Quantity, UnitPrice " +
                "FROM OrderDetail " +
                "WHERE OrderId=@orderId";

            try
            {
                command = new SqlCommand(selectStatement, MusicStoreDb.GetConnection());
                command.Parameters.Add(new SqlParameter("@orderId", orderId));
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                int orderDetailIdOrdinal = reader.GetOrdinal("OrderDetailId");
                int orderIdOrdinal = reader.GetOrdinal("OrderId");
                int albumIdOrdinal = reader.GetOrdinal("AlbumId");
                int quantityOrdinal = reader.GetOrdinal("Quantity");
                int unitpriceOrdinal = reader.GetOrdinal("UnitPrice");

                while (reader.Read())
                {
                    OrderDetail orderDetail = new OrderDetail();

                    orderDetail.OrderDetailId = reader.GetInt32(orderDetailIdOrdinal);
                    orderDetail.OrderId = reader.GetInt32(orderIdOrdinal);
                    orderDetail.AlbumId = reader.GetInt32(albumIdOrdinal);
                    orderDetail.Quantity = reader.GetInt32(quantityOrdinal);
                    orderDetail.UnitPrice = Convert.ToDouble(reader.GetSqlDecimal(unitpriceOrdinal));

                    orderDetailList.Add(orderDetail);
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

            return orderDetailList;
        }
    }
}
