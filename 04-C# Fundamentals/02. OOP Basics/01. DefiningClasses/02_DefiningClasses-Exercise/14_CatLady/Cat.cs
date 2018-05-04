public abstract class Cat
{
    private string breed;
    private string name;

    public string Breed
    {
        get { return breed; }
        set { breed = value; }
    }
    
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Cat(string breed, string name)
    {
        this.Breed = breed;
        this.Name = name;
    }
}