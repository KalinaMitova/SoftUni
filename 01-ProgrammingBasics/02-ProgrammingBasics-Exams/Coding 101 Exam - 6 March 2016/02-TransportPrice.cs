using System;

namespace _02.Transport_Price
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            double price = 0;

            if (n < 20)
            {
                if (timeOfDay == "day")
                {
                    price = 0.7 + n * 0.79;
                }
                else
                {
                    price = 0.7 + n * 0.9;
                }
            }
            else if (n < 100)
            {
                price = n * 0.09;
            }
            else
            {
                price = n * 0.06;
            }

            Console.WriteLine(price);
        }
    }
}