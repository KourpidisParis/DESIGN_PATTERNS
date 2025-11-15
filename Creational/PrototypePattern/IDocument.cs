namespace DesignPatterns.Creational.PrototypePattern
{
    /// <summary>
    /// Prototype interface - defines the Clone method
    /// </summary>
    public interface IDocument
    {
        IDocument Clone();
        void Display();
        string GetDocumentType();
    }
}
