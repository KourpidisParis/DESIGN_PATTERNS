using System;

namespace DesignPatterns.Behavioral.VisitorPattern
{
    /// <summary>
    /// Demo class to showcase the Visitor Pattern
    /// </summary>
    public class Visitor
    {
        public static void Run()
        {
            Console.WriteLine("=== Visitor Pattern ===");
            Console.WriteLine("E-commerce Shopping Cart System\n");

            try
            {
                // Create shopping cart
                ShoppingCart cart = new ShoppingCart();

                // Add items
                cart.AddItem(new Book("Clean Code", 45.00m));
                cart.AddItem(new Book("Design Patterns", 55.00m));
                cart.AddItem(new Electronics("Laptop", 1200.00m));
                cart.AddItem(new Electronics("Mouse", 25.00m));

                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Shopping Cart Items");
                Console.WriteLine("═══════════════════════════════════════\n");

                // Calculate prices
                Console.WriteLine("--- Price Calculation ---");
                PriceCalculator priceCalc = new PriceCalculator();
                cart.Accept(priceCalc);
                Console.WriteLine($"Total Price: ${priceCalc.GetTotalPrice():F2}\n");

                // Calculate taxes
                Console.WriteLine("--- Tax Calculation ---");
                TaxCalculator taxCalc = new TaxCalculator();
                cart.Accept(taxCalc);
                Console.WriteLine($"Total Tax: ${taxCalc.GetTotalTax():F2}\n");

                // Calculate discounts
                Console.WriteLine("--- Discount Calculation ---");
                DiscountCalculator discountCalc = new DiscountCalculator();
                cart.Accept(discountCalc);
                Console.WriteLine($"Total Discount: ${discountCalc.GetTotalDiscount():F2}\n");

                // Final summary
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Order Summary");
                Console.WriteLine("═══════════════════════════════════════\n");

                decimal subtotal = priceCalc.GetTotalPrice();
                decimal tax = taxCalc.GetTotalTax();
                decimal discount = discountCalc.GetTotalDiscount();
                decimal total = subtotal + tax - discount;

                Console.WriteLine($"Subtotal:  ${subtotal:F2}");
                Console.WriteLine($"Tax:       ${tax:F2}");
                Console.WriteLine($"Discount: -${discount:F2}");
                Console.WriteLine($"─────────────────────");
                Console.WriteLine($"Total:     ${total:F2}\n");

                Console.WriteLine("\n=== Understanding the Visitor Pattern ===");
                Console.WriteLine("Components:");
                Console.WriteLine("  1. Element Interface (IShoppingItem) - Objects that can be visited");
                Console.WriteLine("  2. Concrete Elements (Book, Electronics) - Specific item types");
                Console.WriteLine("  3. Visitor Interface (IShoppingVisitor) - Defines operations");
                Console.WriteLine("  4. Concrete Visitors (PriceCalculator, TaxCalculator, etc.)");
                Console.WriteLine("  5. Object Structure (ShoppingCart) - Collection of elements");

                Console.WriteLine("\nHow it works:");
                Console.WriteLine("  1. Each item has Accept() method that takes a visitor");
                Console.WriteLine("  2. Item calls appropriate Visit method on visitor");
                Console.WriteLine("  3. Visitor performs operation specific to that item type");
                Console.WriteLine("  4. Can add new operations without modifying item classes");

                Console.WriteLine("\n=== Key Points ===");
                Console.WriteLine("1. Separates operations from object structure");
                Console.WriteLine("2. Easy to add new operations (new visitor classes)");
                Console.WriteLine("3. Item classes don't need to change");
                Console.WriteLine("4. Can perform different operations on same collection");
                Console.WriteLine("5. Follows Open/Closed Principle for new operations");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}