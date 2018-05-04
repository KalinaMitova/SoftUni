using System;

public class Stat
{
    private string name;
    private int rate;

    public string Name
    {
        get { return name; }
        set
        {
            switch (value.ToLower())
            {
                case "endurance":
                case "sprint":
                case "dribble":
                case "passing":
                case "shooting":
                    name = value;
                    break;
                default:
                    throw new ArgumentException("");
            }
        }
    }
    
    public int Rate
    {
        get { return rate; }
        set
        {
            if(value < 0 || value > 100)
            {
                throw new ArgumentException($"{this.Name} should be between 0 and 100.");
            }

            rate = value;
        }
    }

    public Stat(string name, int rate)
    {
        this.Name = name;
        this.Rate = rate;
    }
}