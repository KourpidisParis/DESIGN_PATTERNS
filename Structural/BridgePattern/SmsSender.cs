using System;

namespace DesignPatterns.Structural.BridgePattern
{
    /// <summary>
    /// Concrete Implementation - Sends messages via SMS
    /// </summary>
    public class SmsSender : IMessageSender
    {
        public void SendMessage(string message, string recipient)
        {
            Console.WriteLine($"[SMS] Sending to {recipient}");
            Console.WriteLine($"  Message: {message}");
            Console.WriteLine($"  Status: SMS sent successfully ✓");
        }
    }
}