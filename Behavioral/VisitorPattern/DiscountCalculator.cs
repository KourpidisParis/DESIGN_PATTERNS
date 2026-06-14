using System;

namespace DesignPatterns.Behavioral.VisitorPattern
{
    /// <summary>
    /// Concrete Visitor - Applies discounts
    /// </summary>
    public class DiscountCalculator : IShoppingVisitor
    {
        private decimal _totalDiscount;
        private const decimal BookDiscount = 0.05m;      // Books: 5% discount
        private const decimal ElectronicsDiscount = 0.15m; // Electronics: 15% discount

        public void VisitBook(Book book)
        {
            decimal discount = book.Price * BookDiscount;
            Console.WriteLine($"📚 Book: {book.Title} → Discount: ${discount:F2} (5%)");
            _totalDiscount += discount;
        }

        public void VisitElectronics(Electronics electronics)
        {
            decimal discount = electronics.Price * ElectronicsDiscount;
            Console.WriteLine($"💻 Electronics: {electronics.Name} → Discount: ${discount:F2} (15%)");
            _totalDiscount += discount;
        }

        public decimal GetTotalDiscount()
        {
            return _totalDiscount;
        }

        public void Reset()
        {
            _totalDiscount = 0;
        }
    }
}