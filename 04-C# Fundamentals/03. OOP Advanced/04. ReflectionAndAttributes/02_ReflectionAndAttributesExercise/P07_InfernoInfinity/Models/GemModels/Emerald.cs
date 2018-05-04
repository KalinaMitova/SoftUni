public class Emerald : Gem, IGem
{
    private const int DefaultStrength = 1;
    private const int DefaultAgility = 4;
    private const int DefaultVitality = 9;

    public Emerald(ClarityLevelEnum clarityLevel)
        : base(DefaultStrength, DefaultAgility, DefaultVitality, clarityLevel)
    {
    }
}