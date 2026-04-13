using System;

namespace DesignPatterns.Behavioral.StrategyPattern
{
    /// <summary>
    /// Concrete Strategy - PayPal payment
    /// </summary>
    public class PayPalPayment : IPaymentStrategy
    {
        private string _email;

        public PayPalPayment(string email)
        {
            _email = email;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"💰 Paid ${amount:F2} using PayPal");
            Console.WriteLine($"   Account: {_email}");
        }
    }
}