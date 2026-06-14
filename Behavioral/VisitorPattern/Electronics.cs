namespace DesignPatterns.Behavioral.VisitorPattern
{
    /// <summary>
    /// Concrete Element - Electronics item
    /// </summary>
    public class Electronics : IShoppingItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Electronics(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public void Accept(IShoppingVisitor visitor)
        {
            visitor.VisitElectronics(this);
        }
    }
}