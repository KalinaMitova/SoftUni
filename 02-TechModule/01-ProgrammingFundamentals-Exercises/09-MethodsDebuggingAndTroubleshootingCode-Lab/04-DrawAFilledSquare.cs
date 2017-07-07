using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_DrawAFilledSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintSquare(n);
        }

        static void PrintSquare(int width)
        {
            PrintSquareTopBottomLine(width);
            for (int i = 0; i < width - 2; i++)
            {
                PrintSquareMiddleLines(width);
            }
            PrintSquareTopBottomLine(width);
        }

        static void PrintSquareMiddleLines(int width)
        {
            Console.Write('-');
            for (int i = 0; i < width - 1; i++)
            {
                Console.Write("\\/");
            }
            Console.WriteLine('-');
        }

        static void PrintSquareTopBottomLine(int width)
        {
            Console.WriteLine(new string('-', width * 2));
        }
    }
}
