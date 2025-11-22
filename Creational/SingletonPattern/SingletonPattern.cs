using System;

namespace DesignPatterns.Creational.SingletonPattern
{
    /// <summary>
    /// Demo class to showcase the Singleton Pattern
    /// </summary>
    public class SingletonPattern
    {
        public static void Run()
        {
            Console.WriteLine("=== Singleton Pattern ===");

            try
            {
                // ========================================
                // Example 1: Database Connection Singleton
                // ========================================
                Console.WriteLine("\n--- Database Connection Singleton ---");
                Console.WriteLine("Getting database connection from different places...\n");

                // First access - creates the instance
                Console.WriteLine("First access:");
                DatabaseConnection db1 = DatabaseConnection.Instance;
                db1.Connect();

                // Second access - returns the SAME instance
                Console.WriteLine("\nSecond access (from another part of the code):");
                DatabaseConnection db2 = DatabaseConnection.Instance;
                db2.ShowStatus();

                // Prove they are the same instance
                Console.WriteLine("\n--- Proving it's the same instance ---");
                Console.WriteLine($"db1 hash code: {db1.GetHashCode()}");
                Console.WriteLine($"db2 hash code: {db2.GetHashCode()}");
                Console.WriteLine($"Are they the same object? {ReferenceEquals(db1, db2)}");

                // Execute queries from different "places"
                Console.WriteLine("\n--- Using the same connection everywhere ---");
                db1.ExecuteQuery("SELECT * FROM Users");
                db2.ExecuteQuery("SELECT * FROM Products");

                // ========================================
                // Example 2: Logger Singleton
                // ========================================
                Console.WriteLine("\n\n--- Logger Singleton ---");
                Console.WriteLine("Logging from different parts of the application...\n");

                // Access logger from "different modules"
                Logger logger1 = Logger.Instance;
                logger1.LogInfo("Application started");

                Logger logger2 = Logger.Instance;
                logger2.LogInfo("User logged in");

                Logger logger3 = Logger.Instance;
                logger3.LogWarning("Low memory warning");

                Logger logger4 = Logger.Instance;
                logger4.LogError("File not found");

                // All logs are in the same place!
                Console.WriteLine("\n--- All logs collected in ONE place ---");
                Console.WriteLine($"logger1 hash code: {logger1.GetHashCode()}");
                Console.WriteLine($"logger4 hash code: {logger4.GetHashCode()}");
                Console.WriteLine($"Same instance? {ReferenceEquals(logger1, logger4)}");
                Console.WriteLine($"Total log entries: {logger1.LogCount}");

                // ========================================
                // Example 3: App Configuration Singleton
                // ========================================
                Console.WriteLine("\n\n--- App Configuration Singleton ---");
                Console.WriteLine("Configuration is consistent everywhere...\n");

                // Access from one place
                AppConfiguration config1 = AppConfiguration.Instance;
                config1.ShowConfiguration();

                // Modify from another place
                Console.WriteLine("\nChanging settings from 'Admin Module':");
                AppConfiguration config2 = AppConfiguration.Instance;
                config2.Environment = "Production";
                config2.DebugMode = false;

                // Check from a third place - changes are reflected!
                Console.WriteLine("\nReading from 'User Module' - changes are reflected:");
                AppConfiguration config3 = AppConfiguration.Instance;
                config3.ShowConfiguration();

                // Prove same instance
                Console.WriteLine($"\nSame instance? {ReferenceEquals(config1, config3)}");

                // ========================================
                // Summary
                // ========================================
                Console.WriteLine("\n\n=== Key Points ===");
                Console.WriteLine("1. Constructor is called only ONCE (check the messages above)");
                Console.WriteLine("2. All variables point to the SAME instance");
                Console.WriteLine("3. Changes made anywhere are visible everywhere");
                Console.WriteLine("4. Perfect for: Database connections, Loggers, Configuration");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
