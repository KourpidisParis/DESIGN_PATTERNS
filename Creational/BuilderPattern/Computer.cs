using System;
using System.Text;

namespace DesignPatterns.Creational.BuilderPattern
{
    /// <summary>
    /// Product - The complex object being built
    /// </summary>
    public class Computer
    {
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public string GPU { get; set; }
        public string MotherBoard { get; set; }
        public string PowerSupply { get; set; }
        public string Case { get; set; }

        public void ShowSpecifications()
        {
            StringBuilder specs = new StringBuilder();
            specs.AppendLine("Computer Specifications:");
            specs.AppendLine($"  CPU: {CPU ?? "Not specified"}");
            specs.AppendLine($"  RAM: {RAM ?? "Not specified"}");
            specs.AppendLine($"  Storage: {Storage ?? "Not specified"}");
            specs.AppendLine($"  GPU: {GPU ?? "Not specified"}");
            specs.AppendLine($"  MotherBoard: {MotherBoard ?? "Not specified"}");
            specs.AppendLine($"  Power Supply: {PowerSupply ?? "Not specified"}");
            specs.AppendLine($"  Case: {Case ?? "Not specified"}");
            
            Console.WriteLine(specs.ToString());
        }
    }
}
