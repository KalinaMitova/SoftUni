using System;

namespace _06_IntervalOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            int minNumber = Math.Min(firstNumber, secondNumber);
            int maxNumber = Math.Max(firstNumber, secondNumber);

            for (int i = minNumber; i <= maxNumber; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
