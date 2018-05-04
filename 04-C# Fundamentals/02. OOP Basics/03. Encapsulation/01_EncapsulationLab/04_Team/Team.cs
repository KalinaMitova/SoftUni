using System;
using System.Collections.Generic;

public class Team
{
    private const int AVERAGE_AGE = 40;

    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public List<Person> FirstTeam
    {
        get { return this.firstTeam; }
    }

    public List<Person> ReserveTeam
    {
        get { return this.reserveTeam; }
    }

    public Team()
    {
        firstTeam = new List<Person>();
        reserveTeam = new List<Person>();
    }

    public Team(string teamName)
        :this()
    {
        Name = teamName;
    }

    public void AddPlayer(Person player)
    {
        if(player.Age < AVERAGE_AGE)
        {
            this.FirstTeam.Add(player);
        }
        else
        {
            this.ReserveTeam.Add(player);
        }
    }

    public override string ToString()
    {
        string output = $"First team has {FirstTeam.Count} players." + Environment.NewLine;
        output += $"Reserve team has {ReserveTeam.Count} players.";

        return output;
    }
}