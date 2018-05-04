public interface IWeapon
{
    string Name { get; }

    int MinimumDamage { get; }
    
    int BonusMinimumDamage { get; }

    int MaximumDamage { get; }

    int BonusMaximumDamage { get; }

    IGem[] Sockets { get; }

    RarityLevelEnum RarityLevel { get; }

    void AddGem(IGem gem, int index);

    void RemoveGem(int index);
}
