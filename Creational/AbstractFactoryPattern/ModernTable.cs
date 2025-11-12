using System;

namespace DesignPatterns.Creational.AbstractFactoryPattern
{
    /// <summary>
    /// Concrete product - Modern Table
    /// </summary>
    public class ModernTable : ITable
    {
        public void PlaceItems()
        {
            Console.WriteLine("Placing items on a glass modern table");
        }

        public string GetStyle()
        {
            return "Modern";
        }
    }
}
