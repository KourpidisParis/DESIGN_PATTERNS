using System;

namespace DesignPatterns.Behavioral.StrategyPattern
{
    /// <summary>
    /// Demo class to showcase the Strategy Pattern
    /// </summary>
    public class Strategy
    {
        public static void Run()
        {
            Console.WriteLine("=== Strategy Pattern ===");
            Console.WriteLine("E-commerce Payment System\n");

            try
            {
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Customer 1: Paying with Credit Card");
                Console.WriteLine("═══════════════════════════════════════\n");

                ShoppingCart cart1 = new ShoppingCart();
                cart1.AddItem("Laptop");
                cart1.AddItem("Mouse");
                cart1.AddItem("Keyboard");

                // Choose credit card payment
                cart1.SetPaymentStrategy(new CreditCardPayment("1234567812345678", "John Doe"));
                cart1.Checkout(1250.00m);

                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Customer 2: Paying with PayPal");
                Console.WriteLine("═══════════════════════════════════════\n");

                ShoppingCart cart2 = new ShoppingCart();
                cart2.AddItem("Headphones");
                cart2.AddItem("USB Cable");

                // Choose PayPal payment
                cart2.SetPaymentStrategy(new PayPalPayment("alice@email.com"));
                cart2.Checkout(85.50m);

                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Customer 3: Paying with Cryptocurrency");
                Console.WriteLine("═══════════════════════════════════════\n");

                ShoppingCart cart3 = new ShoppingCart();
                cart3.AddItem("Gaming Chair");
                cart3.AddItem("Monitor");

                // Choose crypto payment
                cart3.SetPaymentStrategy(new CryptoPayment("1A2B3C4D5E6F7G8H9I0J1K2L3M4N5O6P"));
                cart3.Checkout(650.00m);

                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Customer 4: Forgetting Payment Method");
                Console.WriteLine("═══════════════════════════════════════\n");

                ShoppingCart cart4 = new ShoppingCart();
                cart4.AddItem("Book");
                // No payment strategy set!
                cart4.Checkout(25.00m);

                Console.WriteLine("\n=== Understanding the Strategy Pattern ===");
                Console.WriteLine("Components:");
                Console.WriteLine("  1. Strategy Interface (IPaymentStrategy) - Defines Pay() method");
                Console.WriteLine("  2. Concrete Strategies (CreditCard, PayPal, Crypto)");
                Console.WriteLine("  3. Context (ShoppingCart) - Uses strategy");

                Console.WriteLine("\nHow it works:");
                Console.WriteLine("  1. Customer adds items to cart");
                Console.WriteLine("  2. Customer chooses payment method (strategy)");
                Console.WriteLine("  3. Cart uses chosen strategy to process payment");
                Console.WriteLine("  4. Different strategies = different payment processing");

                Console.WriteLine("\n=== Key Points ===");
                Console.WriteLine("1. Defines a family of algorithms (payment methods)");
                Console.WriteLine("2. Encapsulates each algorithm in separate class");
                Console.WriteLine("3. Makes algorithms interchangeable");
                Console.WriteLine("4. Client chooses which strategy to use");
                Console.WriteLine("5. Easy to add new payment methods without changing cart");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}