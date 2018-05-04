using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Team> teams = new List<Team>();
        
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            try
            {
                string[] tokens = input.Split(";".ToCharArray(), StringSplitOptions.None);

                string command = tokens[0];

                if (command == "Team")
                {
                    string teamName = tokens[1];
                    Team team = new Team(teamName);
                    teams.Add(team);
                }
                else if (command == "Add")
                {
                    string teamName = tokens[1];

                    Team team = teams.FirstOrDefault(t => t.Name == teamName);

                    if (team == null)
                    {
                        throw new ArgumentException($"Team {teamName} does not exist.");
                    }

                    string playerName = tokens[2];

                    int endurance = int.Parse(tokens[3]);
                    int sprint = int.Parse(tokens[4]);
                    int dribble = int.Parse(tokens[5]);
                    int passing = int.Parse(tokens[6]);
                    int shooting = int.Parse(tokens[7]);

                    Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                    team.AddPlayer(player);
                }
                else if (command == "Remove")
                {
                    string teamName = tokens[1];

                    Team team = teams.FirstOrDefault(t => t.Name == teamName);

                    if (team == null)
                    {
                        throw new ArgumentException($"Team {teamName} does not exist.");
                    }

                    string playerName = tokens[2];

                    Player player = team.Players.FirstOrDefault(p => p.Name == playerName);

                    if (player == null)
                    {
                        throw new ArgumentException($"Player {playerName} is not in {teamName} team.");
                    }

                    team.RemovePlayer(player);
                }
                else if (command == "Rating")
                {
                    string teamName = tokens[1];

                    Team team = teams.FirstOrDefault(t => t.Name == teamName);

                    if (team == null)
                    {
                        throw new ArgumentException($"Team {teamName} does not exist.");
                    }

                    team.ShowRating();
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
    }
}