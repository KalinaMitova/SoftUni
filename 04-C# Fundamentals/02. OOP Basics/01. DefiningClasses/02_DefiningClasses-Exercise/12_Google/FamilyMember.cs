public class FamilyMember
{
    private string name;
    private string birthday;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Birthday
    {
        get { return birthday; }
        set { birthday = value; }
    }

    public FamilyMember(string name, string birthday)
    {
        this.Name = name;
        this.Birthday = birthday;
    }
}