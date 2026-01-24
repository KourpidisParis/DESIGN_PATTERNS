using System;

namespace DesignPatterns.Behavioral.MediatorPattern
{
    /// <summary>
    /// Demo class to showcase the Mediator Pattern
    /// </summary>
    public class Mediator
    {
        public static void Run()
        {
            Console.WriteLine("=== Mediator Pattern ===");
            Console.WriteLine("Chat Room Communication System\n");

            try
            {
                // Create mediator (chat room)
                IChatMediator chatRoom = new ChatRoom();

                // Create users
                User john = new User("John", chatRoom);
                User alice = new User("Alice", chatRoom);
                User bob = new User("Bob", chatRoom);
                User sarah = new User("Sarah", chatRoom);

                // Add users to chat room
                chatRoom.AddUser(john);
                chatRoom.AddUser(alice);
                chatRoom.AddUser(bob);
                chatRoom.AddUser(sarah);

                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("Users Sending Messages");
                Console.WriteLine("═══════════════════════════════════════");

                // Users send messages
                john.Send("Hello everyone!");
                
                alice.Send("Hi John! How are you?");
                
                bob.Send("Good morning all!");
                
                sarah.Send("Hey team, meeting at 3 PM today.");
                
                john.Send("Thanks Sarah, I'll be there!");

                Console.WriteLine("\n\n=== Understanding the Mediator Pattern ===");
                Console.WriteLine("WITHOUT Mediator:");
                Console.WriteLine("  - Each user needs to know about all other users");
                Console.WriteLine("  - Users directly call each other's methods");
                Console.WriteLine("  - Adding a new user means updating all existing users");
                Console.WriteLine("  - Complex web of dependencies (4 users = 12 connections!)");

                Console.WriteLine("\nWITH Mediator:");
                Console.WriteLine("  - Users only know about the chat room (mediator)");
                Console.WriteLine("  - Chat room handles all communication");
                Console.WriteLine("  - Adding new user only requires connecting to mediator");
                Console.WriteLine("  - Simple star pattern (4 users = 4 connections)");

                Console.WriteLine("\nComponents:");
                Console.WriteLine("  1. Mediator Interface (IChatMediator) - Defines communication");
                Console.WriteLine("  2. Concrete Mediator (ChatRoom) - Coordinates users");
                Console.WriteLine("  3. Colleague (User) - Communicates through mediator");

                Console.WriteLine("\n=== Key Points ===");
                Console.WriteLine("1. Users don't communicate directly with each other");
                Console.WriteLine("2. All communication goes through the chat room");
                Console.WriteLine("3. Reduces dependencies between users");
                Console.WriteLine("4. Easy to add new users or change communication logic");
                Console.WriteLine("5. Centralizes communication control");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}