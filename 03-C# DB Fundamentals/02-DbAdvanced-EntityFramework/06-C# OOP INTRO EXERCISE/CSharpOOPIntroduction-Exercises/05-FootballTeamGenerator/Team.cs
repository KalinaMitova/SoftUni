using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;
    private List<Player> players;

    public Team(string name)
    {
        this.Name = name;
        this.players = new List<Player>();
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

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        Player player = players.FirstOrDefault(p => p.Name == playerName);

        if (player == null)
        {
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
        }

        players.Remove(player);
    }

    public int Rating => this.players.Count == 0 ? 0 : (int)Math.Round(this.players.Average(p => p.OverallSkillLevel));
}
