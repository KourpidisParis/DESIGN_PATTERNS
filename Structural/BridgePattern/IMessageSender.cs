namespace DesignPatterns.Structural.BridgePattern
{
    /// <summary>
    /// Implementation Interface - Defines how messages are sent
    /// This is the "bridge" that separates abstraction from implementation
    /// </summary>
    public interface IMessageSender
    {
        void SendMessage(string message, string recipient);
    }
}