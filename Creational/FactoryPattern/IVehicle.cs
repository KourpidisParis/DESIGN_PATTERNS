namespace DesignPatterns.Creational.FactoryPattern
{
    /// <summary>
    /// Product interface - defines the common interface for all vehicles
    /// </summary>
    public interface IVehicle
    {
        void Start();
        void Stop();
        void Drive();
        string GetVehicleType();
    }
}
