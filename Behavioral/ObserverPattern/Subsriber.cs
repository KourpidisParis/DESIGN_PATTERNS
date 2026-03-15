using System;

namespace DesignPatterns.Behavioral.ObserverPattern
{
    /// <summary>
    /// Concrete Observer - YouTube subscriber that receives notifications
    /// </summary>
    public class Subscriber : IObserver
    {
        private string _name;

        public Subscriber(string name)
        {
            _name = name;
        }

        public void Update(string videoTitle)
        {
            Console.WriteLine($"   🔔 {_name} received notification: New video \"{videoTitle}\"");
        }

        public string GetName()
        {
            return _name;
        }
    }
}