using System;

namespace DesignPatterns.Behavioral.MementoPattern
{
    /// <summary>
    /// Originator - The object whose state needs to be saved and restored
    /// </summary>
    public class TextEditor
    {
        private string _content;

        public TextEditor()
        {
            _content = "";
        }

        public void Write(string text)
        {
            _content += text;
            Console.WriteLine($"✍️  Wrote: \"{text}\"");
            Console.WriteLine($"   Current content: \"{_content}\"");
        }

        public string GetContent()
        {
            return _content;
        }

        public void ShowContent()
        {
            Console.WriteLine($"📄 Current content: \"{_content}\"");
        }

        // Save current state
        public TextEditorMemento Save()
        {
            Console.WriteLine($"💾 Saving state: \"{_content}\"");
            return new TextEditorMemento(_content);
        }

        // Restore previous state
        public void Restore(TextEditorMemento memento)
        {
            _content = memento.Content;
            Console.WriteLine($"↩️  Restored to: \"{_content}\"");
        }
    }
}