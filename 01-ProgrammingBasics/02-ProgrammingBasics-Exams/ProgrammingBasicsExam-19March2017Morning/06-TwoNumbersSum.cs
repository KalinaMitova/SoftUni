using System;

namespace _06_Two_Numbers_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = start; i >= end; i--)
            {
                for (int j = start; j >= end; j--)
                {
                    counter++;
                    if (i + j == magicNum)
                    {
                        Console.WriteLine("Combination N:{0} ({1} + {2} = {3})", counter, i, j, magicNum);
                        return;
                    }
                }
            }
            Console.WriteLine("{0} combinations - neither equals {1}", counter, magicNum);
        }
    }
}
