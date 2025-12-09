namespace DesignPatterns.Structural.DecoratorPattern
{
    /// <summary>
    /// Concrete Decorator - Adds caramel to coffee
    /// </summary>
    public class CaramelDecorator : CoffeeDecorator
    {
        public CaramelDecorator(ICoffee coffee) : base(coffee)
        {
        }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", Caramel";
        }

        public override decimal GetCost()
        {
            return _coffee.GetCost() + 0.60m;
        }
    }
}