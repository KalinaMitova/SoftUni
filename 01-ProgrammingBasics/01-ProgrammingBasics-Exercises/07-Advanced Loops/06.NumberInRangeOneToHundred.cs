using System;

namespace _06.NumberInRange1To100
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isValid = false;
            do
            {
                Console.Write("Еnter a number in the range [1...100]: ");
                int n = int.Parse(Console.ReadLine());

                if (n > 0 && n <= 100)
                {
                    Console.WriteLine("The number is: " + n);
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            } while (!isValid);            
        }
    }
}
