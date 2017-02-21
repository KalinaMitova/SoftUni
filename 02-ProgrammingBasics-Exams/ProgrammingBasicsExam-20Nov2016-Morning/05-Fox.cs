using System;

namespace _05_Fox
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int length = 2 * n + 3;
            int leftRight = 1;
            int middle = length - 4;
            int center = n;

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(new string('*', leftRight) + '\\' + new string('-', middle) + '/' + new string('*', leftRight));
                leftRight++;
                middle -= 2;                
            }

            for (int i = 1; i <= n/3; i++)
            {
                Console.WriteLine('|' + new string('*', (length - center - 4) / 2) + '\\' + new string('*', center) + '/' + new string('*', (length - center - 4) / 2) + '|');
                center -= 2;
            }

            leftRight = 1;
            middle = length - 4;
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(new string('-', leftRight) + '\\' + new string('*', middle) + '/' + new string('-', leftRight));
                leftRight++;
                middle -= 2;
            }
        }
    }
}
