using System;

namespace DesignPatterns.Behavioral.ChainOfResponsibilityPattern
{
    /// <summary>
    /// Concrete Handler - Management Support (handles critical issues)
    /// </summary>
    public class ManagementSupport : SupportHandler
    {
        public override void HandleRequest(SupportRequest request)
        {
            if (request.Priority == 4)
            {
                Console.WriteLine("👔 Management: Handling CRITICAL request...");
                Console.WriteLine($"   Solution: Executive decision and immediate action for '{request.Issue}'");
                Console.WriteLine("   ✅ Issue resolved by Management\n");
            }
            else
            {
                Console.WriteLine("👔 Management: This request doesn't require management attention.\n");
                if (_nextHandler != null)
                {
                    _nextHandler.HandleRequest(request);
                }
                else
                {
                    Console.WriteLine("⚠️ No appropriate handler found!\n");
                }
            }
        }
    }
}