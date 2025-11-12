using System;

namespace DesignPatterns.Creational.AbstractFactoryPattern
{
    /// <summary>
    /// Concrete product - Victorian Chair
    /// </summary>
    public class VictorianChair : IChair
    {
        public void SitOn()
        {
            Console.WriteLine("Sitting on an elegant Victorian chair with ornate carvings");
        }

        public string GetStyle()
        {
            return "Victorian";
        }
    }
}
