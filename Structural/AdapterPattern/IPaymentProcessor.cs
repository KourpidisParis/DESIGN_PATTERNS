namespace DesignPatterns.Structural.AdapterPattern
{
    /// <summary>
    /// Target Interface - What our application expects
    /// Our app uses this standard interface for all payments
    /// </summary>
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount, string currency);
        bool ValidatePayment(string accountInfo);
        string GetPaymentStatus();
    }
}