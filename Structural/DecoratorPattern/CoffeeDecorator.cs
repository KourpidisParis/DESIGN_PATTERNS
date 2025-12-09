namespace DesignPatterns.Structural.DecoratorPattern
{
    /// <summary>
    /// Base Decorator - Wraps a coffee and delegates to it
    /// </summary>
    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee _coffee;

        public CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        public virtual string GetDescription()
        {
            return _coffee.GetDescription();
        }

        public virtual decimal GetCost()
        {
            return _coffee.GetCost();
        }
    }
}