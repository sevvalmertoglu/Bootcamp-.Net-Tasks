namespace Week1_OCP.BadExample
{
    public class PaymentProcessor
    {
        public void ProcessPayment(string paymentType, double amount)
        {
            if (paymentType == "CreditCard")
            {
                Console.WriteLine($"Processed {amount} using Credit Card.");
            }
            else if (paymentType == "PayPal")
            {
                Console.WriteLine($"Processed {amount} using PayPal.");
            }
            else
            {
                Console.WriteLine("Invalid payment type.");
            }
        }
    }
}
