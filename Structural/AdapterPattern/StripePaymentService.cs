using System;

namespace DesignPatterns.Structural.AdapterPattern
{
    /// <summary>
    /// Third-party Stripe API - Has different method names and parameters
    /// We can't change this - it's external
    /// </summary>
    public class StripePaymentService
    {
        public void MakePayment(int amountInCents, string currencyCode)
        {
            Console.WriteLine($"Stripe API: Charging {amountInCents} cents in {currencyCode}");
        }

        public bool AuthorizeCard(string cardToken)
        {
            Console.WriteLine($"Stripe API: Authorizing card token {cardToken}");
            return true;
        }

        public string GetTransactionState()
        {
            return "Success";
        }
    }
}