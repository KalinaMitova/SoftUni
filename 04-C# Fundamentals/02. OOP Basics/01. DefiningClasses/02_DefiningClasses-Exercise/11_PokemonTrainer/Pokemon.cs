public class Pokemon
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string element;

    public string Element
    {
        get { return element; }
        set { element = value; }
    }

    private decimal health;

    public decimal Health
    {
        get { return health; }
        set { health = value; }
    }

    public Pokemon(string name, string element, decimal health)
    {
        this.Name = name;
        this.Element = element;
        this.Health = health;
    }
}