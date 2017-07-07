using System;

namespace _09_CountTheIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            int number;

            while (true)
            {
                bool isNumber = int.TryParse(Console.ReadLine(), out number);

                if (isNumber)
                {
                    counter++;
                }
                else
                {
                    Console.WriteLine(counter);
                    return;
                }
            }
        }
    }
}
