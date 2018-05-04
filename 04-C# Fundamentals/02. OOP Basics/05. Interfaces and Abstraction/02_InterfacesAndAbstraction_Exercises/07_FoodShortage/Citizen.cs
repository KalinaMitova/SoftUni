public class Citizen : Person, IIdentifiable, IBirthable, IBuyer
{
    public string Id { get; set; }

    public string Birthdate { get; set; }
    
    public Citizen(string name, int age, string id, string birthdate)
        :base(name, age)
    {
        this.Id = id;
        this.Birthdate = birthdate;
    }

    public override void BuyFood()
    {
        this.Food += 10;
    }
}