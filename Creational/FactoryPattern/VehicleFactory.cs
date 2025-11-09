namespace DesignPatterns.Creational.FactoryPattern
{
    /// <summary>
    /// Abstract Creator - defines the factory method interface
    /// </summary>
    public abstract class VehicleFactory
    {
        /// <summary>
        /// Factory Method - subclasses will implement this to create specific vehicles
        /// </summary>
        public abstract IVehicle CreateVehicle();
    }
}
