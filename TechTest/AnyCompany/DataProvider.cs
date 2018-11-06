using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany
{
    public class DataProvider
    {
        private OrderRepository orderRepository = new OrderRepository();

        public Customer GetCustomerWithOrder(int customerId)
        {
            var customer = CustomerRepository.Load(customerId);
            customer.Orders = orderRepository.GetOrdersForCustomer(customerId);

            return customer;
        }

    }
}
