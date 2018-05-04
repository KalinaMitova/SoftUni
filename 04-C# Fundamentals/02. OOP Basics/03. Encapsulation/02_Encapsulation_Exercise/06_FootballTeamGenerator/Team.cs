using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;
    private List<Player> players;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            name = value;
        }
    }
    
    public List<Player> Players
    {
        get { return players; }
        set { players = value; }
    }

    private double Rating => this.Players.Count > 0 ? Math.Round(this.Players.Average(p => p.SkillLevel), 0) : 0;

    public Team(string name)
    {
        this.Name = name;
        this.Players = new List<Player>();
    }

    public void AddPlayer(Player player)
    {
        this.Players.Add(player);
    }

    public void RemovePlayer(Player player)
    {
        if(this.Players.All(p => p.Name != player.Name))
        {
            throw new ArgumentException($"Player {player.Name} is not in {this.Name} team.");
        }

        this.Players.Remove(player);
    }

    public void ShowRating()
    {
        Console.WriteLine($"{this.Name} - {this.Rating}");
    }
}