using System;

namespace _10_Diamond
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftRight = (n - 1) / 2;
            int mid;
            int length = ((n + 1) / 2) * 2 - 1;

            for (int i = 0; i < length; i++)
            {
                mid = n - 2 * leftRight - 2;
                Console.Write(new string('-', leftRight));
                Console.Write('*');
                if (mid >= 0)
                {
                    Console.Write(new string('-', mid));
                    Console.Write('*');
                }
                Console.WriteLine(new string('-', leftRight));

                if (i >= length / 2)
                    leftRight++;
                else
                    leftRight--;
            }
        }
    }
}
