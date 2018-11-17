using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payables.Data
{
    public class InvoiceRepository
    {
        //TODO Implement
        public static IList<Invoice> GetInvoicesDue()
        {
            var invoices = new List<Invoice>();
            SqlDataReader reader = null;

            SqlConnection connection = ConnectionFactory.CreatePayablesConnection();
            string selectStatement = "SELECT InvoiceNumber, InvoiceDate, InvoiceTotal, PaymentTotal, CreditTotal, DueDate " +
                                     "FROM dbo.Invoices " +
                                     "WHERE InvoiceTotal - PaymentTotal - CreditTotal > 0 " +
                                     "ORDER BY DueDate ASC";

            var selectCommand = new SqlCommand(selectStatement, connection);

            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader();

                int invoiceNumberOrdinal = reader.GetOrdinal("InvoiceNumber");
                int invoiceDateOrdinal = reader.GetOrdinal("InvoiceDate");
                int invoiceTotalOrdinal = reader.GetOrdinal("InvoiceTotal");
                int paymentTotalOrdinal = reader.GetOrdinal("PaymentTotal");
                int creditTotalOrdinal = reader.GetOrdinal("CreditTotal");
                int dueDateOrdinal = reader.GetOrdinal("DueDate");

                while (reader.Read())
                {
                    Invoice invoice = new Invoice
                    {
                        InvoiceNumber = reader.IsDBNull(invoiceNumberOrdinal) ? "" : reader.GetString(invoiceNumberOrdinal),
                        InvoiceDate = reader.IsDBNull(invoiceDateOrdinal) ? DateTime.MinValue : reader.GetDateTime(invoiceDateOrdinal),
                        InvoiceTotal = reader.GetDecimal(invoiceTotalOrdinal),
                        PaymentTotal = reader.GetDecimal(paymentTotalOrdinal),
                        CreditTotal = reader.GetDecimal(creditTotalOrdinal),
                        DueDate = reader.GetDateTime(dueDateOrdinal)
                    };

                    //if (!reader.IsDBNull(invoiceNumberOrdinal))
                    //{
                    //    invoice.InvoiceNumber = reader.GetString(invoiceNumberOrdinal);
                    //}
                    invoices.Add(invoice);
                }

            }
            finally
            {
                reader?.Close();

                connection.Close();
            }

            return invoices;
        }
    }
}
