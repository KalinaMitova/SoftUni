using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    private string name;
    private List<Stat> stats;

    public string Name
    {
        get { return name; }
        set
        {
            if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            name = value;
        }
    }
    
    public List<Stat> Stats
    {
        get { return stats; }
        set { stats = value; }
    }
    
    public double SkillLevel => stats.Average(s => s.Rate);

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        this.Name = name;
        this.Stats = new List<Stat>()
        {
            new Stat("Endurance", endurance),
            new Stat("Sprint", sprint),
            new Stat("Dribble", dribble),
            new Stat("Passing", passing),
            new Stat("Shooting", shooting),
        };
    }
}