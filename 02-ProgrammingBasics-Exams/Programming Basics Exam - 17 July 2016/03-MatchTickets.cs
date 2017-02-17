using System;

namespace _03_MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            string category = Console.ReadLine().ToLower();
            int numberOfPeople = int.Parse(Console.ReadLine());

            decimal vipTicketPrice = 499.99m;
            decimal normalTicketPrice = 249.99m;
            decimal transportPrice = 0.0m;
            decimal totalMoney = budget;

            if (numberOfPeople >= 1 && numberOfPeople <= 4)
            {
                transportPrice = budget * (decimal)0.75;
            }
            else if (numberOfPeople >= 5 && numberOfPeople <= 9)
            {
                transportPrice = budget * (decimal)0.6;
            }
            else if (numberOfPeople >= 10 && numberOfPeople <= 24)
            {
                transportPrice = budget * (decimal)0.5;
            }
            else if (numberOfPeople >= 25 && numberOfPeople <= 49)
            {
                transportPrice = budget * (decimal)0.4;
            }
            else
            {
                transportPrice = budget * (decimal)0.25;
            }

            totalMoney -= transportPrice;

            switch (category)
            {
                case "normal":
                    if (normalTicketPrice * numberOfPeople < totalMoney)
                    {
                        Console.WriteLine("Yes! You have {0:F2} leva left.", totalMoney - (normalTicketPrice * numberOfPeople));
                    }
                    else
                    {
                        Console.WriteLine("Not enough money! You need {0:F2} leva.", Math.Abs((normalTicketPrice * numberOfPeople) - totalMoney));
                    }
                    break;
                case "vip":
                    if (vipTicketPrice * numberOfPeople < totalMoney)
                    {
                        Console.WriteLine("Yes! You have {0:F2} leva left.", totalMoney - (vipTicketPrice * numberOfPeople));
                    }
                    else
                    {
                        Console.WriteLine("Not enough money! You need {0:F2} leva.", Math.Abs((vipTicketPrice * numberOfPeople) - totalMoney));
                    }
                    break;
                default:
                    Console.WriteLine("unknown category");
                    break;
            }
        }
    }
}
