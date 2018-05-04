public class Food
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    
    public virtual int Hapiness => -1;

    public Food(string name)
    {
        this.Name = name;
    }
}