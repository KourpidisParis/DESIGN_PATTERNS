using System;

namespace DesignPatterns.Structural.FacadePattern
{
    /// <summary>
    /// Subsystem - Sound System with complex operations
    /// </summary>
    public class SoundSystem
    {
        public void TurnOn()
        {
            Console.WriteLine("Sound System: Powering on...");
        }

        public void TurnOff()
        {
            Console.WriteLine("Sound System: Powering off...");
        }

        public void SetVolume(int level)
        {
            Console.WriteLine($"Sound System: Setting volume to {level}");
        }

        public void SetSurroundSound()
        {
            Console.WriteLine("Sound System: Enabling 5.1 surround sound");
        }

        public void SetInput(string input)
        {
            Console.WriteLine($"Sound System: Setting input to {input}");
        }
    }
}