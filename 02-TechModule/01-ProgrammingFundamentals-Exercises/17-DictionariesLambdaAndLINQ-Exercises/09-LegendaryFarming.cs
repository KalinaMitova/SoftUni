using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyMaterials = new Dictionary<string, int>();
            
            keyMaterials["shards"] = 0;
            keyMaterials["fragments"] = 0;
            keyMaterials["motes"] = 0;

            var junks = new SortedDictionary<string, int>();

            while (true)
            {
                var line = Console.ReadLine().Split();

                var length = line.Length;
                
                for (int i = 0; i < length; i+=2)
                {
                    var key = line[i + 1].ToLower();
                    var value = int.Parse(line[i]);
                    
                    if (key == "shards" || key == "fragments" || key == "motes")
                    {
                        keyMaterials[key] += value;

                        if (keyMaterials[key] >= 250)
                        {
                            var winner = string.Empty;

                            keyMaterials[key] -= 250;

                            switch (key)
                            {
                                case "shards":
                                    winner = "Shadowmourne";
                                    break;
                                case "fragments":
                                    winner = "Valanyr";
                                    break;
                                case "motes":
                                    winner = "Dragonwrath";
                                    break;
                            }

                            Console.WriteLine($"{winner} obtained!");

                            foreach (var keyMaterial in keyMaterials.OrderByDescending(kvp => kvp.Value).ThenBy(kvp => kvp.Key))
                            {
                                Console.WriteLine($"{keyMaterial.Key}: {keyMaterial.Value}");
                            }

                            foreach (var junk in junks)
                            {
                                Console.WriteLine($"{junk.Key}: {junk.Value}");
                            }

                            return;
                        }
                    }
                    else
                    {
                        if (!junks.ContainsKey(key))
                        {
                            junks[key] = 0;
                        }

                        junks[key] += value;
                    }
                }
            }
        }
    }
}
