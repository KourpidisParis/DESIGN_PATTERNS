using System;

namespace DesignPatterns.Behavioral.StatePattern
{
    /// <summary>
    /// Demo class to showcase the State Pattern
    /// </summary>
    public class State
    {
        public static void Run()
        {
            Console.WriteLine("=== State Pattern ===");
            Console.WriteLine("Vending Machine Simulation\n");

            try
            {
                VendingMachine machine = new VendingMachine();

                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Scenario 1: Normal Purchase Flow");
                Console.WriteLine("═══════════════════════════════════════");

                machine.ShowCurrentState();
                machine.InsertCoin();
                machine.ShowCurrentState();
                machine.SelectProduct();
                machine.ShowCurrentState();
                machine.Dispense();
                machine.ShowCurrentState();

                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("Scenario 2: Insert Coin, Then Eject");
                Console.WriteLine("═══════════════════════════════════════");

                machine.ShowCurrentState();
                machine.InsertCoin();
                machine.ShowCurrentState();
                machine.EjectCoin();
                machine.ShowCurrentState();

                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("Scenario 3: Invalid Operations");
                Console.WriteLine("═══════════════════════════════════════");

                machine.ShowCurrentState();
                machine.SelectProduct();  // No coin inserted
                machine.Dispense();       // No product selected

                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("Scenario 4: Duplicate Actions");
                Console.WriteLine("═══════════════════════════════════════");

                machine.ShowCurrentState();
                machine.InsertCoin();
                machine.ShowCurrentState();
                machine.InsertCoin();     // Coin already inserted
                machine.SelectProduct();
                machine.ShowCurrentState();
                machine.SelectProduct();  // Product already selected
                machine.Dispense();
                machine.ShowCurrentState();

                Console.WriteLine("\n\n=== Understanding the State Pattern ===");
                Console.WriteLine("Components:");
                Console.WriteLine("  1. State Interface (IState) - Defines state behaviors");
                Console.WriteLine("  2. Concrete States (NoCoinState, HasCoinState, ProductSelectedState)");
                Console.WriteLine("  3. Context (VendingMachine) - Maintains current state");

                Console.WriteLine("\nHow it works:");
                Console.WriteLine("  1. Machine starts in NoCoinState");
                Console.WriteLine("  2. InsertCoin() → transitions to HasCoinState");
                Console.WriteLine("  3. SelectProduct() → transitions to ProductSelectedState");
                Console.WriteLine("  4. Dispense() → transitions back to NoCoinState");

                Console.WriteLine("\nState Transitions:");
                Console.WriteLine("  NoCoinState → (insert coin) → HasCoinState");
                Console.WriteLine("  HasCoinState → (select product) → ProductSelectedState");
                Console.WriteLine("  HasCoinState → (eject coin) → NoCoinState");
                Console.WriteLine("  ProductSelectedState → (dispense) → NoCoinState");

                Console.WriteLine("\n=== Key Points ===");
                Console.WriteLine("1. Behavior changes based on internal state");
                Console.WriteLine("2. State-specific logic is encapsulated in state classes");
                Console.WriteLine("3. No messy if/else statements in context");
                Console.WriteLine("4. Easy to add new states without modifying existing code");
                Console.WriteLine("5. Each state knows which state to transition to");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}