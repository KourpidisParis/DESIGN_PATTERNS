# Mediator Pattern

## What is it?

The Mediator Pattern defines an object that encapsulates how a set of objects interact. It promotes loose coupling by keeping objects from referring to each other explicitly.

## The Main Idea

Instead of objects communicating directly with each other (creating a complex web of dependencies), they communicate through a mediator. The mediator coordinates all interactions.

Think of it as:
- 💬 **Chat room** - Users send messages to chat room, not to each other
- ✈️ **Air traffic control** - Planes communicate through tower, not directly
- 🏢 **Office receptionist** - Coordinates communication between departments
- 🎮 **Game coordinator** - Players interact through game server

## Real-World Analogy

Imagine 4 people in a group chat:

**Without Mediator:**
- Each person needs phone numbers of all 3 others
- To send a group message, call each person individually
- New person joins? Everyone exchanges phone numbers
- 4 people = 12 connections (everyone to everyone)
- Chaos!

**With Mediator (Chat Room):**
- Each person only knows the chat room
- Send message to chat room, it delivers to everyone
- New person joins? Just connect to chat room
- 4 people = 4 connections (everyone to chat room)
- Simple!

## How It Works

**The Setup:**

You have users who want to communicate. Instead of users knowing about each other, they only know about the chat room.

**The Components:**

**Mediator Interface** - Defines how colleagues communicate (`SendMessage`)

**Concrete Mediator (ChatRoom)** - Coordinates all communication between users

**Colleague (User)** - Sends and receives messages through the mediator

**The Flow:**

1. User calls `Send("Hello")`
2. User asks mediator to send message
3. Mediator receives message and sender info
4. Mediator sends message to all other users
5. Other users receive the message

## Structure
```
User (John)  ───────┐
                    │
User (Alice) ───────┼──→ ChatRoom (Mediator)
                    │         ↓
User (Bob)   ───────┤    Distributes messages
                    │         ↓
User (Sarah) ───────┘    To all users
```

All communication flows through the mediator.

## Project Structure
```
MediatorPattern/
│
├── 📄 IChatMediator.cs           ← Mediator interface
├── 📄 ChatRoom.cs                ← Concrete mediator
├── 📄 User.cs                    ← Colleague
│
├── 📄 Mediator.cs                ← Demo program
└── 📄 README.md                  ← This file
```

## When to Use

Use the Mediator Pattern when:
- A set of objects communicate in complex ways
- You want to reduce dependencies between objects
- You want to reuse objects without their coupled classes
- Communication logic is complex and centralized control would help

## Benefits

✅ **Reduced Coupling** - Objects don't reference each other directly  
✅ **Centralized Control** - All communication logic in one place  
✅ **Simplified Objects** - Colleagues become simpler  
✅ **Easy to Add Colleagues** - Just connect to mediator  
✅ **Reusability** - Objects can be reused in different contexts  

## Drawbacks

⚠️ **God Object** - Mediator can become too complex  
⚠️ **Single Point of Failure** - If mediator fails, all communication stops  

## Example Use Cases

- **Chat applications** - Chat rooms coordinate user messages
- **Air traffic control** - Tower coordinates all aircraft
- **GUI frameworks** - Dialog boxes coordinate widget interactions
- **Game servers** - Coordinate player actions in multiplayer games
- **Smart home systems** - Central hub coordinates device interactions
- **MVC frameworks** - Controller mediates between Model and View

## Complexity Comparison

**Without Mediator (4 users):**
```
Connections: n × (n-1) = 4 × 3 = 12 connections
Each user knows about 3 others
Complex dependency web
```

**With Mediator (4 users):**
```
Connections: n = 4 connections
Each user knows only about mediator
Simple star pattern
```

As users increase, mediator benefits grow exponentially!