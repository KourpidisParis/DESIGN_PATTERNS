using System;

namespace DesignPatterns.Behavioral.VisitorPattern
{
    /// <summary>
    /// Concrete Visitor - Calculates price
    /// </summary>
    public class PriceCalculator : IShoppingVisitor
    {
        private decimal _totalPrice;

        public void VisitBook(Book book)
        {
            Console.WriteLine($"📚 Book: {book.Title} → ${book.Price:F2}");
            _totalPrice += book.Price;
        }

        public void VisitElectronics(Electronics electronics)
        {
            Console.WriteLine($"💻 Electronics: {electronics.Name} → ${electronics.Price:F2}");
            _totalPrice += electronics.Price;
        }

        public decimal GetTotalPrice()
        {
            return _totalPrice;
        }

        public void Reset()
        {
            _totalPrice = 0;
        }
    }
}