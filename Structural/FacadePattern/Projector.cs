using System;

namespace DesignPatterns.Structural.FacadePattern
{
    /// <summary>
    /// Subsystem - Projector with complex operations
    /// </summary>
    public class Projector
    {
        public void TurnOn()
        {
            Console.WriteLine("Projector: Powering on...");
        }

        public void TurnOff()
        {
            Console.WriteLine("Projector: Powering off...");
        }

        public void SetInput(string input)
        {
            Console.WriteLine($"Projector: Setting input to {input}");
        }

        public void SetWideScreenMode()
        {
            Console.WriteLine("Projector: Setting wide screen mode (16:9)");
        }
    }
}