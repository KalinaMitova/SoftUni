using System;

namespace _04_SmartLilly
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            decimal washingMachinePrice = decimal.Parse(Console.ReadLine());
            decimal toyPrice = int.Parse(Console.ReadLine());

            decimal money = 0;
            decimal totalToysMoney = 0;
            decimal totalMoney = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    money += ( 10 * (i / 2) ) - 1;
                }
                else
                {
                    totalToysMoney += toyPrice;
                }
            }

            totalMoney = money + totalToysMoney;

            if (totalMoney >= washingMachinePrice)
            {
                Console.WriteLine("Yes! {0:F2}", totalMoney - washingMachinePrice);
            }
            else
            {
                Console.WriteLine("No! {0:F2}", washingMachinePrice - totalMoney);
            }
        }
    }
}
