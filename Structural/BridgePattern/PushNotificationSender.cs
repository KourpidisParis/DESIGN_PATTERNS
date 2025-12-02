using System;

namespace DesignPatterns.Structural.BridgePattern
{
    /// <summary>
    /// Concrete Implementation - Sends messages via Push Notification
    /// </summary>
    public class PushNotificationSender : IMessageSender
    {
        public void SendMessage(string message, string recipient)
        {
            Console.WriteLine($"[PUSH] Sending to device {recipient}");
            Console.WriteLine($"  Notification: {message}");
            Console.WriteLine($"  Status: Push notification sent successfully ✓");
        }
    }
}