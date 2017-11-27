using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    private string name;
    private Stat[] stats;

    public Player(string name, Stat[] stats)
    {
        this.Name = name;
        this.Stats = stats;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            this.name = value;
        }
    }

    public Stat[] Stats
    {
        get
        {
            return this.stats;
        }
        private set
        {
            this.stats = value;
        }
    }

    public double OverallSkillLevel => this.Stats.Average(s => s.Value);
}