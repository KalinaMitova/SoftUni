using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03_FootballLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            string key = Regex.Escape(Console.ReadLine());
            string teamPattern = $".*{key}(?<teamA>\\w+){key}.*";
            
            string line = Console.ReadLine();
            while (line != "final")
            {
                string[] tokens = line.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

                string teamA = new string(Regex.Match(tokens[0], teamPattern).Groups[1].Value.Reverse().ToArray()).ToUpper();
                string teamB = new string(Regex.Match(tokens[1], teamPattern).Groups[1].Value.Reverse().ToArray()).ToUpper();

                int[] scores = tokens[2].Split(':').Select(int.Parse).ToArray();

                int teamAScore = scores[0];
                int teamBScore = scores[1];

                int teamAPoints = 0;
                int teamBPoints = 0;
                         
                if (teamAScore > teamBScore)
                {
                    teamAPoints = 3;
                }
                else if (teamBScore > teamAScore)
                {
                    teamBPoints = 3;
                }
                else
                {
                    teamAPoints = 1;
                    teamBPoints = 1;
                }
                                
                if (!teams.ContainsKey(teamA))
                {
                    teams[teamA] = new Team
                    {
                        Name = teamA,
                        Goals = teamAScore,
                        Points = teamAPoints
                    };
                }
                else
                {
                    teams[teamA].AddGoals(teamAScore);
                    teams[teamA].AddPoints(teamAPoints);
                }

                if (!teams.ContainsKey(teamB))
                {
                    teams[teamB] = new Team
                    {
                        Name = teamB,
                        Goals = teamBScore,
                        Points = teamBPoints
                    };
                }
                else
                {
                    teams[teamB].AddGoals(teamBScore);
                    teams[teamB].AddPoints(teamBPoints);
                }

                line = Console.ReadLine();
            }

            var place = 1;
            Console.WriteLine("League standings:");
            foreach (var team in teams
                .OrderByDescending(t => t.Value.Points)
                .ThenBy(t => t.Value.Name))
            {
                var currentTeam = team.Value;
                Console.WriteLine($"{place}. {currentTeam.Name} {currentTeam.Points}");
                place++;
            }

            var topThreeByGoals = teams
                .OrderByDescending(t => t.Value.Goals)
                .ThenBy(t => t.Value.Name)
                .Take(3)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine("Top 3 scored goals:");
            foreach (var team in topThreeByGoals)
            {
                var currentTeam = team.Value;
                Console.WriteLine($"- {currentTeam.Name} -> {currentTeam.Goals}");                
            }
        }
    }

    class Team
    {
        public string Name { get; set; }

        public long Goals { get; set; }

        public int Points { get; set; }

        public void AddGoals (int goal)
        {
            this.Goals += goal;
        }

        public void AddPoints (int points)
        {
            this.Points += points;
        }
    }
}
