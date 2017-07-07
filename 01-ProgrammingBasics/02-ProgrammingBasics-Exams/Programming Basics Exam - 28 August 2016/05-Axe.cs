using System;

namespace _05_Axe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int length = 5 * n;
            char element = '-';

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('-', 3 * n) + '*' + new string('-', i) + '*' + new string('-', length - 2 - i - (3 * n)));
            }
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine(new string('*', 3 * n + 1) + new string('-', n - 1) + '*' + new string('-', n - 1));
            }
            for (int i = 0; i < n / 2; i++)
            {
                if (i == n / 2 - 1) element = '*';
                Console.WriteLine(new string('-', 3 * n - i) + '*' + new string(element, n - 1 + i * 2) + '*' + new string('-', n - 1 - i));
            }
        }
    }
}
