using System;

namespace DesignPatterns.Creational.AbstractFactoryPattern
{
    /// <summary>
    /// Concrete product - Victorian Sofa
    /// </summary>
    public class VictorianSofa : ISofa
    {
        public void LieOn()
        {
            Console.WriteLine("Lying on a luxurious Victorian sofa with velvet upholstery");
        }

        public string GetStyle()
        {
            return "Victorian";
        }
    }
}
