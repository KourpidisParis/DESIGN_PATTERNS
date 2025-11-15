using System;

namespace DesignPatterns.Creational.PrototypePattern
{
    /// <summary>
    /// Concrete Prototype - Invoice document
    /// </summary>
    public class Invoice : IDocument
    {
        public string InvoiceNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Items { get; set; }

        public Invoice(string invoiceNumber, string customerName, DateTime issueDate, decimal totalAmount, string items)
        {
            InvoiceNumber = invoiceNumber;
            CustomerName = customerName;
            IssueDate = issueDate;
            TotalAmount = totalAmount;
            Items = items;
        }

        public IDocument Clone()
        {
            // Create a shallow copy
            return (IDocument)this.MemberwiseClone();
        }

        public void Display()
        {
            Console.WriteLine($"Invoice Document:");
            Console.WriteLine($"  Invoice #: {InvoiceNumber}");
            Console.WriteLine($"  Customer: {CustomerName}");
            Console.WriteLine($"  Date: {IssueDate.ToShortDateString()}");
            Console.WriteLine($"  Total: ${TotalAmount}");
            Console.WriteLine($"  Items: {Items}");
        }

        public string GetDocumentType()
        {
            return "Invoice";
        }
    }
}
