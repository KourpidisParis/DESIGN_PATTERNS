namespace DesignPatterns.Structural.DecoratorPattern
{
    /// <summary>
    /// Concrete Decorator - Adds sugar to coffee
    /// </summary>
    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee)
        {
        }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", Sugar";
        }

        public override decimal GetCost()
        {
            return _coffee.GetCost() + 0.25m;
        }
    }
}