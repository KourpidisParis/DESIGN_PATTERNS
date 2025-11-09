# Factory Method Pattern

## What is it?

The Factory Method Pattern is a way to create objects where you let **subclasses decide** which specific object to create.

Instead of creating objects directly with `new Car()` or `new Truck()`, you have **specialized factory classes** that handle the creation for you.

## The Main Idea

You have a **parent factory class** that says: "I can create vehicles"

Then you have **child factory classes** that say:
- 🚗 "I create Cars"
- 🏍️ "I create Motorcycles"  
- 🚚 "I create Trucks"

Each factory is specialized and knows exactly what to build.

## Real-World Analogy

Think about **restaurants**:

- There's a general concept of a "Restaurant" (abstract factory)
- But you have specialized restaurants:
  - 🍕 **Pizza Restaurant** - makes pizza
  - 🍣 **Sushi Restaurant** - makes sushi
  - 🌮 **Taco Restaurant** - makes tacos

Each restaurant (factory) is an expert at making **one specific thing**.

## How It Works

### Step 1: Define what all products can do
```csharp
public interface IVehicle 
{
    void Start();
    void Drive();
    void Stop();
}
```

### Step 2: Create concrete products
```csharp
public class Car : IVehicle { ... }
public class Motorcycle : IVehicle { ... }
public class Truck : IVehicle { ... }
```

### Step 3: Create an abstract factory (the parent)
```csharp
public abstract class VehicleFactory 
{
    // This is the Factory Method - subclasses will implement it
    public abstract IVehicle CreateVehicle();
}
```

### Step 4: Create concrete factories (the children)
```csharp
public class CarFactory : VehicleFactory 
{
    public override IVehicle CreateVehicle() 
    {
        return new Car();
    }
}

public class MotorcycleFactory : VehicleFactory 
{
    public override IVehicle CreateVehicle() 
    {
        return new Motorcycle();
    }
}

public class TruckFactory : VehicleFactory 
{
    public override IVehicle CreateVehicle() 
    {
        return new Truck();
    }
}
```

### Step 5: Use it!
```csharp
// Create a car using CarFactory
VehicleFactory carFactory = new CarFactory();
IVehicle car = carFactory.CreateVehicle();
car.Start();
car.Drive();

// Create a truck using TruckFactory
VehicleFactory truckFactory = new TruckFactory();
IVehicle truck = truckFactory.CreateVehicle();
truck.Start();
truck.Drive();
```

## Key Components

The pattern has these parts:

1. **Product Interface** (`IVehicle`) - Defines what all products can do
2. **Concrete Products** (`Car`, `Motorcycle`, `Truck`) - The actual objects being created
3. **Abstract Factory** (`VehicleFactory`) - Declares the factory method
4. **Concrete Factories** (`CarFactory`, `MotorcycleFactory`, `TruckFactory`) - Implement the factory method to create specific products

## The Pattern Structure

```
                    IVehicle (interface)
                        ↑
        ┌───────────────┼───────────────┐
        │               │               │
       Car         Motorcycle         Truck
        ↑               ↑               ↑
        │               │               │
    CarFactory   MotorcycleFactory  TruckFactory
        ↑               ↑               ↑
        └───────────────┼───────────────┘
                VehicleFactory (abstract)
```

## Project Structure

```
FactoryPattern/
│
├── 📄 IVehicle.cs              ← Product interface
│
├── 📄 Car.cs                   ← Concrete product
├── 📄 Motorcycle.cs            ← Concrete product
├── 📄 Truck.cs                 ← Concrete product
│
├── 📄 VehicleFactory.cs        ← Abstract factory (declares factory method)
│
├── 📄 CarFactory.cs            ← Concrete factory (creates Cars)
├── 📄 MotorcycleFactory.cs     ← Concrete factory (creates Motorcycles)
├── 📄 TruckFactory.cs          ← Concrete factory (creates Trucks)
│
├── 📄 FactoryPattern.cs        ← Demo program
└── 📄 README.md                ← This file
```

## Benefits

✅ **Flexibility** - Easy to add new vehicle types by creating new factories  
✅ **Single Responsibility** - Each factory has one job  
✅ **Open/Closed Principle** - Open for extension, closed for modification  
✅ **Loose Coupling** - Code depends on abstractions, not concrete classes  

## When to Use

Use the Factory Method Pattern when:
- You want to delegate object creation to subclasses
- You have multiple related types of objects to create
- You want to make your code extensible and maintainable
- You want to follow SOLID principles