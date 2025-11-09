namespace DesignPatterns.Creational.FactoryPattern
{
    /// <summary>
    /// Concrete Factory - creates Motorcycle objects
    /// </summary>
    public class MotorcycleFactory : VehicleFactory
    {
        public override IVehicle CreateVehicle()
        {
            return new Motorcycle();
        }
    }
}
