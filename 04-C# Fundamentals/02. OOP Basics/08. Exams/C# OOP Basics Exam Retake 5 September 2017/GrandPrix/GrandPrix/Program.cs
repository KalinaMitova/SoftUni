using System;
using System.Collections.Generic;
using System.Linq;

namespace GrandPrix
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RaceTower raceTower = new RaceTower();

            int numberOfLaps = int.Parse(Console.ReadLine());
            int trackLength = int.Parse(Console.ReadLine());

            raceTower.SetTrackInfo(numberOfLaps, trackLength);

            while (numberOfLaps != raceTower.currentLap)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split();

                string command = tokens[0];

                List<string> arguments = tokens.Skip(1).Take(tokens.Length - 1).ToList();

                switch (command)
                {
                    case "RegisterDriver":
                        raceTower.RegisterDriver(arguments);
                        break;
                    case "Leaderboard":
                        Console.WriteLine(raceTower.GetLeaderboard());
                        break;
                    case "CompleteLaps":                        
                        string completeLapsMessages = raceTower.CompleteLaps(arguments);

                        if (!string.IsNullOrWhiteSpace(completeLapsMessages))
                        {
                            Console.WriteLine(completeLapsMessages);
                        }                                               
                        break;
                    case "Box":
                        raceTower.DriverBoxes(arguments);
                        break;
                    case "ChangeWeather":
                        raceTower.ChangeWeather(arguments);
                        break;
                }
            }

            Driver winner = raceTower.GetWinner();

            Console.WriteLine($"{winner.Name} wins the race for {winner.TotalTime:F3} seconds.");
        }
    }
}
