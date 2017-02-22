using System;

namespace _05_ChristmasHat
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int width = 4 * n + 1;
            int leftRight = (width - 3) / 2;

            Console.WriteLine(new string('.', leftRight) + "/|\\" + new string('.', leftRight));
            Console.WriteLine(new string('.', leftRight) + "\\|/" + new string('.', leftRight));

            for (int i = 0; i < n * 2; i++)
            {
                Console.WriteLine(new string('.', leftRight - i) + '*' + new string('-', i) + "*" + new string('-', i) + '*' + new string('.', leftRight - i));
            }

            Console.WriteLine(new string('*', width));

            for (int i = 0; i < width / 2; i++)
            {
                Console.Write("*.");
            }
            Console.WriteLine('*');
            Console.WriteLine(new string('*', width));
        }
    }
}