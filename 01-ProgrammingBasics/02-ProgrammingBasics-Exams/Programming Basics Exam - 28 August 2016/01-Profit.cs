using System;

namespace _05.Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int workDays = int.Parse(Console.ReadLine());
            double moneyPerDay = double.Parse(Console.ReadLine());
            double usdCurrency = double.Parse(Console.ReadLine());

            int workDaysPerYear = workDays * 12;
            double earnedMoneyForYear = workDaysPerYear * moneyPerDay;
            double bonus = workDays * 2.5 * moneyPerDay;
            double taxes = 0.75d;
            double totalEarnedMoney = (earnedMoneyForYear + bonus) * taxes;
            double earnedMoneyPerDay = (totalEarnedMoney * usdCurrency) / 365;

            Console.WriteLine("{0:f2}", earnedMoneyPerDay);
        }
    }
}