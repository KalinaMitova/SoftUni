using System;

namespace _03_Ferrari
{
    public class Program
    {
        public static void Main()
        {
            string driverName = Console.ReadLine();

            ICar ferrari = new Ferrari(driverName);

            Console.WriteLine(ferrari);
        }
    }
}
