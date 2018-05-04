public class SpecialisedSoldier : Private, ISoldier, IPrivate, ISpecialisedSoldier
{
    private CorpsEnum corps;

    public CorpsEnum Corps
    {
        get
        {
            return this.corps;
        }
        set
        {
            this.corps = value;
        }
    }

    public SpecialisedSoldier(string id, string firstName, string lastName, double salary, CorpsEnum corps)
        : base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}