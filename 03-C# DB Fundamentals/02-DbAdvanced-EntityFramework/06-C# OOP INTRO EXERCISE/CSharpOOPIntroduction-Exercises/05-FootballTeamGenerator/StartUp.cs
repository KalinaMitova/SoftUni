using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_FootballTeamGenerator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string[] statNames = new string[]
            {
                "Endurance",
                "Sprint",
                "Dribble",
                "Passing",
                "Shooting"
            };

            string input;
            while((input = Console.ReadLine())!= "END")
            {
                string[] tokens = input.Split(';');

                string command = tokens[0];
                string teamName = tokens[1];

                try
                {
                    switch (command)
                    {
                        case "Team":
                            {
                                Team newTeam = new Team(teamName);
                                teams.Add(newTeam);
                            }
                            break;
                        case "Add":
                            {
                                if (teams.All(t => t.Name != teamName))
                                {
                                    throw new ArgumentException($"Team {teamName} does not exist.");
                                }

                                Team team = teams.Find(t => t.Name == teamName);

                                Stat[] stats = new Stat[5];
                                string playerName = tokens[2];

                                for (int i = 0; i < stats.Length; i++)
                                {
                                    string statName = statNames[i];
                                    int statValue = int.Parse(tokens[3 + i]);

                                    Stat stat = new Stat(statName, statValue);
                                    stats[i] = stat;
                                }

                                Player player = new Player(playerName, stats);

                                team.AddPlayer(player);
                            }
                            break;
                        case "Remove":
                            {
                                if (teams.All(t => t.Name != teamName))
                                {
                                    throw new ArgumentException($"Team {teamName} does not exist.");
                                }

                                Team team = teams.Find(t => t.Name == teamName);

                                string playerName = tokens[2];
                                team.RemovePlayer(playerName);
                            }
                            break;
                        case "Rating":
                            {
                                if (teams.All(t => t.Name != teamName))
                                {
                                    throw new ArgumentException($"Team {teamName} does not exist.");
                                }

                                Team team = teams.Find(t => t.Name == teamName);

                                Console.WriteLine($"{teamName} - {team.Rating}");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
