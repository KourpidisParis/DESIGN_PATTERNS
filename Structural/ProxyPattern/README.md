# Proxy Pattern

## What is it?

The Proxy Pattern provides a surrogate or placeholder for another object to control access to it. The proxy acts as an intermediary between the client and the real object, adding an extra layer of control.

## The Main Idea

Instead of letting clients access an object directly, you put a proxy in front of it. The proxy has the same interface as the real object, so the client doesn't even know there's a proxy. The proxy can then control access, add security, log activity, or add other functionality.

Think of it as:
- 🔐 **Security guard** - Controls who enters a building
- 🏦 **Bank teller** - Interface to your bank account
- 🚪 **Doorman** - Controls access to an apartment building
- 🛂 **Border checkpoint** - Controls who crosses the border

## Real-World Analogy

Imagine a company office building with a security guard at the entrance:

**Without Proxy (No Security Guard):**
- Anyone can walk in
- No control over who enters
- No record of visitors
- Security risk!

**With Proxy (Security Guard):**
- Guard checks ID badges
- Only allows authorized people
- Blocks unauthorized visitors
- Keeps entry logs
- Can revoke access if needed

The security guard is a **proxy** - an intermediary that controls access to the building (the real object).

## Our Example: Office Internet Access

In our implementation, we create an **Internet Proxy** that blocks access to non-work-related websites, just like many companies do in their offices.

### The Problem

Without a proxy:
- Employees can access any website (Facebook, Netflix, gaming sites)
- Potential productivity loss
- Security risks from malicious sites
- No control over internet usage

### The Solution

With a proxy:
- Block access to banned sites (social media, streaming, gaming)
- Allow work-related sites (Google, GitHub, Stack Overflow)
- Easy to add/remove restrictions
- Could add logging and monitoring

## How It Works

**Subject Interface:**
```csharp
public interface IInternet
{
    void ConnectTo(string site);
}
```

**Real Subject (Actual Internet):**
```csharp
public class RealInternet : IInternet
{
    public void ConnectTo(string site)
    {
        Console.WriteLine($"✅ Connecting to {site}");
    }
}
```

**Proxy (Access Control):**
```csharp
public class ProxyInternet : IInternet
{
    private RealInternet _realInternet;
    private List<string> _bannedSites;

    public ProxyInternet()
    {
        _realInternet = new RealInternet();
        _bannedSites = new List<string>
        {
            "facebook.com",
            "youtube.com",
            "netflix.com"
        };
    }

    public void ConnectTo(string site)
    {
        if (_bannedSites.Contains(site.ToLower()))
        {
            Console.WriteLine($"❌ Access DENIED to {site}");
        }
        else
        {
            _realInternet.ConnectTo(site);
        }
    }
}
```

**Client Usage:**
```csharp
IInternet internet = new ProxyInternet();

internet.ConnectTo("google.com");      // ✅ Allowed
internet.ConnectTo("github.com");      // ✅ Allowed
internet.ConnectTo("facebook.com");    // ❌ Blocked!
internet.ConnectTo("netflix.com");     // ❌ Blocked!
```

## Structure
```
Client
    ↓ uses
    
IInternet (interface)
    ↑ implements
    |
    ├── RealInternet
    |       └── Actual internet connection
    |
    └── ProxyInternet
            ├── Checks banned sites list
            └── Delegates to RealInternet if allowed
```

## Key Components

1. **Subject Interface** (`IInternet`) - Common interface
2. **Real Subject** (`RealInternet`) - The actual internet connection
3. **Proxy** (`ProxyInternet`) - Controls access with banned sites list
4. **Client** - Uses IInternet, doesn't know about proxy

## Project Structure
```
ProxyPattern/
│
├── 📄 IInternet.cs               ← Subject interface
├── 📄 RealInternet.cs            ← Real subject
├── 📄 ProxyInternet.cs           ← Protection proxy
│
├── 📄 Proxy.cs                   ← Demo program
└── 📄 README.md                  ← This file
```

## When to Use

Use the Proxy Pattern when:
- You need to control access to an object
- You want to add security or permission checks
- You need to add logging or monitoring
- You want to delay object creation (lazy loading)
- You want to add caching or optimization

## Benefits

✅ **Security** - Control who can access what  
✅ **Flexibility** - Easy to add/remove restrictions  
✅ **Transparency** - Client doesn't know about the proxy  
✅ **Extensibility** - Can add logging, statistics, caching  
✅ **Single Responsibility** - Proxy handles access control  

## Drawbacks

⚠️ **Complexity** - Adds an extra layer  
⚠️ **Performance** - Slight overhead from checking permissions  
⚠️ **Maintenance** - Another class to maintain  

## Types of Proxies

While our example shows a **Protection Proxy**, there are other types:

### 1. Protection Proxy (Our Example)
Controls access based on rules or permissions.

### 2. Virtual Proxy
Delays creating expensive objects until needed (lazy loading).

### 3. Remote Proxy
Represents an object in a different location (network, server).

### 4. Caching Proxy
Caches results to avoid repeated expensive operations.

### 5. Logging Proxy
Logs all operations for auditing or debugging.

## Example Use Cases

- **Corporate networks** - Block social media, streaming sites
- **Parental controls** - Block inappropriate content for children
- **School networks** - Restrict access to educational sites only
- **Public WiFi** - Block malicious or bandwidth-heavy sites
- **Content filters** - Block sites by category (adult, gambling, etc.)
- **Bandwidth management** - Throttle or block heavy streaming sites