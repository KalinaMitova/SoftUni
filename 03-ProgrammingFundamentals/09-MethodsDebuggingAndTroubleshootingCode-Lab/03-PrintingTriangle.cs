using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintTriangle(n);
        }

        static void PrintTriangle(int length)
        {
            for (int i = 1; i <= length; i++)
            {
                PrintTriangleLine(i);
            }

            for (int i = length - 1; i >= 1; i--)
            {
                PrintTriangleLine(i);
            }
        }

        static void PrintTriangleLine(int length)
        {
            for (int i = 1; i <= length; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
