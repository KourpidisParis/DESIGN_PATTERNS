using System;

namespace DesignPatterns.Creational.AbstractFactoryPattern
{
    /// <summary>
    /// Concrete product - Modern Chair
    /// </summary>
    public class ModernChair : IChair
    {
        public void SitOn()
        {
            Console.WriteLine("Sitting on a sleek, minimalist modern chair");
        }

        public string GetStyle()
        {
            return "Modern";
        }
    }
}
