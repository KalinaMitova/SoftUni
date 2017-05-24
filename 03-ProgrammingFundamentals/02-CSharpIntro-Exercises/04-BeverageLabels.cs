using System;

namespace _04_BeverageLabels
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int volume = int.Parse(Console.ReadLine());
            int energyPerOneHundredMil = int.Parse(Console.ReadLine());
            int sugarPerOneHundredMil = int.Parse(Console.ReadLine());

            double totalEnergy = energyPerOneHundredMil * (volume / 100d);
            double totalSugar = sugarPerOneHundredMil * (volume / 100d);

            Console.WriteLine($"{volume}ml {name}:");
            Console.WriteLine($"{totalEnergy}kcal, {totalSugar}g sugars");
        }
    }
}
