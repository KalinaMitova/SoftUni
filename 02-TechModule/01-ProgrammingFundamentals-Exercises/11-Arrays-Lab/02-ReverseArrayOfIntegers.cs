using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ReverseArrayOfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrayLength = int.Parse(Console.ReadLine());
            int[] numbers = new int[arrayLength];

            // Read numbers
            for (int i = 0; i < arrayLength; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            // Reverse array
            for (int i = 0; i < arrayLength / 2; i++)
            {
                int oldNumber = numbers[i];
                numbers[i] = numbers[arrayLength - i - 1];
                numbers[arrayLength - i - 1] = oldNumber;
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
