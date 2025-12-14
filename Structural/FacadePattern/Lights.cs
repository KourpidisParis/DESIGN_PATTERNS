using System;

namespace DesignPatterns.Structural.FacadePattern
{
    /// <summary>
    /// Subsystem - Smart Lights with complex operations
    /// </summary>
    public class Lights
    {
        public void TurnOff()
        {
            Console.WriteLine("Lights: Turning off...");
        }

        public void Dim(int level)
        {
            Console.WriteLine($"Lights: Dimming to {level}%");
        }

        public void TurnOn()
        {
            Console.WriteLine("Lights: Turning on to full brightness");
        }
    }
}