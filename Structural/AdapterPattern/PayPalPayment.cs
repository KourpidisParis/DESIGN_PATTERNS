using System;

namespace DesignPatterns.Structural.AdapterPattern
{
    /// <summary>
    /// Our internal payment system - already compatible
    /// </summary>
    public class PayPalPayment : IPaymentProcessor
    {
        private string _status;

        public void ProcessPayment(decimal amount, string currency)
        {
            Console.WriteLine($"PayPal: Processing payment of {amount} {currency}");
            _status = "Completed";
        }

        public bool ValidatePayment(string accountInfo)
        {
            Console.WriteLine($"PayPal: Validating account {accountInfo}");
            return true;
        }

        public string GetPaymentStatus()
        {
            return _status;
        }
    }
}