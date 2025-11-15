using System;
using DesignPatterns.Creational.FactoryPattern;
using DesignPatterns.Creational.AbstractFactoryPattern;
using DesignPatterns.Creational.BuilderPattern;
using DesignPatterns.Creational.PrototypePattern;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║               Design Patterns              ║");
            Console.WriteLine("╚════════════════════════════════════════════╝\n");

            if (args.Length == 0)
            {
                ShowHelp();
                return;
            }

            string pattern = args[0].ToLower();

            try
            {
                switch (pattern)
                {
                    case "factory":
                        FactoryPattern.Run();
                        break;

                    case "abstract-factory":
                        AbstractFactoryPattern.Run();
                        break;

                    case "builder":
                        BuilderPattern.Run();
                        break;

                    case "prototype":
                        PrototypePattern.Run();
                        break;

                    case "list":
                        ListPatterns();
                        break;

                    case "help":
                    case "-h":
                    case "--help":
                        ShowHelp();
                        break;

                    default:
                        Console.WriteLine($"❌ Unknown pattern: {args[0]}");
                        Console.WriteLine("\nUse 'dotnet run list' to see available patterns.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Error: {ex.Message}");
            }

            Console.WriteLine("\n--- End ---");
        }

        static void ShowHelp()
        {
            Console.WriteLine("Usage: dotnet run <pattern-name>");
            Console.WriteLine("\nAvailable commands:");
            Console.WriteLine("  dotnet run factory          - Run Factory Pattern demo");
            Console.WriteLine("  dotnet run abstract-factory - Run Abstract Factory Pattern demo");
            Console.WriteLine("  dotnet run builder          - Run Builder Pattern demo");
            Console.WriteLine("  dotnet run prototype        - Run Prototype Pattern demo");
            Console.WriteLine("  dotnet run list             - List all available patterns");
            Console.WriteLine("  dotnet run help             - Show this help message");
            Console.WriteLine("\nExample:");
            Console.WriteLine("  dotnet run factory");
        }

        static void ListPatterns()
        {
            Console.WriteLine("📚 Available Design Patterns:\n");
            
            Console.WriteLine("Creational Patterns:");
            Console.WriteLine("  ✓ factory          - Factory Pattern (Vehicle creation example)");
            Console.WriteLine("  ✓ abstract-factory - Abstract Factory Pattern (Furniture families example)");
            Console.WriteLine("  ✓ builder          - Builder Pattern (Computer construction example)");
            Console.WriteLine("  ✓ prototype        - Prototype Pattern (Document cloning example)");
            Console.WriteLine("  ⏳ singleton       - Coming soon...");
            
            Console.WriteLine("\nStructural Patterns:");
            Console.WriteLine("  ⏳ adapter         - Coming soon...");
            Console.WriteLine("  ⏳ bridge          - Coming soon...");
            Console.WriteLine("  ⏳ composite       - Coming soon...");
            Console.WriteLine("  ⏳ decorator       - Coming soon...");
            Console.WriteLine("  ⏳ facade          - Coming soon...");
            Console.WriteLine("  ⏳ flyweight       - Coming soon...");
            Console.WriteLine("  ⏳ proxy           - Coming soon...");
            
            Console.WriteLine("\nBehavioral Patterns:");
            Console.WriteLine("  ⏳ observer        - Coming soon...");
            Console.WriteLine("  ⏳ strategy        - Coming soon...");
            Console.WriteLine("  ⏳ command         - Coming soon...");
            Console.WriteLine("  ⏳ iterator        - Coming soon...");
            Console.WriteLine("  ⏳ state           - Coming soon...");
            Console.WriteLine("  ⏳ template-method - Coming soon...");
            Console.WriteLine("  ⏳ chain-of-resp   - Coming soon...");
        }
    }
}
