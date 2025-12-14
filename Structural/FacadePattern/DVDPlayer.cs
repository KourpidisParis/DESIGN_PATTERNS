using System;

namespace DesignPatterns.Structural.FacadePattern
{
    /// <summary>
    /// Subsystem - DVD Player with complex operations
    /// </summary>
    public class DVDPlayer
    {
        public void TurnOn()
        {
            Console.WriteLine("DVD Player: Powering on...");
        }

        public void TurnOff()
        {
            Console.WriteLine("DVD Player: Powering off...");
        }

        public void InsertDVD(string movie)
        {
            Console.WriteLine($"DVD Player: Inserting DVD '{movie}'");
        }

        public void Play()
        {
            Console.WriteLine("DVD Player: Playing movie...");
        }

        public void Stop()
        {
            Console.WriteLine("DVD Player: Stopping playback...");
        }

        public void Eject()
        {
            Console.WriteLine("DVD Player: Ejecting DVD...");
        }
    }
}