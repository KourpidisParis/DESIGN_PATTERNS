namespace DesignPatterns.Structural.DecoratorPattern
{
    /// <summary>
    /// Concrete Component - Basic coffee without any extras
    /// </summary>
    public class SimpleCoffee : ICoffee
    {
        public string GetDescription()
        {
            return "Simple Coffee";
        }

        public decimal GetCost()
        {
            return 2.00m;
        }
    }
}