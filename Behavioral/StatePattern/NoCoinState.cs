using System;

namespace DesignPatterns.Behavioral.StatePattern
{
    /// <summary>
    /// Concrete State - No coin inserted
    /// </summary>
    public class NoCoinState : IState
    {
        public void InsertCoin(VendingMachine machine)
        {
            Console.WriteLine("💰 Coin inserted");
            machine.SetState(machine.GetHasCoinState());
        }

        public void EjectCoin(VendingMachine machine)
        {
            Console.WriteLine("⚠️ No coin to eject");
        }

        public void SelectProduct(VendingMachine machine)
        {
            Console.WriteLine("⚠️ Please insert coin first");
        }

        public void Dispense(VendingMachine machine)
        {
            Console.WriteLine("⚠️ Please insert coin and select product");
        }
    }
}