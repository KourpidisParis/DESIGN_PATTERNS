namespace DesignPatterns.Behavioral.VisitorPattern
{
    /// <summary>
    /// Visitor Interface - Defines operations on elements
    /// </summary>
    public interface IShoppingVisitor
    {
        void VisitBook(Book book);
        void VisitElectronics(Electronics electronics);
    }
}