using System;

namespace DesignPatterns.Behavioral.StatePattern
{
    /// <summary>
    /// Concrete State - Coin inserted, waiting for selection
    /// </summary>
    public class HasCoinState : IState
    {
        public void InsertCoin(VendingMachine machine)
        {
            Console.WriteLine("⚠️ Coin already inserted");
        }

        public void EjectCoin(VendingMachine machine)
        {
            Console.WriteLine("💰 Coin ejected");
            machine.SetState(machine.GetNoCoinState());
        }

        public void SelectProduct(VendingMachine machine)
        {
            Console.WriteLine("✅ Product selected");
            machine.SetState(machine.GetProductSelectedState());
        }

        public void Dispense(VendingMachine machine)
        {
            Console.WriteLine("⚠️ Please select a product first");
        }
    }
}