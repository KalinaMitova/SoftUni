namespace P03_DependencyInversion.Strategies
{
    using P03_DependencyInversion.Contracts;

    public class SubtractionStrategy : ICalculationStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
