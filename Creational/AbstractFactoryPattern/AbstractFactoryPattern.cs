using System;

namespace DesignPatterns.Creational.AbstractFactoryPattern
{
    /// <summary>
    /// Demo class to showcase the Abstract Factory Pattern
    /// </summary>
    public class AbstractFactoryPattern
    {
        public static void Run()
        {
            Console.WriteLine("=== Abstract Factory Pattern ===");

            try
            {
                // Create Modern furniture set
                Console.WriteLine("\n--- Creating Modern Furniture Set ---");
                IFurnitureFactory modernFactory = new ModernFurnitureFactory();
                CreateFurnitureSet(modernFactory);

                // Create Victorian furniture set
                Console.WriteLine("\n--- Creating Victorian Furniture Set ---");
                IFurnitureFactory victorianFactory = new VictorianFurnitureFactory();
                CreateFurnitureSet(victorianFactory);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static void CreateFurnitureSet(IFurnitureFactory factory)
        {
            // Create all furniture from the same family
            IChair chair = factory.CreateChair();
            ISofa sofa = factory.CreateSofa();
            ITable table = factory.CreateTable();

            // Use the furniture
            Console.WriteLine($"Style: {chair.GetStyle()}");
            chair.SitOn();
            sofa.LieOn();
            table.PlaceItems();
        }
    }
}
