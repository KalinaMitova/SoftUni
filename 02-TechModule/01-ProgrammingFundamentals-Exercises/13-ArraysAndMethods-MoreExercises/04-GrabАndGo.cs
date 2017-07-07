using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _04_GrabАndGo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
                        
            int length = numbers.Length;
            BigInteger sum = 0;
            bool occurrence = false;

            for (int i = length - 1; i >= 0; i--)
            {
                if (occurrence)
                {
                    sum += numbers[i];
                }

                if (numbers[i] == n)
                {
                    occurrence = true;
                }
            }

            if (occurrence)
            {
                Console.WriteLine(sum);
            }
            else
            {
                Console.WriteLine("No occurrences were found!");
            }
        }
    }
}
