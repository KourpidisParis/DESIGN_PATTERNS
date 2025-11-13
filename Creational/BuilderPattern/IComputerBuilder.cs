namespace DesignPatterns.Creational.BuilderPattern
{
    /// <summary>
    /// Builder interface - defines steps to build a Computer
    /// </summary>
    public interface IComputerBuilder
    {
        void BuildCPU();
        void BuildRAM();
        void BuildStorage();
        void BuildGPU();
        void BuildMotherBoard();
        void BuildPowerSupply();
        void BuildCase();
        Computer GetComputer();
    }
}
