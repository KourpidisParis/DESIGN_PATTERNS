using System;

namespace DesignPatterns.Structural.ProxyPattern
{
    /// <summary>
    /// Demo class to showcase the Proxy Pattern
    /// </summary>
    public class Proxy
    {
        public static void Run()
        {
            Console.WriteLine("=== Proxy Pattern ===");
            Console.WriteLine("Internet Access Control with Protection Proxy\n");

            try
            {
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Scenario: Office Network with Content Filtering");
                Console.WriteLine("═══════════════════════════════════════\n");

                ProxyInternet internet = new ProxyInternet();

                // Show banned sites
                internet.ShowBannedSites();

                // Employee accessing work-related sites
                Console.WriteLine("\n--- Employee accessing work-related sites ---");
                internet.ConnectTo("google.com");
                internet.ConnectTo("github.com");
                internet.ConnectTo("stackoverflow.com");
                internet.ConnectTo("microsoft.com");

                // Employee trying to access blocked sites
                Console.WriteLine("\n--- Employee trying to access blocked sites ---");
                internet.ConnectTo("facebook.com");
                internet.ConnectTo("youtube.com");
                internet.ConnectTo("netflix.com");
                internet.ConnectTo("gaming.com");

                // More allowed sites
                Console.WriteLine("\n--- More work sites ---");
                internet.ConnectTo("wikipedia.org");
                internet.ConnectTo("linkedin.com");
                internet.ConnectTo("gmail.com");

                // Admin adds new banned site
                Console.WriteLine("\n--- Admin adds new restriction ---");
                internet.AddBannedSite("twitter.com");

                Console.WriteLine("\n--- Employee tries newly banned site ---");
                internet.ConnectTo("twitter.com");

                // Summary
                Console.WriteLine("\n\n=== Understanding the Proxy ===");
                Console.WriteLine("WITHOUT Proxy:");
                Console.WriteLine("  - Employees can access any website");
                Console.WriteLine("  - No control or monitoring");
                Console.WriteLine("  - Potential productivity loss");
                Console.WriteLine("  - Security risks");

                Console.WriteLine("\nWITH Proxy:");
                Console.WriteLine("  - Proxy intercepts all requests");
                Console.WriteLine("  - Checks each site against banned list");
                Console.WriteLine("  - Blocks unauthorized access");
                Console.WriteLine("  - Allows work-related sites");
                Console.WriteLine("  - Easy to add/remove restrictions");

                Console.WriteLine("\n=== Key Points ===");
                Console.WriteLine("1. Client uses IInternet interface (doesn't know about proxy)");
                Console.WriteLine("2. Proxy has same interface as RealInternet");
                Console.WriteLine("3. Proxy adds access control without changing RealInternet");
                Console.WriteLine("4. Can easily modify banned sites list");
                Console.WriteLine("5. Could add logging, statistics, or other features");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}