namespace DesignPatterns.Behavioral.StatePattern
{
    /// <summary>
    /// State Interface - Defines methods for different states
    /// </summary>
    public interface IState
    {
        void InsertCoin(VendingMachine machine);
        void EjectCoin(VendingMachine machine);
        void SelectProduct(VendingMachine machine);
        void Dispense(VendingMachine machine);
    }
}