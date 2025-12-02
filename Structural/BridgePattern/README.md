# Bridge Pattern

## What is it?

The Bridge Pattern separates an abstraction from its implementation so that the two can vary independently. It creates a bridge between the "what" (abstraction) and the "how" (implementation).

## The Main Idea

Instead of binding an abstraction to its implementation, you create a bridge that allows them to work together while remaining independent. This means you can change one side without affecting the other.

Think of it as:
- 🌉 **Physical bridge** - Connects two sides that can change independently
- 🎮 **Game controller** - Works with different gaming platforms (PC, Xbox, PlayStation)
- 📱 **Remote control** - Controls different devices (TV, DVD, Audio System)

## Real-World Analogy

Imagine you have different types of messages (Text, Urgent, Scheduled) and different ways to send them (Email, SMS, Push Notification).

**Without Bridge Pattern (Bad):**
You'd need to create a class for every combination:
- TextEmailMessage
- TextSmsMessage
- TextPushMessage
- UrgentEmailMessage
- UrgentSmsMessage
- UrgentPushMessage
- ... and so on

With 3 message types × 3 sending methods = 9 classes! Add one more type or method = even more classes!

**With Bridge Pattern (Good):**
You separate them:
- Message types: TextMessage, UrgentMessage (abstraction)
- Sending methods: EmailSender, SmsSender, PushSender (implementation)

3 + 3 = 6 classes total, and you can mix and match any combination!

## How It Works

### The Problem

You have two dimensions that can vary:
- **What** to do (message type: text, urgent, scheduled)
- **How** to do it (sending method: email, SMS, push)

Combining them in one hierarchy creates an explosion of classes.

### The Solution - Bridge

Separate the two dimensions:

**Abstraction (What):**
```csharp
public abstract class Message
{
    protected IMessageSender _messageSender;  // The bridge!
    
    public abstract void Send(string recipient);
}

public class TextMessage : Message { ... }
public class UrgentMessage : Message { ... }
```

**Implementation (How):**
```csharp
public interface IMessageSender
{
    void SendMessage(string message, string recipient);
}

public class EmailSender : IMessageSender { ... }
public class SmsSender : IMessageSender { ... }
```

**Using the Bridge:**
```csharp
// Text message via Email
Message msg1 = new TextMessage(new EmailSender(), "Hello!");
msg1.Send("user@email.com");

// Same text message via SMS
Message msg2 = new TextMessage(new SmsSender(), "Hello!");
msg2.Send("+1-555-1234");

// Urgent message via Push
Message msg3 = new UrgentMessage(new PushSender(), "Emergency!");
msg3.Send("device_123");
```

## Structure
```
Message (Abstraction)
    ├── TextMessage
    └── UrgentMessage
    
    uses ↓ (bridge)
    
IMessageSender (Implementation)
    ├── EmailSender
    ├── SmsSender
    └── PushNotificationSender
```

The abstraction holds a reference to the implementation (the bridge), and delegates the actual work to it.

## Key Components

1. **Abstraction** (`Message`) - Defines the high-level interface
2. **Refined Abstractions** (`TextMessage`, `UrgentMessage`) - Extend the abstraction
3. **Implementation Interface** (`IMessageSender`) - Defines the low-level interface
4. **Concrete Implementations** (`EmailSender`, `SmsSender`, `PushSender`) - Implement the interface

## Project Structure
```
BridgePattern/
│
├── 📄 IMessageSender.cs              ← Implementation interface
│
├── 📄 EmailSender.cs                 ← Concrete implementation
├── 📄 SmsSender.cs                   ← Concrete implementation
├── 📄 PushNotificationSender.cs      ← Concrete implementation
│
├── 📄 Message.cs                     ← Abstraction
│
├── 📄 TextMessage.cs                 ← Refined abstraction
├── 📄 UrgentMessage.cs               ← Refined abstraction
│
├── 📄 Bridge.cs                      ← Demo program
└── 📄 README.md                      ← This file
```

## When to Use

Use the Bridge Pattern when:
- You want to avoid permanent binding between abstraction and implementation
- Both abstractions and implementations should be extensible by subclassing
- Changes in implementation shouldn't affect clients
- You have a proliferation of classes from coupled interface and implementations
- You want to share an implementation among multiple objects

## Benefits

✅ **Separation of Concerns** - What and how are independent  
✅ **Extensibility** - Add new abstractions or implementations easily  
✅ **Flexibility** - Mix and match any combination  
✅ **Reduced Class Count** - Avoid class explosion  
✅ **Open/Closed Principle** - Open for extension, closed for modification  

## Example Use Cases

- **GUI frameworks** - Separate UI components from platform-specific rendering
- **Database drivers** - Separate database operations from specific database implementations
- **Device drivers** - Separate device interface from platform-specific drivers
- **Payment systems** - Separate payment types from payment gateways
- **Logging systems** - Separate log levels/formats from log destinations