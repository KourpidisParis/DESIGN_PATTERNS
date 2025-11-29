namespace DesignPatterns.Structural.AdapterPattern
{
    /// <summary>
    /// Adapter - Makes Stripe compatible with our IPaymentProcessor interface
    /// </summary>
    public class StripePaymentAdapter : IPaymentProcessor
    {
        private StripePaymentService _stripeService;

        public StripePaymentAdapter()
        {
            _stripeService = new StripePaymentService();
        }

        public void ProcessPayment(decimal amount, string currency)
        {
            // Convert decimal to cents (Stripe uses cents)
            int amountInCents = (int)(amount * 100);
            
            // Call Stripe's method with its expected format
            _stripeService.MakePayment(amountInCents, currency);
        }

        public bool ValidatePayment(string accountInfo)
        {
            // Stripe uses card tokens, not account info
            // We adapt our interface to Stripe's
            return _stripeService.AuthorizeCard(accountInfo);
        }

        public string GetPaymentStatus()
        {
            // Stripe calls it "TransactionState", we call it "PaymentStatus"
            return _stripeService.GetTransactionState();
        }
    }
}