using System;

namespace DesignPatterns.Structural.FlyweightPattern
{
    /// <summary>
    /// Concrete Flyweight - Stores intrinsic state (shared data)
    /// This is the heavy data that's shared among many trees
    /// </summary>
    public class TreeType : ITree
    {
        // Intrinsic state (shared) - same for all trees of this type
        private string _name;
        private string _color;
        private string _texture;

        public TreeType(string name, string color, string texture)
        {
            _name = name;
            _color = color;
            _texture = texture;

            Console.WriteLine($"TreeType: Creating new tree type '{name}' (This is expensive!)");
        }

        public void Display(int x, int y, int height)
        {
            // Extrinsic state (unique per tree) is passed as parameters
            Console.WriteLine($"  🌳 {_name} tree at ({x}, {y}), height: {height}m, color: {_color}");
        }

        public string GetInfo()
        {
            return $"{_name} ({_color}, {_texture})";
        }
    }
}