using Week1_SRP.GoodExample;
class Program
{
    static void Main(string[] args)
    {
        IOrderRepository orderRepository = new OrderRepository();
        IEmailService emailService = new EmailService();

        OrderService orderService = new OrderService(orderRepository, emailService);
        orderService.AddOrder("Order details for product XYZ", "customer@example.com");
    }
}

