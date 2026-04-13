using System;

namespace DesignPatterns.Behavioral.StrategyPattern
{
    /// <summary>
    /// Concrete Strategy - Cryptocurrency payment
    /// </summary>
    public class CryptoPayment : IPaymentStrategy
    {
        private string _walletAddress;

        public CryptoPayment(string walletAddress)
        {
            _walletAddress = walletAddress;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"₿ Paid ${amount:F2} using Cryptocurrency");
            Console.WriteLine($"   Wallet: {_walletAddress.Substring(0, 10)}...{_walletAddress.Substring(_walletAddress.Length - 4)}");
        }
    }
}