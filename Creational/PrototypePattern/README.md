# Prototype Pattern

## What is it?

The Prototype Pattern creates new objects by copying existing objects (prototypes) instead of creating them from scratch. It's like using a template or a photocopy machine — you have a master copy and make clones of it.

## The Main Idea

Instead of calling constructors and setting up objects repeatedly, you create one "prototype" object and then clone it whenever you need a new instance.

Think of it as:
- 📋 Using a template document and filling in the blanks
- 🖨️ Photocopying a form instead of writing it from scratch
- 🧬 Cloning - creating a copy of an existing object

## Real-World Analogy

Imagine you run a print shop:

**Without Prototype Pattern:**
Every time a customer wants a resume, you:
- Start with a blank page
- Add the header structure
- Add sections for experience, education, skills
- Format everything
- Repeat for every customer

**With Prototype Pattern:**
You create one perfect resume template, then:
- Photocopy the template
- Fill in the customer's specific details
- Done in seconds!

## How It Works

### Step 1: Define the Prototype Interface
```csharp
public interface IDocument 
{
    IDocument Clone();
    void Display();
}
```

### Step 2: Create Concrete Prototypes
```csharp
public class Resume : IDocument 
{
    public string Name { get; set; }
    public string Email { get; set; }
    // ... other properties

    public IDocument Clone() 
    {
        return (IDocument)this.MemberwiseClone();
    }
}
```

### Step 3: Clone Objects
```csharp
// Create a template
Resume template = new Resume("Your Name", "email@example.com", ...);

// Clone it
Resume johnResume = (Resume)template.Clone();
johnResume.Name = "John Doe";
johnResume.Email = "john@email.com";

// Clone again for another person
Resume janeResume = (Resume)template.Clone();
janeResume.Name = "Jane Smith";
janeResume.Email = "jane@email.com";
```

## Key Components

1. **Prototype Interface** (`IDocument`) - Declares the clone method
2. **Concrete Prototypes** (`Resume`, `Report`, `Invoice`) - Implement cloning
3. **Client** - Uses clones instead of creating new objects

## The Pattern Structure

```
IDocument (interface)
    ├── Clone() method
    │
    ├── Resume (implements Clone)
    ├── Report (implements Clone)
    └── Invoice (implements Clone)
```

## Project Structure

```
PrototypePattern/
│
├── 📄 IDocument.cs              ← Prototype interface
│
├── 📄 Resume.cs                 ← Concrete prototype
├── 📄 Report.cs                 ← Concrete prototype
├── 📄 Invoice.cs                ← Concrete prototype
│
├── 📄 DocumentManager.cs        ← Manages prototype templates
│
├── 📄 PrototypePattern.cs       ← Demo program
└── 📄 README.md                 ← This file
```

## When to Use

Use the Prototype Pattern when:
- Creating new objects is expensive or complex
- You want to avoid subclasses of object creators
- You need to create many similar objects with slight variations
- Objects have only a few different combinations of state

## Benefits

✅ **Performance** - Cloning is faster than creating from scratch  
✅ **Flexibility** - Add and remove prototypes at runtime  
✅ **Reduced Complexity** - No need for complex initialization code  
✅ **Avoid Subclassing** - Clone instead of creating factory hierarchies  

## Understanding Shallow Copy vs Deep Copy

This is an important concept when cloning objects!

### Shallow Copy (What We Use)

**Simple Explanation:**
Imagine photocopying a document that has a sticky note attached. A shallow copy copies the document BUT both copies share the same sticky note. If you change the sticky note on one copy, it changes on the other too!

**In Code:**
```csharp
public class Resume 
{
    public string Name { get; set; }      // Simple value
    public string Email { get; set; }     // Simple value
    
    public IDocument Clone() 
    {
        // MemberwiseClone creates a shallow copy
        return (IDocument)this.MemberwiseClone();
    }
}
```

**When it works perfectly:**
- Your object has only simple types (string, int, bool, etc.)
- Our Resume example: Name, Email, Phone are all strings
- Each clone gets its own copy of these values ✅

### Deep Copy (When You Need It)

**Simple Explanation:**
Going back to the photocopy analogy - a deep copy would photocopy BOTH the document AND the sticky note. Now each copy is completely independent!

**Example When Shallow Copy Fails:**
```csharp
public class Resume 
{
    public string Name { get; set; }
    public Address HomeAddress { get; set; }  // ⚠️ This is an OBJECT, not a simple value!
    
    public IDocument Clone() 
    {
        return (IDocument)this.MemberwiseClone();  // ❌ Problem!
    }
}

public class Address 
{
    public string Street { get; set; }
    public string City { get; set; }
}
```

**The Problem:**
```csharp
Resume original = new Resume();
original.Name = "John";
original.HomeAddress = new Address { Street = "123 Main St", City = "Boston" };

// Shallow clone
Resume clone = (Resume)original.Clone();
clone.Name = "Jane";  // ✅ This is OK - Jane has her own name
clone.HomeAddress.City = "New York";  // ❌ PROBLEM! This changes BOTH resumes!

// Now BOTH original and clone have address in "New York"!
// They're sharing the same Address object!
```

**The Solution - Deep Copy:**
```csharp
public class Resume 
{
    public string Name { get; set; }
    public Address HomeAddress { get; set; }
    
    public IDocument Clone() 
    {
        var clone = (Resume)this.MemberwiseClone();
        
        // Manually clone the Address object too!
        clone.HomeAddress = new Address 
        {
            Street = this.HomeAddress.Street,
            City = this.HomeAddress.City
        };
        
        return clone;
    }
}
```

**Now it works:**
```csharp
Resume original = new Resume();
original.Name = "John";
original.HomeAddress = new Address { Street = "123 Main St", City = "Boston" };

// Deep clone
Resume clone = (Resume)original.Clone();
clone.Name = "Jane";
clone.HomeAddress.City = "New York";  // ✅ Only clone's address changes!

// original still has "Boston", clone has "New York" - they're independent!
```

### Quick Decision Guide

**Use Shallow Copy when:**
- Your object contains only simple types (string, int, bool, DateTime, etc.)
- Example: Our Resume with Name, Email, Phone (all strings)

**Use Deep Copy when:**
- Your object contains other objects (references)
- Example: Resume with an Address object, or a list of Skills
- You need complete independence between original and clone

### In Our Example

We use **shallow copy** because our documents contain only simple types:
- Resume: Name, Email, Phone (strings)
- Report: Title, Author (strings), Date (DateTime), Pages (int)
- Invoice: InvoiceNumber, CustomerName (strings), Date (DateTime), Amount (decimal)

All of these are simple values, so shallow copy works perfectly! ✅

## Example Use Cases

- **Document templates** - Resume, invoice, report templates
- **Game objects** - Clone enemy units, weapons, items
- **Database records** - Copy record with modifications
- **Configuration objects** - Clone default configurations
- **UI components** - Clone widget configurations
