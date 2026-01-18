using System.Collections.Generic;

namespace DesignPatterns.Behavioral.IteratorPattern
{
    /// <summary>
    /// Concrete Aggregate - Collection of books
    /// </summary>
    public class BookCollection : IAggregate<Book>
    {
        private List<Book> _books;

        public BookCollection()
        {
            _books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public int Count => _books.Count;

        public Book GetBookAt(int index)
        {
            return _books[index];
        }

        public IIterator<Book> CreateIterator()
        {
            return new BookIterator(this);
        }
    }
}