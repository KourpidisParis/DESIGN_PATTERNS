using System;

namespace DesignPatterns.Behavioral.TemplateMethodPattern
{
    /// <summary>
    /// Concrete Class - Coffee implementation
    /// </summary>
    public class Coffee : Beverage
    {
        protected override void Brew()
        {
            Console.WriteLine("Brewing coffee grounds...");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Adding milk and sugar...");
        }
    }
}