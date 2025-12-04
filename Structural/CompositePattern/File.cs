using System;

namespace DesignPatterns.Structural.CompositePattern
{
    /// <summary>
    /// Leaf - Represents individual files (no children)
    /// </summary>
    public class File : IFileSystemComponent
    {
        private string _name;
        private int _size;

        public File(string name, int size)
        {
            _name = name;
            _size = size;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"  📄 File: {_name} ({_size} KB)");
        }

        public int GetSize()
        {
            return _size;
        }
    }
}