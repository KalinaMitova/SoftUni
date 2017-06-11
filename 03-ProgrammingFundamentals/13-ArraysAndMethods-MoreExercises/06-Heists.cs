using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Heists
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prices = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int jewelsPrice = prices[0];
            int goldPreces = prices[1];

            string[] heists = Console.ReadLine().Split();

            long totalEarnings = 0;
            long totalExpenses = 0;

            while (heists[0] != "Jail" && heists[1] != "Time")
            {
                string loot = heists[0];
                int heistExpenses = int.Parse(heists[1]);
                int length = loot.Length;

                for (int i = 0; i < length; i++)
                {
                    if (loot[i] == '%')
                    {
                        totalEarnings += jewelsPrice;
                    }
                    else if (loot[i] == '$')
                    {
                        totalEarnings += goldPreces;
                    }
                }

                totalExpenses += heistExpenses;

                heists = Console.ReadLine().Split();
            }

            if (totalEarnings >= totalExpenses)
            {
                Console.WriteLine($"Heists will continue. Total earnings: {totalEarnings - totalExpenses}.");
            }
            else
            {
                Console.WriteLine($"Have to find another job. Lost: {totalExpenses - totalEarnings}.");
            }
        }
    }
}
