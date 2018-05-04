using System.Collections.Generic;
using System.Linq;

public class Bag
{
    private long capacity;

    private List<Gem> gems;
    
    public long Capacity
    {
        get { return capacity; }
        set { capacity = value; }
    }

    public List<Gem> Gems
    {
        get { return gems; }
        set { gems = value; }
    }

    public long TotalGems => Gems.Where(g => g.Name == GemEnums.Gem).Sum(g => g.Value);

    public long TotalCash => Gems.Where(g => g.Name == GemEnums.Cash).Sum(g => g.Value);
    
    public long TotalGold => Gems.Where(g => g.Name == GemEnums.Gold).Sum(g => g.Value);

    public long TotalBagAmount => gems.Sum(g => g.Value);

    public Bag(long capacity)
    {
        Capacity = capacity;
        Gems = new List<Gem>();
    }    

    public void AddGem(Gem gem)
    {
        if (gem.Name != GemEnums.None && Capacity >= TotalBagAmount + gem.Value)
        {
            if((gem.Name == GemEnums.Gem && TotalGold >= TotalGems + gem.Value) || 
                (gem.Name == GemEnums.Cash && TotalGems >= TotalCash + gem.Value))
            {
                gems.Add(gem);
            }
        }
    }

    public void PrintBag()
    {
        foreach (var x in Gems)
        {
            Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
            foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
            {
                Console.WriteLine($"##{item2.Key} - {item2.Value}");
            }
        }
    }
}