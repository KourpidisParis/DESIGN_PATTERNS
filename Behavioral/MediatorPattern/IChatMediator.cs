namespace DesignPatterns.Behavioral.MediatorPattern
{
    /// <summary>
    /// Mediator Interface - Defines communication method
    /// </summary>
    public interface IChatMediator
    {
        void SendMessage(string message, User user);
        void AddUser(User user);
    }
}