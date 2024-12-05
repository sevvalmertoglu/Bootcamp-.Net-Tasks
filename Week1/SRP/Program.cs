// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main(string[] args)
    {
        IOrderRepository orderRepository = new OrderRepository();
        IEmailService emailService = new EmailService();

        // Order_Service
        Order_Service orderService = new Order_Service(orderRepository, emailService);
        orderService.AddOrder("Order details for product XYZ", "customer@example.com");
    }
}

