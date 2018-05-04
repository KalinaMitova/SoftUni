using System.Collections.Generic;

public class SpecialForce : Soldier
{    
    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    private readonly List<string> weaponsAllowed = new List<string>
    {
        "Gun",
        "AutomaticMachine",
        "MachineGun",
        "RPG",
        "Helmet",
        "Knife",
        "NightVision"
    };

    protected override double OverallSkillMiltiplier => 3.5;

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;

    protected override double RegenerationBonus => 30;
}