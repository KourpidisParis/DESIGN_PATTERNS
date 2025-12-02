using System;

namespace DesignPatterns.Structural.BridgePattern
{
    /// <summary>
    /// Refined Abstraction - Urgent message with priority
    /// </summary>
    public class UrgentMessage : Message
    {
        private string _content;

        public UrgentMessage(IMessageSender messageSender, string content) 
            : base(messageSender)
        {
            _content = content;
        }

        public override void Send(string recipient)
        {
            Console.WriteLine("\n--- Sending URGENT Message ---");
            Console.WriteLine("⚠️  PRIORITY: HIGH");
            _messageSender.SendMessage($"[URGENT] {_content}", recipient);
        }
    }
}