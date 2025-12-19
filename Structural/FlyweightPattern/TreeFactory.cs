using System;
using System.Collections.Generic;

namespace DesignPatterns.Structural.FlyweightPattern
{
    /// <summary>
    /// Flyweight Factory - Manages flyweight objects and ensures they are shared
    /// </summary>
    public class TreeFactory
    {
        private Dictionary<string, TreeType> _treeTypes = new Dictionary<string, TreeType>();

        public TreeType GetTreeType(string name, string color, string texture)
        {
            string key = $"{name}_{color}_{texture}";

            if (!_treeTypes.ContainsKey(key))
            {
                _treeTypes[key] = new TreeType(name, color, texture);
            }
            else
            {
                Console.WriteLine($"TreeFactory: Reusing existing tree type '{name}'");
            }

            return _treeTypes[key];
        }

        public int GetTreeTypeCount()
        {
            return _treeTypes.Count;
        }

        public void ShowTreeTypes()
        {
            Console.WriteLine($"\nTotal tree types created: {_treeTypes.Count}");
            foreach (var treeType in _treeTypes.Values)
            {
                Console.WriteLine($"  - {treeType.GetInfo()}");
            }
        }
    }
}