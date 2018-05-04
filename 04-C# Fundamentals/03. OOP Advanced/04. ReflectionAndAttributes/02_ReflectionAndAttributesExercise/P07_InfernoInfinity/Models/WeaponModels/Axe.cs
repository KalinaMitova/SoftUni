public class Axe : Weapon, IWeapon
{
    private const int DefaultMinimumDamage = 5;
    private const int DefaultMaximumDamage = 10;
    private const int DefaultSocketSize = 4;

    public Axe(string name, RarityLevelEnum rarityLevel) 
        : base(name, DefaultMinimumDamage, DefaultMaximumDamage, DefaultSocketSize, rarityLevel)
    {
    }
}