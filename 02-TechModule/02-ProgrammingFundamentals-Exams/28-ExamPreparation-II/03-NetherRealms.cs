using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03_NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Demon> allDemons = new List<Demon>();

            var demons = Console.ReadLine()
                .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(d => d.Trim())
                .ToArray();

            foreach (string demon in demons)
            {
                var health = Regex.Matches(demon, @"[^0-9\+\-\.\*\/]")
                    .Cast<Match>()
                    .Select(m => m.Value)
                    .Sum(c => (int)char.Parse(c));

                var damage = Regex.Matches(demon, @"-?[0-9]+(\.[0-9]+)?")
                    .Cast<Match>()
                    .Select(m => decimal.Parse(m.Value))
                    .Sum(c => c);

                for (int i = 0; i < demon.Length; i++)
                {
                    if (demon[i] == '*')
                    {
                        damage *= 2;
                    }
                    else if (demon[i] == '/')
                    {
                        damage /= 2;
                    }
                }

                var currentDemon = new Demon
                {
                    Name = demon,
                    Health = health,
                    Damage = damage
                };

                if (allDemons.All(d => d.Name != currentDemon.Name))
                {
                    allDemons.Add(currentDemon);
                }
            }

            foreach (var demon in allDemons.OrderBy(d => d.Name))
            {
                Console.WriteLine(demon);
            }
        }
    }

    class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public decimal Damage { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Health} health, {Damage:F2} damage";
        }
    }

}
