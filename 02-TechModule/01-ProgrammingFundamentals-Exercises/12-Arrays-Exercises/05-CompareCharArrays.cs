using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_CompareCharArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] firstArr = Console.ReadLine().Split().Select(char.Parse).ToArray();
            char[] secondArr = Console.ReadLine().Split().Select(char.Parse).ToArray();

            int firstArrLength = firstArr.Length;
            int secondArrLength = secondArr.Length;

            int shortestLength = Math.Min(firstArrLength, secondArrLength);

            for (int i = 0; i < shortestLength; i++)
            {
                if (firstArr[i] != secondArr[i])
                {
                    if (firstArr[i] < secondArr[i])
                    {
                        Console.WriteLine(String.Join("", firstArr));
                        Console.WriteLine(String.Join("", secondArr));
                        return;
                    }
                    else
                    {
                        Console.WriteLine(String.Join("", secondArr));
                        Console.WriteLine(String.Join("", firstArr));
                        return;
                    }
                }
            }

            if (firstArrLength < secondArrLength)
            {
                Console.WriteLine(String.Join("", firstArr));
                Console.WriteLine(String.Join("", secondArr));
            }
            else
            {
                Console.WriteLine(String.Join("", secondArr));
                Console.WriteLine(String.Join("", firstArr));
            }
        }
    }
}
