# Singleton Pattern

## What is it?

The Singleton Pattern ensures that a class has only **ONE instance** and provides a global point of access to it. No matter how many times you request the instance, you always get the same object.

## The Main Idea

Sometimes you need exactly one object to coordinate actions across your entire application. For example:
- **ONE** database connection manager
- **ONE** logger writing to a log file
- **ONE** configuration object

The Singleton Pattern guarantees this "only one" rule.

## Real-World Analogy

Think about a company's **CEO**:
- There can only be ONE CEO at a time
- Everyone in the company accesses the SAME CEO
- If the CEO makes a decision, it affects everyone
- You don't create a new CEO every time you need to talk to management

That's a Singleton! One instance, accessible everywhere.

## How It Works

### The Three Key Elements

1. **Private constructor** - No one can create instances from outside
2. **Static instance** - The single instance stored inside the class
3. **Public accessor** - A way to get that single instance

### Basic Implementation

```csharp
public sealed class DatabaseConnection
{
    // 1. Store the single instance
    private static DatabaseConnection _instance;
    
    // 2. Private constructor - cannot be called from outside
    private DatabaseConnection()
    {
        Console.WriteLine("Instance created!");
    }
    
    // 3. Public accessor - the only way to get the instance
    public static DatabaseConnection Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DatabaseConnection();
            }
            return _instance;
        }
    }
}
```

### Thread-Safe Implementation

In multi-threaded applications, two threads might try to create the instance at the same time. We use locking to prevent this:

```csharp
public sealed class DatabaseConnection
{
    private static DatabaseConnection _instance;
    private static readonly object _lock = new object();
    
    private DatabaseConnection() { }
    
    public static DatabaseConnection Instance
    {
        get
        {
            // Double-check locking
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DatabaseConnection();
                    }
                }
            }
            return _instance;
        }
    }
}
```

### Modern C# Implementation (Lazy<T>)

The cleanest and safest way in modern C#:

```csharp
public sealed class AppConfiguration
{
    private static readonly Lazy<AppConfiguration> _instance = 
        new Lazy<AppConfiguration>(() => new AppConfiguration());
    
    private AppConfiguration() { }
    
    public static AppConfiguration Instance => _instance.Value;
}
```

`Lazy<T>` handles thread safety automatically and creates the instance only when first accessed.

## Using the Singleton

```csharp
// From anywhere in your code:
DatabaseConnection db1 = DatabaseConnection.Instance;
db1.Connect();

// From another file/class:
DatabaseConnection db2 = DatabaseConnection.Instance;
db2.ExecuteQuery("SELECT * FROM Users");

// db1 and db2 are the SAME object!
Console.WriteLine(db1 == db2);  // True
```

## Key Components

1. **Sealed class** - Prevents inheritance (optional but recommended)
2. **Private constructor** - Prevents external instantiation
3. **Static instance field** - Holds the single instance
4. **Public static property** - Provides global access

## Project Structure

```
SingletonPattern/
│
├── 📄 DatabaseConnection.cs     ← Singleton (thread-safe with lock)
├── 📄 Logger.cs                 ← Singleton (thread-safe with lock)
├── 📄 AppConfiguration.cs       ← Singleton (using Lazy<T>)
│
├── 📄 SingletonPattern.cs       ← Demo program
└── 📄 README.md                 ← This file
```

## When to Use

Use the Singleton Pattern when:
- You need exactly ONE instance of a class
- That instance must be accessible from anywhere
- The single instance should be created only when needed

### Classic Use Cases

- **Database connections** - One connection pool for the app
- **Logging** - One logger writing to one file
- **Configuration** - One config object for all settings
- **Cache** - One cache shared across the application
- **Thread pools** - One pool managing all threads

## Benefits

✅ **Controlled access** - Only one instance exists  
✅ **Reduced memory** - No duplicate objects  
✅ **Global access** - Available from anywhere  
✅ **Lazy initialization** - Created only when needed  

## Drawbacks (Be Careful!)

⚠️ **Global state** - Can make testing difficult  
⚠️ **Hidden dependencies** - Classes depend on the singleton implicitly  
⚠️ **Concurrency issues** - Must be thread-safe in multi-threaded apps  
⚠️ **Violates Single Responsibility** - The class manages itself AND its business logic  

## Singleton vs Static Class

You might wonder: "Why not just use a static class?"

| Singleton | Static Class |
|-----------|--------------|
| Can implement interfaces | Cannot implement interfaces |
| Can be passed as a parameter | Cannot be passed |
| Can be lazy loaded | Loaded when app starts |
| Can have state | Only static state |
| Can be mocked for testing | Hard to mock |

**Use Singleton when:**
- You need an instance (for interfaces, parameters, etc.)
- You want lazy initialization
- You need to mock it in tests

**Use Static Class when:**
- You just need utility methods
- No state is needed
- You never need to mock it

## Thread Safety Explained

### Why Thread Safety Matters

Imagine two threads (A and B) both checking `_instance == null` at the same time:

```
Thread A: if (_instance == null) ← TRUE
Thread B: if (_instance == null) ← TRUE (they both see null!)
Thread A: _instance = new DatabaseConnection();
Thread B: _instance = new DatabaseConnection(); ← OOPS! Second instance!
```

Now you have TWO instances — the Singleton is broken!

### The Solution: Locking

```csharp
lock (_lock)
{
    if (_instance == null)
    {
        _instance = new DatabaseConnection();
    }
}
```

The `lock` ensures only one thread can enter at a time. Problem solved!

## Example Use Cases

- **Game engines** - One game manager controlling everything
- **Print spooler** - One spooler managing all print jobs
- **File manager** - One manager for file operations
- **Hardware access** - One object controlling a hardware device
- **State management** - One store for application state (like Redux)
