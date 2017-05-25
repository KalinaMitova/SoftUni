using System;

namespace _11_OddNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            bool isEven;

            do
            {
                n = int.Parse(Console.ReadLine());
                isEven = n % 2 == 0;
                if (isEven)
                {
                    Console.WriteLine("Please write an odd number.");
                }
            }
            while (isEven);

            Console.WriteLine("The number is: {0}", Math.Abs(n));
        }
    }
}
