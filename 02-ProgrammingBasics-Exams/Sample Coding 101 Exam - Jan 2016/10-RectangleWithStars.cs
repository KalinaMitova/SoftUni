using System;

namespace _10_RectangleWithStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int length = n * 2;

            if (n % 2 == 0) n--;

            Console.WriteLine(new string('%', length));
            for (int i = 0; i < n; i++)
            {
                if (i == n / 2)
                {
                    Console.WriteLine('%' + new string(' ', (length - 4) / 2) + "**" + new string(' ', (length - 4) / 2) + '%');
                }
                else
                {
                    Console.WriteLine('%' + new string(' ', length - 2) + '%');
                }
            }
            Console.WriteLine(new string('%', length));
        }
    }
}
