namespace DesignPatterns.Behavioral.ObserverPattern
{
    /// <summary>
    /// Subject Interface - Defines methods to manage observers
    /// </summary>
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }
}