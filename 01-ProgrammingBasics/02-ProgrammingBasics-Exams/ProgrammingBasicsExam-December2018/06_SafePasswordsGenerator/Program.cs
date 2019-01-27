namespace _06_SafePasswordsGenerator
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int maxCount = int.Parse(Console.ReadLine());

            int minA = 35;
            int maxA = 55;

            int minB = 64;
            int maxB = 96;

            int counter = 0;

            int currentA = minA;
            int currentB = minB;

            for (int x = 1; x <= a; x++)
            {
                for (int y = 1; y <= b; y++)
                {
                    Console.Write($"{(char)currentA}{(char)currentB}{x}{y}{(char)currentB}{(char)currentA}|");

                    currentA++;
                    currentB++;

                    if (currentA > maxA)
                    {
                        currentA = minA;
                    }

                    if (currentB > maxB)
                    {
                        currentB = minB;
                    }
                    counter++;

                    if(counter == maxCount)
                    {
                        Console.WriteLine();
                        return;
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
