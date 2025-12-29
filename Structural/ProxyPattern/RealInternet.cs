using System;

namespace DesignPatterns.Structural.ProxyPattern
{
    /// <summary>
    /// Real Subject - The actual internet connection
    /// </summary>
    public class RealInternet : IInternet
    {
        public void ConnectTo(string site)
        {
            Console.WriteLine($"✅ Connecting to {site}");
        }
    }
}