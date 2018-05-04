namespace P03_DependencyInversion.Strategies
{
    using P03_DependencyInversion.Contracts;

    public class AdditionStrategy : ICalculationStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}
