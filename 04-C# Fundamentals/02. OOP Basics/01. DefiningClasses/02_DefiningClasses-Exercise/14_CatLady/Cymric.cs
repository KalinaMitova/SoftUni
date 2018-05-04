public class Cymric : Cat
{
    private double furLength;

    public double FurLength
    {
        get { return furLength; }
        set { furLength = value; }
    }

    public Cymric(string breed, string name, double furLength)
        : base(breed, name)
    {
        this.FurLength = furLength;
    }

    public override string ToString()
    {
        return $"{this.Breed} {this.Name} {this.FurLength:F2}";
    }
}