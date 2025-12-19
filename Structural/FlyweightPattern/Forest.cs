using System;
using System.Collections.Generic;

namespace DesignPatterns.Structural.FlyweightPattern
{
    /// <summary>
    /// Client - Uses flyweights to manage a large number of objects efficiently
    /// </summary>
    public class Forest
    {
        private List<Tree> _trees = new List<Tree>();
        private TreeFactory _factory = new TreeFactory();

        public void PlantTree(int x, int y, int height, string name, string color, string texture)
        {
            TreeType type = _factory.GetTreeType(name, color, texture);
            Tree tree = new Tree(x, y, height, type);
            _trees.Add(tree);
        }

        public void Display()
        {
            Console.WriteLine($"\nForest has {_trees.Count} trees:");
            foreach (var tree in _trees)
            {
                tree.Display();
            }
        }

        public void ShowStatistics()
        {
            Console.WriteLine($"\n=== Forest Statistics ===");
            Console.WriteLine($"Total trees planted: {_trees.Count}");
            Console.WriteLine($"Unique tree types: {_factory.GetTreeTypeCount()}");
            Console.WriteLine($"Memory saved: Instead of {_trees.Count} TreeType objects, only {_factory.GetTreeTypeCount()} created!");

            _factory.ShowTreeTypes();
        }
    }
}