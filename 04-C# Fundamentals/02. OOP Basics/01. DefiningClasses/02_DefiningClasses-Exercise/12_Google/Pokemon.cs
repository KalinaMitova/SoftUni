public class Pokemon
{
    private string name;
    private string type;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public Pokemon(string name, string type)
    {
        this.Name = name;
        this.Type = type;
    }
}