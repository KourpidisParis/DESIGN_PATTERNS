namespace DesignPatterns.Creational.BuilderPattern
{
    /// <summary>
    /// Director - Controls the building process
    /// </summary>
    public class ComputerDirector
    {
        private IComputerBuilder _builder;

        public ComputerDirector(IComputerBuilder builder)
        {
            _builder = builder;
        }

        public void ChangeBuilder(IComputerBuilder builder)
        {
            _builder = builder;
        }

        public Computer BuildComputer()
        {
            _builder.BuildCPU();
            _builder.BuildRAM();
            _builder.BuildStorage();
            _builder.BuildGPU();
            _builder.BuildMotherBoard();
            _builder.BuildPowerSupply();
            _builder.BuildCase();

            return _builder.GetComputer();
        }

        public Computer BuildMinimalComputer()
        {
            // Build only essential components
            _builder.BuildCPU();
            _builder.BuildRAM();
            _builder.BuildStorage();
            _builder.BuildMotherBoard();
            _builder.BuildPowerSupply();

            return _builder.GetComputer();
        }
    }
}
