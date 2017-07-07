using System;

namespace _05_Hourglass
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int widthHeight = (2 * n) + 1;
            int leftRighDots = 2;
            int emptySpaces = 0;

            Console.WriteLine(new string('*', widthHeight));
            Console.WriteLine(".*" + new string(' ', widthHeight - 4) + "*.");

            for (int i = 0; i < n - 2; i++)
            {
                Console.WriteLine(new string('.', leftRighDots) + '*' + new string('@', widthHeight - leftRighDots * 2 - 2) + '*' + new string('.', leftRighDots));
                leftRighDots++;
            }

            Console.WriteLine(new string('.', leftRighDots) + '*' + new string('.', leftRighDots));
            leftRighDots--;
            for (int i = 0; i < n - 2; i++)
            {
                Console.WriteLine(new string('.', leftRighDots) + '*' + new string(' ', emptySpaces) + '@' + new string(' ', emptySpaces) + '*' + new string('.', leftRighDots));
                leftRighDots--;
                emptySpaces++;
            }

            Console.WriteLine(".*" + new string('@', widthHeight - 4) + "*.");
            Console.WriteLine(new string('*', widthHeight));
        }
    }
}
