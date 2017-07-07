using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Red Bazgargal 100 2500 25

            var typesNamesStats = new Dictionary<string, SortedDictionary<string, Dictionary<string, decimal>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                var type = tokens[0];
                var name = tokens[1];

                if (!typesNamesStats.ContainsKey(type))
                {
                    typesNamesStats[type] = new SortedDictionary<string, Dictionary<string, decimal>>();
                }

                if (!typesNamesStats[type].ContainsKey(name))
                {
                    typesNamesStats[type][name] = new Dictionary<string, decimal>();
                }
                
                var damage = 45m;
                var health = 250m;
                var armor = 10m;

                var isDamage = decimal.TryParse(tokens[2], out damage);
                var isHealth = decimal.TryParse(tokens[3], out health);
                var isArmor = decimal.TryParse(tokens[4], out armor);

                typesNamesStats[type][name]["damage"] = damage;
                typesNamesStats[type][name]["health"] = health;
                typesNamesStats[type][name]["armor"] = armor;
            }

            foreach (var typeNameStat in typesNamesStats)
            {
                var type = typeNameStat.Key;
                var damageAvarage = typeNameStat.Value.Average(el => el.Value["damage"]);
                var healthAvarage = typeNameStat.Value.Average(el => el.Value["health"]);
                var armorAvarage = typeNameStat.Value.Average(el => el.Value["armor"]);

                Console.WriteLine($"{type}::({damageAvarage:F2}/{healthAvarage:F2}/{armorAvarage:F2})");

                foreach (var nameStat in typeNameStat.Value)
                {
                    var name = nameStat.Key;
                    var damage = nameStat.Value["damage"];
                    var health = nameStat.Value["health"];
                    var armor = nameStat.Value["armor"];

                    Console.WriteLine($"-{name} -> damage: {damage}, health: {health}, armor: {armor}");
                }
            }
        }
    }
}
