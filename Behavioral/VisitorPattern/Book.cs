namespace DesignPatterns.Behavioral.VisitorPattern
{
    /// <summary>
    /// Concrete Element - Book item
    /// </summary>
    public class Book : IShoppingItem
    {
        public string Title { get; set; }
        public decimal Price { get; set; }

        public Book(string title, decimal price)
        {
            Title = title;
            Price = price;
        }

        public void Accept(IShoppingVisitor visitor)
        {
            visitor.VisitBook(this);
        }
    }
}