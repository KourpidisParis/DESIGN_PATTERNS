namespace DesignPatterns.Structural.CompositePattern
{
    /// <summary>
    /// Component Interface - Common interface for both files and folders
    /// </summary>
    public interface IFileSystemComponent
    {
        void ShowDetails();
        int GetSize();
    }
}