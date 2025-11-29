using System;

namespace DesignPatterns.Structural.AdapterPattern
{
    /// <summary>
    /// Demo class to showcase the Adapter Pattern
    /// </summary>
    public class Adapter
    {
        public static void Run()
        {
            Console.WriteLine("=== Adapter Pattern ===");
            Console.WriteLine("Integrating different payment providers\n");

            try
            {
                ShoppingCart cart = new ShoppingCart();

                // Scenario 1: Using PayPal (no adapter needed - already compatible)
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Customer 1: Paying with PayPal");
                Console.WriteLine("═══════════════════════════════════════");
                IPaymentProcessor paypal = new PayPalPayment();
                cart.SetPaymentMethod(paypal);
                cart.Checkout(150.00m, "customer1@paypal.com");

                // Scenario 2: Using Stripe (needs adapter)
                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("Customer 2: Paying with Stripe");
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Note: Stripe API uses different method names and cents instead of dollars");
                IPaymentProcessor stripe = new StripePaymentAdapter();
                cart.SetPaymentMethod(stripe);
                cart.Checkout(299.99m, "tok_visa_4242");

                // Show the difference
                Console.WriteLine("\n\n=== Understanding the Adapter ===");
                Console.WriteLine("Without Adapter:");
                Console.WriteLine("  - ShoppingCart expects: ProcessPayment(decimal amount, string currency)");
                Console.WriteLine("  - Stripe provides: MakePayment(int amountInCents, string currencyCode)");
                Console.WriteLine("  - INCOMPATIBLE! ❌");
                Console.WriteLine("\nWith Adapter:");
                Console.WriteLine("  - StripePaymentAdapter implements IPaymentProcessor");
                Console.WriteLine("  - Converts decimal dollars to int cents");
                Console.WriteLine("  - Translates method names");
                Console.WriteLine("  - COMPATIBLE! ✅");

                Console.WriteLine("\n=== Key Points ===");
                Console.WriteLine("1. ShoppingCart works with ANY payment method using IPaymentProcessor");
                Console.WriteLine("2. PayPal already matches our interface - no adapter needed");
                Console.WriteLine("3. Stripe has different API - adapter makes it compatible");
                Console.WriteLine("4. We can add more payment providers without changing ShoppingCart");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}