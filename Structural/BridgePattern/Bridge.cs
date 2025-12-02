using System;

namespace DesignPatterns.Structural.BridgePattern
{
    /// <summary>
    /// Demo class to showcase the Bridge Pattern
    /// </summary>
    public class Bridge
    {
        public static void Run()
        {
            Console.WriteLine("=== Bridge Pattern ===");
            Console.WriteLine("Separating abstraction (message type) from implementation (sending method)\n");

            try
            {
                // Create different senders (implementations)
                IMessageSender emailSender = new EmailSender();
                IMessageSender smsSender = new SmsSender();
                IMessageSender pushSender = new PushNotificationSender();

                // Scenario 1: Text message via Email
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("Scenario 1: Text Message via Email");
                Console.WriteLine("═══════════════════════════════════════");
                Message textEmail = new TextMessage(emailSender, "Your order has been shipped!");
                textEmail.Send("customer@email.com");

                // Scenario 2: Text message via SMS
                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("Scenario 2: Same Text Message via SMS");
                Console.WriteLine("═══════════════════════════════════════");
                Message textSms = new TextMessage(smsSender, "Your order has been shipped!");
                textSms.Send("+1-555-1234");

                // Scenario 3: Urgent message via Push Notification
                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("Scenario 3: Urgent Message via Push");
                Console.WriteLine("═══════════════════════════════════════");
                Message urgentPush = new UrgentMessage(pushSender, "Your payment failed! Update your card.");
                urgentPush.Send("device_token_12345");

                // Scenario 4: Urgent message via Email
                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("Scenario 4: Same Urgent Message via Email");
                Console.WriteLine("═══════════════════════════════════════");
                Message urgentEmail = new UrgentMessage(emailSender, "Your payment failed! Update your card.");
                urgentEmail.Send("customer@email.com");

                // Show the flexibility
                Console.WriteLine("\n\n=== Understanding the Bridge ===");
                Console.WriteLine("Abstraction Side (What):");
                Console.WriteLine("  - TextMessage");
                Console.WriteLine("  - UrgentMessage");
                Console.WriteLine("  - (Can add: ScheduledMessage, EncryptedMessage, etc.)");
                
                Console.WriteLine("\nImplementation Side (How):");
                Console.WriteLine("  - EmailSender");
                Console.WriteLine("  - SmsSender");
                Console.WriteLine("  - PushNotificationSender");
                Console.WriteLine("  - (Can add: SlackSender, TelegramSender, etc.)");

                Console.WriteLine("\n=== Key Points ===");
                Console.WriteLine("1. Message types (abstraction) and sending methods (implementation) are independent");
                Console.WriteLine("2. You can mix and match: any message type with any sender");
                Console.WriteLine("3. Add new message types WITHOUT changing senders");
                Console.WriteLine("4. Add new senders WITHOUT changing message types");
                Console.WriteLine("5. This avoids creating classes like: UrgentEmailMessage, TextSmsMessage, etc.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}