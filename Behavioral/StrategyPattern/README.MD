# Strategy Pattern

## What is it?

The Strategy Pattern defines a family of algorithms, encapsulates each one, and makes them interchangeable. It lets the algorithm vary independently from clients that use it.

## The Main Idea

Instead of implementing multiple algorithms directly in a class, you define separate strategy classes for each algorithm. The client can choose which strategy to use at runtime.

Think of it as:
- 💳 **Payment methods** - Credit card, PayPal, crypto
- 🚗 **Navigation routes** - Fastest, shortest, scenic
- 📦 **Shipping methods** - Standard, express, overnight
- 🗜️ **Compression algorithms** - ZIP, RAR, 7Z

## Real-World Analogy

Imagine shopping online and reaching checkout:

**Without Strategy:**
The shopping cart has if/else statements for every payment method:
if (paymentType == "CreditCard")
processCreditCard()
else if (paymentType == "PayPal")
processPayPal()
else if (paymentType == "Crypto")
processCrypto()

Adding a new payment method means modifying the cart code!

**With Strategy:**
Each payment method is a separate strategy. The cart just calls `strategy.Pay()` without knowing the details. Adding a new payment method? Create a new strategy class. No changes to the cart!

## How It Works

**The Components:**

**Strategy Interface** - Defines `Pay(amount)` method

**Concrete Strategies** - CreditCardPayment, PayPalPayment, CryptoPayment - each implements payment differently

**Context (ShoppingCart)** - Holds a reference to a strategy and delegates payment to it

**The Flow:**

1. Customer adds items to cart
2. Customer selects payment method (sets strategy)
3. Customer clicks checkout
4. Cart calls `strategy.Pay(totalAmount)`
5. Strategy processes payment in its own way

## Structure
ShoppingCart (Context)
↓ uses
IPaymentStrategy (Interface)
↑ implements
|
├── CreditCardPayment
├── PayPalPayment
└── CryptoPayment

Cart doesn't know which strategy it's using - it just calls the interface method.

## Project Structure
StrategyPattern/
│
├── 📄 IPaymentStrategy.cs        ← Strategy interface
│
├── 📄 CreditCardPayment.cs       ← Concrete strategy
├── 📄 PayPalPayment.cs           ← Concrete strategy
├── 📄 CryptoPayment.cs           ← Concrete strategy
│
├── 📄 ShoppingCart.cs            ← Context
│
├── 📄 Strategy.cs                ← Demo program
└── 📄 README.md                  ← This file

## When to Use

Use the Strategy Pattern when:
- You have multiple algorithms for a specific task
- You want to switch algorithms at runtime
- You want to avoid complex conditional statements
- You need different variants of an algorithm

## Benefits

✅ **Open/Closed Principle** - Add new strategies without changing context  
✅ **Runtime Flexibility** - Switch strategies dynamically  
✅ **Cleaner Code** - No complex conditionals  
✅ **Testability** - Test each strategy independently  
✅ **Encapsulation** - Algorithm details hidden in strategy classes  

## Drawbacks

⚠️ **More Objects** - Creates more classes  
⚠️ **Client Awareness** - Client must know about different strategies  

## Example Use Cases

- **Payment processing** - Credit card, PayPal, Apple Pay, Google Pay
- **Sorting algorithms** - Bubble sort, quick sort, merge sort
- **Compression** - ZIP, RAR, GZIP, BZIP2
- **Route planning** - Fastest route, shortest route, avoid tolls
- **Pricing strategies** - Regular price, discount, promotional, seasonal
- **File export** - PDF, CSV, Excel, JSON
- **Validation rules** - Email validation, phone validation, credit card validation

## Strategy vs State

Both patterns look similar but serve different purposes:

**Strategy Pattern:**
- Client chooses the strategy
- Strategies are independent
- Focus: Different algorithms for same task
- Example: Choose payment method

**State Pattern:**
- Object changes state internally
- States transition to each other
- Focus: Different behavior based on state
- Example: Vending machine states

## Without Strategy Pattern

```csharp
public void Checkout(string paymentType)
{
    if (paymentType == "CreditCard")
    {
        // Process credit card
        // 20 lines of code
    }
    else if (paymentType == "PayPal")
    {
        // Process PayPal
        // 15 lines of code
    }
    else if (paymentType == "Crypto")
    {
        // Process crypto
        // 25 lines of code
    }
    // Adding new method? Modify this method!
}
```

## With Strategy Pattern

```csharp
public void Checkout()
{
    _paymentStrategy.Pay(totalAmount);
    // Clean and simple!
    // Adding new method? Just create new strategy class!
}
```

Much cleaner and easier to maintain!