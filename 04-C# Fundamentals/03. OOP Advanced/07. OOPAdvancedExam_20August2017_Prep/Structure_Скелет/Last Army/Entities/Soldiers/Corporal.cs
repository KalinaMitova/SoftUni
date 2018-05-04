using System.Collections.Generic;

public class Corporal : Soldier
{
    public Corporal(string name, int age, double experience, double endurance) : base(name, age, experience, endurance)
    {
    }

    private readonly List<string> weaponsAllowed = new List<string>
    {
        "Gun",
        "AutomaticMachine",
        "MachineGun",
        "Helmet",
        "Knife"
    };

    protected override double OverallSkillMiltiplier => 2.5;

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;

    protected override double RegenerationBonus => 10;
}