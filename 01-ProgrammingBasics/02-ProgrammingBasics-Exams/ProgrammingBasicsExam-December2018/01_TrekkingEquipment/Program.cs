namespace _01_TrekkingEquipment
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            double carabinerPrice = 36.0;
            double ropePrice = 3.6;
            double picellePrice = 19.8;

            int climbersCount = int.Parse(Console.ReadLine());
            int carabinersCount = int.Parse(Console.ReadLine());
            int ropeCount = int.Parse(Console.ReadLine());
            int picelleCount = int.Parse(Console.ReadLine());

            double totalPrice = climbersCount * 
                (carabinerPrice * carabinersCount +
                 ropePrice * ropeCount +
                 picellePrice * picelleCount);

            double totalPriceWithVAT = totalPrice * 1.20;

            Console.WriteLine("{0:F2}", totalPriceWithVAT);
        }
    }
}
