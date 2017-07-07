using System;

namespace _06_MaxCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            int start;
            int end;

            do
            {
                start = int.Parse(Console.ReadLine());
                end = int.Parse(Console.ReadLine());
            } while (start > end);

            int max = int.Parse(Console.ReadLine());
            int counter = 1;

            for (int i = start; i <= end; i++)
            {
                for (int j = start; j <= end; j++)
                {
                    if (max < counter)
                    {
                        Console.WriteLine();
                        return;
                    }
                    Console.Write("<{0}-{1}>", i, j);
                    counter++;
                }
            }
            Console.WriteLine();
        }
    }
}
