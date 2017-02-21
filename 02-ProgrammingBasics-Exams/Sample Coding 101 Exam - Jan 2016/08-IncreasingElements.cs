using System;

namespace _08_IncreasingElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            int prevNum = -1001;
            int maxCount = 0;

            for (int i = 0; i < n; i++)
            {
                int a = int.Parse(Console.ReadLine());

                if (a > prevNum)
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                }

                if (counter > maxCount)
                {
                    maxCount = counter;
                }

                prevNum = a;
            }

            Console.WriteLine(maxCount);
        }
    }
}
