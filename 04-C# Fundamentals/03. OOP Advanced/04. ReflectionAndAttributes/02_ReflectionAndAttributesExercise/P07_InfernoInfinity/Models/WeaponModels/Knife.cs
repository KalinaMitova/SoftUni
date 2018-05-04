public class Knife : Weapon, IWeapon
{
    private const int DefaultMinimumDamage = 3;
    private const int DefaultMaximumDamage = 4;
    private const int DefaultSocketSize = 2;

    public Knife(string name, RarityLevelEnum rarityLevel) 
        : base(name, DefaultMinimumDamage, DefaultMaximumDamage, DefaultSocketSize, rarityLevel)
    {
    }
}