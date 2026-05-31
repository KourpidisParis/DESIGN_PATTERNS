using System;

namespace DesignPatterns.Behavioral.TemplateMethodPattern
{
    /// <summary>
    /// Abstract Class - Defines template method for beverage preparation
    /// </summary>
    public abstract class Beverage
    {
        // Template Method - Defines the algorithm structure
        public void Prepare()
        {
            Console.WriteLine("\n🍵 Preparing beverage...");
            BoilWater();
            Brew();
            PourInCup();
            AddCondiments();
            Console.WriteLine("✅ Beverage ready!\n");
        }

        // Common steps
        protected void BoilWater()
        {
            Console.WriteLine("  1️⃣ Boiling water...");
        }

        protected void PourInCup()
        {
            Console.WriteLine("  3️⃣ Pouring into cup...");
        }

        // Abstract methods - to be implemented by subclasses
        protected abstract void Brew();
        protected abstract void AddCondiments();
    }
}