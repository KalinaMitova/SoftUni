namespace _03_GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GreedyTimes
    {
        public static void Main()
        {
            long bagCapacity = long.Parse(Console.ReadLine());

            string[] items = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Dictionary<string, int>> bag = new Dictionary<string, Dictionary<string, int>>();
            
            long totalGold = 0;
            long totalGems = 0;
            long totalCash = 0;

            for(int i = 0; i < items.Length; i+=2)
            {
                string itemType = items[i];
                int value = int.Parse(items[i + 1]);

                if (bagCapacity < totalCash + totalGems + totalGold + value)
                {
                    continue;
                }

                if (itemType.ToLower() == "gold")
                {
                    if (!bag.ContainsKey("Gold"))
                    {
                        bag.Add("Gold", new Dictionary<string, int>());
                    }

                    if (!bag["Gold"].ContainsKey(itemType))
                    {
                        bag["Gold"].Add(itemType, 0);
                    }
                    bag["Gold"]["Gold"] += value;
                    totalGold += value;
                }
                else if (itemType.ToLower().EndsWith("gem") && itemType.Length >= 4)
                {
                    if (totalGold >= totalGems + value)
                    {
                        if (!bag.ContainsKey("Gem"))
                        {
                            bag.Add("Gem", new Dictionary<string, int>());
                        }

                        if (!bag["Gem"].ContainsKey(itemType))
                        {
                            bag["Gem"].Add(itemType, 0);
                        }

                        bag["Gem"][itemType] += value;
                        totalGems += value;
                    }
                }
                else if(itemType.Length == 3)
                {
                    if (totalGems >= totalCash + value)
                    {
                        if (!bag.ContainsKey("Cash"))
                        {
                            bag.Add("Cash", new Dictionary<string, int>());
                        }

                        if (!bag["Cash"].ContainsKey(itemType))
                        {
                            bag["Cash"].Add(itemType, 0);
                        }

                        bag["Cash"][itemType] += value;
                        totalCash += value;
                    }
                }
                
            }

            foreach (var itemType in bag
                .OrderByDescending(kvp => kvp.Value.Sum(i => i.Value)))
            {
                Console.WriteLine($"<{itemType.Key}> ${itemType.Value.Sum(kvp => kvp.Value)}");

                foreach (var item in itemType.Value
                    .OrderByDescending(kvp => kvp.Key)
                    .ThenBy(i => i.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }
    }
}
