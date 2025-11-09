namespace DesignPatterns.Creational.FactoryPattern
{
    /// <summary>
    /// Concrete Factory - creates Truck objects
    /// </summary>
    public class TruckFactory : VehicleFactory
    {
        public override IVehicle CreateVehicle()
        {
            return new Truck();
        }
    }
}
