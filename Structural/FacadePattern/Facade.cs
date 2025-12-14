using System;

namespace DesignPatterns.Structural.FacadePattern
{
    /// <summary>
    /// Demo class to showcase the Facade Pattern
    /// </summary>
    public class Facade
    {
        public static void Run()
        {
            Console.WriteLine("=== Facade Pattern ===");
            Console.WriteLine("Simplifying complex home theater operations\n");

            try
            {
                // Create the facade
                HomeTheaterFacade homeTheater = new HomeTheaterFacade();

                // Scenario 1: Watch a movie (simple!)
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Scenario 1: Movie Night");
                Console.WriteLine("═══════════════════════════════════════");
                homeTheater.WatchMovie("The Matrix");

                Console.WriteLine("\n--- 2 hours later... ---\n");

                homeTheater.EndMovie();

                // Scenario 2: Watch TV (simple!)
                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("Scenario 2: Watch Regular TV");
                Console.WriteLine("═══════════════════════════════════════");
                homeTheater.WatchTV();

                Console.WriteLine("\n--- 1 hour later... ---\n");

                homeTheater.EndTV();

                // Show the complexity being hidden
                Console.WriteLine("\n\n=== Understanding the Facade ===");
                Console.WriteLine("WITHOUT Facade (you have to do this manually):");
                Console.WriteLine("  1. Dim lights to 10%");
                Console.WriteLine("  2. Turn on projector");
                Console.WriteLine("  3. Set projector input to HDMI 1");
                Console.WriteLine("  4. Set projector to wide screen mode");
                Console.WriteLine("  5. Turn on sound system");
                Console.WriteLine("  6. Set sound system input to DVD");
                Console.WriteLine("  7. Set volume to 50");
                Console.WriteLine("  8. Enable surround sound");
                Console.WriteLine("  9. Turn on DVD player");
                Console.WriteLine("  10. Insert DVD");
                Console.WriteLine("  11. Press play");
                Console.WriteLine("  ... and then reverse all this when done!");

                Console.WriteLine("\nWITH Facade (simple!):");
                Console.WriteLine("  homeTheater.WatchMovie(\"The Matrix\");");
                Console.WriteLine("  ... enjoy the movie ...");
                Console.WriteLine("  homeTheater.EndMovie();");

                Console.WriteLine("\n=== Key Points ===");
                Console.WriteLine("1. Facade hides complexity behind a simple interface");
                Console.WriteLine("2. Client only needs to know WatchMovie() and EndMovie()");
                Console.WriteLine("3. All subsystem coordination is handled internally");
                Console.WriteLine("4. Makes the system easier to use and understand");
                Console.WriteLine("5. You can still access subsystems directly if needed (advanced users)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}