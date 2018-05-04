using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    //private double endurance;

    //public IDictionary<string, IAmmunition> Weapons { get; }

    //protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    //public bool ReadyForMission(IMission mission)
    //{
    //    if (this.Endurance < mission.EnduranceRequired)
    //    {
    //        return false;
    //    }

    //    bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

    //    if (!hasAllEquipment)
    //    {
    //        return false;
    //    }

    //    return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    //}

    //

    //public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);

    private const double MaxEndurance = 100;

    protected abstract double OverallSkillMiltiplier { get; }

    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    protected abstract double RegenerationBonus { get; }

    private double endurance;

    public Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = new Dictionary<string, IAmmunition>();
        foreach (var weapon in this.WeaponsAllowed)
        {
            this.Weapons.Add(weapon, null);
        }
    }

    public string Name { get; }

    public int Age { get; }

    public double Experience { get; private set; }

    public double Endurance
    {
        get
        {
            return this.endurance;
        }
        private set
        {
            this.endurance = Math.Min(value, MaxEndurance);
        }
    }
    
    public double OverallSkill => (this.Age + this.Experience) * OverallSkillMiltiplier;
    
    public IDictionary<string, IAmmunition> Weapons { get; }

    public void CompleteMission(IMission mission)
    {
        this.Endurance -= mission.EnduranceRequired;
        this.Experience += mission.EnduranceRequired;
        AmmunitionRevision(mission.WearLevelDecrement);
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.All(weapon => weapon != null);

        if (!hasAllEquipment)
        {
            return false;
        }

        return !this.Weapons.Values.Any(weapon => weapon.WearLevel <= 0);
    }

    public void Regenerate()
    {
        this.Endurance += this.Age + this.RegenerationBonus;
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
}