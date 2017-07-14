using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01_CharityMarathon
{
    class Program
    {
        static void Main(string[] args)
        {
            int marathonDays = int.Parse(Console.ReadLine());
            int runners = int.Parse(Console.ReadLine());
            int laps = int.Parse(Console.ReadLine());
            int lapLength = int.Parse(Console.ReadLine());
            int trackCapacity = int.Parse(Console.ReadLine());
            decimal moneyPerKilometer = decimal.Parse(Console.ReadLine());
            
            if (runners > trackCapacity * marathonDays)
            {
                runners = trackCapacity * marathonDays;
            }

            decimal totalMeters = lapLength * (decimal)laps * runners;
            decimal totalKilometers = totalMeters / 1000m;
            decimal totalMoney = totalKilometers * moneyPerKilometer;
            
            Console.WriteLine($"Money raised: {totalMoney:F2}");
        }
    }
}
