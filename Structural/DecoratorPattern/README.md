# Decorator Pattern

## What is it?

The Decorator Pattern allows you to add new functionality to an object dynamically without changing its structure. It wraps the original object and adds new behavior while keeping the same interface.

## The Main Idea

Instead of creating subclasses for every possible combination of features, you wrap objects with decorators that add functionality one at a time.

Think of it as:
- ☕ **Coffee shop** - Start with basic coffee, add milk, sugar, whipped cream, etc.
- 🎁 **Gift wrapping** - Start with a gift, add wrapping paper, ribbon, card, etc.
- 🏠 **House renovation** - Start with basic house, add paint, furniture, decorations, etc.
- 📱 **Phone cases** - Start with phone, add case, screen protector, pop socket, etc.

## Video Tutorial

For a visual explanation of the Decorator Pattern, check out this excellent video:

[**📺 Decorator Pattern Explained - YouTube**](https://youtu.be/P-9fXUbQIYw?si=clAdJ-ZPZ2DfeUdS)

## Real-World Analogy

Imagine ordering coffee at a café:

**Without Decorator Pattern:**
You'd need separate classes for every combination:
- SimpleCoffee
- CoffeeWithMilk
- CoffeeWithSugar
- CoffeeWithMilkAndSugar
- CoffeeWithMilkAndSugarAndWhippedCream
- ... (hundreds of combinations!)

**With Decorator Pattern:**
You have:
- SimpleCoffee (base)
- MilkDecorator (adds milk to any coffee)
- SugarDecorator (adds sugar to any coffee)
- WhippedCreamDecorator (adds whipped cream to any coffee)

Then you build what you want:
```csharp
ICoffee coffee = new SimpleCoffee();           // Base: $2.00
coffee = new MilkDecorator(coffee);            // +$0.50 = $2.50
coffee = new SugarDecorator(coffee);           // +$0.25 = $2.75
coffee = new WhippedCreamDecorator(coffee);    // +$0.75 = $3.50
```

## How It Works

### The Components

**Component Interface:**
```csharp
public interface ICoffee
{
    string GetDescription();
    decimal GetCost();
}
```

**Concrete Component (Base Object):**
```csharp
public class SimpleCoffee : ICoffee
{
    public string GetDescription() => "Simple Coffee";
    public decimal GetCost() => 2.00m;
}
```

**Base Decorator:**
```csharp
public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _coffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public virtual string GetDescription()
    {
        return _coffee.GetDescription();
    }

    public virtual decimal GetCost()
    {
        return _coffee.GetCost();
    }
}
```

**Concrete Decorator:**
```csharp
public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return _coffee.GetDescription() + ", Milk";
    }

    public override decimal GetCost()
    {
        return _coffee.GetCost() + 0.50m;
    }
}
```

**Using It:**
```csharp
ICoffee coffee = new SimpleCoffee();
coffee = new MilkDecorator(coffee);
coffee = new SugarDecorator(coffee);

Console.WriteLine(coffee.GetDescription());  // "Simple Coffee, Milk, Sugar"
Console.WriteLine(coffee.GetCost());         // $2.75
```

## Structure
```
ICoffee (interface)
    ↑ implements
    |
    ├── SimpleCoffee (base object)
    |
    └── CoffeeDecorator (base decorator)
            ↑ extends
            |
            ├── MilkDecorator
            ├── SugarDecorator
            ├── WhippedCreamDecorator
            └── CaramelDecorator
```

Each decorator wraps an ICoffee and adds its own behavior.

## Key Components

1. **Component Interface** (`ICoffee`) - Common interface for all objects
2. **Concrete Component** (`SimpleCoffee`) - The base object being decorated
3. **Base Decorator** (`CoffeeDecorator`) - Wraps a component and delegates to it
4. **Concrete Decorators** (`MilkDecorator`, `SugarDecorator`, etc.) - Add specific functionality

## Project Structure
```
DecoratorPattern/
│
├── 📄 ICoffee.cs                    ← Component interface
│
├── 📄 SimpleCoffee.cs               ← Concrete component (base object)
│
├── 📄 CoffeeDecorator.cs            ← Base decorator
│
├── 📄 MilkDecorator.cs              ← Concrete decorator
├── 📄 SugarDecorator.cs             ← Concrete decorator
├── 📄 WhippedCreamDecorator.cs      ← Concrete decorator
├── 📄 CaramelDecorator.cs           ← Concrete decorator
│
├── 📄 Decorator.cs                  ← Demo program
└── 📄 README.md                     ← This file
```

## When to Use

Use the Decorator Pattern when:
- You need to add responsibilities to objects dynamically
- You want to add functionality without creating lots of subclasses
- You need to add/remove responsibilities at runtime
- Extension by subclassing is impractical (too many combinations)

## Benefits

✅ **Flexibility** - Add/remove responsibilities dynamically  
✅ **Single Responsibility** - Each decorator has one job  
✅ **Open/Closed Principle** - Add new decorators without changing existing code  
✅ **Composability** - Combine decorators in any order  
✅ **Avoids class explosion** - Don't need a class for every combination  

## Drawbacks

⚠️ **Complexity** - Many small objects can be hard to debug  
⚠️ **Order matters** - Different decorator orders can give different results  
⚠️ **Identity** - Decorated object is not identical to original  

## Example Use Cases

- **I/O Streams** - Java/C# streams use decorators (BufferedStream wraps FileStream)
- **GUI Components** - Add borders, scrollbars, shadows to UI elements
- **Text formatting** - Add bold, italic, underline to text
- **Logging** - Add timestamps, log levels, formatting to log messages
- **Caching** - Add caching behavior to data access objects
- **Authorization** - Add permission checks to operations