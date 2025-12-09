namespace DesignPatterns.Structural.DecoratorPattern
{
    /// <summary>
    /// Concrete Decorator - Adds milk to coffee
    /// </summary>
    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee)
        {
        }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", Milk";
        }

        public override decimal GetCost()
        {
            return _coffee.GetCost() + 0.50m;
        }
    }
}