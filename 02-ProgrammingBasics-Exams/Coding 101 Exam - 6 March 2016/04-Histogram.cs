using System;

namespace _04_Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double p1 = 0.0;
            double p2 = 0.0;
            double p3 = 0.0;
            double p4 = 0.0;
            double p5 = 0.0;

            for (int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());

                if (currentNum < 200) p1++;
                else if (currentNum >= 200 && currentNum < 400) p2++;
                else if (currentNum >= 400 && currentNum < 600) p3++;
                else if (currentNum >= 600 && currentNum < 800) p4++;
                else if (currentNum >= 800) p5++;
            }

            Console.WriteLine("{0:F2}%", (p1 / n) * 100);
            Console.WriteLine("{0:F2}%", (p2 / n) * 100);
            Console.WriteLine("{0:F2}%", (p3 / n) * 100);
            Console.WriteLine("{0:F2}%", (p4 / n) * 100);
            Console.WriteLine("{0:F2}%", (p5 / n) * 100);
        }
    }
}
