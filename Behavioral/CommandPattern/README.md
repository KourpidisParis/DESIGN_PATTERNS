# Command Pattern

## What is it?

The Command Pattern encapsulates a request as an object, allowing you to parameterize clients with different requests, queue or log requests, and support undoable operations.

## The Main Idea

Instead of directly calling methods on objects, you wrap the request in a command object. This command object knows which object (receiver) to call and which method to execute.

Think of it as:
- 🎮 **Remote control** - Button sends command to device
- 🍔 **Restaurant order** - Waiter takes order (command) to chef
- ↩️ **Undo/Redo** - Commands can be reversed

## Real-World Analogy

A simple remote control with one button:

**Without Command Pattern:**
- Button directly controls the light
- Remote needs to know about Light class
- Hard to add undo functionality
- Can't queue or log actions

**With Command Pattern:**
- Button executes a command object
- Remote doesn't know about Light
- Command handles the action
- Easy to implement undo
- Can store commands for later

## How It Works

**The Flow:**
1. Client creates Light (receiver)
2. Client creates LightOnCommand (wraps the light)
3. Client gives command to RemoteControl
4. User presses button
5. RemoteControl executes command
6. Command calls light.TurnOn()

## Structure
```
Client
    ↓ creates
    
Command (LightOnCommand, LightOffCommand)
    ↓ stored in
    
Invoker (RemoteControl)
    ↓ executes
    
Command.Execute()
    ↓ calls
    
Receiver (Light)
```

## Project Structure
```
CommandPattern/
│
├── 📄 ICommand.cs                ← Command interface
├── 📄 Light.cs                   ← Receiver
├── 📄 LightOnCommand.cs          ← Concrete command
├── 📄 LightOffCommand.cs         ← Concrete command
├── 📄 RemoteControl.cs           ← Invoker
├── 📄 Command.cs                 ← Demo program
└── 📄 README.md                  ← This file
```

## When to Use

Use the Command Pattern when:
- You want to parameterize objects with operations
- You want to queue operations
- You want to implement undo/redo functionality
- You want to log changes
- You want to support transactional operations

## Benefits

✅ **Decoupling** - Invoker doesn't know about receivers  
✅ **Extensibility** - Easy to add new commands  
✅ **Undo/Redo** - Commands can reverse themselves  
✅ **Queueing** - Commands can be queued and executed later  
✅ **Logging** - Can log all commands  

## Drawbacks

⚠️ **More classes** - Need a class for each command  
⚠️ **Complexity** - Adds indirection  

## Example Use Cases

- **GUI buttons** - Each button is a command
- **Text editors** - Undo/redo functionality
- **Game development** - Player actions as commands
- **Database transactions** - Commands that can be rolled back
- **Job queues** - Background tasks
- **Macro recording** - Record and replay actions