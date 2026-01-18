namespace DesignPatterns.Behavioral.IteratorPattern
{
    /// <summary>
    /// Concrete Iterator - Iterates through book collection
    /// </summary>
    public class BookIterator : IIterator<Book>
    {
        private BookCollection _collection;
        private int _currentIndex;
        public BookIterator(BookCollection collection)
        {
            _collection = collection;
            _currentIndex = 0;
        }

        public bool HasNext()
        {
            return _currentIndex < _collection.Count;
        }

        public Book Next()
        {
           Book book = _collection.GetBookAt(_currentIndex);
           _currentIndex++;
           return book;
        }
    }
}