using System;
using System.Collections.Generic;

namespace DesignPatterns.Creational.SingletonPattern
{
    /// <summary>
    /// Singleton - Logger
    /// Only ONE logger should exist to write to a single log file
    /// </summary>
    public sealed class Logger
    {
        // The single instance
        private static Logger _instance;
        
        // Lock object for thread safety
        private static readonly object _lock = new object();
        
        // Log storage (in real app, this would write to a file)
        private List<string> _logs;
        public int LogCount => _logs.Count;

        // Private constructor
        private Logger()
        {
            _logs = new List<string>();
            Console.WriteLine("Logger: Instance created (constructor called)");
        }

        // The global access point
        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Logger();
                        }
                    }
                }
                return _instance;
            }
        }

        public void Log(string message)
        {
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            _logs.Add(logEntry);
            Console.WriteLine($"Logger: {logEntry}");
        }

        public void LogInfo(string message)
        {
            Log($"INFO: {message}");
        }

        public void LogWarning(string message)
        {
            Log($"WARNING: {message}");
        }

        public void LogError(string message)
        {
            Log($"ERROR: {message}");
        }

        public void ShowAllLogs()
        {
            Console.WriteLine($"\n--- All Logs ({_logs.Count} entries) ---");
            foreach (var log in _logs)
            {
                Console.WriteLine(log);
            }
        }
    }
}
