using System.Collections.Generic;

public class Ranker : Soldier
{
    public Ranker(string name, int age, double experience, double endurance) 
        : base(name, age, experience, endurance)
    {
    }

    private readonly List<string> weaponsAllowed = new List<string>
    {
        "Gun",
        "AutomaticMachine",
        "Helmet"
    };

    protected override double OverallSkillMiltiplier => 1.5;

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;

    protected override double RegenerationBonus => 10;
}