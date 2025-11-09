using System;

namespace DesignPatterns.Creational.FactoryPattern
{
    /// <summary>
    /// Concrete Product - Car implementation
    /// </summary>
    public class Car : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("Car: Engine started with ignition key");
        }

        public void Stop()
        {
            Console.WriteLine("Car: Engine stopped, parking brake applied");
        }

        public void Drive()
        {
            Console.WriteLine("Car: Driving on the road with 4 wheels");
        }

        public string GetVehicleType()
        {
            return "Car";
        }
    }
}
