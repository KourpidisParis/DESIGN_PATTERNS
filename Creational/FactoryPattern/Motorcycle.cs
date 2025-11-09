using System;

namespace DesignPatterns.Creational.FactoryPattern
{
    /// <summary>
    /// Concrete Product - Motorcycle implementation
    /// </summary>
    public class Motorcycle : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("Motorcycle: Engine started with kick/button");
        }

        public void Stop()
        {
            Console.WriteLine("Motorcycle: Engine stopped, side stand down");
        }

        public void Drive()
        {
            Console.WriteLine("Motorcycle: Riding on 2 wheels with balance");
        }

        public string GetVehicleType()
        {
            return "Motorcycle";
        }
    }
}
