using System;

namespace _03_BikeRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int juniors = int.Parse(Console.ReadLine());
            int seniors = int.Parse(Console.ReadLine());
            string layout = Console.ReadLine().ToLower();

            decimal juniorsFee;
            decimal seniorsFee;

            switch (layout)
            {
                case "trail":
                    juniorsFee = 5.5m;
                    seniorsFee = 7m;
                    break;
                case "cross-country":
                    juniorsFee = 8m;
                    seniorsFee = 9.5m;
                    break;
                case "downhill":
                    juniorsFee = 12.25m;
                    seniorsFee = 13.75m;
                    break;
                case "road":
                    juniorsFee = 20m;
                    seniorsFee = 21.5m;
                    break;
                default:
                    return;
            }

            decimal totalMoney = (juniors * juniorsFee) + (seniors * seniorsFee);

            if(layout == "cross-country" && juniors + seniors >= 50)
            {
                totalMoney -= totalMoney * 0.25m;
            }

            totalMoney -= totalMoney * 0.05m;

            Console.WriteLine("{0:F2}", totalMoney);
        }
    }
}
