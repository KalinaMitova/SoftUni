using System;

namespace _02_FlowerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfMagnolias = int.Parse(Console.ReadLine());
            int numOfHyacinths = int.Parse(Console.ReadLine());
            int numOfRoses = int.Parse(Console.ReadLine());
            int numOfCactuses = int.Parse(Console.ReadLine());
            decimal giftPrice = decimal.Parse(Console.ReadLine());

            decimal magnoliasPrice = 3.25m;
            decimal hyacinthsPrice = 4m;
            decimal rosesPrice = 3.5m;
            decimal cactusesPrice = 8m;
            
            decimal profit = (numOfMagnolias * magnoliasPrice) +
                (numOfHyacinths * hyacinthsPrice) +
                (numOfRoses * rosesPrice) +
                (numOfCactuses * cactusesPrice);

            profit -= profit * 0.05m; 

            if(profit >= giftPrice)
            {
                Console.WriteLine("She is left with {0} leva.", 
                    Math.Floor(profit - giftPrice));
            }
            else
            {
                Console.WriteLine("She will have to borrow {0} leva.", 
                    Math.Ceiling(giftPrice - profit));
            }
        }
    }
}
