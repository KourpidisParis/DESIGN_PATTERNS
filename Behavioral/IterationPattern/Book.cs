namespace DesignPatterns.Behavioral.IteratorPattern
{
    /// <summary>
    /// Book - Item to be stored in collection
    /// </summary>
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public override string ToString()
        {
            return $"'{Title}' by {Author} ({Year})";
        }
    }
}