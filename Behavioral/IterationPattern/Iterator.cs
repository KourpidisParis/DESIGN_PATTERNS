using System;

namespace DesignPatterns.Behavioral.IteratorPattern
{
    /// <summary>
    /// Demo class to showcase the Iterator Pattern
    /// </summary>
    public class Iterator
    {
        public static void Run()
        {
            Console.WriteLine("=== Iterator Pattern ===");
            Console.WriteLine("Traversing a book collection\n");

            try
            {
                BookCollection library = new BookCollection();

                library.AddBook(new Book("1984", "George Orwell", 1949));
                library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", 1960));
                library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925));
                library.AddBook(new Book("Pride and Prejudice", "Jane Austen", 1813));
                library.AddBook(new Book("The Catcher in the Rye", "J.D. Salinger", 1951));

                Console.WriteLine($"Library has {library.Count} books\n");

                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Iterating through books:");
                Console.WriteLine("═══════════════════════════════════════\n");

                IIterator<Book> iterator = library.CreateIterator();

                int count = 1;
                while (iterator.HasNext())
                {
                    Book book = iterator.Next();
                    Console.WriteLine($"{count}. {book}");
                    count++;
                }

                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("Iterating again (new iterator):");
                Console.WriteLine("═══════════════════════════════════════\n");

                IIterator<Book> iterator2 = library.CreateIterator();
                
                while (iterator2.HasNext())
                {
                    Book book = iterator2.Next();
                    Console.WriteLine($"📚 {book}");
                }

                Console.WriteLine("\n\n=== Understanding the Iterator Pattern ===");
                Console.WriteLine("Components:");
                Console.WriteLine("  1. Iterator Interface - Defines HasNext() and Next()");
                Console.WriteLine("  2. Concrete Iterator - BookIterator (knows current position)");
                Console.WriteLine("  3. Aggregate Interface - Defines CreateIterator()");
                Console.WriteLine("  4. Concrete Aggregate - BookCollection (stores books)");
                Console.WriteLine("  5. Item - Book (the objects being iterated)");

                Console.WriteLine("\nHow it works:");
                Console.WriteLine("  1. Collection creates iterator");
                Console.WriteLine("  2. Iterator keeps track of current position");
                Console.WriteLine("  3. Client uses HasNext() and Next() to traverse");
                Console.WriteLine("  4. Collection's internal structure is hidden");

                Console.WriteLine("\n=== Key Points ===");
                Console.WriteLine("1. Client doesn't know how collection stores items");
                Console.WriteLine("2. Collection can change internal structure without affecting client");
                Console.WriteLine("3. Multiple iterators can traverse same collection");
                Console.WriteLine("4. Iterator maintains its own traversal state");
                Console.WriteLine("5. Follows Single Responsibility Principle");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}