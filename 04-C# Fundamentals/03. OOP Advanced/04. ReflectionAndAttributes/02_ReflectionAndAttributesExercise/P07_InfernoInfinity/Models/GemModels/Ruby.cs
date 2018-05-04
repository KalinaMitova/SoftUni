public class Ruby : Gem, IGem
{
    private const int DefaultStrength = 7;
    private const int DefaultAgility = 2;
    private const int DefaultVitality = 5;

    public Ruby(ClarityLevelEnum clarityLevel) 
        : base(DefaultStrength, DefaultAgility, DefaultVitality, clarityLevel)
    {
    }
}