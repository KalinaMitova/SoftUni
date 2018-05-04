public abstract class Person : IBuyer
{
    public string Name { get; set; }

    public int Age { get; set; }

    public int Food { get; set; }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
        this.Food = 0;
    }

    public abstract void BuyFood();
}