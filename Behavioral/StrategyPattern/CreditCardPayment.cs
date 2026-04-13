using System;

namespace DesignPatterns.Behavioral.StrategyPattern
{
    /// <summary>
    /// Concrete Strategy - Credit card payment
    /// </summary>
    public class CreditCardPayment : IPaymentStrategy
    {
        private string _cardNumber;
        private string _cardHolder;

        public CreditCardPayment(string cardNumber, string cardHolder)
        {
            _cardNumber = cardNumber;
            _cardHolder = cardHolder;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"💳 Paid ${amount:F2} using Credit Card");
            Console.WriteLine($"   Card: **** **** **** {_cardNumber.Substring(_cardNumber.Length - 4)}");
            Console.WriteLine($"   Holder: {_cardHolder}");
        }
    }
}