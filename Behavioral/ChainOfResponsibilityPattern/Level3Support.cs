using System;

namespace DesignPatterns.Behavioral.ChainOfResponsibilityPattern
{
    /// <summary>
    /// Concrete Handler - Level 3 Support (handles high priority issues)
    /// </summary>
    public class Level3Support : SupportHandler
    {
        public override void HandleRequest(SupportRequest request)
        {
            if (request.Priority == 3)
            {
                Console.WriteLine("👨‍💼 Level 3 Support (Senior Engineer): Handling request...");
                Console.WriteLine($"   Solution: Advanced diagnostics for '{request.Issue}'");
                Console.WriteLine("   ✅ Issue resolved by Level 3 Support\n");
            }
            else
            {
                Console.WriteLine("👨‍💼 Level 3 Support: Cannot handle this request. Escalating to Management...\n");
                if (_nextHandler != null)
                {
                    _nextHandler.HandleRequest(request);
                }
                else
                {
                    Console.WriteLine("⚠️ No handler available to process this request!\n");
                }
            }
        }
    }
}