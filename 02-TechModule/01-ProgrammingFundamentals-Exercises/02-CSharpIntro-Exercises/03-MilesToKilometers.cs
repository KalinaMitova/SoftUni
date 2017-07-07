using System;

namespace _03_MilesToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            double mile = double.Parse(Console.ReadLine());
            double kilometers = mile * 1.60934;

            Console.WriteLine("{0:F2}", kilometers);
        }
    }
}
