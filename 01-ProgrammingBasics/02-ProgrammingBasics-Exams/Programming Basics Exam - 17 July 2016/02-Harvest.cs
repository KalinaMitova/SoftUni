using System;

namespace _02_Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double wine = ((x * y) * 0.4) / 2.5;

            if(z > wine)
            {
                Console.WriteLine("It will be a tough winter! More {0} liters wine needed.", Math.Floor(z - wine));
            }
            else
            {
                Console.WriteLine("Good harvest this year! Total wine: {0} liters.", Math.Floor(wine));
                Console.WriteLine("{0} liters left -> {1} liters per person.", Math.Ceiling(wine - z), Math.Ceiling((wine - z) / workers));
            }
        }
    }
}
