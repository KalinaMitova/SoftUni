using System.Collections.Generic;

public class WeaponRepository : IRepository, IAddable
{
    ICollection<IWeapon> weapons;

    public WeaponRepository()
    {
        this.weapons = new List<IWeapon>();
    }

    public IReadOnlyCollection<IWeapon> Weapons
    {
        get
        {
            return (IReadOnlyCollection<IWeapon>)this.weapons;
        }
    }

    public void Add(IWeapon weapon)
    {
        this.weapons.Add(weapon);
    }
}