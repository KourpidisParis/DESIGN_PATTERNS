using System;

namespace DesignPatterns.Structural.AdapterPattern
{
    /// <summary>
    /// Client - Our shopping cart that processes payments
    /// It doesn't care which payment provider is used - they all look the same!
    /// </summary>
    public class ShoppingCart
    {
        private IPaymentProcessor _paymentProcessor;

        public void SetPaymentMethod(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        public void Checkout(decimal totalAmount, string accountInfo)
        {
            Console.WriteLine($"\n--- Shopping Cart Checkout ---");
            Console.WriteLine($"Total: ${totalAmount}");

            if (_paymentProcessor.ValidatePayment(accountInfo))
            {
                _paymentProcessor.ProcessPayment(totalAmount, "USD");
                Console.WriteLine($"Payment Status: {_paymentProcessor.GetPaymentStatus()}");
                Console.WriteLine("Order completed successfully!");
            }
            else
            {
                Console.WriteLine("Payment validation failed!");
            }
        }
    }
}