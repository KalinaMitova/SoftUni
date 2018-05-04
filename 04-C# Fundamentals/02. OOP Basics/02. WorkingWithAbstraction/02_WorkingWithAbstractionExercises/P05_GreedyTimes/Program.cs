using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());

            var bag = new Bag(bagCapacity);

            string[] safe = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            for (int i = 0; i < safe.Length; i += 2)
            {
                string gemName = safe[i];
                long gemValue = long.Parse(safe[i + 1]);

                GemEnums gemEnum = GemParse(gemName);

                Gem gem = new Gem(gemEnum, gemValue);

                bag.AddGem(gem);                
            }

            bag.PrintBag();
        }

        private static GemEnums GemParse(string gemName)
        {
            if (gemName.Length == 3)
            {
                return GemEnums.Cash;
            }
            else if (gemName.ToLower().EndsWith("gem"))
            {
                return GemEnums.Gem;
            }
            else if (gemName.ToLower() == "gold")
            {
                return GemEnums.Gold;
            }

            return GemEnums.None;
        }
    }
}