
namespace DesignPatterns.Behavioral.IteratorPattern
{
    /// <summary>
    /// Aggregate Interface - Defines method to create iterator
    /// </summary>
    public interface IAggregate<T>
    {
        IIterator<T> CreateIterator();
    }
}