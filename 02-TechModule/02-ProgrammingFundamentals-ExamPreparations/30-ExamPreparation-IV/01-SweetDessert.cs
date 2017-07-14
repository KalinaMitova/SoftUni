using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_SweetDessert
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal ivanchoTotalMoney = decimal.Parse(Console.ReadLine());
            int gueststCount = int.Parse(Console.ReadLine());
            decimal bannanPrice = decimal.Parse(Console.ReadLine());
            decimal eggPrice = decimal.Parse(Console.ReadLine());
            decimal barriesPriceForKg = decimal.Parse(Console.ReadLine());

            var portions = gueststCount % 6 == 0 ? gueststCount / 6 : (gueststCount / 6) + 1;
            var pricePerPortoin = (2 * bannanPrice) + (4 * eggPrice) + (0.2m * barriesPriceForKg);
            var totalPrice = pricePerPortoin * portions;

            if (ivanchoTotalMoney >= totalPrice)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {totalPrice:F2}lv.");
            }
            else
            {
                var neededMoney = totalPrice - ivanchoTotalMoney;
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {neededMoney:F2}lv more.");
            }
        }
    }
}
