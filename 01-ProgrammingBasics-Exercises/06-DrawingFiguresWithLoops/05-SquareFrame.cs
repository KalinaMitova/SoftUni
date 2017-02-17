using System;

namespace _05_SquareFrame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int length = n - 2;

            Console.Write('+');
            for (int i = 0; i < length; i++)
            {
                Console.Write(" -");
            }
            Console.WriteLine(" +");

            for (int i = 0; i < length; i++)
            {
                Console.Write('|');
                for (int j = 0; j < length; j++)
                {
                    Console.Write(" -");
                }
                Console.WriteLine(" |");
            }
            
            Console.Write('+');
            for (int i = 0; i < length; i++)
            {
                Console.Write(" -");
            }
            Console.WriteLine(" +");
        }
    }
}
