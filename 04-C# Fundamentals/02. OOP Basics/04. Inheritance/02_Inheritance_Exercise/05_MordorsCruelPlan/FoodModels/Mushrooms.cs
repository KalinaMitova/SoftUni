public class Mushrooms : Food
{
    public override int Hapiness => -10;
    
    public Mushrooms(string name) : base(name) { }
}