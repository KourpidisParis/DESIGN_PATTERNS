# Visitor Pattern

## What is it?

The Visitor Pattern represents an operation to be performed on elements of an object structure. It lets you define new operations without changing the classes of the elements on which it operates.

## The Main Idea

Instead of putting operation methods in the element classes, you create separate visitor classes for each operation. Elements accept visitors, and visitors perform operations on them.

Think of it as:
- 🛒 **Shopping cart** - Different visitors calculate price, tax, discount
- 📄 **Document** - Different visitors render, validate, export
- 📊 **Data structure** - Different visitors traverse, analyze, transform
- 🎨 **Graphics** - Different visitors draw, calculate bounds, export

## Real-World Analogy

Imagine a shopping cart with books and electronics:

**Without Visitor:**
- Each item class (Book, Electronics) has methods: getPrice(), getTax(), getDiscount()
- Adding a new operation? Modify all item classes
- Classes become bloated with all possible operations

**With Visitor:**
- Item classes only know how to accept visitors
- Create separate visitor for each operation: PriceVisitor, TaxVisitor, DiscountVisitor
- Adding new operation? Create new visitor class
- Item classes never change!

## How It Works

**The Components:**

**Element Interface** - Defines `Accept(visitor)` method

**Concrete Elements** - Call `visitor.Visit[Type](this)`

**Visitor Interface** - Defines `Visit[Type]()` for each element type

**Concrete Visitors** - Implement specific operations

**Object Structure** - Collection of elements

**The Flow:**
For each item in cart:

item.Accept(priceCalculator)

↓

Book.Accept(visitor)

↓

visitor.VisitBook(this)

↓

priceCalculator adds book price to total

## Structure
IShoppingItem

├── Book

│   └── Accept(visitor) → visitor.VisitBook(this)

│

└── Electronics

└── Accept(visitor) → visitor.VisitElectronics(this)
IShoppingVisitor

├── PriceCalculator

│   ├── VisitBook()

│   └── VisitElectronics()

│

├── TaxCalculator

│   ├── VisitBook()

│   └── VisitElectronics()

│

└── DiscountCalculator

├── VisitBook()

└── VisitElectronics()

## Project Structure
VisitorPattern/

│

├── 📄 IShoppingItem.cs           ← Element interface

├── 📄 Book.cs                    ← Concrete element

├── 📄 Electronics.cs             ← Concrete element

│

├── 📄 IShoppingVisitor.cs        ← Visitor interface

├── 📄 PriceCalculator.cs         ← Concrete visitor

├── 📄 TaxCalculator.cs           ← Concrete visitor

├── 📄 DiscountCalculator.cs      ← Concrete visitor

│

├── 📄 ShoppingCart.cs            ← Object structure

│

├── 📄 Visitor.cs                 ← Demo program

└── 📄 README.md                  ← This file

## When to Use

Use the Visitor Pattern when:
- You need to perform operations on complex object structures
- Many operations need to be performed on elements
- Element classes don't change often, but operations do
- You want to avoid polluting element classes with operations

## Benefits

✅ **Easy to Add Operations** - New operations as new visitor classes  
✅ **Separation of Concerns** - Operations separate from data  
✅ **Element Classes Stable** - Don't need to change when adding operations  
✅ **Open/Closed Principle** - Open for new operations, closed for modification  

## Drawbacks

⚠️ **Hard to Add Elements** - Adding new element types requires updating all visitors  
⚠️ **Complex** - More classes and indirection  
⚠️ **Encapsulation** - Visitors need access to element internals  

## Example Use Cases

- **Shopping carts** - Price calculator, tax calculator, discount calculator
- **Document processing** - Render, validate, export to different formats
- **Compilers** - Traverse AST: analyze, optimize, generate code
- **File systems** - Different operations: calculate size, search, compress
- **Data analysis** - Analyze, visualize, export data
- **Graph algorithms** - Traverse nodes: search, rank, filter

## Double Dispatch

The Visitor Pattern uses **double dispatch** (dynamic polymorphism twice):

1. `cart.Accept(visitor)` - Calls correct accept method based on cart type
2. `visitor.Visit[Type](item)` - Calls correct visit method based on item type

This allows the right operation to be called based on both the visitor type AND the element type!

## Example Flow
ShoppingCart cart = new ShoppingCart();

cart.AddItem(new Book("Clean Code", 45.00m));

cart.AddItem(new Electronics("Laptop", 1200.00m));
// Calculate prices

PriceCalculator priceCalc = new PriceCalculator();

cart.Accept(priceCalc);

Console.WriteLine($"Total: ${priceCalc.GetTotalPrice()}");  // $1245.00
// Calculate tax

TaxCalculator taxCalc = new TaxCalculator();

cart.Accept(taxCalc);

Console.WriteLine($"Tax: ${taxCalc.GetTotalTax()}");  // $120.00
// Calculate discount

DiscountCalculator discountCalc = new DiscountCalculator();

cart.Accept(discountCalc);

Console.WriteLine($"Discount: ${discountCalc.GetTotalDiscount()}");  // $182.25

## Visitor vs Iterator

**Iterator Pattern:**
- Traverses elements one at a time
- Provides access to elements
- Focus: How to access elements

**Visitor Pattern:**
- Performs operations on elements
- Different operations without modifying elements
- Focus: What to do with elements

## Visitor vs Strategy

**Strategy Pattern:**
- Choose one algorithm at runtime
- Focus: Different algorithms for one concept
- Example: Choose payment method

**Visitor Pattern:**
- Perform different operations on multiple element types
- Focus: Different operations on same structure
- Example: Calculate price, tax, discount on items

## Without Visitor Pattern

```csharp
public class Book
{
    public decimal GetPrice() { return Price; }
    public decimal GetTax() { return 0; } // Books are tax-free
    public decimal GetDiscount() { return Price * 0.05m; }
    public decimal GetRewards() { ... } // New operation
    public void Export() { ... } // Another new operation
    // Every new operation requires modifying this class!
}

public class Electronics
{
    public decimal GetPrice() { return Price; }
    public decimal GetTax() { return Price * 0.1m; }
    public decimal GetDiscount() { return Price * 0.15m; }
    public decimal GetRewards() { ... } // Must implement too
    public void Export() { ... } // Must implement too
    // Classes become bloated!
}
```

## With Visitor Pattern

```csharp
public class Book : IShoppingItem
{
    public void Accept(IShoppingVisitor visitor)
    {
        visitor.VisitBook(this);  // That's it!
    }
}

public class PriceCalculator : IShoppingVisitor
{
    public void VisitBook(Book book) { ... }
    public void VisitElectronics(Electronics electronics) { ... }
}

public class TaxCalculator : IShoppingVisitor
{
    public void VisitBook(Book book) { ... }
    public void VisitElectronics(Electronics electronics) { ... }
}

// Add new operation? Just create a new visitor!
public class RewardsCalculator : IShoppingVisitor
{
    public void VisitBook(Book book) { ... }
    public void VisitElectronics(Electronics electronics) { ... }
}
```

Much cleaner and easier to extend!

## Key Points

1. **Separation of Concerns** - Operations are separate from elements
2. **Easy to Add Operations** - Just create a new visitor
3. **Hard to Add Elements** - Must update all visitors
4. **Double Dispatch** - Right method called based on both types
5. **Encapsulation Trade-off** - Visitors need access to element data
