namespace P03_DependencyInversion
{
    using Contracts;

    public class PrimitiveCalculator
    {
        private ICalculationStrategy calculationStrategy;

        public PrimitiveCalculator(ICalculationStrategy calculationStrategy)
        {
            this.calculationStrategy = calculationStrategy;
        }

        public void ChangeStrategy(ICalculationStrategy calculationStrategy)
        {
            this.calculationStrategy = calculationStrategy;
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            int result = calculationStrategy.Calculate(firstOperand, secondOperand);
            return result;
        }
    }
}
