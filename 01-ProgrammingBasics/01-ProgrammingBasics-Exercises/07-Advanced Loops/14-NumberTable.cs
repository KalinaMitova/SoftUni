using System;

namespace _14_NumberTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    num = row + col + 1;
                    if (row + col + 1 > n) num = 2 * n - num;
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
