using System;

namespace _09_PerfectDiamond
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int length = n * 2 - 1;
            int spaces = n - 1;
            int rowLength = -1;

            for (int i = 0; i < length; i++)
            {
                if (i == 0 || i == length - 1)
                {
                    Console.WriteLine(new string(' ', spaces) + '*');
                }
                else
                {
                    Console.Write(new string(' ', spaces) + '*');

                    for (int j = 0; j < rowLength; j++)
                    {
                        if (j % 2 == 0)
                        {
                            Console.Write('-');
                        }
                        else
                        {
                            Console.Write('*');
                        }
                    }

                    Console.WriteLine('*');
                }
                
                if (i < length / 2)
                {
                    spaces--;
                    rowLength += 2;
                }
                else
                {
                    spaces++;
                    rowLength -= 2;
                }

            }
        }
    }
}
