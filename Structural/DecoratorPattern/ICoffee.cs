namespace DesignPatterns.Structural.DecoratorPattern
{
    /// <summary>
    /// Component Interface - Defines what a coffee can do
    /// </summary>
    public interface ICoffee
    {
        string GetDescription();
        decimal GetCost();
    }
}