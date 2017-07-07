using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_JumpAround
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int index = 0;
            int sum = numbers[0];

            while (true)
            {
                if (index + numbers[index] < numbers.Length)
                {
                    index += numbers[index];
                    sum += numbers[index];
                }
                else
                {
                    if (index - numbers[index] >= 0)
                    {
                        index -= numbers[index];
                        sum += numbers[index];
                    }
                    else
                    {
                        Console.WriteLine(sum);
                        return;
                    }
                }
            }
        }
    }
}
