using System;

namespace DesignPatterns.Behavioral.CommandPattern
{
    /// <summary>
    /// Demo class to showcase the Command Pattern
    /// </summary>
    public class Command
    {
        public static void Run()
        {
            Console.WriteLine("=== Command Pattern ===");
            Console.WriteLine("Simple Remote Control System\n");

            try
            {
                // Create receiver (device)
                Light livingRoomLight = new Light("Living Room");

                // Create commands
                LightOnCommand lightOn = new LightOnCommand(livingRoomLight);
                LightOffCommand lightOff = new LightOffCommand(livingRoomLight);

                // Create invoker (remote control)
                RemoteControl remote = new RemoteControl();

                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Testing Remote Control");
                Console.WriteLine("═══════════════════════════════════════\n");

                // Turn light on
                Console.WriteLine("--- Press ON button ---");
                remote.SetCommand(lightOn);
                remote.PressButton();

                Console.WriteLine("\n--- Press OFF button ---");
                remote.SetCommand(lightOff);
                remote.PressButton();

                Console.WriteLine("\n--- Press ON button again ---");
                remote.SetCommand(lightOn);
                remote.PressButton();

                // Test undo
                Console.WriteLine("\n--- Testing Undo ---");
                remote.PressUndo(); // Undo light on
                remote.PressUndo(); // Undo light off
                remote.PressUndo(); // Undo light on

                Console.WriteLine("\n--- Try undo with empty stack ---");
                remote.PressUndo(); // Nothing to undo

                Console.WriteLine("\n\n=== Understanding the Command Pattern ===");
                Console.WriteLine("Components:");
                Console.WriteLine("  1. Command Interface (ICommand) - Defines Execute() and Undo()");
                Console.WriteLine("  2. Concrete Commands (LightOnCommand, LightOffCommand)");
                Console.WriteLine("  3. Receiver (Light) - The actual device");
                Console.WriteLine("  4. Invoker (RemoteControl) - Executes commands");
                Console.WriteLine("  5. Client - Sets up and connects everything");

                Console.WriteLine("\nHow it works:");
                Console.WriteLine("  Remote Control → Execute Command → Light performs action");
                Console.WriteLine("  Remote doesn't know about Light, only about ICommand");

                Console.WriteLine("\n=== Key Points ===");
                Console.WriteLine("1. Remote control doesn't know about Light directly");
                Console.WriteLine("2. Commands encapsulate requests as objects");
                Console.WriteLine("3. Easy to add new devices and commands");
                Console.WriteLine("4. Undo functionality built into each command");
                Console.WriteLine("5. Commands can be queued, logged, or scheduled");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}