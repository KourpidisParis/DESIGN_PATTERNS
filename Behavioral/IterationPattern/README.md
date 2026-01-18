# Iterator Pattern

## What is it?

The Iterator Pattern provides a way to access elements of a collection sequentially without exposing the underlying representation of the collection.

## The Main Idea

Instead of exposing the internal structure of a collection (array, list, tree), you provide an iterator that allows clients to traverse the collection one element at a time.

Think of it as:
- 📚 **Library catalog** - Browse books one by one without knowing shelf organization
- 📺 **TV channel surfing** - Go through channels without knowing broadcast details
- 📱 **Photo gallery** - Swipe through photos without knowing storage structure
- 🎵 **Playlist** - Navigate songs without knowing how they're stored

## Real-World Analogy

Imagine a library with thousands of books:

**Without Iterator:**
- You need to know how books are organized (by shelves, sections, Dewey Decimal System)
- If library reorganizes, your browsing method breaks
- Hard to browse different ways (by author, by year, by genre)

**With Iterator:**
- You get a catalog (iterator) to browse books
- You don't care how books are physically stored
- Library can reorganize anytime without affecting you
- Different iterators can browse different ways

## How It Works

**The Components:**

**Iterator Interface** - Defines `HasNext()` and `Next()` methods

**Concrete Iterator** - Implements iteration logic and tracks current position

**Aggregate Interface** - Defines `CreateIterator()` method

**Concrete Aggregate** - The collection that creates iterators

**Item** - The objects being stored and iterated

**The Flow:**

1. Client creates a collection (BookCollection)
2. Client adds items to collection
3. Client requests an iterator from collection
4. Client uses `HasNext()` to check if more items exist
5. Client uses `Next()` to get next item
6. Iterator tracks current position internally

## Structure
```
Client
    ↓ requests iterator from
    
BookCollection (Aggregate)
    ↓ creates
    
BookIterator (Iterator)
    ├── HasNext() - checks if more items exist
    └── Next() - returns next item and moves position
```

## Project Structure
```
IteratorPattern/
│
├── 📄 IIterator.cs               ← Iterator interface
├── 📄 IAggregate.cs              ← Aggregate interface
│
├── 📄 Book.cs                    ← Item being stored
├── 📄 BookCollection.cs          ← Concrete aggregate
├── 📄 BookIterator.cs            ← Concrete iterator
│
├── 📄 Iterator.cs                ← Demo program
└── 📄 README.md                  ← This file
```

## When to Use

Use the Iterator Pattern when:
- You want to access collection elements without exposing internal structure
- You want to support multiple simultaneous traversals
- You want to provide a uniform interface for traversing different collections
- You want to hide complex data structures from clients

## Benefits

✅ **Encapsulation** - Collection's internal structure is hidden  
✅ **Single Responsibility** - Collection and traversal are separate  
✅ **Multiple Iterators** - Can have several iterators on same collection  
✅ **Flexibility** - Change collection structure without affecting clients  
✅ **Uniform Interface** - Same way to traverse different collections  

## Drawbacks

⚠️ **Overhead** - Simple collections might not need iterator  
⚠️ **Less efficient** - Direct access might be faster  

## Example Use Cases

- **Collections framework** - Lists, sets, maps in C#, Java
- **File system** - Iterate through files and folders
- **Database results** - Iterate through query results
- **Tree traversal** - Pre-order, in-order, post-order iterators
- **Graph traversal** - BFS, DFS iterators
- **Composite patterns** - Iterate through hierarchical structures

## Note

C# already has built-in iterator support with `IEnumerable<T>` and `IEnumerator<T>`. This example shows the pattern concept. In real C# code, you'd typically use:
```csharp
foreach (var book in library)
{
    Console.WriteLine(book);
}
```

But understanding the Iterator Pattern helps you appreciate how `foreach` works under the hood!