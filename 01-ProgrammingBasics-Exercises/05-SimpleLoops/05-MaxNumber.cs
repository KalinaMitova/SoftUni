using System;

namespace _05_MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int biggest = int.Parse(Console.ReadLine());

            for (int i = 0; i < n - 1; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                if (currentNum > biggest)
                {
                    biggest = currentNum;
                }
            }

            Console.WriteLine(biggest);
        }
    }
}
