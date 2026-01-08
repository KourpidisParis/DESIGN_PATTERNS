using System;

namespace DesignPatterns.Behavioral.ChainOfResponsibilityPattern
{
    /// <summary>
    /// Concrete Handler - Level 1 Support (handles low priority issues)
    /// </summary>
    public class Level1Support : SupportHandler
    {
        public override void HandleRequest(SupportRequest request)
        {
            if (request.Priority == 1)
            {
                Console.WriteLine("👨‍💻 Level 1 Support: Handling request...");
                Console.WriteLine($"   Solution: Basic troubleshooting for '{request.Issue}'");
                Console.WriteLine("   ✅ Issue resolved by Level 1 Support\n");
            }
            else
            {
                Console.WriteLine("👨‍💻 Level 1 Support: Cannot handle this request. Escalating...\n");
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