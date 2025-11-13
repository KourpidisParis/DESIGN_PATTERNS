namespace DesignPatterns.Creational.BuilderPattern
{
    /// <summary>
    /// Concrete Builder - Builds a high-end gaming computer
    /// </summary>
    public class GamingComputerBuilder : IComputerBuilder
    {
        private Computer _computer;

        public GamingComputerBuilder()
        {
            _computer = new Computer();
        }

        public void BuildCPU()
        {
            _computer.CPU = "Intel Core i9-13900K (24 cores, 5.8 GHz)";
        }

        public void BuildRAM()
        {
            _computer.RAM = "64GB DDR5 6000MHz";
        }

        public void BuildStorage()
        {
            _computer.Storage = "2TB NVMe SSD + 4TB HDD";
        }

        public void BuildGPU()
        {
            _computer.GPU = "NVIDIA GeForce RTX 4090 24GB";
        }

        public void BuildMotherBoard()
        {
            _computer.MotherBoard = "ASUS ROG Maximus Z790 Hero";
        }

        public void BuildPowerSupply()
        {
            _computer.PowerSupply = "1000W 80+ Platinum";
        }

        public void BuildCase()
        {
            _computer.Case = "Corsair 5000D Airflow RGB";
        }

        public Computer GetComputer()
        {
            return _computer;
        }
    }
}
