using System;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char symbol = '+';

            for (int row = 0; row < n; row++)
            {
                if (row == 0 || row == n - 1) symbol = '+';
                else symbol = '|';

                Console.Write(symbol);
                for (int col = 0; col < n - 2; col++)
                {
                    Console.Write(" -");
                }
                Console.Write(' ');
                Console.WriteLine(symbol);
            }
        }
    }
}