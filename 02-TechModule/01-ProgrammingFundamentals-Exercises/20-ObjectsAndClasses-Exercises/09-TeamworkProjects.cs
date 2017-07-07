using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var teams = ReadTeams();

            AddMembers(teams);

            PrintTeams(teams);
        }

        private static void PrintTeams(List<Team> teams)
        {
            var teamsWithMembers = teams.Where(team => team.Members.Count > 0);
            var disband = teams.Where(team => team.Members.Count == 0);

            foreach (var team in teamsWithMembers
                .OrderByDescending(team => team.Members.Count())
                .ThenBy(team => team.TeamName))
            {
                Console.WriteLine(team.TeamName);
                Console.WriteLine($"- {team.CreatorName}");

                foreach (var member in team.Members.OrderBy(member => member))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var team in disband
                .OrderBy(team => team.TeamName).ToList())
            {
                Console.WriteLine(team.TeamName);
            }
        }

        private static void AddMembers(List<Team> teams)
        {
            var line = Console.ReadLine();
            while (line != "end of assignment")
            {
                var tokens = line.Split("->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var member = tokens[0];
                var teamToJoin = tokens[1];

                if (teams.All(team => team.TeamName != teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                }
                else if (teams.Any(team => team.CreatorName == member || team.Members.Contains(member)))
                {
                    Console.WriteLine($"Member {member} cannot join team {teamToJoin}!");
                }
                else
                {
                    teams.Find(team => team.TeamName == teamToJoin).Members.Add(member);
                }

                line = Console.ReadLine();
            }
        }

        private static List<Team> ReadTeams()
        {
            var teamList = new List<Team>();

            var teamCreator = new Dictionary<string, string>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split('-');
                var creator = tokens[0];
                var team = tokens[1];

                if (teamCreator.ContainsKey(team))
                {
                    Console.WriteLine($"Team {team} was already created!");
                }
                else if (teamCreator.Any(t => t.Value == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    var newTeam = new Team
                    {
                        CreatorName = creator,
                        TeamName = team,
                        Members = new List<string>()
                    };

                    teamList.Add(newTeam);

                    teamCreator[team] = creator;

                    Console.WriteLine($"Team {team} has been created by {creator}!");
                }
            }

            return teamList;
        }
    }

    class Team
    {
        public string TeamName { get; set; }

        public string CreatorName { get; set; }

        public List<string> Members { get; set; }
    }
}
