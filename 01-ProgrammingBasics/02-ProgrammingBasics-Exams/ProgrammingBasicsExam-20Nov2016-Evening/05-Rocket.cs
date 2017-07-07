using System;

namespace _05_Rocket
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int length = n * 3;
            int leftRight = (length - 2) / 2;
            int middle = 0;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('.', leftRight) + '/' + new string(' ', middle) + '\\' + new string('.', leftRight));
                leftRight--;
                middle += 2;
            }

            leftRight++;
            Console.WriteLine(new string('.', leftRight) + new string('*', n * 2) + new string('.', leftRight));

            middle = n * 2 - 2;
            for (int i = 0; i < n * 2; i++)
            {
                Console.WriteLine(new string('.', leftRight) + '|' + new string('\\', middle) + '|' + new string('.', leftRight));
            }

            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine(new string('.', leftRight) + '/' + new string('*', middle) + '\\' + new string('.', leftRight));
                leftRight--;
                middle += 2;
            }
        }
    }
}
