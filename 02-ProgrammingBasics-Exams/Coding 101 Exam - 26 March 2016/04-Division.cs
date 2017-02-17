using System;

namespace _04_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;

            for (int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());

                if (currentNum % 2 == 0) p1++;
                if (currentNum % 3 == 0) p2++;
                if (currentNum % 4 == 0) p3++;
            }

            Console.WriteLine("{0:F2}%", (p1 / n) * 100);
            Console.WriteLine("{0:F2}%", (p2 / n) * 100);
            Console.WriteLine("{0:F2}%", (p3 / n) * 100);
        }
    }
}
