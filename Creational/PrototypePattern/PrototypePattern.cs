using System;

namespace DesignPatterns.Creational.PrototypePattern
{
    /// <summary>
    /// Demo class to showcase the Prototype Pattern
    /// </summary>
    public class PrototypePattern
    {
        public static void Run()
        {
            Console.WriteLine("=== Prototype Pattern ===");

            try
            {
                Console.WriteLine("\n--- Creating Master Resume Template ---");
                Resume masterResume = new Resume(
                    "[Your Name]",
                    "[your.email@example.com]",
                    "[Your Phone]",
                    "[Your Experience]",
                    "[Your Education]"
                );
                Console.WriteLine("Master template created:");
                masterResume.Display();

                Console.WriteLine("\n--- Cloning Resume for Employee 1 ---");
                Resume employee1Resume = (Resume)masterResume.Clone();
                employee1Resume.Name = "John Doe";
                employee1Resume.Email = "john.doe@company.com";
                employee1Resume.Phone = "+1-555-1234";
                employee1Resume.Experience = "5 years as Senior Developer";
                employee1Resume.Education = "BS Computer Science, MIT";
                employee1Resume.Display();

                Console.WriteLine("\n--- Cloning Resume for Employee 2 ---");
                Resume employee2Resume = (Resume)masterResume.Clone();
                employee2Resume.Name = "Jane Smith";
                employee2Resume.Email = "jane.smith@company.com";
                employee2Resume.Phone = "+1-555-5678";
                employee2Resume.Experience = "3 years as Software Engineer";
                employee2Resume.Education = "MS Software Engineering, Stanford";
                employee2Resume.Display();

                Console.WriteLine("\n--- Cloning Resume for Employee 3 ---");
                Resume employee3Resume = (Resume)masterResume.Clone();
                employee3Resume.Name = "Mike Johnson";
                employee3Resume.Email = "mike.j@company.com";
                employee3Resume.Phone = "+1-555-9012";
                employee3Resume.Experience = "7 years as Tech Lead";
                employee3Resume.Education = "PhD Computer Science, Berkeley";
                employee3Resume.Display();

                // Verify that master template is unchanged
                Console.WriteLine("\n--- Master Template (Unchanged) ---");
                masterResume.Display();

                Console.WriteLine("\n=== Key Point ===");
                Console.WriteLine("We created the master template ONCE and CLONED it 3 times.");
                Console.WriteLine("Each clone is independent - changes don't affect the original.");

                // Another example with Report
                Console.WriteLine("\n\n--- Creating Master Report Template ---");
                Report masterReport = new Report(
                    "[Report Title]",
                    "[Author Name]",
                    DateTime.Now,
                    "[Report Content Here]",
                    0
                );
                Console.WriteLine("Master report template created:");
                masterReport.Display();

                Console.WriteLine("\n--- Cloning Monthly Report ---");
                Report januaryReport = (Report)masterReport.Clone();
                januaryReport.Title = "January 2024 Sales Report";
                januaryReport.Author = "Sales Team";
                januaryReport.Content = "January sales exceeded expectations by 15%";
                januaryReport.Pages = 12;
                januaryReport.Display();

                Console.WriteLine("\n--- Cloning Another Monthly Report ---");
                Report februaryReport = (Report)masterReport.Clone();
                februaryReport.Title = "February 2024 Sales Report";
                februaryReport.Author = "Sales Team";
                februaryReport.Content = "February maintained strong growth at 12%";
                februaryReport.Pages = 10;
                februaryReport.Display();

                Console.WriteLine("\n--- Master Report Template (Still Unchanged) ---");
                masterReport.Display();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
