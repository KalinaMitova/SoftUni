using System;

namespace _13_NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 1;

            for (int row = 1; row <= n; row++)
            { 
                for (int col = 0; col < row; col++)
                {
                    Console.Write(counter + " ");
                    if (counter == n)
                    {
                        Console.WriteLine();
                        return;
                    }
                    counter++;
                }
                Console.WriteLine();
            }
        }
    }
}
