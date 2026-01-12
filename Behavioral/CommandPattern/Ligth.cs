using System;

namespace DesignPatterns.Behavioral.CommandPattern
{
    /// <summary>
    /// Receiver - The object that performs the actual work
    /// </summary>
    public class Light
    {
        private string _location;
        private bool _isOn;

        public Light(string location)
        {
            _location = location;
            _isOn = false;
        }

        public void TurnOn()
        {
            _isOn = true;
            Console.WriteLine($"💡 {_location} light is ON");
        }

        public void TurnOff()
        {
            _isOn = false;
            Console.WriteLine($"🔌 {_location} light is OFF");
        }

        public bool IsOn()
        {
            return _isOn;
        }
    }
}