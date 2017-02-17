using System;

namespace _11_OddOrEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());

            double oddSum = 0.0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenSum = 0.0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenSum += num;
                    if (evenMin > num) evenMin = num;
                    if (evenMax < num) evenMax = num;
                }
                else
                {
                    oddSum += num;
                    if (oddMin > num) oddMin = num;
                    if (oddMax < num) oddMax = num;
                }
            }

            Console.WriteLine("OddSum={0}", oddSum);

            if (oddSum == 0)
            {
                Console.WriteLine("OddMin=No");
                Console.WriteLine("OddMax=No");
            }
            else
            {
                Console.WriteLine("OddMin={0}", oddMin);
                Console.WriteLine("OddMax={0}", oddMax);
            }

            Console.WriteLine("EvenSum={0}", evenSum);

            if (evenSum == 0)
            {
                Console.WriteLine("EvenMin=No");
                Console.WriteLine("EvenMax=No");
            }
            else
            {
                Console.WriteLine("EvenMin={0}", evenMin);
                Console.WriteLine("EvenMax={0}", evenMax);
            }
        }
    }
}
