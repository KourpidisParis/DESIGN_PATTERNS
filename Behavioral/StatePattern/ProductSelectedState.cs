using System;

namespace DesignPatterns.Behavioral.StatePattern
{
    /// <summary>
    /// Concrete State - Product selected, ready to dispense
    /// </summary>
    public class ProductSelectedState : IState
    {
        public void InsertCoin(VendingMachine machine)
        {
            Console.WriteLine("⚠️ Please wait, processing your selection");
        }

        public void EjectCoin(VendingMachine machine)
        {
            Console.WriteLine("⚠️ Too late, product is being dispensed");
        }

        public void SelectProduct(VendingMachine machine)
        {
            Console.WriteLine("⚠️ Product already selected");
        }

        public void Dispense(VendingMachine machine)
        {
            Console.WriteLine("🎁 Dispensing product...");
            machine.SetState(machine.GetNoCoinState());
        }
    }
}