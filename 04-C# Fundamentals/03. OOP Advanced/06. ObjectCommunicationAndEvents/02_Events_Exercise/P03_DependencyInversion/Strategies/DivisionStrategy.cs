namespace P03_DependencyInversion.Strategies
{
    using Contracts;

    class DivisionStrategy : ICalculationStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}
