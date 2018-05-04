namespace P03_DependencyInversion
{
    using System;

    using P03_DependencyInversion.Contracts;
    using P03_DependencyInversion.Factories;
    using P03_DependencyInversion.Strategies;

    class Program
    {
        static void Main()
        {
            PrimitiveCalculator calculator = new PrimitiveCalculator(new AdditionStrategy());

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();

                string firstArgumen = tokens[0];

                if(firstArgumen == "mode")
                {
                    char @operator = tokens[1][0];

                    ICalculationStrategy strategy = StrategyFactory.CreateStrategy(@operator);

                    calculator.ChangeStrategy(strategy);
                }
                else
                {
                    int firstNumber = int.Parse(tokens[0]);
                    int secondNumber = int.Parse(tokens[1]);

                    int result = calculator.PerformCalculation(firstNumber, secondNumber);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
