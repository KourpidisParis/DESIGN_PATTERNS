namespace DesignPatterns.Behavioral.MementoPattern
{
    /// <summary>
    /// Memento - Stores the state of TextEditor
    /// </summary>
    public class TextEditorMemento
    {
        public string Content { get; private set; }

        public TextEditorMemento(string content)
        {
            Content = content;
        }
    }
}