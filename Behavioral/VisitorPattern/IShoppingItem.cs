namespace DesignPatterns.Behavioral.VisitorPattern
{
    /// <summary>
    /// Element Interface - Shopping items that can be visited
    /// </summary>
    public interface IShoppingItem
    {
        void Accept(IShoppingVisitor visitor);
    }
}