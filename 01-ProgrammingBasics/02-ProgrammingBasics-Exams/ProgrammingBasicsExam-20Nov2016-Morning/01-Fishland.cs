using System;

namespace _01_Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal mackerelPrice = decimal.Parse(Console.ReadLine());
            decimal spratPrice = decimal.Parse(Console.ReadLine());
            decimal bonitoWeight = decimal.Parse(Console.ReadLine());
            decimal scadWeight = decimal.Parse(Console.ReadLine());
            int musselWeight = int.Parse(Console.ReadLine());

            decimal bonitoPrice = mackerelPrice + (mackerelPrice * 0.6m);
            decimal scadPrice = spratPrice + (spratPrice * 0.80m);
            decimal musselPrice = 7.5m;

            decimal totalSum = (bonitoWeight * bonitoPrice) + (scadWeight * scadPrice) + (musselWeight * musselPrice);

            Console.WriteLine(Math.Round(totalSum, 2));
        }
    }
}