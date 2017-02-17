using System;

namespace _05_Butterfly
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int length = 2 * (n - 2) + 1;
            char starDash;
            string mid;

            for (int i = 0; i < length; i++)
            {
                if (i % 2 == 0) starDash = '*';
                else starDash = '-';

                if (i < length / 2) mid = "\\ /";
                else mid = "/ \\";

                if (i != length / 2) Console.WriteLine(new string(starDash, n - 2) + mid + new string(starDash, n - 2));
                else Console.WriteLine(new string(' ', n - 1) + '@' + new string(' ', n - 1));
            }
        }
    }
}
