using System;

namespace _05_Parallelepiped
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int width = n * 3 + 1;
            int height = 4 * n + 4;
            int length = 2 * n + 1;

            int rightDots = length;
            int leftDots = 0;

            Console.WriteLine('+' + new string('~', width - rightDots - 2) + '+' + new string('.', rightDots));
            rightDots--;

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine('|' + new string('.', leftDots) + '\\' + new string('~', width - rightDots - leftDots - 3) +'\\' + new string('.', rightDots));
                rightDots--;
                leftDots++;
            }

            leftDots--;
            rightDots++;

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(new string('.', rightDots) + '\\' + new string('.', leftDots) + '|' + new string('~', width - leftDots - rightDots - 3) + '|');
                rightDots++;
                leftDots--;
            }
            
            leftDots++;

            Console.WriteLine(new string('.', rightDots) + new string('.', leftDots) + '+' + new string('~', width - leftDots - rightDots - 2) + '+');
        }
    }
}
