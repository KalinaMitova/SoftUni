using System;

namespace _11_Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectionType = Console.ReadLine().ToLower();
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            double price = 0.0;

            switch (projectionType)
            {
                case "premiere": price = 12; break;
                case "normal": price = 7.5; break;
                case "discount": price = 5; break;
            }

            Console.WriteLine("{0:f2}", price * rows * cols);
        }
    }
}
