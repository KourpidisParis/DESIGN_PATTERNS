using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.MementoPattern
{
    /// <summary>
    /// Caretaker - Manages mementos (history of states)
    /// </summary>
    public class History
    {
        private Stack<TextEditorMemento> _mementos;

        public History()
        {
            _mementos = new Stack<TextEditorMemento>();
        }

        public void Save(TextEditorMemento memento)
        {
            _mementos.Push(memento);
            Console.WriteLine($"   💾 State saved to history (Total saves: {_mementos.Count})");
        }

        public TextEditorMemento Undo()
        {
            if (_mementos.Count > 0)
            {
                TextEditorMemento memento = _mementos.Pop();
                Console.WriteLine($"   ↩️  Undoing... (Remaining saves: {_mementos.Count})");
                return memento;
            }
            else
            {
                Console.WriteLine("   ⚠️  Nothing to undo!");
                return null;
            }
        }

        public int GetHistoryCount()
        {
            return _mementos.Count;
        }
    }
}