using System;

public class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
        :base(id, firstName, lastName, salary)
    {
        ParseCorps(corps);
    }

    private void ParseCorps(string corps)
    {
        bool validCorps = Enum.TryParse<CorpsEnum>(corps, out CorpsEnum corpsEnum);

        if (!validCorps)
        {
            throw new ArgumentException("Invalid corps!");
        }
        this.Corps = corpsEnum;
    }

    public CorpsEnum Corps { get; private set; }
}