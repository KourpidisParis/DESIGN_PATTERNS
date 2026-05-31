using System;

namespace DesignPatterns.Behavioral.TemplateMethodPattern
{
    /// <summary>
    /// Concrete Class - Hot chocolate implementation
    /// </summary>
    public class HotChocolate : Beverage
    {
        protected override void Brew()
        {
            Console.WriteLine("  2️⃣ Mixing cocoa powder with hot water...");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("  4️⃣ Adding whipped cream and marshmallows...");
        }
    }
}