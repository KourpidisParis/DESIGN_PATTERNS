using System;

namespace DesignPatterns.Structural.FlyweightPattern
{
    /// <summary>
    /// Demo class to showcase the Flyweight Pattern
    /// </summary>
    public class Flyweight
    {
        public static void Run()
        {
            Console.WriteLine("=== Flyweight Pattern ===");
            Console.WriteLine("Efficiently managing thousands of similar objects\n");

            try
            {
                Forest forest = new Forest();

                // Plant a large forest with many trees
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Planting 10,000 trees...");
                Console.WriteLine("═══════════════════════════════════════\n");

                // Plant 3,000 Oak trees (same type, different positions)
                for (int i = 0; i < 3000; i++)
                {
                    forest.PlantTree(
                        x: i % 100,
                        y: i / 100,
                        height: 15 + (i % 10),
                        name: "Oak",
                        color: "Green",
                        texture: "Rough"
                    );
                }

                // Plant 4,000 Pine trees (same type, different positions)
                for (int i = 0; i < 4000; i++)
                {
                    forest.PlantTree(
                        x: i % 100 + 100,
                        y: i / 100,
                        height: 20 + (i % 15),
                        name: "Pine",
                        color: "Dark Green",
                        texture: "Needles"
                    );
                }

                // Plant 3,000 Birch trees (same type, different positions)
                for (int i = 0; i < 3000; i++)
                {
                    forest.PlantTree(
                        x: i % 100 + 200,
                        y: i / 100,
                        height: 12 + (i % 8),
                        name: "Birch",
                        color: "Light Green",
                        texture: "Smooth"
                    );
                }

                // Show statistics
                forest.ShowStatistics();

                // Display sample trees
                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("Sample of first 10 trees:");
                Console.WriteLine("═══════════════════════════════════════");
                
                Forest sampleForest = new Forest();
                sampleForest.PlantTree(0, 0, 15, "Oak", "Green", "Rough");
                sampleForest.PlantTree(1, 0, 16, "Oak", "Green", "Rough");
                sampleForest.PlantTree(2, 0, 17, "Oak", "Green", "Rough");
                sampleForest.PlantTree(0, 1, 20, "Pine", "Dark Green", "Needles");
                sampleForest.PlantTree(1, 1, 21, "Pine", "Dark Green", "Needles");
                sampleForest.PlantTree(0, 2, 12, "Birch", "Light Green", "Smooth");
                sampleForest.PlantTree(1, 2, 13, "Birch", "Light Green", "Smooth");
                sampleForest.PlantTree(2, 1, 22, "Pine", "Dark Green", "Needles");
                sampleForest.PlantTree(3, 0, 18, "Oak", "Green", "Rough");
                sampleForest.PlantTree(2, 2, 14, "Birch", "Light Green", "Smooth");
                
                sampleForest.Display();
                sampleForest.ShowStatistics();

                // Explanation
                Console.WriteLine("\n\n=== Understanding the Flyweight ===");
                Console.WriteLine("WITHOUT Flyweight:");
                Console.WriteLine("  - 10,000 trees = 10,000 TreeType objects");
                Console.WriteLine("  - Each TreeType stores name, color, texture (heavy data)");
                Console.WriteLine("  - Massive memory usage!");

                Console.WriteLine("\nWITH Flyweight:");
                Console.WriteLine("  - 10,000 trees = Only 3 TreeType objects (Oak, Pine, Birch)");
                Console.WriteLine("  - TreeType objects are SHARED among all trees of the same type");
                Console.WriteLine("  - Each Tree only stores position and height (light data)");
                Console.WriteLine("  - Huge memory savings!");

                Console.WriteLine("\n=== Key Points ===");
                Console.WriteLine("1. Intrinsic state (shared): name, color, texture");
                Console.WriteLine("2. Extrinsic state (unique): x, y, height");
                Console.WriteLine("3. Factory ensures tree types are shared and reused");
                Console.WriteLine("4. Memory usage reduced from 10,000 objects to 3!");
                Console.WriteLine("5. Perfect for games, graphics, text editors with many similar objects");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}