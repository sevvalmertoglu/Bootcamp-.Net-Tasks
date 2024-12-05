public class Order_Service
{
    private readonly IOrderRepository _orderRepository;
    private readonly IEmailService _emailService;

    public Order_Service(IOrderRepository orderRepository, IEmailService emailService)
    {
        _orderRepository = orderRepository;
        _emailService = emailService;
    }

    public void AddOrder(string orderDetails, string customerEmail)
    {
        Console.WriteLine("Order added: " + orderDetails);

        _orderRepository.Save(orderDetails);

        _emailService.SendEmail(customerEmail, "Your order has been successfully placed!");
    }
}

// Veritabanı işlemleri
public interface IOrderRepository
{
    void Save(string orderDetails);
}

public class OrderRepository : IOrderRepository
{
    public void Save(string orderDetails)
    {
        Console.WriteLine("Order saved to database: " + orderDetails);
    }
}

// E-posta işlemleri
public interface IEmailService
{
    void SendEmail(string email, string message);
}

public class EmailService : IEmailService
{
    public void SendEmail(string email, string message)
    {
        Console.WriteLine($"Email sent to {email}: {message}");
    }
}
