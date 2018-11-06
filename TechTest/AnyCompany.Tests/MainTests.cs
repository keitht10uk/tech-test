using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyCompany;

namespace AnyCompany.Tests
{
    [TestFixture]
    public class MainTests
    {
        [Test]
        public void PlaceOrderShould()
        {
            var order = new Order
            {
                CustomorId = 1,
                Amount = 20
            };

            var orderService = new OrderService();
            var sucess = orderService.PlaceOrder(order);
            Assert.IsTrue(sucess, "Order not save sucessfully");
        }

        [Test]
        public void GetCustomerWithOrdersShould()
        {
            const int customerId = 1;

            var dataProvider = new DataProvider();
            var customer = dataProvider.GetCustomerWithOrder(customerId);
            Assert.IsNotNull(customer, "Customer not found");
            Assert.IsTrue(customer.Orders.Any(), "No order found");
        }
    }
}
