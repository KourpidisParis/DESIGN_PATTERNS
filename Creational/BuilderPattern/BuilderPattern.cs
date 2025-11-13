using System;

namespace DesignPatterns.Creational.BuilderPattern
{
    /// <summary>
    /// Demo class to showcase the Builder Pattern
    /// </summary>
    public class BuilderPattern
    {
        public static void Run()
        {
            Console.WriteLine("=== Builder Pattern ===");

            try
            {
                // Build a Gaming Computer
                Console.WriteLine("\n--- Building Gaming Computer ---");
                IComputerBuilder gamingBuilder = new GamingComputerBuilder();
                ComputerDirector director = new ComputerDirector(gamingBuilder);
                Computer gamingPC = director.BuildComputer();
                gamingPC.ShowSpecifications();

                // Build an Office Computer
                Console.WriteLine("\n--- Building Office Computer ---");
                IComputerBuilder officeBuilder = new OfficeComputerBuilder();
                director.ChangeBuilder(officeBuilder);
                Computer officePC = director.BuildComputer();
                officePC.ShowSpecifications();

                // Build a Workstation Computer
                Console.WriteLine("\n--- Building Workstation Computer ---");
                IComputerBuilder workstationBuilder = new WorkstationComputerBuilder();
                director.ChangeBuilder(workstationBuilder);
                Computer workstation = director.BuildComputer();
                workstation.ShowSpecifications();

                // Build a minimal computer (without GPU and Case)
                Console.WriteLine("\n--- Building Minimal Computer ---");
                director.ChangeBuilder(new OfficeComputerBuilder());
                Computer minimalPC = director.BuildMinimalComputer();
                minimalPC.ShowSpecifications();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
