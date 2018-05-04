namespace P03_DependencyInversion.Factories
{
    using System;

    using P03_DependencyInversion.Contracts;
    using P03_DependencyInversion.Strategies;

    internal class StrategyFactory
    {
        internal static ICalculationStrategy CreateStrategy(char @operator)
        {
            switch (@operator)
            {
                case '+': return new AdditionStrategy();                    
                case '-': return new SubtractionStrategy();
                case '*': return new MultiplicationStrategy();
                case '/': return new DivisionStrategy();
                default: throw new ArgumentException($"Invalid operator!");
            }
        }
    }
}