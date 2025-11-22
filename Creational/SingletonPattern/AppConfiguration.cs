using System;

namespace DesignPatterns.Creational.SingletonPattern
{
    /// <summary>
    /// Singleton - Application Configuration
    /// Settings that should be consistent across the entire application
    /// </summary>
    public sealed class AppConfiguration
    {
        // The single instance (Lazy initialization for thread safety)
        private static readonly Lazy<AppConfiguration> _instance = 
            new Lazy<AppConfiguration>(() => new AppConfiguration());

        // Configuration settings
        public string AppName { get; set; }
        public string Version { get; set; }
        public string Environment { get; set; }
        public int MaxConnections { get; set; }
        public bool DebugMode { get; set; }

        // Private constructor
        private AppConfiguration()
        {
            // Default settings
            AppName = "Design Patterns Demo";
            Version = "1.0.0";
            Environment = "Development";
            MaxConnections = 100;
            DebugMode = true;
            Console.WriteLine("AppConfiguration: Instance created (constructor called)");
        }

        // The global access point (using Lazy<T> for thread-safe initialization)
        public static AppConfiguration Instance => _instance.Value;

        public void ShowConfiguration()
        {
            Console.WriteLine("Application Configuration:");
            Console.WriteLine($"  App Name: {AppName}");
            Console.WriteLine($"  Version: {Version}");
            Console.WriteLine($"  Environment: {Environment}");
            Console.WriteLine($"  Max Connections: {MaxConnections}");
            Console.WriteLine($"  Debug Mode: {DebugMode}");
        }
    }
}
