namespace DesignPatterns.Structural.DecoratorPattern
{
    /// <summary>
    /// Concrete Decorator - Adds whipped cream to coffee
    /// </summary>
    public class WhippedCreamDecorator : CoffeeDecorator
    {
        public WhippedCreamDecorator(ICoffee coffee) : base(coffee)
        {
        }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", Whipped Cream";
        }

        public override decimal GetCost()
        {
            return _coffee.GetCost() + 0.75m;
        }
    }
}