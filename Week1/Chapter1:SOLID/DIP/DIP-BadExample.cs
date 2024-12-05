namespace Week1_DIP.BadExample
{
    public class EmailService
    {
        public void SendEmail(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    public class NotificationManager
    {
        private EmailService _emailService;

        public NotificationManager()
        {
            _emailService = new EmailService();
        }

        public void Notify(string message)
        {
            _emailService.SendEmail(message);
        }
    }
}