using System;

namespace DesignPatterns.Behavioral.ChainOfResponsibilityPattern
{
    /// <summary>
    /// Demo class to showcase the Chain of Responsibility Pattern
    /// </summary>
    public class ChainOfResponsibility
    {
        public static void Run()
        {
            Console.WriteLine("=== Chain of Responsibility Pattern ===");
            Console.WriteLine("Customer Support Ticket System\n");

            try
            {
                // Build the chain: Level1 → Level2 → Level3 → Management
                Console.WriteLine("Building support chain...");
                SupportHandler level1 = new Level1Support();
                SupportHandler level2 = new Level2Support();
                SupportHandler level3 = new Level3Support();
                SupportHandler management = new ManagementSupport();

                level1.SetNext(level2);
                level2.SetNext(level3);
                level3.SetNext(management);

                Console.WriteLine("Chain: Level 1 → Level 2 → Level 3 → Management\n");

                // Create different priority requests
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Processing Support Requests");
                Console.WriteLine("═══════════════════════════════════════\n");

                // Request 1: Low priority
                Console.WriteLine("--- Request 1 ---");
                SupportRequest request1 = new SupportRequest(
                    "John Smith",
                    "Password reset needed",
                    1
                );
                request1.Display();
                level1.HandleRequest(request1);

                // Request 2: Medium priority
                Console.WriteLine("--- Request 2 ---");
                SupportRequest request2 = new SupportRequest(
                    "Sarah Johnson",
                    "Software not installing properly",
                    2
                );
                request2.Display();
                level1.HandleRequest(request2);

                // Request 3: High priority
                Console.WriteLine("--- Request 3 ---");
                SupportRequest request3 = new SupportRequest(
                    "Mike Williams",
                    "Database connection failing",
                    3
                );
                request3.Display();
                level1.HandleRequest(request3);

                // Request 4: Critical priority
                Console.WriteLine("--- Request 4 ---");
                SupportRequest request4 = new SupportRequest(
                    "Emily Davis",
                    "Server down - entire system offline!",
                    4
                );
                request4.Display();
                level1.HandleRequest(request4);

                // Request 5: Another low priority
                Console.WriteLine("--- Request 5 ---");
                SupportRequest request5 = new SupportRequest(
                    "David Brown",
                    "How to change email settings?",
                    1
                );
                request5.Display();
                level1.HandleRequest(request5);

                // Summary
                Console.WriteLine("\n=== Understanding the Chain ===");
                Console.WriteLine("How it works:");
                Console.WriteLine("  1. All requests start at Level 1 Support");
                Console.WriteLine("  2. Each handler checks if it can handle the request");
                Console.WriteLine("  3. If yes → handles it and stops");
                Console.WriteLine("  4. If no → passes to next handler in chain");
                Console.WriteLine("  5. Process continues until someone handles it");

                Console.WriteLine("\nBenefits:");
                Console.WriteLine("  - Request sender doesn't know who will handle it");
                Console.WriteLine("  - Easy to add/remove handlers");
                Console.WriteLine("  - Handlers are loosely coupled");
                Console.WriteLine("  - Follows Single Responsibility Principle");

                Console.WriteLine("\n=== Key Points ===");
                Console.WriteLine("1. Chain of handlers process requests sequentially");
                Console.WriteLine("2. Each handler decides: handle it or pass to next");
                Console.WriteLine("3. Decouples sender from receiver");
                Console.WriteLine("4. Dynamic chain - can be modified at runtime");
                Console.WriteLine("5. Used in: logging, authentication, validation, etc.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}