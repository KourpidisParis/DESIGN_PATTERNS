using System;

namespace DesignPatterns.Behavioral.ChainOfResponsibilityPattern
{
    /// <summary>
    /// Request object - Contains information about the support request
    /// </summary>
    public class SupportRequest
    {
        public string CustomerName { get; set; }
        public string Issue { get; set; }
        public int Priority { get; set; } // 1 = Low, 2 = Medium, 3 = High, 4 = Critical

        public SupportRequest(string customerName, string issue, int priority)
        {
            CustomerName = customerName;
            Issue = issue;
            Priority = priority;
        }

        public void Display()
        {
            string priorityText = Priority switch
            {
                1 => "LOW",
                2 => "MEDIUM",
                3 => "HIGH",
                4 => "CRITICAL",
                _ => "UNKNOWN"
            };

            Console.WriteLine($"Request from {CustomerName}: {Issue} [Priority: {priorityText}]");
        }
    }
}