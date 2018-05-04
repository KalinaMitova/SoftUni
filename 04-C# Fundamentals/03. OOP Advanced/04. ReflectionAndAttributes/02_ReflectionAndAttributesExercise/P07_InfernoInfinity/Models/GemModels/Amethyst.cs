public class Amethyst : Gem, IGem
{
    private const int DefaultStrength = 2;
    private const int DefaultAgility = 8;
    private const int DefaultVitality = 4;

    public Amethyst(ClarityLevelEnum clarityLevel) 
        : base(DefaultStrength, DefaultAgility, DefaultVitality, clarityLevel)
    {
    }
}
