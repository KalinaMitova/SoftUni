using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ImmuneSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var immuneHealth = int.Parse(Console.ReadLine());
            var virus = Console.ReadLine();

            var viruses = new List<string>();
            var totalHealth = immuneHealth;

            while (virus != "end")
            {
                var virusLength = virus.Length;
                var virusStrngth = 0;

                for (int i = 0; i < virusLength; i++)
                {
                    virusStrngth += virus[i];
                }

                virusStrngth /= 3;

                var secondsToDefeat = 0;

                if (!viruses.Contains(virus))
                {
                    secondsToDefeat = virusStrngth * virusLength;
                    viruses.Add(virus);
                }
                else
                {
                    secondsToDefeat = (virusStrngth * virusLength) / 3;
                }
                
                var time = TimeSpan.FromSeconds(secondsToDefeat);
                
                Console.WriteLine($"Virus {virus}: {virusStrngth} => {secondsToDefeat} seconds");

                if (totalHealth > secondsToDefeat)
                {
                    Console.WriteLine($"{virus} defeated in {Math.Floor(time.TotalMinutes)}m {time.Seconds}s.");

                    totalHealth -= secondsToDefeat;

                    Console.WriteLine($"Remaining health: {totalHealth}");

                    totalHealth += (int)(totalHealth * 0.2);

                    if (totalHealth > immuneHealth)
                    {
                        totalHealth = immuneHealth;
                    }
                }
                else
                {
                    Console.WriteLine("Immune System Defeated.");
                    return;
                }

                virus = Console.ReadLine();
            }

            Console.WriteLine($"Final Health: {totalHealth}");
        }
    }
}
