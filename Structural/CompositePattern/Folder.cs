using System;
using System.Collections.Generic;

namespace DesignPatterns.Structural.CompositePattern
{
    /// <summary>
    /// Composite - Represents folders that can contain files and other folders
    /// </summary>
    public class Folder : IFileSystemComponent
    {
        private string _name;
        private List<IFileSystemComponent> _components;

        public Folder(string name)
        {
            _name = name;
            _components = new List<IFileSystemComponent>();
        }

        public void Add(IFileSystemComponent component)
        {
            _components.Add(component);
        }

        public void Remove(IFileSystemComponent component)
        {
            _components.Remove(component);
        }

        public void ShowDetails()
        {
            Console.WriteLine($"📁 Folder: {_name}");
            foreach (var component in _components)
            {
                component.ShowDetails();
            }
        }

        public int GetSize()
        {
            int totalSize = 0;
            foreach (var component in _components)
            {
                totalSize += component.GetSize();
            }
            return totalSize;
        }
    }
}