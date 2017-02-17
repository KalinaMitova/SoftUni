using System;

namespace _04_TriangleOfDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write('$');
                for (int j = 0; j < i; j++)
                {
                    Console.Write(" $");
                }
                Console.WriteLine();
            }
        }
    }
}
