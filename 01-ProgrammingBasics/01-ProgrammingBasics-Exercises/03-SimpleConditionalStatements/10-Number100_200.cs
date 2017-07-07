using System;

namespace _10___Number100._._._200
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n < 100)
            {
                Console.WriteLine("Less than 100");
            }
            else if (n >= 100 && n <= 200)
            {
                Console.WriteLine("Between 100 and 200");
            }
            else
            {
                Console.WriteLine("Greater than 200");
            }
        }
    }
}