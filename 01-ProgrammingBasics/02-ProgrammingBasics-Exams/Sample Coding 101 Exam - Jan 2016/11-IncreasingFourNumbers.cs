using System;

namespace _11_IncreasingFourNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (b - a < 3)
            {
                Console.WriteLine("No");
                return;
            }

            for (int n1 = a; n1 <= b; n1++)
            {
                for (int n2 = a; n2 <= b; n2++)
                {
                    for (int n3 = a; n3 <= b; n3++)
                    {
                        for (int n4 = a; n4 <= b; n4++)
                        {
                            if (n1 < n2 && n2 < n3 && n3 < n4)
                                Console.WriteLine("{0} {1} {2} {3}", n1, n2, n3, n4);
                        }
                    }
                }
            }
        }
    }
}
