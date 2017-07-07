using System;

namespace _01___Excellent_Result
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());

            if (a >= 5.50d)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}