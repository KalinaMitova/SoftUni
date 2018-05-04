public class Sword : Weapon, IWeapon
{
    private const int DefaultMinimumDamage = 4;
    private const int DefaultMaximumDamage = 6;
    private const int DefaultSocketSize = 3;

    public Sword(string name, RarityLevelEnum rarityLevel) 
        : base(name, DefaultMinimumDamage, DefaultMaximumDamage, DefaultSocketSize, rarityLevel)
    {
    }
}