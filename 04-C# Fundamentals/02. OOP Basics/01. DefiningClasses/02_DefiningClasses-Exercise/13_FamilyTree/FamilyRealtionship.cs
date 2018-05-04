public class FamilyRealtionship
{
    private Person parent;
    private Person children;

    public Person Parent
    {
        get { return parent; }
        set { parent = value; }
    }

    public Person Children
    {
        get { return children; }
        set { children = value; }
    }

    public FamilyRealtionship(Person parent, Person children)
    {
        Parent = parent;
        Children = children;
    }
}