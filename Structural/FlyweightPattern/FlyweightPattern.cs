namespace DesignPatterns.Structural.FlyweightPattern
{
    /// <summary>
    /// Flyweight Interface - Defines operations that flyweight objects must implement
    /// </summary>
    public interface ITree
    {
        void Display(int x, int y, int height);
    }
}