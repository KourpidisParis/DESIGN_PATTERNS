
namespace DesignPatterns.Behavioral.MediatorPattern
{
    /// <summary>
    /// Colleague - User that communicates through mediator
    /// </summary>
    public class User
    {
        public string Name { get; private set; }
        private IChatMediator _mediator;

        public User(string name, IChatMediator mediator)
        {
            Name = name;
            _mediator = mediator;
        }

        public void Send(string message)
        {
            _mediator.SendMessage(message, this);
        }

        public void Receive(string message, User sender)
        {
            Console.WriteLine($"   📩 {Name} received: \"{message}\" from {sender.Name}");
        }
    }
}