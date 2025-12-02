using System;

namespace DesignPatterns.Structural.BridgePattern
{
    /// <summary>
    /// Refined Abstraction - Simple text message
    /// </summary>
    public class TextMessage : Message
    {
        private string _content;

        public TextMessage(IMessageSender messageSender, string content) 
            : base(messageSender)
        {
            _content = content;
        }

        public override void Send(string recipient)
        {
            Console.WriteLine("\n--- Sending Text Message ---");
            _messageSender.SendMessage(_content, recipient);
        }
    }
}