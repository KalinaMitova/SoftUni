namespace _16_ComparingFloats
{
    using System;

    static class ComparingFloats
    {
        static void Main()
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double eps = 0.000001;
            double diff = Math.Max(firstNumber, secondNumber) - Math.Min(firstNumber, secondNumber);
            bool isEqual = diff < eps;
            Console.WriteLine(isEqual);    
        }
    }
}
