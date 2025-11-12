using System;

namespace DesignPatterns.Creational.AbstractFactoryPattern
{
    /// <summary>
    /// Concrete product - Victorian Table
    /// </summary>
    public class VictorianTable : ITable
    {
        public void PlaceItems()
        {
            Console.WriteLine("Placing items on a carved wooden Victorian table");
        }

        public string GetStyle()
        {
            return "Victorian";
        }
    }
}
