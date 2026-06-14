using System;

namespace DesignPatterns.Behavioral.VisitorPattern
{
    /// <summary>
    /// Concrete Visitor - Calculates tax
    /// </summary>
    public class TaxCalculator : IShoppingVisitor
    {
        private decimal _totalTax;
        private const decimal BookTaxRate = 0.0m;      // Books are tax-free
        private const decimal ElectronicsTaxRate = 0.1m; // Electronics have 10% tax

        public void VisitBook(Book book)
        {
            decimal tax = book.Price * BookTaxRate;
            Console.WriteLine($"📚 Book: {book.Title} → Tax: ${tax:F2} (Tax-free)");
            _totalTax += tax;
        }

        public void VisitElectronics(Electronics electronics)
        {
            decimal tax = electronics.Price * ElectronicsTaxRate;
            Console.WriteLine($"💻 Electronics: {electronics.Name} → Tax: ${tax:F2} (10%)");
            _totalTax += tax;
        }

        public decimal GetTotalTax()
        {
            return _totalTax;
        }

        public void Reset()
        {
            _totalTax = 0;
        }
    }
}