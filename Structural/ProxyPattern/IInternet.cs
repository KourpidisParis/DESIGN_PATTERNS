namespace DesignPatterns.Structural.ProxyPattern
{
    /// <summary>
    /// Subject Interface - Common interface for Real and Proxy Internet
    /// </summary>
    public interface IInternet
    {
        void ConnectTo(string site);
    }
}