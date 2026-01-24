using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.MediatorPattern
{
    /// <summary>
    /// Concrete Mediator - Chat room that coordinates communication between users
    /// </summary>
    public class ChatRoom : IChatMediator
    {
        private List<User> _users;

        public ChatRoom()
        {
            _users = new List<User>();
        }

        public void AddUser(User user)
        {
            _users.Add(user);
            Console.WriteLine($"✅ {user.Name} joined the chat room");
        }

        public void SendMessage(string message, User sender)
        {
            Console.WriteLine($"\n💬 [{sender.Name}]: {message}");
            
            // Send message to all users except the sender
            foreach (var user in _users)
            {
                if (user != sender)
                {
                    user.Receive(message, sender);
                }
            }
        }
    }
}