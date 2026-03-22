# State Pattern

## What is it?

The State Pattern allows an object to change its behavior when its internal state changes. The object appears to change its class.

## The Main Idea

Instead of using complex conditional statements (if/else, switch) to determine behavior based on state, you encapsulate each state's behavior in separate state classes.

Think of it as:
- 🎰 **Vending machine** - Different states: no coin, has coin, dispensing
- 🚦 **Traffic light** - Different states: red, yellow, green
- 📱 **Phone** - Different states: locked, unlocked, ringing
- 🎮 **Game character** - Different states: idle, walking, running, jumping

## Real-World Analogy

A vending machine behaves differently depending on its state:

**NoCoinState:**
- Insert coin → Machine accepts it, moves to HasCoinState
- Eject coin → "No coin to eject"
- Select product → "Please insert coin first"

**HasCoinState:**
- Insert coin → "Coin already inserted"
- Eject coin → Returns coin, moves to NoCoinState
- Select product → Accepts selection, moves to ProductSelectedState

**ProductSelectedState:**
- Insert coin → "Please wait"
- Eject coin → "Too late"
- Dispense → Gives product, moves to NoCoinState

Same actions (insert coin, eject coin, select product) produce different results depending on current state!

## How It Works

**The Components:**

**State Interface** - Defines methods for all possible actions

**Concrete States** - Implement state-specific behavior (NoCoinState, HasCoinState, ProductSelectedState)

**Context (VendingMachine)** - Maintains reference to current state and delegates actions to it

**The Flow:**
```
[NoCoinState]
    ↓ InsertCoin()
[HasCoinState]
    ↓ SelectProduct()
[ProductSelectedState]
    ↓ Dispense()
[NoCoinState] (back to start)
```

## Structure
```
VendingMachine (Context)
    ├── currentState → Points to one state object
    │
    └── States:
            ├── NoCoinState
            ├── HasCoinState
            └── ProductSelectedState
```

When action is called, context delegates to current state.

## Project Structure
```
StatePattern/
│
├── 📄 IState.cs                  ← State interface
│
├── 📄 NoCoinState.cs             ← Concrete state
├── 📄 HasCoinState.cs            ← Concrete state
├── 📄 ProductSelectedState.cs    ← Concrete state
│
├── 📄 VendingMachine.cs          ← Context
│
├── 📄 State.cs                   ← Demo program
└── 📄 README.md                  ← This file
```

## When to Use

Use the State Pattern when:
- Object behavior depends on its state
- You have complex conditional statements based on state
- State transitions are explicit and well-defined
- You want to localize state-specific behavior

## Benefits

✅ **Cleaner Code** - Eliminates complex conditionals  
✅ **Single Responsibility** - Each state handles its own behavior  
✅ **Open/Closed Principle** - Add new states without modifying existing ones  
✅ **Explicit State Transitions** - Clear state flow  
✅ **Easier Testing** - Test each state independently  

## Drawbacks

⚠️ **More Classes** - One class per state  
⚠️ **Complexity** - Overkill for simple state machines  

## Example Use Cases

- **Vending machines** - Different states for coin insertion, selection, dispensing
- **TCP connections** - Established, listening, closed states
- **Document workflow** - Draft, review, approved, published states
- **Media players** - Playing, paused, stopped states
- **Order processing** - Pending, confirmed, shipped, delivered states
- **Game AI** - Idle, patrol, chase, attack states

## State vs Strategy

Both patterns look similar but serve different purposes:

**State Pattern:**
- Context changes its state internally
- States know about each other (transitions)
- Behavior changes based on state

**Strategy Pattern:**
- Client chooses strategy
- Strategies are independent
- Different algorithms for same task

## Without State Pattern
```csharp
public void InsertCoin()
{
    if (state == "NoCoin")
    {
        // Accept coin
        state = "HasCoin";
    }
    else if (state == "HasCoin")
    {
        // Reject coin
    }
    else if (state == "ProductSelected")
    {
        // Reject coin
    }
}
```

Imagine this for every action! Complex and hard to maintain.

## With State Pattern
```csharp
public void InsertCoin()
{
    currentState.InsertCoin(this);
}
```

Each state handles it differently. Clean and maintainable!