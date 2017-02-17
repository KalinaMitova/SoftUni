using System;

namespace _04.Money
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoins = int.Parse(Console.ReadLine());
            double chineseYuan = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine());

            int bitcoinsToBGN = bitcoins * 1168;
            double yuanToUSD = chineseYuan * 0.15;
            double usdToBGN = yuanToUSD * 1.76;

            double totalMoneysToEUR = (bitcoinsToBGN + usdToBGN) / 1.95;
            double commissionInEUR = totalMoneysToEUR * (commission / 100);

            Console.WriteLine(totalMoneysToEUR - commissionInEUR);
        }
    }
}