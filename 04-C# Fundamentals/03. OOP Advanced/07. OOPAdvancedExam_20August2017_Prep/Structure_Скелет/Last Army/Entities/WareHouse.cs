using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private IDictionary<string, int> ammunitions;
    private IAmmunitionFactory ammunitionFactory;

    public WareHouse()
    {
        this.ammunitions = new Dictionary<string, int>();
        this.ammunitionFactory = new AmmunitionFactory();
    }

    public IDictionary<string, int> Ammunitions => this.ammunitions;

    public void AddAmmunition(string ammunition, int quantity)
    {
        if (this.ammunitions.ContainsKey(ammunition))
        {
            this.ammunitions[ammunition] += quantity;
        }
        else
        {
            this.ammunitions.Add(ammunition, quantity);
        }
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        var missingWeapons = soldier.Weapons.Where(w => w.Value == null).Select(w => w.Key).ToList();

        bool isSoldierEquiped = true;
        foreach (var WeaponName in missingWeapons)
        {
            if(this.ammunitions.ContainsKey(WeaponName) && this.ammunitions[WeaponName] > 0)
            {
                soldier.Weapons[WeaponName] = this.ammunitionFactory.CreateAmmunition(WeaponName);
                this.Ammunitions[WeaponName]--;
            }
            else
            {
                isSoldierEquiped = false;
            }
        }
        return isSoldierEquiped;
    }
}