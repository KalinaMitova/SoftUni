public class Siamese : Cat
{
    private int earSize;

    public int EarSize
    {
        get { return earSize; }
        set { earSize = value; }
    }

    public Siamese(string breed, string name, int earSize)
        :base(breed, name)
    {
        this.EarSize = earSize;
    }

    public override string ToString()
    {
        return $"{this.Breed} {this.Name} {this.EarSize}";
    }
}