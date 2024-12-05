namespace Week1_DIP.GoodExample
{
    public interface IMessageService
    {
        void Send(string message);
    }

    public class EmailService : IMessageService
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    public class SmsService : IMessageService
    {
        public void Send(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }

    public class NotificationManager
    {
        private readonly IMessageService _messageService;

        // Dependency injection
        public NotificationManager(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void Notify(string message)
        {
            _messageService.Send(message);
        }
    }
}