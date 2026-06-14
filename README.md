# Design Patterns

A personal reference and learning project implementing all 23 **Gang of Four** design patterns in C# (.NET 9). Each pattern has a working demo you can run and a README explaining how it works.

## How to use

```bash
# Run a pattern demo
dotnet run <pattern-name>

# List all patterns
dotnet run list
```

## Patterns

### Creational — how objects are created

| Command | Pattern | Demo scenario |
|---|---|---|
| `dotnet run factory` | Factory Method | Vehicle creation |
| `dotnet run abstract-factory` | Abstract Factory | Furniture families |
| `dotnet run builder` | Builder | Computer construction |
| `dotnet run prototype` | Prototype | Document cloning |
| `dotnet run singleton` | Singleton | Database connection |

### Structural — how objects are composed

| Command | Pattern | Demo scenario |
|---|---|---|
| `dotnet run adapter` | Adapter | Payment system |
| `dotnet run bridge` | Bridge | Messaging system |
| `dotnet run composite` | Composite | File system |
| `dotnet run decorator` | Decorator | Coffee customization |
| `dotnet run facade` | Facade | Home cinema |
| `dotnet run flyweight` | Flyweight | Forest rendering |
| `dotnet run proxy` | Proxy | Internet access |

### Behavioral — how objects communicate

| Command | Pattern | Demo scenario |
|---|---|---|
| `dotnet run chain-of-resp` | Chain of Responsibility | Support tickets |
| `dotnet run command` | Command | Smart light device |
| `dotnet run iterator` | Iterator | Book collection |
| `dotnet run mediator` | Mediator | Chat room |
| `dotnet run memento` | Memento | Text editor undo |
| `dotnet run observer` | Observer | YouTube notifications |
| `dotnet run state` | State | Vending machine |
| `dotnet run strategy` | Strategy | Payment methods |
| `dotnet run template` | Template Method | Beverage brewing |
| `dotnet run visitor` | Visitor | Shopping cart |

## Structure

Each pattern lives in its own folder:

```
<Category>/<PatternName>Pattern/
├── I<Something>.cs   ← interfaces
├── <Concrete>.cs     ← implementations
├── <Demo>.cs         ← Run() entry point
└── README.md         ← explanation, analogies, when to use
```

The per-pattern READMEs are the main reference — they explain the concept, show the class structure, compare with similar patterns, and show code examples.
