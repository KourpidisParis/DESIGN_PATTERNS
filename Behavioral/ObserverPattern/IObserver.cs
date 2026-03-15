namespace DesignPatterns.Behavioral.ObserverPattern
{
    /// <summary>
    /// Observer Interface - Defines update method
    /// </summary>
    public interface IObserver
    {
        void Update(string videoTitle);
    }
}