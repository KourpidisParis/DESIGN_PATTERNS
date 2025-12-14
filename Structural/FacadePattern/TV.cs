using System;

namespace DesignPatterns.Structural.FacadePattern
{
    /// <summary>
    /// Subsystem - TV with complex operations
    /// </summary>
    public class TV
    {
        public void TurnOn()
        {
            Console.WriteLine("TV: Powering on...");
        }

        public void TurnOff()
        {
            Console.WriteLine("TV: Powering off...");
        }

        public void SetInput(string input)
        {
            Console.WriteLine($"TV: Setting input to {input}");
        }

        public void AdjustSettings()
        {
            Console.WriteLine("TV: Adjusting picture settings (brightness, contrast, color)");
        }
    }
}