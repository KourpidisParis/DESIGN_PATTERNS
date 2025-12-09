using System;

namespace DesignPatterns.Structural.DecoratorPattern
{
    /// <summary>
    /// Demo class to showcase the Decorator Pattern
    /// </summary>
    public class Decorator
    {
        public static void Run()
        {
            Console.WriteLine("=== Decorator Pattern ===");
            Console.WriteLine("Building custom coffee orders by adding decorators\n");

            try
            {
                // Order 1: Simple coffee
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Order 1: Simple Coffee");
                Console.WriteLine("═══════════════════════════════════════");
                ICoffee coffee1 = new SimpleCoffee();
                Console.WriteLine($"Description: {coffee1.GetDescription()}");
                Console.WriteLine($"Cost: ${coffee1.GetCost():F2}");

                // Order 2: Coffee with milk
                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("Order 2: Coffee with Milk");
                Console.WriteLine("═══════════════════════════════════════");
                ICoffee coffee2 = new SimpleCoffee();
                coffee2 = new MilkDecorator(coffee2);
                Console.WriteLine($"Description: {coffee2.GetDescription()}");
                Console.WriteLine($"Cost: ${coffee2.GetCost():F2}");

                // Order 3: Coffee with milk and sugar
                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("Order 3: Coffee with Milk and Sugar");
                Console.WriteLine("═══════════════════════════════════════");
                ICoffee coffee3 = new SimpleCoffee();
                coffee3 = new MilkDecorator(coffee3);
                coffee3 = new SugarDecorator(coffee3);
                Console.WriteLine($"Description: {coffee3.GetDescription()}");
                Console.WriteLine($"Cost: ${coffee3.GetCost():F2}");

                // Order 4: Fancy coffee with everything
                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("Order 4: Deluxe Coffee");
                Console.WriteLine("═══════════════════════════════════════");
                ICoffee coffee4 = new SimpleCoffee();
                coffee4 = new MilkDecorator(coffee4);
                coffee4 = new SugarDecorator(coffee4);
                coffee4 = new WhippedCreamDecorator(coffee4);
                coffee4 = new CaramelDecorator(coffee4);
                Console.WriteLine($"Description: {coffee4.GetDescription()}");
                Console.WriteLine($"Cost: ${coffee4.GetCost():F2}");

                // Order 5: Double milk and double sugar
                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("Order 5: Extra Sweet Coffee (Double Sugar)");
                Console.WriteLine("═══════════════════════════════════════");
                ICoffee coffee5 = new SimpleCoffee();
                coffee5 = new MilkDecorator(coffee5);
                coffee5 = new SugarDecorator(coffee5);
                coffee5 = new SugarDecorator(coffee5);  // Add sugar twice!
                Console.WriteLine($"Description: {coffee5.GetDescription()}");
                Console.WriteLine($"Cost: ${coffee5.GetCost():F2}");

                // Show the building process
                Console.WriteLine("\n\n=== Understanding the Decorator ===");
                Console.WriteLine("Building a coffee step by step:");
                Console.WriteLine("");
                
                ICoffee step1 = new SimpleCoffee();
                Console.WriteLine($"Step 1: {step1.GetDescription()} = ${step1.GetCost():F2}");
                
                ICoffee step2 = new MilkDecorator(step1);
                Console.WriteLine($"Step 2: {step2.GetDescription()} = ${step2.GetCost():F2}");
                
                ICoffee step3 = new CaramelDecorator(step2);
                Console.WriteLine($"Step 3: {step3.GetDescription()} = ${step3.GetCost():F2}");

                Console.WriteLine("\nEach decorator wraps the previous coffee and adds functionality!");

                Console.WriteLine("\n=== Key Points ===");
                Console.WriteLine("1. Each decorator adds new behavior (description + cost)");
                Console.WriteLine("2. You can stack decorators in any order");
                Console.WriteLine("3. You can add the same decorator multiple times (double sugar)");
                Console.WriteLine("4. The core coffee object is never modified");
                Console.WriteLine("5. Easy to add new decorators (VanillaDecorator, ChocolateDecorator, etc.)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}