using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_FibonacciNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            long fibonacci = Fibonacci(number);
            Console.WriteLine(fibonacci);
        }

        static long Fibonacci(int number)
        {
            long prevNum = 1;
            long currentNumber = 1;
            long fibonacci = 1;
            for (int i = 1; i < number; i++)
            {
                fibonacci = prevNum + currentNumber;
                prevNum = currentNumber;
                currentNumber = fibonacci;
            }
            return fibonacci;
        }
    }
}
