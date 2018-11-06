using System;
using System.Data.SqlClient;

namespace AnyCompany
{
    public static class CustomerRepository
    {
        private static string ConnectionString = @"Data Source=localhost;Database=KeithTest;Trusted_Connection=True;";

        public static Customer Load(int customerId)
        {
            var customer = new Customer();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT Name,DateOfBirth,Country,CustomerId FROM Customer WHERE CustomerId = " + customerId, connection))
                {
                    var reader = command.ExecuteReader();

                    if (!reader.HasRows) throw new ApplicationException(string.Format("Unable to find Customer Id {0}", customerId));

                    reader.Read();

                    // need to think about database nulls i.e. check reader.IsDBNull for each column                    
                    customer.Name = reader["Name"].ToString();
                    customer.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                    customer.Country = reader["Country"].ToString();
                    customer.CustomerId = (int)reader["CustomerId"];
                }
                connection.Close();
            } 
                       
            return customer;
        }
    }
}
