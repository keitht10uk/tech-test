using System.Collections.Generic;
using System.Data.SqlClient;

namespace AnyCompany
{
    internal class OrderRepository
    {
        private static string ConnectionString = @"Data Source=localhost;Database=KeithTest;Trusted_Connection=True;";

        public void Save(Order order)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {

                connection.Open();

                using (var command = new SqlCommand("INSERT INTO [Order] (OrderId, Amount, VAT, CustomerId) VALUES (@OrderId, @Amount, @VAT, @CustomerId)",connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.Parameters.AddWithValue("@OrderId", order.OrderId);
                    command.Parameters.AddWithValue("@Amount", order.Amount);
                    command.Parameters.AddWithValue("@VAT", order.VAT);
                    command.Parameters.AddWithValue("@CustomerId", order.CustomorId);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public IList<Order> GetOrdersForCustomer(int customerId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {

                connection.Open();

                var sql = "Select OrderId, Amount, VAT from [Order] where customerId = " + customerId.ToString();

                var result = new List<Order>();

                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    var reader = command.ExecuteReader();
                   
                    while (reader.Read())
                    {
                        var anOrder = new Order
                        {
                            CustomorId = customerId,
                            OrderId = reader.GetInt32(0),
                            Amount = reader.GetDecimal(1),
                            VAT = reader.GetDecimal(2)
                        };

                        result.Add(anOrder);
                    }
                }

                connection.Close();
                return result;
            }            
        }
    }
}
