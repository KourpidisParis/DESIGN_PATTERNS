using System;

namespace DesignPatterns.Behavioral.TemplateMethodPattern
{
    /// <summary>
    /// Concrete Class - Tea implementation
    /// </summary>
    public class Tea : Beverage
    {
        protected override void Brew()
        {
            Console.WriteLine("  2️⃣ Steeping tea bag...");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("  4️⃣ Adding lemon and honey...");
        }
    }
}