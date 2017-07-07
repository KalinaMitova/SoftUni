using System;

namespace _05_Diamond
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int length = 3 * n + 2;
            int leftRightDots = n;
            char element = '.';

            for (int i = 0; i < length; i++)
            {
                if (i == 0 || i == n || i == length - 1) element = '*';
                else element = '.';

                int mid = 5 * n - (leftRightDots * 2) - 2;

                Console.WriteLine(new string('.', leftRightDots) + '*' + new string(element, mid) + '*' + new string('.', leftRightDots));

                if (i >= n) leftRightDots++;
                else leftRightDots--;
            }
        }
    }
}
