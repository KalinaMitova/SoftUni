using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> people;

    public List<Person> People
    {
        get { return people; }
        set { people = value; }
    }

    public Family()
    {
        people = new List<Person>();
    }

    public void AddMember(Person member)
    {
        people.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.People.OrderByDescending(a => a.Age).First();
    }
}