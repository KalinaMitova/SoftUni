using System;

namespace _12_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int fibonacci = 0;
            int f0 = 0;
            int f1 = 1;

            if (n == 0) fibonacci = 1;

            for (int i = 0; i < n; i++)
            {
                fibonacci = f0 + f1;
                f0 = f1;
                f1 = fibonacci;
            }
            Console.WriteLine(fibonacci);
        }
    }
}
