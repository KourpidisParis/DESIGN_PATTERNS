using System;
using DesignPatterns.Creational.FactoryPattern;
using DesignPatterns.Creational.AbstractFactoryPattern;
using DesignPatterns.Creational.BuilderPattern;
using DesignPatterns.Creational.PrototypePattern;
using DesignPatterns.Creational.SingletonPattern;
using DesignPatterns.Structural.AdapterPattern;
using DesignPatterns.Structural.BridgePattern;
using DesignPatterns.Structural.CompositePattern;
using DesignPatterns.Structural.DecoratorPattern;
using DesignPatterns.Structural.FacadePattern;
using DesignPatterns.Structural.FlyweightPattern;
using DesignPatterns.Structural.ProxyPattern;
using DesignPatterns.Behavioral.ChainOfResponsibilityPattern;
using DesignPatterns.Behavioral.CommandPattern;
using DesignPatterns.Behavioral.IteratorPattern;
using DesignPatterns.Behavioral.MediatorPattern;
using DesignPatterns.Behavioral.MementoPattern;
using DesignPatterns.Behavioral.ObserverPattern;
using DesignPatterns.Behavioral.StatePattern;
using DesignPatterns.Behavioral.StrategyPattern;



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

                    case "singleton":
                        SingletonPattern.Run();
                        break;

                    case "adapter":
                        Adapter.Run();
                        break;

                    case "bridge":
                        Bridge.Run();
                        break;
                    
                    case "composite":
                        Composite.Run();
                        break;    

                    case "decorator":
                        Decorator.Run();
                        break; 

                    case "facade":
                        Facade.Run();
                        break; 

                    case "flyweight":
                        Flyweight.Run();
                        break; 

                    case "iterator":
                        Iterator.Run();
                        break;

                    case "memento":
                        Memento.Run();
                        break;         

                    case "observer":
                        Observer.Run();
                        break;    

                    case "state":
                        State.Run();
                        break;      

                    case "proxy":
                        Proxy.Run();
                        break;

                    case "chain-of-resp":
                        ChainOfResponsibility.Run();
                        break;

                    case "command":
                        Command.Run();
                        break;

                    case "mediator":
                        Mediator.Run();
                        break; 

                    case "strategy":
                        Strategy.Run();
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
            Console.WriteLine("  dotnet run singleton        - Run Singleton Pattern demo");
            Console.WriteLine("  dotnet run adapter          - Run Adapter Pattern demo");
            Console.WriteLine("  dotnet run bridge           - Run Bridge Pattern demo");
            Console.WriteLine("  dotnet run composite        - Run Composite Pattern demo");
            Console.WriteLine("  dotnet run decorator        - Run Decorator Pattern demo");
            Console.WriteLine("  dotnet run facade           - Run Facade Pattern demo");
            Console.WriteLine("  dotnet run flyweight        - Run Flyweight Pattern demo");
            Console.WriteLine("  dotnet run proxy            - Run Proxy Pattern demo");
            Console.WriteLine("  dotnet run chain-of-resp    - Run Chain of Responsibility Pattern demo");
            Console.WriteLine("  dotnet run command          - Run Command Pattern demo");
            Console.WriteLine("  dotnet run iterator         - Run Iterator Pattern demo");
            Console.WriteLine("  dotnet run mediator         - Run Mediator Pattern demo");
            Console.WriteLine("  dotnet run memento          - Run Memento Pattern demo");     
            Console.WriteLine("  dotnet run observer         - Run Observer Pattern demo");
            Console.WriteLine("  dotnet run state            - Run State Pattern demo");
            Console.WriteLine("  dotnet run strategy         - Run Strategy Pattern demo");                                                                            
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
            Console.WriteLine("  ✓ singleton        - Singleton Pattern (Database connection example)");
            
            Console.WriteLine("\nStructural Patterns:");
            Console.WriteLine("  ✓ adapter         - Adapter Pattern (Payment system example)");
            Console.WriteLine("  ✓ bridge          - Bridge Pattern (Messaging system example)");
            Console.WriteLine("  ✓ composite       - Composite Pattern (File system example)");
            Console.WriteLine("  ✓ decorator       - Decorator Pattern (Coffee example)");
            Console.WriteLine("  ✓ facade          - Facade Pattern (Home Cinema example)");
            Console.WriteLine("  ✓ flyweight       - Flyweight Pattern (Forest example)");
            Console.WriteLine("  ✓ proxy           - Proxy Pattern (Internet example)");
            
            Console.WriteLine("\nBehavioral Patterns:");
            Console.WriteLine("  ✓ chain-of-resp    - Chain of Responsibility (Support system example) ");
            Console.WriteLine("  ✓ command          - Command (Light device example)");
            Console.WriteLine("  ✓ iterator         - Iterator (Book Collection Example)");
            Console.WriteLine("  ✓ mediator         - Mediator (Chat Room example)");
            Console.WriteLine("  ✓ memento          - Memento (Text Editor example)");
            Console.WriteLine("  ✓ observer         - Observer Pattern (YouTube example)");
            Console.WriteLine("  ✓ state            - State Pattern (Vending Machine example)");
            Console.WriteLine("  ✓ strategy         - Strategy Pattern (Payment exapmle)");
            Console.WriteLine("  ⏳ template-method - Coming soon...");
        }
    }
}
