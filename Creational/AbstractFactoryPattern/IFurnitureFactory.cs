namespace DesignPatterns.Creational.AbstractFactoryPattern
{
    /// <summary>
    /// Abstract Factory - declares methods for creating a family of products
    /// </summary>
    public interface IFurnitureFactory
    {
        IChair CreateChair();
        ISofa CreateSofa();
        ITable CreateTable();
    }
}
