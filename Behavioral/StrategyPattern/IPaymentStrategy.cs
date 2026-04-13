namespace DesignPatterns.Behavioral.StrategyPattern
{
    /// <summary>
    /// Strategy Interface - Defines payment method
    /// </summary>
    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }
}