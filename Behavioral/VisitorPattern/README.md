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

**Element Interface (IShoppingItem)** - Defines `Accept(visitor)` method

**Concrete Elements (Book, Electronics)** - Call `visitor.Visit[Type](this)`

**Visitor Interface (IShoppingVisitor)** - Defines `Visit[Type]()` for each element type

**Concrete Visitors** - Implement specific operations

**Object Structure (ShoppingCart)** - Collection of elements

**The Flow:**