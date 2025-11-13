namespace DesignPatterns.Creational.BuilderPattern
{
    /// <summary>
    /// Concrete Builder - Builds a budget-friendly office computer
    /// </summary>
    public class OfficeComputerBuilder : IComputerBuilder
    {
        private Computer _computer;

        public OfficeComputerBuilder()
        {
            _computer = new Computer();
        }

        public void BuildCPU()
        {
            _computer.CPU = "Intel Core i5-12400 (6 cores, 4.4 GHz)";
        }

        public void BuildRAM()
        {
            _computer.RAM = "16GB DDR4 3200MHz";
        }

        public void BuildStorage()
        {
            _computer.Storage = "512GB NVMe SSD";
        }

        public void BuildGPU()
        {
            _computer.GPU = "Integrated Graphics";
        }

        public void BuildMotherBoard()
        {
            _computer.MotherBoard = "MSI B660M PRO";
        }

        public void BuildPowerSupply()
        {
            _computer.PowerSupply = "450W 80+ Bronze";
        }

        public void BuildCase()
        {
            _computer.Case = "Standard Mid Tower";
        }

        public Computer GetComputer()
        {
            return _computer;
        }
    }
}
