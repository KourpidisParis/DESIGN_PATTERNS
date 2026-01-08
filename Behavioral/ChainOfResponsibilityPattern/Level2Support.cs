using System;

namespace DesignPatterns.Behavioral.ChainOfResponsibilityPattern
{
    /// <summary>
    /// Concrete Handler - Level 2 Support (handles medium priority issues)
    /// </summary>
    public class Level2Support : SupportHandler
    {
        public override void HandleRequest(SupportRequest request)
        {
            if (request.Priority == 2)
            {
                Console.WriteLine("👨‍🔧 Level 2 Support: Handling request...");
                Console.WriteLine($"   Solution: Technical investigation for '{request.Issue}'");
                Console.WriteLine("   ✅ Issue resolved by Level 2 Support\n");
            }
            else
            {
                Console.WriteLine("👨‍🔧 Level 2 Support: Cannot handle this request. Escalating...\n");
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