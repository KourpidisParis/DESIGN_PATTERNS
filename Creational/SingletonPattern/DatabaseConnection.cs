using System;

namespace DesignPatterns.Creational.SingletonPattern
{
    /// <summary>
    /// Singleton - Database Connection Manager
    /// Only ONE connection should exist in the application
    /// </summary>
    public sealed class DatabaseConnection
    {
        // The single instance
        private static DatabaseConnection _instance;
        
        // Lock object for thread safety
        private static readonly object _lock = new object();
        
        // Connection info
        public string ConnectionString { get; private set; }
        public bool IsConnected { get; private set; }
        public DateTime ConnectedAt { get; private set; }

        // Private constructor - no one can create instances from outside
        private DatabaseConnection()
        {
            ConnectionString = "Server=localhost;Database=MyApp;";
            IsConnected = false;
            Console.WriteLine("DatabaseConnection: Instance created (constructor called)");
        }

        // The global access point
        public static DatabaseConnection Instance
        {
            get
            {
                // Double-check locking for thread safety
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DatabaseConnection();
                        }
                    }
                }
                return _instance;
            }
        }

        public void Connect()
        {
            if (!IsConnected)
            {
                Console.WriteLine("DatabaseConnection: Connecting to database...");
                IsConnected = true;
                ConnectedAt = DateTime.Now;
                Console.WriteLine($"DatabaseConnection: Connected at {ConnectedAt}");
            }
            else
            {
                Console.WriteLine("DatabaseConnection: Already connected!");
            }
        }

        public void Disconnect()
        {
            if (IsConnected)
            {
                Console.WriteLine("DatabaseConnection: Disconnecting from database...");
                IsConnected = false;
            }
            else
            {
                Console.WriteLine("DatabaseConnection: Not connected!");
            }
        }

        public void ExecuteQuery(string query)
        {
            if (IsConnected)
            {
                Console.WriteLine($"DatabaseConnection: Executing query: {query}");
            }
            else
            {
                Console.WriteLine("DatabaseConnection: Cannot execute query - not connected!");
            }
        }

        public void ShowStatus()
        {
            Console.WriteLine($"DatabaseConnection Status:");
            Console.WriteLine($"  Connection String: {ConnectionString}");
            Console.WriteLine($"  Is Connected: {IsConnected}");
            if (IsConnected)
            {
                Console.WriteLine($"  Connected At: {ConnectedAt}");
            }
        }
    }
}
