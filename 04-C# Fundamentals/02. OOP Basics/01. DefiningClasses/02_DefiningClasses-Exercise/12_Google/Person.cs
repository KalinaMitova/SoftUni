using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private Company company;
    private List<Pokemon> pokemons;
    private List<FamilyMember> parents;
    private List<FamilyMember> childrens;
    private Car car;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Company Company
    {
        get { return company; }
        set { company = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    }

    public List<FamilyMember> Parents
    {
        get { return parents; }
        set { parents = value; }
    }

    public List<FamilyMember> Childrens
    {
        get { return childrens; }
        set { childrens = value; }
    }
    
    public Car Car
    {
        get { return car; }
        set { car = value; }
    }

    public Person(string name)
    {
        this.Name = name;
        this.Pokemons = new List<Pokemon>();
        this.Parents = new List<FamilyMember>();
        this.Childrens = new List<FamilyMember>();
    }

    public override string ToString()
    {
        var output = new StringBuilder();

        output.AppendLine(this.name);

        output.AppendLine("Company:");
        if(this.Company != null)
        {
            output.AppendLine($"{this.Company.Name} {this.Company.Department} {this.Company.Salary:F2}");
        }

        output.AppendLine("Car:");
        if(this.Car != null)
        {
            output.AppendLine($"{this.Car.Model} {this.Car.Speed}");
        }

        output.AppendLine("Pokemon:");
        foreach (var pokemon in this.Pokemons)
        {
            output.AppendLine($"{pokemon.Name} {pokemon.Type}");
        }

        output.AppendLine("Parents:");
        foreach (var parent in this.Parents)
        {
            output.AppendLine($"{parent.Name} {parent.Birthday}");
        }

        output.AppendLine("Children:");
        foreach (var cildren in this.Childrens)
        {
            output.AppendLine($"{cildren.Name} {cildren.Birthday}");
        }

        return output.ToString().TrimEnd();
    }
}