namespace DesignPatterns.Behavioral.IteratorPattern
{
    /// <summary>
    /// Iterator Interface - Defines methods for traversing collection
    /// </summary>
    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
    }
}