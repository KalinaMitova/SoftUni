using System;

namespace _04_BackToThePast
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal money = decimal.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            int length = year - 1800;
            decimal spentMoney = 0;

            for (int i = 0; i <= length; i++)
            {
                if (i % 2 == 0)
                {
                    spentMoney += 12000;
                }
                else
                {
                    spentMoney += 12000 + (50 * (18 + i));
                }
            }

            if (money - spentMoney >= 0)
            {
                Console.WriteLine("Yes! He will live a carefree life and will have {0:F2} dollars left.", money - spentMoney);
            }
            else
            {
                Console.WriteLine("He will need {0:F2} dollars to survive.", spentMoney - money);
            }
        }
    }
}
