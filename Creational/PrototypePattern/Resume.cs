using System;

namespace DesignPatterns.Creational.PrototypePattern
{
    /// <summary>
    /// Concrete Prototype - Resume document
    /// </summary>
    public class Resume : IDocument
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }

        public Resume(string name, string email, string phone, string experience, string education)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Experience = experience;
            Education = education;
        }

        public IDocument Clone()
        {
            // Create a shallow copy
            return (IDocument)this.MemberwiseClone();
        }

        public void Display()
        {
            Console.WriteLine($"Resume Document:");
            Console.WriteLine($"  Name: {Name}");
            Console.WriteLine($"  Email: {Email}");
            Console.WriteLine($"  Phone: {Phone}");
            Console.WriteLine($"  Experience: {Experience}");
            Console.WriteLine($"  Education: {Education}");
        }

        public string GetDocumentType()
        {
            return "Resume";
        }
    }
}
