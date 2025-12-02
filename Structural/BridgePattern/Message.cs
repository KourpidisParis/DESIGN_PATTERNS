namespace DesignPatterns.Structural.BridgePattern
{
    /// <summary>
    /// Abstraction - Defines the high-level interface for messages
    /// Uses IMessageSender to actually send messages
    /// </summary>
    public abstract class Message
    {
        protected IMessageSender _messageSender;

        protected Message(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        public abstract void Send(string recipient);
    }
}