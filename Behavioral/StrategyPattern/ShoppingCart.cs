using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.StrategyPattern
{
    /// <summary>
    /// Context - Shopping cart that uses payment strategy
    /// </summary>
    public class ShoppingCart
    {
        private List<string> _items;
        private IPaymentStrategy _paymentStrategy;

        public ShoppingCart()
        {
            _items = new List<string>();
        }

        public void AddItem(string item)
        {
            _items.Add(item);
            Console.WriteLine($"➕ Added: {item}");
        }

        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            _paymentStrategy = strategy;
        }

        public void Checkout(decimal totalAmount)
        {
            Console.WriteLine($"\n🛒 Cart Items:");
            foreach (var item in _items)
            {
                Console.WriteLine($"   - {item}");
            }
            Console.WriteLine($"\n💵 Total: ${totalAmount:F2}\n");

            if (_paymentStrategy == null)
            {
                Console.WriteLine("⚠️ Please select a payment method!");
                return;
            }

            _paymentStrategy.Pay(totalAmount);
            Console.WriteLine("✅ Payment successful!\n");
        }
    }
}