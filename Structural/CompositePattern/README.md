# Composite Pattern

## What is it?

The Composite Pattern allows you to treat individual objects and groups of objects uniformly. It's used to represent tree structures where you want to treat single objects and compositions of objects the same way.

## The Main Idea

You have two types of objects:
- **Leaf objects** - Individual items (like files)
- **Composite objects** - Containers that hold other objects (like folders)

The pattern makes both types implement the same interface, so you can treat them identically.

Think of it as:
- 📁 **File system** - Files and folders
- 🏢 **Organization chart** - Employees and departments
- 🎨 **Graphics editor** - Shapes and groups of shapes
- 📋 **Menu system** - Menu items and submenus

## Real-World Analogy

Think about your computer's file system:

**Files** are individual items:
- Resume.pdf
- Photo.jpg
- Video.mp4

**Folders** can contain files OR other folders:
- Documents folder contains Resume.pdf and Notes.txt
- Downloads folder contains Documents folder and Pictures folder
- Root folder contains everything

You can perform the same operations on both:
- **Show details** - Works on files and folders
- **Get size** - Files return their size, folders return the sum of all contents
- **Delete** - Works on both (deleting a folder deletes everything inside)

The Composite Pattern lets you treat files and folders the same way!

## How It Works

### The Problem

Without the pattern, you'd need lots of type checking:
```csharp
if (item is File)
{
    File file = (File)item;
    file.ShowDetails();
}
else if (item is Folder)
{
    Folder folder = (Folder)item;
    // Show folder and all its contents
    // Need recursive logic here...
}
```

Messy and error-prone!

### The Solution - Composite Pattern

**Component Interface:**
```csharp
public interface IFileSystemComponent
{
    void ShowDetails();
    int GetSize();
}
```

**Leaf (File):**
```csharp
public class File : IFileSystemComponent
{
    private string _name;
    private int _size;

    public void ShowDetails()
    {
        Console.WriteLine($"File: {_name} ({_size} KB)");
    }

    public int GetSize()
    {
        return _size;
    }
}
```

**Composite (Folder):**
```csharp
public class Folder : IFileSystemComponent
{
    private string _name;
    private List<IFileSystemComponent> _components;

    public void Add(IFileSystemComponent component)
    {
        _components.Add(component);
    }

    public void ShowDetails()
    {
        Console.WriteLine($"Folder: {_name}");
        foreach (var component in _components)
        {
            component.ShowDetails();  // Recursive!
        }
    }

    public int GetSize()
    {
        int total = 0;
        foreach (var component in _components)
        {
            total += component.GetSize();  // Recursive!
        }
        return total;
    }
}
```

**Using It:**
```csharp
// Create files
File file1 = new File("Resume.pdf", 250);
File file2 = new File("Photo.jpg", 1500);

// Create folder and add files
Folder folder = new Folder("Documents");
folder.Add(file1);
folder.Add(file2);

// Treat them uniformly
folder.ShowDetails();  // Shows folder and all files inside
int size = folder.GetSize();  // Gets total size automatically
```

## Structure
```
IFileSystemComponent (interface)
    ├── File (Leaf - no children)
    └── Folder (Composite - can have children)
            ├── File
            ├── File
            └── Folder (nested)
                    ├── File
                    └── File
```

The key: Both File and Folder implement the same interface!

## Key Components

1. **Component Interface** (`IFileSystemComponent`) - Common interface for all objects
2. **Leaf** (`File`) - Individual objects with no children
3. **Composite** (`Folder`) - Objects that can contain other components
4. **Client** - Works with components through the interface

## Project Structure
```
CompositePattern/
│
├── 📄 IFileSystemComponent.cs    ← Component interface
│
├── 📄 File.cs                    ← Leaf (individual file)
├── 📄 Folder.cs                  ← Composite (can contain files/folders)
│
├── 📄 Composite.cs               ← Demo program
└── 📄 README.md                  ← This file
```

## When to Use

Use the Composite Pattern when:
- You have tree-like hierarchical structures
- You want to treat individual objects and groups uniformly
- You want clients to ignore the difference between compositions and individual objects
- You need to perform operations on entire trees

## Benefits

✅ **Simplicity** - Treat individual and composite objects the same way  
✅ **Flexibility** - Easy to add new component types  
✅ **Recursive operations** - Operations automatically work on entire trees  
✅ **Open/Closed Principle** - Add new components without changing existing code  

## Drawbacks

⚠️ **Overly general** - Can make it hard to restrict what components can be added  
⚠️ **Type safety** - Runtime checks might be needed for type-specific operations  

## Example Use Cases

- **File systems** - Files and folders (our example)
- **GUI frameworks** - UI components and containers (buttons in panels in windows)
- **Organization charts** - Employees and departments
- **Menu systems** - Menu items and submenus
- **Graphics editors** - Shapes and groups of shapes
- **Expression trees** - Mathematical expressions with operators and operands