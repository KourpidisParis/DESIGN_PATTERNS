using System;

namespace DesignPatterns.Behavioral.MementoPattern
{
    /// <summary>
    /// Demo class to showcase the Memento Pattern
    /// </summary>
    public class Memento
    {
        public static void Run()
        {
            Console.WriteLine("=== Memento Pattern ===");
            Console.WriteLine("Text Editor with Undo Functionality\n");

            try
            {
                // Create text editor and history
                TextEditor editor = new TextEditor();
                History history = new History();

                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Writing and Saving States");
                Console.WriteLine("═══════════════════════════════════════\n");

                // Write and save states
                editor.Write("Hello");
                history.Save(editor.Save());

                Console.WriteLine();
                editor.Write(" World");
                history.Save(editor.Save());

                Console.WriteLine();
                editor.Write("!");
                history.Save(editor.Save());

                Console.WriteLine();
                editor.Write(" This is a test.");
                history.Save(editor.Save());

                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("Current State");
                Console.WriteLine("═══════════════════════════════════════");
                editor.ShowContent();
                Console.WriteLine($"History count: {history.GetHistoryCount()} saved states\n");

                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Testing Undo");
                Console.WriteLine("═══════════════════════════════════════\n");

                // Undo operations
                Console.WriteLine("--- Undo 1 ---");
                TextEditorMemento memento1 = history.Undo();
                if (memento1 != null)
                    editor.Restore(memento1);

                Console.WriteLine("\n--- Undo 2 ---");
                TextEditorMemento memento2 = history.Undo();
                if (memento2 != null)
                    editor.Restore(memento2);

                Console.WriteLine("\n--- Undo 3 ---");
                TextEditorMemento memento3 = history.Undo();
                if (memento3 != null)
                    editor.Restore(memento3);

                Console.WriteLine("\n--- Current state after undos ---");
                editor.ShowContent();

                Console.WriteLine("\n--- Undo 4 ---");
                TextEditorMemento memento4 = history.Undo();
                if (memento4 != null)
                    editor.Restore(memento4);

                Console.WriteLine("\n--- Try undo with empty history ---");
                TextEditorMemento memento5 = history.Undo();
                if (memento5 != null)
                    editor.Restore(memento5);

                Console.WriteLine("\n\n=== Understanding the Memento Pattern ===");
                Console.WriteLine("Components:");
                Console.WriteLine("  1. Originator (TextEditor) - Creates and restores mementos");
                Console.WriteLine("  2. Memento (TextEditorMemento) - Stores state snapshot");
                Console.WriteLine("  3. Caretaker (History) - Manages memento collection");

                Console.WriteLine("\nHow it works:");
                Console.WriteLine("  1. Editor creates memento with current state");
                Console.WriteLine("  2. History stores memento in stack");
                Console.WriteLine("  3. User requests undo");
                Console.WriteLine("  4. History retrieves last memento");
                Console.WriteLine("  5. Editor restores state from memento");

                Console.WriteLine("\n=== Key Points ===");
                Console.WriteLine("1. Saves and restores object state without violating encapsulation");
                Console.WriteLine("2. Memento is immutable (state can't be changed after creation)");
                Console.WriteLine("3. Caretaker doesn't know memento's internal structure");
                Console.WriteLine("4. Perfect for implementing undo/redo functionality");
                Console.WriteLine("5. Each save creates a snapshot of the state");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}