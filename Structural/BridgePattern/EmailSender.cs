using System;

namespace DesignPatterns.Structural.BridgePattern
{
    /// <summary>
    /// Concrete Implementation - Sends messages via Email
    /// </summary>
    public class EmailSender : IMessageSender
    {
        public void SendMessage(string message, string recipient)
        {
            Console.WriteLine($"[EMAIL] Sending to {recipient}");
            Console.WriteLine($"  Subject: Notification");
            Console.WriteLine($"  Body: {message}");
            Console.WriteLine($"  Status: Email sent successfully ✓");
        }
    }
}