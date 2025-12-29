using System;
using System.Collections.Generic;

namespace DesignPatterns.Structural.ProxyPattern
{
    /// <summary>
    /// Protection Proxy - Controls access by blocking banned sites
    /// </summary>
    public class ProxyInternet : IInternet
    {
        private RealInternet _realInternet;
        private List<string> _bannedSites;

        public ProxyInternet()
        {
            _realInternet = new RealInternet();
            _bannedSites = new List<string>
            {
                "facebook.com",
                "youtube.com",
                "netflix.com",
                "gaming.com",
                "banned.com"
            };
        }

        public void ConnectTo(string site)
        {
            if (_bannedSites.Contains(site.ToLower()))
            {
                Console.WriteLine($"❌ Access DENIED to {site} - Site is blocked by company policy!");
            }
            else
            {
                _realInternet.ConnectTo(site);
            }
        }

        public void AddBannedSite(string site)
        {
            if (!_bannedSites.Contains(site.ToLower()))
            {
                _bannedSites.Add(site.ToLower());
                Console.WriteLine($"🚫 Added {site} to banned list");
            }
        }

        public void ShowBannedSites()
        {
            Console.WriteLine("\n📋 Banned Sites:");
            foreach (var site in _bannedSites)
            {
                Console.WriteLine($"  - {site}");
            }
        }
    }
}