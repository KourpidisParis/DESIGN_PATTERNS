# Builder Pattern

## What is it?

The Builder Pattern is a way to construct complex objects step by step. It lets you create different types and representations of an object using the same construction process.

## The Main Idea

Instead of having a massive constructor with many parameters, you build an object **piece by piece** using a builder class.

Think of it as:
- 🏗️ Building a house: foundation → walls → roof → interior
- 🖥️ Building a computer: CPU → RAM → Storage → GPU → etc.

Each builder knows how to construct a specific type of product, putting together all the parts in the right way.

## Real-World Analogy

Imagine ordering a custom burger at a restaurant:

**Without Builder Pattern:**
```
"I want a burger with lettuce, tomato, cheese, bacon, 
pickles, onions, mayo, mustard, and ketchup!"
```
One long, complex order that's hard to remember.

**With Builder Pattern:**
```
BurgerBuilder builder = new DeluxeBurgerBuilder();
builder.AddBun();
builder.AddPatty();
builder.AddCheese();
builder.AddLettuce();
builder.AddTomato();
builder.AddBacon();
Burger burger = builder.GetBurger();
```
Step by step construction that's clear and organized!

## How It Works

### Step 1: Define the Product
```csharp
public class Computer 
{
    public string CPU { get; set; }
    public string RAM { get; set; }
    public string Storage { get; set; }
    public string GPU { get; set; }
    // ... more properties
}
```

### Step 2: Define Builder Interface
```csharp
public interface IComputerBuilder 
{
    void BuildCPU();
    void BuildRAM();
    void BuildStorage();
    void BuildGPU();
    Computer GetComputer();
}
```

### Step 3: Create Concrete Builders
```csharp
public class GamingComputerBuilder : IComputerBuilder 
{
    private Computer _computer = new Computer();
    
    public void BuildCPU() 
    {
        _computer.CPU = "Intel i9-13900K";
    }
    
    public void BuildRAM() 
    {
        _computer.RAM = "64GB DDR5";
    }
    
    // ... implement other methods
    
    public Computer GetComputer() 
    {
        return _computer;
    }
}
```

### Step 4: Create Director (Optional)
```csharp
public class ComputerDirector 
{
    private IComputerBuilder _builder;
    
    public Computer BuildComputer() 
    {
        _builder.BuildCPU();
        _builder.BuildRAM();
        _builder.BuildStorage();
        _builder.BuildGPU();
        return _builder.GetComputer();
    }
}
```

### Step 5: Use it!
```csharp
// Create builder
IComputerBuilder builder = new GamingComputerBuilder();

// Create director
ComputerDirector director = new ComputerDirector(builder);

// Build the computer
Computer computer = director.BuildComputer();
```

## Key Components

1. **Product** (`Computer`) - The complex object being built
2. **Builder Interface** (`IComputerBuilder`) - Defines construction steps
3. **Concrete Builders** (`GamingComputerBuilder`, `OfficeComputerBuilder`) - Implement specific ways to build the product
4. **Director** (`ComputerDirector`) - Controls the building process (optional)

## The Pattern Structure

```
Product: Computer
    ↑ builds
    │
IComputerBuilder (interface)
    ↑ implements
    ├── GamingComputerBuilder → Builds gaming PC
    ├── OfficeComputerBuilder → Builds office PC
    └── WorkstationComputerBuilder → Builds workstation PC
    ↑ uses
    │
ComputerDirector (optional)
```

## Project Structure

```
BuilderPattern/
│
├── 📄 Computer.cs                      ← Product
│
├── 📄 IComputerBuilder.cs              ← Builder interface
│
├── 📄 GamingComputerBuilder.cs         ← Concrete builder
├── 📄 OfficeComputerBuilder.cs         ← Concrete builder
├── 📄 WorkstationComputerBuilder.cs    ← Concrete builder
│
├── 📄 ComputerDirector.cs              ← Director (optional)
│
├── 📄 BuilderPattern.cs                ← Demo program
└── 📄 README.md                        ← This file
```

## When to Use

Use the Builder Pattern when:
- Creating an object requires many steps
- You want to create different representations of the same product
- You want to isolate complex construction code from business logic
- The construction process must allow different representations

## Benefits

✅ **Step-by-step construction** - Build objects gradually  
✅ **Code reusability** - Use the same construction process for different products  
✅ **Isolation** - Construction code is separate from the product's business logic  
✅ **Control** - Better control over the construction process  

## Example Use Cases

- **Document builders:** PDF, HTML, Word documents
- **Query builders:** SQL, MongoDB queries
- **UI builders:** Form builders, dialog builders
- **Configuration builders:** App settings, connection strings
- **Test data builders:** Creating test objects with specific states
