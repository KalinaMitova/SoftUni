public class Citizen : IPerson, IResident
{
    public Citizen(string name, string county, int age)
    {
        this.Name = name;
        this.Country = county;
        this.Age = age;
    }

    public string Name { get; set; }

    public string Country { get; set; }

    public int Age { get; set; }

    string IPerson.GetName()
    {
        return this.Name;
    }

    string IResident.GetName()
    {
        return $"Mr/Ms/Mrs {this.Name}";
    }
}