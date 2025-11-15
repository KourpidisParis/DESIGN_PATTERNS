using System;

namespace DesignPatterns.Creational.PrototypePattern
{
    /// <summary>
    /// Concrete Prototype - Report document
    /// </summary>
    public class Report : IDocument
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int Pages { get; set; }

        public Report(string title, string author, DateTime date, string content, int pages)
        {
            Title = title;
            Author = author;
            Date = date;
            Content = content;
            Pages = pages;
        }

        public IDocument Clone()
        {
            // Create a shallow copy
            return (IDocument)this.MemberwiseClone();
        }

        public void Display()
        {
            Console.WriteLine($"Report Document:");
            Console.WriteLine($"  Title: {Title}");
            Console.WriteLine($"  Author: {Author}");
            Console.WriteLine($"  Date: {Date.ToShortDateString()}");
            Console.WriteLine($"  Content: {Content}");
            Console.WriteLine($"  Pages: {Pages}");
        }

        public string GetDocumentType()
        {
            return "Report";
        }
    }
}
