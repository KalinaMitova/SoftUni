public abstract class Gem : IGem
{
    public Gem(int strength, int agility, int vitality, ClarityLevelEnum clarityLevel)
    {
        this.ClarityLevel = clarityLevel;

        this.Strength = strength + (int)this.ClarityLevel;
        this.Agility = agility + (int)this.ClarityLevel;
        this.Vitality = vitality + (int)this.ClarityLevel;
    }

    public int Strength { get; private set; }

    public int Agility { get; private set; }

    public int Vitality { get; private set; }

    public ClarityLevelEnum ClarityLevel { get; private set; }
}
