using System;
using System.Collections.Generic;

namespace DesignPatterns.Creational.PrototypePattern
{
    /// <summary>
    /// Document Manager - manages prototype documents
    /// </summary>
    public class DocumentManager
    {
        private Dictionary<string, IDocument> _templates = new Dictionary<string, IDocument>();

        public void AddTemplate(string key, IDocument document)
        {
            _templates[key] = document;
        }

        public IDocument CreateDocument(string key)
        {
            if (_templates.ContainsKey(key))
            {
                return _templates[key].Clone();
            }

            throw new ArgumentException($"Template '{key}' not found");
        }

        public void ShowAvailableTemplates()
        {
            Console.WriteLine("Available Templates:");
            foreach (var key in _templates.Keys)
            {
                Console.WriteLine($"  - {key}");
            }
        }
    }
}
