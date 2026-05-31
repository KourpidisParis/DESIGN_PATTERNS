# Template Method Pattern

## What is it?

The Template Method Pattern defines the skeleton of an algorithm in a base class but lets subclasses override specific steps without changing the algorithm's overall structure.

## The Main Idea

You have an algorithm with common steps and steps that vary. Instead of duplicating the algorithm in each subclass, you define the algorithm once in the base class and let subclasses implement only the varying parts.

Think of it as:
- ☕ **Beverage preparation** - Common: boil water, pour in cup. Different: brewing method, condiments
- 🍳 **Recipe** - Common: prep, cook, serve. Different: ingredients, cooking time, seasoning
- 🏗️ **Construction** - Common: design, build, inspect. Different: materials, techniques
- 📄 **Document processing** - Common: read, process, save. Different: file format, processing logic

## Real-World Analogy

Making different beverages follows the same basic steps:

1. **Boil water** (same for all)
2. **Brew** (different: coffee grounds vs tea bag)
3. **Pour into cup** (same for all)
4. **Add condiments** (different: milk+sugar vs lemon+honey)

Without Template Method, each beverage class would duplicate steps 1 and 3. With it, the base class defines the algorithm once, and subclasses only implement the varying parts.

## How It Works

**The Components:**

**Beverage (Abstract Class)** - Defines template method `Prepare()` that outlines the algorithm

**Common Methods** - `BoilWater()` and `PourInCup()` are implemented in base class (same for all)

**Abstract Methods** - `Brew()` and `AddCondiments()` are abstract (different for each beverage)

**Concrete Classes** - Coffee, Tea, HotChocolate implement the abstract methods

**The Flow:**