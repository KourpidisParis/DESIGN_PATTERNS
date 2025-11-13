namespace DesignPatterns.Creational.BuilderPattern
{
    /// <summary>
    /// Concrete Builder - Builds a professional workstation for content creation
    /// </summary>
    public class WorkstationComputerBuilder : IComputerBuilder
    {
        private Computer _computer;

        public WorkstationComputerBuilder()
        {
            _computer = new Computer();
        }

        public void BuildCPU()
        {
            _computer.CPU = "AMD Ryzen 9 7950X (16 cores, 5.7 GHz)";
        }

        public void BuildRAM()
        {
            _computer.RAM = "128GB DDR5 5200MHz ECC";
        }

        public void BuildStorage()
        {
            _computer.Storage = "4TB NVMe SSD RAID 0";
        }

        public void BuildGPU()
        {
            _computer.GPU = "NVIDIA RTX A6000 48GB";
        }

        public void BuildMotherBoard()
        {
            _computer.MotherBoard = "ASUS Pro WS X670E-ACE";
        }

        public void BuildPowerSupply()
        {
            _computer.PowerSupply = "1200W 80+ Titanium";
        }

        public void BuildCase()
        {
            _computer.Case = "Fractal Design Define 7 XL";
        }

        public Computer GetComputer()
        {
            return _computer;
        }
    }
}
