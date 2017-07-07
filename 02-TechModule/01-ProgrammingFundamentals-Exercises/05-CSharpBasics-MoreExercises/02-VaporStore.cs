using System;

namespace _02_VaporStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());
            double totalSpentMoney = 0;

            while (true)
            {
                if (currentBalance == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }

                string game = Console.ReadLine();

                switch (game)
                {
                    case "OutFall 4":
                        if (currentBalance < 39.99)
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        else
                        {
                            currentBalance -= 39.99;
                            totalSpentMoney += 39.99;
                            Console.WriteLine($"Bought {game}");
                        }
                        break;
                    case "CS: OG":
                        if (currentBalance < 15.99)
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        else
                        {
                            currentBalance -= 15.99;
                            totalSpentMoney += 15.99;
                            Console.WriteLine($"Bought {game}");
                        }
                        break;
                    case "Zplinter Zell":
                        if (currentBalance < 19.99)
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        else
                        {
                            currentBalance -= 19.99;
                            totalSpentMoney += 19.99;
                            Console.WriteLine($"Bought {game}");
                        }
                        break;
                    case "Honored 2":
                        if (currentBalance < 59.99)
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        else
                        {
                            currentBalance -= 59.99;
                            totalSpentMoney += 59.99;
                            Console.WriteLine($"Bought {game}");
                        }
                        break;
                    case "RoverWatch":
                        if (currentBalance < 29.99)
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        else
                        {
                            currentBalance -= 29.99;
                            totalSpentMoney += 29.99;
                            Console.WriteLine($"Bought {game}");
                        }
                        break;
                    case "RoverWatch Origins Edition":
                        if (currentBalance < 39.99)
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        else
                        {
                            currentBalance -= 39.99;
                            totalSpentMoney += 39.99;
                            Console.WriteLine($"Bought {game}");
                        }
                        break;
                    case "Game Time":
                        Console.WriteLine($"Total spent: ${totalSpentMoney:F2}. Remaining: ${currentBalance:F2}");
                        return;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                }
            }
        }
    }
}
