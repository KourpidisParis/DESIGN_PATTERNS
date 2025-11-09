using System;

namespace DesignPatterns.Creational.FactoryPattern
{
    /// <summary>
    /// Demo class to showcase the Factory Pattern
    /// </summary>
    public class FactoryPattern
    {
        public static void Run()
        {
            Console.WriteLine("=== Factory Pattern ===");

            try
            {
                Console.WriteLine("--- Creating a Car ---");
                VehicleFactory carFactory = new CarFactory();
                IVehicle car = carFactory.CreateVehicle();
                DemonstrateVehicle(car);

                Console.WriteLine("\n--- Creating a Motorcycle ---");
                VehicleFactory motorcycleFactory = new MotorcycleFactory();
                IVehicle motorcycle = motorcycleFactory.CreateVehicle();
                DemonstrateVehicle(motorcycle);

                Console.WriteLine("\n--- Creating a Truck ---");
                VehicleFactory truckFactory = new TruckFactory();
                IVehicle truck = truckFactory.CreateVehicle();
                DemonstrateVehicle(truck);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static void DemonstrateVehicle(IVehicle vehicle)
        {
            Console.WriteLine($"Vehicle Type: {vehicle.GetVehicleType()}");
            vehicle.Start();
            vehicle.Drive();
            vehicle.Stop();
        }
    }
}
