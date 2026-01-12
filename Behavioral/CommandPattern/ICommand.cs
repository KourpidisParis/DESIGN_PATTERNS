namespace DesignPatterns.Behavioral.CommandPattern
{
    /// <summary>
    /// Command Interface - Declares execution method
    /// </summary>
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}