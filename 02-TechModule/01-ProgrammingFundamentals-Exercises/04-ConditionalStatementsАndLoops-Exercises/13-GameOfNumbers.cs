using System;

namespace _12_TestNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int counter = 0;

            string lastCombination = string.Empty;

            for (int i = n; i <= m; i++)
            {
                for (int j = n; j <= m; j++)
                {
                    counter++;
                    if (i + j == magicNumber)
                    {
                        lastCombination = $"Number found! {i} + {j} = {magicNumber}";
                    }
                }
            }

            if (lastCombination != "")
            {
                Console.WriteLine(lastCombination);
            }
            else
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");
            }
        }
    }
}
