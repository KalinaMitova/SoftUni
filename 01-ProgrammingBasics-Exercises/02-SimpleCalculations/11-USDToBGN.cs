using System;
namespace _11.__usdТоBgn
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal usd = decimal.Parse(Console.ReadLine());
            decimal lev = usd * (decimal)1.79549;

            Console.WriteLine("{0} BGN", Math.Round(lev, 2));
        }
    }
}