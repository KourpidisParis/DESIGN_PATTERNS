# Observer Pattern

## What is it?

The Observer Pattern defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.

## The Main Idea

When one object (the subject) changes, it automatically notifies all other objects (observers) that depend on it, without the subject knowing who or what those observers are.

Think of it as:
- 🔔 **YouTube subscriptions** - Channel notifies all subscribers of new videos
- 📰 **News alerts** - News service notifies all subscribers of breaking news
- 📧 **Email newsletters** - Mailing list notifies all subscribers
- 📱 **Social media** - Post updates notify all followers

## Real-World Analogy

YouTube subscriptions work exactly like the Observer Pattern:

**The Channel (Subject):**
- Maintains a list of subscribers
- When new video is uploaded, notifies all subscribers
- Doesn't know who subscribers are or what they do with the notification

**The Subscribers (Observers):**
- Subscribe to channel (attach)
- Receive notification when new video uploaded (update)
- Can unsubscribe anytime (detach)

**The Flow:**

1. John, Alice, and Bob subscribe to TechTutorials channel
2. Channel uploads "Design Patterns Explained"
3. Channel notifies: John ✅, Alice ✅, Bob ✅
4. Alice unsubscribes
5. Channel uploads "SOLID Principles"
6. Channel notifies: John ✅, Bob ✅ (Alice not notified)

## How It Works

**The Components:**

**Subject Interface** - Defines `Attach()`, `Detach()`, `Notify()`

**Concrete Subject (YouTubeChannel)** - Maintains list of observers, notifies them when state changes

**Observer Interface** - Defines `Update()` method

**Concrete Observer (Subscriber)** - Implements update to receive notifications

**The Flow:**

1. Create YouTube channel (subject)
2. Create subscribers (observers)
3. Subscribers attach to channel
4. Channel uploads video (state change)
5. Channel calls Notify()
6. Each subscriber's Update() is called

## Structure
```
YouTubeChannel (Subject)
    ├── Subscribers List
    │       ├── John
    │       ├── Alice
    │       └── Bob
    │
    └── UploadVideo()
            ↓
        Notify() all subscribers
            ↓
        Each subscriber.Update()
```

## Project Structure
```
ObserverPattern/
│
├── 📄 IObserver.cs               ← Observer interface
├── 📄 ISubject.cs                ← Subject interface
│
├── 📄 YouTubeChannel.cs          ← Concrete subject
├── 📄 Subscriber.cs              ← Concrete observer
│
├── 📄 Observer.cs                ← Demo program
└── 📄 README.md                  ← This file
```

## When to Use

Use the Observer Pattern when:
- A change to one object requires changing others (and you don't know how many)
- An object should notify others without knowing who they are
- You need loose coupling between related objects
- You want to broadcast messages to multiple objects

## Benefits

✅ **Loose Coupling** - Subject and observers are loosely coupled  
✅ **Dynamic Relationships** - Add/remove observers at runtime  
✅ **Broadcast Communication** - One-to-many notification  
✅ **Open/Closed Principle** - Add observers without modifying subject  

## Drawbacks

⚠️ **Unexpected Updates** - Observers might get notified when they don't expect it  
⚠️ **Memory Leaks** - Observers not properly detached can cause leaks  
⚠️ **Performance** - Notifying many observers can be slow  

## Example Use Cases

- **Event handling systems** - GUI events (button clicks, etc.)
- **Model-View-Controller (MVC)** - Model notifies views of changes
- **Real-time data feeds** - Stock prices, sports scores
- **Social media** - Followers get notified of posts
- **Messaging systems** - Pub/sub architectures
- **Monitoring systems** - Alert subscribers when metrics change

## Observer vs Mediator

**Observer:**
- One-to-many relationship
- Subject broadcasts to all observers
- Observers don't communicate with each other

**Mediator:**
- Many-to-many relationship
- Objects communicate through mediator
- Centralized control of communication

## Note

In modern C#, you often use **Events** and **Delegates** instead of implementing Observer from scratch:
```csharp
public event EventHandler VideoUploaded;
```

But understanding the Observer Pattern helps you appreciate how events work!