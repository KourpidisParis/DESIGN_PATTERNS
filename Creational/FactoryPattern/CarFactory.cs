namespace DesignPatterns.Creational.FactoryPattern
{
    /// <summary>
    /// Concrete Factory - creates Car objects
    /// </summary>
    public class CarFactory : VehicleFactory
    {
        public override IVehicle CreateVehicle()
        {
            return new Car();
        }
    }
}
