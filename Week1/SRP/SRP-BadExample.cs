public class OrderService
{
    public void AddOrder(string orderDetails)
    {
        Console.WriteLine("Order added: " + orderDetails);
        SaveToDatabase(orderDetails);
    }

    public void SaveToDatabase(string orderDetails)
    {
        Console.WriteLine("Order saved to database: " + orderDetails);
    }

    public void SendEmail(string email, string message)
    {
        Console.WriteLine($"Email sent to {email}: {message}");
    }
}
