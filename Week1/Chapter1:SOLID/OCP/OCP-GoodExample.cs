    namespace Week1_OCP.GoodExample
{
    public interface IPaymentMethod
    {
        void Process(double amount);
    }

    public class CreditCardPayment : IPaymentMethod
    {
        public void Process(double amount)
        {
            Console.WriteLine($"Processed {amount} using Credit Card.");
        }
    }

    public class PayPalPayment : IPaymentMethod
    {
        public void Process(double amount)
        {
            Console.WriteLine($"Processed {amount} using PayPal.");
        }
    }

    // Yeni bir ödeme yöntemi eklemek daha kolay:
    public class BitcoinPayment : IPaymentMethod
    {
        public void Process(double amount)
        {
            Console.WriteLine($"Processed {amount} using Bitcoin.");
        }
    }

    public class Payment_Processor
    {
        private readonly IPaymentMethod _paymentMethod;

        public Payment_Processor(IPaymentMethod paymentMethod)
        {
            _paymentMethod = paymentMethod;
        }

        public void ProcessPayment(double amount)
        {
            _paymentMethod.Process(amount);
        }
    }
}
