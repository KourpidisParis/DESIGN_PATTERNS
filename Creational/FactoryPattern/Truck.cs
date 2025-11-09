using System;

namespace DesignPatterns.Creational.FactoryPattern
{
    /// <summary>
    /// Concrete Product - Truck implementation
    /// </summary>
    public class Truck : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("Truck: Diesel engine started with heavy rumble");
        }

        public void Stop()
        {
            Console.WriteLine("Truck: Air brakes released, engine off");
        }

        public void Drive()
        {
            Console.WriteLine("Truck: Hauling cargo on multiple axles");
        }

        public string GetVehicleType()
        {
            return "Truck";
        }
    }
}
