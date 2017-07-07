using System;

namespace _06_ControlNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int controlNum = int.Parse(Console.ReadLine());

            int sum = 0;
            int counter = 0;

            for (int i = 1; i <= n; i++)
            {
                for (int j = m; j >= 1; j--)
                {
                    counter++;
                    sum += i * 2 + j * 3;
                    if(sum >= controlNum)
                    {
                        Console.WriteLine("{0} moves", counter);
                        Console.WriteLine("Score: {0} >= {1}", sum, controlNum);
                        return;
                    }
                }
            }

            Console.WriteLine("{0} moves", counter);
        }
    }
}
