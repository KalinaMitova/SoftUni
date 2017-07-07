using System;

namespace _06_RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int length = n + n - 1;
            int counter = 1;

            for (int i = 0; i < length; i++)
            {
                Console.Write(new string(' ', n - counter));
                Console.Write('*');
                for (int j = 1; j < counter; j++)
                    Console.Write(" *");
                Console.WriteLine();

                if (i < length / 2) counter++;
                else counter--;
            }
        }
    }
}