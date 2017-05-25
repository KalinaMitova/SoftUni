using System;

namespace _09_MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int theInteger = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());

            if (multiplier > 10)
            {
                int product = theInteger * multiplier;
                Console.WriteLine($"{theInteger} X {multiplier} = {product}");
                return;
            }

            for (int times = multiplier; times <= 10; times++)
            {
                int product = theInteger * times;
                Console.WriteLine($"{theInteger} X {times} = {product}");
            }
        }
    }
}
