using System;

namespace DesignPatterns.Behavioral.TemplateMethodPattern
{
    /// <summary>
    /// Demo class to showcase the Template Method Pattern
    /// </summary>
    public class TemplateMethod
    {
        public static void Run()
        {
            Console.WriteLine("=== Template Method Pattern ===");
            Console.WriteLine("Beverage Preparation System\n");

            try
            {
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Making Coffee");
                Console.WriteLine("═══════════════════════════════════════");
                Beverage coffee = new Coffee();
                coffee.Prepare();

                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Making Tea");
                Console.WriteLine("═══════════════════════════════════════");
                Beverage tea = new Tea();
                tea.Prepare();

                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Making Hot Chocolate");
                Console.WriteLine("═══════════════════════════════════════");
                Beverage hotChocolate = new HotChocolate();
                hotChocolate.Prepare();

                Console.WriteLine("\n\n=== Understanding the Template Method Pattern ===");
                Console.WriteLine("Template Method (Beverage.Prepare()):");
                Console.WriteLine("  1. Boil water (same for all)");
                Console.WriteLine("  2. Brew (different for each)");
                Console.WriteLine("  3. Pour in cup (same for all)");
                Console.WriteLine("  4. Add condiments (different for each)");

                Console.WriteLine("\nHow it works:");
                Console.WriteLine("  - Base class defines algorithm skeleton");
                Console.WriteLine("  - Some steps are same for all beverages");
                Console.WriteLine("  - Some steps vary and are implemented by subclasses");
                Console.WriteLine("  - Subclasses don't need to remember the overall algorithm");

                Console.WriteLine("\nComponents:");
                Console.WriteLine("  1. Abstract Class (Beverage) - Defines template method");
                Console.WriteLine("  2. Abstract Methods (Brew, AddCondiments) - Overridden by subclasses");
                Console.WriteLine("  3. Concrete Classes (Coffee, Tea, HotChocolate)");

                Console.WriteLine("\n=== Key Points ===");
                Console.WriteLine("1. Defines algorithm skeleton in base class");
                Console.WriteLine("2. Defers specific steps to subclasses");
                Console.WriteLine("3. Subclasses fill in the template");
                Console.WriteLine("4. Hollywood Principle: 'Don't call us, we call you'");
                Console.WriteLine("5. Promotes code reuse and consistent behavior");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}