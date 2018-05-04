public class StreetExtraordinaire : Cat
{
    private int decibelsOfMeows;

    public int DecibelsOfMeows
    {
        get { return decibelsOfMeows; }
        set { decibelsOfMeows = value; }
    }

    public StreetExtraordinaire(string breed, string name, int decibelsOfMeows)
        : base(breed, name)
    {
        this.DecibelsOfMeows = decibelsOfMeows;
    }

    public override string ToString()
    {
        return $"{this.Breed} {this.Name} {this.DecibelsOfMeows}";
    }
}