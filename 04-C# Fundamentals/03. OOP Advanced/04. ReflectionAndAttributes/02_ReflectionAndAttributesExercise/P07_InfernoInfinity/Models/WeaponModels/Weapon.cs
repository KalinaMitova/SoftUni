using System.Linq;

[Custom(Author = "Pesho", 
    Revision = 3, 
    Description = "Used for C# OOP Advanced Course - Enumerations and Attributes.", 
    Reviewers = new string[] { "Pesho", "Svetlio" })]
public abstract class Weapon : IWeapon
{
    public Weapon(string name, int minimumDamage, int maximumDamage, int socketSize, RarityLevelEnum rarityLevel)
    {
        this.RarityLevel = rarityLevel;

        this.Name = name;
        this.MinimumDamage = minimumDamage * (int)this.RarityLevel;
        this.MaximumDamage = maximumDamage * (int)this.RarityLevel;
        this.Sockets = new Gem[socketSize];
    }

    public string Name { get; private set; }

    public int MinimumDamage { get; private set; }

    public int BonusMinimumDamage => this.Sockets.Sum(g => g != null ? (g.Strength* 2) + g.Agility : 0);

    public int MaximumDamage { get; private set; }

    public int BonusMaximumDamage => this.Sockets.Sum(g => g != null ? (g.Strength * 3) + (g.Agility * 4) : 0);

    public IGem[] Sockets { get; private set; }

    public RarityLevelEnum RarityLevel { get; private set; }

    public void AddGem(IGem gem, int index)
    {
        if(index >= 0 && index < this.Sockets.Length)
        {
            this.Sockets[index] = gem;
        }
    }

    public void RemoveGem(int index)
    {
        if (index >= 0 && index < this.Sockets.Length)
        {
            this.Sockets[index] = null;
        }
    }
}
