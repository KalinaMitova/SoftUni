using System;

namespace _12.__CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal sum = decimal.Parse(Console.ReadLine());
            string inputCurrency = Console.ReadLine();
            string outputCurrency = Console.ReadLine();
            decimal toLeva = 0;
            decimal result = 0;

            switch (inputCurrency)
            {
                case "BGN":
                    toLeva = sum;
                    break;
                case "USD":
                    toLeva = sum * (decimal)1.79549;
                    break;
                case "EUR":
                    toLeva = sum * (decimal)1.95583;
                    break;
                case "GBP":
                    toLeva = sum * (decimal)2.53405;
                    break;
            }

            switch (outputCurrency)
            {
                case "BGN":
                    result = toLeva;
                    break;
                case "USD":
                    result = toLeva / (decimal)1.79549;
                    break;
                case "EUR":
                    result = toLeva / (decimal)1.95583;
                    break;
                case "GBP":
                    result = toLeva / (decimal)2.53405;
                    break;
            }

            Console.WriteLine("{0} {1}", Math.Round(result, 2), outputCurrency);
        }
    }
}