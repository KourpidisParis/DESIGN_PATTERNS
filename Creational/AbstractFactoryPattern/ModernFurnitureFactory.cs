namespace DesignPatterns.Creational.AbstractFactoryPattern
{
    /// <summary>
    /// Concrete Factory - creates Modern furniture family
    /// </summary>
    public class ModernFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new ModernChair();
        }

        public ISofa CreateSofa()
        {
            return new ModernSofa();
        }

        public ITable CreateTable()
        {
            return new ModernTable();
        }
    }
}
