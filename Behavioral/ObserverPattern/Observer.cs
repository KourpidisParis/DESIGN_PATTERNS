using System;

namespace DesignPatterns.Behavioral.ObserverPattern
{
    /// <summary>
    /// Demo class to showcase the Observer Pattern
    /// </summary>
    public class Observer
    {
        public static void Run()
        {
            Console.WriteLine("=== Observer Pattern ===");
            Console.WriteLine("YouTube Channel Notification System\n");

            try
            {
                // Create subject (YouTube channel)
                YouTubeChannel techChannel = new YouTubeChannel("TechTutorials");

                // Create observers (subscribers)
                Subscriber john = new Subscriber("John");
                Subscriber alice = new Subscriber("Alice");
                Subscriber bob = new Subscriber("Bob");

                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Users Subscribing to Channel");
                Console.WriteLine("═══════════════════════════════════════\n");

                // Subscribers subscribe to channel
                techChannel.Attach(john);
                techChannel.Attach(alice);
                techChannel.Attach(bob);

                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("Channel Uploads Videos");
                Console.WriteLine("═══════════════════════════════════════");

                // Channel uploads first video
                techChannel.UploadVideo("Design Patterns Explained");

                // Channel uploads second video
                techChannel.UploadVideo("SOLID Principles Tutorial");

                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("Alice Unsubscribes");
                Console.WriteLine("═══════════════════════════════════════\n");

                // Alice unsubscribes
                techChannel.Detach(alice);

                // Channel uploads third video (Alice won't be notified)
                techChannel.UploadVideo("Clean Code Best Practices");

                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("New Subscriber Joins");
                Console.WriteLine("═══════════════════════════════════════\n");

                // New subscriber
                Subscriber sarah = new Subscriber("Sarah");
                techChannel.Attach(sarah);

                // Channel uploads fourth video
                techChannel.UploadVideo("Refactoring Tips and Tricks");

                Console.WriteLine("\n\n=== Understanding the Observer Pattern ===");
                Console.WriteLine("Components:");
                Console.WriteLine("  1. Subject Interface (ISubject) - Attach, Detach, Notify");
                Console.WriteLine("  2. Concrete Subject (YouTubeChannel) - Maintains subscribers list");
                Console.WriteLine("  3. Observer Interface (IObserver) - Update method");
                Console.WriteLine("  4. Concrete Observer (Subscriber) - Receives notifications");

                Console.WriteLine("\nHow it works:");
                Console.WriteLine("  1. Subscribers attach to channel (subscribe)");
                Console.WriteLine("  2. Channel uploads video");
                Console.WriteLine("  3. Channel notifies all subscribers");
                Console.WriteLine("  4. Each subscriber receives update");

                Console.WriteLine("\n=== Key Points ===");
                Console.WriteLine("1. One-to-many dependency between objects");
                Console.WriteLine("2. When subject changes, all observers are notified");
                Console.WriteLine("3. Loose coupling - subject doesn't know observer details");
                Console.WriteLine("4. Observers can subscribe/unsubscribe dynamically");
                Console.WriteLine("5. Also known as Publish-Subscribe pattern");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}