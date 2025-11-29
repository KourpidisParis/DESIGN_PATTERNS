# Adapter Pattern

## What is it?

The Adapter Pattern allows incompatible interfaces to work together. It acts as a bridge between two incompatible interfaces by wrapping one interface to make it compatible with another.

## The Main Idea

You have existing code that expects one interface, but you want to use a class with a different interface. The adapter converts one interface to another.

Think of it as:
- 🔌 **Power adapter** - Converts US plug to EU socket
- 💳 **Payment gateway adapter** - Makes different payment APIs work with your system
- 🔄 **API wrapper** - Adapts third-party APIs to your interface

## Real-World Analogy

Imagine you run an online store with a standard payment system that accepts payments through an interface you designed. Everything works great with PayPal because you built your system with PayPal in mind.

Now you want to add Stripe, but Stripe's API is completely different:
- Your system: `ProcessPayment(decimal amount, string currency)`
- Stripe: `MakePayment(int amountInCents, string currencyCode)`

The methods have different names, and Stripe uses cents while you use dollars!

You can't change Stripe's code (it's a third-party service), and you don't want to rewrite your entire checkout system. 

**Solution:** Create an adapter that translates between the two interfaces!

## How It Works

### The Problem

You have:
- **ShoppingCart** - Expects `IPaymentProcessor` interface
- **PayPalPayment** - Already implements `IPaymentProcessor` ✅
- **StripePaymentService** - Third-party API with different methods ❌

### The Solution - Adapter

Create `StripePaymentAdapter` that:
1. Implements `IPaymentProcessor` (what ShoppingCart expects)
2. Uses `StripePaymentService` internally
3. Translates between the two interfaces

**Example Translation:**
```csharp
// ShoppingCart calls:
ProcessPayment(150.50m, "USD")

// Adapter converts and calls Stripe:
MakePayment(15050, "USD")  // Converted dollars to cents!
```

### Structure
```
IPaymentProcessor (Target Interface)
    ↑ implements
    |
    ├── PayPalPayment (already compatible)
    └── StripePaymentAdapter ──uses──> StripePaymentService (incompatible)

ShoppingCart ──uses──> IPaymentProcessor
```

## Key Components

1. **Target Interface** (`IPaymentProcessor`) - What your application expects
2. **Client** (`ShoppingCart`) - Uses the Target interface
3. **Adaptee** (`StripePaymentService`) - The incompatible third-party class
4. **Adapter** (`StripePaymentAdapter`) - Converts Adaptee to Target interface

## Project Structure
```
AdapterPattern/
│
├── 📄 IPaymentProcessor.cs          ← Target interface
│
├── 📄 PayPalPayment.cs              ← Already compatible
├── 📄 StripePaymentService.cs       ← Third-party (incompatible)
│
├── 📄 StripePaymentAdapter.cs       ← The Adapter
│
├── 📄 ShoppingCart.cs               ← Client
│
├── 📄 Adapter.cs             ← Demo program
└── 📄 README.md                     ← This file
```

## When to Use

Use the Adapter Pattern when:
- You want to use a third-party library with a different interface
- You need to integrate legacy code with new code
- You can't modify the source code of the class you want to adapt
- You want to create a reusable class that works with unrelated classes

## Benefits

✅ **Single Responsibility** - Separates interface conversion from business logic  
✅ **Open/Closed Principle** - Add new adapters without changing existing code  
✅ **Flexibility** - Easily integrate different third-party services  
✅ **Reusability** - Use existing classes without modifying them  

## The Conversion in Action

### What Our System Expects (IPaymentProcessor):
```csharp
ProcessPayment(decimal amount, string currency)
ValidatePayment(string accountInfo)
GetPaymentStatus()
```

### What Stripe Provides (StripePaymentService):
```csharp
MakePayment(int amountInCents, string currencyCode)
AuthorizeCard(string cardToken)
GetTransactionState()
```

### What the Adapter Does (StripePaymentAdapter):
- Converts `decimal` dollars → `int` cents (150.50 → 15050)
- Translates `ProcessPayment` → `MakePayment`
- Translates `ValidatePayment` → `AuthorizeCard`
- Translates `GetPaymentStatus` → `GetTransactionState`

## Example Use Cases

- **Payment gateways** - Integrate PayPal, Stripe, Square, etc.
- **Database drivers** - Adapt different database APIs to a common interface
- **Cloud services** - Adapt AWS, Azure, GCP to a unified interface
- **Legacy system integration** - Make old systems work with new code
- **Third-party libraries** - Adapt external libraries to your interface