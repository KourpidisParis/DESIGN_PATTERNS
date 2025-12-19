namespace DesignPatterns.Structural.FlyweightPattern
{
    /// <summary>
    /// Context Object - Stores extrinsic state (unique data per tree)
    /// References the shared flyweight
    /// </summary>
    public class Tree
    {
        // Extrinsic state (unique per tree)
        private int _x;
        private int _y;
        private int _height;

        // Reference to shared flyweight (intrinsic state)
        private TreeType _type;

        public Tree(int x, int y, int height, TreeType type)
        {
            _x = x;
            _y = y;
            _height = height;
            _type = type;
        }

        public void Display()
        {
            _type.Display(_x, _y, _height);
        }
    }
}