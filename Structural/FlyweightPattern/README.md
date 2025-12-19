# Flyweight Pattern

## What is it?

The Flyweight Pattern reduces memory usage by sharing common data among multiple objects. Instead of each object storing all its data, flyweights share the common parts and only store what's unique.

## The Main Idea

When you have many similar objects, extract the shared data (intrinsic state) and store it once. Each object then references this shared data and only stores what makes it unique (extrinsic state).

Think of it as:
- 🌳 **Forest with trees** - Many trees share the same type (Oak, Pine) but have different positions
- 📝 **Text editor** - Many characters share the same font but have different positions
- 🎮 **Video game** - Many enemies share the same sprite but have different locations
- 🏗️ **Building blocks** - Many blocks share the same texture but are at different positions

## Real-World Analogy

Imagine a video game forest with 10,000 trees. Each tree has:

**Shared data (same for all Oak trees):**
- Tree type: "Oak"
- Color: "Green"
- Texture: Large image file
- 3D Model: Complex mesh data

**Unique data (different for each tree):**
- Position: (x, y)
- Height: 15m, 16m, 17m, etc.

**WITHOUT Flyweight:**
- 10,000 tree objects
- Each stores type, color, texture, model (HEAVY!)
- Total: 10,000 × (heavy data + position) = MASSIVE memory usage

**WITH Flyweight:**
- 1 Oak TreeType object (stores type, color, texture, model)
- 10,000 Tree objects (each only stores position and reference to Oak type)
- Total: 1 × (heavy data) + 10,000 × (position) = Much less memory!

## How It Works

### The Problem
```csharp
// Bad: Each tree stores everything
public class Tree
{
    private string name;       // "Oak" - repeated 3000 times!
    private string color;      // "Green" - repeated 3000 times!
    private string texture;    // Heavy data - repeated 3000 times!
    private int x;
    private int y;
    private int height;
}

// Memory usage: 10,000 trees × (all data) = HUGE!
```

### The Solution - Flyweight Pattern

**Flyweight (Shared Data):**
```csharp
public class TreeType
{
    // Intrinsic state (shared among all trees of this type)
    private string _name;
    private string _color;
    private string _texture;

    public void Display(int x, int y, int height)
    {
        // Extrinsic state passed as parameters
        Console.WriteLine($"{_name} at ({x}, {y}), height: {height}");
    }
}
```

**Context (Unique Data):**
```csharp
public class Tree
{
    // Extrinsic state (unique per tree)
    private int _x;
    private int _y;
    private int _height;
    
    // Reference to shared flyweight
    private TreeType _type;

    public void Display()
    {
        _type.Display(_x, _y, _height);
    }
}
```

**Flyweight Factory:**
```csharp
public class TreeFactory
{
    private Dictionary<string, TreeType> _treeTypes = new Dictionary<string, TreeType>();

    public TreeType GetTreeType(string name, string color, string texture)
    {
        string key = $"{name}_{color}_{texture}";
        
        if (!_treeTypes.ContainsKey(key))
        {
            _treeTypes[key] = new TreeType(name, color, texture);
        }
        
        return _treeTypes[key];  // Return shared instance
    }
}
```

**Using It:**
```csharp
Forest forest = new Forest();

// Plant 3000 Oak trees - only 1 TreeType object created!
for (int i = 0; i < 3000; i++)
{
    forest.PlantTree(i % 100, i / 100, 15, "Oak", "Green", "Rough");
}

// Plant 4000 Pine trees - only 1 more TreeType object created!
for (int i = 0; i < 4000; i++)
{
    forest.PlantTree(i % 100, i / 100, 20, "Pine", "Dark Green", "Needles");
}

// Result: 7000 trees, but only 2 TreeType objects!
```

## Structure
```
TreeFactory
    ├── Creates and manages TreeType objects (flyweights)
    └── Ensures they are shared
    
TreeType (Flyweight)
    └── Stores intrinsic state (name, color, texture)
    
Tree (Context)
    ├── Stores extrinsic state (x, y, height)
    └── References TreeType
    
Forest (Client)
    └── Creates many Trees that share TreeTypes
```

## Key Concepts

**Intrinsic State (Shared):**
- Data that's the same for many objects
- Stored in the flyweight
- Examples: type, color, texture, sprite image

**Extrinsic State (Unique):**
- Data that's unique to each object
- Stored outside the flyweight
- Passed to flyweight methods when needed
- Examples: position, size, rotation

## Project Structure
```
FlyweightPattern/
│
├── 📄 ITree.cs                  ← Flyweight interface
│
├── 📄 TreeType.cs               ← Concrete flyweight (intrinsic state)
├── 📄 TreeFactory.cs            ← Flyweight factory (manages sharing)
│
├── 📄 Tree.cs                   ← Context (extrinsic state)
├── 📄 Forest.cs                 ← Client (uses flyweights)
│
├── 📄 Flyweight.cs              ← Demo program
└── 📄 README.md                 ← This file
```

## When to Use

Use the Flyweight Pattern when:
- Your application uses a large number of similar objects
- Memory usage is a concern
- Most object state can be extracted and shared
- Object identity doesn't matter (you don't need unique instances)

## Benefits

✅ **Memory efficiency** - Drastically reduces memory usage  
✅ **Performance** - Fewer objects means less garbage collection  
✅ **Scalability** - Can handle millions of objects  
✅ **Centralized management** - Shared data in one place  

## Drawbacks

⚠️ **Complexity** - More complex code structure  
⚠️ **Runtime cost** - Need to compute/pass extrinsic state  
⚠️ **Thread safety** - Shared objects need careful handling in multi-threaded apps  

## Example Use Cases

- **Text editors** - Characters share font data, only position is unique
- **Game engines** - Sprites/models shared among many game objects
- **Web browsers** - DOM nodes share style information
- **Graphics systems** - Many shapes share color/texture data
- **Particle systems** - Thousands of particles share rendering data
- **String pools** - Programming languages share identical string objects

## Real-World Impact

**Example: Game with 100,000 trees**

WITHOUT Flyweight:
- 100,000 tree objects
- Each: 1KB (type data) + 12 bytes (position)
- Total: 100,000 × 1,012 bytes ≈ 96 MB

WITH Flyweight:
- 5 TreeType objects (Oak, Pine, Birch, Maple, Spruce)
- 100,000 Tree objects (position only)
- Total: (5 × 1KB) + (100,000 × 12 bytes) ≈ 1.2 MB

**Memory savings: 96 MB → 1.2 MB (98.75% reduction!)**