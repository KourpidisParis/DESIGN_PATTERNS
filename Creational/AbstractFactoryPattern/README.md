# Abstract Factory Pattern

## What is it?

The Abstract Factory Pattern provides a way to create **families of related objects** without specifying their concrete classes. It's like having different factories, where each factory produces a complete set of related products that work together.

## The Main Idea

Instead of creating individual objects one by one, you use a factory that creates **entire families** of related objects that are designed to work together.

Think of it as:
- 🏭 **Modern Furniture Factory** → Creates: Modern Chair + Modern Sofa + Modern Table
- 🏭 **Victorian Furniture Factory** → Creates: Victorian Chair + Victorian Sofa + Victorian Table

Each factory produces a **complete matching set** of furniture in a specific style.

## Real-World Analogy

Imagine you're furnishing a room:

**Without Abstract Factory:**
- You buy a modern chair from Store A
- You buy a Victorian sofa from Store B  
- You buy a minimalist table from Store C
- **Result:** Nothing matches! 😵

**With Abstract Factory:**
- You go to a **Modern Furniture Store** → Get matching modern chair, sofa, and table ✅
- OR you go to a **Victorian Furniture Store** → Get matching Victorian chair, sofa, and table ✅
- **Result:** Everything matches perfectly! 🎉

## How It Works

### Step 1: Define product interfaces
```csharp
public interface IChair { ... }
public interface ISofa { ... }
public interface ITable { ... }
```

### Step 2: Create concrete products for each family
```csharp
// Modern Family
public class ModernChair : IChair { ... }
public class ModernSofa : ISofa { ... }
public class ModernTable : ITable { ... }

// Victorian Family
public class VictorianChair : IChair { ... }
public class VictorianSofa : ISofa { ... }
public class VictorianTable : ITable { ... }
```

### Step 3: Define abstract factory interface
```csharp
public interface IFurnitureFactory 
{
    IChair CreateChair();
    ISofa CreateSofa();
    ITable CreateTable();
}
```

### Step 4: Create concrete factories for each family
```csharp
public class ModernFurnitureFactory : IFurnitureFactory 
{
    public IChair CreateChair() => new ModernChair();
    public ISofa CreateSofa() => new ModernSofa();
    public ITable CreateTable() => new ModernTable();
}

public class VictorianFurnitureFactory : IFurnitureFactory 
{
    public IChair CreateChair() => new VictorianChair();
    public ISofa CreateSofa() => new VictorianSofa();
    public ITable CreateTable() => new VictorianTable();
}
```

### Step 5: Use it!
```csharp
// Choose a factory (style)
IFurnitureFactory factory = new ModernFurnitureFactory();

// Create a complete matching set
IChair chair = factory.CreateChair();
ISofa sofa = factory.CreateSofa();
ITable table = factory.CreateTable();

// All furniture matches!
```

## Key Components

1. **Abstract Products** (`IChair`, `ISofa`, `ITable`) - Interfaces for each product type
2. **Concrete Products** (`ModernChair`, `VictorianSofa`, etc.) - Specific implementations
3. **Abstract Factory** (`IFurnitureFactory`) - Interface for creating product families
4. **Concrete Factories** (`ModernFurnitureFactory`, `VictorianFurnitureFactory`) - Create specific product families

## The Pattern Structure

```
IFurnitureFactory (interface)
├── ModernFurnitureFactory
│   ├── Creates: ModernChair
│   ├── Creates: ModernSofa
│   └── Creates: ModernTable
│
└── VictorianFurnitureFactory
    ├── Creates: VictorianChair
    ├── Creates: VictorianSofa
    └── Creates: VictorianTable
```

## Project Structure

```
AbstractFactoryPattern/
│
├── 📄 IChair.cs                        ← Product interface
├── 📄 ISofa.cs                         ← Product interface
├── 📄 ITable.cs                        ← Product interface
│
├── 📄 ModernChair.cs                   ← Concrete product (Modern family)
├── 📄 ModernSofa.cs                    ← Concrete product (Modern family)
├── 📄 ModernTable.cs                   ← Concrete product (Modern family)
│
├── 📄 VictorianChair.cs                ← Concrete product (Victorian family)
├── 📄 VictorianSofa.cs                 ← Concrete product (Victorian family)
├── 📄 VictorianTable.cs                ← Concrete product (Victorian family)
│
├── 📄 IFurnitureFactory.cs             ← Abstract factory interface
│
├── 📄 ModernFurnitureFactory.cs        ← Concrete factory (creates Modern family)
├── 📄 VictorianFurnitureFactory.cs     ← Concrete factory (creates Victorian family)
│
├── 📄 AbstractFactoryPattern.cs        ← Demo program
└── 📄 README.md                        ← This file
```

## Difference from Factory Method

| Factory Method | Abstract Factory |
|----------------|------------------|
| Creates **one** product | Creates **families** of products |
| Uses inheritance | Uses composition |
| Returns a single object | Returns multiple related objects |
| Example: CarFactory creates Car | Example: ModernFactory creates Chair + Sofa + Table |

## Benefits

✅ **Consistency** - All products from a factory are designed to work together  
✅ **Isolation** - Client code is isolated from concrete product classes  
✅ **Easy to swap** - Change the entire product family by changing one factory  
✅ **SOLID principles** - Follows Open/Closed Principle  

## When to Use

Use the Abstract Factory Pattern when:
- You need to create families of related products
- You want products to be consistent (all Modern or all Victorian)
- You want to provide a library of products and reveal only interfaces
- You want to switch between different product families easily

## Example Use Cases

- **UI Themes:** Windows/Mac/Linux UI components
- **Database Providers:** SQL Server/MySQL/PostgreSQL connections
- **Document Formats:** PDF/Word/HTML exporters
- **Game Platforms:** PC/Console/Mobile game assets
