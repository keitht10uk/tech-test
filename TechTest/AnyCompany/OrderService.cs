namespace AnyCompany
{
    public class OrderService
    {
        private readonly OrderRepository orderRepository = new OrderRepository();

        public bool PlaceOrder(Order order)
        {
            var customer = CustomerRepository.Load(order.CustomorId);

            if (order.Amount == 0)
                return false;

            if (customer.Country == "UK")
                order.VAT = 0.2m;
            else
                order.VAT = 0;

            orderRepository.Save(order);

            return true;
        }
    }
}
