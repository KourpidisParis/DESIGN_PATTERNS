using System;

namespace DesignPatterns.Creational.AbstractFactoryPattern
{
    /// <summary>
    /// Concrete product - Modern Sofa
    /// </summary>
    public class ModernSofa : ISofa
    {
        public void LieOn()
        {
            Console.WriteLine("Lying on a contemporary modern sofa with clean lines");
        }

        public string GetStyle()
        {
            return "Modern";
        }
    }
}
