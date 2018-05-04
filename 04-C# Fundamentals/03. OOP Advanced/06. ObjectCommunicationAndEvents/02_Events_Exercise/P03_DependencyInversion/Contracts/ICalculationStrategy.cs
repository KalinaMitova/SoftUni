namespace P03_DependencyInversion.Contracts
{
    public interface ICalculationStrategy
    {
        int Calculate(int firstOperand, int secondOperand);
    }
}
