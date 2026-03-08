# Memento Pattern

## What is it?

The Memento Pattern provides the ability to restore an object to its previous state without violating encapsulation. It's like creating a save point in a video game.

## The Main Idea

Capture an object's internal state and save it externally so you can restore the object to that state later, all without exposing the object's internal structure.

Think of it as:
- 💾 **Save game** - Save your progress and restore it later
- ↩️ **Undo in text editor** - Restore previous versions of text
- 📸 **Snapshot** - Take a picture of current state
- 🔄 **System restore** - Restore computer to previous state

## Real-World Analogy

Imagine writing a document:

**Without Memento:**
- You make changes but can't undo them
- To go back, you'd need to manually remember what was there before
- No way to experiment safely
- Mistakes are permanent

**With Memento:**
- Press Save before making changes (create memento)
- Make experimental changes
- Don't like it? Press Undo (restore memento)
- Can go back through multiple saves
- Safe to experiment!

## How It Works

**The Components:**

**Originator (TextEditor)** - The object whose state needs saving. Creates mementos and restores from them.

**Memento (TextEditorMemento)** - Stores the state snapshot. Immutable once created.

**Caretaker (History)** - Manages the collection of mementos. Doesn't know what's inside them.

**The Flow:**

1. User writes "Hello" in editor
2. Editor creates memento with "Hello"
3. History stores memento
4. User writes " World" → content is "Hello World"
5. Editor creates new memento with "Hello World"
6. History stores it
7. User presses Undo
8. History retrieves "Hello" memento
9. Editor restores to "Hello"

## Structure
```
TextEditor (Originator)
    ├── Creates → TextEditorMemento (Memento)
    └── Restores from → TextEditorMemento
    
History (Caretaker)
    └── Stores collection of → TextEditorMemento
```

## Project Structure
```
MementoPattern/
│
├── 📄 TextEditorMemento.cs       ← Memento (state snapshot)
├── 📄 TextEditor.cs              ← Originator (creates/restores)
├── 📄 History.cs                 ← Caretaker (manages mementos)
│
├── 📄 Memento.cs                 ← Demo program
└── 📄 README.md                  ← This file
```

## When to Use

Use the Memento Pattern when:
- You need to save and restore object state (undo/redo)
- Direct access to state would violate encapsulation
- You want to implement checkpoints or snapshots
- State needs to be preserved for rollback

## Benefits

✅ **Encapsulation** - Doesn't expose object's internal structure  
✅ **Simplicity** - Easy to implement undo/redo  
✅ **Isolation** - Originator and caretaker are separate  
✅ **State Preservation** - Save multiple states  

## Drawbacks

⚠️ **Memory Usage** - Each memento consumes memory  
⚠️ **Performance** - Creating mementos can be expensive for large objects  
⚠️ **Caretaker Overhead** - Managing many mementos can be complex  

## Example Use Cases

- **Text editors** - Undo/redo functionality
- **Graphics editors** - Restore to previous drawing states
- **Games** - Save/load game state, checkpoints
- **Database transactions** - Rollback to previous state
- **Form wizards** - Navigate back through steps
- **Configuration management** - Restore previous settings
- **Version control** - Snapshot file states

## Important Notes

**Memento is Immutable:**  
Once created, a memento's state cannot change. This ensures saved states remain consistent.

**Caretaker is Blind:**  
The caretaker (History) stores mementos but doesn't know or care what's inside them. This maintains encapsulation.

**Multiple Mementos:**  
You can save multiple states and navigate through them (undo multiple times, or even redo).