# Chain of Responsibility Pattern

## What is it?

The Chain of Responsibility Pattern passes a request along a chain of handlers. Each handler decides either to process the request or to pass it to the next handler in the chain.

## The Main Idea

Instead of hard-coding who handles a request, you create a chain of potential handlers. The request travels down the chain until someone handles it.

Think of it as:
- 📞 **Customer support escalation** - Level 1 → Level 2 → Level 3 → Management
- 🏥 **Medical triage** - Nurse → Doctor → Specialist → Surgeon
- 💰 **Expense approval** - Supervisor → Manager → Director → VP
- 🎓 **Grade appeal** - Teacher → Department Head → Dean → Provost

## Real-World Analogy

Imagine calling customer support with a technical problem:

**Level 1 Support:**
- Can you restart your computer? (Simple issues)
- If solved → Done!
- If not → Escalate to Level 2

**Level 2 Support:**
- Let me check your system logs... (Technical issues)
- If solved → Done!
- If not → Escalate to Level 3

**Level 3 Support:**
- This requires code investigation... (Complex issues)
- If solved → Done!
- If not → Escalate to Management

**Management:**
- We'll assign an engineer immediately! (Critical issues)
- Handles it regardless

This is the Chain of Responsibility Pattern! Each level tries to handle it, or passes it up.

## How It Works

### The Components

**Request Object:**
```csharp
public class SupportRequest
{
    public string CustomerName { get; set; }
    public string Issue { get; set; }
    public int Priority { get; set; } // 1=Low, 2=Medium, 3=High, 4=Critical
}
```

**Abstract Handler:**
```csharp
public abstract class SupportHandler
{
    protected SupportHandler _nextHandler;

    public void SetNext(SupportHandler nextHandler)
    {
        _nextHandler = nextHandler;
    }

    public abstract void HandleRequest(SupportRequest request);
}
```

**Concrete Handler:**
```csharp
public class Level1Support : SupportHandler
{
    public override void HandleRequest(SupportRequest request)
    {
        if (request.Priority == 1)
        {
            // Handle it
            Console.WriteLine("Level 1: Resolved!");
        }
        else if (_nextHandler != null)
        {
            // Pass to next
            _nextHandler.HandleRequest(request);
        }
    }
}
```

**Building the Chain:**
```csharp
SupportHandler level1 = new Level1Support();
SupportHandler level2 = new Level2Support();
SupportHandler level3 = new Level3Support();
SupportHandler management = new ManagementSupport();

// Build chain: Level1 → Level2 → Level3 → Management
level1.SetNext(level2);
level2.SetNext(level3);
level3.SetNext(management);

// Send request to chain
SupportRequest request = new SupportRequest("John", "Database crash", 4);
level1.HandleRequest(request); // Automatically escalates to management
```

## Structure
```
Client
    ↓ sends request
    
Handler1 (Level 1)
    ↓ can't handle, pass to next
    
Handler2 (Level 2)
    ↓ can't handle, pass to next
    
Handler3 (Level 3)
    ↓ can't handle, pass to next
    
Handler4 (Management)
    ✅ handles it
```

## Key Components

1. **Handler** - Interface/abstract class defining handling method
2. **Concrete Handlers** - Level1Support, Level2Support, etc.
3. **Request** - Object containing request information
4. **Client** - Sends request to first handler in chain

## Project Structure
```
ChainOfResponsibilityPattern/
│
├── 📄 SupportRequest.cs              ← Request object
│
├── 📄 SupportHandler.cs              ← Abstract handler
│
├── 📄 Level1Support.cs               ← Concrete handler
├── 📄 Level2Support.cs               ← Concrete handler
├── 📄 Level3Support.cs               ← Concrete handler
├── 📄 ManagementSupport.cs           ← Concrete handler
│
├── 📄 ChainOfResponsibility.cs       ← Demo program
└── 📄 README.md                      ← This file
```

## When to Use

Use the Chain of Responsibility Pattern when:
- Multiple objects can handle a request, but handler isn't known in advance
- You want to issue a request without specifying the receiver
- Set of handlers should be specified dynamically
- You want to decouple sender from receiver

## Benefits

✅ **Reduced Coupling** - Sender doesn't know who handles the request  
✅ **Flexibility** - Add/remove handlers easily  
✅ **Single Responsibility** - Each handler does one thing  
✅ **Dynamic Chain** - Can modify chain at runtime  
✅ **Open/Closed Principle** - Add handlers without changing existing code  

## Drawbacks

⚠️ **No guarantee** - Request might not be handled  
⚠️ **Performance** - Request travels through chain (can be slow)  
⚠️ **Debugging** - Hard to trace which handler processed request  

## Example Use Cases

- **Logging systems** - Debug → Info → Warning → Error → Critical handlers
- **Authentication** - Token → Session → OAuth → Basic Auth
- **Validation** - Required → Format → Business Rules → Database
- **Event handling** - GUI event bubbling (click → button → panel → window)
- **Middleware** - Web request pipeline (auth → logging → routing → handler)
- **Exception handling** - Try different recovery strategies